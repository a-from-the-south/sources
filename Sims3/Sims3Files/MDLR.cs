using System;
using System.Collections.Generic;
using System.IO;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000033 RID: 51
	public class MDLR : DBPFEntry
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000258 RID: 600 RVA: 0x000041A3 File Offset: 0x000023A3
		// (set) Token: 0x06000259 RID: 601 RVA: 0x000041AB File Offset: 0x000023AB
		public short unkShort1 { get; private set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600025A RID: 602 RVA: 0x000041B4 File Offset: 0x000023B4
		// (set) Token: 0x0600025B RID: 603 RVA: 0x000041BC File Offset: 0x000023BC
		public uint tgiOffset { get; private set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600025C RID: 604 RVA: 0x000041C5 File Offset: 0x000023C5
		// (set) Token: 0x0600025D RID: 605 RVA: 0x000041CD File Offset: 0x000023CD
		public uint tgiSize { get; private set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600025E RID: 606 RVA: 0x000041D6 File Offset: 0x000023D6
		// (set) Token: 0x0600025F RID: 607 RVA: 0x000041DE File Offset: 0x000023DE
		public short unkShort2 { get; private set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000260 RID: 608 RVA: 0x000041E7 File Offset: 0x000023E7
		// (set) Token: 0x06000261 RID: 609 RVA: 0x000041EF File Offset: 0x000023EF
		public short indexCount { get; private set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000262 RID: 610 RVA: 0x000041F8 File Offset: 0x000023F8
		// (set) Token: 0x06000263 RID: 611 RVA: 0x00004200 File Offset: 0x00002400
		public List<uint> index { get; private set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00004209 File Offset: 0x00002409
		// (set) Token: 0x06000265 RID: 613 RVA: 0x00004211 File Offset: 0x00002411
		public List<TGIIndex> TGIIndex { get; private set; }

		// Token: 0x06000266 RID: 614 RVA: 0x0000421A File Offset: 0x0000241A
		public MDLR()
		{
			this.index = new List<uint>();
			this.TGIIndex = new List<TGIIndex>();
			this.typeId = 3482995406U;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00014A60 File Offset: 0x00012C60
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

		// Token: 0x06000268 RID: 616 RVA: 0x00014AC4 File Offset: 0x00012CC4
		public override void UnSerialize()
		{
			this.index.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.unkShort1 = binaryReader.ReadInt16();
			this.tgiOffset = binaryReader.ReadUInt32();
			this.tgiSize = binaryReader.ReadUInt32();
			this.unkShort2 = binaryReader.ReadInt16();
			this.indexCount = binaryReader.ReadInt16();
			for (int i = 0; i < (int)this.indexCount; i++)
			{
				this.index.Add(binaryReader.ReadUInt32());
			}
			uint num = binaryReader.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(binaryReader);
				this.TGIIndex.Add(tgiindex);
				num2++;
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00014B90 File Offset: 0x00012D90
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.unkShort1);
			binaryWriter.Write(this.tgiOffset);
			binaryWriter.Write(this.tgiSize);
			binaryWriter.Write(this.unkShort2);
			binaryWriter.Write((short)this.index.Count);
			foreach (uint value in this.index)
			{
				binaryWriter.Write(value);
			}
			binaryWriter.Write(this.TGIIndex.Count);
			foreach (TGIIndex tgiindex in this.TGIIndex)
			{
				tgiindex.Serialize(binaryWriter);
			}
			byte[] result = memoryStream.ToArray();
			memoryStream.Dispose();
			binaryWriter.Close();
			return result;
		}
	}
}
