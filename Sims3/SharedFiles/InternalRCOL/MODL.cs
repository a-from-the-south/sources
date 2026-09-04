using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000B9 RID: 185
	public class MODL : RCOLItem
	{
		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000970 RID: 2416 RVA: 0x000075FE File Offset: 0x000057FE
		// (set) Token: 0x06000971 RID: 2417 RVA: 0x00007606 File Offset: 0x00005806
		[Browsable(false)]
		public byte[] Data { get; set; }

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000972 RID: 2418 RVA: 0x0000760F File Offset: 0x0000580F
		// (set) Token: 0x06000973 RID: 2419 RVA: 0x00007617 File Offset: 0x00005817
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Header { get; set; }

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x00007620 File Offset: 0x00005820
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x00007628 File Offset: 0x00005828
		[TypeConverter(typeof(IntTypeConverter))]
		public int Version { get; set; }

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x00007631 File Offset: 0x00005831
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x00007639 File Offset: 0x00005839
		public float[] BoundingBox { get; set; }

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x00007642 File Offset: 0x00005842
		// (set) Token: 0x06000979 RID: 2425 RVA: 0x0000764A File Offset: 0x0000584A
		[TypeConverter(typeof(IntTypeConverter))]
		public int Unk1 { get; set; }

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x00007653 File Offset: 0x00005853
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x0000765B File Offset: 0x0000585B
		[TypeConverter(typeof(IntTypeConverter))]
		public int Unk2 { get; set; }

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x00007664 File Offset: 0x00005864
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x0000766C File Offset: 0x0000586C
		[TypeConverter(typeof(IntTypeConverter))]
		public uint FadeType { get; set; }

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00007675 File Offset: 0x00005875
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x0000767D File Offset: 0x0000587D
		public float CustomFadeDistance { get; set; }

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x00007686 File Offset: 0x00005886
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x0000768E File Offset: 0x0000588E
		public List<MODL.MODLEntry> Entries { get; private set; }

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x00007697 File Offset: 0x00005897
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x0000769F File Offset: 0x0000589F
		public float[][] ExtendedBoundingBoxes { get; set; }

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x000076A8 File Offset: 0x000058A8
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x000076B0 File Offset: 0x000058B0
		[Browsable(false)]
		public RCOL Parent { get; set; }

		// Token: 0x06000986 RID: 2438 RVA: 0x000076B9 File Offset: 0x000058B9
		public MODL(RCOL parent)
		{
			this.Parent = parent;
			this.Entries = new List<MODL.MODLEntry>();
			this.BoundingBox = new float[6];
			this.ExtendedBoundingBoxes = new float[0][];
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0002E980 File Offset: 0x0002CB80
		public override string ToString()
		{
			return "MODL v" + this.Version.ToString();
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0002E9A8 File Offset: 0x0002CBA8
		public override void UnSerialize(BinaryReader reader)
		{
			this.Data = reader.ReadBytes((int)reader.BaseStream.Length);
			reader.BaseStream.Position = 0L;
			this.Header = reader.ReadUInt32();
			this.Version = reader.ReadInt32();
			uint num = reader.ReadUInt32();
			for (int i = 0; i < this.BoundingBox.Length; i++)
			{
				this.BoundingBox[i] = reader.ReadSingle();
			}
			if (this.Version >= 258)
			{
				uint num2 = reader.ReadUInt32();
				this.ExtendedBoundingBoxes = new float[num2][];
				if (num2 > 0U)
				{
					int num3 = 0;
					while ((long)num3 < (long)((ulong)num2))
					{
						this.ExtendedBoundingBoxes[num3] = new float[6];
						this.ExtendedBoundingBoxes[num3][0] = reader.ReadSingle();
						this.ExtendedBoundingBoxes[num3][1] = reader.ReadSingle();
						this.ExtendedBoundingBoxes[num3][2] = reader.ReadSingle();
						this.ExtendedBoundingBoxes[num3][3] = reader.ReadSingle();
						this.ExtendedBoundingBoxes[num3][4] = reader.ReadSingle();
						this.ExtendedBoundingBoxes[num3][5] = reader.ReadSingle();
						num3++;
					}
				}
				this.FadeType = reader.ReadUInt32();
				this.CustomFadeDistance = reader.ReadSingle();
			}
			if (this.Version >= 768)
			{
				this.Unk1 = reader.ReadInt32();
				this.Unk2 = reader.ReadInt32();
			}
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num))
			{
				MODL.MODLEntry modlentry = new MODL.MODLEntry();
				modlentry.UnSerialize(reader);
				this.Entries.Add(modlentry);
				num4++;
			}
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0002EB30 File Offset: 0x0002CD30
		public override void Serialize(BinaryWriter w)
		{
			w.Write(this.Header);
			w.Write(this.Version);
			w.Write(this.Entries.Count);
			for (int i = 0; i < this.BoundingBox.Length; i++)
			{
				w.Write(this.BoundingBox[i]);
			}
			if (this.Version >= 258)
			{
				w.Write(this.ExtendedBoundingBoxes.Length);
				for (int j = 0; j < this.ExtendedBoundingBoxes.Length; j++)
				{
					w.Write(this.ExtendedBoundingBoxes[j][0]);
					w.Write(this.ExtendedBoundingBoxes[j][1]);
					w.Write(this.ExtendedBoundingBoxes[j][2]);
					w.Write(this.ExtendedBoundingBoxes[j][3]);
					w.Write(this.ExtendedBoundingBoxes[j][4]);
					w.Write(this.ExtendedBoundingBoxes[j][5]);
				}
				w.Write(this.FadeType);
				w.Write(this.CustomFadeDistance);
			}
			if (this.Version >= 768)
			{
				w.Write(this.Unk1);
				w.Write(this.Unk2);
			}
			foreach (MODL.MODLEntry modlentry in this.Entries)
			{
				modlentry.Serialize(w);
			}
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x020001AA RID: 426
		public class MODLEntry
		{
			// Token: 0x170004F4 RID: 1268
			// (get) Token: 0x06000FDE RID: 4062 RVA: 0x0000AF92 File Offset: 0x00009192
			// (set) Token: 0x06000FDF RID: 4063 RVA: 0x0000AF9A File Offset: 0x0000919A
			[TypeConverter(typeof(IntTypeConverter))]
			public int LodModel { get; set; }

			// Token: 0x170004F5 RID: 1269
			// (get) Token: 0x06000FE0 RID: 4064 RVA: 0x0000AFA3 File Offset: 0x000091A3
			// (set) Token: 0x06000FE1 RID: 4065 RVA: 0x0000AFAB File Offset: 0x000091AB
			public MODL.MODLEntry.LodInfo LodInfoFlags { get; set; }

			// Token: 0x170004F6 RID: 1270
			// (get) Token: 0x06000FE2 RID: 4066 RVA: 0x0000AFB4 File Offset: 0x000091B4
			// (set) Token: 0x06000FE3 RID: 4067 RVA: 0x0000AFBC File Offset: 0x000091BC
			public MODL.MODLEntry.LodID LodIDFlags { get; set; }

			// Token: 0x170004F7 RID: 1271
			// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x0000AFC5 File Offset: 0x000091C5
			// (set) Token: 0x06000FE5 RID: 4069 RVA: 0x0000AFCD File Offset: 0x000091CD
			public float MinZ { get; set; }

			// Token: 0x170004F8 RID: 1272
			// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x0000AFD6 File Offset: 0x000091D6
			// (set) Token: 0x06000FE7 RID: 4071 RVA: 0x0000AFDE File Offset: 0x000091DE
			public float MaxZ { get; set; }

			// Token: 0x170004F9 RID: 1273
			// (get) Token: 0x06000FE8 RID: 4072 RVA: 0x0000AFE7 File Offset: 0x000091E7
			[Browsable(false)]
			public uint LOD
			{
				get
				{
					return (uint)this.LodIDFlags;
				}
			}

			// Token: 0x170004FA RID: 1274
			// (get) Token: 0x06000FE9 RID: 4073 RVA: 0x0000AFEF File Offset: 0x000091EF
			[Browsable(false)]
			public int IndexType
			{
				get
				{
					return (this.LodModel & 805306368) >> 16;
				}
			}

			// Token: 0x170004FB RID: 1275
			// (get) Token: 0x06000FEA RID: 4074 RVA: 0x0000B000 File Offset: 0x00009200
			[Browsable(false)]
			public int Index
			{
				get
				{
					return this.LodModel & 268435455;
				}
			}

			// Token: 0x06000FEB RID: 4075 RVA: 0x00044020 File Offset: 0x00042220
			public void UnSerialize(BinaryReader r)
			{
				this.LodModel = r.ReadInt32();
				uint lodInfoFlags = r.ReadUInt32();
				this.LodInfoFlags = (MODL.MODLEntry.LodInfo)lodInfoFlags;
				this.LodIDFlags = (MODL.MODLEntry.LodID)r.ReadUInt32();
				this.MinZ = r.ReadSingle();
				this.MaxZ = r.ReadSingle();
			}

			// Token: 0x06000FEC RID: 4076 RVA: 0x0000B00E File Offset: 0x0000920E
			public void Serialize(BinaryWriter w)
			{
				w.Write((uint)this.LodModel);
				w.Write((uint)this.LodInfoFlags);
				w.Write((uint)this.LodIDFlags);
				w.Write(this.MinZ);
				w.Write(this.MaxZ);
			}

			// Token: 0x020001DB RID: 475
			[Flags]
			public enum LodInfo : uint
			{
				// Token: 0x04002601 RID: 9729
				None = 0U,
				// Token: 0x04002602 RID: 9730
				Portal = 1U,
				// Token: 0x04002603 RID: 9731
				Door = 2U
			}

			// Token: 0x020001DC RID: 476
			[Flags]
			public enum LodID : uint
			{
				// Token: 0x04002605 RID: 9733
				HighDetail = 0U,
				// Token: 0x04002606 RID: 9734
				MediumDetail = 1U,
				// Token: 0x04002607 RID: 9735
				LowDetail = 2U,
				// Token: 0x04002608 RID: 9736
				HighDetailShadow = 65536U,
				// Token: 0x04002609 RID: 9737
				MediumDetailShadow = 65537U,
				// Token: 0x0400260A RID: 9738
				LowDetailShadow = 65538U
			}
		}
	}
}
