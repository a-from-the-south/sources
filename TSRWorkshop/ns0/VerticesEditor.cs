using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;

namespace ns0
{
	// Token: 0x02000083 RID: 131
	internal sealed partial class VerticesEditor : Form
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x0004FD7C File Offset: 0x0004DF7C
		// (set) Token: 0x0600050A RID: 1290 RVA: 0x00004ACA File Offset: 0x00002CCA
		private RCOL _geometry { get; set; }

		// Token: 0x0600050B RID: 1291 RVA: 0x0004FD94 File Offset: 0x0004DF94
		public VerticesEditor(RCOL geometry)
		{
			this._geometry = geometry;
			this.InitializeComponent();
			GEOM geom = geometry.Entries[0] as GEOM;
			VerticesEditor.Class56[] array = new VerticesEditor.Class56[geom.vertices.Count];
			int num = 0;
			foreach (GEOM.GEOMVertex geomvertex in geom.vertices)
			{
				array[num++] = new VerticesEditor.Class56(num, Convert.ToString(geomvertex.vertexId), ((int)geomvertex.tagVal[0] + ((int)geomvertex.tagVal[1] << 8) + ((int)geomvertex.tagVal[2] << 16) + ((int)geomvertex.tagVal[3] << 24)).ToString("X8"));
			}
			this.dataGridView1.DataSource = array;
			this.dataGridView1.AutoResizeColumn(0);
			this.dataGridView1.AutoResizeColumn(1);
			this.dataGridView1.AutoResizeColumn(2);
			this.dataGridView1.Columns[0].ReadOnly = true;
			this.textBox_0 = new TextBox();
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0004FEC0 File Offset: 0x0004E0C0
		private void okButton_Click(object sender, EventArgs e)
		{
			VerticesEditor.Class56[] array = this.dataGridView1.DataSource as VerticesEditor.Class56[];
			GEOM geom = this._geometry.Entries[0] as GEOM;
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					VerticesEditor.Class56 @class = array[i];
					geom.vertices[i].tagVal = new byte[]
					{
						(byte)(Convert.ToInt32(@class.Tagvalue, 16) & 255),
						(byte)(Convert.ToInt32(@class.Tagvalue, 16) >> 8 & 255),
						(byte)(Convert.ToInt32(@class.Tagvalue, 16) >> 16 & 255),
						(byte)(Convert.ToInt32(@class.Tagvalue, 16) >> 24 & 255)
					};
					geom.vertices[i].vertexId = Convert.ToInt32(@class.VertexID);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0004FFE0 File Offset: 0x0004E1E0
		private void fillAllWithThisValueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.dataGridView1.SelectedCells.Count == 1)
			{
				DataGridViewCell dataGridViewCell = this.dataGridView1.SelectedCells[0];
				int columnIndex = dataGridViewCell.ColumnIndex;
				VerticesEditor.Class56[] array = this.dataGridView1.DataSource as VerticesEditor.Class56[];
				RCOLItem rcolitem = this._geometry.Entries[0];
				for (int i = 0; i < array.Length; i++)
				{
					if (columnIndex == 1)
					{
						array[i].VertexID = (dataGridViewCell.Value as string);
					}
					else if (columnIndex == 2)
					{
						array[i].Tagvalue = (dataGridViewCell.Value as string);
					}
				}
				this.dataGridView1.Refresh();
				this.dataGridView1.RefreshEdit();
			}
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00004AD5 File Offset: 0x00002CD5
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000488 RID: 1160
		private TextBox textBox_0;

		// Token: 0x04000491 RID: 1169
		[CompilerGenerated]
		private RCOL rcol_0;

		// Token: 0x02000084 RID: 132
		internal sealed class Class56
		{
			// Token: 0x170000CE RID: 206
			// (get) Token: 0x06000511 RID: 1297 RVA: 0x000504FC File Offset: 0x0004E6FC
			// (set) Token: 0x06000512 RID: 1298 RVA: 0x00004AF6 File Offset: 0x00002CF6
			public int VertexNum { get; set; }

			// Token: 0x170000CF RID: 207
			// (get) Token: 0x06000513 RID: 1299 RVA: 0x00050514 File Offset: 0x0004E714
			// (set) Token: 0x06000514 RID: 1300 RVA: 0x00004B01 File Offset: 0x00002D01
			public string VertexID { get; set; }

			// Token: 0x170000D0 RID: 208
			// (get) Token: 0x06000515 RID: 1301 RVA: 0x0005052C File Offset: 0x0004E72C
			// (set) Token: 0x06000516 RID: 1302 RVA: 0x00004B0C File Offset: 0x00002D0C
			public string Tagvalue { get; set; }

			// Token: 0x06000517 RID: 1303 RVA: 0x00004B17 File Offset: 0x00002D17
			public Class56(int num, string id, string tag)
			{
				this.Tagvalue = tag;
				this.VertexNum = num;
				this.VertexID = id;
			}

			// Token: 0x04000492 RID: 1170
			[CompilerGenerated]
			private int int_0;

			// Token: 0x04000493 RID: 1171
			[CompilerGenerated]
			private string string_0;

			// Token: 0x04000494 RID: 1172
			[CompilerGenerated]
			private string string_1;
		}
	}
}
