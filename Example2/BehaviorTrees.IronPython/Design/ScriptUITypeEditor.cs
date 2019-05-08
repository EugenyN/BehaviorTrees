// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace BehaviorTrees.IronPython.Design
{

	/// <summary>
	/// 
	/// </summary>
	public class ScriptUITypeEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context == null || context.Instance == null)
				return base.GetEditStyle(context);

			return UITypeEditorEditStyle.Modal;
		}

		public override bool IsDropDownResizable
		{
			get { return true; }
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context == null || context.Instance == null || provider == null)
				return value;

			string text = (string)Convert.ChangeType(value, context.PropertyDescriptor.PropertyType);

			// dependency inversion
			var scriptEditorService = MefComposer.GetExportedValue<IScriptEditorService>();
			if (scriptEditorService != null) {
				var script = new PythonScript(text);
				scriptEditorService.ShowEditor(script, context);
				return script.Text;
			}

			return text;
		}
	}
}
