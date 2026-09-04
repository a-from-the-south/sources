using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000C9 RID: 201
	public class MATD : RCOLItem, ICloneable
	{
		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000AB0 RID: 2736 RVA: 0x00007F6C File Offset: 0x0000616C
		// (set) Token: 0x06000AB1 RID: 2737 RVA: 0x00007F74 File Offset: 0x00006174
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Type { get; set; }

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000AB2 RID: 2738 RVA: 0x00007F7D File Offset: 0x0000617D
		// (set) Token: 0x06000AB3 RID: 2739 RVA: 0x00007F85 File Offset: 0x00006185
		[TypeConverter(typeof(IntTypeConverter))]
		public uint InternalType { get; set; }

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x00007F8E File Offset: 0x0000618E
		// (set) Token: 0x06000AB5 RID: 2741 RVA: 0x00007F96 File Offset: 0x00006196
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Version { get; set; }

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x00007F9F File Offset: 0x0000619F
		// (set) Token: 0x06000AB7 RID: 2743 RVA: 0x00007FA7 File Offset: 0x000061A7
		[TypeConverter(typeof(IntTypeConverter))]
		public uint NameHash { get; set; }

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x00007FB0 File Offset: 0x000061B0
		// (set) Token: 0x06000AB9 RID: 2745 RVA: 0x00007FB8 File Offset: 0x000061B8
		public MATD.MATDShader Shader { get; set; }

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000ABA RID: 2746 RVA: 0x00007FC1 File Offset: 0x000061C1
		// (set) Token: 0x06000ABB RID: 2747 RVA: 0x00007FC9 File Offset: 0x000061C9
		[TypeConverter(typeof(IntTypeConverter))]
		public uint IsVideoSurface { get; set; }

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000ABC RID: 2748 RVA: 0x00007FD2 File Offset: 0x000061D2
		// (set) Token: 0x06000ABD RID: 2749 RVA: 0x00007FDA File Offset: 0x000061DA
		[TypeConverter(typeof(IntTypeConverter))]
		public uint IsPaintingSurface { get; set; }

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000ABE RID: 2750 RVA: 0x00007FE3 File Offset: 0x000061E3
		// (set) Token: 0x06000ABF RID: 2751 RVA: 0x00007FEB File Offset: 0x000061EB
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Unk5 { get; set; }

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x00007FF4 File Offset: 0x000061F4
		// (set) Token: 0x06000AC1 RID: 2753 RVA: 0x00007FFC File Offset: 0x000061FC
		[TypeConverter(typeof(IntTypeConverter))]
		public uint DataSize { get; set; }

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000AC2 RID: 2754 RVA: 0x00008005 File Offset: 0x00006205
		// (set) Token: 0x06000AC3 RID: 2755 RVA: 0x0000800D File Offset: 0x0000620D
		[TypeConverter(typeof(IntTypeConverter))]
		public ushort MTRLUnk1 { get; set; }

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000AC4 RID: 2756 RVA: 0x00008016 File Offset: 0x00006216
		// (set) Token: 0x06000AC5 RID: 2757 RVA: 0x0000801E File Offset: 0x0000621E
		[TypeConverter(typeof(IntTypeConverter))]
		public ushort MTRLUnk2 { get; set; }

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x00008027 File Offset: 0x00006227
		// (set) Token: 0x06000AC7 RID: 2759 RVA: 0x0000802F File Offset: 0x0000622F
		public List<MATD.MATDEntry> Entries { get; set; }

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x00008038 File Offset: 0x00006238
		// (set) Token: 0x06000AC9 RID: 2761 RVA: 0x00008040 File Offset: 0x00006240
		[Browsable(false)]
		private byte[] data { get; set; }

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000ACA RID: 2762 RVA: 0x00008049 File Offset: 0x00006249
		// (set) Token: 0x06000ACB RID: 2763 RVA: 0x00008051 File Offset: 0x00006251
		[Browsable(false)]
		public RCOL Parent { get; private set; }

		// Token: 0x06000ACC RID: 2764 RVA: 0x0000805A File Offset: 0x0000625A
		public MATD(RCOL parent)
		{
			this.Parent = parent;
			this.Entries = new List<MATD.MATDEntry>();
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000ACD RID: 2765 RVA: 0x00008074 File Offset: 0x00006274
		[Browsable(false)]
		public byte[] Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x00033658 File Offset: 0x00031858
		public override string ToString()
		{
			return "Material (0x" + this.NameHash.ToString("X8") + ")";
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x00033688 File Offset: 0x00031888
		public object Clone()
		{
			MATD matd = (MATD)base.MemberwiseClone();
			matd.Entries = new List<MATD.MATDEntry>(this.Entries.Count);
			matd.NameHash = (uint)new Random((int)DateTime.Now.Ticks).Next();
			foreach (MATD.MATDEntry matdentry in this.Entries)
			{
				matd.Entries.Add(matdentry.Clone());
			}
			return matd;
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00033728 File Offset: 0x00031928
		public static MATD CreateMatdForFloor(RCOL parent)
		{
			MATD matd = MATD._createGenericMatd(parent, MATD.MATDShader.BluePrint);
			matd.Entries.Add(new MATD.MATDEntry(MATD.MATDEntryType.DiffuseMap, MATD.MATDDataType.Texture, new object[]
			{
				1558749909,
				144072066,
				11720834,
				0,
				0
			}));
			matd.Entries.Add(new MATD.MATDEntry(MATD.MATDEntryType.IsPartition, MATD.MATDDataType.FloatType, new object[]
			{
				1f
			}));
			matd.Entries.Add(new MATD.MATDEntry(MATD.MATDEntryType.Diffuse, MATD.MATDDataType.FloatType, new object[]
			{
				1f,
				1f,
				1f,
				1f
			}));
			return matd;
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x00033810 File Offset: 0x00031A10
		private static MATD _createGenericMatd(RCOL parent, MATD.MATDShader shaderType)
		{
			return new MATD(parent)
			{
				Type = 1146372429U,
				Version = 1U,
				NameHash = 0U,
				Shader = shaderType,
				MTRLUnk1 = 0,
				MTRLUnk2 = 0,
				InternalType = 1280463949U
			};
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0003385C File Offset: 0x00031A5C
		public void CopyTo(MATD to)
		{
			to.Shader = this.Shader;
			to.Entries.Clear();
			foreach (MATD.MATDEntry matdentry in this.Entries)
			{
				MATD.MATDEntry matdentry2 = matdentry.Clone();
				if (matdentry2.DataType == MATD.MATDDataType.Texture && (matdentry2.Values.Length == 4 || matdentry2.Values.Length == 5))
				{
					bool flag = false;
					bool flag2 = true;
					ResKey resKey;
					if (matdentry2.Values.Length == 4)
					{
						int[] intValue = matdentry2.GetIntValue();
						if (intValue[2] != 0)
						{
							flag2 = false;
							resKey = new ResKey(intValue[2], intValue[3], intValue[1], intValue[0]);
							resKey.Game = this.Parent.gameVersion;
						}
						else
						{
							int num = (int)matdentry2.Values[0] & 268435455;
							resKey = this.Parent.ExternalResources[num - 1].ResKey;
						}
					}
					else
					{
						int[] intValue2 = matdentry.GetIntValue();
						resKey = new ResKey(intValue2[2], intValue2[3], intValue2[1], intValue2[0]);
						flag2 = false;
					}
					if (flag2)
					{
						int i = 0;
						while (i < to.Parent.ExternalResources.Count)
						{
							if (!to.Parent.ExternalResources[i].ResKey.Equals(resKey))
							{
								i++;
							}
							else
							{
								matdentry2.Values = new object[]
								{
									805306368 + i + 1,
									0,
									0,
									0
								};
								flag = true;
								IL_17F:
								if (!flag && matdentry.Values.Length == 4)
								{
									RCOLFileEntry item = new RCOLFileEntry((RCOLItemType)resKey.TypeId, resKey.InstanceId, resKey.SecondInstanceId, resKey.GroupId);
									to.Parent.ExternalResources.Add(item);
									int num2 = to.Parent.ExternalResources.IndexOf(item);
									matdentry2.Values = new object[]
									{
										805306368 + num2 + 1,
										0,
										0,
										0
									};
									goto IL_2C0;
								}
								goto IL_2C0;
							}
						}
						goto IL_17F;
					}
					if (matdentry2.Values.Length == 4)
					{
						matdentry2.Values = new object[]
						{
							resKey.SecondInstanceId,
							resKey.InstanceId,
							(int)resKey.TypeId,
							resKey.GroupId
						};
					}
					else
					{
						if (matdentry2.Values.Length != 5)
						{
							throw new Exception("Valuelength " + matdentry2.Values.Length.ToString() + " not supported for MATD REskey");
						}
						matdentry2.Values = new object[]
						{
							resKey.SecondInstanceId,
							resKey.InstanceId,
							(int)resKey.TypeId,
							resKey.GroupId,
							0
						};
					}
				}
				IL_2C0:
				to.Entries.Add(matdentry2);
			}
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x00033B98 File Offset: 0x00031D98
		public override void UnSerialize(BinaryReader reader)
		{
			this.data = reader.ReadBytes((int)reader.BaseStream.Length);
			reader.BaseStream.Position = 0L;
			this.Entries.Clear();
			this.Type = reader.ReadUInt32();
			this.Version = reader.ReadUInt32();
			this.NameHash = reader.ReadUInt32();
			uint shader = reader.ReadUInt32();
			this.Shader = (MATD.MATDShader)shader;
			int num = reader.ReadInt32();
			if (this.Version < 259U)
			{
				this.InternalType = reader.ReadUInt32();
				this.Unk5 = reader.ReadUInt32();
				this.MTRLUnk1 = reader.ReadUInt16();
				this.MTRLUnk2 = reader.ReadUInt16();
			}
			else if (this.Version >= 259U)
			{
				this.IsVideoSurface = reader.ReadUInt32();
				this.IsPaintingSurface = reader.ReadUInt32();
				this.InternalType = reader.ReadUInt32();
				this.Unk5 = reader.ReadUInt32();
				this.DataSize = reader.ReadUInt32();
			}
			uint num2 = reader.ReadUInt32();
			int num3 = 0;
			while ((long)num3 < (long)((ulong)num2))
			{
				MATD.MATDEntry matdentry = new MATD.MATDEntry();
				matdentry.Type = (MATD.MATDEntryType)reader.ReadUInt32();
				matdentry.DataType = (MATD.MATDDataType)reader.ReadUInt32();
				matdentry.NumValues = reader.ReadInt32();
				matdentry.Offset = reader.ReadUInt32();
				this.Entries.Add(matdentry);
				num3++;
			}
			foreach (MATD.MATDEntry matdentry2 in this.Entries)
			{
				reader.BaseStream.Position = (long)(this.data.Length - num) + (long)((ulong)matdentry2.Offset);
				MATD.MATDDataType dataType = matdentry2.DataType;
				matdentry2.Bytes = reader.ReadBytes(matdentry2.NumValues * 4);
			}
			reader.Close();
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x00033D80 File Offset: 0x00031F80
		public override void Serialize(BinaryWriter w)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
			binaryWriter.Write(this.InternalType);
			binaryWriter.Write(this.Unk5);
			int num = 0;
			foreach (MATD.MATDEntry matdentry in this.Entries)
			{
				num += matdentry.NumValues;
			}
			if (this.Version < 259U)
			{
				binaryWriter.Write(this.MTRLUnk1);
				binaryWriter.Write(this.MTRLUnk2);
			}
			else
			{
				binaryWriter.Write(num * 4);
			}
			binaryWriter.Write(this.Entries.Count);
			long position = memoryStream.Position;
			foreach (MATD.MATDEntry matdentry2 in this.Entries)
			{
				int value = (int)((long)(this.Entries.Count * 16 + 16) + memoryStream2.Position);
				binaryWriter.Write((uint)matdentry2.Type);
				binaryWriter.Write((uint)matdentry2.DataType);
				binaryWriter.Write(matdentry2.NumValues);
				binaryWriter.Write(value);
				foreach (byte value2 in matdentry2.Bytes)
				{
					binaryWriter2.Write(value2);
				}
			}
			binaryWriter.Write(memoryStream2.ToArray());
			memoryStream2.Dispose();
			binaryWriter2.Close();
			w.Write(this.Type);
			w.Write(this.Version);
			w.Write(this.NameHash);
			w.Write((uint)this.Shader);
			w.Write((int)memoryStream.Length);
			if (this.Version >= 259U)
			{
				w.Write(this.IsVideoSurface);
				w.Write(this.IsPaintingSurface);
			}
			w.Write(memoryStream.ToArray());
			memoryStream.Dispose();
			binaryWriter.Close();
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x00033FA4 File Offset: 0x000321A4
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (MATD.MATDEntry matdentry in this.Entries)
			{
				if (matdentry.DataType == MATD.MATDDataType.Image)
				{
					int[] intValue = matdentry.GetIntValue();
					if (new ResKey(intValue[2], intValue[3], intValue[1], intValue[0]).Equals(from))
					{
						matdentry.Values = new object[]
						{
							to.SecondInstanceId,
							to.InstanceId,
							(int)to.TypeId,
							to.GroupId
						};
						num++;
					}
				}
				if (matdentry.DataType == MATD.MATDDataType.Another_Image)
				{
					int[] intValue2 = matdentry.GetIntValue();
					if (new ResKey(intValue2[2], intValue2[3], intValue2[1], intValue2[0]).Equals(from))
					{
						matdentry.Values = new object[]
						{
							to.SecondInstanceId,
							to.InstanceId,
							(int)to.TypeId,
							to.GroupId
						};
						num++;
					}
				}
				else if (matdentry.DataType == MATD.MATDDataType.Texture)
				{
					int[] intValue3 = matdentry.GetIntValue();
					if (intValue3[2] != 0)
					{
						if (new ResKey(intValue3[2], intValue3[3], intValue3[1], intValue3[0]).Equals(from))
						{
							matdentry.Values = new object[]
							{
								to.SecondInstanceId,
								to.InstanceId,
								(int)to.TypeId,
								to.GroupId
							};
							num++;
						}
					}
					else if (this.Parent.gameVersion == 4)
					{
						throw new Exception("ReplaceReferences, reskey is external resource. Not implemented.");
					}
				}
				else
				{
					int[] intValue4 = matdentry.GetIntValue();
					if (intValue4.Length == 4 && new ResKey(intValue4[2], intValue4[3], intValue4[1], intValue4[0]).Equals(from))
					{
						matdentry.Values = new object[]
						{
							to.SecondInstanceId,
							to.InstanceId,
							(int)to.TypeId,
							to.GroupId
						};
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x020001BC RID: 444
		public enum MATDShader : uint
		{
			// Token: 0x04000D7A RID: 3450
			None,
			// Token: 0x04000D7B RID: 3451
			BluePrint = 1751426142U,
			// Token: 0x04000D7C RID: 3452
			Additive = 1525770033U,
			// Token: 0x04000D7D RID: 3453
			BasinWater = 1789733589U,
			// Token: 0x04000D7E RID: 3454
			BuildingWindow = 2063821825U,
			// Token: 0x04000D7F RID: 3455
			CASRoom = 2495195189U,
			// Token: 0x04000D80 RID: 3456
			Counters = 2752982882U,
			// Token: 0x04000D81 RID: 3457
			Counters2 = 2994706292U,
			// Token: 0x04000D82 RID: 3458
			DropShadow = 3231479170U,
			// Token: 0x04000D83 RID: 3459
			Fence = 1729134568U,
			// Token: 0x04000D84 RID: 3460
			FlatMirror = 2794298921U,
			// Token: 0x04000D85 RID: 3461
			Floors = 3162820608U,
			// Token: 0x04000D86 RID: 3462
			Foliage = 1162469934U,
			// Token: 0x04000D87 RID: 3463
			FullBright = 351941470U,
			// Token: 0x04000D88 RID: 3464
			Gemstones = 2690892240U,
			// Token: 0x04000D89 RID: 3465
			GlassForFences = 1385720930U,
			// Token: 0x04000D8A RID: 3466
			GlassForObjects = 1227803260U,
			// Token: 0x04000D8B RID: 3467
			GlassForObjectsTranslucent = 2224877601U,
			// Token: 0x04000D8C RID: 3468
			GlassForPortals = 2178752589U,
			// Token: 0x04000D8D RID: 3469
			GlassForRabbitHoles = 643824289U,
			// Token: 0x04000D8E RID: 3470
			GlassShader1 = 1068219516U,
			// Token: 0x04000D8F RID: 3471
			ImpostorWater = 662501611U,
			// Token: 0x04000D90 RID: 3472
			Instanced = 213397176U,
			// Token: 0x04000D91 RID: 3473
			InstancedWindow = 3825821404U,
			// Token: 0x04000D92 RID: 3474
			Landmark = 2321594729U,
			// Token: 0x04000D93 RID: 3475
			LotImposter = 1751129571U,
			// Token: 0x04000D94 RID: 3476
			LotPondWater = 3778569092U,
			// Token: 0x04000D95 RID: 3477
			OutdoorProp = 1294384832U,
			// Token: 0x04000D96 RID: 3478
			Painting = 2856933409U,
			// Token: 0x04000D97 RID: 3479
			ParticleAnim = 1175360500U,
			// Token: 0x04000D98 RID: 3480
			ParticleJet = 4284377352U,
			// Token: 0x04000D99 RID: 3481
			Phong = 3104856685U,
			// Token: 0x04000D9A RID: 3482
			PhongAlpha = 4234134034U,
			// Token: 0x04000D9B RID: 3483
			PickWater = 3238484239U,
			// Token: 0x04000D9C RID: 3484
			Plumbob = 3740362084U,
			// Token: 0x04000D9D RID: 3485
			PreviewWallsAndFloors = 557671168U,
			// Token: 0x04000D9E RID: 3486
			RabbitHoleHighDetail = 2369022908U,
			// Token: 0x04000D9F RID: 3487
			RabbitHoleMediumDetail = 2933813509U,
			// Token: 0x04000DA0 RID: 3488
			SomeRoofShader = 2077253475U,
			// Token: 0x04000DA1 RID: 3489
			Rug = 712161697U,
			// Token: 0x04000DA2 RID: 3490
			SculptureIce = 3856237831U,
			// Token: 0x04000DA3 RID: 3491
			ShadowMap = 570302589U,
			// Token: 0x04000DA4 RID: 3492
			SimEyelashes = 2644353377U,
			// Token: 0x04000DA5 RID: 3493
			SimEyes = 3481956532U,
			// Token: 0x04000DA6 RID: 3494
			simglass = 1591385310U,
			// Token: 0x04000DA7 RID: 3495
			SimHair = 2231202130U,
			// Token: 0x04000DA8 RID: 3496
			SimSkin = 1417909433U,
			// Token: 0x04000DA9 RID: 3497
			SolidPhong = 1204183948U,
			// Token: 0x04000DAA RID: 3498
			Stairs = 1289942167U,
			// Token: 0x04000DAB RID: 3499
			StandingWater = 1895686162U,
			// Token: 0x04000DAC RID: 3500
			Subtractive = 187116741U,
			// Token: 0x04000DAD RID: 3501
			Trampoline = 960094356U
		}

		// Token: 0x020001BD RID: 445
		public enum MATDEntryType : uint
		{
			// Token: 0x04000DAF RID: 3503
			SnowMap = 62370308U,
			// Token: 0x04000DB0 RID: 3504
			SnowDisallowed = 4040939536U,
			// Token: 0x04000DB1 RID: 3505
			SnowHeightParams = 2948805983U,
			// Token: 0x04000DB2 RID: 3506
			LightmapAlwaysOn = 1237225679U,
			// Token: 0x04000DB3 RID: 3507
			ScratchHeigh = 3023664172U,
			// Token: 0x04000DB4 RID: 3508
			VertSelfIlluminationScale = 2678378039U,
			// Token: 0x04000DB5 RID: 3509
			lightColorAndIntensity = 1651884598U,
			// Token: 0x04000DB6 RID: 3510
			heightMapScale = 4145812156U,
			// Token: 0x04000DB7 RID: 3511
			LightmapSizeParameters = 207156736U,
			// Token: 0x04000DB8 RID: 3512
			CurseFaceSampler = 3134069910U,
			// Token: 0x04000DB9 RID: 3513
			SkinSpecularPower = 2627003788U,
			// Token: 0x04000DBA RID: 3514
			InitialPaintsSnowMeltingWithCutout = 3189838889U,
			// Token: 0x04000DBB RID: 3515
			SimHairVisualizer = 278785974U,
			// Token: 0x04000DBC RID: 3516
			Floors = 3162820608U,
			// Token: 0x04000DBD RID: 3517
			SimAlphaBlended = 3904172532U,
			// Token: 0x04000DBE RID: 3518
			ParticleAnim = 1175360500U,
			// Token: 0x04000DBF RID: 3519
			roadsMask = 521917606U,
			// Token: 0x04000DC0 RID: 3520
			FresnelOffset = 4217809099U,
			// Token: 0x04000DC1 RID: 3521
			samplerimposterTextureAOandSI = 3024092310U,
			// Token: 0x04000DC2 RID: 3522
			treebillboard = 3989898994U,
			// Token: 0x04000DC3 RID: 3523
			CameraAzimuthTrig = 2676899150U,
			// Token: 0x04000DC4 RID: 3524
			ClampedBlitOp = 2860349177U,
			// Token: 0x04000DC5 RID: 3525
			PickCounters = 3456896449U,
			// Token: 0x04000DC6 RID: 3526
			RoofUnlit = 207385401U,
			// Token: 0x04000DC7 RID: 3527
			LifetimeSecondsOverride = 144048099U,
			// Token: 0x04000DC8 RID: 3528
			BasicShadows = 3071046124U,
			// Token: 0x04000DC9 RID: 3529
			SimPet = 2067444953U,
			// Token: 0x04000DCA RID: 3530
			CASLightMap = 2366953658U,
			// Token: 0x04000DCB RID: 3531
			samplerPointSampleBlitMap = 3091144266U,
			// Token: 0x04000DCC RID: 3532
			SnowDoorAlphaMap = 2912735866U,
			// Token: 0x04000DCD RID: 3533
			PoolNormalMap1 = 474223741U,
			// Token: 0x04000DCE RID: 3534
			LeavesDensity = 2795326631U,
			// Token: 0x04000DCF RID: 3535
			PoolNormalMap2 = 474223742U,
			// Token: 0x04000DD0 RID: 3536
			Sepia = 5630929U,
			// Token: 0x04000DD1 RID: 3537
			translucentTextureOffsets = 3521303845U,
			// Token: 0x04000DD2 RID: 3538
			colorMap2 = 3287135898U,
			// Token: 0x04000DD3 RID: 3539
			DebugCrossFade = 112146120U,
			// Token: 0x04000DD4 RID: 3540
			colorMap3 = 3287135899U,
			// Token: 0x04000DD5 RID: 3541
			WorldCursor = 2428087181U,
			// Token: 0x04000DD6 RID: 3542
			EdgeColor = 3930858527U,
			// Token: 0x04000DD7 RID: 3543
			samplerImpostorDetailTexture = 681010428U,
			// Token: 0x04000DD8 RID: 3544
			samplerSkyReflection = 822762765U,
			// Token: 0x04000DD9 RID: 3545
			colorMap4 = 3287135900U,
			// Token: 0x04000DDA RID: 3546
			colorMap5,
			// Token: 0x04000DDB RID: 3547
			DistortionTexture = 2744891553U,
			// Token: 0x04000DDC RID: 3548
			colorMap6 = 3287135902U,
			// Token: 0x04000DDD RID: 3549
			StyleTexture = 3936963161U,
			// Token: 0x04000DDE RID: 3550
			Level12TimeScale = 3915406039U,
			// Token: 0x04000DDF RID: 3551
			SkinRampTexture = 2121252927U,
			// Token: 0x04000DE0 RID: 3552
			TerrainChunkTranslation = 197127764U,
			// Token: 0x04000DE1 RID: 3553
			samplerExteriorDiffuseLightProbe = 53975371U,
			// Token: 0x04000DE2 RID: 3554
			OverlaySpec = 838700810U,
			// Token: 0x04000DE3 RID: 3555
			pickTerrain = 256491169U,
			// Token: 0x04000DE4 RID: 3556
			HDLightPositions = 1091892113U,
			// Token: 0x04000DE5 RID: 3557
			samplerworldBuilderObjectGridMap = 3129645891U,
			// Token: 0x04000DE6 RID: 3558
			AOMap = 2903925429U,
			// Token: 0x04000DE7 RID: 3559
			RenderSHToCube = 1221666180U,
			// Token: 0x04000DE8 RID: 3560
			BlueRampTexture = 1443613086U,
			// Token: 0x04000DE9 RID: 3561
			CASSkinSinglePass = 1518466692U,
			// Token: 0x04000DEA RID: 3562
			GhostHorse = 3151285517U,
			// Token: 0x04000DEB RID: 3563
			FrustumDebug = 3770936106U,
			// Token: 0x04000DEC RID: 3564
			tapWeights = 659406195U,
			// Token: 0x04000DED RID: 3565
			GhostFurOpaque = 1656749536U,
			// Token: 0x04000DEE RID: 3566
			GhostNoiseParams = 4102540086U,
			// Token: 0x04000DEF RID: 3567
			LightBasisMap1 = 2113795412U,
			// Token: 0x04000DF0 RID: 3568
			ImposterShadows = 3322554579U,
			// Token: 0x04000DF1 RID: 3569
			LightBasisMap0 = 2113795413U,
			// Token: 0x04000DF2 RID: 3570
			LightBasisMap3,
			// Token: 0x04000DF3 RID: 3571
			BillboardNormal = 588222451U,
			// Token: 0x04000DF4 RID: 3572
			RenderVectors = 639850179U,
			// Token: 0x04000DF5 RID: 3573
			LightBasisMap2 = 2113795415U,
			// Token: 0x04000DF6 RID: 3574
			ShadowMainMap = 1860095008U,
			// Token: 0x04000DF7 RID: 3575
			ClearBuffer = 4143705102U,
			// Token: 0x04000DF8 RID: 3576
			samplerterrainLightMap = 484644092U,
			// Token: 0x04000DF9 RID: 3577
			glyphCacheTexture = 1374937206U,
			// Token: 0x04000DFA RID: 3578
			DimmingRadius = 853516952U,
			// Token: 0x04000DFB RID: 3579
			BackFaceDiffuseContribution = 3594625457U,
			// Token: 0x04000DFC RID: 3580
			ImpostorLightingGlow = 93669649U,
			// Token: 0x04000DFD RID: 3581
			ErrorAsset = 2220928147U,
			// Token: 0x04000DFE RID: 3582
			samplerValueRampTexture = 3190454171U,
			// Token: 0x04000DFF RID: 3583
			PrecipitationShadowMainMap = 2743649469U,
			// Token: 0x04000E00 RID: 3584
			floorImposterMaker = 3522590832U,
			// Token: 0x04000E01 RID: 3585
			DimmingCenterHeight = 28159200U,
			// Token: 0x04000E02 RID: 3586
			SeaLevel = 1545393100U,
			// Token: 0x04000E03 RID: 3587
			FloorWithStrobelight = 3228484374U,
			// Token: 0x04000E04 RID: 3588
			DirtOverlay = 1211575906U,
			// Token: 0x04000E05 RID: 3589
			AmbientFloorBottom = 256305026U,
			// Token: 0x04000E06 RID: 3590
			RainRippleUVRandomOffset = 2345530972U,
			// Token: 0x04000E07 RID: 3591
			CreateThumbnail = 1689509519U,
			// Token: 0x04000E08 RID: 3592
			samplerTireTracksTextureN = 3751248132U,
			// Token: 0x04000E09 RID: 3593
			shadowmapmerged = 3801188249U,
			// Token: 0x04000E0A RID: 3594
			HSVToRGBOp = 3691611321U,
			// Token: 0x04000E0B RID: 3595
			samplerTireTracksTextureD = 3751248142U,
			// Token: 0x04000E0C RID: 3596
			samplerSkyMoonTexture8 = 2510577554U,
			// Token: 0x04000E0D RID: 3597
			CASMap2Target = 1247237339U,
			// Token: 0x04000E0E RID: 3598
			clipBoundsMap = 981403094U,
			// Token: 0x04000E0F RID: 3599
			samplerSkyMoonTexture2 = 2510577560U,
			// Token: 0x04000E10 RID: 3600
			samplerSkyMoonTexture3,
			// Token: 0x04000E11 RID: 3601
			samplerSkyMoonTexture6 = 2510577564U,
			// Token: 0x04000E12 RID: 3602
			samplerSkyMoonTexture7,
			// Token: 0x04000E13 RID: 3603
			samplerSkyMoonTexture4,
			// Token: 0x04000E14 RID: 3604
			samplerSkyMoonTexture5,
			// Token: 0x04000E15 RID: 3605
			samplerNormalTexture = 982638175U,
			// Token: 0x04000E16 RID: 3606
			BrushedMetal = 1071094029U,
			// Token: 0x04000E17 RID: 3607
			rainPuddleNormalsTexture = 1860377906U,
			// Token: 0x04000E18 RID: 3608
			WallFloorSpecScaleOverride = 3389099822U,
			// Token: 0x04000E19 RID: 3609
			CloudColorWRTSunLight1 = 1841981521U,
			// Token: 0x04000E1A RID: 3610
			samplerFinMapTexture1 = 2230575398U,
			// Token: 0x04000E1B RID: 3611
			CloudColorWRTSunLight2 = 1841981522U,
			// Token: 0x04000E1C RID: 3612
			samplerFinMapTexture0 = 2230575399U,
			// Token: 0x04000E1D RID: 3613
			GreenRampTexture = 2134117535U,
			// Token: 0x04000E1E RID: 3614
			TB_QuadData = 151413851U,
			// Token: 0x04000E1F RID: 3615
			ponds = 2042856855U,
			// Token: 0x04000E20 RID: 3616
			FurMapTexture = 2268285051U,
			// Token: 0x04000E21 RID: 3617
			kInteriorCausticsGain = 3823073034U,
			// Token: 0x04000E22 RID: 3618
			SkyNightStarsFlat = 1201051956U,
			// Token: 0x04000E23 RID: 3619
			permGradSampler = 640081245U,
			// Token: 0x04000E24 RID: 3620
			samplerLightingRamp = 3408752511U,
			// Token: 0x04000E25 RID: 3621
			EmissiveBloomMultiplier = 1225682612U,
			// Token: 0x04000E26 RID: 3622
			ImpostorColorDefault = 3981423374U,
			// Token: 0x04000E27 RID: 3623
			kFurLength = 1050927563U,
			// Token: 0x04000E28 RID: 3624
			ChannelSelectOp = 506870683U,
			// Token: 0x04000E29 RID: 3625
			PeelMapTarget = 516715872U,
			// Token: 0x04000E2A RID: 3626
			samplerNoiseVolumeMap = 2295319857U,
			// Token: 0x04000E2B RID: 3627
			simglass = 1591385310U,
			// Token: 0x04000E2C RID: 3628
			normalMapLM = 2663813243U,
			// Token: 0x04000E2D RID: 3629
			Ceiling = 3504694206U,
			// Token: 0x04000E2E RID: 3630
			terrainLightProbeMap = 2598785976U,
			// Token: 0x04000E2F RID: 3631
			PuddleInfoPartialTexture = 3096247325U,
			// Token: 0x04000E30 RID: 3632
			ghostHair = 12817574U,
			// Token: 0x04000E31 RID: 3633
			samplerLevel1NormalMap = 3591587381U,
			// Token: 0x04000E32 RID: 3634
			SimPetFurExitData = 2828374284U,
			// Token: 0x04000E33 RID: 3635
			SelfShadowMotion = 1825619277U,
			// Token: 0x04000E34 RID: 3636
			CASMapBlur = 3670780233U,
			// Token: 0x04000E35 RID: 3637
			samplerWaterReflectionMap = 4212166635U,
			// Token: 0x04000E36 RID: 3638
			HeadBoneIndex = 4127552695U,
			// Token: 0x04000E37 RID: 3639
			BloodMap = 1625003231U,
			// Token: 0x04000E38 RID: 3640
			OverlaySpecSampler = 2790763646U,
			// Token: 0x04000E39 RID: 3641
			samplerFurLin = 289244191U,
			// Token: 0x04000E3A RID: 3642
			leafMesh = 1233557386U,
			// Token: 0x04000E3B RID: 3643
			SkyIntensity = 2390356495U,
			// Token: 0x04000E3C RID: 3644
			samplerFloorGridTexture = 290158720U,
			// Token: 0x04000E3D RID: 3645
			VideoVTexture = 1424149133U,
			// Token: 0x04000E3E RID: 3646
			RenderParticlePoint = 185757763U,
			// Token: 0x04000E3F RID: 3647
			editModeSeaWater = 2568163870U,
			// Token: 0x04000E40 RID: 3648
			InitialPaintsFrost = 3380225798U,
			// Token: 0x04000E41 RID: 3649
			CASFinal = 1931118628U,
			// Token: 0x04000E42 RID: 3650
			FluidEffect = 2410362724U,
			// Token: 0x04000E43 RID: 3651
			samplerSkinDetailTexture = 1132977152U,
			// Token: 0x04000E44 RID: 3652
			samplerObjectSnowSideTexture = 2753673923U,
			// Token: 0x04000E45 RID: 3653
			samplerPuddleInfoTexture = 977335016U,
			// Token: 0x04000E46 RID: 3654
			UseLampColor = 1454514381U,
			// Token: 0x04000E47 RID: 3655
			SimLightingTweaks3 = 2082482820U,
			// Token: 0x04000E48 RID: 3656
			SimLightingTweaks2,
			// Token: 0x04000E49 RID: 3657
			PreviewWallsAndFloors = 557671168U,
			// Token: 0x04000E4A RID: 3658
			SimLightingTweaks1 = 2082482822U,
			// Token: 0x04000E4B RID: 3659
			SkyLight = 2929423632U,
			// Token: 0x04000E4C RID: 3660
			Soulstone = 1387396455U,
			// Token: 0x04000E4D RID: 3661
			kDistantNormalMapTiling = 662437481U,
			// Token: 0x04000E4E RID: 3662
			lightColor = 2184656436U,
			// Token: 0x04000E4F RID: 3663
			UVScales = 1107632361U,
			// Token: 0x04000E50 RID: 3664
			pickleafcard = 3996018012U,
			// Token: 0x04000E51 RID: 3665
			RoadTexture = 1397887492U,
			// Token: 0x04000E52 RID: 3666
			DiffuseMapSampler = 3817305567U,
			// Token: 0x04000E53 RID: 3667
			TerrainLightNoSnowElev = 2726785314U,
			// Token: 0x04000E54 RID: 3668
			CreateThumbnailR2Sepia = 2938955387U,
			// Token: 0x04000E55 RID: 3669
			RippleHeights = 1778898913U,
			// Token: 0x04000E56 RID: 3670
			WorldBuilderPaintingMaskParams = 1419430486U,
			// Token: 0x04000E57 RID: 3671
			BasisFactorA = 882880649U,
			// Token: 0x04000E58 RID: 3672
			BasisFactorB,
			// Token: 0x04000E59 RID: 3673
			BasisFactorC,
			// Token: 0x04000E5A RID: 3674
			BasisFactorD,
			// Token: 0x04000E5B RID: 3675
			ImpostorLightingDefault = 1594095977U,
			// Token: 0x04000E5C RID: 3676
			LotPondImpostor = 3716496696U,
			// Token: 0x04000E5D RID: 3677
			OverlayAlphaThreshold = 2167902914U,
			// Token: 0x04000E5E RID: 3678
			GlassForRabbitHoles = 643824289U,
			// Token: 0x04000E5F RID: 3679
			LightingDirectScale = 4012314340U,
			// Token: 0x04000E60 RID: 3680
			samplerClampedDiffuseMap = 1391471763U,
			// Token: 0x04000E61 RID: 3681
			VideoViewportAdjust = 2917905033U,
			// Token: 0x04000E62 RID: 3682
			WorldSpaceViewCameraPosition = 1499108884U,
			// Token: 0x04000E63 RID: 3683
			moonhalo = 582384376U,
			// Token: 0x04000E64 RID: 3684
			HaloLowColor = 783870164U,
			// Token: 0x04000E65 RID: 3685
			WorldLeavesTexture = 631065856U,
			// Token: 0x04000E66 RID: 3686
			samplerSkyMoonNMTexture = 1512112467U,
			// Token: 0x04000E67 RID: 3687
			curlPixelRadius = 2672348079U,
			// Token: 0x04000E68 RID: 3688
			HasExteriorAndInteriorLighting = 1608888536U,
			// Token: 0x04000E69 RID: 3689
			AlphaTestShadows = 3929248974U,
			// Token: 0x04000E6A RID: 3690
			GlobalWeatherParams2 = 4050287996U,
			// Token: 0x04000E6B RID: 3691
			uvMapping = 3821868770U,
			// Token: 0x04000E6C RID: 3692
			GlobalWeatherParams3 = 4050287997U,
			// Token: 0x04000E6D RID: 3693
			paraboloidLookupTexture = 3860120525U,
			// Token: 0x04000E6E RID: 3694
			TerrainLight_IndoorWithStrobeLight = 3304955103U,
			// Token: 0x04000E6F RID: 3695
			samplerWeightMap = 77915695U,
			// Token: 0x04000E70 RID: 3696
			ExteriorMinspecLightData = 4120295616U,
			// Token: 0x04000E71 RID: 3697
			SimPetFurFinData = 162371723U,
			// Token: 0x04000E72 RID: 3698
			FadeYThreshold = 2474612297U,
			// Token: 0x04000E73 RID: 3699
			Jade = 3949123215U,
			// Token: 0x04000E74 RID: 3700
			billboard_alpha = 2520288603U,
			// Token: 0x04000E75 RID: 3701
			dvds = 2265159856U,
			// Token: 0x04000E76 RID: 3702
			SecondaryNormalMapWeight = 3330526214U,
			// Token: 0x04000E77 RID: 3703
			SunTexture = 2126674322U,
			// Token: 0x04000E78 RID: 3704
			PickCASSimFur = 1868483829U,
			// Token: 0x04000E79 RID: 3705
			TreeShadowScale = 1329150377U,
			// Token: 0x04000E7A RID: 3706
			InitialPaints = 4024811208U,
			// Token: 0x04000E7B RID: 3707
			PickDefault = 2417471557U,
			// Token: 0x04000E7C RID: 3708
			samplerBurnInfoTexture = 4096699709U,
			// Token: 0x04000E7D RID: 3709
			InteriorFloor = 417363785U,
			// Token: 0x04000E7E RID: 3710
			InitialPaintsWithCutout = 2560838444U,
			// Token: 0x04000E7F RID: 3711
			SkinDetailTexture = 1413528626U,
			// Token: 0x04000E80 RID: 3712
			samplerShadowMainMap = 162093622U,
			// Token: 0x04000E81 RID: 3713
			samplercolorMap4 = 1599679778U,
			// Token: 0x04000E82 RID: 3714
			BillboardFadeConstants = 2920297451U,
			// Token: 0x04000E83 RID: 3715
			phongalpha = 4234134034U,
			// Token: 0x04000E84 RID: 3716
			HorizonLight = 2703517090U,
			// Token: 0x04000E85 RID: 3717
			samplercolorMap2 = 1599679780U,
			// Token: 0x04000E86 RID: 3718
			samplercolorMap3,
			// Token: 0x04000E87 RID: 3719
			PickWallsWithCutoutBacksideSolid = 3978639950U,
			// Token: 0x04000E88 RID: 3720
			Simple = 1916446439U,
			// Token: 0x04000E89 RID: 3721
			Level12WorldScaleUV = 1929706927U,
			// Token: 0x04000E8A RID: 3722
			TreeLightColors = 379571667U,
			// Token: 0x04000E8B RID: 3723
			samplerprelimThumbs = 2224508707U,
			// Token: 0x04000E8C RID: 3724
			samplerblendMap = 2929086722U,
			// Token: 0x04000E8D RID: 3725
			ShadowLocations = 2141009635U,
			// Token: 0x04000E8E RID: 3726
			samplerSkinSecondaryNormalTexture = 3054535696U,
			// Token: 0x04000E8F RID: 3727
			TerrainCenterPos = 2223115735U,
			// Token: 0x04000E90 RID: 3728
			leafCard = 732605503U,
			// Token: 0x04000E91 RID: 3729
			FullBrightInstanced = 3922053121U,
			// Token: 0x04000E92 RID: 3730
			imposterTexture = 3184488901U,
			// Token: 0x04000E93 RID: 3731
			permTexture = 1947483448U,
			// Token: 0x04000E94 RID: 3732
			MultiplyValue = 4097649628U,
			// Token: 0x04000E95 RID: 3733
			CASMap1Texture = 3810180480U,
			// Token: 0x04000E96 RID: 3734
			terrainLightMap = 1607839750U,
			// Token: 0x04000E97 RID: 3735
			RenderParticleClipAlpha = 3330290567U,
			// Token: 0x04000E98 RID: 3736
			samplerPeelMapTexture = 4188186714U,
			// Token: 0x04000E99 RID: 3737
			LayerSelect0 = 2895711624U,
			// Token: 0x04000E9A RID: 3738
			LayerSelect1,
			// Token: 0x04000E9B RID: 3739
			LayerSelect2,
			// Token: 0x04000E9C RID: 3740
			samplerVideoUTexture = 869954982U,
			// Token: 0x04000E9D RID: 3741
			shadowbranch = 1010290765U,
			// Token: 0x04000E9E RID: 3742
			samplerTireTracksIntersectionTextureN = 2212704887U,
			// Token: 0x04000E9F RID: 3743
			samplerFrostMap = 4054907803U,
			// Token: 0x04000EA0 RID: 3744
			thumbnailSceneClearColor = 3882769025U,
			// Token: 0x04000EA1 RID: 3745
			samplerTireTracksIntersectionTextureD = 2212704893U,
			// Token: 0x04000EA2 RID: 3746
			LMTexMapping = 2823608655U,
			// Token: 0x04000EA3 RID: 3747
			wallTopColor = 1817318151U,
			// Token: 0x04000EA4 RID: 3748
			samplerSkyMoonTexture = 3246855150U,
			// Token: 0x04000EA5 RID: 3749
			samplerSkinNormalTexture = 1100985782U,
			// Token: 0x04000EA6 RID: 3750
			DiffuseMap = 1824587141U,
			// Token: 0x04000EA7 RID: 3751
			SpecularMap1 = 3468328586U,
			// Token: 0x04000EA8 RID: 3752
			SomeMap2 = 3403839823U,
			// Token: 0x04000EA9 RID: 3753
			SomeMap3 = 2042907803U,
			// Token: 0x04000EAA RID: 3754
			SomeMap4 = 433562560U,
			// Token: 0x04000EAB RID: 3755
			RoomLightMap = 3888812390U,
			// Token: 0x04000EAC RID: 3756
			CASSpecProbeTexture = 3338773446U,
			// Token: 0x04000EAD RID: 3757
			DrawDips = 3523302977U,
			// Token: 0x04000EAE RID: 3758
			edit_mode_sea = 3145570157U,
			// Token: 0x04000EAF RID: 3759
			AdditiveValue = 962981088U,
			// Token: 0x04000EB0 RID: 3760
			GammaCurveValues = 229506263U,
			// Token: 0x04000EB1 RID: 3761
			samplerimposterTextureWater = 1287405644U,
			// Token: 0x04000EB2 RID: 3762
			ScratchRepeat = 405265396U,
			// Token: 0x04000EB3 RID: 3763
			HeightSamplerLM = 1037983193U,
			// Token: 0x04000EB4 RID: 3764
			bloodColor = 944209948U,
			// Token: 0x04000EB5 RID: 3765
			BlurrySpecularLightProbe = 2267898792U,
			// Token: 0x04000EB6 RID: 3766
			imposterTextureWater = 3208624634U,
			// Token: 0x04000EB7 RID: 3767
			blendTexMapping = 2243173869U,
			// Token: 0x04000EB8 RID: 3768
			SkyMoonTexture8 = 3307213236U,
			// Token: 0x04000EB9 RID: 3769
			SkyMoonTexture4 = 3307213240U,
			// Token: 0x04000EBA RID: 3770
			SkyMoonTexture5,
			// Token: 0x04000EBB RID: 3771
			FrameData = 509289252U,
			// Token: 0x04000EBC RID: 3772
			SkyMoonTexture6 = 3307213242U,
			// Token: 0x04000EBD RID: 3773
			ExteriorSpecularLightProbe = 2138195454U,
			// Token: 0x04000EBE RID: 3774
			SkyMoonTexture7 = 3307213243U,
			// Token: 0x04000EBF RID: 3775
			SkyMoonTexture2 = 3307213246U,
			// Token: 0x04000EC0 RID: 3776
			Night = 1011622525U,
			// Token: 0x04000EC1 RID: 3777
			SkyMoonTexture3 = 3307213247U,
			// Token: 0x04000EC2 RID: 3778
			StaticTerrainLightmap = 2259017636U,
			// Token: 0x04000EC3 RID: 3779
			tech0 = 243117967U,
			// Token: 0x04000EC4 RID: 3780
			worldSpacePosScale = 660735943U,
			// Token: 0x04000EC5 RID: 3781
			PhotographyStyles = 397588680U,
			// Token: 0x04000EC6 RID: 3782
			main = 3161908922U,
			// Token: 0x04000EC7 RID: 3783
			FilterCubeMap = 2630690622U,
			// Token: 0x04000EC8 RID: 3784
			SimEyes = 3481956532U,
			// Token: 0x04000EC9 RID: 3785
			SkinOverlayTexture = 3242004507U,
			// Token: 0x04000ECA RID: 3786
			FloorWithStrobelightAndBlacklight = 2819425050U,
			// Token: 0x04000ECB RID: 3787
			CubeMap = 2298377204U,
			// Token: 0x04000ECC RID: 3788
			SkyReflection = 1423296171U,
			// Token: 0x04000ECD RID: 3789
			samplerDetailMap = 1690912310U,
			// Token: 0x04000ECE RID: 3790
			YCbCrChannelCoeff = 4236469954U,
			// Token: 0x04000ECF RID: 3791
			SimPetFurLowQuality = 1169492057U,
			// Token: 0x04000ED0 RID: 3792
			LotPondPick = 596135308U,
			// Token: 0x04000ED1 RID: 3793
			ShadowMap = 570302589U,
			// Token: 0x04000ED2 RID: 3794
			samplersimDropShadowTexture = 2751031988U,
			// Token: 0x04000ED3 RID: 3795
			TrampolinePick = 298168087U,
			// Token: 0x04000ED4 RID: 3796
			BlitOp = 2706505905U,
			// Token: 0x04000ED5 RID: 3797
			HeatShimmerSampler = 3981553340U,
			// Token: 0x04000ED6 RID: 3798
			samplerVideoVTexture = 2628253507U,
			// Token: 0x04000ED7 RID: 3799
			TerrainIndoor = 2291584341U,
			// Token: 0x04000ED8 RID: 3800
			ShaderDayNightParameters = 4096596154U,
			// Token: 0x04000ED9 RID: 3801
			casskin = 24586391U,
			// Token: 0x04000EDA RID: 3802
			NormalUVScale = 3123518137U,
			// Token: 0x04000EDB RID: 3803
			tanColorData1 = 3996701788U,
			// Token: 0x04000EDC RID: 3804
			Occluder = 119526356U,
			// Token: 0x04000EDD RID: 3805
			tanColorData2 = 3996701791U,
			// Token: 0x04000EDE RID: 3806
			DecalInvRadius = 384274027U,
			// Token: 0x04000EDF RID: 3807
			UnlitExteriorWall = 2573660689U,
			// Token: 0x04000EE0 RID: 3808
			sysOrigin = 834338466U,
			// Token: 0x04000EE1 RID: 3809
			SpecularLightProbe = 1123337308U,
			// Token: 0x04000EE2 RID: 3810
			boneColor = 21206472U,
			// Token: 0x04000EE3 RID: 3811
			TerrainLightProbe = 228990170U,
			// Token: 0x04000EE4 RID: 3812
			FloorWithBlacklight = 3280475506U,
			// Token: 0x04000EE5 RID: 3813
			SecondaryNormalMapWeights = 2272931073U,
			// Token: 0x04000EE6 RID: 3814
			SurfaceTransparency = 2786695792U,
			// Token: 0x04000EE7 RID: 3815
			DebouncePower = 1700799967U,
			// Token: 0x04000EE8 RID: 3816
			LotPaint = 2164881482U,
			// Token: 0x04000EE9 RID: 3817
			TwigDiffuseMap = 3769416306U,
			// Token: 0x04000EEA RID: 3818
			BouncePower = 4222007448U,
			// Token: 0x04000EEB RID: 3819
			GhostFur = 3879525921U,
			// Token: 0x04000EEC RID: 3820
			StandingWater = 1895686162U,
			// Token: 0x04000EED RID: 3821
			ScratchTextureDimensions = 1767969761U,
			// Token: 0x04000EEE RID: 3822
			GlassForFences = 1385720930U,
			// Token: 0x04000EEF RID: 3823
			DiffuseUVScale = 760107134U,
			// Token: 0x04000EF0 RID: 3824
			samplerIceCracksNormalMap = 2516347906U,
			// Token: 0x04000EF1 RID: 3825
			MoonHaloTexture = 389381681U,
			// Token: 0x04000EF2 RID: 3826
			ObjectSnowNormalMap = 3534996170U,
			// Token: 0x04000EF3 RID: 3827
			OutdoorProp = 1294384832U,
			// Token: 0x04000EF4 RID: 3828
			RoofHighlightMultiplier = 2182339800U,
			// Token: 0x04000EF5 RID: 3829
			SpikeHelperSampler = 4189700063U,
			// Token: 0x04000EF6 RID: 3830
			samplerDropShadowAtlas2 = 1115938725U,
			// Token: 0x04000EF7 RID: 3831
			PoolWindowTranslucent = 966676988U,
			// Token: 0x04000EF8 RID: 3832
			TerrainDecal = 3086543935U,
			// Token: 0x04000EF9 RID: 3833
			LightMapSampler = 1158060677U,
			// Token: 0x04000EFA RID: 3834
			Composite_UVOffset = 2566118337U,
			// Token: 0x04000EFB RID: 3835
			MeteorShadowAnimationData = 226899545U,
			// Token: 0x04000EFC RID: 3836
			windata = 489311429U,
			// Token: 0x04000EFD RID: 3837
			ReflectionPass = 4065021849U,
			// Token: 0x04000EFE RID: 3838
			sun = 644904077U,
			// Token: 0x04000EFF RID: 3839
			shadowleafmesh = 2376028658U,
			// Token: 0x04000F00 RID: 3840
			LightColors = 820663215U,
			// Token: 0x04000F01 RID: 3841
			glyphCacheSampler = 2073323867U,
			// Token: 0x04000F02 RID: 3842
			samplerLightMap = 2728932845U,
			// Token: 0x04000F03 RID: 3843
			MipLevelTex = 1466122956U,
			// Token: 0x04000F04 RID: 3844
			SunReflectionParameters = 2740880486U,
			// Token: 0x04000F05 RID: 3845
			samplerSpecularMap = 1307305946U,
			// Token: 0x04000F06 RID: 3846
			CubeMapToParaboloid = 2639051016U,
			// Token: 0x04000F07 RID: 3847
			FadeZThreshold = 425764380U,
			// Token: 0x04000F08 RID: 3848
			samplerWaterSunSpecular = 2285609441U,
			// Token: 0x04000F09 RID: 3849
			AnimSpeed = 3590376291U,
			// Token: 0x04000F0A RID: 3850
			TerrainHighInsideGreenhouse = 666048751U,
			// Token: 0x04000F0B RID: 3851
			SparkleSpeed = 3121844766U,
			// Token: 0x04000F0C RID: 3852
			BloomScale = 3801851052U,
			// Token: 0x04000F0D RID: 3853
			samplerHSVtoRGBShiftTexture = 338289055U,
			// Token: 0x04000F0E RID: 3854
			GlobalWeatherParams = 4132083258U,
			// Token: 0x04000F0F RID: 3855
			WindSpeed = 1726592700U,
			// Token: 0x04000F10 RID: 3856
			InteriorWall = 1465439457U,
			// Token: 0x04000F11 RID: 3857
			samplerVideoYTexture = 42044802U,
			// Token: 0x04000F12 RID: 3858
			VideoYTexture = 4200756816U,
			// Token: 0x04000F13 RID: 3859
			renderPickId = 1599696537U,
			// Token: 0x04000F14 RID: 3860
			LevelToReveal = 4227459269U,
			// Token: 0x04000F15 RID: 3861
			OverlayTexture = 1304479932U,
			// Token: 0x04000F16 RID: 3862
			SimCensorEffect = 3430036675U,
			// Token: 0x04000F17 RID: 3863
			InteriorFloorUnlit = 3791609903U,
			// Token: 0x04000F18 RID: 3864
			samplerHaloRamp = 368939493U,
			// Token: 0x04000F19 RID: 3865
			wiggle = 3556152674U,
			// Token: 0x04000F1A RID: 3866
			SimShadowDepthScale = 3987016989U,
			// Token: 0x04000F1B RID: 3867
			WeightMap = 1673088809U,
			// Token: 0x04000F1C RID: 3868
			InteriorWallWithBlacklight = 1396240306U,
			// Token: 0x04000F1D RID: 3869
			WorldBuilderBrushParams = 2911805450U,
			// Token: 0x04000F1E RID: 3870
			BillboardAzimuth = 2996836582U,
			// Token: 0x04000F1F RID: 3871
			DecalCenters1X = 1049799021U,
			// Token: 0x04000F20 RID: 3872
			samplerObjectSnowSideNormalMap = 1643873803U,
			// Token: 0x04000F21 RID: 3873
			FadeDistance = 2507280618U,
			// Token: 0x04000F22 RID: 3874
			InteriorWallWithStrobeAndBlacklight = 2308151830U,
			// Token: 0x04000F23 RID: 3875
			TerrainHigh = 3435101884U,
			// Token: 0x04000F24 RID: 3876
			CounterLightingConfig = 923848021U,
			// Token: 0x04000F25 RID: 3877
			samplerAmbientOcclusionMap = 593441406U,
			// Token: 0x04000F26 RID: 3878
			EdgeDarkening = 2351421641U,
			// Token: 0x04000F27 RID: 3879
			uishader = 3445762600U,
			// Token: 0x04000F28 RID: 3880
			samplercensorTexture = 4161904054U,
			// Token: 0x04000F29 RID: 3881
			PondWaterLevel = 3608402673U,
			// Token: 0x04000F2A RID: 3882
			SpecularUVSelector = 3056944812U,
			// Token: 0x04000F2B RID: 3883
			FogParams = 1365672397U,
			// Token: 0x04000F2C RID: 3884
			samplerSnowDoorAlphaMap = 220582872U,
			// Token: 0x04000F2D RID: 3885
			SkinDetailTextureDark = 2573238926U,
			// Token: 0x04000F2E RID: 3886
			LightDirections = 503625581U,
			// Token: 0x04000F2F RID: 3887
			samplerterrainLightProbeMap = 4206694142U,
			// Token: 0x04000F30 RID: 3888
			boundaryRange = 1366268730U,
			// Token: 0x04000F31 RID: 3889
			RenderParticlePointNormal = 3188456002U,
			// Token: 0x04000F32 RID: 3890
			samplerSelfIlluminationMap = 2491667878U,
			// Token: 0x04000F33 RID: 3891
			ObjectSnowEdgeTexture = 2293517247U,
			// Token: 0x04000F34 RID: 3892
			GlowStrength = 1946592777U,
			// Token: 0x04000F35 RID: 3893
			WallsVisualizer = 556389396U,
			// Token: 0x04000F36 RID: 3894
			samplerSkyReflectionBlurry = 4059610281U,
			// Token: 0x04000F37 RID: 3895
			BillboardLightingAdjust = 3869610155U,
			// Token: 0x04000F38 RID: 3896
			billboardPick = 1532097833U,
			// Token: 0x04000F39 RID: 3897
			samplerSparkleMap = 2924172675U,
			// Token: 0x04000F3A RID: 3898
			TrampolineShadow = 1287917352U,
			// Token: 0x04000F3B RID: 3899
			ShimmerControl = 2615547101U,
			// Token: 0x04000F3C RID: 3900
			HaloBlur = 3282915152U,
			// Token: 0x04000F3D RID: 3901
			SimHorse = 100097777U,
			// Token: 0x04000F3E RID: 3902
			RotationSpeed = 838875860U,
			// Token: 0x04000F3F RID: 3903
			WindowFrostTexture = 3788628366U,
			// Token: 0x04000F40 RID: 3904
			GlassForPortals = 2178752589U,
			// Token: 0x04000F41 RID: 3905
			LightAmbient = 2827910461U,
			// Token: 0x04000F42 RID: 3906
			BurntTile = 1762647814U,
			// Token: 0x04000F43 RID: 3907
			BB360TexCoords = 3826470015U,
			// Token: 0x04000F44 RID: 3908
			colorVisualizer = 4087293278U,
			// Token: 0x04000F45 RID: 3909
			AutoRainbow = 1601700074U,
			// Token: 0x04000F46 RID: 3910
			Blueprint = 1751426142U,
			// Token: 0x04000F47 RID: 3911
			SkinDetailLightTexture = 3656780160U,
			// Token: 0x04000F48 RID: 3912
			GammaEnable = 1562232113U,
			// Token: 0x04000F49 RID: 3913
			PhongVisualizer = 2538956417U,
			// Token: 0x04000F4A RID: 3914
			samplerSunHaloTexture = 4209244470U,
			// Token: 0x04000F4B RID: 3915
			AmbientUVSelector = 2038402689U,
			// Token: 0x04000F4C RID: 3916
			kMaxSnowDepth = 3117182734U,
			// Token: 0x04000F4D RID: 3917
			blendMap2 = 2856451394U,
			// Token: 0x04000F4E RID: 3918
			blendMap3,
			// Token: 0x04000F4F RID: 3919
			blendMap4,
			// Token: 0x04000F50 RID: 3920
			blendMap5,
			// Token: 0x04000F51 RID: 3921
			diffuseProbeWeights = 1538657412U,
			// Token: 0x04000F52 RID: 3922
			EmissiveLightMultiplier = 2398559365U,
			// Token: 0x04000F53 RID: 3923
			SimAlphaTested = 3691477573U,
			// Token: 0x04000F54 RID: 3924
			blendMap6 = 2856451398U,
			// Token: 0x04000F55 RID: 3925
			SculptureMultiplierMap = 4166886831U,
			// Token: 0x04000F56 RID: 3926
			ObjectSnowSideTexture = 3369129541U,
			// Token: 0x04000F57 RID: 3927
			SkyDark = 3026287392U,
			// Token: 0x04000F58 RID: 3928
			Error = 1880695829U,
			// Token: 0x04000F59 RID: 3929
			OverrideFactor = 2385890496U,
			// Token: 0x04000F5A RID: 3930
			VertexAnimBlendWeights = 3360550072U,
			// Token: 0x04000F5B RID: 3931
			MeteorShadowTechnique = 2818678129U,
			// Token: 0x04000F5C RID: 3932
			HeatShimmerTexture = 1567719237U,
			// Token: 0x04000F5D RID: 3933
			DecalRadiusHalf = 690757321U,
			// Token: 0x04000F5E RID: 3934
			PuddleNoise = 1365564069U,
			// Token: 0x04000F5F RID: 3935
			ImpostorWater = 662501611U,
			// Token: 0x04000F60 RID: 3936
			CloudColorWRTSunDark1 = 3815083393U,
			// Token: 0x04000F61 RID: 3937
			CloudColorWRTSunDark2,
			// Token: 0x04000F62 RID: 3938
			TreeSnowParams = 3317160074U,
			// Token: 0x04000F63 RID: 3939
			SimShadow = 3427618522U,
			// Token: 0x04000F64 RID: 3940
			InteriorFadePlaceholder = 1528128722U,
			// Token: 0x04000F65 RID: 3941
			CurseLevel3 = 3787572492U,
			// Token: 0x04000F66 RID: 3942
			CurseLevel2,
			// Token: 0x04000F67 RID: 3943
			CurseLevel1,
			// Token: 0x04000F68 RID: 3944
			SpecStyle = 2505364495U,
			// Token: 0x04000F69 RID: 3945
			WallShadow = 2650378921U,
			// Token: 0x04000F6A RID: 3946
			Opacity = 2703972388U,
			// Token: 0x04000F6B RID: 3947
			shaderdebug = 3392560511U,
			// Token: 0x04000F6C RID: 3948
			samplerRedRampTexture = 3301773589U,
			// Token: 0x04000F6D RID: 3949
			samplerShadowMap = 2263750791U,
			// Token: 0x04000F6E RID: 3950
			ObjectWeatherParams = 2801179794U,
			// Token: 0x04000F6F RID: 3951
			LampColor = 1465698880U,
			// Token: 0x04000F70 RID: 3952
			CloudColorWRTHorizonDark1 = 2479131100U,
			// Token: 0x04000F71 RID: 3953
			SpecularMapSampler = 1532493904U,
			// Token: 0x04000F72 RID: 3954
			CloudTexture2 = 258742821U,
			// Token: 0x04000F73 RID: 3955
			CloudTexture1,
			// Token: 0x04000F74 RID: 3956
			SkyReflectionBlurry = 730673147U,
			// Token: 0x04000F75 RID: 3957
			CloudColorWRTHorizonDark2 = 2479131103U,
			// Token: 0x04000F76 RID: 3958
			FurMapTexture0 = 1354439057U,
			// Token: 0x04000F77 RID: 3959
			CloudVisibilityThreshold2 = 566642449U,
			// Token: 0x04000F78 RID: 3960
			CloudVisibilityThreshold1,
			// Token: 0x04000F79 RID: 3961
			weights1 = 1401067593U,
			// Token: 0x04000F7A RID: 3962
			highlightMultiplier = 639021210U,
			// Token: 0x04000F7B RID: 3963
			samplerDirtOverlay = 3912587800U,
			// Token: 0x04000F7C RID: 3964
			weights2 = 1401067594U,
			// Token: 0x04000F7D RID: 3965
			mixKeyCompositor = 2163679661U,
			// Token: 0x04000F7E RID: 3966
			LotPondFogOfExploration = 2294233893U,
			// Token: 0x04000F7F RID: 3967
			alphaCutoff = 1432359132U,
			// Token: 0x04000F80 RID: 3968
			PositionTweak = 4013347200U,
			// Token: 0x04000F81 RID: 3969
			LeafRockRustleRotations = 1275269806U,
			// Token: 0x04000F82 RID: 3970
			permGrad4dTexture = 2163872948U,
			// Token: 0x04000F83 RID: 3971
			ReadDepthBuffer = 1374044610U,
			// Token: 0x04000F84 RID: 3972
			DetailMap = 2449857192U,
			// Token: 0x04000F85 RID: 3973
			ShowPhysicallyUnroutableTerrain = 417458522U,
			// Token: 0x04000F86 RID: 3974
			instancePositions = 300348620U,
			// Token: 0x04000F87 RID: 3975
			DetailMapSampler = 609341896U,
			// Token: 0x04000F88 RID: 3976
			unlitLotTerrain = 2157565631U,
			// Token: 0x04000F89 RID: 3977
			FramesRandomStartFactor = 1913778767U,
			// Token: 0x04000F8A RID: 3978
			imposterHolidayLightsTexture = 1924604468U,
			// Token: 0x04000F8B RID: 3979
			SnowMeltingMap = 1132763248U,
			// Token: 0x04000F8C RID: 3980
			simCensor = 1231594616U,
			// Token: 0x04000F8D RID: 3981
			samplerCubeMap = 3701164938U,
			// Token: 0x04000F8E RID: 3982
			RedRampTexture = 67691519U,
			// Token: 0x04000F8F RID: 3983
			texMaskSampler = 4188156500U,
			// Token: 0x04000F90 RID: 3984
			ViewToClipSpaceMatrix = 3661701696U,
			// Token: 0x04000F91 RID: 3985
			PondImpostorMaker = 2127730741U,
			// Token: 0x04000F92 RID: 3986
			TerrainVisualization = 3314147908U,
			// Token: 0x04000F93 RID: 3987
			stairs = 1289942167U,
			// Token: 0x04000F94 RID: 3988
			BackFillColor = 3484544868U,
			// Token: 0x04000F95 RID: 3989
			CreateThumbnailR2Grey = 2913731322U,
			// Token: 0x04000F96 RID: 3990
			ClearOp = 2630952605U,
			// Token: 0x04000F97 RID: 3991
			samplerPaintMap_0 = 3008032540U,
			// Token: 0x04000F98 RID: 3992
			samplerPaintMap_1,
			// Token: 0x04000F99 RID: 3993
			samplerPaintMap_2,
			// Token: 0x04000F9A RID: 3994
			samplerPaintMap_3,
			// Token: 0x04000F9B RID: 3995
			gradTexture4d = 3136863806U,
			// Token: 0x04000F9C RID: 3996
			DirtOverlaySampler = 807412422U,
			// Token: 0x04000F9D RID: 3997
			LeavesInfoTexture = 272792970U,
			// Token: 0x04000F9E RID: 3998
			MuscleRegionMap = 1492415554U,
			// Token: 0x04000F9F RID: 3999
			RenderParticleTexture = 1477210548U,
			// Token: 0x04000FA0 RID: 4000
			shadererror = 2729029748U,
			// Token: 0x04000FA1 RID: 4001
			PoolWaterOutside = 1931887637U,
			// Token: 0x04000FA2 RID: 4002
			samplerIcePatchesTexture = 1427197371U,
			// Token: 0x04000FA3 RID: 4003
			ghost = 4023194814U,
			// Token: 0x04000FA4 RID: 4004
			LocalToLightSpaceMatrix = 78260348U,
			// Token: 0x04000FA5 RID: 4005
			RoadDetailMap = 674835910U,
			// Token: 0x04000FA6 RID: 4006
			Normal = 1160234136U,
			// Token: 0x04000FA7 RID: 4007
			OverlaySpecularProbe = 1333327502U,
			// Token: 0x04000FA8 RID: 4008
			CreateThumbnailR1 = 1324674956U,
			// Token: 0x04000FA9 RID: 4009
			samplerWindowFrostTexture = 19142084U,
			// Token: 0x04000FAA RID: 4010
			RainRipples = 4086475564U,
			// Token: 0x04000FAB RID: 4011
			BlitData = 195761524U,
			// Token: 0x04000FAC RID: 4012
			translucentTarget = 1738382669U,
			// Token: 0x04000FAD RID: 4013
			CreateThumbnailR2 = 1324674959U,
			// Token: 0x04000FAE RID: 4014
			casFur = 350109675U,
			// Token: 0x04000FAF RID: 4015
			samplerAOMap = 3693000351U,
			// Token: 0x04000FB0 RID: 4016
			ThumbnailAmbient = 4033384153U,
			// Token: 0x04000FB1 RID: 4017
			SourceUVScale = 1181586215U,
			// Token: 0x04000FB2 RID: 4018
			samplerExteriorSpecularLightProbe = 438157776U,
			// Token: 0x04000FB3 RID: 4019
			samplerDecalTexture1 = 3387547304U,
			// Token: 0x04000FB4 RID: 4020
			samplerDecalTexture0,
			// Token: 0x04000FB5 RID: 4021
			BurnNoise = 3008529920U,
			// Token: 0x04000FB6 RID: 4022
			VertexColorScale = 2734519242U,
			// Token: 0x04000FB7 RID: 4023
			samplerDecalTexture3 = 3387547306U,
			// Token: 0x04000FB8 RID: 4024
			samplerDecalTexture2,
			// Token: 0x04000FB9 RID: 4025
			samplerSpecularLightProbe = 3336159994U,
			// Token: 0x04000FBA RID: 4026
			ExteriorCeiling = 3534506260U,
			// Token: 0x04000FBB RID: 4027
			ObjectToWorldSpaceMatrix = 2934779398U,
			// Token: 0x04000FBC RID: 4028
			Gemstone = 1512671665U,
			// Token: 0x04000FBD RID: 4029
			SculptureOpaque = 2631268511U,
			// Token: 0x04000FBE RID: 4030
			unlit = 1939797779U,
			// Token: 0x04000FBF RID: 4031
			clipAlphaOpacity = 1780495220U,
			// Token: 0x04000FC0 RID: 4032
			WaterSunSpecular = 316965571U,
			// Token: 0x04000FC1 RID: 4033
			samplerterrain_detail = 870068622U,
			// Token: 0x04000FC2 RID: 4034
			SpecularProbeMultiplierTop = 1867918714U,
			// Token: 0x04000FC3 RID: 4035
			FramesSampler = 936821221U,
			// Token: 0x04000FC4 RID: 4036
			DiffuseUVSelector = 2448341759U,
			// Token: 0x04000FC5 RID: 4037
			Mask_Bias = 1772050107U,
			// Token: 0x04000FC6 RID: 4038
			ForceVector = 3953422971U,
			// Token: 0x04000FC7 RID: 4039
			ParticleLight = 3651724617U,
			// Token: 0x04000FC8 RID: 4040
			TerrainFog = 150254984U,
			// Token: 0x04000FC9 RID: 4041
			Specular = 752949314U,
			// Token: 0x04000FCA RID: 4042
			FloorGrid = 3863930045U,
			// Token: 0x04000FCB RID: 4043
			TerrainHighNoSnowElev = 1002944522U,
			// Token: 0x04000FCC RID: 4044
			samplerFurMapTexture0 = 2625458543U,
			// Token: 0x04000FCD RID: 4045
			samplerSourceTexture = 1904975497U,
			// Token: 0x04000FCE RID: 4046
			BasicShadowsReversedCull = 2181696726U,
			// Token: 0x04000FCF RID: 4047
			samplertranslucentTexture = 1170576725U,
			// Token: 0x04000FD0 RID: 4048
			samplerLevel3NormalMap = 3156163023U,
			// Token: 0x04000FD1 RID: 4049
			GhostHeightParams = 264861765U,
			// Token: 0x04000FD2 RID: 4050
			TimeData = 3916545370U,
			// Token: 0x04000FD3 RID: 4051
			PhongAlpha = 3645021331U,
			// Token: 0x04000FD4 RID: 4052
			TerrainLight_Indoor = 520572706U,
			// Token: 0x04000FD5 RID: 4053
			samplerroutingMap = 2176014015U,
			// Token: 0x04000FD6 RID: 4054
			SpecCompositeTexture = 3595762398U,
			// Token: 0x04000FD7 RID: 4055
			LightMapXform = 1347033551U,
			// Token: 0x04000FD8 RID: 4056
			routingMap = 2119479021U,
			// Token: 0x04000FD9 RID: 4057
			TwigTransitionMap = 1593080783U,
			// Token: 0x04000FDA RID: 4058
			samplerPuddleInfoPartialTexture = 2036892099U,
			// Token: 0x04000FDB RID: 4059
			samplerRainPuddleNoiseMap = 145807361U,
			// Token: 0x04000FDC RID: 4060
			samplerRainDrops = 3681208369U,
			// Token: 0x04000FDD RID: 4061
			texMap = 427735206U,
			// Token: 0x04000FDE RID: 4062
			OverrideVelocity = 342324600U,
			// Token: 0x04000FDF RID: 4063
			PickRug = 403832872U,
			// Token: 0x04000FE0 RID: 4064
			WorldToClipSpaceMatrix = 99907151U,
			// Token: 0x04000FE1 RID: 4065
			WavyControls = 3345837916U,
			// Token: 0x04000FE2 RID: 4066
			WallNormalToTangentMultiplier = 1344101455U,
			// Token: 0x04000FE3 RID: 4067
			SomeMask = 205658138U,
			// Token: 0x04000FE4 RID: 4068
			SunVector = 316642732U,
			// Token: 0x04000FE5 RID: 4069
			RoutableSurfaceOpacity = 678223031U,
			// Token: 0x04000FE6 RID: 4070
			ColorRampSampler = 955347306U,
			// Token: 0x04000FE7 RID: 4071
			samplerMuscleRegionMap = 3285663712U,
			// Token: 0x04000FE8 RID: 4072
			MeteorShadow = 2798361033U,
			// Token: 0x04000FE9 RID: 4073
			ghostEyes = 2357769384U,
			// Token: 0x04000FEA RID: 4074
			PoolImpostorColor = 3426546321U,
			// Token: 0x04000FEB RID: 4075
			PickParticle = 3524010628U,
			// Token: 0x04000FEC RID: 4076
			FillScreen = 1737227854U,
			// Token: 0x04000FED RID: 4077
			worldLeafMap = 981594867U,
			// Token: 0x04000FEE RID: 4078
			samplerFurMap = 759164780U,
			// Token: 0x04000FEF RID: 4079
			LightingRamp = 2926786901U,
			// Token: 0x04000FF0 RID: 4080
			Debug = 1031089514U,
			// Token: 0x04000FF1 RID: 4081
			ClipToWorldSpaceMatrix = 835670645U,
			// Token: 0x04000FF2 RID: 4082
			EmissionMap = 4077113682U,
			// Token: 0x04000FF3 RID: 4083
			colorMap = 3687987128U,
			// Token: 0x04000FF4 RID: 4084
			samplerTerrainSnowDiffuseMap = 3194391263U,
			// Token: 0x04000FF5 RID: 4085
			MultiplyMap = 3448150597U,
			// Token: 0x04000FF6 RID: 4086
			samplerGhostNoiseTexture = 1248082015U,
			// Token: 0x04000FF7 RID: 4087
			drawGreen = 420640668U,
			// Token: 0x04000FF8 RID: 4088
			WorldCursorTexture = 1196385938U,
			// Token: 0x04000FF9 RID: 4089
			samplerSkinDetailLightTexture = 700282222U,
			// Token: 0x04000FFA RID: 4090
			FloorShadows = 1973206000U,
			// Token: 0x04000FFB RID: 4091
			PlatformOffsetFactor = 1192428548U,
			// Token: 0x04000FFC RID: 4092
			samplerimposterTexture = 2113626643U,
			// Token: 0x04000FFD RID: 4093
			Vignette = 2599107363U,
			// Token: 0x04000FFE RID: 4094
			InteriorWallWithStrobelight = 1081237078U,
			// Token: 0x04000FFF RID: 4095
			RoomHideFactor = 4182990153U,
			// Token: 0x04001000 RID: 4096
			StarConstellationTexture = 3696295583U,
			// Token: 0x04001001 RID: 4097
			convolveWeights = 1302377892U,
			// Token: 0x04001002 RID: 4098
			ColorMapSampler = 1434167192U,
			// Token: 0x04001003 RID: 4099
			RunEffect = 3347346451U,
			// Token: 0x04001004 RID: 4100
			Trampoline = 960094356U,
			// Token: 0x04001005 RID: 4101
			texMaskMap = 3545772854U,
			// Token: 0x04001006 RID: 4102
			DistantTerrain = 3465375587U,
			// Token: 0x04001007 RID: 4103
			InteriorAOSIPlaceholder = 1309331052U,
			// Token: 0x04001008 RID: 4104
			imposterTextureAOandSI = 365548184U,
			// Token: 0x04001009 RID: 4105
			ScratchTexture = 1991880542U,
			// Token: 0x0400100A RID: 4106
			ThermalSim = 3053178723U,
			// Token: 0x0400100B RID: 4107
			SpecularAmount = 1360624094U,
			// Token: 0x0400100C RID: 4108
			FinMapTexture1 = 1368046288U,
			// Token: 0x0400100D RID: 4109
			FinMapTexture0,
			// Token: 0x0400100E RID: 4110
			TreeShadowCompositor = 1216048074U,
			// Token: 0x0400100F RID: 4111
			ObjectPlacementOutline = 3326974917U,
			// Token: 0x04001010 RID: 4112
			ImpostorColorGlow = 2522997504U,
			// Token: 0x04001011 RID: 4113
			SkinToneOp = 1135957219U,
			// Token: 0x04001012 RID: 4114
			SimPetFurPeelTexture = 171107487U,
			// Token: 0x04001013 RID: 4115
			Plumbob = 3740362084U,
			// Token: 0x04001014 RID: 4116
			WaterScrollSpeedLayer2 = 2946569269U,
			// Token: 0x04001015 RID: 4117
			WaterScrollSpeedLayer1,
			// Token: 0x04001016 RID: 4118
			tree = 3322072369U,
			// Token: 0x04001017 RID: 4119
			kDistantTransitionBias = 2409458469U,
			// Token: 0x04001018 RID: 4120
			InvisibleMeteor = 1871287018U,
			// Token: 0x04001019 RID: 4121
			ceilingLightmapScale = 1273787518U,
			// Token: 0x0400101A RID: 4122
			QuadScale = 1162143510U,
			// Token: 0x0400101B RID: 4123
			kHairTile = 368772596U,
			// Token: 0x0400101C RID: 4124
			Roof = 2077253475U,
			// Token: 0x0400101D RID: 4125
			UVTiling = 2000464773U,
			// Token: 0x0400101E RID: 4126
			samplercompositeMap = 358286310U,
			// Token: 0x0400101F RID: 4127
			HaloRamp = 2230771963U,
			// Token: 0x04001020 RID: 4128
			HighFreqWater = 1534278464U,
			// Token: 0x04001021 RID: 4129
			branchMain = 2779766762U,
			// Token: 0x04001022 RID: 4130
			ExteriorWalls = 3446109522U,
			// Token: 0x04001023 RID: 4131
			samplerSculptureMultiplierMap = 2560697761U,
			// Token: 0x04001024 RID: 4132
			Skirt = 4127577150U,
			// Token: 0x04001025 RID: 4133
			samplerparaboloidLookupTexture = 1955156179U,
			// Token: 0x04001026 RID: 4134
			LotPondWater = 3778569092U,
			// Token: 0x04001027 RID: 4135
			instanceOrientsAndHighlight = 1872076651U,
			// Token: 0x04001028 RID: 4136
			MaskMap = 703402985U,
			// Token: 0x04001029 RID: 4137
			samplerPondReflection = 286732529U,
			// Token: 0x0400102A RID: 4138
			InitialPaintsThickSnowWithCutout = 3055764414U,
			// Token: 0x0400102B RID: 4139
			permSampler2d = 2540335655U,
			// Token: 0x0400102C RID: 4140
			precipitationShadowTextureData = 2534619931U,
			// Token: 0x0400102D RID: 4141
			moon6 = 1111046144U,
			// Token: 0x0400102E RID: 4142
			moon7,
			// Token: 0x0400102F RID: 4143
			terrainAOSI = 2484382836U,
			// Token: 0x04001030 RID: 4144
			RugSort = 2422839209U,
			// Token: 0x04001031 RID: 4145
			moon4 = 1111046146U,
			// Token: 0x04001032 RID: 4146
			moon5,
			// Token: 0x04001033 RID: 4147
			moon2,
			// Token: 0x04001034 RID: 4148
			moon3,
			// Token: 0x04001035 RID: 4149
			samplerScratchTexture = 2889928260U,
			// Token: 0x04001036 RID: 4150
			Sky_Reflection = 2439531488U,
			// Token: 0x04001037 RID: 4151
			SkinToneOp_Index = 3737578530U,
			// Token: 0x04001038 RID: 4152
			RoadSnowTexture = 271150415U,
			// Token: 0x04001039 RID: 4153
			LotImposter = 1751129571U,
			// Token: 0x0400103A RID: 4154
			samplerAlbedoTexture = 3167691289U,
			// Token: 0x0400103B RID: 4155
			moon8 = 1111046158U,
			// Token: 0x0400103C RID: 4156
			WaterReflectionMap = 183441741U,
			// Token: 0x0400103D RID: 4157
			lodMixMap = 2706438182U,
			// Token: 0x0400103E RID: 4158
			CloudColorWRTShadow2 = 3364418304U,
			// Token: 0x0400103F RID: 4159
			worldBuilderBrushMap = 2250410538U,
			// Token: 0x04001040 RID: 4160
			PrecipitationParams = 3517359324U,
			// Token: 0x04001041 RID: 4161
			WaterColorTint = 461970800U,
			// Token: 0x04001042 RID: 4162
			PickSimFur = 2814424154U,
			// Token: 0x04001043 RID: 4163
			doFourBoneSkinning = 1696550909U,
			// Token: 0x04001044 RID: 4164
			VideoUVScale = 3975027455U,
			// Token: 0x04001045 RID: 4165
			NormalTexture = 999204177U,
			// Token: 0x04001046 RID: 4166
			RemappedChannelSelectOp = 1379088941U,
			// Token: 0x04001047 RID: 4167
			terrain_detail = 2032607260U,
			// Token: 0x04001048 RID: 4168
			screenRect = 1745494023U,
			// Token: 0x04001049 RID: 4169
			AmbientOcclusionMap = 2954672736U,
			// Token: 0x0400104A RID: 4170
			CASMap2Texture = 1342944353U,
			// Token: 0x0400104B RID: 4171
			SizeScaleEnd = 2300195123U,
			// Token: 0x0400104C RID: 4172
			Masked = 33263166U,
			// Token: 0x0400104D RID: 4173
			SculptureDiffuseMap = 1372743910U,
			// Token: 0x0400104E RID: 4174
			NormalMapScale = 1011213108U,
			// Token: 0x0400104F RID: 4175
			colorTexMapping = 4149612821U,
			// Token: 0x04001050 RID: 4176
			PoolWaterReflective = 3161534851U,
			// Token: 0x04001051 RID: 4177
			texSampler = 3183421956U,
			// Token: 0x04001052 RID: 4178
			fadeDownPlaceholder = 438096778U,
			// Token: 0x04001053 RID: 4179
			samplerBurnNoise = 948667766U,
			// Token: 0x04001054 RID: 4180
			Downsample = 1515299995U,
			// Token: 0x04001055 RID: 4181
			samplerThermalSimRamp = 1441679101U,
			// Token: 0x04001056 RID: 4182
			FurTextureDimensions = 662485542U,
			// Token: 0x04001057 RID: 4183
			DisableSnowXRay = 3398594850U,
			// Token: 0x04001058 RID: 4184
			HSVtoRGBShiftTexture = 26401953U,
			// Token: 0x04001059 RID: 4185
			simDropShadowTarget = 3478949698U,
			// Token: 0x0400105A RID: 4186
			samplerDistortionTexture = 489007991U,
			// Token: 0x0400105B RID: 4187
			GammaBlit = 2471643325U,
			// Token: 0x0400105C RID: 4188
			PlatformMinFilter = 569516042U,
			// Token: 0x0400105D RID: 4189
			InteriorPrecipitationFogParams = 2695522972U,
			// Token: 0x0400105E RID: 4190
			WorldToObjectSpaceMatrix = 3941051342U,
			// Token: 0x0400105F RID: 4191
			HaloRampSampler = 3560459481U,
			// Token: 0x04001060 RID: 4192
			kFinOffsets = 428718301U,
			// Token: 0x04001061 RID: 4193
			CutoutValidHeights = 1833162679U,
			// Token: 0x04001062 RID: 4194
			ContourSmoothing = 505928909U,
			// Token: 0x04001063 RID: 4195
			TreeFallColor1 = 196471308U,
			// Token: 0x04001064 RID: 4196
			TreeFallColor0,
			// Token: 0x04001065 RID: 4197
			Rug = 712161697U,
			// Token: 0x04001066 RID: 4198
			occluderviz = 2903136975U,
			// Token: 0x04001067 RID: 4199
			samplerBurnTexture = 4034553545U,
			// Token: 0x04001068 RID: 4200
			samplerRoadDetailMap = 82755492U,
			// Token: 0x04001069 RID: 4201
			WaterNoiseMap = 3635492234U,
			// Token: 0x0400106A RID: 4202
			PuddleInfoTexture = 3848666386U,
			// Token: 0x0400106B RID: 4203
			JetTexture = 1389240603U,
			// Token: 0x0400106C RID: 4204
			PassThrough = 2804736953U,
			// Token: 0x0400106D RID: 4205
			ColorRamp = 1477981654U,
			// Token: 0x0400106E RID: 4206
			Bloom = 3934470626U,
			// Token: 0x0400106F RID: 4207
			SnowFences = 1061190990U,
			// Token: 0x04001070 RID: 4208
			samplerLeavesInfoTexture = 1906397048U,
			// Token: 0x04001071 RID: 4209
			SimSkinVisualizer = 2526618029U,
			// Token: 0x04001072 RID: 4210
			EmissionMapUVSelector = 3162652124U,
			// Token: 0x04001073 RID: 4211
			samplerLeavesDensity = 1757220165U,
			// Token: 0x04001074 RID: 4212
			DeformerOffset = 2346665798U,
			// Token: 0x04001075 RID: 4213
			Blit = 1661379836U,
			// Token: 0x04001076 RID: 4214
			PostProcess = 3975098250U,
			// Token: 0x04001077 RID: 4215
			SunHaloTexture = 3891377612U,
			// Token: 0x04001078 RID: 4216
			SinkCutout = 1072125132U,
			// Token: 0x04001079 RID: 4217
			PoolAnimationData = 147306687U,
			// Token: 0x0400107A RID: 4218
			samplerMaskMap = 2256093375U,
			// Token: 0x0400107B RID: 4219
			ProbeGenerationTweaks = 1870709744U,
			// Token: 0x0400107C RID: 4220
			lightPosition = 2268590202U,
			// Token: 0x0400107D RID: 4221
			rainPuddle2Target = 1784620324U,
			// Token: 0x0400107E RID: 4222
			RGBToYCbCr = 37147598U,
			// Token: 0x0400107F RID: 4223
			Text = 2972449336U,
			// Token: 0x04001080 RID: 4224
			SpecularUVScale = 4046333891U,
			// Token: 0x04001081 RID: 4225
			HorizonDark = 519766922U,
			// Token: 0x04001082 RID: 4226
			TerrainSnowNormalMap = 1120712358U,
			// Token: 0x04001083 RID: 4227
			TangentMap = 19781230U,
			// Token: 0x04001084 RID: 4228
			SnowDoorNormalMap = 73685821U,
			// Token: 0x04001085 RID: 4229
			samplerBlueRampTexture = 2946159368U,
			// Token: 0x04001086 RID: 4230
			LightScalars = 1998584090U,
			// Token: 0x04001087 RID: 4231
			FullBright = 351941470U,
			// Token: 0x04001088 RID: 4232
			LightProbe = 1494410015U,
			// Token: 0x04001089 RID: 4233
			VisibleOnlyAtNight = 2891778690U,
			// Token: 0x0400108A RID: 4234
			LightProbeDebug = 266479024U,
			// Token: 0x0400108B RID: 4235
			samplerPoolNormalMap2 = 3133180280U,
			// Token: 0x0400108C RID: 4236
			NoiseAndMipScaleUV = 3993006809U,
			// Token: 0x0400108D RID: 4237
			samplercolorMap = 1918903378U,
			// Token: 0x0400108E RID: 4238
			samplerPoolNormalMap1 = 3133180283U,
			// Token: 0x0400108F RID: 4239
			HairRegion = 2665299285U,
			// Token: 0x04001090 RID: 4240
			Clouds = 3464232719U,
			// Token: 0x04001091 RID: 4241
			samplerLotWeatherDataMap = 2742514606U,
			// Token: 0x04001092 RID: 4242
			ShadowDebug = 2280219698U,
			// Token: 0x04001093 RID: 4243
			samplerrainPuddleScratchTexture = 128238630U,
			// Token: 0x04001094 RID: 4244
			PickSeaWater = 2825848700U,
			// Token: 0x04001095 RID: 4245
			samplerIridescenceMap = 1910274409U,
			// Token: 0x04001096 RID: 4246
			MinspecLightData = 616368618U,
			// Token: 0x04001097 RID: 4247
			ExteriorWall = 232566523U,
			// Token: 0x04001098 RID: 4248
			ThermalSimRamp = 2627615575U,
			// Token: 0x04001099 RID: 4249
			boundarySlope = 409402812U,
			// Token: 0x0400109A RID: 4250
			samplerIceNoise = 2219229982U,
			// Token: 0x0400109B RID: 4251
			ClothingSpecularColor = 2470967011U,
			// Token: 0x0400109C RID: 4252
			ParticleAnimFullbright = 357980155U,
			// Token: 0x0400109D RID: 4253
			kScreenPixels = 369885363U,
			// Token: 0x0400109E RID: 4254
			DynamicParticleJetRateControl = 1034514584U,
			// Token: 0x0400109F RID: 4255
			uvRect = 1900733298U,
			// Token: 0x040010A0 RID: 4256
			VideoUTexture = 2152637676U,
			// Token: 0x040010A1 RID: 4257
			heightMapLM = 760169219U,
			// Token: 0x040010A2 RID: 4258
			mirror = 2039020852U,
			// Token: 0x040010A3 RID: 4259
			Walls = 2538584648U,
			// Token: 0x040010A4 RID: 4260
			TreeLocations = 2587947303U,
			// Token: 0x040010A5 RID: 4261
			StyleSamplerPoint = 522463426U,
			// Token: 0x040010A6 RID: 4262
			samplerOpacityMap = 2842734296U,
			// Token: 0x040010A7 RID: 4263
			DecalCenters2X = 999466020U,
			// Token: 0x040010A8 RID: 4264
			samplerDualSkinToneMap = 2493030928U,
			// Token: 0x040010A9 RID: 4265
			SkyMoonTexture = 2355351492U,
			// Token: 0x040010AA RID: 4266
			HolidayLights = 1738189900U,
			// Token: 0x040010AB RID: 4267
			RainDrops = 3632249175U,
			// Token: 0x040010AC RID: 4268
			RabbitHoleMediumDetail = 2933813509U,
			// Token: 0x040010AD RID: 4269
			morphWeights = 537939508U,
			// Token: 0x040010AE RID: 4270
			PondWater = 428202305U,
			// Token: 0x040010AF RID: 4271
			NormalMap = 1851151498U,
			// Token: 0x040010B0 RID: 4272
			ReflectionParams = 3720624904U,
			// Token: 0x040010B1 RID: 4273
			InitialPaintsThickSnow = 1639283126U,
			// Token: 0x040010B2 RID: 4274
			SkinSecondaryNormalTexture = 3956372046U,
			// Token: 0x040010B3 RID: 4275
			moon = 3128647858U,
			// Token: 0x040010B4 RID: 4276
			samplerLeavesTexture1 = 1503621281U,
			// Token: 0x040010B5 RID: 4277
			Light0ToWorldSpaceMatrix = 192735663U,
			// Token: 0x040010B6 RID: 4278
			samplerLeavesTexture2 = 1503621282U,
			// Token: 0x040010B7 RID: 4279
			samplerLeavesTexture3,
			// Token: 0x040010B8 RID: 4280
			TerrainSnowDiffuseMap = 376829153U,
			// Token: 0x040010B9 RID: 4281
			samplerObjOutlineTexture = 2699697437U,
			// Token: 0x040010BA RID: 4282
			SharpSpecularLightProbe = 1042813650U,
			// Token: 0x040010BB RID: 4283
			ImpostorHelper = 1276206150U,
			// Token: 0x040010BC RID: 4284
			samplerSkyReflectionForRain = 2785782160U,
			// Token: 0x040010BD RID: 4285
			samplerWorldCursorTexture = 2645005624U,
			// Token: 0x040010BE RID: 4286
			Additive = 1525770033U,
			// Token: 0x040010BF RID: 4287
			samplerworldLeafMap = 3682472181U,
			// Token: 0x040010C0 RID: 4288
			staticterrain = 3764097450U,
			// Token: 0x040010C1 RID: 4289
			HasTwigTexture = 4028887545U,
			// Token: 0x040010C2 RID: 4290
			IceNoise = 3983569508U,
			// Token: 0x040010C3 RID: 4291
			WallFloorSpecularProbe = 548501280U,
			// Token: 0x040010C4 RID: 4292
			NoiseMapScale = 1585897121U,
			// Token: 0x040010C5 RID: 4293
			samplerSecondaryNormalMap = 3391432192U,
			// Token: 0x040010C6 RID: 4294
			billboardDepth = 2681239809U,
			// Token: 0x040010C7 RID: 4295
			CasSimHair = 4244114657U,
			// Token: 0x040010C8 RID: 4296
			jointMatrix = 3279738680U,
			// Token: 0x040010C9 RID: 4297
			ChannelSelectOp_Select = 1523361206U,
			// Token: 0x040010CA RID: 4298
			LeavesNoise = 2067691501U,
			// Token: 0x040010CB RID: 4299
			InitialPaintsSnowMelting = 476801353U,
			// Token: 0x040010CC RID: 4300
			Precipitation = 3806582394U,
			// Token: 0x040010CD RID: 4301
			PickWallsWithCutout = 3472310297U,
			// Token: 0x040010CE RID: 4302
			instanced = 213397176U,
			// Token: 0x040010CF RID: 4303
			translucentTexture = 1975351315U,
			// Token: 0x040010D0 RID: 4304
			IceCracksNormalMap = 1645434956U,
			// Token: 0x040010D1 RID: 4305
			PoolWaterReflectiveOutside = 3544615992U,
			// Token: 0x040010D2 RID: 4306
			scratchTextureOffsets = 3545327806U,
			// Token: 0x040010D3 RID: 4307
			InstancedImpostorColor = 3886800540U,
			// Token: 0x040010D4 RID: 4308
			samplerSkinOverlayTexture = 818203385U,
			// Token: 0x040010D5 RID: 4309
			simBlobShadowTexture = 2493033376U,
			// Token: 0x040010D6 RID: 4310
			SkinNormalTexture = 1378014460U,
			// Token: 0x040010D7 RID: 4311
			Light0AzimuthTrig = 532030593U,
			// Token: 0x040010D8 RID: 4312
			VisualizerControl = 1332189668U,
			// Token: 0x040010D9 RID: 4313
			HolidayLightColor = 1428673466U,
			// Token: 0x040010DA RID: 4314
			puddle = 2003927601U,
			// Token: 0x040010DB RID: 4315
			SimSimpleBlobShadow = 3779311925U,
			// Token: 0x040010DC RID: 4316
			ExteriorWallShadow = 939244775U,
			// Token: 0x040010DD RID: 4317
			SpecularMap = 2907867744U,
			// Token: 0x040010DE RID: 4318
			samplerNoiseMap = 1299830423U,
			// Token: 0x040010DF RID: 4319
			samplerrainPuddle1Texture = 2972944519U,
			// Token: 0x040010E0 RID: 4320
			SingleObject = 1522927548U,
			// Token: 0x040010E1 RID: 4321
			Level1NormalMap = 376395543U,
			// Token: 0x040010E2 RID: 4322
			SkinMatrices = 2061832034U,
			// Token: 0x040010E3 RID: 4323
			LotWeatherDataMap = 4214727620U,
			// Token: 0x040010E4 RID: 4324
			PosScale = 1215711461U,
			// Token: 0x040010E5 RID: 4325
			CASLightMapDimensions = 663428653U,
			// Token: 0x040010E6 RID: 4326
			SkinnedShadow = 2348054335U,
			// Token: 0x040010E7 RID: 4327
			SkinToneRampSampler = 2948599082U,
			// Token: 0x040010E8 RID: 4328
			puddleIndoor = 3631030720U,
			// Token: 0x040010E9 RID: 4329
			kTerrainWetnessDarkening = 1821526467U,
			// Token: 0x040010EA RID: 4330
			RoadsCompositor = 2089498513U,
			// Token: 0x040010EB RID: 4331
			AOandSI = 3930322584U,
			// Token: 0x040010EC RID: 4332
			PrecipitationFogParams = 2172405988U,
			// Token: 0x040010ED RID: 4333
			RefractionDistortionScale = 3284431521U,
			// Token: 0x040010EE RID: 4334
			SkinToneIndex = 3647343526U,
			// Token: 0x040010EF RID: 4335
			BlurrySpecProbeSampler = 3812694150U,
			// Token: 0x040010F0 RID: 4336
			TerrainLow = 148681086U,
			// Token: 0x040010F1 RID: 4337
			Tiberium = 3960883458U,
			// Token: 0x040010F2 RID: 4338
			tbops = 2743577813U,
			// Token: 0x040010F3 RID: 4339
			DropShadow = 3231479170U,
			// Token: 0x040010F4 RID: 4340
			DecalTechnique = 1336778794U,
			// Token: 0x040010F5 RID: 4341
			VertexLightColors = 1118466393U,
			// Token: 0x040010F6 RID: 4342
			GhostNoiseTexture = 1052543461U,
			// Token: 0x040010F7 RID: 4343
			samplerPuddleNoise = 641282319U,
			// Token: 0x040010F8 RID: 4344
			NormalMapUVSelector = 1095985332U,
			// Token: 0x040010F9 RID: 4345
			samplerRoadNormalMap = 1162344310U,
			// Token: 0x040010FA RID: 4346
			DecalColor3 = 4289967820U,
			// Token: 0x040010FB RID: 4347
			FillColor = 1371990035U,
			// Token: 0x040010FC RID: 4348
			DecalColor2 = 4289967821U,
			// Token: 0x040010FD RID: 4349
			DecalColor1,
			// Token: 0x040010FE RID: 4350
			GhostFilterColor = 1191773817U,
			// Token: 0x040010FF RID: 4351
			DecalColor0 = 4289967823U,
			// Token: 0x04001100 RID: 4352
			XrayCursorParams = 4257841913U,
			// Token: 0x04001101 RID: 4353
			samplerStarNoiseCubemap = 4192355026U,
			// Token: 0x04001102 RID: 4354
			SimPetFurOpaque = 4195527549U,
			// Token: 0x04001103 RID: 4355
			billboard = 4277232958U,
			// Token: 0x04001104 RID: 4356
			PoolPick = 1665568536U,
			// Token: 0x04001105 RID: 4357
			samplerTwigDiffuseMap = 443464040U,
			// Token: 0x04001106 RID: 4358
			DrawRipples = 1756077340U,
			// Token: 0x04001107 RID: 4359
			SeaWaterEdit = 1031641607U,
			// Token: 0x04001108 RID: 4360
			PickInstanced = 3071771241U,
			// Token: 0x04001109 RID: 4361
			RoofImpostorColor = 1579794957U,
			// Token: 0x0400110A RID: 4362
			samplerCASDiffuseProbeTexture = 3936714819U,
			// Token: 0x0400110B RID: 4363
			ScratchTarget = 1207485594U,
			// Token: 0x0400110C RID: 4364
			samplerCutoutMap = 2214271075U,
			// Token: 0x0400110D RID: 4365
			SkinSpecularColor = 3458267398U,
			// Token: 0x0400110E RID: 4366
			samplerSkyNightStarsFlat = 1924598146U,
			// Token: 0x0400110F RID: 4367
			Subtractive = 187116741U,
			// Token: 0x04001110 RID: 4368
			Landmark = 2321594729U,
			// Token: 0x04001111 RID: 4369
			ValueRampTexture = 1965152693U,
			// Token: 0x04001112 RID: 4370
			prelimThumbs = 232300437U,
			// Token: 0x04001113 RID: 4371
			samplerBloodMap = 900639573U,
			// Token: 0x04001114 RID: 4372
			CloudColorWRTHorizonLight2 = 1100534389U,
			// Token: 0x04001115 RID: 4373
			GlassForObjectsTranslucent = 2224877601U,
			// Token: 0x04001116 RID: 4374
			CloudColorWRTHorizonLight1 = 1100534390U,
			// Token: 0x04001117 RID: 4375
			PickWater = 3238484239U,
			// Token: 0x04001118 RID: 4376
			TreeFallVariation = 2249913657U,
			// Token: 0x04001119 RID: 4377
			AdjustedDominantSkyLightVector = 1463514755U,
			// Token: 0x0400111A RID: 4378
			ObjOutlineRefPoint = 2265217665U,
			// Token: 0x0400111B RID: 4379
			samplerCurvedPoolPreviewTexture = 2269092575U,
			// Token: 0x0400111C RID: 4380
			LotWeatherDataMapScale = 4124885954U,
			// Token: 0x0400111D RID: 4381
			screenSpaceAdjust = 997344944U,
			// Token: 0x0400111E RID: 4382
			samplerSkinToneRampTexture = 3911334689U,
			// Token: 0x0400111F RID: 4383
			NormalBumpScale = 2294696674U,
			// Token: 0x04001120 RID: 4384
			DiffuseLightProbe = 3602343775U,
			// Token: 0x04001121 RID: 4385
			positionMapping2D = 3167100156U,
			// Token: 0x04001122 RID: 4386
			RenderParticleNormal = 3080657182U,
			// Token: 0x04001123 RID: 4387
			samplerObjectSnowEdgeTexture = 641204613U,
			// Token: 0x04001124 RID: 4388
			PeelMapTexture = 1793388708U,
			// Token: 0x04001125 RID: 4389
			InstancedShadowCaster = 1801508576U,
			// Token: 0x04001126 RID: 4390
			IridescenceMap = 3429955163U,
			// Token: 0x04001127 RID: 4391
			CloserSeaWaterReflectivePlaceholder = 630913961U,
			// Token: 0x04001128 RID: 4392
			Particle = 1839757979U,
			// Token: 0x04001129 RID: 4393
			RevealMap = 4092734148U,
			// Token: 0x0400112A RID: 4394
			PondReflection = 2539270803U,
			// Token: 0x0400112B RID: 4395
			SpeedStretchFactor = 1715965992U,
			// Token: 0x0400112C RID: 4396
			SimPetFace = 2477920454U,
			// Token: 0x0400112D RID: 4397
			blendMap = 1032205008U,
			// Token: 0x0400112E RID: 4398
			LightMap = 3849776951U,
			// Token: 0x0400112F RID: 4399
			WaterCausticsMap = 3388806677U,
			// Token: 0x04001130 RID: 4400
			Bubble = 3835649095U,
			// Token: 0x04001131 RID: 4401
			CurseFaceTexture = 334577795U,
			// Token: 0x04001132 RID: 4402
			WorldBuilderGridParams = 566259114U,
			// Token: 0x04001133 RID: 4403
			samplerRevealMap = 2360753994U,
			// Token: 0x04001134 RID: 4404
			BurnInfoTexture = 2303118275U,
			// Token: 0x04001135 RID: 4405
			AlbedoTexture = 2822410159U,
			// Token: 0x04001136 RID: 4406
			ColorBias = 2791328401U,
			// Token: 0x04001137 RID: 4407
			ColorSampler = 2600383118U,
			// Token: 0x04001138 RID: 4408
			LowFreqWater = 3960732740U,
			// Token: 0x04001139 RID: 4409
			fence = 1729134568U,
			// Token: 0x0400113A RID: 4410
			ClothingShininess = 2770011695U,
			// Token: 0x0400113B RID: 4411
			thumbnailViewportAdjust = 2712614036U,
			// Token: 0x0400113C RID: 4412
			GameTimeData = 902075060U,
			// Token: 0x0400113D RID: 4413
			RippleSpeed = 1390329968U,
			// Token: 0x0400113E RID: 4414
			samplerMoonHaloTexture = 3475412307U,
			// Token: 0x0400113F RID: 4415
			FloorThickness = 4274312745U,
			// Token: 0x04001140 RID: 4416
			SpecCompositeSampler = 2884116435U,
			// Token: 0x04001141 RID: 4417
			PickLotTerrainAndFloors = 2594042804U,
			// Token: 0x04001142 RID: 4418
			FloorEdgeHighlightMultiplier = 3271027415U,
			// Token: 0x04001143 RID: 4419
			thumbnailUVScale = 2057712168U,
			// Token: 0x04001144 RID: 4420
			WorldToLotTransAndLotScale = 1942617509U,
			// Token: 0x04001145 RID: 4421
			NoiseVolumeMap = 3413229947U,
			// Token: 0x04001146 RID: 4422
			TerrainGeomorphDistances = 2877903393U,
			// Token: 0x04001147 RID: 4423
			FailBlurry = 3969241541U,
			// Token: 0x04001148 RID: 4424
			VertexColor = 3012624812U,
			// Token: 0x04001149 RID: 4425
			compositeMap = 2350722644U,
			// Token: 0x0400114A RID: 4426
			DiffuseSampler = 3808597855U,
			// Token: 0x0400114B RID: 4427
			StaticTerrainCompositorPacked = 1499390745U,
			// Token: 0x0400114C RID: 4428
			TerrainLightAndFog = 3141364157U,
			// Token: 0x0400114D RID: 4429
			BillboardLightColorAndAmbientScalar = 4230936906U,
			// Token: 0x0400114E RID: 4430
			AlphaMaskThreshold = 3883543392U,
			// Token: 0x0400114F RID: 4431
			BlitCube = 3989054499U,
			// Token: 0x04001150 RID: 4432
			rainPuddle2Texture = 435537592U,
			// Token: 0x04001151 RID: 4433
			PointSampleBlitOp = 3277311211U,
			// Token: 0x04001152 RID: 4434
			InteriorBuildingAmbientColor = 2011076600U,
			// Token: 0x04001153 RID: 4435
			RoadNormalMap = 3164611260U,
			// Token: 0x04001154 RID: 4436
			RoofImpostorLighting = 3407089996U,
			// Token: 0x04001155 RID: 4437
			ObjOutlineUVScale = 1287390399U,
			// Token: 0x04001156 RID: 4438
			tanBlendData = 2932083787U,
			// Token: 0x04001157 RID: 4439
			SecondaryNormalMap = 3751256782U,
			// Token: 0x04001158 RID: 4440
			RotAxis = 2372404711U,
			// Token: 0x04001159 RID: 4441
			roads = 1577763374U,
			// Token: 0x0400115A RID: 4442
			OpacityMap = 1809831238U,
			// Token: 0x0400115B RID: 4443
			BurnedWindowGlass = 2616257575U,
			// Token: 0x0400115C RID: 4444
			normalTexMapping = 2028447707U,
			// Token: 0x0400115D RID: 4445
			Composite_UVScale = 4090242886U,
			// Token: 0x0400115E RID: 4446
			Window = 2330457189U,
			// Token: 0x0400115F RID: 4447
			WorldSpaceCameraPosition = 2153279147U,
			// Token: 0x04001160 RID: 4448
			CutoutMap = 1229021669U,
			// Token: 0x04001161 RID: 4449
			LightMapScale = 1333644187U,
			// Token: 0x04001162 RID: 4450
			SparkleMap = 4212995461U,
			// Token: 0x04001163 RID: 4451
			samplerSinkCutout = 375551978U,
			// Token: 0x04001164 RID: 4452
			samplerSharpSpecularLightProbe = 1818578092U,
			// Token: 0x04001165 RID: 4453
			SpecularProbeMultiplierBottom = 3958055280U,
			// Token: 0x04001166 RID: 4454
			ShadowCaster = 1241971045U,
			// Token: 0x04001167 RID: 4455
			BurnTexture = 1075802547U,
			// Token: 0x04001168 RID: 4456
			AmbientDomeExterior = 2560950604U,
			// Token: 0x04001169 RID: 4457
			Dummy = 4079084883U,
			// Token: 0x0400116A RID: 4458
			tapPositions = 1246112304U,
			// Token: 0x0400116B RID: 4459
			NoiseMap = 3785348473U,
			// Token: 0x0400116C RID: 4460
			VideoCapture = 3282567376U,
			// Token: 0x0400116D RID: 4461
			samplerSkinRampTexture = 2972838721U,
			// Token: 0x0400116E RID: 4462
			samplerCASSpecProbeTexture = 431658028U,
			// Token: 0x0400116F RID: 4463
			LargeObjectBody = 2168717531U,
			// Token: 0x04001170 RID: 4464
			ExteriorWallAOSI = 1721780835U,
			// Token: 0x04001171 RID: 4465
			CASMap1Target = 492251788U,
			// Token: 0x04001172 RID: 4466
			Level12NormalScale = 2642410897U,
			// Token: 0x04001173 RID: 4467
			permGradTexture = 3824792884U,
			// Token: 0x04001174 RID: 4468
			cubeMapTexture = 1016436813U,
			// Token: 0x04001175 RID: 4469
			CounterMatrixRow1 = 519595357U,
			// Token: 0x04001176 RID: 4470
			CounterMatrixRow2,
			// Token: 0x04001177 RID: 4471
			NormalSamplerLM = 2869052961U,
			// Token: 0x04001178 RID: 4472
			ClipMultiplier = 2796530430U,
			// Token: 0x04001179 RID: 4473
			WorldToPrecipitationShadowMatrix = 1997118526U,
			// Token: 0x0400117A RID: 4474
			kStandardFurLength = 2366993110U,
			// Token: 0x0400117B RID: 4475
			TireTracksIntersectionTextureD = 2003258515U,
			// Token: 0x0400117C RID: 4476
			LocalToClipSpaceMatrix = 3021671076U,
			// Token: 0x0400117D RID: 4477
			Day = 311764537U,
			// Token: 0x0400117E RID: 4478
			RemapDirection = 2308666795U,
			// Token: 0x0400117F RID: 4479
			TireTracksIntersectionTextureN = 2003258521U,
			// Token: 0x04001180 RID: 4480
			DropShadowAtlas2 = 2653448759U,
			// Token: 0x04001181 RID: 4481
			Phong = 3104856685U,
			// Token: 0x04001182 RID: 4482
			ThumbnailShadowPlane = 3543067771U,
			// Token: 0x04001183 RID: 4483
			pickFloor = 2657118612U,
			// Token: 0x04001184 RID: 4484
			samplerIceCracksTexture = 2760906754U,
			// Token: 0x04001185 RID: 4485
			GhostColor1 = 3791276380U,
			// Token: 0x04001186 RID: 4486
			GhostColor2 = 3791276383U,
			// Token: 0x04001187 RID: 4487
			SelfIlluminationMap = 1845917012U,
			// Token: 0x04001188 RID: 4488
			Level3NormalMap = 4138064157U,
			// Token: 0x04001189 RID: 4489
			samplerNormalMap = 372949932U,
			// Token: 0x0400118A RID: 4490
			FailCopyImage = 2844094733U,
			// Token: 0x0400118B RID: 4491
			samplerOverlaySpec = 2766674356U,
			// Token: 0x0400118C RID: 4492
			shadowTextureData = 247640034U,
			// Token: 0x0400118D RID: 4493
			staticTerrainLowLOD = 1094545489U,
			// Token: 0x0400118E RID: 4494
			VertexLightDirections = 2833033335U,
			// Token: 0x0400118F RID: 4495
			SimDropShadow = 394646129U,
			// Token: 0x04001190 RID: 4496
			Shininess = 4149606399U,
			// Token: 0x04001191 RID: 4497
			DivetScale = 3465315089U,
			// Token: 0x04001192 RID: 4498
			samplerrainPuddleNormalsTexture = 2566935112U,
			// Token: 0x04001193 RID: 4499
			casSkinShadowData = 1372852987U,
			// Token: 0x04001194 RID: 4500
			CurvedPoolPreview = 908168080U,
			// Token: 0x04001195 RID: 4501
			samplerSnowMeltingMap = 3598928714U,
			// Token: 0x04001196 RID: 4502
			HaloHighColor = 3557044824U,
			// Token: 0x04001197 RID: 4503
			thumbnailUVOffsets = 3000436918U,
			// Token: 0x04001198 RID: 4504
			WindStrength = 3158975812U,
			// Token: 0x04001199 RID: 4505
			RenderSHToCubeSpecularAlpha = 1752372425U,
			// Token: 0x0400119A RID: 4506
			PickParticleClipAlpha = 3812538918U,
			// Token: 0x0400119B RID: 4507
			AmbientDomeBottom = 3297098375U,
			// Token: 0x0400119C RID: 4508
			TimelineLength = 8498840U,
			// Token: 0x0400119D RID: 4509
			DetailSampler = 4229070334U,
			// Token: 0x0400119E RID: 4510
			PointSampleBlitMap = 1228658832U,
			// Token: 0x0400119F RID: 4511
			PaintUVScale = 3068778160U,
			// Token: 0x040011A0 RID: 4512
			SimSkin = 1417909433U,
			// Token: 0x040011A1 RID: 4513
			samplerRoadSnowTexture = 3158412513U,
			// Token: 0x040011A2 RID: 4514
			SnowUnderTreesNormalMap = 1038496074U,
			// Token: 0x040011A3 RID: 4515
			SimBaseHeight = 4003055252U,
			// Token: 0x040011A4 RID: 4516
			terrainLightFog = 1777043172U,
			// Token: 0x040011A5 RID: 4517
			samplerDiffuseLightProbe = 756068553U,
			// Token: 0x040011A6 RID: 4518
			kDistantNormalMapScale = 1002568330U,
			// Token: 0x040011A7 RID: 4519
			ParticleJet = 4284377352U,
			// Token: 0x040011A8 RID: 4520
			SourceTexture = 2558513599U,
			// Token: 0x040011A9 RID: 4521
			LotSkirtThumbnail = 505040989U,
			// Token: 0x040011AA RID: 4522
			AmbientDomeTop = 3590790035U,
			// Token: 0x040011AB RID: 4523
			BounceAmountMeters = 3629395339U,
			// Token: 0x040011AC RID: 4524
			LotTerrainImposterMaker = 2933950704U,
			// Token: 0x040011AD RID: 4525
			GlassForObjects = 1227803260U,
			// Token: 0x040011AE RID: 4526
			LeavesTexture2 = 3975829560U,
			// Token: 0x040011AF RID: 4527
			SnowFloorEdges = 2917732192U,
			// Token: 0x040011B0 RID: 4528
			LeavesTexture3 = 3975829561U,
			// Token: 0x040011B1 RID: 4529
			StyleSampler = 2457615152U,
			// Token: 0x040011B2 RID: 4530
			RippleDistanceScale = 3434306456U,
			// Token: 0x040011B3 RID: 4531
			samplerCloudTexture1 = 1286193224U,
			// Token: 0x040011B4 RID: 4532
			LeavesTexture1 = 3975829563U,
			// Token: 0x040011B5 RID: 4533
			samplerWaterCausticsMap = 1427153615U,
			// Token: 0x040011B6 RID: 4534
			MeteorShadowAnimationData2 = 2739375657U,
			// Token: 0x040011B7 RID: 4535
			rainPuddleScratchTexture = 735463696U,
			// Token: 0x040011B8 RID: 4536
			TangentUVScale = 3919384149U,
			// Token: 0x040011B9 RID: 4537
			FrostMap = 3435404841U,
			// Token: 0x040011BA RID: 4538
			LeavesTile = 3407441397U,
			// Token: 0x040011BB RID: 4539
			CASRoom = 2495195189U,
			// Token: 0x040011BC RID: 4540
			frond = 1260494882U,
			// Token: 0x040011BD RID: 4541
			Painting = 2856933409U,
			// Token: 0x040011BE RID: 4542
			simoverlay = 3573046578U,
			// Token: 0x040011BF RID: 4543
			samplerSpecCompositeTexture = 3076313556U,
			// Token: 0x040011C0 RID: 4544
			samplersimBlobShadowTexture = 2096244674U,
			// Token: 0x040011C1 RID: 4545
			rainPuddleScratchTarget = 4083641148U,
			// Token: 0x040011C2 RID: 4546
			SimPetFur = 2811195844U,
			// Token: 0x040011C3 RID: 4547
			WorldToLotTrig = 1678902475U,
			// Token: 0x040011C4 RID: 4548
			samplerGreenRampTexture = 2915455397U,
			// Token: 0x040011C5 RID: 4549
			UndergroundBackdrop = 1022430850U,
			// Token: 0x040011C6 RID: 4550
			samplerSnowUnderTreesNormalMap = 1840453628U,
			// Token: 0x040011C7 RID: 4551
			samplerSparkleCube = 3731349816U,
			// Token: 0x040011C8 RID: 4552
			TerrainNormals = 2605307208U,
			// Token: 0x040011C9 RID: 4553
			oneOver256 = 1132547544U,
			// Token: 0x040011CA RID: 4554
			DeflectionThreshold = 2103582049U,
			// Token: 0x040011CB RID: 4555
			gemstones = 2690892240U,
			// Token: 0x040011CC RID: 4556
			AnimDir = 1065992943U,
			// Token: 0x040011CD RID: 4557
			samplerTerrainSnowNormalMap = 480514144U,
			// Token: 0x040011CE RID: 4558
			kFloorWetnessDarkening = 2566369578U,
			// Token: 0x040011CF RID: 4559
			BuildingWindow = 2063821825U,
			// Token: 0x040011D0 RID: 4560
			AmbientFloorTop = 4087624520U,
			// Token: 0x040011D1 RID: 4561
			ColorTransform = 1104051426U,
			// Token: 0x040011D2 RID: 4562
			SculptureIce = 3856237831U,
			// Token: 0x040011D3 RID: 4563
			PickLotTerrainAndFloorsWithCutouts = 1186445075U,
			// Token: 0x040011D4 RID: 4564
			kMat = 1812040018U,
			// Token: 0x040011D5 RID: 4565
			HeatShimmer = 1138402348U,
			// Token: 0x040011D6 RID: 4566
			CasSimHairSimple = 2813552891U,
			// Token: 0x040011D7 RID: 4567
			AmbientSkyColor = 236569367U,
			// Token: 0x040011D8 RID: 4568
			Controls = 2625546787U,
			// Token: 0x040011D9 RID: 4569
			Hideable = 2771508729U,
			// Token: 0x040011DA RID: 4570
			samplerTwigTransitionMap = 1276154865U,
			// Token: 0x040011DB RID: 4571
			SkyReflectionForRain = 1086107598U,
			// Token: 0x040011DC RID: 4572
			Diffuse = 1669179909U,
			// Token: 0x040011DD RID: 4573
			IsFloor = 3653260085U,
			// Token: 0x040011DE RID: 4574
			samplerOverlayTexture = 1643401406U,
			// Token: 0x040011DF RID: 4575
			samplerFurMapTexture = 1247903877U,
			// Token: 0x040011E0 RID: 4576
			WallTop = 303746246U,
			// Token: 0x040011E1 RID: 4577
			HighlightIndex = 2552887569U,
			// Token: 0x040011E2 RID: 4578
			PoolWater = 2766698112U,
			// Token: 0x040011E3 RID: 4579
			ExteriorDiffuseLightProbe = 1286676533U,
			// Token: 0x040011E4 RID: 4580
			Road = 2110808655U,
			// Token: 0x040011E5 RID: 4581
			ColorSamplerGamma = 464686929U,
			// Token: 0x040011E6 RID: 4582
			PickCASSim = 651259978U,
			// Token: 0x040011E7 RID: 4583
			OverlayOnly = 434326413U,
			// Token: 0x040011E8 RID: 4584
			samplerMultiplyMap = 3804914195U,
			// Token: 0x040011E9 RID: 4585
			StarNoiseCubemap = 888576884U,
			// Token: 0x040011EA RID: 4586
			GhostFurLowQuality = 833616360U,
			// Token: 0x040011EB RID: 4587
			gradTexture = 800394446U,
			// Token: 0x040011EC RID: 4588
			samplerCASMap1Texture = 350233382U,
			// Token: 0x040011ED RID: 4589
			FloorTileCeiling = 1012614022U,
			// Token: 0x040011EE RID: 4590
			DebugClipToWorldSpaceMatrix = 1939655122U,
			// Token: 0x040011EF RID: 4591
			mixKeyColor = 2328058083U,
			// Token: 0x040011F0 RID: 4592
			WorldToLightSpaceMatrix = 2852683857U,
			// Token: 0x040011F1 RID: 4593
			forceWallUpDown = 814736809U,
			// Token: 0x040011F2 RID: 4594
			FramesPerSecond = 1080745472U,
			// Token: 0x040011F3 RID: 4595
			CloserSeaWater = 2187368761U,
			// Token: 0x040011F4 RID: 4596
			Sky = 611348932U,
			// Token: 0x040011F5 RID: 4597
			SkyMoonNMTexture = 2753296253U,
			// Token: 0x040011F6 RID: 4598
			Video = 2982943478U,
			// Token: 0x040011F7 RID: 4599
			PickSim = 806642883U,
			// Token: 0x040011F8 RID: 4600
			SnowMeltingNoiseMap = 3663836002U,
			// Token: 0x040011F9 RID: 4601
			SkinToneRampTexture = 4192944791U,
			// Token: 0x040011FA RID: 4602
			samplerWorldLeavesTexture = 2683269794U,
			// Token: 0x040011FB RID: 4603
			pickbranch = 1352146974U,
			// Token: 0x040011FC RID: 4604
			TreeRandomFactors = 770203676U,
			// Token: 0x040011FD RID: 4605
			CurseSpikeHelperTexture = 13609034U,
			// Token: 0x040011FE RID: 4606
			SimShadowDepth = 3802934365U,
			// Token: 0x040011FF RID: 4607
			BillboardLodLimits = 1625804107U,
			// Token: 0x04001200 RID: 4608
			SolidPhong = 1204183948U,
			// Token: 0x04001201 RID: 4609
			LightingTweaks = 60515694U,
			// Token: 0x04001202 RID: 4610
			renderPickTransform = 3081652298U,
			// Token: 0x04001203 RID: 4611
			SimEyelashes = 2644353377U,
			// Token: 0x04001204 RID: 4612
			SizeScaleStart = 2590781128U,
			// Token: 0x04001205 RID: 4613
			TextureSpeedScale = 1480454999U,
			// Token: 0x04001206 RID: 4614
			Mask_Select = 3067272252U,
			// Token: 0x04001207 RID: 4615
			simDropShadowTexture = 1950398374U,
			// Token: 0x04001208 RID: 4616
			StencilToColor = 1801075353U,
			// Token: 0x04001209 RID: 4617
			GhostFilterParams = 1730641126U,
			// Token: 0x0400120A RID: 4618
			samplerLightBasisMap3 = 969502188U,
			// Token: 0x0400120B RID: 4619
			samplerLightBasisMap2,
			// Token: 0x0400120C RID: 4620
			samplerLightBasisMap1,
			// Token: 0x0400120D RID: 4621
			samplerLightBasisMap0,
			// Token: 0x0400120E RID: 4622
			CurvedPoolPreviewTexture = 325725353U,
			// Token: 0x0400120F RID: 4623
			ObjOutlineTexture = 2280767287U,
			// Token: 0x04001210 RID: 4624
			kImposterTerranAndFloorWetnessDarkening = 3193638102U,
			// Token: 0x04001211 RID: 4625
			DebugLightProbe = 1316544516U,
			// Token: 0x04001212 RID: 4626
			samplerSkinDetailDarkTexture = 928813304U,
			// Token: 0x04001213 RID: 4627
			ExteriorLightData = 3248492569U,
			// Token: 0x04001214 RID: 4628
			PondMurk = 2855967219U,
			// Token: 0x04001215 RID: 4629
			CASDiffuseProbeTexture = 4097931805U,
			// Token: 0x04001216 RID: 4630
			samplerSnowMeltingNoiseMap = 1358583980U,
			// Token: 0x04001217 RID: 4631
			TreeLightDirections = 3494412529U,
			// Token: 0x04001218 RID: 4632
			WaterAngles = 26518374U,
			// Token: 0x04001219 RID: 4633
			FailNoisy = 74620033U,
			// Token: 0x0400121A RID: 4634
			blendSelect = 2391112634U,
			// Token: 0x0400121B RID: 4635
			numCurls = 2452585552U,
			// Token: 0x0400121C RID: 4636
			DecalTexture3 = 2585195088U,
			// Token: 0x0400121D RID: 4637
			permTexture2d = 4259952010U,
			// Token: 0x0400121E RID: 4638
			samplerCASMap2Texture = 2108531907U,
			// Token: 0x0400121F RID: 4639
			DecalTexture2 = 2585195089U,
			// Token: 0x04001220 RID: 4640
			DecalTexture1,
			// Token: 0x04001221 RID: 4641
			DecalTexture0,
			// Token: 0x04001222 RID: 4642
			specularScale = 4076645772U,
			// Token: 0x04001223 RID: 4643
			samplerEmissionMap = 1854746656U,
			// Token: 0x04001224 RID: 4644
			NormalMapBasis = 3165474356U,
			// Token: 0x04001225 RID: 4645
			RainPuddleNoiseMap = 3906819219U,
			// Token: 0x04001226 RID: 4646
			Sculpture = 2244311626U,
			// Token: 0x04001227 RID: 4647
			InitialPaintsFrostWithCutout = 149457166U,
			// Token: 0x04001228 RID: 4648
			SparkleCube = 496025734U,
			// Token: 0x04001229 RID: 4649
			PoolImpostorColorAOSI = 350348993U,
			// Token: 0x0400122A RID: 4650
			PickPondWater = 2490332932U,
			// Token: 0x0400122B RID: 4651
			PlatformMipFilter = 1677241000U,
			// Token: 0x0400122C RID: 4652
			duds = 2499605371U,
			// Token: 0x0400122D RID: 4653
			TerrainLight_InsideGreenhouse = 3728160980U,
			// Token: 0x0400122E RID: 4654
			samplerimposterHolidayLightsTexture = 472241250U,
			// Token: 0x0400122F RID: 4655
			RoofAO = 1706170823U,
			// Token: 0x04001230 RID: 4656
			ClampedChannelSelectOp = 3913352835U,
			// Token: 0x04001231 RID: 4657
			NormalMapSampler = 1272664318U,
			// Token: 0x04001232 RID: 4658
			Counters = 2752982882U,
			// Token: 0x04001233 RID: 4659
			PickWalls = 3088765817U,
			// Token: 0x04001234 RID: 4660
			UVScrollSpeed = 4075726572U,
			// Token: 0x04001235 RID: 4661
			rainPuddle1Texture = 1584606201U,
			// Token: 0x04001236 RID: 4662
			LocToPaintWeightUV = 294561179U,
			// Token: 0x04001237 RID: 4663
			WorldBuilderBoundaryColor = 1657055675U,
			// Token: 0x04001238 RID: 4664
			ShadowMerged = 2297968761U,
			// Token: 0x04001239 RID: 4665
			pickleafmesh = 2225062037U,
			// Token: 0x0400123A RID: 4666
			RoofSnowNormalMap = 3602469267U,
			// Token: 0x0400123B RID: 4667
			InstancedObject = 3838049061U,
			// Token: 0x0400123C RID: 4668
			TerrainLight = 2466251492U,
			// Token: 0x0400123D RID: 4669
			ViewToWorldSpaceMatrix = 2401224220U,
			// Token: 0x0400123E RID: 4670
			IcePatchesTexture = 2041293821U,
			// Token: 0x0400123F RID: 4671
			samplerWaterNoiseMap = 3850013196U,
			// Token: 0x04001240 RID: 4672
			RoofWeatherParams = 3775480143U,
			// Token: 0x04001241 RID: 4673
			samplerRoadTexture = 1435702742U,
			// Token: 0x04001242 RID: 4674
			PaintMap_2 = 1820089376U,
			// Token: 0x04001243 RID: 4675
			PaintMap_3,
			// Token: 0x04001244 RID: 4676
			PaintMap_0,
			// Token: 0x04001245 RID: 4677
			FurMap = 1721460714U,
			// Token: 0x04001246 RID: 4678
			PaintMap_1 = 1820089379U,
			// Token: 0x04001247 RID: 4679
			BloomFactor = 1097355403U,
			// Token: 0x04001248 RID: 4680
			shadowleafcard = 2180486471U,
			// Token: 0x04001249 RID: 4681
			CloserSeaWaterReflective = 798975706U,
			// Token: 0x0400124A RID: 4682
			WindMatrices = 2679991343U,
			// Token: 0x0400124B RID: 4683
			BasinWater = 1789733589U,
			// Token: 0x0400124C RID: 4684
			RabbitHoleHighDetail = 2369022908U,
			// Token: 0x0400124D RID: 4685
			Layer2Shift = 2456366258U,
			// Token: 0x0400124E RID: 4686
			LargeObjectFloor = 3274153339U,
			// Token: 0x0400124F RID: 4687
			IceCracksTexture = 688743540U,
			// Token: 0x04001250 RID: 4688
			PickParticleTexture = 2986177437U,
			// Token: 0x04001251 RID: 4689
			Births = 1452147559U,
			// Token: 0x04001252 RID: 4690
			WorldSpaceLightPosition = 4070230092U,
			// Token: 0x04001253 RID: 4691
			ShadowBlur = 3654028678U,
			// Token: 0x04001254 RID: 4692
			translucentSampler = 917049638U,
			// Token: 0x04001255 RID: 4693
			PickTrampoline = 3051909459U,
			// Token: 0x04001256 RID: 4694
			BlendSampler = 1020960342U,
			// Token: 0x04001257 RID: 4695
			DetailUVScale = 3449313803U,
			// Token: 0x04001258 RID: 4696
			TerrainFogNoSnowElev = 773404638U,
			// Token: 0x04001259 RID: 4697
			LotTerrain = 298891041U,
			// Token: 0x0400125A RID: 4698
			StaticTerrainCompositor = 4217794805U,
			// Token: 0x0400125B RID: 4699
			SimpleSim = 1323651004U,
			// Token: 0x0400125C RID: 4700
			SimSkinThumbnail = 2667546411U,
			// Token: 0x0400125D RID: 4701
			rainPuddle1Target = 697572883U,
			// Token: 0x0400125E RID: 4702
			MinspecHorizonColor = 1696962096U,
			// Token: 0x0400125F RID: 4703
			PreviewWithAlpha = 1685391585U,
			// Token: 0x04001260 RID: 4704
			SkinNormalMapSampler = 1364707593U,
			// Token: 0x04001261 RID: 4705
			PeelMapDepthTarget = 4028565425U,
			// Token: 0x04001262 RID: 4706
			samplerObjectSnowNormalMap = 69368748U,
			// Token: 0x04001263 RID: 4707
			BillboardTangent = 813673993U,
			// Token: 0x04001264 RID: 4708
			ScreenCaptureEffects = 710682525U,
			// Token: 0x04001265 RID: 4709
			CasSimEyes = 3038693783U,
			// Token: 0x04001266 RID: 4710
			censorTexture = 4117365408U,
			// Token: 0x04001267 RID: 4711
			ImpostorDetailTexture = 1457637042U,
			// Token: 0x04001268 RID: 4712
			Foliage = 1162469934U,
			// Token: 0x04001269 RID: 4713
			samplerRoofSnowNormalMap = 4055920781U,
			// Token: 0x0400126A RID: 4714
			FloorGridTexture = 3669410498U,
			// Token: 0x0400126B RID: 4715
			ExteriorFloors = 485042218U,
			// Token: 0x0400126C RID: 4716
			CloudTextureOffsetWRTLayer1 = 2636947865U,
			// Token: 0x0400126D RID: 4717
			DualSkinToneMap = 3540888006U,
			// Token: 0x0400126E RID: 4718
			worldBuilderObjectGridMap = 2265616657U,
			// Token: 0x0400126F RID: 4719
			kMaxFurdist = 2667852849U,
			// Token: 0x04001270 RID: 4720
			CloudTextureOffsetWRTLayer2 = 2636947866U,
			// Token: 0x04001271 RID: 4721
			TireTracksTextureD = 1582645268U,
			// Token: 0x04001272 RID: 4722
			BloomData = 2370137826U,
			// Token: 0x04001273 RID: 4723
			samplerPrecipitationShadowMainMap = 3181556295U,
			// Token: 0x04001274 RID: 4724
			TireTracksTextureN = 1582645278U,
			// Token: 0x04001275 RID: 4725
			ClothingSpecularPower = 588236413U,
			// Token: 0x04001276 RID: 4726
			samplerworldBuilderBrushMap = 3678779596U,
			// Token: 0x04001277 RID: 4727
			CloudSharpness2 = 2972087361U,
			// Token: 0x04001278 RID: 4728
			CloudSharpness1,
			// Token: 0x04001279 RID: 4729
			kDistantTransitionRate = 3347262840U,
			// Token: 0x0400127A RID: 4730
			Greyscale = 826180286U,
			// Token: 0x0400127B RID: 4731
			HDLightColors = 962172115U,
			// Token: 0x0400127C RID: 4732
			samplerDiffuseMap = 1801026059U,
			// Token: 0x0400127D RID: 4733
			SkinDetailDarkTexture = 2343301050U,
			// Token: 0x0400127E RID: 4734
			SimHair = 2231202130U,
			// Token: 0x0400127F RID: 4735
			xyMapping = 459968486U,
			// Token: 0x04001280 RID: 4736
			curlDeltas = 483243866U,
			// Token: 0x04001281 RID: 4737
			FurMapTarget = 2655346645U,
			// Token: 0x04001282 RID: 4738
			SunColor = 943905378U,
			// Token: 0x04001283 RID: 4739
			ObjectToClipSpaceMatrix = 3034097694U,
			// Token: 0x04001284 RID: 4740
			samplercubeMapTexture = 4189416603U,
			// Token: 0x04001285 RID: 4741
			kFresnelScale = 2616295881U,
			// Token: 0x04001286 RID: 4742
			samplerBlurrySpecularLightProbe = 18141786U,
			// Token: 0x04001287 RID: 4743
			BufferBSampler = 1861235653U,
			// Token: 0x04001288 RID: 4744
			samplerSkinDetailTextureDark = 3227223220U,
			// Token: 0x04001289 RID: 4745
			RoadGrateDrain = 2298654786U,
			// Token: 0x0400128A RID: 4746
			rainPuddleNormalsTarget = 290389438U,
			// Token: 0x0400128B RID: 4747
			OverlaySampler = 793243605U,
			// Token: 0x0400128C RID: 4748
			ExteriorSimDropShadow = 32389867U,
			// Token: 0x0400128D RID: 4749
			samplerrainPuddle2Texture = 3939284714U,
			// Token: 0x0400128E RID: 4750
			colors = 245870429U,
			// Token: 0x0400128F RID: 4751
			samplerRoomLightMap = 55530896U,
			// Token: 0x04001290 RID: 4752
			halo = 3633416831U,
			// Token: 0x04001291 RID: 4753
			FloorsVisualizer = 723466988U,
			// Token: 0x04001292 RID: 4754
			ObjectSnowSideNormalMap = 698772701U,
			// Token: 0x04001293 RID: 4755
			kMagScale = 626082825U,
			// Token: 0x04001294 RID: 4756
			BufferASampler = 1045433204U,
			// Token: 0x04001295 RID: 4757
			FlatMirror = 2794298921U,
			// Token: 0x04001296 RID: 4758
			Ambient = 77978275U,
			// Token: 0x04001297 RID: 4759
			AlignAcrossDirection = 25712774U,
			// Token: 0x04001298 RID: 4760
			AlignToDirection = 397904630U,
			// Token: 0x04001299 RID: 4761
			AlphaMap = 3287985231U,
			// Token: 0x0400129A RID: 4762
			AlwaysOn = 4028195869U,
			// Token: 0x0400129B RID: 4763
			AverageColor = 1150958183U,
			// Token: 0x0400129C RID: 4764
			BlendDestMode = 2615069495U,
			// Token: 0x0400129D RID: 4765
			BlendOperation = 756267321U,
			// Token: 0x0400129E RID: 4766
			BlendSourceMode = 160819564U,
			// Token: 0x0400129F RID: 4767
			DaytimeOnly = 1806928316U,
			// Token: 0x040012A0 RID: 4768
			DiffuseMapUVChannel = 3294256961U,
			// Token: 0x040012A1 RID: 4769
			DropShadowAtlas = 581797127U,
			// Token: 0x040012A2 RID: 4770
			DropShadowStrength = 454735061U,
			// Token: 0x040012A3 RID: 4771
			Emission = 1003766176U,
			// Token: 0x040012A4 RID: 4772
			ForceAmount = 3570736386U,
			// Token: 0x040012A5 RID: 4773
			ForceDirection = 696786773U,
			// Token: 0x040012A6 RID: 4774
			HighlightColor = 2432228592U,
			// Token: 0x040012A7 RID: 4775
			index_of_refraction = 3668529965U,
			// Token: 0x040012A8 RID: 4776
			IsSolidObject = 1002412495U,
			// Token: 0x040012A9 RID: 4777
			LifetimeSeconds = 2216765235U,
			// Token: 0x040012AA RID: 4778
			LightingEnabled = 2707309972U,
			// Token: 0x040012AB RID: 4779
			MaskHeight = 2224872156U,
			// Token: 0x040012AC RID: 4780
			MaskWidth = 1887400239U,
			// Token: 0x040012AD RID: 4781
			NoAutomaticDaylightDimming = 1018559088U,
			// Token: 0x040012AE RID: 4782
			OverrideDirection = 202563288U,
			// Token: 0x040012AF RID: 4783
			OverrideSpeed = 2748724270U,
			// Token: 0x040012B0 RID: 4784
			ParticleCount = 3425810472U,
			// Token: 0x040012B1 RID: 4785
			PosOffset = 2031009580U,
			// Token: 0x040012B2 RID: 4786
			Reflective = 1942590014U,
			// Token: 0x040012B3 RID: 4787
			reflectivity = 700243231U,
			// Token: 0x040012B4 RID: 4788
			RootColor = 3909458422U,
			// Token: 0x040012B5 RID: 4789
			RotateSpeedRadsSec = 381647428U,
			// Token: 0x040012B6 RID: 4790
			ShadowAlphaTest = 4273076683U,
			// Token: 0x040012B7 RID: 4791
			SharpSpecControl = 289947393U,
			// Token: 0x040012B8 RID: 4792
			SharpSpecThreshold = 2419844307U,
			// Token: 0x040012B9 RID: 4793
			SpecularMapUVChannel = 3406116486U,
			// Token: 0x040012BA RID: 4794
			Transparency = 97660883U,
			// Token: 0x040012BB RID: 4795
			Transparent = 2558788601U,
			// Token: 0x040012BC RID: 4796
			UseDiffuseForAlphaTest = 3046636159U,
			// Token: 0x040012BD RID: 4797
			UVOffset = 1465395305U,
			// Token: 0x040012BE RID: 4798
			UVScale = 362521918U,
			// Token: 0x040012BF RID: 4799
			IsObject = 1276308712U,
			// Token: 0x040012C0 RID: 4800
			IsGenericBox = 880582151U,
			// Token: 0x040012C1 RID: 4801
			StretchRect = 2369311022U,
			// Token: 0x040012C2 RID: 4802
			IsPartition = 1380975165U,
			// Token: 0x040012C3 RID: 4803
			NormalMapUVChannel = 2189874156U,
			// Token: 0x040012C4 RID: 4804
			HighlightPhong = 236711583U,
			// Token: 0x040012C5 RID: 4805
			samplerWaterReflectionMapForLot = 1321443377U,
			// Token: 0x040012C6 RID: 4806
			Cloud = 1350606868U,
			// Token: 0x040012C7 RID: 4807
			RenderPickFuzzyTest = 1927680470U,
			// Token: 0x040012C8 RID: 4808
			g_DofGaussian_ps_params = 3753326150U,
			// Token: 0x040012C9 RID: 4809
			exteriorSpecModulation = 2360703732U,
			// Token: 0x040012CA RID: 4810
			samplerEnvCubeMap = 826073167U,
			// Token: 0x040012CB RID: 4811
			DirtUVScale = 3109831659U,
			// Token: 0x040012CC RID: 4812
			samplerDiffuseMapTileable = 4248992335U,
			// Token: 0x040012CD RID: 4813
			SsaoDepth_Stairs = 301967755U,
			// Token: 0x040012CE RID: 4814
			Bloom_Blur = 277390066U,
			// Token: 0x040012CF RID: 4815
			InstancedWindow = 3825821404U,
			// Token: 0x040012D0 RID: 4816
			PlumbBob = 2132907828U,
			// Token: 0x040012D1 RID: 4817
			CASSpecularTerms = 3052013068U,
			// Token: 0x040012D2 RID: 4818
			bIsWorldTerrain = 44400750U,
			// Token: 0x040012D3 RID: 4819
			ResizeZToColorRawZ = 3134043771U,
			// Token: 0x040012D4 RID: 4820
			ShadowTintColor = 2070445983U,
			// Token: 0x040012D5 RID: 4821
			bIsLotTerrain = 1455606613U,
			// Token: 0x040012D6 RID: 4822
			bIsLotFloor = 4068530752U,
			// Token: 0x040012D7 RID: 4823
			GenerateDiscAreaLightmap = 26670418U,
			// Token: 0x040012D8 RID: 4824
			samplerBakedLightMap = 426781818U,
			// Token: 0x040012D9 RID: 4825
			RenderPickMap = 2646605568U,
			// Token: 0x040012DA RID: 4826
			SsaoDepth_Walls = 2944997300U,
			// Token: 0x040012DB RID: 4827
			BabySkin = 3077699806U,
			// Token: 0x040012DC RID: 4828
			VertexShaders = 3762731079U,
			// Token: 0x040012DD RID: 4829
			tex0 = 2972449404U,
			// Token: 0x040012DE RID: 4830
			NormalMapUVxform = 4264483807U,
			// Token: 0x040012DF RID: 4831
			tex1 = 2972449405U,
			// Token: 0x040012E0 RID: 4832
			AlphaBlended = 4112102783U,
			// Token: 0x040012E1 RID: 4833
			InstancedScrollingLight = 2680253899U,
			// Token: 0x040012E2 RID: 4834
			paint_colorMap5 = 824541152U,
			// Token: 0x040012E3 RID: 4835
			paint_colorMap4,
			// Token: 0x040012E4 RID: 4836
			paint_colorMap7,
			// Token: 0x040012E5 RID: 4837
			LargeObjectPhong = 2402550475U,
			// Token: 0x040012E6 RID: 4838
			paint_colorMap6 = 824541155U,
			// Token: 0x040012E7 RID: 4839
			paint_colorMap1,
			// Token: 0x040012E8 RID: 4840
			paint_colorMap3 = 824541158U,
			// Token: 0x040012E9 RID: 4841
			samplerCubeMapTex = 3865690361U,
			// Token: 0x040012EA RID: 4842
			paint_colorMap2 = 824541159U,
			// Token: 0x040012EB RID: 4843
			kInteriorWallCausticsScale = 3313485207U,
			// Token: 0x040012EC RID: 4844
			paint_colorMap8 = 824541165U,
			// Token: 0x040012ED RID: 4845
			Medatorlighting = 1824907581U,
			// Token: 0x040012EE RID: 4846
			g_ssao_ps_params = 3447604892U,
			// Token: 0x040012EF RID: 4847
			HeightMap = 718378482U,
			// Token: 0x040012F0 RID: 4848
			WallCutoutProxy = 2111181967U,
			// Token: 0x040012F1 RID: 4849
			ObjectAnchorLocation = 3654291210U,
			// Token: 0x040012F2 RID: 4850
			DepthTest = 3247757268U,
			// Token: 0x040012F3 RID: 4851
			RefractionOpacity = 1984440675U,
			// Token: 0x040012F4 RID: 4852
			PickAnimatedTree = 2296236369U,
			// Token: 0x040012F5 RID: 4853
			CausticsScrollSpeedLayer2 = 3764923077U,
			// Token: 0x040012F6 RID: 4854
			SkinDetail2ndOverlayOpacity = 2266343400U,
			// Token: 0x040012F7 RID: 4855
			CausticsScrollSpeedLayer1 = 3764923078U,
			// Token: 0x040012F8 RID: 4856
			samplerOverlayMap = 3325902073U,
			// Token: 0x040012F9 RID: 4857
			texgen = 429412562U,
			// Token: 0x040012FA RID: 4858
			particleFogMultiplier = 526104224U,
			// Token: 0x040012FB RID: 4859
			InstancedVertexAnim = 1676193157U,
			// Token: 0x040012FC RID: 4860
			samplerGhostMaskTexture = 1978230553U,
			// Token: 0x040012FD RID: 4861
			RoadLightmapgeneration = 2202394751U,
			// Token: 0x040012FE RID: 4862
			BlockPreview = 2715364732U,
			// Token: 0x040012FF RID: 4863
			SimGhostCAS = 1511421450U,
			// Token: 0x04001300 RID: 4864
			PixelShaders = 4229118971U,
			// Token: 0x04001301 RID: 4865
			CausticsLayer2Shift = 374870539U,
			// Token: 0x04001302 RID: 4866
			g_hsv_tweaker_offset_texture = 1947089304U,
			// Token: 0x04001303 RID: 4867
			samplerg_hsv_tweaker_input_texture = 1801607865U,
			// Token: 0x04001304 RID: 4868
			AmbientColor = 1598772660U,
			// Token: 0x04001305 RID: 4869
			BlockModel = 867509135U,
			// Token: 0x04001306 RID: 4870
			terrainNormalMapIsCompressed = 547036302U,
			// Token: 0x04001307 RID: 4871
			TerrainCubeMap = 1460089827U,
			// Token: 0x04001308 RID: 4872
			use16F = 4130693295U,
			// Token: 0x04001309 RID: 4873
			ObjectScale = 505196594U,
			// Token: 0x0400130A RID: 4874
			HairAlphaBlend = 1567751532U,
			// Token: 0x0400130B RID: 4875
			DetailNormalMap = 88845155U,
			// Token: 0x0400130C RID: 4876
			SkinToneAndMakeupTexture = 1579992505U,
			// Token: 0x0400130D RID: 4877
			VideoActive = 3119137484U,
			// Token: 0x0400130E RID: 4878
			SunCubeBasis = 618204912U,
			// Token: 0x0400130F RID: 4879
			ObjectToWorldBillboardYMatrix = 3590192892U,
			// Token: 0x04001310 RID: 4880
			LotSkirtMaskThumbnail = 2818017609U,
			// Token: 0x04001311 RID: 4881
			OverlayNormalMap = 5898708U,
			// Token: 0x04001312 RID: 4882
			RenderPickRamp = 700604718U,
			// Token: 0x04001313 RID: 4883
			lightmapgeneration = 2274359037U,
			// Token: 0x04001314 RID: 4884
			PointLightColors = 3720814919U,
			// Token: 0x04001315 RID: 4885
			samplercharMapTexture = 269907440U,
			// Token: 0x04001316 RID: 4886
			g_ssao_ps_apply_params = 1739633531U,
			// Token: 0x04001317 RID: 4887
			roof = 2077253475U,
			// Token: 0x04001318 RID: 4888
			DoubleSided = 463289029U,
			// Token: 0x04001319 RID: 4889
			SsaoDepth_AnimatedTree = 395896662U,
			// Token: 0x0400131A RID: 4890
			samplercolorMap6 = 1599679776U,
			// Token: 0x0400131B RID: 4891
			samplercolorMap7,
			// Token: 0x0400131C RID: 4892
			samplercolorMap5 = 1599679779U,
			// Token: 0x0400131D RID: 4893
			SunLightCloudColor = 4226563255U,
			// Token: 0x0400131E RID: 4894
			SpecMapAtlas = 2654784975U,
			// Token: 0x0400131F RID: 4895
			CloudSharpnessCurves = 2391686801U,
			// Token: 0x04001320 RID: 4896
			AlphaTestSkinnedShadows = 1860902916U,
			// Token: 0x04001321 RID: 4897
			CASHighlightInfo = 3516935152U,
			// Token: 0x04001322 RID: 4898
			SsaoDepth_Floor = 2033606645U,
			// Token: 0x04001323 RID: 4899
			gIntBufCreationParams = 2947011855U,
			// Token: 0x04001324 RID: 4900
			sky = 611348932U,
			// Token: 0x04001325 RID: 4901
			ShadowAttenuation = 2735379379U,
			// Token: 0x04001326 RID: 4902
			Headlights = 1515523356U,
			// Token: 0x04001327 RID: 4903
			ReflectionTexture = 3403839823U,
			// Token: 0x04001328 RID: 4904
			DropShadowAccountForSsao = 2453356542U,
			// Token: 0x04001329 RID: 4905
			AddZFailRenderPass = 1116613263U,
			// Token: 0x0400132A RID: 4906
			CASAmbientIntensity = 2532098495U,
			// Token: 0x0400132B RID: 4907
			ShadowMapTypeDepthCascade = 3987464814U,
			// Token: 0x0400132C RID: 4908
			RefractionNormalMap = 1527257717U,
			// Token: 0x0400132D RID: 4909
			kMaxMaskedAlpha = 3219908407U,
			// Token: 0x0400132E RID: 4910
			VideoDecode = 1568063276U,
			// Token: 0x0400132F RID: 4911
			DiffuseOpacity = 3567488612U,
			// Token: 0x04001330 RID: 4912
			samplerWaterCausticsNormalMap = 692785976U,
			// Token: 0x04001331 RID: 4913
			BillboardClouds = 396528716U,
			// Token: 0x04001332 RID: 4914
			CounterCutoutProxy = 717090341U,
			// Token: 0x04001333 RID: 4915
			BltConstantAlpha = 2748132239U,
			// Token: 0x04001334 RID: 4916
			ui = 1551306167U,
			// Token: 0x04001335 RID: 4917
			UVScrollOffset = 3497841666U,
			// Token: 0x04001336 RID: 4918
			kGhostHeightFadeThreshold = 262694575U,
			// Token: 0x04001337 RID: 4919
			cascadeTransfer = 3667261860U,
			// Token: 0x04001338 RID: 4920
			IndoorTerrainHigh = 3296496759U,
			// Token: 0x04001339 RID: 4921
			samplerNormalMapAtlas = 230421665U,
			// Token: 0x0400133A RID: 4922
			OverlayLightMap = 1652023029U,
			// Token: 0x0400133B RID: 4923
			CounterInvTranslate = 2648237158U,
			// Token: 0x0400133C RID: 4924
			PointLightPositions = 1654159237U,
			// Token: 0x0400133D RID: 4925
			GeneratePointLightmap = 3754985636U,
			// Token: 0x0400133E RID: 4926
			samplerLightsMap = 2608415270U,
			// Token: 0x0400133F RID: 4927
			ResizeZToColor = 1985750103U,
			// Token: 0x04001340 RID: 4928
			gBloomControl = 2186710252U,
			// Token: 0x04001341 RID: 4929
			UseLargeLotObjectLighting = 2696724017U,
			// Token: 0x04001342 RID: 4930
			lightMapColor = 2573386360U,
			// Token: 0x04001343 RID: 4931
			InstancedBillboard = 791613881U,
			// Token: 0x04001344 RID: 4932
			SimGhostGlass = 1135020921U,
			// Token: 0x04001345 RID: 4933
			PortalLOD = 3431415592U,
			// Token: 0x04001346 RID: 4934
			WriteBlurInAlpha = 789578668U,
			// Token: 0x04001347 RID: 4935
			WriteBlurInAlphaUsingFullZ = 2893610247U,
			// Token: 0x04001348 RID: 4936
			WriteBlurInAlphaUsingFullZRawZ = 3538635083U,
			// Token: 0x04001349 RID: 4937
			SimSkinCAS = 3741868984U,
			// Token: 0x0400134A RID: 4938
			SimGhostGlassCAS = 1773564024U,
			// Token: 0x0400134B RID: 4939
			SharedTerrainLightmap = 3588805487U,
			// Token: 0x0400134C RID: 4940
			SpecPaintTexture = 1822797765U,
			// Token: 0x0400134D RID: 4941
			dropshadow = 3231479170U,
			// Token: 0x0400134E RID: 4942
			Blt = 597278277U,
			// Token: 0x0400134F RID: 4943
			BillboardText = 111683787U,
			// Token: 0x04001350 RID: 4944
			bIsWorldMask = 3467189695U,
			// Token: 0x04001351 RID: 4945
			simglassCAS = 3510540605U,
			// Token: 0x04001352 RID: 4946
			BltCube = 483639750U,
			// Token: 0x04001353 RID: 4947
			Pretransformed = 1728416455U,
			// Token: 0x04001354 RID: 4948
			Filter = 2008252611U,
			// Token: 0x04001355 RID: 4949
			Fill = 3047988258U,
			// Token: 0x04001356 RID: 4950
			bIsRoad = 942835475U,
			// Token: 0x04001357 RID: 4951
			g_hsv_tweaker_input_texture = 2558190987U,
			// Token: 0x04001358 RID: 4952
			MapPack = 102686334U,
			// Token: 0x04001359 RID: 4953
			VideoSurface = 2554453067U,
			// Token: 0x0400135A RID: 4954
			WallTopCutout = 717059122U,
			// Token: 0x0400135B RID: 4955
			interiorSpecModulation = 2544552002U,
			// Token: 0x0400135C RID: 4956
			HorizonLightCloudColor = 2063933286U,
			// Token: 0x0400135D RID: 4957
			IndoorHiliteTerrainHigh = 789529992U,
			// Token: 0x0400135E RID: 4958
			rug = 712161697U,
			// Token: 0x0400135F RID: 4959
			WaterScrollSpeedDiffuse = 3775679272U,
			// Token: 0x04001360 RID: 4960
			ShowLayerCountVisualization = 2439487894U,
			// Token: 0x04001361 RID: 4961
			Stairs = 1289942167U,
			// Token: 0x04001362 RID: 4962
			VertexShaders_NoUByte4N = 1089720204U,
			// Token: 0x04001363 RID: 4963
			Scale = 1894020421U,
			// Token: 0x04001364 RID: 4964
			samplerCASGrubbyTexture = 3909894724U,
			// Token: 0x04001365 RID: 4965
			AdditiveLightMap = 1506156963U,
			// Token: 0x04001366 RID: 4966
			samplergBloomInputTexture = 3327336986U,
			// Token: 0x04001367 RID: 4967
			NormalMirror = 1026971097U,
			// Token: 0x04001368 RID: 4968
			ScrollingLight = 3884549266U,
			// Token: 0x04001369 RID: 4969
			TerrainGrid = 129711944U,
			// Token: 0x0400136A RID: 4970
			NormalMapAtlas = 72011727U,
			// Token: 0x0400136B RID: 4971
			ShadowDecal = 2548808816U,
			// Token: 0x0400136C RID: 4972
			SsaoDepth_Counters = 2675654598U,
			// Token: 0x0400136D RID: 4973
			samplerLightMesh = 3837932270U,
			// Token: 0x0400136E RID: 4974
			poiMap = 636560579U,
			// Token: 0x0400136F RID: 4975
			gVolumetricLightScatteringParams = 2486251212U,
			// Token: 0x04001370 RID: 4976
			staticTerrainLightmap = 2259017636U,
			// Token: 0x04001371 RID: 4977
			CausticNormalUVScale1 = 640725064U,
			// Token: 0x04001372 RID: 4978
			PlacementPreview = 3947782422U,
			// Token: 0x04001373 RID: 4979
			CausticNormalUVScale2 = 640725067U,
			// Token: 0x04001374 RID: 4980
			CASAmbientIntensityTexture = 3761107188U,
			// Token: 0x04001375 RID: 4981
			samplerFloorCubeMap = 3971843058U,
			// Token: 0x04001376 RID: 4982
			HeightMapWSDEScales = 1432558000U,
			// Token: 0x04001377 RID: 4983
			DistBasedFilterRawZ = 2065219992U,
			// Token: 0x04001378 RID: 4984
			ResizeZToDepth = 3546704793U,
			// Token: 0x04001379 RID: 4985
			g_zBuffer = 2737848385U,
			// Token: 0x0400137A RID: 4986
			EnvCubeMapOpacity = 2612609556U,
			// Token: 0x0400137B RID: 4987
			InstancedGrass = 1688347478U,
			// Token: 0x0400137C RID: 4988
			SsaoDepth_Sim = 3046430198U,
			// Token: 0x0400137D RID: 4989
			Scrolling = 676173606U,
			// Token: 0x0400137E RID: 4990
			weightValues = 842627147U,
			// Token: 0x0400137F RID: 4991
			RadialBlur = 2788013583U,
			// Token: 0x04001380 RID: 4992
			g_SsaoBuffer = 3153226635U,
			// Token: 0x04001381 RID: 4993
			CubeMapTex = 3230934431U,
			// Token: 0x04001382 RID: 4994
			bypassGamma = 1481680352U,
			// Token: 0x04001383 RID: 4995
			samplerCASBurntTexture = 1739240416U,
			// Token: 0x04001384 RID: 4996
			FloorTrim = 2227319321U,
			// Token: 0x04001385 RID: 4997
			kExteriorFloorCausticsScale = 2175127623U,
			// Token: 0x04001386 RID: 4998
			VideoUVMapping = 1755135747U,
			// Token: 0x04001387 RID: 4999
			samplerAdditiveLightMap = 2263542573U,
			// Token: 0x04001388 RID: 5000
			samplerReflectionTexture = 2214435933U,
			// Token: 0x04001389 RID: 5001
			InstancedShadowCasterFast = 1382029018U,
			// Token: 0x0400138A RID: 5002
			Interior = 1132214669U,
			// Token: 0x0400138B RID: 5003
			asseterror = 935392879U,
			// Token: 0x0400138C RID: 5004
			PlumbBobCubeMap = 3732426031U,
			// Token: 0x0400138D RID: 5005
			CASHighlightTexture = 2268915325U,
			// Token: 0x0400138E RID: 5006
			GenerateShadedLightmap = 4004915175U,
			// Token: 0x0400138F RID: 5007
			VertexAnim = 2021675924U,
			// Token: 0x04001390 RID: 5008
			ScrollSpeedLightMap = 328678777U,
			// Token: 0x04001391 RID: 5009
			PickParticleNoOcclude = 4140384134U,
			// Token: 0x04001392 RID: 5010
			DepthBias = 2888357919U,
			// Token: 0x04001393 RID: 5011
			SSAOIntensity = 1778773354U,
			// Token: 0x04001394 RID: 5012
			PaintTexture = 2947877492U,
			// Token: 0x04001395 RID: 5013
			ReceiveShadows = 551727011U,
			// Token: 0x04001396 RID: 5014
			VertexOffset = 1454351946U,
			// Token: 0x04001397 RID: 5015
			samplerShadowAttenuationTexture = 2753075270U,
			// Token: 0x04001398 RID: 5016
			useAlphaBlending = 2866351697U,
			// Token: 0x04001399 RID: 5017
			UseVertColor = 156297172U,
			// Token: 0x0400139A RID: 5018
			TerrainHighWithBlendedPaint = 1094536006U,
			// Token: 0x0400139B RID: 5019
			FlipBook = 415734043U,
			// Token: 0x0400139C RID: 5020
			kFootClipThreshold = 3226293019U,
			// Token: 0x0400139D RID: 5021
			gPosToUVDest = 2225317260U,
			// Token: 0x0400139E RID: 5022
			WaterCausticsNormalMap = 1116251514U,
			// Token: 0x0400139F RID: 5023
			SpecMap = 3468328586U,
			// Token: 0x040013A0 RID: 5024
			LightsAnimSpeed = 853888038U,
			// Token: 0x040013A1 RID: 5025
			PixelShaders_AlphaComposite = 1044419603U,
			// Token: 0x040013A2 RID: 5026
			RenderPick = 1567891298U,
			// Token: 0x040013A3 RID: 5027
			instancedFences = 3054075058U,
			// Token: 0x040013A4 RID: 5028
			ShadowAttenuationTexture = 3408260616U,
			// Token: 0x040013A5 RID: 5029
			OverlayMap = 3698704683U,
			// Token: 0x040013A6 RID: 5030
			CounterInvRotate = 543002905U,
			// Token: 0x040013A7 RID: 5031
			Wall = 2108779961U,
			// Token: 0x040013A8 RID: 5032
			AlphaScroll = 3704974032U,
			// Token: 0x040013A9 RID: 5033
			VolumeMap = 450999767U,
			// Token: 0x040013AA RID: 5034
			kDayDimScale = 2467319766U,
			// Token: 0x040013AB RID: 5035
			geomorph = 4112578698U,
			// Token: 0x040013AC RID: 5036
			BlurScale = 1306069296U,
			// Token: 0x040013AD RID: 5037
			CausticsNormalMapScale = 1381092479U,
			// Token: 0x040013AE RID: 5038
			IndoorTerrainHighWithBlendedPaint = 2841425873U,
			// Token: 0x040013AF RID: 5039
			NextFloorLightMapXform = 3924134624U,
			// Token: 0x040013B0 RID: 5040
			UIStencil = 2107488177U,
			// Token: 0x040013B1 RID: 5041
			PickCASSimGhost = 1260068615U,
			// Token: 0x040013B2 RID: 5042
			samplerCASAmbientIntensityTexture = 3863133470U,
			// Token: 0x040013B3 RID: 5043
			Highlighting = 565456625U,
			// Token: 0x040013B4 RID: 5044
			LotSkirtShadowThumbnail = 3501508625U,
			// Token: 0x040013B5 RID: 5045
			samplerVolumeMap = 594432093U,
			// Token: 0x040013B6 RID: 5046
			samplerShadowDecalMap = 3130384884U,
			// Token: 0x040013B7 RID: 5047
			cabinet = 4235037199U,
			// Token: 0x040013B8 RID: 5048
			bIsWorldChunkBoundaries = 2923738632U,
			// Token: 0x040013B9 RID: 5049
			samplerCASHotSpotAtlas = 3473699640U,
			// Token: 0x040013BA RID: 5050
			GenerateSpotLightmap = 2676635022U,
			// Token: 0x040013BB RID: 5051
			simskin = 1417909433U,
			// Token: 0x040013BC RID: 5052
			EmissiveOpacity = 3214741563U,
			// Token: 0x040013BD RID: 5053
			samplerNextFloorLightBasisMap2 = 264108692U,
			// Token: 0x040013BE RID: 5054
			samplerNextFloorLightBasisMap3,
			// Token: 0x040013BF RID: 5055
			billboardSize = 3848695377U,
			// Token: 0x040013C0 RID: 5056
			samplerNextFloorLightBasisMap0 = 264108694U,
			// Token: 0x040013C1 RID: 5057
			WaterReflectionMapForLot = 993441451U,
			// Token: 0x040013C2 RID: 5058
			samplerNextFloorLightBasisMap1 = 264108695U,
			// Token: 0x040013C3 RID: 5059
			EnvCubeMap = 333444021U,
			// Token: 0x040013C4 RID: 5060
			Bloom_Apply = 461712207U,
			// Token: 0x040013C5 RID: 5061
			samplerFloorThicknessTexture = 2829428684U,
			// Token: 0x040013C6 RID: 5062
			CascadeShadowParams = 1317291839U,
			// Token: 0x040013C7 RID: 5063
			HiliteTerrainHigh = 3292158635U,
			// Token: 0x040013C8 RID: 5064
			posScale = 1215711461U,
			// Token: 0x040013C9 RID: 5065
			WallTopBottomShadow = 977448647U,
			// Token: 0x040013CA RID: 5066
			samplerSecondaryLightmap = 2039091297U,
			// Token: 0x040013CB RID: 5067
			posOffset = 2031009580U,
			// Token: 0x040013CC RID: 5068
			samplerSkinDetailHSL = 3183704788U,
			// Token: 0x040013CD RID: 5069
			samplerg_colorTexture = 59142535U,
			// Token: 0x040013CE RID: 5070
			StairsPreviewMode = 1142096768U,
			// Token: 0x040013CF RID: 5071
			FadeEnabled = 1723796206U,
			// Token: 0x040013D0 RID: 5072
			LightMapTex = 205658138U,
			// Token: 0x040013D1 RID: 5073
			SsaoDepth_LotTerrain = 2626222669U,
			// Token: 0x040013D2 RID: 5074
			Cutouts = 2791857932U,
			// Token: 0x040013D3 RID: 5075
			HighlightInstanced = 2312659870U,
			// Token: 0x040013D4 RID: 5076
			InstancedObjectFast = 327686579U,
			// Token: 0x040013D5 RID: 5077
			gCascadeDepthRemap = 101849284U,
			// Token: 0x040013D6 RID: 5078
			samplerDetailNormalMap = 3869291461U,
			// Token: 0x040013D7 RID: 5079
			showTessMap = 813437777U,
			// Token: 0x040013D8 RID: 5080
			UseVertSelfIllumination = 1234354128U,
			// Token: 0x040013D9 RID: 5081
			shininess = 4149606399U,
			// Token: 0x040013DA RID: 5082
			mvp = 662564464U,
			// Token: 0x040013DB RID: 5083
			SsaoDepth_Rug = 2778135397U,
			// Token: 0x040013DC RID: 5084
			SkinDetailHSL = 1010896790U,
			// Token: 0x040013DD RID: 5085
			colorMap7 = 3287135903U,
			// Token: 0x040013DE RID: 5086
			bIsWorldGrid = 1052882751U,
			// Token: 0x040013DF RID: 5087
			HiliteTerrainLow = 3746401263U,
			// Token: 0x040013E0 RID: 5088
			g_dof_params = 347685483U,
			// Token: 0x040013E1 RID: 5089
			Bloom_ApplyDebug = 2069536224U,
			// Token: 0x040013E2 RID: 5090
			Gizmo = 1114996413U,
			// Token: 0x040013E3 RID: 5091
			InstancedFloorTrim = 68968794U,
			// Token: 0x040013E4 RID: 5092
			AnimatedGrass = 4126600848U,
			// Token: 0x040013E5 RID: 5093
			TransferTechnique = 423279710U,
			// Token: 0x040013E6 RID: 5094
			ScrollSpeedDiffuse = 3577059427U,
			// Token: 0x040013E7 RID: 5095
			screenPosition = 2265118432U,
			// Token: 0x040013E8 RID: 5096
			ConvertLightmap = 46422856U,
			// Token: 0x040013E9 RID: 5097
			samplerLightMapTex = 1235659916U,
			// Token: 0x040013EA RID: 5098
			IndoorHiliteTerrainHighWithBlendedPaint = 2388673730U,
			// Token: 0x040013EB RID: 5099
			gammaCorrection = 2919544676U,
			// Token: 0x040013EC RID: 5100
			BltYCoCg = 183364706U,
			// Token: 0x040013ED RID: 5101
			samplerg_SsaoBuffer = 2615999593U,
			// Token: 0x040013EE RID: 5102
			gShadowAttenuationUsage = 320558993U,
			// Token: 0x040013EF RID: 5103
			NameBillboard = 869158541U,
			// Token: 0x040013F0 RID: 5104
			PickBillboard = 990485355U,
			// Token: 0x040013F1 RID: 5105
			WriteDepthMask = 2979854677U,
			// Token: 0x040013F2 RID: 5106
			LargeObject = 1492535787U,
			// Token: 0x040013F3 RID: 5107
			TranslucencyParams = 2530739360U,
			// Token: 0x040013F4 RID: 5108
			samplerObjOutlineColorStateTexture = 3936044965U,
			// Token: 0x040013F5 RID: 5109
			RefractionNormalMapScale = 1030115765U,
			// Token: 0x040013F6 RID: 5110
			g_hsv_tweaker_ps_params = 4286001655U,
			// Token: 0x040013F7 RID: 5111
			NormalMapTileable = 3556618410U,
			// Token: 0x040013F8 RID: 5112
			SsaoDepthWall = 1756194602U,
			// Token: 0x040013F9 RID: 5113
			DiffUVScale = 193095205U,
			// Token: 0x040013FA RID: 5114
			ShadowDecalDebug = 265096013U,
			// Token: 0x040013FB RID: 5115
			color = 2954315994U,
			// Token: 0x040013FC RID: 5116
			Ssao = 689351603U,
			// Token: 0x040013FD RID: 5117
			samplerFloorGridMap = 345314335U,
			// Token: 0x040013FE RID: 5118
			SunDarkCloudColor = 280427265U,
			// Token: 0x040013FF RID: 5119
			samplerSkinToneAndMakeupTexture = 3517602627U,
			// Token: 0x04001400 RID: 5120
			samplerg_hsv_tweaker_offset_texture = 3485256590U,
			// Token: 0x04001401 RID: 5121
			BoundaryColors = 575154199U,
			// Token: 0x04001402 RID: 5122
			CASHighlightTint = 248518227U,
			// Token: 0x04001403 RID: 5123
			PosUVScalesScaled = 3559480647U,
			// Token: 0x04001404 RID: 5124
			g_lot_terrain_spec_paint_ps_params = 3790380776U,
			// Token: 0x04001405 RID: 5125
			samplerTerrainCubeMap = 2494925313U,
			// Token: 0x04001406 RID: 5126
			FloorGridMap = 2127581277U,
			// Token: 0x04001407 RID: 5127
			LightBackside = 262552439U,
			// Token: 0x04001408 RID: 5128
			LightBillboard = 946450320U,
			// Token: 0x04001409 RID: 5129
			BlockHighlight = 4081524736U,
			// Token: 0x0400140A RID: 5130
			bIsWorldBrush = 245704789U,
			// Token: 0x0400140B RID: 5131
			PickParticleAnim = 583195899U,
			// Token: 0x0400140C RID: 5132
			samplerRefractionNormalMap = 336207199U,
			// Token: 0x0400140D RID: 5133
			UVScaleShift = 440923126U,
			// Token: 0x0400140E RID: 5134
			Expand = 3436031589U,
			// Token: 0x0400140F RID: 5135
			samplerSunTexture = 224011944U,
			// Token: 0x04001410 RID: 5136
			samplerClothWithAlphaTexture = 2441650740U,
			// Token: 0x04001411 RID: 5137
			EmissiveMap = 4041229310U,
			// Token: 0x04001412 RID: 5138
			SsaoDepth_WallTopBottom = 1760158927U,
			// Token: 0x04001413 RID: 5139
			GhostMaskTexture = 238253335U,
			// Token: 0x04001414 RID: 5140
			FloorFeatures = 1981783012U,
			// Token: 0x04001415 RID: 5141
			PickWallsEmptyResult = 3805381275U,
			// Token: 0x04001416 RID: 5142
			PickModularFloorPiece = 2994184960U,
			// Token: 0x04001417 RID: 5143
			NightOpacity = 2988347388U,
			// Token: 0x04001418 RID: 5144
			ColumnMode = 3046444574U,
			// Token: 0x04001419 RID: 5145
			CubeEnvMap = 2042907803U,
			// Token: 0x0400141A RID: 5146
			samplerProceduralLightmap = 2745298584U,
			// Token: 0x0400141B RID: 5147
			samplerRefractionMap = 2844942980U,
			// Token: 0x0400141C RID: 5148
			ScrollAlpha = 684795490U,
			// Token: 0x0400141D RID: 5149
			debugui = 4035433560U,
			// Token: 0x0400141E RID: 5150
			SortPostAlpha = 1505546421U,
			// Token: 0x0400141F RID: 5151
			BltChannel = 3924782570U,
			// Token: 0x04001420 RID: 5152
			paint_colorMap = 3061119479U,
			// Token: 0x04001421 RID: 5153
			kHeightDataScale = 785656861U,
			// Token: 0x04001422 RID: 5154
			gShadowAttenuationControl = 3301325259U,
			// Token: 0x04001423 RID: 5155
			BlurBlurLevel = 3540726697U,
			// Token: 0x04001424 RID: 5156
			specScales = 2333701849U,
			// Token: 0x04001425 RID: 5157
			kInteriorFloorCausticsScale = 1825817329U,
			// Token: 0x04001426 RID: 5158
			HeightMapBrush = 321494098U,
			// Token: 0x04001427 RID: 5159
			BakedLightMap = 1894696520U,
			// Token: 0x04001428 RID: 5160
			samplerOverlayLightMap = 1444263259U,
			// Token: 0x04001429 RID: 5161
			PickGizmo = 2213821824U,
			// Token: 0x0400142A RID: 5162
			TerrainLight_SunShadowOnly = 3814058497U,
			// Token: 0x0400142B RID: 5163
			WaterLightMap = 2902136628U,
			// Token: 0x0400142C RID: 5164
			SimGhost = 2501288791U,
			// Token: 0x0400142D RID: 5165
			samplerCASRoomCubeMap = 3182425450U,
			// Token: 0x0400142E RID: 5166
			samplerRenderPickMap = 3398117946U,
			// Token: 0x0400142F RID: 5167
			Caustics = 2658898058U,
			// Token: 0x04001430 RID: 5168
			ShadowDecalMap = 1346634978U,
			// Token: 0x04001431 RID: 5169
			PoolWindow = 2925572255U,
			// Token: 0x04001432 RID: 5170
			kMaxRegularAlpha = 3876630066U,
			// Token: 0x04001433 RID: 5171
			RenderPickTest = 1653169370U,
			// Token: 0x04001434 RID: 5172
			cxmul = 1226817622U,
			// Token: 0x04001435 RID: 5173
			samplerpaint_blendMap2 = 2593866493U,
			// Token: 0x04001436 RID: 5174
			samplerpaint_blendMap1,
			// Token: 0x04001437 RID: 5175
			WriteAlphaOnZ = 1884748489U,
			// Token: 0x04001438 RID: 5176
			ShadowPosition = 471547452U,
			// Token: 0x04001439 RID: 5177
			gPosConv = 4079991064U,
			// Token: 0x0400143A RID: 5178
			WindMagnitude = 340077587U,
			// Token: 0x0400143B RID: 5179
			ResizeZToDepthRawZ = 695198065U,
			// Token: 0x0400143C RID: 5180
			HighlightDefault = 510800050U,
			// Token: 0x0400143D RID: 5181
			samplerg_zBuffer = 1642140155U,
			// Token: 0x0400143E RID: 5182
			samplerDiffuseMapAtlas = 3676416832U,
			// Token: 0x0400143F RID: 5183
			BaseTime = 1829873937U,
			// Token: 0x04001440 RID: 5184
			instancedGlass = 1068219516U,
			// Token: 0x04001441 RID: 5185
			PickInstancedVertexAnim = 2109304440U,
			// Token: 0x04001442 RID: 5186
			CASPickDir = 20175828U,
			// Token: 0x04001443 RID: 5187
			CPUSkintone = 3782865078U,
			// Token: 0x04001444 RID: 5188
			HighlightData = 568092911U,
			// Token: 0x04001445 RID: 5189
			WriteBlurInAlphaRawZ = 1037689360U,
			// Token: 0x04001446 RID: 5190
			TintedMirror = 2929728080U,
			// Token: 0x04001447 RID: 5191
			UVAlpha = 737803860U,
			// Token: 0x04001448 RID: 5192
			samplerCASHighlightTexture = 1287047583U,
			// Token: 0x04001449 RID: 5193
			CASMedatorLighting = 625159426U,
			// Token: 0x0400144A RID: 5194
			LightmapAlphaEmissive = 1377476864U,
			// Token: 0x0400144B RID: 5195
			Burn = 1410848354U,
			// Token: 0x0400144C RID: 5196
			TerrainChunkPosition = 119910782U,
			// Token: 0x0400144D RID: 5197
			ReflectionBlend = 2707550379U,
			// Token: 0x0400144E RID: 5198
			RoadObjectPhong = 1996625220U,
			// Token: 0x0400144F RID: 5199
			SpecUVScale = 4280935609U,
			// Token: 0x04001450 RID: 5200
			painting = 2856933409U,
			// Token: 0x04001451 RID: 5201
			ClipSpaceOffset = 4104438258U,
			// Token: 0x04001452 RID: 5202
			g_lotpaint_vs_params = 3848143911U,
			// Token: 0x04001453 RID: 5203
			FountainWater = 690816042U,
			// Token: 0x04001454 RID: 5204
			UseVertAlpha = 3274529685U,
			// Token: 0x04001455 RID: 5205
			HighlightSimGhost = 209152729U,
			// Token: 0x04001456 RID: 5206
			samplerLightsAnimGradientMap = 2448508759U,
			// Token: 0x04001457 RID: 5207
			DiffuseMapAtlas = 3025685082U,
			// Token: 0x04001458 RID: 5208
			TerrainLightmapScale = 3279649976U,
			// Token: 0x04001459 RID: 5209
			ThumbnailEnvironment = 4198904942U,
			// Token: 0x0400145A RID: 5210
			gPosToUVSrc = 824308978U,
			// Token: 0x0400145B RID: 5211
			CASRimFalloff = 931511054U,
			// Token: 0x0400145C RID: 5212
			LightMesh = 1982860912U,
			// Token: 0x0400145D RID: 5213
			AnimatedGrassViewMatrix = 3768660328U,
			// Token: 0x0400145E RID: 5214
			staticTerrainCompositor = 4217794805U,
			// Token: 0x0400145F RID: 5215
			SingleObjectVisualizer = 1390438664U,
			// Token: 0x04001460 RID: 5216
			SecondaryLightmap = 1533515787U,
			// Token: 0x04001461 RID: 5217
			samplerCubeEnvMap = 3766080173U,
			// Token: 0x04001462 RID: 5218
			BurnDebug = 584510619U,
			// Token: 0x04001463 RID: 5219
			samplerDiffuseMap2 = 148578147U,
			// Token: 0x04001464 RID: 5220
			SpecMapTileable = 1451039402U,
			// Token: 0x04001465 RID: 5221
			AlphaMaskThresholdDiv255 = 603107999U,
			// Token: 0x04001466 RID: 5222
			DiffuseScrollSpeed = 4061275451U,
			// Token: 0x04001467 RID: 5223
			OpaqueWindowColor = 1379670613U,
			// Token: 0x04001468 RID: 5224
			specMap4 = 4187304714U,
			// Token: 0x04001469 RID: 5225
			BltVolume = 546233027U,
			// Token: 0x0400146A RID: 5226
			specMap2 = 4187304716U,
			// Token: 0x0400146B RID: 5227
			GenerateWindowLightmap = 4100005754U,
			// Token: 0x0400146C RID: 5228
			specMap3 = 4187304717U,
			// Token: 0x0400146D RID: 5229
			TerrainMaskOnly = 79274198U,
			// Token: 0x0400146E RID: 5230
			paint_blendMap1 = 2296765008U,
			// Token: 0x0400146F RID: 5231
			paint_blendMap2 = 2296765011U,
			// Token: 0x04001470 RID: 5232
			DiffuseScale = 1044340101U,
			// Token: 0x04001471 RID: 5233
			LightmapLightDirection = 4243326632U,
			// Token: 0x04001472 RID: 5234
			samplerMapPack = 282992108U,
			// Token: 0x04001473 RID: 5235
			AnimatedTree = 1233806186U,
			// Token: 0x04001474 RID: 5236
			HsvTweaker = 3515606077U,
			// Token: 0x04001475 RID: 5237
			CASHotSpotAtlas = 188567266U,
			// Token: 0x04001476 RID: 5238
			WorldBuilderPaintingMaskColor = 1170628809U,
			// Token: 0x04001477 RID: 5239
			FloorThicknessTexture = 1576313150U,
			// Token: 0x04001478 RID: 5240
			SsaoRawZ = 1626930991U,
			// Token: 0x04001479 RID: 5241
			LightsAnimGradientMap = 2947160889U,
			// Token: 0x0400147A RID: 5242
			Bloom_DownSampleAndMask = 879824370U,
			// Token: 0x0400147B RID: 5243
			TextureWrap = 48307102U,
			// Token: 0x0400147C RID: 5244
			CASBurntTexture = 4253321770U,
			// Token: 0x0400147D RID: 5245
			g_ssao_filter_ps_params = 3279489939U,
			// Token: 0x0400147E RID: 5246
			BrushPositionAndData = 2508461977U,
			// Token: 0x0400147F RID: 5247
			SpecularEnvMap = 239611671U,
			// Token: 0x04001480 RID: 5248
			backdrop = 1001177303U,
			// Token: 0x04001481 RID: 5249
			SpecularStrength = 1329954709U,
			// Token: 0x04001482 RID: 5250
			WorldBuilderBrushShapeColor = 4109262736U,
			// Token: 0x04001483 RID: 5251
			FloorCubeMap = 433562560U,
			// Token: 0x04001484 RID: 5252
			InstancedVisualizer = 1393673572U,
			// Token: 0x04001485 RID: 5253
			HighlightSim = 10809460U,
			// Token: 0x04001486 RID: 5254
			ApplyGaussianBlurUsingFullZRawZ = 3876188110U,
			// Token: 0x04001487 RID: 5255
			CASGrubbyTexture = 4072283910U,
			// Token: 0x04001488 RID: 5256
			GenerateRectAreaLightmap = 636481347U,
			// Token: 0x04001489 RID: 5257
			ShadowmapTypeDepthNV = 2500307156U,
			// Token: 0x0400148A RID: 5258
			SpecularPower = 977294285U,
			// Token: 0x0400148B RID: 5259
			ShadowTint = 3067310814U,
			// Token: 0x0400148C RID: 5260
			samplerspecMap2 = 3508624722U,
			// Token: 0x0400148D RID: 5261
			samplerspecMap3,
			// Token: 0x0400148E RID: 5262
			GeomorphDistances = 3578847958U,
			// Token: 0x0400148F RID: 5263
			samplerspecMap4 = 3508624724U,
			// Token: 0x04001490 RID: 5264
			SsaoDepth_LotTerrainAndFloors = 2782309125U,
			// Token: 0x04001491 RID: 5265
			windDirection2 = 3523898524U,
			// Token: 0x04001492 RID: 5266
			SsaoDepth_PlumbBob = 2916507152U,
			// Token: 0x04001493 RID: 5267
			gIntensityBuffer = 1156619045U,
			// Token: 0x04001494 RID: 5268
			cxadd = 1511448773U,
			// Token: 0x04001495 RID: 5269
			clouds = 3464232719U,
			// Token: 0x04001496 RID: 5270
			diffuse = 1669179909U,
			// Token: 0x04001497 RID: 5271
			LightingScale = 417655101U,
			// Token: 0x04001498 RID: 5272
			showSingleLayer = 1841079293U,
			// Token: 0x04001499 RID: 5273
			trivial = 1886105036U,
			// Token: 0x0400149A RID: 5274
			samplerSpecMapTileable = 2506365892U,
			// Token: 0x0400149B RID: 5275
			HiliteTerrainHighWithBlendedPaint = 3869100565U,
			// Token: 0x0400149C RID: 5276
			InstancedWindowLOD = 168805281U,
			// Token: 0x0400149D RID: 5277
			StaticLightData = 2147215005U,
			// Token: 0x0400149E RID: 5278
			wallTopBottomColor = 1610543052U,
			// Token: 0x0400149F RID: 5279
			ScrollSpeedDetail = 3677432144U,
			// Token: 0x040014A0 RID: 5280
			CausticNormalSampleScale1 = 1438441727U,
			// Token: 0x040014A1 RID: 5281
			ClothWithAlphaTexture = 1777200286U,
			// Token: 0x040014A2 RID: 5282
			samplerOverlaySpecularMap = 894474988U,
			// Token: 0x040014A3 RID: 5283
			RefractionMap = 327887430U,
			// Token: 0x040014A4 RID: 5284
			StairRailings = 3146098103U,
			// Token: 0x040014A5 RID: 5285
			samplerblendMap2 = 3634464276U,
			// Token: 0x040014A6 RID: 5286
			DiffuseMapTileable = 2870659725U,
			// Token: 0x040014A7 RID: 5287
			bIsWorldRoutable = 2769084565U,
			// Token: 0x040014A8 RID: 5288
			samplerSpecMapAtlas = 5365453U,
			// Token: 0x040014A9 RID: 5289
			g_lot_terrain_paint_ps_params = 1762603762U,
			// Token: 0x040014AA RID: 5290
			NormalMapTileableScale = 1938392532U,
			// Token: 0x040014AB RID: 5291
			detail = 1594510218U,
			// Token: 0x040014AC RID: 5292
			viewDistanceBasis = 1491101787U,
			// Token: 0x040014AD RID: 5293
			samplerEmissiveMap = 4155185216U,
			// Token: 0x040014AE RID: 5294
			HighlightStairs = 790546029U,
			// Token: 0x040014AF RID: 5295
			ShadowOpacity = 2525894748U,
			// Token: 0x040014B0 RID: 5296
			ShadowMapTypeDepthATI = 2199232660U,
			// Token: 0x040014B1 RID: 5297
			TextureClamp_V = 1363460392U,
			// Token: 0x040014B2 RID: 5298
			TextureClamp_U = 1363460395U,
			// Token: 0x040014B3 RID: 5299
			DiffuseColumnRowCount = 128133846U,
			// Token: 0x040014B4 RID: 5300
			lightAndFog = 1615212478U,
			// Token: 0x040014B5 RID: 5301
			CASRoomCubeMap = 3092814852U,
			// Token: 0x040014B6 RID: 5302
			DayOpacity = 396886800U,
			// Token: 0x040014B7 RID: 5303
			PointLightTemplates = 3485939620U,
			// Token: 0x040014B8 RID: 5304
			CustomBlockGrid = 1109162987U,
			// Token: 0x040014B9 RID: 5305
			phongglass = 3574056862U,
			// Token: 0x040014BA RID: 5306
			FlipSpeed = 3118978621U,
			// Token: 0x040014BB RID: 5307
			AlwaysUseRigLighting = 2290788411U,
			// Token: 0x040014BC RID: 5308
			CASHighlightAddScale = 15983885U,
			// Token: 0x040014BD RID: 5309
			GenerateTubeLightmap = 2021161488U,
			// Token: 0x040014BE RID: 5310
			TerrainLightmapGeneration = 1343024580U,
			// Token: 0x040014BF RID: 5311
			SsaoDepthWallWithCutout = 1882100858U,
			// Token: 0x040014C0 RID: 5312
			TerrainShadowOnly = 2496276914U,
			// Token: 0x040014C1 RID: 5313
			DetailNormalUVScale = 1444798224U,
			// Token: 0x040014C2 RID: 5314
			PooledMeshFallbackShadows = 3453167076U,
			// Token: 0x040014C3 RID: 5315
			g_colorTexture = 3679692081U,
			// Token: 0x040014C4 RID: 5316
			samplerBurnNoiseTexture = 2988743159U,
			// Token: 0x040014C5 RID: 5317
			PickStairs = 3857436004U,
			// Token: 0x040014C6 RID: 5318
			Censor = 1350838219U,
			// Token: 0x040014C7 RID: 5319
			CASHighlightEnable = 4100794729U,
			// Token: 0x040014C8 RID: 5320
			samplerSpecMap = 1115752736U,
			// Token: 0x040014C9 RID: 5321
			NextFloorLightBasisMap0 = 4186387516U,
			// Token: 0x040014CA RID: 5322
			ColorVisualizer = 4087293278U,
			// Token: 0x040014CB RID: 5323
			NextFloorLightBasisMap1 = 4186387517U,
			// Token: 0x040014CC RID: 5324
			NextFloorLightBasisMap2,
			// Token: 0x040014CD RID: 5325
			NextFloorLightBasisMap3,
			// Token: 0x040014CE RID: 5326
			SsaoDepth_Terrain = 1192069476U,
			// Token: 0x040014CF RID: 5327
			Dof = 546651180U,
			// Token: 0x040014D0 RID: 5328
			WallTopBottom = 707261915U,
			// Token: 0x040014D1 RID: 5329
			samplerPlumbBobCubeMap = 2330613845U,
			// Token: 0x040014D2 RID: 5330
			InstancedTreeBillboard = 1468103297U,
			// Token: 0x040014D3 RID: 5331
			charMapTexture = 4120962498U,
			// Token: 0x040014D4 RID: 5332
			PickPhong = 3055534916U,
			// Token: 0x040014D5 RID: 5333
			samplerSpecPaintTexture = 3765114287U,
			// Token: 0x040014D6 RID: 5334
			InstancedVisualizerFast = 1408470574U,
			// Token: 0x040014D7 RID: 5335
			Roughness = 3774096113U,
			// Token: 0x040014D8 RID: 5336
			Brightness = 4100859180U,
			// Token: 0x040014D9 RID: 5337
			SimpleTree = 2892154263U,
			// Token: 0x040014DA RID: 5338
			ApplyScattering = 3126217793U,
			// Token: 0x040014DB RID: 5339
			CausticsUVScale = 2675114251U,
			// Token: 0x040014DC RID: 5340
			kTiledUVDecompressionScale = 3301087324U,
			// Token: 0x040014DD RID: 5341
			OpaqueWindow = 2342490984U,
			// Token: 0x040014DE RID: 5342
			samplerWaterLightMap = 3909387510U,
			// Token: 0x040014DF RID: 5343
			Billboard = 4277232958U,
			// Token: 0x040014E0 RID: 5344
			samplerNormalMapTileable = 3629436456U,
			// Token: 0x040014E1 RID: 5345
			LightsMap = 568100360U,
			// Token: 0x040014E2 RID: 5346
			TranslucencyEnabled = 1466868981U,
			// Token: 0x040014E3 RID: 5347
			HighlightCounter = 3709275241U,
			// Token: 0x040014E4 RID: 5348
			DetailNormalMapScale = 2313949055U,
			// Token: 0x040014E5 RID: 5349
			SimGlass = 1591385310U,
			// Token: 0x040014E6 RID: 5350
			SimPreview = 1613703190U,
			// Token: 0x040014E7 RID: 5351
			NormalMapAtlasScale = 3479853235U,
			// Token: 0x040014E8 RID: 5352
			samplergIntensityBuffer = 3632437959U,
			// Token: 0x040014E9 RID: 5353
			specular = 752949314U,
			// Token: 0x040014EA RID: 5354
			SsaoDepth_Backdrop = 3252106067U,
			// Token: 0x040014EB RID: 5355
			billboardOrigin = 1211876916U,
			// Token: 0x040014EC RID: 5356
			kAtlasUVDecompressionScale = 3614559637U,
			// Token: 0x040014ED RID: 5357
			PickSimGhost = 4203404140U,
			// Token: 0x040014EE RID: 5358
			BurnNoiseTexture = 2670592921U,
			// Token: 0x040014EF RID: 5359
			kRPSearchOrder = 392524018U,
			// Token: 0x040014F0 RID: 5360
			ApplyGaussianBlurUsingFullZ = 24154542U,
			// Token: 0x040014F1 RID: 5361
			samplerOverlayNormalMap = 2873678846U,
			// Token: 0x040014F2 RID: 5362
			ReflectionColor = 3122023791U,
			// Token: 0x040014F3 RID: 5363
			DistBasedFilter = 346814084U,
			// Token: 0x040014F4 RID: 5364
			HorizonDarkCloudColor = 1152275550U,
			// Token: 0x040014F5 RID: 5365
			CASBodyPartHighlightInfo = 3322259697U,
			// Token: 0x040014F6 RID: 5366
			SsaoDepth_Instanced = 147603652U,
			// Token: 0x040014F7 RID: 5367
			UseYRotBillboard = 1181233615U,
			// Token: 0x040014F8 RID: 5368
			ModularFloorPiece = 3717940257U,
			// Token: 0x040014F9 RID: 5369
			smallMultiplier = 2220732491U,
			// Token: 0x040014FA RID: 5370
			g_DofGaussian_vs_params = 3010652048U,
			// Token: 0x040014FB RID: 5371
			CreateIntensityMaskWithZ = 1224894422U,
			// Token: 0x040014FC RID: 5372
			gBloomInputTexture = 1905007376U,
			// Token: 0x040014FD RID: 5373
			samplerpaint_colorMap3 = 3698442816U,
			// Token: 0x040014FE RID: 5374
			samplerSpecularEnvMap = 3650058685U,
			// Token: 0x040014FF RID: 5375
			samplerpaint_colorMap2 = 3698442817U,
			// Token: 0x04001500 RID: 5376
			samplerpaint_colorMap1,
			// Token: 0x04001501 RID: 5377
			SimSkinWithTone = 1203231173U,
			// Token: 0x04001502 RID: 5378
			p7 = 3698442820U,
			// Token: 0x04001503 RID: 5379
			samplerpaint_colorMap6,
			// Token: 0x04001504 RID: 5380
			samplerpaint_colorMap5,
			// Token: 0x04001505 RID: 5381
			CreateIntensityMask = 2046606396U,
			// Token: 0x04001506 RID: 5382
			samplerpaint_colorMap4 = 3698442823U,
			// Token: 0x04001507 RID: 5383
			WeightedGaussianBlur = 4180605812U,
			// Token: 0x04001508 RID: 5384
			samplerpaint_colorMap8 = 3698442827U,
			// Token: 0x04001509 RID: 5385
			SsaoDepth_Default = 1015697628U,
			// Token: 0x0400150A RID: 5386
			DiffuseMap2 = 3100579949U,
			// Token: 0x0400150B RID: 5387
			UIBillboard = 1025309692U,
			// Token: 0x0400150C RID: 5388
			ReflectionStrength = 1679927433U,
			// Token: 0x0400150D RID: 5389
			Water = 2654748154U,
			// Token: 0x0400150E RID: 5390
			SsaoDepth_Billboard = 3477536050U,
			// Token: 0x0400150F RID: 5391
			samplerPaintTexture = 3784047806U,
			// Token: 0x04001510 RID: 5392
			ProceduralLightmap = 2198600946U,
			// Token: 0x04001511 RID: 5393
			text = 2972449336U,
			// Token: 0x04001512 RID: 5394
			UserControlled = 1741052226U,
			// Token: 0x04001513 RID: 5395
			WaterLightMapOpacity = 4164719219U,
			// Token: 0x04001514 RID: 5396
			OccluderVizColor = 3237126608U
		}

		// Token: 0x020001BE RID: 446
		public enum MATDDataType : uint
		{
			// Token: 0x04001516 RID: 5398
			FloatType = 1U,
			// Token: 0x04001517 RID: 5399
			IntType,
			// Token: 0x04001518 RID: 5400
			Texture = 4U,
			// Token: 0x04001519 RID: 5401
			Image = 65540U,
			// Token: 0x0400151A RID: 5402
			Another_Image = 262148U
		}

		// Token: 0x020001BF RID: 447
		public class MATDEntry
		{
			// Token: 0x060010CD RID: 4301 RVA: 0x0000331D File Offset: 0x0000151D
			public MATDEntry()
			{
			}

			// Token: 0x060010CE RID: 4302 RVA: 0x0000B7D2 File Offset: 0x000099D2
			public MATDEntry(MATD.MATDEntryType Type, MATD.MATDDataType DataType, object[] Data)
			{
				this.Type = Type;
				this.DataType = DataType;
				this.Values = Data;
			}

			// Token: 0x17000557 RID: 1367
			// (get) Token: 0x060010CF RID: 4303 RVA: 0x0000B7EF File Offset: 0x000099EF
			// (set) Token: 0x060010D0 RID: 4304 RVA: 0x0000B7F7 File Offset: 0x000099F7
			public MATD.MATDEntryType Type { get; set; }

			// Token: 0x17000558 RID: 1368
			// (get) Token: 0x060010D1 RID: 4305 RVA: 0x0000B800 File Offset: 0x00009A00
			// (set) Token: 0x060010D2 RID: 4306 RVA: 0x0000B808 File Offset: 0x00009A08
			public MATD.MATDDataType DataType { get; set; }

			// Token: 0x17000559 RID: 1369
			// (get) Token: 0x060010D3 RID: 4307 RVA: 0x0000B811 File Offset: 0x00009A11
			// (set) Token: 0x060010D4 RID: 4308 RVA: 0x0000B819 File Offset: 0x00009A19
			[TypeConverter(typeof(IntTypeConverter))]
			public int NumValues { get; set; }

			// Token: 0x1700055A RID: 1370
			// (get) Token: 0x060010D5 RID: 4309 RVA: 0x0000B822 File Offset: 0x00009A22
			// (set) Token: 0x060010D6 RID: 4310 RVA: 0x0000B82A File Offset: 0x00009A2A
			[TypeConverter(typeof(IntTypeConverter))]
			public uint Offset { get; set; }

			// Token: 0x1700055B RID: 1371
			// (get) Token: 0x060010D7 RID: 4311 RVA: 0x0000B833 File Offset: 0x00009A33
			// (set) Token: 0x060010D8 RID: 4312 RVA: 0x0000B83B File Offset: 0x00009A3B
			[Browsable(false)]
			public byte[] Bytes { get; set; }

			// Token: 0x060010D9 RID: 4313 RVA: 0x00045B60 File Offset: 0x00043D60
			public float[] GetFloatValue()
			{
				float[] array = new float[this.NumValues];
				for (int i = 0; i < this.NumValues; i++)
				{
					array[i] = BitConverter.ToSingle(this.Bytes, 4 * i);
				}
				return array;
			}

			// Token: 0x060010DA RID: 4314 RVA: 0x00045B9C File Offset: 0x00043D9C
			public int[] GetIntValue()
			{
				int[] array = new int[this.NumValues];
				for (int i = 0; i < this.NumValues; i++)
				{
					array[i] = BitConverter.ToInt32(this.Bytes, 4 * i);
				}
				return array;
			}

			// Token: 0x060010DB RID: 4315 RVA: 0x00045BD8 File Offset: 0x00043DD8
			public byte[] GetByteValue()
			{
				byte[] array = new byte[this.NumValues];
				for (int i = 0; i < this.NumValues; i++)
				{
					array[i] = this.Bytes[i];
				}
				return array;
			}

			// Token: 0x1700055C RID: 1372
			// (get) Token: 0x060010DC RID: 4316 RVA: 0x00045C10 File Offset: 0x00043E10
			// (set) Token: 0x060010DD RID: 4317 RVA: 0x00045D24 File Offset: 0x00043F24
			[Browsable(true)]
			public object[] Values
			{
				get
				{
					object[] array = new object[this.NumValues];
					MATD.MATDDataType dataType = this.DataType;
					switch (dataType)
					{
					case MATD.MATDDataType.FloatType:
						for (int i = 0; i < this.NumValues; i++)
						{
							array[i] = BitConverter.ToSingle(this.Bytes, 4 * i);
						}
						return array;
					case MATD.MATDDataType.IntType:
						for (int i = 0; i < this.NumValues; i++)
						{
							array[i] = BitConverter.ToInt32(this.Bytes, 4 * i);
						}
						return array;
					case (MATD.MATDDataType)3U:
						break;
					case MATD.MATDDataType.Texture:
						goto IL_E3;
					default:
						if (dataType == MATD.MATDDataType.Image)
						{
							goto IL_E3;
						}
						if (dataType == MATD.MATDDataType.Another_Image)
						{
							for (int i = 0; i < this.NumValues; i++)
							{
								array[i] = this.GetIntValue()[i];
							}
							return array;
						}
						break;
					}
					for (int i = 0; i < this.NumValues; i++)
					{
						array[i] = BitConverter.ToInt32(this.Bytes, 4 * i);
					}
					return array;
					IL_E3:
					for (int i = 0; i < this.NumValues; i++)
					{
						array[i] = this.GetIntValue()[i];
					}
					return array;
				}
				set
				{
					this.NumValues = value.Length;
					this.Bytes = new byte[this.NumValues * 4];
					MATD.MATDDataType dataType = this.DataType;
					switch (dataType)
					{
					case MATD.MATDDataType.FloatType:
						for (int i = 0; i < this.NumValues; i++)
						{
							Array.Copy(BitConverter.GetBytes((float)value[i]), 0, this.Bytes, i * 4, 4);
						}
						return;
					case MATD.MATDDataType.IntType:
						for (int i = 0; i < this.NumValues; i++)
						{
							Array.Copy(BitConverter.GetBytes((int)value[i]), 0, this.Bytes, i * 4, 4);
						}
						return;
					case (MATD.MATDDataType)3U:
						break;
					case MATD.MATDDataType.Texture:
						goto IL_111;
					default:
						if (dataType == MATD.MATDDataType.Image)
						{
							goto IL_111;
						}
						if (dataType == MATD.MATDDataType.Another_Image)
						{
							for (int i = 0; i < this.NumValues; i++)
							{
								Array.Copy(BitConverter.GetBytes((int)value[i]), 0, this.Bytes, i * 4, 4);
							}
							return;
						}
						break;
					}
					for (int i = 0; i < this.NumValues; i++)
					{
						Array.Copy(BitConverter.GetBytes((float)value[i]), 0, this.Bytes, i * 4, 4);
					}
					return;
					IL_111:
					for (int i = 0; i < this.NumValues; i++)
					{
						Array.Copy(BitConverter.GetBytes((int)value[i]), 0, this.Bytes, i * 4, 4);
					}
				}
			}

			// Token: 0x060010DE RID: 4318 RVA: 0x0000B844 File Offset: 0x00009A44
			public MATD.MATDEntry Clone()
			{
				return (MATD.MATDEntry)base.MemberwiseClone();
			}

			// Token: 0x060010DF RID: 4319 RVA: 0x00045E70 File Offset: 0x00044070
			public override string ToString()
			{
				return this.Type.ToString("G") + ": " + ((this.DataType == MATD.MATDDataType.Another_Image) ? this.GetByteValue().ToString() : ((this.DataType == MATD.MATDDataType.Image) ? this.GetByteValue().ToString() : ((this.DataType == MATD.MATDDataType.Texture) ? this.GetByteValue().ToString() : ((this.DataType == MATD.MATDDataType.IntType) ? this.GetIntValue().ToString() : this.GetFloatValue().ToString()))));
			}
		}

		// Token: 0x020001C0 RID: 448
		public class InternalMATD
		{
			// Token: 0x1700055D RID: 1373
			// (get) Token: 0x060010E0 RID: 4320 RVA: 0x0000B851 File Offset: 0x00009A51
			// (set) Token: 0x060010E1 RID: 4321 RVA: 0x0000B859 File Offset: 0x00009A59
			public GEOM Parent { get; private set; }

			// Token: 0x1700055E RID: 1374
			// (get) Token: 0x060010E2 RID: 4322 RVA: 0x0000B862 File Offset: 0x00009A62
			// (set) Token: 0x060010E3 RID: 4323 RVA: 0x0000B86A File Offset: 0x00009A6A
			[TypeConverter(typeof(IntTypeConverter))]
			public int Type { get; set; }

			// Token: 0x1700055F RID: 1375
			// (get) Token: 0x060010E4 RID: 4324 RVA: 0x0000B873 File Offset: 0x00009A73
			// (set) Token: 0x060010E5 RID: 4325 RVA: 0x0000B87B File Offset: 0x00009A7B
			[TypeConverter(typeof(IntTypeConverter))]
			public int Unk { get; set; }

			// Token: 0x17000560 RID: 1376
			// (get) Token: 0x060010E6 RID: 4326 RVA: 0x0000B884 File Offset: 0x00009A84
			// (set) Token: 0x060010E7 RID: 4327 RVA: 0x0000B88C File Offset: 0x00009A8C
			[TypeConverter(typeof(IntTypeConverter))]
			public int DataSize { get; set; }

			// Token: 0x17000561 RID: 1377
			// (get) Token: 0x060010E8 RID: 4328 RVA: 0x0000B895 File Offset: 0x00009A95
			// (set) Token: 0x060010E9 RID: 4329 RVA: 0x0000B89D File Offset: 0x00009A9D
			public List<MATD.MATDEntry> Entries { get; set; }

			// Token: 0x060010EA RID: 4330 RVA: 0x0000B8A6 File Offset: 0x00009AA6
			public InternalMATD(GEOM parent)
			{
				this.Parent = parent;
			}

			// Token: 0x060010EB RID: 4331 RVA: 0x00045F08 File Offset: 0x00044108
			public object Clone()
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				this.Serialize(binaryWriter);
				memoryStream.Position = 0L;
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				MATD.InternalMATD internalMATD = new MATD.InternalMATD(this.Parent);
				internalMATD.Unserialize(binaryReader);
				binaryReader.Close();
				binaryWriter.Close();
				memoryStream.Dispose();
				return internalMATD;
			}

			// Token: 0x060010EC RID: 4332 RVA: 0x00045F64 File Offset: 0x00044164
			public void CopyTo(MATD.InternalMATD to)
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				this.Serialize(binaryWriter);
				memoryStream.Position = 0L;
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				to.Unserialize(binaryReader);
				binaryReader.Close();
				binaryWriter.Close();
				memoryStream.Dispose();
			}

			// Token: 0x060010ED RID: 4333 RVA: 0x00045FB4 File Offset: 0x000441B4
			public void Unserialize(BinaryReader r)
			{
				this.Entries = new List<MATD.MATDEntry>();
				this.Type = r.ReadInt32();
				this.Unk = r.ReadInt32();
				this.DataSize = r.ReadInt32();
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					MATD.MATDEntry matdentry = new MATD.MATDEntry();
					matdentry.Type = (MATD.MATDEntryType)r.ReadUInt32();
					matdentry.DataType = (MATD.MATDDataType)r.ReadUInt32();
					matdentry.NumValues = r.ReadInt32();
					matdentry.Offset = r.ReadUInt32();
					this.Entries.Add(matdentry);
				}
				foreach (MATD.MATDEntry matdentry2 in this.Entries)
				{
					r.BaseStream.Position = (long)((ulong)matdentry2.Offset);
					matdentry2.Bytes = r.ReadBytes(matdentry2.NumValues * 4);
				}
			}

			// Token: 0x060010EE RID: 4334 RVA: 0x000460B0 File Offset: 0x000442B0
			public void Serialize(BinaryWriter w)
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				MemoryStream memoryStream2 = new MemoryStream();
				BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
				binaryWriter.Write(this.Entries.Count);
				foreach (MATD.MATDEntry matdentry in this.Entries)
				{
					int value = (int)((long)(this.Entries.Count * 16 + 16) + binaryWriter2.BaseStream.Position);
					binaryWriter.Write((uint)matdentry.Type);
					binaryWriter.Write((uint)matdentry.DataType);
					binaryWriter.Write(matdentry.NumValues);
					binaryWriter.Write(value);
					foreach (byte value2 in matdentry.Bytes)
					{
						binaryWriter2.Write(value2);
					}
				}
				binaryWriter.Write(memoryStream2.ToArray());
				w.Write(this.Type);
				w.Write(this.Unk);
				w.Write((int)memoryStream2.Length);
				w.Write(memoryStream.ToArray());
				memoryStream2.Dispose();
				binaryWriter2.Close();
				memoryStream.Dispose();
				binaryWriter.Close();
			}

			// Token: 0x060010EF RID: 4335 RVA: 0x0000B8B5 File Offset: 0x00009AB5
			public override string ToString()
			{
				return "Internal MATD";
			}
		}
	}
}
