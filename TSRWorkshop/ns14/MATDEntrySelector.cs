using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns14
{
	// Token: 0x02000044 RID: 68
	internal sealed partial class MATDEntrySelector : Form
	{
		// Token: 0x06000288 RID: 648 RVA: 0x0002F768 File Offset: 0x0002D968
		public MATDEntrySelector(Dictionary<string, object[]> dictionary)
		{
			this.dictionary = dictionary;
			this.InitializeComponent();
			AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
			this.DropdownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.DropdownList.AutoCompleteSource = AutoCompleteSource.CustomSource;
			this.DropdownList.AutoCompleteCustomSource = autoCompleteStringCollection;
			foreach (KeyValuePair<string, object[]> keyValuePair in this.dictionary)
			{
				autoCompleteStringCollection.Add(keyValuePair.Key);
				this.DropdownList.Items.Add(keyValuePair.Key);
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00003914 File Offset: 0x00001B14
		private void DropdownList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && this.DropdownList.SelectedIndex != -1)
			{
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000393D File Offset: 0x00001B3D
		private void MATDEntrySelector_Shown(object sender, EventArgs e)
		{
			this.DropdownList.Focus();
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000394D File Offset: 0x00001B4D
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0400022F RID: 559
		private Dictionary<string, object[]> dictionary;

		// Token: 0x04000230 RID: 560
		private IContainer icontainer_0;
	}
}
