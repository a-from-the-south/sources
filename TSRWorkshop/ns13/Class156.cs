using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns1;
using ns17;
using ns3;
using ns6;

namespace ns13
{
	// Token: 0x02000185 RID: 389
	[Attribute2("Balloon")]
	internal sealed class Class156 : Class154
	{
		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x060011D6 RID: 4566 RVA: 0x000BDC24 File Offset: 0x000BBE24
		// (set) Token: 0x060011D7 RID: 4567 RVA: 0x000097C4 File Offset: 0x000079C4
		[Description("The background color of a tip.")]
		[Attribute1]
		public Color BackColor
		{
			get
			{
				return (Color)this.class152_0.method_2("BackColor", SystemColors.Info);
			}
			set
			{
				this.class152_0.method_3("BackColor", base.method_4(value), Color.Empty);
			}
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x060011D8 RID: 4568 RVA: 0x000BDC5C File Offset: 0x000BBE5C
		// (set) Token: 0x060011D9 RID: 4569 RVA: 0x000097EE File Offset: 0x000079EE
		[Attribute1]
		[Description("The color of the tip border.")]
		public Color BorderColor
		{
			get
			{
				return (Color)this.class152_0.method_2("BorderColor", SystemColors.InfoText);
			}
			set
			{
				this.class152_0.method_3("BorderColor", base.method_4(value), Color.Empty);
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x060011DA RID: 4570 RVA: 0x000BDC94 File Offset: 0x000BBE94
		// (set) Token: 0x060011DB RID: 4571 RVA: 0x00009818 File Offset: 0x00007A18
		[Attribute1]
		[Description("The color of the text on a tip.")]
		public Color TextColor
		{
			get
			{
				return (Color)this.class152_0.method_2("TextColor", SystemColors.InfoText);
			}
			set
			{
				this.class152_0.method_3("TextColor", base.method_4(value), Color.Empty);
			}
		}

		// Token: 0x060011DC RID: 4572 RVA: 0x000BDCCC File Offset: 0x000BBECC
		protected override Class163 vmethod_2(Class161 class161_0)
		{
			Class163 @class = base.vmethod_2(class161_0);
			@class.method_1(4, 18);
			@class.WindowBounds = Rectangle.Inflate(@class.WindowBounds, 4, 2);
			@class.ShadowBounds = new Rectangle(@class.ShadowBounds.Location, @class.ShadowBounds.Size + new Size(8, 32));
			return @class;
		}

		// Token: 0x060011DD RID: 4573 RVA: 0x000BDD38 File Offset: 0x000BBF38
		protected override void vmethod_3(PaintEventArgs paintEventArgs_0, Class161 class161_0, Class163 class163_0)
		{
			if (base.method_8(class161_0) && Rectangle.Intersect(class163_0.ShadowBounds, class163_0.WindowBounds) != class163_0.ShadowBounds)
			{
				Rectangle shadowBounds = class163_0.ShadowBounds;
				shadowBounds.X += 4;
				shadowBounds.Width -= 4;
				shadowBounds.Y += 16;
				shadowBounds.Height -= 28;
				Class154.smethod_4(paintEventArgs_0.Graphics, shadowBounds, 12, Color.FromArgb(128, Color.Black));
			}
		}

		// Token: 0x060011DE RID: 4574 RVA: 0x000BDDD4 File Offset: 0x000BBFD4
		protected override void vmethod_4(PaintEventArgs paintEventArgs_0, Class161 class161_0, Class163 class163_0)
		{
			Rectangle windowBounds = class163_0.WindowBounds;
			GraphicsPath path = Class154.smethod_3(windowBounds, Class154.x9843c083bd22e3f5 ? 10 : 14, Class154.Enum22.flag_0);
			using (Brush brush = new SolidBrush(this.BackColor))
			{
				paintEventArgs_0.Graphics.FillPath(brush, path);
			}
			using (Pen pen = new Pen(this.BorderColor))
			{
				if (Class154.x9843c083bd22e3f5)
				{
					paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				}
				else
				{
					pen.Alignment = PenAlignment.Inset;
				}
				paintEventArgs_0.Graphics.DrawPath(pen, path);
				if (Class154.x9843c083bd22e3f5)
				{
					paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.Default;
				}
				Point[] points = this.method_14(class161_0, windowBounds);
				using (Brush brush2 = new SolidBrush(this.BackColor))
				{
					paintEventArgs_0.Graphics.FillPolygon(brush2, points);
				}
				using (Pen pen2 = new Pen(this.BackColor))
				{
					paintEventArgs_0.Graphics.DrawPolygon(pen2, points);
				}
				paintEventArgs_0.Graphics.DrawLines(pen, points);
			}
		}

		// Token: 0x060011DF RID: 4575 RVA: 0x000BDF1C File Offset: 0x000BC11C
		private Point[] method_14(Class161 class161_0, Rectangle rectangle_0)
		{
			Rectangle rectangle = class161_0.method_6();
			int num = Math.Min(Math.Max(rectangle.X, rectangle_0.X + 16), rectangle_0.Right - 32);
			bool flag = num > rectangle_0.X + rectangle_0.Width / 2;
			Point[] result;
			if (rectangle.Y <= 0)
			{
				result = new Point[]
				{
					new Point(num, rectangle_0.Y),
					new Point(num + (flag ? 16 : 0), rectangle_0.Y - 16),
					new Point(num + 16, rectangle_0.Y)
				};
			}
			else
			{
				result = new Point[]
				{
					new Point(num + 16, rectangle_0.Bottom - 1),
					new Point(num + (flag ? 16 : 0), rectangle_0.Bottom - 1 + 16),
					new Point(num, rectangle_0.Bottom - 1)
				};
			}
			return result;
		}

		// Token: 0x060011E0 RID: 4576 RVA: 0x000BE04C File Offset: 0x000BC24C
		protected override Region vmethod_6(Class161 class161_0, Class163 class163_0)
		{
			Rectangle windowBounds = class163_0.WindowBounds;
			Point[] array = this.method_14(class161_0, windowBounds);
			Point[] array2 = new Point[6];
			if (array[0].Y == windowBounds.Y)
			{
				array.CopyTo(array2, 0);
				Point[] array3 = array2;
				int num = 3;
				Point[] array4 = array2;
				int num2 = 4;
				Point[] array5 = array2;
				int num3 = 5;
				array5[num3] = new Point(windowBounds.X + 10, windowBounds.Bottom);
				array3[num] = (array4[num2] = array5[num3]);
			}
			else
			{
				Point[] array6 = array2;
				int num4 = 0;
				Point[] array7 = array2;
				int num5 = 1;
				Point[] array8 = array2;
				int num6 = 2;
				array8[num6] = new Point(windowBounds.X + 10, windowBounds.Y);
				array6[num4] = (array7[num5] = array8[num6]);
				array.CopyTo(array2, 3);
			}
			Region result;
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddLines(new Point[]
				{
					new Point(windowBounds.X, windowBounds.Y + 5),
					new Point(windowBounds.X + 1, windowBounds.Y + 3),
					new Point(windowBounds.X + 2, windowBounds.Y + 2),
					new Point(windowBounds.X + 3, windowBounds.Y + 1),
					new Point(windowBounds.X + 5, windowBounds.Y),
					new Point(array2[0].X, array2[0].Y),
					new Point(array2[1].X, array2[1].Y),
					new Point(array2[1].X + 1, array2[1].Y),
					new Point(array2[2].X + 1, array2[2].Y),
					new Point(windowBounds.Right - 5, windowBounds.Y),
					new Point(windowBounds.Right - 2, windowBounds.Y + 2),
					new Point(windowBounds.Right - 1, windowBounds.Y + 4),
					new Point(windowBounds.Right, windowBounds.Bottom - 7),
					new Point(windowBounds.Right - 2, windowBounds.Bottom - 3),
					new Point(windowBounds.Right - 5, windowBounds.Bottom - 1),
					new Point(windowBounds.Right - 6, windowBounds.Bottom),
					new Point(array2[3].X + 1, array2[3].Y),
					new Point(array2[4].X + 1, array2[4].Y),
					new Point(array2[4].X, array2[4].Y),
					new Point(array2[5].X, array2[5].Y),
					new Point(windowBounds.X + 5, windowBounds.Bottom),
					new Point(windowBounds.X + 5, windowBounds.Bottom - 1),
					new Point(windowBounds.X + 4, windowBounds.Bottom - 1),
					new Point(windowBounds.X + 2, windowBounds.Bottom - 3),
					new Point(windowBounds.X + 1, windowBounds.Bottom - 4),
					new Point(windowBounds.X, windowBounds.Bottom - 6)
				});
				result = new Region(graphicsPath);
			}
			return result;
		}
	}
}
