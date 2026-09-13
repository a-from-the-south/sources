using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns10;
using ns11;
using ns15;
using ns16;
using ns20;
using ns6;
using ns9;

namespace ns3
{
	// Token: 0x020001EC RID: 492
	[DesignerCategory("Code")]
	internal sealed partial class Form2 : Form
	{
		// Token: 0x0600139F RID: 5023 RVA: 0x000C7D58 File Offset: 0x000C5F58
		private void method_0()
		{
			this.panel_0.SuspendLayout();
			this.panel_1.SuspendLayout();
			base.SuspendLayout();
			this.control12_0.IconState = Enum35.const_1;
			this.control12_1.IconState = Enum35.const_1;
			this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.checkBox_0.FlatStyle = FlatStyle.System;
			this.checkBox_0.Location = new Point(22, 98);
			this.checkBox_0.Size = new Size(226, 16);
			this.checkBox_0.TabIndex = 13;
			this.checkBox_0.Text = "Ignore this error and attempt to &continue.";
			this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
			this.label_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.label_0.FlatStyle = FlatStyle.System;
			this.label_0.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label_0.Location = new Point(20, 124);
			this.label_0.Size = new Size(381, 16);
			this.label_0.Text = string.Format("Please tell {0} about this problem.", "Ibibi HB");
			this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_0.FlatStyle = FlatStyle.System;
			this.button_0.Size = new Size(75, 24);
			this.button_0.Location = new Point(400 - this.button_0.Width, 205);
			this.button_0.TabIndex = 4;
			this.button_0.Text = "&Don't Send";
			this.button_0.Click += this.button_0_Click;
			this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_1.FlatStyle = FlatStyle.System;
			this.button_1.Size = new Size(105, 24);
			this.button_1.Location = new Point(this.button_0.Left - this.button_1.Width - 6, 205);
			this.button_1.TabIndex = 3;
			this.button_1.Text = "&Send Error Report";
			this.button_1.Click += this.button_1_Click;
			this.button_6.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_6.FlatStyle = FlatStyle.System;
			this.button_6.Size = new Size(64, 24);
			this.button_6.Location = new Point(this.button_1.Left - this.button_6.Width - 6, 205);
			this.button_6.TabIndex = 14;
			this.button_6.Text = "De&bug";
			this.button_6.Visible = false;
			this.button_6.Click += this.button_6_Click;
			this.label_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.label_1.FlatStyle = FlatStyle.System;
			this.label_1.Location = new Point(20, 140);
			this.label_1.Size = new Size(381, 55);
			this.label_1.Text = string.Format("To help improve the software you use, {0} is interested in learning more about this error. We have created a report about the error for you to send to us.", "Ibibi HB");
			this.class209_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.class209_0.Location = new Point(20, 69);
			this.class209_0.Size = new Size(381, 13);
			this.button_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_2.FlatStyle = FlatStyle.System;
			this.button_2.Size = new Size(80, 24);
			this.button_2.Location = new Point(400 - this.button_2.Width, 205);
			this.button_2.TabIndex = 7;
			this.button_2.Text = "&Cancel";
			this.button_2.Click += this.button_2_Click;
			this.button_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_3.Enabled = false;
			this.button_3.FlatStyle = FlatStyle.System;
			this.button_3.Size = new Size(105, 24);
			this.button_3.Location = new Point(this.button_2.Left - this.button_3.Width - 6, 205);
			this.button_3.TabIndex = 6;
			this.button_3.Text = "&OK";
			this.button_3.Click += this.button_3_Click;
			this.button_4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_4.FlatStyle = FlatStyle.System;
			this.button_4.Location = this.button_3.Location;
			this.button_4.Size = this.button_3.Size;
			this.button_4.TabIndex = 5;
			this.button_4.Text = "&Retry";
			this.button_4.Visible = false;
			this.button_4.Click += this.button_4_Click;
			this.button_5.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_5.FlatStyle = FlatStyle.System;
			this.button_5.Location = this.button_3.Location;
			this.button_5.Size = this.button_3.Size;
			this.button_5.TabIndex = 5;
			this.button_5.Text = "Save Report";
			this.button_5.Visible = false;
			this.button_5.Click += this.button_5_Click;
			this.control14_0.Location = new Point(87, 146);
			this.control14_0.Visible = false;
			this.control11_0.SetBounds(24, 72, 368, 16);
			this.control11_1.SetBounds(24, 96, 368, 16);
			this.control11_2.SetBounds(24, 120, 368, 16);
			this.control11_3.SetBounds(24, 144, 368, 16);
			this.control13_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.control13_0.SetBounds(20, 444, 120, 32);
			this.panel_0.Controls.AddRange(new Control[]
			{
				this.button_6,
				this.checkBox_0,
				this.label_0,
				this.button_0,
				this.button_1,
				this.label_1,
				this.class209_0,
				this.control12_0
			});
			this.panel_0.Size = new Size(413, 240);
			this.panel_0.TabIndex = 0;
			this.panel_1.Controls.AddRange(new Control[]
			{
				this.button_2,
				this.button_3,
				this.button_4,
				this.button_5,
				this.control14_0,
				this.control12_1,
				this.control11_0,
				this.control11_1,
				this.control11_2,
				this.control11_3
			});
			this.panel_1.Size = new Size(413, 240);
			this.panel_1.TabIndex = 2;
			this.panel_1.Visible = false;
			this.AutoScaleBaseSize = new Size(5, 13);
			base.ClientSize = new Size(434, 488);
			base.ControlBox = false;
			base.Controls.AddRange(new Control[]
			{
				this.control13_0,
				this.panel_0,
				this.panel_1
			});
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.ShowInTaskbar = false;
			base.MinimizeBox = false;
			base.MaximizeBox = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "TSR Workshop";
			if (this.Text.Length == 0)
			{
				this.Text = "Error Reporting";
			}
			try
			{
				base.TopMost = true;
			}
			catch
			{
			}
			this.panel_0.ResumeLayout(false);
			this.panel_1.ResumeLayout(false);
			base.ResumeLayout(false);
			this.button_4.BringToFront();
			this.button_5.BringToFront();
			base.Size = new Size(419, 264);
			this.panel_1.Dock = DockStyle.Fill;
			this.panel_0.Dock = DockStyle.Fill;
		}

