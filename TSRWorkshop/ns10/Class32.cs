using System;
using System.IO;
using System.Runtime.CompilerServices;
using Sims3WorkshopSDK.Interfaces;

namespace ns10
{
	// Token: 0x02000033 RID: 51
	internal sealed class Class32 : ITransform
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00027B60 File Offset: 0x00025D60
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00003360 File Offset: 0x00001560
		public float[] Origin { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00027B78 File Offset: 0x00025D78
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x0000336B File Offset: 0x0000156B
		public float[] Scale { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00027B90 File Offset: 0x00025D90
		// (set) Token: 0x060001CA RID: 458 RVA: 0x00003376 File Offset: 0x00001576
		public float[] Quat { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00027BA8 File Offset: 0x00025DA8
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00003381 File Offset: 0x00001581
		public int Dimensions { get; set; }

		// Token: 0x060001CD RID: 461 RVA: 0x00027BC0 File Offset: 0x00025DC0
		public void method_0(BinaryReader binaryReader_0)
		{
			this.Sims3WorkshopSDK.Interfaces.ITransform.Dimensions = binaryReader_0.ReadInt32();
			this.Sims3WorkshopSDK.Interfaces.ITransform.Origin = new float[3];
			this.Sims3WorkshopSDK.Interfaces.ITransform.Origin[0] = binaryReader_0.ReadSingle();
			this.Sims3WorkshopSDK.Interfaces.ITransform.Origin[1] = binaryReader_0.ReadSingle();
			this.Sims3WorkshopSDK.Interfaces.ITransform.Origin[2] = binaryReader_0.ReadSingle();
			this.Sims3WorkshopSDK.Interfaces.ITransform.Quat = new float[12];
			for (int i = 0; i < 4; i++)
			{
				this.Sims3WorkshopSDK.Interfaces.ITransform.Quat[i] = binaryReader_0.ReadSingle();
			}
			this.Sims3WorkshopSDK.Interfaces.ITransform.Scale = new float[9];
			for (int j = 0; j < 9; j++)
			{
				this.Sims3WorkshopSDK.Interfaces.ITransform.Scale[j] = binaryReader_0.ReadSingle();
			}
		}

		// Token: 0x04000188 RID: 392
		[CompilerGenerated]
		private float[] float_0;

		// Token: 0x04000189 RID: 393
		[CompilerGenerated]
		private float[] float_1;

		// Token: 0x0400018A RID: 394
		[CompilerGenerated]
		private float[] float_2;

		// Token: 0x0400018B RID: 395
		[CompilerGenerated]
		private int int_0;
	}
}
