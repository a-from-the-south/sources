using System;
using System.Runtime.CompilerServices;

namespace ns3
{
	// Token: 0x02000017 RID: 23
	internal sealed class Class17
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000098 RID: 152 RVA: 0x000152A8 File Offset: 0x000134A8
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00002E6B File Offset: 0x0000106B
		public uint BoneHash { get; set; }

		// Token: 0x0600009A RID: 154 RVA: 0x00002E76 File Offset: 0x00001076
		public Class17(uint boneHash, float tx, float ty, float tz, float rx, float ry, float rz)
		{
			this.BoneHash = boneHash;
			this.tx = tx;
			this.ty = ty;
			this.tz = tz;
			this.rx = rx;
			this.ry = ry;
			this.rz = rz;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000152C0 File Offset: 0x000134C0
		public string ToString()
		{
			return "transformation";
		}

		// Token: 0x040000E1 RID: 225
		public float tx;

		// Token: 0x040000E2 RID: 226
		public float ty;

		// Token: 0x040000E3 RID: 227
		public float tz;

		// Token: 0x040000E4 RID: 228
		public float rx;

		// Token: 0x040000E5 RID: 229
		public float ry;

		// Token: 0x040000E6 RID: 230
		public float rz;

		// Token: 0x040000E7 RID: 231
		[CompilerGenerated]
		private uint uint_0;
	}
}
