using System;
using ns16;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns6
{
	// Token: 0x02000100 RID: 256
	internal interface Interface10
	{
		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000AF5 RID: 2805
		// (set) Token: 0x06000AF6 RID: 2806
		Enum18 CurrentDragMode { get; set; }

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000AF7 RID: 2807
		// (set) Token: 0x06000AF8 RID: 2808
		Matrix Transformation { get; set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000AF9 RID: 2809
		Matrix TransformationX { get; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000AFA RID: 2810
		Matrix TransformationY { get; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000AFB RID: 2811
		Matrix TransformationZ { get; }

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000AFC RID: 2812
		Matrix WorldTransformation { get; }

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000AFD RID: 2813
		Mesh XHandle { get; }

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000AFE RID: 2814
		Mesh YHandle { get; }

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000AFF RID: 2815
		Mesh ZHandle { get; }

		// Token: 0x06000B00 RID: 2816
		void imethod_0();

		// Token: 0x06000B01 RID: 2817
		void imethod_1();

		// Token: 0x06000B02 RID: 2818
		void imethod_2();

		// Token: 0x06000B03 RID: 2819
		void imethod_3(Device device_0, Matrix matrix_0);

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000B04 RID: 2820
		// (set) Token: 0x06000B05 RID: 2821
		bool Visible { get; set; }

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000B06 RID: 2822
		string Name { get; }
	}
}
