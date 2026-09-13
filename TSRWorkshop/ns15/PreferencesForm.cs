using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns10;
using ns11;
using ns13;
using ns3;

namespace ns15
{
	// Token: 0x02000136 RID: 310
	internal sealed partial class PreferencesForm : Form
	{
		// Token: 0x06000E54 RID: 3668 RVA: 0x000B41D4 File Offset: 0x000B23D4
		public PreferencesForm()
		{
			this.InitializeComponent();
			this.list_0 = new List<Interface11>();
			this.list_0.Add(new Control6());
			this.list_0.Add(new Control7());
			this.list_0.Add(new Control5());
			this.list_0.Add(new PluginList());
			foreach (Interface11 @interface in this.list_0)
			{
				this.treeView1.Nodes.Add(@interface.Name);
			}
			this.treeView1_AfterSelect(this.treeView1, new TreeViewEventArgs(this.treeView1.Nodes[0]));
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x000B42B4 File Offset: 0x000B24B4
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			this.detailsPanel.Controls.Clear();
			foreach (Interface11 @interface in this.list_0)
			{
				if (@interface.Name == e.Node.Text)
				{
					this.detailsPanel.Controls.Add(@interface as UserControl);
					(@interface as UserControl).Dock = DockStyle.Fill;
				}
			}
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x000B4350 File Offset: 0x000B2550
		private void cancelButton_Click(object sender, EventArgs e)
		{
			foreach (Interface11 @interface in this.list_0)
			{
				@interface.imethod_1();
			}
			base.Close();
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x000B43AC File Offset: 0x000B25AC
		private void applyButton_Click(object sender, EventArgs e)
		{
			foreach (Interface11 @interface in this.list_0)
			{
				@interface.imethod_0();
			}
			base.Close();
		}

		// Token: 0x06000E58 RID: 3672 RVA: 0x00002A71 File Offset: 0x00000C71
		private void PreferencesForm_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x00007BED File Offset: 0x00005DED
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000B08 RID: 2824
		private List<Interface11> list_0;

		// Token: 0x04000B09 RID: 2825
		private IContainer icontainer_0;
	}
}
