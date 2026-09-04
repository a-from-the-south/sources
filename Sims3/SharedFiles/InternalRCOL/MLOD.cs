using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000BF RID: 191
	public class MLOD : RCOLItem
	{
		// Token: 0x1700035E RID: 862
		// (get) Token: 0x060009FD RID: 2557 RVA: 0x00007A61 File Offset: 0x00005C61
		// (set) Token: 0x060009FE RID: 2558 RVA: 0x00007A69 File Offset: 0x00005C69
		[TypeConverter(typeof(IntTypeConverter))]
		public uint TypeId { get; set; }

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x00007A72 File Offset: 0x00005C72
		// (set) Token: 0x06000A00 RID: 2560 RVA: 0x00007A7A File Offset: 0x00005C7A
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Version { get; set; }

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x00007A83 File Offset: 0x00005C83
		// (set) Token: 0x06000A02 RID: 2562 RVA: 0x00007A8B File Offset: 0x00005C8B
		public List<MLOD.MLODEntry> Entries { get; set; }

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x00007A94 File Offset: 0x00005C94
		// (set) Token: 0x06000A04 RID: 2564 RVA: 0x00007A9C File Offset: 0x00005C9C
		[Browsable(false)]
		public RCOL Parent { get; set; }

		// Token: 0x06000A05 RID: 2565 RVA: 0x00007AA5 File Offset: 0x00005CA5
		public MLOD(RCOL parent)
		{
			this.Parent = parent;
			this.Entries = new List<MLOD.MLODEntry>();
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000A06 RID: 2566 RVA: 0x00007ABF File Offset: 0x00005CBF
		[Browsable(false)]
		public byte[] Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x0002FA0C File Offset: 0x0002DC0C
		public override void UnSerialize(BinaryReader reader)
		{
			this.data = reader.ReadBytes((int)reader.BaseStream.Length);
			reader.BaseStream.Position = 0L;
			this.TypeId = reader.ReadUInt32();
			this.Version = reader.ReadUInt32();
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int count = reader.ReadInt32();
				MemoryStream memoryStream = new MemoryStream(reader.ReadBytes(count));
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				MLOD.MLODEntry mlodentry = new MLOD.MLODEntry(this);
				mlodentry.UnSerialize(binaryReader);
				binaryReader.Close();
				memoryStream.Dispose();
				this.Entries.Add(mlodentry);
			}
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x0002FAB4 File Offset: 0x0002DCB4
		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(this.TypeId);
			writer.Write(this.Version);
			writer.Write(this.Entries.Count);
			foreach (MLOD.MLODEntry mlodentry in this.Entries)
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				mlodentry.Serialize(binaryWriter);
				byte[] array = memoryStream.ToArray();
				writer.Write(array.Length);
				writer.Write(array);
				memoryStream.Dispose();
				binaryWriter.Close();
			}
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x0002FB60 File Offset: 0x0002DD60
		public override string ToString()
		{
			return "MLOD - " + this.Entries.Count.ToString() + " subgroups , LOD: 0x" + this.Parent.GroupID.ToString("X8");
		}

		// Token: 0x040004D0 RID: 1232
		[Browsable(false)]
		private byte[] data;

		// Token: 0x020001B0 RID: 432
		public class GeoStateEntry
		{
			// Token: 0x1700050D RID: 1293
			// (get) Token: 0x06001014 RID: 4116 RVA: 0x0000B19F File Offset: 0x0000939F
			// (set) Token: 0x06001015 RID: 4117 RVA: 0x0000B1A7 File Offset: 0x000093A7
			public uint NameHash { get; set; }

			// Token: 0x1700050E RID: 1294
			// (get) Token: 0x06001016 RID: 4118 RVA: 0x0000B1B0 File Offset: 0x000093B0
			// (set) Token: 0x06001017 RID: 4119 RVA: 0x0000B1B8 File Offset: 0x000093B8
			public int IBUFOffset { get; set; }

			// Token: 0x1700050F RID: 1295
			// (get) Token: 0x06001018 RID: 4120 RVA: 0x0000B1C1 File Offset: 0x000093C1
			// (set) Token: 0x06001019 RID: 4121 RVA: 0x0000B1C9 File Offset: 0x000093C9
			public int VBUFOffset { get; set; }

			// Token: 0x17000510 RID: 1296
			// (get) Token: 0x0600101A RID: 4122 RVA: 0x0000B1D2 File Offset: 0x000093D2
			// (set) Token: 0x0600101B RID: 4123 RVA: 0x0000B1DA File Offset: 0x000093DA
			public int VertexCount { get; set; }

			// Token: 0x17000511 RID: 1297
			// (get) Token: 0x0600101C RID: 4124 RVA: 0x0000B1E3 File Offset: 0x000093E3
			// (set) Token: 0x0600101D RID: 4125 RVA: 0x0000B1EB File Offset: 0x000093EB
			public int FaceCount { get; set; }

			// Token: 0x0600101E RID: 4126 RVA: 0x0000B1F4 File Offset: 0x000093F4
			public void Unserialize(BinaryReader r)
			{
				this.NameHash = r.ReadUInt32();
				this.IBUFOffset = r.ReadInt32();
				this.VBUFOffset = r.ReadInt32();
				this.VertexCount = r.ReadInt32();
				this.FaceCount = r.ReadInt32();
			}

			// Token: 0x0600101F RID: 4127 RVA: 0x0000B232 File Offset: 0x00009432
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.NameHash);
				w.Write(this.IBUFOffset);
				w.Write(this.VBUFOffset);
				w.Write(this.VertexCount);
				w.Write(this.FaceCount);
			}

			// Token: 0x06001020 RID: 4128 RVA: 0x0000B270 File Offset: 0x00009470
			public override string ToString()
			{
				return "Geostateentry";
			}
		}

		// Token: 0x020001B1 RID: 433
		public enum PrimitiveType : byte
		{
			// Token: 0x04000D1C RID: 3356
			PointList,
			// Token: 0x04000D1D RID: 3357
			LineList,
			// Token: 0x04000D1E RID: 3358
			LineStrip,
			// Token: 0x04000D1F RID: 3359
			TriangleList,
			// Token: 0x04000D20 RID: 3360
			TriangleFan,
			// Token: 0x04000D21 RID: 3361
			TriangleStrip,
			// Token: 0x04000D22 RID: 3362
			QuadList,
			// Token: 0x04000D23 RID: 3363
			DisplayList
		}

		// Token: 0x020001B2 RID: 434
		[Flags]
		public enum MeshFlags : byte
		{
			// Token: 0x04000D25 RID: 3365
			BasinInterior = 1,
			// Token: 0x04000D26 RID: 3366
			HDExteriorLit = 2,
			// Token: 0x04000D27 RID: 3367
			PortalSide = 4,
			// Token: 0x04000D28 RID: 3368
			DropShadow = 8,
			// Token: 0x04000D29 RID: 3369
			ShadowCaster = 16,
			// Token: 0x04000D2A RID: 3370
			Foundation = 32,
			// Token: 0x04000D2B RID: 3371
			Pickable = 64
		}

		// Token: 0x020001B3 RID: 435
		public class MLODEntry : RCOLItem, ICloneable
		{
			// Token: 0x17000512 RID: 1298
			// (get) Token: 0x06001022 RID: 4130 RVA: 0x0000B277 File Offset: 0x00009477
			// (set) Token: 0x06001023 RID: 4131 RVA: 0x0000B27F File Offset: 0x0000947F
			[Browsable(false)]
			public string Name { get; set; }

			// Token: 0x17000513 RID: 1299
			// (get) Token: 0x06001024 RID: 4132 RVA: 0x0000B288 File Offset: 0x00009488
			// (set) Token: 0x06001025 RID: 4133 RVA: 0x0000B290 File Offset: 0x00009490
			[Browsable(false)]
			public string AliasKey { get; set; }

			// Token: 0x17000514 RID: 1300
			// (get) Token: 0x06001026 RID: 4134 RVA: 0x0000B299 File Offset: 0x00009499
			// (set) Token: 0x06001027 RID: 4135 RVA: 0x0000B2A1 File Offset: 0x000094A1
			[Browsable(false)]
			public bool Expanded { get; set; }

			// Token: 0x17000515 RID: 1301
			// (get) Token: 0x06001028 RID: 4136 RVA: 0x0000B2AA File Offset: 0x000094AA
			// (set) Token: 0x06001029 RID: 4137 RVA: 0x0000B2B2 File Offset: 0x000094B2
			[Browsable(false)]
			public bool Visible { get; set; }

			// Token: 0x17000516 RID: 1302
			// (get) Token: 0x0600102A RID: 4138 RVA: 0x0000B2BB File Offset: 0x000094BB
			// (set) Token: 0x0600102B RID: 4139 RVA: 0x0000B2C3 File Offset: 0x000094C3
			[TypeConverter(typeof(IntTypeConverter))]
			public int MATDIndex { get; set; }

			// Token: 0x17000517 RID: 1303
			// (get) Token: 0x0600102C RID: 4140 RVA: 0x0000B2CC File Offset: 0x000094CC
			// (set) Token: 0x0600102D RID: 4141 RVA: 0x0000B2D4 File Offset: 0x000094D4
			[TypeConverter(typeof(IntTypeConverter))]
			public int VRTFIndex { get; set; }

			// Token: 0x17000518 RID: 1304
			// (get) Token: 0x0600102E RID: 4142 RVA: 0x0000B2DD File Offset: 0x000094DD
			// (set) Token: 0x0600102F RID: 4143 RVA: 0x0000B2E5 File Offset: 0x000094E5
			[TypeConverter(typeof(IntTypeConverter))]
			public int VBUFIndex { get; set; }

			// Token: 0x17000519 RID: 1305
			// (get) Token: 0x06001030 RID: 4144 RVA: 0x0000B2EE File Offset: 0x000094EE
			// (set) Token: 0x06001031 RID: 4145 RVA: 0x0000B2F6 File Offset: 0x000094F6
			[TypeConverter(typeof(IntTypeConverter))]
			public int IBUFIndex { get; set; }

			// Token: 0x1700051A RID: 1306
			// (get) Token: 0x06001032 RID: 4146 RVA: 0x0000B2FF File Offset: 0x000094FF
			// (set) Token: 0x06001033 RID: 4147 RVA: 0x0000B307 File Offset: 0x00009507
			[TypeConverter(typeof(IntTypeConverter))]
			private uint VBUFType { get; set; }

			// Token: 0x1700051B RID: 1307
			// (get) Token: 0x06001034 RID: 4148 RVA: 0x0000B310 File Offset: 0x00009510
			[TypeConverter(typeof(IntTypeConverter))]
			public long VBUFOffset
			{
				get
				{
					return this._vbuffOffset;
				}
			}

			// Token: 0x1700051C RID: 1308
			// (get) Token: 0x06001035 RID: 4149 RVA: 0x0000B318 File Offset: 0x00009518
			// (set) Token: 0x06001036 RID: 4150 RVA: 0x0000B320 File Offset: 0x00009520
			[TypeConverter(typeof(IntTypeConverter))]
			public long IBUFOffset { get; set; }

			// Token: 0x1700051D RID: 1309
			// (get) Token: 0x06001037 RID: 4151 RVA: 0x0000B329 File Offset: 0x00009529
			// (set) Token: 0x06001038 RID: 4152 RVA: 0x0000B331 File Offset: 0x00009531
			[TypeConverter(typeof(IntTypeConverter))]
			public uint NameHash { get; set; }

			// Token: 0x1700051E RID: 1310
			// (get) Token: 0x06001039 RID: 4153 RVA: 0x0000B33A File Offset: 0x0000953A
			// (set) Token: 0x0600103A RID: 4154 RVA: 0x0000B342 File Offset: 0x00009542
			[TypeConverter(typeof(IntTypeConverter))]
			public int GeostateCount { get; set; }

			// Token: 0x1700051F RID: 1311
			// (get) Token: 0x0600103B RID: 4155 RVA: 0x0000B34B File Offset: 0x0000954B
			// (set) Token: 0x0600103C RID: 4156 RVA: 0x0000B353 File Offset: 0x00009553
			[TypeConverter(typeof(IntTypeConverter))]
			public int VBUFCount { get; set; }

			// Token: 0x17000520 RID: 1312
			// (get) Token: 0x0600103D RID: 4157 RVA: 0x0000B35C File Offset: 0x0000955C
			// (set) Token: 0x0600103E RID: 4158 RVA: 0x0000B364 File Offset: 0x00009564
			[TypeConverter(typeof(IntTypeConverter))]
			public int IBUFCount { get; set; }

			// Token: 0x17000521 RID: 1313
			// (get) Token: 0x0600103F RID: 4159 RVA: 0x0000B36D File Offset: 0x0000956D
			// (set) Token: 0x06001040 RID: 4160 RVA: 0x0000B375 File Offset: 0x00009575
			[TypeConverter(typeof(IntTypeConverter))]
			public int SKINIndex { get; set; }

			// Token: 0x17000522 RID: 1314
			// (get) Token: 0x06001041 RID: 4161 RVA: 0x0000B37E File Offset: 0x0000957E
			// (set) Token: 0x06001042 RID: 4162 RVA: 0x0000B386 File Offset: 0x00009586
			[TypeConverter(typeof(IntTypeConverter))]
			public uint BoneCount { get; set; }

			// Token: 0x17000523 RID: 1315
			// (get) Token: 0x06001043 RID: 4163 RVA: 0x0000B38F File Offset: 0x0000958F
			// (set) Token: 0x06001044 RID: 4164 RVA: 0x0000B397 File Offset: 0x00009597
			[TypeConverter(typeof(IntTypeConverter))]
			public uint GeostateIndex { get; set; }

			// Token: 0x17000524 RID: 1316
			// (get) Token: 0x06001045 RID: 4165 RVA: 0x0000B3A0 File Offset: 0x000095A0
			// (set) Token: 0x06001046 RID: 4166 RVA: 0x0000B3A8 File Offset: 0x000095A8
			[TypeConverter(typeof(IntTypeConverter))]
			public int BaseMaterialIndex { get; set; }

			// Token: 0x17000525 RID: 1317
			// (get) Token: 0x06001047 RID: 4167 RVA: 0x0000B3B1 File Offset: 0x000095B1
			// (set) Token: 0x06001048 RID: 4168 RVA: 0x0000B3B9 File Offset: 0x000095B9
			[TypeConverter(typeof(IntTypeConverter))]
			public uint SomeIndex { get; set; }

			// Token: 0x17000526 RID: 1318
			// (get) Token: 0x06001049 RID: 4169 RVA: 0x0000B3C2 File Offset: 0x000095C2
			// (set) Token: 0x0600104A RID: 4170 RVA: 0x0000B3CA File Offset: 0x000095CA
			[TypeConverter(typeof(IntTypeConverter))]
			public List<uint> Bones { get; set; }

			// Token: 0x17000527 RID: 1319
			// (get) Token: 0x0600104B RID: 4171 RVA: 0x0000B3D3 File Offset: 0x000095D3
			// (set) Token: 0x0600104C RID: 4172 RVA: 0x0000B3DB File Offset: 0x000095DB
			public List<MLOD.GeoStateEntry> GeoStateEntries { get; set; }

			// Token: 0x17000528 RID: 1320
			// (get) Token: 0x0600104D RID: 4173 RVA: 0x0000B3E4 File Offset: 0x000095E4
			// (set) Token: 0x0600104E RID: 4174 RVA: 0x0000B3EC File Offset: 0x000095EC
			public float[] BoundingBox { get; set; }

			// Token: 0x17000529 RID: 1321
			// (get) Token: 0x0600104F RID: 4175 RVA: 0x0000B3F5 File Offset: 0x000095F5
			// (set) Token: 0x06001050 RID: 4176 RVA: 0x0000B3FD File Offset: 0x000095FD
			public List<float[]> extra_bounding { get; set; }

			// Token: 0x1700052A RID: 1322
			// (get) Token: 0x06001051 RID: 4177 RVA: 0x0000B406 File Offset: 0x00009606
			// (set) Token: 0x06001052 RID: 4178 RVA: 0x0000B40E File Offset: 0x0000960E
			[TypeConverter(typeof(IntTypeConverter))]
			public uint ParentNameHash { get; set; }

			// Token: 0x1700052B RID: 1323
			// (get) Token: 0x06001053 RID: 4179 RVA: 0x0000B417 File Offset: 0x00009617
			// (set) Token: 0x06001054 RID: 4180 RVA: 0x0000B41F File Offset: 0x0000961F
			public float[] MirrorPlaneNormal { get; set; }

			// Token: 0x1700052C RID: 1324
			// (get) Token: 0x06001055 RID: 4181 RVA: 0x0000B428 File Offset: 0x00009628
			// (set) Token: 0x06001056 RID: 4182 RVA: 0x0000B430 File Offset: 0x00009630
			public float MirrorPlaneOffset { get; set; }

			// Token: 0x1700052D RID: 1325
			// (get) Token: 0x06001057 RID: 4183 RVA: 0x0000B439 File Offset: 0x00009639
			[Browsable(false)]
			public uint Type
			{
				get
				{
					return this.VBUFType;
				}
			}

			// Token: 0x1700052E RID: 1326
			// (get) Token: 0x06001058 RID: 4184 RVA: 0x0004406C File Offset: 0x0004226C
			// (set) Token: 0x06001059 RID: 4185 RVA: 0x000032EA File Offset: 0x000014EA
			[Browsable(false)]
			public StreamVector3 PositionScalar
			{
				get
				{
					if (this.BaseMaterialIndex != 0)
					{
						RCOLItem rcolitem = this.Parent.Parent.Entries[this.BaseMaterialIndex + ((this.Parent.Parent.DataType == 2) ? 1 : 0)];
						if (rcolitem is MATD)
						{
							using (List<MATD.MATDEntry>.Enumerator enumerator = (rcolitem as MATD).Entries.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									MATD.MATDEntry matdentry = enumerator.Current;
									if (matdentry.Type == MATD.MATDEntryType.PosScale && matdentry.DataType == MATD.MATDDataType.FloatType && matdentry.NumValues >= 3)
									{
										return new StreamVector3((float)matdentry.Values[0], (float)matdentry.Values[1], (float)matdentry.Values[2]);
									}
								}
								goto IL_CF;
							}
							StreamVector3 result;
							return result;
						}
					}
					IL_CF:
					return null;
				}
				set
				{
				}
			}

			// Token: 0x1700052F RID: 1327
			// (get) Token: 0x0600105A RID: 4186 RVA: 0x0000B441 File Offset: 0x00009641
			// (set) Token: 0x0600105B RID: 4187 RVA: 0x0000B450 File Offset: 0x00009650
			public MLOD.PrimitiveType PrimitiveType
			{
				get
				{
					return (MLOD.PrimitiveType)(this.VBUFType & 255U);
				}
				set
				{
					this.VBUFType = (uint)(((uint)this.MeshFlags << 8) + (byte)value);
				}
			}

			// Token: 0x17000530 RID: 1328
			// (get) Token: 0x0600105C RID: 4188 RVA: 0x0000B462 File Offset: 0x00009662
			// (set) Token: 0x0600105D RID: 4189 RVA: 0x0000B473 File Offset: 0x00009673
			public MLOD.MeshFlags MeshFlags
			{
				get
				{
					return (MLOD.MeshFlags)(this.VBUFType >> 8 & 255U);
				}
				set
				{
					this.VBUFType = (uint)((long)((long)value << 8) + (long)((ulong)(this.VBUFType & 255U)));
				}
			}

			// Token: 0x17000531 RID: 1329
			// (get) Token: 0x0600105E RID: 4190 RVA: 0x0000B48E File Offset: 0x0000968E
			// (set) Token: 0x0600105F RID: 4191 RVA: 0x0000B496 File Offset: 0x00009696
			[Browsable(false)]
			public MLOD Parent { get; set; }

			// Token: 0x06001060 RID: 4192 RVA: 0x0004415C File Offset: 0x0004235C
			public MLODEntry(MLOD parent)
			{
				this.Parent = parent;
				this.Visible = true;
				this.Expanded = true;
				this.Bones = new List<uint>();
				this.BoundingBox = new float[6];
				this.GeoStateEntries = new List<MLOD.GeoStateEntry>();
				this.MirrorPlaneNormal = new float[3];
				this.extra_bounding = new List<float[]>();
			}

			// Token: 0x06001061 RID: 4193 RVA: 0x000441C0 File Offset: 0x000423C0
			public List<KeyValuePair<int, MATD>> GetAllMaterials()
			{
				List<KeyValuePair<int, MATD>> list = new List<KeyValuePair<int, MATD>>();
				RCOLItem rcolitem = this.Parent.Parent.Entries[this.MATDIndex + ((this.Parent.Parent.DataType == 2) ? 1 : 0)];
				if (rcolitem is MATD && !list.Contains(new KeyValuePair<int, MATD>(this.MATDIndex, rcolitem as MATD)))
				{
					list.Add(new KeyValuePair<int, MATD>(this.MATDIndex, rcolitem as MATD));
				}
				else if (rcolitem is MTST)
				{
					MTST mtst = rcolitem as MTST;
					MATD value = this.Parent.Parent.Entries[mtst.MATDIndex + ((this.Parent.Parent.DataType == 2) ? 1 : 0)] as MATD;
					if (!list.Contains(new KeyValuePair<int, MATD>(mtst.MATDIndex, value)))
					{
						list.Add(new KeyValuePair<int, MATD>(mtst.MATDIndex, value));
					}
					foreach (MTST.MTSTEntry mtstentry in mtst.Entries)
					{
						value = (this.Parent.Parent.Entries[mtstentry.MATDIndex + ((this.Parent.Parent.DataType == 2) ? 1 : 0)] as MATD);
						if (!list.Contains(new KeyValuePair<int, MATD>(mtstentry.MATDIndex, value)))
						{
							list.Add(new KeyValuePair<int, MATD>(mtstentry.MATDIndex, value));
						}
					}
				}
				MATD matd = this.Parent.Parent.Entries[this.GEOStateIndex + ((this.Parent.Parent.DataType == 2) ? 1 : 0)] as MATD;
				if (matd != null && !list.Contains(new KeyValuePair<int, MATD>(this.GEOStateIndex, matd)))
				{
					list.Add(new KeyValuePair<int, MATD>(this.GEOStateIndex, matd));
				}
				return list;
			}

			// Token: 0x06001062 RID: 4194 RVA: 0x0000B49F File Offset: 0x0000969F
			public object CloneSims4()
			{
				return this.Clone(true);
			}

			// Token: 0x06001063 RID: 4195 RVA: 0x0000B4A8 File Offset: 0x000096A8
			public object Clone()
			{
				return this.Clone(false);
			}

			// Token: 0x06001064 RID: 4196 RVA: 0x000443C4 File Offset: 0x000425C4
			public object Clone(bool forSims4)
			{
				MLOD.MLODEntry mlodentry = new MLOD.MLODEntry(this.Parent);
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				this.Serialize(binaryWriter);
				MemoryStream memoryStream2 = new MemoryStream(memoryStream.ToArray());
				BinaryReader binaryReader = new BinaryReader(memoryStream2);
				mlodentry.UnSerialize(binaryReader);
				memoryStream.Dispose();
				memoryStream2.Dispose();
				binaryWriter.Close();
				binaryReader.Close();
				MLOD parent = mlodentry.Parent;
				RCOL parent2 = parent.Parent;
				VRTF vrtf = parent2.Entries[mlodentry.VRTFIndex + ((parent2.DataType == 2) ? 1 : 0)] as VRTF;
				if (vrtf == null)
				{
					vrtf = VRTF.GetDefaultForType(mlodentry);
				}
				VBUF vbuf = parent2.Entries[mlodentry.VBUFIndex + ((parent2.DataType == 2) ? 1 : 0)] as VBUF;
				IBUF ibuf = parent2.Entries[mlodentry.IBUFIndex + ((parent2.DataType == 2) ? 1 : 0)] as IBUF;
				RCOLItem rcolitem = parent2.Entries[mlodentry.MATDIndex + ((parent2.DataType == 2) ? 1 : 0)];
				SKIN skin = parent2.Entries[mlodentry.SKINIndex + ((parent2.DataType == 2) ? 1 : 0)] as SKIN;
				RCOLItem rcolitem2 = parent2.Entries[mlodentry.GEOStateIndex + ((parent2.DataType == 2) ? 1 : 0)];
				if (!(rcolitem is MATD) && rcolitem is MTST)
				{
					MTST item = (rcolitem as MTST).Clone() as MTST;
					mlodentry.MATDIndex = parent2.AddEntry(RCOLItemType.MTST, item);
				}
				MATD matd = rcolitem2 as MATD;
				if (vbuf != null)
				{
					if (forSims4)
					{
						mlodentry.SetVertexOffset((long)vbuf.CopyFromIndexAndVRTF(mlodentry.VBUFOffset, mlodentry.VertexCount, vrtf));
					}
					else
					{
						VBUF item2 = vbuf.CloneFromIndexAndVRTF(mlodentry.VBUFOffset, mlodentry.VertexCount, vrtf) as VBUF;
						mlodentry.SetVertexOffset(0L);
						mlodentry.VBUFIndex = parent2.AddEntry(RCOLItemType.VBUF, item2);
					}
				}
				if (ibuf != null)
				{
					IBUF ibuf2 = ibuf.CloneFromIndexAndVRTF(mlodentry.IBUFOffset, mlodentry.FaceCount, vrtf) as IBUF;
					mlodentry.IBUFOffset = 0L;
					mlodentry.IBUFIndex = parent2.AddEntry(RCOLItemType.IBUF, ibuf2);
					if (mlodentry.GeostateCount > 0)
					{
						List<short> list = new List<short>();
						foreach (MLOD.GeoStateEntry geoStateEntry in mlodentry.GeoStateEntries)
						{
							int count = list.Count;
							for (int i = 0; i < geoStateEntry.FaceCount * 3; i++)
							{
								short item3 = ibuf.Index[geoStateEntry.IBUFOffset + i];
								list.Add(item3);
							}
							geoStateEntry.IBUFOffset = count;
						}
						ibuf2.Index = list.ToArray();
					}
				}
				if (forSims4 && skin != null)
				{
					SKIN item4 = skin.Clone() as SKIN;
					mlodentry.SKINIndex = parent2.AddEntry(RCOLItemType.SKIN, item4);
				}
				parent.Entries.Add(mlodentry);
				return mlodentry;
			}

			// Token: 0x06001065 RID: 4197 RVA: 0x000446EC File Offset: 0x000428EC
			public void setupBoundingBoxes(VBUF vbuf, VRTF vertexDeclaration)
			{
				float[][] array = this.extra_bounding.ToArray();
				this.extra_bounding.Clear();
				if (array.Length != 0)
				{
					for (int i = 0; i < this.Bones.Count; i++)
					{
						List<StreamVector4> list = new List<StreamVector4>();
						for (int j = 0; j < this.VertexCount; j++)
						{
							sbyte[] assignment = vbuf.GetAssignment(vertexDeclaration, j, this.VBUFOffset, 0);
							for (int k = 0; k < assignment.Length; k++)
							{
								if ((int)assignment[k] == i && assignment[k] > -1)
								{
									StreamVector4 position = vbuf.GetPosition(vertexDeclaration, j, this.VBUFOffset, 0, this.PositionScalar);
									list.Add(position);
								}
							}
						}
						float num = float.MaxValue;
						float num2 = float.MaxValue;
						float val = float.MaxValue;
						float num3 = float.MinValue;
						float num4 = float.MinValue;
						float num5 = float.MinValue;
						foreach (StreamVector4 streamVector in list)
						{
							num = Math.Min(num, streamVector.X);
							num2 = Math.Min(num2, streamVector.Y);
							val = Math.Min(val, streamVector.Z);
							num3 = Math.Max(num3, streamVector.X);
							num4 = Math.Max(num4, streamVector.Y);
							num5 = Math.Max(num5, streamVector.Z);
						}
						this.extra_bounding.Add(new float[]
						{
							num,
							num2,
							num,
							num3,
							num4,
							num5
						});
					}
				}
			}

			// Token: 0x06001066 RID: 4198 RVA: 0x00044890 File Offset: 0x00042A90
			public override void UnSerialize(BinaryReader reader)
			{
				this.extra_bounding = new List<float[]>();
				this.BoundingBox = new float[6];
				this.MirrorPlaneNormal = new float[3];
				this.Bones = new List<uint>();
				this.GeoStateEntries = new List<MLOD.GeoStateEntry>();
				this.NameHash = reader.ReadUInt32();
				this.MATDIndex = (reader.ReadInt32() & -268435457);
				this.VRTFIndex = (reader.ReadInt32() & -268435457);
				this.VBUFIndex = (reader.ReadInt32() & -268435457);
				this.IBUFIndex = (reader.ReadInt32() & -268435457);
				this.VBUFType = reader.ReadUInt32();
				this._vbuffOffset = reader.ReadInt64();
				this.IBUFOffset = reader.ReadInt64();
				this.VBUFCount = reader.ReadInt32();
				this.IBUFCount = reader.ReadInt32();
				this.BoundingBox[0] = reader.ReadSingle();
				this.BoundingBox[1] = reader.ReadSingle();
				this.BoundingBox[2] = reader.ReadSingle();
				this.BoundingBox[3] = reader.ReadSingle();
				this.BoundingBox[4] = reader.ReadSingle();
				this.BoundingBox[5] = reader.ReadSingle();
				this.SKINIndex = (reader.ReadInt32() & -268435457);
				this.BoneCount = reader.ReadUInt32();
				int num = 0;
				while ((long)num < (long)((ulong)this.BoneCount))
				{
					this.Bones.Add(reader.ReadUInt32());
					num++;
				}
				if (this.Parent.Version >= 516U)
				{
					this.BaseMaterialIndex = (reader.ReadInt32() & -268435457);
				}
				else
				{
					this.GeostateIndex = (reader.ReadUInt32() & 4026531839U);
				}
				this.GeostateCount = reader.ReadInt32();
				for (int i = 0; i < this.GeostateCount; i++)
				{
					MLOD.GeoStateEntry geoStateEntry = new MLOD.GeoStateEntry();
					geoStateEntry.Unserialize(reader);
					this.GeoStateEntries.Add(geoStateEntry);
				}
				if (this.Parent.Version > 513U)
				{
					this.ParentNameHash = reader.ReadUInt32();
					this.MirrorPlaneNormal[0] = reader.ReadSingle();
					this.MirrorPlaneNormal[1] = reader.ReadSingle();
					this.MirrorPlaneNormal[2] = reader.ReadSingle();
					this.MirrorPlaneOffset = reader.ReadSingle();
				}
				if (this.Parent.Version >= 516U)
				{
					this.SomeIndex = (reader.ReadUInt32() & 4026531839U);
				}
				if (this.Parent.Version >= 518U && reader.BaseStream.Position < reader.BaseStream.Length)
				{
					if (reader.BaseStream.Length - reader.BaseStream.Position != (long)(this.Bones.Count * 6 * 4))
					{
						throw new Exception("Extra boundingbox data in MLOD does not line up with the number of bones");
					}
					for (int j = 0; j < this.Bones.Count; j++)
					{
						float[] item = new float[]
						{
							reader.ReadSingle(),
							reader.ReadSingle(),
							reader.ReadSingle(),
							reader.ReadSingle(),
							reader.ReadSingle(),
							reader.ReadSingle()
						};
						this.extra_bounding.Add(item);
					}
				}
				if (reader.BaseStream.Position != reader.BaseStream.Length)
				{
					throw new Exception("MLOD not parsed to end of stream, at position " + reader.BaseStream.Position.ToString() + " of " + reader.BaseStream.Length.ToString());
				}
			}

			// Token: 0x06001067 RID: 4199 RVA: 0x00044C04 File Offset: 0x00042E04
			public override void Serialize(BinaryWriter w)
			{
				w.Write(this.NameHash);
				w.Write(this.MATDIndex | ((this.MATDIndex != 0) ? 268435456 : 0));
				w.Write(this.VRTFIndex | ((this.VRTFIndex != 0) ? 268435456 : 0));
				w.Write(this.VBUFIndex | ((this.VBUFIndex != 0) ? 268435456 : 0));
				w.Write(this.IBUFIndex | ((this.IBUFIndex != 0) ? 268435456 : 0));
				w.Write(this.VBUFType);
				w.Write(this._vbuffOffset);
				w.Write(this.IBUFOffset);
				w.Write(this.VBUFCount);
				w.Write(this.IBUFCount);
				w.Write(this.BoundingBox[0]);
				w.Write(this.BoundingBox[1]);
				w.Write(this.BoundingBox[2]);
				w.Write(this.BoundingBox[3]);
				w.Write(this.BoundingBox[4]);
				w.Write(this.BoundingBox[5]);
				w.Write((int)((long)this.SKINIndex | (long)((this.SKINIndex != 0) ? 268435456UL : 0UL)));
				w.Write(this.Bones.Count);
				for (int i = 0; i < this.Bones.Count; i++)
				{
					w.Write(this.Bones[i]);
				}
				if (this.Parent.Version >= 516U)
				{
					w.Write((int)((long)this.BaseMaterialIndex | (long)((this.BaseMaterialIndex != 0) ? 268435456UL : 0UL)));
				}
				else
				{
					w.Write(this.GeostateIndex | ((this.GeostateIndex != 0U) ? 268435456U : 0U));
				}
				w.Write(this.GeoStateEntries.Count);
				foreach (MLOD.GeoStateEntry geoStateEntry in this.GeoStateEntries)
				{
					geoStateEntry.Serialize(w);
				}
				if (this.Parent.Version > 513U)
				{
					w.Write(this.ParentNameHash);
					w.Write(this.MirrorPlaneNormal[0]);
					w.Write(this.MirrorPlaneNormal[1]);
					w.Write(this.MirrorPlaneNormal[2]);
					w.Write(this.MirrorPlaneOffset);
				}
				if (this.Parent.Version >= 516U)
				{
					w.Write(this.SomeIndex | ((this.SomeIndex != 0U) ? 268435456U : 0U));
				}
				if (this.Parent.Version >= 518U && this.extra_bounding.Count != 0)
				{
					for (int j = 0; j < this.extra_bounding.Count; j++)
					{
						float[] array = this.extra_bounding[j];
						w.Write(array[0]);
						w.Write(array[1]);
						w.Write(array[2]);
						w.Write(array[3]);
						w.Write(array[4]);
						w.Write(array[5]);
					}
				}
			}

			// Token: 0x06001068 RID: 4200 RVA: 0x00003309 File Offset: 0x00001509
			public override int ReplaceReferences(ResKey from, ResKey to)
			{
				return 0;
			}

			// Token: 0x17000532 RID: 1330
			// (get) Token: 0x06001069 RID: 4201 RVA: 0x0000B4B1 File Offset: 0x000096B1
			// (set) Token: 0x0600106A RID: 4202 RVA: 0x0000B4B9 File Offset: 0x000096B9
			public int GEOStateIndex
			{
				get
				{
					return (int)this.GeostateIndex;
				}
				set
				{
					this.GeostateIndex = (uint)value;
				}
			}

			// Token: 0x17000533 RID: 1331
			// (get) Token: 0x0600106B RID: 4203 RVA: 0x0000B4C2 File Offset: 0x000096C2
			// (set) Token: 0x0600106C RID: 4204 RVA: 0x0000B4CA File Offset: 0x000096CA
			public int VertexCount
			{
				get
				{
					return this.VBUFCount;
				}
				private set
				{
					this.VBUFCount = value;
				}
			}

			// Token: 0x0600106D RID: 4205 RVA: 0x0000B4CA File Offset: 0x000096CA
			public void SetVertexCount(int value)
			{
				this.VBUFCount = value;
			}

			// Token: 0x0600106E RID: 4206 RVA: 0x0000B4D3 File Offset: 0x000096D3
			public void SetVertexOffset(long value)
			{
				this._vbuffOffset = value;
			}

			// Token: 0x17000534 RID: 1332
			// (get) Token: 0x0600106F RID: 4207 RVA: 0x0000B4DC File Offset: 0x000096DC
			// (set) Token: 0x06001070 RID: 4208 RVA: 0x0000B4E4 File Offset: 0x000096E4
			public int FaceCount
			{
				get
				{
					return this.IBUFCount;
				}
				set
				{
					this.IBUFCount = value;
				}
			}

			// Token: 0x06001071 RID: 4209 RVA: 0x00044F1C File Offset: 0x0004311C
			public override string ToString()
			{
				return this.VBUFCount.ToString() + " vertices, " + this.FaceCount.ToString() + " faces";
			}

			// Token: 0x04000D3F RID: 3391
			private long _vbuffOffset;
		}
	}
}
