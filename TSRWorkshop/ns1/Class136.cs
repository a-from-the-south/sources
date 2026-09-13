using System;
using System.Collections.Generic;
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
using ns9;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns1
{
	// Token: 0x02000122 RID: 290
	internal sealed class Class136 : Class133, EditorToolBox.Interface0
	{
		// Token: 0x06000D18 RID: 3352 RVA: 0x000A48BC File Offset: 0x000A2ABC
		private Class136(Device device)
		{
			this.rotateControl_0 = new RotateControl();
			this.vertexBuffer_0 = new VertexBuffer(device, (int)(this.float_0 * 6f) * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x000A4910 File Offset: 0x000A2B10
		public static Class136 smethod_0()
		{
			if (Class136.class136_0 == null)
			{
				Class136.class136_0 = new Class136(Class132.smethod_0().Device);
			}
			return Class136.class136_0;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x000A4944 File Offset: 0x000A2B44
		public override void imethod_4()
		{
			base.imethod_4();
			this.rotateControl_0.Parent = EditorToolBox.smethod_0().Container;
			this.rotateControl_0.Dock = DockStyle.Fill;
			this.rotateControl_0.SendToBack();
			this.rotateControl_0.Visible = true;
			this.method_1();
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x000A4998 File Offset: 0x000A2B98
		private unsafe void method_1()
		{
			Vector3 left = Vector3.Zero;
			Vector3 minimum = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 maximum = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			int num = 0;
			float num2 = 0f;
			float num3 = 0f;
			this.float_6 = num2;
			float num4 = num3;
			float num5 = 0f;
			this.float_5 = num4;
			float num6 = num5;
			float num7 = 0f;
			this.float_4 = num6;
			float num8 = num7;
			float num9 = 0f;
			this.float_3 = num8;
			float num10 = num9;
			float num11 = 0f;
			this.float_2 = num10;
			this.float_1 = num11;
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
			Math.Max(vector.X, Math.Max(vector.Y, vector.Z));
			DataStream dataStream3 = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
			Class112.Struct7* ptr2 = (Class112.Struct7*)((void*)dataStream3.DataPointer);
			int num12 = 0;
			while ((float)num12 < this.float_0 * 6f)
			{
				ptr2[num12].position = Vector3.Zero;
				num12++;
			}
			double num13 = 6.283185307179586 / (double)this.float_0;
			for (float num14 = 0f; num14 < this.float_0 - 2f; num14 += 1f)
			{
				double num15 = 6.283185307179586 * (double)(num14 / this.float_0) + num13;
				double num16 = 6.283185307179586 * (double)((num14 + 1f) / this.float_0) + num13;
				float x = (float)Math.Cos(num15);
				float z = (float)Math.Sin(num15);
				float x2 = (float)Math.Cos(num16);
				float z2 = (float)Math.Sin(num16);
				ptr2[(int)(num14 * 6f)].position = new Vector3(x, -0.05f, z);
				ptr2[(int)(num14 * 6f) + 1].position = new Vector3(x, 0.05f, z);
				ptr2[(int)(num14 * 6f) + 2].position = new Vector3(x2, 0.05f, z2);
				ptr2[(int)(num14 * 6f) + 3].position = new Vector3(x2, -0.05f, z2);
				ptr2[(int)(num14 * 6f) + 4].position = new Vector3(x, -0.05f, z);
				ptr2[(int)(num14 * 6f) + 5].position = new Vector3(x2, 0.05f, z2);
			}
			float x3 = (float)Math.Cos(-num13);
			float z3 = (float)Math.Sin(-num13);
			float x4 = (float)Math.Cos(0.0);
			float z4 = (float)Math.Sin(0.0);
			float x5 = (float)Math.Cos(num13);
			float z5 = (float)Math.Sin(num13);
			ptr2[(int)((this.float_0 - 1f) * 6f)].position = new Vector3(x3, -0.1f, z3);
			ptr2[(int)((this.float_0 - 1f) * 6f) + 1].position = new Vector3(x4, 0f, z4);
			ptr2[(int)((this.float_0 - 1f) * 6f) + 2].position = new Vector3(x3, 0.1f, z3);
			ptr2[(int)((this.float_0 - 1f) * 6f) + 3].position = new Vector3(x5, -0.1f, z5);
			ptr2[(int)((this.float_0 - 1f) * 6f) + 4].position = new Vector3(x4, 0f, z4);
			ptr2[(int)((this.float_0 - 1f) * 6f) + 5].position = new Vector3(x5, 0.1f, z5);
			this.vertexBuffer_0.Unlock();
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x0000740B File Offset: 0x0000560B
		public override void imethod_5()
		{
			base.imethod_5();
			this.rotateControl_0.Visible = false;
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x00007421 File Offset: 0x00005621
		public override void vmethod_0(bool bool_6)
		{
			base.vmethod_0(bool_6);
			if (bool_6)
			{
				this.vertexBuffer_0.Dispose();
			}
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x000A5058 File Offset: 0x000A3258
		public bool imethod_0(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			this.bool_2 = false;
			this.bool_1 = false;
			this.bool_0 = false;
			return false;
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x000A5084 File Offset: 0x000A3284
		public unsafe bool imethod_1(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			this.point_0.X = mouseEventArgs_0.X;
			this.point_0.Y = mouseEventArgs_0.Y;
			if ((Control.ModifierKeys & Keys.Shift) != Keys.None)
			{
				this.float_1 = 0f;
				this.float_2 = 0f;
				this.float_3 = 0f;
			}
			bool result;
			if ((mouseEventArgs_0.Button == MouseButtons.Left || mouseEventArgs_0.Button == MouseButtons.Right) && (Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				Vector3 vector = this.boundingBox_0.Maximum - this.boundingBox_0.Minimum;
				float num = Math.Max(vector.X, Math.Max(vector.Y, vector.Z));
				Matrix right = Matrix.Scaling(num, num, num) * Matrix.Translation(this.vector3_0);
				Matrix left = Matrix.RotationY(this.float_1) * Matrix.RotationZ(1.5707964f) * right;
				Matrix left2 = Matrix.RotationY(this.float_2) * right;
				Matrix left3 = Matrix.RotationY(this.float_3) * Matrix.RotationX(1.5707964f) * right;
				Vector3 vector2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 vector3 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 vector4 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left2 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 vector5 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left2 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 vector6 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left3 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 vector7 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left3 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
				Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
				for (float num2 = 0f; num2 < this.float_0; num2 += 1f)
				{
					float val = 0f;
					float val2 = 0f;
					float val3 = 0f;
					float val4 = 0f;
					float val5 = 0f;
					float val6 = 0f;
					if (!Ray.Intersects(new Ray(vector2, vector3), ptr[(int)(num2 * 6f)].position, ptr[(int)(num2 * 6f) + 1].position, ptr[(int)(num2 * 6f) + 2].position, out val) && !Ray.Intersects(new Ray(vector2, vector3), ptr[(int)(num2 * 6f) + 3].position, ptr[(int)(num2 * 6f) + 4].position, ptr[(int)(num2 * 6f) + 5].position, out val2))
					{
						if (!Ray.Intersects(new Ray(vector4, vector5), ptr[(int)(num2 * 6f)].position, ptr[(int)(num2 * 6f) + 1].position, ptr[(int)(num2 * 6f) + 2].position, out val3) && !Ray.Intersects(new Ray(vector4, vector5), ptr[(int)(num2 * 6f) + 3].position, ptr[(int)(num2 * 6f) + 4].position, ptr[(int)(num2 * 6f) + 5].position, out val4))
						{
							if (Ray.Intersects(new Ray(vector6, vector7), ptr[(int)(num2 * 6f)].position, ptr[(int)(num2 * 6f) + 1].position, ptr[(int)(num2 * 6f) + 2].position, out val5) || Ray.Intersects(new Ray(vector6, vector7), ptr[(int)(num2 * 6f) + 3].position, ptr[(int)(num2 * 6f) + 4].position, ptr[(int)(num2 * 6f) + 5].position, out val6))
							{
								float num3 = Vector3.Distance(vector6, vector7);
								float amount = Math.Max(val5, val6) * num3 / num3;
								this.vector3_1 = Vector3.Lerp(vector6, vector7, amount);
								this.bool_2 = true;
							}
						}
						else
						{
							float num4 = Vector3.Distance(vector4, vector5);
							float amount2 = Math.Max(val3, val4) * num4 / num4;
							this.vector3_1 = Vector3.Lerp(vector4, vector5, amount2);
							this.bool_1 = true;
						}
					}
					else
					{
						float num5 = Vector3.Distance(vector2, vector3);
						float amount3 = Math.Max(val, val2) * num5 / num5;
						this.vector3_1 = Vector3.Lerp(vector2, vector3, amount3);
						this.bool_0 = true;
					}
					if (this.bool_0 || this.bool_1 || this.bool_2)
					{
						break;
					}
				}
				this.vertexBuffer_0.Unlock();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x000A5800 File Offset: 0x000A3A00
		public unsafe bool imethod_2(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			this.bool_5 = false;
			this.bool_4 = false;
			this.bool_3 = false;
			bool result;
			if ((Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				Vector3 vector = this.boundingBox_0.Maximum - this.boundingBox_0.Minimum;
				float num = Math.Max(vector.X, Math.Max(vector.Y, vector.Z));
				Matrix matrix = Matrix.Scaling(num, num, num) * Matrix.Translation(this.vector3_0);
				if (!this.bool_0 && !this.bool_1 && !this.bool_2)
				{
					matrix = Matrix.Scaling(num, num, num) * Matrix.Translation(this.vector3_0);
					Matrix left = Matrix.RotationZ(1.5707964f) * matrix;
					Matrix left2 = matrix;
					Matrix left3 = Matrix.RotationX(1.5707964f) * matrix;
					Vector3 position = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 direction = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 position2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left2 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 direction2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left2 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 position3 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left3 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 direction3 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left3 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
					Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
					for (float num2 = 0f; num2 < this.float_0; num2 += 1f)
					{
						float num3 = 0f;
						float num4 = 0f;
						float num5 = 0f;
						float num6 = 0f;
						float num7 = 0f;
						float num8 = 0f;
						if (!Ray.Intersects(new Ray(position, direction), ptr[(int)(num2 * 6f)].position, ptr[(int)(num2 * 6f) + 1].position, ptr[(int)(num2 * 6f) + 2].position, out num3) && !Ray.Intersects(new Ray(position, direction), ptr[(int)(num2 * 6f) + 3].position, ptr[(int)(num2 * 6f) + 4].position, ptr[(int)(num2 * 6f) + 5].position, out num4))
						{
							if (!Ray.Intersects(new Ray(position2, direction2), ptr[(int)(num2 * 6f)].position, ptr[(int)(num2 * 6f) + 1].position, ptr[(int)(num2 * 6f) + 2].position, out num5) && !Ray.Intersects(new Ray(position2, direction2), ptr[(int)(num2 * 6f) + 3].position, ptr[(int)(num2 * 6f) + 4].position, ptr[(int)(num2 * 6f) + 5].position, out num6))
							{
								if (Ray.Intersects(new Ray(position3, direction3), ptr[(int)(num2 * 6f)].position, ptr[(int)(num2 * 6f) + 1].position, ptr[(int)(num2 * 6f) + 2].position, out num7) || Ray.Intersects(new Ray(position3, direction3), ptr[(int)(num2 * 6f) + 3].position, ptr[(int)(num2 * 6f) + 4].position, ptr[(int)(num2 * 6f) + 5].position, out num8))
								{
									this.bool_5 = true;
								}
							}
							else
							{
								this.bool_4 = true;
							}
						}
						else
						{
							this.bool_3 = true;
						}
						if (this.bool_5 || this.bool_3 || this.bool_4)
						{
							break;
						}
					}
					this.vertexBuffer_0.Unlock();
					result = true;
				}
				else
				{
					Matrix left4 = Matrix.RotationY(this.float_1) * Matrix.RotationZ(1.5707964f) * matrix;
					Matrix left5 = Matrix.RotationY(this.float_2) * matrix;
					Matrix left6 = Matrix.RotationY(this.float_3) * Matrix.RotationX(1.5707964f) * matrix;
					Vector3 vector2 = Vector3.Project(this.vector3_1, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left4 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 vector3 = Vector3.Project(this.vector3_1, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left5 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					Vector3 vector4 = Vector3.Project(this.vector3_1, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left6 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
					float num9 = Vector2.Distance(new Vector2((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y), new Vector2(vector2.X, vector2.Y));
					float num10 = Vector2.Distance(new Vector2((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y), new Vector2(vector3.X, vector3.Y));
					float num11 = Vector2.Distance(new Vector2((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y), new Vector2(vector4.X, vector4.Y));
					bool flag = true;
					int num12 = 0;
					bool flag2 = true;
					while (flag && num12 < 2)
					{
						if (this.bool_0)
						{
							this.float_1 += (flag2 ? 0.0001f : -0.0001f);
							Matrix left7 = Matrix.RotationY(this.float_1) * Matrix.RotationZ(1.5707964f) * matrix;
							Vector3 vector5 = Vector3.Project(this.vector3_1, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left7 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
							float num13 = Vector2.Distance(new Vector2((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y), new Vector2(vector5.X, vector5.Y));
							if (num13 > num9)
							{
								flag2 = !flag2;
								num12++;
							}
							num9 = num13;
						}
						else if (this.bool_1)
						{
							this.float_2 += (flag2 ? 0.0001f : -0.0001f);
							Matrix left8 = Matrix.RotationY(this.float_2) * matrix;
							Vector3 vector6 = Vector3.Project(this.vector3_1, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left8 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
							float num14 = Vector2.Distance(new Vector2((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y), new Vector2(vector6.X, vector6.Y));
							if (num14 > num10)
							{
								flag2 = !flag2;
								num12++;
							}
							num10 = num14;
						}
						else if (this.bool_2)
						{
							this.float_3 += (flag2 ? 0.0001f : -0.0001f);
							Matrix left9 = Matrix.RotationY(this.float_3) * Matrix.RotationX(1.5707964f) * matrix;
							Vector3 vector7 = Vector3.Project(this.vector3_1, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, left9 * meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
							float num15 = Vector2.Distance(new Vector2((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y), new Vector2(vector7.X, vector7.Y));
							if (num15 > num11)
							{
								flag2 = !flag2;
								num12++;
							}
							num11 = num15;
						}
					}
					Console.WriteLine(string.Concat(new object[]
					{
						this.float_1,
						",",
						this.float_2,
						",",
						this.float_3
					}));
					List<Class102> renderables = Class132.smethod_0().Renderables;
					Matrix transformation = Matrix.Translation(this.vector3_0);
					Matrix transformation2 = Matrix.Translation(this.vector3_0);
					transformation2.Invert();
					foreach (Interface9 @interface in Class132.smethod_0().method_45())
					{
						if (@interface is Class121 && @interface.CurrentSelectionIndex.Count > 0)
						{
							MLOD.MLODEntry mlodentry = (@interface as Class121).MLODEntry;
							RCOL parent = mlodentry.Parent.Parent;
							RCOLItem rcolitem = parent.Entries[(@interface as Class121).MLODEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)];
							DataStream dataStream2 = @interface.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
							Class112.Struct7* ptr2 = (Class112.Struct7*)((void*)dataStream2.DataPointer);
							DataStream dataStream3 = @interface.VertexBuffer.Lock(0, 0, LockFlags.None);
							Class112.Struct7* ptr3 = (Class112.Struct7*)((void*)dataStream3.DataPointer);
							foreach (Class102.Class107 @class in @interface.CurrentSelectionIndex)
							{
								Vector3 vector8 = ptr2[@class.short_0].position;
								Vector3 vector9 = ptr2[@class.short_0].normal;
								vector8 = Vector3.TransformCoordinate(vector8, transformation2);
								vector9 = Vector3.TransformCoordinate(vector9, transformation2);
								if (this.bool_0)
								{
									vector8 = Vector3.TransformCoordinate(vector8, Matrix.RotationX(-(this.float_1 - this.float_4)));
									vector9 = Vector3.TransformCoordinate(vector9, Matrix.RotationX(-(this.float_1 - this.float_4)));
								}
								if (this.bool_1)
								{
									vector8 = Vector3.TransformCoordinate(vector8, Matrix.RotationY(this.float_2 - this.float_5));
									vector9 = Vector3.TransformCoordinate(vector9, Matrix.RotationY(this.float_2 - this.float_5));
								}
								if (this.bool_2)
								{
									vector8 = Vector3.TransformCoordinate(vector8, Matrix.RotationZ(this.float_3 - this.float_6));
									vector9 = Vector3.TransformCoordinate(vector9, Matrix.RotationZ(this.float_3 - this.float_6));
								}
								vector8 = Vector3.TransformCoordinate(vector8, transformation);
								vector9 = Vector3.TransformCoordinate(vector9, transformation);
								ptr2[@class.short_0].position = (ptr3[@class.short_0].position = vector8);
								ptr2[@class.short_0].normal = (ptr3[@class.short_0].normal = vector9);
							}
							@interface.VertexBufferTransformed.Unlock();
							@interface.VertexBuffer.Unlock();
						}
					}
					this.float_4 = this.float_1;
					this.float_5 = this.float_2;
					this.float_6 = this.float_3;
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x000A66EC File Offset: 0x000A48EC
		public void imethod_3(MeshEditor meshEditor_0, Device device_0, Matrix matrix_0)
		{
			Vector3 vector = this.boundingBox_0.Maximum - this.boundingBox_0.Minimum;
			float num = Math.Max(vector.X, Math.Max(vector.Y, vector.Z));
			Matrix matrix = Matrix.Scaling(num, num, num) * Matrix.Translation(this.vector3_0);
			base.vmethod_5(meshEditor_0, device_0, matrix_0);
			Class140.smethod_0().method_27("isSkinned", false);
			Class140.smethod_0().method_28("g_forcedTransparency", 1f);
			Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
			device_0.SetTexture(0, null);
			device_0.SetTexture(1, null);
			device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
			device_0.SetTransform(TransformState.World, matrix * matrix_0);
			Class140.smethod_0().method_9(RenderState.Lighting, false);
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
			Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
			Class140.smethod_0().method_40("FlatShade");
			Class140.smethod_0().method_35();
			int num2 = Class140.smethod_0().method_36();
			for (int i = 0; i < num2; i++)
			{
				Class140.smethod_0().method_38(i);
				Class140.smethod_0().method_22("g_ambient", new Vector4(1f, 0f, 0f, (this.bool_3 || this.bool_0) ? 0.9f : 0.7f));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_32(Matrix.RotationY(this.float_1) * Matrix.RotationZ(1.5707964f) * matrix * matrix_0, Class132.smethod_0().ViewMatrix);
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
				device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, (int)this.float_0 * 2);
				Class140.smethod_0().method_22("g_ambient", new Vector4(0f, 1f, 0f, (this.bool_4 || this.bool_1) ? 0.9f : 0.7f));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_32(Matrix.RotationY(this.float_2) * matrix * matrix_0, Class132.smethod_0().ViewMatrix);
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
				device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, (int)this.float_0 * 2);
				Class140.smethod_0().method_22("g_ambient", new Vector4(0f, 0f, 1f, (this.bool_5 || this.bool_2) ? 0.9f : 0.7f));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_32(Matrix.RotationY(this.float_3) * Matrix.RotationX(1.5707964f) * matrix * matrix_0, Class132.smethod_0().ViewMatrix);
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
				device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, (int)this.float_0 * 2);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
		}

		// Token: 0x040009EA RID: 2538
		private RotateControl rotateControl_0;

		// Token: 0x040009EB RID: 2539
		private VertexBuffer vertexBuffer_0;

		// Token: 0x040009EC RID: 2540
		private Vector3 vector3_0;

		// Token: 0x040009ED RID: 2541
		private BoundingBox boundingBox_0;

		// Token: 0x040009EE RID: 2542
		private bool bool_0;

		// Token: 0x040009EF RID: 2543
		private bool bool_1;

		// Token: 0x040009F0 RID: 2544
		private bool bool_2;

		// Token: 0x040009F1 RID: 2545
		private bool bool_3;

		// Token: 0x040009F2 RID: 2546
		private bool bool_4;

		// Token: 0x040009F3 RID: 2547
		private bool bool_5;

		// Token: 0x040009F4 RID: 2548
		private float float_0 = 32f;

		// Token: 0x040009F5 RID: 2549
		private float float_1;

		// Token: 0x040009F6 RID: 2550
		private float float_2;

		// Token: 0x040009F7 RID: 2551
		private float float_3;

		// Token: 0x040009F8 RID: 2552
		private static Class136 class136_0;

		// Token: 0x040009F9 RID: 2553
		private Point point_0;

		// Token: 0x040009FA RID: 2554
		private Vector3 vector3_1;

		// Token: 0x040009FB RID: 2555
		private float float_4;

		// Token: 0x040009FC RID: 2556
		private float float_5;

		// Token: 0x040009FD RID: 2557
		private float float_6;
	}
}
