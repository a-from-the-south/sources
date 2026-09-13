using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns10;
using ns15;
using ns16;
using ns3;
using ns6;
using ns8;
using Package.Sims3Files.InternalRCOL;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns17
{
	// Token: 0x02000114 RID: 276
	internal sealed class Class124 : Interface10
	{
		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000C53 RID: 3155 RVA: 0x0009D4EC File Offset: 0x0009B6EC
		// (set) Token: 0x06000C54 RID: 3156 RVA: 0x00007072 File Offset: 0x00005272
		public SKIN.SKINEntry Entry { get; set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000C55 RID: 3157 RVA: 0x0009D504 File Offset: 0x0009B704
		// (set) Token: 0x06000C56 RID: 3158 RVA: 0x0000707D File Offset: 0x0000527D
		public bool Visible { get; set; }

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000C57 RID: 3159 RVA: 0x0009D51C File Offset: 0x0009B71C
		// (set) Token: 0x06000C58 RID: 3160 RVA: 0x00007088 File Offset: 0x00005288
		private VertexBuffer VBUF { get; set; }

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000C59 RID: 3161 RVA: 0x0009D534 File Offset: 0x0009B734
		// (set) Token: 0x06000C5A RID: 3162 RVA: 0x00007093 File Offset: 0x00005293
		public Plane Plane { get; set; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000C5B RID: 3163 RVA: 0x0009D54C File Offset: 0x0009B74C
		// (set) Token: 0x06000C5C RID: 3164 RVA: 0x0000709E File Offset: 0x0000529E
		public Plane Plane2 { get; set; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000C5D RID: 3165 RVA: 0x0009D564 File Offset: 0x0009B764
		// (set) Token: 0x06000C5E RID: 3166 RVA: 0x000070A9 File Offset: 0x000052A9
		public Mesh XHandle { get; set; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000C5F RID: 3167 RVA: 0x0009D57C File Offset: 0x0009B77C
		// (set) Token: 0x06000C60 RID: 3168 RVA: 0x000070B4 File Offset: 0x000052B4
		public Mesh YHandle { get; set; }

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000C61 RID: 3169 RVA: 0x0009D594 File Offset: 0x0009B794
		// (set) Token: 0x06000C62 RID: 3170 RVA: 0x000070BF File Offset: 0x000052BF
		public Mesh ZHandle { get; set; }

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000C63 RID: 3171 RVA: 0x0009D5AC File Offset: 0x0009B7AC
		// (set) Token: 0x06000C64 RID: 3172 RVA: 0x000070CA File Offset: 0x000052CA
		public string ReadableName { get; set; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000C65 RID: 3173 RVA: 0x0009D5C4 File Offset: 0x0009B7C4
		// (set) Token: 0x06000C66 RID: 3174 RVA: 0x000070D5 File Offset: 0x000052D5
		public string HashedName { get; set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000C67 RID: 3175 RVA: 0x0009D5DC File Offset: 0x0009B7DC
		// (set) Token: 0x06000C68 RID: 3176 RVA: 0x000070E0 File Offset: 0x000052E0
		public Enum18 CurrentDragMode { get; set; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000C69 RID: 3177 RVA: 0x0009D5F4 File Offset: 0x0009B7F4
		// (set) Token: 0x06000C6A RID: 3178 RVA: 0x000070EB File Offset: 0x000052EB
		public bool Selected { get; set; }

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000C6B RID: 3179 RVA: 0x0009D60C File Offset: 0x0009B80C
		// (set) Token: 0x06000C6C RID: 3180 RVA: 0x000070F6 File Offset: 0x000052F6
		public Matrix Transformation
		{
			get
			{
				return this.matrix_0;
			}
			set
			{
				this.method_3(value, true);
				this.renderable.imethod_14();
			}
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x0009D624 File Offset: 0x0009B824
		public void method_3(Matrix matrix_4, bool bool_2)
		{
			this.matrix_0 = matrix_4;
			this.imethod_0();
			this.imethod_2();
			if (this.renderable is Class105 && bool_2)
			{
				foreach (Class124 @class in (this.renderable as Class105).SkinEntries)
				{
					if (@class.GrannyBone == this.GrannyBone)
					{
						@class.method_3(matrix_4, false);
					}
				}
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000C6E RID: 3182 RVA: 0x0009D6B8 File Offset: 0x0009B8B8
		public Matrix TransformationX
		{
			get
			{
				return this.matrix_1 * this.matrix_0;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000C6F RID: 3183 RVA: 0x0009D6DC File Offset: 0x0009B8DC
		public Matrix TransformationY
		{
			get
			{
				return this.matrix_2 * this.matrix_0;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000C70 RID: 3184 RVA: 0x0009D700 File Offset: 0x0009B900
		public Matrix TransformationZ
		{
			get
			{
				return this.matrix_3 * this.matrix_0;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000C71 RID: 3185 RVA: 0x0009D724 File Offset: 0x0009B924
		public Matrix WorldTransformation
		{
			get
			{
				return this.Transformation;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000C72 RID: 3186 RVA: 0x0009D73C File Offset: 0x0009B93C
		// (set) Token: 0x06000C73 RID: 3187 RVA: 0x0000710D File Offset: 0x0000530D
		public Class33 GrannyBone { get; set; }

		// Token: 0x06000C74 RID: 3188 RVA: 0x0009D754 File Offset: 0x0009B954
		public Class124(Device device, Class102 renderable, SKIN.SKINEntry skinEntry, Class33 grannyBone, Color color)
		{
			this.renderable = renderable;
			this.GrannyBone = grannyBone;
			Vector3 point = new Vector3(-100f, 0f, -100f);
			Vector3 vector = new Vector3(100f, 0f, -100f);
			Vector3 point2 = new Vector3(100f, 0f, 100f);
			Vector3 point3 = new Vector3(-100f, 0f, 100f);
			this.Plane = new Plane(point, vector, point3);
			this.Plane2 = new Plane(vector, point2, point3);
			this.color = color;
			this.Entry = skinEntry;
			this.VBUF = new VertexBuffer(device, 6 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			this.XHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.YHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.ZHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.imethod_2();
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000C75 RID: 3189 RVA: 0x0009D878 File Offset: 0x0009BA78
		public string Name
		{
			get
			{
				Vector3 coordinate = new Vector3(0f, 0f, 0f);
				coordinate = Vector3.TransformCoordinate(coordinate, this.matrix_0);
				return string.Concat(new string[]
				{
					"SkinEntry ",
					this.GrannyBone.Sims3WorkshopSDK.Interfaces.IBone.Name,
					"\n(",
					string.Format("{0:0.000}", coordinate.X),
					",",
					string.Format("{0:0.000}", coordinate.Y),
					",",
					string.Format("{0:0.000}", coordinate.Z),
					")\n(",
					string.Format("{0:0.000}", this.Entry.BoneMatrix[3]),
					",",
					string.Format("{0:0.000}", this.Entry.BoneMatrix[7]),
					",",
					string.Format("{0:0.000}", this.Entry.BoneMatrix[11]),
					")"
				});
			}
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x0009D9B8 File Offset: 0x0009BBB8
		public void imethod_0()
		{
			Matrix matrix = this.matrix_0;
			matrix.Invert();
			this.Entry.BoneMatrix[0] = (float)Math.Round((double)matrix.M11, 3);
			this.Entry.BoneMatrix[4] = (float)Math.Round((double)matrix.M12, 3);
			this.Entry.BoneMatrix[8] = (float)Math.Round((double)matrix.M13, 3);
			this.Entry.BoneMatrix[1] = (float)Math.Round((double)matrix.M21, 3);
			this.Entry.BoneMatrix[5] = (float)Math.Round((double)matrix.M22, 3);
			this.Entry.BoneMatrix[9] = (float)Math.Round((double)matrix.M23, 3);
			this.Entry.BoneMatrix[2] = (float)Math.Round((double)matrix.M31, 3);
			this.Entry.BoneMatrix[6] = (float)Math.Round((double)matrix.M32, 3);
			this.Entry.BoneMatrix[10] = (float)Math.Round((double)matrix.M33, 3);
			this.Entry.BoneMatrix[3] = (float)Math.Round((double)matrix.M41, 3);
			this.Entry.BoneMatrix[7] = (float)Math.Round((double)matrix.M42, 3);
			this.Entry.BoneMatrix[11] = (float)Math.Round((double)matrix.M43, 3);
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x0009DB28 File Offset: 0x0009BD28
		public void imethod_2()
		{
			this.matrix_0 = Matrix.Identity;
			this.matrix_0.M11 = this.Entry.BoneMatrix[0];
			this.matrix_0.M12 = this.Entry.BoneMatrix[4];
			this.matrix_0.M13 = this.Entry.BoneMatrix[8];
			this.matrix_0.M21 = this.Entry.BoneMatrix[1];
			this.matrix_0.M22 = this.Entry.BoneMatrix[5];
			this.matrix_0.M23 = this.Entry.BoneMatrix[9];
			this.matrix_0.M31 = this.Entry.BoneMatrix[2];
			this.matrix_0.M32 = this.Entry.BoneMatrix[6];
			this.matrix_0.M33 = this.Entry.BoneMatrix[10];
			this.matrix_0.M41 = this.Entry.BoneMatrix[3];
			this.matrix_0.M42 = this.Entry.BoneMatrix[7];
			this.matrix_0.M43 = this.Entry.BoneMatrix[11];
			this.matrix_0.Invert();
			Vector3 zero = Vector3.Zero;
			Class112.Struct7[] data = new Class112.Struct7[]
			{
				new Class112.Struct7(zero, 1f, Color.Red.ToArgb()),
				new Class112.Struct7(Vector3.TransformCoordinate(zero, Matrix.Translation(new Vector3(0.05f, 0f, 0f))), 2f, Color.Red.ToArgb()),
				new Class112.Struct7(zero, 1f, Color.Green.ToArgb()),
				new Class112.Struct7(Vector3.TransformCoordinate(zero, Matrix.Translation(new Vector3(0f, 0.05f, 0f))), 2f, Color.Green.ToArgb()),
				new Class112.Struct7(zero, 1f, Color.Blue.ToArgb()),
				new Class112.Struct7(Vector3.TransformCoordinate(zero, Matrix.Translation(new Vector3(0f, 0f, 0.05f))), 2f, Color.Blue.ToArgb())
			};
			DataStream dataStream = this.VBUF.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct7>(data, 0, 6);
			this.VBUF.Unlock();
			this.matrix_1 = Matrix.RotationY(1.5707964f) * Matrix.Translation(new Vector3(0.07f, 0f, 0f));
			this.matrix_2 = Matrix.RotationX(-1.5707964f) * Matrix.Translation(new Vector3(0f, 0.07f, 0f));
			this.matrix_3 = Matrix.Translation(new Vector3(0f, 0f, 0.07f));
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x0009DE54 File Offset: 0x0009C054
		public void imethod_3(Device device_0, Matrix matrix_4)
		{
			Matrix matrix = this.matrix_0;
			Matrix viewMatrix = Class132.smethod_0().ViewMatrix;
			device_0.SetTexture(0, null);
			device_0.SetTexture(1, null);
			device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
			device_0.SetTransform(TransformState.World, matrix * matrix_4);
			Class140.smethod_0().method_9(RenderState.Lighting, false);
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
			device_0.SetStreamSource(0, this.VBUF, 0, Class112.Struct7.SizeInBytes);
			device_0.DrawPrimitives(PrimitiveType.LineList, 0, 3);
			Class140.smethod_0().method_22("g_ambient", this.Selected ? new Vector4(1f, 0f, 0f, 1f) : new Vector4(0.7f, 0.7f, 1f, 0.6f));
			Class140.smethod_0().method_40("Slot");
			Class140.smethod_0().method_35();
			int num = Class140.smethod_0().method_36();
			for (int i = 0; i < num; i++)
			{
				Class140.smethod_0().method_38(i);
				Class140.smethod_0().method_32(this.matrix_1 * matrix * matrix_4, viewMatrix);
				this.XHandle.DrawSubset(0);
				Class140.smethod_0().method_32(this.matrix_2 * matrix * matrix_4, viewMatrix);
				this.YHandle.DrawSubset(0);
				Class140.smethod_0().method_32(this.matrix_3 * matrix * matrix_4, viewMatrix);
				this.ZHandle.DrawSubset(0);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
			Class140.smethod_0().method_32(matrix_4, Class132.smethod_0().ViewMatrix);
			Class140.smethod_0().method_10();
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x00007118 File Offset: 0x00005318
		public void imethod_1()
		{
			this.XHandle.Dispose();
			this.YHandle.Dispose();
			this.ZHandle.Dispose();
			this.VBUF.Dispose();
		}

		// Token: 0x0400097F RID: 2431
		private Color color;

		// Token: 0x04000980 RID: 2432
		private Matrix matrix_0;

		// Token: 0x04000981 RID: 2433
		private Matrix matrix_1;

		// Token: 0x04000982 RID: 2434
		private Matrix matrix_2;

		// Token: 0x04000983 RID: 2435
		private Matrix matrix_3;

		// Token: 0x04000984 RID: 2436
		private Class102 renderable;

		// Token: 0x04000985 RID: 2437
		[CompilerGenerated]
		private SKIN.SKINEntry skinentry_0;

		// Token: 0x04000986 RID: 2438
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000987 RID: 2439
		[CompilerGenerated]
		private VertexBuffer vertexBuffer_0;

		// Token: 0x04000988 RID: 2440
		[CompilerGenerated]
		private Plane plane_0;

		// Token: 0x04000989 RID: 2441
		[CompilerGenerated]
		private Plane plane_1;

		// Token: 0x0400098A RID: 2442
		[CompilerGenerated]
		private Mesh mesh_0;

		// Token: 0x0400098B RID: 2443
		[CompilerGenerated]
		private Mesh mesh_1;

		// Token: 0x0400098C RID: 2444
		[CompilerGenerated]
		private Mesh mesh_2;

		// Token: 0x0400098D RID: 2445
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400098E RID: 2446
		[CompilerGenerated]
		private string string_1;

		// Token: 0x0400098F RID: 2447
		[CompilerGenerated]
		private Enum18 enum18_0;

		// Token: 0x04000990 RID: 2448
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x04000991 RID: 2449
		[CompilerGenerated]
		private Class33 class33_0;
	}
}
