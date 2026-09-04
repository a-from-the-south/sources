using System;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200002B RID: 43
	public class FirePlace : Sims3BuildItem
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00003F40 File Offset: 0x00002140
		// (set) Token: 0x0600020E RID: 526 RVA: 0x00003F48 File Offset: 0x00002148
		public FireplaceType FireplaceType { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00003F51 File Offset: 0x00002151
		// (set) Token: 0x06000210 RID: 528 RVA: 0x00003F59 File Offset: 0x00002159
		public int[] Index { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x06000212 RID: 530 RVA: 0x000032EA File Offset: 0x000014EA
		public override int PostModel
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x06000214 RID: 532 RVA: 0x000032EA File Offset: 0x000014EA
		public override int VPXYIndex
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x06000216 RID: 534 RVA: 0x000032EA File Offset: 0x000014EA
		public override int DiagonalModelIndex
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00003F62 File Offset: 0x00002162
		public FirePlace()
		{
			this.typeId = 83086337U;
			this.Index = new int[7];
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0001409C File Offset: 0x0001229C
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
			return num;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00014100 File Offset: 0x00012300
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			base.Version = binaryReader.ReadUInt32();
			this.tgiOffset = binaryReader.ReadUInt32();
			this.tgiSize = binaryReader.ReadUInt32();
			base._readCommonSection(binaryReader);
			this.FireplaceType = (FireplaceType)binaryReader.ReadByte();
			this.Index[0] = binaryReader.ReadInt32();
			this.Index[1] = binaryReader.ReadInt32();
			this.Index[2] = binaryReader.ReadInt32();
			this.Index[3] = binaryReader.ReadInt32();
			this.Index[4] = binaryReader.ReadInt32();
			this.Index[5] = binaryReader.ReadInt32();
			this.Index[6] = binaryReader.ReadInt32();
			uint num = binaryReader.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(binaryReader);
				base.TGIIndex.Add(tgiindex);
				num2++;
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x0600021A RID: 538 RVA: 0x000141F8 File Offset: 0x000123F8
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.BigEndianUnicode);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2, Encoding.BigEndianUnicode);
			base._writeCommon(binaryWriter2);
			binaryWriter2.Write((byte)this.FireplaceType);
			binaryWriter2.Write(this.Index[0]);
			binaryWriter2.Write(this.Index[1]);
			binaryWriter2.Write(this.Index[2]);
			binaryWriter2.Write(this.Index[3]);
			binaryWriter2.Write(this.Index[4]);
			binaryWriter2.Write(this.Index[5]);
			binaryWriter2.Write(this.Index[6]);
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

		// Token: 0x04000123 RID: 291
		private uint tgiOffset;

		// Token: 0x04000124 RID: 292
		private uint tgiSize;
	}
}
