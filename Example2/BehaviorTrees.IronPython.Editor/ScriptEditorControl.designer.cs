namespace BehaviorTrees.IronPython.Editor
{
	partial class ScriptEditorControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptEditorControl));
            this.codeEditorCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.saveTSButton = new System.Windows.Forms.ToolStripSplitButton();
            this.saveAndCloseTSButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutTSButton = new System.Windows.Forms.ToolStripButton();
            this.copyTSButton = new System.Windows.Forms.ToolStripButton();
            this.pasteTSButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoTSButton = new System.Windows.Forms.ToolStripButton();
            this.redoTSButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.executeTSButton = new System.Windows.Forms.ToolStripButton();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pythonTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.codeEditorCMS.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pythonTextbox)).BeginInit();
            this.SuspendLayout();
            // 
            // codeEditorCMS
            // 
            this.codeEditorCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.selectAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.executeToolStripMenuItem});
            this.codeEditorCMS.Name = "codeEditorCMS";
            this.codeEditorCMS.Size = new System.Drawing.Size(123, 148);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(119, 6);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.ExecuteToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTSButton,
            this.toolStripSeparator1,
            this.cutTSButton,
            this.copyTSButton,
            this.pasteTSButton,
            this.toolStripSeparator2,
            this.undoTSButton,
            this.redoTSButton,
            this.toolStripSeparator3,
            this.executeTSButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(649, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // saveTSButton
            // 
            this.saveTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveTSButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAndCloseTSButton});
            this.saveTSButton.Image = ((System.Drawing.Image)(resources.GetObject("saveTSButton.Image")));
            this.saveTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveTSButton.Name = "saveTSButton";
            this.saveTSButton.Size = new System.Drawing.Size(32, 22);
            this.saveTSButton.Text = "Save";
            this.saveTSButton.ToolTipText = "Save script";
            this.saveTSButton.Click += new System.EventHandler(this.SaveTSButton_Click);
            // 
            // saveAndCloseTSButton
            // 
            this.saveAndCloseTSButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAndCloseTSButton.Image")));
            this.saveAndCloseTSButton.Name = "saveAndCloseTSButton";
            this.saveAndCloseTSButton.Size = new System.Drawing.Size(180, 22);
            this.saveAndCloseTSButton.Text = "Save and Close";
            this.saveAndCloseTSButton.Click += new System.EventHandler(this.SaveAndCloseTSButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cutTSButton
            // 
            this.cutTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutTSButton.Image = ((System.Drawing.Image)(resources.GetObject("cutTSButton.Image")));
            this.cutTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutTSButton.Name = "cutTSButton";
            this.cutTSButton.Size = new System.Drawing.Size(23, 22);
            this.cutTSButton.Text = "toolStripButton2";
            this.cutTSButton.ToolTipText = "Cut";
            this.cutTSButton.Click += new System.EventHandler(this.CutTSButton_Click);
            // 
            // copyTSButton
            // 
            this.copyTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyTSButton.Image = ((System.Drawing.Image)(resources.GetObject("copyTSButton.Image")));
            this.copyTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyTSButton.Name = "copyTSButton";
            this.copyTSButton.Size = new System.Drawing.Size(23, 22);
            this.copyTSButton.Text = "toolStripButton3";
            this.copyTSButton.ToolTipText = "Copy";
            this.copyTSButton.Click += new System.EventHandler(this.CopyTSButton_Click);
            // 
            // pasteTSButton
            // 
            this.pasteTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteTSButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteTSButton.Image")));
            this.pasteTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteTSButton.Name = "pasteTSButton";
            this.pasteTSButton.Size = new System.Drawing.Size(23, 22);
            this.pasteTSButton.Text = "toolStripButton4";
            this.pasteTSButton.ToolTipText = "Paste";
            this.pasteTSButton.Click += new System.EventHandler(this.PasteTSButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // undoTSButton
            // 
            this.undoTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoTSButton.Image = ((System.Drawing.Image)(resources.GetObject("undoTSButton.Image")));
            this.undoTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoTSButton.Name = "undoTSButton";
            this.undoTSButton.Size = new System.Drawing.Size(23, 22);
            this.undoTSButton.Text = "toolStripButton2";
            this.undoTSButton.ToolTipText = "Undo";
            this.undoTSButton.Click += new System.EventHandler(this.UndoTSButton_Click);
            // 
            // redoTSButton
            // 
            this.redoTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoTSButton.Image = ((System.Drawing.Image)(resources.GetObject("redoTSButton.Image")));
            this.redoTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoTSButton.Name = "redoTSButton";
            this.redoTSButton.Size = new System.Drawing.Size(23, 22);
            this.redoTSButton.Text = "toolStripButton1";
            this.redoTSButton.ToolTipText = "Redo";
            this.redoTSButton.Click += new System.EventHandler(this.RedoTSButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // executeTSButton
            // 
            this.executeTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.executeTSButton.Image = ((System.Drawing.Image)(resources.GetObject("executeTSButton.Image")));
            this.executeTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.executeTSButton.Name = "executeTSButton";
            this.executeTSButton.Size = new System.Drawing.Size(23, 22);
            this.executeTSButton.Text = "toolStripButton5";
            this.executeTSButton.ToolTipText = "Execute (F5)";
            this.executeTSButton.Click += new System.EventHandler(this.ExecuteTSButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.outputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outputTextBox.Location = new System.Drawing.Point(0, 0);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(649, 102);
            this.outputTextBox.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pythonTextbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.outputTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(649, 292);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 11;
            // 
            // pythonTextbox
            // 
            this.pythonTextbox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.pythonTextbox.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.pythonTextbox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.pythonTextbox.BackBrush = null;
            this.pythonTextbox.CharHeight = 14;
            this.pythonTextbox.CharWidth = 8;
            this.pythonTextbox.ContextMenuStrip = this.codeEditorCMS;
            this.pythonTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pythonTextbox.DefaultMarkerSize = 8;
            this.pythonTextbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.pythonTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pythonTextbox.FindForm = null;
            this.pythonTextbox.GoToForm = null;
            this.pythonTextbox.Hotkeys = resources.GetString("pythonTextbox.Hotkeys");
            this.pythonTextbox.IsReplaceMode = false;
            this.pythonTextbox.Location = new System.Drawing.Point(0, 0);
            this.pythonTextbox.Name = "pythonTextbox";
            this.pythonTextbox.Paddings = new System.Windows.Forms.Padding(0);
            this.pythonTextbox.ReplaceForm = null;
            this.pythonTextbox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.pythonTextbox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("pythonTextbox.ServiceColors")));
            this.pythonTextbox.Size = new System.Drawing.Size(649, 186);
            this.pythonTextbox.TabIndex = 3;
            this.pythonTextbox.Zoom = 100;
            this.pythonTextbox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.PythonTextbox_TextChanged);
            this.pythonTextbox.AutoIndentNeeded += new System.EventHandler<FastColoredTextBoxNS.AutoIndentEventArgs>(this.PythonTextbox_AutoIndentNeeded);
            // 
            // ScriptEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ScriptEditorControl";
            this.Size = new System.Drawing.Size(649, 317);
            this.codeEditorCMS.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pythonTextbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton cutTSButton;
		private System.Windows.Forms.ToolStripButton copyTSButton;
		private System.Windows.Forms.ToolStripButton pasteTSButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton executeTSButton;
		private System.Windows.Forms.TextBox outputTextBox;
		private System.Windows.Forms.ToolStripButton undoTSButton;
		private System.Windows.Forms.ToolStripButton redoTSButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ContextMenuStrip codeEditorCMS;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private FastColoredTextBoxNS.FastColoredTextBox pythonTextbox;
		private System.Windows.Forms.ToolStripSplitButton saveTSButton;
		private System.Windows.Forms.ToolStripMenuItem saveAndCloseTSButton;
	}
}