		// Token: 0x060013A0 RID: 5024 RVA: 0x000C85E4 File Offset: 0x000C67E4
		private void button_5_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save Report";
			saveFileDialog.DefaultExt = "saencryptedreport";
			saveFileDialog.Filter = "SmartAssembly Encrypted Exception Report|*.saencryptedreport";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.reportExceptionEventArgs.method_4(saveFileDialog.FileName);
				base.Close();
			}
		}

		// Token: 0x060013A1 RID: 5025 RVA: 0x000C863C File Offset: 0x000C683C
		private void button_1_Click(object sender, EventArgs e)
		{
			try
			{
				this.panel_0.Visible = false;
				this.panel_1.Visible = true;
				this.control13_0.Visible = true;
				if (this.reportExceptionEventArgs != null)
				{
					this.method_1(new ThreadStart(this.method_6));
				}
			}
			catch
			{
			}
		}

		// Token: 0x060013A2 RID: 5026 RVA: 0x0000A577 File Offset: 0x00008777
		private void method_1(ThreadStart threadStart_0)
		{
			this.thread_0 = new Thread(threadStart_0);
			this.thread_0.Start();
		}

		// Token: 0x060013A3 RID: 5027 RVA: 0x0000A590 File Offset: 0x00008790
		private void button_0_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060013A4 RID: 5028 RVA: 0x000C869C File Offset: 0x000C689C
		private void button_2_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.thread_0 != null)
				{
					this.thread_0.Abort();
				}
			}
			catch
			{
			}
			base.Close();
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x0000A590 File Offset: 0x00008790
		private void button_3_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x0000A598 File Offset: 0x00008798
		private void checkBox_0_CheckedChanged(object sender, EventArgs e)
		{
			this.reportExceptionEventArgs.TryToContinue = this.checkBox_0.Checked;
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x000C86D8 File Offset: 0x000C68D8
		private void method_2(object sender, EventArgs11 e)
		{
			try
			{
				base.Invoke(new Delegate35(this.method_4), new object[]
				{
					sender,
					e
				});
			}
			catch (InvalidOperationException)
			{
			}
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x000C8720 File Offset: 0x000C6920
		private void method_3(object sender, EventArgs e)
		{
			try
			{
				base.Invoke(new EventHandler(this.method_5), new object[]
				{
					sender,
					e
				});
			}
			catch (InvalidOperationException)
			{
			}
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x0000A5B0 File Offset: 0x000087B0
		protected void OnClosing(CancelEventArgs e)
		{
			if (this.thread_0 != null && this.thread_0.IsAlive)
			{
				this.thread_0.Abort();
			}
			base.OnClosing(e);
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x000C8768 File Offset: 0x000C6968
		private void method_4(object sender, EventArgs11 e)
		{
			Button button = (!this.bool_0 || Thread.CurrentThread.ApartmentState != ApartmentState.STA) ? this.button_4 : this.button_5;
			switch (e.Step)
			{
			case Enum34.const_0:
				if (e.Failed)
				{
					this.control11_0.method_3(e.ErrorMessage);
					button.Visible = true;
					button.Focus();
					return;
				}
				this.control11_0.method_1();
				return;
			case Enum34.const_1:
				if (e.Failed)
				{
					this.control11_1.method_3(e.ErrorMessage);
					button.Visible = true;
					button.Focus();
					return;
				}
				this.control11_0.method_2();
				this.control11_1.method_1();
				return;
			case Enum34.const_2:
				if (e.Failed)
				{
					this.control14_0.Visible = false;
					this.control11_2.method_3(e.ErrorMessage);
					button.Visible = true;
					button.Focus();
					return;
				}
				this.control11_1.method_2();
				this.control11_2.method_1();
				this.control14_0.Visible = true;
				return;
			case Enum34.const_3:
				this.control14_0.Visible = false;
				this.control11_2.method_2();
				this.control11_3.method_2();
				this.button_3.Enabled = true;
				this.button_3.Focus();
				this.button_2.Enabled = false;
				return;
			default:
				return;
			}
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x0000A590 File Offset: 0x00008790
		private void method_5(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x000C88C8 File Offset: 0x000C6AC8
		private void button_4_Click(object sender, EventArgs e)
		{
			this.bool_0 = true;
			this.button_4.Visible = false;
			this.control11_0.method_0();
			this.control11_1.method_0();
			this.control11_2.method_0();
			if (this.reportExceptionEventArgs != null)
			{
				this.method_1(new ThreadStart(this.method_6));
			}
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x0000A5D9 File Offset: 0x000087D9
		private void method_6()
		{
			this.reportExceptionEventArgs.method_6();
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x0000A5E7 File Offset: 0x000087E7
		private void button_6_Click(object sender, EventArgs e)
		{
			if (this.reportExceptionEventArgs != null)
			{
				this.method_1(new ThreadStart(this.reportExceptionEventArgs.method_3));
			}
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x000C8924 File Offset: 0x000C6B24
		public Form2(Class210 unhandledExceptionHandler, EventArgs9 reportExceptionEventArgs)
		{
			this.method_0();
			int num = base.Height;
			this.reportExceptionEventArgs = reportExceptionEventArgs;
			this.class209_0.Text = reportExceptionEventArgs.Exception.Message;
			num += this.class209_0.Height - base.FontHeight;
			if (!reportExceptionEventArgs.ShowContinueCheckbox)
			{
				this.checkBox_0.Visible = false;
				num -= this.checkBox_0.Height;
			}
			if (num > base.Height)
			{
				base.Height = num;
			}
			if (reportExceptionEventArgs.CanDebug)
			{
				unhandledExceptionHandler.DebuggerLaunched += this.method_3;
				this.button_6.Visible = true;
				if (this.button_6.Left < this.control13_0.Right)
				{
					this.control13_0.Visible = false;
				}
			}
			if (!reportExceptionEventArgs.CanSendReport)
			{
				this.button_1.Enabled = false;
				if (this.button_0.CanFocus)
				{
					this.button_0.Focus();
				}
			}
			unhandledExceptionHandler.SendingReportFeedback += this.method_2;
		}

		// Token: 0x04000DE4 RID: 3556
		private EventArgs9 reportExceptionEventArgs;

		// Token: 0x04000DE5 RID: 3557
		private Thread thread_0;

		// Token: 0x04000DE6 RID: 3558
		private CheckBox checkBox_0 = new CheckBox();

		// Token: 0x04000DE7 RID: 3559
		private Label label_0 = new Label();

		// Token: 0x04000DE8 RID: 3560
		private Button button_0 = new Button();

		// Token: 0x04000DE9 RID: 3561
		private Button button_1 = new Button();

		// Token: 0x04000DEA RID: 3562
		private Label label_1 = new Label();

		// Token: 0x04000DEB RID: 3563
		private Class209 class209_0 = new Class209();

		// Token: 0x04000DEC RID: 3564
		private Panel panel_0 = new Panel();

		// Token: 0x04000DED RID: 3565
		private Panel panel_1 = new Panel();

		// Token: 0x04000DEE RID: 3566
		private Button button_2 = new Button();

		// Token: 0x04000DEF RID: 3567
		private Control14 control14_0 = new Control14();

		// Token: 0x04000DF0 RID: 3568
		private Control11 control11_0 = new Control11("Preparing the error report.");

		// Token: 0x04000DF1 RID: 3569
		private Control11 control11_1 = new Control11("Connecting to server.");

		// Token: 0x04000DF2 RID: 3570
		private Control11 control11_2 = new Control11("Transferring report.");

		// Token: 0x04000DF3 RID: 3571
		private Control11 control11_3 = new Control11("Error reporting completed. Thank you.");

		// Token: 0x04000DF4 RID: 3572
		private Button button_3 = new Button();

		// Token: 0x04000DF5 RID: 3573
		private Button button_4 = new Button();

		// Token: 0x04000DF6 RID: 3574
		private Button button_5 = new Button();

		// Token: 0x04000DF7 RID: 3575
		private Control12 control12_0 = new Control12(string.Format("{0} has encountered a problem.\nWe are sorry for the inconvenience.", "TSR Workshop"));

		// Token: 0x04000DF8 RID: 3576
		private Control12 control12_1 = new Control12(string.Format("Please wait while {0} is sending the report to {1} through the Internet.", "TSR Workshop", "Ibibi HB"));

		// Token: 0x04000DF9 RID: 3577
		private Control13 control13_0 = new Control13();

		// Token: 0x04000DFA RID: 3578
		private Button button_6 = new Button();

		// Token: 0x04000DFB RID: 3579
		private bool bool_0;
	}
}
