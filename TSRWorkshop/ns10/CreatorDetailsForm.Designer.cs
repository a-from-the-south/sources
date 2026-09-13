namespace ns10
{
	// Token: 0x020000CD RID: 205
	internal sealed partial class CreatorDetailsForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600089E RID: 2206 RVA: 0x00079CE8 File Offset: 0x00077EE8
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			global::ns8.Class157 renderer = new global::ns8.Class157();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns10.CreatorDetailsForm));
			this.okBtn = new global::System.Windows.Forms.Button();
			this.cancelBtn = new global::System.Windows.Forms.Button();
			this.noask = new global::System.Windows.Forms.CheckBox();
			this.visualTipProvider_0 = new global::Skybound.VisualTips.VisualTipProvider(this.icontainer_0);
			this.control5_0 = new global::ns3.Control5();
			base.SuspendLayout();
			this.okBtn.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new global::System.Drawing.Point(202, 249);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new global::System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 4;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new global::System.EventHandler(this.okBtn_Click);
			this.cancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new global::System.Drawing.Point(284, 249);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new global::System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 5;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.noask.AutoSize = true;
			this.noask.Location = new global::System.Drawing.Point(11, 252);
			this.noask.Name = "noask";
			this.noask.Size = new global::System.Drawing.Size(123, 17);
			this.noask.TabIndex = 6;
			this.noask.Text = "Do not ask next time";
			this.noask.UseVisualStyleBackColor = true;
			this.visualTipProvider_0.Renderer = renderer;
			this.control5_0.Location = new global::System.Drawing.Point(5, 6);
			this.control5_0.Name = "CreatorDetailsPanel";
			this.control5_0.Size = new global::System.Drawing.Size(358, 237);
			this.control5_0.TabIndex = 7;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(370, 281);
			base.Controls.Add(this.control5_0);
			base.Controls.Add(this.noask);
			base.Controls.Add(this.cancelBtn);
			base.Controls.Add(this.okBtn);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "CreatorDetailsForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CreatorDetails";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040006E6 RID: 1766
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x040006E7 RID: 1767
		private global::System.Windows.Forms.Button okBtn;

		// Token: 0x040006E8 RID: 1768
		private global::System.Windows.Forms.Button cancelBtn;

		// Token: 0x040006E9 RID: 1769
		private global::System.Windows.Forms.CheckBox noask;

		// Token: 0x040006EA RID: 1770
		private global::Skybound.VisualTips.VisualTipProvider visualTipProvider_0;

		// Token: 0x040006EB RID: 1771
		public global::ns3.Control5 control5_0;
	}
}
