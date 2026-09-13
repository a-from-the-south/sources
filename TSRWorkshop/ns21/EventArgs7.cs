using System;
using ns17;

namespace ns21
{
	// Token: 0x0200016D RID: 365
	internal sealed class EventArgs7 : EventArgs
	{
		// Token: 0x06001166 RID: 4454 RVA: 0x000093E7 File Offset: 0x000075E7
		public EventArgs7(Class161 tip, object instance)
		{
			this.tip = tip;
			this.instance = instance;
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06001167 RID: 4455 RVA: 0x000BBF70 File Offset: 0x000BA170
		public Class161 Tip
		{
			get
			{
				return this.tip;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06001168 RID: 4456 RVA: 0x000BBF88 File Offset: 0x000BA188
		public object Instance
		{
			get
			{
				return this.instance;
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06001169 RID: 4457 RVA: 0x000BBFA0 File Offset: 0x000BA1A0
		// (set) Token: 0x0600116A RID: 4458 RVA: 0x000093FF File Offset: 0x000075FF
		public bool Cancel
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		// Token: 0x04000BDB RID: 3035
		private Class161 tip;

		// Token: 0x04000BDC RID: 3036
		private object instance;

		// Token: 0x04000BDD RID: 3037
		private bool bool_0;
	}
}
