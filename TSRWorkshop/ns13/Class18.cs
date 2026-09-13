using System;
using System.Runtime.CompilerServices;
using ns2;
using VisualHint.SmartPropertyGrid;

namespace ns13
{
	// Token: 0x02000018 RID: 24
	[ShowChildProperties(true)]
	[PropertyFeel("button")]
	internal sealed class Class18
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600009C RID: 156 RVA: 0x000152E0 File Offset: 0x000134E0
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00002EB5 File Offset: 0x000010B5
		public Class111 ContainerEntry { get; set; }

		// Token: 0x0600009E RID: 158 RVA: 0x00002EC0 File Offset: 0x000010C0
		public Class18(Class111 entry)
		{
			this.ContainerEntry = entry;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000152C0 File Offset: 0x000134C0
		public string ToString()
		{
			return "transformation";
		}

		// Token: 0x040000E8 RID: 232
		[CompilerGenerated]
		private Class111 class111_0;
	}
}
