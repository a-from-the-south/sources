using System;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000044 RID: 68
	public class ROOF : Sims3BuildItem
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000377 RID: 887 RVA: 0x00004B2B File Offset: 0x00002D2B
		// (set) Token: 0x06000378 RID: 888 RVA: 0x000032EA File Offset: 0x000014EA
		public override int VPXYIndex
		{
			get
			{
				return this.TopMaterialIndex;
			}
			set
			{
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000379 RID: 889 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x0600037A RID: 890 RVA: 0x000032EA File Offset: 0x000014EA
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

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600037B RID: 891 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x0600037C RID: 892 RVA: 0x000032EA File Offset: 0x000014EA
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

		// Token: 0x0600037D RID: 893 RVA: 0x00004B33 File Offset: 0x00002D33
		public ROOF()
		{
			this.typeId = 4058889606U;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0001409C File Offset: 0x0001229C
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

		// Token: 0x0600037F RID: 895 RVA: 0x0001979C File Offset: 0x0001799C
		public override void UnSerialize()
		{
			base.TGIIndex.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			base.Version = binaryReader.ReadUInt32();
			this.tgiOffset = binaryReader.ReadUInt32();
			this.tgiSize = binaryReader.ReadUInt32();
			base._readCommonSection(binaryReader);
			this.TopMaterialIndex = binaryReader.ReadInt32();
			this.UndersideMaterialIndex = binaryReader.ReadInt32();
			this.SideStripsMaterialIndex = binaryReader.ReadInt32();
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

		// Token: 0x06000380 RID: 896 RVA: 0x00019854 File Offset: 0x00017A54
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.BigEndianUnicode);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2, Encoding.BigEndianUnicode);
			base._writeCommon(binaryWriter2);
			binaryWriter2.Write(this.TopMaterialIndex);
			binaryWriter2.Write(this.UndersideMaterialIndex);
			binaryWriter2.Write(this.SideStripsMaterialIndex);
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

		// Token: 0x040001D7 RID: 471
		private uint tgiOffset;

		// Token: 0x040001D8 RID: 472
		private uint tgiSize;

		// Token: 0x040001D9 RID: 473
		public int TopMaterialIndex;

		// Token: 0x040001DA RID: 474
		public int UndersideMaterialIndex;

		// Token: 0x040001DB RID: 475
		public int SideStripsMaterialIndex;
	}
}
