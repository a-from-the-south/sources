using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sims3WorkshopSDK.Forms
{
	// Token: 0x02000039 RID: 57
	public partial class AlertForm : Form
	{
		// Token: 0x06000102 RID: 258 RVA: 0x000025FB File Offset: 0x000007FB
		public AlertForm(string messageString)
		{
			this.InitializeComponent();
			this.message.Text = messageString;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00002615 File Offset: 0x00000815
		private void okBtn_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
