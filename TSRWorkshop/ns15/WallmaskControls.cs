using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ns10;
using ns11;
using ns14;
using ns18;
using ns3;
using ns6;
using ns7;
using ns8;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns15
{
	// Token: 0x02000029 RID: 41
	internal sealed class WallmaskControls : UserControl, Interface2
	{
		// Token: 0x06000138 RID: 312 RVA: 0x0001CDDC File Offset: 0x0001AFDC
		public static WallmaskControls smethod_0()
		{
			if (WallmaskControls.wallmaskControls_0 == null)
			{
				WallmaskControls.wallmaskControls_0 = new WallmaskControls();
			}
			return WallmaskControls.wallmaskControls_0;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0001CE04 File Offset: 0x0001B004
		private WallmaskControls()
		{
			this.InitializeComponent();
			this.list_1 = new List<Class102.Class107>();
			ToolTip toolTip = new ToolTip();
			toolTip.AutoPopDelay = 5000;
			toolTip.InitialDelay = 1000;
			toolTip.ReshowDelay = 500;
			toolTip.ShowAlways = true;
			toolTip.SetToolTip(this.addSelection, "Remove rectangular cutout");
			toolTip.SetToolTip(this.removeSelection, "Add rectangular cutout");
			toolTip.SetToolTip(this.circleremove, "Add circular cutout");
			toolTip.SetToolTip(this.circleadd, "Remove circular coutout");
			Device device = Class140.smethod_0().Device;
			this.struct6_0 = new Class112.Struct6[2048];
			this.vertexBuffer_0 = new VertexBuffer(device, 2048 * Class112.Struct6.SizeInBytes, Usage.None, Class112.Struct6.vertexFormat_0, Pool.Managed);
			DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct6>(this.struct6_0, 0, 2048);
			this.vertexBuffer_0.Unlock();
			dataStream.Dispose();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0001CF14 File Offset: 0x0001B114
		private void removeSelection_Click(object sender, EventArgs e)
		{
			CheckBox checkBox = this.circleadd;
			CheckBox checkBox2 = this.circleremove;
			this.addSelection.Checked = false;
			checkBox2.Checked = false;
			checkBox.Checked = false;
			this.removeSelection.Checked = true;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0001CF58 File Offset: 0x0001B158
		private void addSelection_Click(object sender, EventArgs e)
		{
			CheckBox checkBox = this.circleadd;
			CheckBox checkBox2 = this.circleremove;
			this.removeSelection.Checked = false;
			checkBox2.Checked = false;
			checkBox.Checked = false;
			this.addSelection.Checked = true;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0001CF9C File Offset: 0x0001B19C
		private void circleremove_Click(object sender, EventArgs e)
		{
			CheckBox checkBox = this.addSelection;
			CheckBox checkBox2 = this.circleadd;
			this.removeSelection.Checked = false;
			checkBox2.Checked = false;
			checkBox.Checked = false;
			this.circleremove.Checked = true;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0001CFE0 File Offset: 0x0001B1E0
		private void circleadd_Click(object sender, EventArgs e)
		{
			CheckBox checkBox = this.addSelection;
			CheckBox checkBox2 = this.circleremove;
			this.removeSelection.Checked = false;
			checkBox2.Checked = false;
			checkBox.Checked = false;
			this.circleadd.Checked = true;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0001D024 File Offset: 0x0001B224
		private void WallmaskControls_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawLine(Pens.Black, new Point(0, e.ClipRectangle.Height - 1), new Point(e.ClipRectangle.Width, e.ClipRectangle.Height - 1));
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0001D080 File Offset: 0x0001B280
		public unsafe bool imethod_0(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2)
		{
			List<Class102> renderables = Class132.smethod_0().Renderables;
			foreach (Class102 @class in renderables)
			{
				Class105 class2 = (Class105)@class;
				if (class2 != null)
				{
					int num = 64;
					int num2 = 256;
					Graphics graphics = Graphics.FromImage(class2.WallMaskImage);
					DataStream dataStream = class2.vertexBuffer_0.Lock(0, 0, LockFlags.None);
					(void*)dataStream.DataPointer;
					List<Point> list = new List<Point>();
					Matrix transformation = Matrix.RotationY((float)(class2.IsDiagonal ? 45 : 0) * 0.017453292f) * Matrix.Translation(new Vector3(0f, 0f, 0f));
					Vector3 vector = Vector3.TransformCoordinate(this.vector3_0, transformation);
					Vector3 vector2 = Vector3.TransformCoordinate(this.vector3_1, transformation);
					Vector3 vector3 = Vector3.TransformCoordinate(this.vector3_2, transformation);
					Vector3 vector4 = Vector3.TransformCoordinate(this.vector3_3, transformation);
					Vector3 vector5 = vector;
					double num3 = (double)(5f - vector5.X) * 0.1;
					double num4 = (double)((3f - vector5.Y) / 3f) * 0.5;
					int x = (int)((double)(num * 10) * num3);
					int y = (int)((double)num2 * num4);
					list.Add(new Point(x, y));
					vector5 = vector2;
					num3 = (double)(5f - vector5.X) * 0.1;
					num4 = (double)((3f - vector5.Y) / 3f) * 0.5;
					x = (int)((double)(num * 10) * num3);
					y = (int)((double)num2 * num4);
					list.Add(new Point(x, y));
					vector5 = vector3;
					num3 = (double)(5f - vector5.X) * 0.1;
					num4 = (double)((3f - vector5.Y) / 3f) * 0.5;
					x = (int)((double)(num * 10) * num3);
					y = (int)((double)num2 * num4);
					list.Add(new Point(x, y));
					vector5 = vector4;
					num3 = (double)(5f - vector5.X) * 0.1;
					num4 = (double)((3f - vector5.Y) / 3f) * 0.5;
					x = (int)((double)(num * 10) * num3);
					y = (int)((double)num2 * num4);
					list.Add(new Point(x, y));
					if (list.Count > 0 && this.list_0.Count > 0)
					{
						Color color = (WallmaskControls.smethod_0().addSelection.Checked || WallmaskControls.smethod_0().circleadd.Checked) ? Color.OliveDrab : Color.FromArgb(255, Color.White);
						if (!WallmaskControls.smethod_0().circleremove.Checked && !WallmaskControls.smethod_0().circleadd.Checked)
						{
							graphics.FillPolygon(new SolidBrush(color), list.ToArray());
						}
						else
						{
							int num5 = Math.Max(Math.Max(Math.Max(list[0].X, list[1].X), list[2].X), list[3].X);
							Math.Max(Math.Max(Math.Max(list[0].Y, list[1].Y), list[2].Y), list[3].Y);
							int num6 = Math.Min(Math.Min(Math.Max(list[0].X, list[1].X), list[2].X), list[3].X);
							int num7 = Math.Min(Math.Min(Math.Max(list[0].Y, list[1].Y), list[2].Y), list[3].Y);
							int num8 = num5 - num6;
							Rectangle rect = new Rectangle(num6, num7 - (int)((float)num8 * 0.65f), num8 * 2, (int)((float)(num8 * 2) * 0.65f));
							graphics.FillEllipse(new SolidBrush(color), rect);
						}
						for (int i = 0; i < num2 / 2; i++)
						{
							for (int j = 0; j < num * 10; j++)
							{
								Color pixel = class2.WallMaskImage.GetPixel(j, i);
								if (pixel.R == 255 && pixel.G == 255 && pixel.B == 255)
								{
									class2.WallMaskImage.SetPixel(j, i, Color.FromArgb(0, Color.White));
									class2.WallMaskImage.SetPixel(Math.Min(639, 639 - j), Math.Min(129 + i - 1, 255), Color.FromArgb(0, Color.White));
								}
								else
								{
									Color pixel2 = class2.WallMaskImage.GetPixel(j, i);
									class2.WallMaskImage.SetPixel(j, i, pixel2);
									class2.WallMaskImage.SetPixel(Math.Min(639, 639 - j), Math.Min(129 + i - 1, 255), pixel2);
								}
							}
						}
					}
					class2.texture_0.Dispose();
					MemoryStream memoryStream = new MemoryStream();
					class2.WallMaskImage.Save(memoryStream, ImageFormat.Png);
					memoryStream.Position = 0L;
					memoryStream.Dispose();
					foreach (OBJD.WallMask wallMask in class2.Objd.WallMasks)
					{
						ResKey key = new ResKey(class2.Objd.TgiIndex[wallMask.DdsIndex].AsString());
						Class132.mainForm.CurrentProject.Package.RemoveEntry(key);
					}
					class2.Objd.WallMasks.Clear();
					int k = 32;
					IL_9B1:
					while (k < class2.WallMaskImage.Width)
					{
						float num9 = -(float)Math.Ceiling((double)((float)Math.Abs(320 - k) / 32f)) + 0.5f;
						bool flag = false;
						for (int l = 128; l < class2.WallMaskImage.Height; l++)
						{
							if (class2.WallMaskImage.GetPixel(k, l).A == 0)
							{
								flag = true;
								IL_6C7:
								if (flag)
								{
									int num10 = (int)(Math.Floor((double)((float)(k - 32) / 64f)) * 64.0 + 32.0);
									num9 = -((float)(320 - num10) / 64f);
									int num11 = num10 + 64;
									Bitmap bitmap = new Bitmap(64, 128);
									Graphics.FromImage(bitmap).DrawImage(class2.WallMaskImage, new Rectangle(0, 0, 64, 128), new Rectangle(num10, 128, 64, 128), GraphicsUnit.Pixel);
									for (int m = 0; m < 64; m++)
									{
										for (int n = 0; n < 128; n++)
										{
											if (bitmap.GetPixel(m, n).A != 255)
											{
												bitmap.SetPixel(m, n, Color.FromArgb(0, 0, 0, 0));
											}
											else
											{
												bitmap.SetPixel(m, n, Color.White);
											}
										}
									}
									DDS dds = new DDS();
									dds.AddImage(bitmap);
									dds.GroupID = class2.Objd.GroupID;
									string text = string.Concat(new object[]
									{
										class2.Objd.GenerateResKey().ToString(),
										"_mask_",
										num9,
										"_",
										num9 + 1f
									});
									ulong hash = FNV64.GetHash(text);
									dds.InstanceID = (int)(hash & 4294967295UL);
									dds.SecondInstanceID = (int)(hash >> 32 & 4294967295UL);
									dds.SetData(dds.Serialize());
									Class132.mainForm.CurrentProject.Package.AddEntry(dds);
									bitmap.Dispose();
									int ddsIndex = class2.Objd.AddTgi(class2.Objd.TgiIndex, new TGIIndex(dds.GenerateResKey()));
									OBJD.WallMask wallMask2 = new OBJD.WallMask();
									wallMask2.DdsIndex = ddsIndex;
									wallMask2.F1 = num9;
									wallMask2.F2 = -0.5f;
									wallMask2.F3 = wallMask2.F1 + 1f;
									wallMask2.F4 = -0.5f;
									if (class2.IsDiagonal)
									{
										wallMask2.F2 = -wallMask2.F1;
										wallMask2.F4 = -wallMask2.F3;
									}
									OBJD.WallMask wallMask3 = new OBJD.WallMask();
									wallMask3.DdsIndex = ddsIndex;
									wallMask3.F1 = wallMask2.F3;
									wallMask3.F2 = -0.5f;
									wallMask3.F3 = wallMask2.F1;
									wallMask3.F4 = -0.5f;
									if (class2.IsDiagonal)
									{
										wallMask3.F2 = wallMask2.F4;
										wallMask3.F4 = wallMask2.F2;
									}
									class2.Objd.WallMasks.Add(wallMask2);
									class2.Objd.WallMasks.Add(wallMask3);
									k = num11;
								}
								k++;
								goto IL_9B1;
							}
						}
						goto IL_6C7;
					}
					class2.Objd.NumWallCutoutTilesPerLevel = (uint)(class2.Objd.WallMasks.Count / 2);
					class2.vertexBuffer_0.Unlock();
					class2.method_15(Class140.smethod_0().Device);
					(Class132.mainForm.CurrentProjectModel as Class80).method_2();
				}
			}
			this.bool_0 = false;
			this.list_1.Clear();
			this.list_0.Clear();
			return true;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0001DB14 File Offset: 0x0001BD14
		public unsafe bool imethod_1(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2)
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
				if (mouseEventArgs_0.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
				{
					this.list_0.Add(new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
					Point item = this.list_0[0];
					Point point = new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y);
					Point value = point;
					if (this.list_0.Count >= 2)
					{
						value = this.list_0[1];
					}
					this.list_0.Clear();
					this.list_0.Add(item);
					this.list_0.Add(point);
					this.struct6_0[0].position = new Vector3((float)item.X, (float)item.Y, 0f);
					this.struct6_0[1].position = new Vector3((float)point.X, (float)item.Y, 0f);
					this.struct6_0[2].position = new Vector3((float)point.X, (float)point.Y, 0f);
					this.struct6_0[3].position = new Vector3((float)point.X, (float)point.Y, 0f);
					this.struct6_0[4].position = new Vector3((float)item.X, (float)item.Y, 0f);
					int num = 5;
					float num2 = 0f;
					for (int i = 1; i <= 360; i++)
					{
						float num3 = 1f * (float)i;
						double num4 = (double)num3 * 0.017453292519943295;
						double num5 = (double)num2 * 0.017453292519943295;
						float x = (float)Math.Cos(num5);
						float y = (float)Math.Sin(num5);
						float x2 = (float)Math.Cos(num4);
						float y2 = (float)Math.Sin(num4);
						this.struct6_0[num++].position = new Vector3(x, y, 0f);
						this.struct6_0[num++].position = new Vector3(x2, y2, 0f);
						num2 = num3;
					}
					List<Class102> renderables = Class132.smethod_0().Renderables;
					foreach (Class102 @class in renderables)
					{
						Class105 class2 = (Class105)@class;
						if (class2 != null)
						{
							Matrix.RotationY((float)(class2.IsDiagonal ? 45 : 0) * 0.017453292f) * Matrix.Translation(new Vector3(0f, 0f, (float)(class2.IsDiagonal ? 0 : 0))) * Matrix.Translation(0f, 0f, class2.IsDiagonal ? 0f : -0.426f);
							Matrix transformation = Matrix.RotationY((float)(class2.IsDiagonal ? 45 : 0) * 0.017453292f) * Matrix.Translation(0f, 0f, class2.IsDiagonal ? 0f : -0.426f);
							transformation.Invert();
							DataStream dataStream = class2.vertexBuffer_0.Lock(0, 0, LockFlags.None);
							Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
							Vector3 vector = Vector3.Unproject(new Vector3((float)item.X, (float)item.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
							Vector3 vector2 = Vector3.Unproject(new Vector3((float)item.X, (float)item.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
							Vector3 vector3 = Vector3.Unproject(new Vector3((float)value.X, (float)value.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
							Vector3 vector4 = Vector3.Unproject(new Vector3((float)value.X, (float)value.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
							Vector3 vector5 = Vector3.Unproject(new Vector3((float)point.X, (float)point.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
							Vector3 vector6 = Vector3.Unproject(new Vector3((float)point.X, (float)point.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
							Ray ray = new Ray(vector, Vector3.Normalize(vector2));
							Ray ray2 = new Ray(vector5, Vector3.Normalize(vector6));
							Ray ray3 = new Ray(vector3, Vector3.Normalize(vector4));
							float num6 = 0f;
							Vector3 vector7 = Vector3.Zero;
							Vector3 vector8 = Vector3.Zero;
							Vector3 vector9 = Vector3.Zero;
							Vector3 vector10 = Vector3.Zero;
							if (Ray.Intersects(ray, ptr[9].position, ptr[10].position, ptr[11].position, out num6))
							{
								vector7 = Vector3.Lerp(vector, vector2, (float)((double)(num6 / Vector3.Distance(vector, vector2))));
							}
							else if (Ray.Intersects(ray, ptr[6].position, ptr[7].position, ptr[8].position, out num6))
							{
								vector7 = Vector3.Lerp(vector, vector2, (float)((double)(num6 / Vector3.Distance(vector, vector2))));
							}
							if (Ray.Intersects(ray2, ptr[9].position, ptr[10].position, ptr[11].position, out num6))
							{
								vector8 = Vector3.Lerp(vector5, vector6, (float)((double)(num6 / Vector3.Distance(vector5, vector6))));
								vector9 = new Vector3(vector8.X, vector7.Y, vector8.Z);
								vector10 = new Vector3(vector7.X, vector8.Y, vector7.Z);
							}
							else if (Ray.Intersects(ray2, ptr[6].position, ptr[7].position, ptr[8].position, out num6))
							{
								vector8 = Vector3.Lerp(vector5, vector6, (float)((double)(num6 / Vector3.Distance(vector5, vector6))));
								vector9 = new Vector3(vector8.X, vector7.Y, vector8.Z);
								vector10 = new Vector3(vector7.X, vector8.Y, vector7.Z);
							}
							else if (Ray.Intersects(ray3, ptr[9].position, ptr[10].position, ptr[11].position, out num6))
							{
								vector8 = Vector3.Lerp(vector3, vector4, (float)((double)(num6 / Vector3.Distance(vector3, vector4))));
								vector9 = new Vector3(vector8.X, vector7.Y, vector8.Z);
								vector10 = new Vector3(vector7.X, vector8.Y, vector7.Z);
								point = (this.list_0[1] = value);
							}
							else if (Ray.Intersects(ray3, ptr[6].position, ptr[7].position, ptr[8].position, out num6))
							{
								vector8 = Vector3.Lerp(vector3, vector4, (float)((double)(num6 / Vector3.Distance(vector3, vector4))));
								vector9 = new Vector3(vector8.X, vector7.Y, vector8.Z);
								vector10 = new Vector3(vector7.X, vector8.Y, vector7.Z);
								point = (this.list_0[1] = value);
							}
							float z = 0f;
							float num7 = 0f;
							vector10.Z = z;
							float z2 = num7;
							float num8 = 0f;
							vector8.Z = z2;
							float z3 = num8;
							float z4 = 0f;
							vector9.Z = z3;
							vector7.Z = z4;
							vector8 = Vector3.TransformCoordinate(vector8, transformation);
							vector10 = Vector3.TransformCoordinate(vector10, transformation);
							vector7 = Vector3.TransformCoordinate(vector7, transformation);
							vector9 = Vector3.TransformCoordinate(vector9, transformation);
							float z5 = 0f;
							float num9 = 0f;
							vector10.Z = z5;
							float z6 = num9;
							float num10 = 0f;
							vector8.Z = z6;
							float z7 = num10;
							float z8 = 0f;
							vector9.Z = z7;
							vector7.Z = z8;
							float num11 = 10f / (float)class2.WallMaskImage.Width;
							float num12 = 3f / (float)(class2.WallMaskImage.Height / 2);
							vector7.X = (float)(Math.Floor((double)(vector7.X / num11)) * (double)num11);
							vector9.X = (float)(Math.Floor((double)(vector9.X / num11)) * (double)num11);
							vector8.X = (float)(Math.Floor((double)(vector8.X / num11)) * (double)num11);
							vector10.X = (float)(Math.Floor((double)(vector10.X / num11)) * (double)num11);
							if (vector7.Y > 3f - num12)
							{
								vector7.Y = 3f;
							}
							else if (vector7.Y < 1.5f)
							{
								vector7.Y = (float)(Math.Floor((double)(vector7.Y / num12)) * (double)num12);
							}
							else if (vector7.Y >= 1.5f)
							{
								vector7.Y = (float)(Math.Ceiling((double)(vector7.Y / num12)) * (double)num12);
							}
							if (vector9.Y > 3f - num12)
							{
								vector9.Y = 3f;
							}
							else if (vector9.Y < 1.5f)
							{
								vector9.Y = (float)(Math.Floor((double)(vector9.Y / num12)) * (double)num12);
							}
							else if (vector9.Y >= 1.5f)
							{
								vector9.Y = (float)(Math.Ceiling((double)(vector9.Y / num12)) * (double)num12);
							}
							if (vector8.Y > 3f - num12)
							{
								vector8.Y = 3f;
							}
							else if (vector8.Y < 1.5f)
							{
								vector8.Y = (float)(Math.Floor((double)(vector8.Y / num12)) * (double)num12);
							}
							else if (vector8.Y >= 1.5f)
							{
								vector8.Y = (float)(Math.Ceiling((double)(vector8.Y / num12)) * (double)num12);
							}
							if (vector10.Y > 3f - num12)
							{
								vector10.Y = 3f;
							}
							else if (vector10.Y < 1.5f)
							{
								vector10.Y = (float)(Math.Floor((double)(vector10.Y / num12)) * (double)num12);
							}
							else if (vector10.Y >= 1.5f)
							{
								vector10.Y = (float)(Math.Ceiling((double)(vector10.Y / num12)) * (double)num12);
							}
							if (class2.IsDiagonal)
							{
								vector7.X = (float)(Math.Sqrt((double)(vector7.X * vector7.X + vector7.X * vector7.X)) * ((vector7.X < 0f) ? -1.0 : 1.0));
								vector9.X = (float)(Math.Sqrt((double)(vector9.X * vector9.X + vector9.X * vector9.X)) * ((vector9.X < 0f) ? -1.0 : 1.0));
								vector8.X = (float)(Math.Sqrt((double)(vector8.X * vector8.X + vector8.X * vector8.X)) * ((vector8.X < 0f) ? -1.0 : 1.0));
								vector10.X = (float)(Math.Sqrt((double)(vector10.X * vector10.X + vector10.X * vector10.X)) * ((vector10.X < 0f) ? -1.0 : 1.0));
							}
							this.vector3_0 = vector7;
							this.vector3_1 = vector9;
							this.vector3_2 = vector8;
							this.vector3_3 = vector10;
							for (int j = 5; j < 725; j++)
							{
								Vector3 scale = new Vector3(Vector3.Distance(vector7, vector9), Vector3.Distance(vector7, vector9), 0f);
								Matrix transformation2 = Matrix.Identity * Matrix.Scaling(scale) * Matrix.Translation(vector7) * Matrix.Translation(0f, 0f, class2.IsDiagonal ? 0f : -0.426f) * Matrix.RotationY((float)(class2.IsDiagonal ? 45 : 0) * 0.017453292f);
								Vector3 vector11 = Vector3.TransformCoordinate(this.struct6_0[j].position, transformation2);
								Vector3 vector12 = Vector3.Project(vector11, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
								this.struct6_0[j].position = new Vector3(vector12.X, vector12.Y, 0f);
							}
							vector7 = Vector3.Project(vector7, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
							vector8 = Vector3.Project(vector8, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
							vector9 = Vector3.Project(vector9, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
							vector10 = Vector3.Project(vector10, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_2 * matrix_1 * matrix_0);
							this.struct6_0[0].position = new Vector3(vector7.X, vector7.Y, 0f);
							this.struct6_0[1].position = new Vector3(vector9.X, vector9.Y, 0f);
							this.struct6_0[2].position = new Vector3(vector8.X, vector8.Y, 0f);
							this.struct6_0[3].position = new Vector3(vector10.X, vector10.Y, 0f);
							this.struct6_0[4].position = new Vector3(vector7.X, vector7.Y, 0f);
							class2.vertexBuffer_0.Unlock();
						}
					}
					this.int_0 = 5;
					DataStream dataStream2 = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
					dataStream2.WriteRange<Class112.Struct6>(this.struct6_0, 0, 725);
					this.vertexBuffer_0.Unlock();
					dataStream2.Dispose();
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0001EC54 File Offset: 0x0001CE54
		public bool imethod_2(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2)
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
				this.bool_0 = true;
				result = true;
			}
			return result;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0001EC90 File Offset: 0x0001CE90
		public void imethod_3(Device device_0)
		{
			if (WallmaskControls.smethod_0().Visible)
			{
				Class140 @class = Class140.smethod_0();
				SlimDX.Direct3D9.Font textFont = Class132.smethod_0().TextFont;
				Texture blankTexture = Class132.smethod_0().BlankTexture;
				@class.method_9(RenderState.ZEnable, false);
				Sprite sprite = new Sprite(@class.Device);
				sprite.Begin(SpriteFlags.AlphaBlend);
				string text = "Wallmask edit enabled...";
				int width = textFont.MeasureString(sprite, text, DrawTextFormat.Left).Width + 8;
				int height = textFont.MeasureString(sprite, text, DrawTextFormat.Left).Height + 4;
				sprite.Draw(blankTexture, new Rectangle?(new Rectangle(0, 0, width, height)), new Vector3?(Vector3.Zero), new Vector3?(new Vector3(10f, 10f, 0f)), Color.Black);
				textFont.DrawString(sprite, text, 8, 40, Color.Black);
				sprite.End();
				sprite.Dispose();
				if (this.bool_0 && this.int_0 > 0)
				{
					VertexDeclaration vertexDeclaration = device_0.VertexDeclaration;
					device_0.VertexFormat = Class112.Struct6.vertexFormat_0;
					device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct6.SizeInBytes);
					Class140.smethod_0().method_40("SelectionLine");
					Class140.smethod_0().method_31("g_ambient", Color.White);
					if (!WallmaskControls.smethod_0().circleadd.Checked && !WallmaskControls.smethod_0().circleremove.Checked)
					{
						int num = Class140.smethod_0().method_36();
						for (int i = 0; i < num; i++)
						{
							Class140.smethod_0().method_38(i);
							device_0.DrawPrimitives(PrimitiveType.LineStrip, 0, this.int_0 - 1);
							Class140.smethod_0().method_39();
						}
					}
					else
					{
						int num2 = Class140.smethod_0().method_36();
						for (int j = 0; j < num2; j++)
						{
							Class140.smethod_0().method_38(j);
							device_0.DrawPrimitives(PrimitiveType.LineStrip, 5, 719);
							Class140.smethod_0().method_39();
						}
					}
					Class140.smethod_0().method_37();
					device_0.VertexDeclaration = vertexDeclaration;
				}
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000143 RID: 323 RVA: 0x0001EEB0 File Offset: 0x0001D0B0
		// (remove) Token: 0x06000144 RID: 324 RVA: 0x0001EEE8 File Offset: 0x0001D0E8
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

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000145 RID: 325 RVA: 0x0001EF20 File Offset: 0x0001D120
		// (remove) Token: 0x06000146 RID: 326 RVA: 0x0001EF58 File Offset: 0x0001D158
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

		// Token: 0x06000147 RID: 327 RVA: 0x00002A71 File Offset: 0x00000C71
		public void imethod_4(int int_1)
		{
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000031F7 File Offset: 0x000013F7
		public void imethod_5()
		{
			WallmaskControls.smethod_0().Visible = false;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00003206 File Offset: 0x00001406
		private void button1_Click(object sender, EventArgs e)
		{
			Class132.smethod_0().SelectionDialog = null;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00003215 File Offset: 0x00001415
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0001EF90 File Offset: 0x0001D190
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(WallmaskControls));
			this.removeSelection = new CheckBox();
			this.addSelection = new CheckBox();
			this.circleadd = new CheckBox();
			this.circleremove = new CheckBox();
			this.button1 = new Button();
			base.SuspendLayout();
			this.removeSelection.Appearance = Appearance.Button;
			this.removeSelection.Checked = true;
			this.removeSelection.CheckState = CheckState.Checked;
			this.removeSelection.Dock = DockStyle.Left;
			this.removeSelection.Image = (Image)componentResourceManager.GetObject("removeSelection.Image");
			this.removeSelection.Location = new Point(4, 4);
			this.removeSelection.Name = "removeSelection";
			this.removeSelection.Size = new Size(24, 24);
			this.removeSelection.TabIndex = 3;
			this.removeSelection.UseVisualStyleBackColor = true;
			this.removeSelection.Click += this.removeSelection_Click;
			this.addSelection.Appearance = Appearance.Button;
			this.addSelection.Dock = DockStyle.Left;
			this.addSelection.Image = (Image)componentResourceManager.GetObject("addSelection.Image");
			this.addSelection.Location = new Point(28, 4);
			this.addSelection.Name = "addSelection";
			this.addSelection.Size = new Size(24, 24);
			this.addSelection.TabIndex = 5;
			this.addSelection.UseVisualStyleBackColor = true;
			this.addSelection.Click += this.addSelection_Click;
			this.circleadd.Appearance = Appearance.Button;
			this.circleadd.Dock = DockStyle.Left;
			this.circleadd.Image = (Image)componentResourceManager.GetObject("circleadd.Image");
			this.circleadd.Location = new Point(76, 4);
			this.circleadd.Name = "circleadd";
			this.circleadd.Size = new Size(24, 24);
			this.circleadd.TabIndex = 8;
			this.circleadd.UseVisualStyleBackColor = true;
			this.circleadd.Click += this.circleadd_Click;
			this.circleremove.Appearance = Appearance.Button;
			this.circleremove.Dock = DockStyle.Left;
			this.circleremove.Image = (Image)componentResourceManager.GetObject("circleremove.Image");
			this.circleremove.Location = new Point(52, 4);
			this.circleremove.Name = "circleremove";
			this.circleremove.Size = new Size(24, 24);
			this.circleremove.TabIndex = 7;
			this.circleremove.UseVisualStyleBackColor = true;
			this.circleremove.Click += this.circleremove_Click;
			this.button1.Dock = DockStyle.Right;
			this.button1.Location = new Point(505, 4);
			this.button1.Name = "button1";
			this.button1.Size = new Size(44, 24);
			this.button1.TabIndex = 9;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += this.button1_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(182, 225, 131);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.circleadd);
			base.Controls.Add(this.circleremove);
			base.Controls.Add(this.addSelection);
			base.Controls.Add(this.removeSelection);
			base.Name = "WallmaskControls";
			base.Padding = new Padding(4);
			base.Size = new Size(553, 32);
			base.Paint += this.WallmaskControls_Paint;
			base.ResumeLayout(false);
		}

		// Token: 0x04000126 RID: 294
		private List<Point> list_0 = new List<Point>();

		// Token: 0x04000127 RID: 295
		private Class112.Struct6[] struct6_0;

		// Token: 0x04000128 RID: 296
		private int int_0;

		// Token: 0x04000129 RID: 297
		private VertexBuffer vertexBuffer_0;

		// Token: 0x0400012A RID: 298
		private bool bool_0;

		// Token: 0x0400012B RID: 299
		public List<Class102.Class107> list_1;

		// Token: 0x0400012C RID: 300
		private static WallmaskControls wallmaskControls_0;

		// Token: 0x0400012D RID: 301
		private Vector3 vector3_0;

		// Token: 0x0400012E RID: 302
		private Vector3 vector3_1;

		// Token: 0x0400012F RID: 303
		private Vector3 vector3_2;

		// Token: 0x04000130 RID: 304
		private Vector3 vector3_3;

		// Token: 0x04000131 RID: 305
		private Delegate4 delegate4_0;

		// Token: 0x04000132 RID: 306
		private Delegate5 delegate5_0;

		// Token: 0x04000133 RID: 307
		private IContainer icontainer_0;

		// Token: 0x04000134 RID: 308
		public CheckBox removeSelection;

		// Token: 0x04000135 RID: 309
		public CheckBox addSelection;

		// Token: 0x04000136 RID: 310
		public CheckBox circleadd;

		// Token: 0x04000137 RID: 311
		public CheckBox circleremove;

		// Token: 0x04000138 RID: 312
		private Button button1;
	}
}
