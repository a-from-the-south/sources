namespace ns6
{
	// Token: 0x020000EC RID: 236
	internal sealed partial class UpdatesAvailableForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600099E RID: 2462 RVA: 0x00084BD8 File Offset: 0x00082DD8
		private void InitializeComponent()
		{
			this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.button1 = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.LinkBehavior = global::System.Windows.Forms.LinkBehavior.AlwaysUnderline;
			this.linkLabel1.Location = new global::System.Drawing.Point(10, 40);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new global::System.Drawing.Size(208, 13);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Click here to download and install updates";
			this.linkLabel1.VisitedLinkColor = global::System.Drawing.Color.Blue;
			this.linkLabel1.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			this.button1.Location = new global::System.Drawing.Point(277, 40);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(10, 18);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(265, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "There are updates available for the Sims 3 Workshop.";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(359, 70);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.linkLabel1);
			this.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "UpdatesAvailableForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Updates Available";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040007C5 RID: 1989
		private global::System.Windows.Forms.LinkLabel linkLabel1;

		// Token: 0x040007C6 RID: 1990
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040007C7 RID: 1991
		private global::System.Windows.Forms.Label label1;
	}
}
