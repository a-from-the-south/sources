using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Package;

namespace ns3
{
	// Token: 0x020000E8 RID: 232
	internal sealed partial class ResourceSelector : Form
	{
		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000977 RID: 2423 RVA: 0x00083580 File Offset: 0x00081780
		// (set) Token: 0x06000978 RID: 2424 RVA: 0x00006348 File Offset: 0x00004548
		public DBPFEntry Resource { get; private set; }

		// Token: 0x06000979 RID: 2425 RVA: 0x00006353 File Offset: 0x00004553
		public ResourceSelector(List<DBPFEntry> keys)
		{
			this.InitializeComponent();
			this.comboBox1.Items.AddRange(keys.ToArray());
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x00006379 File Offset: 0x00004579
		private void selectButton_Click(object sender, EventArgs e)
		{
			this.Resource = (this.comboBox1.SelectedItem as DBPFEntry);
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x000063A0 File Offset: 0x000045A0
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040007A3 RID: 1955
		private IContainer icontainer_0;

		// Token: 0x040007A8 RID: 1960
		[CompilerGenerated]
		private DBPFEntry dbpfentry_0;
	}
}
