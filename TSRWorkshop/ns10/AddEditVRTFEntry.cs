using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Package.Sims3Files.InternalRCOL;

namespace ns10
{
	// Token: 0x02000036 RID: 54
	internal sealed partial class AddEditVRTFEntry : Form
	{
		// Token: 0x060001FD RID: 509 RVA: 0x000280FC File Offset: 0x000262FC
		public AddEditVRTFEntry(VertexFormatEntry entry)
		{
			this.entry = entry;
			this.InitializeComponent();
			foreach (object obj in Enum.GetValues(typeof(VertexEntryUsage)))
			{
				int selectedIndex = this.usageCombo.Items.Add(obj.ToString());
				if (obj.ToString().Equals(entry.Usage.ToString()))
				{
					this.usageCombo.SelectedIndex = selectedIndex;
				}
			}
			foreach (object obj2 in Enum.GetValues(typeof(VertexEntryType)))
			{
				int selectedIndex2 = this.typeCombo.Items.Add(obj2.ToString());
				if (obj2.ToString().Equals(entry.Type.ToString()))
				{
					this.typeCombo.SelectedIndex = selectedIndex2;
				}
			}
			this.offsetTextbox.Text = entry.Offset.ToString();
			this.indexTextbox.Text = entry.Index.ToString();
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00028268 File Offset: 0x00026468
		private void button2_Click(object sender, EventArgs e)
		{
			uint num = 0U;
			foreach (object obj in Enum.GetValues(typeof(VertexEntryUsage)))
			{
				if (this.usageCombo.Text.Equals(obj.ToString()))
				{
					num = ((uint)obj & 255U);
				}
			}
			num += (uint.Parse(this.indexTextbox.Text) & 255U) << 8;
			foreach (object obj2 in Enum.GetValues(typeof(VertexEntryType)))
			{
				if (this.typeCombo.Text.Equals(obj2.ToString()))
				{
					num += ((uint)obj2 & 255U) << 16;
				}
			}
			num += (uint.Parse(this.offsetTextbox.Text) & 255U) << 24;
			this.entry.SetValue((int)num);
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00002A71 File Offset: 0x00000C71
		private void label4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00003472 File Offset: 0x00001672
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0400019F RID: 415
		private VertexFormatEntry entry;

		// Token: 0x040001A0 RID: 416
		private IContainer icontainer_0;
	}
}
