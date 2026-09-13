using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns10;
using ns15;
using ns16;
using ns17;
using ns2;
using ns3;
using ns6;
using ns8;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns12
{
	// Token: 0x0200010E RID: 270
	internal sealed class Class119 : Interface10
	{
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000B73 RID: 2931 RVA: 0x00092DF0 File Offset: 0x00090FF0
		// (set) Token: 0x06000B74 RID: 2932 RVA: 0x00006BFD File Offset: 0x00004DFD
		public Class33 BoneEntry { get; set; }

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x00092E08 File Offset: 0x00091008
		// (set) Token: 0x06000B76 RID: 2934 RVA: 0x00006C08 File Offset: 0x00004E08
		public Class33 ParentBone { get; set; }

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x00092E20 File Offset: 0x00091020
		// (set) Token: 0x06000B78 RID: 2936 RVA: 0x00006C13 File Offset: 0x00004E13
		public bool Visible { get; set; }

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x00092E38 File Offset: 0x00091038
		// (set) Token: 0x06000B7A RID: 2938 RVA: 0x00006C1E File Offset: 0x00004E1E
		public bool Selected { get; set; }

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x00092E50 File Offset: 0x00091050
		// (set) Token: 0x06000B7C RID: 2940 RVA: 0x00006C29 File Offset: 0x00004E29
		private VertexBuffer VBUF { get; set; }

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x00092E68 File Offset: 0x00091068
		// (set) Token: 0x06000B7E RID: 2942 RVA: 0x00006C34 File Offset: 0x00004E34
		public Plane Plane { get; set; }

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000B7F RID: 2943 RVA: 0x00092E80 File Offset: 0x00091080
		// (set) Token: 0x06000B80 RID: 2944 RVA: 0x00006C3F File Offset: 0x00004E3F
		public Plane Plane2 { get; set; }

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000B81 RID: 2945 RVA: 0x00092E98 File Offset: 0x00091098
		// (set) Token: 0x06000B82 RID: 2946 RVA: 0x00006C4A File Offset: 0x00004E4A
		public Mesh XHandle { get; set; }

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000B83 RID: 2947 RVA: 0x00092EB0 File Offset: 0x000910B0
		// (set) Token: 0x06000B84 RID: 2948 RVA: 0x00006C55 File Offset: 0x00004E55
		public Mesh YHandle { get; set; }

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000B85 RID: 2949 RVA: 0x00092EC8 File Offset: 0x000910C8
		// (set) Token: 0x06000B86 RID: 2950 RVA: 0x00006C60 File Offset: 0x00004E60
		public Mesh ZHandle { get; set; }

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000B87 RID: 2951 RVA: 0x00092EE0 File Offset: 0x000910E0
		// (set) Token: 0x06000B88 RID: 2952 RVA: 0x00006C6B File Offset: 0x00004E6B
		public string ReadableName { get; set; }

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x00092EF8 File Offset: 0x000910F8
		// (set) Token: 0x06000B8A RID: 2954 RVA: 0x00006C76 File Offset: 0x00004E76
		public string HashedName { get; set; }

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000B8B RID: 2955 RVA: 0x00092F10 File Offset: 0x00091110
		// (set) Token: 0x06000B8C RID: 2956 RVA: 0x00006C81 File Offset: 0x00004E81
		public Enum18 CurrentDragMode { get; set; }

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x00092F28 File Offset: 0x00091128
		// (set) Token: 0x06000B8E RID: 2958 RVA: 0x00092FD0 File Offset: 0x000911D0
		public Matrix Transformation
		{
			get
			{
				return Matrix.RotationQuaternion(new Quaternion(this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[0], this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[1], this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[2], this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[3])) * Matrix.Translation(new Vector3(this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Origin[0], this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Origin[1], this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Origin[2]));
			}
			set
			{
				Matrix matrix = value;
				this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Origin[0] = matrix.M41;
				this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Origin[1] = matrix.M42;
				this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Origin[2] = matrix.M43;
				Quaternion quaternion = Quaternion.RotationMatrix(matrix);
				quaternion.Normalize();
				this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[0] = quaternion.X;
				this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[1] = quaternion.Y;
				this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[2] = quaternion.Z;
				this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[3] = quaternion.W;
				Matrix matrix2 = matrix;
				matrix2.Invert();
				this.BoneEntry.InverseMatrix[0] = matrix2.M11;
				this.BoneEntry.InverseMatrix[1] = matrix2.M12;
				this.BoneEntry.InverseMatrix[2] = matrix2.M13;
				this.BoneEntry.InverseMatrix[3] = matrix2.M14;
				this.BoneEntry.InverseMatrix[4] = matrix2.M21;
				this.BoneEntry.InverseMatrix[5] = matrix2.M22;
				this.BoneEntry.InverseMatrix[6] = matrix2.M23;
				this.BoneEntry.InverseMatrix[7] = matrix2.M24;
				this.BoneEntry.InverseMatrix[8] = matrix2.M31;
				this.BoneEntry.InverseMatrix[9] = matrix2.M32;
				this.BoneEntry.InverseMatrix[10] = matrix2.M33;
				this.BoneEntry.InverseMatrix[11] = matrix2.M34;
				this.BoneEntry.InverseMatrix[12] = matrix2.M41;
				this.BoneEntry.InverseMatrix[13] = matrix2.M42;
				this.BoneEntry.InverseMatrix[14] = matrix2.M43;
				this.BoneEntry.InverseMatrix[15] = matrix2.M44;
				this.imethod_2();
				this.renderable.imethod_14();
				if (this.renderable is Class105)
				{
					foreach (Class119 @class in (this.renderable as Class105).JointEntries)
					{
						@class.imethod_2();
					}
				}
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x00093260 File Offset: 0x00091460
		public Matrix TransformationX
		{
			get
			{
				return this.matrix_0 * this.BoneEntry.CombinedBoneTransformationMatrix;
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x00093288 File Offset: 0x00091488
		public Matrix TransformationY
		{
			get
			{
				return this.matrix_1 * this.BoneEntry.CombinedBoneTransformationMatrix;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x000932B0 File Offset: 0x000914B0
		public Matrix TransformationZ
		{
			get
			{
				return this.matrix_2 * this.BoneEntry.CombinedBoneTransformationMatrix;
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x000932D8 File Offset: 0x000914D8
		public Matrix WorldTransformation
		{
			get
			{
				return this.BoneEntry.CombinedBoneTransformationMatrix;
			}
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x000932F4 File Offset: 0x000914F4
		public Class119(Device device, Class102 renderable, ResKey grannyKey, Class28 grannyInfo, Class33 boneEntry, Class33 parentBone, Color color)
		{
			this.renderable = renderable;
			Vector3 point = new Vector3(-100f, 0f, -100f);
			Vector3 vector = new Vector3(100f, 0f, -100f);
			Vector3 point2 = new Vector3(100f, 0f, 100f);
			Vector3 point3 = new Vector3(-100f, 0f, 100f);
			this.Plane = new Plane(point, vector, point3);
			this.Plane2 = new Plane(vector, point2, point3);
			this.BoneEntry = boneEntry;
			this.ParentBone = parentBone;
			this.grannyKey = grannyKey;
			this.grannyInfo = grannyInfo;
			this.VBUF = new VertexBuffer(device, 8 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			this.XHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.YHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.ZHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.imethod_2();
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000B94 RID: 2964 RVA: 0x00093420 File Offset: 0x00091620
		public string Name
		{
			get
			{
				return string.Concat(new string[]
				{
					"Joint - ",
					this.BoneEntry.Sims3WorkshopSDK.Interfaces.IBone.Name,
					"\n(",
					string.Format("{0:0.000}", this.BoneEntry.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[0]),
					",",
					string.Format("{0:0.000}", this.BoneEntry.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[1]),
					",",
					string.Format("{0:0.000}", this.BoneEntry.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[2]),
					")"
				});
			}
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x000934E4 File Offset: 0x000916E4
		public void imethod_0()
		{
			if (Class132.mainForm.RIGEditor != null)
			{
				IRIGEditor rigeditor = Class132.mainForm.RIGEditor;
				RIG rig = Class132.mainForm.CurrentProject.Package.GetEntry(this.grannyKey) as RIG;
				rigeditor.UpdateRIGFromGranny2Info(rig, this.grannyInfo);
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				object obj = Class132.mainForm.CurrentProjectModel.GetRenderable();
				if (obj is Class105)
				{
					Class105 @class = obj as Class105;
					foreach (Class111 class2 in @class.ContainerEntries)
					{
						uint boneHash = class2.RSLTEntry.BoneHash;
						uint nameHash = this.BoneEntry.NameHash;
					}
					foreach (Class111 class3 in @class.RouteEntries)
					{
						if (class3.RSLTEntry.BoneHash == this.BoneEntry.NameHash)
						{
							Matrix combinedBoneTransformationMatrix = this.BoneEntry.CombinedBoneTransformationMatrix;
							class3.Transformation = combinedBoneTransformationMatrix;
							class3.imethod_0();
						}
					}
					foreach (Class111 class4 in @class.KinematicEntries)
					{
						if (class4.RSLTEntry.BoneHash == this.BoneEntry.NameHash)
						{
							Matrix combinedBoneTransformationMatrix2 = this.BoneEntry.CombinedBoneTransformationMatrix;
							class4.Transformation = combinedBoneTransformationMatrix2;
							class4.imethod_0();
						}
					}
					foreach (Class111 class5 in @class.EffectEntries)
					{
						if (class5.RSLTEntry.BoneHash == this.BoneEntry.NameHash)
						{
							Matrix combinedBoneTransformationMatrix3 = this.BoneEntry.CombinedBoneTransformationMatrix;
							class5.Transformation = combinedBoneTransformationMatrix3;
							class5.imethod_0();
						}
					}
					foreach (MLOD.MLODEntry mlodentry in (obj as Class105).Objects.Keys)
					{
						if (mlodentry.SkinIndex != -1)
						{
							SKIN skin = mlodentry.Parent.Parent.Entries[mlodentry.SkinIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as SKIN;
							if (skin != null)
							{
								SKIN.SKINEntry skinentry = skin.HashedEntries[this.BoneEntry.NameHash] as SKIN.SKINEntry;
								if (skinentry != null)
								{
									Matrix combinedBoneTransformationMatrix4 = this.BoneEntry.CombinedBoneTransformationMatrix;
									combinedBoneTransformationMatrix4.Invert();
									skinentry.BoneMatrix[0] = combinedBoneTransformationMatrix4.M11;
									skinentry.BoneMatrix[4] = combinedBoneTransformationMatrix4.M12;
									skinentry.BoneMatrix[8] = combinedBoneTransformationMatrix4.M13;
									skinentry.BoneMatrix[1] = combinedBoneTransformationMatrix4.M21;
									skinentry.BoneMatrix[5] = combinedBoneTransformationMatrix4.M22;
									skinentry.BoneMatrix[9] = combinedBoneTransformationMatrix4.M23;
									skinentry.BoneMatrix[2] = combinedBoneTransformationMatrix4.M31;
									skinentry.BoneMatrix[6] = combinedBoneTransformationMatrix4.M32;
									skinentry.BoneMatrix[10] = combinedBoneTransformationMatrix4.M33;
									skinentry.BoneMatrix[3] = combinedBoneTransformationMatrix4.M41;
									skinentry.BoneMatrix[7] = combinedBoneTransformationMatrix4.M42;
									skinentry.BoneMatrix[11] = combinedBoneTransformationMatrix4.M43;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x00093900 File Offset: 0x00091B00
		public void imethod_2()
		{
			Vector3 zero = Vector3.Zero;
			Class112.Struct7[] array = new Class112.Struct7[8];
			array[0] = new Class112.Struct7(zero, 1f, Color.Red.ToArgb());
			array[1] = new Class112.Struct7(Vector3.TransformCoordinate(zero, Matrix.Translation(new Vector3(0.05f, 0f, 0f))), 2f, Color.Red.ToArgb());
			array[2] = new Class112.Struct7(zero, 1f, Color.Green.ToArgb());
			array[3] = new Class112.Struct7(Vector3.TransformCoordinate(zero, Matrix.Translation(new Vector3(0f, 0.05f, 0f))), 2f, Color.Green.ToArgb());
			array[4] = new Class112.Struct7(zero, 1f, Color.Blue.ToArgb());
			array[5] = new Class112.Struct7(Vector3.TransformCoordinate(zero, Matrix.Translation(new Vector3(0f, 0f, 0.05f))), 2f, Color.Blue.ToArgb());
			DataStream dataStream = this.VBUF.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct7>(array, 0, 6);
			this.VBUF.Unlock();
			this.matrix_0 = Matrix.RotationY(1.5707964f) * Matrix.Translation(new Vector3(0.07f, 0f, 0f));
			this.matrix_1 = Matrix.RotationX(-1.5707964f) * Matrix.Translation(new Vector3(0f, 0.07f, 0f));
			this.matrix_2 = Matrix.Translation(new Vector3(0f, 0f, 0.07f));
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00093AF4 File Offset: 0x00091CF4
		public void imethod_3(Device device_0, Matrix matrix_3)
		{
			device_0.SetTexture(0, null);
			device_0.SetTexture(1, null);
			device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
			device_0.SetTransform(TransformState.World, this.BoneEntry.CombinedBoneTransformationMatrix * matrix_3);
			Class140.smethod_0().method_9(RenderState.Lighting, false);
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
			device_0.SetStreamSource(0, this.VBUF, 0, Class112.Struct7.SizeInBytes);
			device_0.DrawPrimitives(PrimitiveType.LineList, 0, 3);
			Class140.smethod_0().method_22("g_ambient", this.Selected ? new Vector4(1f, 1f, 0f, 1f) : new Vector4(0f, 1f, 0f, 0.6f));
			Class140.smethod_0().method_40("Slot");
			Class140.smethod_0().method_35();
			int num = Class140.smethod_0().method_36();
			for (int i = 0; i < num; i++)
			{
				Class140.smethod_0().method_38(i);
				Class140.smethod_0().method_32(this.matrix_0 * this.BoneEntry.CombinedBoneTransformationMatrix * matrix_3, Class132.smethod_0().ViewMatrix);
				this.XHandle.DrawSubset(0);
				Class140.smethod_0().method_32(this.matrix_1 * this.BoneEntry.CombinedBoneTransformationMatrix * matrix_3, Class132.smethod_0().ViewMatrix);
				this.YHandle.DrawSubset(0);
				Class140.smethod_0().method_32(this.matrix_2 * this.BoneEntry.CombinedBoneTransformationMatrix * matrix_3, Class132.smethod_0().ViewMatrix);
				this.ZHandle.DrawSubset(0);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
			Class140.smethod_0().method_32(matrix_3, Class132.smethod_0().ViewMatrix);
			Class140.smethod_0().method_10();
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x00006C8C File Offset: 0x00004E8C
		public void imethod_1()
		{
			this.XHandle.Dispose();
			this.YHandle.Dispose();
			this.ZHandle.Dispose();
			this.VBUF.Dispose();
		}

		// Token: 0x04000909 RID: 2313
		private ResKey grannyKey;

		// Token: 0x0400090A RID: 2314
		private Class28 grannyInfo;

		// Token: 0x0400090B RID: 2315
		private Matrix matrix_0;

		// Token: 0x0400090C RID: 2316
		private Matrix matrix_1;

		// Token: 0x0400090D RID: 2317
		private Matrix matrix_2;

		// Token: 0x0400090E RID: 2318
		private Class102 renderable;

		// Token: 0x0400090F RID: 2319
		[CompilerGenerated]
		private Class33 class33_0;

		// Token: 0x04000910 RID: 2320
		[CompilerGenerated]
		private Class33 class33_1;

		// Token: 0x04000911 RID: 2321
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000912 RID: 2322
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x04000913 RID: 2323
		[CompilerGenerated]
		private VertexBuffer vertexBuffer_0;

		// Token: 0x04000914 RID: 2324
		[CompilerGenerated]
		private Plane plane_0;

		// Token: 0x04000915 RID: 2325
		[CompilerGenerated]
		private Plane plane_1;

		// Token: 0x04000916 RID: 2326
		[CompilerGenerated]
		private Mesh mesh_0;

		// Token: 0x04000917 RID: 2327
		[CompilerGenerated]
		private Mesh mesh_1;

		// Token: 0x04000918 RID: 2328
		[CompilerGenerated]
		private Mesh mesh_2;

		// Token: 0x04000919 RID: 2329
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400091A RID: 2330
		[CompilerGenerated]
		private string string_1;

		// Token: 0x0400091B RID: 2331
		[CompilerGenerated]
		private Enum18 enum18_0;
	}
}
