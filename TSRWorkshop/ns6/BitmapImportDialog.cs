using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ns17;
using Sims3WorkshopSDK;

namespace ns6
{
	// Token: 0x0200003A RID: 58
	internal sealed partial class BitmapImportDialog : Form
	{
		// Token: 0x06000220 RID: 544 RVA: 0x00029E60 File Offset: 0x00028060
		public BitmapImportDialog(Bitmap image)
		{
			this.InitializeComponent();
			this.preview.FitToView = true;
			this.image = image;
			this.preview.Image = this.image;
			if ((image.Flags & 2) == 0)
			{
				this.enableAlpha.Checked = false;
				this.keepAlpha.Enabled = false;
				this.alphaFull.Checked = true;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00029ED0 File Offset: 0x000280D0
		public bool UseAlpha
		{
			get
			{
				return this.enableAlpha.Checked;
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00029EEC File Offset: 0x000280EC
		public Bitmap method_0()
		{
			return (Bitmap)this.preview.Image;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void btnContinue_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000352D File Offset: 0x0000172D
		private void enableAlpha_CheckedChanged(object sender, EventArgs e)
		{
			this.alphaGroup.Enabled = this.enableAlpha.Checked;
			this.method_1();
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000354D File Offset: 0x0000174D
		private void alphaFromImage_CheckedChanged(object sender, EventArgs e)
		{
			this.method_1();
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00029F10 File Offset: 0x00028110
		private void method_1()
		{
			if (this.enableAlpha.Checked && this.keepAlpha.Checked)
			{
				this.preview.Image = this.image;
			}
			else
			{
				this.viewAlpha.Checked = true;
				FastPixel fastPixel = null;
				if (this.enableAlpha.Checked && this.alphaFromImage.Checked && this.image_0 != null)
				{
					fastPixel = new FastPixel(this.image_0 as Bitmap);
					fastPixel.Lock();
				}
				Bitmap bitmap = ((Bitmap)this.image).Clone(new Rectangle(new Point(0, 0), new Size(this.image.Width, this.image.Height)), PixelFormat.Format32bppArgb);
				FastPixel fastPixel2 = new FastPixel(bitmap);
				fastPixel2.Lock();
				Color color = Color.White;
				if (this.alphaEmpty.Checked && this.enableAlpha.Checked)
				{
					color = Color.Black;
				}
				for (int i = 0; i < fastPixel2.Height; i++)
				{
					for (int j = 0; j < fastPixel2.Width; j++)
					{
						Point location = new Point(j, i);
						if (fastPixel != null)
						{
							color = fastPixel.GetPixel(location);
						}
						Color pixel = fastPixel2.GetPixel(location);
						Color colour = Color.FromArgb((int)((color.R + color.G + color.B) / 3), (int)pixel.R, (int)pixel.G, (int)pixel.B);
						fastPixel2.SetPixel(location, colour);
					}
				}
				if (fastPixel != null)
				{
					fastPixel.Unlock(false);
				}
				fastPixel2.Unlock(true);
				this.preview.Image = bitmap;
			}
			this.preview.method_3();
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0002A0BC File Offset: 0x000282BC
		private void setImgBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Import alpha grayscale";
			openFileDialog.Filter = "Bitmap Image (*.tif, *.png)|*.tif;*.png";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
				this.image_0 = Image.FromFile(fileName);
				Control control = this.alphaFromImage;
				this.alphaFromImage.Checked = true;
				control.Enabled = true;
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00003557 File Offset: 0x00001757
		private void viewAlpha_CheckedChanged(object sender, EventArgs e)
		{
			this.preview.method_0(this.viewRed.Checked, this.viewGreen.Checked, this.viewBlue.Checked, this.viewAlpha.Checked);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00003592 File Offset: 0x00001792
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040001C9 RID: 457
		private Image image_0;

		// Token: 0x040001CA RID: 458
		private Image image;

		// Token: 0x040001CB RID: 459
		private IContainer icontainer_0;
	}
}
