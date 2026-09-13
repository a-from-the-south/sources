using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK.Interfaces;

namespace ns19
{
	// Token: 0x020000E1 RID: 225
	internal sealed partial class PickMLOD : Form
	{
		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x00080180 File Offset: 0x0007E380
		// (set) Token: 0x06000942 RID: 2370 RVA: 0x00006285 File Offset: 0x00004485
		public List<object[]> Entries { get; private set; }

		// Token: 0x06000943 RID: 2371 RVA: 0x00080198 File Offset: 0x0007E398
		public PickMLOD(List<MLOD> lods)
		{
			this.InitializeComponent();
			this.Entries = new List<object[]>();
			foreach (MLOD mlod in lods)
			{
				Lod lod = (Lod)(mlod.Parent.GroupID & 16777215);
				string text = lod.ToString() + " detail";
				TreeNode treeNode = new TreeNode(string.Concat(new object[]
				{
					text,
					" ",
					mlod.Entries.Count,
					" entries"
				}));
				treeNode.Tag = mlod;
				foreach (MLOD.MLODEntry mlodentry in mlod.Entries)
				{
					TreeNode treeNode2 = new TreeNode(mlodentry.ToString());
					treeNode2.Tag = mlodentry;
					treeNode2.Expand();
					treeNode.Nodes.Add(treeNode2);
				}
				treeNode.Expand();
				this.treeView1.Nodes.Add(treeNode);
			}
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0008030C File Offset: 0x0007E50C
		private void okButton_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.treeView1.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				foreach (object obj2 in treeNode.Nodes)
				{
					TreeNode treeNode2 = (TreeNode)obj2;
					if (treeNode2.Checked)
					{
						this.Entries.Add(new object[]
						{
							treeNode.Tag,
							treeNode2.Tag
						});
					}
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x000803EC File Offset: 0x0007E5EC
		private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Tag is MLOD)
			{
				foreach (object obj in e.Node.Nodes)
				{
					TreeNode treeNode = (TreeNode)obj;
					treeNode.Checked = e.Node.Checked;
				}
			}
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00006290 File Offset: 0x00004490
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000761 RID: 1889
		private IContainer icontainer_0;

		// Token: 0x04000767 RID: 1895
		[CompilerGenerated]
		private List<object[]> list_0;
	}
}
