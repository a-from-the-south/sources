using System;
using System.IO;
using Package.Sims2Files.RCOLResource;

namespace Package.Geometry
{
	// Token: 0x020000F1 RID: 241
	public class RotationQuaternion : IRCOLResource
	{
		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000C59 RID: 3161 RVA: 0x00008D15 File Offset: 0x00006F15
		public float X
		{
			get
			{
				return this.r_floatValue1;
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000C5A RID: 3162 RVA: 0x00008D1D File Offset: 0x00006F1D
		public float Y
		{
			get
			{
				return this.r_floatValue2;
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000C5B RID: 3163 RVA: 0x00008D25 File Offset: 0x00006F25
		public float Z
		{
			get
			{
				return this.r_floatValue3;
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000C5C RID: 3164 RVA: 0x00008D2D File Offset: 0x00006F2D
		public float W
		{
			get
			{
				return this.r_floatValue4;
			}
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x00008D35 File Offset: 0x00006F35
		public void UnSerialize(BinaryReader reader)
		{
			this.r_floatValue1 = reader.ReadSingle();
			this.r_floatValue2 = reader.ReadSingle();
			this.r_floatValue3 = reader.ReadSingle();
			this.r_floatValue4 = reader.ReadSingle();
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x000038FA File Offset: 0x00001AFA
		public byte[] Serialize()
		{
			throw new NotImplementedException();
		}

		// Token: 0x040005C8 RID: 1480
		private float r_floatValue1;

		// Token: 0x040005C9 RID: 1481
		private float r_floatValue2;

		// Token: 0x040005CA RID: 1482
		private float r_floatValue3;

		// Token: 0x040005CB RID: 1483
		private float r_floatValue4;
	}
}
