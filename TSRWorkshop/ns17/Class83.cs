using System;
using System.Collections;
using ns3;
using Sims3Workshop.Data;

namespace ns17
{
	// Token: 0x020000BD RID: 189
	internal sealed class Class83 : PropertyBag
	{
		// Token: 0x060007F1 RID: 2033 RVA: 0x00005B00 File Offset: 0x00003D00
		public Class83()
		{
			this.hashtable_0 = new Hashtable();
		}

		// Token: 0x17000154 RID: 340
		public object this[string string_1]
		{
			get
			{
				return this.hashtable_0[string_1];
			}
			set
			{
				this.hashtable_0[string_1] = value;
			}
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00005B26 File Offset: 0x00003D26
		protected override void vmethod_0(EventArgs2 eventArgs2_0)
		{
			eventArgs2_0.Value = this.hashtable_0[eventArgs2_0.Property.Name];
			base.vmethod_0(eventArgs2_0);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00005B4D File Offset: 0x00003D4D
		protected override void vmethod_1(EventArgs2 eventArgs2_0)
		{
			this.hashtable_0[eventArgs2_0.Property.Name] = eventArgs2_0.Value;
			base.vmethod_1(eventArgs2_0);
		}

		// Token: 0x0400065A RID: 1626
		private Hashtable hashtable_0;
	}
}
