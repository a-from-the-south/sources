using System;
using System.Runtime.CompilerServices;
using SlimDX.Direct3D9;

namespace ns8
{
	// Token: 0x02000126 RID: 294
	internal sealed class EventArgs3 : EventArgs
	{
		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000D6C RID: 3436 RVA: 0x000A8438 File Offset: 0x000A6638
		// (set) Token: 0x06000D6D RID: 3437 RVA: 0x0000774A File Offset: 0x0000594A
		public Device Device { get; private set; }

		// Token: 0x06000D6E RID: 3438 RVA: 0x00007755 File Offset: 0x00005955
		public EventArgs3(Device device)
		{
			this.Device = device;
		}

		// Token: 0x04000A1F RID: 2591
		[CompilerGenerated]
		private Device device_0;
	}
}
