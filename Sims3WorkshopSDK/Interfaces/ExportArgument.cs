using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000024 RID: 36
	public class ExportArgument
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000025D9 File Offset: 0x000007D9
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x000025E1 File Offset: 0x000007E1
		public string Name { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x000025EA File Offset: 0x000007EA
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x000025F2 File Offset: 0x000007F2
		public object Value { get; set; }
	}
}
