using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;

namespace ns18
{
	// Token: 0x020000C9 RID: 201
	internal sealed partial class BoneAssigmentEditor : Form
	{
		// Token: 0x06000874 RID: 2164 RVA: 0x00078124 File Offset: 0x00076324
		public BoneAssigmentEditor(MLOD mlod, MLOD.MLODEntry mlodEntry)
		{
			this.mlod = mlod;
			this.mlodEntry = mlodEntry;
			this.InitializeComponent();
			RCOL parent = this.mlod.Parent;
			this.list_0 = new List<BoneAssigmentEditor.Class90>(mlodEntry.VertexCount);
			VRTF vrtf = parent.Entries[mlodEntry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] as VRTF;
			VBUF vbuf = (VBUF)parent.Entries[mlodEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)];
			if (vrtf == null)
			{
				vrtf = VRTF.GetDefaultForLength((mlodEntry.Type == 20483U) ? 8 : 16);
			}
			List<string> list = new List<string>();
			for (int i = 0; i < mlodEntry.VertexCount; i++)
			{
				sbyte[] assignment = vbuf.GetAssignment(vrtf, i, mlodEntry.VBUFOffset, 0);
				float[] weights = vbuf.GetWeights(vrtf, i, mlodEntry.VBUFOffset, 0);
				string b = (assignment[0] != -1) ? ("0x" + mlodEntry.Bones[(int)((byte)assignment[0])].ToString("X8")) : "";
				string b2 = (assignment[1] != -1) ? ("0x" + mlodEntry.Bones[(int)((byte)assignment[1])].ToString("X8")) : "";
				string b3 = (assignment[2] != -1) ? ("0x" + mlodEntry.Bones[(int)((byte)assignment[2])].ToString("X8")) : "";
				string b4 = (assignment[3] != -1) ? ("0x" + mlodEntry.Bones[(int)((byte)assignment[3])].ToString("X8")) : "";
				string w = weights[0].ToString("0.000000000000");
				string w2 = weights[1].ToString("0.000000000000");
				string w3 = weights[2].ToString("0.000000000000");
				string w4 = weights[3].ToString("0.000000000000");
				BoneAssigmentEditor.Class90 item = new BoneAssigmentEditor.Class90(i, b, b2, b3, b4, w, w2, w3, w4);
				this.list_0.Add(item);
				if (list.IndexOf(assignment[0].ToString()) == -1)
				{
					list.Add(assignment[0].ToString());
				}
				if (list.IndexOf(assignment[1].ToString()) == -1)
				{
					list.Add(assignment[1].ToString());
				}
				if (list.IndexOf(assignment[2].ToString()) == -1)
				{
					list.Add(assignment[2].ToString());
				}
				if (list.IndexOf(assignment[3].ToString()) == -1)
				{
					list.Add(assignment[3].ToString());
				}
			}
			this.dataGridView1.DataSource = this.list_0;
			foreach (string item2 in list)
			{
				this.listBox1.Items.Add(item2);
			}
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00078470 File Offset: 0x00076670
		private void okButton_Click(object sender, EventArgs e)
		{
			RCOL parent = this.mlod.Parent;
			VRTF vrtf = parent.Entries[this.mlodEntry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] as VRTF;
			VBUF vbuf = (VBUF)parent.Entries[this.mlodEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)];
			if (vrtf == null)
			{
				vrtf = VRTF.GetDefaultForLength((this.mlodEntry.Type == 20483U) ? 8 : 16);
			}
			new List<string>();
			for (int i = 0; i < this.list_0.Count; i++)
			{
				BoneAssigmentEditor.Class90 @class = this.list_0[i];
				int num = Convert.ToInt32(@class.VertexNum);
				try
				{
					float num2 = Convert.ToSingle(@class.Weight1);
					float num3 = Convert.ToSingle(@class.Weight2);
					float num4 = Convert.ToSingle(@class.Weight3);
					float num5 = Convert.ToSingle(@class.Weight4);
					sbyte b = -1;
					sbyte b2 = -1;
					sbyte b3 = -1;
					sbyte b4 = -1;
					if (!string.IsNullOrEmpty(@class.Bone1))
					{
						b = (sbyte)this.mlodEntry.Bones.IndexOf(Convert.ToUInt32(@class.Bone1, 16));
					}
					if (!string.IsNullOrEmpty(@class.Bone2))
					{
						b2 = (sbyte)this.mlodEntry.Bones.IndexOf(Convert.ToUInt32(@class.Bone2, 16));
					}
					if (!string.IsNullOrEmpty(@class.Bone3))
					{
						b3 = (sbyte)this.mlodEntry.Bones.IndexOf(Convert.ToUInt32(@class.Bone3, 16));
					}
					if (!string.IsNullOrEmpty(@class.Bone4))
					{
						b4 = (sbyte)this.mlodEntry.Bones.IndexOf(Convert.ToUInt32(@class.Bone4, 16));
					}
					vbuf.SetAssignment(vrtf, num, this.mlodEntry.VBUFOffset, new sbyte[]
					{
						b,
						b2,
						b3,
						b4
					});
					vbuf.SetWeights(vrtf, num, this.mlodEntry.VBUFOffset, new float[]
					{
						num2,
						num3,
						num4,
						num5
					});
				}
				catch (Exception ex)
				{
					MessageBox.Show(string.Concat(new object[]
					{
						"Invalid data for vertex #",
						num,
						"\n\n",
						ex.Message
					}));
					return;
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00078718 File Offset: 0x00076918
		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			this.listBox1.Items.Clear();
			foreach (object obj in this.dataGridView1.SelectedCells)
			{
				DataGridViewTextBoxCell dataGridViewTextBoxCell = (DataGridViewTextBoxCell)obj;
				BoneAssigmentEditor.Class90 @class = this.list_0[dataGridViewTextBoxCell.RowIndex];
				if (list.IndexOf(@class.Bone1) == -1)
				{
					list.Add(@class.Bone1);
				}
				if (list.IndexOf(@class.Bone2) == -1)
				{
					list.Add(@class.Bone2);
				}
				if (list.IndexOf(@class.Bone3) == -1)
				{
					list.Add(@class.Bone3);
				}
				if (list.IndexOf(@class.Bone4) == -1)
				{
					list.Add(@class.Bone4);
				}
			}
			List<string> list2 = list;
			if (BoneAssigmentEditor.comparison_0 == null)
			{
				BoneAssigmentEditor.comparison_0 = new Comparison<string>(BoneAssigmentEditor.smethod_0);
			}
			list2.Sort(BoneAssigmentEditor.comparison_0);
			foreach (string text in list)
			{
				if (!string.IsNullOrEmpty(text))
				{
					this.listBox1.Items.Add(text);
				}
			}
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00078888 File Offset: 0x00076A88
		private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			BoneAssigmentEditor.Class91 @class = new BoneAssigmentEditor.Class91();
			@class.string_0 = this.dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
			this.list_0.Sort(new Comparison<BoneAssigmentEditor.Class90>(@class.method_0));
			this.dataGridView1.DataSource = this.list_0;
			this.dataGridView1.Invalidate();
			this.dataGridView1.Refresh();
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x000788FC File Offset: 0x00076AFC
		private void button2_Click(object sender, EventArgs e)
		{
			if (this.listBox1.SelectedItems.Count != 0)
			{
				object selectedItem = this.listBox1.SelectedItem;
				foreach (BoneAssigmentEditor.Class90 @class in this.list_0)
				{
					if (@class.Bone1.Equals(selectedItem))
					{
						@class.Weight1 = "0";
					}
					if (@class.Bone2.Equals(selectedItem))
					{
						@class.Weight2 = "0";
					}
					if (@class.Bone3.Equals(selectedItem))
					{
						@class.Weight3 = "0";
					}
					if (@class.Bone4.Equals(selectedItem))
					{
						@class.Weight4 = "0";
					}
				}
				this.dataGridView1.DataSource = this.list_0;
				this.dataGridView1.Invalidate();
				this.dataGridView1.Refresh();
			}
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x000789FC File Offset: 0x00076BFC
		private void button1_Click(object sender, EventArgs e)
		{
			if (this.listBox1.SelectedItems.Count != 0)
			{
				object selectedItem = this.listBox1.SelectedItem;
				foreach (BoneAssigmentEditor.Class90 @class in this.list_0)
				{
					if (@class.Bone1.Equals(selectedItem))
					{
						@class.Bone1 = "";
					}
					if (@class.Bone2.Equals(selectedItem))
					{
						@class.Bone2 = "";
					}
					if (@class.Bone3.Equals(selectedItem))
					{
						@class.Bone3 = "";
					}
					if (@class.Bone4.Equals(selectedItem))
					{
						@class.Bone4 = "";
					}
				}
				this.dataGridView1.DataSource = this.list_0;
				this.dataGridView1.Invalidate();
				this.dataGridView1.Refresh();
			}
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00005D75 File Offset: 0x00003F75
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x000794B0 File Offset: 0x000776B0
		[CompilerGenerated]
		private static int smethod_0(string string_0, string string_1)
		{
			return string_0.CompareTo(string_1);
		}

		// Token: 0x040006B8 RID: 1720
		private MLOD mlod;

		// Token: 0x040006B9 RID: 1721
		private MLOD.MLODEntry mlodEntry;

		// Token: 0x040006BA RID: 1722
		private List<BoneAssigmentEditor.Class90> list_0;

		// Token: 0x040006BB RID: 1723
		private IContainer icontainer_0;

		// Token: 0x040006CF RID: 1743
		[CompilerGenerated]
		private static Comparison<string> comparison_0;

		// Token: 0x020000CA RID: 202
		internal sealed class Class90
		{
			// Token: 0x1700016A RID: 362
			// (get) Token: 0x0600087E RID: 2174 RVA: 0x000794C8 File Offset: 0x000776C8
			// (set) Token: 0x0600087F RID: 2175 RVA: 0x00005D96 File Offset: 0x00003F96
			public int VertexNum { get; set; }

			// Token: 0x1700016B RID: 363
			// (get) Token: 0x06000880 RID: 2176 RVA: 0x000794E0 File Offset: 0x000776E0
			// (set) Token: 0x06000881 RID: 2177 RVA: 0x00005DA1 File Offset: 0x00003FA1
			public string Bone1 { get; set; }

			// Token: 0x1700016C RID: 364
			// (get) Token: 0x06000882 RID: 2178 RVA: 0x000794F8 File Offset: 0x000776F8
			// (set) Token: 0x06000883 RID: 2179 RVA: 0x00005DAC File Offset: 0x00003FAC
			public string Bone2 { get; set; }

			// Token: 0x1700016D RID: 365
			// (get) Token: 0x06000884 RID: 2180 RVA: 0x00079510 File Offset: 0x00077710
			// (set) Token: 0x06000885 RID: 2181 RVA: 0x00005DB7 File Offset: 0x00003FB7
			public string Bone3 { get; set; }

			// Token: 0x1700016E RID: 366
			// (get) Token: 0x06000886 RID: 2182 RVA: 0x00079528 File Offset: 0x00077728
			// (set) Token: 0x06000887 RID: 2183 RVA: 0x00005DC2 File Offset: 0x00003FC2
			public string Bone4 { get; set; }

			// Token: 0x1700016F RID: 367
			// (get) Token: 0x06000888 RID: 2184 RVA: 0x00079540 File Offset: 0x00077740
			// (set) Token: 0x06000889 RID: 2185 RVA: 0x00005DCD File Offset: 0x00003FCD
			public string Weight1 { get; set; }

			// Token: 0x17000170 RID: 368
			// (get) Token: 0x0600088A RID: 2186 RVA: 0x00079558 File Offset: 0x00077758
			// (set) Token: 0x0600088B RID: 2187 RVA: 0x00005DD8 File Offset: 0x00003FD8
			public string Weight2 { get; set; }

			// Token: 0x17000171 RID: 369
			// (get) Token: 0x0600088C RID: 2188 RVA: 0x00079570 File Offset: 0x00077770
			// (set) Token: 0x0600088D RID: 2189 RVA: 0x00005DE3 File Offset: 0x00003FE3
			public string Weight3 { get; set; }

			// Token: 0x17000172 RID: 370
			// (get) Token: 0x0600088E RID: 2190 RVA: 0x00079588 File Offset: 0x00077788
			// (set) Token: 0x0600088F RID: 2191 RVA: 0x00005DEE File Offset: 0x00003FEE
			public string Weight4 { get; set; }

			// Token: 0x06000890 RID: 2192 RVA: 0x000795A0 File Offset: 0x000777A0
			public Class90(int num, string b1, string b2, string b3, string b4, string w1, string w2, string w3, string w4)
			{
				this.VertexNum = num;
				this.Bone1 = b1;
				this.Bone2 = b2;
				this.Bone3 = b3;
				this.Bone4 = b4;
				this.Weight1 = w1;
				this.Weight2 = w2;
				this.Weight3 = w3;
				this.Weight4 = w4;
			}

			// Token: 0x040006D0 RID: 1744
			[CompilerGenerated]
			private int int_0;

			// Token: 0x040006D1 RID: 1745
			[CompilerGenerated]
			private string string_0;

			// Token: 0x040006D2 RID: 1746
			[CompilerGenerated]
			private string string_1;

			// Token: 0x040006D3 RID: 1747
			[CompilerGenerated]
			private string string_2;

			// Token: 0x040006D4 RID: 1748
			[CompilerGenerated]
			private string string_3;

			// Token: 0x040006D5 RID: 1749
			[CompilerGenerated]
			private string string_4;

			// Token: 0x040006D6 RID: 1750
			[CompilerGenerated]
			private string string_5;

			// Token: 0x040006D7 RID: 1751
			[CompilerGenerated]
			private string string_6;

			// Token: 0x040006D8 RID: 1752
			[CompilerGenerated]
			private string string_7;
		}

		// Token: 0x020000CB RID: 203
		[CompilerGenerated]
		private sealed class Class91
		{
			// Token: 0x06000892 RID: 2194 RVA: 0x000795FC File Offset: 0x000777FC
			public int method_0(BoneAssigmentEditor.Class90 class90_0, BoneAssigmentEditor.Class90 class90_1)
			{
				string key;
				switch (key = this.string_0)
				{
				case "VertexNum":
					return Convert.ToInt32(class90_0.VertexNum).CompareTo(Convert.ToInt32(class90_1.VertexNum));
				case "Bone1":
					return class90_0.Bone1.CompareTo(class90_1.Bone1);
				case "Weight1":
					return Convert.ToSingle(class90_0.Weight1).CompareTo(Convert.ToSingle(class90_1.Weight1));
				case "Bone2":
					return class90_0.Bone2.CompareTo(class90_1.Bone2);
				case "Weight2":
					return Convert.ToSingle(class90_0.Weight2).CompareTo((float)Convert.ToInt32(class90_1.Weight2));
				case "Bone3":
					return class90_0.Bone3.CompareTo(class90_1.Bone3);
				case "Weight3":
					return Convert.ToSingle(class90_0.Weight3).CompareTo(Convert.ToSingle(class90_1.Weight3));
				case "Bone4":
					return class90_0.Bone4.CompareTo(class90_1.Bone4);
				case "Weight4":
					return Convert.ToSingle(class90_0.Weight4).CompareTo(Convert.ToSingle(class90_1.Weight4));
				}
				return 0;
			}

			// Token: 0x040006D9 RID: 1753
			public string string_0;
		}
	}
}
