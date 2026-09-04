using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Package.Squish;
using Sims3WorkshopSDK;

namespace Package.ImageResource
{
	// Token: 0x020000E7 RID: 231
	public class DXT5LRLE : DBPFEntry, TextureResource
	{
		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000BDD RID: 3037 RVA: 0x00008988 File Offset: 0x00006B88
		// (set) Token: 0x06000BDE RID: 3038 RVA: 0x00008990 File Offset: 0x00006B90
		public uint Magic { get; set; }

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000BDF RID: 3039 RVA: 0x00008999 File Offset: 0x00006B99
		// (set) Token: 0x06000BE0 RID: 3040 RVA: 0x000089A1 File Offset: 0x00006BA1
		public DXT5LRLE.LRLEFormat Format { get; set; }

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x000089AA File Offset: 0x00006BAA
		// (set) Token: 0x06000BE2 RID: 3042 RVA: 0x000089B2 File Offset: 0x00006BB2
		public ushort Width { get; set; }

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000BE3 RID: 3043 RVA: 0x000089BB File Offset: 0x00006BBB
		// (set) Token: 0x06000BE4 RID: 3044 RVA: 0x000089C3 File Offset: 0x00006BC3
		public ushort Height { get; set; }

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x000089CC File Offset: 0x00006BCC
		// (set) Token: 0x06000BE6 RID: 3046 RVA: 0x000089D4 File Offset: 0x00006BD4
		public int[] Palette { get; private set; }

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x000089DD File Offset: 0x00006BDD
		public uint MipMapCount
		{
			get
			{
				return this.mipCount;
			}
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x000032FA File Offset: 0x000014FA
		public DXT5LRLE(DBPFType typeId)
		{
			this.typeId = typeId;
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x0003A670 File Offset: 0x00038870
		public override void UnSerialize()
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			this.Magic = binaryReader.ReadUInt32();
			this.Format = (DXT5LRLE.LRLEFormat)binaryReader.ReadUInt32();
			if (this.Magic != 1162629708U)
			{
				throw new Exception("Not in LRLE format");
			}
			this.Width = binaryReader.ReadUInt16();
			this.Height = binaryReader.ReadUInt16();
			this.mipCount = binaryReader.ReadUInt32();
			Stream baseStream = binaryReader.BaseStream;
			this.commandOffsets = new uint[this.mipCount];
			int num = 0;
			while ((long)num < (long)((ulong)this.mipCount))
			{
				this.commandOffsets[num] = binaryReader.ReadUInt32();
				num++;
			}
			if (this.Format == DXT5LRLE.LRLEFormat.V002)
			{
				this.Palette = new int[binaryReader.ReadInt32()];
				for (int i = 0; i < this.Palette.Length; i++)
				{
					this.Palette[i] = binaryReader.ReadInt32();
				}
			}
			this.mipData = new byte[baseStream.Length - baseStream.Position];
			baseStream.Read(this.mipData, 0, this.mipData.Length);
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x0003A78C File Offset: 0x0003898C
		public DXT5LRLE.Mip[] ReadMips()
		{
			DXT5LRLE.Mip[] array = new DXT5LRLE.Mip[this.mipCount];
			int num = 0;
			while ((long)num < (long)((ulong)this.mipCount))
			{
				long num2 = (long)((ulong)this.commandOffsets[num]);
				long num3 = (long)(((long)num == (long)((ulong)(this.mipCount - 1U))) ? ((ulong)((uint)((long)this.mipData.Length))) : ((ulong)this.commandOffsets[num + 1]));
				byte[] array2 = new byte[num3 - num2];
				Array.Copy(this.mipData, num2, array2, 0L, (long)array2.Length);
				array[num] = new DXT5LRLE.Mip(array2, num, this.Format, this.Palette, num2, num3, this.Width >> num, this.Height >> num);
				num++;
			}
			return array;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0003A848 File Offset: 0x00038A48
		internal static ulong ReadPackedInt(BinaryReader s)
		{
			ulong num = 0UL;
			int num2 = 0;
			byte b;
			do
			{
				b = s.ReadByte();
				num |= (ulong)((ulong)(b & 127) << num2);
				num2 += 7;
			}
			while ((b & 128) != 0);
			return num;
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x000089E5 File Offset: 0x00006BE5
		internal static ulong ReadPackedInt(BinaryReader s, byte start)
		{
			if ((start & 128) != 0)
			{
				return (ulong)(start & 127) | DXT5LRLE.ReadPackedInt(s) << 7;
			}
			return (ulong)start;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x0003A884 File Offset: 0x00038A84
		internal static int BlockIndexToScanlineIndex(int block_index, int width, int block_row_size, int width_log2)
		{
			int num = block_index & block_row_size - 1;
			int num2 = block_index >> width_log2 >> 1;
			int num3 = num >> 4;
			int num4 = block_index >> 2 & 3;
			int num5 = block_index & 3;
			int num6 = (num2 << 2) + num4;
			int num7 = (num3 << 2) + num5;
			return num6 * width + num7;
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x0003A8C0 File Offset: 0x00038AC0
		internal static int Log2(int n)
		{
			int num = 0;
			while (n > 0)
			{
				n >>= 1;
				num++;
			}
			return num;
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x00008A01 File Offset: 0x00006C01
		public void ImportFromDDS(DDS dds)
		{
			throw new Exception("Import DDS to LRLE not supported");
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x0003A8E0 File Offset: 0x00038AE0
		public DDS ToDDS()
		{
			DXT5LRLE.Mip mip = this.ReadMips()[0];
			byte[] pixels = mip.GetPixels();
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			DDS dds = new DDS(DXTFormat.DXT5);
			dds.SurfaceDesc.dwWidth = (int)this.Width;
			dds.SurfaceDesc.dwHeight = (int)this.Height;
			dds.SurfaceDesc.dwMipMapCount = 1;
			dds.SurfaceDesc.Serialize(binaryWriter);
			dds.SurfaceDesc.ddpfPixelFormat.dwFourCC = DXTFormat.UNKNOWN;
			dds.SurfaceDesc.ddpfPixelFormat.dwFlags = 65;
			dds.SurfaceDesc.ddpfPixelFormat.dwRGBBitCount = 32;
			dds.SurfaceDesc.ddpfPixelFormat.dwRGBAlphaBitMask = 4278190080U;
			dds.SurfaceDesc.ddpfPixelFormat.dwRBitMask = 16711680U;
			dds.SurfaceDesc.ddpfPixelFormat.dwGBitMask = 65280U;
			dds.SurfaceDesc.ddpfPixelFormat.dwBBitMask = 255U;
			byte[] buffer = DdsSquish.CompressImage(new Bitmap(ImageLoader.Load(new DDS.MipMap(dds, pixels, mip.Width, mip.Height))), 4);
			binaryWriter.Write(buffer);
			memoryStream.Position = 0L;
			dds.SetData(memoryStream.ToArray());
			memoryStream.Dispose();
			return dds;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x00008A0D File Offset: 0x00006C0D
		public void FromDDS(DDS source)
		{
			this.ImportFromDDS(source);
			this.UnSerialize();
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0000330C File Offset: 0x0000150C
		public override byte[] Serialize()
		{
			return this.data;
		}

		// Token: 0x040005A4 RID: 1444
		private byte[] mipData;

		// Token: 0x040005A5 RID: 1445
		private uint mipCount;

		// Token: 0x040005A6 RID: 1446
		private uint[] commandOffsets;

		// Token: 0x020001C3 RID: 451
		public enum LRLEFormat
		{
			// Token: 0x04001533 RID: 5427
			Default,
			// Token: 0x04001534 RID: 5428
			V002 = 842018902
		}

		// Token: 0x020001C4 RID: 452
		public class MipMap
		{
			// Token: 0x17000562 RID: 1378
			// (get) Token: 0x060010F4 RID: 4340 RVA: 0x0000B8BC File Offset: 0x00009ABC
			// (set) Token: 0x060010F5 RID: 4341 RVA: 0x0000B8C4 File Offset: 0x00009AC4
			public int Width { get; set; }

			// Token: 0x17000563 RID: 1379
			// (get) Token: 0x060010F6 RID: 4342 RVA: 0x0000B8CD File Offset: 0x00009ACD
			// (set) Token: 0x060010F7 RID: 4343 RVA: 0x0000B8D5 File Offset: 0x00009AD5
			public int Height { get; set; }

			// Token: 0x17000564 RID: 1380
			// (get) Token: 0x060010F8 RID: 4344 RVA: 0x0000B8DE File Offset: 0x00009ADE
			// (set) Token: 0x060010F9 RID: 4345 RVA: 0x0000B8E6 File Offset: 0x00009AE6
			public int OffsetColor1 { get; set; }

			// Token: 0x17000565 RID: 1381
			// (get) Token: 0x060010FA RID: 4346 RVA: 0x0000B8EF File Offset: 0x00009AEF
			// (set) Token: 0x060010FB RID: 4347 RVA: 0x0000B8F7 File Offset: 0x00009AF7
			public int OffsetColor2 { get; set; }

			// Token: 0x17000566 RID: 1382
			// (get) Token: 0x060010FC RID: 4348 RVA: 0x0000B900 File Offset: 0x00009B00
			// (set) Token: 0x060010FD RID: 4349 RVA: 0x0000B908 File Offset: 0x00009B08
			public int OffsetAlpha { get; set; }

			// Token: 0x17000567 RID: 1383
			// (get) Token: 0x060010FE RID: 4350 RVA: 0x0000B911 File Offset: 0x00009B11
			// (set) Token: 0x060010FF RID: 4351 RVA: 0x0000B919 File Offset: 0x00009B19
			public int OffsetBitmask { get; set; }

			// Token: 0x17000568 RID: 1384
			// (get) Token: 0x06001100 RID: 4352 RVA: 0x0000B922 File Offset: 0x00009B22
			// (set) Token: 0x06001101 RID: 4353 RVA: 0x0000B92A File Offset: 0x00009B2A
			public int OffsetSpecular { get; set; }

			// Token: 0x17000569 RID: 1385
			// (get) Token: 0x06001102 RID: 4354 RVA: 0x0000B933 File Offset: 0x00009B33
			// (set) Token: 0x06001103 RID: 4355 RVA: 0x0000B93B File Offset: 0x00009B3B
			public int RLEOffset { get; set; }

			// Token: 0x1700056A RID: 1386
			// (get) Token: 0x06001104 RID: 4356 RVA: 0x0000B944 File Offset: 0x00009B44
			// (set) Token: 0x06001105 RID: 4357 RVA: 0x0000B94C File Offset: 0x00009B4C
			public byte[] Data { get; set; }

			// Token: 0x1700056B RID: 1387
			// (get) Token: 0x06001106 RID: 4358 RVA: 0x0000B955 File Offset: 0x00009B55
			// (set) Token: 0x06001107 RID: 4359 RVA: 0x0000B95D File Offset: 0x00009B5D
			public byte[] AlphaData { get; set; }
		}

		// Token: 0x020001C5 RID: 453
		public class Mip
		{
			// Token: 0x1700056C RID: 1388
			// (get) Token: 0x06001109 RID: 4361 RVA: 0x0000B966 File Offset: 0x00009B66
			public int Width { get; }

			// Token: 0x1700056D RID: 1389
			// (get) Token: 0x0600110A RID: 4362 RVA: 0x0000B96E File Offset: 0x00009B6E
			public int Height { get; }

			// Token: 0x1700056E RID: 1390
			// (get) Token: 0x0600110B RID: 4363 RVA: 0x0000B976 File Offset: 0x00009B76
			public long Start { get; }

			// Token: 0x1700056F RID: 1391
			// (get) Token: 0x0600110C RID: 4364 RVA: 0x0000B97E File Offset: 0x00009B7E
			public long End { get; }

			// Token: 0x17000570 RID: 1392
			// (get) Token: 0x0600110D RID: 4365 RVA: 0x0000B986 File Offset: 0x00009B86
			public int Index { get; }

			// Token: 0x17000571 RID: 1393
			// (get) Token: 0x0600110E RID: 4366 RVA: 0x0000B98E File Offset: 0x00009B8E
			public long Length
			{
				get
				{
					return this.End - this.Start;
				}
			}

			// Token: 0x0600110F RID: 4367 RVA: 0x000464D4 File Offset: 0x000446D4
			private unsafe void WritePixel(int* pixels, int color)
			{
				int num = this.pixelsRead;
				this.pixelsRead = num + 1;
				pixels[DXT5LRLE.BlockIndexToScanlineIndex(num, this.Width, this.blockRowSize, this.widthLog2)] = color;
			}

			// Token: 0x06001110 RID: 4368 RVA: 0x00046510 File Offset: 0x00044710
			public Mip(byte[] mipBytes, int index, DXT5LRLE.LRLEFormat version, int[] palette, long start, long end, int width, int height)
			{
				this.mipBytes = mipBytes;
				this.version = version;
				this.palette = palette;
				this.Width = width;
				this.Height = height;
				this.Index = index;
				this.Start = start;
				this.End = end;
				this.blockRowSize = this.Width << 2;
				this.widthLog2 = DXT5LRLE.Log2(this.Width);
			}

			// Token: 0x06001111 RID: 4369 RVA: 0x00046580 File Offset: 0x00044780
			public byte[] GetPixels()
			{
				byte[] array = new byte[this.Width * this.Height << 2];
				GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
				this.Read(gchandle.AddrOfPinnedObject());
				gchandle.Free();
				return array;
			}

			// Token: 0x06001112 RID: 4370 RVA: 0x000465C0 File Offset: 0x000447C0
			public unsafe void Read(IntPtr pixels)
			{
				using (BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.mipBytes)))
				{
					DXT5LRLE.LRLEFormat lrleformat = this.version;
					if (lrleformat != DXT5LRLE.LRLEFormat.Default)
					{
						if (lrleformat != DXT5LRLE.LRLEFormat.V002)
						{
							throw new NotSupportedException(string.Format("Unsuported version: {0}", this.version));
						}
						this.ReadV002(binaryReader, this.palette, (int*)pixels.ToPointer());
					}
					else
					{
						this.Read0000(binaryReader, (int*)pixels.ToPointer());
					}
				}
			}

			// Token: 0x06001113 RID: 4371 RVA: 0x0004664C File Offset: 0x0004484C
			private unsafe void Read0000(BinaryReader s, int* pixels)
			{
				while (s.BaseStream.Position < s.BaseStream.Length)
				{
					byte b = s.ReadByte();
					switch (b & 3)
					{
					case 0:
						this.pixelsRead += (int)(DXT5LRLE.ReadPackedInt(s, b) >> 2);
						break;
					case 1:
					{
						int num = b >> 2;
						for (int i = 0; i < num; i++)
						{
							this.WritePixel(pixels, s.ReadInt32());
						}
						break;
					}
					case 2:
					{
						int num2 = (int)(DXT5LRLE.ReadPackedInt(s, b) >> 2);
						int color = s.ReadInt32();
						for (int j = 0; j < num2; j++)
						{
							this.WritePixel(pixels, color);
						}
						break;
					}
					case 3:
					{
						int num3 = b >> 2;
						byte[] array = new byte[num3 << 2];
						int k = 0;
						while (k < array.Length)
						{
							ulong num4 = DXT5LRLE.ReadPackedInt(s);
							if ((num4 & 1UL) != 0UL)
							{
								int num5 = (int)(num4 >> 1);
								s.Read(array, k, num5);
								k += num5;
							}
							else if ((num4 & 2UL) != 0UL)
							{
								int num6 = (int)(num4 >> 2);
								byte b2 = s.ReadByte();
								for (int l = 0; l < num6; l++)
								{
									array[k++] = b2;
								}
							}
							else
							{
								int num7 = (int)(num4 >> 2);
								k += num7;
							}
						}
						int m = 0;
						int num8 = num3;
						int num9 = num8 + num3;
						int num10 = num9 + num3;
						while (m < num3)
						{
							this.WritePixel(pixels, BitConverter.ToInt32(new byte[]
							{
								array[m++],
								array[num8++],
								array[num9++],
								array[num10++]
							}, 0));
						}
						break;
					}
					default:
						throw new Exception(string.Format("Unknown comand {0}", (int)(b & 3)));
					}
				}
			}

			// Token: 0x06001114 RID: 4372 RVA: 0x00046830 File Offset: 0x00044A30
			private unsafe void ReadV002(BinaryReader s, int[] palette, int* pixels)
			{
				while (s.BaseStream.Position < s.BaseStream.Length)
				{
					ulong num = DXT5LRLE.ReadPackedInt(s);
					ulong num2 = num & 1UL;
					if (num2 != 0UL)
					{
						if (num2 != 1UL)
						{
							throw new Exception(string.Format("Unknown command {0}", num2));
						}
						int num3 = (int)(num >> 2);
						int num4 = ((int)num & 3) >> 1;
						for (int i = 0; i < num3; i++)
						{
							int color;
							if (num4 != 0)
							{
								if (num4 != 1)
								{
									throw new Exception(string.Format("Unknown flags {0}", num4));
								}
								color = s.ReadInt32();
							}
							else
							{
								color = palette[(int)DXT5LRLE.ReadPackedInt(s)];
							}
							this.WritePixel(pixels, color);
						}
					}
					else
					{
						int num5 = (int)(num >> 3);
						int num6 = ((int)num & 7) >> 1;
						int color2;
						switch (num6)
						{
						case 1:
							color2 = palette[(int)s.ReadByte()];
							break;
						case 2:
							color2 = palette[(int)s.ReadUInt16()];
							break;
						case 3:
							color2 = s.ReadInt32();
							break;
						default:
							throw new Exception(string.Format("Unknown flags {0}", num6));
						}
						for (int j = 0; j < num5; j++)
						{
							this.WritePixel(pixels, color2);
						}
					}
				}
			}

			// Token: 0x0400153F RID: 5439
			private readonly byte[] mipBytes;

			// Token: 0x04001540 RID: 5440
			private readonly DXT5LRLE.LRLEFormat version;

			// Token: 0x04001541 RID: 5441
			private readonly int[] palette;

			// Token: 0x04001542 RID: 5442
			private readonly int blockRowSize;

			// Token: 0x04001543 RID: 5443
			private readonly int widthLog2;

			// Token: 0x04001544 RID: 5444
			private int pixelsRead;
		}
	}
}
