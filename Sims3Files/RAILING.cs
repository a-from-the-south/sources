using System;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200003F RID: 63
	public class RAILING : Sims3BuildItem
	{
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00004A64 File Offset: 0x00002C64
		// (set) Token: 0x0600035D RID: 861 RVA: 0x00004A6C File Offset: 0x00002C6C
		public int Railing4xModel { get; set; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00004A75 File Offset: 0x00002C75
		// (set) Token: 0x0600035F RID: 863 RVA: 0x00004A7D File Offset: 0x00002C7D
		public int Railing1xModel { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000360 RID: 864 RVA: 0x00004A86 File Offset: 0x00002C86
		// (set) Token: 0x06000361 RID: 865 RVA: 0x00004A8E File Offset: 0x00002C8E
		public override int PostModel { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00004A97 File Offset: 0x00002C97
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00004A9F File Offset: 0x00002C9F
		public override int VPXYIndex
		{
			get
			{
				return this.Railing4xModel;
			}
			set
			{
				this.Railing4xModel = value;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000364 RID: 868 RVA: 0x00004AA8 File Offset: 0x00002CA8
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00004AB0 File Offset: 0x00002CB0
		public override int DiagonalModelIndex
		{
			get
			{
				return this.Railing1xModel;
			}
			set
			{
				this.Railing1xModel = value;
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00004AB9 File Offset: 0x00002CB9
		public RAILING()
		{
			this.typeId = 80052483U;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00013C0C File Offset: 0x00011E0C
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

		// Token: 0x06000368 RID: 872 RVA: 0x0001947C File Offset: 0x0001767C
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
			this.Railing4xModel = binaryReader.ReadInt32();
			this.Railing1xModel = binaryReader.ReadInt32();
			this.PostModel = binaryReader.ReadInt32();
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

		// Token: 0x06000369 RID: 873 RVA: 0x00019580 File Offset: 0x00017780
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
			binaryWriter2.Write(this.Railing4xModel);
			binaryWriter2.Write(this.Railing1xModel);
			binaryWriter2.Write(this.PostModel);
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

		// Token: 0x040001B1 RID: 433
		private uint tgiOffset;

		// Token: 0x040001B2 RID: 434
		private uint tgiSize;
	}
}
