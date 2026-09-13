using System;
using System.Collections.Generic;
using ns8;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns13
{
	// Token: 0x020000FE RID: 254
	internal interface Interface9
	{
		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000ADC RID: 2780
		// (set) Token: 0x06000ADD RID: 2781
		bool Visible { get; set; }

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000ADE RID: 2782
		// (set) Token: 0x06000ADF RID: 2783
		bool Selected { get; set; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000AE0 RID: 2784
		// (set) Token: 0x06000AE1 RID: 2785
		Lod LOD { get; set; }

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000AE2 RID: 2786
		MATD Matd { get; }

		// Token: 0x06000AE3 RID: 2787
		bool imethod_0(Device device_0, Matrix matrix_0, Vector3 vector3_0, Vector3 vector3_1, out float float_0);

		// Token: 0x06000AE4 RID: 2788
		void imethod_1(bool bool_0);

		// Token: 0x06000AE5 RID: 2789
		void imethod_2(Device device_0, MATD matd_0);

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000AE6 RID: 2790
		MATD DefaultMaterial { get; }

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000AE7 RID: 2791
		// (set) Token: 0x06000AE8 RID: 2792
		object Tag { get; set; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000AE9 RID: 2793
		VertexBuffer VertexBuffer { get; }

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000AEA RID: 2794
		VertexBuffer VertexBufferTransformed { get; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000AEB RID: 2795
		IndexBuffer IndexBuffer { get; }

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000AEC RID: 2796
		IndexBuffer SelectedIndexBuffer { get; }

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000AED RID: 2797
		List<Class102.Class107> CurrentSelectionIndex { get; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000AEE RID: 2798
		int FaceCount { get; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000AEF RID: 2799
		int VertexCount { get; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000AF0 RID: 2800
		int IBUFOffset { get; }

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000AF1 RID: 2801
		int VBUFOffset { get; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000AF2 RID: 2802
		Matrix[] Palette { get; }

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000AF3 RID: 2803
		Matrix[] ColorPalette { get; }

		// Token: 0x06000AF4 RID: 2804
		void imethod_3();
	}
}
