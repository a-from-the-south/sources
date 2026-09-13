using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns16;

namespace ns13
{
	// Token: 0x0200014F RID: 335
	internal sealed class Class148
	{
		// Token: 0x06000FF2 RID: 4082
		[DllImport("gdi32")]
		private static extern IntPtr SelectObject(IntPtr intptr_2, IntPtr intptr_3);

		// Token: 0x06000FF3 RID: 4083
		[DllImport("user32", CharSet = CharSet.Auto)]
		private static extern int DrawText(IntPtr intptr_2, string string_0, int int_14, ref Class148.Struct13 struct13_0, int int_15);

		// Token: 0x06000FF4 RID: 4084
		[DllImport("gdi32")]
		private static extern int SetTextColor(IntPtr intptr_2, int int_14);

		// Token: 0x06000FF5 RID: 4085
		[DllImport("gdi32")]
		private static extern int GetTextColor(IntPtr intptr_2);

		// Token: 0x06000FF6 RID: 4086
		[DllImport("gdi32")]
		private static extern int SetBkColor(IntPtr intptr_2, int int_14);

		// Token: 0x06000FF7 RID: 4087
		[DllImport("gdi32")]
		private static extern int SetBkMode(IntPtr intptr_2, int int_14);

		// Token: 0x06000FF8 RID: 4088
		[DllImport("gdi32")]
		private static extern IntPtr CreateFontIndirectA(ref Class148.Struct12 struct12_0);

		// Token: 0x06000FF9 RID: 4089
		[DllImport("gdi32")]
		private static extern int DeleteObject(IntPtr intptr_2);

		// Token: 0x06000FFA RID: 4090 RVA: 0x00002BA3 File Offset: 0x00000DA3
		private Class148()
		{
		}

		// Token: 0x06000FFB RID: 4091 RVA: 0x000B8050 File Offset: 0x000B6250
		public static void smethod_0(Graphics graphics_1, string string_0, Font font_1, Color color_0, Color color_1, Rectangle rectangle_0, Enum25 enum25_0)
		{
			if (string_0 != null && string_0.Length != 0 && graphics_1 != null && font_1 != null && !(rectangle_0.Size == Size.Empty) && !color_0.Equals(Color.Empty) && !color_0.Equals(Color.Transparent))
			{
				IntPtr hdc = graphics_1.GetHdc();
				try
				{
					IntPtr intptr_ = Class148.smethod_3(font_1);
					IntPtr intptr_2 = Class148.SelectObject(hdc, intptr_);
					if (!color_1.Equals(Color.Empty) && !color_1.Equals(Color.Transparent))
					{
						Class148.SetBkMode(hdc, 2);
						Class148.SetBkColor(hdc, ColorTranslator.ToWin32(color_1));
					}
					else
					{
						Class148.SetBkMode(hdc, 1);
					}
					int textColor = Class148.GetTextColor(hdc);
					Class148.SetTextColor(hdc, ColorTranslator.ToWin32(color_0));
					Class148.Struct13 @struct = new Class148.Struct13(rectangle_0);
					Class148.DrawText(hdc, string_0, string_0.Length, ref @struct, (int)enum25_0);
					Class148.SetTextColor(hdc, textColor);
					Class148.SelectObject(hdc, intptr_2);
				}
				finally
				{
					graphics_1.ReleaseHdc(hdc);
				}
			}
		}

