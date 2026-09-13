using System;
using System.Threading;

namespace ns1
{
	// Token: 0x020000C3 RID: 195
	internal sealed class Class89
	{
		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000838 RID: 2104 RVA: 0x00076BD8 File Offset: 0x00074DD8
		// (remove) Token: 0x06000839 RID: 2105 RVA: 0x00076C10 File Offset: 0x00074E10
		public event Class89.Delegate20 ProjectChanged
		{
			add
			{
				Class89.Delegate20 @delegate = this.delegate20_0;
				Class89.Delegate20 delegate2;
				do
				{
					delegate2 = @delegate;
					Class89.Delegate20 value2 = (Class89.Delegate20)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class89.Delegate20>(ref this.delegate20_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Class89.Delegate20 @delegate = this.delegate20_0;
				Class89.Delegate20 delegate2;
				do
				{
					delegate2 = @delegate;
					Class89.Delegate20 value2 = (Class89.Delegate20)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class89.Delegate20>(ref this.delegate20_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x00005C40 File Offset: 0x00003E40
		public void method_0(EventArgs eventArgs_0)
		{
			if (this.delegate20_0 != null)
			{
				this.delegate20_0(eventArgs_0);
			}
		}

		// Token: 0x0400069A RID: 1690
		private Class89.Delegate20 delegate20_0;

		// Token: 0x020000C4 RID: 196
		// (Invoke) Token: 0x0600083D RID: 2109
		public delegate void Delegate20(EventArgs e);
	}
}
