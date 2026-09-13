using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ns10;
using ns13;
using ns16;
using ns2;
using ns6;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns21
{
	// Token: 0x0200011E RID: 286
	internal class Class133
	{
		// Token: 0x06000CE0 RID: 3296 RVA: 0x000A0A6C File Offset: 0x0009EC6C
		public Class133()
		{
			Bitmap bitmap = new Bitmap(256, 256);
			Graphics.FromImage(bitmap).FillRectangle(new SolidBrush(Color.FromArgb(180, Color.Yellow)), new Rectangle(0, 0, 256, 256));
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Bmp);
			memoryStream.Position = 0L;
			this.texture_0 = Texture.FromStream(Class140.smethod_0().Device, memoryStream);
			memoryStream.Dispose();
			bitmap.Dispose();
			System.Drawing.Font font = new System.Drawing.Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
			this.font_0 = new SlimDX.Direct3D9.Font(Class140.smethod_0().Device, font);
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x00007333 File Offset: 0x00005533
		public virtual void vmethod_0(bool bool_0)
		{
			if (bool_0)
			{
				this.font_0.Dispose();
				this.texture_0.Dispose();
			}
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void vmethod_1()
		{
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void vmethod_2(IProjectModel iprojectModel_0)
		{
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void imethod_4()
		{
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void imethod_5()
		{
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void vmethod_3(Device device_0)
		{
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x000A0B2C File Offset: 0x0009ED2C
		public virtual void vmethod_4(string string_0, int int_0, int int_1)
		{
			Class140 @class = Class140.smethod_0();
			Class140.smethod_0().method_9(RenderState.ZEnable, false);
			Sprite sprite = new Sprite(@class.Device);
			sprite.Begin(SpriteFlags.AlphaBlend);
			int width = this.font_0.MeasureString(sprite, string_0, DrawTextFormat.Left).Width + 8;
			int height = this.font_0.MeasureString(sprite, string_0, DrawTextFormat.Left).Height + 4;
			sprite.Draw(this.texture_0, new Rectangle?(new Rectangle(0, 0, width, height)), new Vector3?(Vector3.Zero), new Vector3?(new Vector3((float)int_0, (float)int_1, 0f)), Color.White);
			this.font_0.DrawString(sprite, string_0, int_0 + 4, int_1 + 2, Color.Black);
			sprite.End();
			sprite.Dispose();
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00007350 File Offset: 0x00005550
		public virtual void vmethod_5(MeshEditor meshEditor_0, Device device_0, Matrix matrix_0)
		{
			this.method_0(meshEditor_0, device_0, matrix_0, false);
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x000A0C08 File Offset: 0x0009EE08
		public void method_0(MeshEditor meshEditor_0, Device device_0, Matrix matrix_0, bool bool_0)
		{
			Interface9[] array = meshEditor_0.method_45();
			foreach (Interface9 @interface in array)
			{
				device_0.Indices = @interface.IndexBuffer;
				device_0.SetStreamSource(0, @interface.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
				Class140.smethod_0().method_40("FlatShade");
				Class140.smethod_0().method_33(@interface.Palette);
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
				Class140.smethod_0().method_9(RenderState.ZEnable, bool_0);
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
				Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
				Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
				Class140.smethod_0().method_28("g_forcedTransparency", bool_0 ? 1f : 0.1f);
				if (@interface is Class121)
				{
					Class140.smethod_0().method_27("isSkinned", (@interface as Class121).Skinned);
				}
				else
				{
					Class140.smethod_0().method_27("isSkinned", true);
				}
				Class140.smethod_0().method_30("g_ambient", Color.LightBlue.ToArgb());
				Class140.smethod_0().method_35();
				int num = Class140.smethod_0().method_36();
				for (int j = 0; j < num; j++)
				{
					Class140.smethod_0().method_38(j);
					device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, @interface.VertexCount, @interface.IBUFOffset, @interface.FaceCount);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				Class140.smethod_0().method_40("Line");
				Class140.smethod_0().method_28("g_forcedTransparency", bool_0 ? 0.5f : 0.4f);
				Class140.smethod_0().method_30("g_ambient", Color.White.ToArgb());
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Wireframe);
				num = Class140.smethod_0().method_36();
				for (int k = 0; k < num; k++)
				{
					Class140.smethod_0().method_38(k);
					device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, @interface.VertexCount, @interface.IBUFOffset, @interface.FaceCount);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, false);
				Class140.smethod_0().method_40("Line");
				Class140.smethod_0().method_30("g_ambient", Color.White.ToArgb());
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Point);
				Class140.smethod_0().method_9(RenderState.PointSize, 3f);
				Class140.smethod_0().method_28("g_forcedTransparency", 1f);
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, false);
				Class140.smethod_0().method_28("g_forcedTransparency", 0.8f);
				num = Class140.smethod_0().method_36();
				for (int l = 0; l < num; l++)
				{
					Class140.smethod_0().method_38(l);
					device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, @interface.VertexCount, @interface.IBUFOffset, @interface.FaceCount);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				Class140.smethod_0().method_30("g_ambient", Color.Red.ToArgb());
				device_0.Indices = @interface.SelectedIndexBuffer;
				num = Class140.smethod_0().method_36();
				for (int m = 0; m < num; m++)
				{
					Class140.smethod_0().method_38(m);
					device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, @interface.VertexCount, 0, @interface.CurrentSelectionIndex.Count);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				Class140.smethod_0().method_28("g_forcedTransparency", 1f);
			}
		}

		// Token: 0x040009C6 RID: 2502
		protected Texture texture_0;

		// Token: 0x040009C7 RID: 2503
		protected SlimDX.Direct3D9.Font font_0;
	}
}
