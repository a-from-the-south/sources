using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns1;
using ns10;
using ns13;
using ns17;
using ns19;
using ns20;
using ns3;
using ns6;

namespace ns8
{
	// Token: 0x02000192 RID: 402
	[Attribute2("Office")]
	internal sealed class Class157 : Class154
	{
		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x0600122D RID: 4653 RVA: 0x000BFD30 File Offset: 0x000BDF30
		// (set) Token: 0x0600122E RID: 4654 RVA: 0x00009971 File Offset: 0x00007B71
		[ParenthesizePropertyName(true)]
		[Description("The preset which determines the default colors used by the renderer.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[DefaultValue(typeof(Class180), "AutoSelect")]
		public Class180 Preset
		{
			get
			{
				Class180 autoSelect;
				if (this.class180_0 != null)
				{
					autoSelect = this.class180_0;
				}
				else
				{
					autoSelect = Class180.AutoSelect;
				}
				return autoSelect;
			}
			set
			{
				this.class180_0 = value;
				base.method_0("Preset");
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x0600122F RID: 4655 RVA: 0x000BFD58 File Offset: 0x000BDF58
		// (set) Token: 0x06001230 RID: 4656 RVA: 0x00009987 File Offset: 0x00007B87
		[Attribute1]
		[Description("Whether a tip is displayed with round corners.")]
		public bool RoundCorners
		{
			get
			{
				return (bool)this.class152_0.method_2("RoundCorners", true);
			}
			set
			{
				this.class152_0.method_3("RoundCorners", value, true);
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06001231 RID: 4657 RVA: 0x000BFD88 File Offset: 0x000BDF88
		// (set) Token: 0x06001232 RID: 4658 RVA: 0x000099A7 File Offset: 0x00007BA7
		[Description("The effect used to draw a tip background.")]
		[Attribute1]
		public Enum32 BackgroundEffect
		{
			get
			{
				return (Enum32)this.class152_0.method_2("BackgroundEffect", Enum32.const_0);
			}
			set
			{
				this.class152_0.method_3("BackgroundEffect", value, Enum32.const_0);
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06001233 RID: 4659 RVA: 0x000BFDB8 File Offset: 0x000BDFB8
		// (set) Token: 0x06001234 RID: 4660 RVA: 0x000097C4 File Offset: 0x000079C4
		[Attribute1]
		[Description("The background color of a tip.")]
		public Color BackColor
		{
			get
			{
				return (Color)this.class152_0.method_2("BackColor", this.Preset.backColor);
			}
			set
			{
				this.class152_0.method_3("BackColor", base.method_4(value), Color.Empty);
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06001235 RID: 4661 RVA: 0x000BFDF4 File Offset: 0x000BDFF4
		// (set) Token: 0x06001236 RID: 4662 RVA: 0x000099C7 File Offset: 0x00007BC7
		[Attribute1]
		[Description("The color into which the background gradient blends on a tip.")]
		public Color BackColorGradient
		{
			get
			{
				return (Color)this.class152_0.method_2("BackColorGradient", this.Preset.backColorGradient);
			}
			set
			{
				this.class152_0.method_3("BackColorGradient", base.method_4(value), Color.Empty);
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06001237 RID: 4663 RVA: 0x000BFE30 File Offset: 0x000BE030
		// (set) Token: 0x06001238 RID: 4664 RVA: 0x000099F1 File Offset: 0x00007BF1
		[Attribute1]
		[Description("The angle of the background gradient, in degrees clockwise from the x-axis (0-360).")]
		public int GradientAngle
		{
			get
			{
				return (int)this.class152_0.method_2("GradientAngle", 90);
			}
			set
			{
				this.class152_0.method_3("GradientAngle", value, 90);
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06001239 RID: 4665 RVA: 0x000BFE60 File Offset: 0x000BE060
		// (set) Token: 0x0600123A RID: 4666 RVA: 0x000097EE File Offset: 0x000079EE
		[Attribute1]
		[Description("The color of the tip border.")]
		public Color BorderColor
		{
			get
			{
				return (Color)this.class152_0.method_2("BorderColor", this.Preset.borderColor);
			}
			set
			{
				this.class152_0.method_3("BorderColor", base.method_4(value), Color.Empty);
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x0600123B RID: 4667 RVA: 0x000BFE9C File Offset: 0x000BE09C
		// (set) Token: 0x0600123C RID: 4668 RVA: 0x00009818 File Offset: 0x00007A18
		[Attribute1]
		[Description("The color of the text on a tip.")]
		public Color TextColor
		{
			get
			{
				return (Color)this.class152_0.method_2("TextColor", this.Preset.textColor);
			}
			set
			{
				this.class152_0.method_3("TextColor", base.method_4(value), Color.Empty);
			}
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x000BFED8 File Offset: 0x000BE0D8
		protected override void vmethod_4(PaintEventArgs paintEventArgs_0, Class161 class161_0, Class163 class163_0)
		{
			Rectangle windowBounds = class163_0.WindowBounds;
			bool flag = this.BackgroundEffect == Enum32.const_1;
			GraphicsPath graphicsPath;
			if (this.RoundCorners)
			{
				graphicsPath = Class154.smethod_3(windowBounds, Class154.x9843c083bd22e3f5 ? 5 : 7, Class154.Enum22.flag_0);
			}
			else
			{
				graphicsPath = new GraphicsPath();
				graphicsPath.AddRectangle(new Rectangle(windowBounds.Location, windowBounds.Size - new Size(1, 1)));
			}
			using (Brush brush = new LinearGradientBrush(windowBounds, this.BackColor, this.BackColorGradient, (float)(this.GradientAngle + (flag ? 180 : 0)), false))
			{
				paintEventArgs_0.Graphics.FillPath(brush, graphicsPath);
			}
			if (flag)
			{
				int num = (int)((1f - (1f - this.BackColor.GetBrightness()) * 0.75f) * 255f);
				Color baseColor = Color.FromArgb(num, num, num);
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(windowBounds, Color.FromArgb(128, baseColor), Color.FromArgb(0, baseColor), LinearGradientMode.Vertical))
				{
					using (GraphicsPath graphicsPath2 = this.method_14(windowBounds, this.RoundCorners ? (Class154.x9843c083bd22e3f5 ? 5 : 7) : 0))
					{
						paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.HighQuality;
						paintEventArgs_0.Graphics.FillPath(linearGradientBrush, graphicsPath2);
						paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.Default;
					}
				}
			}
			using (Pen pen = new Pen(this.BorderColor))
			{
				if (Class154.x9843c083bd22e3f5)
				{
					paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				}
				else
				{
					pen.Alignment = PenAlignment.Center;
				}
				paintEventArgs_0.Graphics.DrawPath(pen, graphicsPath);
				if (Class154.x9843c083bd22e3f5)
				{
					paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.Default;
				}
			}
			if (base.method_5(class161_0))
			{
				int num2 = class163_0.method_3(Enum23.const_6).Top - 6;
				Color color = Color.FromArgb((int)((float)this.BackColorGradient.R * 0.9f), (int)((float)this.BackColorGradient.G * 0.9f), (int)((float)this.BackColorGradient.B * 0.9f));
				using (Pen pen2 = new Pen(color))
				{
					paintEventArgs_0.Graphics.DrawLine(pen2, windowBounds.X + 5, num2, windowBounds.Right - 6, num2);
					pen2.Color = ControlPaint.Light(this.BackColor);
					paintEventArgs_0.Graphics.DrawLine(pen2, windowBounds.X + 5, num2 + 1, windowBounds.Right - 6, num2 + 1);
				}
			}
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x000C01B8 File Offset: 0x000BE3B8
		private GraphicsPath method_14(Rectangle rectangle_0, int int_1)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (int_1 == 0)
			{
				graphicsPath.AddLine(rectangle_0.X, rectangle_0.Y, rectangle_0.Right - 1, rectangle_0.Y);
				graphicsPath.AddLine(rectangle_0.Right - 1, rectangle_0.Y, rectangle_0.Right - 1, rectangle_0.Bottom - 1);
			}
			else
			{
				graphicsPath.AddLine(rectangle_0.X + int_1, rectangle_0.Y, rectangle_0.Right - int_1 - 1, rectangle_0.Y);
				graphicsPath.AddArc(rectangle_0.Right - int_1 - 1, rectangle_0.Y, int_1, int_1, 270f, 90f);
				graphicsPath.AddLine(rectangle_0.Right - 1, rectangle_0.Y + int_1, rectangle_0.Right - 1, rectangle_0.Bottom - int_1);
			}
			graphicsPath.AddBezier(rectangle_0.Right - 1, rectangle_0.Bottom - 1, rectangle_0.Right, rectangle_0.Y + rectangle_0.Height / 2, rectangle_0.X + rectangle_0.Width / 2, rectangle_0.Y, rectangle_0.X, rectangle_0.Y);
			graphicsPath.CloseAllFigures();
			return graphicsPath;
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x000C02F4 File Offset: 0x000BE4F4
		protected override Color vmethod_1(Class161 class161_0, Enum23 enum23_0)
		{
			return this.TextColor;
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x000C030C File Offset: 0x000BE50C
		protected override Region vmethod_6(Class161 class161_0, Class163 class163_0)
		{
			Region result;
			if (this.RoundCorners)
			{
				Rectangle windowBounds = class163_0.WindowBounds;
				windowBounds.Width++;
				windowBounds.Height++;
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddPolygon(new Point[]
				{
					new Point(windowBounds.X + 2, windowBounds.Y),
					new Point(windowBounds.Right - 3, windowBounds.Y),
					new Point(windowBounds.Right - 1, windowBounds.Y + 2),
					new Point(windowBounds.Right - 1, windowBounds.Bottom - 4),
					new Point(windowBounds.Right - 4, windowBounds.Bottom - 1),
					new Point(windowBounds.X + 2, windowBounds.Bottom - 1),
					new Point(windowBounds.X, windowBounds.Bottom - 4),
					new Point(windowBounds.X, windowBounds.Y + 2)
				});
				result = new Region(graphicsPath);
			}
			else
			{
				result = base.vmethod_6(class161_0, class163_0);
			}
			return result;
		}

		// Token: 0x04000CA4 RID: 3236
		private Class180 class180_0;
	}
}
