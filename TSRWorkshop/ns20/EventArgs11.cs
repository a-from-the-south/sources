using System;
using ns3;

namespace ns20
{
	// Token: 0x020001D4 RID: 468
	internal sealed class EventArgs11 : EventArgs
	{
		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06001321 RID: 4897 RVA: 0x0000A092 File Offset: 0x00008292
		public Enum34 Step
		{
			get
			{
				return this.step;
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06001322 RID: 4898 RVA: 0x0000A09A File Offset: 0x0000829A
		public bool Failed
		{
			get
			{
				return this.bool_0;
			}
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06001323 RID: 4899 RVA: 0x0000A0A2 File Offset: 0x000082A2
		public string ErrorMessage
		{
			get
			{
				return this.errorMessage;
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06001324 RID: 4900 RVA: 0x0000A0AA File Offset: 0x000082AA
		public string ReportID
		{
			get
			{
				return this.reportId;
			}
		}

		// Token: 0x06001325 RID: 4901 RVA: 0x0000A0B2 File Offset: 0x000082B2
		internal EventArgs11(Enum34 step) : this(step, string.Empty)
		{
		}

		// Token: 0x06001326 RID: 4902 RVA: 0x0000A0C0 File Offset: 0x000082C0
		internal EventArgs11(Enum34 step, string errorMessage) : this(step, errorMessage, string.Empty)
		{
		}

		// Token: 0x06001327 RID: 4903 RVA: 0x000C6344 File Offset: 0x000C4544
		internal EventArgs11(Enum34 step, string errorMessage, string reportId)
		{
			this.step = step;
			this.bool_0 = (errorMessage != null && errorMessage.Length > 0);
			this.errorMessage = errorMessage;
			this.reportId = reportId;
		}

		// Token: 0x04000D82 RID: 3458
		private Enum34 step;

		// Token: 0x04000D83 RID: 3459
		private readonly bool bool_0;

		// Token: 0x04000D84 RID: 3460
		private readonly string errorMessage = string.Empty;

		// Token: 0x04000D85 RID: 3461
		private readonly string reportId = string.Empty;
	}
}
