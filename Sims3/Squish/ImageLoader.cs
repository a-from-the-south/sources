using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Package.ImageResource;

namespace Package.Squish
{
	// Token: 0x02000013 RID: 19
	public class ImageLoader
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x0000371B File Offset: 0x0000191B
		public static Image Load(DDS.MipMap mipMap)
		{
			return ImageLoader.Load(new Size(mipMap.width, mipMap.height), mipMap.data.Length, mipMap.dds.SurfaceDesc, mipMap.data);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00010164 File Offset: 0x0000E364
		private static Image Load(Size imgSize, int datasize, DDS.DDSurfaceDesction description, byte[] data)
		{
			int flags = -1;
			if (description.ddpfPixelFormat.dwFourCC == DXTFormat.DXT1)
			{
				flags = 1;
			}
			else if (description.ddpfPixelFormat.dwFourCC == DXTFormat.DXT3)
			{
				flags = 2;
			}
			else if (description.ddpfPixelFormat.dwFourCC == DXTFormat.DXT5)
			{
				flags = 4;
			}
			else
			{
				if (description.ddpfPixelFormat.dwFourCC == DXTFormat.ATI2)
				{
					Bitmap bitmap = new Bitmap(description.dwWidth, description.dwHeight);
					int num = 0;
					int num2 = 0;
					int num3 = data.Length / 16;
					BinaryReader binaryReader = new BinaryReader(new MemoryStream(data));
					for (int i = 0; i < num3; i++)
					{
						float[] array = new float[8];
						float[] array2 = new float[8];
						array[0] = (float)binaryReader.ReadByte() / 255f;
						array[1] = (float)binaryReader.ReadByte() / 255f;
						if (array[0] > array[1])
						{
							array[2] = (6f * array[0] + 1f * array[1]) / 7f;
							array[3] = (5f * array[0] + 2f * array[1]) / 7f;
							array[4] = (4f * array[0] + 3f * array[1]) / 7f;
							array[5] = (3f * array[0] + 4f * array[1]) / 7f;
							array[6] = (2f * array[0] + 5f * array[1]) / 7f;
							array[7] = (1f * array[0] + 6f * array[1]) / 7f;
						}
						else
						{
							array[2] = (4f * array[0] + 1f * array[1]) / 5f;
							array[3] = (3f * array[0] + 2f * array[1]) / 5f;
							array[4] = (2f * array[0] + 3f * array[1]) / 5f;
							array[5] = (1f * array[0] + 4f * array[1]) / 5f;
							array[6] = 0f;
							array[7] = 1f;
						}
						byte[] array3 = new byte[8];
						binaryReader.Read(array3, 0, 6);
						long num4 = BitConverter.ToInt64(array3, 0);
						array2[0] = (float)binaryReader.ReadByte() / 255f;
						array2[1] = (float)binaryReader.ReadByte() / 255f;
						array3 = new byte[8];
						binaryReader.Read(array3, 0, 6);
						BitConverter.ToInt64(array3, 0);
						if (array2[0] > array2[1])
						{
							array2[2] = (6f * array2[0] + 1f * array2[1]) / 7f;
							array2[3] = (5f * array2[0] + 2f * array2[1]) / 7f;
							array2[4] = (4f * array2[0] + 3f * array2[1]) / 7f;
							array2[5] = (3f * array2[0] + 4f * array2[1]) / 7f;
							array2[6] = (2f * array2[0] + 5f * array2[1]) / 7f;
							array2[7] = (1f * array2[0] + 6f * array2[1]) / 7f;
						}
						else
						{
							array2[2] = (4f * array2[0] + 1f * array2[1]) / 5f;
							array2[3] = (3f * array2[0] + 2f * array2[1]) / 5f;
							array2[4] = (2f * array2[0] + 3f * array2[1]) / 5f;
							array2[5] = (1f * array2[0] + 4f * array2[1]) / 5f;
							array2[6] = 0f;
							array2[7] = 1f;
						}
						for (int j = 0; j < 4; j++)
						{
							for (int k = 0; k < 4; k++)
							{
								int num5 = (j * 4 + k) * 3;
								long num6 = num4 >> num5 & 7L;
								long num7 = num4 >> num5 & 7L;
								bitmap.SetPixel(k + num * 4, j + num2 * 4, Color.FromArgb(255, (int)(255f * array[(int)(checked((IntPtr)num6))]), (int)(255f * array2[(int)(checked((IntPtr)num7))]), 0));
							}
						}
						num++;
						if (num == description.dwWidth / 4)
						{
							num2++;
							num = 0;
						}
					}
					binaryReader.Close();
					return bitmap;
				}
				if ((description.ddpfPixelFormat.dwFlags & 64) == 64)
				{
					if (description.ddpfPixelFormat.dwRGBBitCount == 32)
					{
						return ImageLoader.ImageFromRaw32Data(imgSize.Width, imgSize.Height, data, description.ddpfPixelFormat.dwRBitMask, description.ddpfPixelFormat.dwGBitMask, description.ddpfPixelFormat.dwBBitMask, description.ddpfPixelFormat.dwRGBAlphaBitMask);
					}
					if (description.ddpfPixelFormat.dwRGBBitCount == 8)
					{
						return ImageLoader.ImageFromRaw8Data(imgSize.Width, imgSize.Height, data);
					}
				}
			}
			byte[] data2 = DdsSquish.DecompressImage(data, imgSize.Width, imgSize.Height, flags);
			return ImageLoader.ImageFromRaw32Data(imgSize.Width, imgSize.Height, data2, 255U, 65280U, 16711680U, 4278190080U);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000106D4 File Offset: 0x0000E8D4
		private unsafe static Image ImageFromRaw32Data(int width, int height, byte[] data, uint rm, uint gm, uint bm, uint am)
		{
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
			int num = 4;
			int num2 = 0;
			for (int i = 0; i < bitmapData.Height; i++)
			{
				byte* ptr = (byte*)((void*)bitmapData.Scan0) + i * bitmapData.Stride;
				for (int j = 0; j < bitmapData.Width; j++)
				{
					int value = ((int)data[num2 + 3] << 24) + ((int)data[num2 + 2] << 16) + ((int)data[num2 + 1] << 8) + (int)data[num2];
					byte b = ImageLoader.shift(rm, value);
					byte b2 = ImageLoader.shift(gm, value);
					byte b3 = ImageLoader.shift(bm, value);
					byte b4 = ImageLoader.shift(am, value);
					ptr[j * num] = b3;
					ptr[j * num + 1] = b2;
					ptr[j * num + 2] = b;
					ptr[j * num + 3] = b4;
					num2 += 4;
				}
			}
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000107E4 File Offset: 0x0000E9E4
		private static byte shift(uint mask, int value)
		{
			if (mask == 4278190080U)
			{
				return (byte)(((long)value & 4278190080L) >> 24 & 255L);
			}
			if (mask == 16711680U)
			{
				return (byte)((value & 16711680) >> 16 & 255);
			}
			if (mask == 65280U)
			{
				return (byte)((value & 65280) >> 8 & 255);
			}
			if (mask == 255U)
			{
				return (byte)(value & 255);
			}
			return 0;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0001085C File Offset: 0x0000EA5C
		private unsafe static Image ImageFromRaw8Data(int width, int height, byte[] data)
		{
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
			int num = 1;
			int num2 = 0;
			for (int i = 0; i < bitmapData.Height; i++)
			{
				byte* ptr = (byte*)((void*)bitmapData.Scan0) + i * bitmapData.Stride;
				for (int j = 0; j < bitmapData.Width; j++)
				{
					byte b = data[num2++];
					ptr[j * num] = b;
				}
			}
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000108F8 File Offset: 0x0000EAF8
		private static Image DXT3Parser(Size parentsize, ImageLoader.TxtrFormats format, int imgsize, BinaryReader reader, int wd, int hg)
		{
			Bitmap bitmap = null;
			try
			{
				if (format != ImageLoader.TxtrFormats.DXT3Format)
				{
					if (format != ImageLoader.TxtrFormats.DXT5Format)
					{
						if (wd != 0 && hg != 0)
						{
							bitmap = new Bitmap(wd, hg, PixelFormat.Format24bppRgb);
							goto IL_5D;
						}
						return new Bitmap(Math.Max(1, wd), Math.Max(1, hg));
					}
				}
				if (wd == 0 || hg == 0)
				{
					return new Bitmap(Math.Max(1, wd), Math.Max(1, hg));
				}
				bitmap = new Bitmap(wd, hg, PixelFormat.Format32bppArgb);
				IL_5D:
				int[] array = new int[16];
				for (int i = 0; i < bitmap.Height; i += 4)
				{
					for (int j = 0; j < bitmap.Width; j += 4)
					{
						if (format == ImageLoader.TxtrFormats.DXT3Format)
						{
							long num = reader.ReadInt64();
							for (int k = 0; k < 16; k++)
							{
								array[k] = (int)((num & 15L) * 17L);
								num >>= 4;
							}
						}
						else if (format == ImageLoader.TxtrFormats.DXT5Format)
						{
							int num2 = (int)reader.ReadByte();
							int num3 = (int)reader.ReadByte();
							long num4 = (long)((ulong)reader.ReadUInt32() | (ulong)reader.ReadUInt16() << 32);
							int[] array2 = new int[8];
							array2[0] = num2;
							array2[1] = num3;
							if (num2 > num3)
							{
								array2[2] = (6 * num2 + num3) / 7;
								array2[3] = (5 * num2 + 2 * num3) / 7;
								array2[4] = (4 * num2 + 3 * num3) / 7;
								array2[5] = (3 * num2 + 4 * num3) / 7;
								array2[6] = (2 * num2 + 5 * num3) / 7;
								array2[7] = (num2 + 6 * num3) / 7;
							}
							else
							{
								array2[2] = (4 * num2 + num3) / 5;
								array2[3] = (3 * num2 + 2 * num3) / 5;
								array2[4] = (2 * num2 + 3 * num3) / 5;
								array2[5] = (num2 + 4 * num3) / 5;
								array2[6] = 0;
								array2[7] = 255;
							}
							for (int l = 0; l < 16; l++)
							{
								array[l] = array2[(int)(checked((IntPtr)(num4 & 7L)))];
								num4 >>= 3;
							}
						}
						ushort num5 = reader.ReadUInt16();
						int num6 = (int)reader.ReadUInt16();
						int num7 = (int)Convert.ToByte((double)(num5 >> 11 & 31) * 8.225806451612904);
						int num8 = (int)Convert.ToByte((double)(num5 >> 5 & 63) * 4.0476190476190474);
						int num9 = (int)Convert.ToByte((double)(num5 & 31) * 8.225806451612904);
						int num10 = (int)Convert.ToByte((double)(num6 >> 11 & 31) * 8.225806451612904);
						int num11 = (int)Convert.ToByte((double)(num6 >> 5 & 63) * 4.0476190476190474);
						int num12 = (int)Convert.ToByte((double)(num6 & 31) * 8.225806451612904);
						Color[] array3 = new Color[]
						{
							Color.FromArgb(num7, num8, num9),
							Color.FromArgb(num10, num11, num12),
							Color.FromArgb(((num7 << 1) + num10) / 3 & 255, ((num8 << 1) + num11) / 3 & 255, ((num9 << 1) + num12) / 3 & 255),
							Color.FromArgb(((num10 << 1) + num7) / 3 & 255, ((num11 << 1) + num8) / 3 & 255, ((num12 << 1) + num9) / 3 & 255)
						};
						uint num13 = reader.ReadUInt32();
						for (int m = 0; m < 4; m++)
						{
							for (int n = 0; n < 4; n++)
							{
								try
								{
									if (j + n < wd && i + m < hg)
									{
										uint num14 = num13 >> ((m << 2) + n << 1) & 3U;
										if (format != ImageLoader.TxtrFormats.DXT3Format)
										{
											if (format != ImageLoader.TxtrFormats.DXT5Format)
											{
												bitmap.SetPixel(j + n, i + m, array3[(int)num14]);
												goto IL_39E;
											}
										}
										bitmap.SetPixel(j + n, i + m, Color.FromArgb(array[(m << 2) + n], array3[(int)num14]));
									}
									IL_39E:
									goto IL_3C2;
								}
								catch (Exception)
								{
									goto IL_3C2;
								}
								break;
								IL_3C2:;
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return bitmap;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00010D28 File Offset: 0x0000EF28
		private static byte[] DXT3Writer(Image img, ImageLoader.TxtrFormats format)
		{
			int squishFlags = -1;
			if (format == ImageLoader.TxtrFormats.DXT1Format)
			{
				squishFlags = 1;
			}
			else if (format == ImageLoader.TxtrFormats.DXT3Format)
			{
				squishFlags = 2;
			}
			else if (format == ImageLoader.TxtrFormats.DXT5Format)
			{
				squishFlags = 4;
			}
			return DdsSquish.CompressImage((Bitmap)img, squishFlags);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00010D5C File Offset: 0x0000EF5C
		private static byte[] OldDXT3Writer(Image img, ImageLoader.TxtrFormats format)
		{
			if (img == null)
			{
				return new byte[0];
			}
			BinaryWriter binaryWriter = new BinaryWriter(new MemoryStream());
			Bitmap bitmap = (Bitmap)img;
			new int[bitmap.Width * bitmap.Height];
			for (int i = 0; i < bitmap.Height; i += 4)
			{
				for (int j = 0; j < bitmap.Width; j += 4)
				{
					if (format == ImageLoader.TxtrFormats.DXT3Format)
					{
						Color[] array = new Color[4];
						for (int k = 0; k < 4; k++)
						{
							for (int l = 0; l < 4; l++)
							{
								if (j + l < bitmap.Width && i + k < bitmap.Height)
								{
									array[l] = bitmap.GetPixel(j + l, i + k);
								}
								else
								{
									array[l] = Color.Black;
								}
							}
							ImageLoader.DXT3WriteTransparencyBlock(binaryWriter, array);
						}
					}
					else if (format == ImageLoader.TxtrFormats.DXT5Format)
					{
						Color[] array2 = new Color[16];
						for (int m = 0; m < 4; m++)
						{
							for (int n = 0; n < 4; n++)
							{
								if (j + n < bitmap.Width && i + m < bitmap.Height)
								{
									array2[m * 4 + n] = bitmap.GetPixel(j + n, i + m);
								}
								else
								{
									array2[m * 4 + n] = Color.Black;
								}
							}
						}
						ImageLoader.DXT5WriteTransparencyBlock(binaryWriter, array2);
					}
					Color[,] array3 = new Color[4, 4];
					for (int num = 0; num < 4; num++)
					{
						for (int num2 = 0; num2 < 4; num2++)
						{
							try
							{
								if (j + num2 < bitmap.Width && i + num < bitmap.Height)
								{
									array3[num2, num] = bitmap.GetPixel(j + num2, i + num);
								}
								else
								{
									array3[num2, num] = Color.Black;
								}
								goto IL_1C3;
							}
							catch (Exception)
							{
								goto IL_1C3;
							}
							break;
							IL_1C3:;
						}
					}
					ImageLoader.DXT3WriteTexel(binaryWriter, array3, format);
				}
			}
			BinaryReader binaryReader = new BinaryReader(binaryWriter.BaseStream);
			binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
			return binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00010F78 File Offset: 0x0000F178
		protected static void DXT3WriteTransparencyBlock(BinaryWriter writer, Color[] alphas)
		{
			ushort num = 0;
			for (int i = alphas.Length - 1; i >= 0; i--)
			{
				byte b = alphas[i].A * 15 / byte.MaxValue;
				num = (ushort)(num << 4);
				num |= (ushort)(b & 15);
			}
			writer.Write(num);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00010FC4 File Offset: 0x0000F1C4
		protected static void DXT5WriteTransparencyBlock(BinaryWriter writer, Color[] alphas)
		{
			byte[] array = new byte[8];
			array[0] = 0;
			array[1] = byte.MaxValue;
			foreach (Color color in alphas)
			{
				if (color.A > array[0])
				{
					array[0] = color.A;
				}
				if (color.A < array[1])
				{
					array[1] = color.A;
				}
			}
			array[2] = (6 * array[0] + array[1]) / 7;
			array[3] = (5 * array[0] + 2 * array[1]) / 7;
			array[4] = (4 * array[0] + 3 * array[1]) / 7;
			array[5] = (3 * array[0] + 4 * array[1]) / 7;
			array[6] = (2 * array[0] + 5 * array[1]) / 7;
			array[7] = (array[0] + 6 * array[1]) / 7;
			long num = 0L;
			for (int j = alphas.Length - 1; j >= 0; j--)
			{
				Color color2 = alphas[j];
				int num2 = 0;
				int num3 = int.MaxValue;
				for (int k = 0; k < array.Length; k++)
				{
					if (Math.Abs((int)(color2.A - array[k])) < num3)
					{
						num3 = Math.Abs((int)(color2.A - array[k]));
						num2 = k;
					}
				}
				num <<= 3;
				num |= (long)num2;
			}
			ushort value = (ushort)(num >> 32 & 65535L);
			uint value2 = (uint)(num & 4294967295L);
			writer.Write(array[0]);
			writer.Write(array[1]);
			writer.Write(value2);
			writer.Write(value);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0001114C File Offset: 0x0000F34C
		protected static double DXT3ColorDist(Color table, Color test)
		{
			return Math.Pow((double)(table.R - test.R), 2.0) + Math.Pow((double)(table.G - test.G), 2.0) + Math.Pow((double)(table.B - test.B), 2.0);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000111B8 File Offset: 0x0000F3B8
		protected static byte DXT3NearestTableColor(Color[] table, Color col)
		{
			double num = double.MaxValue;
			int num2 = 0;
			for (int i = 0; i < 4; i++)
			{
				double num3 = ImageLoader.DXT3ColorDist(table[i], col);
				if (num3 < num)
				{
					num = num3;
					num2 = i;
				}
			}
			return (byte)(num2 & 3);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000374C File Offset: 0x0000194C
		protected static void DXT3MinColor(ref Color table, Color test)
		{
			if (table.ToArgb() > test.ToArgb())
			{
				table = test;
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00003764 File Offset: 0x00001964
		protected static void DXT3MaxColor(ref Color table, Color test)
		{
			if (table.ToArgb() < test.ToArgb())
			{
				table = test;
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000111F8 File Offset: 0x0000F3F8
		protected static Color DXT3MixColors(Color c1, Color c2, double f1, double f2)
		{
			byte red = Convert.ToByte((double)c1.R * f1 + (double)c2.R * f2);
			byte green = Convert.ToByte((double)c1.G * f1 + (double)c2.G * f2);
			byte blue = Convert.ToByte((double)c1.B * f1 + (double)c2.B * f2);
			return Color.FromArgb(255, (int)red, (int)green, (int)blue);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00011264 File Offset: 0x0000F464
		protected static short DXT3Get565Color(Color col)
		{
			return (short)(((int)(col.R * 31 / byte.MaxValue & 31) << 6 | (int)(col.G * 63 / byte.MaxValue & 63)) << 5 | (int)(col.B * 31 / byte.MaxValue & 31));
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000112B4 File Offset: 0x0000F4B4
		private static void DXT3WriteTexel(BinaryWriter writer, Color[,] colors, ImageLoader.TxtrFormats format)
		{
			Color[] array = new Color[4];
			array[0] = Color.White;
			array[1] = Color.Black;
			for (byte b = 0; b < 4; b += 1)
			{
				for (byte b2 = 0; b2 < 4; b2 += 1)
				{
					Color test = colors[(int)b2, (int)b];
					ImageLoader.DXT3MinColor(ref array[0], test);
					ImageLoader.DXT3MaxColor(ref array[1], test);
				}
			}
			if (array[0].ToArgb() <= array[1].ToArgb())
			{
				array[2] = ImageLoader.DXT3MixColors(array[0], array[1], 0.5, 0.5);
				array[3] = Color.Black;
			}
			else
			{
				array[2] = ImageLoader.DXT3MixColors(array[0], array[1], 0.6666666666666666, 0.3333333333333333);
				array[3] = ImageLoader.DXT3MixColors(array[0], array[1], 0.3333333333333333, 0.6666666666666666);
			}
			writer.Write(ImageLoader.DXT3Get565Color(array[0]));
			writer.Write(ImageLoader.DXT3Get565Color(array[1]));
			for (short num = 0; num < 4; num += 1)
			{
				int num2 = 0;
				for (short num3 = 3; num3 >= 0; num3 -= 1)
				{
					num2 <<= 2;
					num2 |= (int)ImageLoader.DXT3NearestTableColor(array, colors[(int)num3, (int)num]);
				}
				writer.Write((byte)num2);
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00011438 File Offset: 0x0000F638
		private static byte[] RAWWriter(Image img, ImageLoader.TxtrFormats format)
		{
			if (img == null)
			{
				return new byte[0];
			}
			BinaryWriter binaryWriter = new BinaryWriter(new MemoryStream());
			Bitmap bitmap = (Bitmap)img;
			for (int i = 0; i < bitmap.Height; i++)
			{
				for (int j = 0; j < bitmap.Width; j++)
				{
					Color pixel = bitmap.GetPixel(j, i);
					binaryWriter.Write(pixel.B);
					if (format != ImageLoader.TxtrFormats.Raw8Bit && format != ImageLoader.TxtrFormats.ExtRaw8Bit)
					{
						binaryWriter.Write(pixel.G);
						binaryWriter.Write(pixel.R);
						if (format == ImageLoader.TxtrFormats.Raw32Bit)
						{
							binaryWriter.Write(pixel.A);
						}
					}
				}
			}
			BinaryReader binaryReader = new BinaryReader(binaryWriter.BaseStream);
			binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
			return binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
		}

		// Token: 0x020000FA RID: 250
		private enum TxtrFormats : uint
		{
			// Token: 0x040005E4 RID: 1508
			Unknown,
			// Token: 0x040005E5 RID: 1509
			Raw32Bit,
			// Token: 0x040005E6 RID: 1510
			Raw24Bit,
			// Token: 0x040005E7 RID: 1511
			ExtRaw8Bit,
			// Token: 0x040005E8 RID: 1512
			DXT1Format,
			// Token: 0x040005E9 RID: 1513
			DXT3Format,
			// Token: 0x040005EA RID: 1514
			Raw8Bit,
			// Token: 0x040005EB RID: 1515
			DXT5Format = 8U,
			// Token: 0x040005EC RID: 1516
			ExtRaw24Bit,
			// Token: 0x040005ED RID: 1517
			Raw32Bit_BGRA
		}
	}
}
