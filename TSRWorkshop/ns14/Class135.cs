using System;
using System.Drawing;
using System.Windows.Forms;
using ns10;
using ns12;
using ns13;
using ns16;
using ns2;
using ns21;
using ns6;
using ns8;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns14
{
	// Token: 0x02000121 RID: 289
	internal sealed class Class135 : Class133, EditorToolBox.Interface0
	{
		// Token: 0x06000D0E RID: 3342 RVA: 0x000A30C0 File Offset: 0x000A12C0
		private Class135(Device device)
		{
			this.moveControl_0 = new MoveControl();
			this.mesh_0 = Mesh.CreateBox(device, 1f, 1f, 1f);
			this.mesh_1 = Mesh.CreateCylinder(device, 0.01f, 0.001f, 0.035f, 12, 12);
			this.mesh_2 = Mesh.CreateCylinder(device, 0.01f, 0.001f, 0.035f, 12, 12);
			this.mesh_3 = Mesh.CreateCylinder(device, 0.01f, 0.001f, 0.035f, 12, 12);
			this.vertexBuffer_0 = new VertexBuffer(device, 30 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x000A3174 File Offset: 0x000A1374
		public static Class135 smethod_0()
		{
			if (Class135.class135_0 == null)
			{
				Class135.class135_0 = new Class135(Class132.smethod_0().Device);
			}
			return Class135.class135_0;
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x000A31A8 File Offset: 0x000A13A8
		public override void imethod_4()
		{
			base.imethod_4();
			this.moveControl_0.Parent = EditorToolBox.smethod_0().Container;
			this.moveControl_0.Dock = DockStyle.Fill;
			this.moveControl_0.SendToBack();
			this.moveControl_0.Visible = true;
			this.method_1();
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x000A31FC File Offset: 0x000A13FC
		private unsafe void method_1()
		{
			Vector3 left = Vector3.Zero;
			Vector3 minimum = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 maximum = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			int num = 0;
			foreach (Interface9 @interface in Class132.smethod_0().method_45())
			{
				if (@interface is Class121 && @interface.CurrentSelectionIndex.Count > 0)
				{
					MLOD.MLODEntry mlodentry = (@interface as Class121).MLODEntry;
					RCOL parent = mlodentry.Parent.Parent;
					if (!(parent.Entries[mlodentry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] is VRTF))
					{
						VRTF defaultForLength = VRTF.GetDefaultForLength((mlodentry.Type == 20483U) ? 8 : 16);
					}
					RCOLItem rcolitem = parent.Entries[(@interface as Class121).MLODEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)];
					DataStream dataStream = @interface.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
					(void*)dataStream.DataPointer;
					DataStream dataStream2 = @interface.VertexBuffer.Lock(0, 0, LockFlags.None);
					Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream2.DataPointer);
					foreach (Class102.Class107 @class in @interface.CurrentSelectionIndex)
					{
						Vector3 position = ptr[@class.short_0].position;
						left += position;
						minimum.X = Math.Min(minimum.X, position.X);
						minimum.Y = Math.Min(minimum.Y, position.Y);
						minimum.Z = Math.Min(minimum.Z, position.Z);
						maximum.X = Math.Max(maximum.X, position.X);
						maximum.Y = Math.Max(maximum.Y, position.Y);
						maximum.Z = Math.Max(maximum.Z, position.Z);
					}
					num += @interface.CurrentSelectionIndex.Count;
					@interface.VertexBuffer.Unlock();
					@interface.VertexBufferTransformed.Unlock();
				}
			}
			left = (this.boundingBox_0.Maximum + this.boundingBox_0.Minimum) / 2f;
			this.vector3_0 = left;
			this.boundingBox_0 = new BoundingBox(minimum, maximum);
			Vector3 vector = this.boundingBox_0.Maximum - this.boundingBox_0.Minimum;
			float num2 = Math.Max(vector.X, Math.Max(vector.Y, vector.Z));
			DataStream dataStream3 = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
			Class112.Struct7* ptr2 = (Class112.Struct7*)((void*)dataStream3.DataPointer);
			ptr2->position = Vector3.Zero;
			ptr2[1].position = new Vector3(0f, 0f, num2 + 0.1f);
			ptr2[2].position = Vector3.Zero;
			ptr2[3].position = new Vector3(0f, 0f, num2 + 0.1f);
			ptr2[4].position = Vector3.Zero;
			ptr2[5].position = new Vector3(0f, 0f, num2 + 0.1f);
			ptr2[6].position = new Vector3(-0.5f, -0.5f, -0.5f);
			ptr2[7].position = new Vector3(0.5f, -0.5f, -0.5f);
			ptr2[8].position = new Vector3(0.5f, -0.5f, -0.5f);
			ptr2[9].position = new Vector3(0.5f, -0.5f, 0.5f);
			ptr2[10].position = new Vector3(0.5f, -0.5f, 0.5f);
			ptr2[11].position = new Vector3(-0.5f, -0.5f, 0.5f);
			ptr2[12].position = new Vector3(-0.5f, -0.5f, 0.5f);
			ptr2[13].position = new Vector3(-0.5f, -0.5f, -0.5f);
			ptr2[14].position = new Vector3(-0.5f, 0.5f, -0.5f);
			ptr2[15].position = new Vector3(0.5f, 0.5f, -0.5f);
			ptr2[16].position = new Vector3(0.5f, 0.5f, -0.5f);
			ptr2[17].position = new Vector3(0.5f, 0.5f, 0.5f);
			ptr2[18].position = new Vector3(0.5f, 0.5f, 0.5f);
			ptr2[19].position = new Vector3(-0.5f, 0.5f, 0.5f);
			ptr2[20].position = new Vector3(-0.5f, 0.5f, 0.5f);
			ptr2[21].position = new Vector3(-0.5f, 0.5f, -0.5f);
			ptr2[22].position = ptr2[6].position;
			ptr2[23].position = ptr2[14].position;
			ptr2[24].position = ptr2[8].position;
			ptr2[25].position = ptr2[16].position;
			ptr2[26].position = ptr2[10].position;
			ptr2[27].position = ptr2[18].position;
			ptr2[28].position = ptr2[12].position;
			ptr2[29].position = ptr2[20].position;
			this.vertexBuffer_0.Unlock();
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x000073F5 File Offset: 0x000055F5
		public override void imethod_5()
		{
			base.imethod_5();
			this.moveControl_0.Visible = false;
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x000A3950 File Offset: 0x000A1B50
		public override void vmethod_0(bool bool_4)
		{
			base.vmethod_0(bool_4);
			if (bool_4)
			{
				this.mesh_1.Dispose();
				this.mesh_2.Dispose();
				this.mesh_3.Dispose();
				this.vertexBuffer_0.Dispose();
				this.mesh_0.Dispose();
			}
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x000A39A0 File Offset: 0x000A1BA0
		public bool imethod_0(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			this.bool_3 = false;
			return false;
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x000A39BC File Offset: 0x000A1BBC
		public bool imethod_1(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			this.point_0.X = mouseEventArgs_0.X;
			this.point_0.Y = mouseEventArgs_0.Y;
			bool result;
			if ((mouseEventArgs_0.Button == MouseButtons.Left || mouseEventArgs_0.Button == MouseButtons.Right) && (Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				this.bool_2 = false;
				this.bool_1 = false;
				this.bool_0 = false;
				Vector3 vector = this.boundingBox_0.Maximum - this.boundingBox_0.Minimum;
				float num = Math.Max(vector.X, Math.Max(vector.Y, vector.Z));
				Matrix left = Matrix.RotationY(1.5707964f) * Matrix.Translation(this.vector3_0) * Matrix.Translation(num + 0.1f, 0f, 0f);
				Matrix left2 = Matrix.RotationX(1.5707964f) * Matrix.Translation(this.vector3_0) * Matrix.Translation(0f, num + 0.1f, 0f);
				Matrix left3 = Matrix.Translation(this.vector3_0) * Matrix.Translation(0f, 0f, num + 0.1f);
				Vector3 position = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 direction = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 position2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left2 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 direction2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left2 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 position3 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left3 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 direction3 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left3 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				if (this.mesh_1.Intersects(new Ray(position, direction)))
				{
					this.bool_0 = true;
				}
				if (this.mesh_2.Intersects(new Ray(position2, direction2)))
				{
					this.bool_1 = true;
				}
				if (this.mesh_3.Intersects(new Ray(position3, direction3)))
				{
					this.bool_2 = true;
				}
				this.bool_3 = true;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x000A3E1C File Offset: 0x000A201C
		public unsafe bool imethod_2(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			bool result;
			if ((mouseEventArgs_0.Button == MouseButtons.Left || mouseEventArgs_0.Button == MouseButtons.Right) && (Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				if (this.bool_3)
				{
					Vector3 vector = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 vector2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 vector3 = Vector3.Unproject(new Vector3((float)this.point_0.X, (float)this.point_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 vector4 = Vector3.Unproject(new Vector3((float)this.point_0.X, (float)this.point_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 vector5 = vector3 - vector;
					vector4 - vector2;
					foreach (Interface9 @interface in Class132.smethod_0().method_45())
					{
						if (@interface is Class121 && @interface.CurrentSelectionIndex.Count > 0)
						{
							MLOD.MLODEntry mlodentry = (@interface as Class121).MLODEntry;
							RCOL parent = mlodentry.Parent.Parent;
							if (!(parent.Entries[mlodentry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] is VRTF))
							{
								VRTF defaultForLength = VRTF.GetDefaultForLength((mlodentry.Type == 20483U) ? 8 : 16);
							}
							RCOLItem rcolitem = parent.Entries[(@interface as Class121).MLODEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)];
							DataStream dataStream = @interface.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
							Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
							DataStream dataStream2 = @interface.VertexBuffer.Lock(0, 0, LockFlags.None);
							Class112.Struct7* ptr2 = (Class112.Struct7*)((void*)dataStream2.DataPointer);
							Vector3 vector6 = Vector3.Zero;
							foreach (Class102.Class107 @class in @interface.CurrentSelectionIndex)
							{
								vector6 += ptr2[@class.short_0].position;
							}
							vector6 /= (float)@interface.CurrentSelectionIndex.Count;
							float num = Vector3.Distance(vector6, vector3);
							Vector3 left = Vector3.Lerp(vector, vector2, num / Vector3.Distance(vector, vector2));
							Vector3 right = Vector3.Lerp(vector3, vector4, num / Vector3.Distance(vector3, vector4));
							vector5 = left - right;
							foreach (Class102.Class107 class2 in @interface.CurrentSelectionIndex)
							{
								Vector3 position = ptr[class2.short_0].position;
								if (this.moveControl_0.moveX.Checked && !this.bool_2 && !this.bool_1)
								{
									position.X += vector5.X;
								}
								if (this.moveControl_0.moveY.Checked && !this.bool_0 && !this.bool_2)
								{
									position.Y += vector5.Y;
								}
								if (this.moveControl_0.moveZ.Checked && !this.bool_1 && !this.bool_0)
								{
									position.Z += vector5.Z;
								}
								ptr2[class2.short_0].position = (ptr[class2.short_0].position = position);
							}
							@interface.VertexBufferTransformed.Unlock();
							@interface.VertexBuffer.Unlock();
						}
					}
					foreach (Class102 class3 in Class132.smethod_0().Renderables)
					{
						class3.imethod_14();
					}
					this.method_1();
				}
				this.point_0.X = mouseEventArgs_0.X;
				this.point_0.Y = mouseEventArgs_0.Y;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x000A43FC File Offset: 0x000A25FC
		public void imethod_3(MeshEditor meshEditor_0, Device device_0, Matrix matrix_0)
		{
			Vector3 vector = this.boundingBox_0.Maximum - this.boundingBox_0.Minimum;
			float num = Math.Max(vector.X, Math.Max(vector.Y, vector.Z));
			Matrix left = Matrix.Scaling(num, num, num) * Matrix.Translation(this.vector3_0);
			base.vmethod_5(meshEditor_0, device_0, matrix_0);
			Class140.smethod_0().method_27("isSkinned", false);
			Class140.smethod_0().method_28("g_forcedTransparency", 1f);
			Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
			device_0.SetTexture(0, null);
			device_0.SetTexture(1, null);
			device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
			device_0.SetTransform(TransformState.World, left * matrix_0);
			Class140.smethod_0().method_9(RenderState.Lighting, false);
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
			Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
			Class140.smethod_0().method_40("FlatShade");
			Class140.smethod_0().method_35();
			int num2 = Class140.smethod_0().method_36();
			for (int i = 0; i < num2; i++)
			{
				Class140.smethod_0().method_22("g_ambient", new Vector4(0f, 1f, 1f, 0.25f));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_38(i);
				Class140.smethod_0().method_32(left * matrix_0, Class132.smethod_0().ViewMatrix);
				this.mesh_0.DrawSubset(0);
				Class140.smethod_0().method_22("g_ambient", new Vector4(0f, 1f, 1f, 0.6f));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Wireframe);
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
				device_0.DrawPrimitives(PrimitiveType.LineList, 6, 12);
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
				Class140.smethod_0().method_22("g_ambient", new Vector4(1f, 0f, 0f, 0.9f));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_32(Matrix.RotationY(1.5707964f) * Matrix.Translation(this.vector3_0) * matrix_0, Class132.smethod_0().ViewMatrix);
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
				device_0.DrawPrimitives(PrimitiveType.LineList, 0, 1);
				Class140.smethod_0().method_32(Matrix.RotationY(1.5707964f) * Matrix.Translation(this.vector3_0) * Matrix.Translation(num + 0.1f, 0f, 0f) * matrix_0, Class132.smethod_0().ViewMatrix);
				this.mesh_1.DrawSubset(0);
				Class140.smethod_0().method_22("g_ambient", new Vector4(0f, 1f, 0f, 0.9f));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_32(Matrix.RotationX(-1.5707964f) * Matrix.Translation(this.vector3_0) * matrix_0, Class132.smethod_0().ViewMatrix);
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
				device_0.DrawPrimitives(PrimitiveType.LineList, 2, 1);
				Class140.smethod_0().method_32(Matrix.RotationX(-1.5707964f) * Matrix.Translation(this.vector3_0) * Matrix.Translation(0f, num + 0.1f, 0f) * matrix_0, Class132.smethod_0().ViewMatrix);
				this.mesh_2.DrawSubset(0);
				Class140.smethod_0().method_22("g_ambient", new Vector4(0f, 0f, 1f, 0.9f));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_32(Matrix.Translation(this.vector3_0) * matrix_0, Class132.smethod_0().ViewMatrix);
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
				device_0.DrawPrimitives(PrimitiveType.LineList, 4, 1);
				Class140.smethod_0().method_32(Matrix.Translation(this.vector3_0) * Matrix.Translation(0f, 0f, num + 0.1f) * matrix_0, Class132.smethod_0().ViewMatrix);
				this.mesh_3.DrawSubset(0);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
		}

		// Token: 0x040009DC RID: 2524
		private MoveControl moveControl_0;

		// Token: 0x040009DD RID: 2525
		private Mesh mesh_0;

		// Token: 0x040009DE RID: 2526
		private Mesh mesh_1;

		// Token: 0x040009DF RID: 2527
		private Mesh mesh_2;

		// Token: 0x040009E0 RID: 2528
		private Mesh mesh_3;

		// Token: 0x040009E1 RID: 2529
		private Vector3 vector3_0;

		// Token: 0x040009E2 RID: 2530
		private BoundingBox boundingBox_0;

		// Token: 0x040009E3 RID: 2531
		private VertexBuffer vertexBuffer_0;

		// Token: 0x040009E4 RID: 2532
		private bool bool_0;

		// Token: 0x040009E5 RID: 2533
		private bool bool_1;

		// Token: 0x040009E6 RID: 2534
		private bool bool_2;

		// Token: 0x040009E7 RID: 2535
		private static Class135 class135_0;

		// Token: 0x040009E8 RID: 2536
		private Point point_0;

		// Token: 0x040009E9 RID: 2537
		private bool bool_3;
	}
}
