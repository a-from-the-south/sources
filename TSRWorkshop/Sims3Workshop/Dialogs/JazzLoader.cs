using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns1;
using ns16;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;

namespace Sims3Workshop.Dialogs
{
	// Token: 0x020000D6 RID: 214
	public sealed partial class JazzLoader : Form
	{
		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060008DA RID: 2266 RVA: 0x0007BBDC File Offset: 0x00079DDC
		// (remove) Token: 0x060008DB RID: 2267 RVA: 0x0007BC14 File Offset: 0x00079E14
		public event JazzLoader.GDelegate0 OnLoadClip
		{
			add
			{
				JazzLoader.GDelegate0 gdelegate = this.gdelegate0_0;
				JazzLoader.GDelegate0 gdelegate2;
				do
				{
					gdelegate2 = gdelegate;
					JazzLoader.GDelegate0 value2 = (JazzLoader.GDelegate0)Delegate.Combine(gdelegate2, value);
					gdelegate = Interlocked.CompareExchange<JazzLoader.GDelegate0>(ref this.gdelegate0_0, value2, gdelegate2);
				}
				while (gdelegate != gdelegate2);
			}
			remove
			{
				JazzLoader.GDelegate0 gdelegate = this.gdelegate0_0;
				JazzLoader.GDelegate0 gdelegate2;
				do
				{
					gdelegate2 = gdelegate;
					JazzLoader.GDelegate0 value2 = (JazzLoader.GDelegate0)Delegate.Remove(gdelegate2, value);
					gdelegate = Interlocked.CompareExchange<JazzLoader.GDelegate0>(ref this.gdelegate0_0, value2, gdelegate2);
				}
				while (gdelegate != gdelegate2);
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0007BC4C File Offset: 0x00079E4C
		public JazzLoader()
		{
			this.InitializeComponent();
			this.autoCompleteStringCollection_0 = new AutoCompleteStringCollection();
			this.comboBox1.AutoCompleteCustomSource = this.autoCompleteStringCollection_0;
			this.comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0007BC9C File Offset: 0x00079E9C
		public void method_0()
		{
			this.listView1.Items.Clear();
			this.autoCompleteStringCollection_0.Clear();
			NameMap nameMap = Class76.smethod_30(new ResKey("key:0166038c:00000000:E04EA45043e8ba2a"), false, true) as NameMap;
			List<ResKey> list = Class76.smethod_19(new ResKey(DBPFType.JAZZ));
			foreach (ResKey resKey_ in list)
			{
				JAZZ jazz = Class76.smethod_26(resKey_) as JAZZ;
				S_SM s_SM = jazz.Entries[0] as S_SM;
				string text = "unknown";
				foreach (NameMap.MapEntry mapEntry in nameMap.Map)
				{
					if (mapEntry.Instance == (long)((ulong)s_SM.hashedName))
					{
						text = mapEntry.Name;
					}
				}
				this.autoCompleteStringCollection_0.Add(text);
				if (!(this.comboBox1.Text != "") || text.ToLower().Contains(this.comboBox1.Text.ToLower()))
				{
					foreach (RCOLItem rcolitem in jazz.Entries)
					{
						if (rcolitem is S_Play)
						{
							ListViewItem listViewItem = this.listView1.Items.Add(text);
							S_Play s_Play = rcolitem as S_Play;
							if (!string.IsNullOrEmpty(s_Play.animationName))
							{
								listViewItem.SubItems.Add(s_Play.animationName);
								listViewItem.SubItems.Add("");
							}
							else
							{
								listViewItem.SubItems.Add(s_Play.clip.AsString());
								listViewItem.SubItems.Add("");
							}
						}
					}
				}
			}
			this.listView1.Columns[0].Width = -2;
			this.listView1.Columns[1].Width = -2;
			this.listView1.Columns[2].Width = -2;
			this.listView1.EndUpdate();
			this.listView1.ListViewItemSorter = this.class97_0;
			this.listView1.Sort();
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void closeButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0007BF54 File Offset: 0x0007A154
		private void loadButton_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count > 0)
			{
				try
				{
					ResKey resKey = new ResKey(this.listView1.SelectedItems[0].SubItems[1].Text);
					ResKey resKey_ = Class76.smethod_17(resKey, false);
					S_CLIP s_CLIP = Class76.smethod_26(resKey_) as S_CLIP;
					this.listView1.SelectedItems[0].SubItems[2].Text = s_CLIP.ActorName;
					if (this.gdelegate0_0 != null)
					{
						this.gdelegate0_0(resKey);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00006067 File Offset: 0x00004267
		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			this.loadButton_Click(sender, e);
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0007C010 File Offset: 0x0007A210
		private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column == this.class97_0.SortColumn)
			{
				if (this.class97_0.Order == SortOrder.Ascending)
				{
					this.class97_0.Order = SortOrder.Descending;
				}
				else
				{
					this.class97_0.Order = SortOrder.Ascending;
				}
			}
			else
			{
				this.class97_0.SortColumn = e.Column;
				this.class97_0.Order = SortOrder.Ascending;
			}
			this.listView1.Sort();
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00002A71 File Offset: 0x00000C71
		private void JazzLoader_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00006073 File Offset: 0x00004273
		private void JazzLoader_Shown(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00006073 File Offset: 0x00004273
		private void method_1(object sender, KeyEventArgs e)
		{
			this.method_0();
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00002A71 File Offset: 0x00000C71
		private void comboBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00002A71 File Offset: 0x00000C71
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00002A71 File Offset: 0x00000C71
		private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
		{
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00006073 File Offset: 0x00004273
		private void button1_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0000607D File Offset: 0x0000427D
		private void comboBox1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.method_0();
			}
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00006091 File Offset: 0x00004291
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000710 RID: 1808
		private JazzLoader.GDelegate0 gdelegate0_0;

		// Token: 0x04000711 RID: 1809
		private Class97 class97_0 = new Class97();

		// Token: 0x04000712 RID: 1810
		private AutoCompleteStringCollection autoCompleteStringCollection_0;

		// Token: 0x04000713 RID: 1811
		private static List<ResKey> list_0;

		// Token: 0x04000714 RID: 1812
		private static List<ResKey> list_1;

		// Token: 0x04000715 RID: 1813
		private IContainer icontainer_0;

		// Token: 0x020000D7 RID: 215
		// (Invoke) Token: 0x060008ED RID: 2285
		public delegate void GDelegate0(ResKey reskey);
	}
}
