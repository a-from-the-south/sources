using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x0200002E RID: 46
	public interface IBone
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B5 RID: 181
		// (set) Token: 0x060000B6 RID: 182
		string Name { get; set; }

		// Token: 0x060000B7 RID: 183
		ITransform GetTransformation();

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000B8 RID: 184
		// (set) Token: 0x060000B9 RID: 185
		int ParentIndex { get; set; }
	}
}
