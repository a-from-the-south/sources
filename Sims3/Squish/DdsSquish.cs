using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Sims3WorkshopSDK;

namespace Package.Squish
{
	// Token: 0x02000012 RID: 18
	internal sealed class DdsSquish
	{
		// Token: 0x060000EE RID: 238 RVA: 0x000036F6 File Offset: 0x000018F6
		private static bool Is64Bit()
		{
			return Marshal.SizeOf<IntPtr>(IntPtr.Zero) == 8;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000FFB4 File Offset: 0x0000E1B4
		private unsafe static void CallCompressImage(byte[] rgba, int width, int height, byte[] blocks, int flags)
		{
			fixed (byte[] array = rgba)
			{
				byte* rgba2;
				if (rgba != null && array.Length != 0)
				{
					rgba2 = &array[0];
				}
				else
				{
					rgba2 = null;
				}
				fixed (byte[] array2 = blocks)
				{
					byte* blocks2;
					if (blocks != null && array2.Length != 0)
					{
						blocks2 = &array2[0];
					}
					else
					{
						blocks2 = null;
					}
					if (DdsSquish.Is64Bit())
					{
						DdsSquish.SquishInterface_64.SquishCompressImage(rgba2, width, height, blocks2, flags);
					}
					else
					{
						DdsSquish.SquishInterface_32.SquishCompressImage(rgba2, width, height, blocks2, flags);
					}
				}
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00010014 File Offset: 0x0000E214
		private unsafe static void CallDecompressImage(byte[] rgba, int width, int height, byte[] blocks, int flags)
		{
			fixed (byte[] array = rgba)
			{
				byte* rgba2;
				if (rgba != null && array.Length != 0)
				{
					rgba2 = &array[0];
				}
				else
				{
					rgba2 = null;
				}
				fixed (byte[] array2 = blocks)
				{
					byte* blocks2;
					if (blocks != null && array2.Length != 0)
					{
						blocks2 = &array2[0];
					}
					else
					{
						blocks2 = null;
					}
					if (DdsSquish.Is64Bit())
					{
						DdsSquish.SquishInterface_64.SquishDecompressImage(rgba2, width, height, blocks2, flags);
					}
					else
					{
						DdsSquish.SquishInterface_32.SquishDecompressImage(rgba2, width, height, blocks2, flags);
					}
				}
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00010074 File Offset: 0x0000E274
		internal static byte[] CompressImage(Bitmap inputSurface, int squishFlags)
		{
			byte[] array = new byte[inputSurface.Width * inputSurface.Height * 4];
			FastPixel fastPixel = new FastPixel(inputSurface);
			fastPixel.Lock();
			for (int i = 0; i < inputSurface.Height; i++)
			{
				for (int j = 0; j < inputSurface.Width; j++)
				{
					Color pixel = fastPixel.GetPixel(j, i);
					int num = i * fastPixel.Width * 4 + j * 4;
					array[num] = pixel.R;
					array[num + 1] = pixel.G;
					array[num + 2] = pixel.B;
					array[num + 3] = pixel.A;
				}
			}
			fastPixel.Unlock(false);
			int num2 = (inputSurface.Width + 3) / 4 * ((inputSurface.Height + 3) / 4);
			int num3 = ((squishFlags & 1) != 0) ? 8 : 16;
			byte[] array2 = new byte[num2 * num3];
			DdsSquish.CallCompressImage(array, inputSurface.Width, inputSurface.Height, array2, squishFlags);
			return array2;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00003705 File Offset: 0x00001905
		internal static byte[] DecompressImage(byte[] blocks, int width, int height, int flags)
		{
			byte[] array = new byte[width * height * 4];
			DdsSquish.CallDecompressImage(array, width, height, blocks, flags);
			return array;
		}

		// Token: 0x020000F7 RID: 247
		public enum SquishFlags
		{
			// Token: 0x040005DA RID: 1498
			kDxt1 = 1,
			// Token: 0x040005DB RID: 1499
			kDxt3,
			// Token: 0x040005DC RID: 1500
			kDxt5 = 4,
			// Token: 0x040005DD RID: 1501
			kColourClusterFit = 8,
			// Token: 0x040005DE RID: 1502
			kColourRangeFit = 16,
			// Token: 0x040005DF RID: 1503
			kColourMetricPerceptual = 32,
			// Token: 0x040005E0 RID: 1504
			kColourMetricUniform = 64,
			// Token: 0x040005E1 RID: 1505
			kWeightColourByAlpha = 128,
			// Token: 0x040005E2 RID: 1506
			kColourIterativeClusterFit = 256
		}

		// Token: 0x020000F8 RID: 248
		private sealed class SquishInterface_32
		{
			// Token: 0x06000C73 RID: 3187
			[DllImport("squishdll.dll")]
			internal unsafe static extern void SquishCompressImage(byte* rgba, int width, int height, byte* blocks, int flags);

			// Token: 0x06000C74 RID: 3188
			[DllImport("squishdll.dll")]
			internal unsafe static extern void SquishDecompressImage(byte* rgba, int width, int height, byte* blocks, int flags);
		}

		// Token: 0x020000F9 RID: 249
		private sealed class SquishInterface_64
		{
			// Token: 0x06000C76 RID: 3190
			[DllImport("squishdll_x64.dll")]
			internal unsafe static extern void SquishCompressImage(byte* rgba, int width, int height, byte* blocks, int flags);

			// Token: 0x06000C77 RID: 3191
			[DllImport("squishdll_x64.dll")]
			internal unsafe static extern void SquishDecompressImage(byte* rgba, int width, int height, byte* blocks, int flags);
		}
	}
}
