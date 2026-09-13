using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns12;
using ns16;

namespace ns6
{
	// Token: 0x0200018E RID: 398
	internal sealed partial class IconFormatDialog : Form
	{
		// Token: 0x0600120B RID: 4619 RVA: 0x000098DC File Offset: 0x00007ADC
		public IconFormatDialog()
		{
			this.InitializeComponent();
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x0600120C RID: 4620 RVA: 0x000BF254 File Offset: 0x000BD454
		// (set) Token: 0x0600120D RID: 4621 RVA: 0x000BF26C File Offset: 0x000BD46C
		public Class178 x7d8d2ed69d304345
		{
			get
			{
				return this.class178_0;
			}
			set
			{
				this.class178_0 = value;
				this.lstFormats.Items.Clear();
				if (this.class178_0 != null)
				{
					Struct23[] array = this.class178_0.method_6();
					foreach (Struct23 @struct in array)
					{
						this.lstFormats.Items.Add(@struct);
					}
					this.lstFormats.SelectedIndex = 0;
				}
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x0600120E RID: 4622 RVA: 0x000BF2E8 File Offset: 0x000BD4E8
		public Struct23 x88ff53b73da867e0
		{
			get
			{
				Struct23 result;
				if (this.lstFormats.SelectedItem != null)
				{
					result = (Struct23)this.lstFormats.SelectedItem;
				}
				else
				{
					result = Struct23.struct23_0;
				}
				return result;
			}
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x000098EC File Offset: 0x00007AEC
		private void lstFormats_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.picIcon.Invalidate();
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x000BF67C File Offset: 0x000BD87C
		private void picIcon_Paint(object sender, PaintEventArgs e)
		{
			using (Brush brush = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.LightGray, Color.White))
			{
				e.Graphics.FillRectangle(brush, this.picIcon.ClientRectangle);
			}
			if (this.lstFormats.SelectedItem != null)
			{
				e.Graphics.DrawImage(this.x7d8d2ed69d304345.method_3((Struct23)this.lstFormats.SelectedItem), 0, 0);
			}
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void cmdOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x000098FB File Offset: 0x00007AFB
		private void lstFormats_DoubleClick(object sender, EventArgs e)
		{
			if (this.lstFormats.SelectedIndex >= 0)
			{
				this.cmdOK_Click(this.cmdOK, EventArgs.Empty);
			}
		}

		// Token: 0x04000C90 RID: 3216
		private Class178 class178_0;
	}
}
