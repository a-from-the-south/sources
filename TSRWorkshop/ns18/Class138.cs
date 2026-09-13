using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ns10;
using ns12;
using ns13;
using ns16;
using ns2;
using ns21;
using ns6;
using ns8;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns18
{
	// Token: 0x02000127 RID: 295
	internal sealed class Class138 : Class133, EditorToolBox.Interface0
	{
		// Token: 0x06000D6F RID: 3439 RVA: 0x000A8450 File Offset: 0x000A6650
		public static Class138 smethod_0()
		{
			if (Class138.class138_0 == null)
			{
				Class138.class138_0 = new Class138(Class140.smethod_0().Device);
			}
			return Class138.class138_0;
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x00007766 File Offset: 0x00005966
		public void method_1(bool bool_0)
		{
			base.vmethod_0(bool_0);
			if (this.texture_2 != null)
			{
				this.texture_2.Dispose();
			}
			if (bool_0)
			{
				this.texture_1.Dispose();
			}
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x000A8484 File Offset: 0x000A6684
		public unsafe override void vmethod_3(Device device_0)
		{
			this.texture_2 = new Texture(device_0, 512, 1024, 0, Usage.Dynamic, Format.A8R8G8B8, Pool.Default);
			Texture texture = this.texture_2;
			DataRectangle dataRectangle = texture.LockRectangle(0, LockFlags.None);
			byte* ptr = (byte*)((void*)dataRectangle.Data.DataPointer);
			int num = 0;
			while ((long)num < dataRectangle.Data.Length)
			{
				ptr[num] = 0;
				ptr[num + 1] = 0;
				ptr[num + 2] = 0;
				ptr[num + 3] = byte.MaxValue;
				num += 4;
			}
			texture.UnlockRectangle(0);
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x000A8510 File Offset: 0x000A6710
		public Class138(Device device)
		{
			this.vmethod_3(device);
			Bitmap bitmap = new Bitmap(32, 32);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawArc(Pens.Black, new Rectangle(0, 0, 32, 32), 0f, 360f);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Bmp);
			memoryStream.Position = 0L;
			this.texture_1 = Texture.FromStream(device, memoryStream, Usage.None, Pool.Managed);
			memoryStream.Dispose();
			bitmap.Dispose();
			graphics.Dispose();
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x000A85AC File Offset: 0x000A67AC
		public void imethod_3(MeshEditor meshEditor_0, Device device_0, Matrix matrix_0)
		{
			Interface9[] array = meshEditor_0.method_45();
			foreach (Interface9 @interface in array)
			{
				if (@interface is Class121)
				{
					Class132.smethod_0().method_30((@interface as Class121).Matd);
				}
				device_0.Indices = @interface.IndexBuffer;
				device_0.SetStreamSource(0, @interface.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
				Class140.smethod_0().method_14(this.texture_2);
				Class140.smethod_0().method_40("FlatShade");
				Class140.smethod_0().method_33(@interface.Palette);
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
				Class140.smethod_0().method_9(RenderState.ZEnable, true);
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
				Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
				Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
				Class140.smethod_0().method_28("g_forcedTransparency", 1f);
				Class140.smethod_0().method_27("isSkinned", true);
				Class140.smethod_0().method_30("g_ambient", Color.White.ToArgb());
				Class140.smethod_0().method_35();
				int num = Class140.smethod_0().method_36();
				for (int j = 0; j < num; j++)
				{
					Class140.smethod_0().method_38(j);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				Class140.smethod_0().method_40("FlatShadeTexture");
				Class140.smethod_0().method_30("g_ambient", Color.Red.ToArgb());
				Class140.smethod_0().method_9(RenderState.ZEnable, true);
				Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
				num = Class140.smethod_0().method_36();
				for (int k = 0; k < num; k++)
				{
					Class140.smethod_0().method_38(k);
					device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, @interface.VertexCount, @interface.IBUFOffset, @interface.FaceCount);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				device_0.Indices = @interface.SelectedIndexBuffer;
				Class140.smethod_0().method_40("FlatShade");
				Class140.smethod_0().method_9(RenderState.ZEnable, false);
				Class140.smethod_0().method_30("g_ambient", Color.Green.ToArgb());
				num = Class140.smethod_0().method_36();
				for (int l = 0; l < num; l++)
				{
					Class140.smethod_0().method_38(l);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				Class140.smethod_0().method_28("g_forcedTransparency", 1f);
			}
			if ((Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				Sprite sprite = new Sprite(device_0);
				sprite.Begin(SpriteFlags.AlphaBlend);
				sprite.Draw(this.texture_1, new Vector3?(new Vector3(16f, 16f, 0f)), new Vector3?(new Vector3((float)this.point_0.X, (float)this.point_0.Y, 0f)), new Color4(Color.White));
				sprite.End();
				sprite.Dispose();
			}
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool imethod_0(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			return false;
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x000A8900 File Offset: 0x000A6B00
		public bool imethod_1(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			return this.imethod_2(meshEditor_0, viewport_0, mouseEventArgs_0);
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x00057BB8 File Offset: 0x00055DB8
		public static bool smethod_1(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, Vector3 vector3_3, Vector3 vector3_4, out float float_0, out float float_1, out float float_2)
		{
			float_0 = 0f;
			float_1 = 0f;
			float_2 = 0f;
			Vector3 vector = vector3_3 - vector3_2;
			Vector3 vector2 = vector3_4 - vector3_2;
			Vector3 right = Vector3.Cross(vector3_1, vector2);
			float num = Vector3.Dot(vector, right);
			bool result;
			if (num > -1E-05f)
			{
				result = false;
			}
			else
			{
				float num2 = 1f / num;
				Vector3 left = vector3_0 - vector3_2;
				float_1 = Vector3.Dot(left, right) * num2;
				if (float_1 >= -0.001f && float_1 <= 1.001f)
				{
					Vector3 right2 = Vector3.Cross(left, vector);
					float_2 = Vector3.Dot(vector3_1, right2) * num2;
					if (float_2 >= -0.001f && float_1 + float_2 <= 1.001f)
					{
						float_0 = Vector3.Dot(vector2, right2) * num2;
						if (float_0 <= 0f)
						{
							result = false;
						}
						else
						{
							result = true;
						}
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x000A891C File Offset: 0x000A6B1C
		public unsafe bool imethod_2(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			this.point_0 = mouseEventArgs_0.Location;
			bool result;
			if (mouseEventArgs_0.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Control) == Keys.None)
			{
				new Rectangle(this.point_0.X - 16, this.point_0.Y - 16, 32, 32);
				Vector3 vector = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3 vector2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				new Ray(vector, Vector3.Normalize(vector2));
				Interface9[] array = meshEditor_0.method_45();
				foreach (Interface9 @interface in array)
				{
					if (@interface is Class121)
					{
						@interface.CurrentSelectionIndex.Clear();
						long ibufoffset = (@interface as Class121).MLODEntry.IBUFOffset;
						long vbufoffset = (@interface as Class121).MLODEntry.VBUFOffset;
						DataStream dataStream = @interface.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
						DataStream dataStream2 = @interface.IndexBuffer.Lock(0, 0, LockFlags.None);
						Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
						short* ptr2 = (short*)((void*)dataStream2.DataPointer);
						float num = float.MaxValue;
						int num2 = 0;
						int num3 = 0;
						int num4 = 0;
						Vector3 vector3 = Vector3.Zero;
						Vector3 vector4 = Vector3.Zero;
						Vector3 vector5 = Vector3.Zero;
						for (int j = 0; j < @interface.FaceCount; j++)
						{
							short num5 = ptr2[j * 3 + 2];
							short num6 = ptr2[j * 3 + 1];
							short num7 = ptr2[j * 3];
							Vector3 position = ptr[num5].position;
							Vector3 position2 = ptr[num6].position;
							Vector3 position3 = ptr[num7].position;
							float num8 = 0f;
							float scale = 0f;
							float scale2 = 0f;
							if (Class138.smethod_1(vector, vector2, position, position2, position3, out num8, out scale, out scale2))
							{
								Vector3 value = position + scale * (position2 - position) + scale2 * (position3 - position);
								float num9 = Vector3.Distance(vector, value);
								if (num9 < num)
								{
									num = num9;
									vector3 = position;
									vector4 = position2;
									vector5 = position3;
									num2 = (int)num5;
									num3 = (int)num6;
									num4 = (int)num7;
								}
							}
						}
						if (num != 3.4028235E+38f)
						{
							int num10 = num2;
							int num11 = num3;
							int num12 = num4;
							Vector3 vector3_ = vector3;
							Vector3 vector3_2 = vector4;
							Vector3 vector3_3 = vector5;
							float num13 = 0f;
							float scale3 = 0f;
							float scale4 = 0f;
							if (Class138.smethod_1(vector, vector2, vector3_, vector3_2, vector3_3, out num13, out scale3, out scale4))
							{
								Vector2 vector6 = ptr[num10].vector2_0 + scale3 * (ptr[num11].vector2_0 - ptr[num10].vector2_0) + scale4 * (ptr[num12].vector2_0 - ptr[num10].vector2_0);
								int num14 = Math.Max(0, Math.Min((int)(512f * (vector6.X * 3.051851E-05f)), 512));
								int num15 = Math.Max(0, Math.Min((int)(1024f * (vector6.Y * 3.051851E-05f)), 1024));
								Math.Max(num14 - 3, 0);
								Math.Max(num15 - 3, 0);
								Math.Min(1023, num14 + 3);
								Math.Min(1023, num15 + 3);
								Texture texture = this.texture_2;
								DataRectangle dataRectangle = texture.LockRectangle(0, LockFlags.None);
								byte* ptr3 = (byte*)((void*)dataRectangle.Data.DataPointer);
								for (float num16 = 14f; num16 > 0f; num16 -= 1f)
								{
									for (float num17 = 0f; num17 < 90f; num17 += 1f)
									{
										double num18 = (double)num17 * 0.017453292519943295;
										int num19 = (int)(Math.Sin(num18) * (double)num16);
										int num20 = (int)(Math.Cos(num18) * (double)num16);
										int num21 = num14 + num19;
										int num22 = num15 + num20;
										int num23 = (num22 * 512 + num21) * 4;
										if (num23 >= 0 && (long)num23 < dataRectangle.Data.Length)
										{
											byte b = (byte)((int)(5f * (1f - num16 / 14f)));
											byte b2 = ptr3[num23 + 2];
											ptr3[num23] = 0;
											ptr3[num23 + 1] = 0;
											ptr3[num23 + 2] = (byte)Math.Min(255, (int)(b2 + b));
											ptr3[num23 + 3] = byte.MaxValue;
										}
										num21 = num14 + num19;
										num22 = num15 - num20;
										num23 = (num22 * 512 + num21) * 4;
										if (num23 >= 0 && (long)num23 < dataRectangle.Data.Length)
										{
											byte b3 = (byte)((int)(5f * (1f - num16 / 14f)));
											byte b4 = ptr3[num23 + 2];
											ptr3[num23] = 0;
											ptr3[num23 + 1] = 0;
											ptr3[num23 + 2] = (byte)Math.Min(255, (int)(b4 + b3));
											ptr3[num23 + 3] = byte.MaxValue;
										}
										num21 = num14 - num19;
										num22 = num15 - num20;
										num23 = (num22 * 512 + num21) * 4;
										if (num23 >= 0 && (long)num23 < dataRectangle.Data.Length)
										{
											byte b5 = (byte)((int)(5f * (1f - num16 / 14f)));
											byte b6 = ptr3[num23 + 2];
											ptr3[num23] = 0;
											ptr3[num23 + 1] = 0;
											ptr3[num23 + 2] = (byte)Math.Min(255, (int)(b6 + b5));
											ptr3[num23 + 3] = byte.MaxValue;
										}
										num21 = num14 - num19;
										num22 = num15 + num20;
										num23 = (num22 * 512 + num21) * 4;
										if (num23 >= 0 && (long)num23 < dataRectangle.Data.Length)
										{
											byte b7 = (byte)((int)(5f * (1f - num16 / 14f)));
											byte b8 = ptr3[num23 + 2];
											ptr3[num23] = 0;
											ptr3[num23 + 1] = 0;
											ptr3[num23 + 2] = (byte)Math.Min(255, (int)(b8 + b7));
											ptr3[num23 + 3] = byte.MaxValue;
										}
									}
								}
								texture.UnlockRectangle(0);
							}
						}
						@interface.IndexBuffer.Unlock();
						@interface.VertexBufferTransformed.Unlock();
						@interface.imethod_3();
					}
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x04000A20 RID: 2592
		private Point point_0 = default(Point);

		// Token: 0x04000A21 RID: 2593
		protected Texture texture_1;

		// Token: 0x04000A22 RID: 2594
		protected Texture texture_2;

		// Token: 0x04000A23 RID: 2595
		private static Class138 class138_0;
	}
}
