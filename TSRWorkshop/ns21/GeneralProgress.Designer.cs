namespace ns21
{
	// Token: 0x020000D0 RID: 208
	internal sealed partial class GeneralProgress : global::System.Windows.Forms.Form
	{
		// Token: 0x060008B5 RID: 2229 RVA: 0x0007A438 File Offset: 0x00078638
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(70, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please wait...";
			this.progressBar1.Location = new global::System.Drawing.Point(12, 39);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(322, 23);
			this.progressBar1.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(346, 74);
			base.ControlBox = false;
			base.Controls.Add(this.progressBar1);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "GeneralProgress";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Hold it...";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040006F5 RID: 1781
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040006F6 RID: 1782
		private global::System.Windows.Forms.ProgressBar progressBar1;
	}
}
