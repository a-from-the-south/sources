using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns0;

namespace ns8
{
	// Token: 0x020001E4 RID: 484
	internal sealed class Class213
	{
		// Token: 0x0600138B RID: 5003
		[DllImport("shell32")]
		private static extern int ExtractIconEx(string string_0, int int_6, ref int int_7, ref int int_8, int int_9);

		// Token: 0x0600138C RID: 5004
		[DllImport("user32", CharSet = CharSet.Unicode)]
		private static extern int DrawText(IntPtr intptr_0, string string_0, int int_6, ref Class213.Struct42 struct42_0, int int_7);

		// Token: 0x0600138D RID: 5005
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

		// Token: 0x0600138E RID: 5006
		[DllImport("kernel32.Dll")]
		private static extern short GetVersionEx(ref Class213.Struct43 struct43_1);

		// Token: 0x0600138F RID: 5007
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int int_6);

		// Token: 0x06001390 RID: 5008
		[DllImport("kernel32.dll")]
		private static extern void GetSystemInfo(ref Class213.Struct44 struct44_0);

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06001391 RID: 5009 RVA: 0x000C7B18 File Offset: 0x000C5D18
		private static Class213.Struct43 VersionInfo
		{
			get
			{
				if (!Class213.bool_0)
				{
					Class213.struct43_0 = default(Class213.Struct43);
					try
					{
						Class213.struct43_0.int_0 = Marshal.SizeOf(typeof(Class213.Struct43));
						Class213.GetVersionEx(ref Class213.struct43_0);
						Class213.bool_0 = true;
					}
					catch
					{
					}
				}
				return Class213.struct43_0;
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06001392 RID: 5010 RVA: 0x000C7B7C File Offset: 0x000C5D7C
		internal static bool IsX64
		{
			get
			{
				bool result;
				try
				{
					Class213.Struct44 @struct = default(Class213.Struct44);
					Class213.GetSystemInfo(ref @struct);
					result = (@struct.ushort_0 == 9);
				}
				catch
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06001393 RID: 5011 RVA: 0x000C7BBC File Offset: 0x000C5DBC
		internal static bool IsServerR2
		{
			get
			{
				bool result;
				try
				{
					result = (Class213.GetSystemMetrics(89) != 0);
				}
				catch
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06001394 RID: 5012 RVA: 0x0000A4FE File Offset: 0x000086FE
		internal static bool IsWorkstation
		{
			get
			{
				return Class213.VersionInfo.byte_0 == 1;
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06001395 RID: 5013 RVA: 0x0000A50D File Offset: 0x0000870D
		internal static string ServicePack
		{
			get
			{
				return Class213.VersionInfo.string_0;
			}
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x000C7BF0 File Offset: 0x000C5DF0
		public static Icon smethod_0()
		{
			Icon result;
			try
			{
				result = Class213.smethod_1();
			}
			catch (Exception)
			{
				result = Class206.smethod_1("default");
			}
			return result;
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x000C7C24 File Offset: 0x000C5E24
		private static Icon smethod_1()
		{
			int num = 0;
			int num2 = 0;
			int num3 = Class213.ExtractIconEx(Application.ExecutablePath, -1, ref num2, ref num2, 1);
			if (num3 > 0)
			{
				Class213.ExtractIconEx(Application.ExecutablePath, 0, ref num, ref num2, 1);
				if (num != 0)
				{
					return Icon.FromHandle(new IntPtr(num));
				}
			}
			return null;
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x000C7C6C File Offset: 0x000C5E6C
		internal static int smethod_2(Graphics graphics_0, string string_0, Font font_0, int int_6)
		{
			try
			{
				return Class213.smethod_4(graphics_0, string_0, font_0, int_6);
			}
			catch (Exception)
			{
				try
				{
					return Convert.ToInt32((double)Class213.smethod_3(graphics_0, string_0, font_0, int_6) * 1.1);
				}
				catch (Exception)
				{
				}
			}
			return 0;
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x000C7CC8 File Offset: 0x000C5EC8
		private static int smethod_3(Graphics graphics_0, string string_0, Font font_0, int int_6)
		{
			return Size.Ceiling(graphics_0.MeasureString(string_0, font_0, int_6)).Height;
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x000C7CEC File Offset: 0x000C5EEC
		private static int smethod_4(Graphics graphics_0, string string_0, Font font_0, int int_6)
		{
			Class213.Struct42 @struct = new Class213.Struct42(new Rectangle(0, 0, int_6, 10000));
			IntPtr hdc = graphics_0.GetHdc();
			IntPtr intptr_ = font_0.ToHfont();
			IntPtr intptr_2 = Class213.SelectObject(hdc, intptr_);
			Class213.DrawText(hdc, string_0, -1, ref @struct, 3088);
			Class213.SelectObject(hdc, intptr_2);
			graphics_0.ReleaseHdc(hdc);
			return @struct.int_3 - @struct.int_1;
		}

		// Token: 0x04000DBF RID: 3519
		private const int int_0 = 16;

		// Token: 0x04000DC0 RID: 3520
		private const int int_1 = 1024;

		// Token: 0x04000DC1 RID: 3521
		private const int int_2 = 2048;

		// Token: 0x04000DC2 RID: 3522
		private const int int_3 = 1;

		// Token: 0x04000DC3 RID: 3523
		private const int int_4 = 89;

		// Token: 0x04000DC4 RID: 3524
		private const int int_5 = 9;

		// Token: 0x04000DC5 RID: 3525
		private static bool bool_0;

		// Token: 0x04000DC6 RID: 3526
		private static Class213.Struct43 struct43_0;

		// Token: 0x020001E5 RID: 485
		private struct Struct42
		{
			// Token: 0x0600139C RID: 5020 RVA: 0x0000A519 File Offset: 0x00008719
			public Struct42(Rectangle rectangle)
			{
				this.int_0 = rectangle.Left;
				this.int_1 = rectangle.Top;
				this.int_3 = rectangle.Bottom;
				this.int_2 = rectangle.Right;
			}

			// Token: 0x04000DC7 RID: 3527
			public int int_0;

			// Token: 0x04000DC8 RID: 3528
			public int int_1;

			// Token: 0x04000DC9 RID: 3529
			public int int_2;

			// Token: 0x04000DCA RID: 3530
			public int int_3;
		}

		// Token: 0x020001E6 RID: 486
		private struct Struct43
		{
			// Token: 0x04000DCB RID: 3531
			public int int_0;

			// Token: 0x04000DCC RID: 3532
			public uint uint_0;

			// Token: 0x04000DCD RID: 3533
			public uint uint_1;

			// Token: 0x04000DCE RID: 3534
			public uint uint_2;

			// Token: 0x04000DCF RID: 3535
			public uint uint_3;

			// Token: 0x04000DD0 RID: 3536
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string string_0;

			// Token: 0x04000DD1 RID: 3537
			public ushort ushort_0;

			// Token: 0x04000DD2 RID: 3538
			public ushort ushort_1;

			// Token: 0x04000DD3 RID: 3539
			public ushort ushort_2;

			// Token: 0x04000DD4 RID: 3540
			public byte byte_0;

			// Token: 0x04000DD5 RID: 3541
			private byte byte_1;
		}

		// Token: 0x020001E7 RID: 487
		public struct Struct44
		{
			// Token: 0x04000DD6 RID: 3542
			public ushort ushort_0;

			// Token: 0x04000DD7 RID: 3543
			private ushort ushort_1;

			// Token: 0x04000DD8 RID: 3544
			public uint uint_0;

			// Token: 0x04000DD9 RID: 3545
			public IntPtr intptr_0;

			// Token: 0x04000DDA RID: 3546
			public IntPtr intptr_1;

			// Token: 0x04000DDB RID: 3547
			public IntPtr intptr_2;

			// Token: 0x04000DDC RID: 3548
			public uint uint_1;

			// Token: 0x04000DDD RID: 3549
			public uint uint_2;

			// Token: 0x04000DDE RID: 3550
			public uint uint_3;

			// Token: 0x04000DDF RID: 3551
			public ushort ushort_2;

			// Token: 0x04000DE0 RID: 3552
			public ushort ushort_3;
		}
	}
}
