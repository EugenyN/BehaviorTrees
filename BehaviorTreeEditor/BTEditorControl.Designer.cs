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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTEditorControl));
            CommonTools.TreeListColumn treeListColumn4 = new CommonTools.TreeListColumn("Name", "Name");
            CommonTools.TreeListColumn treeListColumn5 = new CommonTools.TreeListColumn("Type", "Type");
            CommonTools.TreeListColumn treeListColumn6 = new CommonTools.TreeListColumn("Parameters", "Parameters");
            this.behaviorTreeCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newTSButton = new System.Windows.Forms.ToolStripButton();
            this.loadTSButton = new System.Windows.Forms.ToolStripButton();
            this.saveTSButton = new System.Windows.Forms.ToolStripSplitButton();
            this.saveAsTSButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.executeTSButton = new System.Windows.Forms.ToolStripButton();
            this.stopTSButton = new System.Windows.Forms.ToolStripButton();
            this.entityComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.behaviorTreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.behaviorTreeTL = new CommonTools.TreeListView();
            this.behaviorTreeCMS.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorTreeTL)).BeginInit();
            this.SuspendLayout();
            // 
            // behaviorTreeCMS
            // 
            this.behaviorTreeCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem});
            this.behaviorTreeCMS.Name = "btEditorCMS";
            this.behaviorTreeCMS.Size = new System.Drawing.Size(116, 26);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.ExecuteToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTSButton,
            this.loadTSButton,
            this.saveTSButton,
            this.toolStripSeparator1,
            this.executeTSButton,
            this.stopTSButton,
            this.entityComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(809, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newTSButton
            // 
            this.newTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newTSButton.Image = ((System.Drawing.Image)(resources.GetObject("newTSButton.Image")));
            this.newTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newTSButton.Name = "newTSButton";
            this.newTSButton.Size = new System.Drawing.Size(23, 22);
            this.newTSButton.Text = "New";
            this.newTSButton.Click += new System.EventHandler(this.NewTSButton_Click);
            // 
            // loadTSButton
            // 
            this.loadTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadTSButton.Image = ((System.Drawing.Image)(resources.GetObject("loadTSButton.Image")));
            this.loadTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadTSButton.Name = "loadTSButton";
            this.loadTSButton.Size = new System.Drawing.Size(23, 22);
            this.loadTSButton.Text = "Load";
            this.loadTSButton.Click += new System.EventHandler(this.LoadTSButton_Click);
            // 
            // saveTSButton
            // 
            this.saveTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveTSButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsTSButton});
            this.saveTSButton.Image = ((System.Drawing.Image)(resources.GetObject("saveTSButton.Image")));
            this.saveTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveTSButton.Name = "saveTSButton";
            this.saveTSButton.Size = new System.Drawing.Size(32, 22);
            this.saveTSButton.Text = "Save";
            this.saveTSButton.ButtonClick += new System.EventHandler(this.SaveTSButton_ButtonClick);
            // 
            // saveAsTSButton
            // 
            this.saveAsTSButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAsTSButton.Image")));
            this.saveAsTSButton.Name = "saveAsTSButton";
            this.saveAsTSButton.Size = new System.Drawing.Size(114, 22);
            this.saveAsTSButton.Text = "Save As";
            this.saveAsTSButton.Click += new System.EventHandler(this.SaveAsTSButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.executeTSButton.Click += new System.EventHandler(this.executeTSButton_Click);
            // 
            // stopTSButton
            // 
            this.stopTSButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopTSButton.Image = ((System.Drawing.Image)(resources.GetObject("stopTSButton.Image")));
            this.stopTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopTSButton.Name = "stopTSButton";
            this.stopTSButton.Size = new System.Drawing.Size(23, 22);
            this.stopTSButton.Text = "toolStripButton1";
            this.stopTSButton.ToolTipText = "Stop";
            this.stopTSButton.Click += new System.EventHandler(this.stopTSButton_Click);
            // 
            // entityComboBox
            // 
            this.entityComboBox.Name = "entityComboBox";
            this.entityComboBox.Size = new System.Drawing.Size(200, 25);
            // 
            // behaviorTreeImageList
            // 
            this.behaviorTreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.behaviorTreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("behaviorTreeImageList.ImageStream")));
            this.behaviorTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.behaviorTreeImageList.Images.SetKeyName(0, "action.png");
            this.behaviorTreeImageList.Images.SetKeyName(1, "composite.png");
            this.behaviorTreeImageList.Images.SetKeyName(2, "condition.png");
            this.behaviorTreeImageList.Images.SetKeyName(3, "decorator.png");
            this.behaviorTreeImageList.Images.SetKeyName(4, "trigger.png");
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(227, 526);
            this.propertyGrid1.TabIndex = 20;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.behaviorTreeTL);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(809, 526);
            this.splitContainer1.SplitterDistance = 578;
            this.splitContainer1.TabIndex = 21;
            // 
            // behaviorTreeTL
            // 
            this.behaviorTreeTL.AllowDrop = true;
            treeListColumn4.AutoSizeMinSize = 0;
            treeListColumn4.Width = 270;
            treeListColumn5.AutoSizeMinSize = 0;
            treeListColumn5.Width = 90;
            treeListColumn6.AutoSizeMinSize = 0;
            treeListColumn6.Width = 150;
            this.behaviorTreeTL.Columns.AddRange(new CommonTools.TreeListColumn[] {
            treeListColumn4,
            treeListColumn5,
            treeListColumn6});
            this.behaviorTreeTL.ContextMenuStrip = this.behaviorTreeCMS;
            this.behaviorTreeTL.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.behaviorTreeTL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.behaviorTreeTL.Images = this.behaviorTreeImageList;
            this.behaviorTreeTL.Location = new System.Drawing.Point(0, 0);
            this.behaviorTreeTL.Name = "behaviorTreeTL";
            this.behaviorTreeTL.RowOptions.ItemHeight = 26;
            this.behaviorTreeTL.Size = new System.Drawing.Size(578, 526);
            this.behaviorTreeTL.TabIndex = 19;
            this.behaviorTreeTL.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BehaviorTreeTL_AfterSelect);
            this.behaviorTreeTL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BehaviorTreeTL_MouseUp);
            // 
            // BTEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BTEditorControl";
            this.Size = new System.Drawing.Size(809, 551);
            this.behaviorTreeCMS.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorTreeTL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
