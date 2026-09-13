using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ns0;
using ns10;
using ns11;
using ns15;
using ns19;
using ns8;

namespace ns3
{
	// Token: 0x020001EE RID: 494
	[DesignerCategory("Code")]
	internal sealed partial class Form3 : Form
	{
		// Token: 0x060013B1 RID: 5041 RVA: 0x000C8B50 File Offset: 0x000C6D50
		private void method_0()
		{
			base.SuspendLayout();
			this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_1.FlatStyle = FlatStyle.System;
			this.button_1.Size = new Size(100, 24);
			this.button_1.Location = new Point(408 - this.button_1.Width, 188);
			this.button_1.TabIndex = 0;
			this.button_1.Text = "&Quit";
			this.button_1.Click += this.button_1_Click;
			this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_0.FlatStyle = FlatStyle.System;
			this.button_0.Size = new Size(100, 24);
			this.button_0.Location = new Point(this.button_1.Left - this.button_0.Width - 6, 188);
			this.button_0.TabIndex = 1;
			this.button_0.Text = "&Continue";
			this.button_0.Click += this.button_0_Click;
			this.control13_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.control13_0.SetBounds(6, 186, 120, 32);
			this.control12_0.IconState = Enum35.const_2;
			this.class209_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.class209_0.Location = new Point(20, 72);
			this.class209_0.Size = new Size(382, 13);
			this.AutoScaleBaseSize = new Size(5, 13);
			base.ClientSize = new Size(418, 224);
			base.ControlBox = false;
			base.Controls.AddRange(new Control[]
			{
				this.control13_0,
				this.button_0,
				this.button_1,
				this.control12_0,
				this.class209_0
			});
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			base.ResumeLayout(false);
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x0000A608 File Offset: 0x00008808
		private void button_0_Click(object sender, EventArgs e)
		{
			this.securityExceptionEventArgs.TryToContinue = true;
			base.Close();
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x0000A61C File Offset: 0x0000881C
		private void button_1_Click(object sender, EventArgs e)
		{
			this.securityExceptionEventArgs.TryToContinue = false;
			base.Close();
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x000C8D70 File Offset: 0x000C6F70
		public Form3(EventArgs10 securityExceptionEventArgs)
		{
			this.method_0();
			base.Icon = Class213.smethod_0();
			this.Text = "TSR Workshop";
			if (this.Text.Length == 0)
			{
				this.Text = "Security error";
			}
			this.securityExceptionEventArgs = securityExceptionEventArgs;
			if (!securityExceptionEventArgs.CanContinue)
			{
				this.button_0.Visible = false;
			}
			if (securityExceptionEventArgs.SecurityMessage.Length > 0)
			{
				this.class209_0.Text = securityExceptionEventArgs.SecurityMessage;
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(string.Format("{0} attempted to perform an operation not allowed by the security policy. To grant this application the required permission, contact your system administrator, or use the Microsoft .NET Framework Configuration tool.\n\n", "TSR Workshop"));
				if (securityExceptionEventArgs.CanContinue)
				{
					stringBuilder.Append("If you click Continue, the application will ignore this error and attempt to continue. If you click Quit, the application will close immediately.\n\n");
				}
				stringBuilder.Append(securityExceptionEventArgs.SecurityException.Message);
				this.class209_0.Text = stringBuilder.ToString();
			}
			int num = this.class209_0.Bottom + 60;
			if (num > base.ClientSize.Height)
			{
				base.ClientSize = new Size(base.ClientSize.Width, num);
			}
		}

		// Token: 0x04000E1F RID: 3615
		private const string string_0 = "{1fe9e38e-05cc-46a3-ae48-6cda8fb62056}";

		// Token: 0x04000E20 RID: 3616
		private EventArgs10 securityExceptionEventArgs = null;

		// Token: 0x04000E21 RID: 3617
		private Control13 control13_0 = new Control13();

		// Token: 0x04000E22 RID: 3618
		private Button button_0 = new Button();

		// Token: 0x04000E23 RID: 3619
		private Button button_1 = new Button();

		// Token: 0x04000E24 RID: 3620
		private Control12 control12_0 = new Control12(string.Format("{0} attempted to perform an operation not allowed by the security policy.", "TSR Workshop"));

		// Token: 0x04000E25 RID: 3621
		private Class209 class209_0 = new Class209();
	}
}
