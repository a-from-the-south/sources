using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Sims3Workshop.Preferences;

namespace ns10
{
	// Token: 0x02000133 RID: 307
	internal sealed class PluginList : UserControl, Interface11
	{
		// Token: 0x06000E46 RID: 3654 RVA: 0x000B3BFC File Offset: 0x000B1DFC
		public PluginList()
		{
			this.InitializeComponent();
			PluginDirectory pluginDirectory = PluginList.smethod_0();
			foreach (PluginDirectoryEntry pluginDirectoryEntry in pluginDirectory.entries)
			{
				if (pluginDirectoryEntry.bool_0)
				{
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.Text = "";
					listViewItem.Checked = pluginDirectoryEntry.enabled;
					listViewItem.SubItems.Add(pluginDirectoryEntry.name);
					listViewItem.SubItems.Add(pluginDirectoryEntry.version);
					this.listView1.Columns[0].Width = -2;
					this.listView1.Columns[1].Width = -2;
					this.listView1.Columns[2].Width = -2;
					this.listView1.Items.Add(listViewItem);
				}
			}
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x000B3D0C File Offset: 0x000B1F0C
		public static PluginDirectory smethod_0()
		{
			PluginDirectory result;
			if (PluginList.pluginDirectory_0 != null)
			{
				result = PluginList.pluginDirectory_0;
			}
			else
			{
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TSR Workshop");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				if (File.Exists(text + "\\plugins.dat"))
				{
					Stream stream = File.Open(text + "\\plugins.dat", FileMode.Open);
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					try
					{
						PluginList.pluginDirectory_0 = (binaryFormatter.Deserialize(stream) as PluginDirectory);
						stream.Close();
						goto IL_EC;
					}
					catch (Exception)
					{
						stream.Close();
						MessageBox.Show("Could not deserialize plugin list. Deleting it.");
						File.Delete(text + "\\plugins.dat");
						if (File.Exists(text + "\\plugins.dat"))
						{
							MessageBox.Show("Could not delete the file.");
						}
						PluginList.pluginDirectory_0 = new PluginDirectory();
						PluginList.pluginDirectory_0.entries = new List<PluginDirectoryEntry>();
						goto IL_EC;
					}
				}
				PluginList.pluginDirectory_0 = new PluginDirectory();
				PluginList.pluginDirectory_0.entries = new List<PluginDirectoryEntry>();
				IL_EC:
				result = PluginList.pluginDirectory_0;
			}
			return result;
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x000B3E20 File Offset: 0x000B2020
		public static void smethod_1()
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TSR Workshop");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			Stream stream = File.Open(text + "\\plugins.dat", FileMode.Create);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(stream, PluginList.pluginDirectory_0);
			stream.Close();
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x000B3E7C File Offset: 0x000B207C
		void Interface11.imethod_0()
		{
			PluginDirectory pluginDirectory = PluginList.smethod_0();
			foreach (object obj in this.listView1.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				PluginDirectoryEntry pluginDirectoryEntry = pluginDirectory.method_2(listViewItem.SubItems[1].Text);
				pluginDirectoryEntry.enabled = listViewItem.Checked;
			}
			PluginList.smethod_1();
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000E4A RID: 3658 RVA: 0x000B3F08 File Offset: 0x000B2108
		string Interface11.Name
		{
			get
			{
				return "Plugins";
			}
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x00002A71 File Offset: 0x00000C71
		public void imethod_1()
		{
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x00007BCC File Offset: 0x00005DCC
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x000B3F20 File Offset: 0x000B2120
		private void InitializeComponent()
		{
			this.listView1 = new ListView();
			this.columnHeader_2 = new ColumnHeader();
			this.columnHeader_0 = new ColumnHeader();
			this.columnHeader_1 = new ColumnHeader();
			base.SuspendLayout();
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new ColumnHeader[]
			{
				this.columnHeader_2,
				this.columnHeader_0,
				this.columnHeader_1
			});
			this.listView1.Dock = DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new Size(500, 259);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = View.Details;
			this.columnHeader_2.Text = "Enabled";
			this.columnHeader_0.Text = "Plugin name";
			this.columnHeader_0.Width = 73;
			this.columnHeader_1.Text = "Version";
			this.columnHeader_1.Width = 100;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.listView1);
			base.Name = "PluginList";
			base.Size = new Size(500, 259);
			base.ResumeLayout(false);
		}

		// Token: 0x04000AFD RID: 2813
		private static PluginDirectory pluginDirectory_0;

		// Token: 0x04000AFE RID: 2814
		private IContainer icontainer_0;

		// Token: 0x04000AFF RID: 2815
		private ListView listView1;

		// Token: 0x04000B00 RID: 2816
		private ColumnHeader columnHeader_0;

		// Token: 0x04000B01 RID: 2817
		private ColumnHeader columnHeader_1;

		// Token: 0x04000B02 RID: 2818
		private ColumnHeader columnHeader_2;
	}
}
