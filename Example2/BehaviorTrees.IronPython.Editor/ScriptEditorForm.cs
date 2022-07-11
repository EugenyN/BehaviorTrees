// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System;
using System.Windows.Forms;

namespace BehaviorTrees.IronPython.Editor
{
	public partial class ScriptEditorForm : Form
	{
		public ScriptEditorForm()
		{
			InitializeComponent();
			scriptEditorControl.EditorClosing += new EventHandler(ScriptEditorControl_EditorClosing);
			scriptEditorControl.ScriptLoaded += new EventHandler(ScriptEditorControl_DataLoaded);
		}

		public ScriptEditorForm(PythonScript data)
			: this()
		{
			scriptEditorControl.LoadData(data);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
					components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void ScriptEditorControl_EditorClosing(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void ScriptEditorControl_DataLoaded(object sender, EventArgs e)
		{
			UpdateCaption();
		}

		private void ScriptEditorForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					scriptEditorControl.ExecuteScript();
					break;
			}
		}

		private void UpdateCaption()
		{
			UpdateCaption(scriptEditorControl.Script);
		}

		private void UpdateCaption(PythonScript data)
		{
			Text = "Script Editor - [ " + data.Name + " ]";
		}
	}
}
