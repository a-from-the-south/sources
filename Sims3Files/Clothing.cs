using System;
using System.IO;
using System.Text;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000027 RID: 39
	public class Clothing : DBPFEntry
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00003D91 File Offset: 0x00001F91
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x00003D99 File Offset: 0x00001F99
		public uint UnkDword1 { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x00003DA2 File Offset: 0x00001FA2
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x00003DAA File Offset: 0x00001FAA
		public uint UnkDword2 { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00003DB3 File Offset: 0x00001FB3
		// (set) Token: 0x060001D9 RID: 473 RVA: 0x00003DBB File Offset: 0x00001FBB
		public uint UnkDword3 { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00003DC4 File Offset: 0x00001FC4
		// (set) Token: 0x060001DB RID: 475 RVA: 0x00003DCC File Offset: 0x00001FCC
		public uint Bgeo_type { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00003DD5 File Offset: 0x00001FD5
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00003DDD File Offset: 0x00001FDD
		public uint Bgeo_group { get; set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00003DE6 File Offset: 0x00001FE6
		// (set) Token: 0x060001DF RID: 479 RVA: 0x00003DEE File Offset: 0x00001FEE
		public uint Bgeo_instance { get; set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00003DF7 File Offset: 0x00001FF7
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x00003DFF File Offset: 0x00001FFF
		public uint Bgeo_secondIstance { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00003E08 File Offset: 0x00002008
		// (set) Token: 0x060001E3 RID: 483 RVA: 0x00003E10 File Offset: 0x00002010
		public string FileName { get; set; }

		// Token: 0x060001E4 RID: 484 RVA: 0x000038FA File Offset: 0x00001AFA
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00013AA0 File Offset: 0x00011CA0
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.UnkDword1 = binaryReader.ReadUInt32();
			this.UnkDword2 = binaryReader.ReadUInt32();
			this.UnkDword3 = binaryReader.ReadUInt32();
			byte[] array = new byte[(int)binaryReader.ReadByte()];
			for (int i = 0; i < array.Length; i += 2)
			{
				array[i + 1] = binaryReader.ReadByte();
				array[i] = binaryReader.ReadByte();
			}
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			this.FileName = unicodeEncoding.GetString(array);
			binaryReader.ReadUInt32();
			this.Bgeo_type = binaryReader.ReadUInt32();
			this.Bgeo_group = binaryReader.ReadUInt32();
			this.Bgeo_instance = binaryReader.ReadUInt32();
			this.Bgeo_secondIstance = binaryReader.ReadUInt32();
			binaryReader.Close();
			memoryStream.Dispose();
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x000038FA File Offset: 0x00001AFA
		public override byte[] Serialize()
		{
			throw new NotImplementedException();
		}
	}
}
