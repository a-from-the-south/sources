using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns8
{
	// Token: 0x02000040 RID: 64
	internal sealed partial class InputForm : Form
	{
		// Token: 0x06000267 RID: 615 RVA: 0x0000381D File Offset: 0x00001A1D
		public InputForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00002A71 File Offset: 0x00000C71
		private void textField_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00002B20 File Offset: 0x00000D20
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00002A71 File Offset: 0x00000C71
		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000382D File Offset: 0x00001A2D
		private void InputForm_Load(object sender, EventArgs e)
		{
			this.textField.Focus();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000383D File Offset: 0x00001A3D
		private void textField_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.button2_Click(sender, new EventArgs());
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00003857 File Offset: 0x00001A57
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0400021C RID: 540
		private IContainer icontainer_0;
	}
}
