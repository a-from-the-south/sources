using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000046 RID: 70
	public class SomeFile : DBPFEntry
	{
		// Token: 0x06000386 RID: 902 RVA: 0x00004B69 File Offset: 0x00002D69
		public SomeFile()
		{
			this.typeId = 54635721U;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x000038FA File Offset: 0x00001AFA
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00019C08 File Offset: 0x00017E08
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

		// Token: 0x06000389 RID: 905 RVA: 0x000038FA File Offset: 0x00001AFA
		public override byte[] Serialize()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00004B7C File Offset: 0x00002D7C
		public uint Identifier
		{
			get
			{
				return this.identifier;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00004B84 File Offset: 0x00002D84
		public byte[] UknownData
		{
			get
			{
				return this.unknownData;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600038C RID: 908 RVA: 0x00004B8C File Offset: 0x00002D8C
		public uint NumItems
		{
			get
			{
				return (uint)this.items.Length;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00004B96 File Offset: 0x00002D96
		public uint[][] Items
		{
			get
			{
				return this.items;
			}
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00004B9E File Offset: 0x00002D9E
		public override string ToString()
		{
			return "SMKD | " + base.ToString();
		}

		// Token: 0x040001DD RID: 477
		protected uint identifier;

		// Token: 0x040001DE RID: 478
		protected uint lengthOfData;

		// Token: 0x040001DF RID: 479
		protected byte[] unknownData;

		// Token: 0x040001E0 RID: 480
		protected byte numItems;

		// Token: 0x040001E1 RID: 481
		protected uint[][] items;
	}
}
