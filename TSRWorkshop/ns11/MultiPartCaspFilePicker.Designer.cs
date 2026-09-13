namespace ns11
{
	// Token: 0x020000DC RID: 220
	internal sealed partial class MultiPartCaspFilePicker : global::System.Windows.Forms.Form
	{
		// Token: 0x0600091C RID: 2332 RVA: 0x0007EA84 File Offset: 0x0007CC84
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns11.MultiPartCaspFilePicker));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.okButton = new global::System.Windows.Forms.Button();
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.columnHeader_0 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader_1 = new global::System.Windows.Forms.ColumnHeader();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.okButton);
			this.panel1.Controls.Add(this.cancelButton);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 180);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(368, 33);
			this.panel1.TabIndex = 0;
			this.okButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.okButton.Location = new global::System.Drawing.Point(208, 5);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(287, 5);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader_0,
				this.columnHeader_1
			});
			this.listView1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new global::System.Drawing.Point(0, 41);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.OwnerDraw = true;
			this.listView1.Size = new global::System.Drawing.Size(368, 139);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.listView1.DrawColumnHeader += new global::System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
			this.listView1.DrawItem += new global::System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
			this.listView1.DrawSubItem += new global::System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
			this.listView1.ItemChecked += new global::System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
			this.listView1.DoubleClick += new global::System.EventHandler(this.listView1_DoubleClick);
			this.columnHeader_0.Text = "";
			this.columnHeader_0.Width = 74;
			this.columnHeader_1.Text = "Import from";
			this.columnHeader_1.Width = 289;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new global::System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new global::System.Windows.Forms.Padding(4, 7, 4, 4);
			this.label1.Size = new global::System.Drawing.Size(368, 38);
			this.label1.TabIndex = 2;
			this.label1.Text = "This CASP has multiple groups and morphstates, each group will be imported from a separate file.";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(368, 213);
			base.ControlBox = false;
			base.Controls.Add(this.label1);
			base.Controls.Add(this.listView1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "MultiPartCaspFilePicker";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select files";
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000741 RID: 1857
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000742 RID: 1858
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x04000743 RID: 1859
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x04000744 RID: 1860
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x04000745 RID: 1861
		private global::System.Windows.Forms.ColumnHeader columnHeader_0;

		// Token: 0x04000746 RID: 1862
		private global::System.Windows.Forms.ColumnHeader columnHeader_1;

		// Token: 0x04000747 RID: 1863
		private global::System.Windows.Forms.Label label1;
	}
}
