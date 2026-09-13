namespace ns6
{
	// Token: 0x0200003A RID: 58
	internal sealed partial class BitmapImportDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600022B RID: 555 RVA: 0x0002A120 File Offset: 0x00028320
		private void InitializeComponent()
		{
			this.btnContinue = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.alphaGroup = new global::System.Windows.Forms.GroupBox();
			this.keepAlpha = new global::System.Windows.Forms.RadioButton();
			this.alphaFull = new global::System.Windows.Forms.RadioButton();
			this.alphaEmpty = new global::System.Windows.Forms.RadioButton();
			this.alphaFromImage = new global::System.Windows.Forms.RadioButton();
			this.setImgBtn = new global::System.Windows.Forms.Button();
			this.enableAlpha = new global::System.Windows.Forms.CheckBox();
			this.preview = new global::ns17.Control0();
			this.viewRed = new global::System.Windows.Forms.CheckBox();
			this.viewGreen = new global::System.Windows.Forms.CheckBox();
			this.viewBlue = new global::System.Windows.Forms.CheckBox();
			this.viewAlpha = new global::System.Windows.Forms.CheckBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.alphaGroup.SuspendLayout();
			base.SuspendLayout();
			this.btnContinue.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnContinue.Location = new global::System.Drawing.Point(111, 479);
			this.btnContinue.Name = "btnContinue";
			this.btnContinue.Size = new global::System.Drawing.Size(75, 23);
			this.btnContinue.TabIndex = 8;
			this.btnContinue.Text = "Continue";
			this.btnContinue.UseVisualStyleBackColor = true;
			this.btnContinue.Click += new global::System.EventHandler(this.btnContinue_Click);
			this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(192, 479);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 37;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.alphaGroup.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.alphaGroup.Controls.Add(this.setImgBtn);
			this.alphaGroup.Controls.Add(this.alphaFromImage);
			this.alphaGroup.Controls.Add(this.alphaEmpty);
			this.alphaGroup.Controls.Add(this.alphaFull);
			this.alphaGroup.Controls.Add(this.keepAlpha);
			this.alphaGroup.Location = new global::System.Drawing.Point(11, 14);
			this.alphaGroup.Name = "alphaGroup";
			this.alphaGroup.Size = new global::System.Drawing.Size(260, 118);
			this.alphaGroup.TabIndex = 39;
			this.alphaGroup.TabStop = false;
			this.alphaGroup.Text = "     ";
			this.keepAlpha.AutoSize = true;
			this.keepAlpha.Checked = true;
			this.keepAlpha.Location = new global::System.Drawing.Point(12, 20);
			this.keepAlpha.Name = "keepAlpha";
			this.keepAlpha.Size = new global::System.Drawing.Size(115, 17);
			this.keepAlpha.TabIndex = 0;
			this.keepAlpha.TabStop = true;
			this.keepAlpha.Text = "Keep current alpha";
			this.keepAlpha.UseVisualStyleBackColor = true;
			this.keepAlpha.CheckedChanged += new global::System.EventHandler(this.alphaFromImage_CheckedChanged);
			this.alphaFull.AutoSize = true;
			this.alphaFull.Location = new global::System.Drawing.Point(12, 43);
			this.alphaFull.Name = "alphaFull";
			this.alphaFull.Size = new global::System.Drawing.Size(119, 17);
			this.alphaFull.TabIndex = 1;
			this.alphaFull.Text = "Fully opaque (white)";
			this.alphaFull.UseVisualStyleBackColor = true;
			this.alphaFull.CheckedChanged += new global::System.EventHandler(this.alphaFromImage_CheckedChanged);
			this.alphaEmpty.AutoSize = true;
			this.alphaEmpty.Location = new global::System.Drawing.Point(12, 66);
			this.alphaEmpty.Name = "alphaEmpty";
			this.alphaEmpty.Size = new global::System.Drawing.Size(137, 17);
			this.alphaEmpty.TabIndex = 2;
			this.alphaEmpty.Text = "Fully transparent (black)";
			this.alphaEmpty.UseVisualStyleBackColor = true;
			this.alphaEmpty.CheckedChanged += new global::System.EventHandler(this.alphaFromImage_CheckedChanged);
			this.alphaFromImage.AutoSize = true;
			this.alphaFromImage.Enabled = false;
			this.alphaFromImage.Location = new global::System.Drawing.Point(12, 89);
			this.alphaFromImage.Name = "alphaFromImage";
			this.alphaFromImage.Size = new global::System.Drawing.Size(143, 17);
			this.alphaFromImage.TabIndex = 3;
			this.alphaFromImage.Text = "Set from grayscale image";
			this.alphaFromImage.UseVisualStyleBackColor = true;
			this.alphaFromImage.CheckedChanged += new global::System.EventHandler(this.alphaFromImage_CheckedChanged);
			this.setImgBtn.Location = new global::System.Drawing.Point(179, 86);
			this.setImgBtn.Name = "setImgBtn";
			this.setImgBtn.Size = new global::System.Drawing.Size(75, 23);
			this.setImgBtn.TabIndex = 4;
			this.setImgBtn.Text = "Set image";
			this.setImgBtn.UseVisualStyleBackColor = true;
			this.setImgBtn.Click += new global::System.EventHandler(this.setImgBtn_Click);
			this.enableAlpha.AutoSize = true;
			this.enableAlpha.Checked = true;
			this.enableAlpha.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.enableAlpha.Location = new global::System.Drawing.Point(23, 12);
			this.enableAlpha.Name = "enableAlpha";
			this.enableAlpha.Size = new global::System.Drawing.Size(131, 17);
			this.enableAlpha.TabIndex = 5;
			this.enableAlpha.Text = "Enable Alpha Channel";
			this.enableAlpha.UseVisualStyleBackColor = true;
			this.enableAlpha.CheckedChanged += new global::System.EventHandler(this.enableAlpha_CheckedChanged);
			this.preview.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.preview.BackgroundColor = global::System.Drawing.Color.Empty;
			this.preview.BlueMult = 0f;
			this.preview.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.preview.Brightness = 0f;
			this.preview.DefaultClickAction = global::ns17.Control0.Enum3.const_0;
			this.preview.DefaultDragAction = global::ns17.Control0.Enum4.const_0;
			this.preview.FitToView = false;
			this.preview.GreenMult = 0f;
			this.preview.Image = null;
			this.preview.Location = new global::System.Drawing.Point(11, 166);
			this.preview.Name = "preview";
			this.preview.RedMult = 0f;
			this.preview.Size = new global::System.Drawing.Size(255, 254);
			this.preview.TabIndex = 40;
			this.preview.UseAlpha = true;
			this.preview.UseBlue = true;
			this.preview.UseGreen = true;
			this.preview.UseRed = true;
			this.preview.Zoom = 1f;
			this.viewRed.AutoSize = true;
			this.viewRed.Checked = true;
			this.viewRed.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.viewRed.Location = new global::System.Drawing.Point(12, 427);
			this.viewRed.Name = "viewRed";
			this.viewRed.Size = new global::System.Drawing.Size(46, 17);
			this.viewRed.TabIndex = 41;
			this.viewRed.Text = "Red";
			this.viewRed.UseVisualStyleBackColor = true;
			this.viewRed.CheckedChanged += new global::System.EventHandler(this.viewAlpha_CheckedChanged);
			this.viewGreen.AutoSize = true;
			this.viewGreen.Checked = true;
			this.viewGreen.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.viewGreen.Location = new global::System.Drawing.Point(64, 427);
			this.viewGreen.Name = "viewGreen";
			this.viewGreen.Size = new global::System.Drawing.Size(55, 17);
			this.viewGreen.TabIndex = 42;
			this.viewGreen.Text = "Green";
			this.viewGreen.UseVisualStyleBackColor = true;
			this.viewGreen.CheckedChanged += new global::System.EventHandler(this.viewAlpha_CheckedChanged);
			this.viewBlue.AutoSize = true;
			this.viewBlue.Checked = true;
			this.viewBlue.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.viewBlue.Location = new global::System.Drawing.Point(121, 427);
			this.viewBlue.Name = "viewBlue";
			this.viewBlue.Size = new global::System.Drawing.Size(47, 17);
			this.viewBlue.TabIndex = 43;
			this.viewBlue.Text = "Blue";
			this.viewBlue.UseVisualStyleBackColor = true;
			this.viewBlue.CheckedChanged += new global::System.EventHandler(this.viewAlpha_CheckedChanged);
			this.viewAlpha.AutoSize = true;
			this.viewAlpha.Checked = true;
			this.viewAlpha.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.viewAlpha.Location = new global::System.Drawing.Point(172, 427);
			this.viewAlpha.Name = "viewAlpha";
			this.viewAlpha.Size = new global::System.Drawing.Size(53, 17);
			this.viewAlpha.TabIndex = 44;
			this.viewAlpha.Text = "Alpha";
			this.viewAlpha.UseVisualStyleBackColor = true;
			this.viewAlpha.CheckedChanged += new global::System.EventHandler(this.viewAlpha_CheckedChanged);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(9, 150);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(45, 13);
			this.label1.TabIndex = 45;
			this.label1.Text = "Preview";
			base.AcceptButton = this.btnContinue;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(281, 514);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.viewAlpha);
			base.Controls.Add(this.viewBlue);
			base.Controls.Add(this.viewGreen);
			base.Controls.Add(this.viewRed);
			base.Controls.Add(this.preview);
			base.Controls.Add(this.enableAlpha);
			base.Controls.Add(this.alphaGroup);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnContinue);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Name = "BitmapImportDialog";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Import bitmap";
			this.alphaGroup.ResumeLayout(false);
			this.alphaGroup.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001CC RID: 460
		private global::System.Windows.Forms.Button btnContinue;

		// Token: 0x040001CD RID: 461
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040001CE RID: 462
		private global::System.Windows.Forms.GroupBox alphaGroup;

		// Token: 0x040001CF RID: 463
		private global::System.Windows.Forms.RadioButton keepAlpha;

		// Token: 0x040001D0 RID: 464
		private global::System.Windows.Forms.Button setImgBtn;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.RadioButton alphaFromImage;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.RadioButton alphaEmpty;

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.RadioButton alphaFull;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.CheckBox enableAlpha;

		// Token: 0x040001D5 RID: 469
		private global::ns17.Control0 preview;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.CheckBox viewRed;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.CheckBox viewGreen;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.CheckBox viewBlue;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.CheckBox viewAlpha;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.Label label1;
	}
}
