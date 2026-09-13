namespace ns11
{
	// Token: 0x020000E7 RID: 231
	internal sealed partial class ProjectInfo : global::System.Windows.Forms.Form
	{
		// Token: 0x06000976 RID: 2422 RVA: 0x00083450 File Offset: 0x00081650
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns11.ProjectInfo));
			this.info = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.info.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.info.Location = new global::System.Drawing.Point(0, 0);
			this.info.Multiline = true;
			this.info.Name = "info";
			this.info.ReadOnly = true;
			this.info.Size = new global::System.Drawing.Size(249, 213);
			this.info.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(249, 213);
			base.Controls.Add(this.info);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "ProjectInfo";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Project Info";
			base.Load += new global::System.EventHandler(this.ProjectInfo_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040007A2 RID: 1954
		private global::System.Windows.Forms.TextBox info;
	}
}
