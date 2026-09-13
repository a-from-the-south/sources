using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns8;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;

namespace ns6
{
	// Token: 0x02000060 RID: 96
	internal sealed partial class MLODEntryEditor : Form
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x00044140 File Offset: 0x00042340
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x00004051 File Offset: 0x00002251
		public RCOL MLODModel { get; set; }

		// Token: 0x060003B6 RID: 950 RVA: 0x0000405C File Offset: 0x0000225C
		public MLODEntryEditor(MLOD mlod)
		{
			this.mlod = mlod;
			this.InitializeComponent();
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00004073 File Offset: 0x00002273
		private void doneButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			if (this.bool_0)
			{
				base.DialogResult = DialogResult.OK;
			}
			base.Close();
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00004093 File Offset: 0x00002293
		private void exportButton_Click(object sender, EventArgs e)
		{
			if (Class132.mainForm.ExportFile(DBPFType.MLOD, this.mlod.Parent) == PluginResult.OK)
			{
				MessageBox.Show(this, "Export complete!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00044158 File Offset: 0x00042358
		private void importButton_Click(object sender, EventArgs e)
		{
			this.MLODModel = (this.mlod.Parent.Clone() as RCOL);
			this.bool_0 = (Class132.mainForm.ImportFile(DBPFType.MLOD, this.MLODModel) == PluginResult.OK);
			if (this.bool_0)
			{
				MessageBox.Show(this, "Import complete!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x060003BB RID: 955 RVA: 0x000040C8 File Offset: 0x000022C8
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000380 RID: 896
		private MLOD mlod;

		// Token: 0x04000381 RID: 897
		private bool bool_0;

		// Token: 0x04000382 RID: 898
		private IContainer icontainer_0;

		// Token: 0x04000387 RID: 903
		[CompilerGenerated]
		private RCOL rcol_0;
	}
}
