using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200001A RID: 26
	public class CCACHE : DBPFEntry
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00003C1B File Offset: 0x00001E1B
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00003C23 File Offset: 0x00001E23
		public uint Version { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00003C2C File Offset: 0x00001E2C
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x00003C34 File Offset: 0x00001E34
		public uint Dword { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00003C3D File Offset: 0x00001E3D
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x00003C45 File Offset: 0x00001E45
		public uint Dword2 { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00003C4E File Offset: 0x00001E4E
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x00003C56 File Offset: 0x00001E56
		public uint Dword3 { get; set; }

		// Token: 0x060001A5 RID: 421 RVA: 0x00003C5F File Offset: 0x00001E5F
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			if (base.ResKey.Equals(from))
			{
				base.ResKey.SetFromResKey(to);
				return 1;
			}
			return 0;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0001327C File Offset: 0x0001147C
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.Version = binaryReader.ReadUInt32();
			this.Dword = binaryReader.ReadUInt32();
			this.Dword2 = binaryReader.ReadUInt32();
			this.Dword3 = binaryReader.ReadUInt32();
			uint num = binaryReader.ReadUInt32();
			uint num2 = binaryReader.ReadUInt32();
			uint num3 = binaryReader.ReadUInt32();
			uint num4 = binaryReader.ReadUInt32();
			base.ResKey = new ResKey(num, (int)num2, (int)num3, (int)num4);
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00013304 File Offset: 0x00011504
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.Version);
			binaryWriter.Write(this.Dword);
			binaryWriter.Write(this.Dword2);
			binaryWriter.Write(this.Dword3);
			binaryWriter.Write(base.ResKey.TypeId);
			binaryWriter.Write((uint)base.ResKey.GroupId);
			binaryWriter.Write((uint)base.ResKey.InstanceId);
			binaryWriter.Write((uint)base.ResKey.SecondInstanceId);
			binaryWriter.Close();
			this.data = memoryStream.ToArray();
			memoryStream.Dispose();
			return this.data;
		}
	}
}
