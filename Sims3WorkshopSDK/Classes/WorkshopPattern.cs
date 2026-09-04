using System;
using System.Drawing;
using System.Globalization;

namespace Sims3WorkshopSDK.Classes
{
	// Token: 0x02000042 RID: 66
	public class WorkshopPattern
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000131 RID: 305 RVA: 0x000027F3 File Offset: 0x000009F3
		// (set) Token: 0x06000132 RID: 306 RVA: 0x000027FB File Offset: 0x000009FB
		public string Description { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00002804 File Offset: 0x00000A04
		// (set) Token: 0x06000134 RID: 308 RVA: 0x0000280C File Offset: 0x00000A0C
		public string Category { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00002815 File Offset: 0x00000A15
		// (set) Token: 0x06000136 RID: 310 RVA: 0x0000281D File Offset: 0x00000A1D
		public string SurfaceType { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00002826 File Offset: 0x00000A26
		// (set) Token: 0x06000138 RID: 312 RVA: 0x0000282E File Offset: 0x00000A2E
		public bool UseCompression { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00002837 File Offset: 0x00000A37
		// (set) Token: 0x0600013A RID: 314 RVA: 0x0000283F File Offset: 0x00000A3F
		public Channel R { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00002848 File Offset: 0x00000A48
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00002850 File Offset: 0x00000A50
		public Channel G { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00002859 File Offset: 0x00000A59
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00002861 File Offset: 0x00000A61
		public Channel B { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600013F RID: 319 RVA: 0x0000286A File Offset: 0x00000A6A
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00002872 File Offset: 0x00000A72
		public Channel A { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000141 RID: 321 RVA: 0x0000287B File Offset: 0x00000A7B
		// (set) Token: 0x06000142 RID: 322 RVA: 0x00002883 File Offset: 0x00000A83
		public string Title { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000143 RID: 323 RVA: 0x0000288C File Offset: 0x00000A8C
		// (set) Token: 0x06000144 RID: 324 RVA: 0x00002894 File Offset: 0x00000A94
		public Color BgFill { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0000289D File Offset: 0x00000A9D
		// (set) Token: 0x06000146 RID: 326 RVA: 0x000028A5 File Offset: 0x00000AA5
		public Bitmap Mask { get; set; }

		// Token: 0x06000147 RID: 327 RVA: 0x00005880 File Offset: 0x00003A80
		public WorkshopPattern()
		{
			this.BgFill = Color.Black;
			this.R = new Channel(4278190080U, false, Color.White, true);
			this.G = new Channel(16711680U, false, Color.White, true);
			this.B = new Channel(65280U, false, Color.White, true);
			this.A = new Channel(255U, false, Color.White, true);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000058FC File Offset: 0x00003AFC
		public static string ColorAsString(Color c)
		{
			float num = (float)c.R / 255f;
			float num2 = (float)c.G / 255f;
			float num3 = (float)c.B / 255f;
			return num.ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + "," + num2.ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + "," + num3.ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",1";
		}
	}
}