		// Token: 0x06000FFC RID: 4092 RVA: 0x000B8178 File Offset: 0x000B6378
		public static Size smethod_1(string string_0, Font font_1)
		{
			return Class148.smethod_2(string_0, font_1, Size.Empty, Enum25.const_1);
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x000B8198 File Offset: 0x000B6398
		public static Size smethod_2(string string_0, Font font_1, Size size_0, Enum25 enum25_0)
		{
			Size result;
			if (string_0 != null && string_0.Length != 0 && font_1 != null)
			{
				if (size_0 == Size.Empty)
				{
					size_0 = new Size(32767, 0);
				}
				IntPtr intptr_ = Class148.smethod_3(font_1);
				IntPtr intptr_2 = Class148.SelectObject(Class148.x47a5d035f277dbb5, intptr_);
				Class148.Struct13 @struct = new Class148.Struct13(new Rectangle(0, 0, size_0.Width, size_0.Height));
				Class148.DrawText(Class148.x47a5d035f277dbb5, string_0, string_0.Length, ref @struct, (int)(enum25_0 | (Enum25)1024));
				Class148.SelectObject(Class148.x47a5d035f277dbb5, intptr_2);
				result = new Size(@struct.int_2 - @struct.int_0, @struct.int_3 - @struct.int_1);
			}
			else
			{
				result = Size.Empty;
			}
			return result;
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x000B825C File Offset: 0x000B645C
		private static IntPtr smethod_3(Font font_1)
		{
			IntPtr result;
			if (font_1 == Class148.font_0)
			{
				result = Class148.intptr_0;
			}
			else
			{
				if (Class148.intptr_0 != IntPtr.Zero)
				{
					Class148.DeleteObject(Class148.intptr_0);
				}
				Class148.font_0 = font_1;
				result = (Class148.intptr_0 = Class148.smethod_4(font_1));
			}
			return result;
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x000B82AC File Offset: 0x000B64AC
		private static IntPtr smethod_4(Font font_1)
		{
			object obj = default(Class148.Struct12);
			font_1.ToLogFont(obj);
			Class148.Struct12 @struct = (Class148.Struct12)obj;
			@struct.string_0 = font_1.Name;
			@struct.byte_6 = 0;
			return Class148.CreateFontIndirectA(ref @struct);
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06001000 RID: 4096 RVA: 0x000B82FC File Offset: 0x000B64FC
		private static IntPtr x47a5d035f277dbb5
		{
			get
			{
				if (Class148.intptr_1 == IntPtr.Zero)
				{
					Class148.bitmap_0 = new Bitmap(1, 1);
					Class148.graphics_0 = Graphics.FromImage(Class148.bitmap_0);
					Class148.intptr_1 = Class148.graphics_0.GetHdc();
				}
				return Class148.intptr_1;
			}
		}

		// Token: 0x04000B57 RID: 2903
		private const int int_0 = 1024;

		// Token: 0x04000B58 RID: 2904
		private const int int_1 = 20;

		// Token: 0x04000B59 RID: 2905
		private const int int_2 = 2;

		// Token: 0x04000B5A RID: 2906
		private const int int_3 = 1;

		// Token: 0x04000B5B RID: 2907
		private const int int_4 = 1048576;

		// Token: 0x04000B5C RID: 2908
		private const int int_5 = 0;

		// Token: 0x04000B5D RID: 2909
		private const int int_6 = 1;

		// Token: 0x04000B5E RID: 2910
		private const int int_7 = 2048;

		// Token: 0x04000B5F RID: 2911
		private const int int_8 = 2;

		// Token: 0x04000B60 RID: 2912
		private const int int_9 = 131072;

		// Token: 0x04000B61 RID: 2913
		private const int int_10 = 32;

		// Token: 0x04000B62 RID: 2914
		private const int int_11 = 4;

		// Token: 0x04000B63 RID: 2915
		private const int int_12 = 0;

		// Token: 0x04000B64 RID: 2916
		private const int int_13 = 8;

		// Token: 0x04000B65 RID: 2917
		private static Font font_0;

		// Token: 0x04000B66 RID: 2918
		private static IntPtr intptr_0;

		// Token: 0x04000B67 RID: 2919
		private static IntPtr intptr_1;

		// Token: 0x04000B68 RID: 2920
		private static Graphics graphics_0;

		// Token: 0x04000B69 RID: 2921
		private static Bitmap bitmap_0;

		// Token: 0x02000150 RID: 336
		private struct Struct12
		{
			// Token: 0x04000B6A RID: 2922
			public int int_0;

			// Token: 0x04000B6B RID: 2923
			public int int_1;

			// Token: 0x04000B6C RID: 2924
			public int int_2;

			// Token: 0x04000B6D RID: 2925
			public int int_3;

			// Token: 0x04000B6E RID: 2926
			public int int_4;

			// Token: 0x04000B6F RID: 2927
			public byte byte_0;

			// Token: 0x04000B70 RID: 2928
			public byte byte_1;

			// Token: 0x04000B71 RID: 2929
			public byte byte_2;

			// Token: 0x04000B72 RID: 2930
			public byte byte_3;

			// Token: 0x04000B73 RID: 2931
			public byte byte_4;

			// Token: 0x04000B74 RID: 2932
			public byte byte_5;

			// Token: 0x04000B75 RID: 2933
			public byte byte_6;

			// Token: 0x04000B76 RID: 2934
			public byte byte_7;

			// Token: 0x04000B77 RID: 2935
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
			public string string_0;
		}

		// Token: 0x02000151 RID: 337
		private struct Struct13
		{
			// Token: 0x06001001 RID: 4097 RVA: 0x00008647 File Offset: 0x00006847
			public Struct13(Rectangle r)
			{
				this.int_0 = r.Left;
				this.int_1 = r.Top;
				this.int_2 = r.Right;
				this.int_3 = r.Bottom;
			}

			// Token: 0x04000B78 RID: 2936
			public int int_0;

			// Token: 0x04000B79 RID: 2937
			public int int_1;

			// Token: 0x04000B7A RID: 2938
			public int int_2;

			// Token: 0x04000B7B RID: 2939
			public int int_3;
		}
	}
}
