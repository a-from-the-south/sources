using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns3;
using ns8;
using Sims3Workshop.Properties;
using Skybound.VisualTips;

namespace ns10
{
	// Token: 0x020000CD RID: 205
	internal sealed partial class CreatorDetailsForm : Form
	{
		// Token: 0x0600089B RID: 2203 RVA: 0x00005E3F File Offset: 0x0000403F
		public CreatorDetailsForm()
		{
			this.InitializeComponent();
			this.noask.Checked = !Settings.Default.AskCreatorInfo;
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x00005E67 File Offset: 0x00004067
		private void okBtn_Click(object sender, EventArgs e)
		{
			Settings.Default.AskCreatorInfo = !this.noask.Checked;
			this.control5_0.imethod_0();
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x00005E8E File Offset: 0x0000408E
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
