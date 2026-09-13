using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using ns10;
using ns16;
using ns6;
using ns8;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns15
{
	// Token: 0x0200010F RID: 271
	internal sealed class Class120
	{
		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x00093D10 File Offset: 0x00091F10
		// (set) Token: 0x06000B9A RID: 2970 RVA: 0x00006CBC File Offset: 0x00004EBC
		public float Angle
		{
			get
			{
				return this.lite.Floats[10];
			}
			set
			{
				this.lite.Floats[10] = value;
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x00093D30 File Offset: 0x00091F30
		// (set) Token: 0x06000B9C RID: 2972 RVA: 0x00006CCF File Offset: 0x00004ECF
		public bool Visible { get; set; }

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x00093D48 File Offset: 0x00091F48
		public Mesh PositionHandle
		{
			get
			{
				return this.mesh_1;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x00093D60 File Offset: 0x00091F60
		// (set) Token: 0x06000B9F RID: 2975 RVA: 0x00006CDA File Offset: 0x00004EDA
		public ResKey Reskey { get; private set; }

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x00093D78 File Offset: 0x00091F78
		// (set) Token: 0x06000BA1 RID: 2977 RVA: 0x00006CE5 File Offset: 0x00004EE5
		public LITE.LightEntry Tag
		{
			get
			{
				return this.lite;
			}
			set
			{
				this.lite = value;
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x00093D90 File Offset: 0x00091F90
		// (set) Token: 0x06000BA3 RID: 2979 RVA: 0x00006CF0 File Offset: 0x00004EF0
		public Matrix Transformation
		{
			get
			{
				return this.matrix_1;
			}
			set
			{
				this.matrix_1 = value;
			}
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x00093DA8 File Offset: 0x00091FA8
		public Class120(Device device, LITE.LightEntry lite, ResKey reskey)
		{
			this.Reskey = reskey;
			this.lite = lite;
			this.int_0 = 24;
			this.material_0 = default(Material);
			this.material_1 = default(Material);
			this.material_0.Ambient = Color.FromArgb(150, Color.Yellow);
			this.material_1.Ambient = Color.FromArgb(150, Color.Yellow);
			this.material_1.Diffuse = Color.FromArgb(150, Color.Yellow);
			this.material_0.Diffuse = Color.FromArgb(150, Color.Yellow);
			this.method_1(device);
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x00093E70 File Offset: 0x00092070
		public static Matrix smethod_0(Vector3 vector3_3, Vector3 vector3_4)
		{
			Vector3 vector = vector3_4 - vector3_3;
			Vector3 unitY = Vector3.UnitY;
			vector.Normalize();
			float angle = (float)Math.Acos((double)Vector3.Dot(vector, unitY));
			Vector3 axis = Vector3.Cross(unitY, vector);
			axis.Normalize();
			Matrix result = Matrix.RotationAxis(axis, angle);
			Matrix.Translation(vector3_3).Invert();
			return result;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x00093ED4 File Offset: 0x000920D4
		public void method_0()
		{
			try
			{
				Vector3 vector = this.vector3_0 - this.vector3_1;
				this.lite.Floats[7] = vector.X;
				this.lite.Floats[8] = vector.Y;
				this.lite.Floats[9] = vector.Z;
				this.matrix_0 = Class120.smethod_0(this.vector3_0, this.vector3_1);
				this.float_0 = Vector3.Distance(this.vector3_0, this.vector3_1);
				double a = 0.017453292519943295 * (double)this.lite.Floats[10];
				this.float_1 = (float)(Math.Tan(a) * (double)this.float_0);
				this.float_2 = this.float_1 * 1.8f;
				string text = this.lite.Floats[3].ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",";
				text = text + this.lite.Floats[4].ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",";
				text = text + this.lite.Floats[5].ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",1.0000000";
				Color color = Class76.smethod_32(text);
				this.struct7_0[0] = new Class112.Struct7(Vector3.Zero, 1.5f, Color.Red.ToArgb());
				this.struct7_0[1] = new Class112.Struct7(new Vector3(this.float_1, this.float_0, 0f), 1.5f, Color.Red.ToArgb());
				this.struct7_0[2] = new Class112.Struct7(Vector3.Zero, 1.5f, Color.Red.ToArgb());
				this.struct7_0[3] = new Class112.Struct7(new Vector3(-this.float_1, this.float_0, 0f), 1.5f, Color.Red.ToArgb());
				this.struct7_0[4] = new Class112.Struct7(Vector3.Zero, 1.5f, Color.Red.ToArgb());
				this.struct7_0[5] = new Class112.Struct7(new Vector3(0f, this.float_0, this.float_1), 1.5f, Color.Red.ToArgb());
				this.struct7_0[6] = new Class112.Struct7(Vector3.Zero, 1.5f, Color.Red.ToArgb());
				Class112.Struct7[] array = this.struct7_0;
				int num = 7;
				int num2 = 8;
				array[num] = new Class112.Struct7(new Vector3(0f, this.float_0, -this.float_1), 1.5f, Color.Red.ToArgb());
				float num3 = 0f;
				float x = (float)(Math.Cos((double)0f) * (double)this.float_1);
				float z = (float)(Math.Sin((double)0f) * (double)this.float_1);
				for (int i = 0; i < this.int_0; i++)
				{
					num3 += 360f / (float)this.int_0;
					float num4 = (float)(Math.Cos((double)num3 * 0.017453292519943295) * (double)this.float_1);
					float num5 = (float)(Math.Sin((double)num3 * 0.017453292519943295) * (double)this.float_1);
					this.struct7_0[num2++] = new Class112.Struct7(new Vector3(x, this.float_0, z), 1.5f, Color.Red.ToArgb());
					this.struct7_0[num2++] = new Class112.Struct7(new Vector3(num4, this.float_0, num5), 1.5f, Color.Red.ToArgb());
					x = num4;
					z = num5;
				}
				num3 = 0f;
				x = (float)(Math.Cos((double)0f) * (double)this.float_1);
				z = (float)(Math.Sin((double)0f) * (double)this.float_1);
				for (int j = 0; j < this.int_0; j++)
				{
					num3 += 360f / (float)this.int_0;
					float num6 = (float)(Math.Cos((double)num3 * 0.017453292519943295) * (double)this.float_1);
					float num7 = (float)(Math.Sin((double)num3 * 0.017453292519943295) * (double)this.float_1);
					this.struct7_0[num2++] = new Class112.Struct7(new Vector3(0f, this.float_0, 0f), 1.5f, color.ToArgb());
					this.struct7_0[num2++] = new Class112.Struct7(new Vector3(x, this.float_0, z), 1.5f, color.ToArgb());
					this.struct7_0[num2++] = new Class112.Struct7(new Vector3(num6, this.float_0, num7), 1.5f, color.ToArgb());
					x = num6;
					z = num7;
				}
				text = Math.Min(1f, this.lite.Floats[3] + 0.2f).ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",";
				text = text + Math.Min(1f, this.lite.Floats[4] + 0.2f).ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",";
				text = text + Math.Min(1f, this.lite.Floats[5] + 0.2f).ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",1.0000000";
				color = Class76.smethod_32(text);
				num3 = 0f;
				x = (float)(Math.Cos((double)0f) * (double)this.float_2);
				z = (float)(Math.Sin((double)0f) * (double)this.float_2);
				for (int k = 0; k < this.int_0; k++)
				{
					num3 += 360f / (float)this.int_0;
					float num8 = (float)(Math.Cos((double)num3 * 0.017453292519943295) * (double)this.float_2);
					float num9 = (float)(Math.Sin((double)num3 * 0.017453292519943295) * (double)this.float_2);
					this.struct7_0[num2++] = new Class112.Struct7(new Vector3(0f, this.float_0, 0f), 1.5f, color.ToArgb());
					this.struct7_0[num2++] = new Class112.Struct7(new Vector3(x, this.float_0, z), 1.5f, color.ToArgb());
					this.struct7_0[num2++] = new Class112.Struct7(new Vector3(num8, this.float_0, num9), 1.5f, color.ToArgb());
					x = num8;
					z = num9;
				}
				this.struct7_0[num2++] = new Class112.Struct7(new Vector3(0f, this.float_0, 0f), 1.5f, Color.Red.ToArgb());
				this.vector3_2.Z = this.float_0 / 2f;
				DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
				dataStream.WriteRange<Class112.Struct7>(this.struct7_0, 0, this.int_1 * 2 + this.int_2 * 3 + 1);
				this.vertexBuffer_0.Unlock();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x00094740 File Offset: 0x00092940
		public unsafe void method_1(Device device_0)
		{
			this.uint_0 = (uint)this.lite.Type;
			this.vector3_0 = new Vector3(this.lite.Floats[0], this.lite.Floats[1], this.lite.Floats[2]);
			this.vector3_1 = this.vector3_0 - new Vector3(this.lite.Floats[7], this.lite.Floats[8], this.lite.Floats[9]);
			this.Angle = this.lite.Floats[10];
			this.int_1 = this.int_0 + 4;
			this.int_2 = this.int_0 * 2;
			this.vertexBuffer_0 = new VertexBuffer(device_0, (this.int_1 * 2 + this.int_2 * 3 + 1) * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			this.struct7_0 = new Class112.Struct7[this.int_1 * 2 + this.int_2 * 3 + 1];
			this.method_0();
			this.mesh_1 = Mesh.CreateSphere(device_0, 0.02f, 24, 24);
			if (this.uint_0 == 1U)
			{
				this.vector3_1 = Vector3.Zero;
				float x = this.lite.Floats[0];
				float y = this.lite.Floats[1];
				float z = this.lite.Floats[2];
				Vector3 vector = Vector3.TransformCoordinate(new Vector3(x, y, z), Matrix.Translation(new Vector3((Math.Round((double)this.lite.Floats[6], 3) != 0.0) ? (1f / this.lite.Floats[6]) : 0f, (Math.Round((double)this.lite.Floats[7], 3) != 0.0) ? (1f / this.lite.Floats[7]) : 0f, (Math.Round((double)this.lite.Floats[8], 3) != 0.0) ? (1f / this.lite.Floats[8]) : 0f)));
				Vector3 vector2 = Vector3.TransformCoordinate(new Vector3(x, y, z), Matrix.Translation(new Vector3((Math.Round((double)this.lite.Floats[9], 3) != 0.0) ? (1f / this.lite.Floats[9]) : 0f, (Math.Round((double)this.lite.Floats[10], 3) != 0.0) ? (1f / this.lite.Floats[10]) : 0f, (Math.Round((double)this.lite.Floats[11], 3) != 0.0) ? (1f / this.lite.Floats[11]) : 0f)));
				this.vector3_0 = new Vector3(0f, 0f, 0f);
				Vector3 vector3 = vector;
				Vector3 vector4 = vector2;
				Math.Max(vector3.X, vector4.X);
				Math.Min(vector3.X, vector4.X);
				Math.Max(vector3.Z, vector4.Z);
				Math.Min(vector3.Z, vector4.Z);
				this.mesh_0 = new Mesh(device_0, 12, 36, MeshFlags.Managed, Class112.Struct7.VertexElements);
				Vector3 position = new Vector3(vector3.X, vector3.Y, vector3.Z);
				Vector3 position2 = new Vector3(vector3.X, vector4.Y, vector3.Z);
				Vector3 position3 = new Vector3(vector3.X, vector4.Y, vector4.Z);
				Vector3 position4 = new Vector3(vector3.X, vector3.Y, vector4.Z);
				Vector3 position5 = new Vector3(vector4.X, vector3.Y, vector3.Z);
				Vector3 position6 = new Vector3(vector4.X, vector4.Y, vector3.Z);
				Vector3 position7 = new Vector3(vector4.X, vector4.Y, vector4.Z);
				Vector3 position8 = new Vector3(vector4.X, vector3.Y, vector4.Z);
				Class112.Struct7* ptr = (Class112.Struct7*)((void*)this.mesh_0.LockVertexBuffer(LockFlags.None).DataPointer);
				short* ptr2 = (short*)((void*)this.mesh_0.LockIndexBuffer(LockFlags.None).DataPointer);
				ptr[0].position = position;
				ptr[1].position = position2;
				ptr[2].position = position3;
				ptr[3].position = position3;
				ptr[4].position = position4;
				ptr[5].position = position;
				ptr[6].position = position5;
				ptr[7].position = position6;
				ptr[8].position = position;
				ptr[9].position = position6;
				ptr[10].position = position2;
				ptr[11].position = position;
				ptr[12].position = position8;
				ptr[13].position = position7;
				ptr[14].position = position6;
				ptr[15].position = position6;
				ptr[16].position = position5;
				ptr[17].position = position8;
				ptr[18].position = position4;
				ptr[19].position = position3;
				ptr[20].position = position7;
				ptr[21].position = position4;
				ptr[22].position = position7;
				ptr[23].position = position8;
				ptr[24].position = position3;
				ptr[25].position = position2;
				ptr[26].position = position6;
				ptr[27].position = position3;
				ptr[28].position = position6;
				ptr[29].position = position7;
				ptr[30].position = position;
				ptr[31].position = position4;
				ptr[32].position = position5;
				ptr[33].position = position4;
				ptr[34].position = position8;
				ptr[35].position = position5;
				for (int i = 0; i < 36; i++)
				{
					ptr2[i] = (short)i;
				}
				this.mesh_0.UnlockIndexBuffer();
				this.mesh_0.UnlockVertexBuffer();
				Class112.Struct7[] array = new Class112.Struct7[2];
				array[0] = default(Class112.Struct7);
				array[0].position = new Vector3(this.lite.Floats[0], this.lite.Floats[1], this.lite.Floats[2]);
				array[1].position = new Vector3(this.lite.Floats[0] + this.lite.Floats[3], this.lite.Floats[1] + this.lite.Floats[4], this.lite.Floats[2] + this.lite.Floats[5]);
				DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
				dataStream.WriteRange<Class112.Struct7>(array);
				this.vertexBuffer_0.Unlock();
			}
			else if (this.uint_0 == 4U)
			{
				this.mesh_0 = Mesh.CreateSphere(device_0, 0.05f, 24, 24);
			}
			else if (this.uint_0 == 3U)
			{
				this.mesh_0 = Mesh.CreateSphere(device_0, 0.05f, 24, 24);
			}
			else if (this.uint_0 == 7U)
			{
				this.mesh_0 = Mesh.CreateBox(device_0, this.lite.Floats[13], this.lite.Floats[14], 0.1f);
			}
			else if (this.uint_0 == 9U)
			{
				this.mesh_0 = Mesh.CreateBox(device_0, this.lite.Floats[13], this.lite.Floats[14], 0.1f);
			}
			else
			{
				this.mesh_0 = Mesh.CreateSphere(device_0, 0.05f, 24, 24);
			}
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x00095100 File Offset: 0x00093300
		public void method_2(Device device_0, Matrix matrix_2)
		{
			if (this.Visible)
			{
				device_0.Material = this.material_0;
				device_0.SetTexture(0, null);
				device_0.SetTexture(1, null);
				Matrix identity = Matrix.Identity;
				Matrix matrix = identity;
				matrix.Invert();
				Class140.smethod_0().method_9(RenderState.Lighting, true);
				Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, false);
				Class140.smethod_0().method_9(RenderState.ZEnable, true);
				Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
				Class140.smethod_0().method_9(RenderState.Lighting, false);
				Class140.smethod_0().method_10();
				if (this.uint_0 != 4U)
				{
					if (this.uint_0 != 5U)
					{
						Class140.smethod_0().method_32(Matrix.Translation(this.vector3_0) * matrix_2, Class132.smethod_0().ViewMatrix);
						Class140.smethod_0().method_9(RenderState.Lighting, false);
						if (this.uint_0 == 1U)
						{
							Class140.smethod_0().method_40("OccluderLight");
						}
						else
						{
							Class140.smethod_0().method_40("LineLight");
						}
						int num = Class140.smethod_0().method_36();
						for (int i = 0; i < num; i++)
						{
							Class140.smethod_0().method_38(i);
							this.mesh_0.DrawSubset(0);
							Class140.smethod_0().method_39();
						}
						Class140.smethod_0().method_37();
						Class140.smethod_0().method_40("LineLight");
						num = Class140.smethod_0().method_36();
						for (int j = 0; j < num; j++)
						{
							Class140.smethod_0().method_38(j);
							Class140.smethod_0().Device.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
							Class140.smethod_0().Device.DrawPrimitives(PrimitiveType.LineStrip, 0, 1);
							Class140.smethod_0().method_39();
						}
						Class140.smethod_0().method_37();
						if (this.lite.Floats[12] != 0f)
						{
							Vector3 amount = new Vector3((this.lite.Floats[3] != 0f) ? (this.lite.Floats[12] * this.lite.Floats[3]) : 0f, (this.lite.Floats[4] != 0f) ? (this.lite.Floats[12] * this.lite.Floats[4]) : 0f, (this.lite.Floats[5] != 0f) ? (this.lite.Floats[12] * this.lite.Floats[5]) : 0f);
							Class140.smethod_0().method_32(Matrix.Translation(amount) * matrix_2, Class132.smethod_0().ViewMatrix);
							num = Class140.smethod_0().method_36();
							for (int k = 0; k < num; k++)
							{
								Class140.smethod_0().method_38(k);
								Class140.smethod_0().method_39();
							}
							Class140.smethod_0().method_37();
							Class140.smethod_0().method_32(Matrix.Translation(this.vector3_0) * matrix_2, Class132.smethod_0().ViewMatrix);
							goto IL_4C9;
						}
						goto IL_4C9;
					}
				}
				Class140.smethod_0().method_32(identity * this.matrix_0 * Matrix.Translation(this.vector3_0) * matrix_2, Class132.smethod_0().ViewMatrix);
				Class140.smethod_0().method_40("PointLight");
				int num2 = Class140.smethod_0().method_36();
				for (int l = 0; l < num2; l++)
				{
					Class140.smethod_0().method_38(l);
					device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
					device_0.SetStreamSource(0, this.vertexBuffer_0, this.int_1 * 2 * Class112.Struct7.SizeInBytes, Class112.Struct7.SizeInBytes);
					device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, this.int_2);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				Class140.smethod_0().method_40("LineLight");
				num2 = Class140.smethod_0().method_36();
				for (int m = 0; m < num2; m++)
				{
					Class140.smethod_0().method_38(m);
					device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
					device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
					device_0.DrawPrimitives(PrimitiveType.LineList, 0, this.int_1);
					Class140.smethod_0().method_32(Matrix.Translation(this.vector3_1) * matrix_2, Class132.smethod_0().ViewMatrix);
					this.mesh_1.DrawSubset(0);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				Class140.smethod_0().method_32(matrix_2, Class132.smethod_0().ViewMatrix);
				IL_4C9:
				Class140.smethod_0().method_10();
			}
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x00006CFB File Offset: 0x00004EFB
		public void method_3(bool bool_1)
		{
			if (bool_1)
			{
				this.vertexBuffer_0.Dispose();
				this.mesh_0.Dispose();
				this.mesh_1.Dispose();
			}
		}

		// Token: 0x0400091C RID: 2332
		private Mesh mesh_0;

		// Token: 0x0400091D RID: 2333
		private Mesh mesh_1;

		// Token: 0x0400091E RID: 2334
		public Vector3 vector3_0;

		// Token: 0x0400091F RID: 2335
		public Vector3 vector3_1;

		// Token: 0x04000920 RID: 2336
		public Vector3 vector3_2;

		// Token: 0x04000921 RID: 2337
		public Matrix matrix_0;

		// Token: 0x04000922 RID: 2338
		private Material material_0;

		// Token: 0x04000923 RID: 2339
		private Material material_1;

		// Token: 0x04000924 RID: 2340
		private VertexBuffer vertexBuffer_0;

		// Token: 0x04000925 RID: 2341
		public float float_0;

		// Token: 0x04000926 RID: 2342
		public float float_1;

		// Token: 0x04000927 RID: 2343
		public float float_2;

		// Token: 0x04000928 RID: 2344
		private int int_0;

		// Token: 0x04000929 RID: 2345
		private int int_1;

		// Token: 0x0400092A RID: 2346
		private int int_2;

		// Token: 0x0400092B RID: 2347
		private LITE.LightEntry lite;

		// Token: 0x0400092C RID: 2348
		private uint uint_0;

		// Token: 0x0400092D RID: 2349
		private Class112.Struct7[] struct7_0;

		// Token: 0x0400092E RID: 2350
		public Matrix matrix_1;

		// Token: 0x0400092F RID: 2351
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000930 RID: 2352
		[CompilerGenerated]
		private ResKey resKey_0;
	}
}
