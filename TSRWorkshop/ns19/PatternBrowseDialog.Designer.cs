namespace ns19
{
	// Token: 0x020000DE RID: 222
	internal sealed partial class PatternBrowseDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x06000938 RID: 2360 RVA: 0x0007FA1C File Offset: 0x0007DC1C
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			this.imageList_0 = new global::System.Windows.Forms.ImageList(this.icontainer_0);
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.progress = new global::System.Windows.Forms.ToolStripProgressBar();
			this.statusLabel = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.category = new global::System.Windows.Forms.ComboBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.cancelBtn = new global::System.Windows.Forms.Button();
			this.doneBtn = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.patternListView = new global::System.Windows.Forms.ListView();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.imageList_0.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList_0.ImageSize = new global::System.Drawing.Size(128, 128);
			this.imageList_0.TransparentColor = global::System.Drawing.Color.Transparent;
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.progress,
				this.statusLabel
			});
			this.statusStrip1.LayoutStyle = global::System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 499);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(564, 22);
			this.statusStrip1.TabIndex = 15;
			this.statusStrip1.Text = "statusStrip1";
			this.progress.Name = "progress";
			this.progress.Size = new global::System.Drawing.Size(100, 16);
			this.statusLabel.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.statusLabel.LinkColor = global::System.Drawing.Color.Blue;
			this.statusLabel.Margin = new global::System.Windows.Forms.Padding(0, 2, 0, 2);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new global::System.Drawing.Size(35, 18);
			this.statusLabel.Text = "Done";
			this.panel1.Controls.Add(this.category);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(6);
			this.panel1.Size = new global::System.Drawing.Size(564, 33);
			this.panel1.TabIndex = 19;
			this.category.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.category.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.category.FormattingEnabled = true;
			this.category.Items.AddRange(new object[]
			{
				"In Project",
				"Abstract",
				"Carpet/Rug",
				"Fabric",
				"Geometric",
				"Leather/Fur",
				"Masonry",
				"Metal",
				"Miscellaneous",
				"Theme",
				"Tile/Mosaic",
				"Paint",
				"Plastic/Rubber",
				"Rock/Stone",
				"Weave/Wicker",
				"Wood"
			});
			this.category.Location = new global::System.Drawing.Point(6, 6);
			this.category.Name = "category";
			this.category.Size = new global::System.Drawing.Size(552, 21);
			this.category.TabIndex = 11;
			this.category.SelectedIndexChanged += new global::System.EventHandler(this.category_SelectedIndexChanged);
			this.panel3.Controls.Add(this.cancelBtn);
			this.panel3.Controls.Add(this.doneBtn);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new global::System.Drawing.Point(0, 464);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(564, 35);
			this.panel3.TabIndex = 17;
			this.cancelBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelBtn.Location = new global::System.Drawing.Point(484, 4);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new global::System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 1;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new global::System.EventHandler(this.cancelBtn_Click);
			this.doneBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.doneBtn.Enabled = false;
			this.doneBtn.Location = new global::System.Drawing.Point(403, 4);
			this.doneBtn.Name = "doneBtn";
			this.doneBtn.Size = new global::System.Drawing.Size(75, 23);
			this.doneBtn.TabIndex = 0;
			this.doneBtn.Text = "Done";
			this.doneBtn.UseVisualStyleBackColor = true;
			this.doneBtn.Click += new global::System.EventHandler(this.doneBtn_Click);
			this.panel2.Controls.Add(this.patternListView);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 33);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(5, 0, 5, 5);
			this.panel2.Size = new global::System.Drawing.Size(564, 431);
			this.panel2.TabIndex = 20;
			this.patternListView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.patternListView.LargeImageList = this.imageList_0;
			this.patternListView.Location = new global::System.Drawing.Point(5, 0);
			this.patternListView.Name = "patternListView";
			this.patternListView.Size = new global::System.Drawing.Size(554, 426);
			this.patternListView.TabIndex = 19;
			this.patternListView.UseCompatibleStateImageBehavior = false;
			this.patternListView.SelectedIndexChanged += new global::System.EventHandler(this.patternListView_SelectedIndexChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(564, 521);
			base.ControlBox = false;
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.statusStrip1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Name = "PatternBrowseDialog";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pattern Browser";
			base.Shown += new global::System.EventHandler(this.PatternBrowseDialog_Shown);
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.PatternBrowseDialog_FormClosing);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000754 RID: 1876
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000755 RID: 1877
		private global::System.Windows.Forms.ImageList imageList_0;

		// Token: 0x04000756 RID: 1878
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x04000757 RID: 1879
		private global::System.Windows.Forms.ToolStripProgressBar progress;

		// Token: 0x04000758 RID: 1880
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000759 RID: 1881
		private global::System.Windows.Forms.ComboBox category;

		// Token: 0x0400075A RID: 1882
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400075B RID: 1883
		private global::System.Windows.Forms.Button cancelBtn;

		// Token: 0x0400075C RID: 1884
		private global::System.Windows.Forms.Button doneBtn;

		// Token: 0x0400075D RID: 1885
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400075E RID: 1886
		private global::System.Windows.Forms.ListView patternListView;

		// Token: 0x0400075F RID: 1887
		private global::System.Windows.Forms.ToolStripStatusLabel statusLabel;
	}
}
