namespace Sims3Workshop
{
	// Token: 0x02000128 RID: 296
	public sealed partial class Mainform : global::System.Windows.Forms.Form, global::Sims3WorkshopSDK.Interfaces.IWorkshop
	{
		// Token: 0x06000DE6 RID: 3558 RVA: 0x00007AF7 File Offset: 0x00005CF7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x000ABA64 File Offset: 0x000A9C64
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::ns17.Class161 @class = new global::ns17.Class161();
			global::ns17.Class161 class2 = new global::ns17.Class161();
			global::ns17.Class161 class3 = new global::ns17.Class161();
			global::ns17.Class161 class4 = new global::ns17.Class161();
			global::ns17.Class161 class5 = new global::ns17.Class161();
			global::ns17.Class161 class6 = new global::ns17.Class161();
			global::ns17.Class161 class7 = new global::ns17.Class161();
			global::ns17.Class161 class8 = new global::ns17.Class161();
			global::ns17.Class161 class9 = new global::ns17.Class161();
			global::ns17.Class161 class10 = new global::ns17.Class161();
			global::ns17.Class161 class11 = new global::ns17.Class161();
			global::ns8.Class157 renderer = new global::ns8.Class157();
			global::ns17.Class161 class12 = new global::ns17.Class161();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Sims3Workshop.Mainform));
			this.statusStrip = new global::System.Windows.Forms.StatusStrip();
			this.status = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.fpsLabel = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.fileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.newMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveAsMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.closeMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new global::System.Windows.Forms.ToolStripSeparator();
			this.recentMenuItems = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.importMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.exportMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.recentSeparator = new global::System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.projectContentsMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.projectInfoMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.preferencesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.propertiesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.channelEditorToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolsMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.loadAnimationToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkForUpdatesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.meshSplitMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.channelEditMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.pickmaterialMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.editChannelToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip = new global::System.Windows.Forms.MenuStrip();
			this.mainPanel = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.mainSplitContainer = new global::System.Windows.Forms.SplitContainer();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.viewMenu = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.ViewViewButton = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ViewPanButton = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ViewZoomButton = new global::System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new global::System.Windows.Forms.Button();
			this.availableViewsMenu = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.viewFree = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.viewTop = new global::System.Windows.Forms.ToolStripMenuItem();
			this.viewBottom = new global::System.Windows.Forms.ToolStripMenuItem();
			this.viewLeft = new global::System.Windows.Forms.ToolStripMenuItem();
			this.viewRight = new global::System.Windows.Forms.ToolStripMenuItem();
			this.viewFront = new global::System.Windows.Forms.ToolStripMenuItem();
			this.viewBack = new global::System.Windows.Forms.ToolStripMenuItem();
			this.DisplayJointsButton = new global::System.Windows.Forms.CheckBox();
			this.displaySlotsButton = new global::System.Windows.Forms.CheckBox();
			this.displayWireframeButton = new global::System.Windows.Forms.CheckBox();
			this.displayBumpMapButton = new global::System.Windows.Forms.CheckBox();
			this.displayGroundShadow = new global::System.Windows.Forms.CheckBox();
			this.displayNormalsButton = new global::System.Windows.Forms.CheckBox();
			this.displayGridButton = new global::System.Windows.Forms.CheckBox();
			this.lowLod = new global::System.Windows.Forms.CheckBox();
			this.mediumLod = new global::System.Windows.Forms.CheckBox();
			this.highLod = new global::System.Windows.Forms.CheckBox();
			this.veryHighLod = new global::System.Windows.Forms.CheckBox();
			this.reloadEffectsButton = new global::System.Windows.Forms.Button();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.visualTipProvider1 = new global::Skybound.VisualTips.VisualTipProvider(this.components);
			this.splitButton1 = new global::SplitButtonDemo.SplitButton();
			this.ViewButton = new global::SplitButtonDemo.SplitButton();
			this.statusStrip.SuspendLayout();
			this.meshSplitMenuStrip.SuspendLayout();
			this.channelEditMenuStrip.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.mainPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.viewMenu.SuspendLayout();
			this.availableViewsMenu.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.statusStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.status,
				this.fpsLabel
			});
			this.statusStrip.Location = new global::System.Drawing.Point(0, 681);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new global::System.Drawing.Size(934, 22);
			this.statusStrip.TabIndex = 3;
			this.statusStrip.Text = "statusStrip1";
			this.status.Name = "status";
			this.status.Size = new global::System.Drawing.Size(0, 17);
			this.fpsLabel.Name = "fpsLabel";
			this.fpsLabel.Size = new global::System.Drawing.Size(0, 17);
			this.fileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.newMenuItem,
				this.toolStripMenuItem2,
				this.saveMenuItem,
				this.saveAsMenuItem,
				this.closeMenuItem,
				this.toolStripSeparator5,
				this.recentMenuItems,
				this.toolStripSeparator3,
				this.importMenuItem,
				this.exportMenuItem,
				this.recentSeparator,
				this.exitToolStripMenuItem
			});
			this.fileToolStripMenuItem.ForeColor = global::System.Drawing.SystemColors.MenuText;
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new global::System.Drawing.Size(36, 20);
			this.fileToolStripMenuItem.Text = "File";
			this.newMenuItem.Image = global::ns17.Class143._new;
			this.newMenuItem.Name = "newMenuItem";
			this.newMenuItem.ShortcutKeyDisplayString = "";
			this.newMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131150;
			this.newMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.newMenuItem.Text = "New";
			this.newMenuItem.Click += new global::System.EventHandler(this.newMenuItem_Click);
			this.toolStripMenuItem2.Image = global::ns17.Class143.open;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = (global::System.Windows.Forms.Keys)131151;
			this.toolStripMenuItem2.Size = new global::System.Drawing.Size(156, 22);
			this.toolStripMenuItem2.Text = "Open";
			this.toolStripMenuItem2.Click += new global::System.EventHandler(this.toolStripMenuItem2_Click);
			this.saveMenuItem.Enabled = false;
			this.saveMenuItem.Image = global::ns17.Class143.save;
			this.saveMenuItem.Name = "saveMenuItem";
			this.saveMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131155;
			this.saveMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.saveMenuItem.Text = "Save";
			this.saveMenuItem.Click += new global::System.EventHandler(this.saveMenuItem_Click);
			this.saveAsMenuItem.Enabled = false;
			this.saveAsMenuItem.Image = global::ns17.Class143.saveas;
			this.saveAsMenuItem.Name = "saveAsMenuItem";
			this.saveAsMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.saveAsMenuItem.Text = "Save As";
			this.saveAsMenuItem.Click += new global::System.EventHandler(this.saveAsMenuItem_Click);
			this.closeMenuItem.Enabled = false;
			this.closeMenuItem.Image = global::ns17.Class143.close;
			this.closeMenuItem.Name = "closeMenuItem";
			this.closeMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131159;
			this.closeMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.closeMenuItem.Text = "Close";
			this.closeMenuItem.Click += new global::System.EventHandler(this.toolStripMenuItem3_Click);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new global::System.Drawing.Size(153, 6);
			this.recentMenuItems.Name = "recentMenuItems";
			this.recentMenuItems.Size = new global::System.Drawing.Size(156, 22);
			this.recentMenuItems.Text = "Recent project";
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new global::System.Drawing.Size(153, 6);
			this.importMenuItem.Enabled = false;
			this.importMenuItem.Image = global::ns17.Class143.import;
			this.importMenuItem.Name = "importMenuItem";
			this.importMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.importMenuItem.Text = "Import";
			this.exportMenuItem.Enabled = false;
			this.exportMenuItem.Image = global::ns17.Class143.export;
			this.exportMenuItem.Name = "exportMenuItem";
			this.exportMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.exportMenuItem.Text = "Export";
			this.recentSeparator.Name = "recentSeparator";
			this.recentSeparator.Size = new global::System.Drawing.Size(153, 6);
			this.exitToolStripMenuItem.Image = global::ns17.Class143.exit;
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new global::System.EventHandler(this.exitToolStripMenuItem_Click);
			this.editToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.projectContentsMenuItem,
				this.projectInfoMenuItem,
				this.toolStripSeparator2,
				this.preferencesToolStripMenuItem
			});
			this.editToolStripMenuItem.ForeColor = global::System.Drawing.SystemColors.MenuText;
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new global::System.Drawing.Size(40, 20);
			this.editToolStripMenuItem.Text = "Edit";
			this.projectContentsMenuItem.Enabled = false;
			this.projectContentsMenuItem.Name = "projectContentsMenuItem";
			this.projectContentsMenuItem.Size = new global::System.Drawing.Size(166, 22);
			this.projectContentsMenuItem.Text = "Project contents";
			this.projectContentsMenuItem.Click += new global::System.EventHandler(this.projectContentsMenuItem_Click);
			this.projectInfoMenuItem.Enabled = false;
			this.projectInfoMenuItem.Name = "projectInfoMenuItem";
			this.projectInfoMenuItem.Size = new global::System.Drawing.Size(166, 22);
			this.projectInfoMenuItem.Text = "Project info";
			this.projectInfoMenuItem.Click += new global::System.EventHandler(this.projectInfoToolStripMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(163, 6);
			this.preferencesToolStripMenuItem.Image = global::ns17.Class143.preferences;
			this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
			this.preferencesToolStripMenuItem.Size = new global::System.Drawing.Size(166, 22);
			this.preferencesToolStripMenuItem.Text = "Preferences";
			this.preferencesToolStripMenuItem.Click += new global::System.EventHandler(this.preferencesToolStripMenuItem_Click);
			this.toolStripMenuItem1.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.propertiesToolStripMenuItem,
				this.channelEditorToolStripMenuItem
			});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new global::System.Drawing.Size(44, 20);
			this.toolStripMenuItem1.Text = "View";
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			this.propertiesToolStripMenuItem.Size = new global::System.Drawing.Size(149, 22);
			this.propertiesToolStripMenuItem.Text = "Properties";
			this.channelEditorToolStripMenuItem.Name = "channelEditorToolStripMenuItem";
			this.channelEditorToolStripMenuItem.Size = new global::System.Drawing.Size(149, 22);
			this.channelEditorToolStripMenuItem.Text = "ChannelEditor";
			this.toolsMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.loadAnimationToolStripMenuItem,
				this.toolStripMenuItem3
			});
			this.toolsMenuItem.ForeColor = global::System.Drawing.SystemColors.MenuText;
			this.toolsMenuItem.Name = "toolsMenuItem";
			this.toolsMenuItem.Size = new global::System.Drawing.Size(48, 20);
			this.toolsMenuItem.Text = "Tools";
			this.loadAnimationToolStripMenuItem.Enabled = false;
			this.loadAnimationToolStripMenuItem.Name = "loadAnimationToolStripMenuItem";
			this.loadAnimationToolStripMenuItem.Size = new global::System.Drawing.Size(158, 22);
			this.loadAnimationToolStripMenuItem.Text = "Load Animation";
			this.loadAnimationToolStripMenuItem.Click += new global::System.EventHandler(this.loadAnimationToolStripMenuItem_Click);
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new global::System.Drawing.Size(155, 6);
			this.helpToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.checkForUpdatesToolStripMenuItem,
				this.toolStripSeparator1,
				this.aboutToolStripMenuItem
			});
			this.helpToolStripMenuItem.ForeColor = global::System.Drawing.SystemColors.MenuText;
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new global::System.Drawing.Size(43, 20);
			this.helpToolStripMenuItem.Text = "Help";
			this.checkForUpdatesToolStripMenuItem.Image = global::ns17.Class143.updates;
			this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
			this.checkForUpdatesToolStripMenuItem.Size = new global::System.Drawing.Size(174, 22);
			this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
			this.checkForUpdatesToolStripMenuItem.Visible = false;
			this.checkForUpdatesToolStripMenuItem.Click += new global::System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(171, 6);
			this.toolStripSeparator1.Visible = false;
			this.aboutToolStripMenuItem.Image = global::ns17.Class143.about;
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new global::System.Drawing.Size(174, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new global::System.EventHandler(this.aboutToolStripMenuItem_Click);
			this.meshSplitMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.deleteToolStripMenuItem
			});
			this.meshSplitMenuStrip.Name = "contextMenuStrip1";
			this.meshSplitMenuStrip.Size = new global::System.Drawing.Size(154, 26);
			this.deleteToolStripMenuItem.Image = global::ns17.Class143.element_delete;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new global::System.Drawing.Size(153, 22);
			this.deleteToolStripMenuItem.Text = "Delete selected";
			this.channelEditMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.pickmaterialMenuItem,
				this.editChannelToolStripMenuItem
			});
			this.channelEditMenuStrip.Name = "contextMenuStrip1";
			this.channelEditMenuStrip.Size = new global::System.Drawing.Size(143, 48);
			this.pickmaterialMenuItem.Name = "pickmaterialMenuItem";
			this.pickmaterialMenuItem.Size = new global::System.Drawing.Size(142, 22);
			this.pickmaterialMenuItem.Text = "Pick Material";
			this.editChannelToolStripMenuItem.Image = global::ns17.Class143.element_edit;
			this.editChannelToolStripMenuItem.Name = "editChannelToolStripMenuItem";
			this.editChannelToolStripMenuItem.Size = new global::System.Drawing.Size(142, 22);
			this.editChannelToolStripMenuItem.Text = "Edit Channel";
			this.menuStrip.BackColor = global::System.Drawing.SystemColors.MenuBar;
			this.menuStrip.BackgroundImage = global::ns17.Class143.topback;
			this.menuStrip.Font = new global::System.Drawing.Font("Tahoma", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.menuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.fileToolStripMenuItem,
				this.editToolStripMenuItem,
				this.toolsMenuItem,
				this.helpToolStripMenuItem
			});
			this.menuStrip.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new global::System.Drawing.Size(934, 24);
			this.menuStrip.TabIndex = 4;
			this.menuStrip.Text = "menuStrip1";
			this.mainPanel.Controls.Add(this.panel2);
			this.mainPanel.Controls.Add(this.panel1);
			this.mainPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new global::System.Drawing.Point(0, 24);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new global::System.Drawing.Size(934, 657);
			this.mainPanel.TabIndex = 21;
			this.panel2.BackColor = global::System.Drawing.Color.Transparent;
			this.panel2.Controls.Add(this.mainSplitContainer);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 40);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(934, 617);
			this.panel2.TabIndex = 16;
			this.mainSplitContainer.BackColor = global::System.Drawing.Color.FromArgb(182, 225, 131);
			this.mainSplitContainer.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel2;
			this.mainSplitContainer.Location = new global::System.Drawing.Point(0, 0);
			this.mainSplitContainer.Name = "mainSplitContainer";
			this.mainSplitContainer.Panel1.BackColor = global::System.Drawing.Color.Transparent;
			this.mainSplitContainer.Panel1.Padding = new global::System.Windows.Forms.Padding(4, 0, 0, 4);
			this.mainSplitContainer.Panel1MinSize = 0;
			this.mainSplitContainer.Panel2.Padding = new global::System.Windows.Forms.Padding(0, 0, 2, 4);
			this.mainSplitContainer.Panel2MinSize = 0;
			this.mainSplitContainer.Size = new global::System.Drawing.Size(934, 617);
			this.mainSplitContainer.SplitterDistance = 566;
			this.mainSplitContainer.TabIndex = 13;
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 225, 131);
			this.panel1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.reloadEffectsButton);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.panel1.Size = new global::System.Drawing.Size(934, 40);
			this.panel1.TabIndex = 15;
			this.panel4.Controls.Add(this.splitButton1);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.ViewButton);
			this.panel4.Controls.Add(this.DisplayJointsButton);
			this.panel4.Controls.Add(this.displaySlotsButton);
			this.panel4.Controls.Add(this.displayWireframeButton);
			this.panel4.Controls.Add(this.displayBumpMapButton);
			this.panel4.Controls.Add(this.displayGroundShadow);
			this.panel4.Controls.Add(this.displayNormalsButton);
			this.panel4.Controls.Add(this.displayGridButton);
			this.panel4.Controls.Add(this.lowLod);
			this.panel4.Controls.Add(this.mediumLod);
			this.panel4.Controls.Add(this.highLod);
			this.panel4.Controls.Add(this.veryHighLod);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new global::System.Windows.Forms.Padding(6);
			this.panel4.Size = new global::System.Drawing.Size(573, 40);
			this.panel4.TabIndex = 14;
			this.viewMenu.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.ViewViewButton,
				this.ViewPanButton,
				this.ViewZoomButton
			});
			this.viewMenu.Name = "viewMenu";
			this.viewMenu.Size = new global::System.Drawing.Size(107, 70);
			this.ViewViewButton.Checked = true;
			this.ViewViewButton.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.ViewViewButton.Name = "ViewViewButton";
			this.ViewViewButton.Size = new global::System.Drawing.Size(106, 22);
			this.ViewViewButton.Text = "View";
			this.ViewViewButton.Click += new global::System.EventHandler(this.ViewViewButton_Click);
			this.ViewPanButton.Name = "ViewPanButton";
			this.ViewPanButton.Size = new global::System.Drawing.Size(106, 22);
			this.ViewPanButton.Text = "Pan";
			this.ViewPanButton.Click += new global::System.EventHandler(this.ViewPanButton_Click);
			this.ViewZoomButton.Name = "ViewZoomButton";
			this.ViewZoomButton.Size = new global::System.Drawing.Size(106, 22);
			this.ViewZoomButton.Text = "Zoom";
			this.ViewZoomButton.Click += new global::System.EventHandler(this.ViewZoomButton_Click);
			this.button1.Location = new global::System.Drawing.Point(494, 6);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(48, 28);
			this.button1.TabIndex = 15;
			this.button1.Text = "Edit";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click_3);
			this.availableViewsMenu.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.viewFree,
				this.toolStripSeparator4,
				this.viewTop,
				this.viewBottom,
				this.viewLeft,
				this.viewRight,
				this.viewFront,
				this.viewBack
			});
			this.availableViewsMenu.Name = "availableViewsMenu";
			this.availableViewsMenu.Size = new global::System.Drawing.Size(115, 164);
			this.availableViewsMenu.ItemClicked += new global::System.Windows.Forms.ToolStripItemClickedEventHandler(this.availableViewsMenu_ItemClicked);
			this.viewFree.Checked = true;
			this.viewFree.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.viewFree.Name = "viewFree";
			this.viewFree.Size = new global::System.Drawing.Size(114, 22);
			this.viewFree.Tag = "0";
			this.viewFree.Text = "Free";
			this.viewFree.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new global::System.Drawing.Size(111, 6);
			this.viewTop.Name = "viewTop";
			this.viewTop.Size = new global::System.Drawing.Size(114, 22);
			this.viewTop.Tag = "1";
			this.viewTop.Text = "Top";
			this.viewBottom.Name = "viewBottom";
			this.viewBottom.Size = new global::System.Drawing.Size(114, 22);
			this.viewBottom.Tag = "2";
			this.viewBottom.Text = "Bottom";
			this.viewLeft.Name = "viewLeft";
			this.viewLeft.Size = new global::System.Drawing.Size(114, 22);
			this.viewLeft.Tag = "3";
			this.viewLeft.Text = "Left";
			this.viewRight.Name = "viewRight";
			this.viewRight.Size = new global::System.Drawing.Size(114, 22);
			this.viewRight.Tag = "4";
			this.viewRight.Text = "Right";
			this.viewFront.Name = "viewFront";
			this.viewFront.Size = new global::System.Drawing.Size(114, 22);
			this.viewFront.Tag = "5";
			this.viewFront.Text = "Front";
			this.viewBack.Name = "viewBack";
			this.viewBack.Size = new global::System.Drawing.Size(114, 22);
			this.viewBack.Tag = "6";
			this.viewBack.Text = "Back";
			this.DisplayJointsButton.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.DisplayJointsButton.AutoSize = true;
			this.DisplayJointsButton.Image = global::ns17.Class143.bone;
			this.DisplayJointsButton.Location = new global::System.Drawing.Point(304, 6);
			this.DisplayJointsButton.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.DisplayJointsButton.Name = "DisplayJointsButton";
			this.DisplayJointsButton.Size = new global::System.Drawing.Size(28, 28);
			this.DisplayJointsButton.TabIndex = 10;
			this.DisplayJointsButton.UseVisualStyleBackColor = true;
			@class.Text = "Show Joints";
			this.visualTipProvider1.method_3(this.DisplayJointsButton, @class);
			this.DisplayJointsButton.Click += new global::System.EventHandler(this.rigCheckBox_Click);
			this.displaySlotsButton.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.displaySlotsButton.AutoSize = true;
			this.displaySlotsButton.Image = global::ns17.Class143.slots;
			this.displaySlotsButton.Location = new global::System.Drawing.Point(275, 6);
			this.displaySlotsButton.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.displaySlotsButton.Name = "displaySlotsButton";
			this.displaySlotsButton.Size = new global::System.Drawing.Size(28, 28);
			this.displaySlotsButton.TabIndex = 9;
			this.displaySlotsButton.UseVisualStyleBackColor = true;
			class2.Text = "Show Slots";
			this.visualTipProvider1.method_3(this.displaySlotsButton, class2);
			this.displaySlotsButton.Click += new global::System.EventHandler(this.displaySlots_Click);
			this.displayWireframeButton.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.displayWireframeButton.AutoSize = true;
			this.displayWireframeButton.Image = global::ns17.Class143.wireframe;
			this.displayWireframeButton.Location = new global::System.Drawing.Point(246, 6);
			this.displayWireframeButton.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.displayWireframeButton.Name = "displayWireframeButton";
			this.displayWireframeButton.Size = new global::System.Drawing.Size(28, 28);
			this.displayWireframeButton.TabIndex = 8;
			this.displayWireframeButton.UseVisualStyleBackColor = true;
			class3.Text = "Show Wireframe";
			this.visualTipProvider1.method_3(this.displayWireframeButton, class3);
			this.displayWireframeButton.Click += new global::System.EventHandler(this.wireframe_Click);
			this.displayBumpMapButton.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.displayBumpMapButton.AutoSize = true;
			this.displayBumpMapButton.Image = global::ns17.Class143.bullet_ball_glass_grey;
			this.displayBumpMapButton.Location = new global::System.Drawing.Point(217, 6);
			this.displayBumpMapButton.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.displayBumpMapButton.Name = "displayBumpMapButton";
			this.displayBumpMapButton.Size = new global::System.Drawing.Size(28, 28);
			this.displayBumpMapButton.TabIndex = 7;
			this.displayBumpMapButton.UseVisualStyleBackColor = true;
			class4.Text = "Show Bumpmap";
			this.visualTipProvider1.method_3(this.displayBumpMapButton, class4);
			this.displayBumpMapButton.Click += new global::System.EventHandler(this.bumpmapCheckbox_Click);
			this.displayGroundShadow.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.displayGroundShadow.AutoSize = true;
			this.displayGroundShadow.Image = global::ns17.Class143.shadow;
			this.displayGroundShadow.Location = new global::System.Drawing.Point(188, 6);
			this.displayGroundShadow.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.displayGroundShadow.Name = "displayGroundShadow";
			this.displayGroundShadow.Size = new global::System.Drawing.Size(28, 28);
			this.displayGroundShadow.TabIndex = 6;
			this.displayGroundShadow.UseVisualStyleBackColor = true;
			class5.Text = "Show Groundshadow";
			this.visualTipProvider1.method_3(this.displayGroundShadow, class5);
			this.displayGroundShadow.CheckedChanged += new global::System.EventHandler(this.displayGroundShadow_CheckedChanged);
			this.displayGroundShadow.Click += new global::System.EventHandler(this.groundCheckbox_CheckedChanged);
			this.displayNormalsButton.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.displayNormalsButton.AutoSize = true;
			this.displayNormalsButton.Image = global::ns17.Class143.normals;
			this.displayNormalsButton.Location = new global::System.Drawing.Point(159, 6);
			this.displayNormalsButton.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.displayNormalsButton.Name = "displayNormalsButton";
			this.displayNormalsButton.Size = new global::System.Drawing.Size(28, 28);
			this.displayNormalsButton.TabIndex = 5;
			this.displayNormalsButton.UseVisualStyleBackColor = true;
			class6.Text = "Show Normals";
			this.visualTipProvider1.method_3(this.displayNormalsButton, class6);
			this.displayNormalsButton.Click += new global::System.EventHandler(this.checkBox1_CheckedChanged);
			this.displayGridButton.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.displayGridButton.AutoSize = true;
			this.displayGridButton.Image = global::ns17.Class143.grid;
			this.displayGridButton.Location = new global::System.Drawing.Point(130, 6);
			this.displayGridButton.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.displayGridButton.Name = "displayGridButton";
			this.displayGridButton.Size = new global::System.Drawing.Size(28, 28);
			this.displayGridButton.TabIndex = 4;
			this.displayGridButton.UseVisualStyleBackColor = true;
			class7.Text = "Show Grid";
			this.visualTipProvider1.method_3(this.displayGridButton, class7);
			this.displayGridButton.Click += new global::System.EventHandler(this.gridEnabled_CheckedChanged);
			this.lowLod.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.lowLod.AutoSize = true;
			this.lowLod.Image = global::ns17.Class143.lod4;
			this.lowLod.Location = new global::System.Drawing.Point(92, 6);
			this.lowLod.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.lowLod.Name = "lowLod";
			this.lowLod.Size = new global::System.Drawing.Size(28, 28);
			this.lowLod.TabIndex = 3;
			this.lowLod.UseVisualStyleBackColor = true;
			class8.Text = "Low Detail";
			this.visualTipProvider1.method_3(this.lowLod, class8);
			this.lowLod.Click += new global::System.EventHandler(this.lodUltrahigh_CheckedChanged);
			this.mediumLod.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.mediumLod.AutoSize = true;
			this.mediumLod.Image = global::ns17.Class143.lod2;
			this.mediumLod.Location = new global::System.Drawing.Point(63, 6);
			this.mediumLod.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.mediumLod.Name = "mediumLod";
			this.mediumLod.Size = new global::System.Drawing.Size(28, 28);
			this.mediumLod.TabIndex = 2;
			this.mediumLod.UseVisualStyleBackColor = true;
			class9.Text = "Medium Detail";
			this.visualTipProvider1.method_3(this.mediumLod, class9);
			this.mediumLod.Click += new global::System.EventHandler(this.lodUltrahigh_CheckedChanged);
			this.highLod.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.highLod.AutoSize = true;
			this.highLod.Image = global::ns17.Class143.lod2;
			this.highLod.Location = new global::System.Drawing.Point(34, 6);
			this.highLod.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.highLod.Name = "highLod";
			this.highLod.Size = new global::System.Drawing.Size(28, 28);
			this.highLod.TabIndex = 1;
			this.highLod.UseVisualStyleBackColor = true;
			class10.Text = "High Detail";
			this.visualTipProvider1.method_3(this.highLod, class10);
			this.highLod.Click += new global::System.EventHandler(this.lodUltrahigh_CheckedChanged);
			this.veryHighLod.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.veryHighLod.AutoSize = true;
			this.veryHighLod.Image = global::ns17.Class143.lod1;
			this.veryHighLod.Location = new global::System.Drawing.Point(5, 6);
			this.veryHighLod.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.veryHighLod.Name = "veryHighLod";
			this.veryHighLod.Size = new global::System.Drawing.Size(28, 28);
			this.veryHighLod.TabIndex = 0;
			this.veryHighLod.UseVisualStyleBackColor = true;
			class11.Text = "Very High Detail";
			this.visualTipProvider1.method_3(this.veryHighLod, class11);
			this.veryHighLod.Click += new global::System.EventHandler(this.lodUltrahigh_CheckedChanged);
			this.reloadEffectsButton.Location = new global::System.Drawing.Point(670, 9);
			this.reloadEffectsButton.Name = "reloadEffectsButton";
			this.reloadEffectsButton.Size = new global::System.Drawing.Size(165, 23);
			this.reloadEffectsButton.TabIndex = 11;
			this.reloadEffectsButton.Text = "Reload Shaders";
			this.reloadEffectsButton.UseVisualStyleBackColor = true;
			this.reloadEffectsButton.Visible = false;
			this.reloadEffectsButton.Click += new global::System.EventHandler(this.button1_Click_2);
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::ns17.Class143.topright;
			this.pictureBox1.Location = new global::System.Drawing.Point(573, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(361, 40);
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			this.visualTipProvider1.Animation = global::ns20.Enum24.const_2;
			this.visualTipProvider1.Renderer = renderer;
			this.visualTipProvider1.Shadow = global::ns1.Enum26.const_2;
			this.splitButton1.ClickedImage = "Clicked";
			this.splitButton1.ContextMenuStrip = this.viewMenu;
			this.splitButton1.DisabledImage = "Disabled";
			this.splitButton1.FocusedImage = "Focused";
			this.splitButton1.HoverImage = "Hover";
			this.splitButton1.ImageAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.splitButton1.ImageKey = "Normal";
			this.splitButton1.Location = new global::System.Drawing.Point(422, 6);
			this.splitButton1.MinimumSize = new global::System.Drawing.Size(0, 28);
			this.splitButton1.Name = "splitButton1";
			this.splitButton1.NormalImage = "Normal";
			this.splitButton1.Size = new global::System.Drawing.Size(62, 28);
			this.splitButton1.TabIndex = 18;
			this.splitButton1.Text = "View";
			this.splitButton1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.splitButton1.UseVisualStyleBackColor = true;
			this.ViewButton.ClickedImage = "Clicked";
			this.ViewButton.ContextMenuStrip = this.availableViewsMenu;
			this.ViewButton.DisabledImage = "Disabled";
			this.ViewButton.FocusedImage = "Focused";
			this.ViewButton.HoverImage = "Hover";
			this.ViewButton.ImageAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.ViewButton.ImageKey = "Normal";
			this.ViewButton.Location = new global::System.Drawing.Point(342, 6);
			this.ViewButton.MinimumSize = new global::System.Drawing.Size(28, 28);
			this.ViewButton.Name = "ViewButton";
			this.ViewButton.NormalImage = "Normal";
			this.ViewButton.Size = new global::System.Drawing.Size(70, 28);
			this.ViewButton.TabIndex = 11;
			this.ViewButton.Text = "Free";
			this.ViewButton.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.ViewButton.UseVisualStyleBackColor = true;
			class12.Text = "Choose View";
			this.visualTipProvider1.method_3(this.ViewButton, class12);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(934, 703);
			base.Controls.Add(this.mainPanel);
			base.Controls.Add(this.menuStrip);
			base.Controls.Add(this.statusStrip);
			this.DoubleBuffered = true;
			this.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.IsMdiContainer = true;
			base.MainMenuStrip = this.menuStrip;
			this.MinimumSize = new global::System.Drawing.Size(950, 738);
			base.Name = "Mainform";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TSR Workshop";
			base.Activated += new global::System.EventHandler(this.Mainform_Activated);
			base.Deactivate += new global::System.EventHandler(this.Mainform_Deactivate);
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Mainform_FormClosing);
			base.Load += new global::System.EventHandler(this.Mainform_Load);
			base.Shown += new global::System.EventHandler(this.Mainform_Shown);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.Mainform_KeyDown);
			base.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.Mainform_KeyUp);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.meshSplitMenuStrip.ResumeLayout(false);
			this.channelEditMenuStrip.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.mainPanel.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.mainSplitContainer.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.viewMenu.ResumeLayout(false);
			this.availableViewsMenu.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000A39 RID: 2617
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000A3A RID: 2618
		private global::System.Windows.Forms.StatusStrip statusStrip;

		// Token: 0x04000A3B RID: 2619
		private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

		// Token: 0x04000A3C RID: 2620
		private global::System.Windows.Forms.ToolStripMenuItem importMenuItem;

		// Token: 0x04000A3D RID: 2621
		private global::System.Windows.Forms.ToolStripMenuItem exportMenuItem;

		// Token: 0x04000A3E RID: 2622
		private global::System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

		// Token: 0x04000A3F RID: 2623
		private global::System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;

		// Token: 0x04000A40 RID: 2624
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;

		// Token: 0x04000A41 RID: 2625
		private global::System.Windows.Forms.ToolStripMenuItem saveMenuItem;

		// Token: 0x04000A42 RID: 2626
		private global::System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;

		// Token: 0x04000A43 RID: 2627
		private global::System.Windows.Forms.ToolStripMenuItem closeMenuItem;

		// Token: 0x04000A44 RID: 2628
		private global::System.Windows.Forms.ToolStripMenuItem newMenuItem;

		// Token: 0x04000A45 RID: 2629
		private global::System.Windows.Forms.ToolStripSeparator recentSeparator;

		// Token: 0x04000A46 RID: 2630
		private global::System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;

		// Token: 0x04000A47 RID: 2631
		private global::System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;

		// Token: 0x04000A48 RID: 2632
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		// Token: 0x04000A49 RID: 2633
		private global::System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

		// Token: 0x04000A4A RID: 2634
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

		// Token: 0x04000A4B RID: 2635
		public global::System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;

		// Token: 0x04000A4C RID: 2636
		public global::System.Windows.Forms.ToolStripMenuItem channelEditorToolStripMenuItem;

		// Token: 0x04000A4D RID: 2637
		private global::System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;

		// Token: 0x04000A4E RID: 2638
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

		// Token: 0x04000A4F RID: 2639
		private global::System.Windows.Forms.ToolStripMenuItem toolsMenuItem;

		// Token: 0x04000A50 RID: 2640
		private global::System.Windows.Forms.MenuStrip menuStrip;

		// Token: 0x04000A51 RID: 2641
		private global::System.Windows.Forms.ContextMenuStrip channelEditMenuStrip;

		// Token: 0x04000A52 RID: 2642
		private global::System.Windows.Forms.ToolStripMenuItem pickmaterialMenuItem;

		// Token: 0x04000A53 RID: 2643
		private global::System.Windows.Forms.ToolStripMenuItem editChannelToolStripMenuItem;

		// Token: 0x04000A54 RID: 2644
		private global::System.Windows.Forms.ContextMenuStrip meshSplitMenuStrip;

		// Token: 0x04000A55 RID: 2645
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

		// Token: 0x04000A56 RID: 2646
		private global::System.Windows.Forms.ToolStripStatusLabel status;

		// Token: 0x04000A57 RID: 2647
		private global::System.Windows.Forms.Panel mainPanel;

		// Token: 0x04000A58 RID: 2648
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000A59 RID: 2649
		private global::System.Windows.Forms.SplitContainer mainSplitContainer;

		// Token: 0x04000A5A RID: 2650
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000A5B RID: 2651
		private global::System.Windows.Forms.ToolStripMenuItem projectContentsMenuItem;

		// Token: 0x04000A5C RID: 2652
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		// Token: 0x04000A5D RID: 2653
		private global::Skybound.VisualTips.VisualTipProvider visualTipProvider1;

		// Token: 0x04000A5E RID: 2654
		private global::System.Windows.Forms.ToolStripMenuItem projectInfoMenuItem;

		// Token: 0x04000A5F RID: 2655
		private global::System.Windows.Forms.ContextMenuStrip availableViewsMenu;

		// Token: 0x04000A60 RID: 2656
		private global::System.Windows.Forms.ToolStripMenuItem viewFree;

		// Token: 0x04000A61 RID: 2657
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

		// Token: 0x04000A62 RID: 2658
		private global::System.Windows.Forms.ToolStripMenuItem viewTop;

		// Token: 0x04000A63 RID: 2659
		private global::System.Windows.Forms.ToolStripMenuItem viewLeft;

		// Token: 0x04000A64 RID: 2660
		private global::System.Windows.Forms.ToolStripMenuItem viewRight;

		// Token: 0x04000A65 RID: 2661
		private global::System.Windows.Forms.ToolStripMenuItem viewFront;

		// Token: 0x04000A66 RID: 2662
		private global::System.Windows.Forms.ToolStripMenuItem viewBack;

		// Token: 0x04000A67 RID: 2663
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000A68 RID: 2664
		private global::System.Windows.Forms.Button reloadEffectsButton;

		// Token: 0x04000A69 RID: 2665
		private global::System.Windows.Forms.ToolStripStatusLabel fpsLabel;

		// Token: 0x04000A6A RID: 2666
		private global::System.Windows.Forms.ToolStripMenuItem loadAnimationToolStripMenuItem;

		// Token: 0x04000A6B RID: 2667
		private global::System.Windows.Forms.ToolStripMenuItem viewBottom;

		// Token: 0x04000A6C RID: 2668
		private global::System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;

		// Token: 0x04000A6D RID: 2669
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000A6E RID: 2670
		private global::System.Windows.Forms.ContextMenuStrip viewMenu;

		// Token: 0x04000A6F RID: 2671
		public global::System.Windows.Forms.ToolStripMenuItem ViewZoomButton;

		// Token: 0x04000A70 RID: 2672
		public global::System.Windows.Forms.ToolStripMenuItem ViewPanButton;

		// Token: 0x04000A71 RID: 2673
		public global::System.Windows.Forms.ToolStripMenuItem ViewViewButton;

		// Token: 0x04000A72 RID: 2674
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000A73 RID: 2675
		private global::System.Windows.Forms.CheckBox lowLod;

		// Token: 0x04000A74 RID: 2676
		private global::System.Windows.Forms.CheckBox mediumLod;

		// Token: 0x04000A75 RID: 2677
		private global::System.Windows.Forms.CheckBox highLod;

		// Token: 0x04000A76 RID: 2678
		private global::System.Windows.Forms.CheckBox veryHighLod;

		// Token: 0x04000A77 RID: 2679
		private global::System.Windows.Forms.CheckBox displaySlotsButton;

		// Token: 0x04000A78 RID: 2680
		private global::System.Windows.Forms.CheckBox displayWireframeButton;

		// Token: 0x04000A79 RID: 2681
		private global::System.Windows.Forms.CheckBox displayBumpMapButton;

		// Token: 0x04000A7A RID: 2682
		private global::System.Windows.Forms.CheckBox displayGroundShadow;

		// Token: 0x04000A7B RID: 2683
		private global::System.Windows.Forms.CheckBox displayNormalsButton;

		// Token: 0x04000A7C RID: 2684
		private global::System.Windows.Forms.CheckBox displayGridButton;

		// Token: 0x04000A7D RID: 2685
		public global::System.Windows.Forms.CheckBox DisplayJointsButton;

		// Token: 0x04000A7E RID: 2686
		public global::SplitButtonDemo.SplitButton ViewButton;

		// Token: 0x04000A7F RID: 2687
		public global::SplitButtonDemo.SplitButton splitButton1;

		// Token: 0x04000A80 RID: 2688
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator5;

		// Token: 0x04000A81 RID: 2689
		private global::System.Windows.Forms.ToolStripMenuItem recentMenuItems;
	}
}
