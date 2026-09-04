using System;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200004D RID: 77
	public class Text : DBPFEntry
	{
		// Token: 0x060003F1 RID: 1009 RVA: 0x00004E5F File Offset: 0x0000305F
		public Text()
		{
			this.typeId = 4043265432U;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x000032EA File Offset: 0x000014EA
		public override void UnSerialize()
		{
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x000038FA File Offset: 0x00001AFA
		public override byte[] Serialize()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00004E72 File Offset: 0x00003072
		public override string ToString()
		{
			return "PNG | " + base.ToString();
		}
	}
}
