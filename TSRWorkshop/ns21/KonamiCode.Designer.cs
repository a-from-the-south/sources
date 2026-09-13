namespace ns21
{
	// Token: 0x020000D8 RID: 216
	internal sealed partial class KonamiCode : global::System.Windows.Forms.Form
	{
		// Token: 0x060008F2 RID: 2290 RVA: 0x0007C710 File Offset: 0x0007A910
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(116, 676);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(82, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Code Monkey 1";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(458, 676);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(82, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Code Monkey 2";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::ns17.Class143.apan;
			base.ClientSize = new global::System.Drawing.Size(634, 708);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "KonamiCode";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "You´ve entered a secret area!";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000722 RID: 1826
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000723 RID: 1827
		private global::System.Windows.Forms.Label label2;
	}
}
