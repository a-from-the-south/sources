using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ns10;
using ns12;
using ns13;
using ns16;
using ns21;
using ns6;
using ns8;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns14
{
	// Token: 0x02000123 RID: 291
	internal sealed class Class137 : Class133, EditorToolBox.Interface0
	{
		// Token: 0x06000D22 RID: 3362 RVA: 0x000A6A48 File Offset: 0x000A4C48
		private Class137(Device device)
		{
			Bitmap bitmap = new Bitmap(32, 32);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawArc(Pens.Red, new Rectangle(0, 0, 32, 32), 0f, 360f);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Bmp);
			memoryStream.Position = 0L;
			this.texture_1 = Texture.FromStream(device, memoryStream, Usage.None, Pool.Managed);
			memoryStream.Dispose();
			bitmap.Dispose();
			graphics.Dispose();
			this.struct6_0 = new Class112.Struct6[2048];
			this.vertexBuffer_0 = new VertexBuffer(device, 2048 * Class112.Struct6.SizeInBytes, Usage.None, Class112.Struct6.vertexFormat_0, Pool.Managed);
			DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct6>(this.struct6_0, 0, 2048);
			this.vertexBuffer_0.Unlock();
			dataStream.Dispose();
			this.selectionControl_0 = new SelectionControl();
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x000A6B44 File Offset: 0x000A4D44
		public static Class137 smethod_0()
		{
			if (Class137.class137_0 == null)
			{
				Class137.class137_0 = new Class137(Class140.smethod_0().Device);
			}
			return Class137.class137_0;
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x000A6B78 File Offset: 0x000A4D78
		public override void imethod_4()
		{
			base.imethod_4();
			this.selectionControl_0.Parent = EditorToolBox.smethod_0().Container;
			this.selectionControl_0.Dock = DockStyle.Fill;
			this.selectionControl_0.SendToBack();
			this.selectionControl_0.Visible = true;
			this.method_1();
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x0000743A File Offset: 0x0000563A
		public override void imethod_5()
		{
			base.imethod_5();
			this.selectionControl_0.Visible = false;
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x00007450 File Offset: 0x00005650
		public override void vmethod_0(bool bool_2)
		{
			base.vmethod_0(bool_2);
			if (bool_2)
			{
				this.vertexBuffer_0.Dispose();
				this.texture_1.Dispose();
			}
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x000A6BCC File Offset: 0x000A4DCC
		private void method_1()
		{
			this.int_1 = 0;
			this.int_2 = 0;
			foreach (Interface9 @interface in Class132.smethod_0().method_45())
			{
				this.int_1 += @interface.VertexCount;
				this.int_2 += @interface.CurrentSelectionIndex.Count;
			}
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x000A6C34 File Offset: 0x000A4E34
		public unsafe bool imethod_0(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			this.bool_0 = false;
			bool result;
			if ((mouseEventArgs_0.Button == MouseButtons.Left || mouseEventArgs_0.Button == MouseButtons.Right) && (Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				if (this.selectionControl_0.rectangularSelection.Checked)
				{
					Interface9[] array = meshEditor_0.method_45();
					Interface9[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						int num = Math.Min(this.point_0.X, this.point_1.X);
						int num2 = Math.Min(this.point_0.Y, this.point_1.Y);
						int num3 = Math.Max(this.point_0.X, this.point_1.X);
						int num4 = Math.Max(this.point_0.Y, this.point_1.Y);
						Rectangle rectangle = new Rectangle(num, num2, num3 - num, num4 - num2);
						foreach (Interface9 @interface in meshEditor_0.method_45())
						{
							DataStream dataStream = @interface.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
							Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
							bool flag = false;
							for (int k = 0; k < @interface.VertexCount; k++)
							{
								Vector3 position = ptr[k].position;
								Vector3 vector = Vector3.Project(position, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
								if (rectangle.Contains(new Point((int)vector.X, (int)vector.Y)))
								{
									Class102.Class107 @class = new Class102.Class107();
									@class.short_1 = (@class.short_2 = (@class.short_0 = (short)k));
									if (!@interface.CurrentSelectionIndex.Contains(@class) && mouseEventArgs_0.Button == MouseButtons.Left)
									{
										flag = true;
										@interface.CurrentSelectionIndex.Add(@class);
									}
									else if (@interface.CurrentSelectionIndex.Contains(@class) && mouseEventArgs_0.Button == MouseButtons.Right)
									{
										@interface.CurrentSelectionIndex.Remove(@class);
										flag = true;
									}
								}
							}
							@interface.VertexBuffer.Unlock();
							if (flag)
							{
								@interface.imethod_3();
							}
						}
					}
					this.struct6_0[0].position = new Vector3(0f, 0f, 0f);
					this.struct6_0[1].position = new Vector3(0f, 0f, 0f);
					this.struct6_0[2].position = new Vector3(0f, 0f, 0f);
					this.struct6_0[3].position = new Vector3(0f, 0f, 0f);
					this.struct6_0[4].position = new Vector3(0f, 0f, 0f);
					DataStream dataStream2 = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
					dataStream2.WriteRange<Class112.Struct6>(this.struct6_0, 0, 5);
					this.vertexBuffer_0.Unlock();
					dataStream2.Dispose();
				}
				this.method_1();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x000A709C File Offset: 0x000A529C
		public unsafe bool imethod_1(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			bool result;
			if ((mouseEventArgs_0.Button == MouseButtons.Left || mouseEventArgs_0.Button == MouseButtons.Right) && (Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				Vector3 value = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				this.point_0 = new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y);
				if (this.selectionControl_0.brushSelection.Checked)
				{
					this.bool_1 = true;
					Interface9[] array = meshEditor_0.method_45();
					for (int i = 0; i < array.Length; i++)
					{
						Rectangle rectangle = new Rectangle(this.point_1.X - 16, this.point_1.Y - 16, 32, 32);
						foreach (Interface9 @interface in meshEditor_0.method_45())
						{
							if ((Control.ModifierKeys & Keys.Shift) == Keys.None)
							{
								@interface.CurrentSelectionIndex.Clear();
							}
							DataStream dataStream = @interface.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
							Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
							for (int k = 0; k < @interface.VertexCount; k++)
							{
								Vector3 position = ptr[k].position;
								Vector3 vector = Vector3.Project(position, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
								float num = Vector2.Distance(new Vector2(vector.X, vector.Y), new Vector2((float)this.point_1.X, (float)this.point_1.Y));
								if (rectangle.Contains(new Point((int)vector.X, (int)vector.Y)))
								{
									Vector3.Distance(value, position);
									Class102.Class107 @class = new Class102.Class107();
									@class.short_1 = (@class.short_2 = (@class.short_0 = (short)k));
									@class.vector3_0.X = 1f - num / 16f;
									if (!@interface.CurrentSelectionIndex.Contains(@class) && mouseEventArgs_0.Button == MouseButtons.Left)
									{
										@interface.CurrentSelectionIndex.Add(@class);
									}
									else if (@interface.CurrentSelectionIndex.Contains(@class) && mouseEventArgs_0.Button == MouseButtons.Right)
									{
										@interface.CurrentSelectionIndex.Remove(@class);
									}
								}
							}
							@interface.VertexBuffer.Unlock();
							@interface.imethod_3();
						}
					}
				}
				else if (this.selectionControl_0.rectangularSelection.Checked)
				{
					Interface9[] array3 = meshEditor_0.method_45();
					Interface9[] array4 = array3;
					for (int l = 0; l < array4.Length; l++)
					{
						foreach (Interface9 interface2 in meshEditor_0.method_45())
						{
							if ((Control.ModifierKeys & Keys.Shift) == Keys.None)
							{
								interface2.CurrentSelectionIndex.Clear();
							}
						}
					}
					this.bool_0 = true;
				}
				this.method_1();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x000A74A0 File Offset: 0x000A56A0
		public unsafe bool imethod_2(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
			Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
			this.point_1.X = mouseEventArgs_0.X;
			this.point_1.Y = mouseEventArgs_0.Y;
			bool result;
			if ((mouseEventArgs_0.Button == MouseButtons.Left || mouseEventArgs_0.Button == MouseButtons.Right) && (Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				if (this.selectionControl_0.rectangularSelection.Checked)
				{
					this.bool_0 = true;
					int num = Math.Min(this.point_0.X, this.point_1.X);
					int num2 = Math.Min(this.point_0.Y, this.point_1.Y);
					int num3 = Math.Max(this.point_0.X, this.point_1.X);
					int num4 = Math.Max(this.point_0.Y, this.point_1.Y);
					this.struct6_0[0].position = new Vector3((float)num, (float)num2, 0f);
					this.struct6_0[1].position = new Vector3((float)num3, (float)num2, 0f);
					this.struct6_0[2].position = new Vector3((float)num3, (float)num4, 0f);
					this.struct6_0[3].position = new Vector3((float)num, (float)num4, 0f);
					this.struct6_0[4].position = new Vector3((float)num, (float)num2, 0f);
					DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
					dataStream.WriteRange<Class112.Struct6>(this.struct6_0, 0, 5);
					this.vertexBuffer_0.Unlock();
					dataStream.Dispose();
				}
				else if (this.selectionControl_0.brushSelection.Checked && this.bool_1)
				{
					Interface9[] array = meshEditor_0.method_45();
					Interface9[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						Rectangle rectangle = new Rectangle(this.point_1.X - 16, this.point_1.Y - 16, 32, 32);
						foreach (Interface9 @interface in meshEditor_0.method_45())
						{
							DataStream dataStream2 = @interface.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
							Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream2.DataPointer);
							bool flag = false;
							for (int k = 0; k < @interface.VertexCount; k++)
							{
								Vector3 position = ptr[k].position;
								Vector3 vector = Vector3.Project(position, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
								if (rectangle.Contains(new Point((int)vector.X, (int)vector.Y)))
								{
									Class102.Class107 @class = new Class102.Class107();
									@class.short_1 = (@class.short_2 = (@class.short_0 = (short)k));
									if (!@interface.CurrentSelectionIndex.Contains(@class) && mouseEventArgs_0.Button == MouseButtons.Left)
									{
										flag = true;
										@interface.CurrentSelectionIndex.Add(@class);
									}
									else if (@interface.CurrentSelectionIndex.Contains(@class) && mouseEventArgs_0.Button == MouseButtons.Right)
									{
										@interface.CurrentSelectionIndex.Remove(@class);
										flag = true;
									}
								}
							}
							@interface.VertexBuffer.Unlock();
							if (flag)
							{
								@interface.imethod_3();
							}
						}
					}
					this.point_0 = new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y);
				}
				this.method_1();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x000A7960 File Offset: 0x000A5B60
		public void imethod_3(MeshEditor meshEditor_0, Device device_0, Matrix matrix_0)
		{
			base.vmethod_5(meshEditor_0, device_0, matrix_0);
			if ((Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				if (this.selectionControl_0.brushSelection.Checked)
				{
					Sprite sprite = new Sprite(device_0);
					sprite.Begin(SpriteFlags.AlphaBlend);
					sprite.Draw(this.texture_1, new Vector3?(new Vector3(16f, 16f, 0f)), new Vector3?(new Vector3((float)this.point_1.X, (float)this.point_1.Y, 0f)), new Color4(Color.White));
					sprite.End();
					sprite.Dispose();
				}
				else if (this.bool_0)
				{
					VertexDeclaration vertexDeclaration = device_0.VertexDeclaration;
					device_0.VertexFormat = Class112.Struct6.vertexFormat_0;
					device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct6.SizeInBytes);
					Class140.smethod_0().method_40("SelectionLine");
					Class140.smethod_0().method_31("g_ambient", Color.Blue);
					int num = Class140.smethod_0().method_36();
					for (int i = 0; i < num; i++)
					{
						Class140.smethod_0().method_38(i);
						device_0.DrawPrimitives(PrimitiveType.LineStrip, 0, this.int_0 - 1);
						Class140.smethod_0().method_39();
					}
					Class140.smethod_0().method_37();
					device_0.VertexDeclaration = vertexDeclaration;
				}
			}
			base.vmethod_4(string.Concat(new object[]
			{
				this.int_2,
				" of ",
				this.int_1,
				" vertices selected"
			}), 218, 10);
		}

		// Token: 0x040009FE RID: 2558
		protected Texture texture_1;

		// Token: 0x040009FF RID: 2559
		private int int_0 = 5;

		// Token: 0x04000A00 RID: 2560
		private Class112.Struct6[] struct6_0;

		// Token: 0x04000A01 RID: 2561
		private VertexBuffer vertexBuffer_0;

		// Token: 0x04000A02 RID: 2562
		private bool bool_0;

		// Token: 0x04000A03 RID: 2563
		private SelectionControl selectionControl_0;

		// Token: 0x04000A04 RID: 2564
		private static Class137 class137_0;

		// Token: 0x04000A05 RID: 2565
		private int int_1;

		// Token: 0x04000A06 RID: 2566
		private int int_2;

		// Token: 0x04000A07 RID: 2567
		private Point point_0;

		// Token: 0x04000A08 RID: 2568
		private Point point_1;

		// Token: 0x04000A09 RID: 2569
		private bool bool_1;
	}
}
