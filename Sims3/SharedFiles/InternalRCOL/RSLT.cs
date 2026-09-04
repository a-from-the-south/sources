using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000B7 RID: 183
	public class RSLT : RCOLItem
	{
		// Token: 0x17000312 RID: 786
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x0000749C File Offset: 0x0000569C
		// (set) Token: 0x0600093E RID: 2366 RVA: 0x000074A4 File Offset: 0x000056A4
		[Browsable(false)]
		public RSLTResource Parent { get; set; }

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x000074AD File Offset: 0x000056AD
		// (set) Token: 0x06000940 RID: 2368 RVA: 0x000074B5 File Offset: 0x000056B5
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Type { get; set; }

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x000074BE File Offset: 0x000056BE
		// (set) Token: 0x06000942 RID: 2370 RVA: 0x000074C6 File Offset: 0x000056C6
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Version { get; set; }

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000943 RID: 2371 RVA: 0x000074CF File Offset: 0x000056CF
		// (set) Token: 0x06000944 RID: 2372 RVA: 0x000074D7 File Offset: 0x000056D7
		public List<RSLT.Entry> RouteEntries { get; set; }

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000945 RID: 2373 RVA: 0x000074E0 File Offset: 0x000056E0
		// (set) Token: 0x06000946 RID: 2374 RVA: 0x000074E8 File Offset: 0x000056E8
		public List<RSLT.Entry> ContainerEntries { get; set; }

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x000074F1 File Offset: 0x000056F1
		// (set) Token: 0x06000948 RID: 2376 RVA: 0x000074F9 File Offset: 0x000056F9
		public List<RSLT.Entry> EffectEntries { get; set; }

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000949 RID: 2377 RVA: 0x00007502 File Offset: 0x00005702
		// (set) Token: 0x0600094A RID: 2378 RVA: 0x0000750A File Offset: 0x0000570A
		public List<RSLT.Entry> KinematicEntries { get; set; }

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x0600094B RID: 2379 RVA: 0x00007513 File Offset: 0x00005713
		// (set) Token: 0x0600094C RID: 2380 RVA: 0x0000751B File Offset: 0x0000571B
		[TypeConverter(typeof(IntTypeConverter))]
		public uint DWord0 { get; set; }

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x0600094D RID: 2381 RVA: 0x00007524 File Offset: 0x00005724
		// (set) Token: 0x0600094E RID: 2382 RVA: 0x0000752C File Offset: 0x0000572C
		[TypeConverter(typeof(IntTypeConverter))]
		public uint DWord1 { get; set; }

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x0600094F RID: 2383 RVA: 0x00007535 File Offset: 0x00005735
		// (set) Token: 0x06000950 RID: 2384 RVA: 0x0000753D File Offset: 0x0000573D
		[TypeConverter(typeof(IntTypeConverter))]
		public uint DWord2 { get; set; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x00007546 File Offset: 0x00005746
		// (set) Token: 0x06000952 RID: 2386 RVA: 0x0000754E File Offset: 0x0000574E
		[TypeConverter(typeof(IntTypeConverter))]
		public uint DWord3 { get; set; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x00007557 File Offset: 0x00005757
		// (set) Token: 0x06000954 RID: 2388 RVA: 0x0000755F File Offset: 0x0000575F
		public List<RSLT.SlotWithOffset> SlotOffsetsForRoutes { get; set; }

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x00007568 File Offset: 0x00005768
		// (set) Token: 0x06000956 RID: 2390 RVA: 0x00007570 File Offset: 0x00005770
		public List<RSLT.SlotWithOffset> SlotOffsetsForContainments { get; set; }

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x00007579 File Offset: 0x00005779
		// (set) Token: 0x06000958 RID: 2392 RVA: 0x00007581 File Offset: 0x00005781
		public List<RSLT.SlotWithOffset> SlotOffsetsForEffects { get; set; }

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000959 RID: 2393 RVA: 0x0000758A File Offset: 0x0000578A
		// (set) Token: 0x0600095A RID: 2394 RVA: 0x00007592 File Offset: 0x00005792
		public List<RSLT.SlotWithOffset> SlotOffsetsForKinematics { get; set; }

		// Token: 0x0600095B RID: 2395 RVA: 0x0002D824 File Offset: 0x0002BA24
		public RSLT(RSLTResource parent)
		{
			this.Parent = parent;
			this.RouteEntries = new List<RSLT.Entry>();
			this.ContainerEntries = new List<RSLT.Entry>();
			this.EffectEntries = new List<RSLT.Entry>();
			this.KinematicEntries = new List<RSLT.Entry>();
			this.SlotOffsetsForRoutes = new List<RSLT.SlotWithOffset>();
			this.SlotOffsetsForContainments = new List<RSLT.SlotWithOffset>();
			this.SlotOffsetsForEffects = new List<RSLT.SlotWithOffset>();
			this.SlotOffsetsForKinematics = new List<RSLT.SlotWithOffset>();
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0002D898 File Offset: 0x0002BA98
		public override void UnSerialize(BinaryReader r)
		{
			this.data = r.ReadBytes((int)r.BaseStream.Length);
			r.BaseStream.Position = 0L;
			this.SlotOffsetsForRoutes.Clear();
			this.SlotOffsetsForContainments.Clear();
			this.SlotOffsetsForEffects.Clear();
			this.SlotOffsetsForKinematics.Clear();
			this.RouteEntries.Clear();
			this.KinematicEntries.Clear();
			this.EffectEntries.Clear();
			this.ContainerEntries.Clear();
			this.Type = r.ReadUInt32();
			this.Version = r.ReadUInt32();
			uint num = r.ReadUInt32();
			uint num2 = r.ReadUInt32();
			uint num3 = r.ReadUInt32();
			uint num4 = r.ReadUInt32();
			r.ReadUInt32();
			int num5 = 0;
			while ((long)num5 < (long)((ulong)num))
			{
				RSLT.Entry entry = new RSLT.Entry();
				entry.NameHash = r.ReadUInt32();
				this.RouteEntries.Add(entry);
				num5++;
			}
			int num6 = 0;
			while ((long)num6 < (long)((ulong)num))
			{
				this.RouteEntries[num6].BoneHash = r.ReadUInt32();
				num6++;
			}
			int num7 = 0;
			while ((long)num7 < (long)((ulong)num))
			{
				RSLT.Entry entry2 = this.RouteEntries[num7];
				entry2.Transformation = new float[12];
				for (int i = 0; i < 12; i++)
				{
					entry2.Transformation[i] = r.ReadSingle();
				}
				num7++;
			}
			if (num > 0U)
			{
				this.DWord0 = r.ReadUInt32();
			}
			int num8 = 0;
			while ((long)num8 < (long)((ulong)this.DWord0))
			{
				RSLT.SlotWithOffset slotWithOffset = new RSLT.SlotWithOffset();
				slotWithOffset.UnSerialize(r);
				this.SlotOffsetsForRoutes.Add(slotWithOffset);
				num8++;
			}
			int num9 = 0;
			while ((long)num9 < (long)((ulong)num2))
			{
				RSLT.Entry entry3 = new RSLT.Entry();
				entry3.NameHash = r.ReadUInt32();
				this.ContainerEntries.Add(entry3);
				num9++;
			}
			int num10 = 0;
			while ((long)num10 < (long)((ulong)num2))
			{
				this.ContainerEntries[num10].BoneHash = r.ReadUInt32();
				num10++;
			}
			if (this.Version >= 8U)
			{
				int num11 = 0;
				while ((long)num11 < (long)((ulong)num2))
				{
					this.ContainerEntries[num11].SlotSize = (uint)r.ReadByte();
					num11++;
				}
				int num12 = 0;
				while ((long)num12 < (long)((ulong)num2))
				{
					this.ContainerEntries[num12].SlotTypeSet = r.ReadUInt64();
					num12++;
				}
				int num13 = 0;
				while ((long)num13 < (long)((ulong)num2))
				{
					this.ContainerEntries[num13].DirectionLocked = r.ReadByte();
					num13++;
				}
				if (this.Version >= 9U)
				{
					int num14 = 0;
					while ((long)num14 < (long)((ulong)num2))
					{
						this.ContainerEntries[num14].SomeOtherBool = r.ReadByte();
						num14++;
					}
				}
				if (this.Version >= 10U)
				{
					int num15 = 0;
					while ((long)num15 < (long)((ulong)num2))
					{
						this.ContainerEntries[num15].SomeOtherBool2 = r.ReadByte();
						num15++;
					}
				}
				int num16 = 0;
				while ((long)num16 < (long)((ulong)num2))
				{
					this.ContainerEntries[num16].LegacyHash = r.ReadUInt32();
					num16++;
				}
			}
			if (this.Version < 8U)
			{
				int num17 = 0;
				while ((long)num17 < (long)((ulong)num2))
				{
					this.ContainerEntries[num17].PlacementFlag = (RSLT.PlacementFlags)r.ReadUInt32();
					num17++;
				}
			}
			int num18 = 0;
			while ((long)num18 < (long)((ulong)num2))
			{
				RSLT.Entry entry4 = this.ContainerEntries[num18];
				entry4.Transformation = new float[12];
				for (int j = 0; j < 12; j++)
				{
					entry4.Transformation[j] = r.ReadSingle();
				}
				num18++;
			}
			if (num2 > 0U)
			{
				this.DWord1 = r.ReadUInt32();
			}
			int num19 = 0;
			while ((long)num19 < (long)((ulong)this.DWord1))
			{
				RSLT.SlotWithOffset slotWithOffset2 = new RSLT.SlotWithOffset();
				slotWithOffset2.UnSerialize(r);
				this.SlotOffsetsForContainments.Add(slotWithOffset2);
				num19++;
			}
			int num20 = 0;
			while ((long)num20 < (long)((ulong)num3))
			{
				RSLT.Entry entry5 = new RSLT.Entry();
				entry5.NameHash = r.ReadUInt32();
				this.EffectEntries.Add(entry5);
				num20++;
			}
			int num21 = 0;
			while ((long)num21 < (long)((ulong)num3))
			{
				this.EffectEntries[num21].BoneHash = r.ReadUInt32();
				num21++;
			}
			int num22 = 0;
			while ((long)num22 < (long)((ulong)num3))
			{
				RSLT.Entry entry6 = this.EffectEntries[num22];
				entry6.Transformation = new float[12];
				for (int k = 0; k < 12; k++)
				{
					entry6.Transformation[k] = r.ReadSingle();
				}
				num22++;
			}
			if (num3 > 0U)
			{
				this.DWord2 = r.ReadUInt32();
			}
			int num23 = 0;
			while ((long)num23 < (long)((ulong)this.DWord2))
			{
				RSLT.SlotWithOffset slotWithOffset3 = new RSLT.SlotWithOffset();
				slotWithOffset3.UnSerialize(r);
				this.SlotOffsetsForEffects.Add(slotWithOffset3);
				num23++;
			}
			int num24 = 0;
			while ((long)num24 < (long)((ulong)num4))
			{
				RSLT.Entry entry7 = new RSLT.Entry();
				entry7.NameHash = r.ReadUInt32();
				this.KinematicEntries.Add(entry7);
				num24++;
			}
			int num25 = 0;
			while ((long)num25 < (long)((ulong)num4))
			{
				this.KinematicEntries[num25].BoneHash = r.ReadUInt32();
				num25++;
			}
			int num26 = 0;
			while ((long)num26 < (long)((ulong)num4))
			{
				RSLT.Entry entry8 = this.KinematicEntries[num26];
				entry8.Transformation = new float[12];
				for (int l = 0; l < 12; l++)
				{
					entry8.Transformation[l] = r.ReadSingle();
				}
				num26++;
			}
			if (num4 > 0U)
			{
				this.DWord3 = r.ReadUInt32();
			}
			int num27 = 0;
			while ((long)num27 < (long)((ulong)this.DWord3))
			{
				RSLT.SlotWithOffset slotWithOffset4 = new RSLT.SlotWithOffset();
				slotWithOffset4.UnSerialize(r);
				this.SlotOffsetsForKinematics.Add(slotWithOffset4);
				num27++;
			}
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0002DE74 File Offset: 0x0002C074
		public override void Serialize(BinaryWriter w)
		{
			w.Write(this.Type);
			w.Write(this.Version);
			w.Write(this.RouteEntries.Count);
			w.Write(this.ContainerEntries.Count);
			w.Write(this.EffectEntries.Count);
			w.Write(this.KinematicEntries.Count);
			w.Write(0);
			foreach (RSLT.Entry entry in this.RouteEntries)
			{
				w.Write(entry.NameHash);
			}
			foreach (RSLT.Entry entry2 in this.RouteEntries)
			{
				w.Write(entry2.BoneHash);
			}
			foreach (RSLT.Entry entry3 in this.RouteEntries)
			{
				for (int i = 0; i < 12; i++)
				{
					w.Write(entry3.Transformation[i]);
				}
			}
			if (this.RouteEntries.Count > 0)
			{
				w.Write(this.DWord0);
			}
			foreach (RSLT.SlotWithOffset slotWithOffset in this.SlotOffsetsForRoutes)
			{
				slotWithOffset.Serialize(w);
			}
			foreach (RSLT.Entry entry4 in this.ContainerEntries)
			{
				w.Write(entry4.NameHash);
			}
			foreach (RSLT.Entry entry5 in this.ContainerEntries)
			{
				w.Write(entry5.BoneHash);
			}
			if (this.Version >= 8U)
			{
				foreach (RSLT.Entry entry6 in this.ContainerEntries)
				{
					w.Write((byte)entry6.SlotSize);
				}
				foreach (RSLT.Entry entry7 in this.ContainerEntries)
				{
					w.Write(entry7.SlotTypeSet);
				}
				foreach (RSLT.Entry entry8 in this.ContainerEntries)
				{
					w.Write(entry8.DirectionLocked);
				}
				if (this.Version >= 9U)
				{
					foreach (RSLT.Entry entry9 in this.ContainerEntries)
					{
						w.Write(entry9.SomeOtherBool);
					}
				}
				if (this.Version >= 10U)
				{
					foreach (RSLT.Entry entry10 in this.ContainerEntries)
					{
						w.Write(entry10.SomeOtherBool2);
					}
				}
				foreach (RSLT.Entry entry11 in this.ContainerEntries)
				{
					w.Write(entry11.LegacyHash);
				}
			}
			if (this.Version < 8U)
			{
				foreach (RSLT.Entry entry12 in this.ContainerEntries)
				{
					w.Write((uint)entry12.PlacementFlag);
				}
			}
			foreach (RSLT.Entry entry13 in this.ContainerEntries)
			{
				for (int j = 0; j < 12; j++)
				{
					w.Write(entry13.Transformation[j]);
				}
			}
			if (this.ContainerEntries.Count > 0)
			{
				w.Write(this.DWord1);
			}
			foreach (RSLT.SlotWithOffset slotWithOffset2 in this.SlotOffsetsForContainments)
			{
				slotWithOffset2.Serialize(w);
			}
			foreach (RSLT.Entry entry14 in this.EffectEntries)
			{
				w.Write(entry14.NameHash);
			}
			foreach (RSLT.Entry entry15 in this.EffectEntries)
			{
				w.Write(entry15.BoneHash);
			}
			foreach (RSLT.Entry entry16 in this.EffectEntries)
			{
				for (int k = 0; k < 12; k++)
				{
					w.Write(entry16.Transformation[k]);
				}
			}
			if (this.EffectEntries.Count > 0)
			{
				w.Write(this.DWord2);
			}
			foreach (RSLT.SlotWithOffset slotWithOffset3 in this.SlotOffsetsForEffects)
			{
				slotWithOffset3.Serialize(w);
			}
			foreach (RSLT.Entry entry17 in this.KinematicEntries)
			{
				w.Write(entry17.NameHash);
			}
			foreach (RSLT.Entry entry18 in this.KinematicEntries)
			{
				w.Write(entry18.BoneHash);
			}
			foreach (RSLT.Entry entry19 in this.KinematicEntries)
			{
				for (int l = 0; l < 12; l++)
				{
					w.Write(entry19.Transformation[l]);
				}
			}
			if (this.KinematicEntries.Count > 0)
			{
				w.Write(this.DWord3);
			}
			foreach (RSLT.SlotWithOffset slotWithOffset4 in this.SlotOffsetsForKinematics)
			{
				slotWithOffset4.Serialize(w);
			}
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0000759B File Offset: 0x0000579B
		public override string ToString()
		{
			return "RSLT";
		}

		// Token: 0x0400048F RID: 1167
		[Browsable(false)]
		private byte[] data;

		// Token: 0x020001A6 RID: 422
		public enum PlacementFlags : uint
		{
			// Token: 0x04000CCD RID: 3277
			None = 1U,
			// Token: 0x04000CCE RID: 3278
			Small = 8U,
			// Token: 0x04000CCF RID: 3279
			Medium = 16U,
			// Token: 0x04000CD0 RID: 3280
			Large = 32U,
			// Token: 0x04000CD1 RID: 3281
			Sim = 256U,
			// Token: 0x04000CD2 RID: 3282
			Chair = 512U,
			// Token: 0x04000CD3 RID: 3283
			CounterSin = 1024U,
			// Token: 0x04000CD4 RID: 3284
			EndTable = 2048U,
			// Token: 0x04000CD5 RID: 3285
			Stool = 4096U,
			// Token: 0x04000CD6 RID: 3286
			CounterAppliance = 8192U,
			// Token: 0x04000CD7 RID: 3287
			Functional = 262144U,
			// Token: 0x04000CD8 RID: 3288
			Decorative = 524288U,
			// Token: 0x04000CD9 RID: 3289
			Upgrade = 16777216U,
			// Token: 0x04000CDA RID: 3290
			Vertical = 33554432U,
			// Token: 0x04000CDB RID: 3291
			PlacementOnly = 67108864U,
			// Token: 0x04000CDC RID: 3292
			CardinalRotation = 268435456U,
			// Token: 0x04000CDD RID: 3293
			FullRotation = 536870912U,
			// Token: 0x04000CDE RID: 3294
			AlwaysUp = 1073741824U
		}

		// Token: 0x020001A7 RID: 423
		public class Entry
		{
			// Token: 0x170004E0 RID: 1248
			// (get) Token: 0x06000FAB RID: 4011 RVA: 0x0000AE3E File Offset: 0x0000903E
			// (set) Token: 0x06000FAC RID: 4012 RVA: 0x0000AE46 File Offset: 0x00009046
			[TypeConverter(typeof(IntTypeConverter))]
			public uint NameHash { get; set; }

			// Token: 0x170004E1 RID: 1249
			// (get) Token: 0x06000FAD RID: 4013 RVA: 0x0000AE4F File Offset: 0x0000904F
			// (set) Token: 0x06000FAE RID: 4014 RVA: 0x0000AE57 File Offset: 0x00009057
			[TypeConverter(typeof(IntTypeConverter))]
			public uint BoneHash { get; set; }

			// Token: 0x170004E2 RID: 1250
			// (get) Token: 0x06000FAF RID: 4015 RVA: 0x0000AE60 File Offset: 0x00009060
			// (set) Token: 0x06000FB0 RID: 4016 RVA: 0x0000AE68 File Offset: 0x00009068
			[TypeConverter(typeof(IntTypeConverter))]
			public uint SlotSize { get; set; }

			// Token: 0x170004E3 RID: 1251
			// (get) Token: 0x06000FB1 RID: 4017 RVA: 0x0000AE71 File Offset: 0x00009071
			// (set) Token: 0x06000FB2 RID: 4018 RVA: 0x0000AE79 File Offset: 0x00009079
			[TypeConverter(typeof(IntTypeConverter))]
			public ulong SlotTypeSet { get; set; }

			// Token: 0x170004E4 RID: 1252
			// (get) Token: 0x06000FB3 RID: 4019 RVA: 0x0000AE82 File Offset: 0x00009082
			// (set) Token: 0x06000FB4 RID: 4020 RVA: 0x0000AE8A File Offset: 0x0000908A
			[TypeConverter(typeof(IntTypeConverter))]
			public byte DirectionLocked { get; set; }

			// Token: 0x170004E5 RID: 1253
			// (get) Token: 0x06000FB5 RID: 4021 RVA: 0x0000AE93 File Offset: 0x00009093
			// (set) Token: 0x06000FB6 RID: 4022 RVA: 0x0000AE9B File Offset: 0x0000909B
			[TypeConverter(typeof(IntTypeConverter))]
			public byte SomeOtherBool { get; set; }

			// Token: 0x170004E6 RID: 1254
			// (get) Token: 0x06000FB7 RID: 4023 RVA: 0x0000AEA4 File Offset: 0x000090A4
			// (set) Token: 0x06000FB8 RID: 4024 RVA: 0x0000AEAC File Offset: 0x000090AC
			[TypeConverter(typeof(IntTypeConverter))]
			public byte SomeOtherBool2 { get; set; }

			// Token: 0x170004E7 RID: 1255
			// (get) Token: 0x06000FB9 RID: 4025 RVA: 0x0000AEB5 File Offset: 0x000090B5
			// (set) Token: 0x06000FBA RID: 4026 RVA: 0x0000AEBD File Offset: 0x000090BD
			[TypeConverter(typeof(IntTypeConverter))]
			public uint LegacyHash { get; set; }

			// Token: 0x170004E8 RID: 1256
			// (get) Token: 0x06000FBB RID: 4027 RVA: 0x0000AEC6 File Offset: 0x000090C6
			// (set) Token: 0x06000FBC RID: 4028 RVA: 0x0000AECE File Offset: 0x000090CE
			public RSLT.PlacementFlags PlacementFlag { get; set; }

			// Token: 0x170004E9 RID: 1257
			// (get) Token: 0x06000FBD RID: 4029 RVA: 0x0000AED7 File Offset: 0x000090D7
			// (set) Token: 0x06000FBE RID: 4030 RVA: 0x0000AEDF File Offset: 0x000090DF
			public float[] Transformation { get; set; }

			// Token: 0x06000FBF RID: 4031 RVA: 0x00043D58 File Offset: 0x00041F58
			public Entry()
			{
				this.Transformation = new float[12];
				float[] transformation = this.Transformation;
				int num = 0;
				float[] transformation2 = this.Transformation;
				int num2 = 5;
				float[] transformation3 = this.Transformation;
				int num3 = 10;
				float num4 = 1f;
				float num5 = 1f;
				transformation3[num3] = num4;
				float num6 = num5;
				num5 = 1f;
				transformation2[num2] = num6;
				transformation[num] = num5;
			}

			// Token: 0x06000FC0 RID: 4032 RVA: 0x00043DA4 File Offset: 0x00041FA4
			public object Clone()
			{
				RSLT.Entry entry = new RSLT.Entry();
				entry.NameHash = this.NameHash;
				entry.BoneHash = this.BoneHash;
				entry.SlotSize = this.SlotSize;
				entry.SlotTypeSet = this.SlotTypeSet;
				entry.DirectionLocked = this.DirectionLocked;
				entry.SomeOtherBool = this.SomeOtherBool;
				entry.SomeOtherBool2 = this.SomeOtherBool2;
				entry.LegacyHash = this.LegacyHash;
				entry.PlacementFlag = this.PlacementFlag;
				entry.Transformation = new float[12];
				this.Transformation.CopyTo(entry.Transformation, 0);
				return entry;
			}

			// Token: 0x06000FC1 RID: 4033 RVA: 0x00043E44 File Offset: 0x00042044
			public override string ToString()
			{
				return "RSLT Entry 0x" + this.BoneHash.ToString("X8");
			}
		}

		// Token: 0x020001A8 RID: 424
		public class SlotWithOffset
		{
			// Token: 0x170004EA RID: 1258
			// (get) Token: 0x06000FC2 RID: 4034 RVA: 0x0000AEE8 File Offset: 0x000090E8
			// (set) Token: 0x06000FC3 RID: 4035 RVA: 0x0000AEF0 File Offset: 0x000090F0
			[TypeConverter(typeof(IntTypeConverter))]
			public uint idx { get; set; }

			// Token: 0x170004EB RID: 1259
			// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x0000AEF9 File Offset: 0x000090F9
			// (set) Token: 0x06000FC5 RID: 4037 RVA: 0x0000AF01 File Offset: 0x00009101
			public float posX { get; set; }

			// Token: 0x170004EC RID: 1260
			// (get) Token: 0x06000FC6 RID: 4038 RVA: 0x0000AF0A File Offset: 0x0000910A
			// (set) Token: 0x06000FC7 RID: 4039 RVA: 0x0000AF12 File Offset: 0x00009112
			public float posY { get; set; }

			// Token: 0x170004ED RID: 1261
			// (get) Token: 0x06000FC8 RID: 4040 RVA: 0x0000AF1B File Offset: 0x0000911B
			// (set) Token: 0x06000FC9 RID: 4041 RVA: 0x0000AF23 File Offset: 0x00009123
			public float posZ { get; set; }

			// Token: 0x170004EE RID: 1262
			// (get) Token: 0x06000FCA RID: 4042 RVA: 0x0000AF2C File Offset: 0x0000912C
			// (set) Token: 0x06000FCB RID: 4043 RVA: 0x0000AF34 File Offset: 0x00009134
			public float rotX { get; set; }

			// Token: 0x170004EF RID: 1263
			// (get) Token: 0x06000FCC RID: 4044 RVA: 0x0000AF3D File Offset: 0x0000913D
			// (set) Token: 0x06000FCD RID: 4045 RVA: 0x0000AF45 File Offset: 0x00009145
			public float rotY { get; set; }

			// Token: 0x170004F0 RID: 1264
			// (get) Token: 0x06000FCE RID: 4046 RVA: 0x0000AF4E File Offset: 0x0000914E
			// (set) Token: 0x06000FCF RID: 4047 RVA: 0x0000AF56 File Offset: 0x00009156
			public float rotZ { get; set; }

			// Token: 0x06000FD0 RID: 4048 RVA: 0x00043E70 File Offset: 0x00042070
			public void UnSerialize(BinaryReader r)
			{
				this.idx = r.ReadUInt32();
				this.posX = r.ReadSingle();
				this.posY = r.ReadSingle();
				this.posZ = r.ReadSingle();
				this.rotX = r.ReadSingle();
				this.rotY = r.ReadSingle();
				this.rotZ = r.ReadSingle();
			}

			// Token: 0x06000FD1 RID: 4049 RVA: 0x00043ED4 File Offset: 0x000420D4
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.idx);
				w.Write(this.posX);
				w.Write(this.posY);
				w.Write(this.posZ);
				w.Write(this.rotX);
				w.Write(this.rotY);
				w.Write(this.rotZ);
			}
		}
	}
}
