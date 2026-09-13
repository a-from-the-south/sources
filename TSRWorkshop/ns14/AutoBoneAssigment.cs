using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Sims3WorkshopSDK.Classes;

namespace ns14
{
	// Token: 0x02000037 RID: 55
	internal sealed partial class AutoBoneAssigment : Form
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00028968 File Offset: 0x00026B68
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00003493 File Offset: 0x00001693
		private string wsoFile { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00028980 File Offset: 0x00026B80
		// (set) Token: 0x06000206 RID: 518 RVA: 0x0000349E File Offset: 0x0000169E
		public WSOFile WSO { get; private set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00028998 File Offset: 0x00026B98
		// (set) Token: 0x06000208 RID: 520 RVA: 0x000034A9 File Offset: 0x000016A9
		public List<AutoBoneAssigment.Class35> Entries { get; private set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000209 RID: 521 RVA: 0x000289B0 File Offset: 0x00026BB0
		public bool DoMorphs
		{
			get
			{
				bool result;
				if (this.autoMorph.Enabled)
				{
					result = this.autoMorph.Checked;
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600020A RID: 522 RVA: 0x000289E0 File Offset: 0x00026BE0
		public bool DoBones
		{
			get
			{
				bool result;
				if (this.autoBone.Enabled)
				{
					result = this.autoBone.Checked;
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600020B RID: 523 RVA: 0x00028A10 File Offset: 0x00026C10
		public int InterpolationLevel
		{
			get
			{
				return this.comboBox1.SelectedIndex + 1;
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00028A30 File Offset: 0x00026C30
		public AutoBoneAssigment(object[] groups, bool enableMorphs)
		{
			this.Entries = new List<AutoBoneAssigment.Class35>();
			this.InitializeComponent();
			this.listView1.Items.Clear();
			int num = 0;
			foreach (object[] array in groups)
			{
				AutoBoneAssigment.Class35 @class = new AutoBoneAssigment.Class35(array[0] as string, array[1]);
				@class.Checked = true;
				this.listView1.Items.Add(@class);
				num++;
			}
			this.comboBox1.SelectedIndex = 2;
			if (!enableMorphs)
			{
				this.autoMorph.Enabled = false;
				this.comboBox1.Enabled = false;
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00028ADC File Offset: 0x00026CDC
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.listView2.Items.Clear();
			foreach (object obj in this.listView1.Items)
			{
				AutoBoneAssigment.Class35 @class = (AutoBoneAssigment.Class35)obj;
				@class.UsedGroups.Clear();
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Workshop Object|*.wso";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.wsoFile = openFileDialog.FileName;
				this.WSO = new WSOFile();
				this.WSO.OpenFromFile(this.wsoFile);
				foreach (WSOFile.WSOMesh wsomesh in this.WSO.Meshes)
				{
					this.listView2.Items.Add(wsomesh.Name);
				}
				if (this.listView1.Items.Count == this.WSO.Meshes.Count)
				{
					int num = 0;
					foreach (object obj2 in this.listView1.Items)
					{
						AutoBoneAssigment.Class35 class2 = (AutoBoneAssigment.Class35)obj2;
						class2.UsedGroups.Add(this.listView2.Items[num].Text);
						num++;
					}
				}
			}
			this.listView1.Items[0].Selected = true;
			this.listView1.Focus();
			this.comboBox1.SelectedIndex = 2;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00028CC0 File Offset: 0x00026EC0
		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count != 0)
			{
				this.bool_0 = true;
				foreach (object obj in this.listView2.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					listViewItem.Checked = false;
				}
				AutoBoneAssigment.Class35 @class = this.listView1.SelectedItems[0] as AutoBoneAssigment.Class35;
				foreach (string value in @class.UsedGroups)
				{
					foreach (object obj2 in this.listView2.Items)
					{
						ListViewItem listViewItem2 = (ListViewItem)obj2;
						if (listViewItem2.Text.Equals(value))
						{
							listViewItem2.Checked = true;
						}
					}
				}
				this.bool_0 = false;
			}
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00028E04 File Offset: 0x00027004
		private void listView2_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (this.listView1.SelectedItems.Count != 0 && !this.bool_0)
			{
				AutoBoneAssigment.Class35 @class = this.listView1.SelectedItems[0] as AutoBoneAssigment.Class35;
				ListViewItem listViewItem = this.listView2.Items[e.Index];
				if (e.NewValue == CheckState.Checked)
				{
					@class.UsedGroups.Add(listViewItem.Text);
				}
				else
				{
					@class.UsedGroups.Remove(listViewItem.Text);
				}
			}
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00028E8C File Offset: 0x0002708C
		private void button2_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.listView1.Items)
			{
				AutoBoneAssigment.Class35 @class = (AutoBoneAssigment.Class35)obj;
				if (@class.Checked)
				{
					this.Entries.Add(@class);
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000034B4 File Offset: 0x000016B4
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040001AB RID: 427
		private bool bool_0;

		// Token: 0x040001AC RID: 428
		private IContainer icontainer_0;

		// Token: 0x040001BE RID: 446
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040001BF RID: 447
		[CompilerGenerated]
		private WSOFile wsofile_0;

		// Token: 0x040001C0 RID: 448
		[CompilerGenerated]
		private List<AutoBoneAssigment.Class35> list_0;

		// Token: 0x02000038 RID: 56
		public sealed class Class35 : ListViewItem
		{
			// Token: 0x1700005A RID: 90
			// (get) Token: 0x06000214 RID: 532 RVA: 0x00029A6C File Offset: 0x00027C6C
			// (set) Token: 0x06000215 RID: 533 RVA: 0x000034D5 File Offset: 0x000016D5
			public new object Tag { get; set; }

			// Token: 0x1700005B RID: 91
			// (get) Token: 0x06000216 RID: 534 RVA: 0x00029A84 File Offset: 0x00027C84
			// (set) Token: 0x06000217 RID: 535 RVA: 0x000034E0 File Offset: 0x000016E0
			public List<string> UsedGroups { get; set; }

			// Token: 0x06000218 RID: 536 RVA: 0x00029A9C File Offset: 0x00027C9C
			public Class35(string name, object tag)
			{
				this.Tag = tag;
				base.Name = name;
				base.Text = base.Name + " - " + ((tag == null) ? "" : tag.ToString());
				this.UsedGroups = new List<string>();
			}

			// Token: 0x06000219 RID: 537 RVA: 0x00029AF0 File Offset: 0x00027CF0
			public string ToString()
			{
				return base.Text + " - " + this.Tag.ToString();
			}

			// Token: 0x040001C1 RID: 449
			[CompilerGenerated]
			private object object_0;

			// Token: 0x040001C2 RID: 450
			[CompilerGenerated]
			private List<string> list_0;
		}
	}
}
