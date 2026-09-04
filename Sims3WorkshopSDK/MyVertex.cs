using System;

namespace Sims3WorkshopSDK
{
	// Token: 0x0200000F RID: 15
	public class MyVertex
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00002513 File Offset: 0x00000713
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000039B0 File Offset: 0x00001BB0
		public override bool Equals(object o)
		{
			if (o.GetType().Equals(typeof(MyVertex)))
			{
				MyVertex myVertex = (MyVertex)o;
				return this.posX.Equals(myVertex.posX) && this.posY.Equals(myVertex.posY) && this.posZ.Equals(myVertex.posZ) && this.norX.Equals(myVertex.norX) && this.norY.Equals(myVertex.norY) && this.norZ.Equals(myVertex.norZ) && this.vertexId.Equals(myVertex.vertexId) && this.b1.Equals(myVertex.b1) && this.b2.Equals(myVertex.b2) && this.b3.Equals(myVertex.b3) && this.b4.Equals(myVertex.b4) && this.w1.Equals(myVertex.w1) && this.w2.Equals(myVertex.w2) && this.w3.Equals(myVertex.w3) && this.w4.Equals(myVertex.w4) && this.ty.Equals(myVertex.ty) && this.tx.Equals(myVertex.tx) && this.tangent1.Equals(myVertex.tangent1) && this.tangent2.Equals(myVertex.tangent2) && this.tangent3.Equals(myVertex.tangent3) && this.tangent4.Equals(myVertex.tangent4);
			}
			return false;
		}

		// Token: 0x04000036 RID: 54
		public float posX;

		// Token: 0x04000037 RID: 55
		public float posY;

		// Token: 0x04000038 RID: 56
		public float posZ;

		// Token: 0x04000039 RID: 57
		public float posW;

		// Token: 0x0400003A RID: 58
		public float norX;

		// Token: 0x0400003B RID: 59
		public float norY;

		// Token: 0x0400003C RID: 60
		public float norZ;

		// Token: 0x0400003D RID: 61
		public float norW;

		// Token: 0x0400003E RID: 62
		public int vertexId;

		// Token: 0x0400003F RID: 63
		public byte b1;

		// Token: 0x04000040 RID: 64
		public byte b2;

		// Token: 0x04000041 RID: 65
		public byte b3;

		// Token: 0x04000042 RID: 66
		public byte b4;

		// Token: 0x04000043 RID: 67
		public byte ub1;

		// Token: 0x04000044 RID: 68
		public byte ub2;

		// Token: 0x04000045 RID: 69
		public byte ub3;

		// Token: 0x04000046 RID: 70
		public byte ub4;

		// Token: 0x04000047 RID: 71
		public float w1;

		// Token: 0x04000048 RID: 72
		public float w2;

		// Token: 0x04000049 RID: 73
		public float w3;

		// Token: 0x0400004A RID: 74
		public float w4;

		// Token: 0x0400004B RID: 75
		public float tx;

		// Token: 0x0400004C RID: 76
		public float ty;

		// Token: 0x0400004D RID: 77
		public float tx2;

		// Token: 0x0400004E RID: 78
		public float ty2;

		// Token: 0x0400004F RID: 79
		public float tangent1;

		// Token: 0x04000050 RID: 80
		public float tangent2;

		// Token: 0x04000051 RID: 81
		public float tangent3;

		// Token: 0x04000052 RID: 82
		public float tangent4;
	}
}
