using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x0200002D RID: 45
	public interface ISkeleton
	{
		// Token: 0x060000B2 RID: 178
		IBone[] GetBones();

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B3 RID: 179
		// (set) Token: 0x060000B4 RID: 180
		string Name { get; set; }
	}
}
