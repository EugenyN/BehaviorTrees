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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptEditorControl));
			codeEditorCMS = new System.Windows.Forms.ContextMenuStrip(components);
			cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			saveTSButton = new System.Windows.Forms.ToolStripSplitButton();
			saveAndCloseTSButton = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			cutTSButton = new System.Windows.Forms.ToolStripButton();
			copyTSButton = new System.Windows.Forms.ToolStripButton();
			pasteTSButton = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			undoTSButton = new System.Windows.Forms.ToolStripButton();
			redoTSButton = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			executeTSButton = new System.Windows.Forms.ToolStripButton();
			outputTextBox = new System.Windows.Forms.TextBox();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			pythonTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
			codeEditorCMS.SuspendLayout();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pythonTextbox).BeginInit();
			SuspendLayout();
			// 
			// codeEditorCMS
			// 
			codeEditorCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem, toolStripMenuItem1, selectAllToolStripMenuItem, toolStripMenuItem2, executeToolStripMenuItem });
			codeEditorCMS.Name = "codeEditorCMS";
			codeEditorCMS.Size = new System.Drawing.Size(123, 148);
			// 
			// cutToolStripMenuItem
			// 
			cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			cutToolStripMenuItem.Text = "Cut";
			cutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
			// 
			// copyToolStripMenuItem
			// 
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			copyToolStripMenuItem.Text = "Copy";
			copyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
			// 
			// pasteToolStripMenuItem
			// 
			pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			pasteToolStripMenuItem.Text = "Paste";
			pasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click;
			// 
			// deleteToolStripMenuItem
			// 
			deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			deleteToolStripMenuItem.Text = "Delete";
			deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			selectAllToolStripMenuItem.Text = "Select All";
			selectAllToolStripMenuItem.Click += SelectAllToolStripMenuItem_Click;
			// 
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(119, 6);
			// 
			// executeToolStripMenuItem
			// 
			executeToolStripMenuItem.Name = "executeToolStripMenuItem";
			executeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			executeToolStripMenuItem.Text = "Execute";
			executeToolStripMenuItem.Click += ExecuteToolStripMenuItem_Click;
			// 
			// toolStrip1
			// 
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { saveTSButton, toolStripSeparator1, cutTSButton, copyTSButton, pasteTSButton, toolStripSeparator2, undoTSButton, redoTSButton, toolStripSeparator3, executeTSButton });
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new System.Drawing.Size(649, 25);
			toolStrip1.TabIndex = 10;
			toolStrip1.Text = "toolStrip1";
			// 
			// saveTSButton
			// 
			saveTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			saveTSButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveAndCloseTSButton });
			saveTSButton.Image = (System.Drawing.Image)resources.GetObject("saveTSButton.Image");
			saveTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			saveTSButton.Name = "saveTSButton";
			saveTSButton.Size = new System.Drawing.Size(32, 22);
			saveTSButton.Text = "Save";
			saveTSButton.ToolTipText = "Save script";
			saveTSButton.Click += SaveTSButton_Click;
			// 
			// saveAndCloseTSButton
			// 
			saveAndCloseTSButton.Image = (System.Drawing.Image)resources.GetObject("saveAndCloseTSButton.Image");
			saveAndCloseTSButton.Name = "saveAndCloseTSButton";
			saveAndCloseTSButton.Size = new System.Drawing.Size(153, 22);
			saveAndCloseTSButton.Text = "Save and Close";
			saveAndCloseTSButton.Click += SaveAndCloseTSButton_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// cutTSButton
			// 
			cutTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			cutTSButton.Image = (System.Drawing.Image)resources.GetObject("cutTSButton.Image");
			cutTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			cutTSButton.Name = "cutTSButton";
			cutTSButton.Size = new System.Drawing.Size(23, 22);
			cutTSButton.Text = "toolStripButton2";
			cutTSButton.ToolTipText = "Cut";
			cutTSButton.Click += CutTSButton_Click;
			// 
			// copyTSButton
			// 
			copyTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			copyTSButton.Image = (System.Drawing.Image)resources.GetObject("copyTSButton.Image");
			copyTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			copyTSButton.Name = "copyTSButton";
			copyTSButton.Size = new System.Drawing.Size(23, 22);
			copyTSButton.Text = "toolStripButton3";
			copyTSButton.ToolTipText = "Copy";
			copyTSButton.Click += CopyTSButton_Click;
			// 
			// pasteTSButton
			// 
			pasteTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			pasteTSButton.Image = (System.Drawing.Image)resources.GetObject("pasteTSButton.Image");
			pasteTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			pasteTSButton.Name = "pasteTSButton";
			pasteTSButton.Size = new System.Drawing.Size(23, 22);
			pasteTSButton.Text = "toolStripButton4";
			pasteTSButton.ToolTipText = "Paste";
			pasteTSButton.Click += PasteTSButton_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// undoTSButton
			// 
			undoTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			undoTSButton.Image = (System.Drawing.Image)resources.GetObject("undoTSButton.Image");
			undoTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			undoTSButton.Name = "undoTSButton";
			undoTSButton.Size = new System.Drawing.Size(23, 22);
			undoTSButton.Text = "toolStripButton2";
			undoTSButton.ToolTipText = "Undo";
			undoTSButton.Click += UndoTSButton_Click;
			// 
			// redoTSButton
			// 
			redoTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			redoTSButton.Image = (System.Drawing.Image)resources.GetObject("redoTSButton.Image");
			redoTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			redoTSButton.Name = "redoTSButton";
			redoTSButton.Size = new System.Drawing.Size(23, 22);
			redoTSButton.Text = "toolStripButton1";
			redoTSButton.ToolTipText = "Redo";
			redoTSButton.Click += RedoTSButton_Click;
			// 
			// toolStripSeparator3
			// 
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// executeTSButton
			// 
			executeTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			executeTSButton.Image = (System.Drawing.Image)resources.GetObject("executeTSButton.Image");
			executeTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			executeTSButton.Name = "executeTSButton";
			executeTSButton.Size = new System.Drawing.Size(23, 22);
			executeTSButton.Text = "toolStripButton5";
			executeTSButton.ToolTipText = "Execute (F5)";
			executeTSButton.Click += ExecuteTSButton_Click;
			// 
			// outputTextBox
			// 
			outputTextBox.BackColor = System.Drawing.SystemColors.Window;
			outputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			outputTextBox.Font = new System.Drawing.Font("Courier New", 8.25F);
			outputTextBox.Location = new System.Drawing.Point(0, 0);
			outputTextBox.Multiline = true;
			outputTextBox.Name = "outputTextBox";
			outputTextBox.ReadOnly = true;
			outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			outputTextBox.Size = new System.Drawing.Size(649, 102);
			outputTextBox.TabIndex = 0;
			// 
			// splitContainer1
			// 
			splitContainer1.BackColor = System.Drawing.SystemColors.Control;
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.Location = new System.Drawing.Point(0, 25);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(pythonTextbox);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(outputTextBox);
			splitContainer1.Size = new System.Drawing.Size(649, 292);
			splitContainer1.SplitterDistance = 186;
			splitContainer1.TabIndex = 11;
			// 
			// pythonTextbox
			// 
			pythonTextbox.AutoCompleteBracketsList = new char[]
	{
	'(',
	')',
	'{',
	'}',
	'[',
	']',
	'"',
	'"',
	'\'',
	'\''
	};
			pythonTextbox.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
			pythonTextbox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
			pythonTextbox.BackBrush = null;
			pythonTextbox.CharHeight = 14;
			pythonTextbox.CharWidth = 8;
			pythonTextbox.ContextMenuStrip = codeEditorCMS;
			pythonTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			pythonTextbox.DefaultMarkerSize = 8;
			pythonTextbox.DisabledColor = System.Drawing.Color.FromArgb(100, 180, 180, 180);
			pythonTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			pythonTextbox.FindForm = null;
			pythonTextbox.Font = new System.Drawing.Font("Courier New", 9.75F);
			pythonTextbox.GoToForm = null;
			//pythonTextbox.Hotkeys = resources.GetString("pythonTextbox.Hotkeys");
			pythonTextbox.IsReplaceMode = false;
			pythonTextbox.Location = new System.Drawing.Point(0, 0);
			pythonTextbox.Name = "pythonTextbox";
			pythonTextbox.Paddings = new System.Windows.Forms.Padding(0);
			pythonTextbox.ReplaceForm = null;
			pythonTextbox.SelectionColor = System.Drawing.Color.FromArgb(60, 0, 0, 255);
			pythonTextbox.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("pythonTextbox.ServiceColors");
			pythonTextbox.Size = new System.Drawing.Size(649, 186);
			pythonTextbox.TabIndex = 3;
			pythonTextbox.Zoom = 100;
			pythonTextbox.TextChanged += PythonTextbox_TextChanged;
			pythonTextbox.AutoIndentNeeded += PythonTextbox_AutoIndentNeeded;
			// 
			// ScriptEditorControl
			// 
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			Controls.Add(splitContainer1);
			Controls.Add(toolStrip1);
			Name = "ScriptEditorControl";
			Size = new System.Drawing.Size(649, 317);
			codeEditorCMS.ResumeLayout(false);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pythonTextbox).EndInit();
			ResumeLayout(false);
			PerformLayout();

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
