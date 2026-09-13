using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns10
{
	// Token: 0x0200004C RID: 76
	internal sealed partial class RenumberDialog : Form
	{
		// Token: 0x060002F5 RID: 757 RVA: 0x00003B43 File Offset: 0x00001D43
		public RenumberDialog()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00003B53 File Offset: 0x00001D53
		private void doGroup_CheckedChanged(object sender, EventArgs e)
		{
			this.group.Enabled = this.doGroup.Checked;
			this.method_0();
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00003B73 File Offset: 0x00001D73
		private void doIId_CheckedChanged(object sender, EventArgs e)
		{
			this.iId.Enabled = this.doIId.Checked;
			this.method_0();
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00003B93 File Offset: 0x00001D93
		private void doIId2_CheckedChanged(object sender, EventArgs e)
		{
			this.iId2.Enabled = this.doIId2.Checked;
			this.method_0();
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00038B88 File Offset: 0x00036D88
		private void method_0()
		{
			this.btnRandom.Enabled = (this.btnOk.Enabled = (this.update.Enabled = (this.doGroup.Checked || this.doIId.Checked || this.doIId2.Checked)));
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00038BE8 File Offset: 0x00036DE8
		private void btnRandom_Click(object sender, EventArgs e)
		{
			int seed = (int)DateTime.Now.Ticks;
			Random random = new Random(seed);
			if (this.doGroup.Checked)
			{
				this.group.Text = "0x" + random.Next().ToString("X8");
			}
			if (this.doIId.Checked)
			{
				this.iId.Text = "0x" + random.Next().ToString("X8");
			}
			if (this.doIId2.Checked)
			{
				this.iId2.Text = "0x" + random.Next().ToString("X8");
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void btnOk_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00038CB0 File Offset: 0x00036EB0
		public int method_1(int int_0)
		{
			int result;
			if (!this.doGroup.Checked)
			{
				result = int_0;
			}
			else
			{
				result = (int)Convert.ToUInt32(this.group.Text, 16);
			}
			return result;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00038CE4 File Offset: 0x00036EE4
		public int method_2(int int_0)
		{
			int result;
			if (!this.doIId.Checked)
			{
				result = int_0;
			}
			else
			{
				result = (int)Convert.ToUInt32(this.iId.Text, 16);
			}
			return result;
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00038D18 File Offset: 0x00036F18
		public int method_3(int int_0)
		{
			int result;
			if (!this.doIId2.Checked)
			{
				result = int_0;
			}
			else
			{
				result = (int)Convert.ToUInt32(this.iId2.Text, 16);
			}
			return result;
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00003BB3 File Offset: 0x00001DB3
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040002A6 RID: 678
		private IContainer icontainer_0;
	}
}
