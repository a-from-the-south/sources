using System;
using System.Collections.Generic;
using System.IO;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200004C RID: 76
	public class Test : DBPFEntry
	{
		// Token: 0x060003ED RID: 1005 RVA: 0x00004E4C File Offset: 0x0000304C
		public Test()
		{
			this.typeId = 887432316U;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x000038FA File Offset: 0x00001AFA
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0001AAAC File Offset: 0x00018CAC
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			binaryReader.ReadUInt16();
			uint num = binaryReader.ReadUInt32();
			binaryReader.ReadUInt16();
			uint num2 = binaryReader.ReadUInt32();
			binaryReader.BaseStream.Position = (long)((ulong)(num2 + 6U));
			ushort num3 = binaryReader.ReadUInt16();
			short[][] array = new short[(int)num3][];
			for (int i = 0; i < (int)num3; i++)
			{
				array[i] = new short[4];
				array[i][0] = binaryReader.ReadInt16();
				array[i][1] = binaryReader.ReadInt16();
				array[i][2] = binaryReader.ReadInt16();
				array[i][3] = binaryReader.ReadInt16();
			}
			binaryReader.BaseStream.Position = (long)((ulong)num);
			uint num4 = binaryReader.ReadUInt32();
			List<TGIIndex> list = new List<TGIIndex>();
			int num5 = 0;
			while ((long)num5 < (long)((ulong)num4))
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(binaryReader);
				list.Add(tgiindex);
				num5++;
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x000038FA File Offset: 0x00001AFA
		public override byte[] Serialize()
		{
			throw new NotImplementedException();
		}
	}
}
