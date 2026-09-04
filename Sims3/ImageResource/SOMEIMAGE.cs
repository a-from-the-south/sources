using System;
using Sims3WorkshopSDK;

namespace Package.ImageResource
{
	// Token: 0x020000E9 RID: 233
	public class SOMEIMAGE : DBPFEntry
	{
		// Token: 0x06000BFD RID: 3069 RVA: 0x00008A7E File Offset: 0x00006C7E
		public SOMEIMAGE()
		{
			this.typeId = 1612179606U;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x000032EA File Offset: 0x000014EA
		public override void UnSerialize()
		{
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0000330C File Offset: 0x0000150C
		public override byte[] Serialize()
		{
			return this.data;
		}
	}
}
