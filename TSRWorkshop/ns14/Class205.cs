using System;

namespace ns14
{
	// Token: 0x020001CC RID: 460
	internal sealed class Class205
	{
		// Token: 0x060012F2 RID: 4850 RVA: 0x00009ECC File Offset: 0x000080CC
		public Class205(object o, bool firstLevel) : this(o, (o != null) ? o.GetType() : null, firstLevel)
		{
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x00009EE2 File Offset: 0x000080E2
		public Class205(object o, Type t, bool firstLevel)
		{
			this.o = o;
			this.t = t;
			this.firstLevel = firstLevel;
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x060012F4 RID: 4852 RVA: 0x00009EFF File Offset: 0x000080FF
		public bool FirstLevel
		{
			get
			{
				return this.firstLevel;
			}
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x00009F07 File Offset: 0x00008107
		public object method_0()
		{
			return this.o;
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x00009F0F File Offset: 0x0000810F
		public Type method_1()
		{
			return this.t;
		}

		// Token: 0x04000D73 RID: 3443
		private readonly Type t;

		// Token: 0x04000D74 RID: 3444
		private readonly object o;

		// Token: 0x04000D75 RID: 3445
		private readonly bool firstLevel;
	}
}
