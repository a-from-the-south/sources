using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ns1;
using ns17;
using ns20;
using ns21;
using ns6;
using ns7;
using ns8;
using Package;
using Package.Sims3Files;
using Package.Squish;
using Sims3WorkshopSDK;
using Skybound.VisualTips;

namespace ns16
{
	// Token: 0x0200007F RID: 127
	internal sealed partial class ImageEditor : Form
	{
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0004C844 File Offset: 0x0004AA44
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x00004935 File Offset: 0x00002B35
		public ResKey Image
		{
			get
			{
				return this.resKey_0;
			}
			set
			{
				this.resKey_0 = value;
				this.method_1();
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0004C85C File Offset: 0x0004AA5C
		public ImageEditor()
		{
			this.InitializeComponent();
			if (ImageEditor.size_0 != Size.Empty)
			{
				base.Size = ImageEditor.size_0;
			}
			if (ImageEditor.point_0 != Point.Empty)
			{
				base.Location = ImageEditor.point_0;
			}
			this.preview.OnZoomChanged += this.method_0;
			this.preview.Select();
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0004C8D4 File Offset: 0x0004AAD4
		private void method_0(object object_0, Class51 class51_0)
		{
			if (this.preview.Zoom == 1f)
			{
				this.statusSize.Text = this.preview.DisplayWidth + " x " + this.preview.DisplayHeight;
			}
			else
			{
				this.statusSize.Text = this.preview.Zoom * 100f + "%";
			}
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0004C958 File Offset: 0x0004AB58
		private void method_1()
		{
			if (this.resKey_0 != null)
			{
				if (this.dds_0 == null)
				{
					this.dds_0 = (DDS)Class76.smethod_30(this.resKey_0, false, false);
					if (this.dds_0 == null)
					{
						return;
					}
				}
				this.dds_0.UpdateDescription();
				this.statusInfo.Text = this.dds_0.Description;
				try
				{
					if (this.dds_0.MipMaps.Length > 0)
					{
						DDS.MipMap mipMap = this.dds_0.MipMaps[0];
						Image image = ImageLoader.Load(mipMap);
						this.preview.Image = image;
						this.preview.Refresh();
						this.statusSize.Text = this.preview.DisplayWidth + " x " + this.preview.DisplayHeight;
					}
					else
					{
						this.statusSize.Text = "no mipmaps in DDS";
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error when loading preview.\n\n" + ex.Message);
				}
			}
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0004CA70 File Offset: 0x0004AC70
		private void done_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			DBPF package = Class132.mainForm.CurrentProject.Package;
			if (!package.HasEntry(new ResKey(this.dds_0.GenerateResKey())) && this.bool_0)
			{
				int seed = (int)DateTime.Now.Ticks;
				Random random = new Random(seed);
				this.dds_0.InstanceID = random.Next();
				this.dds_0.SecondInstanceID = random.Next();
				package.AddEntry(this.dds_0);
				this.resKey_0 = new TextureResKey(this.dds_0.GenerateResKey());
			}
			else if (this.bool_0)
			{
				DialogResult dialogResult = MessageBox.Show("Do you want to replace the current texture with the new texture? Clicking No will create a new texture.", "Update / Replace", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Cancel)
				{
					base.DialogResult = DialogResult.Cancel;
				}
				else if (dialogResult == DialogResult.Yes)
				{
					package.AddEntry(this.dds_0);
				}
				else if (dialogResult == DialogResult.No)
				{
					int seed2 = (int)DateTime.Now.Ticks;
					Random random2 = new Random(seed2);
					this.dds_0.InstanceID = random2.Next();
					this.dds_0.SecondInstanceID = random2.Next();
					this.resKey_0 = new TextureResKey(this.dds_0.GenerateResKey());
					package.AddEntry(this.dds_0);
				}
			}
			base.Close();
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0004CBC0 File Offset: 0x0004ADC0
		private void export_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Export Texture";
			saveFileDialog.FileName = this.resKey_0.AsString().Replace(':', '_');
			saveFileDialog.Filter = "DirectDraw Surface (*.dds)|*.dds|Tiff (*.tif)|*.tif|Png (*.png)|*.png";
			saveFileDialog.FilterIndex = ImageEditor.int_0;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				ImageEditor.int_0 = saveFileDialog.FilterIndex;
				string fileName = saveFileDialog.FileName;
				if (fileName.EndsWith(".dds"))
				{
					try
					{
						this.dds_0.SaveToFile(fileName);
						goto IL_E7;
					}
					catch (Exception ex)
					{
						MessageBox.Show("Could not save file\n\n" + ex.Message);
						goto IL_E7;
					}
				}
				try
				{
					DDS.MipMap mipMap = this.dds_0.MipMaps[0];
					Image image = ImageLoader.Load(mipMap);
					image.Save(fileName, fileName.EndsWith(".tif") ? ImageFormat.Tiff : ImageFormat.Png);
				}
				catch (Exception ex2)
				{
					MessageBox.Show("Could not save file\n\n" + ex2.Message);
				}
				IL_E7:
				MessageBox.Show(this, "Export complete", "Export complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0004CCE8 File Offset: 0x0004AEE8
		private void import_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Import texture";
			openFileDialog.FileName = this.resKey_0.AsString().Replace(':', '_');
			openFileDialog.Filter = "DirectDraw Surface (*.dds)|*.dds|Bitmap Image (*.tif, *.png)|*.tif;*.png";
			openFileDialog.FilterIndex = ImageEditor.int_0;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				ImageEditor.int_0 = openFileDialog.FilterIndex;
				string fileName = openFileDialog.FileName;
				DDS dds = new DDS();
				dds.InstanceID = this.resKey_0.InstanceId;
				dds.GroupID = this.resKey_0.GroupId;
				dds.SecondInstanceID = this.resKey_0.SecondInstanceId;
				try
				{
					if (fileName.EndsWith(".dds"))
					{
						dds.LoadFile(fileName);
					}
					else
					{
						Image image = System.Drawing.Image.FromFile(fileName);
						BitmapImportDialog bitmapImportDialog = new BitmapImportDialog((Bitmap)image);
						if (bitmapImportDialog.ShowDialog(this) != DialogResult.OK)
						{
							return;
						}
						Bitmap image2 = bitmapImportDialog.method_0();
						dds.AddImage(image2, true, bitmapImportDialog.UseAlpha ? DDS.DXTFormat.DXT5 : DDS.DXTFormat.DXT1);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Could not load DDS, either the file is corrupted or it uses a unsupported format.\n\nExited with error:\n\n" + ex.Message);
					return;
				}
				if (dds.SurfaceDesc.ddpfPixelFormat.dwFourCC != DDS.DXTFormat.RAW32 && dds.SurfaceDesc.ddpfPixelFormat.dwFourCC != DDS.DXTFormat.UNKNOWN)
				{
					this.dds_0 = dds;
				}
				else if (MessageBox.Show(this, "This is a uncompressed DDS file. Uncompressed DDS files will result in a larger package.\n\nDo you still want to use it?", "Uncompressed DDS", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					this.dds_0 = dds;
				}
				this.bool_0 = true;
				this.done.Enabled = true;
				this.method_1();
			}
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0004CE84 File Offset: 0x0004B084
		private void browse_Click(object sender, EventArgs e)
		{
			ProjectContentsBrowser projectContentsBrowser = new ProjectContentsBrowser(Class132.mainForm.CurrentProject.Package);
			projectContentsBrowser.TypeFilter = new List<DBPFType>
			{
				DBPFType.DDS
			};
			if (projectContentsBrowser.ShowDialog(this) == DialogResult.OK && projectContentsBrowser.SelectedItems.Count > 0)
			{
				ResKey resKey = projectContentsBrowser.SelectedItems[0];
				this.dds_0 = (Class76.smethod_26(resKey) as DDS);
				this.bool_0 = false;
				this.Image = (this.resKey_0 = new TextureResKey(resKey.AsString()));
				this.done.Enabled = true;
				this.method_1();
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x000032ED File Offset: 0x000014ED
		private void method_2()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0004CF2C File Offset: 0x0004B12C
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.textBox1.Text;
				if (!text.ToLower().Contains("key:"))
				{
					text = "key:" + text;
				}
				ResKey resKey = new ResKey(text);
				DBPFEntry dbpfentry = Class76.smethod_26(resKey);
				if (dbpfentry is DDS)
				{
					this.dds_0 = (dbpfentry as DDS);
					this.bool_0 = false;
					this.Image = (this.resKey_0 = new TextureResKey(resKey.AsString()));
					this.method_1();
					this.done.Enabled = true;
				}
				else
				{
					MessageBox.Show("Could not find resource");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00004946 File Offset: 0x00002B46
		private void ImageEditor_LocationChanged(object sender, EventArgs e)
		{
			ImageEditor.point_0 = base.Location;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0004CFEC File Offset: 0x0004B1EC
		private void ImageEditor_SizeChanged(object sender, EventArgs e)
		{
			ImageEditor.size_0 = base.Size;
			this.statusSize.Text = this.preview.DisplayWidth + " x " + this.preview.DisplayHeight;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00002A71 File Offset: 0x00000C71
		private void ImageEditor_KeyDown(object sender, KeyEventArgs e)
		{
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00002A71 File Offset: 0x00000C71
		private void ImageEditor_KeyUp(object sender, KeyEventArgs e)
		{
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00002A71 File Offset: 0x00000C71
		private void method_3(object sender, EventArgs e)
		{
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00002A71 File Offset: 0x00000C71
		private void method_4(object sender, EventArgs e)
		{
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0004D03C File Offset: 0x0004B23C
		private void fillAlpha_CheckedChanged(object sender, EventArgs e)
		{
			this.preview.UseAlpha = this.fillAlpha.Checked;
			this.preview.UseRed = this.useRed.Checked;
			this.preview.UseGreen = this.useGreen.Checked;
			this.preview.UseBlue = this.useBlue.Checked;
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00004955 File Offset: 0x00002B55
		private void emptyBtn_Click(object sender, EventArgs e)
		{
			this.textBox1.Text = "key:00b2d882:00000000:75f8f21e0f143cac";
			this.button1_Click(sender, e);
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00004971 File Offset: 0x00002B71
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000444 RID: 1092
		private ResKey resKey_0;

		// Token: 0x04000445 RID: 1093
		private DDS dds_0;

		// Token: 0x04000446 RID: 1094
		private bool bool_0;

		// Token: 0x04000447 RID: 1095
		private static Point point_0 = Point.Empty;

		// Token: 0x04000448 RID: 1096
		private static Size size_0 = Size.Empty;

		// Token: 0x04000449 RID: 1097
		private static int int_0 = 0;
	}
}
