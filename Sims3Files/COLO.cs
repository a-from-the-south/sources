using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200001C RID: 28
	public class COLO : DBPFEntry
	{
		// Token: 0x060001AD RID: 429 RVA: 0x00003C86 File Offset: 0x00001E86
		public COLO()
		{
			this.typeId = 201803423U;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00013670 File Offset: 0x00011870
		public override void UnSerialize()
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			binaryReader.ReadInt32();
			int num = binaryReader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int num2 = binaryReader.ReadInt32();
				Console.WriteLine("0x" + binaryReader.ReadInt32().ToString("X8") + num2.ToString("X8"));
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000330C File Offset: 0x0000150C
		public override byte[] Serialize()
		{
			return this.data;
		}
	}
}
