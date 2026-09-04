using System;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200002C RID: 44
	public class FLOOR : Sims3BuildItem
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600021B RID: 539 RVA: 0x00003F81 File Offset: 0x00002181
		// (set) Token: 0x0600021C RID: 540 RVA: 0x00003F89 File Offset: 0x00002189
		public override int VPXYIndex { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600021D RID: 541 RVA: 0x00003F92 File Offset: 0x00002192
		// (set) Token: 0x0600021E RID: 542 RVA: 0x00003F9A File Offset: 0x0000219A
		public override int DiagonalModelIndex { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00003FA3 File Offset: 0x000021A3
		// (set) Token: 0x06000220 RID: 544 RVA: 0x00003FAB File Offset: 0x000021AB
		public override int PostModel { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00003FB4 File Offset: 0x000021B4
		// (set) Token: 0x06000222 RID: 546 RVA: 0x00003FBC File Offset: 0x000021BC
		public uint Unknown2 { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000223 RID: 547 RVA: 0x00003FC5 File Offset: 0x000021C5
		// (set) Token: 0x06000224 RID: 548 RVA: 0x00003FCD File Offset: 0x000021CD
		public byte Unknown3 { get; set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000225 RID: 549 RVA: 0x00003FD6 File Offset: 0x000021D6
		// (set) Token: 0x06000226 RID: 550 RVA: 0x00003FDE File Offset: 0x000021DE
		public uint Unknown4 { get; set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00003FE7 File Offset: 0x000021E7
		// (set) Token: 0x06000228 RID: 552 RVA: 0x00003FEF File Offset: 0x000021EF
		public byte Unknown5 { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00003FF8 File Offset: 0x000021F8
		// (set) Token: 0x0600022A RID: 554 RVA: 0x00004000 File Offset: 0x00002200
		public uint Unknown6 { get; set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600022B RID: 555 RVA: 0x00004009 File Offset: 0x00002209
		// (set) Token: 0x0600022C RID: 556 RVA: 0x00004011 File Offset: 0x00002211
		public byte Unknown7 { get; set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600022D RID: 557 RVA: 0x0000401A File Offset: 0x0000221A
		// (set) Token: 0x0600022E RID: 558 RVA: 0x00004022 File Offset: 0x00002222
		public int Index4 { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600022F RID: 559 RVA: 0x0000402B File Offset: 0x0000222B
		// (set) Token: 0x06000230 RID: 560 RVA: 0x00004033 File Offset: 0x00002233
		public int Index5 { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000231 RID: 561 RVA: 0x0000403C File Offset: 0x0000223C
		// (set) Token: 0x06000232 RID: 562 RVA: 0x00004044 File Offset: 0x00002244
		public int Index6 { get; set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000233 RID: 563 RVA: 0x0000404D File Offset: 0x0000224D
		// (set) Token: 0x06000234 RID: 564 RVA: 0x00004055 File Offset: 0x00002255
		public byte[] ByteData { get; set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000235 RID: 565 RVA: 0x0000405E File Offset: 0x0000225E
		// (set) Token: 0x06000236 RID: 566 RVA: 0x00004066 File Offset: 0x00002266
		public byte[] ByteData2 { get; set; }

		// Token: 0x06000237 RID: 567 RVA: 0x0000406F File Offset: 0x0000226F
		public FLOOR()
		{
			this.typeId = 1365025997U;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0001409C File Offset: 0x0001229C
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

		// Token: 0x06000239 RID: 569 RVA: 0x0001436C File Offset: 0x0001256C
		public override void UnSerialize()
		{
			base.TGIIndex.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			base.Version = binaryReader.ReadUInt32();
			this.tgiOffset = binaryReader.ReadUInt32();
			this.tgiSize = binaryReader.ReadUInt32();
			base._readCommonSection(binaryReader);
			this.Unknown2 = binaryReader.ReadUInt32();
			this.Unknown3 = binaryReader.ReadByte();
			this.Unknown4 = binaryReader.ReadUInt32();
			this.Unknown5 = binaryReader.ReadByte();
			this.Unknown6 = binaryReader.ReadUInt32();
			this.Unknown7 = binaryReader.ReadByte();
			this.ByteData = binaryReader.ReadBytes(4);
			this.VPXYIndex = binaryReader.ReadInt32();
			this.DiagonalModelIndex = binaryReader.ReadInt32();
			this.PostModel = binaryReader.ReadInt32();
			this.Index4 = binaryReader.ReadInt32();
			this.Index5 = binaryReader.ReadInt32();
			this.Index6 = binaryReader.ReadInt32();
			this.ByteData = binaryReader.ReadBytes(8);
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

		// Token: 0x0600023A RID: 570 RVA: 0x000144AC File Offset: 0x000126AC
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.BigEndianUnicode);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2, Encoding.BigEndianUnicode);
			base._writeCommon(binaryWriter2);
			binaryWriter2.Write(this.Unknown2);
			binaryWriter2.Write(this.Unknown3);
			binaryWriter2.Write(this.Unknown4);
			binaryWriter2.Write(this.Unknown5);
			binaryWriter2.Write(this.Unknown6);
			binaryWriter2.Write(this.Unknown7);
			binaryWriter2.Write(this.ByteData);
			binaryWriter2.Write(this.VPXYIndex);
			binaryWriter2.Write(this.DiagonalModelIndex);
			binaryWriter2.Write(this.PostModel);
			binaryWriter2.Write(this.Index4);
			binaryWriter2.Write(this.Index5);
			binaryWriter2.Write(this.Index6);
			binaryWriter2.Write(this.ByteData2);
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

		// Token: 0x04000133 RID: 307
		private uint tgiOffset;

		// Token: 0x04000134 RID: 308
		private uint tgiSize;
	}
}
