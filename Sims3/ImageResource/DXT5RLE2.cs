using System;
using System.Collections.Generic;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.ImageResource
{
	// Token: 0x020000EF RID: 239
	public class DXT5RLE2 : DBPFEntry, TextureResource
	{
		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000C3C RID: 3132 RVA: 0x00008C40 File Offset: 0x00006E40
		// (set) Token: 0x06000C3D RID: 3133 RVA: 0x00008C48 File Offset: 0x00006E48
		public uint Magic { get; set; }

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x00008C51 File Offset: 0x00006E51
		// (set) Token: 0x06000C3F RID: 3135 RVA: 0x00008C59 File Offset: 0x00006E59
		public uint Format { get; set; }

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x00008C62 File Offset: 0x00006E62
		// (set) Token: 0x06000C41 RID: 3137 RVA: 0x00008C6A File Offset: 0x00006E6A
		public ushort Width { get; set; }

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x00008C73 File Offset: 0x00006E73
		// (set) Token: 0x06000C43 RID: 3139 RVA: 0x00008C7B File Offset: 0x00006E7B
		public ushort Height { get; set; }

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x00008C84 File Offset: 0x00006E84
		// (set) Token: 0x06000C45 RID: 3141 RVA: 0x00008C8C File Offset: 0x00006E8C
		public List<DXT5RLE2.MipMap> MipMaps { get; set; }

		// Token: 0x06000C46 RID: 3142 RVA: 0x00008C95 File Offset: 0x00006E95
		public DXT5RLE2(DBPFType typeId)
		{
			this.typeId = typeId;
			this.MipMaps = new List<DXT5RLE2.MipMap>();
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x0003CBC4 File Offset: 0x0003ADC4
		public void ImportFromDDS(DDS dds)
		{
			this.typeId = 877907861U;
			this.MipMaps = new List<DXT5RLE2.MipMap>();
			MemoryStream memoryStream = new MemoryStream(dds.GetData());
			memoryStream.Position = 128L;
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream2);
			this.Width = (ushort)dds.Width;
			this.Height = (ushort)dds.Height;
			int num = 16;
			int num2 = 16 + 20 * dds.MipMaps.Length;
			for (int i = 0; i < dds.MipMaps.Length; i++)
			{
				this.MipMaps.Add(new DXT5RLE2.MipMap());
			}
			binaryWriter.Write(894720068U);
			binaryWriter.Write(843402322U);
			binaryWriter.Write(this.Width);
			binaryWriter.Write(this.Height);
			binaryWriter.Write((ushort)this.MipMaps.Count);
			binaryWriter.Write(0);
			using (MemoryStream memoryStream3 = new MemoryStream())
			{
				using (MemoryStream memoryStream4 = new MemoryStream())
				{
					using (MemoryStream memoryStream5 = new MemoryStream())
					{
						using (MemoryStream memoryStream6 = new MemoryStream())
						{
							using (MemoryStream memoryStream7 = new MemoryStream())
							{
								BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream3);
								for (int j = 0; j < this.MipMaps.Count; j++)
								{
									this.MipMaps[j] = new DXT5RLE2.MipMap
									{
										RLEOffset = (int)memoryStream3.Length,
										OffsetColor1 = (int)memoryStream4.Length,
										OffsetColor2 = (int)memoryStream5.Length,
										OffsetAlpha = (int)memoryStream6.Length,
										OffsetBitmask = (int)memoryStream7.Length
									};
									int num3 = Math.Max(4, dds.SurfaceDesc.dwWidth >> j);
									int num4 = Math.Max(4, dds.SurfaceDesc.dwHeight >> j);
									int num5 = Math.Max(1, (num3 + 3) / 4) * Math.Max(1, (num4 + 3) / 4) * 16;
									byte[] buffer = this.MipMaps[j].Data = binaryReader.ReadBytes(num5);
									byte[] alphaData = dds.MipMaps[j].AlphaData;
									int num6 = 0;
									int num7 = 0;
									int k = 0;
									while (k < num5)
									{
										ushort num8 = 0;
										while (num8 < 16383 && k < num5 && this.TestAlphaAllZero(num6, num7, alphaData, num3))
										{
											num8 += 1;
											k += 16;
											num6 += 4;
											if (num6 >= num3)
											{
												num7 += 4;
												num6 = 0;
											}
										}
										if (num8 > 0)
										{
											num8 = (ushort)(num8 << 2);
											num8 |= 0;
											binaryWriter2.Write(num8);
										}
										else
										{
											int num9 = k;
											ushort num10 = 0;
											while (num10 < 16383 && k < num5 && this.TestAlphaAllOne(num6, num7, alphaData, num3))
											{
												num10 += 1;
												k += 16;
												num6 += 4;
												if (num6 >= num3)
												{
													num7 += 4;
													num6 = 0;
												}
											}
											if (num10 > 0)
											{
												int l = 0;
												while (l < (int)num10)
												{
													memoryStream4.Write(buffer, num9 + 8, 4);
													memoryStream5.Write(buffer, num9 + 12, 4);
													l++;
													num9 += 16;
												}
												num10 = (ushort)(num10 << 2);
												num10 |= 2;
												binaryWriter2.Write(num10);
											}
											else
											{
												int num11 = k;
												int num12 = num6;
												int num13 = num7;
												ushort num14 = 0;
												while (num14 < 16383 && k < num5 && !this.TestAlphaAllZero(num6, num7, alphaData, num3) && !this.TestAlphaAllOne(num6, num7, alphaData, num3))
												{
													num14 += 1;
													k += 16;
													num6 += 4;
													if (num6 >= num3)
													{
														num7 += 4;
														num6 = 0;
													}
												}
												if (num14 <= 0)
												{
													throw new NotImplementedException();
												}
												int m = 0;
												while (m < (int)num14)
												{
													memoryStream6.Write(buffer, num11, 2);
													memoryStream7.Write(buffer, num11 + 2, 6);
													memoryStream4.Write(buffer, num11 + 8, 4);
													memoryStream5.Write(buffer, num11 + 12, 4);
													num12 += 4;
													if (num12 >= num3)
													{
														num13 += 4;
														num12 = 0;
													}
													m++;
													num11 += 16;
												}
												num14 = (ushort)(num14 << 2);
												num14 |= 1;
												binaryWriter2.Write(num14);
											}
										}
									}
								}
								memoryStream2.Position = (long)num2;
								memoryStream3.Position = 0L;
								int num15 = (int)memoryStream2.Position;
								memoryStream2.Write(memoryStream3.ToArray(), 0, (int)memoryStream3.Length);
								memoryStream4.Position = 0L;
								int num16 = (int)memoryStream2.Position;
								memoryStream2.Write(memoryStream4.ToArray(), 0, (int)memoryStream4.Length);
								memoryStream5.Position = 0L;
								int num17 = (int)memoryStream2.Position;
								memoryStream2.Write(memoryStream5.ToArray(), 0, (int)memoryStream5.Length);
								memoryStream6.Position = 0L;
								int num18 = (int)memoryStream2.Position;
								memoryStream2.Write(memoryStream6.ToArray(), 0, (int)memoryStream6.Length);
								memoryStream7.Position = 0L;
								int num19 = (int)memoryStream2.Position;
								memoryStream2.Write(memoryStream7.ToArray(), 0, (int)memoryStream7.Length);
								memoryStream2.Position = (long)num;
								for (int n = 0; n < this.MipMaps.Count; n++)
								{
									DXT5RLE2.MipMap mipMap = this.MipMaps[n];
									binaryWriter.Write(mipMap.RLEOffset + num15);
									binaryWriter.Write(mipMap.OffsetColor1 + num16);
									binaryWriter.Write(mipMap.OffsetColor2 + num17);
									binaryWriter.Write(mipMap.OffsetAlpha + num18);
									binaryWriter.Write(mipMap.OffsetBitmask + num19);
								}
							}
						}
					}
				}
			}
			this.data = memoryStream2.ToArray();
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x0003C374 File Offset: 0x0003A574
		private bool TestAlphaAllZero(int xOffset, int yOffset, byte[] alphaData, int mipWidth)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					int num = xOffset + j;
					int num2 = yOffset + i;
					if (alphaData[num2 * mipWidth + num] != 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x0003C3B0 File Offset: 0x0003A5B0
		private bool TestAlphaAllOne(int xOffset, int yOffset, byte[] alphaData, int mipWidth)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					int num = xOffset + j;
					int num2 = yOffset + i;
					if (alphaData[num2 * mipWidth + num] != 255)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x0003D220 File Offset: 0x0003B420
		public override void UnSerialize()
		{
			this.MipMaps.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.Magic = binaryReader.ReadUInt32();
			this.Format = binaryReader.ReadUInt32();
			this.Width = binaryReader.ReadUInt16();
			this.Height = binaryReader.ReadUInt16();
			ushort num = binaryReader.ReadUInt16();
			ushort num2 = this.Width;
			ushort num3 = this.Height;
			if (binaryReader.ReadUInt16() != 0)
			{
				throw new Exception("Invalid RLE2 format");
			}
			for (int i = 0; i < (int)num; i++)
			{
				DXT5RLE2.MipMap mipMap = new DXT5RLE2.MipMap();
				mipMap.Width = (int)num2;
				mipMap.Height = (int)num3;
				mipMap.RLEOffset = binaryReader.ReadInt32();
				mipMap.OffsetColor1 = binaryReader.ReadInt32();
				mipMap.OffsetColor2 = binaryReader.ReadInt32();
				mipMap.OffsetAlpha = binaryReader.ReadInt32();
				mipMap.OffsetBitmask = binaryReader.ReadInt32();
				long position = binaryReader.BaseStream.Position;
				binaryReader.BaseStream.Position = (long)mipMap.RLEOffset;
				int j = Math.Max(1, (int)(num2 * num3 / 16));
				BinaryReader binaryReader2 = new BinaryReader(new MemoryStream(this.data));
				BinaryReader binaryReader3 = new BinaryReader(new MemoryStream(this.data));
				BinaryReader binaryReader4 = new BinaryReader(new MemoryStream(this.data));
				BinaryReader binaryReader5 = new BinaryReader(new MemoryStream(this.data));
				binaryReader2.BaseStream.Position = (long)mipMap.OffsetColor1;
				binaryReader3.BaseStream.Position = (long)mipMap.OffsetColor2;
				binaryReader4.BaseStream.Position = (long)mipMap.OffsetAlpha;
				binaryReader5.BaseStream.Position = (long)mipMap.OffsetBitmask;
				MemoryStream memoryStream2 = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream2);
				while (j > 0)
				{
					ushort num4 = binaryReader.ReadUInt16();
					int num5 = num4 >> 2;
					j -= num5;
					if ((num4 & 2) == 2)
					{
						for (int k = 0; k < num5; k++)
						{
							byte[] buffer = binaryReader2.ReadBytes(4);
							byte[] buffer2 = binaryReader3.ReadBytes(4);
							binaryWriter.Write(1280);
							binaryWriter.Write(ushort.MaxValue);
							binaryWriter.Write(ushort.MaxValue);
							binaryWriter.Write(ushort.MaxValue);
							binaryWriter.Write(buffer);
							binaryWriter.Write(buffer2);
						}
					}
					else if ((num4 & 1) == 1)
					{
						for (int l = 0; l < num5; l++)
						{
							byte[] buffer3 = binaryReader2.ReadBytes(4);
							byte[] buffer4 = binaryReader3.ReadBytes(4);
							byte[] buffer5 = binaryReader4.ReadBytes(2);
							byte[] buffer6 = binaryReader5.ReadBytes(6);
							binaryWriter.Write(buffer5);
							binaryWriter.Write(buffer6);
							binaryWriter.Write(buffer3);
							binaryWriter.Write(buffer4);
						}
					}
					else
					{
						for (int m = 0; m < num5; m++)
						{
							binaryWriter.Write(5);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
						}
					}
				}
				memoryStream2.Position = 0L;
				byte[] array = new byte[Math.Max(1, (int)(num2 / 4)) * Math.Max(1, (int)(num3 / 4)) * 16];
				memoryStream2.Read(array, 0, array.Length);
				mipMap.Data = array;
				this.MipMaps.Add(mipMap);
				binaryWriter.Close();
				memoryStream2.Close();
				binaryReader.BaseStream.Position = position;
				num2 /= 2;
				num3 /= 2;
			}
			memoryStream.Close();
			binaryReader.Close();
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0000330C File Offset: 0x0000150C
		public override byte[] Serialize()
		{
			return this.data;
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x0003D5AC File Offset: 0x0003B7AC
		public DDS ToDDS()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			DDS dds = new DDS(DXTFormat.DXT5);
			dds.SurfaceDesc.dwWidth = (int)this.Width;
			dds.SurfaceDesc.dwHeight = (int)this.Height;
			dds.SurfaceDesc.dwPitchOrLinearSize = this.MipMaps[0].Data.Length;
			int num = 0;
			foreach (DXT5RLE2.MipMap mipMap in this.MipMaps)
			{
				if (mipMap.Width > 0 && mipMap.Height > 0)
				{
					num++;
				}
			}
			num = Math.Min(num, 9);
			dds.SurfaceDesc.dwMipMapCount = num;
			dds.SurfaceDesc.Serialize(binaryWriter);
			for (int i = 0; i < num; i++)
			{
				binaryWriter.Write(this.MipMaps[i].Data);
			}
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Position = 0L;
			memoryStream.Read(array, 0, (int)binaryWriter.BaseStream.Length);
			dds.SetData(array);
			memoryStream.Dispose();
			return dds;
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x00008CAF File Offset: 0x00006EAF
		public void FromDDS(DDS source)
		{
			this.ImportFromDDS(source);
			this.UnSerialize();
		}

		// Token: 0x020001CB RID: 459
		public class MipMap
		{
			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x06001137 RID: 4407 RVA: 0x0000BB2F File Offset: 0x00009D2F
			// (set) Token: 0x06001138 RID: 4408 RVA: 0x0000BB37 File Offset: 0x00009D37
			public int Width { get; set; }

			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x06001139 RID: 4409 RVA: 0x0000BB40 File Offset: 0x00009D40
			// (set) Token: 0x0600113A RID: 4410 RVA: 0x0000BB48 File Offset: 0x00009D48
			public int Height { get; set; }

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x0600113B RID: 4411 RVA: 0x0000BB51 File Offset: 0x00009D51
			// (set) Token: 0x0600113C RID: 4412 RVA: 0x0000BB59 File Offset: 0x00009D59
			public int OffsetColor1 { get; set; }

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x0600113D RID: 4413 RVA: 0x0000BB62 File Offset: 0x00009D62
			// (set) Token: 0x0600113E RID: 4414 RVA: 0x0000BB6A File Offset: 0x00009D6A
			public int OffsetColor2 { get; set; }

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x0600113F RID: 4415 RVA: 0x0000BB73 File Offset: 0x00009D73
			// (set) Token: 0x06001140 RID: 4416 RVA: 0x0000BB7B File Offset: 0x00009D7B
			public int OffsetAlpha { get; set; }

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x06001141 RID: 4417 RVA: 0x0000BB84 File Offset: 0x00009D84
			// (set) Token: 0x06001142 RID: 4418 RVA: 0x0000BB8C File Offset: 0x00009D8C
			public int OffsetBitmask { get; set; }

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x06001143 RID: 4419 RVA: 0x0000BB95 File Offset: 0x00009D95
			// (set) Token: 0x06001144 RID: 4420 RVA: 0x0000BB9D File Offset: 0x00009D9D
			public int RLEOffset { get; set; }

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x06001145 RID: 4421 RVA: 0x0000BBA6 File Offset: 0x00009DA6
			// (set) Token: 0x06001146 RID: 4422 RVA: 0x0000BBAE File Offset: 0x00009DAE
			public byte[] Data { get; set; }
		}
	}
}
