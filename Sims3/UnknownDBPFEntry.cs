using System;
using Sims3WorkshopSDK;

namespace Package
{
	// Token: 0x02000007 RID: 7
	public class UnknownDBPFEntry : DBPFEntry
	{
		// Token: 0x06000078 RID: 120 RVA: 0x000032FA File Offset: 0x000014FA
		public UnknownDBPFEntry(uint typeId)
		{
			this.typeId = typeId;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000032EA File Offset: 0x000014EA
		public override void UnSerialize()
		{
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000330C File Offset: 0x0000150C
		public override byte[] Serialize()
		{
			return this.data;
		}
	}
}
