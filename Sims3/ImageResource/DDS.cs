using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Package.Squish;
using Sims3WorkshopSDK;

namespace Package.ImageResource
{
	// Token: 0x020000ED RID: 237
	public class DDS : DBPFEntry, TextureResource
	{
		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000C11 RID: 3089 RVA: 0x00008B3D File Offset: 0x00006D3D
		public string Description
		{
			get
			{
				return this._description;
			}
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x0003B110 File Offset: 0x00039310
		public DDS(DXTFormat format)
		{
			this.typeId = 11720834U;
			this.surfaceDescription = new DDS.DDSurfaceDesction();
			this.surfaceDescription.ddpfPixelFormat.dwFlags = 4;
			this.surfaceDescription.ddpfPixelFormat.dwRGBBitCount = 32;
			this.surfaceDescription.ddpfPixelFormat.dwFourCC = format;
			if (format == DXTFormat.RAW32)
			{
				this.surfaceDescription.ddpfPixelFormat.dwFlags = 65;
				this.surfaceDescription.ddpfPixelFormat.dwRBitMask = 16711680U;
				this.surfaceDescription.ddpfPixelFormat.dwGBitMask = 65280U;
				this.surfaceDescription.ddpfPixelFormat.dwBBitMask = 255U;
				this.surfaceDescription.ddpfPixelFormat.dwRGBAlphaBitMask = 4278190080U;
			}
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x0003B1E4 File Offset: 0x000393E4
		public DDS(DBPFType type)
		{
			this.typeId = type;
			this.surfaceDescription = new DDS.DDSurfaceDesction();
			this.surfaceDescription.ddpfPixelFormat.dwFlags = 4;
			this.surfaceDescription.ddpfPixelFormat.dwRGBBitCount = 32;
			this.surfaceDescription.ddpfPixelFormat.dwFourCC = DXTFormat.DXT3;
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x00008B45 File Offset: 0x00006D45
		public DDS() : this(11720834)
		{
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000C15 RID: 3093 RVA: 0x00008B52 File Offset: 0x00006D52
		public DDS.DDSurfaceDesction SurfaceDesc
		{
			get
			{
				return this.surfaceDescription;
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000C16 RID: 3094 RVA: 0x00008B5A File Offset: 0x00006D5A
		public DDS.DDSPixelFormat PixelFormat
		{
			get
			{
				return this.surfaceDescription.ddpfPixelFormat;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000C17 RID: 3095 RVA: 0x00008B67 File Offset: 0x00006D67
		public int Width
		{
			get
			{
				return this.surfaceDescription.dwWidth;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x00008B74 File Offset: 0x00006D74
		public int Height
		{
			get
			{
				return this.surfaceDescription.dwHeight;
			}
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x0003B24C File Offset: 0x0003944C
		public void AddImage(Bitmap image, bool generateMipMaps, DXTFormat format)
		{
			this.mipMaps.Clear();
			if (generateMipMaps)
			{
				int i = image.Width;
				int num = image.Height;
				while (i > 0)
				{
					Bitmap image2 = this.Resize(image, i, num, true);
					i = Math.Max(1, i / 2);
					num = Math.Max(1, num / 2);
					this.AddImage(image2, format);
					if (i == 1 || num == 1)
					{
						break;
					}
				}
			}
			else
			{
				this.AddImage(image, format);
			}
			this.surfaceDescription.dwWidth = image.Width;
			this.surfaceDescription.dwHeight = image.Height;
			this.surfaceDescription.ddpfPixelFormat.dwFourCC = format;
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x0003B2E8 File Offset: 0x000394E8
		public Bitmap Resize(Bitmap b, int nWidth, int nHeight, bool bBilinear)
		{
			Bitmap bitmap = (Bitmap)b.Clone();
			b = new Bitmap(nWidth, nHeight, bitmap.PixelFormat);
			FastPixel fastPixel = new FastPixel(bitmap);
			FastPixel fastPixel2 = new FastPixel(b);
			fastPixel.Lock();
			fastPixel2.Lock();
			double num = (double)bitmap.Width / (double)nWidth;
			double num2 = (double)bitmap.Height / (double)nHeight;
			if (bBilinear)
			{
				Color color = default(Color);
				Color color2 = default(Color);
				Color color3 = default(Color);
				Color color4 = default(Color);
				for (int i = 0; i < b.Width; i++)
				{
					for (int j = 0; j < b.Height; j++)
					{
						int num3 = (int)Math.Floor((double)i * num);
						int num4 = (int)Math.Floor((double)j * num2);
						int num5 = num3 + 1;
						if (num5 >= bitmap.Width)
						{
							num5 = num3;
						}
						int num6 = num4 + 1;
						if (num6 >= bitmap.Height)
						{
							num6 = num4;
						}
						double num7 = (double)i * num - (double)num3;
						double num8 = (double)j * num2 - (double)num4;
						double num9 = 1.0 - num7;
						double num10 = 1.0 - num8;
						color = fastPixel.GetPixel(num3, num4);
						color2 = fastPixel.GetPixel(num5, num4);
						color3 = fastPixel.GetPixel(num3, num6);
						color4 = fastPixel.GetPixel(num5, num6);
						byte b2 = (byte)(num9 * (double)color.B + num7 * (double)color2.B);
						byte b3 = (byte)(num9 * (double)color3.B + num7 * (double)color4.B);
						byte blue = (byte)(num10 * (double)b2 + num8 * (double)b3);
						b2 = (byte)(num9 * (double)color.G + num7 * (double)color2.G);
						b3 = (byte)(num9 * (double)color3.G + num7 * (double)color4.G);
						byte green = (byte)(num10 * (double)b2 + num8 * (double)b3);
						b2 = (byte)(num9 * (double)color.R + num7 * (double)color2.R);
						b3 = (byte)(num9 * (double)color3.R + num7 * (double)color4.R);
						byte red = (byte)(num10 * (double)b2 + num8 * (double)b3);
						b2 = (byte)(num9 * (double)color.A + num7 * (double)color2.A);
						b3 = (byte)(num9 * (double)color3.A + num7 * (double)color4.A);
						byte alpha = (byte)(num10 * (double)b2 + num8 * (double)b3);
						fastPixel2.SetPixel(i, j, Color.FromArgb((int)alpha, (int)red, (int)green, (int)blue));
					}
				}
				fastPixel.Unlock(false);
				fastPixel2.Unlock(true);
			}
			else
			{
				for (int k = 0; k < b.Width; k++)
				{
					for (int l = 0; l < b.Height; l++)
					{
						b.SetPixel(k, l, bitmap.GetPixel((int)Math.Floor((double)k * num), (int)Math.Floor((double)l * num2)));
					}
				}
			}
			return b;
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00008B81 File Offset: 0x00006D81
		public void AddImage(Bitmap image)
		{
			this.AddImage(image, DXTFormat.DXT5);
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x0003B5C4 File Offset: 0x000397C4
		public void AddImage(Bitmap image, DXTFormat format)
		{
			int num = 0;
			if (format != DXTFormat.UNKNOWN)
			{
				this.surfaceDescription.ddpfPixelFormat.dwFourCC = format;
			}
			if (this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DXT1)
			{
				num = 1;
			}
			else if (this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DXT3)
			{
				num = 2;
			}
			else if (this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DXT5)
			{
				num = 4;
			}
			int width = image.Width;
			int height = image.Height;
			byte[] array;
			if (num == 0)
			{
				array = new byte[width * height * 4];
				int num2 = 0;
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						Color pixel = image.GetPixel(j, i);
						array[num2++] = pixel.A;
						array[num2++] = pixel.R;
						array[num2++] = pixel.G;
						array[num2++] = pixel.B;
					}
				}
			}
			else
			{
				array = DdsSquish.CompressImage(image, num);
			}
			DDS.MipMap mipMap = new DDS.MipMap(this, array, image.Width, image.Height);
			mipMap._alphaData = null;
			this.mipMaps.Add(mipMap);
			if (mipMap.width > this.surfaceDescription.dwWidth || mipMap.height > this.surfaceDescription.dwHeight)
			{
				this.surfaceDescription.dwWidth = mipMap.width;
				this.surfaceDescription.dwHeight = mipMap.height;
			}
			this.surfaceDescription.dwMipMapCount = this.mipMaps.Count;
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x0003B75C File Offset: 0x0003995C
		public void LoadFile(string filename)
		{
			FileStream fileStream = new FileStream(filename, FileMode.Open);
			this.data = new byte[fileStream.Length];
			fileStream.Read(this.data, 0, (int)fileStream.Length);
			fileStream.Dispose();
			this.UnSerialize();
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x000032AF File Offset: 0x000014AF
		public override void SetData(byte[] data)
		{
			this.data = data;
			this.UnSerialize();
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x0003B7A4 File Offset: 0x000399A4
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.UnSerialize(binaryReader);
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x0003B7D8 File Offset: 0x000399D8
		public void UnSerialize(BinaryReader binaryReader)
		{
			this.mipMaps.Clear();
			this.surfaceDescription = new DDS.DDSurfaceDesction();
			this.surfaceDescription.UnSerialize(binaryReader);
			int num = this.surfaceDescription.dwWidth;
			int num2 = this.surfaceDescription.dwHeight;
			int num3 = this.surfaceDescription.dwMipMapCount;
			if ((this.surfaceDescription.dwFlags & 131072) == 0)
			{
				num3 = 1;
			}
			bool flag = false;
			if (this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DST1 || this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DST3 || this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DST5)
			{
				int num4 = (int)(binaryReader.BaseStream.Length - 128L);
				binaryReader.BaseStream.Position = 128L;
				BinaryReader binaryReader2 = new BinaryReader(binaryReader.BaseStream);
				MemoryStream memoryStream = new MemoryStream();
				byte[] buffer = binaryReader2.ReadBytes(num4);
				BinaryWriter writer = new BinaryWriter(memoryStream);
				if (this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DST5)
				{
					this.surfaceDescription.ddpfPixelFormat.dwFourCC = DXTFormat.DXT5;
					this.surfaceDescription.Serialize(writer);
					int num5 = 0;
					int num6 = 0 + (num4 >> 3);
					int num7 = num6 + (num4 >> 2);
					int num8 = num7 + (6 * num4 >> 4);
					int num9 = (num6 - 0) / 2;
					for (int i = 0; i < num9; i++)
					{
						memoryStream.Write(buffer, num5, 2);
						memoryStream.Write(buffer, num7, 6);
						memoryStream.Write(buffer, num6, 4);
						memoryStream.Write(buffer, num8, 4);
						num5 += 2;
						num7 += 6;
						num6 += 4;
						num8 += 4;
					}
				}
				else
				{
					if (this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DST3)
					{
						this.surfaceDescription.ddpfPixelFormat.dwFourCC = DXTFormat.DXT3;
						this.surfaceDescription.Serialize(writer);
						throw new NotImplementedException("no samples");
					}
					if (this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DST1)
					{
						this.surfaceDescription.ddpfPixelFormat.dwFourCC = DXTFormat.DXT1;
						this.surfaceDescription.Serialize(writer);
						int num10 = 0;
						int num11 = 0 + (num4 >> 1);
						int num12 = (num11 - 0) / 4;
						for (int j = 0; j < num12; j++)
						{
							memoryStream.Write(buffer, num10, 4);
							memoryStream.Write(buffer, num11, 4);
							num10 += 4;
							num11 += 4;
						}
					}
				}
				memoryStream.Position = 128L;
				binaryReader = new BinaryReader(memoryStream);
				flag = true;
			}
			for (int k = 0; k < num3; k++)
			{
				int num13;
				if ((this.surfaceDescription.ddpfPixelFormat.dwFlags & 64) == 64)
				{
					num13 = num * num2 * 4;
				}
				else
				{
					int num14 = (this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DXT1) ? 8 : 16;
					num13 = Math.Max(1, num / 4) * Math.Max(1, num2 / 4) * num14;
				}
				this.dataSizeRaw += num * num2 * 4;
				this.dataSize += num13;
				byte[] data = binaryReader.ReadBytes(num13);
				DDS.MipMap mipMap = new DDS.MipMap(this, data, num, num2);
				mipMap._alphaData = null;
				this.mipMaps.Add(mipMap);
				num = Math.Max(1, num / 2);
				num2 = Math.Max(1, num2 / 2);
			}
			if (flag)
			{
				this.data = null;
				this.data = this.Serialize();
			}
			this.UpdateDescription();
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x0003BB68 File Offset: 0x00039D68
		public void UpdateDescription()
		{
			int dwWidth = this.surfaceDescription.dwWidth;
			int dwHeight = this.surfaceDescription.dwHeight;
			this._description = dwWidth.ToString() + " x " + dwHeight.ToString();
			this._description += ((this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DXT1) ? " DXT1" : ((this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DXT2) ? " DXT2" : ((this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DXT3) ? " DXT3" : ((this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DXT4) ? " DXT4" : ((this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.DXT5) ? " DXT5" : ((this.surfaceDescription.ddpfPixelFormat.dwFourCC == DXTFormat.RAW32) ? " RAW32" : "Unknown"))))));
			this._description = this._description + " MipMaps: " + this.surfaceDescription.dwMipMapCount.ToString();
			this._description = string.Concat(new string[]
			{
				this._description,
				" compressed/uncompressed size: ",
				Math.Round((double)(this.compressedSize / 1024f), 2).ToString("0.00"),
				"/",
				Math.Round((double)(this.uncompressedSize / 1024f), 2).ToString("0.00"),
				" Kb (",
				(100.0 - Math.Round((double)(this.compressedSize / this.uncompressedSize * 100f), 0)).ToString(),
				"%)"
			});
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x0003BD54 File Offset: 0x00039F54
		public override byte[] Serialize()
		{
			if (this.data != null && this.data.Length != 0)
			{
				return this.data;
			}
			int val = 0;
			int val2 = 0;
			foreach (DDS.MipMap mipMap in this.mipMaps)
			{
				val = Math.Max(val, mipMap.width);
				val2 = Math.Max(val2, mipMap.height);
			}
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			this.surfaceDescription.Serialize(binaryWriter);
			foreach (DDS.MipMap mipMap2 in this.mipMaps)
			{
				binaryWriter.Write(mipMap2.data);
			}
			byte[] array = new byte[binaryWriter.BaseStream.Length];
			binaryWriter.BaseStream.Position = 0L;
			binaryWriter.BaseStream.Read(array, 0, (int)binaryWriter.BaseStream.Length);
			binaryWriter.Close();
			memoryStream.Dispose();
			return array;
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000C24 RID: 3108 RVA: 0x00008B8F File Offset: 0x00006D8F
		public DDS.MipMap[] MipMaps
		{
			get
			{
				return this.mipMaps.ToArray();
			}
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x0003BE90 File Offset: 0x0003A090
		public override void SaveToFile(string fileName)
		{
			DBPFEntry dbpfentry = this;
			if (this.data == null)
			{
				base.IsUnpacked = false;
				dbpfentry = (base.Package as DBPF).GetEntry(base.ResKey);
			}
			FileStream fileStream = new FileStream(fileName, FileMode.Create);
			byte[] data = dbpfentry.GetData();
			fileStream.Write(data, 0, data.Length);
			fileStream.Close();
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x00008B9C File Offset: 0x00006D9C
		public override string ToString()
		{
			return "DDS | " + base.ToString();
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x00007B2B File Offset: 0x00005D2B
		public DDS ToDDS()
		{
			return this;
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x00008BAE File Offset: 0x00006DAE
		public void FromDDS(DDS source)
		{
			this.data = source.GetData();
			this.UnSerialize();
		}

		// Token: 0x040005B7 RID: 1463
		private List<DDS.MipMap> mipMaps = new List<DDS.MipMap>();

		// Token: 0x040005B8 RID: 1464
		private DDS.DDSurfaceDesction surfaceDescription;

		// Token: 0x040005B9 RID: 1465
		private int dataSize;

		// Token: 0x040005BA RID: 1466
		private int dataSizeRaw;

		// Token: 0x040005BB RID: 1467
		private string _description;

		// Token: 0x020001C6 RID: 454
		public class MipMap
		{
			// Token: 0x17000572 RID: 1394
			// (get) Token: 0x06001115 RID: 4373 RVA: 0x00046978 File Offset: 0x00044B78
			// (set) Token: 0x06001116 RID: 4374 RVA: 0x0000B99D File Offset: 0x00009B9D
			public unsafe byte[] AlphaData
			{
				get
				{
					if (this._alphaData == null)
					{
						Bitmap bitmap = ImageLoader.Load(this) as Bitmap;
						this._alphaData = new byte[Math.Max(16, this.width * this.height)];
						BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
						int num = 4;
						int num2 = 0;
						for (int i = 0; i < bitmapData.Height; i++)
						{
							byte* ptr = (byte*)((void*)bitmapData.Scan0) + i * bitmapData.Stride;
							for (int j = 0; j < bitmapData.Width; j++)
							{
								this._alphaData[i * this.width + j] = ptr[j * num + 3];
								num2 += 4;
							}
						}
						bitmap.UnlockBits(bitmapData);
					}
					return this._alphaData;
				}
				set
				{
					this._alphaData = value;
				}
			}

			// Token: 0x06001117 RID: 4375 RVA: 0x0000B9A6 File Offset: 0x00009BA6
			public MipMap(DDS dds, byte[] data, int width, int height)
			{
				this.dds = dds;
				this.data = data;
				this.width = width;
				this.height = height;
			}

			// Token: 0x17000573 RID: 1395
			// (get) Token: 0x06001118 RID: 4376 RVA: 0x0000B9CB File Offset: 0x00009BCB
			public DXTFormat Format
			{
				get
				{
					return this.dds.SurfaceDesc.ddpfPixelFormat.dwFourCC;
				}
			}

			// Token: 0x0400154A RID: 5450
			public DDS dds;

			// Token: 0x0400154B RID: 5451
			public byte[] data;

			// Token: 0x0400154C RID: 5452
			public byte[] _alphaData;

			// Token: 0x0400154D RID: 5453
			public int width;

			// Token: 0x0400154E RID: 5454
			public int height;
		}

		// Token: 0x020001C7 RID: 455
		public class DDSurfaceDesction
		{
			// Token: 0x06001119 RID: 4377 RVA: 0x00046A50 File Offset: 0x00044C50
			public DDSurfaceDesction()
			{
				this.identifier = 542327876;
				this.dwFlags = 659463;
				this.dwSize = 124;
				this.dwReserved1 = new int[11];
				this.ddpfPixelFormat = new DDS.DDSPixelFormat();
				this.ddsCaps = new DDS.DDSCaps();
			}

			// Token: 0x0600111A RID: 4378 RVA: 0x00046AA4 File Offset: 0x00044CA4
			public void Serialize(BinaryWriter writer)
			{
				writer.Write(this.identifier);
				writer.Write(this.dwSize);
				if ((this.ddpfPixelFormat.dwFlags & 64) == 64)
				{
					this.ddpfPixelFormat.dwFourCC = DXTFormat.UNKNOWN;
					this.dwFlags |= 8;
					this.dwPitchOrLinearSize = this.dwWidth * this.dwHeight * (this.ddpfPixelFormat.dwRGBBitCount / 8);
				}
				writer.Write(this.dwFlags);
				writer.Write(this.dwHeight);
				writer.Write(this.dwWidth);
				writer.Write(this.dwPitchOrLinearSize);
				writer.Write(this.dwDepth);
				writer.Write(this.dwMipMapCount);
				for (int i = 0; i < 11; i++)
				{
					writer.Write(this.dwReserved1[i]);
				}
				this.ddpfPixelFormat.Serialize(writer);
				this.ddsCaps.Serialize(writer);
				writer.Write(this.dwReserved2);
			}

			// Token: 0x0600111B RID: 4379 RVA: 0x00046BA0 File Offset: 0x00044DA0
			public void UnSerialize(BinaryReader binaryReader)
			{
				this.identifier = binaryReader.ReadInt32();
				this.dwSize = binaryReader.ReadInt32();
				this.dwFlags = binaryReader.ReadInt32();
				this.dwHeight = binaryReader.ReadInt32();
				this.dwWidth = binaryReader.ReadInt32();
				this.dwPitchOrLinearSize = binaryReader.ReadInt32();
				this.dwDepth = binaryReader.ReadInt32();
				this.dwMipMapCount = binaryReader.ReadInt32();
				for (int i = 0; i < 11; i++)
				{
					this.dwReserved1[i] = binaryReader.ReadInt32();
				}
				this.ddpfPixelFormat = new DDS.DDSPixelFormat();
				this.ddpfPixelFormat.UnSerialize(binaryReader);
				new DDS.DDSCaps().UnSerialize(binaryReader);
				this.dwReserved2 = binaryReader.ReadInt32();
			}

			// Token: 0x0400154F RID: 5455
			public int identifier;

			// Token: 0x04001550 RID: 5456
			public int dwSize;

			// Token: 0x04001551 RID: 5457
			public int dwFlags;

			// Token: 0x04001552 RID: 5458
			public int dwHeight;

			// Token: 0x04001553 RID: 5459
			public int dwWidth;

			// Token: 0x04001554 RID: 5460
			public int dwPitchOrLinearSize;

			// Token: 0x04001555 RID: 5461
			public int dwDepth;

			// Token: 0x04001556 RID: 5462
			public int dwMipMapCount;

			// Token: 0x04001557 RID: 5463
			public int[] dwReserved1;

			// Token: 0x04001558 RID: 5464
			public DDS.DDSPixelFormat ddpfPixelFormat;

			// Token: 0x04001559 RID: 5465
			public DDS.DDSCaps ddsCaps;

			// Token: 0x0400155A RID: 5466
			public int dwReserved2;

			// Token: 0x020001E6 RID: 486
			public enum FLAGS
			{
				// Token: 0x0400261C RID: 9756
				DDSD_CAPS = 1,
				// Token: 0x0400261D RID: 9757
				DDSD_DEPTH = 8388608,
				// Token: 0x0400261E RID: 9758
				DDSD_HEIGHT = 2,
				// Token: 0x0400261F RID: 9759
				DDSD_LINEARSIZE = 524288,
				// Token: 0x04002620 RID: 9760
				DDSD_LPSURFACE = 2048,
				// Token: 0x04002621 RID: 9761
				DDSD_MIPMAPCOUNT = 131072,
				// Token: 0x04002622 RID: 9762
				DDSD_PITCH = 8,
				// Token: 0x04002623 RID: 9763
				DDSD_PIXELFORMAT = 4096,
				// Token: 0x04002624 RID: 9764
				DDSD_WIDTH = 4,
				// Token: 0x04002625 RID: 9765
				DDSD_ZBUFFERBITDEPTH = 64
			}
		}

		// Token: 0x020001C8 RID: 456
		public class DDSPixelFormat
		{
			// Token: 0x0600111C RID: 4380 RVA: 0x0000B9E2 File Offset: 0x00009BE2
			public DDSPixelFormat()
			{
				this.dwSize = 32;
				this.dwRGBBitCount = 32;
			}

			// Token: 0x0600111D RID: 4381 RVA: 0x00046C58 File Offset: 0x00044E58
			public void Serialize(BinaryWriter writer)
			{
				writer.Write(this.dwSize);
				writer.Write(this.dwFlags);
				writer.Write((int)this.dwFourCC);
				writer.Write(this.dwRGBBitCount);
				writer.Write(this.dwRBitMask);
				writer.Write(this.dwGBitMask);
				writer.Write(this.dwBBitMask);
				writer.Write(this.dwRGBAlphaBitMask);
			}

			// Token: 0x0600111E RID: 4382 RVA: 0x00046CC8 File Offset: 0x00044EC8
			public void UnSerialize(BinaryReader binaryReader)
			{
				this.dwSize = binaryReader.ReadInt32();
				this.dwFlags = binaryReader.ReadInt32();
				uint num = binaryReader.ReadUInt32();
				this.dwFourCC = (this.originalwFourCC = (DXTFormat)num);
				this.dwRGBBitCount = binaryReader.ReadInt32();
				this.dwRBitMask = binaryReader.ReadUInt32();
				this.dwGBitMask = binaryReader.ReadUInt32();
				this.dwBBitMask = binaryReader.ReadUInt32();
				this.dwRGBAlphaBitMask = binaryReader.ReadUInt32();
			}

			// Token: 0x0400155B RID: 5467
			public int dwSize;

			// Token: 0x0400155C RID: 5468
			public int dwFlags;

			// Token: 0x0400155D RID: 5469
			public DXTFormat dwFourCC;

			// Token: 0x0400155E RID: 5470
			public DXTFormat originalwFourCC;

			// Token: 0x0400155F RID: 5471
			public int dwRGBBitCount;

			// Token: 0x04001560 RID: 5472
			public uint dwRBitMask;

			// Token: 0x04001561 RID: 5473
			public uint dwGBitMask;

			// Token: 0x04001562 RID: 5474
			public uint dwBBitMask;

			// Token: 0x04001563 RID: 5475
			public uint dwRGBAlphaBitMask;

			// Token: 0x020001E7 RID: 487
			public enum FLAGS
			{
				// Token: 0x04002627 RID: 9767
				DDPF_ALPHAPIXELS = 1,
				// Token: 0x04002628 RID: 9768
				DDPF_FOURCC = 4,
				// Token: 0x04002629 RID: 9769
				DDPF_RGB = 64
			}
		}

		// Token: 0x020001C9 RID: 457
		public class DDSCaps
		{
			// Token: 0x0600111F RID: 4383 RVA: 0x0000B9FA File Offset: 0x00009BFA
			public DDSCaps()
			{
				this.dwCaps1 = 4198408U;
				this.reserved = new uint[2];
			}

			// Token: 0x06001120 RID: 4384 RVA: 0x0000BA19 File Offset: 0x00009C19
			public void Serialize(BinaryWriter writer)
			{
				writer.Write(this.dwCaps1);
				writer.Write(this.dwCaps2);
				writer.Write(this.reserved[0]);
				writer.Write(this.reserved[0]);
			}

			// Token: 0x06001121 RID: 4385 RVA: 0x0000BA4F File Offset: 0x00009C4F
			public void UnSerialize(BinaryReader binaryReader)
			{
				this.dwCaps1 = binaryReader.ReadUInt32();
				this.dwCaps2 = binaryReader.ReadUInt32();
				this.reserved[0] = binaryReader.ReadUInt32();
				this.reserved[1] = binaryReader.ReadUInt32();
			}

			// Token: 0x04001564 RID: 5476
			public uint dwCaps1;

			// Token: 0x04001565 RID: 5477
			public uint dwCaps2;

			// Token: 0x04001566 RID: 5478
			public uint[] reserved;

			// Token: 0x020001E8 RID: 488
			public enum FLAGS : uint
			{
				// Token: 0x0400262B RID: 9771
				DDSCAPS_COMPLEX = 8U,
				// Token: 0x0400262C RID: 9772
				DDSCAPS_TEXTURE = 4096U,
				// Token: 0x0400262D RID: 9773
				DDSCAPS_MIPMAP = 4194304U
			}
		}
	}
}
