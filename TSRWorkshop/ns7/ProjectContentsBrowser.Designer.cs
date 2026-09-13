namespace ns7
{
	// Token: 0x020000E3 RID: 227
	internal sealed partial class ProjectContentsBrowser : global::System.Windows.Forms.Form
	{
		// Token: 0x06000967 RID: 2407 RVA: 0x00082600 File Offset: 0x00080800
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns7.ProjectContentsBrowser));
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.ddsPreviewImage = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.columnHeader_0 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader_1 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader_2 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader_3 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader_4 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader_5 = new global::System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
			this.ctxImport = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ctxExport = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.cpyReskey = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.editToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.renumberToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.pjExportMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.pjImportMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.statusLabel = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.ddsPreviewImage).BeginInit();
			this.panel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			base.SuspendLayout();
			this.button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button2.Location = new global::System.Drawing.Point(590, 414);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Location = new global::System.Drawing.Point(695, 414);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel3.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel3.Controls.Add(this.panel5);
			this.panel3.Location = new global::System.Drawing.Point(580, 25);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(200, 187);
			this.panel3.TabIndex = 3;
			this.panel5.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel5.Controls.Add(this.ddsPreviewImage);
			this.panel5.Location = new global::System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new global::System.Windows.Forms.Padding(10);
			this.panel5.Size = new global::System.Drawing.Size(200, 187);
			this.panel5.TabIndex = 2;
			this.ddsPreviewImage.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.ddsPreviewImage.BackColor = global::System.Drawing.Color.White;
			this.ddsPreviewImage.BackgroundImage = global::ns17.Class143.alphacheck;
			this.ddsPreviewImage.Location = new global::System.Drawing.Point(10, 10);
			this.ddsPreviewImage.Name = "ddsPreviewImage";
			this.ddsPreviewImage.Size = new global::System.Drawing.Size(180, 153);
			this.ddsPreviewImage.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.ddsPreviewImage.TabIndex = 1;
			this.ddsPreviewImage.TabStop = false;
			this.panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel1.Controls.Add(this.listView1);
			this.panel1.Location = new global::System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(10);
			this.panel1.Size = new global::System.Drawing.Size(575, 420);
			this.panel1.TabIndex = 4;
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader_0,
				this.columnHeader_1,
				this.columnHeader_2,
				this.columnHeader_3,
				this.columnHeader_4,
				this.columnHeader_5
			});
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new global::System.Drawing.Point(10, 10);
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(555, 400);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new global::System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			this.listView1.Click += new global::System.EventHandler(this.listView1_Click);
			this.columnHeader_0.Text = "Type";
			this.columnHeader_1.Text = "GroupID";
			this.columnHeader_2.Text = "InstanceID";
			this.columnHeader_2.Width = 86;
			this.columnHeader_3.Text = "Second Instance ID";
			this.columnHeader_3.Width = 110;
			this.columnHeader_4.Text = "Size uncompressed";
			this.columnHeader_4.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader_4.Width = 106;
			this.columnHeader_5.Text = "Size compressed";
			this.columnHeader_5.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader_5.Width = 94;
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.ctxImport,
				this.ctxExport,
				this.toolStripSeparator1,
				this.cpyReskey,
				this.toolStripSeparator2,
				this.editToolStripMenuItem,
				this.removeToolStripMenuItem,
				this.renumberToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(139, 148);
			this.contextMenuStrip1.Opening += new global::System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			this.ctxImport.Name = "ctxImport";
			this.ctxImport.Size = new global::System.Drawing.Size(138, 22);
			this.ctxImport.Text = "Import";
			this.ctxImport.Click += new global::System.EventHandler(this.ctxImport_Click);
			this.ctxExport.Name = "ctxExport";
			this.ctxExport.Size = new global::System.Drawing.Size(138, 22);
			this.ctxExport.Text = "Export";
			this.ctxExport.Click += new global::System.EventHandler(this.ctxExport_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(135, 6);
			this.cpyReskey.Name = "cpyReskey";
			this.cpyReskey.Size = new global::System.Drawing.Size(138, 22);
			this.cpyReskey.Text = "Copy reskey";
			this.cpyReskey.Click += new global::System.EventHandler(this.cpyReskey_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(135, 6);
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new global::System.Drawing.Size(138, 22);
			this.editToolStripMenuItem.Text = "Edit";
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new global::System.Drawing.Size(138, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new global::System.EventHandler(this.removeToolStripMenuItem_Click);
			this.renumberToolStripMenuItem.Name = "renumberToolStripMenuItem";
			this.renumberToolStripMenuItem.Size = new global::System.Drawing.Size(138, 22);
			this.renumberToolStripMenuItem.Text = "Renumber";
			this.renumberToolStripMenuItem.Click += new global::System.EventHandler(this.renumberToolStripMenuItem_Click);
			this.panel4.Controls.Add(this.menuStrip1);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(782, 25);
			this.panel4.TabIndex = 5;
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.pjExportMenuItem,
				this.pjImportMenuItem
			});
			this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(782, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.pjExportMenuItem.Name = "pjExportMenuItem";
			this.pjExportMenuItem.Size = new global::System.Drawing.Size(52, 20);
			this.pjExportMenuItem.Text = "Export";
			this.pjImportMenuItem.Name = "pjImportMenuItem";
			this.pjImportMenuItem.Size = new global::System.Drawing.Size(55, 20);
			this.pjImportMenuItem.Text = "Import";
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.statusLabel
			});
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 448);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(782, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new global::System.Drawing.Size(0, 17);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(782, 470);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel4);
			this.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "ProjectContentsBrowser";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Project Contents";
			base.Load += new global::System.EventHandler(this.ProjectContentsBrowser_Load);
			this.panel3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.ddsPreviewImage).EndInit();
			this.panel1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400077F RID: 1919
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000780 RID: 1920
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000781 RID: 1921
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000782 RID: 1922
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000783 RID: 1923
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000784 RID: 1924
		private global::System.Windows.Forms.PictureBox ddsPreviewImage;

		// Token: 0x04000785 RID: 1925
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000786 RID: 1926
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x04000787 RID: 1927
		private global::System.Windows.Forms.ColumnHeader columnHeader_0;

		// Token: 0x04000788 RID: 1928
		private global::System.Windows.Forms.ColumnHeader columnHeader_1;

		// Token: 0x04000789 RID: 1929
		private global::System.Windows.Forms.ColumnHeader columnHeader_2;

		// Token: 0x0400078A RID: 1930
		private global::System.Windows.Forms.ColumnHeader columnHeader_3;

		// Token: 0x0400078B RID: 1931
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x0400078C RID: 1932
		private global::System.Windows.Forms.ToolStripMenuItem ctxExport;

		// Token: 0x0400078D RID: 1933
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		// Token: 0x0400078E RID: 1934
		private global::System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;

		// Token: 0x0400078F RID: 1935
		private global::System.Windows.Forms.ToolStripMenuItem ctxImport;

		// Token: 0x04000790 RID: 1936
		private global::System.Windows.Forms.ToolStripMenuItem cpyReskey;

		// Token: 0x04000791 RID: 1937
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		// Token: 0x04000792 RID: 1938
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000793 RID: 1939
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x04000794 RID: 1940
		private global::System.Windows.Forms.ToolStripMenuItem pjExportMenuItem;

		// Token: 0x04000795 RID: 1941
		private global::System.Windows.Forms.ToolStripMenuItem pjImportMenuItem;

		// Token: 0x04000796 RID: 1942
		private global::System.Windows.Forms.ColumnHeader columnHeader_4;

		// Token: 0x04000797 RID: 1943
		private global::System.Windows.Forms.ColumnHeader columnHeader_5;

		// Token: 0x04000798 RID: 1944
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x04000799 RID: 1945
		private global::System.Windows.Forms.ToolStripStatusLabel statusLabel;

		// Token: 0x0400079A RID: 1946
		private global::System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;

		// Token: 0x0400079B RID: 1947
		private global::System.Windows.Forms.ToolStripMenuItem renumberToolStripMenuItem;
	}
}
