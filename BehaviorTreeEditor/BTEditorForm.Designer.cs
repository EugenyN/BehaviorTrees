namespace BehaviorTreesEditor
{
	partial class BTEditorForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTEditorForm));
			scriptEditorControl = new BTEditorControl();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// scriptEditorControl
			// 
			scriptEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
			scriptEditorControl.Location = new System.Drawing.Point(0, 0);
			scriptEditorControl.Name = "scriptEditorControl";
			scriptEditorControl.Size = new System.Drawing.Size(819, 502);
			scriptEditorControl.TabIndex = 0;
			// 
			// statusStrip1
			// 
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel });
			statusStrip1.Location = new System.Drawing.Point(0, 502);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(819, 22);
			statusStrip1.TabIndex = 1;
			statusStrip1.Text = "statusStrip1";
			// 
			// statusLabel
			// 
			statusLabel.Name = "statusLabel";
			statusLabel.Size = new System.Drawing.Size(66, 17);
			statusLabel.Text = "statusLabel";
			// 
			// BTEditorForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(819, 524);
			Controls.Add(scriptEditorControl);
			Controls.Add(statusStrip1);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			KeyPreview = true;
			Name = "BTEditorForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Behavior Tree Editor";
			KeyDown += BTEditorForm_KeyDown;
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		private BTEditorControl scriptEditorControl;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
	}
}