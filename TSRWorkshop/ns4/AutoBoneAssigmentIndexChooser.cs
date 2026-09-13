using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns4
{
	// Token: 0x02000039 RID: 57
	internal sealed partial class AutoBoneAssigmentIndexChooser : Form
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00029B1C File Offset: 0x00027D1C
		public int SelectedIndex
		{
			get
			{
				return this.comboBox1.SelectedIndex;
			}
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000034EB File Offset: 0x000016EB
		public AutoBoneAssigmentIndexChooser(string[] groups)
		{
			this.InitializeComponent();
			this.comboBox1.Items.AddRange(groups);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000350C File Offset: 0x0000170C
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040001C3 RID: 451
		private IContainer icontainer_0;
	}
}
