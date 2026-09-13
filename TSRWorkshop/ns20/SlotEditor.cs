using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns13;

namespace ns20
{
	// Token: 0x02000061 RID: 97
	internal sealed partial class SlotEditor : Form
	{
		// Token: 0x060003BD RID: 957 RVA: 0x000040E9 File Offset: 0x000022E9
		public SlotEditor(Class129 entry)
		{
			this.list_0 = new List<float[]>();
			this.entry = entry;
			this.InitializeComponent();
			this.method_0();
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00044480 File Offset: 0x00042680
		private void method_0()
		{
			this.bool_0 = false;
			this.list_0.Clear();
			foreach (float[] array in this.entry.Slot.Entries)
			{
				this.list_0.Add(new float[]
				{
					array[0],
					array[1]
				});
			}
			this.flx.Text = this.entry.Slot.Entries[0][0].ToString();
			this.flz.Text = this.entry.Slot.Entries[0][1].ToString();
			this.nlx.Text = this.entry.Slot.Entries[1][0].ToString();
			this.nlz.Text = this.entry.Slot.Entries[1][1].ToString();
			this.nrx.Text = this.entry.Slot.Entries[2][0].ToString();
			this.nrz.Text = this.entry.Slot.Entries[2][1].ToString();
			this.frx.Text = this.entry.Slot.Entries[3][0].ToString();
			this.frz.Text = this.entry.Slot.Entries[3][1].ToString();
			this.bool_0 = true;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void okButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00004111 File Offset: 0x00002311
		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.entry.Slot.Entries = this.list_0;
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00044674 File Offset: 0x00042874
		private void flx_TextChanged(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				try
				{
					this.entry.Slot.Entries[0][0] = float.Parse(this.flx.Text);
					this.entry.Slot.Entries[0][1] = float.Parse(this.flz.Text);
					this.entry.Slot.Entries[1][0] = float.Parse(this.nlx.Text);
					this.entry.Slot.Entries[1][1] = float.Parse(this.nlz.Text);
					this.entry.Slot.Entries[2][0] = float.Parse(this.nrx.Text);
					this.entry.Slot.Entries[2][1] = float.Parse(this.nrz.Text);
					this.entry.Slot.Entries[3][0] = float.Parse(this.frx.Text);
					this.entry.Slot.Entries[3][1] = float.Parse(this.frz.Text);
					this.entry.method_0();
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00044814 File Offset: 0x00042A14
		private void offsetZ_TextChanged(object sender, EventArgs e)
		{
			try
			{
				float num = float.Parse(this.offsetX.Text);
				float num2 = float.Parse(this.offsetZ.Text);
				this.entry.Slot.Entries[0][0] = this.list_0[0][0] + num;
				this.entry.Slot.Entries[0][1] = this.list_0[0][1] + num2;
				this.entry.Slot.Entries[1][0] = this.list_0[1][0] + num;
				this.entry.Slot.Entries[1][1] = this.list_0[1][1] + num2;
				this.entry.Slot.Entries[2][0] = this.list_0[2][0] + num;
				this.entry.Slot.Entries[2][1] = this.list_0[2][1] + num2;
				this.entry.Slot.Entries[3][0] = this.list_0[3][0] + num;
				this.entry.Slot.Entries[3][1] = this.list_0[3][1] + num2;
				this.entry.method_0();
				this.bool_0 = false;
				this.flx.Text = this.entry.Slot.Entries[0][0].ToString();
				this.flz.Text = this.entry.Slot.Entries[0][1].ToString();
				this.nlx.Text = this.entry.Slot.Entries[1][0].ToString();
				this.nlz.Text = this.entry.Slot.Entries[1][1].ToString();
				this.nrx.Text = this.entry.Slot.Entries[2][0].ToString();
				this.nrz.Text = this.entry.Slot.Entries[2][1].ToString();
				this.frx.Text = this.entry.Slot.Entries[3][0].ToString();
				this.frz.Text = this.entry.Slot.Entries[3][1].ToString();
				this.bool_0 = true;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00004138 File Offset: 0x00002338
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000388 RID: 904
		private Class129 entry;

		// Token: 0x04000389 RID: 905
		private List<float[]> list_0;

		// Token: 0x0400038A RID: 906
		private bool bool_0;

		// Token: 0x0400038B RID: 907
		private IContainer icontainer_0;
	}
}
