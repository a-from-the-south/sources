using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns10;
using ns11;
using ns13;
using ns14;
using ns18;
using ns2;
using ns3;
using ns6;
using ns7;
using ns8;
using SlimDX;
using SlimDX.Direct3D9;
using SplitButtonDemo;

namespace ns19
{
	// Token: 0x0200003F RID: 63
	internal sealed partial class GeostateSelector : Form, Interface2
	{
		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000247 RID: 583 RVA: 0x0002BB0C File Offset: 0x00029D0C
		// (remove) Token: 0x06000248 RID: 584 RVA: 0x0002BB44 File Offset: 0x00029D44
		public event Delegate4 Done
		{
			add
			{
				Delegate4 @delegate = this.delegate4_0;
				Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate4 value2 = (Delegate4)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate4>(ref this.delegate4_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate4 @delegate = this.delegate4_0;
				Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate4 value2 = (Delegate4)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate4>(ref this.delegate4_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000249 RID: 585 RVA: 0x0002BB7C File Offset: 0x00029D7C
		// (remove) Token: 0x0600024A RID: 586 RVA: 0x0002BBB4 File Offset: 0x00029DB4
		public event Delegate5 OnClear
		{
			add
			{
				Delegate5 @delegate = this.delegate5_0;
				Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate5 value2 = (Delegate5)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate5>(ref this.delegate5_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate5 @delegate = this.delegate5_0;
				Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate5 value2 = (Delegate5)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate5>(ref this.delegate5_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0002BBEC File Offset: 0x00029DEC
		public GeostateSelector(bool enableEdit)
		{
			this.InitializeComponent();
			this.list_0 = new List<Class102.Class107>();
			this.short_0 = new short[300];
			this.enableEdit = enableEdit;
			this.basicSquare.Checked = GeostateSelector.bool_0;
			this.freehandRadio.Checked = GeostateSelector.bool_1;
			this.picknclickRadio.Checked = GeostateSelector.bool_2;
			this.ignorebackfaces.Checked = GeostateSelector.bool_4;
			this.fullyContained.Checked = GeostateSelector.bool_5;
			this.moveRadio.Checked = GeostateSelector.bool_6;
			this.rotateRadio.Checked = GeostateSelector.bool_7;
			if (this.basicSquare.Checked)
			{
				this.basicSquare_Click(this.basicSquare, new EventArgs());
			}
			else if (this.freehandRadio.Checked)
			{
				this.freehandRadio_Click(this.basicSquare, new EventArgs());
			}
			else if (this.picknclickRadio.Checked)
			{
				this.picknclickRadio_Click(this.basicSquare, new EventArgs());
			}
			Device device = Class140.smethod_0().Device;
			this.struct6_1 = new Class112.Struct6[2048];
			this.vertexBuffer_0 = new VertexBuffer(device, 2048 * Class112.Struct6.SizeInBytes, Usage.None, Class112.Struct6.vertexFormat_0, Pool.Managed);
			DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct6>(this.struct6_1, 0, 2048);
			this.vertexBuffer_0.Unlock();
			dataStream.Dispose();
			this.struct6_0 = new Class112.Struct6[300];
			this.vertexBuffer_1 = new VertexBuffer(device, 300 * Class112.Struct6.SizeInBytes, Usage.None, Class112.Struct6.vertexFormat_0, Pool.Managed);
			dataStream = this.vertexBuffer_1.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct6>(this.struct6_0, 0, 300);
			this.vertexBuffer_1.Unlock();
			dataStream.Dispose();
			this.editGroup.Enabled = enableEdit;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0002BDF0 File Offset: 0x00029FF0
		public void imethod_3(Device device_0)
		{
			if (this.bool_9 && this.int_1 > 0)
			{
				VertexDeclaration vertexDeclaration = device_0.VertexDeclaration;
				device_0.VertexFormat = Class112.Struct6.vertexFormat_0;
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct6.SizeInBytes);
				Class140.smethod_0().method_40("SelectionLine");
				Class140.smethod_0().method_31("g_ambient", Color.White);
				int num = Class140.smethod_0().method_36();
				for (int i = 0; i < num; i++)
				{
					Class140.smethod_0().method_38(i);
					device_0.DrawPrimitives(PrimitiveType.LineStrip, 0, this.int_1 - 1);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				device_0.VertexDeclaration = vertexDeclaration;
			}
			if (this.bool_8)
			{
				VertexDeclaration vertexDeclaration2 = device_0.VertexDeclaration;
				Class140.smethod_0().method_9(RenderState.ZEnable, false);
				Sprite sprite = new Sprite(device_0);
				sprite.Begin(SpriteFlags.AlphaBlend);
				int num2 = 0;
				foreach (Class102.Class107 @class in this.list_0)
				{
					Vector3 position = this.struct6_0[num2 * 3].position;
					Vector3 position2 = this.struct6_0[num2 * 3 + 1].position;
					float x = position.X;
					float y = position2.Y;
					if (num2 != this.int_0 / 3)
					{
						goto IL_164;
					}
					if (this.int_0 == -1)
					{
						goto IL_164;
					}
					Color color = Color.White;
					IL_169:
					Color value = color;
					string text = (num2 == this.list_0.Count - 1) ? "All" : ("Face " + num2);
					int width = Math.Max(80, Class132.smethod_0().TextFont.MeasureString(sprite, text, DrawTextFormat.Left).Width + 8);
					sprite.Draw(Class132.smethod_0().BlankTexture, new Rectangle?(new Rectangle(0, 0, width, 20)), new Vector3?(Vector3.Zero), new Vector3?(new Vector3(x, y, 0f)), value);
					Class132.smethod_0().TextFont.DrawString(sprite, text, (int)(x + 4f), (int)(y + 2f), Color.Black);
					num2++;
					continue;
					IL_164:
					color = Color.LightGray;
					goto IL_169;
				}
				sprite.End();
				sprite.Dispose();
				device_0.VertexDeclaration = vertexDeclaration2;
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x000036C0 File Offset: 0x000018C0
		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.point_0 = Class132.smethod_0().point_1;
			this.bool_8 = true;
			this.int_0 = 0;
			this.timer_0.Dispose();
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0002C088 File Offset: 0x0002A288
		public bool imethod_2(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2)
		{
			bool result;
			if ((Control.ModifierKeys & Keys.Control) == Keys.None && mouseEventArgs_0.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				List<Class102> renderables = Class132.smethod_0().Renderables;
				if (this.method_5() == 1)
				{
					this.list_0.Clear();
					Vector3 vector3_ = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
					Vector3 vector3_2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
					using (List<Class102>.Enumerator enumerator = renderables.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							Class102 @class = enumerator.Current;
							if (@class is Class105)
							{
								List<Class102.Class108> list = (@class as Class105).method_23(vector3_, vector3_2, viewport_0, matrix_0, matrix_1, matrix_2, this.method_6(), this.list_1.ToArray(), this.method_7());
								foreach (Class102.Class108 class2 in list)
								{
									Class121 class3 = class2.RenderableItem as Class121;
									if (class3 == (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable)
									{
										if (class2.SelectedFaces.Count > 1)
										{
											this.timer_0 = new System.Windows.Forms.Timer();
											this.timer_0.Interval = 500;
											this.timer_0.Tick += this.timer_0_Tick;
											this.timer_0.Start();
											this.list_0.AddRange(class2.SelectedFaces.ToArray());
											this.method_0(mouseEventArgs_0.X, mouseEventArgs_0.Y);
										}
										class3.imethod_3();
										this.imethod_4(class3.CurrentSelectionIndex.Count);
									}
								}
							}
						}
						goto IL_2EC;
					}
				}
				if (this.method_5() == 2)
				{
					this.bool_9 = true;
					this.list_1.Clear();
					this.int_1 = 0;
					this.list_1.Add(new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
				}
				else if (this.method_5() == 3)
				{
					this.bool_9 = true;
					this.list_1.Clear();
					this.int_1 = 0;
					this.list_1.Add(new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
				}
				IL_2EC:
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0002C3C4 File Offset: 0x0002A5C4
		public bool imethod_1(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2)
		{
			bool result;
			if ((Control.ModifierKeys & Keys.Control) != Keys.None)
			{
				result = true;
			}
			else if ((Control.ModifierKeys & Keys.Alt) != Keys.None)
			{
				result = true;
			}
			else
			{
				if (this.list_0.Count > 0)
				{
					this.int_0 = -1;
					int num = 0;
					foreach (Class102.Class107 @class in this.list_0)
					{
						Vector3 position = this.struct6_0[num * 3].position;
						Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, 80, 20);
						if (rectangle.IntersectsWith(new Rectangle(mouseEventArgs_0.X, mouseEventArgs_0.Y, 1, 1)))
						{
							this.int_0 = num * 3;
						}
						num++;
					}
				}
				List<Class102> renderables = Class132.smethod_0().Renderables;
				if (this.method_5() == 1)
				{
					Class132.smethod_0().CursorText = null;
					Vector3 vector3_ = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
					Vector3 vector3_2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
					foreach (Class102 class2 in renderables)
					{
						if (class2 is Class105)
						{
							List<Class102.Class108> list = (class2 as Class105).method_23(vector3_, vector3_2, viewport_0, matrix_0, matrix_1, matrix_2, this.method_6(), this.list_1.ToArray(), this.method_7());
							foreach (Class102.Class108 class3 in list)
							{
								Class121 class4 = class3.RenderableItem as Class121;
								if (class4 == (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable)
								{
									Class132.smethod_0().CursorText = class3.SelectedFaces.Count + " Face(s)";
								}
							}
						}
					}
				}
				if (this.method_5() == 2 && mouseEventArgs_0.Button == MouseButtons.Left)
				{
					this.list_1.Add(new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
					for (int i = 0; i < this.list_1.Count; i++)
					{
						this.struct6_1[i].position = new Vector3((float)this.list_1[i].X, (float)this.list_1[i].Y, 0f);
					}
					this.int_1 = this.list_1.Count;
					DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
					dataStream.WriteRange<Class112.Struct6>(this.struct6_1, 0, this.int_1);
					this.vertexBuffer_0.Unlock();
					dataStream.Dispose();
				}
				if (this.method_5() == 3 && mouseEventArgs_0.Button == MouseButtons.Left)
				{
					this.list_1.Add(new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
					int num2 = Math.Min(this.list_1[0].X, this.list_1[this.list_1.Count - 1].X);
					int num3 = Math.Min(this.list_1[0].Y, this.list_1[this.list_1.Count - 1].Y);
					int num4 = Math.Max(this.list_1[0].X, this.list_1[this.list_1.Count - 1].X);
					int num5 = Math.Max(this.list_1[0].Y, this.list_1[this.list_1.Count - 1].Y);
					this.int_1 = 5;
					this.struct6_1[0].position = new Vector3((float)num2, (float)num3, 0f);
					this.struct6_1[1].position = new Vector3((float)num4, (float)num3, 0f);
					this.struct6_1[2].position = new Vector3((float)num4, (float)num5, 0f);
					this.struct6_1[3].position = new Vector3((float)num2, (float)num5, 0f);
					this.struct6_1[4].position = new Vector3((float)num2, (float)num3, 0f);
					DataStream dataStream2 = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
					dataStream2.WriteRange<Class112.Struct6>(this.struct6_1, 0, this.int_1);
					this.vertexBuffer_0.Unlock();
					dataStream2.Dispose();
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0002C98C File Offset: 0x0002AB8C
		public bool imethod_0(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2)
		{
			this.bool_9 = false;
			if (this.timer_0 != null)
			{
				this.timer_0.Dispose();
			}
			if ((Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				List<Class102> renderables = Class132.smethod_0().Renderables;
				if (this.method_5() == 1 && this.bool_8 && this.list_0.Count > 0 && this.int_0 != -1)
				{
					if (this.int_0 / 3 < this.list_0.Count)
					{
						if (this.int_0 / 3 == this.list_0.Count - 1)
						{
							Class121 mlodrenderable = (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable;
							for (int i = 0; i < this.list_0.Count - 1; i++)
							{
								Class102.Class107 item = this.list_0[i];
								if ((Control.ModifierKeys & Keys.Shift) == Keys.None)
								{
									if (!mlodrenderable.CurrentSelectionIndex.Contains(item))
									{
										mlodrenderable.CurrentSelectionIndex.Add(item);
									}
								}
								else if ((Control.ModifierKeys & Keys.Shift) != Keys.None && mlodrenderable.CurrentSelectionIndex.Contains(item))
								{
									mlodrenderable.CurrentSelectionIndex.Remove(item);
								}
								mlodrenderable.imethod_3();
								this.imethod_4(mlodrenderable.CurrentSelectionIndex.Count);
							}
						}
						else
						{
							Class102.Class107 item2 = this.list_0[this.int_0 / 3];
							Class121 mlodrenderable2 = (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable;
							if ((Control.ModifierKeys & Keys.Shift) == Keys.None)
							{
								if (!mlodrenderable2.CurrentSelectionIndex.Contains(item2))
								{
									mlodrenderable2.CurrentSelectionIndex.Add(item2);
								}
							}
							else if ((Control.ModifierKeys & Keys.Shift) != Keys.None && mlodrenderable2.CurrentSelectionIndex.Contains(item2))
							{
								mlodrenderable2.CurrentSelectionIndex.Remove(item2);
							}
							mlodrenderable2.imethod_3();
							this.imethod_4(mlodrenderable2.CurrentSelectionIndex.Count);
						}
					}
					this.list_0.Clear();
					this.int_0 = -1;
				}
				else if (this.method_5() == 1 && (Control.ModifierKeys & Keys.Control) == Keys.None && mouseEventArgs_0.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Alt) == Keys.None)
				{
					this.list_0.Clear();
					Vector3 vector3_ = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
					Vector3 vector3_2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
					foreach (Class102 @class in renderables)
					{
						if (@class is Class105)
						{
							List<Class102.Class108> list = (@class as Class105).method_23(vector3_, vector3_2, viewport_0, matrix_0, matrix_1, matrix_2, this.method_6(), this.list_1.ToArray(), this.method_7());
							foreach (Class102.Class108 class2 in list)
							{
								Class121 class3 = class2.RenderableItem as Class121;
								if (class3 == (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable)
								{
									float num = float.MaxValue;
									foreach (Class102.Class107 class4 in class2.SelectedFaces)
									{
										num = Math.Min(num, class4.float_0);
									}
									foreach (Class102.Class107 class5 in class2.SelectedFaces)
									{
										if (!class3.CurrentSelectionIndex.Contains(class5) || class5.float_0 != num || (Control.ModifierKeys & Keys.Shift) == Keys.None)
										{
											if (class3.CurrentSelectionIndex.Contains(class5) || class5.float_0 != num || (Control.ModifierKeys & Keys.Shift) != Keys.None)
											{
												continue;
											}
											class3.CurrentSelectionIndex.Add(class5);
										}
										else
										{
											class3.CurrentSelectionIndex.Remove(class5);
										}
										break;
									}
									class3.imethod_3();
									this.imethod_4(class3.CurrentSelectionIndex.Count);
								}
							}
						}
					}
				}
				this.bool_8 = false;
				if (this.method_5() == 3)
				{
					Graphics graphics = Graphics.FromImage(Class132.smethod_0().SelectionOverlay);
					Size size = Class132.smethod_0().method_38();
					graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, size.Width, size.Height));
					if (this.list_1.Count > 1)
					{
						Point point = this.list_1[0];
						Point point2 = this.list_1[this.list_1.Count - 1];
						Point point3 = new Point(point2.X, point.Y);
						Point point4 = new Point(point.X, point2.Y);
						graphics.DrawLine(Pens.Black, point, point3);
						graphics.DrawLine(Pens.Black, point3, point2);
						graphics.DrawLine(Pens.Black, point2, point4);
						graphics.DrawLine(Pens.Black, point4, point);
						Point point5 = new Point(Math.Min(point.X, point2.X), Math.Min(point.Y, point2.Y));
						Point point6 = new Point(Math.Max(point.X, point2.X), Math.Max(point.Y, point2.Y));
						graphics.FillRectangle(Brushes.Black, new Rectangle(point5.X, point5.Y, point6.X - point5.X, point6.Y - point5.Y));
						int x = point.X;
						int x2 = point2.X;
						this.list_1.Clear();
						for (int j = point5.X; j < point6.X; j++)
						{
							this.list_1.Add(new Point(j, point5.Y));
						}
						for (int k = point5.Y; k < point6.Y; k++)
						{
							this.list_1.Add(new Point(point6.X, k));
						}
						for (int l = point6.X; l > point5.X; l--)
						{
							this.list_1.Add(new Point(l, point6.Y));
						}
						for (int m = point6.Y; m > point5.Y; m--)
						{
							this.list_1.Add(new Point(point5.X, m));
						}
					}
					using (List<Class102>.Enumerator enumerator5 = renderables.GetEnumerator())
					{
						while (enumerator5.MoveNext())
						{
							Class102 class6 = enumerator5.Current;
							if (class6 is Class105)
							{
								List<Class102.Class108> list2 = (class6 as Class105).method_22(Class132.smethod_0().SelectionOverlay as Bitmap, viewport_0, matrix_0, matrix_1, matrix_2, this.method_6(), this.list_1.ToArray(), this.method_7());
								foreach (Class102.Class108 class7 in list2)
								{
									Class121 class8 = class7.RenderableItem as Class121;
									if (class8 == (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable)
									{
										foreach (Class102.Class107 item3 in class7.SelectedFaces)
										{
											if ((Control.ModifierKeys & Keys.Shift) == Keys.None)
											{
												if (!class8.CurrentSelectionIndex.Contains(item3))
												{
													class8.CurrentSelectionIndex.Add(item3);
												}
											}
											else if ((Control.ModifierKeys & Keys.Shift) != Keys.None && class8.CurrentSelectionIndex.Contains(item3))
											{
												class8.CurrentSelectionIndex.Remove(item3);
											}
										}
										class8.imethod_3();
										this.imethod_4(class8.CurrentSelectionIndex.Count);
									}
								}
							}
						}
						goto IL_AF8;
					}
				}
				if (this.method_5() == 2)
				{
					Graphics graphics2 = Graphics.FromImage(Class132.smethod_0().SelectionOverlay);
					Size size2 = Class132.smethod_0().method_38();
					graphics2.FillRectangle(Brushes.White, new Rectangle(0, 0, size2.Width, size2.Height));
					if (this.list_1.Count > 0)
					{
						graphics2.FillPolygon(Brushes.Black, this.list_1.ToArray());
						foreach (Class102 class9 in renderables)
						{
							if (class9 is Class105)
							{
								List<Class102.Class108> list3 = (class9 as Class105).method_22(Class132.smethod_0().SelectionOverlay as Bitmap, viewport_0, matrix_0, matrix_1, matrix_2, this.method_6(), this.list_1.ToArray(), this.method_7());
								foreach (Class102.Class108 class10 in list3)
								{
									Class121 class11 = class10.RenderableItem as Class121;
									if (class11 == (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable)
									{
										foreach (Class102.Class107 item4 in class10.SelectedFaces)
										{
											if ((Control.ModifierKeys & Keys.Shift) == Keys.None)
											{
												if (!class11.CurrentSelectionIndex.Contains(item4))
												{
													class11.CurrentSelectionIndex.Add(item4);
												}
											}
											else if ((Control.ModifierKeys & Keys.Shift) != Keys.None && class11.CurrentSelectionIndex.Contains(item4))
											{
												class11.CurrentSelectionIndex.Remove(item4);
											}
										}
										class11.imethod_3();
										this.imethod_4(class11.CurrentSelectionIndex.Count);
									}
								}
							}
						}
					}
				}
				IL_AF8:
				this.boundingBox_0.Maximum = new Vector3(float.MinValue);
				this.boundingBox_0.Minimum = new Vector3(float.MaxValue);
				foreach (Class102 class12 in renderables)
				{
					if (class12 is Class105)
					{
						foreach (Interface9 @interface in class12.Objects.Values)
						{
							Class121 class13 = (Class121)@interface;
							if (class13 != null && class13 == (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable)
							{
								this.boundingBox_0.Minimum.X = Math.Min(this.boundingBox_0.Minimum.X, class13.MLODEntry.BoundingBox[0]);
								this.boundingBox_0.Minimum.Y = Math.Min(this.boundingBox_0.Minimum.Y, class13.MLODEntry.BoundingBox[1]);
								this.boundingBox_0.Minimum.Z = Math.Min(this.boundingBox_0.Minimum.Z, class13.MLODEntry.BoundingBox[2]);
								this.boundingBox_0.Maximum.X = Math.Max(this.boundingBox_0.Maximum.X, class13.MLODEntry.BoundingBox[3]);
								this.boundingBox_0.Maximum.Y = Math.Max(this.boundingBox_0.Maximum.Y, class13.MLODEntry.BoundingBox[4]);
								this.boundingBox_0.Maximum.Z = Math.Max(this.boundingBox_0.Maximum.Z, class13.MLODEntry.BoundingBox[5]);
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0002D7C8 File Offset: 0x0002B9C8
		private void method_0(int int_2, int int_3)
		{
			float num = (float)int_2;
			float num2 = (float)int_3;
			List<Class102.Class107> list = this.list_0;
			if (GeostateSelector.comparison_0 == null)
			{
				GeostateSelector.comparison_0 = new Comparison<Class102.Class107>(GeostateSelector.smethod_0);
			}
			list.Sort(GeostateSelector.comparison_0);
			if (this.list_0.Count > 0)
			{
				float val = float.MaxValue;
				float val2 = float.MaxValue;
				float val3 = float.MinValue;
				float val4 = float.MinValue;
				foreach (Class102.Class107 @class in this.list_0)
				{
					val = Math.Min(val, Math.Min(@class.vector2_0.X, Math.Min(@class.vector2_1.X, @class.vector2_2.X)));
					val3 = Math.Max(val3, Math.Max(@class.vector2_0.X, Math.Max(@class.vector2_1.X, @class.vector2_2.X)));
					val2 = Math.Min(val2, Math.Min(@class.vector2_0.Y, Math.Min(@class.vector2_1.Y, @class.vector2_2.Y)));
					val4 = Math.Max(val4, Math.Max(@class.vector2_0.Y, Math.Max(@class.vector2_1.Y, @class.vector2_2.Y)));
				}
				num = (float)int_2;
				num2 = (float)int_3;
				int num3 = 0;
				float x;
				float y;
				foreach (Class102.Class107 class2 in this.list_0)
				{
					x = num;
					y = num2 + (float)(num3 * 20);
					this.struct6_0[num3 * 3].position = new Vector3(x, y, 0f);
					this.struct6_0[num3 * 3 + 1].position = new Vector3(x, y, 0f);
					this.struct6_0[num3 * 3 + 2].position = new Vector3(x, y, 0f);
					this.short_0[num3 * 3] = class2.short_0;
					this.short_0[num3 * 3 + 1] = class2.short_1;
					this.short_0[num3 * 3 + 2] = class2.short_2;
					num3++;
				}
				Class102.Class107 item = new Class102.Class107();
				this.list_0.Add(item);
				x = num;
				y = num2 + (float)(num3 * 20);
				this.struct6_0[num3 * 3].position = new Vector3(x, y, 0f);
				this.struct6_0[num3 * 3 + 1].position = new Vector3(x, y, 0f);
				this.struct6_0[num3 * 3 + 2].position = new Vector3(x, y, 0f);
				this.short_0[num3 * 3] = 0;
				this.short_0[num3 * 3 + 1] = 0;
				this.short_0[num3 * 3 + 2] = 0;
				num3++;
				DataStream dataStream = this.vertexBuffer_1.Lock(0, 0, LockFlags.None);
				dataStream.WriteRange<Class112.Struct6>(this.struct6_0, 0, 300);
				this.vertexBuffer_1.Unlock();
				dataStream.Dispose();
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000036ED File Offset: 0x000018ED
		public void method_1()
		{
			this.vertexBuffer_0.Dispose();
			this.vertexBuffer_1.Dispose();
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00003707 File Offset: 0x00001907
		public void imethod_5()
		{
			this.button2_Click(this, null);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00003713 File Offset: 0x00001913
		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			if (this.delegate4_0 != null)
			{
				this.delegate4_0(base.DialogResult);
			}
			this.method_1();
			base.Close();
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00003743 File Offset: 0x00001943
		private void doneButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			if (this.delegate4_0 != null)
			{
				this.delegate4_0(base.DialogResult);
			}
			this.method_1();
			base.Close();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00003773 File Offset: 0x00001973
		private void method_2(object sender, EventArgs e)
		{
			if (this.delegate5_0 != null)
			{
				this.delegate5_0();
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000378A File Offset: 0x0000198A
		public void imethod_4(int int_2)
		{
			this.facesSelectedLabel.Text = int_2.ToString();
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0002DB48 File Offset: 0x0002BD48
		private void picknclickRadio_Click(object sender, EventArgs e)
		{
			this.basicSquare.Checked = false;
			GeostateSelector.bool_0 = false;
			this.freehandRadio.Checked = false;
			GeostateSelector.bool_1 = false;
			this.picknclickRadio.Checked = true;
			GeostateSelector.bool_2 = true;
			this.ignorebackfaces.Enabled = true;
			this.fullyContained.Enabled = false;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0002DBAC File Offset: 0x0002BDAC
		private void freehandRadio_Click(object sender, EventArgs e)
		{
			this.basicSquare.Checked = false;
			GeostateSelector.bool_0 = false;
			this.freehandRadio.Checked = true;
			GeostateSelector.bool_1 = true;
			this.picknclickRadio.Checked = false;
			GeostateSelector.bool_2 = false;
			this.ignorebackfaces.Enabled = true;
			this.fullyContained.Enabled = true;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0002DC10 File Offset: 0x0002BE10
		private void basicSquare_Click(object sender, EventArgs e)
		{
			this.basicSquare.Checked = true;
			GeostateSelector.bool_0 = true;
			this.freehandRadio.Checked = false;
			GeostateSelector.bool_1 = false;
			this.picknclickRadio.Checked = false;
			GeostateSelector.bool_2 = false;
			this.ignorebackfaces.Enabled = true;
			this.fullyContained.Enabled = true;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0002DC74 File Offset: 0x0002BE74
		public bool method_3()
		{
			return this.enableEdit;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0002DC8C File Offset: 0x0002BE8C
		public int method_4()
		{
			int result;
			if (this.moveRadio.Checked)
			{
				result = 0;
			}
			else if (this.rotateRadio.Checked)
			{
				result = 1;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0002DCC0 File Offset: 0x0002BEC0
		public int method_5()
		{
			int result;
			if (this.basicSquare.Checked)
			{
				result = 3;
			}
			else if (this.freehandRadio.Checked)
			{
				result = 2;
			}
			else if (this.picknclickRadio.Checked)
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0002DD08 File Offset: 0x0002BF08
		public int method_6()
		{
			int result;
			if (this.picknclickRadio.Checked)
			{
				result = 0;
			}
			else if (this.fullyContained.Checked)
			{
				result = 2;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0002DD3C File Offset: 0x0002BF3C
		public int method_7()
		{
			int result;
			if (this.ignorebackfaces.Checked)
			{
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000037A0 File Offset: 0x000019A0
		private void ignorebackfaces_Click(object sender, EventArgs e)
		{
			GeostateSelector.bool_4 = this.ignorebackfaces.Checked;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x000037B4 File Offset: 0x000019B4
		private void fullyContained_Click(object sender, EventArgs e)
		{
			GeostateSelector.bool_5 = this.fullyContained.Checked;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0002DD60 File Offset: 0x0002BF60
		private unsafe void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<Class102> renderables = Class132.smethod_0().Renderables;
			foreach (Class102 @class in renderables)
			{
				if (@class is Class105)
				{
					new List<Class102.Class108>();
					foreach (Interface9 @interface in @class.Objects.Values)
					{
						Class121 class2 = (Class121)@interface;
						if (class2 == (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable)
						{
							class2.CurrentSelectionIndex.Clear();
							DataStream dataStream = class2.IndexBuffer.Lock(0, 0, LockFlags.None);
							DataStream dataStream2 = class2.VertexBuffer.Lock(0, 0, LockFlags.None);
							short* ptr = (short*)((void*)dataStream.DataPointer);
							(void*)dataStream2.DataPointer;
							new Class102.Class108(class2);
							for (int i = 0; i < class2.MLODEntry.FaceCount * 3; i += 3)
							{
								short num = ptr[((long)i + class2.MLODEntry.IBUFOffset) * 2L / 2L];
								short short_ = ptr[((long)(i + 1) + class2.MLODEntry.IBUFOffset) * 2L / 2L];
								short short_2 = ptr[((long)(i + 2) + class2.MLODEntry.IBUFOffset) * 2L / 2L];
								Class102.Class107 class3 = new Class102.Class107();
								class3.short_0 = num;
								class3.short_1 = short_;
								class3.short_2 = short_2;
								Class121 class4 = class2;
								if (!class4.CurrentSelectionIndex.Contains(class3))
								{
									class4.CurrentSelectionIndex.Add(class3);
								}
							}
							class2.imethod_3();
							this.imethod_4(class2.CurrentSelectionIndex.Count);
						}
					}
				}
			}
			Class132.smethod_0().method_35();
		}

		// Token: 0x06000263 RID: 611 RVA: 0x000037C8 File Offset: 0x000019C8
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0002EB90 File Offset: 0x0002CD90
		[CompilerGenerated]
		private static int smethod_0(Class102.Class107 class107_0, Class102.Class107 class107_1)
		{
			return class107_0.float_0.CompareTo(class107_1.float_0);
		}

		// Token: 0x040001EF RID: 495
		private Delegate4 delegate4_0;

		// Token: 0x040001F0 RID: 496
		private Delegate5 delegate5_0;

		// Token: 0x040001F1 RID: 497
		public static bool bool_0 = false;

		// Token: 0x040001F2 RID: 498
		public static bool bool_1 = false;

		// Token: 0x040001F3 RID: 499
		public static bool bool_2 = true;

		// Token: 0x040001F4 RID: 500
		public static bool bool_3 = false;

		// Token: 0x040001F5 RID: 501
		public static bool bool_4 = true;

		// Token: 0x040001F6 RID: 502
		public static bool bool_5 = true;

		// Token: 0x040001F7 RID: 503
		public static bool bool_6 = true;

		// Token: 0x040001F8 RID: 504
		public static bool bool_7 = false;

		// Token: 0x040001F9 RID: 505
		private bool enableEdit;

		// Token: 0x040001FA RID: 506
		public List<Class102.Class107> list_0;

		// Token: 0x040001FB RID: 507
		private Class112.Struct6[] struct6_0;

		// Token: 0x040001FC RID: 508
		public short[] short_0;

		// Token: 0x040001FD RID: 509
		public int int_0;

		// Token: 0x040001FE RID: 510
		public bool bool_8;

		// Token: 0x040001FF RID: 511
		private Point point_0;

		// Token: 0x04000200 RID: 512
		private List<Point> list_1 = new List<Point>();

		// Token: 0x04000201 RID: 513
		private BoundingBox boundingBox_0 = default(BoundingBox);

		// Token: 0x04000202 RID: 514
		private Class112.Struct6[] struct6_1;

		// Token: 0x04000203 RID: 515
		private int int_1;

		// Token: 0x04000204 RID: 516
		private bool bool_9 = true;

		// Token: 0x04000205 RID: 517
		private VertexBuffer vertexBuffer_0;

		// Token: 0x04000206 RID: 518
		private VertexBuffer vertexBuffer_1;

		// Token: 0x04000207 RID: 519
		private System.Windows.Forms.Timer timer_0;

		// Token: 0x0400021B RID: 539
		[CompilerGenerated]
		private static Comparison<Class102.Class107> comparison_0;
	}
}
