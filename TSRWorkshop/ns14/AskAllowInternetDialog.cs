using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Sims3Workshop.Properties;

namespace ns14
{
	// Token: 0x020000C8 RID: 200
	internal sealed partial class AskAllowInternetDialog : Form
	{
		// Token: 0x0600086E RID: 2158 RVA: 0x00005D0D File Offset: 0x00003F0D
		public AskAllowInternetDialog()
		{
			this.InitializeComponent();
			base.DialogResult = DialogResult.No;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00077DC0 File Offset: 0x00075FC0
		private void AskAllowInternetDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.AskAllowInternet = this.ask.Checked;
			if (!this.ask.Checked)
			{
				Settings.Default.AllowInternet = this.bool_0;
				MessageBox.Show(this, "You can at any time change this behaviour in the preferences dialog.");
			}
			Settings.Default.Save();
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00005D24 File Offset: 0x00003F24
		private void yes_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
			this.bool_0 = true;
			base.Close();
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00005D3C File Offset: 0x00003F3C
		private void no_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
			this.bool_0 = false;
			base.Close();
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00005D54 File Offset: 0x00003F54
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040006B2 RID: 1714
		private bool bool_0;

		// Token: 0x040006B3 RID: 1715
		private IContainer icontainer_0;
	}
}
