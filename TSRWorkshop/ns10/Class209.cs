using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns8;

namespace ns10
{
	// Token: 0x020001DA RID: 474
	[DesignerCategory("Code")]
	internal sealed class Class209 : Label
	{
		// Token: 0x0600133D RID: 4925 RVA: 0x000C68B8 File Offset: 0x000C4AB8
		private void method_0()
		{
			try
			{
				using (Graphics graphics = base.CreateGraphics())
				{
					int num = Class213.smethod_2(graphics, this.Text, this.Font, base.Width);
					if (num > 0)
					{
						base.Height = num;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600133E RID: 4926 RVA: 0x0000A102 File Offset: 0x00008302
		protected void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.method_0();
		}

		// Token: 0x0600133F RID: 4927 RVA: 0x0000A111 File Offset: 0x00008311
		protected void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.method_0();
		}

		// Token: 0x06001340 RID: 4928 RVA: 0x0000A120 File Offset: 0x00008320
		protected void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this.method_0();
		}

		// Token: 0x06001341 RID: 4929 RVA: 0x0000A12F File Offset: 0x0000832F
		public Class209()
		{
			base.FlatStyle = FlatStyle.System;
			base.UseMnemonic = false;
		}
	}
}
