using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using ns2;

namespace ns0
{
	// Token: 0x020000B2 RID: 178
	[TypeConverter(typeof(Class78))]
	internal sealed class Class77
	{
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060006FA RID: 1786 RVA: 0x0006844C File Offset: 0x0006664C
		public double BaseH
		{
			get
			{
				return this.double_4;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x00068464 File Offset: 0x00066664
		public double BaseS
		{
			get
			{
				return this.double_0;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x0006847C File Offset: 0x0006667C
		public double BaseV
		{
			get
			{
				return this.double_1;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x00068494 File Offset: 0x00066694
		// (set) Token: 0x060006FE RID: 1790 RVA: 0x000055B7 File Offset: 0x000037B7
		public double ShiftH
		{
			get
			{
				return this.double_5;
			}
			set
			{
				this.double_5 = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x000684AC File Offset: 0x000666AC
		// (set) Token: 0x06000700 RID: 1792 RVA: 0x000055C2 File Offset: 0x000037C2
		public double ShiftS
		{
			get
			{
				return this.double_2;
			}
			set
			{
				this.double_2 = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x000684C4 File Offset: 0x000666C4
		// (set) Token: 0x06000702 RID: 1794 RVA: 0x000055CD File Offset: 0x000037CD
		public double ShiftV
		{
			get
			{
				return this.double_3;
			}
			set
			{
				this.double_3 = value;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x000684DC File Offset: 0x000666DC
		// (set) Token: 0x06000704 RID: 1796 RVA: 0x000055D8 File Offset: 0x000037D8
		public double H
		{
			get
			{
				return (this.double_4 + this.double_5) * 360.0;
			}
			set
			{
				this.double_4 = value;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x00068504 File Offset: 0x00066704
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x000055E3 File Offset: 0x000037E3
		public double S
		{
			get
			{
				return this.double_0 + this.double_2;
			}
			set
			{
				this.double_0 = value;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x00068524 File Offset: 0x00066724
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x000055EE File Offset: 0x000037EE
		public double V
		{
			get
			{
				return this.double_1 + this.double_3;
			}
			set
			{
				this.double_1 = value;
			}
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x000055F9 File Offset: 0x000037F9
		public Class77(double h, double s, double v)
		{
			this.double_4 = h / 360.0;
			this.double_0 = s - this.double_0;
			this.double_1 = v - this.double_1;
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00068544 File Offset: 0x00066744
		public Class77(string value)
		{
			string[] array = value.Split(new char[]
			{
				','
			});
			this.double_4 = double.Parse(array[0], CultureInfo.InvariantCulture.NumberFormat);
			this.double_0 = double.Parse(array[1], CultureInfo.InvariantCulture.NumberFormat);
			this.double_1 = double.Parse(array[2], CultureInfo.InvariantCulture.NumberFormat);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x000685B8 File Offset: 0x000667B8
		public Color method_0()
		{
			int red;
			int green;
			int blue;
			this.method_2(this.double_4 * 360.0, this.double_0, this.double_1, out red, out green, out blue);
			return Color.FromArgb(255, red, green, blue);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00068600 File Offset: 0x00066800
		public Color method_1()
		{
			int red;
			int green;
			int blue;
			this.method_2((this.double_4 + this.double_5) * 360.0, this.double_0 + this.double_2, this.double_1 + this.double_3, out red, out green, out blue);
			return Color.FromArgb(255, red, green, blue);
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0006865C File Offset: 0x0006685C
		public string ToString()
		{
			return string.Concat(new string[]
			{
				this.H.ToString("F", CultureInfo.InvariantCulture.NumberFormat),
				", ",
				this.S.ToString("F", CultureInfo.InvariantCulture.NumberFormat),
				", ",
				this.V.ToString("F", CultureInfo.InvariantCulture.NumberFormat)
			});
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000686EC File Offset: 0x000668EC
		private void method_2(double double_6, double double_7, double double_8, out int int_0, out int int_1, out int int_2)
		{
			double num;
			for (num = double_6; num < 0.0; num += 360.0)
			{
			}
			while (num >= 360.0)
			{
				num -= 360.0;
			}
			double num3;
			double num4;
			double num5;
			if (double_8 <= 0.0)
			{
				double num2 = 0.0;
				num3 = (double)0f;
				num4 = (double)0f;
				num5 = num2;
			}
			else if (double_7 <= 0.0)
			{
				num3 = double_8;
				num4 = double_8;
				num5 = double_8;
			}
			else
			{
				double num6 = num / 60.0;
				int num7 = (int)Math.Floor(num6);
				double num8 = num6 - (double)num7;
				double num9 = double_8 * (1.0 - double_7);
				double num10 = double_8 * (1.0 - double_7 * num8);
				double num11 = double_8 * (1.0 - double_7 * (1.0 - num8));
				switch (num7)
				{
				case -1:
					num5 = double_8;
					num4 = num9;
					num3 = num10;
					break;
				case 0:
					num5 = double_8;
					num4 = num11;
					num3 = num9;
					break;
				case 1:
					num5 = num10;
					num4 = double_8;
					num3 = num9;
					break;
				case 2:
					num5 = num9;
					num4 = double_8;
					num3 = num11;
					break;
				case 3:
					num5 = num9;
					num4 = num10;
					num3 = double_8;
					break;
				case 4:
					num5 = num11;
					num4 = num9;
					num3 = double_8;
					break;
				case 5:
					num5 = double_8;
					num4 = num9;
					num3 = num10;
					break;
				case 6:
					num5 = double_8;
					num4 = num11;
					num3 = num9;
					break;
				default:
					num3 = double_8;
					num4 = double_8;
					num5 = double_8;
					break;
				}
			}
			int_0 = this.method_3((int)(num5 * 255.0));
			int_1 = this.method_3((int)(num4 * 255.0));
			int_2 = this.method_3((int)(num3 * 255.0));
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00068890 File Offset: 0x00066A90
		private int method_3(int int_0)
		{
			int result;
			if (int_0 < 0)
			{
				result = 0;
			}
			else if (int_0 > 255)
			{
				result = 255;
			}
			else
			{
				result = int_0;
			}
			return result;
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x000688BC File Offset: 0x00066ABC
		public static Class77 smethod_0(Color color_0)
		{
			double num = (double)color_0.R / 255.0;
			double num2 = (double)color_0.G / 255.0;
			double num3 = (double)color_0.B / 255.0;
			double num4 = Math.Min(Math.Min(num, num2), num3);
			double v;
			double num5 = v = Math.Max(Math.Max(num, num2), num3);
			double num6 = num5 - num4;
			double s;
			double num7;
			if (num5 != 0.0)
			{
				if (num6 != 0.0)
				{
					s = num6 / num5;
					if (num == num5)
					{
						num7 = (num2 - num3) / num6;
						goto IL_113;
					}
					if (num2 == num5)
					{
						num7 = 2.0 + (num3 - num) / num6;
						goto IL_113;
					}
					num7 = 4.0 + (num - num2) / num6;
					goto IL_113;
				}
			}
			s = 0.0;
			num7 = 0.0;
			IL_113:
			num7 *= 60.0;
			if (num7 < 0.0)
			{
				num7 += 360.0;
			}
			return new Class77(num7, s, v);
		}

		// Token: 0x0400062C RID: 1580
		private double double_0;

		// Token: 0x0400062D RID: 1581
		private double double_1;

		// Token: 0x0400062E RID: 1582
		private double double_2;

		// Token: 0x0400062F RID: 1583
		private double double_3;

		// Token: 0x04000630 RID: 1584
		private double double_4;

		// Token: 0x04000631 RID: 1585
		private double double_5;
	}
}
