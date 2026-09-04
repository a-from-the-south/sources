using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x0200001A RID: 26
	public class ImportArgument
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000025B7 File Offset: 0x000007B7
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000025BF File Offset: 0x000007BF
		public string Name { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000025C8 File Offset: 0x000007C8
		// (set) Token: 0x0600008D RID: 141 RVA: 0x000025D0 File Offset: 0x000007D0
		public object Value { get; set; }
	}
}
