using System;
using System.ComponentModel;

namespace Sims3WorkshopSDK
{
	// Token: 0x0200000B RID: 11
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class StreamVector3
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000023B7 File Offset: 0x000005B7
		// (set) Token: 0x06000050 RID: 80 RVA: 0x000023BF File Offset: 0x000005BF
		[TypeConverter(typeof(SingleConverter))]
		public float X { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000051 RID: 81 RVA: 0x000023C8 File Offset: 0x000005C8
		// (set) Token: 0x06000052 RID: 82 RVA: 0x000023D0 File Offset: 0x000005D0
		[TypeConverter(typeof(SingleConverter))]
		public float Y { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000053 RID: 83 RVA: 0x000023D9 File Offset: 0x000005D9
		// (set) Token: 0x06000054 RID: 84 RVA: 0x000023E1 File Offset: 0x000005E1
		[TypeConverter(typeof(SingleConverter))]
		public float Z { get; set; }

		// Token: 0x06000055 RID: 85 RVA: 0x000023EA File Offset: 0x000005EA
		public StreamVector3(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000038C8 File Offset: 0x00001AC8
		public StreamVector3()
		{
			float z = 0f;
			float num = 0f;
			this.Z = z;
			float y = num;
			float x = 0f;
			this.Y = y;
			this.X = x;
		}
	}
}
