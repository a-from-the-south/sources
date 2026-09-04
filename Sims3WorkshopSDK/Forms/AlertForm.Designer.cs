namespace Sims3WorkshopSDK.Forms
{
	// Token: 0x02000039 RID: 57
	public partial class AlertForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000104 RID: 260 RVA: 0x0000261D File Offset: 0x0000081D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000045E0 File Offset: 0x000027E0
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.okBtn = new global::System.Windows.Forms.Button();
			this.message = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.message);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(162, 126);
			this.panel1.TabIndex = 0;
			this.panel2.Controls.Add(this.okBtn);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 73);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(162, 53);
			this.panel2.TabIndex = 1;
			this.okBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.okBtn.Location = new global::System.Drawing.Point(42, 14);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new global::System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 0;
			this.okBtn.Text = "Ok";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new global::System.EventHandler(this.okBtn_Click);
			this.message.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.message.AutoSize = true;
			this.message.Location = new global::System.Drawing.Point(53, 25);
			this.message.Name = "message";
			this.message.Size = new global::System.Drawing.Size(49, 13);
			this.message.TabIndex = 0;
			this.message.Text = "Alert Box";
			this.message.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			base.ClientSize = new global::System.Drawing.Size(162, 126);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "AlertForm";
			this.Text = "AlertForm";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400013D RID: 317
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400013E RID: 318
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400013F RID: 319
		private global::System.Windows.Forms.Label message;

		// Token: 0x04000140 RID: 320
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000141 RID: 321
		private global::System.Windows.Forms.Button okBtn;
	}
}
