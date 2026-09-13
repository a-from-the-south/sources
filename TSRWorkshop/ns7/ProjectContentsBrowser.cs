using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns1;
using ns10;
using ns16;
using ns17;
using ns18;
using ns8;
using Package;
using Package.Sims3Files;
using Package.Squish;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Interfaces;

namespace ns7
{
	// Token: 0x020000E3 RID: 227
	internal sealed partial class ProjectContentsBrowser : Form
	{
		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x000813D8 File Offset: 0x0007F5D8
		// (set) Token: 0x06000952 RID: 2386 RVA: 0x000062D2 File Offset: 0x000044D2
		public List<DBPFType> TypeFilter { get; set; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x000813F0 File Offset: 0x0007F5F0
		// (set) Token: 0x06000954 RID: 2388 RVA: 0x000062DD File Offset: 0x000044DD
		public List<ResKey> SelectedItems { get; set; }

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000955 RID: 2389 RVA: 0x00081408 File Offset: 0x0007F608
		// (remove) Token: 0x06000956 RID: 2390 RVA: 0x00081440 File Offset: 0x0007F640
		public event ProjectContentsBrowser.Delegate28 Done
		{
			add
			{
				ProjectContentsBrowser.Delegate28 @delegate = this.delegate28_0;
				ProjectContentsBrowser.Delegate28 delegate2;
				do
				{
					delegate2 = @delegate;
					ProjectContentsBrowser.Delegate28 value2 = (ProjectContentsBrowser.Delegate28)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<ProjectContentsBrowser.Delegate28>(ref this.delegate28_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				ProjectContentsBrowser.Delegate28 @delegate = this.delegate28_0;
				ProjectContentsBrowser.Delegate28 delegate2;
				do
				{
					delegate2 = @delegate;
					ProjectContentsBrowser.Delegate28 value2 = (ProjectContentsBrowser.Delegate28)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<ProjectContentsBrowser.Delegate28>(ref this.delegate28_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00081478 File Offset: 0x0007F678
		public ProjectContentsBrowser(DBPF dbpf)
		{
			this.SelectedItems = new List<ResKey>();
			this.dbpf = dbpf;
			this.TypeFilter = new List<DBPFType>
			{
				DBPFType.ALL
			};
			this.InitializeComponent();
			this.listView1.ListViewItemSorter = this.class97_0;
			this.class97_0.Order = SortOrder.Ascending;
			this.class97_0.SortColumn = 0;
			this.listView1.Sort();
			foreach (IImportPlugin importPlugin in Class132.mainForm.ImportPlugins)
			{
				if (typeof(IImportPlugin).IsAssignableFrom(importPlugin.GetType()) && importPlugin.Location == ImportLocation.ProjectContents)
				{
					Class141 @class = new Class141(importPlugin as IWorkshopExtension);
					@class.Click += this.method_0;
					@class.Text = importPlugin.MenuItemText;
					this.pjImportMenuItem.DropDownItems.Add(@class);
				}
			}
			foreach (IExportPlugin exportPlugin in Class132.mainForm.ExportPlugins)
			{
				if (typeof(IExportPlugin).IsAssignableFrom(exportPlugin.GetType()) && exportPlugin.Location == ExportLocation.ProjectContents)
				{
					Class141 class2 = new Class141(exportPlugin as IWorkshopExtension);
					class2.Click += this.method_0;
					class2.Text = exportPlugin.MenuItemText;
					this.pjExportMenuItem.DropDownItems.Add(class2);
				}
			}
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0008163C File Offset: 0x0007F83C
		public void method_0(object sender, EventArgs e)
		{
			Class141 @class = sender as Class141;
			try
			{
				if (typeof(IImportPlugin).IsAssignableFrom(@class.Extension.GetType()))
				{
					(@class.Extension as IImportPlugin).Import();
				}
				else if (typeof(IExportPlugin).IsAssignableFrom(@class.Extension.GetType()))
				{
					(@class.Extension as IExportPlugin).Export();
				}
				else if (typeof(IToolPlugin).IsAssignableFrom(@class.Extension.GetType()))
				{
					(@class.Extension as IToolPlugin).Open();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x00081704 File Offset: 0x0007F904
		private void ProjectContentsBrowser_Load(object sender, EventArgs e)
		{
			this.listView1.Items.Clear();
			this.listView1.BeginUpdate();
			int num = 0;
			long num2 = 0L;
			long num3 = 0L;
			foreach (DBPFType typeId in this.TypeFilter)
			{
				List<ResKey> list = this.dbpf.SearchEntries(new ResKey(typeId, 0, 0, 0));
				foreach (ResKey resKey in list)
				{
					ProjectContentsBrowser.Class96 @class = new ProjectContentsBrowser.Class96();
					@class.resKey_0 = resKey;
					@class.Text = ((DBPFType)resKey.TypeId).ToString();
					this.listView1.Items.Add(@class);
					@class.SubItems.Add("0x" + resKey.GroupId.ToString("X8"));
					@class.SubItems.Add("0x" + resKey.InstanceId.ToString("X8"));
					@class.SubItems.Add("0x" + resKey.SecondInstanceId.ToString("X8"));
					num++;
					DBPFEntry entry = this.dbpf.GetEntry(resKey);
					byte[] data = entry.GetData();
					byte[] array = new byte[data.Length];
					num3 += (long)data.Length;
					@class.SubItems.Add(this.method_1(data.Length));
					int num4 = Class132.mainForm.CompressData(ref data, out array);
					if (num4 == -1)
					{
						num4 = data.Length;
					}
					num2 += (long)num4;
					@class.SubItems.Add(this.method_1(num4));
					array = null;
				}
			}
			foreach (object obj in this.listView1.Columns)
			{
				ColumnHeader columnHeader = (ColumnHeader)obj;
				columnHeader.Width = -2;
			}
			this.listView1.EndUpdate();
			this.statusLabel.Text = string.Concat(new object[]
			{
				num,
				" items, total size: ",
				this.method_1((int)num2),
				" (",
				this.method_1((int)num3),
				" uncompressed)"
			});
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00081A00 File Offset: 0x0007FC00
		private string method_1(int int_0)
		{
			string result;
			if (int_0 < 1024)
			{
				result = int_0 + " b ";
			}
			else if (int_0 < 1048576)
			{
				result = ((float)int_0 / 1024f).ToString("0.00") + " Kb";
			}
			else
			{
				result = ((float)int_0 / 1048576f).ToString("0.00") + " Mb";
			}
			return result;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00081A78 File Offset: 0x0007FC78
		private void removeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Do you really, really, reheeally want to remove the items from the project? This can not be undone.", "Remove files", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				foreach (object obj in this.listView1.SelectedItems)
				{
					ProjectContentsBrowser.Class96 @class = (ProjectContentsBrowser.Class96)obj;
					this.dbpf.RemoveEntry(@class.resKey_0);
				}
				this.ProjectContentsBrowser_Load(sender, e);
			}
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x00081B04 File Offset: 0x0007FD04
		private void button2_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.listView1.SelectedItems)
			{
				ProjectContentsBrowser.Class96 @class = (ProjectContentsBrowser.Class96)obj;
				this.SelectedItems.Add(@class.resKey_0);
			}
			base.DialogResult = DialogResult.OK;
			if (this.delegate28_0 != null)
			{
				this.delegate28_0();
			}
			base.Close();
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00081B90 File Offset: 0x0007FD90
		private void listView1_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count == 1 && (this.listView1.SelectedItems[0] as ProjectContentsBrowser.Class96).resKey_0.TypeId == 11720834U)
			{
				try
				{
					DDS dds = Class76.smethod_26((this.listView1.SelectedItems[0] as ProjectContentsBrowser.Class96).resKey_0) as DDS;
					DDS.MipMap mipMap = dds.MipMaps[0];
					this.ddsPreviewImage.Image = ImageLoader.Load(mipMap);
					dds.Dispose();
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error when loading preview.\n\n" + ex.Message);
					return;
				}
			}
			if (this.listView1.SelectedItems.Count == 1)
			{
				if ((this.listView1.SelectedItems[0] as ProjectContentsBrowser.Class96).resKey_0.TypeId != 779470692U && (this.listView1.SelectedItems[0] as ProjectContentsBrowser.Class96).resKey_0.TypeId != 779470693U)
				{
					if ((this.listView1.SelectedItems[0] as ProjectContentsBrowser.Class96).resKey_0.TypeId != 779470694U)
					{
						goto IL_183;
					}
				}
				try
				{
					PNG png = Class76.smethod_26((this.listView1.SelectedItems[0] as ProjectContentsBrowser.Class96).resKey_0) as PNG;
					this.ddsPreviewImage.Image = png.Image;
					return;
				}
				catch (Exception ex2)
				{
					MessageBox.Show("Error when loading preview.\n\n" + ex2.Message);
					return;
				}
			}
			IL_183:
			this.ddsPreviewImage.Image = null;
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x00081D4C File Offset: 0x0007FF4C
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

		// Token: 0x06000960 RID: 2400 RVA: 0x00081DC0 File Offset: 0x0007FFC0
		private void ctxExport_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count == 1)
			{
				using (IEnumerator enumerator = this.listView1.SelectedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						ProjectContentsBrowser.Class96 @class = (ProjectContentsBrowser.Class96)obj;
						DBPFEntry dbpfentry = Class76.smethod_26(@class.resKey_0);
						Class132.mainForm.ExportFile(dbpfentry.TypeID, dbpfentry);
					}
					return;
				}
			}
			MessageBox.Show("Select one item to export at a time, and one item only.");
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00081E58 File Offset: 0x00080058
		private void ctxImport_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count == 1)
			{
				using (IEnumerator enumerator = this.listView1.SelectedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						ProjectContentsBrowser.Class96 @class = (ProjectContentsBrowser.Class96)obj;
						DBPFEntry dbpfentry = Class76.smethod_26(@class.resKey_0);
						DBPFEntry dbpfentry2 = dbpfentry.Clone() as DBPFEntry;
						if (Class132.mainForm.ImportFile(dbpfentry.TypeID, dbpfentry2) == PluginResult.OK)
						{
							Class132.mainForm.CurrentProject.Package.RemoveEntry(dbpfentry);
							Class132.mainForm.CurrentProject.Package.AddEntry(dbpfentry2);
						}
					}
					return;
				}
			}
			MessageBox.Show("Select one item to import at a time, and one item only.");
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x00081F30 File Offset: 0x00080130
		private void cpyReskey_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count == 1)
			{
				using (IEnumerator enumerator = this.listView1.SelectedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						ProjectContentsBrowser.Class96 @class = (ProjectContentsBrowser.Class96)obj;
						DBPFEntry dbpfentry = Class76.smethod_26(@class.resKey_0);
						string text = dbpfentry.GenerateResKey();
						Clipboard.SetText(text);
					}
					return;
				}
			}
			MessageBox.Show("Select one item to import at a time, and one item only.");
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x00081FC4 File Offset: 0x000801C4
		private void renumberToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count >= 1)
			{
				RenumberDialog renumberDialog = new RenumberDialog();
				if (renumberDialog.ShowDialog(this) == DialogResult.OK)
				{
					if (Class132.mainForm.GetCurrentProjectModel().GetCurrentProject().HasChanges)
					{
						DialogResult dialogResult = MessageBox.Show(this, "The project have unsaved changes, renumbering requires the project to be reloaded. Do you want to save the project before proceeding?", "Renumber", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
						if (dialogResult == DialogResult.Cancel)
						{
							return;
						}
						if (dialogResult == DialogResult.Yes)
						{
							Class132.mainForm.SaveCurrentProject();
						}
					}
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					foreach (object obj in this.listView1.SelectedItems)
					{
						ProjectContentsBrowser.Class96 @class = (ProjectContentsBrowser.Class96)obj;
						ResKey resKey_ = @class.resKey_0;
						ResKey resKey = new ResKey(resKey_.TypeId, renumberDialog.method_1(resKey_.GroupId), renumberDialog.method_2(resKey_.InstanceId), renumberDialog.method_3(resKey_.SecondInstanceId));
						if (dictionary.ContainsKey(resKey.AsString()))
						{
							MessageBox.Show(this, "Error, this will result in duplicate entries. Aborting!", "Duplicate entries", MessageBoxButtons.OK);
							goto IL_344;
						}
						dictionary.Add(resKey.AsString(), resKey_.AsString());
					}
					foreach (object obj2 in this.listView1.Items)
					{
						ProjectContentsBrowser.Class96 class2 = (ProjectContentsBrowser.Class96)obj2;
						ResKey resKey_2 = class2.resKey_0;
						if (!dictionary.ContainsValue(resKey_2.AsString()))
						{
							if (dictionary.ContainsKey(resKey_2.AsString()))
							{
								MessageBox.Show(this, "Error, this will result in duplicate entries. Aborting!", "Duplicate entries", MessageBoxButtons.OK);
								goto IL_344;
							}
							dictionary.Add(resKey_2.AsString(), resKey_2.AsString());
						}
					}
					foreach (object obj3 in this.listView1.SelectedItems)
					{
						ProjectContentsBrowser.Class96 class3 = (ProjectContentsBrowser.Class96)obj3;
						ResKey resKey_3 = class3.resKey_0;
						ResKey resKey2 = new ResKey(resKey_3.TypeId, renumberDialog.method_1(resKey_3.GroupId), renumberDialog.method_2(resKey_3.InstanceId), renumberDialog.method_3(resKey_3.SecondInstanceId));
						this.dbpf.GetEntry(resKey_3);
						this.dbpf.ChangeEntryResKey(resKey_3, resKey2, renumberDialog.update.Checked);
						class3.resKey_0 = resKey2;
						class3.SubItems[0].Text = ((DBPFType)resKey2.TypeId).ToString();
						class3.SubItems[1].Text = "0x" + resKey2.GroupId.ToString("X8");
						class3.SubItems[2].Text = "0x" + resKey2.InstanceId.ToString("X8");
						class3.SubItems[3].Text = "0x" + resKey2.SecondInstanceId.ToString("X8");
					}
					Class132.mainForm.ReloadProject();
				}
				this.listView1.Focus();
				IL_344:;
			}
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x00082364 File Offset: 0x00080564
		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			this.editToolStripMenuItem.Enabled = (this.cpyReskey.Enabled = (this.ctxImport.Enabled = (this.ctxExport.Enabled = (this.listView1.SelectedItems.Count == 1))));
			this.renumberToolStripMenuItem.Enabled = (this.removeToolStripMenuItem.Enabled = (this.listView1.SelectedItems.Count > 0));
			this.editToolStripMenuItem.DropDownItems.Clear();
			if (this.ctxImport.Enabled)
			{
				List<IFileImportPlugin> fileImportPluginsForType = Class132.mainForm.GetFileImportPluginsForType(((ProjectContentsBrowser.Class96)this.listView1.SelectedItems[0]).resKey_0.Type);
				this.ctxImport.Enabled = (fileImportPluginsForType.Count > 0);
			}
			if (this.ctxExport.Enabled)
			{
				List<IFileExportPlugin> fileExportPluginsForType = Class132.mainForm.GetFileExportPluginsForType(((ProjectContentsBrowser.Class96)this.listView1.SelectedItems[0]).resKey_0.Type);
				this.ctxExport.Enabled = (fileExportPluginsForType.Count > 0);
			}
			if (this.editToolStripMenuItem.Enabled)
			{
				List<IDBPFEntryEditor> editorPluginsForType = Class132.mainForm.GetEditorPluginsForType(((ProjectContentsBrowser.Class96)this.listView1.SelectedItems[0]).resKey_0.Type);
				if (editorPluginsForType.Count == 0)
				{
					this.editToolStripMenuItem.Enabled = false;
				}
				else
				{
					this.editToolStripMenuItem.Enabled = true;
					foreach (IDBPFEntryEditor idbpfentryEditor in editorPluginsForType)
					{
						WorkshopExtension workshopExtension = (WorkshopExtension)idbpfentryEditor;
						ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
						toolStripMenuItem.Text = workshopExtension.Name;
						toolStripMenuItem.Click += this.method_2;
						toolStripMenuItem.Tag = workshopExtension;
						this.editToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
					}
				}
			}
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x0008257C File Offset: 0x0008077C
		private void method_2(object sender, EventArgs e)
		{
			IDBPFEntryEditor idbpfentryEditor = (IDBPFEntryEditor)((ToolStripMenuItem)sender).Tag;
			DBPFEntry dbpfentry = Class76.smethod_26(((ProjectContentsBrowser.Class96)this.listView1.SelectedItems[0]).resKey_0);
			DBPFEntry dbpfentry2 = dbpfentry.Clone() as DBPFEntry;
			if (idbpfentryEditor.OpenEditor(dbpfentry2) == PluginResult.OK)
			{
				Class132.mainForm.CurrentProject.Package.RemoveEntry(dbpfentry);
				Class132.mainForm.CurrentProject.Package.AddEntry(dbpfentry2);
			}
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x000062E8 File Offset: 0x000044E8
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0400077C RID: 1916
		private Class97 class97_0 = new Class97();

		// Token: 0x0400077D RID: 1917
		private DBPF dbpf;

		// Token: 0x0400077E RID: 1918
		private ProjectContentsBrowser.Delegate28 delegate28_0;

		// Token: 0x0400079C RID: 1948
		[CompilerGenerated]
		private List<DBPFType> list_0;

		// Token: 0x0400079D RID: 1949
		[CompilerGenerated]
		private List<ResKey> list_1;

		// Token: 0x020000E4 RID: 228
		private sealed class Class96 : ListViewItem
		{
			// Token: 0x0400079E RID: 1950
			public ResKey resKey_0;
		}

		// Token: 0x020000E5 RID: 229
		// (Invoke) Token: 0x0600096A RID: 2410
		public delegate void Delegate28();
	}
}
