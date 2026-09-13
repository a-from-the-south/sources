using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns10;
using Sims3Workshop.Properties;
using Sims3WorkshopSDK.Classes;

namespace ns3
{
	// Token: 0x02000130 RID: 304
	internal sealed class Control5 : UserControl, Interface11
	{
		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000E06 RID: 3590 RVA: 0x000AE280 File Offset: 0x000AC480
		public CreatorDetails Data
		{
			get
			{
				return this.creatorDetails_0;
			}
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000E07 RID: 3591 RVA: 0x000AE298 File Offset: 0x000AC498
		// (set) Token: 0x06000E08 RID: 3592 RVA: 0x00002A71 File Offset: 0x00000C71
		public new string Name
		{
			get
			{
				return "Creator Details";
			}
			set
			{
			}
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x000AE2B0 File Offset: 0x000AC4B0
		public Control5()
		{
			this.method_2();
			this.creatorDetails_0 = new CreatorDetails();
			this.creatorDetails_0.Name = Settings.Default.CreatorName;
			this.creatorDetails_0.Website = Settings.Default.CreatorWebsite;
			this.method_1();
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x000AE308 File Offset: 0x000AC508
		private void method_1()
		{
			this.FullName = this.creatorDetails_0.Name;
			this.Website = this.creatorDetails_0.Website;
			this.TSREmail = Settings.Default.TSREmail;
			this.TSRPassword = Settings.Default.TSRPassword;
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000E0B RID: 3595 RVA: 0x000AE35C File Offset: 0x000AC55C
		// (set) Token: 0x06000E0C RID: 3596 RVA: 0x00007B29 File Offset: 0x00005D29
		public string TSREmail
		{
			get
			{
				return this.tsrEmail.Text;
			}
			set
			{
				this.tsrEmail.Text = value;
			}
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000E0D RID: 3597 RVA: 0x000AE378 File Offset: 0x000AC578
		// (set) Token: 0x06000E0E RID: 3598 RVA: 0x00007B39 File Offset: 0x00005D39
		public string TSRPassword
		{
			get
			{
				return this.tsrPassword.Text;
			}
			set
			{
				this.tsrPassword.Text = value;
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x000AE394 File Offset: 0x000AC594
		// (set) Token: 0x06000E10 RID: 3600 RVA: 0x00007B49 File Offset: 0x00005D49
		public string FullName
		{
			get
			{
				return this.name.Text;
			}
			set
			{
				this.name.Text = value;
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000E11 RID: 3601 RVA: 0x000AE3B0 File Offset: 0x000AC5B0
		// (set) Token: 0x06000E12 RID: 3602 RVA: 0x00007B59 File Offset: 0x00005D59
		public string Website
		{
			get
			{
				return this.website.Text;
			}
			set
			{
				this.website.Text = value;
			}
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x000AE3CC File Offset: 0x000AC5CC
		public void imethod_0()
		{
			this.creatorDetails_0.Name = this.FullName;
			this.creatorDetails_0.Website = this.Website;
			Settings.Default.CreatorName = this.FullName;
			Settings.Default.CreatorWebsite = this.Website;
			Settings.Default.TSRPassword = this.TSRPassword;
			Settings.Default.TSREmail = this.TSREmail;
			Settings.Default.Save();
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x00002A71 File Offset: 0x00000C71
		public void imethod_1()
		{
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x00007B69 File Offset: 0x00005D69
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x000AE448 File Offset: 0x000AC648
		private void method_2()
		{
			this.groupBox2 = new GroupBox();
			this.tsrPassword = new TextBox();
			this.tsrEmail = new TextBox();
			this.label3 = new Label();
			this.label4 = new Label();
			this.groupBox1 = new GroupBox();
			this.website = new TextBox();
			this.name = new TextBox();
			this.label2 = new Label();
			this.label1 = new Label();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.tsrPassword);
			this.groupBox2.Controls.Add(this.tsrEmail);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new Point(5, 121);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(356, 112);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "TSR Details (optional)";
			this.tsrPassword.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tsrPassword.Location = new Point(10, 82);
			this.tsrPassword.Name = "tsrPassword";
			this.tsrPassword.PasswordChar = '*';
			this.tsrPassword.Size = new Size(337, 20);
			this.tsrPassword.TabIndex = 7;
			this.tsrEmail.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tsrEmail.Location = new Point(9, 43);
			this.tsrEmail.Name = "tsrEmail";
			this.tsrEmail.Size = new Size(338, 20);
			this.tsrEmail.TabIndex = 6;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(7, 66);
			this.label3.Name = "label3";
			this.label3.Size = new Size(81, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "TSR Password:";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(6, 27);
			this.label4.Name = "label4";
			this.label4.Size = new Size(60, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "TSR Email:";
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.website);
			this.groupBox1.Controls.Add(this.name);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new Point(5, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(356, 112);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Artist Details";
			this.website.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.website.Location = new Point(9, 82);
			this.website.Name = "website";
			this.website.Size = new Size(338, 20);
			this.website.TabIndex = 7;
			this.name.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.name.Location = new Point(9, 43);
			this.name.Name = "name";
			this.name.Size = new Size(338, 20);
			this.name.TabIndex = 6;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(7, 66);
			this.label2.Name = "label2";
			this.label2.Size = new Size(74, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Website URL:";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(6, 27);
			this.label1.Name = "label1";
			this.label1.Size = new Size(61, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Your name:";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			this.Name = "CreatorDetailsPanel";
			base.Size = new Size(366, 245);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000A89 RID: 2697
		private CreatorDetails creatorDetails_0;

		// Token: 0x04000A8A RID: 2698
		private IContainer icontainer_0;

		// Token: 0x04000A8B RID: 2699
		private GroupBox groupBox2;

		// Token: 0x04000A8C RID: 2700
		public TextBox tsrPassword;

		// Token: 0x04000A8D RID: 2701
		public TextBox tsrEmail;

		// Token: 0x04000A8E RID: 2702
		private Label label3;

		// Token: 0x04000A8F RID: 2703
		private Label label4;

		// Token: 0x04000A90 RID: 2704
		private GroupBox groupBox1;

		// Token: 0x04000A91 RID: 2705
		private TextBox website;

		// Token: 0x04000A92 RID: 2706
		private TextBox name;

		// Token: 0x04000A93 RID: 2707
		private Label label2;

		// Token: 0x04000A94 RID: 2708
		private Label label1;
	}
}
