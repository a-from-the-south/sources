using System;
using System.Drawing;
using System.Drawing.Imaging;
using ns11;

namespace ns14
{
	// Token: 0x0200004E RID: 78
	internal sealed class Class42
	{
		// Token: 0x06000304 RID: 772 RVA: 0x0003941C File Offset: 0x0003761C
		public static bool smethod_0(Bitmap bitmap_0, int int_0)
		{
			Class41 @class = new Class41();
			@class.method_0(1);
			@class.int_4 = 1;
			@class.int_9 = 8;
			@class.int_10 = 0;
			Class42.smethod_3(bitmap_0, @class);
			return true;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00039458 File Offset: 0x00037658
		public static void smethod_1(Bitmap bitmap_0, ColorMatrix colorMatrix_0)
		{
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix_0);
			Graphics graphics = Graphics.FromImage(bitmap_0);
			Rectangle destRect = new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height);
			graphics.DrawImage(bitmap_0, destRect, 0, 0, bitmap_0.Width, bitmap_0.Height, GraphicsUnit.Pixel, imageAttributes);
		}

		// Token: 0x06000306 RID: 774 RVA: 0x000394A8 File Offset: 0x000376A8
		public static void smethod_2(Bitmap bitmap_0, ColorMap[] colorMap_0)
		{
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(colorMap_0);
			Graphics graphics = Graphics.FromImage(bitmap_0);
			Rectangle rectangle = new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height);
			SolidBrush brush = new SolidBrush(Color.Transparent);
			graphics.FillRectangle(brush, rectangle);
			graphics.DrawImage(bitmap_0, rectangle, 0, 0, bitmap_0.Width, bitmap_0.Height, GraphicsUnit.Pixel, imageAttributes);
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0003950C File Offset: 0x0003770C
		public unsafe static bool smethod_3(Bitmap bitmap_0, Class41 class41_0)
		{
			bool result;
			if (class41_0.int_9 == 0)
			{
				result = false;
			}
			else
			{
				Bitmap bitmap = (Bitmap)bitmap_0.Clone();
				BitmapData bitmapData = bitmap_0.LockBits(new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
				BitmapData bitmapData2 = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
				int stride = bitmapData.Stride;
				int num = stride * 2;
				IntPtr scan = bitmapData.Scan0;
				IntPtr scan2 = bitmapData2.Scan0;
				byte* ptr = (byte*)((void*)scan);
				byte* ptr2 = (byte*)((void*)scan2);
				int num2 = stride - bitmap_0.Width * 3;
				int num3 = bitmap_0.Width - 2;
				int num4 = bitmap_0.Height - 2;
				for (int i = 0; i < num4; i++)
				{
					for (int j = 0; j < num3; j++)
					{
						int num5 = ((int)ptr2[2] * class41_0.int_0 + (int)ptr2[5] * class41_0.int_1 + (int)ptr2[8] * class41_0.int_2 + (int)ptr2[2 + stride] * class41_0.int_3 + (int)ptr2[5 + stride] * class41_0.int_4 + (int)ptr2[8 + stride] * class41_0.int_5 + (int)ptr2[2 + num] * class41_0.int_6 + (int)ptr2[5 + num] * class41_0.int_7 + (int)ptr2[8 + num] * class41_0.int_8) / class41_0.int_9 + class41_0.int_10;
						if (num5 < 0)
						{
							num5 = 0;
						}
						if (num5 > 255)
						{
							num5 = 255;
						}
						ptr[5 + stride] = (byte)num5;
						num5 = ((int)ptr2[1] * class41_0.int_0 + (int)ptr2[4] * class41_0.int_1 + (int)ptr2[7] * class41_0.int_2 + (int)ptr2[1 + stride] * class41_0.int_3 + (int)ptr2[4 + stride] * class41_0.int_4 + (int)ptr2[7 + stride] * class41_0.int_5 + (int)ptr2[1 + num] * class41_0.int_6 + (int)ptr2[4 + num] * class41_0.int_7 + (int)ptr2[7 + num] * class41_0.int_8) / class41_0.int_9 + class41_0.int_10;
						if (num5 < 0)
						{
							num5 = 0;
						}
						if (num5 > 255)
						{
							num5 = 255;
						}
						ptr[4 + stride] = (byte)num5;
						num5 = ((int)(*ptr2) * class41_0.int_0 + (int)ptr2[3] * class41_0.int_1 + (int)ptr2[6] * class41_0.int_2 + (int)ptr2[stride] * class41_0.int_3 + (int)ptr2[3 + stride] * class41_0.int_4 + (int)ptr2[6 + stride] * class41_0.int_5 + (int)ptr2[num] * class41_0.int_6 + (int)ptr2[3 + num] * class41_0.int_7 + (int)ptr2[6 + num] * class41_0.int_8) / class41_0.int_9 + class41_0.int_10;
						if (num5 < 0)
						{
							num5 = 0;
						}
						if (num5 > 255)
						{
							num5 = 255;
						}
						ptr[3 + stride] = (byte)num5;
						ptr += 3;
						ptr2 += 3;
					}
					ptr += 6;
					ptr2 += 6;
					ptr += num2;
					ptr2 += num2;
				}
				bitmap_0.UnlockBits(bitmapData);
				bitmap.UnlockBits(bitmapData2);
				result = true;
			}
			return result;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00039854 File Offset: 0x00037A54
		public unsafe static bool smethod_4(Bitmap bitmap_0, int int_0)
		{
			BitmapData bitmapData = bitmap_0.LockBits(new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			int stride = bitmapData.Stride;
			IntPtr scan = bitmapData.Scan0;
			byte* ptr = (byte*)((void*)scan);
			int num = stride - bitmap_0.Width * 3;
			int num2 = bitmap_0.Width - 2;
			int num3 = bitmap_0.Height - 2;
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					ptr[stride] = (((int)ptr[stride] > int_0) ? byte.MaxValue : 0);
					ptr[stride + 1] = (((int)ptr[stride] > int_0) ? byte.MaxValue : 0);
					ptr[stride + 2] = (((int)ptr[stride] > int_0) ? byte.MaxValue : 0);
					ptr += 3;
				}
				ptr += num;
			}
			bitmap_0.UnlockBits(bitmapData);
			return true;
		}
	}
}
