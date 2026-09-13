namespace ns12
{
	// Token: 0x0200004B RID: 75
	internal sealed partial class ObjdVersionDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x060002F4 RID: 756 RVA: 0x00038138 File Offset: 0x00036338
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns12.ObjdVersionDialog));
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.okButton = new global::System.Windows.Forms.Button();
			this.v01a = new global::System.Windows.Forms.CheckBox();
			this.v01c = new global::System.Windows.Forms.CheckBox();
			this.v017 = new global::System.Windows.Forms.CheckBox();
			this.v020 = new global::System.Windows.Forms.CheckBox();
			this.v021 = new global::System.Windows.Forms.CheckBox();
			this.v019 = new global::System.Windows.Forms.CheckBox();
			this.v01b = new global::System.Windows.Forms.CheckBox();
			this.v01d = new global::System.Windows.Forms.CheckBox();
			this.v01e = new global::System.Windows.Forms.CheckBox();
			this.v01f = new global::System.Windows.Forms.CheckBox();
			this.v022 = new global::System.Windows.Forms.CheckBox();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(196, 297);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.okButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.okButton.Location = new global::System.Drawing.Point(115, 297);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.v01a.AutoSize = true;
			this.v01a.Location = new global::System.Drawing.Point(12, 84);
			this.v01a.Name = "v01a";
			this.v01a.Size = new global::System.Drawing.Size(160, 17);
			this.v01a.TabIndex = 2;
			this.v01a.Tag = "26";
			this.v01a.Text = "Extended Object Type Flags";
			this.v01a.UseVisualStyleBackColor = true;
			this.v01a.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.v01c.AutoSize = true;
			this.v01c.Location = new global::System.Drawing.Point(12, 130);
			this.v01c.Name = "v01c";
			this.v01c.Size = new global::System.Drawing.Size(162, 17);
			this.v01c.TabIndex = 3;
			this.v01c.Tag = "28";
			this.v01c.Text = "Extended Subcategory Flags";
			this.v01c.UseVisualStyleBackColor = true;
			this.v01c.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.v017.AutoSize = true;
			this.v017.Location = new global::System.Drawing.Point(12, 38);
			this.v017.Name = "v017";
			this.v017.Size = new global::System.Drawing.Size(77, 17);
			this.v017.TabIndex = 4;
			this.v017.Tag = "23";
			this.v017.Text = "Floor mask";
			this.v017.UseVisualStyleBackColor = true;
			this.v017.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.v020.AutoSize = true;
			this.v020.Location = new global::System.Drawing.Point(12, 222);
			this.v020.Name = "v020";
			this.v020.Size = new global::System.Drawing.Size(160, 17);
			this.v020.TabIndex = 5;
			this.v020.Tag = "32";
			this.v020.Text = "Extended floor mask bounds";
			this.v020.UseVisualStyleBackColor = true;
			this.v020.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.v021.AutoSize = true;
			this.v021.Location = new global::System.Drawing.Point(12, 245);
			this.v021.Name = "v021";
			this.v021.Size = new global::System.Drawing.Size(106, 17);
			this.v021.TabIndex = 6;
			this.v021.Tag = "33";
			this.v021.Text = "Floor mask offset";
			this.v021.UseVisualStyleBackColor = true;
			this.v021.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.v019.AutoSize = true;
			this.v019.Location = new global::System.Drawing.Point(12, 61);
			this.v019.Name = "v019";
			this.v019.Size = new global::System.Drawing.Size(106, 17);
			this.v019.TabIndex = 7;
			this.v019.Tag = "25";
			this.v019.Text = "Underside object";
			this.v019.UseVisualStyleBackColor = true;
			this.v019.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.v01b.AutoSize = true;
			this.v01b.Location = new global::System.Drawing.Point(12, 107);
			this.v01b.Name = "v01b";
			this.v01b.Size = new global::System.Drawing.Size(84, 17);
			this.v01b.TabIndex = 8;
			this.v01b.Tag = "27";
			this.v01b.Text = "Proxy object";
			this.v01b.UseVisualStyleBackColor = true;
			this.v01b.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.v01d.AutoSize = true;
			this.v01d.Location = new global::System.Drawing.Point(12, 153);
			this.v01d.Name = "v01d";
			this.v01d.Size = new global::System.Drawing.Size(92, 17);
			this.v01d.TabIndex = 9;
			this.v01d.Tag = "29";
			this.v01d.Text = "Blueprint XML";
			this.v01d.UseVisualStyleBackColor = true;
			this.v01d.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.v01e.AutoSize = true;
			this.v01e.Location = new global::System.Drawing.Point(12, 176);
			this.v01e.Name = "v01e";
			this.v01e.Size = new global::System.Drawing.Size(91, 17);
			this.v01e.TabIndex = 10;
			this.v01e.Tag = "30";
			this.v01e.Text = "Blueprint Icon";
			this.v01e.UseVisualStyleBackColor = true;
			this.v01e.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.v01f.AutoSize = true;
			this.v01f.Location = new global::System.Drawing.Point(12, 199);
			this.v01f.Name = "v01f";
			this.v01f.Size = new global::System.Drawing.Size(122, 17);
			this.v01f.TabIndex = 11;
			this.v01f.Tag = "31";
			this.v01f.Text = "Blueprint Icon Offset";
			this.v01f.UseVisualStyleBackColor = true;
			this.v01f.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.v022.AutoSize = true;
			this.v022.Location = new global::System.Drawing.Point(12, 268);
			this.v022.Name = "v022";
			this.v022.Size = new global::System.Drawing.Size(89, 17);
			this.v022.TabIndex = 12;
			this.v022.Tag = "34";
			this.v022.Text = "Modular Arch";
			this.v022.UseVisualStyleBackColor = true;
			this.v022.CheckedChanged += new global::System.EventHandler(this.v022_CheckedChanged);
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new global::System.Drawing.Point(12, 15);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(159, 17);
			this.checkBox1.TabIndex = 13;
			this.checkBox1.Tag = "22";
			this.checkBox1.Text = "Standard object (version 22)";
			this.checkBox1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(283, 332);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.v022);
			base.Controls.Add(this.v01f);
			base.Controls.Add(this.v01e);
			base.Controls.Add(this.v01d);
			base.Controls.Add(this.v01b);
			base.Controls.Add(this.v019);
			base.Controls.Add(this.v021);
			base.Controls.Add(this.v020);
			base.Controls.Add(this.v017);
			base.Controls.Add(this.v01c);
			base.Controls.Add(this.v01a);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.cancelButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ObjdVersionDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "OBJD Version";
			base.Load += new global::System.EventHandler(this.ObjdVersionDialog_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000298 RID: 664
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x04000299 RID: 665
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x0400029A RID: 666
		private global::System.Windows.Forms.CheckBox v01a;

		// Token: 0x0400029B RID: 667
		private global::System.Windows.Forms.CheckBox v01c;

		// Token: 0x0400029C RID: 668
		private global::System.Windows.Forms.CheckBox v017;

		// Token: 0x0400029D RID: 669
		private global::System.Windows.Forms.CheckBox v020;

		// Token: 0x0400029E RID: 670
		private global::System.Windows.Forms.CheckBox v021;

		// Token: 0x0400029F RID: 671
		private global::System.Windows.Forms.CheckBox v019;

		// Token: 0x040002A0 RID: 672
		private global::System.Windows.Forms.CheckBox v01b;

		// Token: 0x040002A1 RID: 673
		private global::System.Windows.Forms.CheckBox v01d;

		// Token: 0x040002A2 RID: 674
		private global::System.Windows.Forms.CheckBox v01e;

		// Token: 0x040002A3 RID: 675
		private global::System.Windows.Forms.CheckBox v01f;

		// Token: 0x040002A4 RID: 676
		private global::System.Windows.Forms.CheckBox v022;

		// Token: 0x040002A5 RID: 677
		private global::System.Windows.Forms.CheckBox checkBox1;
	}
}
