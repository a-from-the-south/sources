using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x0200002F RID: 47
	public interface ITransform
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000BA RID: 186
		// (set) Token: 0x060000BB RID: 187
		float[] Origin { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000BC RID: 188
		// (set) Token: 0x060000BD RID: 189
		float[] Scale { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000BE RID: 190
		// (set) Token: 0x060000BF RID: 191
		float[] Quat { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000C0 RID: 192
		// (set) Token: 0x060000C1 RID: 193
		int Dimensions { get; set; }
	}
}
