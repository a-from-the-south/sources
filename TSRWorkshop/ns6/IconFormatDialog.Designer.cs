namespace ns6
{
	// Token: 0x0200018E RID: 398
	internal sealed partial class IconFormatDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600120F RID: 4623 RVA: 0x000BF324 File Offset: 0x000BD524
		private void InitializeComponent()
		{
			this.lstFormats = new global::System.Windows.Forms.ListBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.picIcon = new global::System.Windows.Forms.PictureBox();
			this.cmdOK = new global::System.Windows.Forms.Button();
			this.cmdCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.lstFormats.IntegralHeight = false;
			this.lstFormats.Location = new global::System.Drawing.Point(7, 40);
			this.lstFormats.Name = "lstFormats";
			this.lstFormats.Size = new global::System.Drawing.Size(124, 256);
			this.lstFormats.TabIndex = 0;
			this.lstFormats.DoubleClick += new global::System.EventHandler(this.lstFormats_DoubleClick);
			this.lstFormats.SelectedIndexChanged += new global::System.EventHandler(this.lstFormats_SelectedIndexChanged);
			this.label1.Location = new global::System.Drawing.Point(6, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(380, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "This icon file contains more than one size or color depth.  Please choose the size and color depth to load from the list below.";
			this.picIcon.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.picIcon.Location = new global::System.Drawing.Point(135, 40);
			this.picIcon.Name = "picIcon";
			this.picIcon.Size = new global::System.Drawing.Size(256, 256);
			this.picIcon.TabIndex = 2;
			this.picIcon.TabStop = false;
			this.picIcon.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picIcon_Paint);
			this.cmdOK.Location = new global::System.Drawing.Point(317, 304);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new global::System.Drawing.Size(74, 22);
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new global::System.EventHandler(this.cmdOK_Click);
			this.cmdCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new global::System.Drawing.Point(317, 330);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new global::System.Drawing.Size(74, 22);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "Cancel";
			base.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 14);
			base.CancelButton = this.cmdCancel;
			base.ClientSize = new global::System.Drawing.Size(400, 361);
			base.Controls.Add(this.cmdCancel);
			base.Controls.Add(this.cmdOK);
			base.Controls.Add(this.picIcon);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.lstFormats);
			this.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "IconFormatDialog";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Choose Icon";
			base.ResumeLayout(false);
		}

		// Token: 0x04000C8B RID: 3211
		private global::System.Windows.Forms.ListBox lstFormats;

		// Token: 0x04000C8C RID: 3212
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000C8D RID: 3213
		private global::System.Windows.Forms.Button cmdOK;

		// Token: 0x04000C8E RID: 3214
		private global::System.Windows.Forms.Button cmdCancel;

		// Token: 0x04000C8F RID: 3215
		private global::System.Windows.Forms.PictureBox picIcon;
	}
}
