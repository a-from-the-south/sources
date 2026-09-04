using System;

namespace Sims3WorkshopSDK.Classes
{
	// Token: 0x02000041 RID: 65
	public class PositionNormalTexturedVertex
	{
		// Token: 0x06000130 RID: 304 RVA: 0x0000581C File Offset: 0x00003A1C
		public PositionNormalTexturedVertex(float vx, float vy, float vz, float nx, float ny, float nz, float uvx, float uvy)
		{
			this.vertexX = vx;
			this.vertexY = vy;
			this.vertexZ = vz;
			this.normalX = nx;
			this.normalY = ny;
			this.normalZ = nz;
			this.uvX = uvx;
			this.uvY = uvy;
			this.boneWeight = new float[]
			{
				0f,
				0f,
				0f,
				1f
			};
		}

		// Token: 0x0400014B RID: 331
		public uint boneIndex;

		// Token: 0x0400014C RID: 332
		public float vertexX;

		// Token: 0x0400014D RID: 333
		public float vertexY;

		// Token: 0x0400014E RID: 334
		public float vertexZ;

		// Token: 0x0400014F RID: 335
		public float normalX;

		// Token: 0x04000150 RID: 336
		public float normalZ;

		// Token: 0x04000151 RID: 337
		public float normalY;

		// Token: 0x04000152 RID: 338
		public float uvX;

		// Token: 0x04000153 RID: 339
		public float uvY;

		// Token: 0x04000154 RID: 340
		public float[] boneWeight;
	}
}
