using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VisualHint.SmartPropertyGrid;

namespace ns13
{
	// Token: 0x02000019 RID: 25
	[ShowChildProperties(true)]
	[PropertyFeel("button")]
	internal sealed class Class19
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x000152F8 File Offset: 0x000134F8
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00002ED1 File Offset: 0x000010D1
		private Class129 Slot { get; set; }

		// Token: 0x060000A2 RID: 162 RVA: 0x00002EDC File Offset: 0x000010DC
		public Class19(Class129 entry)
		{
			this.Slot = entry;
			this.list_0 = new List<float[]>();
			this.list_0.AddRange(entry.Slot.Entries);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00015310 File Offset: 0x00013510
		public string ToString()
		{
			return this.Slot.Slot.Entries.Count + " positions";
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00015350 File Offset: 0x00013550
		public Class129 method_0()
		{
			return this.Slot;
		}

		// Token: 0x040000E9 RID: 233
		public List<float[]> list_0;

		// Token: 0x040000EA RID: 234
		[CompilerGenerated]
		private Class129 class129_0;
	}
}
