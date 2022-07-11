// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace BehaviorTrees.IronPython.Editor
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

			var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (edSvc == null)
				return null;

			string text = (string)Convert.ChangeType(value, context.PropertyDescriptor.PropertyType);

			var script = new PythonScript(text);
			using (var form = new ScriptEditorForm(script))
			{
				if (edSvc.ShowDialog(form) == DialogResult.OK)
					return script.Text;
			}

			return value;
		}
	}
}
