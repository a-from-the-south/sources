namespace ns14
{
	// Token: 0x02000037 RID: 55
	internal sealed partial class AutoBoneAssigment : global::System.Windows.Forms.Form
	{
		// Token: 0x06000213 RID: 531 RVA: 0x00028F08 File Offset: 0x00027108
		private void InitializeComponent()
		{
			global::System.Windows.Forms.ListViewItem listViewItem = new global::System.Windows.Forms.ListViewItem("Group 0 - 6 vertices and 2 faces");
			global::System.Windows.Forms.ListViewItem listViewItem2 = new global::System.Windows.Forms.ListViewItem("Group 1");
			global::System.Windows.Forms.ListViewItem listViewItem3 = new global::System.Windows.Forms.ListViewItem("Group 3");
			global::System.Windows.Forms.ListViewItem listViewItem4 = new global::System.Windows.Forms.ListViewItem("Group 4");
			global::System.Windows.Forms.ListViewItem listViewItem5 = new global::System.Windows.Forms.ListViewItem("Group 5");
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.columnHeader_1 = new global::System.Windows.Forms.ColumnHeader();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.autoMorph = new global::System.Windows.Forms.CheckBox();
			this.autoBone = new global::System.Windows.Forms.CheckBox();
			this.listView2 = new global::System.Windows.Forms.ListView();
			this.columnHeader_0 = new global::System.Windows.Forms.ColumnHeader();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 445);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(487, 34);
			this.panel1.TabIndex = 0;
			this.button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button2.Location = new global::System.Drawing.Point(324, 6);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Location = new global::System.Drawing.Point(405, 6);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel2.Controls.Add(this.splitContainer1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 40);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(487, 405);
			this.panel2.TabIndex = 1;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.listView1);
			this.splitContainer1.Panel1.Controls.Add(this.panel4);
			this.splitContainer1.Panel2.Controls.Add(this.listView2);
			this.splitContainer1.Panel2.Controls.Add(this.panel3);
			this.splitContainer1.Size = new global::System.Drawing.Size(487, 405);
			this.splitContainer1.SplitterDistance = 222;
			this.splitContainer1.TabIndex = 0;
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader_1
			});
			this.listView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			listViewItem.StateImageIndex = 0;
			listViewItem2.StateImageIndex = 0;
			listViewItem3.StateImageIndex = 0;
			listViewItem4.StateImageIndex = 0;
			listViewItem5.StateImageIndex = 0;
			this.listView1.Items.AddRange(new global::System.Windows.Forms.ListViewItem[]
			{
				listViewItem,
				listViewItem2,
				listViewItem3,
				listViewItem4,
				listViewItem5
			});
			this.listView1.Location = new global::System.Drawing.Point(0, 36);
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(222, 369);
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new global::System.EventHandler(this.listView1_SelectedIndexChanged);
			this.columnHeader_1.Text = "Groupname";
			this.columnHeader_1.Width = 218;
			this.panel4.Controls.Add(this.autoMorph);
			this.panel4.Controls.Add(this.autoBone);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(222, 36);
			this.panel4.TabIndex = 1;
			this.autoMorph.AutoSize = true;
			this.autoMorph.Location = new global::System.Drawing.Point(102, 10);
			this.autoMorph.Name = "autoMorph";
			this.autoMorph.Size = new global::System.Drawing.Size(80, 17);
			this.autoMorph.TabIndex = 1;
			this.autoMorph.Text = "Auto morph";
			this.autoMorph.UseVisualStyleBackColor = true;
			this.autoBone.AutoSize = true;
			this.autoBone.Checked = true;
			this.autoBone.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.autoBone.Location = new global::System.Drawing.Point(7, 10);
			this.autoBone.Name = "autoBone";
			this.autoBone.Size = new global::System.Drawing.Size(89, 17);
			this.autoBone.TabIndex = 0;
			this.autoBone.Text = "Assign bones";
			this.autoBone.UseVisualStyleBackColor = true;
			this.listView2.CheckBoxes = true;
			this.listView2.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader_0
			});
			this.listView2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listView2.Location = new global::System.Drawing.Point(0, 36);
			this.listView2.Name = "listView2";
			this.listView2.Size = new global::System.Drawing.Size(261, 369);
			this.listView2.TabIndex = 1;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = global::System.Windows.Forms.View.Details;
			this.listView2.ItemCheck += new global::System.Windows.Forms.ItemCheckEventHandler(this.listView2_ItemCheck);
			this.columnHeader_0.Text = "Groupname";
			this.columnHeader_0.Width = 257;
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.comboBox1);
			this.panel3.Controls.Add(this.linkLabel1);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(261, 36);
			this.panel3.TabIndex = 0;
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new global::System.Drawing.Point(146, 12);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new global::System.Drawing.Size(108, 13);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Load reference WSO";
			this.linkLabel1.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			this.comboBox1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[]
			{
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"10"
			});
			this.comboBox1.Location = new global::System.Drawing.Point(106, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(34, 21);
			this.comboBox1.TabIndex = 1;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(94, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Interpolation Level";
			this.label2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new global::System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Padding = new global::System.Windows.Forms.Padding(4, 6, 4, 4);
			this.label2.Size = new global::System.Drawing.Size(487, 40);
			this.label2.TabIndex = 2;
			this.label2.Text = "The reference mesh needs to contain vertex information both all parts of your mesh, i.e if you have both bottom and top parts the reference mesh needs to have both bottom and top too.";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(487, 479);
			base.ControlBox = false;
			base.Controls.Add(this.label2);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "AutoBoneAssigment";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Auto Bone and Auto Morph";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040001AD RID: 429
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040001AE RID: 430
		private global::System.Windows.Forms.Button button2;

		// Token: 0x040001AF RID: 431
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040001B0 RID: 432
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040001B1 RID: 433
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040001B2 RID: 434
		private global::System.Windows.Forms.ListView listView2;

		// Token: 0x040001B3 RID: 435
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040001B4 RID: 436
		private global::System.Windows.Forms.LinkLabel linkLabel1;

		// Token: 0x040001B5 RID: 437
		private global::System.Windows.Forms.ColumnHeader columnHeader_0;

		// Token: 0x040001B6 RID: 438
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x040001B7 RID: 439
		private global::System.Windows.Forms.ColumnHeader columnHeader_1;

		// Token: 0x040001B8 RID: 440
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040001B9 RID: 441
		private global::System.Windows.Forms.CheckBox autoMorph;

		// Token: 0x040001BA RID: 442
		private global::System.Windows.Forms.CheckBox autoBone;

		// Token: 0x040001BB RID: 443
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040001BC RID: 444
		private global::System.Windows.Forms.ComboBox comboBox1;

		// Token: 0x040001BD RID: 445
		private global::System.Windows.Forms.Label label2;
	}
}
