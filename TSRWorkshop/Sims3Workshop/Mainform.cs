using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ns1;
using ns10;
using ns11;
using ns12;
using ns14;
using ns15;
using ns16;
using ns17;
using ns18;
using ns2;
using ns20;
using ns21;
using ns3;
using ns6;
using ns7;
using ns8;
using Package;
using Package.Sims3Files;
using Sims3Workshop.Control;
using Sims3Workshop.Data;
using Sims3Workshop.Dialogs;
using Sims3Workshop.Preferences;
using Sims3Workshop.Properties;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using Skybound.VisualTips;
using SplitButtonDemo;

namespace Sims3Workshop
{
	// Token: 0x02000128 RID: 296
	public sealed partial class Mainform : Form, IWorkshop
	{
		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000D78 RID: 3448 RVA: 0x000A9060 File Offset: 0x000A7260
		public Panel ProjectPanel
		{
			get
			{
				return this.mainSplitContainer.Panel2;
			}
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x000A907C File Offset: 0x000A727C
		public Mainform()
		{
			this.splashScreen = new Splash();
			this.splashScreen.Show();
			this.splashScreen.Refresh();
			this.InitializeComponent();
			base.KeyPreview = true;
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x000A9124 File Offset: 0x000A7324
		public int SetupDevice()
		{
			MeshEditor meshEditor = Class132.smethod_0();
			int num = meshEditor.method_21();
			int result;
			if (num < 0)
			{
				result = num;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x00007792 File Offset: 0x00005992
		public void Render(bool ignoreSuspend)
		{
			if (this.suspend && !ignoreSuspend)
			{
				Thread.Sleep(10);
			}
			else
			{
				this.Render();
			}
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x000A914C File Offset: 0x000A734C
		public void Render()
		{
			MeshEditor meshEditor = Class132.smethod_0();
			meshEditor.method_35();
			Thread.Sleep(10);
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x000A9170 File Offset: 0x000A7370
		public void RefreshView()
		{
			foreach (Class102 class102_ in Class132.smethod_0().Renderables)
			{
				Class132.smethod_0().method_3(class102_);
			}
			this.Render();
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x000077B0 File Offset: 0x000059B0
		public void SetStatus(string text)
		{
			this.status.Text = text;
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x000A91D4 File Offset: 0x000A73D4
		public void UpdateRecent(WorkshopProject project)
		{
			int num = 0;
			for (int i = 1; i < 11; i++)
			{
				string a = Settings.Default["Recent" + i] as string;
				if (a != "" && a == project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Filename)
				{
					num = i;
				}
			}
			if (num != 0)
			{
				object value = Settings.Default["Recent1"];
				Settings.Default["Recent1"] = project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Filename;
				int num2 = 2;
				while (num2 <= num && num2 < 10)
				{
					object obj = Settings.Default["Recent" + num2];
					Settings.Default["Recent" + num2] = value;
					value = obj;
					num2++;
				}
			}
			else
			{
				for (int j = 10; j > 1; j--)
				{
					Settings.Default["Recent" + j] = Settings.Default["Recent" + (j - 1)];
				}
				Settings.Default["Recent1"] = project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Filename;
				Settings.Default.Save();
			}
			this.loadRecent();
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x000A931C File Offset: 0x000A751C
		private void loadRecent()
		{
			this.recentMenuItems.DropDownItems.Clear();
			for (int i = 1; i < 11; i++)
			{
				string text = Settings.Default["Recent" + i] as string;
				if (text != "")
				{
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
					string text2 = Path.GetFullPath(text);
					string fileName = Path.GetFileName(text);
					if (text2.Length > 15)
					{
						text2 = text2.Substring(0, 15) + "...";
					}
					toolStripMenuItem.Text = text2 + "\\" + fileName;
					toolStripMenuItem.Tag = text;
					toolStripMenuItem.Click += this.mi_Click;
					this.recentMenuItems.DropDownItems.Add(toolStripMenuItem);
				}
			}
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x000A93EC File Offset: 0x000A75EC
		private void mi_Click(object sender, EventArgs e)
		{
			WorkshopProject project = WorkshopProject.smethod_1((sender as ToolStripMenuItem).Tag as string);
			this.OpenProject(project);
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x000A9418 File Offset: 0x000A7618
		private void Mainform_Load(object sender, EventArgs e)
		{
			this.button1.Visible = true;
			Class132.smethod_0().Dock = DockStyle.Fill;
			Class132.smethod_0().Parent = this.mainSplitContainer.Panel1;
			ToolStripMenuItem toolStripMenuItem = this.propertiesToolStripMenuItem;
			this.channelEditorToolStripMenuItem.Checked = true;
			toolStripMenuItem.Checked = true;
			this.mainSplitContainer.Panel2MinSize = 364;
			this.loadGameData();
			this.loadRecent();
			this.loadPlugins();
			this.splashScreen.Close();
			if (Settings.Default.ismaximized == 1)
			{
				base.WindowState = FormWindowState.Maximized;
			}
			else
			{
				base.Width = Settings.Default.width;
				base.Height = Settings.Default.height;
			}
			bool flag = true;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				string text = commandLineArgs[i];
				if (text.ToLower() == "/i")
				{
					string defaultFile = commandLineArgs[i + 2];
					foreach (IImportPlugin importPlugin in this._importPlugins)
					{
						if ((importPlugin as IWorkshopExtension).Name == "Sims 3 Object Importer")
						{
							importPlugin.SetDefaultFile(defaultFile);
							importPlugin.Import();
						}
					}
				}
				if (text.ToLower().Contains(".wrk"))
				{
					flag = false;
					this._projectToOpen = text;
				}
			}
			if (flag)
			{
				this.ShowWelcomeScreen(true);
				this.SetStatus("No project loaded");
			}
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x000077C0 File Offset: 0x000059C0
		private void t_Tick(object sender, EventArgs e)
		{
			this.fpsLabel.Text = Class132.smethod_0().Fps + " fps";
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x00002A71 File Offset: 0x00000C71
		private void Mainform_WelcomeDone()
		{
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x000A95A4 File Offset: 0x000A77A4
		private void loadGameData()
		{
			this.splashScreen.method_0("Loading packages: 0%");
			this.splashScreen.Refresh();
			this.numGameFiles = Class76.smethod_15();
			Class76.Delegate18 value = new Class76.Delegate18(this.GameDataUtil_Progress);
			Class76.Progress += value;
			Class76.smethod_19(new ResKey(4243240539U));
			Class76.Progress -= value;
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x000A9604 File Offset: 0x000A7804
		private void GameDataUtil_Progress(int percent, int filecount)
		{
			this.totFileCount += filecount;
			this.splashScreen.method_0("Loading packages: " + Math.Round((double)((float)this.totFileCount / (float)this.numGameFiles * 100f)) + "%");
			this.splashScreen.Refresh();
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06000D87 RID: 3463 RVA: 0x000A9668 File Offset: 0x000A7868
		public List<IImportPlugin> ImportPlugins
		{
			get
			{
				return this._importPlugins;
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06000D88 RID: 3464 RVA: 0x000A9680 File Offset: 0x000A7880
		public List<IExportPlugin> ExportPlugins
		{
			get
			{
				return this._exportPlugins;
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06000D89 RID: 3465 RVA: 0x000A9698 File Offset: 0x000A7898
		public List<IToolPlugin> ToolPlugins
		{
			get
			{
				return this._toolPlugins;
			}
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x000A96B0 File Offset: 0x000A78B0
		private void loadPlugins()
		{
			if (Directory.Exists(Application.StartupPath + "\\\\plugins\\\\"))
			{
				string[] fileSystemEntries = Directory.GetFileSystemEntries(Application.StartupPath + "\\\\plugins\\\\", "*.dll");
				PluginDirectory pluginDirectory = PluginList.smethod_0();
				foreach (string path in fileSystemEntries)
				{
					try
					{
						string fileName = Path.GetFileName(path);
						Assembly assembly = Assembly.LoadFile(path);
						Type[] types = assembly.GetTypes();
						foreach (Type type in types)
						{
							if (typeof(IWorkshopExtension).IsAssignableFrom(type))
							{
								WorkshopExtension workshopExtension = assembly.CreateInstance(type.FullName) as WorkshopExtension;
								this.splashScreen.method_0("Loading plugin: " + workshopExtension.Name);
								this.splashScreen.Refresh();
								Thread.Sleep(50);
								PluginDirectoryEntry pluginDirectoryEntry = pluginDirectory.method_2(workshopExtension.Name);
								if (pluginDirectoryEntry == null)
								{
									pluginDirectoryEntry = pluginDirectory.method_1(workshopExtension.Name);
									pluginDirectoryEntry.enabled = true;
									pluginDirectoryEntry.version = workshopExtension.PluginVersion;
								}
								else
								{
									pluginDirectoryEntry.version = workshopExtension.PluginVersion;
									pluginDirectoryEntry.bool_0 = true;
								}
								if (pluginDirectoryEntry.enabled)
								{
									if (workshopExtension._init(this) == PluginResult.OK)
									{
										if (workshopExtension.Initialize() != PluginResult.OK)
										{
											MessageBox.Show("Could not initilialize plugin, " + fileName);
										}
										else
										{
											if (typeof(IDBPFEntryEditor).IsAssignableFrom(type))
											{
												this._dbpfEditorPlugins.Add(workshopExtension as IDBPFEntryEditor);
											}
											if (typeof(IFileImportPlugin).IsAssignableFrom(type))
											{
												this._fileImportPlugins.Add(workshopExtension as IFileImportPlugin);
											}
											if (typeof(IFileExportPlugin).IsAssignableFrom(type))
											{
												this._fileExportPlugins.Add(workshopExtension as IFileExportPlugin);
											}
											if (typeof(IImportPlugin).IsAssignableFrom(type))
											{
												if ((workshopExtension as IImportPlugin).Location == ImportLocation.ImportMenu)
												{
													Class141 @class = new Class141(workshopExtension);
													@class.Click += this.importMenuItemClick;
													@class.Text = (workshopExtension as IImportPlugin).MenuItemText;
													this.importMenuItem.DropDownItems.Add(@class);
												}
												this._importPlugins.Add(workshopExtension as IImportPlugin);
											}
											if (typeof(IExportPlugin).IsAssignableFrom(type))
											{
												if ((workshopExtension as IExportPlugin).Location == ExportLocation.ExportMenu)
												{
													Class141 class2 = new Class141(workshopExtension);
													class2.Click += this.importMenuItemClick;
													class2.Text = (workshopExtension as IExportPlugin).MenuItemText;
													this.exportMenuItem.DropDownItems.Add(class2);
												}
												this._exportPlugins.Add(workshopExtension as IExportPlugin);
											}
											if (typeof(IToolPlugin).IsAssignableFrom(type))
											{
												Class141 class3 = new Class141(workshopExtension);
												class3.Click += this.importMenuItemClick;
												class3.Text = (workshopExtension as IToolPlugin).MenuItemText;
												this.toolsMenuItem.DropDownItems.Add(class3);
												class3.Enabled = !(workshopExtension as IToolPlugin).RequiresProject;
												this._toolPlugins.Add(workshopExtension as IToolPlugin);
											}
										}
									}
									else
									{
										MessageBox.Show("Could not _initilialize plugin, " + fileName);
									}
								}
							}
						}
					}
					catch (Exception)
					{
					}
				}
				PluginList.smethod_1();
				this._importPlugins.Sort((IImportPlugin p1, IImportPlugin p2) => (p1 as WorkshopExtension).SortOrder.CompareTo((p2 as WorkshopExtension).SortOrder));
				this._exportPlugins.Sort((IExportPlugin p1, IExportPlugin p2) => (p1 as WorkshopExtension).SortOrder.CompareTo((p2 as WorkshopExtension).SortOrder));
				this._fileExportPlugins.Sort((IFileExportPlugin p1, IFileExportPlugin p2) => (p1 as WorkshopExtension).SortOrder.CompareTo((p2 as WorkshopExtension).SortOrder));
				this._fileImportPlugins.Sort((IFileImportPlugin p1, IFileImportPlugin p2) => (p1 as WorkshopExtension).SortOrder.CompareTo((p2 as WorkshopExtension).SortOrder));
				this._dbpfEditorPlugins.Sort((IDBPFEntryEditor p1, IDBPFEntryEditor p2) => (p1 as WorkshopExtension).SortOrder.CompareTo((p2 as WorkshopExtension).SortOrder));
				this.DisplayJointsButton.Enabled = false;
				foreach (IDBPFEntryEditor idbpfentryEditor in this._dbpfEditorPlugins)
				{
					if (idbpfentryEditor.GetType().FullName.Equals("RIGEditor.RIGEditor"))
					{
						this.DisplayJointsButton.Enabled = true;
						this.RIGEditor = (idbpfentryEditor as IRIGEditor);
					}
				}
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06000D8B RID: 3467 RVA: 0x000A9BA4 File Offset: 0x000A7DA4
		// (set) Token: 0x06000D8C RID: 3468 RVA: 0x000077E8 File Offset: 0x000059E8
		public IRIGEditor RIGEditor { get; set; }

		// Token: 0x06000D8D RID: 3469 RVA: 0x0008163C File Offset: 0x0007F83C
		public void importMenuItemClick(object sender, EventArgs e)
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

		// Token: 0x06000D8E RID: 3470 RVA: 0x000A9BBC File Offset: 0x000A7DBC
		public ToolStripItem AddStatusMessage(string message)
		{
			ToolStripItem result;
			if (base.InvokeRequired)
			{
				Mainform.OnStatusMessage method = new Mainform.OnStatusMessage(this.AddStatusMessage);
				result = (base.Invoke(method, new object[]
				{
					message
				}) as ToolStripItem);
			}
			else
			{
				result = this.statusStrip.Items.Add(message);
			}
			return result;
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x000A9C10 File Offset: 0x000A7E10
		public void RemoveStatusMessage(ToolStripItem stripItem)
		{
			if (base.InvokeRequired)
			{
				Mainform.OnRemoveStatusMessage method = new Mainform.OnRemoveStatusMessage(this.RemoveStatusMessage);
				base.Invoke(method, new object[]
				{
					stripItem
				});
			}
			else
			{
				this.statusStrip.Items.Remove(stripItem);
			}
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x000A9C5C File Offset: 0x000A7E5C
		public void UpdatesAvailable()
		{
			if (base.InvokeRequired)
			{
				Mainform.OnUpdatesAvailable method = new Mainform.OnUpdatesAvailable(this.UpdatesAvailable);
				base.Invoke(method, new object[0]);
			}
			else
			{
				new UpdatesAvailableForm().ShowDialog(Class132.mainForm);
			}
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x000A9CA0 File Offset: 0x000A7EA0
		public void DisableUpdateMenuItem()
		{
			if (base.InvokeRequired)
			{
				Mainform.OnDisableUpdateMenuItem method = new Mainform.OnDisableUpdateMenuItem(this.DisableUpdateMenuItem);
				base.Invoke(method, new object[0]);
			}
			else
			{
				this.checkForUpdatesToolStripMenuItem.Enabled = false;
			}
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x000A9CE0 File Offset: 0x000A7EE0
		public void EnableUpdateMenuItem()
		{
			if (base.InvokeRequired)
			{
				Mainform.OnEnableUpdateMenuItem method = new Mainform.OnEnableUpdateMenuItem(this.EnableUpdateMenuItem);
				base.Invoke(method, new object[0]);
			}
			else
			{
				this.checkForUpdatesToolStripMenuItem.Enabled = true;
			}
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x000A9D20 File Offset: 0x000A7F20
		private void CheckUpdates()
		{
			Thread thread = new Thread(new ThreadStart(this._updateWorker));
			thread.Start();
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x00002A71 File Offset: 0x00000C71
		private void _updateWorker()
		{
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x000A9D48 File Offset: 0x000A7F48
		public void ShowWelcomeScreen(bool show)
		{
			if (show)
			{
				this.welcome = new WelcomeControl();
				base.Controls.Add(this.welcome);
				this.welcome.Parent = this;
				this.welcome.BackColor = Color.White;
				this.welcome.BackgroundImageLayout = ImageLayout.None;
				this.welcome.Dock = DockStyle.Fill;
				this.welcome.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
				this.welcome.Location = new Point(0, 24);
				this.welcome.Name = "welcome";
				this.welcome.Size = new Size(942, 660);
				this.welcome.TabIndex = 22;
				this.welcome.BringToFront();
				this.welcome.Select();
			}
			else if (this.welcome != null)
			{
				base.Controls.Remove(this.welcome);
				this.welcome.Dispose();
			}
			this.MinimumSize = (show ? new Size(950, 738) : new Size(800, 600));
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000D96 RID: 3478 RVA: 0x000A9E7C File Offset: 0x000A807C
		public WorkshopProject CurrentProject
		{
			get
			{
				return this._currentProject;
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000D97 RID: 3479 RVA: 0x000A9E94 File Offset: 0x000A8094
		public IProjectModel CurrentProjectModel
		{
			get
			{
				return this._currentProjectModel;
			}
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x000077F3 File Offset: 0x000059F3
		public void ReloadProject()
		{
			if (this._currentProjectModel != null && this._currentProject != null)
			{
				this.OpenProject(this._currentProject);
			}
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x00007813 File Offset: 0x00005A13
		public void SaveCurrentProject()
		{
			if (this._currentProject != null && this._currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Save())
			{
				this.UpdateRecent(this._currentProject);
			}
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x000A9EAC File Offset: 0x000A80AC
		public void OpenProject(WorkshopProject project)
		{
			this.SetStatus("");
			if (project != null)
			{
				if (this._currentProject != null)
				{
					this.CloseCurrentProject();
				}
				this.ShowWelcomeScreen(false);
				this._currentProjectModel = null;
				this._currentProject = project;
				this._currentProject_ProjectChanged(new EventArgs());
				this._currentProject.class89_0.ProjectChanged += this._currentProject_ProjectChanged;
				this._currentProject.Package.EntryAdded += this.Package_EntryAdded;
				this.saveMenuItem.Enabled = true;
				this.saveAsMenuItem.Enabled = true;
				this.Text = this._windowTitle + ": " + project.ToString();
				this.projectContentsMenuItem.Enabled = true;
				this.projectInfoMenuItem.Enabled = true;
				this.saveMenuItem.Enabled = true;
				this.saveAsMenuItem.Enabled = true;
				this.closeMenuItem.Enabled = true;
				this.importMenuItem.Enabled = true;
				this.exportMenuItem.Enabled = true;
				this.loadAnimationToolStripMenuItem.Enabled = true;
				foreach (object obj in this.toolsMenuItem.DropDownItems)
				{
					if (obj is Class141)
					{
						(obj as Class141).Enabled = true;
					}
				}
				Sims3Workshop.Data.ProjectType type = project.Type;
				switch (type)
				{
				case Sims3Workshop.Data.ProjectType.CLOTHING:
				case Sims3Workshop.Data.ProjectType.MAKEUP:
				case Sims3Workshop.Data.ProjectType.HAIR:
				case Sims3Workshop.Data.ProjectType.ACCESSORY:
					break;
				case (Sims3Workshop.Data.ProjectType)5:
					goto IL_30D;
				case Sims3Workshop.Data.ProjectType.OBJECT:
					goto IL_2B9;
				default:
					switch (type)
					{
					case Sims3Workshop.Data.ProjectType.STAIRS:
					case Sims3Workshop.Data.ProjectType.FENCE:
					case Sims3Workshop.Data.ProjectType.RAILING:
					case Sims3Workshop.Data.ProjectType.WALL:
					case Sims3Workshop.Data.ProjectType.ROOF:
					case Sims3Workshop.Data.ProjectType.TERRAIN:
						break;
					case Sims3Workshop.Data.ProjectType.FLOOR:
						goto IL_30D;
					default:
						if (type != Sims3Workshop.Data.ProjectType.BLUEPRINT)
						{
							goto IL_30D;
						}
						try
						{
							this._currentProjectModel = new Class26(project);
							this.SetStatus("Project loaded");
							goto IL_30D;
						}
						catch (Exception ex)
						{
							string message = ex.Message;
							if (ex.InnerException != null)
							{
								message = ex.InnerException.Message;
							}
							MessageBox.Show(message);
							Class132.mainForm.SetStatus(message);
							goto IL_4EB;
						}
						break;
					}
					try
					{
						this._currentProjectModel = new Class86(project, project.Type);
						this.SetStatus("Project loaded");
						goto IL_30D;
					}
					catch (Exception ex2)
					{
						string message2 = ex2.Message;
						if (ex2.InnerException != null)
						{
							message2 = ex2.InnerException.Message;
						}
						MessageBox.Show(message2);
						Class132.mainForm.SetStatus(message2);
						goto IL_4EB;
					}
					break;
				}
				try
				{
					this._currentProjectModel = new Class68(project);
					this.SetStatus("Project loaded");
					goto IL_30D;
				}
				catch (Exception ex3)
				{
					string message3 = ex3.Message;
					if (ex3.InnerException != null)
					{
						message3 = ex3.InnerException.Message;
					}
					MessageBox.Show(message3);
					Class132.mainForm.SetStatus(message3);
					goto IL_4EB;
				}
				try
				{
					IL_2B9:
					this._currentProjectModel = new Class80(project);
					this.SetStatus("Project loaded");
				}
				catch (Exception ex4)
				{
					string message4 = ex4.Message;
					if (ex4.InnerException != null)
					{
						message4 = ex4.InnerException.Message;
					}
					MessageBox.Show(message4);
					Class132.mainForm.SetStatus(message4);
					goto IL_4EB;
				}
				try
				{
					IL_30D:
					this.displaySlotsButton.Enabled = this._currentProjectModel.HasSlots();
					this.displayBumpMapButton.Enabled = this._currentProjectModel.HasBumpMap();
					this._currentProjectModel.SetSlotsVisible(this.displaySlotsButton.Checked);
					this._currentProjectModel.SetRigVisible(this.DisplayJointsButton.Checked);
					Class132.smethod_0().GroundEnabled = (this.displayGroundShadow.Checked = (this.displayGroundShadow.Enabled = this._currentProjectModel.HasShadows()));
					List<Lod> lodLevels = this._currentProjectModel.GetLodLevels();
					if (lodLevels.Count == 0)
					{
						this.SetCurrentLOD(Lod.High);
						CheckBox checkBox = this.veryHighLod;
						CheckBox checkBox2 = this.highLod;
						CheckBox checkBox3 = this.mediumLod;
						this.lowLod.Checked = false;
						checkBox3.Checked = false;
						checkBox2.Checked = false;
						checkBox.Checked = false;
					}
					if (lodLevels.Contains(Lod.UltraHigh))
					{
						this.SetCurrentLOD(Lod.UltraHigh);
					}
					else if (lodLevels.Contains(Lod.High))
					{
						this.SetCurrentLOD(Lod.High);
					}
					else if (lodLevels.Contains(Lod.Medium))
					{
						this.SetCurrentLOD(Lod.Medium);
					}
					else if (lodLevels.Contains(Lod.Low))
					{
						this.SetCurrentLOD(Lod.Low);
					}
					this.veryHighLod.Enabled = lodLevels.Contains(Lod.UltraHigh);
					this.highLod.Enabled = lodLevels.Contains(Lod.High);
					this.mediumLod.Enabled = lodLevels.Contains(Lod.Medium);
					this.lowLod.Enabled = lodLevels.Contains(Lod.Low);
					Class132.smethod_0().ObjectRotation = 0f;
					EditorToolBox.smethod_0().method_0(this.CurrentProjectModel);
				}
				catch (Exception ex5)
				{
					string message5 = ex5.Message;
					if (ex5.InnerException != null)
					{
						message5 = ex5.InnerException.Message;
					}
					MessageBox.Show(message5);
					Class132.mainForm.SetStatus(message5);
				}
				IL_4EB:;
			}
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x00007838 File Offset: 0x00005A38
		private void Package_EntryAdded(DBPFEntry entry)
		{
			this._currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			this.status.Text = entry.ToString() + " added to project.";
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x00002A71 File Offset: 0x00000C71
		private void Events_ProjectChanged(EventArgs e)
		{
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x00002A71 File Offset: 0x00000C71
		public void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
		{
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x00002A71 File Offset: 0x00000C71
		private void model_PropertyChanged(XmlDocument preset)
		{
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x000AA43C File Offset: 0x000A863C
		private bool CloseCurrentProject()
		{
			bool result;
			if (this._currentProject == null)
			{
				result = true;
			}
			else if (this._currentProject.method_2() == DialogResult.Cancel)
			{
				result = false;
			}
			else
			{
				this.ShowWelcomeScreen(true);
				this._currentProject = null;
				Class132.smethod_0().method_20();
				Class132.smethod_0().ViewMode = MeshEditor.Enum9.const_0;
				Class132.mainForm.ProjectPanel.Controls.Clear();
				this.saveAsMenuItem.Enabled = false;
				this.saveMenuItem.Enabled = false;
				this.closeMenuItem.Enabled = false;
				this.importMenuItem.Enabled = false;
				this.exportMenuItem.Enabled = false;
				this.projectContentsMenuItem.Enabled = false;
				this.projectInfoMenuItem.Enabled = false;
				this.loadAnimationToolStripMenuItem.Enabled = false;
				foreach (object obj in this.toolsMenuItem.DropDownItems)
				{
					if (obj is Class141 && ((obj as Class141).Extension as IToolPlugin).RequiresProject)
					{
						(obj as Class141).Enabled = false;
					}
				}
				this.Text = this._windowTitle;
				this.SetStatus("No project loaded");
				if (this._currentProjectModel != null)
				{
					this._currentProjectModel.Unload();
				}
				Class132.smethod_0().method_49(null);
				EditorToolBox.smethod_0().Hide();
				result = true;
			}
			return result;
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x000AA5BC File Offset: 0x000A87BC
		private void _currentProject_ProjectChanged(EventArgs e)
		{
			if (base.InvokeRequired)
			{
				Class89.Delegate20 method = new Class89.Delegate20(this._currentProject_ProjectChanged);
				base.Invoke(method, new object[]
				{
					e
				});
			}
			else
			{
				this.Text = this._windowTitle + ": " + this._currentProject.ToString();
			}
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x00007863 File Offset: 0x00005A63
		private void Mainform_MeshPropertyChanged(PropertiesForm.EventArgs4 e)
		{
			this._currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x00007873 File Offset: 0x00005A73
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this._currentProjectModel != null)
			{
				this._currentProjectModel.Unload();
			}
			Application.Exit();
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x000AA618 File Offset: 0x000A8818
		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			try
			{
				WorkshopProject workshopProject = WorkshopProject.smethod_0();
				if (workshopProject != null)
				{
					if (this.CloseCurrentProject())
					{
						this.OpenProject(workshopProject);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x0000788F File Offset: 0x00005A8F
		private void saveMenuItem_Click(object sender, EventArgs e)
		{
			if (this._currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Save())
			{
				this.UpdateRecent(this._currentProject);
			}
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x000078AC File Offset: 0x00005AAC
		private void saveAsMenuItem_Click(object sender, EventArgs e)
		{
			if (this._currentProject.method_4(true))
			{
				this.UpdateRecent(this._currentProject);
			}
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x000AA664 File Offset: 0x000A8864
		private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.ismaximized = ((base.WindowState == FormWindowState.Maximized) ? 1 : 0);
			Settings.Default.width = base.Width;
			Settings.Default.height = base.Height;
			Settings.Default.Save();
			if (this._currentProject != null)
			{
				if (this._currentProject.method_2() == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
				else
				{
					this._currentProject = null;
				}
			}
			if (!e.Cancel)
			{
				this.exitToolStripMenuItem_Click(null, null);
			}
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x000078CA File Offset: 0x00005ACA
		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			this.CloseCurrentProject();
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x000AA6EC File Offset: 0x000A88EC
		private void newMenuItem_Click(object sender, EventArgs e)
		{
			if (this.CloseCurrentProject())
			{
				NewProjectForm newProjectForm = new NewProjectForm();
				if (newProjectForm.ShowDialog(this) == DialogResult.OK)
				{
					this.OpenProject(newProjectForm.Project);
				}
			}
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x000078D5 File Offset: 0x00005AD5
		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AboutBox().ShowDialog();
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x000078E4 File Offset: 0x00005AE4
		private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.CheckUpdates();
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x000078EE File Offset: 0x00005AEE
		private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new PreferencesForm().ShowDialog(this);
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x000078FE File Offset: 0x00005AFE
		private void channelCombo_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = 80;
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x0000790A File Offset: 0x00005B0A
		private void Mainform_Shown(object sender, EventArgs e)
		{
			int ismaximized = Settings.Default.ismaximized;
			if (this._projectToOpen != null)
			{
				this.OpenProject(WorkshopProject.smethod_1(this._projectToOpen));
			}
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x00007932 File Offset: 0x00005B32
		protected override void OnResizeBegin(EventArgs e)
		{
			base.OnResizeBegin(e);
			this.inSizeMove = true;
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x00007944 File Offset: 0x00005B44
		protected override void OnResizeEnd(EventArgs e)
		{
			Class132.smethod_0().method_36();
			this.inSizeMove = false;
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x000AA724 File Offset: 0x000A8924
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 5)
			{
				if (m.WParam == Class88.intptr_1)
				{
					Class132.smethod_0().method_36();
				}
				else if (m.WParam == Class88.intptr_2 && !this.inSizeMove)
				{
					Class132.smethod_0().method_36();
				}
			}
			base.WndProc(ref m);
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x00002A71 File Offset: 0x00000C71
		private void editHierarchyToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00002A71 File Offset: 0x00000C71
		private void splitButton1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x00007959 File Offset: 0x00005B59
		private void button1_Click(object sender, EventArgs e)
		{
			Class132.smethod_0().method_46();
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x000AA788 File Offset: 0x000A8988
		public IMeshEditor GetMeshEditor()
		{
			return Class132.smethod_0();
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x000AA7A0 File Offset: 0x000A89A0
		public Form GetParentForm()
		{
			return Class132.mainForm;
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x000A9E94 File Offset: 0x000A8094
		public IProjectModel GetCurrentProjectModel()
		{
			return this._currentProjectModel;
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x000AA7B8 File Offset: 0x000A89B8
		private string makeRequest(string url)
		{
			HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
			WebResponse response = httpWebRequest.GetResponse();
			StreamReader streamReader = new StreamReader(response.GetResponseStream());
			string result = streamReader.ReadToEnd();
			response.Close();
			return result;
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x000AA7F8 File Offset: 0x000A89F8
		private int loginToTsr(IWin32Window ownerWindow)
		{
			int num = -1;
			string tsremail = Settings.Default.TSREmail;
			string tsrpassword = Settings.Default.TSRPassword;
			if (tsremail == "" || tsrpassword == "")
			{
				MessageBox.Show(ownerWindow, "No TSR Email / Password set", "Failed");
				CreatorDetailsForm creatorDetailsForm = new CreatorDetailsForm();
				DialogResult dialogResult;
				for (dialogResult = creatorDetailsForm.ShowDialog(); dialogResult == DialogResult.OK; dialogResult = creatorDetailsForm.ShowDialog())
				{
					tsremail = creatorDetailsForm.control5_0.TSREmail;
					tsrpassword = creatorDetailsForm.control5_0.TSRPassword;
					if (!string.IsNullOrEmpty(tsremail) && !string.IsNullOrEmpty(tsrpassword))
					{
						break;
					}
					MessageBox.Show("Email and password can not be empty!");
				}
				if (dialogResult == DialogResult.Cancel)
				{
					return -1;
				}
			}
			int result;
			for (;;)
			{
				try
				{
					string text = this.makeRequest("http://test.thesimsresource.com/webservices/members/do/getMemberId/email/" + tsremail + "/password/" + tsrpassword);
					num = (string.IsNullOrEmpty(text) ? -1 : int.Parse(text));
					goto IL_160;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Failed to login to TSR\n\n" + ex.Message);
					result = -1;
					goto IL_166;
				}
				IL_F0:
				MessageBox.Show(ownerWindow, "Incorrect TSR Email / Password", "Failed");
				CreatorDetailsForm creatorDetailsForm2 = new CreatorDetailsForm();
				DialogResult dialogResult2;
				for (dialogResult2 = creatorDetailsForm2.ShowDialog(); dialogResult2 == DialogResult.OK; dialogResult2 = creatorDetailsForm2.ShowDialog())
				{
					tsremail = creatorDetailsForm2.control5_0.TSREmail;
					tsrpassword = creatorDetailsForm2.control5_0.TSRPassword;
					if (!string.IsNullOrEmpty(tsremail) && !string.IsNullOrEmpty(tsrpassword))
					{
						break;
					}
					MessageBox.Show("Email and password can not be empty!");
				}
				if (dialogResult2 == DialogResult.Cancel)
				{
					break;
				}
				continue;
				IL_160:
				if (num == -1)
				{
					goto IL_F0;
				}
				goto IL_171;
			}
			return -1;
			IL_166:
			return result;
			IL_171:
			return num;
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x000AA990 File Offset: 0x000A8B90
		public UploadResult UploadFileToStorage(IWin32Window ownerWindow, string fileName, byte[] data)
		{
			int num = this.loginToTsr(ownerWindow);
			UploadResult result;
			if (num == -1)
			{
				result = UploadResult.UPLOAD_INCORRECT_PASSWORD;
			}
			else
			{
				string text = this.makeRequest("http://test.thesimsresource.com/webservices/members/do/maxQuota/memberId/" + num);
				long num2 = long.Parse(text);
				text = this.makeRequest("http://test.thesimsresource.com/webservices/members/do/quota/memberId/" + num);
				long num3 = long.Parse(text);
				num3 += (long)data.Length;
				if (num3 > num2)
				{
					result = UploadResult.UPLOAD_STORAGE_FULL;
				}
				else
				{
					text = this.makeRequest(string.Concat(new object[]
					{
						"http://test.thesimsresource.com/webservices/members/do/hasFile/memberId/",
						num,
						"/fileName/",
						fileName
					}));
					string text2 = text;
					if (text2.Equals("yes"))
					{
						DialogResult dialogResult = MessageBox.Show(ownerWindow, "A file named " + fileName + " already exists. \n\nDo you want to overwrite it?", "File Exists", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if (dialogResult == DialogResult.Cancel)
						{
							return UploadResult.UPLOAD_CANCELED;
						}
						if (dialogResult == DialogResult.No)
						{
							return UploadResult.UPLOAD_CANCELED;
						}
					}
					string tempFileName = Path.GetTempFileName();
					FileStream fileStream = new FileStream(tempFileName, FileMode.Create);
					fileStream.Write(data, 0, data.Length);
					fileStream.Close();
					UploadResult uploadResult = UploadResult.UPLOAD_OK;
					try
					{
						string tsrpassword = Settings.Default.TSRPassword;
						string tsremail = Settings.Default.TSREmail;
						if (Class99.smethod_0(tsremail, tsrpassword, tempFileName, fileName))
						{
							uploadResult = UploadResult.UPLOAD_OK;
						}
						else
						{
							uploadResult = UploadResult.UPLOAD_FAILED;
						}
					}
					catch (Exception)
					{
						uploadResult = UploadResult.UPLOAD_FAILED;
					}
					try
					{
						if (File.Exists(tempFileName))
						{
							File.Delete(tempFileName);
						}
					}
					catch (Exception)
					{
					}
					result = uploadResult;
				}
			}
			return result;
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x000AAB18 File Offset: 0x000A8D18
		public CreatorDetails GetCreatorDetails()
		{
			CreatorDetailsForm creatorDetailsForm = new CreatorDetailsForm();
			CreatorDetails result;
			if (Settings.Default.AskCreatorInfo)
			{
				DialogResult dialogResult = creatorDetailsForm.ShowDialog(this);
				if (dialogResult == DialogResult.OK)
				{
					result = creatorDetailsForm.control5_0.Data;
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = creatorDetailsForm.control5_0.Data;
			}
			return result;
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x000AAB64 File Offset: 0x000A8D64
		public string CreateGuid(string salt)
		{
			string s = Settings.Default.CreatorName + "_" + salt;
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = Encoding.ASCII.GetBytes(s);
			array = md5CryptoServiceProvider.ComputeHash(array);
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("X2"));
				if (num == 3 || num == 5 || num == 7 || num == 9)
				{
					stringBuilder.Append("-");
				}
				num++;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x00007967 File Offset: 0x00005B67
		private void reloadStartpageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.welcome.method_6();
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x00007976 File Offset: 0x00005B76
		private void projectContentsMenuItem_Click(object sender, EventArgs e)
		{
			new ProjectContentsBrowser(this.CurrentProject.Package).ShowDialog(this);
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x00007991 File Offset: 0x00005B91
		private void Mainform_KeyDown(object sender, KeyEventArgs e)
		{
			MeshEditor.bool_2 = e.Alt;
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x000AAC1C File Offset: 0x000A8E1C
		private void Mainform_KeyUp(object sender, KeyEventArgs e)
		{
			MeshEditor.bool_2 = e.Alt;
			Keys keyCode = e.KeyCode;
			if (keyCode == Keys.Up && this.numKeyPresses == 0)
			{
				this.numKeyPresses++;
			}
			else if (keyCode == Keys.Up && this.numKeyPresses == 1)
			{
				this.numKeyPresses++;
			}
			else if (keyCode == Keys.Down && this.numKeyPresses == 2)
			{
				this.numKeyPresses++;
			}
			else if (keyCode == Keys.Down && this.numKeyPresses == 3)
			{
				this.numKeyPresses++;
			}
			else if (keyCode == Keys.Left && this.numKeyPresses == 4)
			{
				this.numKeyPresses++;
			}
			else if (keyCode == Keys.Right && this.numKeyPresses == 5)
			{
				this.numKeyPresses++;
			}
			else if (keyCode == Keys.Left && this.numKeyPresses == 6)
			{
				this.numKeyPresses++;
			}
			else if (keyCode == Keys.Right && this.numKeyPresses == 7)
			{
				this.numKeyPresses++;
			}
			else if (keyCode == Keys.B && this.numKeyPresses == 8)
			{
				this.numKeyPresses++;
			}
			else if (keyCode == Keys.A && this.numKeyPresses == 9)
			{
				new KonamiCode().ShowDialog(Class132.mainForm);
				this.numKeyPresses = 0;
			}
			else
			{
				this.numKeyPresses = 0;
			}
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x000079A0 File Offset: 0x00005BA0
		private void gridEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Class132.smethod_0().GridEnabled = this.displayGridButton.Checked;
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x000AAD8C File Offset: 0x000A8F8C
		public IGamedata GetGamedataInstance()
		{
			return new Class75();
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x000AADA4 File Offset: 0x000A8FA4
		public Lod GetCurrentLOD()
		{
			return this._currentLod;
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x000079B9 File Offset: 0x00005BB9
		private void lodUltrahigh_CheckedChanged(object sender, EventArgs e)
		{
			this.SetCurrentLOD((this.veryHighLod == sender) ? Lod.UltraHigh : ((this.highLod == sender) ? Lod.High : ((this.lowLod == sender) ? Lod.Low : Lod.Medium)));
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x000AADBC File Offset: 0x000A8FBC
		public void SetCurrentLOD(Lod lod)
		{
			if (this._currentLod != lod && this._currentProjectModel != null)
			{
				this.veryHighLod.Checked = (lod == Lod.UltraHigh);
				this.highLod.Checked = (lod == Lod.High);
				this.mediumLod.Checked = (lod == Lod.Medium);
				this.lowLod.Checked = (lod == Lod.Low);
				this._currentProjectModel.LodChanged(lod);
				this._currentLod = lod;
			}
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x000079EC File Offset: 0x00005BEC
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			Class132.smethod_0().NormalsEnabled = this.displayNormalsButton.Checked;
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x00007A05 File Offset: 0x00005C05
		private void wireframe_Click(object sender, EventArgs e)
		{
			Class132.smethod_0().Wireframe = this.displayWireframeButton.Checked;
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x00007A1E File Offset: 0x00005C1E
		private void displaySlots_Click(object sender, EventArgs e)
		{
			if (this._currentProjectModel != null)
			{
				this._currentProjectModel.SetSlotsVisible(this.displaySlotsButton.Checked);
			}
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x000AAE30 File Offset: 0x000A9030
		public List<IFileExportPlugin> GetFileExportPluginsForType(DBPFType type)
		{
			List<IFileExportPlugin> list = new List<IFileExportPlugin>();
			foreach (IFileExportPlugin fileExportPlugin in this._fileExportPlugins)
			{
				if (fileExportPlugin.SupportedTypes.Contains(type) || fileExportPlugin.SupportedTypes.Contains(DBPFType.ALL))
				{
					list.Add(fileExportPlugin);
				}
			}
			return list;
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x000AAEAC File Offset: 0x000A90AC
		public List<IFileImportPlugin> GetFileImportPluginsForType(DBPFType type)
		{
			List<IFileImportPlugin> list = new List<IFileImportPlugin>();
			foreach (IFileImportPlugin fileImportPlugin in this._fileImportPlugins)
			{
				if (fileImportPlugin.SupportedTypes.Contains(type) || fileImportPlugin.SupportedTypes.Contains(DBPFType.ALL))
				{
					list.Add(fileImportPlugin);
				}
			}
			return list;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x000AAF28 File Offset: 0x000A9128
		public List<IDBPFEntryEditor> GetEditorPluginsForType(DBPFType type)
		{
			List<IDBPFEntryEditor> list = new List<IDBPFEntryEditor>();
			foreach (IDBPFEntryEditor idbpfentryEditor in this._dbpfEditorPlugins)
			{
				if (idbpfentryEditor.SupportedTypes.Contains(type) || idbpfentryEditor.SupportedTypes.Contains(DBPFType.ALL))
				{
					list.Add(idbpfentryEditor);
				}
			}
			return list;
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x000AAFA4 File Offset: 0x000A91A4
		public IWorkshopProject LoadProject(string name)
		{
			return WorkshopProject.smethod_1(name);
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x000AAFC0 File Offset: 0x000A91C0
		public string GetGlobalSetting(string name)
		{
			return Settings.Default[name] as string;
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x00007A40 File Offset: 0x00005C40
		public void SetGlobalSetting(string name, string value)
		{
			Settings.Default[name] = value;
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x000AAFE4 File Offset: 0x000A91E4
		public PluginResult GetPluginResource(string name, out object obj)
		{
			PluginResult result;
			foreach (IExportPlugin exportPlugin in this._exportPlugins)
			{
				if (exportPlugin.GetType().ToString().ToLower().Equals(name.ToLower()))
				{
					obj = exportPlugin;
					result = PluginResult.OK;
					goto IL_21E;
				}
			}
			foreach (IImportPlugin importPlugin in this._importPlugins)
			{
				if (importPlugin.GetType().ToString().ToLower().Equals(name.ToLower()))
				{
					obj = importPlugin;
					result = PluginResult.OK;
					goto IL_21E;
				}
			}
			foreach (IFileExportPlugin fileExportPlugin in this._fileExportPlugins)
			{
				if (fileExportPlugin.GetType().ToString().ToLower().Equals(name.ToLower()))
				{
					obj = fileExportPlugin;
					result = PluginResult.OK;
					goto IL_21E;
				}
			}
			foreach (IFileImportPlugin fileImportPlugin in this._fileImportPlugins)
			{
				if (fileImportPlugin.GetType().ToString().ToLower().Equals(name.ToLower()))
				{
					obj = fileImportPlugin;
					result = PluginResult.OK;
					goto IL_21E;
				}
			}
			foreach (IDBPFEntryEditor idbpfentryEditor in this._dbpfEditorPlugins)
			{
				if (idbpfentryEditor.GetType().ToString().ToLower().Equals(name.ToLower()))
				{
					obj = idbpfentryEditor;
					result = PluginResult.OK;
					goto IL_21E;
				}
			}
			foreach (IToolPlugin toolPlugin in this._toolPlugins)
			{
				if (toolPlugin.GetType().ToString().ToLower().Equals(name.ToLower()))
				{
					obj = toolPlugin;
					result = PluginResult.OK;
					goto IL_21E;
				}
			}
			obj = null;
			return PluginResult.FAIL;
			IL_21E:
			return result;
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x000AB264 File Offset: 0x000A9464
		public PluginResult ExportResource(DBPFType type, object file)
		{
			return this.ExportFile(type, file);
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x000AB280 File Offset: 0x000A9480
		public PluginResult ExportFile(DBPFType type, object f)
		{
			DBPFEntry file = f as DBPFEntry;
			PluginResult pluginResult = PluginResult.FAIL;
			string text = "";
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			List<IFileExportPlugin> fileExportPluginsForType = Class132.mainForm.GetFileExportPluginsForType(type);
			PluginResult result;
			if (fileExportPluginsForType.Count == 0)
			{
				MessageBox.Show("No available exporters for this filetype.");
				result = pluginResult;
			}
			else
			{
				Dictionary<int, IFileExportPlugin> dictionary = new Dictionary<int, IFileExportPlugin>();
				int num = 0;
				foreach (IFileExportPlugin fileExportPlugin in fileExportPluginsForType)
				{
					text = string.Concat(new string[]
					{
						text,
						string.IsNullOrEmpty(text) ? "" : "|",
						fileExportPlugin.GetExtensionNameForType(type),
						" (*.",
						fileExportPlugin.GetExtensionForType(type),
						")|*.",
						fileExportPlugin.GetExtensionForType(type)
					});
					dictionary.Add(num++, fileExportPlugin);
				}
				saveFileDialog.Filter = text;
				if (this.lastExportFormat.ContainsKey(type))
				{
					int num2 = 0;
					foreach (KeyValuePair<int, IFileExportPlugin> keyValuePair in dictionary)
					{
						if (dictionary[num2] == this.lastExportFormat[type])
						{
							saveFileDialog.FilterIndex = num2 + 1;
						}
						num2++;
					}
				}
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					IFileExportPlugin fileExportPlugin2 = dictionary[saveFileDialog.FilterIndex - 1];
					if (!this.lastExportFormat.ContainsKey(type))
					{
						this.lastExportFormat.Add(type, fileExportPlugin2);
					}
					PluginResult result2;
					try
					{
						pluginResult = fileExportPlugin2.Export(type, saveFileDialog.FileName, file);
						goto IL_1E2;
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, "Export failed\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						result2 = pluginResult;
					}
					return result2;
				}
				MessageBox.Show(this, "Export aborted!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				IL_1E2:
				result = pluginResult;
			}
			return result;
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x000AB4A0 File Offset: 0x000A96A0
		public PluginResult ImportFile(DBPFType type, object f)
		{
			DBPFEntry file = f as DBPFEntry;
			PluginResult pluginResult = PluginResult.FAIL;
			string text = "";
			OpenFileDialog openFileDialog = new OpenFileDialog();
			List<IFileImportPlugin> fileImportPluginsForType = Class132.mainForm.GetFileImportPluginsForType(type);
			PluginResult result;
			if (fileImportPluginsForType.Count == 0)
			{
				MessageBox.Show("No available importers for this filetype.");
				result = pluginResult;
			}
			else
			{
				Dictionary<int, IFileImportPlugin> dictionary = new Dictionary<int, IFileImportPlugin>();
				int num = 0;
				foreach (IFileImportPlugin fileImportPlugin in fileImportPluginsForType)
				{
					text = string.Concat(new string[]
					{
						text,
						string.IsNullOrEmpty(text) ? "" : "|",
						fileImportPlugin.GetExtensionNameForType(type),
						" (*.",
						fileImportPlugin.GetExtensionForType(type),
						")|*.",
						fileImportPlugin.GetExtensionForType(type)
					});
					dictionary.Add(num++, fileImportPlugin);
				}
				openFileDialog.Filter = text;
				if (this.lastImportFormat.ContainsKey(type))
				{
					int num2 = 0;
					foreach (KeyValuePair<int, IFileImportPlugin> keyValuePair in dictionary)
					{
						if (dictionary[num2] == this.lastImportFormat[type])
						{
							openFileDialog.FilterIndex = num2 + 1;
						}
						num2++;
					}
				}
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					IFileImportPlugin fileImportPlugin2 = dictionary[openFileDialog.FilterIndex - 1];
					PluginResult result2;
					try
					{
						pluginResult = fileImportPlugin2.Import(type, openFileDialog.FileName, file);
						if (!this.lastImportFormat.ContainsKey(type))
						{
							this.lastImportFormat.Add(type, fileImportPlugin2);
						}
						goto IL_1E2;
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, "Import failed\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						result2 = pluginResult;
					}
					return result2;
				}
				MessageBox.Show(this, "Import aborted!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				IL_1E2:
				result = pluginResult;
			}
			return result;
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x000AB6C0 File Offset: 0x000A98C0
		public PluginResult EditFile(DBPFType type, DBPFEntry file)
		{
			PluginResult pluginResult = PluginResult.FAIL;
			List<IDBPFEntryEditor> editorPluginsForType = Class132.mainForm.GetEditorPluginsForType(type);
			PluginResult result;
			if (editorPluginsForType.Count == 0)
			{
				MessageBox.Show("No available editors for this filetype.");
				result = pluginResult;
			}
			else
			{
				IDBPFEntryEditor idbpfentryEditor;
				if (editorPluginsForType.Count > 1)
				{
					EditorPickForm editorPickForm = new EditorPickForm(editorPluginsForType);
					if (editorPickForm.ShowDialog(this) == DialogResult.Cancel)
					{
						return pluginResult;
					}
					idbpfentryEditor = editorPickForm.idbpfentryEditor_0;
				}
				else
				{
					idbpfentryEditor = editorPluginsForType[0];
				}
				pluginResult = idbpfentryEditor.OpenEditor(file);
				result = pluginResult;
			}
			return result;
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x000AB734 File Offset: 0x000A9934
		private void projectInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProjectInfo projectInfo = new ProjectInfo();
			projectInfo.ShowDialog(Class132.mainForm);
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x000AB758 File Offset: 0x000A9958
		private void uploadToTSRbtn_Click(object sender, EventArgs e)
		{
			foreach (IExportPlugin exportPlugin in this._exportPlugins)
			{
				if (exportPlugin.MenuItemText == "To TheSimsResource")
				{
					exportPlugin.Export();
				}
			}
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x000AB7C0 File Offset: 0x000A99C0
		private void availableViewsMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem != null)
			{
				if (e.ClickedItem is ToolStripMenuItem)
				{
					foreach (object obj in this.availableViewsMenu.Items)
					{
						ToolStripItem toolStripItem = (ToolStripItem)obj;
						if (toolStripItem is ToolStripMenuItem)
						{
							(toolStripItem as ToolStripMenuItem).Checked = false;
						}
					}
					(e.ClickedItem as ToolStripMenuItem).Checked = true;
					this.ViewButton.Text = e.ClickedItem.Text;
					Class132.smethod_0().ViewMode = (MeshEditor.Enum9)Convert.ToInt32(e.ClickedItem.Tag);
				}
			}
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x00007A50 File Offset: 0x00005C50
		private void button1_Click_1(object sender, EventArgs e)
		{
			Class140.smethod_0().method_5();
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x000AB88C File Offset: 0x000A9A8C
		private void button1_Click_2(object sender, EventArgs e)
		{
			Class140.smethod_0().method_5();
			MeshEditor meshEditor = Class132.smethod_0();
			meshEditor.Parent.Invalidate();
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x000AB8B8 File Offset: 0x000A9AB8
		public int CompressData(ref byte[] inData, out byte[] outData)
		{
			return Class69.smethod_0(ref inData, out outData);
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00007A5E File Offset: 0x00005C5E
		private void groundCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			Class132.smethod_0().GroundEnabled = this.displayGroundShadow.Checked;
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x00007A77 File Offset: 0x00005C77
		private void bumpmapCheckbox_Click(object sender, EventArgs e)
		{
			Class132.smethod_0().BumpMapEnabled = this.displayBumpMapButton.Checked;
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x00007A90 File Offset: 0x00005C90
		private void Mainform_Deactivate(object sender, EventArgs e)
		{
			this.suspend = true;
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x00007A9B File Offset: 0x00005C9B
		private void Mainform_Activated(object sender, EventArgs e)
		{
			this.suspend = false;
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x00007AA6 File Offset: 0x00005CA6
		private void loadAnimationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Mainform.jazzDialog = new JazzLoader();
			Mainform.jazzDialog.OnLoadClip += this.jazzDialog_OnLoadClip;
			Mainform.jazzDialog.Show(this);
		}

		// Token: 0x06000DDE RID: 3550 RVA: 0x000AB8D0 File Offset: 0x000A9AD0
		private void jazzDialog_OnLoadClip(ResKey reskey)
		{
			DBPFEntry dbpfentry = Class76.smethod_26(reskey);
			if (dbpfentry == null)
			{
				reskey.GroupId = 134217728;
				dbpfentry = Class76.smethod_26(reskey);
			}
			if (dbpfentry != null)
			{
				Class132.smethod_0().method_49(dbpfentry as S_CLIP);
			}
			else
			{
				MessageBox.Show("Could not load clip " + reskey.AsString());
			}
		}

		// Token: 0x06000DDF RID: 3551 RVA: 0x00007AD5 File Offset: 0x00005CD5
		private void rigCheckBox_Click(object sender, EventArgs e)
		{
			if (this.CurrentProjectModel != null)
			{
				this.CurrentProjectModel.SetRigVisible(this.DisplayJointsButton.Checked);
			}
		}

		// Token: 0x06000DE0 RID: 3552 RVA: 0x000AB928 File Offset: 0x000A9B28
		private void button1_Click_3(object sender, EventArgs e)
		{
			if (EditorToolBox.smethod_0().Visible)
			{
				EditorToolBox.smethod_0().Visible = false;
			}
			else
			{
				EditorToolBox editorToolBox = EditorToolBox.smethod_0();
				editorToolBox.Visible = true;
				editorToolBox.Parent = Class132.smethod_0().RenderPanel;
				editorToolBox.Dock = DockStyle.Left;
				editorToolBox.SendToBack();
				editorToolBox.Width = 208;
				this.Render();
			}
		}

		// Token: 0x06000DE1 RID: 3553 RVA: 0x000AB98C File Offset: 0x000A9B8C
		private void ViewViewButton_Click(object sender, EventArgs e)
		{
			this.ViewViewButton.Checked = true;
			ToolStripMenuItem viewZoomButton = this.ViewZoomButton;
			this.ViewPanButton.Checked = false;
			viewZoomButton.Checked = false;
			this.splitButton1.Text = "View";
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x000AB9D4 File Offset: 0x000A9BD4
		private void ViewPanButton_Click(object sender, EventArgs e)
		{
			this.ViewPanButton.Checked = true;
			ToolStripMenuItem viewViewButton = this.ViewViewButton;
			this.ViewZoomButton.Checked = false;
			viewViewButton.Checked = false;
			this.splitButton1.Text = "Pan";
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x000ABA1C File Offset: 0x000A9C1C
		private void ViewZoomButton_Click(object sender, EventArgs e)
		{
			this.ViewZoomButton.Checked = true;
			ToolStripMenuItem viewViewButton = this.ViewViewButton;
			this.ViewPanButton.Checked = false;
			viewViewButton.Checked = false;
			this.splitButton1.Text = "Zoom";
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x00002A71 File Offset: 0x00000C71
		private void d(object sender, EventArgs e)
		{
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x00002A71 File Offset: 0x00000C71
		private void displayGroundShadow_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04000A24 RID: 2596
		private WorkshopProject _currentProject;

		// Token: 0x04000A25 RID: 2597
		private string _windowTitle = "TSR Workshop";

		// Token: 0x04000A26 RID: 2598
		private IProjectModel _currentProjectModel;

		// Token: 0x04000A27 RID: 2599
		private WelcomeControl welcome;

		// Token: 0x04000A28 RID: 2600
		private Splash splashScreen;

		// Token: 0x04000A29 RID: 2601
		private bool suspend;

		// Token: 0x04000A2A RID: 2602
		private string _projectToOpen;

		// Token: 0x04000A2B RID: 2603
		private int numGameFiles;

		// Token: 0x04000A2C RID: 2604
		private int totFileCount;

		// Token: 0x04000A2D RID: 2605
		private List<IImportPlugin> _importPlugins = new List<IImportPlugin>();

		// Token: 0x04000A2E RID: 2606
		private List<IExportPlugin> _exportPlugins = new List<IExportPlugin>();

		// Token: 0x04000A2F RID: 2607
		private List<IToolPlugin> _toolPlugins = new List<IToolPlugin>();

		// Token: 0x04000A30 RID: 2608
		private List<IFileExportPlugin> _fileExportPlugins = new List<IFileExportPlugin>();

		// Token: 0x04000A31 RID: 2609
		private List<IFileImportPlugin> _fileImportPlugins = new List<IFileImportPlugin>();

		// Token: 0x04000A32 RID: 2610
		private List<IDBPFEntryEditor> _dbpfEditorPlugins = new List<IDBPFEntryEditor>();

		// Token: 0x04000A33 RID: 2611
		private bool inSizeMove;

		// Token: 0x04000A34 RID: 2612
		private int numKeyPresses;

		// Token: 0x04000A35 RID: 2613
		private Lod _currentLod;

		// Token: 0x04000A36 RID: 2614
		private Dictionary<DBPFType, IFileExportPlugin> lastExportFormat = new Dictionary<DBPFType, IFileExportPlugin>();

		// Token: 0x04000A37 RID: 2615
		private Dictionary<DBPFType, IFileImportPlugin> lastImportFormat = new Dictionary<DBPFType, IFileImportPlugin>();

		// Token: 0x04000A38 RID: 2616
		public static JazzLoader jazzDialog;

		// Token: 0x02000129 RID: 297
		// (Invoke) Token: 0x06000DEE RID: 3566
		public delegate void OnUpdatesAvailable();

		// Token: 0x0200012A RID: 298
		// (Invoke) Token: 0x06000DF2 RID: 3570
		public delegate void OnDisableUpdateMenuItem();

		// Token: 0x0200012B RID: 299
		// (Invoke) Token: 0x06000DF6 RID: 3574
		public delegate void OnEnableUpdateMenuItem();

		// Token: 0x0200012C RID: 300
		// (Invoke) Token: 0x06000DFA RID: 3578
		public delegate ToolStripItem OnStatusMessage(string message);

		// Token: 0x0200012D RID: 301
		// (Invoke) Token: 0x06000DFE RID: 3582
		public delegate void OnRemoveStatusMessage(ToolStripItem stripItem);
	}
}
