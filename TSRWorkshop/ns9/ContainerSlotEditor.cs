using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns13;
using ns2;
using ns3;
using ns8;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK.Classes;
using SlimDX;

namespace ns9
{
	// Token: 0x02000008 RID: 8
	internal sealed partial class ContainerSlotEditor : Form
	{
		// Token: 0x06000029 RID: 41 RVA: 0x0000CA88 File Offset: 0x0000AC88
		public ContainerSlotEditor(Class18 wrapper)
		{
			this.entry_0 = wrapper.ContainerEntry.RSLTEntry;
			this.InitializeComponent();
			this.t0.Text = this.entry_0.Transformation[0].ToString();
			this.t1.Text = this.entry_0.Transformation[1].ToString();
			this.t2.Text = this.entry_0.Transformation[2].ToString();
			this.t3.Text = this.entry_0.Transformation[3].ToString();
			this.t4.Text = this.entry_0.Transformation[4].ToString();
			this.t5.Text = this.entry_0.Transformation[5].ToString();
			this.t6.Text = this.entry_0.Transformation[6].ToString();
			this.t7.Text = this.entry_0.Transformation[7].ToString();
			this.t8.Text = this.entry_0.Transformation[8].ToString();
			this.t9.Text = this.entry_0.Transformation[9].ToString();
			this.t10.Text = this.entry_0.Transformation[10].ToString();
			this.t11.Text = this.entry_0.Transformation[11].ToString();
			this.nameHash.Text = "0x" + this.entry_0.NameHash.ToString("X8");
			this.boneHash.Text = "0x" + this.entry_0.BoneHash.ToString("X8");
			this.label6.Text = wrapper.ContainerEntry.BoneName;
			foreach (object obj in this.listView1.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				uint num = Convert.ToUInt32(listViewItem.Tag as string, 16);
				if ((this.entry_0.PlacementFlag & (RSLT.PlacementFlags)num) != (RSLT.PlacementFlags)0U)
				{
					listViewItem.Checked = true;
				}
			}
			string text = this.nameHash.Text;
			foreach (object obj2 in this.comboBox1.AutoCompleteCustomSource)
			{
				string text2 = (string)obj2;
				string a = "0x" + FNV32.GetHash(text2).ToString("X8");
				if (a == text)
				{
					this.comboBox1.Text = text2;
				}
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000CDC0 File Offset: 0x0000AFC0
		private void okButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			bool flag = false;
			object renderable = Class132.mainForm.CurrentProjectModel.GetRenderable();
			if (renderable is Class105)
			{
				Class105 @class = renderable as Class105;
				foreach (Class111 class2 in @class.ContainerEntries)
				{
					if (class2.RSLTEntry == this.entry_0)
					{
						class2.Transformation = new Matrix
						{
							M11 = Convert.ToSingle(this.t0.Text),
							M12 = Convert.ToSingle(this.t4.Text),
							M13 = Convert.ToSingle(this.t8.Text),
							M21 = Convert.ToSingle(this.t1.Text),
							M22 = Convert.ToSingle(this.t5.Text),
							M23 = Convert.ToSingle(this.t9.Text),
							M31 = Convert.ToSingle(this.t2.Text),
							M32 = Convert.ToSingle(this.t6.Text),
							M33 = Convert.ToSingle(this.t10.Text),
							M41 = Convert.ToSingle(this.t3.Text),
							M42 = Convert.ToSingle(this.t7.Text),
							M43 = Convert.ToSingle(this.t11.Text)
						};
						class2.imethod_0();
						flag = true;
					}
				}
			}
			if (!flag)
			{
				this.entry_0.Transformation[0] = Convert.ToSingle(this.t0.Text);
				this.entry_0.Transformation[1] = Convert.ToSingle(this.t1.Text);
				this.entry_0.Transformation[2] = Convert.ToSingle(this.t2.Text);
				this.entry_0.Transformation[3] = Convert.ToSingle(this.t3.Text);
				this.entry_0.Transformation[4] = Convert.ToSingle(this.t4.Text);
				this.entry_0.Transformation[5] = Convert.ToSingle(this.t5.Text);
				this.entry_0.Transformation[6] = Convert.ToSingle(this.t6.Text);
				this.entry_0.Transformation[7] = Convert.ToSingle(this.t7.Text);
				this.entry_0.Transformation[8] = Convert.ToSingle(this.t8.Text);
				this.entry_0.Transformation[9] = Convert.ToSingle(this.t9.Text);
				this.entry_0.Transformation[10] = Convert.ToSingle(this.t10.Text);
				this.entry_0.Transformation[11] = Convert.ToSingle(this.t11.Text);
			}
			this.entry_0.BoneHash = Convert.ToUInt32(this.boneHash.Text, 16);
			this.entry_0.NameHash = Convert.ToUInt32(this.nameHash.Text, 16);
			this.entry_0.PlacementFlag = (RSLT.PlacementFlags)0U;
			foreach (object obj in this.listView1.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				uint num = Convert.ToUInt32(listViewItem.Tag as string, 16);
				if (listViewItem.Checked)
				{
					this.entry_0.PlacementFlag |= (RSLT.PlacementFlags)num;
				}
			}
			base.Close();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void canelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000D1C8 File Offset: 0x0000B3C8
		private void comboBox1_TextUpdate(object sender, EventArgs e)
		{
			this.nameHash.Text = "0x" + FNV32.GetHash(this.comboBox1.Text).ToString("X8");
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000D20C File Offset: 0x0000B40C
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			this.boneHash.Text = "0x" + FNV32.GetHash(this.textBox2.Text).ToString("X8");
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002AD3 File Offset: 0x00000CD3
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000030 RID: 48
		private RSLT.Entry entry_0;

		// Token: 0x04000031 RID: 49
		private IContainer icontainer_0;
	}
}
