namespace Sims3Workshop.Dialogs
{
	// Token: 0x020000E9 RID: 233
	public sealed partial class Splash : global::System.Windows.Forms.Form
	{
		// Token: 0x06000981 RID: 2433 RVA: 0x00083828 File Offset: 0x00081A28
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(12, 278);
			this.label1.MinimumSize = new global::System.Drawing.Size(400, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(400, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Loading...";
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(501, 193);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(116, 83);
			this.label2.TabIndex = 1;
			this.label2.Text = "Programming:\r\nMikael Sundberg\r\nJohan Isacsson\r\n\r\nGraphics and UI:\r\nThomas Isacsson\r\n";
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(509, 278);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(81, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Version label";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackgroundImage = global::ns17.Class143.splash1;
			base.ClientSize = new global::System.Drawing.Size(600, 300);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new global::System.Drawing.Size(600, 300);
			this.MinimumSize = new global::System.Drawing.Size(600, 300);
			base.Name = "Splash";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Splash";
			base.ResumeLayout(false);
		}

		// Token: 0x040007AA RID: 1962
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040007AB RID: 1963
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040007AC RID: 1964
		private global::System.Windows.Forms.Label label3;
	}
}
