namespace BehaviorTreesEditor
{
	partial class BTEditorControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTEditorControl));
			CommonTools.TreeListColumn treeListColumn1 = new CommonTools.TreeListColumn("Name", "Name");
			CommonTools.TreeListColumn treeListColumn2 = new CommonTools.TreeListColumn("Type", "Type");
			CommonTools.TreeListColumn treeListColumn3 = new CommonTools.TreeListColumn("Parameters", "Parameters");
			behaviorTreeCMS = new System.Windows.Forms.ContextMenuStrip(components);
			executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			newTSButton = new System.Windows.Forms.ToolStripButton();
			loadTSButton = new System.Windows.Forms.ToolStripButton();
			saveTSButton = new System.Windows.Forms.ToolStripSplitButton();
			saveAsTSButton = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			executeTSButton = new System.Windows.Forms.ToolStripButton();
			stopTSButton = new System.Windows.Forms.ToolStripButton();
			entityComboBox = new System.Windows.Forms.ToolStripComboBox();
			behaviorTreeImageList = new System.Windows.Forms.ImageList(components);
			propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			behaviorTreeTL = new CommonTools.TreeListView();
			behaviorTreeCMS.SuspendLayout();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)behaviorTreeTL).BeginInit();
			SuspendLayout();
			// 
			// behaviorTreeCMS
			// 
			behaviorTreeCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { executeToolStripMenuItem });
			behaviorTreeCMS.Name = "btEditorCMS";
			behaviorTreeCMS.Size = new System.Drawing.Size(115, 26);
			// 
			// executeToolStripMenuItem
			// 
			executeToolStripMenuItem.Name = "executeToolStripMenuItem";
			executeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			executeToolStripMenuItem.Text = "Execute";
			executeToolStripMenuItem.Click += ExecuteToolStripMenuItem_Click;
			// 
			// toolStrip1
			// 
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { newTSButton, loadTSButton, saveTSButton, toolStripSeparator1, executeTSButton, stopTSButton, entityComboBox });
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new System.Drawing.Size(809, 25);
			toolStrip1.TabIndex = 10;
			toolStrip1.Text = "toolStrip1";
			// 
			// newTSButton
			// 
			newTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			newTSButton.Image = (System.Drawing.Image)resources.GetObject("newTSButton.Image");
			newTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			newTSButton.Name = "newTSButton";
			newTSButton.Size = new System.Drawing.Size(23, 22);
			newTSButton.Text = "New";
			newTSButton.Click += NewTSButton_Click;
			// 
			// loadTSButton
			// 
			loadTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			loadTSButton.Image = (System.Drawing.Image)resources.GetObject("loadTSButton.Image");
			loadTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			loadTSButton.Name = "loadTSButton";
			loadTSButton.Size = new System.Drawing.Size(23, 22);
			loadTSButton.Text = "Load";
			loadTSButton.Click += LoadTSButton_Click;
			// 
			// saveTSButton
			// 
			saveTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			saveTSButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveAsTSButton });
			saveTSButton.Image = (System.Drawing.Image)resources.GetObject("saveTSButton.Image");
			saveTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			saveTSButton.Name = "saveTSButton";
			saveTSButton.Size = new System.Drawing.Size(32, 22);
			saveTSButton.Text = "Save";
			saveTSButton.ButtonClick += SaveTSButton_ButtonClick;
			// 
			// saveAsTSButton
			// 
			saveAsTSButton.Image = (System.Drawing.Image)resources.GetObject("saveAsTSButton.Image");
			saveAsTSButton.Name = "saveAsTSButton";
			saveAsTSButton.Size = new System.Drawing.Size(114, 22);
			saveAsTSButton.Text = "Save As";
			saveAsTSButton.Click += SaveAsTSButton_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
			executeTSButton.Click += executeTSButton_Click;
			// 
			// stopTSButton
			// 
			stopTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			stopTSButton.Image = (System.Drawing.Image)resources.GetObject("stopTSButton.Image");
			stopTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			stopTSButton.Name = "stopTSButton";
			stopTSButton.Size = new System.Drawing.Size(23, 22);
			stopTSButton.Text = "toolStripButton1";
			stopTSButton.ToolTipText = "Stop";
			stopTSButton.Click += stopTSButton_Click;
			// 
			// entityComboBox
			// 
			entityComboBox.Name = "entityComboBox";
			entityComboBox.Size = new System.Drawing.Size(200, 25);
			// 
			// behaviorTreeImageList
			// 
			behaviorTreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			behaviorTreeImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("behaviorTreeImageList.ImageStream");
			behaviorTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
			behaviorTreeImageList.Images.SetKeyName(0, "action.png");
			behaviorTreeImageList.Images.SetKeyName(1, "composite.png");
			behaviorTreeImageList.Images.SetKeyName(2, "condition.png");
			behaviorTreeImageList.Images.SetKeyName(3, "decorator.png");
			behaviorTreeImageList.Images.SetKeyName(4, "trigger.png");
			// 
			// propertyGrid1
			// 
			propertyGrid1.BackColor = System.Drawing.SystemColors.Control;
			propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			propertyGrid1.Location = new System.Drawing.Point(0, 0);
			propertyGrid1.Name = "propertyGrid1";
			propertyGrid1.Size = new System.Drawing.Size(227, 526);
			propertyGrid1.TabIndex = 20;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.Location = new System.Drawing.Point(0, 25);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(behaviorTreeTL);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(propertyGrid1);
			splitContainer1.Size = new System.Drawing.Size(809, 526);
			splitContainer1.SplitterDistance = 578;
			splitContainer1.TabIndex = 21;
			// 
			// behaviorTreeTL
			// 
			behaviorTreeTL.AllowDrop = true;
			treeListColumn1.AutoSizeMinSize = 0;
			treeListColumn1.VisibleIndex = 0;
			treeListColumn1.Width = 270;
			treeListColumn2.AutoSizeMinSize = 0;
			treeListColumn2.VisibleIndex = 1;
			treeListColumn2.Width = 90;
			treeListColumn3.AutoSizeMinSize = 0;
			treeListColumn3.VisibleIndex = 2;
			treeListColumn3.Width = 150;
			behaviorTreeTL.Columns.AddRange(new CommonTools.TreeListColumn[] { treeListColumn1, treeListColumn2, treeListColumn3 });
			behaviorTreeTL.ContextMenuStrip = behaviorTreeCMS;
			behaviorTreeTL.Cursor = System.Windows.Forms.Cursors.VSplit;
			behaviorTreeTL.Dock = System.Windows.Forms.DockStyle.Fill;
			behaviorTreeTL.Images = behaviorTreeImageList;
			behaviorTreeTL.Location = new System.Drawing.Point(0, 0);
			behaviorTreeTL.Name = "behaviorTreeTL";
			behaviorTreeTL.RowOptions.ItemHeight = 26;
			behaviorTreeTL.Size = new System.Drawing.Size(578, 526);
			behaviorTreeTL.TabIndex = 19;
			behaviorTreeTL.AfterSelect += BehaviorTreeTL_AfterSelect;
			behaviorTreeTL.MouseUp += BehaviorTreeTL_MouseUp;
			// 
			// BTEditorControl
			// 
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			Controls.Add(splitContainer1);
			Controls.Add(toolStrip1);
			Name = "BTEditorControl";
			Size = new System.Drawing.Size(809, 551);
			behaviorTreeCMS.ResumeLayout(false);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)behaviorTreeTL).EndInit();
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton executeTSButton;
		private System.Windows.Forms.ToolStripSplitButton saveTSButton;
		private System.Windows.Forms.ContextMenuStrip behaviorTreeCMS;
		private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
		private CommonTools.TreeListView behaviorTreeTL;
		private CommonTools.TreeListColumn treeListColumn1;
		private CommonTools.TreeListColumn treeListColumn2;
		private CommonTools.TreeListColumn treeListColumn3;
		private System.Windows.Forms.ToolStripButton stopTSButton;
		private System.Windows.Forms.ToolStripComboBox entityComboBox;
		private System.Windows.Forms.ImageList behaviorTreeImageList;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripButton loadTSButton;
		private System.Windows.Forms.ToolStripButton newTSButton;
		private System.Windows.Forms.ToolStripMenuItem saveAsTSButton;
	}
}
