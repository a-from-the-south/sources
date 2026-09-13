using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ns15;
using ns16;
using ns8;
using Package;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using SlimDX.Direct3D9;

namespace ns19
{
	// Token: 0x020000DE RID: 222
	internal sealed partial class PatternBrowseDialog : Form
	{
		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000924 RID: 2340 RVA: 0x0007EF7C File Offset: 0x0007D17C
		// (set) Token: 0x06000925 RID: 2341 RVA: 0x00006224 File Offset: 0x00004424
		public PatternResKey SelectedPattern { get; set; }

		// Token: 0x06000926 RID: 2342 RVA: 0x0007EF94 File Offset: 0x0007D194
		public PatternBrowseDialog(PatternResKey currentPattern)
		{
			this.currentPattern = currentPattern;
			this.InitializeComponent();
			if (!File.Exists(this.string_1))
			{
				Application.ProductVersion.Split(new char[]
				{
					'.'
				});
			}
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0007EFFC File Offset: 0x0007D1FC
		public void method_0()
		{
			this.category.Items.Clear();
			this.method_2();
			this.method_3();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.ProgressChanged += this.backgroundWorker_0_ProgressChanged;
			this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.category.SelectedIndex = 0;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0007F09C File Offset: 0x0007D29C
		private void category_SelectedIndexChanged(object sender, EventArgs e)
		{
			lock (this.patternListView)
			{
				this.doneBtn.Enabled = false;
				this.string_0 = this.category.SelectedItem.ToString();
				this.patternListView.Clear();
				this.imageList_0.Images.Clear();
				this.progress.Visible = true;
				this.progress.Value = 0;
				this.progress.Maximum = this.dictionary_0[this.string_0].Count + 1;
				if (!this.backgroundWorker_0.IsBusy)
				{
					this.backgroundWorker_0.RunWorkerAsync();
				}
			}
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0000622F File Offset: 0x0000442F
		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.progress.Value = e.ProgressPercentage;
			this.statusLabel.Text = e.UserState.ToString();
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0007F164 File Offset: 0x0007D364
		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.progress.Visible = false;
			this.statusLabel.Text = "Done";
			if (this.bool_0)
			{
				this.bool_0 = false;
				Preset preset = Class76.smethod_26(this.currentPattern) as Preset;
				string attribute = (preset.Documents[0].SelectSingleNode("/complate") as XmlElement).GetAttribute("category");
				if (this.dictionary_0["_In Project_"].Contains(preset.GenerateResKey()))
				{
					this.category.SelectedIndex = 0;
				}
				else
				{
					int num = 0;
					foreach (object obj in this.category.Items)
					{
						if (obj.Equals(attribute))
						{
							this.category.SelectedIndex = num;
							break;
						}
						num++;
					}
				}
			}
		}

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x0600092B RID: 2347 RVA: 0x0007F270 File Offset: 0x0007D470
		// (remove) Token: 0x0600092C RID: 2348 RVA: 0x0007F2A8 File Offset: 0x0007D4A8
		private event PatternBrowseDialog.Delegate26 WorkDone
		{
			add
			{
				PatternBrowseDialog.Delegate26 @delegate = this.delegate26_0;
				PatternBrowseDialog.Delegate26 delegate2;
				do
				{
					delegate2 = @delegate;
					PatternBrowseDialog.Delegate26 value2 = (PatternBrowseDialog.Delegate26)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<PatternBrowseDialog.Delegate26>(ref this.delegate26_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				PatternBrowseDialog.Delegate26 @delegate = this.delegate26_0;
				PatternBrowseDialog.Delegate26 delegate2;
				do
				{
					delegate2 = @delegate;
					PatternBrowseDialog.Delegate26 value2 = (PatternBrowseDialog.Delegate26)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<PatternBrowseDialog.Delegate26>(ref this.delegate26_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0007F2E0 File Offset: 0x0007D4E0
		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			List<string> list = this.dictionary_0[this.string_0];
			string a = this.string_0;
			Texture texture = Class132.smethod_0().method_4(this.imageList_0.ImageSize);
			Class27 @class = new Class27(this.imageList_0.ImageSize);
			for (int i = 0; i < list.Count; i++)
			{
				if (backgroundWorker.CancellationPending)
				{
					e.Cancel = true;
					IL_21F:
					texture.Dispose();
					@class.imethod_2(true);
					e.Result = true;
					if (this.delegate26_0 != null)
					{
						this.delegate26_0();
					}
					return;
				}
				Preset preset;
				if (ResKey.IsValid(list[i]))
				{
					preset = (Preset)Class76.smethod_26(new ResKey(list[i]));
				}
				else
				{
					preset = (Preset)Class76.smethod_3(list[i], DBPFType.PRESET);
				}
				XmlNode namedItem = preset.Documents[0].FirstChild.Attributes.GetNamedItem("name");
				ListViewItem listViewItem_ = new ListViewItem((namedItem != null) ? namedItem.InnerText : "no name")
				{
					Tag = preset
				};
				ResKey resKey = new ResKey(DBPFType.PNG, preset.GroupID, preset.InstanceID, preset.SecondInstanceID);
				PNG png = new PNG();
				png.GroupID = resKey.GroupId;
				png.InstanceID = resKey.InstanceId;
				png.SecondInstanceID = resKey.SecondInstanceId;
				Bitmap image = null;
				Class132.smethod_0().method_9(ref image, @class, texture, preset.GenerateResKey(), this.imageList_0.ImageSize, null, null, "DiffuseMap", "($partType)");
				png.Image = image;
				if (a == this.string_0)
				{
					this.method_1(listViewItem_, png.Image);
					this.backgroundWorker_0.ReportProgress(i, string.Concat(new object[]
					{
						"Rendering preview ",
						i + 1,
						" of ",
						list.Count,
						"..."
					}));
				}
				else
				{
					i = 0;
					list = this.dictionary_0[this.string_0];
					a = this.string_0;
				}
			}
			goto IL_21F;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0007F53C File Offset: 0x0007D73C
		private void method_1(ListViewItem listViewItem_0, Image image_0)
		{
			if (base.InvokeRequired)
			{
				PatternBrowseDialog.Delegate27 method = new PatternBrowseDialog.Delegate27(this.method_1);
				base.Invoke(method, new object[]
				{
					listViewItem_0,
					image_0
				});
			}
			else
			{
				this.imageList_0.Images.Add(image_0);
				listViewItem_0.ImageIndex = this.imageList_0.Images.Count - 1;
				this.patternListView.Items.Add(listViewItem_0);
			}
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x0007F5B8 File Offset: 0x0007D7B8
		private void method_2()
		{
			this.dictionary_0 = new Dictionary<string, List<string>>
			{
				{
					"_In Project_",
					new List<string>()
				}
			};
			List<ResKey> list = Class132.mainForm.CurrentProject.Package.SearchEntries(new ResKey(DBPFType.PRESET));
			foreach (ResKey resKey in list)
			{
				Preset preset = (Preset)Class132.mainForm.CurrentProject.Package.GetEntry(resKey);
				if (preset.Documents.Count > 0)
				{
					XmlElement xmlElement = preset.Documents[0].SelectSingleNode("/complate") as XmlElement;
					if (xmlElement == null || !xmlElement.GetAttribute("type").ToLower().Equals("fabric"))
					{
						continue;
					}
				}
				this.dictionary_0["_In Project_"].Add(resKey.AsString());
			}
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x0007F6C8 File Offset: 0x0007D8C8
		private void method_3()
		{
			List<DBPFEntry> list = Class76.smethod_24(new ResKey((DBPFType)3571055589U));
			foreach (DBPFEntry dbpfentry in list)
			{
				foreach (XmlDocument xmlDocument in (dbpfentry as PatternList).Documents)
				{
					XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/patternlist/category");
					if (xmlNodeList != null)
					{
						for (int i = 0; i < xmlNodeList.Count; i++)
						{
							XmlNode xmlNode = xmlNodeList.Item(i);
							string innerText = xmlNode.Attributes.GetNamedItem("name").InnerText;
							for (int j = 0; j < xmlNode.ChildNodes.Count; j++)
							{
								XmlNode xmlNode2 = xmlNode.ChildNodes[j];
								string innerText2 = xmlNode2.Attributes.GetNamedItem("name").InnerText;
								if (!this.dictionary_0.ContainsKey(innerText))
								{
									this.dictionary_0.Add(innerText, new List<string>());
								}
								this.dictionary_0[innerText].Add(innerText2);
							}
						}
					}
				}
			}
			string[] array = new string[this.dictionary_0.Keys.Count];
			this.dictionary_0.Keys.CopyTo(array, 0);
			Array.Sort<string>(array);
			this.category.Items.AddRange(array);
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0007F894 File Offset: 0x0007DA94
		private void patternListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.patternListView.SelectedItems.Count != 1)
			{
				this.SelectedPattern = null;
				this.doneBtn.Enabled = false;
			}
			else
			{
				this.doneBtn.Enabled = true;
				Preset preset = (Preset)this.patternListView.SelectedItems[0].Tag;
				this.SelectedPattern = new PatternResKey(preset.GenerateResKey());
			}
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0007F904 File Offset: 0x0007DB04
		private void doneBtn_Click(object sender, EventArgs e)
		{
			if (this.backgroundWorker_0 != null && this.backgroundWorker_0.IsBusy)
			{
				if (this.delegate26_0 == null)
				{
					this.WorkDone += this.method_4;
				}
				this.backgroundWorker_0.CancelAsync();
			}
			else
			{
				this.method_4();
			}
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0007F958 File Offset: 0x0007DB58
		private void method_4()
		{
			if (base.InvokeRequired)
			{
				PatternBrowseDialog.Delegate26 method = new PatternBrowseDialog.Delegate26(this.method_4);
				base.Invoke(method, new object[0]);
			}
			else if (this.SelectedPattern == null && !this.bool_1)
			{
				MessageBox.Show("No pattern is selected");
			}
			else
			{
				base.DialogResult = (this.bool_1 ? DialogResult.Cancel : DialogResult.OK);
				base.Close();
			}
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0007F9C4 File Offset: 0x0007DBC4
		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.bool_1 = true;
			if (this.backgroundWorker_0 != null && this.backgroundWorker_0.IsBusy)
			{
				if (this.delegate26_0 == null)
				{
					this.WorkDone += this.method_4;
				}
				this.backgroundWorker_0.CancelAsync();
			}
			else
			{
				this.method_4();
			}
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00002A71 File Offset: 0x00000C71
		private void PatternBrowseDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0000625A File Offset: 0x0000445A
		private void PatternBrowseDialog_Shown(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00006264 File Offset: 0x00004464
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0400074C RID: 1868
		private Dictionary<string, List<string>> dictionary_0;

		// Token: 0x0400074D RID: 1869
		private BackgroundWorker backgroundWorker_0;

		// Token: 0x0400074E RID: 1870
		private string string_0;

		// Token: 0x0400074F RID: 1871
		private readonly string string_1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TSRWorkshop\\patternthumbs.package";

		// Token: 0x04000750 RID: 1872
		private PatternResKey currentPattern;

		// Token: 0x04000751 RID: 1873
		private bool bool_0 = true;

		// Token: 0x04000752 RID: 1874
		private PatternBrowseDialog.Delegate26 delegate26_0;

		// Token: 0x04000753 RID: 1875
		private bool bool_1;

		// Token: 0x04000760 RID: 1888
		[CompilerGenerated]
		private PatternResKey patternResKey_0;

		// Token: 0x020000DF RID: 223
		// (Invoke) Token: 0x0600093A RID: 2362
		private delegate void Delegate26();

		// Token: 0x020000E0 RID: 224
		// (Invoke) Token: 0x0600093E RID: 2366
		private delegate void Delegate27(ListViewItem item, Image img);
	}
}
