using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ns13;
using ns14;
using ns17;
using ns3;
using ns6;
using ns8;
using Package;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns16
{
	// Token: 0x020000D5 RID: 213
	internal sealed partial class GenerateWallmask : Form
	{
		// Token: 0x060008CA RID: 2250 RVA: 0x0007A5DC File Offset: 0x000787DC
		public GenerateWallmask()
		{
			this.InitializeComponent();
			this.class105_0 = (Class132.smethod_0().Renderables[0] as Class105);
			this.class105_0.UseTempWallmask = true;
			this.class105_0.TempWallmasks = new List<DDS>();
			this.colorMap_0 = new ColorMap[2];
			this.colorMap_0[0] = new ColorMap();
			this.colorMap_0[1] = new ColorMap();
			this.colorMap_0[0].OldColor = Color.Black;
			this.colorMap_0[0].NewColor = Color.White;
			this.colorMap_0[1].OldColor = Color.White;
			this.colorMap_0[1].NewColor = Color.Black;
			this.int_0 = 1;
			this.method_3();
			this.method_0();
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0007A6B8 File Offset: 0x000788B8
		private void method_0()
		{
			this.class105_0.TempWallmasks.Clear();
			Bitmap bitmap_ = new Bitmap(this.bitmap_0);
			Bitmap bitmap = this.method_1(bitmap_);
			Bitmap bitmap_2 = new Bitmap(this.bitmap_1);
			Bitmap bitmap2 = this.method_1(bitmap_2);
			int num = 0;
			for (int i = 0; i < this.int_2 * 2; i++)
			{
				if (i > 0)
				{
					num += ((i % 2 == 0) ? 1 : 0);
				}
				DDS dds = new DDS();
				Bitmap image = (i % 2 == 0) ? bitmap : bitmap2;
				MemoryStream memoryStream = new MemoryStream();
				Bitmap bitmap3 = new Bitmap(64, 128);
				Graphics graphics = Graphics.FromImage(bitmap3);
				Rectangle srcRect = new Rectangle(64 * num, 0, 64, 128);
				Rectangle destRect = new Rectangle(0, 0, 64, 128);
				graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
				bitmap3.Save(memoryStream, ImageFormat.Bmp);
				memoryStream.Position = 0L;
				Texture texture = Texture.FromStream(Class132.smethod_0().Device, memoryStream, Usage.None, Pool.Managed);
				DataStream dataStream = BaseTexture.ToStream(texture, ImageFileFormat.Dds);
				byte[] array = new byte[dataStream.Length];
				dataStream.Position = 0L;
				dataStream.Read(array, 0, (int)dataStream.Length);
				dds.SetData(array);
				texture.Dispose();
				dataStream.Dispose();
				this.class105_0.TempWallmasks.Add(dds);
			}
			this.class105_0.WallDirty = true;
			Class132.mainForm.Render();
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x0007A844 File Offset: 0x00078A44
		private Bitmap method_1(Bitmap bitmap_2)
		{
			int num = Math.Abs(this.feather.Value);
			if (this.feather.Value > 0)
			{
				Class42.smethod_2(bitmap_2, this.colorMap_0);
			}
			for (int i = 0; i < num; i++)
			{
				Class42.smethod_0(bitmap_2, 1);
				Class42.smethod_4(bitmap_2, this.threshold.Value);
			}
			if (this.feather.Value > 0)
			{
				Class42.smethod_2(bitmap_2, this.colorMap_0);
			}
			Bitmap bitmap = new Bitmap(bitmap_2);
			bitmap.MakeTransparent(Color.Black);
			return bitmap;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0007A8D4 File Offset: 0x00078AD4
		private void method_2()
		{
			bool flag = true;
			Bitmap bitmap_ = new Bitmap(this.bitmap_0);
			for (;;)
			{
				Bitmap image = this.method_1(bitmap_);
				if (flag)
				{
					this.previewFront.Image = image;
				}
				else
				{
					this.previewBack.Image = image;
				}
				if (!flag)
				{
					break;
				}
				flag = false;
				bitmap_ = new Bitmap(this.bitmap_1);
			}
			this.int_1 = this.feather.Value;
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0007A940 File Offset: 0x00078B40
		private void method_3()
		{
			this.bool_0 = this.onlyGlass.Checked;
			if (this.bool_0)
			{
				this.method_4();
			}
			else
			{
				this.bool_0 = true;
				this.method_4();
				Bitmap bitmap = new Bitmap(this.bitmap_0);
				bitmap.MakeTransparent(Color.White);
				Bitmap bitmap2 = new Bitmap(this.bitmap_1);
				bitmap2.MakeTransparent(Color.White);
				this.bool_0 = false;
				this.method_4();
				Graphics graphics = Graphics.FromImage(this.bitmap_0);
				Rectangle rectangle = new Rectangle(0, 0, this.bitmap_0.Width, this.bitmap_0.Height);
				graphics.DrawImage(bitmap, rectangle, rectangle, GraphicsUnit.Pixel);
				graphics = Graphics.FromImage(this.bitmap_1);
				graphics.DrawImage(bitmap2, rectangle, rectangle, GraphicsUnit.Pixel);
			}
			this.method_2();
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x0007AA0C File Offset: 0x00078C0C
		private void method_4()
		{
			MeshEditor meshEditor = Class132.smethod_0();
			Device device = meshEditor.Device;
			Vector3[] array = meshEditor.Renderables[0].imethod_13();
			Surface renderTarget = device.GetRenderTarget(0);
			Class102 @class = meshEditor.Renderables[0];
			float num = (float)this.distance.Value / 1000f;
			float num2 = @class.Footprints[0].Slot.BoundingBox[2];
			float num3 = @class.Footprints[0].Slot.BoundingBox[0];
			float num4 = num2 - num3;
			this.int_2 = ((num4 <= 1f) ? 1 : ((num4 <= 2f) ? 2 : 3));
			Texture texture = new Texture(device, this.int_0 * 64 * this.int_2, this.int_0 * 128, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
			Texture texture2 = new Texture(device, this.int_0 * 64 * this.int_2, this.int_0 * 128, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
			meshEditor.EffectsDisabled = true;
			bool flag = true;
			bool wireframe = meshEditor.Wireframe;
			meshEditor.Wireframe = false;
			for (;;)
			{
				Texture texture3 = flag ? texture : texture2;
				device.SetRenderTarget(0, texture3.GetSurfaceLevel(0));
				device.BeginScene();
				Class140.smethod_0().method_40("WallMask");
				Class140.smethod_0().method_12(new Vector4(1f, 1f, 1f, 1f), new Vector4(0f, 0f, 0f, 0f));
				float num5 = (float)this.feather.Value / 30f;
				float num6 = (array[0].Z + array[1].Z) / 2f;
				float z = flag ? (10f + num6 + num) : (-10f + num6 - num);
				Matrix matrix_ = Matrix.OrthoRH((float)this.int_2, 3f, 0f, (float)(this.bool_0 ? 20 : 10));
				Matrix matrix_2 = Matrix.Translation(0f, 0f, 0f) * Matrix.Identity;
				Vector3 vector = new Vector3(0f, 1.5f, z);
				Matrix matrix_3 = Matrix.LookAtRH(vector, new Vector3(vector.X, vector.Y, 0f), new Vector3(0f, 1f, 0f));
				Class140.smethod_0().method_32(matrix_2, matrix_3);
				Class140.smethod_0().method_25("g_mProj", matrix_);
				Matrix identity = Matrix.Identity;
				Class140.smethod_0().method_25("g_mObjTrans", identity);
				Class140.smethod_0().method_23("g_vEye", vector);
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_9(RenderState.ZEnable, true);
				Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
				Class140.smethod_0().method_9(RenderState.AlphaTestEnable, false);
				Class140.smethod_0().method_9(RenderState.SeparateAlphaBlendEnable, false);
				device.Clear(ClearFlags.ZBuffer | ClearFlags.Target, Color.White, 1f, 0);
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
				Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
				device.EnableLight(0, false);
				device.EnableLight(1, false);
				Class140.smethod_0().method_9(RenderState.Lighting, false);
				Class140.smethod_0().method_9(RenderState.ZEnable, true);
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
				foreach (Class102 class2 in meshEditor.Renderables)
				{
					foreach (KeyValuePair<MLOD.MLODEntry, Interface9> keyValuePair in class2.Objects)
					{
						MATD.MATDShader shader = keyValuePair.Value.Matd.Shader;
						if (shader == (MATD.MATDShader)3231479170U || (this.bool_0 && shader != MATD.MATDShader.GlassForFences && shader != MATD.MATDShader.GlassForObjects && shader != (MATD.MATDShader)2224877601U && shader != (MATD.MATDShader)2178752589U && shader != MATD.MATDShader.GlassForRabbitHoles))
						{
							keyValuePair.Value.Tag = keyValuePair.Value.Visible;
							keyValuePair.Value.Visible = false;
						}
					}
					bool displayWall = class2.DisplayWall;
					class2.DisplayWall = false;
					class2.imethod_0(matrix_2, matrix_3, device);
					class2.DisplayWall = displayWall;
					foreach (KeyValuePair<MLOD.MLODEntry, Interface9> keyValuePair2 in class2.Objects)
					{
						MATD.MATDShader shader2 = keyValuePair2.Value.Matd.Shader;
						if (shader2 == (MATD.MATDShader)3231479170U || (this.bool_0 && shader2 != MATD.MATDShader.GlassForFences && shader2 != MATD.MATDShader.GlassForObjects && shader2 != (MATD.MATDShader)2224877601U && shader2 != (MATD.MATDShader)2178752589U && shader2 != MATD.MATDShader.GlassForRabbitHoles))
						{
							keyValuePair2.Value.Visible = (bool)keyValuePair2.Value.Tag;
						}
					}
				}
				device.EndScene();
				device.Present();
				if (flag)
				{
					this.bitmap_0 = new Bitmap(BaseTexture.ToStream(texture3, ImageFileFormat.Png));
				}
				else
				{
					this.bitmap_1 = new Bitmap(BaseTexture.ToStream(texture3, ImageFileFormat.Png));
				}
				texture3.Dispose();
				if (!flag)
				{
					break;
				}
				flag = false;
			}
			device.SetRenderTarget(0, renderTarget);
			meshEditor.EffectsDisabled = false;
			meshEditor.Wireframe = wireframe;
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00005FE0 File Offset: 0x000041E0
		private void onlyGlass_CheckedChanged(object sender, EventArgs e)
		{
			this.method_3();
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x0007B00C File Offset: 0x0007920C
		private void threshold_ValueChanged(object sender, EventArgs e)
		{
			this.featherLbl.Text = "Feather amount: " + this.feather.Value;
			this.thresholdLbl.Text = "Threshold: " + this.threshold.Value;
			this.method_2();
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00002A71 File Offset: 0x00000C71
		private void cancelBtn_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0007B06C File Offset: 0x0007926C
		private void okBtn_Click(object sender, EventArgs e)
		{
			this.method_0();
			DBPF package = Class132.mainForm.CurrentProject.Package;
			int num = 0;
			List<int> list = new List<int>(this.int_2 * 2);
			foreach (OBJD.WallMask wallMask in this.class105_0.Objd.WallMasks)
			{
				DDS dds = this.class105_0.TempWallmasks[num];
				dds.ResKey = new ResKey(this.class105_0.Objd.TgiIndex[wallMask.DdsIndex].Reskey);
				ResKey key = new ResKey(this.class105_0.Objd.TgiIndex[wallMask.DdsIndex].AsString());
				if (package.HasEntry(key) && !list.Contains(wallMask.DdsIndex))
				{
					package.AddEntry(dds);
				}
				else
				{
					dds.CreateNewResKey((int)DateTime.Now.Ticks + num);
					package.AddEntry(dds);
					if (!list.Contains(wallMask.DdsIndex))
					{
						this.class105_0.Objd.TgiIndex[wallMask.DdsIndex].Reskey = dds.ResKey.AsString();
					}
					else
					{
						this.class105_0.Objd.TgiIndex.Add(new TGIIndex(dds.ResKey));
						wallMask.DdsIndex = this.class105_0.Objd.TgiIndex.Count - 1;
					}
				}
				list.Add(wallMask.DdsIndex);
				num++;
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00005FEA File Offset: 0x000041EA
		private void GenerateWallmask_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.class105_0.UseTempWallmask = false;
			this.class105_0.WallDirty = true;
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00002A71 File Offset: 0x00000C71
		private void feather_Scroll(object sender, EventArgs e)
		{
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00006006 File Offset: 0x00004206
		private void previewBtn_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00006010 File Offset: 0x00004210
		private void distance_ValueChanged(object sender, EventArgs e)
		{
			this.distanceLbl.Text = "Z clip: " + (float)this.distance.Value / 1000f;
			this.method_3();
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00006046 File Offset: 0x00004246
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040006F9 RID: 1785
		private Class105 class105_0;

		// Token: 0x040006FA RID: 1786
		private Bitmap bitmap_0;

		// Token: 0x040006FB RID: 1787
		private Bitmap bitmap_1;

		// Token: 0x040006FC RID: 1788
		private int int_0 = 1;

		// Token: 0x040006FD RID: 1789
		private int int_1;

		// Token: 0x040006FE RID: 1790
		private ColorMap[] colorMap_0;

		// Token: 0x040006FF RID: 1791
		private int int_2;

		// Token: 0x04000700 RID: 1792
		private bool bool_0;

		// Token: 0x04000701 RID: 1793
		private IContainer icontainer_0;
	}
}
