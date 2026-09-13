using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;

namespace ns10
{
	// Token: 0x02000009 RID: 9
	internal sealed partial class GenericValueListEditor : Form
	{
		// Token: 0x06000030 RID: 48 RVA: 0x0000E828 File Offset: 0x0000CA28
		public GenericValueListEditor(MLOD.MLODEntry mlodEntry, VRTF vrtf, VertexFormatEntry entry)
		{
			RCOL parent = mlodEntry.Parent.Parent;
			VBUF vbuf = parent.Entries[mlodEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)] as VBUF;
			RCOLItem rcolitem = parent.Entries[mlodEntry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)];
			this.InitializeComponent();
			VertexEntryType type = entry.Type;
			if (type != VertexEntryType.FLOAT2)
			{
				if (type == VertexEntryType.Short2)
				{
					this.listView1.Columns.Add("Word");
					this.listView1.Columns.Add("Word");
				}
			}
			else
			{
				this.listView1.Columns.Add("Float");
				this.listView1.Columns.Add("Float");
			}
			for (int i = 0; i < mlodEntry.VertexCount; i++)
			{
				List<object> data = vbuf.GetData(i, vrtf, entry, mlodEntry.VBUFOffset);
				ListViewItem listViewItem = null;
				foreach (object obj in data)
				{
					if (listViewItem == null)
					{
						listViewItem = this.listView1.Items.Add(obj.ToString());
					}
					else
					{
						listViewItem.SubItems.Add(obj.ToString());
					}
				}
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002AF4 File Offset: 0x00000CF4
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0400004E RID: 78
		private IContainer icontainer_0;
	}
}
