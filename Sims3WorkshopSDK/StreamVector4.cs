using System;
using System.ComponentModel;

namespace Sims3WorkshopSDK
{
	// Token: 0x0200000C RID: 12
	public class StreamVector4
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002407 File Offset: 0x00000607
		// (set) Token: 0x06000058 RID: 88 RVA: 0x0000240F File Offset: 0x0000060F
		[TypeConverter(typeof(SingleConverter))]
		public float X { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002418 File Offset: 0x00000618
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002420 File Offset: 0x00000620
		[TypeConverter(typeof(SingleConverter))]
		public float Y { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002429 File Offset: 0x00000629
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002431 File Offset: 0x00000631
		[TypeConverter(typeof(SingleConverter))]
		public float Z { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600005D RID: 93 RVA: 0x0000243A File Offset: 0x0000063A
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002442 File Offset: 0x00000642
		[TypeConverter(typeof(SingleConverter))]
		public float W { get; set; }

		// Token: 0x0600005F RID: 95 RVA: 0x0000244B File Offset: 0x0000064B
		public StreamVector4(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003900 File Offset: 0x00001B00
		public StreamVector4()
		{
			float w = 0f;
			float num = 0f;
			this.W = w;
			float z = num;
			float num2 = 0f;
			this.Z = z;
			float y = num2;
			float x = 0f;
			this.Y = y;
			this.X = x;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002470 File Offset: 0x00000670
		public void Normalize()
		{
			this.X /= this.W;
			this.Y /= this.W;
			this.Z /= this.W;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000024AB File Offset: 0x000006AB
		public void Normalize(float W)
		{
			this.X *= 1f / W;
			this.Y *= 1f / W;
			this.Z *= 1f / W;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003948 File Offset: 0x00001B48
		public override bool Equals(object obj)
		{
			return obj is StreamVector4 && ((obj as StreamVector4).X == this.X && (obj as StreamVector4).Y == this.Y && (obj as StreamVector4).Z == this.Z) && (obj as StreamVector4).W == this.W;
		}
	}
}
