using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000B6 RID: 182
	public class MTST : RCOLItem, ICloneable
	{
		// Token: 0x1700030C RID: 780
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x0000741C File Offset: 0x0000561C
		// (set) Token: 0x0600092C RID: 2348 RVA: 0x00007424 File Offset: 0x00005624
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Type { get; set; }

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x0000742D File Offset: 0x0000562D
		// (set) Token: 0x0600092E RID: 2350 RVA: 0x00007435 File Offset: 0x00005635
		[Browsable(false)]
		public byte[] Data { get; set; }

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x0000743E File Offset: 0x0000563E
		// (set) Token: 0x06000930 RID: 2352 RVA: 0x00007446 File Offset: 0x00005646
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Version { get; set; }

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000931 RID: 2353 RVA: 0x0000744F File Offset: 0x0000564F
		// (set) Token: 0x06000932 RID: 2354 RVA: 0x00007457 File Offset: 0x00005657
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Unknown { get; set; }

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000933 RID: 2355 RVA: 0x00007460 File Offset: 0x00005660
		// (set) Token: 0x06000934 RID: 2356 RVA: 0x00007468 File Offset: 0x00005668
		[TypeConverter(typeof(IntTypeConverter))]
		public int MATDIndex { get; set; }

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000935 RID: 2357 RVA: 0x00007471 File Offset: 0x00005671
		// (set) Token: 0x06000936 RID: 2358 RVA: 0x00007479 File Offset: 0x00005679
		public List<MTST.MTSTEntry> Entries { get; set; }

		// Token: 0x06000937 RID: 2359 RVA: 0x00007482 File Offset: 0x00005682
		public MTST()
		{
			this.Entries = new List<MTST.MTSTEntry>();
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0002D6A8 File Offset: 0x0002B8A8
		public override void UnSerialize(BinaryReader r)
		{
			this.Type = r.ReadUInt32();
			this.Version = r.ReadUInt32();
			this.Unknown = r.ReadUInt32();
			this.MATDIndex = (int)((long)r.ReadInt32() & 4026531839L);
			uint num = r.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				MTST.MTSTEntry mtstentry = new MTST.MTSTEntry(this.Version);
				mtstentry.Unserialize(r);
				this.Entries.Add(mtstentry);
				num2++;
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0002D728 File Offset: 0x0002B928
		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(this.Type);
			writer.Write(this.Version);
			writer.Write(this.Unknown);
			writer.Write(this.MATDIndex | ((this.MATDIndex != 0) ? 268435456 : 0));
			writer.Write(this.Entries.Count);
			foreach (MTST.MTSTEntry mtstentry in this.Entries)
			{
				mtstentry.Serialize(writer);
			}
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0002D7CC File Offset: 0x0002B9CC
		public object Clone()
		{
			MTST mtst = new MTST();
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			this.Serialize(binaryWriter);
			MemoryStream memoryStream2 = new MemoryStream(memoryStream.ToArray());
			BinaryReader binaryReader = new BinaryReader(memoryStream2);
			mtst.UnSerialize(binaryReader);
			memoryStream.Dispose();
			memoryStream2.Dispose();
			binaryWriter.Close();
			binaryReader.Close();
			return mtst;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00007495 File Offset: 0x00005695
		public override string ToString()
		{
			return "MTST";
		}

		// Token: 0x020001A5 RID: 421
		public class MTSTEntry
		{
			// Token: 0x170004DC RID: 1244
			// (get) Token: 0x06000F9E RID: 3998 RVA: 0x0000AD7B File Offset: 0x00008F7B
			// (set) Token: 0x06000F9F RID: 3999 RVA: 0x0000AD83 File Offset: 0x00008F83
			[TypeConverter(typeof(IntTypeConverter))]
			public int MATDIndex { get; set; }

			// Token: 0x170004DD RID: 1245
			// (get) Token: 0x06000FA0 RID: 4000 RVA: 0x0000AD8C File Offset: 0x00008F8C
			// (set) Token: 0x06000FA1 RID: 4001 RVA: 0x0000AD94 File Offset: 0x00008F94
			[TypeConverter(typeof(IntTypeConverter))]
			public uint Hash { get; set; }

			// Token: 0x170004DE RID: 1246
			// (get) Token: 0x06000FA2 RID: 4002 RVA: 0x0000AD9D File Offset: 0x00008F9D
			// (set) Token: 0x06000FA3 RID: 4003 RVA: 0x0000ADA5 File Offset: 0x00008FA5
			[TypeConverter(typeof(IntTypeConverter))]
			public uint VariantNameHash { get; set; }

			// Token: 0x170004DF RID: 1247
			// (get) Token: 0x06000FA4 RID: 4004 RVA: 0x0000ADAE File Offset: 0x00008FAE
			// (set) Token: 0x06000FA5 RID: 4005 RVA: 0x0000ADB6 File Offset: 0x00008FB6
			public uint Version { get; set; }

			// Token: 0x06000FA6 RID: 4006 RVA: 0x0000ADBF File Offset: 0x00008FBF
			public MTSTEntry(uint version)
			{
				this.Version = version;
			}

			// Token: 0x06000FA7 RID: 4007 RVA: 0x0000ADCE File Offset: 0x00008FCE
			public void Unserialize(BinaryReader r)
			{
				this.MATDIndex = (int)((long)r.ReadInt32() & 4026531839L);
				this.Hash = r.ReadUInt32();
				if (this.Version == 768U)
				{
					this.VariantNameHash = r.ReadUInt32();
				}
			}

			// Token: 0x06000FA8 RID: 4008 RVA: 0x00043CDC File Offset: 0x00041EDC
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.MATDIndex | ((this.MATDIndex != 0) ? 268435456 : 0));
				w.Write(this.Hash);
				if (this.Version == 768U)
				{
					w.Write(this.VariantNameHash);
				}
			}

			// Token: 0x06000FA9 RID: 4009 RVA: 0x0000AE0D File Offset: 0x0000900D
			public MTST.MTSTEntry Clone()
			{
				return new MTST.MTSTEntry(this.Version)
				{
					MATDIndex = this.MATDIndex,
					Hash = this.Hash,
					VariantNameHash = this.VariantNameHash
				};
			}

			// Token: 0x06000FAA RID: 4010 RVA: 0x00043D2C File Offset: 0x00041F2C
			public override string ToString()
			{
				return "MTST Entry 0x" + this.Hash.ToString("X8");
			}
		}
	}
}
