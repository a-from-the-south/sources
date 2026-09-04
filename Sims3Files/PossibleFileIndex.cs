using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000040 RID: 64
	public class PossibleFileIndex : DBPFEntry
	{
		// Token: 0x0600036A RID: 874 RVA: 0x00004ACC File Offset: 0x00002CCC
		public PossibleFileIndex()
		{
			this.typeId = 81276304U;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000038FA File Offset: 0x00001AFA
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00019704 File Offset: 0x00017904
		public override void UnSerialize()
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			binaryReader.ReadUInt16();
			ushort num = binaryReader.ReadUInt16();
			this.items = new uint[(int)num][];
			for (int i = 0; i < (int)num; i++)
			{
				this.items[i] = new uint[4];
				this.items[i][0] = binaryReader.ReadUInt32();
				this.items[i][1] = binaryReader.ReadUInt32();
				this.items[i][2] = binaryReader.ReadUInt32();
				this.items[i][3] = binaryReader.ReadUInt32();
			}
			binaryReader.Close();
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600036D RID: 877 RVA: 0x00004ADF File Offset: 0x00002CDF
		public uint[][] Items
		{
			get
			{
				return this.items;
			}
		}

		// Token: 0x0600036E RID: 878 RVA: 0x000038FA File Offset: 0x00001AFA
		public override byte[] Serialize()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00004AE7 File Offset: 0x00002CE7
		public override string ToString()
		{
			return "PossibleFileIndex | " + base.ToString();
		}

		// Token: 0x040001B3 RID: 435
		private uint[][] items;
	}
}
