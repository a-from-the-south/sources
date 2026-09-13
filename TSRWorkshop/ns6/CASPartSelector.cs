using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns16;
using Package.Sims3Files;
using Sims3WorkshopSDK;

namespace ns6
{
	// Token: 0x0200003E RID: 62
	internal sealed partial class CASPartSelector : Form
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600023F RID: 575 RVA: 0x0002B6A8 File Offset: 0x000298A8
		// (set) Token: 0x06000240 RID: 576 RVA: 0x0000365C File Offset: 0x0000185C
		public ResKey Reskey { get; set; }

		// Token: 0x06000241 RID: 577 RVA: 0x0002B6C0 File Offset: 0x000298C0
		public CASPartSelector(List<string> possibleParts)
		{
			this.InitializeComponent();
			foreach (string key in possibleParts)
			{
				ResKey tag = new ResKey(key);
				CASP casp = Class76.smethod_26(tag) as CASP;
				PNG png = Class76.smethod_5(Class76.Enum14.const_1, new ResKey(1651466445U, casp.GroupID, casp.InstanceID, casp.SecondInstanceID)) as PNG;
				ListViewItem listViewItem = this.listView1.Items.Add(casp.str1);
				listViewItem.Tag = tag;
				if (png != null)
				{
					this.imageList_0.Images.Add(png.Image);
					listViewItem.ImageIndex = this.imageList_0.Images.Count - 1;
				}
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00003667 File Offset: 0x00001867
		private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (this.listView1.SelectedItems.Count > 0)
			{
				this.Reskey = (this.listView1.SelectedItems[0].Tag as ResKey);
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000369F File Offset: 0x0000189F
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040001EE RID: 494
		[CompilerGenerated]
		private ResKey resKey_0;
	}
}
