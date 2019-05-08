// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.IronPython;
using BehaviorTrees.IronPython.Design;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace IronPythonEditor
{
	[Export(typeof(IScriptEditorService))]
	public class ScriptEditorService : IScriptEditorService
	{
		public void ShowEditor(PythonScript data, ITypeDescriptorContext context)
		{
			var editor = new ScriptEditorForm(data);
			editor.ShowDialog(null);
		}
	}
}
