namespace ns16
{
	// Token: 0x020000D5 RID: 213
	internal sealed partial class GenerateWallmask : global::System.Windows.Forms.Form
	{
		// Token: 0x060008D9 RID: 2265 RVA: 0x0007B244 File Offset: 0x00079444
		private void InitializeComponent()
		{
			this.previewFront = new global::System.Windows.Forms.PictureBox();
			this.cancelBtn = new global::System.Windows.Forms.Button();
			this.okBtn = new global::System.Windows.Forms.Button();
			this.feather = new global::System.Windows.Forms.TrackBar();
			this.featherLbl = new global::System.Windows.Forms.Label();
			this.onlyGlass = new global::System.Windows.Forms.CheckBox();
			this.previewBack = new global::System.Windows.Forms.PictureBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.previewBtn = new global::System.Windows.Forms.Button();
			this.thresholdLbl = new global::System.Windows.Forms.Label();
			this.threshold = new global::System.Windows.Forms.TrackBar();
			this.distanceLbl = new global::System.Windows.Forms.Label();
			this.distance = new global::System.Windows.Forms.TrackBar();
			((global::System.ComponentModel.ISupportInitialize)this.previewFront).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.feather).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.previewBack).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.threshold).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.distance).BeginInit();
			base.SuspendLayout();
			this.previewFront.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.previewFront.BackColor = global::System.Drawing.Color.Black;
			this.previewFront.BackgroundImage = global::ns17.Class143.alphacheck;
			this.previewFront.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.previewFront.Location = new global::System.Drawing.Point(12, 25);
			this.previewFront.Name = "previewFront";
			this.previewFront.Size = new global::System.Drawing.Size(192, 128);
			this.previewFront.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.previewFront.TabIndex = 0;
			this.previewFront.TabStop = false;
			this.cancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new global::System.Drawing.Point(47, 543);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new global::System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 2;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new global::System.EventHandler(this.cancelBtn_Click);
			this.okBtn.Location = new global::System.Drawing.Point(128, 543);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new global::System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 3;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new global::System.EventHandler(this.okBtn_Click);
			this.feather.Location = new global::System.Drawing.Point(12, 367);
			this.feather.Maximum = 20;
			this.feather.Minimum = -20;
			this.feather.Name = "feather";
			this.feather.Size = new global::System.Drawing.Size(192, 45);
			this.feather.TabIndex = 10;
			this.feather.ValueChanged += new global::System.EventHandler(this.threshold_ValueChanged);
			this.feather.Scroll += new global::System.EventHandler(this.feather_Scroll);
			this.featherLbl.AutoSize = true;
			this.featherLbl.Location = new global::System.Drawing.Point(12, 351);
			this.featherLbl.Name = "featherLbl";
			this.featherLbl.Size = new global::System.Drawing.Size(93, 13);
			this.featherLbl.TabIndex = 11;
			this.featherLbl.Text = "Feather amount: 0";
			this.onlyGlass.AutoSize = true;
			this.onlyGlass.Checked = true;
			this.onlyGlass.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.onlyGlass.Location = new global::System.Drawing.Point(15, 331);
			this.onlyGlass.Name = "onlyGlass";
			this.onlyGlass.Size = new global::System.Drawing.Size(74, 17);
			this.onlyGlass.TabIndex = 12;
			this.onlyGlass.Text = "Glass only";
			this.onlyGlass.UseVisualStyleBackColor = true;
			this.onlyGlass.CheckedChanged += new global::System.EventHandler(this.onlyGlass_CheckedChanged);
			this.previewBack.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.previewBack.BackColor = global::System.Drawing.Color.Black;
			this.previewBack.BackgroundImage = global::ns17.Class143.alphacheck;
			this.previewBack.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.previewBack.Location = new global::System.Drawing.Point(11, 179);
			this.previewBack.Name = "previewBack";
			this.previewBack.Size = new global::System.Drawing.Size(192, 128);
			this.previewBack.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.previewBack.TabIndex = 13;
			this.previewBack.TabStop = false;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(35, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Inside";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(12, 163);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(43, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Outside";
			this.previewBtn.Location = new global::System.Drawing.Point(128, 327);
			this.previewBtn.Name = "previewBtn";
			this.previewBtn.Size = new global::System.Drawing.Size(75, 23);
			this.previewBtn.TabIndex = 16;
			this.previewBtn.Text = "Preview";
			this.previewBtn.UseVisualStyleBackColor = true;
			this.previewBtn.Click += new global::System.EventHandler(this.previewBtn_Click);
			this.thresholdLbl.AutoSize = true;
			this.thresholdLbl.Location = new global::System.Drawing.Point(11, 406);
			this.thresholdLbl.Name = "thresholdLbl";
			this.thresholdLbl.Size = new global::System.Drawing.Size(72, 13);
			this.thresholdLbl.TabIndex = 18;
			this.thresholdLbl.Text = "Threshold: 30";
			this.threshold.LargeChange = 10;
			this.threshold.Location = new global::System.Drawing.Point(11, 422);
			this.threshold.Maximum = 255;
			this.threshold.Name = "threshold";
			this.threshold.Size = new global::System.Drawing.Size(192, 45);
			this.threshold.TabIndex = 17;
			this.threshold.TickFrequency = 5;
			this.threshold.Value = 30;
			this.threshold.ValueChanged += new global::System.EventHandler(this.threshold_ValueChanged);
			this.distanceLbl.AutoSize = true;
			this.distanceLbl.Location = new global::System.Drawing.Point(9, 470);
			this.distanceLbl.Name = "distanceLbl";
			this.distanceLbl.Size = new global::System.Drawing.Size(60, 13);
			this.distanceLbl.TabIndex = 20;
			this.distanceLbl.Text = "Z clip: 0.05";
			this.distance.LargeChange = 10;
			this.distance.Location = new global::System.Drawing.Point(9, 486);
			this.distance.Maximum = 100;
			this.distance.Name = "distance";
			this.distance.Size = new global::System.Drawing.Size(192, 45);
			this.distance.TabIndex = 19;
			this.distance.TickFrequency = 5;
			this.distance.Value = 50;
			this.distance.ValueChanged += new global::System.EventHandler(this.distance_ValueChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.cancelBtn;
			base.ClientSize = new global::System.Drawing.Size(215, 578);
			base.Controls.Add(this.distanceLbl);
			base.Controls.Add(this.distance);
			base.Controls.Add(this.thresholdLbl);
			base.Controls.Add(this.threshold);
			base.Controls.Add(this.previewBtn);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.previewBack);
			base.Controls.Add(this.onlyGlass);
			base.Controls.Add(this.featherLbl);
			base.Controls.Add(this.feather);
			base.Controls.Add(this.okBtn);
			base.Controls.Add(this.cancelBtn);
			base.Controls.Add(this.previewFront);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "GenerateWallmask";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Generate Wallmask";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.GenerateWallmask_FormClosed);
			((global::System.ComponentModel.ISupportInitialize)this.previewFront).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.feather).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.previewBack).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.threshold).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.distance).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000702 RID: 1794
		private global::System.Windows.Forms.PictureBox previewFront;

		// Token: 0x04000703 RID: 1795
		private global::System.Windows.Forms.Button cancelBtn;

		// Token: 0x04000704 RID: 1796
		private global::System.Windows.Forms.Button okBtn;

		// Token: 0x04000705 RID: 1797
		private global::System.Windows.Forms.TrackBar feather;

		// Token: 0x04000706 RID: 1798
		private global::System.Windows.Forms.Label featherLbl;

		// Token: 0x04000707 RID: 1799
		private global::System.Windows.Forms.CheckBox onlyGlass;

		// Token: 0x04000708 RID: 1800
		private global::System.Windows.Forms.PictureBox previewBack;

		// Token: 0x04000709 RID: 1801
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400070A RID: 1802
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400070B RID: 1803
		private global::System.Windows.Forms.Button previewBtn;

		// Token: 0x0400070C RID: 1804
		private global::System.Windows.Forms.Label thresholdLbl;

		// Token: 0x0400070D RID: 1805
		private global::System.Windows.Forms.TrackBar threshold;

		// Token: 0x0400070E RID: 1806
		private global::System.Windows.Forms.Label distanceLbl;

		// Token: 0x0400070F RID: 1807
		private global::System.Windows.Forms.TrackBar distance;
	}
}
