using System;
using System.IO;
using System.Text;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000019 RID: 25
	public class CATA : DBPFEntry
	{
		// Token: 0x06000198 RID: 408 RVA: 0x00003BF6 File Offset: 0x00001DF6
		public CATA()
		{
			this.typeId = 68746794U;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000131A4 File Offset: 0x000113A4
		public override void UnSerialize()
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			byte b = binaryReader.ReadByte();
			byte[] array = new byte[(int)b];
			for (int i = 0; i < (int)b; i += 2)
			{
				array[i + 1] = binaryReader.ReadByte();
				array[i] = binaryReader.ReadByte();
			}
			if (b > 0)
			{
				new UnicodeEncoding().GetString(array);
			}
			b = binaryReader.ReadByte();
			array = new byte[(int)b];
			for (int j = 0; j < (int)b; j += 2)
			{
				array[j + 1] = binaryReader.ReadByte();
				array[j] = binaryReader.ReadByte();
			}
			if (b > 0)
			{
				new UnicodeEncoding().GetString(array);
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000038FA File Offset: 0x00001AFA
		public override byte[] Serialize()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00003C09 File Offset: 0x00001E09
		public override string ToString()
		{
			return "CATA | " + base.ToString();
		}
	}
}
