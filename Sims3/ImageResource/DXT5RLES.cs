using System;
using System.Collections.Generic;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.ImageResource
{
	// Token: 0x020000EE RID: 238
	public class DXT5RLES : DBPFEntry, TextureResource
	{
		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000C29 RID: 3113 RVA: 0x00008BC2 File Offset: 0x00006DC2
		// (set) Token: 0x06000C2A RID: 3114 RVA: 0x00008BCA File Offset: 0x00006DCA
		public uint Magic { get; set; }

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000C2B RID: 3115 RVA: 0x00008BD3 File Offset: 0x00006DD3
		// (set) Token: 0x06000C2C RID: 3116 RVA: 0x00008BDB File Offset: 0x00006DDB
		public uint Format { get; set; }

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000C2D RID: 3117 RVA: 0x00008BE4 File Offset: 0x00006DE4
		// (set) Token: 0x06000C2E RID: 3118 RVA: 0x00008BEC File Offset: 0x00006DEC
		public ushort Width { get; set; }

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000C2F RID: 3119 RVA: 0x00008BF5 File Offset: 0x00006DF5
		// (set) Token: 0x06000C30 RID: 3120 RVA: 0x00008BFD File Offset: 0x00006DFD
		public ushort Height { get; set; }

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000C31 RID: 3121 RVA: 0x00008C06 File Offset: 0x00006E06
		// (set) Token: 0x06000C32 RID: 3122 RVA: 0x00008C0E File Offset: 0x00006E0E
		public List<DXT5RLES.MipMap> MipMaps { get; set; }

		// Token: 0x06000C33 RID: 3123 RVA: 0x00008C17 File Offset: 0x00006E17
		public DXT5RLES(DBPFType typeId)
		{
			this.typeId = typeId;
			this.MipMaps = new List<DXT5RLES.MipMap>();
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x0003BEE4 File Offset: 0x0003A0E4
		public override void UnSerialize()
		{
			this.MipMaps.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.Magic = binaryReader.ReadUInt32();
			this.Format = binaryReader.ReadUInt32();
			this.Width = binaryReader.ReadUInt16();
			this.Height = binaryReader.ReadUInt16();
			uint num = binaryReader.ReadUInt32();
			ushort num2 = this.Width;
			ushort num3 = this.Height;
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num))
			{
				DXT5RLES.MipMap mipMap = new DXT5RLES.MipMap();
				mipMap.Width = (mipMap.Width = (int)num2);
				mipMap.Height = (mipMap.Height = (int)num3);
				mipMap.RLEOffset = (mipMap.RLEOffset = binaryReader.ReadInt32());
				mipMap.OffsetColor1 = (mipMap.OffsetColor1 = binaryReader.ReadInt32());
				mipMap.OffsetColor2 = (mipMap.OffsetColor2 = binaryReader.ReadInt32());
				mipMap.OffsetAlpha = (mipMap.OffsetAlpha = binaryReader.ReadInt32());
				mipMap.OffsetBitmask = (mipMap.OffsetBitmask = binaryReader.ReadInt32());
				mipMap.OffsetSpecular = (mipMap.OffsetSpecular = binaryReader.ReadInt32());
				long position = binaryReader.BaseStream.Position;
				binaryReader.BaseStream.Position = (long)mipMap.RLEOffset;
				int i = Math.Max(1, (int)(num2 * num3 / 16));
				BinaryReader binaryReader2 = new BinaryReader(new MemoryStream(this.data));
				BinaryReader binaryReader3 = new BinaryReader(new MemoryStream(this.data));
				BinaryReader binaryReader4 = new BinaryReader(new MemoryStream(this.data));
				BinaryReader binaryReader5 = new BinaryReader(new MemoryStream(this.data));
				BinaryReader binaryReader6 = new BinaryReader(new MemoryStream(this.data));
				binaryReader2.BaseStream.Position = (long)mipMap.OffsetColor1;
				binaryReader3.BaseStream.Position = (long)mipMap.OffsetColor2;
				binaryReader4.BaseStream.Position = (long)mipMap.OffsetAlpha;
				binaryReader5.BaseStream.Position = (long)mipMap.OffsetBitmask;
				binaryReader6.BaseStream.Position = (long)mipMap.OffsetSpecular;
				MemoryStream memoryStream2 = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream2);
				MemoryStream memoryStream3 = new MemoryStream();
				BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream3);
				while (i > 0)
				{
					ushort num5 = binaryReader.ReadUInt16();
					int num6 = num5 >> 2;
					i -= num6;
					if ((num5 & 2) == 2)
					{
						for (int j = 0; j < num6; j++)
						{
							byte[] buffer = binaryReader2.ReadBytes(4);
							byte[] buffer2 = binaryReader3.ReadBytes(4);
							binaryWriter.Write(20480);
							binaryWriter.Write(613566756U);
							binaryWriter.Write(37449);
							binaryWriter.Write(buffer);
							binaryWriter.Write(buffer2);
							for (int k = 0; k < 16; k++)
							{
								binaryWriter2.Write(byte.MaxValue);
							}
						}
					}
					else if ((num5 & 1) == 1)
					{
						for (int l = 0; l < num6; l++)
						{
							byte[] buffer3 = binaryReader2.ReadBytes(4);
							byte[] buffer4 = binaryReader3.ReadBytes(4);
							byte[] buffer5 = binaryReader4.ReadBytes(2);
							byte[] buffer6 = binaryReader5.ReadBytes(6);
							byte[] buffer7 = binaryReader6.ReadBytes(16);
							binaryWriter.Write(buffer5);
							binaryWriter.Write(buffer6);
							binaryWriter.Write(buffer3);
							binaryWriter.Write(buffer4);
							binaryWriter2.Write(buffer7);
						}
					}
					else
					{
						for (int m = 0; m < num6; m++)
						{
							binaryWriter.Write(1280);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							for (int n = 0; n < 16; n++)
							{
								binaryWriter2.Write(0);
							}
						}
					}
				}
				memoryStream2.Position = 0L;
				memoryStream3.Position = 0L;
				byte[] array = new byte[(int)(num2 * num3)];
				byte[] array2 = new byte[(int)(num2 * num3)];
				memoryStream2.Read(array, 0, array.Length);
				memoryStream3.Read(array2, 0, array2.Length);
				mipMap.Data = array;
				mipMap.AlphaData = array2;
				binaryWriter.Close();
				memoryStream2.Close();
				binaryWriter2.Close();
				memoryStream3.Close();
				this.MipMaps.Add(mipMap);
				binaryReader.BaseStream.Position = position;
				num2 /= 2;
				num3 /= 2;
				num4++;
			}
			memoryStream.Close();
			binaryReader.Close();
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x0003C374 File Offset: 0x0003A574
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

		// Token: 0x06000C37 RID: 3127 RVA: 0x0003C3B0 File Offset: 0x0003A5B0
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

		// Token: 0x06000C38 RID: 3128 RVA: 0x0003C3F4 File Offset: 0x0003A5F4
		public void ImportFromDDS(DDS dds)
		{
			this.typeId = 3129306232U;
			this.MipMaps = new List<DXT5RLES.MipMap>();
			MemoryStream memoryStream = new MemoryStream(dds.GetData());
			memoryStream.Position = 128L;
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream2);
			this.Width = (ushort)dds.Width;
			this.Height = (ushort)dds.Height;
			int num = 16;
			int num2 = 16 + 24 * dds.MipMaps.Length;
			for (int i = 0; i < dds.MipMaps.Length; i++)
			{
				this.MipMaps.Add(new DXT5RLES.MipMap());
			}
			binaryWriter.Write(894720068U);
			binaryWriter.Write(1397050450U);
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
								using (MemoryStream memoryStream8 = new MemoryStream())
								{
									BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream3);
									for (int j = 0; j < this.MipMaps.Count; j++)
									{
										this.MipMaps[j] = new DXT5RLES.MipMap
										{
											RLEOffset = (int)memoryStream3.Length,
											OffsetColor1 = (int)memoryStream4.Length,
											OffsetColor2 = (int)memoryStream5.Length,
											OffsetAlpha = (int)memoryStream6.Length,
											OffsetBitmask = (int)memoryStream7.Length,
											OffsetSpecular = (int)memoryStream8.Length
										};
										int num3 = Math.Max(4, dds.SurfaceDesc.dwWidth >> j);
										int num4 = Math.Max(4, dds.SurfaceDesc.dwHeight >> j);
										Math.Max(1, dds.SurfaceDesc.dwDepth >> j);
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
														for (int n = 0; n < 4; n++)
														{
															for (int num15 = 0; num15 < 4; num15++)
															{
																int num16 = num12 + num15;
																int num17 = num13 + n;
																byte value = alphaData[num17 * num3 + num16];
																memoryStream8.WriteByte(value);
															}
														}
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
									int num18 = (int)memoryStream2.Position;
									memoryStream2.Write(memoryStream3.ToArray(), 0, (int)memoryStream3.Length);
									memoryStream4.Position = 0L;
									int num19 = (int)memoryStream2.Position;
									memoryStream2.Write(memoryStream4.ToArray(), 0, (int)memoryStream4.Length);
									memoryStream5.Position = 0L;
									int num20 = (int)memoryStream2.Position;
									memoryStream2.Write(memoryStream5.ToArray(), 0, (int)memoryStream5.Length);
									memoryStream6.Position = 0L;
									int num21 = (int)memoryStream2.Position;
									memoryStream2.Write(memoryStream6.ToArray(), 0, (int)memoryStream6.Length);
									memoryStream7.Position = 0L;
									int num22 = (int)memoryStream2.Position;
									memoryStream2.Write(memoryStream7.ToArray(), 0, (int)memoryStream7.Length);
									memoryStream8.Position = 0L;
									int num23 = (int)memoryStream2.Position;
									memoryStream2.Write(memoryStream8.ToArray(), 0, (int)memoryStream8.Length);
									memoryStream2.Position = (long)num;
									for (int num24 = 0; num24 < this.MipMaps.Count; num24++)
									{
										DXT5RLES.MipMap mipMap = this.MipMaps[num24];
										binaryWriter.Write(mipMap.RLEOffset + num18);
										binaryWriter.Write(mipMap.OffsetColor1 + num19);
										binaryWriter.Write(mipMap.OffsetColor2 + num20);
										binaryWriter.Write(mipMap.OffsetAlpha + num21);
										binaryWriter.Write(mipMap.OffsetBitmask + num22);
										binaryWriter.Write(mipMap.OffsetSpecular + num23);
									}
								}
							}
						}
					}
				}
			}
			this.data = memoryStream2.ToArray();
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x0003CB2C File Offset: 0x0003AD2C
		public DDS ToDDS()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			DDS dds = new DDS(DXTFormat.DXT5);
			dds.SurfaceDesc.dwWidth = (int)this.Width;
			dds.SurfaceDesc.dwHeight = (int)this.Height;
			dds.SurfaceDesc.dwMipMapCount = 1;
			dds.SurfaceDesc.Serialize(binaryWriter);
			binaryWriter.Write(this.MipMaps[0].Data);
			memoryStream.Position = 0L;
			dds.SetData(memoryStream.ToArray());
			memoryStream.Dispose();
			return dds;
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x00008C31 File Offset: 0x00006E31
		public void FromDDS(DDS source)
		{
			this.ImportFromDDS(source);
			this.UnSerialize();
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x0000330C File Offset: 0x0000150C
		public override byte[] Serialize()
		{
			return this.data;
		}

		// Token: 0x020001CA RID: 458
		public class MipMap
		{
			// Token: 0x17000574 RID: 1396
			// (get) Token: 0x06001122 RID: 4386 RVA: 0x0000BA85 File Offset: 0x00009C85
			// (set) Token: 0x06001123 RID: 4387 RVA: 0x0000BA8D File Offset: 0x00009C8D
			public int Width { get; set; }

			// Token: 0x17000575 RID: 1397
			// (get) Token: 0x06001124 RID: 4388 RVA: 0x0000BA96 File Offset: 0x00009C96
			// (set) Token: 0x06001125 RID: 4389 RVA: 0x0000BA9E File Offset: 0x00009C9E
			public int Height { get; set; }

			// Token: 0x17000576 RID: 1398
			// (get) Token: 0x06001126 RID: 4390 RVA: 0x0000BAA7 File Offset: 0x00009CA7
			// (set) Token: 0x06001127 RID: 4391 RVA: 0x0000BAAF File Offset: 0x00009CAF
			public int OffsetColor1 { get; set; }

			// Token: 0x17000577 RID: 1399
			// (get) Token: 0x06001128 RID: 4392 RVA: 0x0000BAB8 File Offset: 0x00009CB8
			// (set) Token: 0x06001129 RID: 4393 RVA: 0x0000BAC0 File Offset: 0x00009CC0
			public int OffsetColor2 { get; set; }

			// Token: 0x17000578 RID: 1400
			// (get) Token: 0x0600112A RID: 4394 RVA: 0x0000BAC9 File Offset: 0x00009CC9
			// (set) Token: 0x0600112B RID: 4395 RVA: 0x0000BAD1 File Offset: 0x00009CD1
			public int OffsetAlpha { get; set; }

			// Token: 0x17000579 RID: 1401
			// (get) Token: 0x0600112C RID: 4396 RVA: 0x0000BADA File Offset: 0x00009CDA
			// (set) Token: 0x0600112D RID: 4397 RVA: 0x0000BAE2 File Offset: 0x00009CE2
			public int OffsetBitmask { get; set; }

			// Token: 0x1700057A RID: 1402
			// (get) Token: 0x0600112E RID: 4398 RVA: 0x0000BAEB File Offset: 0x00009CEB
			// (set) Token: 0x0600112F RID: 4399 RVA: 0x0000BAF3 File Offset: 0x00009CF3
			public int OffsetSpecular { get; set; }

			// Token: 0x1700057B RID: 1403
			// (get) Token: 0x06001130 RID: 4400 RVA: 0x0000BAFC File Offset: 0x00009CFC
			// (set) Token: 0x06001131 RID: 4401 RVA: 0x0000BB04 File Offset: 0x00009D04
			public int RLEOffset { get; set; }

			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x06001132 RID: 4402 RVA: 0x0000BB0D File Offset: 0x00009D0D
			// (set) Token: 0x06001133 RID: 4403 RVA: 0x0000BB15 File Offset: 0x00009D15
			public byte[] Data { get; set; }

			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x06001134 RID: 4404 RVA: 0x0000BB1E File Offset: 0x00009D1E
			// (set) Token: 0x06001135 RID: 4405 RVA: 0x0000BB26 File Offset: 0x00009D26
			public byte[] AlphaData { get; set; }
		}
	}
}
