namespace BehaviorTrees.IronPython.Editor
{
	partial class ScriptEditorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			scriptEditorControl = new ScriptEditorControl();
			SuspendLayout();
			// 
			// scriptEditorControl
			// 
			scriptEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
			scriptEditorControl.Location = new System.Drawing.Point(0, 0);
			scriptEditorControl.Name = "scriptEditorControl";
			scriptEditorControl.Size = new System.Drawing.Size(604, 325);
			scriptEditorControl.TabIndex = 0;
			// 
			// ScriptEditorForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(604, 325);
			Controls.Add(scriptEditorControl);
			KeyPreview = true;
			Name = "ScriptEditorForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Script Editor";
			KeyDown += ScriptEditorForm_KeyDown;
			ResumeLayout(false);

		}

		#endregion

		private ScriptEditorControl scriptEditorControl;
	}
}