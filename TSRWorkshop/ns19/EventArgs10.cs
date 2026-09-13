using System;
using System.Security;

namespace ns19
{
	// Token: 0x020001D2 RID: 466
	internal sealed class EventArgs10 : EventArgs
	{
		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06001313 RID: 4883 RVA: 0x0000A011 File Offset: 0x00008211
		public SecurityException SecurityException
		{
			get
			{
				return this.securityException;
			}
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06001314 RID: 4884 RVA: 0x0000A019 File Offset: 0x00008219
		public string SecurityMessage
		{
			get
			{
				return this.securityMessage;
			}
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06001315 RID: 4885 RVA: 0x0000A021 File Offset: 0x00008221
		public bool CanContinue
		{
			get
			{
				return this.canContinue;
			}
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06001316 RID: 4886 RVA: 0x0000A029 File Offset: 0x00008229
		// (set) Token: 0x06001317 RID: 4887 RVA: 0x0000A031 File Offset: 0x00008231
		public bool TryToContinue
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

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06001318 RID: 4888 RVA: 0x0000A03A File Offset: 0x0000823A
		// (set) Token: 0x06001319 RID: 4889 RVA: 0x0000A042 File Offset: 0x00008242
		public bool ReportException
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x0000A04B File Offset: 0x0000824B
		public EventArgs10(SecurityException securityException)
		{
			this.securityException = securityException;
		}

		// Token: 0x0600131B RID: 4891 RVA: 0x0000A06C File Offset: 0x0000826C
		public EventArgs10(SecurityException securityException, bool canContinue) : this(securityException)
		{
			this.canContinue = canContinue;
		}

		// Token: 0x0600131C RID: 4892 RVA: 0x0000A07C File Offset: 0x0000827C
		public EventArgs10(string securityMessage, bool canContinue) : this(new SecurityException(securityMessage), canContinue)
		{
			this.securityMessage = securityMessage;
		}

		// Token: 0x04000D7D RID: 3453
		private SecurityException securityException;

		// Token: 0x04000D7E RID: 3454
		private string securityMessage = string.Empty;

		// Token: 0x04000D7F RID: 3455
		private bool bool_0;

		// Token: 0x04000D80 RID: 3456
		private bool bool_1;

		// Token: 0x04000D81 RID: 3457
		private bool canContinue = true;
	}
}
