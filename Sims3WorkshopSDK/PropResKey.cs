using System;

namespace Sims3WorkshopSDK
{
	// Token: 0x02000009 RID: 9
	public class PropResKey : ResKey
	{
		// Token: 0x0600004A RID: 74 RVA: 0x0000239D File Offset: 0x0000059D
		public PropResKey() : base(DBPFType.TXTC)
		{
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002345 File Offset: 0x00000545
		public PropResKey(string key) : base(key)
		{
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002382 File Offset: 0x00000582
		public PropResKey(string key, GameVersion game) : base(key, game)
		{
		}
	}
}
