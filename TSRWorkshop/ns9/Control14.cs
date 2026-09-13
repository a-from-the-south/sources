using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns0;

namespace ns9
{
	// Token: 0x020001DF RID: 479
	[DesignerCategory("Code")]
	internal sealed class Control14 : Control
	{
		// Token: 0x06001361 RID: 4961 RVA: 0x0000A342 File Offset: 0x00008542
		protected void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (!base.DesignMode)
			{
				this.method_0(base.Visible);
			}
		}

		// Token: 0x06001362 RID: 4962 RVA: 0x0000A35F File Offset: 0x0000855F
		private void method_0(bool bool_0)
		{
			this.timer_0.Enabled = bool_0;
			this.int_0 = 0;
			this.Refresh();
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x0000A37A File Offset: 0x0000857A
		protected void OnResize(EventArgs e)
		{
			base.Size = new Size(Convert.ToInt32(250f * this.float_0), Convert.ToInt32(42f * this.float_1));
			base.OnResize(e);
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x0000A3B0 File Offset: 0x000085B0
		protected void ScaleCore(float dx, float dy)
		{
			this.float_0 = dx;
			this.float_1 = dy;
			base.ScaleCore(dx, dy);
			this.OnResize(EventArgs.Empty);
		}

		// Token: 0x06001365 RID: 4965 RVA: 0x0000A3D3 File Offset: 0x000085D3
		protected void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.bitmap_0 != null)
				{
					this.bitmap_0.Dispose();
				}
				this.timer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001366 RID: 4966 RVA: 0x000C7148 File Offset: 0x000C5348
		protected void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (this.bitmap_1 != null)
			{
				e.Graphics.DrawImage(this.bitmap_1, new Rectangle(0, 0, Convert.ToInt32(250f * this.float_0), Convert.ToInt32(42f * this.float_1)), new Rectangle(0, 0, 250, 42), GraphicsUnit.Pixel);
			}
			if (this.bitmap_0 != null && this.int_0 > 0)
			{
				e.Graphics.SetClip(new Rectangle(Convert.ToInt32(46f * this.float_0), 0, Convert.ToInt32(165f * this.float_0), Convert.ToInt32(34f * this.float_1)));
				e.Graphics.DrawImage(this.bitmap_0, new Rectangle(Convert.ToInt32((float)(this.int_0 - 6) * this.float_0), Convert.ToInt32(16f * this.float_1), Convert.ToInt32(40f * this.float_0), Convert.ToInt32(12f * this.float_1)), 0, 0, 40, 12, GraphicsUnit.Pixel);
			}
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x0000A3FD File Offset: 0x000085FD
		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.int_0 += 11;
			if (this.int_0 > 198)
			{
				this.int_0 = 0;
			}
			this.Refresh();
		}

		// Token: 0x06001368 RID: 4968 RVA: 0x000C7270 File Offset: 0x000C5470
		public Control14()
		{
			this.timer_0.Interval = 85;
			this.timer_0.Tick += this.timer_0_Tick;
			base.Size = new Size(250, 42);
			base.TabStop = false;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
		}

		// Token: 0x04000DAD RID: 3501
		private int int_0 = 99;

		// Token: 0x04000DAE RID: 3502
		private readonly Bitmap bitmap_0 = Class206.smethod_0("data");

		// Token: 0x04000DAF RID: 3503
		private readonly Bitmap bitmap_1 = Class206.smethod_0("network");

		// Token: 0x04000DB0 RID: 3504
		private readonly Timer timer_0 = new Timer();

		// Token: 0x04000DB1 RID: 3505
		private float float_0 = 1f;

		// Token: 0x04000DB2 RID: 3506
		private float float_1 = 1f;
	}
}
