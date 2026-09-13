using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Interfaces;

namespace ns6
{
	// Token: 0x020000CE RID: 206
	internal sealed partial class EditorPickForm : Form
	{
		// Token: 0x0600089F RID: 2207 RVA: 0x00079FE4 File Offset: 0x000781E4
		public EditorPickForm(List<IDBPFEntryEditor> plugins)
		{
			this.InitializeComponent();
			foreach (IDBPFEntryEditor editor in plugins)
			{
				this.comboBox.Items.Add(new EditorPickForm.Class92(editor));
			}
			if (this.comboBox.Items.Count > 0)
			{
				this.comboBox.SelectedIndex = 0;
			}
			base.DialogResult = DialogResult.Cancel;
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00005EAF File Offset: 0x000040AF
		private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.idbpfentryEditor_0 = (this.comboBox.SelectedItem as EditorPickForm.Class92).editor;
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x00005ECE File Offset: 0x000040CE
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040006EC RID: 1772
		public IDBPFEntryEditor idbpfentryEditor_0;

		// Token: 0x040006ED RID: 1773
		private IContainer icontainer_0;

		// Token: 0x020000CF RID: 207
		private sealed class Class92
		{
			// Token: 0x060008A4 RID: 2212 RVA: 0x00005EEF File Offset: 0x000040EF
			public Class92(IDBPFEntryEditor editor)
			{
				this.editor = editor;
			}

			// Token: 0x060008A5 RID: 2213 RVA: 0x0007A210 File Offset: 0x00078410
			public string ToString()
			{
				return (this.editor as WorkshopExtension).Name;
			}

			// Token: 0x040006F0 RID: 1776
			public IDBPFEntryEditor editor;
		}
	}
}
