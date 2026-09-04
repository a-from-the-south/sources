using System;
using System.Drawing;

namespace Sims3WorkshopSDK.Classes
{
	// Token: 0x02000043 RID: 67
	public class Channel
	{
		// Token: 0x06000149 RID: 329 RVA: 0x000028AE File Offset: 0x00000AAE
		public Channel(uint channel, bool enabled, Bitmap background, bool blend)
		{
			this.Enabled = enabled;
			this.ChannelMask = channel;
			this.Background = background;
			this.Blending = blend;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x000028D3 File Offset: 0x00000AD3
		public Channel(uint channel, bool enabled, Color color, bool blend)
		{
			this.Enabled = enabled;
			this.ChannelMask = channel;
			this.Color = color;
			this.Blending = blend;
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600014B RID: 331 RVA: 0x000028F8 File Offset: 0x00000AF8
		// (set) Token: 0x0600014C RID: 332 RVA: 0x00002900 File Offset: 0x00000B00
		public uint ChannelMask { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00002909 File Offset: 0x00000B09
		// (set) Token: 0x0600014E RID: 334 RVA: 0x00002911 File Offset: 0x00000B11
		public Color Color { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600014F RID: 335 RVA: 0x0000291A File Offset: 0x00000B1A
		// (set) Token: 0x06000150 RID: 336 RVA: 0x00002922 File Offset: 0x00000B22
		public Bitmap Background { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000151 RID: 337 RVA: 0x0000292B File Offset: 0x00000B2B
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00002933 File Offset: 0x00000B33
		public bool Blending { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000153 RID: 339 RVA: 0x0000293C File Offset: 0x00000B3C
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00002944 File Offset: 0x00000B44
		public bool Enabled { get; set; }
	}
}
