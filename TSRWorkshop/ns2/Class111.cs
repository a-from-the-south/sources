using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns10;
using ns15;
using ns16;
using ns17;
using ns3;
using ns6;
using ns8;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns2
{
	// Token: 0x02000101 RID: 257
	internal sealed class Class111 : Interface10
	{
		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000B07 RID: 2823 RVA: 0x0008D2A4 File Offset: 0x0008B4A4
		public Class28 GrannyInfo
		{
			get
			{
				return this.grannyInfo;
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000B08 RID: 2824 RVA: 0x0008D2BC File Offset: 0x0008B4BC
		// (set) Token: 0x06000B09 RID: 2825 RVA: 0x00006A1E File Offset: 0x00004C1E
		public RSLT.Entry RSLTEntry { get; set; }

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000B0A RID: 2826 RVA: 0x0008D2D4 File Offset: 0x0008B4D4
		// (set) Token: 0x06000B0B RID: 2827 RVA: 0x00006A29 File Offset: 0x00004C29
		public RSLT RSLT { get; set; }

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000B0C RID: 2828 RVA: 0x0008D2EC File Offset: 0x0008B4EC
		// (set) Token: 0x06000B0D RID: 2829 RVA: 0x00006A34 File Offset: 0x00004C34
		public bool Visible { get; set; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000B0E RID: 2830 RVA: 0x0008D304 File Offset: 0x0008B504
		// (set) Token: 0x06000B0F RID: 2831 RVA: 0x00006A3F File Offset: 0x00004C3F
		private VertexBuffer VBUF { get; set; }

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000B10 RID: 2832 RVA: 0x0008D31C File Offset: 0x0008B51C
		// (set) Token: 0x06000B11 RID: 2833 RVA: 0x00006A4A File Offset: 0x00004C4A
		public Plane Plane { get; set; }

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000B12 RID: 2834 RVA: 0x0008D334 File Offset: 0x0008B534
		// (set) Token: 0x06000B13 RID: 2835 RVA: 0x00006A55 File Offset: 0x00004C55
		public Plane Plane2 { get; set; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000B14 RID: 2836 RVA: 0x0008D34C File Offset: 0x0008B54C
		// (set) Token: 0x06000B15 RID: 2837 RVA: 0x00006A60 File Offset: 0x00004C60
		public Mesh XHandle { get; set; }

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000B16 RID: 2838 RVA: 0x0008D364 File Offset: 0x0008B564
		// (set) Token: 0x06000B17 RID: 2839 RVA: 0x00006A6B File Offset: 0x00004C6B
		public Mesh YHandle { get; set; }

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000B18 RID: 2840 RVA: 0x0008D37C File Offset: 0x0008B57C
		// (set) Token: 0x06000B19 RID: 2841 RVA: 0x00006A76 File Offset: 0x00004C76
		public Mesh ZHandle { get; set; }

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000B1A RID: 2842 RVA: 0x0008D394 File Offset: 0x0008B594
		// (set) Token: 0x06000B1B RID: 2843 RVA: 0x00006A81 File Offset: 0x00004C81
		public string ReadableName { get; set; }

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000B1C RID: 2844 RVA: 0x0008D3AC File Offset: 0x0008B5AC
		// (set) Token: 0x06000B1D RID: 2845 RVA: 0x00006A8C File Offset: 0x00004C8C
		public string HashedName { get; set; }

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000B1E RID: 2846 RVA: 0x0008D3C4 File Offset: 0x0008B5C4
		// (set) Token: 0x06000B1F RID: 2847 RVA: 0x00006A97 File Offset: 0x00004C97
		public Enum18 CurrentDragMode { get; set; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000B20 RID: 2848 RVA: 0x0008D3DC File Offset: 0x0008B5DC
		// (set) Token: 0x06000B21 RID: 2849 RVA: 0x00006AA2 File Offset: 0x00004CA2
		public string BoneName { get; set; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000B22 RID: 2850 RVA: 0x0008D3F4 File Offset: 0x0008B5F4
		// (set) Token: 0x06000B23 RID: 2851 RVA: 0x00006AAD File Offset: 0x00004CAD
		public Matrix Transformation
		{
			get
			{
				return this.matrix_0;
			}
			set
			{
				this.matrix_0 = value;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000B24 RID: 2852 RVA: 0x0008D40C File Offset: 0x0008B60C
		public Matrix TransformationX
		{
			get
			{
				return this.matrix_1 * this.matrix_0;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000B25 RID: 2853 RVA: 0x0008D430 File Offset: 0x0008B630
		public Matrix TransformationY
		{
			get
			{
				return this.matrix_2 * this.matrix_0;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000B26 RID: 2854 RVA: 0x0008D454 File Offset: 0x0008B654
		public Matrix TransformationZ
		{
			get
			{
				return this.matrix_3 * this.matrix_0;
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000B27 RID: 2855 RVA: 0x0008D478 File Offset: 0x0008B678
		public Matrix WorldTransformation
		{
			get
			{
				return this.Transformation;
			}
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0008D490 File Offset: 0x0008B690
		public Class111(Device device, RSLT rslt, RSLT.Entry rsltEntry, Color color, Class28 grannyInfo)
		{
			this.grannyInfo = grannyInfo;
			Vector3 point = new Vector3(-100f, 0f, -100f);
			Vector3 vector = new Vector3(100f, 0f, -100f);
			Vector3 point2 = new Vector3(100f, 0f, 100f);
			Vector3 point3 = new Vector3(-100f, 0f, 100f);
			this.Plane = new Plane(point, vector, point3);
			this.Plane2 = new Plane(vector, point2, point3);
			this.color = color;
			this.RSLTEntry = rsltEntry;
			this.RSLT = rslt;
			this.VBUF = new VertexBuffer(device, 6 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			this.XHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.YHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.ZHandle = Mesh.CreateCylinder(device, 0.005f, 0f, 0.04f, 24, 24);
			this.imethod_2();
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000B29 RID: 2857 RVA: 0x0008D5B4 File Offset: 0x0008B7B4
		public string Name
		{
			get
			{
				return string.Concat(new string[]
				{
					"SlotEntry - ",
					(this.BoneName != null) ? this.BoneName : ("0x" + this.RSLTEntry.BoneHash.ToString("X8")),
					"\n(",
					string.Format("{0:0.000}", this.matrix_0.M41),
					",",
					string.Format("{0:0.000}", this.matrix_0.M42),
					",",
					string.Format("{0:0.000}", this.matrix_0.M43),
					")"
				});
			}
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0008D688 File Offset: 0x0008B888
		public void imethod_0()
		{
			this.RSLTEntry.Transformation[0] = 1f;
			this.RSLTEntry.Transformation[4] = 0f;
			this.RSLTEntry.Transformation[8] = 0f;
			this.RSLTEntry.Transformation[1] = 0f;
			this.RSLTEntry.Transformation[5] = 1f;
			this.RSLTEntry.Transformation[9] = 0f;
			this.RSLTEntry.Transformation[2] = 0f;
			this.RSLTEntry.Transformation[6] = 0f;
			this.RSLTEntry.Transformation[10] = 1f;
			this.RSLTEntry.Transformation[3] = this.matrix_0.M41;
			this.RSLTEntry.Transformation[7] = this.matrix_0.M42;
			this.RSLTEntry.Transformation[11] = this.matrix_0.M43;
			object renderable = Class132.mainForm.CurrentProjectModel.GetRenderable();
			if (renderable is Class105)
			{
				foreach (MLOD.MLODEntry mlodentry in (renderable as Class105).Objects.Keys)
				{
					if (mlodentry.SkinIndex != -1)
					{
						SKIN skin = mlodentry.Parent.Parent.Entries[mlodentry.SkinIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as SKIN;
						if (skin != null)
						{
							SKIN.SKINEntry skinentry = skin.HashedEntries[this.RSLTEntry.BoneHash] as SKIN.SKINEntry;
							if (skinentry != null)
							{
								Matrix matrix = this.matrix_0;
								matrix.Invert();
								skinentry.BoneMatrix[0] = matrix.M11;
								skinentry.BoneMatrix[4] = matrix.M12;
								skinentry.BoneMatrix[8] = matrix.M13;
								skinentry.BoneMatrix[1] = matrix.M21;
								skinentry.BoneMatrix[5] = matrix.M22;
								skinentry.BoneMatrix[9] = matrix.M23;
								skinentry.BoneMatrix[2] = matrix.M31;
								skinentry.BoneMatrix[6] = matrix.M32;
								skinentry.BoneMatrix[10] = matrix.M33;
								skinentry.BoneMatrix[3] = matrix.M41;
								skinentry.BoneMatrix[7] = matrix.M42;
								skinentry.BoneMatrix[11] = matrix.M43;
							}
						}
					}
				}
				if (Class132.mainForm.RIGEditor != null)
				{
					IRIGEditor rigeditor = Class132.mainForm.RIGEditor;
					if ((renderable as Class105).GrannyInfo != null)
					{
						Class28 @class = (renderable as Class105).GrannyInfo;
						foreach (Class33 class2 in @class.Skeletons[0].Bones)
						{
							if (class2.NameHash == this.RSLTEntry.BoneHash)
							{
								Matrix combinedBoneTransformationMatrix = class2.ParentBone.CombinedBoneTransformationMatrix;
								combinedBoneTransformationMatrix.Invert();
								Matrix matrix2 = this.matrix_0 * combinedBoneTransformationMatrix;
								class2.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Origin[0] = matrix2.M41;
								class2.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Origin[1] = matrix2.M42;
								class2.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Origin[2] = matrix2.M43;
								Quaternion quaternion = Quaternion.RotationMatrix(matrix2);
								quaternion.Normalize();
								class2.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[0] = quaternion.X;
								class2.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[1] = quaternion.Y;
								class2.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[2] = quaternion.Z;
								class2.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat[3] = quaternion.W;
								Matrix matrix3 = matrix2;
								matrix3.Invert();
								class2.InverseMatrix[0] = matrix3.M11;
								class2.InverseMatrix[1] = matrix3.M12;
								class2.InverseMatrix[2] = matrix3.M13;
								class2.InverseMatrix[3] = matrix3.M14;
								class2.InverseMatrix[4] = matrix3.M21;
								class2.InverseMatrix[5] = matrix3.M22;
								class2.InverseMatrix[6] = matrix3.M23;
								class2.InverseMatrix[7] = matrix3.M24;
								class2.InverseMatrix[8] = matrix3.M31;
								class2.InverseMatrix[9] = matrix3.M32;
								class2.InverseMatrix[10] = matrix3.M33;
								class2.InverseMatrix[11] = matrix3.M34;
								class2.InverseMatrix[12] = matrix3.M41;
								class2.InverseMatrix[13] = matrix3.M42;
								class2.InverseMatrix[14] = matrix3.M43;
								class2.InverseMatrix[15] = matrix3.M44;
							}
						}
						foreach (ResKey key in Class132.mainForm.CurrentProject.Package.SearchEntries(new ResKey((DBPFType)2393838558U)))
						{
							RIG rig = Class132.mainForm.CurrentProject.Package.GetEntry(key) as RIG;
							rigeditor.UpdateRIGFromGranny2Info(rig, @class);
							Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
							foreach (Class102 class3 in Class132.smethod_0().Renderables)
							{
								class3.imethod_14();
							}
						}
					}
				}
			}
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0008DC80 File Offset: 0x0008BE80
		public void imethod_2()
		{
			this.matrix_0 = Matrix.Identity;
			this.matrix_0.M11 = this.RSLTEntry.Transformation[0];
			this.matrix_0.M12 = this.RSLTEntry.Transformation[4];
			this.matrix_0.M13 = this.RSLTEntry.Transformation[8];
			this.matrix_0.M21 = this.RSLTEntry.Transformation[1];
			this.matrix_0.M22 = this.RSLTEntry.Transformation[5];
			this.matrix_0.M23 = this.RSLTEntry.Transformation[9];
			this.matrix_0.M31 = this.RSLTEntry.Transformation[2];
			this.matrix_0.M32 = this.RSLTEntry.Transformation[6];
			this.matrix_0.M33 = this.RSLTEntry.Transformation[10];
			this.matrix_0.M41 = this.RSLTEntry.Transformation[3];
			this.matrix_0.M42 = this.RSLTEntry.Transformation[7];
			this.matrix_0.M43 = this.RSLTEntry.Transformation[11];
			if (this.grannyInfo != null)
			{
				foreach (Class33 @class in this.grannyInfo.Skeletons[0].Bones)
				{
					if (@class.NameHash == this.RSLTEntry.BoneHash)
					{
						float[] quat = @class.Sims3WorkshopSDK.Interfaces.IBone.GetTransformation().Quat;
						this.matrix_0 = Matrix.RotationQuaternion(new Quaternion(quat[0], quat[1], quat[2], quat[3])) * this.matrix_0;
					}
				}
			}
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

		// Token: 0x06000B2C RID: 2860 RVA: 0x0008E020 File Offset: 0x0008C220
		public void imethod_3(Device device_0, Matrix matrix_4)
		{
			device_0.SetTexture(0, null);
			device_0.SetTexture(1, null);
			device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
			device_0.SetTransform(TransformState.World, this.matrix_0 * matrix_4);
			Class140.smethod_0().method_9(RenderState.Lighting, false);
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
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

		// Token: 0x06000B2D RID: 2861 RVA: 0x00006AB8 File Offset: 0x00004CB8
		public void imethod_1()
		{
			this.XHandle.Dispose();
			this.YHandle.Dispose();
			this.ZHandle.Dispose();
			this.VBUF.Dispose();
		}

		// Token: 0x04000888 RID: 2184
		private Class28 grannyInfo;

		// Token: 0x04000889 RID: 2185
		private Color color;

		// Token: 0x0400088A RID: 2186
		private Matrix matrix_0;

		// Token: 0x0400088B RID: 2187
		private Matrix matrix_1;

		// Token: 0x0400088C RID: 2188
		private Matrix matrix_2;

		// Token: 0x0400088D RID: 2189
		private Matrix matrix_3;

		// Token: 0x0400088E RID: 2190
		[CompilerGenerated]
		private RSLT.Entry entry_0;

		// Token: 0x0400088F RID: 2191
		[CompilerGenerated]
		private RSLT rslt_0;

		// Token: 0x04000890 RID: 2192
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000891 RID: 2193
		[CompilerGenerated]
		private VertexBuffer vertexBuffer_0;

		// Token: 0x04000892 RID: 2194
		[CompilerGenerated]
		private Plane plane_0;

		// Token: 0x04000893 RID: 2195
		[CompilerGenerated]
		private Plane plane_1;

		// Token: 0x04000894 RID: 2196
		[CompilerGenerated]
		private Mesh mesh_0;

		// Token: 0x04000895 RID: 2197
		[CompilerGenerated]
		private Mesh mesh_1;

		// Token: 0x04000896 RID: 2198
		[CompilerGenerated]
		private Mesh mesh_2;

		// Token: 0x04000897 RID: 2199
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000898 RID: 2200
		[CompilerGenerated]
		private string string_1;

		// Token: 0x04000899 RID: 2201
		[CompilerGenerated]
		private Enum18 enum18_0;

		// Token: 0x0400089A RID: 2202
		[CompilerGenerated]
		private string string_2;
	}
}
