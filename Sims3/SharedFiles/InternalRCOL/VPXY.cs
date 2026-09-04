using System;
using System.Collections.Generic;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000BC RID: 188
	public class VPXY : RCOLItem
	{
		// Token: 0x17000341 RID: 833
		// (get) Token: 0x060009B3 RID: 2483 RVA: 0x000077FB File Offset: 0x000059FB
		// (set) Token: 0x060009B4 RID: 2484 RVA: 0x00007803 File Offset: 0x00005A03
		public uint typeId { get; set; }

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x060009B5 RID: 2485 RVA: 0x0000780C File Offset: 0x00005A0C
		// (set) Token: 0x060009B6 RID: 2486 RVA: 0x00007814 File Offset: 0x00005A14
		public uint version { get; set; }

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x060009B7 RID: 2487 RVA: 0x0000781D File Offset: 0x00005A1D
		// (set) Token: 0x060009B8 RID: 2488 RVA: 0x00007825 File Offset: 0x00005A25
		public uint tgiOffset { get; set; }

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0000782E File Offset: 0x00005A2E
		// (set) Token: 0x060009BA RID: 2490 RVA: 0x00007836 File Offset: 0x00005A36
		public uint tgiSize { get; set; }

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x060009BB RID: 2491 RVA: 0x0000783F File Offset: 0x00005A3F
		// (set) Token: 0x060009BC RID: 2492 RVA: 0x00007847 File Offset: 0x00005A47
		public List<TGIIndex> TGIIndex { get; set; }

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x060009BD RID: 2493 RVA: 0x00007850 File Offset: 0x00005A50
		// (set) Token: 0x060009BE RID: 2494 RVA: 0x00007858 File Offset: 0x00005A58
		public byte unkByte1 { get; set; }

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x00007861 File Offset: 0x00005A61
		// (set) Token: 0x060009C0 RID: 2496 RVA: 0x00007869 File Offset: 0x00005A69
		public float f1 { get; set; }

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x00007872 File Offset: 0x00005A72
		// (set) Token: 0x060009C2 RID: 2498 RVA: 0x0000787A File Offset: 0x00005A7A
		public float f2 { get; set; }

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x060009C3 RID: 2499 RVA: 0x00007883 File Offset: 0x00005A83
		// (set) Token: 0x060009C4 RID: 2500 RVA: 0x0000788B File Offset: 0x00005A8B
		public float f3 { get; set; }

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x060009C5 RID: 2501 RVA: 0x00007894 File Offset: 0x00005A94
		// (set) Token: 0x060009C6 RID: 2502 RVA: 0x0000789C File Offset: 0x00005A9C
		public float f4 { get; set; }

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x060009C7 RID: 2503 RVA: 0x000078A5 File Offset: 0x00005AA5
		// (set) Token: 0x060009C8 RID: 2504 RVA: 0x000078AD File Offset: 0x00005AAD
		public float f5 { get; set; }

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x060009C9 RID: 2505 RVA: 0x000078B6 File Offset: 0x00005AB6
		// (set) Token: 0x060009CA RID: 2506 RVA: 0x000078BE File Offset: 0x00005ABE
		public float f6 { get; set; }

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x060009CB RID: 2507 RVA: 0x000078C7 File Offset: 0x00005AC7
		// (set) Token: 0x060009CC RID: 2508 RVA: 0x000078CF File Offset: 0x00005ACF
		public byte[] bb { get; set; }

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x060009CD RID: 2509 RVA: 0x000078D8 File Offset: 0x00005AD8
		// (set) Token: 0x060009CE RID: 2510 RVA: 0x00007916 File Offset: 0x00005B16
		public float[] BoundingBox
		{
			get
			{
				return new float[]
				{
					this.f1,
					this.f2,
					this.f3,
					this.f4,
					this.f5,
					this.f6
				};
			}
			set
			{
				this.f1 = value[0];
				this.f2 = value[1];
				this.f3 = value[2];
				this.f4 = value[3];
				this.f5 = value[4];
				this.f6 = value[5];
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060009CF RID: 2511 RVA: 0x0000794E File Offset: 0x00005B4E
		// (set) Token: 0x060009D0 RID: 2512 RVA: 0x00007956 File Offset: 0x00005B56
		public byte modularFlag { get; set; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060009D1 RID: 2513 RVA: 0x0000795F File Offset: 0x00005B5F
		// (set) Token: 0x060009D2 RID: 2514 RVA: 0x00007967 File Offset: 0x00005B67
		public int ftptIndex { get; set; }

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x060009D3 RID: 2515 RVA: 0x00007970 File Offset: 0x00005B70
		// (set) Token: 0x060009D4 RID: 2516 RVA: 0x00007978 File Offset: 0x00005B78
		public List<VPXY.VPXEntryEntry> entries { get; set; }

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060009D5 RID: 2517 RVA: 0x0002EFD0 File Offset: 0x0002D1D0
		public string ModelKey
		{
			get
			{
				foreach (TGIIndex tgiindex in this.TGIIndex)
				{
					if (tgiindex.IsType(30478132))
					{
						return tgiindex.Reskey;
					}
				}
				return null;
			}
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0002F038 File Offset: 0x0002D238
		public override void Serialize(BinaryWriter w)
		{
			w.Write(this.typeId);
			w.Write(this.version);
			w.Write(this.tgiOffset);
			w.Write(this.tgiSize);
			w.Write((byte)this.entries.Count);
			foreach (VPXY.VPXEntryEntry vpxentryEntry in this.entries)
			{
				if (vpxentryEntry.type == 0)
				{
					w.Write(vpxentryEntry.type);
					w.Write(vpxentryEntry.msIndex);
					w.Write((byte)vpxentryEntry.index.Count);
					using (List<int>.Enumerator enumerator2 = vpxentryEntry.index.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							int value = enumerator2.Current;
							w.Write(value);
						}
						continue;
					}
				}
				if (vpxentryEntry.type == 1)
				{
					w.Write(vpxentryEntry.type);
					w.Write(vpxentryEntry.index[0]);
				}
				else
				{
					w.Write(vpxentryEntry.index[0]);
				}
			}
			w.Write(this.unkByte1);
			w.Write(this.f1);
			w.Write(this.f2);
			w.Write(this.f3);
			w.Write(this.f4);
			w.Write(this.f5);
			w.Write(this.f6);
			w.Write(this.bb);
			w.Write(this.modularFlag);
			if (this.modularFlag == 1)
			{
				w.Write(this.ftptIndex);
			}
			if (this.TGIIndex.Count > 0)
			{
				w.Write(this.TGIIndex.Count);
				foreach (TGIIndex tgiindex in this.TGIIndex)
				{
					tgiindex.Serialize(w);
				}
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0002F260 File Offset: 0x0002D460
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (TGIIndex tgiindex in this.TGIIndex)
			{
				if (tgiindex.Equals(from))
				{
					tgiindex.SetFromResKey(to);
					num++;
				}
			}
			return num;
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0002F2C4 File Offset: 0x0002D4C4
		public override void UnSerialize(BinaryReader r)
		{
			this.entries = new List<VPXY.VPXEntryEntry>();
			this.TGIIndex = new List<TGIIndex>();
			this.typeId = r.ReadUInt32();
			this.version = r.ReadUInt32();
			this.tgiOffset = r.ReadUInt32();
			this.tgiSize = r.ReadUInt32();
			byte b = r.ReadByte();
			for (int i = 0; i < (int)b; i++)
			{
				VPXY.VPXEntryEntry vpxentryEntry = new VPXY.VPXEntryEntry();
				vpxentryEntry.type = r.ReadByte();
				if (vpxentryEntry.type == 0)
				{
					vpxentryEntry.msIndex = r.ReadByte();
					vpxentryEntry.count = r.ReadByte();
					for (int j = 0; j < (int)vpxentryEntry.count; j++)
					{
						vpxentryEntry.index.Add(r.ReadInt32());
					}
				}
				else if (vpxentryEntry.type == 1)
				{
					vpxentryEntry.index.Add(r.ReadInt32());
				}
				else
				{
					r.BaseStream.Position = r.BaseStream.Position - 1L;
					vpxentryEntry.index.Add(r.ReadInt32());
				}
				this.entries.Add(vpxentryEntry);
			}
			this.unkByte1 = r.ReadByte();
			this.f1 = r.ReadSingle();
			this.f2 = r.ReadSingle();
			this.f3 = r.ReadSingle();
			this.f4 = r.ReadSingle();
			this.f5 = r.ReadSingle();
			this.f6 = r.ReadSingle();
			this.bb = r.ReadBytes(4);
			this.modularFlag = r.ReadByte();
			if (this.modularFlag == 1)
			{
				this.ftptIndex = r.ReadInt32();
			}
			if (this.tgiSize > 0U)
			{
				uint num = r.ReadUInt32();
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					TGIIndex tgiindex = new TGIIndex();
					tgiindex.UnSerialize(r);
					this.TGIIndex.Add(tgiindex);
					num2++;
				}
			}
			if (r.BaseStream.Position < r.BaseStream.Length)
			{
				throw new Exception("did not read to end in VPXY: " + this.ToString());
			}
		}

		// Token: 0x040004C2 RID: 1218
		public List<int> index;

		// Token: 0x020001AC RID: 428
		public class VPXEntryEntry
		{
			// Token: 0x17000507 RID: 1287
			// (get) Token: 0x06001005 RID: 4101 RVA: 0x0000B109 File Offset: 0x00009309
			// (set) Token: 0x06001006 RID: 4102 RVA: 0x0000B111 File Offset: 0x00009311
			public byte type { get; set; }

			// Token: 0x17000508 RID: 1288
			// (get) Token: 0x06001007 RID: 4103 RVA: 0x0000B11A File Offset: 0x0000931A
			// (set) Token: 0x06001008 RID: 4104 RVA: 0x0000B122 File Offset: 0x00009322
			public byte msIndex { get; set; }

			// Token: 0x17000509 RID: 1289
			// (get) Token: 0x06001009 RID: 4105 RVA: 0x0000B12B File Offset: 0x0000932B
			// (set) Token: 0x0600100A RID: 4106 RVA: 0x0000B133 File Offset: 0x00009333
			public byte count { get; set; }

			// Token: 0x1700050A RID: 1290
			// (get) Token: 0x0600100B RID: 4107 RVA: 0x0000B13C File Offset: 0x0000933C
			// (set) Token: 0x0600100C RID: 4108 RVA: 0x0000B144 File Offset: 0x00009344
			public List<int> index { get; set; }

			// Token: 0x0600100D RID: 4109 RVA: 0x0000B14D File Offset: 0x0000934D
			public VPXEntryEntry()
			{
				this.index = new List<int>();
			}
		}
	}
}
