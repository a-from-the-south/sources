using System;
using System.ComponentModel;

namespace Sims3WorkshopSDK
{
	// Token: 0x0200000D RID: 13
	public class Float2
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000024E9 File Offset: 0x000006E9
		// (set) Token: 0x06000065 RID: 101 RVA: 0x000024F1 File Offset: 0x000006F1
		[TypeConverter(typeof(SingleConverter))]
		public float U { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000024FA File Offset: 0x000006FA
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00002502 File Offset: 0x00000702
		[TypeConverter(typeof(SingleConverter))]
		public float V { get; set; }
	}
}
