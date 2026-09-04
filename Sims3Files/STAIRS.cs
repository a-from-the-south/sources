using System;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000049 RID: 73
	public class STAIRS : Sims3BuildItem
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00004C04 File Offset: 0x00002E04
		// (set) Token: 0x06000399 RID: 921 RVA: 0x00004C0C File Offset: 0x00002E0C
		public override int VPXYIndex
		{
			get
			{
				return this.Steps4xModel;
			}
			set
			{
				this.Steps4xModel = value;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00004C15 File Offset: 0x00002E15
		// (set) Token: 0x0600039B RID: 923 RVA: 0x00004C1D File Offset: 0x00002E1D
		public override int DiagonalModelIndex
		{
			get
			{
				return this.Steps1xModel;
			}
			set
			{
				this.Steps1xModel = value;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00004C26 File Offset: 0x00002E26
		// (set) Token: 0x0600039D RID: 925 RVA: 0x00004C2E File Offset: 0x00002E2E
		public override int PostModel
		{
			get
			{
				return this.WallCapModel;
			}
			set
			{
				this.WallCapModel = value;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00004C37 File Offset: 0x00002E37
		// (set) Token: 0x0600039F RID: 927 RVA: 0x00004C3F File Offset: 0x00002E3F
		public int Steps4xModel { get; set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00004C48 File Offset: 0x00002E48
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x00004C50 File Offset: 0x00002E50
		public int Steps1xModel { get; set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00004C59 File Offset: 0x00002E59
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x00004C61 File Offset: 0x00002E61
		public int WallCapModel { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00004C6A File Offset: 0x00002E6A
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x00004C72 File Offset: 0x00002E72
		public int Railing { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x00004C7B File Offset: 0x00002E7B
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x00004C83 File Offset: 0x00002E83
		public int Wall { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x00004C8C File Offset: 0x00002E8C
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x00004C94 File Offset: 0x00002E94
		public int Floor { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060003AA RID: 938 RVA: 0x00004C9D File Offset: 0x00002E9D
		// (set) Token: 0x060003AB RID: 939 RVA: 0x00004CA5 File Offset: 0x00002EA5
		public int Fence { get; set; }

		// Token: 0x060003AC RID: 940 RVA: 0x00004CAE File Offset: 0x00002EAE
		public STAIRS()
		{
			this.typeId = 77374669U;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00013C0C File Offset: 0x00011E0C
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (TGIIndex tgiindex in base.TGIIndex)
			{
				if (tgiindex.Equals(from))
				{
					tgiindex.SetFromResKey(to);
					num++;
				}
			}
			foreach (OBJD.Material material in base.Materials)
			{
				num += material.ReplaceReferences(from, to);
			}
			return num;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00019D94 File Offset: 0x00017F94
		public override void UnSerialize()
		{
			base.TGIIndex.Clear();
			base.Materials.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			base.Version = binaryReader.ReadUInt32();
			this.tgiOffset = binaryReader.ReadUInt32();
			this.tgiSize = binaryReader.ReadUInt32();
			if (base.Version == 3U)
			{
				uint num = binaryReader.ReadUInt32();
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					OBJD.Material material = new OBJD.Material();
					material.Unserialize(binaryReader);
					base.Materials.Add(material);
					num2++;
				}
			}
			base._readCommonSection(binaryReader);
			this.Steps4xModel = binaryReader.ReadInt32();
			this.Steps1xModel = binaryReader.ReadInt32();
			this.WallCapModel = binaryReader.ReadInt32();
			this.Railing = binaryReader.ReadInt32();
			this.Wall = binaryReader.ReadInt32();
			this.Floor = binaryReader.ReadInt32();
			this.Fence = binaryReader.ReadInt32();
			uint num3 = binaryReader.ReadUInt32();
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num3))
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(binaryReader);
				base.TGIIndex.Add(tgiindex);
				num4++;
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00019EC8 File Offset: 0x000180C8
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.BigEndianUnicode);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2, Encoding.BigEndianUnicode);
			if (base.Version == 3U)
			{
				binaryWriter2.Write(base.Materials.Count);
				foreach (OBJD.Material material in base.Materials)
				{
					material.Serialize(binaryWriter2);
				}
			}
			base._writeCommon(binaryWriter2);
			binaryWriter2.Write(this.Steps4xModel);
			binaryWriter2.Write(this.Steps1xModel);
			binaryWriter2.Write(this.WallCapModel);
			binaryWriter2.Write(this.Railing);
			binaryWriter2.Write(this.Wall);
			binaryWriter2.Write(this.Floor);
			binaryWriter2.Write(this.Fence);
			this.tgiOffset = (uint)binaryWriter2.BaseStream.Position;
			binaryWriter2.Write(base.TGIIndex.Count);
			foreach (TGIIndex tgiindex in base.TGIIndex)
			{
				tgiindex.Serialize(binaryWriter2);
			}
			this.tgiSize = (uint)binaryWriter2.BaseStream.Position - this.tgiOffset;
			binaryWriter.Write(base.Version);
			binaryWriter.Write(this.tgiOffset + 4U);
			binaryWriter.Write(this.tgiSize);
			binaryWriter.Write(memoryStream2.ToArray());
			byte[] result = memoryStream.ToArray();
			memoryStream2.Dispose();
			memoryStream.Dispose();
			return result;
		}

		// Token: 0x040001EA RID: 490
		private uint tgiOffset;

		// Token: 0x040001EB RID: 491
		private uint tgiSize;
	}
}
