using System;
using System.Collections.Generic;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000048 RID: 72
	public class SpeedTree : DBPFEntry
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000392 RID: 914 RVA: 0x00004BD5 File Offset: 0x00002DD5
		// (set) Token: 0x06000393 RID: 915 RVA: 0x00004BDD File Offset: 0x00002DDD
		public List<SpeedTree.TextureValue> TextureValues { get; private set; }

		// Token: 0x06000394 RID: 916 RVA: 0x00004BE6 File Offset: 0x00002DE6
		public SpeedTree()
		{
			this.typeId = 11883242U;
			this.TextureValues = new List<SpeedTree.TextureValue>();
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00019CCC File Offset: 0x00017ECC
		public override void UnSerialize()
		{
			this.TextureValues.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			int num = 0;
			while (memoryStream.Position < memoryStream.Length)
			{
				binaryReader.BaseStream.Position = (long)num++;
				int num2 = binaryReader.ReadInt32();
				if (num2 == 18005 || num2 == 60006 || num2 == 70002)
				{
					SpeedTree.TextureValue textureValue = new SpeedTree.TextureValue();
					textureValue.DataOffset = binaryReader.BaseStream.Position;
					textureValue.DataLength = binaryReader.ReadInt32();
					textureValue.Value = new string(binaryReader.ReadChars(textureValue.DataLength));
					this.TextureValues.Add(textureValue);
				}
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0000330C File Offset: 0x0000150C
		public override byte[] Serialize()
		{
			return this.data;
		}

		// Token: 0x02000118 RID: 280
		public class TextureValue
		{
			// Token: 0x1700042F RID: 1071
			// (get) Token: 0x06000D44 RID: 3396 RVA: 0x0000941E File Offset: 0x0000761E
			// (set) Token: 0x06000D45 RID: 3397 RVA: 0x00009426 File Offset: 0x00007626
			public long DataOffset { get; set; }

			// Token: 0x17000430 RID: 1072
			// (get) Token: 0x06000D46 RID: 3398 RVA: 0x0000942F File Offset: 0x0000762F
			// (set) Token: 0x06000D47 RID: 3399 RVA: 0x00009437 File Offset: 0x00007637
			public int DataLength { get; set; }

			// Token: 0x17000431 RID: 1073
			// (get) Token: 0x06000D48 RID: 3400 RVA: 0x00009440 File Offset: 0x00007640
			// (set) Token: 0x06000D49 RID: 3401 RVA: 0x00009448 File Offset: 0x00007648
			public string Value { get; set; }
		}
	}
}
