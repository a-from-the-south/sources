using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns10;
using ns13;
using ns16;
using ns2;
using ns3;
using ns6;
using ns8;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns5
{
	// Token: 0x02000111 RID: 273
	internal sealed class Class122
	{
		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x00097F18 File Offset: 0x00096118
		// (set) Token: 0x06000BE9 RID: 3049 RVA: 0x00006E32 File Offset: 0x00005032
		public bool Visible { get; set; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000BEA RID: 3050 RVA: 0x00097F30 File Offset: 0x00096130
		// (set) Token: 0x06000BEB RID: 3051 RVA: 0x00006E3D File Offset: 0x0000503D
		private VertexBuffer VBUF { get; set; }

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000BEC RID: 3052 RVA: 0x00097F48 File Offset: 0x00096148
		// (set) Token: 0x06000BED RID: 3053 RVA: 0x00006E48 File Offset: 0x00005048
		public Plane Plane { get; set; }

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x00097F60 File Offset: 0x00096160
		// (set) Token: 0x06000BEF RID: 3055 RVA: 0x00006E53 File Offset: 0x00005053
		public Plane Plane2 { get; set; }

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x00097F78 File Offset: 0x00096178
		// (set) Token: 0x06000BF1 RID: 3057 RVA: 0x00006E5E File Offset: 0x0000505E
		public Mesh XHandle { get; set; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x00097F90 File Offset: 0x00096190
		// (set) Token: 0x06000BF3 RID: 3059 RVA: 0x00006E69 File Offset: 0x00005069
		public Mesh YHandle { get; set; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x00097FA8 File Offset: 0x000961A8
		// (set) Token: 0x06000BF5 RID: 3061 RVA: 0x00006E74 File Offset: 0x00005074
		public Mesh ZHandle { get; set; }

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x00097FC0 File Offset: 0x000961C0
		// (set) Token: 0x06000BF7 RID: 3063 RVA: 0x00006E7F File Offset: 0x0000507F
		public string ReadableName { get; set; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x00097FD8 File Offset: 0x000961D8
		// (set) Token: 0x06000BF9 RID: 3065 RVA: 0x00006E8A File Offset: 0x0000508A
		public string HashedName { get; set; }

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000BFA RID: 3066 RVA: 0x00097FF0 File Offset: 0x000961F0
		// (set) Token: 0x06000BFB RID: 3067 RVA: 0x00006E95 File Offset: 0x00005095
		public Enum18 CurrentDragMode { get; set; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000BFC RID: 3068 RVA: 0x00098008 File Offset: 0x00096208
		// (set) Token: 0x06000BFD RID: 3069 RVA: 0x00098020 File Offset: 0x00096220
		public unsafe Matrix Transformation
		{
			get
			{
				return this.matrix_0;
			}
			set
			{
				Matrix right = Matrix.Identity;
				if (this.CurrentDragMode == Enum18.const_0)
				{
					right = Matrix.Translation(new Vector3(-this.boundingBox_0.Maximum.X - 0.2f + 0.07f, 0f, 0f));
				}
				else if (this.CurrentDragMode == Enum18.const_1)
				{
					right = Matrix.Translation(new Vector3(0f, -this.boundingBox_0.Maximum.Y - 0.2f + 0.07f, 0f));
				}
				else if (this.CurrentDragMode == Enum18.const_2)
				{
					right = Matrix.Translation(new Vector3(0f, 0f, -this.boundingBox_0.Maximum.Z - 0.2f + 0.07f));
				}
				Matrix matrix = value * right;
				float num = matrix.M41 - this.matrix_0.M41;
				float num2 = matrix.M42 - this.matrix_0.M42;
				float num3 = matrix.M43 - this.matrix_0.M43;
				this.matrix_0 = matrix;
				foreach (Class102 @class in Class132.smethod_0().Renderables)
				{
					if (@class is Class105)
					{
						List<short> list = new List<short>();
						foreach (Interface9 @interface in @class.Objects.Values)
						{
							Class121 class2 = (Class121)@interface;
							DataStream dataStream = class2.VertexBuffer.Lock(0, 0, LockFlags.None);
							Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
							foreach (Class102.Class107 class3 in class2.CurrentSelectionIndex)
							{
								if (!list.Contains(class3.short_0))
								{
									Class112.Struct7 @struct = ptr[class3.short_0];
									@struct.position.X = @struct.position.X + num;
									@struct.position.Y = @struct.position.Y + num2;
									@struct.position.Z = @struct.position.Z + num3;
									ptr[class3.short_0] = @struct;
									list.Add(class3.short_0);
								}
								if (!list.Contains(class3.short_1))
								{
									Class112.Struct7 struct2 = ptr[class3.short_1];
									struct2.position.X = struct2.position.X + num;
									struct2.position.Y = struct2.position.Y + num2;
									struct2.position.Z = struct2.position.Z + num3;
									ptr[class3.short_1] = struct2;
									list.Add(class3.short_1);
								}
								if (!list.Contains(class3.short_2))
								{
									Class112.Struct7 struct3 = ptr[class3.short_2];
									struct3.position.X = struct3.position.X + num;
									struct3.position.Y = struct3.position.Y + num2;
									struct3.position.Z = struct3.position.Z + num3;
									ptr[class3.short_2] = struct3;
									list.Add(class3.short_2);
								}
							}
							class2.VertexBuffer.Unlock();
						}
						list.Clear();
					}
				}
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000BFE RID: 3070 RVA: 0x00098428 File Offset: 0x00096628
		public Matrix TransformationX
		{
			get
			{
				return this.matrix_1 * this.matrix_0;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000BFF RID: 3071 RVA: 0x0009844C File Offset: 0x0009664C
		public Matrix TransformationY
		{
			get
			{
				return this.matrix_2 * this.matrix_0;
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x00098470 File Offset: 0x00096670
		public Matrix TransformationZ
		{
			get
			{
				return this.matrix_3 * this.matrix_0;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000C01 RID: 3073 RVA: 0x00098494 File Offset: 0x00096694
		public Matrix WorldTransformation
		{
			get
			{
				return this.Transformation;
			}
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x000984AC File Offset: 0x000966AC
		public Class122(Device device)
		{
			Vector3 point = new Vector3(-100f, 0f, -100f);
			Vector3 vector = new Vector3(100f, 0f, -100f);
			Vector3 point2 = new Vector3(100f, 0f, 100f);
			Vector3 point3 = new Vector3(-100f, 0f, 100f);
			this.Plane = new Plane(point, vector, point3);
			this.Plane2 = new Plane(vector, point2, point3);
			this.color_0 = Color.White;
			this.VBUF = new VertexBuffer(device, 6 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			this.XHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.YHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.ZHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.boundingBox_0 = default(BoundingBox);
			this.method_2();
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000C03 RID: 3075 RVA: 0x000985CC File Offset: 0x000967CC
		public string Name
		{
			get
			{
				return "move";
			}
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x00002A71 File Offset: 0x00000C71
		public void method_0()
		{
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x00006EA0 File Offset: 0x000050A0
		public void method_1(BoundingBox boundingBox_1)
		{
			this.boundingBox_0 = boundingBox_1;
			this.method_2();
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x000985E4 File Offset: 0x000967E4
		public void method_2()
		{
			this.matrix_0 = Matrix.Identity;
			Vector3 zero = Vector3.Zero;
			Class112.Struct7[] data = new Class112.Struct7[]
			{
				new Class112.Struct7(zero, 1f, Color.Red.ToArgb()),
				new Class112.Struct7(new Vector3(this.boundingBox_0.Maximum.X + 0.2f, 0f, 0f), 2f, Color.Red.ToArgb()),
				new Class112.Struct7(zero, 1f, Color.Green.ToArgb()),
				new Class112.Struct7(new Vector3(0f, this.boundingBox_0.Maximum.Y + 0.2f, 0f), 2f, Color.Green.ToArgb()),
				new Class112.Struct7(zero, 1f, Color.Blue.ToArgb()),
				new Class112.Struct7(new Vector3(0f, 0f, this.boundingBox_0.Maximum.Z + 0.2f), 2f, Color.Blue.ToArgb())
			};
			DataStream dataStream = this.VBUF.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct7>(data, 0, 6);
			this.VBUF.Unlock();
			this.matrix_1 = Matrix.RotationY(1.5707964f) * Matrix.Translation(new Vector3(this.boundingBox_0.Maximum.X + 0.2f, 0f, 0f));
			this.matrix_2 = Matrix.RotationX(-1.5707964f) * Matrix.Translation(new Vector3(0f, this.boundingBox_0.Maximum.Y + 0.2f, 0f));
			this.matrix_3 = Matrix.Translation(new Vector3(0f, 0f, this.boundingBox_0.Maximum.Z + 0.2f));
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x00098828 File Offset: 0x00096A28
		public void method_3(Device device_0, Matrix matrix_4)
		{
			device_0.SetTexture(0, null);
			device_0.SetTexture(1, null);
			device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
			device_0.SetTransform(TransformState.World, this.matrix_0 * matrix_4);
			Class140.smethod_0().method_9(RenderState.Lighting, false);
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
			Class140.smethod_0().method_9(RenderState.ZEnable, true);
			Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
			device_0.SetStreamSource(0, this.VBUF, 0, Class112.Struct7.SizeInBytes);
			device_0.DrawPrimitives(PrimitiveType.LineList, 0, 3);
			Class140.smethod_0().method_22("g_ambient", new Vector4(1f, 1f, 0f, 0.6f));
			Class140.smethod_0().method_40("Slot");
			int num = Class140.smethod_0().method_36();
			for (int i = 0; i < num; i++)
			{
				Class140.smethod_0().method_38(i);
				Class140.smethod_0().method_32(this.matrix_1 * this.matrix_0 * matrix_4, Class132.smethod_0().ViewMatrix);
				this.XHandle.DrawSubset(0);
				Class140.smethod_0().method_32(this.matrix_2 * this.matrix_0 * matrix_4, Class132.smethod_0().ViewMatrix);
				this.YHandle.DrawSubset(0);
				Class140.smethod_0().method_32(this.matrix_3 * this.matrix_0 * matrix_4, Class132.smethod_0().ViewMatrix);
				this.ZHandle.DrawSubset(0);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
			Class140.smethod_0().method_32(matrix_4, Class132.smethod_0().ViewMatrix);
			Class140.smethod_0().method_10();
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x00006EB1 File Offset: 0x000050B1
		public void method_4(bool bool_1)
		{
			if (bool_1)
			{
				this.XHandle.Dispose();
				this.YHandle.Dispose();
				this.ZHandle.Dispose();
				this.VBUF.Dispose();
			}
		}

		// Token: 0x04000952 RID: 2386
		private Color color_0;

		// Token: 0x04000953 RID: 2387
		private Matrix matrix_0;

		// Token: 0x04000954 RID: 2388
		private Matrix matrix_1;

		// Token: 0x04000955 RID: 2389
		private Matrix matrix_2;

		// Token: 0x04000956 RID: 2390
		private Matrix matrix_3;

		// Token: 0x04000957 RID: 2391
		private BoundingBox boundingBox_0;

		// Token: 0x04000958 RID: 2392
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000959 RID: 2393
		[CompilerGenerated]
		private VertexBuffer vertexBuffer_0;

		// Token: 0x0400095A RID: 2394
		[CompilerGenerated]
		private Plane plane_0;

		// Token: 0x0400095B RID: 2395
		[CompilerGenerated]
		private Plane plane_1;

		// Token: 0x0400095C RID: 2396
		[CompilerGenerated]
		private Mesh mesh_0;

		// Token: 0x0400095D RID: 2397
		[CompilerGenerated]
		private Mesh mesh_1;

		// Token: 0x0400095E RID: 2398
		[CompilerGenerated]
		private Mesh mesh_2;

		// Token: 0x0400095F RID: 2399
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000960 RID: 2400
		[CompilerGenerated]
		private string string_1;

		// Token: 0x04000961 RID: 2401
		[CompilerGenerated]
		private Enum18 enum18_0;
	}
}
