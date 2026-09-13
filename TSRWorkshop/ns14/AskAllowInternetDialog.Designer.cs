namespace ns14
{
	// Token: 0x020000C8 RID: 200
	internal sealed partial class AskAllowInternetDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x06000873 RID: 2163 RVA: 0x00077E18 File Offset: 0x00076018
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns14.AskAllowInternetDialog));
			this.label1 = new global::System.Windows.Forms.Label();
			this.yes = new global::System.Windows.Forms.Button();
			this.no = new global::System.Windows.Forms.Button();
			this.ask = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.label1.Location = new global::System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(316, 45);
			this.label1.TabIndex = 0;
			this.label1.Text = "In order to check for the latest version and to display news and updates TSR Workshop need to connect to TSR, do you want to allow this?";
			this.yes.Location = new global::System.Drawing.Point(12, 57);
			this.yes.Name = "yes";
			this.yes.Size = new global::System.Drawing.Size(75, 23);
			this.yes.TabIndex = 1;
			this.yes.Text = "Yes";
			this.yes.UseVisualStyleBackColor = true;
			this.yes.Click += new global::System.EventHandler(this.yes_Click);
			this.no.DialogResult = global::System.Windows.Forms.DialogResult.No;
			this.no.Location = new global::System.Drawing.Point(96, 57);
			this.no.Name = "no";
			this.no.Size = new global::System.Drawing.Size(75, 23);
			this.no.TabIndex = 2;
			this.no.Text = "No";
			this.no.UseVisualStyleBackColor = true;
			this.no.Click += new global::System.EventHandler(this.no_Click);
			this.ask.AutoSize = true;
			this.ask.Checked = true;
			this.ask.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.ask.Location = new global::System.Drawing.Point(12, 89);
			this.ask.Name = "ask";
			this.ask.Size = new global::System.Drawing.Size(149, 17);
			this.ask.TabIndex = 3;
			this.ask.Text = "Always perform this check";
			this.ask.UseVisualStyleBackColor = true;
			base.AcceptButton = this.yes;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.no;
			base.ClientSize = new global::System.Drawing.Size(337, 118);
			base.Controls.Add(this.ask);
			base.Controls.Add(this.no);
			base.Controls.Add(this.yes);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "AskAllowInternetDialog";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Fetch data?";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.AskAllowInternetDialog_FormClosing);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040006B4 RID: 1716
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040006B5 RID: 1717
		private global::System.Windows.Forms.Button yes;

		// Token: 0x040006B6 RID: 1718
		private global::System.Windows.Forms.Button no;

		// Token: 0x040006B7 RID: 1719
		private global::System.Windows.Forms.CheckBox ask;
	}
}
