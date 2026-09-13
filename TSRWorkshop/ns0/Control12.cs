using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns11;
using ns8;

namespace ns0
{
	// Token: 0x020001DC RID: 476
	[DesignerCategory("Code")]
	internal sealed class Control12 : Control
	{
		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x0600134F RID: 4943 RVA: 0x0000A246 File Offset: 0x00008446
		// (set) Token: 0x06001350 RID: 4944 RVA: 0x000C6B78 File Offset: 0x000C4D78
		public Enum35 IconState
		{
			get
			{
				return this.enum35_0;
			}
			set
			{
				if (this.enum35_0 != value)
				{
					this.enum35_0 = value;
					switch (this.enum35_0)
					{
					case Enum35.const_1:
						this.bitmap_0 = Class206.smethod_0("error16");
						break;
					case Enum35.const_2:
						this.bitmap_0 = Class206.smethod_0("warning16");
						break;
					default:
						this.bitmap_0 = null;
						break;
					}
					this.Refresh();
				}
			}
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06001351 RID: 4945 RVA: 0x0000A24E File Offset: 0x0000844E
		// (set) Token: 0x06001352 RID: 4946 RVA: 0x0000A25B File Offset: 0x0000845B
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string Text
		{
			get
			{
				return this.label_0.Text;
			}
			set
			{
				this.label_0.Text = value;
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06001353 RID: 4947 RVA: 0x0000A269 File Offset: 0x00008469
		// (set) Token: 0x06001354 RID: 4948 RVA: 0x0000A271 File Offset: 0x00008471
		public Image Image
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
				this.Refresh();
			}
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x000C6BE0 File Offset: 0x000C4DE0
		protected void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.icon_0 != null)
				{
					this.icon_0.Dispose();
					this.icon_0 = null;
				}
				if (this.image_0 != null)
				{
					this.image_0.Dispose();
					this.image_0 = null;
				}
				if (this.bitmap_0 != null)
				{
					this.bitmap_0.Dispose();
					this.bitmap_0 = null;
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x000C6C48 File Offset: 0x000C4E48
		protected void OnResize(EventArgs e)
		{
			this.label_0.SetBounds(Convert.ToInt32(13f * this.float_0), Convert.ToInt32(15f * this.float_1), base.Width - Convert.ToInt32(69f * this.float_0), base.Height - Convert.ToInt32(18f * this.float_1));
			base.OnResize(e);
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x0000A280 File Offset: 0x00008480
		protected void ScaleCore(float dx, float dy)
		{
			this.float_0 = dx;
			this.float_1 = dy;
			base.ScaleCore(dx, dy);
			this.OnResize(EventArgs.Empty);
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x000C6CBC File Offset: 0x000C4EBC
		protected void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.DrawLine(SystemPens.ControlDark, 0, base.ClientSize.Height - 2, base.ClientSize.Width, base.ClientSize.Height - 2);
			e.Graphics.DrawLine(SystemPens.ControlLightLight, 0, base.ClientSize.Height - 1, base.ClientSize.Width, base.ClientSize.Height - 1);
			Rectangle rectangle = new Rectangle(base.ClientSize.Width - Convert.ToInt32(48f * this.float_0), Convert.ToInt32(11f * this.float_1), Convert.ToInt32(32f * this.float_0), Convert.ToInt32(32f * this.float_1));
			if (this.image_0 != null)
			{
				e.Graphics.DrawImage(this.image_0, rectangle, new Rectangle(0, 0, 32, 32), GraphicsUnit.Pixel);
				return;
			}
			if (this.icon_0 != null)
			{
				e.Graphics.DrawIcon(this.icon_0, rectangle);
				if (this.bitmap_0 != null)
				{
					e.Graphics.DrawImage(this.bitmap_0, new Rectangle(rectangle.Right - Convert.ToInt32(12f * this.float_0), rectangle.Bottom - Convert.ToInt32(12f * this.float_1), Convert.ToInt32(16f * this.float_0), Convert.ToInt32(16f * this.float_1)), new Rectangle(0, 0, 16, 16), GraphicsUnit.Pixel);
				}
			}
		}

		// Token: 0x06001359 RID: 4953 RVA: 0x000C6E70 File Offset: 0x000C5070
		protected void OnFontChanged(EventArgs e)
		{
			try
			{
				this.label_0.Font = new Font(this.Font, FontStyle.Bold);
				base.OnFontChanged(e);
			}
			catch
			{
			}
		}

		// Token: 0x0600135A RID: 4954 RVA: 0x000C6EB0 File Offset: 0x000C50B0
		public Control12()
		{
			try
			{
				this.label_0.FlatStyle = FlatStyle.System;
				this.label_0.Font = new Font(this.Font, FontStyle.Bold);
			}
			catch
			{
			}
			base.Controls.Add(this.label_0);
			this.BackColor = SystemColors.Window;
			base.TabStop = false;
			this.Dock = DockStyle.Top;
			base.Height = 58;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			this.icon_0 = Class213.smethod_0();
			this.OnResize(EventArgs.Empty);
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x0000A2A3 File Offset: 0x000084A3
		public Control12(string text) : this()
		{
			this.label_0.Text = text;
		}

		// Token: 0x04000D9B RID: 3483
		private Label label_0 = new Label();

		// Token: 0x04000D9C RID: 3484
		private Image image_0;

		// Token: 0x04000D9D RID: 3485
		private Icon icon_0;

		// Token: 0x04000D9E RID: 3486
		private Bitmap bitmap_0;

		// Token: 0x04000D9F RID: 3487
		private Enum35 enum35_0;

		// Token: 0x04000DA0 RID: 3488
		private float float_0 = 1f;

		// Token: 0x04000DA1 RID: 3489
		private float float_1 = 1f;
	}
}
