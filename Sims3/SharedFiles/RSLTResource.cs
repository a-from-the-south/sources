using System;
using System.Collections.Generic;
using Package.SharedFiles.InternalRCOL;

namespace Package.SharedFiles
{
	// Token: 0x020000AF RID: 175
	public class RSLTResource : RCOL
	{
		// Token: 0x060008E0 RID: 2272 RVA: 0x00007109 File Offset: 0x00005309
		public RSLTResource() : base(-754694879)
		{
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00007116 File Offset: 0x00005316
		public static RSLTResource Create()
		{
			return new RSLTResource
			{
				Version = 3,
				DataType = 1,
				internalIndex = new List<RCOLFileEntry>(),
				externalIndex = new List<RCOLFileEntry>()
			};
		}
	}
}
