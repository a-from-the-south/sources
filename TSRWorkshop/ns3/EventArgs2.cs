using System;
using ns11;

namespace ns3
{
	// Token: 0x020000B8 RID: 184
	internal sealed class EventArgs2 : EventArgs
	{
		// Token: 0x060007AB RID: 1963 RVA: 0x00005976 File Offset: 0x00003B76
		public EventArgs2(Class82 property, object val)
		{
			this.property = property;
			this.val = val;
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060007AC RID: 1964 RVA: 0x00071F80 File Offset: 0x00070180
		public Class82 Property
		{
			get
			{
				return this.property;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x00071F98 File Offset: 0x00070198
		// (set) Token: 0x060007AE RID: 1966 RVA: 0x0000598E File Offset: 0x00003B8E
		public object Value
		{
			get
			{
				return this.val;
			}
			set
			{
				this.val = value;
			}
		}

		// Token: 0x04000651 RID: 1617
		private Class82 property;

		// Token: 0x04000652 RID: 1618
		private object val;
	}
}
