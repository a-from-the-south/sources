using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns8;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;

namespace ns11
{
	// Token: 0x020000DC RID: 220
	internal sealed partial class MultiPartCaspFilePicker : Form
	{
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x0007E5F8 File Offset: 0x0007C7F8
		// (set) Token: 0x06000912 RID: 2322 RVA: 0x00006195 File Offset: 0x00004395
		public MultiPartCaspFilePicker.Class95[] Parts { get; set; }

		// Token: 0x06000913 RID: 2323 RVA: 0x0007E610 File Offset: 0x0007C810
		public MultiPartCaspFilePicker(string filterString, VPXY vpxy, VPXY.VPXEntryEntry vpxyEntry, bool import)
		{
			this.import = import;
			this.filterString = filterString;
			this.InitializeComponent();
			int num = 0;
			foreach (int num2 in vpxyEntry.index)
			{
				TGIIndex tgiindex = vpxy.TGIIndex[num2];
				Geometry geometry = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.Reskey)) as Geometry;
				foreach (RCOLItem rcolitem in geometry.Entries)
				{
					GEOM geom = (GEOM)rcolitem;
					ListViewItem listViewItem = this.listView1.Items.Add("Group " + num);
					listViewItem.Tag = num2;
					listViewItem.Checked = true;
					listViewItem.SubItems.Add("double click to select " + (import ? "input" : "output") + " file");
					num++;
				}
			}
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0007E760 File Offset: 0x0007C960
		private void okButton_Click(object sender, EventArgs e)
		{
			this.Parts = new MultiPartCaspFilePicker.Class95[1024];
			foreach (object obj in this.listView1.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				MultiPartCaspFilePicker.Class95 @class = new MultiPartCaspFilePicker.Class95();
				if (string.IsNullOrEmpty((string)listViewItem.SubItems[1].Tag))
				{
					MessageBox.Show(this, "You need to select a output file for group " + listViewItem.Index + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				@class.FileName = (string)listViewItem.SubItems[1].Tag;
				@class.FilterIndex = (int)listViewItem.SubItems[0].Tag;
				@class.Checked = listViewItem.Checked;
				this.Parts[(int)listViewItem.Tag] = @class;
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x000061A0 File Offset: 0x000043A0
		private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			e.DrawDefault = true;
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x000061AB File Offset: 0x000043AB
		private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if (e.ColumnIndex == 2)
			{
				e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
			}
			else
			{
				e.DrawDefault = true;
			}
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x000061D7 File Offset: 0x000043D7
		private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0007E884 File Offset: 0x0007CA84
		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count != 0)
			{
				if (this.import)
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Filter = this.filterString;
					if (openFileDialog.ShowDialog(this) == DialogResult.OK)
					{
						this.listView1.SelectedItems[0].SubItems[0].Tag = openFileDialog.FilterIndex;
						this.listView1.SelectedItems[0].SubItems[1].Text = Path.GetFileName(openFileDialog.FileName);
						this.listView1.SelectedItems[0].SubItems[1].Tag = openFileDialog.FileName;
					}
				}
				else
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.Filter = this.filterString;
					if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
					{
						this.listView1.SelectedItems[0].SubItems[0].Tag = saveFileDialog.FilterIndex;
						this.listView1.SelectedItems[0].SubItems[1].Text = Path.GetFileName(saveFileDialog.FileName);
						this.listView1.SelectedItems[0].SubItems[1].Tag = saveFileDialog.FileName;
					}
				}
				this.listView1.SelectedItems[0].Checked = true;
			}
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x0007EA0C File Offset: 0x0007CC0C
		private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			int num = 0;
			foreach (object obj in this.listView1.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				if (listViewItem.Checked)
				{
					num++;
				}
			}
			this.okButton.Enabled = (num > 0);
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x000061E2 File Offset: 0x000043E2
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0400073E RID: 1854
		private bool import;

		// Token: 0x0400073F RID: 1855
		private string filterString;

		// Token: 0x04000740 RID: 1856
		private IContainer icontainer_0;

		// Token: 0x04000748 RID: 1864
		[CompilerGenerated]
		private MultiPartCaspFilePicker.Class95[] class95_0;

		// Token: 0x020000DD RID: 221
		public sealed class Class95
		{
			// Token: 0x1700017C RID: 380
			// (get) Token: 0x0600091D RID: 2333 RVA: 0x0007EF34 File Offset: 0x0007D134
			// (set) Token: 0x0600091E RID: 2334 RVA: 0x00006203 File Offset: 0x00004403
			public int FilterIndex { get; set; }

			// Token: 0x1700017D RID: 381
			// (get) Token: 0x0600091F RID: 2335 RVA: 0x0007EF4C File Offset: 0x0007D14C
			// (set) Token: 0x06000920 RID: 2336 RVA: 0x0000620E File Offset: 0x0000440E
			public string FileName { get; set; }

			// Token: 0x1700017E RID: 382
			// (get) Token: 0x06000921 RID: 2337 RVA: 0x0007EF64 File Offset: 0x0007D164
			// (set) Token: 0x06000922 RID: 2338 RVA: 0x00006219 File Offset: 0x00004419
			public bool Checked { get; set; }

			// Token: 0x04000749 RID: 1865
			[CompilerGenerated]
			private int int_0;

			// Token: 0x0400074A RID: 1866
			[CompilerGenerated]
			private string string_0;

			// Token: 0x0400074B RID: 1867
			[CompilerGenerated]
			private bool bool_0;
		}
	}
}
