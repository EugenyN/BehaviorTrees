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
            this.scriptEditorControl = new BehaviorTrees.IronPython.Editor.ScriptEditorControl();
            this.SuspendLayout();
            // 
            // scriptEditorControl
            // 
            this.scriptEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptEditorControl.Location = new System.Drawing.Point(0, 0);
            this.scriptEditorControl.Name = "scriptEditorControl";
            this.scriptEditorControl.Script = null;
            this.scriptEditorControl.Size = new System.Drawing.Size(604, 325);
            this.scriptEditorControl.TabIndex = 0;
            // 
            // ScriptEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(604, 325);
            this.Controls.Add(this.scriptEditorControl);
            this.KeyPreview = true;
            this.Name = "ScriptEditorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScriptEditorForm_KeyDown);
            this.ResumeLayout(false);

		}

		#endregion

		private ScriptEditorControl scriptEditorControl;
	}
}