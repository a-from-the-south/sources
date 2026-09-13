using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns13;
using VisualHint.SmartPropertyGrid;

namespace ns9
{
	// Token: 0x02000023 RID: 35
	[PropertyFeel("button")]
	[ShowChildProperties(true)]
	internal sealed class Class25
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600011D RID: 285 RVA: 0x0001C8F0 File Offset: 0x0001AAF0
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00003127 File Offset: 0x00001327
		private Class129 Slot { get; set; }

		// Token: 0x0600011F RID: 287 RVA: 0x00003132 File Offset: 0x00001332
		public Class25(Class129 entry)
		{
			this.Slot = entry;
			this.list_0 = new List<float[]>();
			this.list_0.AddRange(entry.Slot.Entries);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0001C908 File Offset: 0x0001AB08
		public string ToString()
		{
			return this.Slot.Slot.Entries.Count + " positions";
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0001C948 File Offset: 0x0001AB48
		public Class129 method_0()
		{
			return this.Slot;
		}

		// Token: 0x0400011C RID: 284
		public List<float[]> list_0;

		// Token: 0x0400011D RID: 285
		[CompilerGenerated]
		private Class129 class129_0;
	}
}
