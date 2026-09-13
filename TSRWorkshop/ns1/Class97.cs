using System;
using System.Collections;
using System.Windows.Forms;

namespace ns1
{
	// Token: 0x020000E6 RID: 230
	internal sealed class Class97 : IComparer
	{
		// Token: 0x0600096D RID: 2413 RVA: 0x000832A8 File Offset: 0x000814A8
		public int Compare(object x, object y)
		{
			ListViewItem listViewItem = (ListViewItem)x;
			ListViewItem listViewItem2 = (ListViewItem)y;
			int num = string.Compare(listViewItem.SubItems[this.int_0].Text, listViewItem2.SubItems[this.int_0].Text);
			int result;
			if (this.sortOrder_0 == SortOrder.Ascending)
			{
				result = num;
			}
			else if (this.sortOrder_0 == SortOrder.Descending)
			{
				result = -num;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600096F RID: 2415 RVA: 0x00083318 File Offset: 0x00081518
		// (set) Token: 0x0600096E RID: 2414 RVA: 0x00006311 File Offset: 0x00004511
		public int SortColumn
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000971 RID: 2417 RVA: 0x00083330 File Offset: 0x00081530
		// (set) Token: 0x06000970 RID: 2416 RVA: 0x0000631C File Offset: 0x0000451C
		public SortOrder Order
		{
			get
			{
				return this.sortOrder_0;
			}
			set
			{
				this.sortOrder_0 = value;
			}
		}

		// Token: 0x0400079F RID: 1951
		private int int_0;

		// Token: 0x040007A0 RID: 1952
		private SortOrder sortOrder_0;
	}
}
