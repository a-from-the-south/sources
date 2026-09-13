namespace ns2
{
	// Token: 0x02000045 RID: 69
	internal sealed partial class NewProjectForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060002B2 RID: 690 RVA: 0x0003564C File Offset: 0x0003384C
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns2.NewProjectForm));
			global::System.Windows.Forms.ListViewGroup listViewGroup = new global::System.Windows.Forms.ListViewGroup("Clone an item", global::System.Windows.Forms.HorizontalAlignment.Left);
			global::System.Windows.Forms.ListViewGroup listViewGroup2 = new global::System.Windows.Forms.ListViewGroup("Import", global::System.Windows.Forms.HorizontalAlignment.Left);
			global::System.Windows.Forms.ListViewItem listViewItem = new global::System.Windows.Forms.ListViewItem("Clothing", 0);
			global::System.Windows.Forms.ListViewItem listViewItem2 = new global::System.Windows.Forms.ListViewItem("Makeup/Facial overlay", 1);
			global::System.Windows.Forms.ListViewItem listViewItem3 = new global::System.Windows.Forms.ListViewItem("Hair", 2);
			global::System.Windows.Forms.ListViewItem listViewItem4 = new global::System.Windows.Forms.ListViewItem("Accessory", 3);
			global::System.Windows.Forms.ListViewItem listViewItem5 = new global::System.Windows.Forms.ListViewItem("Object", 4);
			global::System.Windows.Forms.ListViewItem listViewItem6 = new global::System.Windows.Forms.ListViewItem("Modular Object", 5);
			global::System.Windows.Forms.ListViewItem listViewItem7 = new global::System.Windows.Forms.ListViewItem("Builditem", 6);
			global::System.Windows.Forms.ListViewItem listViewItem8 = new global::System.Windows.Forms.ListViewItem("New import", 7);
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.status = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.progress = new global::System.Windows.Forms.ToolStripProgressBar();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.imageList_1 = new global::System.Windows.Forms.ImageList(this.icontainer_0);
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
			this.showInfoToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.copyReskeyToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.wizard = new global::ns19.Wizard();
			this.donePage = new global::ns6.Class146();
			this.details = new global::ns6.Class146();
			this.diagonalChoice = new global::System.Windows.Forms.GroupBox();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.description = new global::System.Windows.Forms.TextBox();
			this.descriptionLabel = new global::System.Windows.Forms.Label();
			this.title = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.unique = new global::System.Windows.Forms.TextBox();
			this.uniqueLabel = new global::System.Windows.Forms.Label();
			this.projectName = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.clone = new global::ns6.Class146();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.items = new global::System.Windows.Forms.ListView();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.filterSearch = new global::System.Windows.Forms.TextBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.treeView1 = new global::System.Windows.Forms.TreeView();
			this.import = new global::ns6.Class146();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.newGroupId = new global::System.Windows.Forms.TextBox();
			this.preserveGroupId = new global::System.Windows.Forms.CheckBox();
			this.projectTypeLabel = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.importImage = new global::System.Windows.Forms.PictureBox();
			this.nameLabel = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.browse = new global::System.Windows.Forms.Button();
			this.importFile = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.pageStart = new global::ns6.Class146();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.projectTemplate = new global::System.Windows.Forms.ListView();
			this.columnHeader_0 = new global::System.Windows.Forms.ColumnHeader();
			this.statusStrip1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.wizard.SuspendLayout();
			this.details.SuspendLayout();
			this.diagonalChoice.SuspendLayout();
			this.clone.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel7.SuspendLayout();
			this.import.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.importImage).BeginInit();
			this.pageStart.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.status,
				this.progress
			});
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 466);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(824, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			this.status.Name = "status";
			this.status.Size = new global::System.Drawing.Size(0, 17);
			this.progress.Name = "progress";
			this.progress.Size = new global::System.Drawing.Size(100, 16);
			this.progress.Style = global::System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progress.Visible = false;
			this.panel5.Controls.Add(this.wizard);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new global::System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(824, 466);
			this.panel5.TabIndex = 2;
			this.imageList_1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList_1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList_1.Images.SetKeyName(0, "clothing.png");
			this.imageList_1.Images.SetKeyName(1, "makeup.png");
			this.imageList_1.Images.SetKeyName(2, "hair.png");
			this.imageList_1.Images.SetKeyName(3, "accessories.png");
			this.imageList_1.Images.SetKeyName(4, "object.png");
			this.imageList_1.Images.SetKeyName(5, "cube_green_new.png");
			this.imageList_1.Images.SetKeyName(6, "builditems.png");
			this.imageList_1.Images.SetKeyName(7, "package.png");
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.showInfoToolStripMenuItem,
				this.copyReskeyToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(139, 48);
			this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
			this.showInfoToolStripMenuItem.Size = new global::System.Drawing.Size(138, 22);
			this.showInfoToolStripMenuItem.Text = "Show info";
			this.showInfoToolStripMenuItem.Click += new global::System.EventHandler(this.showInfoToolStripMenuItem_Click);
			this.copyReskeyToolStripMenuItem.Name = "copyReskeyToolStripMenuItem";
			this.copyReskeyToolStripMenuItem.Size = new global::System.Drawing.Size(138, 22);
			this.copyReskeyToolStripMenuItem.Text = "Copy reskey";
			this.copyReskeyToolStripMenuItem.Click += new global::System.EventHandler(this.copyReskeyToolStripMenuItem_Click);
			this.wizard.Controls.Add(this.import);
			this.wizard.Controls.Add(this.clone);
			this.wizard.Controls.Add(this.details);
			this.wizard.Controls.Add(this.donePage);
			this.wizard.Controls.Add(this.pageStart);
			this.wizard.HeaderImage = global::ns17.Class143.stripe;
			this.wizard.HeaderTitleFont = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.wizard.Location = new global::System.Drawing.Point(0, 0);
			this.wizard.Name = "wizard";
			this.wizard.Pages.method_0(new global::ns6.Class146[]
			{
				this.pageStart,
				this.import,
				this.clone,
				this.details,
				this.donePage
			});
			this.wizard.Size = new global::System.Drawing.Size(824, 466);
			this.wizard.TabIndex = 0;
			this.wizard.WelcomeImage = global::ns17.Class143.verticalstripe;
			this.wizard.BeforeSwitchPages += new global::ns19.Wizard.Delegate30(this.method_1);
			this.wizard.AfterSwitchPages += new global::ns19.Wizard.Delegate31(this.method_2);
			this.wizard.Finish += new global::System.EventHandler(this.method_16);
			this.donePage.Description = "You are now ready to create your own custom content. Click \"OK\" below to close this dialogue window and return to the TSR Workshop screen where your new project will load and become visible.";
			this.donePage.Location = new global::System.Drawing.Point(0, 0);
			this.donePage.Name = "donePage";
			this.donePage.Size = new global::System.Drawing.Size(824, 418);
			this.donePage.Style = global::ns11.Enum21.const_2;
			this.donePage.TabIndex = 12;
			this.donePage.Title = "Finished";
			this.details.Controls.Add(this.diagonalChoice);
			this.details.Controls.Add(this.description);
			this.details.Controls.Add(this.descriptionLabel);
			this.details.Controls.Add(this.title);
			this.details.Controls.Add(this.label3);
			this.details.Controls.Add(this.unique);
			this.details.Controls.Add(this.uniqueLabel);
			this.details.Controls.Add(this.projectName);
			this.details.Controls.Add(this.label1);
			this.details.Description = "Give your project a name and some additinal details";
			this.details.Location = new global::System.Drawing.Point(0, 0);
			this.details.Name = "details";
			this.details.Padding = new global::System.Windows.Forms.Padding(0, 64, 0, 0);
			this.details.Size = new global::System.Drawing.Size(824, 418);
			this.details.TabIndex = 13;
			this.details.Title = "Project details";
			this.diagonalChoice.Controls.Add(this.checkBox1);
			this.diagonalChoice.Controls.Add(this.label6);
			this.diagonalChoice.Controls.Add(this.label4);
			this.diagonalChoice.Location = new global::System.Drawing.Point(15, 285);
			this.diagonalChoice.Name = "diagonalChoice";
			this.diagonalChoice.Size = new global::System.Drawing.Size(540, 114);
			this.diagonalChoice.TabIndex = 15;
			this.diagonalChoice.TabStop = false;
			this.diagonalChoice.Text = "Diagonal part";
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new global::System.Drawing.Point(11, 82);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(306, 17);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Yes, clone the base item and add it as a diagonal reference";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(8, 58);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(287, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Doing so will include the diagonal cloned part in the project.";
			this.label4.Location = new global::System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(307, 34);
			this.label4.TabIndex = 0;
			this.label4.Text = "This item does not have a diagonal reference. Do you want to clone the base item and add it as a diagonal reference?";
			this.description.Location = new global::System.Drawing.Point(15, 190);
			this.description.MaxLength = 256;
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new global::System.Drawing.Size(540, 89);
			this.description.TabIndex = 14;
			this.descriptionLabel.AutoSize = true;
			this.descriptionLabel.Location = new global::System.Drawing.Point(12, 171);
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Size = new global::System.Drawing.Size(60, 13);
			this.descriptionLabel.TabIndex = 13;
			this.descriptionLabel.Text = "Description";
			this.title.Location = new global::System.Drawing.Point(15, 145);
			this.title.Name = "title";
			this.title.Size = new global::System.Drawing.Size(260, 20);
			this.title.TabIndex = 12;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(12, 126);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(27, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Title";
			this.unique.Location = new global::System.Drawing.Point(295, 100);
			this.unique.Name = "unique";
			this.unique.Size = new global::System.Drawing.Size(260, 20);
			this.unique.TabIndex = 10;
			this.unique.Visible = false;
			this.uniqueLabel.AutoSize = true;
			this.uniqueLabel.Location = new global::System.Drawing.Point(292, 81);
			this.uniqueLabel.Name = "uniqueLabel";
			this.uniqueLabel.Size = new global::System.Drawing.Size(84, 13);
			this.uniqueLabel.TabIndex = 9;
			this.uniqueLabel.Text = "Unique Identifier";
			this.uniqueLabel.Visible = false;
			this.projectName.Location = new global::System.Drawing.Point(15, 100);
			this.projectName.Name = "projectName";
			this.projectName.Size = new global::System.Drawing.Size(260, 20);
			this.projectName.TabIndex = 8;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 81);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(71, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Project Name";
			this.clone.Controls.Add(this.panel4);
			this.clone.Description = "Clone something";
			this.clone.Location = new global::System.Drawing.Point(0, 0);
			this.clone.Name = "clone";
			this.clone.Padding = new global::System.Windows.Forms.Padding(0, 64, 0, 0);
			this.clone.Size = new global::System.Drawing.Size(824, 418);
			this.clone.TabIndex = 11;
			this.panel4.Controls.Add(this.items);
			this.panel4.Controls.Add(this.panel6);
			this.panel4.Controls.Add(this.panel7);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new global::System.Drawing.Point(0, 64);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new global::System.Windows.Forms.Padding(4);
			this.panel4.Size = new global::System.Drawing.Size(824, 354);
			this.panel4.TabIndex = 7;
			this.items.ContextMenuStrip = this.contextMenuStrip1;
			this.items.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.items.Location = new global::System.Drawing.Point(204, 4);
			this.items.Name = "items";
			this.items.Size = new global::System.Drawing.Size(616, 316);
			this.items.TabIndex = 3;
			this.items.UseCompatibleStateImageBehavior = false;
			this.items.SelectedIndexChanged += new global::System.EventHandler(this.items_SelectedIndexChanged);
			this.items.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.items_MouseDoubleClick);
			this.panel6.BackColor = global::System.Drawing.SystemColors.Control;
			this.panel6.Controls.Add(this.panel8);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel6.Location = new global::System.Drawing.Point(204, 320);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new global::System.Windows.Forms.Padding(0, 5, 0, 0);
			this.panel6.Size = new global::System.Drawing.Size(616, 30);
			this.panel6.TabIndex = 7;
			this.panel6.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
			this.panel8.BackColor = global::System.Drawing.Color.White;
			this.panel8.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel8.Controls.Add(this.panel9);
			this.panel8.Controls.Add(this.pictureBox1);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new global::System.Drawing.Point(0, 5);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new global::System.Windows.Forms.Padding(3, 2, 0, 2);
			this.panel8.Size = new global::System.Drawing.Size(616, 25);
			this.panel8.TabIndex = 8;
			this.panel9.Controls.Add(this.filterSearch);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel9.Location = new global::System.Drawing.Point(19, 2);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new global::System.Windows.Forms.Padding(3, 2, 4, 0);
			this.panel9.Size = new global::System.Drawing.Size(595, 19);
			this.panel9.TabIndex = 11;
			this.filterSearch.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.filterSearch.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.filterSearch.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Point, 0);
			this.filterSearch.ForeColor = global::System.Drawing.SystemColors.WindowFrame;
			this.filterSearch.Location = new global::System.Drawing.Point(3, 2);
			this.filterSearch.Name = "filterSearch";
			this.filterSearch.Size = new global::System.Drawing.Size(588, 13);
			this.filterSearch.TabIndex = 11;
			this.filterSearch.Text = "type keyword here";
			this.filterSearch.TextChanged += new global::System.EventHandler(this.filterSearch_TextChanged);
			this.filterSearch.Enter += new global::System.EventHandler(this.filterSearch_Enter);
			this.filterSearch.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.filterSearch_KeyUp);
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.Image = global::ns17.Class143.view;
			this.pictureBox1.Location = new global::System.Drawing.Point(3, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(16, 19);
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			this.panel7.Controls.Add(this.treeView1);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel7.Location = new global::System.Drawing.Point(4, 4);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(0, 0, 4, 0);
			this.panel7.Size = new global::System.Drawing.Size(200, 346);
			this.panel7.TabIndex = 6;
			this.treeView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new global::System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new global::System.Drawing.Size(196, 346);
			this.treeView1.TabIndex = 4;
			this.treeView1.AfterSelect += new global::System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.import.Controls.Add(this.panel2);
			this.import.Description = "Select a .package file to import";
			this.import.Location = new global::System.Drawing.Point(0, 0);
			this.import.Name = "import";
			this.import.Padding = new global::System.Windows.Forms.Padding(0, 64, 0, 0);
			this.import.Size = new global::System.Drawing.Size(824, 418);
			this.import.TabIndex = 14;
			this.import.Title = "Import from .package";
			this.panel2.Controls.Add(this.newGroupId);
			this.panel2.Controls.Add(this.preserveGroupId);
			this.panel2.Controls.Add(this.projectTypeLabel);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.importImage);
			this.panel2.Controls.Add(this.nameLabel);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.browse);
			this.panel2.Controls.Add(this.importFile);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 64);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(824, 354);
			this.panel2.TabIndex = 0;
			this.newGroupId.Enabled = false;
			this.newGroupId.Location = new global::System.Drawing.Point(267, 172);
			this.newGroupId.Name = "newGroupId";
			this.newGroupId.Size = new global::System.Drawing.Size(110, 20);
			this.newGroupId.TabIndex = 12;
			this.newGroupId.Text = "0x00000000";
			this.newGroupId.TextChanged += new global::System.EventHandler(this.newGroupId_TextChanged);
			this.preserveGroupId.AutoSize = true;
			this.preserveGroupId.Checked = true;
			this.preserveGroupId.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.preserveGroupId.Location = new global::System.Drawing.Point(267, 152);
			this.preserveGroupId.Name = "preserveGroupId";
			this.preserveGroupId.Size = new global::System.Drawing.Size(115, 17);
			this.preserveGroupId.TabIndex = 10;
			this.preserveGroupId.Text = "Preserve group ID:";
			this.preserveGroupId.UseVisualStyleBackColor = true;
			this.preserveGroupId.CheckedChanged += new global::System.EventHandler(this.preserveGroupId_CheckedChanged);
			this.projectTypeLabel.BackColor = global::System.Drawing.Color.White;
			this.projectTypeLabel.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.projectTypeLabel.Location = new global::System.Drawing.Point(267, 79);
			this.projectTypeLabel.Name = "projectTypeLabel";
			this.projectTypeLabel.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 0);
			this.projectTypeLabel.Size = new global::System.Drawing.Size(234, 20);
			this.projectTypeLabel.TabIndex = 9;
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(264, 62);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(60, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Projectype:";
			this.importImage.BackColor = global::System.Drawing.Color.White;
			this.importImage.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.importImage.Location = new global::System.Drawing.Point(17, 62);
			this.importImage.Name = "importImage";
			this.importImage.Size = new global::System.Drawing.Size(238, 274);
			this.importImage.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.importImage.TabIndex = 7;
			this.importImage.TabStop = false;
			this.nameLabel.BackColor = global::System.Drawing.Color.White;
			this.nameLabel.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.nameLabel.Location = new global::System.Drawing.Point(267, 122);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 0);
			this.nameLabel.Size = new global::System.Drawing.Size(545, 20);
			this.nameLabel.TabIndex = 4;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(264, 105);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(38, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "Name:";
			this.browse.Location = new global::System.Drawing.Point(737, 30);
			this.browse.Name = "browse";
			this.browse.Size = new global::System.Drawing.Size(75, 21);
			this.browse.TabIndex = 2;
			this.browse.Text = "Browse";
			this.browse.UseVisualStyleBackColor = true;
			this.browse.Click += new global::System.EventHandler(this.browse_Click);
			this.importFile.Location = new global::System.Drawing.Point(16, 31);
			this.importFile.Name = "importFile";
			this.importFile.Size = new global::System.Drawing.Size(715, 20);
			this.importFile.TabIndex = 1;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(13, 14);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(69, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "File to import:";
			this.pageStart.Controls.Add(this.panel1);
			this.pageStart.Description = "Enter a name for the project and select a template";
			this.pageStart.Location = new global::System.Drawing.Point(0, 0);
			this.pageStart.Name = "pageStart";
			this.pageStart.Padding = new global::System.Windows.Forms.Padding(0, 64, 0, 0);
			this.pageStart.Size = new global::System.Drawing.Size(824, 418);
			this.pageStart.TabIndex = 10;
			this.pageStart.Title = "Create a new project";
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 64);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(824, 354);
			this.panel1.TabIndex = 9;
			this.panel3.Controls.Add(this.projectTemplate);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new global::System.Windows.Forms.Padding(4);
			this.panel3.Size = new global::System.Drawing.Size(824, 354);
			this.panel3.TabIndex = 9;
			this.projectTemplate.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader_0
			});
			this.projectTemplate.Dock = global::System.Windows.Forms.DockStyle.Fill;
			listViewGroup.Header = "Clone an item";
			listViewGroup.Name = "cloned";
			listViewGroup2.Header = "Import";
			listViewGroup2.Name = "new";
			this.projectTemplate.Groups.AddRange(new global::System.Windows.Forms.ListViewGroup[]
			{
				listViewGroup,
				listViewGroup2
			});
			this.projectTemplate.HideSelection = false;
			listViewItem.Group = listViewGroup;
			listViewItem.Tag = global::Sims3WorkshopSDK.Interfaces.ProjectType.CLOTHING;
			listViewItem2.Group = listViewGroup;
			listViewItem2.Tag = global::Sims3WorkshopSDK.Interfaces.ProjectType.MAKEUP;
			listViewItem3.Group = listViewGroup;
			listViewItem3.Tag = global::Sims3WorkshopSDK.Interfaces.ProjectType.HAIR;
			listViewItem4.Group = listViewGroup;
			listViewItem4.Tag = global::Sims3WorkshopSDK.Interfaces.ProjectType.ACCESSORY;
			listViewItem5.Group = listViewGroup;
			listViewItem5.Tag = global::Sims3WorkshopSDK.Interfaces.ProjectType.OBJECT;
			listViewItem6.Group = listViewGroup;
			listViewItem6.Tag = global::Sims3WorkshopSDK.Interfaces.ProjectType.MODULAR;
			listViewItem7.Group = listViewGroup;
			listViewItem7.Tag = global::Sims3WorkshopSDK.Interfaces.ProjectType.BUILD;
			listViewItem8.Group = listViewGroup2;
			listViewItem8.Tag = global::Sims3WorkshopSDK.Interfaces.ProjectType.CLOTHING;
			this.projectTemplate.Items.AddRange(new global::System.Windows.Forms.ListViewItem[]
			{
				listViewItem,
				listViewItem2,
				listViewItem3,
				listViewItem4,
				listViewItem5,
				listViewItem6,
				listViewItem7,
				listViewItem8
			});
			this.projectTemplate.LargeImageList = this.imageList_1;
			this.projectTemplate.Location = new global::System.Drawing.Point(4, 4);
			this.projectTemplate.MultiSelect = false;
			this.projectTemplate.Name = "projectTemplate";
			this.projectTemplate.Size = new global::System.Drawing.Size(816, 346);
			this.projectTemplate.TabIndex = 7;
			this.projectTemplate.UseCompatibleStateImageBehavior = false;
			this.projectTemplate.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.projectTemplate_MouseDoubleClick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(824, 488);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.statusStrip1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximumSize = new global::System.Drawing.Size(1500, 1500);
			this.MinimumSize = new global::System.Drawing.Size(387, 517);
			base.Name = "NewProjectForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Project";
			base.Load += new global::System.EventHandler(this.NewProjectForm_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.wizard.ResumeLayout(false);
			this.details.ResumeLayout(false);
			this.details.PerformLayout();
			this.diagonalChoice.ResumeLayout(false);
			this.diagonalChoice.PerformLayout();
			this.clone.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel7.ResumeLayout(false);
			this.import.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.importImage).EndInit();
			this.pageStart.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400024A RID: 586
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x0400024B RID: 587
		private global::ns19.Wizard wizard;

		// Token: 0x0400024C RID: 588
		private global::ns6.Class146 pageStart;

		// Token: 0x0400024D RID: 589
		private global::System.Windows.Forms.ListView projectTemplate;

		// Token: 0x0400024E RID: 590
		private global::ns6.Class146 donePage;

		// Token: 0x0400024F RID: 591
		private global::ns6.Class146 clone;

		// Token: 0x04000250 RID: 592
		private global::System.Windows.Forms.TreeView treeView1;

		// Token: 0x04000251 RID: 593
		private global::System.Windows.Forms.ColumnHeader columnHeader_0;

		// Token: 0x04000252 RID: 594
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000253 RID: 595
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000257 RID: 599
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000258 RID: 600
		private global::System.Windows.Forms.ListView items;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.ToolStripStatusLabel status;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.ToolStripProgressBar progress;

		// Token: 0x0400025B RID: 603
		private global::ns6.Class146 details;

		// Token: 0x0400025C RID: 604
		private global::System.Windows.Forms.TextBox projectName;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.TextBox unique;

		// Token: 0x0400025F RID: 607
		private global::System.Windows.Forms.Label uniqueLabel;

		// Token: 0x04000260 RID: 608
		private global::System.Windows.Forms.TextBox title;

		// Token: 0x04000261 RID: 609
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000262 RID: 610
		private global::System.Windows.Forms.TextBox description;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.Label descriptionLabel;

		// Token: 0x04000264 RID: 612
		private global::ns6.Class146 import;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.Button browse;

		// Token: 0x04000267 RID: 615
		private global::System.Windows.Forms.TextBox importFile;

		// Token: 0x04000268 RID: 616
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000269 RID: 617
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x0400026A RID: 618
		private global::System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.ToolStripMenuItem copyReskeyToolStripMenuItem;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.PictureBox importImage;

		// Token: 0x0400026D RID: 621
		private global::System.Windows.Forms.Label nameLabel;

		// Token: 0x0400026E RID: 622
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400026F RID: 623
		private global::System.Windows.Forms.Label projectTypeLabel;

		// Token: 0x04000270 RID: 624
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.CheckBox preserveGroupId;

		// Token: 0x04000272 RID: 626
		private global::System.Windows.Forms.TextBox newGroupId;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.GroupBox diagonalChoice;

		// Token: 0x04000274 RID: 628
		private global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x04000275 RID: 629
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000276 RID: 630
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000277 RID: 631
		public global::System.Windows.Forms.ImageList imageList_1;

		// Token: 0x04000278 RID: 632
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000279 RID: 633
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x0400027A RID: 634
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x0400027B RID: 635
		private global::System.Windows.Forms.TextBox filterSearch;

		// Token: 0x0400027C RID: 636
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
