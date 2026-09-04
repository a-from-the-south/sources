using System;
using System.IO;

namespace Package.Sims3Files
{
	// Token: 0x02000047 RID: 71
	public class SomeFile_2 : SomeFile
	{
		// Token: 0x0600038F RID: 911 RVA: 0x00004BB0 File Offset: 0x00002DB0
		public SomeFile_2()
		{
			this.typeId = 54137909U;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00019C08 File Offset: 0x00017E08
		public override void UnSerialize()
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			this.identifier = binaryReader.ReadUInt32();
			this.lengthOfData = binaryReader.ReadUInt32();
			this.unknownData = binaryReader.ReadBytes((int)this.lengthOfData);
			this.numItems = binaryReader.ReadByte();
			this.items = new uint[(int)this.numItems][];
			for (int i = 0; i < (int)this.numItems; i++)
			{
				this.items[i] = new uint[4];
				this.items[i][0] = binaryReader.ReadUInt32();
				this.items[i][1] = binaryReader.ReadUInt32();
				this.items[i][2] = binaryReader.ReadUInt32();
				this.items[i][3] = binaryReader.ReadUInt32();
			}
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00004BC3 File Offset: 0x00002DC3
		public override string ToString()
		{
			return "SMKD_2 | " + base.ToString();
		}
	}
}
