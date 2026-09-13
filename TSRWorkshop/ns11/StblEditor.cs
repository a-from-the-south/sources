using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Package;
using Package.Sims3Files;
using Sims3Workshop.Data;
using Sims3WorkshopSDK;

namespace ns11
{
	// Token: 0x02000010 RID: 16
	internal sealed partial class StblEditor : Form
	{
		// Token: 0x06000054 RID: 84 RVA: 0x0001299C File Offset: 0x00010B9C
		public StblEditor(DBPF package, ulong guid, string text, int instanceId)
		{
			this.InitializeComponent();
			this.package = package;
			this.instanceId = instanceId;
			this.guid = guid;
			this.textStr.Text = text;
			this.text = text;
			string[] localizedStrings = STBL.GetLocalizedStrings(package, guid, this.instanceId);
			for (int i = 0; i < 23; i++)
			{
				int num = this.strings.Rows.Add();
				this.strings.Rows[num].Tag = num;
				this.strings.Rows[num].Cells[0].Value = STBL.Locales[i];
				this.strings.Rows[num].Cells[1].Value = (localizedStrings[num] ?? text);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00012A8C File Offset: 0x00010C8C
		public StblEditor(WorkshopProject project, string key, string text)
		{
			this.InitializeComponent();
			this.bool_0 = false;
			this.key = key;
			this.project = project;
			this.textStr.Text = text;
			this.text = text;
			string[] array = new string[23];
			STBL.Locales.Keys.CopyTo(array, 0);
			if (!project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaObjects.ContainsKey("localizedStrings"))
			{
				project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaObjects["localizedStrings"] = new Dictionary<string, Dictionary<string, string>>();
			}
			Dictionary<string, Dictionary<string, string>> dictionary = (Dictionary<string, Dictionary<string, string>>)project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaObjects["localizedStrings"];
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = new Dictionary<string, string>();
			}
			for (int i = 0; i < 23; i++)
			{
				int num = this.strings.Rows.Add();
				this.strings.Rows[num].Tag = num;
				this.strings.Rows[num].Cells[0].Value = STBL.Locales[i];
				if (!dictionary[key].ContainsKey(array[num]))
				{
					dictionary[key][array[num]] = text;
				}
				this.strings.Rows[num].Cells[1].Value = dictionary[key][array[num]];
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00012C00 File Offset: 0x00010E00
		private void btnSave_Click(object sender, EventArgs e)
		{
			this.text = this.textStr.Text;
			if (this.bool_0)
			{
				for (byte b = 0; b < 23; b += 1)
				{
					if (this.strings.Rows[(int)b].Cells[1].Value != null)
					{
						int num = (int)b << 24;
						List<ResKey> list = this.package.SearchEntries(new ResKey(DBPFType.STBL, 0, num, this.instanceId));
						STBL stbl;
						if (list.Count > 0)
						{
							stbl = (STBL)this.package.GetEntry(list[0]);
						}
						else
						{
							stbl = new STBL
							{
								ResKey = new ResKey(DBPFType.STBL, 0, num, this.instanceId)
							};
							this.package.AddEntry(stbl);
						}
						stbl.SetEntry(this.guid, string.Concat(this.strings.Rows[(int)b].Cells[1].Value ?? this.text));
					}
				}
			}
			else
			{
				Dictionary<string, Dictionary<string, string>> dictionary = (Dictionary<string, Dictionary<string, string>>)this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaObjects["localizedStrings"];
				string[] array = new string[23];
				STBL.Locales.Keys.CopyTo(array, 0);
				for (int i = 0; i < 23; i++)
				{
					if (this.strings.Rows[i].Cells[1].Value != null)
					{
						string value = (string)this.strings.Rows[i].Cells[1].Value;
						dictionary[this.key][array[i]] = value;
					}
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00012DD8 File Offset: 0x00010FD8
		private void copy_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 23; i++)
			{
				this.strings.Rows[i].Cells[1].Value = this.textStr.Text;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002BCC File Offset: 0x00000DCC
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040000AF RID: 175
		public string text;

		// Token: 0x040000B0 RID: 176
		private readonly DBPF package;

		// Token: 0x040000B1 RID: 177
		private readonly int instanceId;

		// Token: 0x040000B2 RID: 178
		private readonly ulong guid;

		// Token: 0x040000B3 RID: 179
		private readonly WorkshopProject project;

		// Token: 0x040000B4 RID: 180
		private readonly string key;

		// Token: 0x040000B5 RID: 181
		private readonly bool bool_0 = true;

		// Token: 0x040000B6 RID: 182
		private IContainer icontainer_0;
	}
}
