using System;

namespace ns15
{
	// Token: 0x020001CD RID: 461
	internal sealed class EventArgs8 : EventArgs
	{
		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x060012F7 RID: 4855 RVA: 0x00009F17 File Offset: 0x00008117
		public Exception FatalException
		{
			get
			{
				return this.fatalException;
			}
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x00009F1F File Offset: 0x0000811F
		internal EventArgs8(Exception fatalException)
		{
			this.fatalException = fatalException;
		}

		// Token: 0x04000D76 RID: 3446
		private Exception fatalException;
	}
}
