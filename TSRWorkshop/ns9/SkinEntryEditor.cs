using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Package.Sims3Files.InternalRCOL;
using SlimDX;

namespace ns9
{
	// Token: 0x0200000F RID: 15
	internal sealed partial class SkinEntryEditor : Form
	{
		// Token: 0x0600004F RID: 79 RVA: 0x00011FE8 File Offset: 0x000101E8
		public SkinEntryEditor(SKIN.SKINEntry skinEntry)
		{
			this.skinEntry = skinEntry;
			this.InitializeComponent();
			this.m11.Text = this.skinEntry.BoneMatrix[0].ToString();
			this.m12.Text = this.skinEntry.BoneMatrix[4].ToString();
			this.m13.Text = this.skinEntry.BoneMatrix[8].ToString();
			this.m21.Text = this.skinEntry.BoneMatrix[1].ToString();
			this.m22.Text = this.skinEntry.BoneMatrix[5].ToString();
			this.m23.Text = this.skinEntry.BoneMatrix[9].ToString();
			this.m31.Text = this.skinEntry.BoneMatrix[2].ToString();
			this.m32.Text = this.skinEntry.BoneMatrix[6].ToString();
			this.m33.Text = this.skinEntry.BoneMatrix[10].ToString();
			this.m41.Text = this.skinEntry.BoneMatrix[3].ToString();
			this.m42.Text = this.skinEntry.BoneMatrix[7].ToString();
			this.m43.Text = this.skinEntry.BoneMatrix[11].ToString();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0001219C File Offset: 0x0001039C
		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				Matrix identity = Matrix.Identity;
				this.skinEntry.BoneMatrix[0] = Convert.ToSingle(this.m11.Text);
				this.skinEntry.BoneMatrix[4] = Convert.ToSingle(this.m12.Text);
				this.skinEntry.BoneMatrix[8] = Convert.ToSingle(this.m13.Text);
				this.skinEntry.BoneMatrix[1] = Convert.ToSingle(this.m21.Text);
				this.skinEntry.BoneMatrix[5] = Convert.ToSingle(this.m22.Text);
				this.skinEntry.BoneMatrix[9] = Convert.ToSingle(this.m23.Text);
				this.skinEntry.BoneMatrix[2] = Convert.ToSingle(this.m31.Text);
				this.skinEntry.BoneMatrix[6] = Convert.ToSingle(this.m32.Text);
				this.skinEntry.BoneMatrix[10] = Convert.ToSingle(this.m33.Text);
				this.skinEntry.BoneMatrix[3] = Convert.ToSingle(this.m41.Text);
				this.skinEntry.BoneMatrix[7] = Convert.ToSingle(this.m42.Text);
				this.skinEntry.BoneMatrix[11] = Convert.ToSingle(this.m43.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002BAB File Offset: 0x00000DAB
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0400009F RID: 159
		private SKIN.SKINEntry skinEntry;

		// Token: 0x040000A0 RID: 160
		private IContainer icontainer_0;
	}
}
