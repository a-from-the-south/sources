using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns10;
using ns11;
using ns16;
using ns17;
using ns18;
using ns19;
using ns3;
using ns5;
using ns6;
using ns7;
using ns8;
using Package;
using Package.Helper;
using Package.Sims3Files;
using Sims3Workshop.Data;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Interfaces;

namespace ns2
{
	// Token: 0x02000045 RID: 69
	internal sealed partial class NewProjectForm : Form
	{
		// Token: 0x0600028F RID: 655 RVA: 0x0000396E File Offset: 0x00001B6E
		public NewProjectForm()
		{
			this.InitializeComponent();
			Class76.smethod_29();
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void method_0(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0002FA5C File Offset: 0x0002DC5C
		public WorkshopProject Project
		{
			get
			{
				return this.workshopProject_0;
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000398E File Offset: 0x00001B8E
		private void NewProjectForm_Load(object sender, EventArgs e)
		{
			this.projectName.Select();
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0002FA74 File Offset: 0x0002DC74
		private void method_1(object sender, Wizard.EventArgs6 e)
		{
			try
			{
				Convert.ToInt32(this.newGroupId.Text, 16);
			}
			catch (Exception)
			{
				MessageBox.Show("Invalid group id!");
				e.Cancel = true;
				this.newGroupId.BackColor = Color.FromArgb(255, 255, 200, 200);
				this.newGroupId.Focus();
			}
			Class146 @class = this.wizard.Pages[e.OldIndex];
			if (@class == this.import && e.NewIndex > e.OldIndex)
			{
				e.NewIndex++;
			}
			else if (@class == this.details && e.NewIndex < e.OldIndex && this.bool_1)
			{
				e.NewIndex = 1;
			}
			else
			{
				if (@class == this.pageStart && e.NewIndex > e.OldIndex)
				{
					if (this.projectTemplate.SelectedItems.Count != 1)
					{
						MessageBox.Show("Please chose a template for the project.", "New Project Wizard", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						e.Cancel = true;
					}
					else
					{
						ListViewItem listViewItem = this.projectTemplate.SelectedItems[0];
						if (!"new".Equals(listViewItem.Group.Name))
						{
							this.bool_0 = false;
							e.NewIndex++;
							try
							{
								string[] array = Class76.smethod_11();
								if (array.Length == 0)
								{
									MessageBox.Show("Game path is needed in order to make a clone.");
									e.Cancel = true;
								}
								goto IL_6DF;
							}
							catch (Exception0)
							{
								MessageBox.Show(null, Application.ProductName + " can not run without access to the game files, exiting.", "Error");
								Application.Exit();
								goto IL_6DF;
							}
						}
						this.bool_0 = false;
						this.wizard.NextEnabled = false;
						this.wizard.BackEnabled = true;
					}
				}
				else if ((@class == this.clone || @class == this.import) && e.NewIndex > e.OldIndex)
				{
					if (this.dbpfentry_0 == null)
					{
						e.Cancel = true;
					}
					else
					{
						this.diagonalChoice.Enabled = false;
						this.diagonalChoice.Visible = false;
						Sims3Workshop.Data.ProjectType projectType = this.projectType_0;
						switch (projectType)
						{
						case Sims3Workshop.Data.ProjectType.CLOTHING:
						case Sims3Workshop.Data.ProjectType.MAKEUP:
						case Sims3Workshop.Data.ProjectType.HAIR:
						case Sims3Workshop.Data.ProjectType.ACCESSORY:
						{
							this.projectName.Text = "new CAS project";
							CASP casp = this.dbpfentry_0 as CASP;
							this.unique.Text = casp.str1;
							this.title.Text = StringHelpers.FromCamelCase(casp.str1);
							Control control = this.description;
							this.descriptionLabel.Visible = false;
							control.Visible = false;
							return;
						}
						case (Sims3Workshop.Data.ProjectType)5:
							goto IL_6DF;
						case Sims3Workshop.Data.ProjectType.OBJECT:
							break;
						case Sims3Workshop.Data.ProjectType.BUILD:
						{
							BuildItem buildItem = this.dbpfentry_0 as BuildItem;
							this.unique.Visible = false;
							this.uniqueLabel.Visible = false;
							this.projectName.Text = ((buildItem.CatalogNameEntry.IndexOf("Name:") != -1) ? (buildItem.CatalogNameEntry.Substring(buildItem.CatalogNameEntry.IndexOf("Name:") + 5) + "_Clone") : buildItem.CatalogNameEntry);
							this.unique.Text = buildItem.CatalogNameEntry;
							this.title.Text = StringHelpers.FromCamelCase((buildItem.CatalogNameEntry.IndexOf("Name:") != -1) ? buildItem.CatalogNameEntry.Substring(buildItem.CatalogNameEntry.IndexOf("Name:") + 5) : buildItem.CatalogNameEntry);
							this.description.Text = ((buildItem.CatalogDescEntry.IndexOf("Description:") > -1) ? StringHelpers.FromCamelCase(buildItem.CatalogDescEntry.Substring(buildItem.CatalogDescEntry.IndexOf("Description:") + 12)) : "");
							return;
						}
						default:
							if (projectType != Sims3Workshop.Data.ProjectType.MODULAR)
							{
								return;
							}
							break;
						}
						DBPFEntry dbpfentry = this.dbpfentry_0;
						if (this.dbpfentry_0 is MDLR)
						{
							dbpfentry = Class76.smethod_26((this.dbpfentry_0 as MDLR).TGIIndex[0]);
						}
						if (dbpfentry is OBJD)
						{
							OBJD objd = dbpfentry as OBJD;
							objd.GenerateResKey();
							this.unique.Visible = false;
							this.uniqueLabel.Visible = false;
							this.projectName.Text = objd.CatalogNameEntry.Replace("CatalogObjects/Name:", "") + "_Clone";
							this.unique.Text = objd.CatalogNameEntry + " Clone";
							this.title.Text = StringHelpers.FromCamelCase(objd.CatalogNameEntry.Replace("CatalogObjects/Name:", "")) + " clone";
							if ((objd.BuildCategoryFlags & 268435456U) != 0U)
							{
								this.description.Text = StringHelpers.FromCamelCase(objd.CatalogDescEntry.Replace("Gameplay/Objects/Blueprints:", ""));
							}
							else
							{
								this.description.Text = StringHelpers.FromCamelCase(objd.CatalogDescEntry.Replace("CatalogObjects/Description:", ""));
							}
							if (objd.DiagonalIndex >= 0 && objd.DiagonalIndex < objd.TgiIndex.Count)
							{
								this.diagonalChoice.Visible = true;
								this.diagonalChoice.Enabled = (objd.TgiIndex[objd.DiagonalIndex].TypeId != 832458525U);
							}
							else
							{
								MessageBox.Show(string.Concat(new object[]
								{
									"Error, diagonal index is ",
									objd.DiagonalIndex,
									" and tgiindex count is ",
									objd.TgiIndex.Count
								}));
							}
						}
						else if (this.dbpfentry_0 is FirePlace)
						{
							FirePlace firePlace = this.dbpfentry_0 as FirePlace;
							firePlace.GenerateResKey();
							this.unique.Visible = false;
							this.uniqueLabel.Visible = false;
							this.projectName.Text = firePlace.CatalogNameEntry.Replace("CatalogObjects/Name:", "") + "_Clone";
							this.unique.Text = firePlace.CatalogNameEntry + " Clone";
							this.title.Text = StringHelpers.FromCamelCase(firePlace.CatalogNameEntry.Replace("CatalogObjects/Name:", "")) + " clone";
							this.description.Text = StringHelpers.FromCamelCase(firePlace.CatalogDescEntry.Replace("CatalogObjects/Description:", ""));
						}
					}
				}
				else if (@class == this.clone && e.NewIndex < e.OldIndex)
				{
					e.NewIndex--;
				}
				else if (@class == this.details && e.NewIndex < e.OldIndex && this.bool_0)
				{
					e.NewIndex--;
				}
				IL_6DF:;
			}
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00030180 File Offset: 0x0002E380
		private void method_2(object sender, Wizard.EventArgs5 e)
		{
			this.status.Text = "";
			Class146 @class = this.wizard.Pages[e.NewIndex];
			int newIndex = e.NewIndex;
			int oldIndex = e.OldIndex;
			if (@class == this.clone)
			{
				this.projectType_0 = (Sims3Workshop.Data.ProjectType)this.projectTemplate.SelectedItems[0].Tag;
				Sims3Workshop.Data.ProjectType projectType = this.projectType_0;
				switch (projectType)
				{
				case Sims3Workshop.Data.ProjectType.CLOTHING:
					this.type_0 = CASP.Type.Body;
					this.string_0 = "Clothing";
					this.clone.Title = "Clothing clone";
					this.clone.Description = "Select a clothing item to clone, use the tree view to filter and select the category you are insterested in.";
					break;
				case Sims3Workshop.Data.ProjectType.MAKEUP:
					this.type_0 = CASP.Type.Face;
					this.string_0 = "Makeup/Overlay";
					this.clone.Title = "Makeup / Facial Overlay clone";
					this.clone.Description = "Select an overlay item to clone, use the tree view to filter and select the category you are insterested in.";
					break;
				case Sims3Workshop.Data.ProjectType.HAIR:
					this.type_0 = CASP.Type.Hair;
					this.string_0 = "Hair";
					this.clone.Title = "Hair clone";
					this.clone.Description = "Select a hair item to clone, use the tree view to filter and select the category you are insterested in.";
					break;
				case Sims3Workshop.Data.ProjectType.ACCESSORY:
					this.type_0 = CASP.Type.Accessories;
					this.string_0 = "Accessory";
					this.clone.Title = "Accessory clone";
					this.clone.Description = "Select an accessory item to clone, use the tree view to filter and select the category you are insterested in.";
					break;
				case (Sims3Workshop.Data.ProjectType)5:
					break;
				case Sims3Workshop.Data.ProjectType.OBJECT:
					this.string_0 = "Object";
					this.clone.Title = "Object clone";
					this.clone.Description = "Select an object to clone, use the tree view to filter and select the category you are insterested in.";
					break;
				case Sims3Workshop.Data.ProjectType.BUILD:
					this.string_0 = "Builditem";
					this.clone.Title = "Builditem clone";
					this.clone.Description = "Select builditem to clone, use the tree view to filer and select the category you are interesed in.";
					break;
				default:
					if (projectType == Sims3Workshop.Data.ProjectType.MODULAR)
					{
						this.string_0 = "Modular object";
						this.clone.Title = "Modular clone";
						this.clone.Description = "Select modular object to clone, use the tree view to filer and select the object you are interesed in.";
					}
					break;
				}
				this.treeView1.Nodes.Clear();
				this.items.Items.Clear();
				this.list_10 = null;
				this.filterSearch.Text = "";
				this.progress.Visible = true;
				this.status.Text = "Reading game data, please wait...";
				this.treeView1.Enabled = false;
				Wizard wizard = this.wizard;
				Wizard wizard2 = this.wizard;
				this.wizard.BackEnabled = false;
				wizard2.CancelEnabled = false;
				wizard.NextEnabled = false;
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.WorkerSupportsCancellation = false;
				backgroundWorker.DoWork += this.method_7;
				Sims3Workshop.Data.ProjectType projectType2 = this.projectType_0;
				switch (projectType2)
				{
				case Sims3Workshop.Data.ProjectType.OBJECT:
					backgroundWorker.RunWorkerCompleted += this.method_5;
					break;
				case Sims3Workshop.Data.ProjectType.BUILD:
					backgroundWorker.RunWorkerCompleted += this.method_3;
					break;
				default:
					if (projectType2 != Sims3Workshop.Data.ProjectType.MODULAR)
					{
						backgroundWorker.RunWorkerCompleted += this.method_6;
					}
					else
					{
						backgroundWorker.RunWorkerCompleted += this.method_4;
					}
					break;
				}
				backgroundWorker.RunWorkerAsync();
			}
			else if (@class == this.donePage)
			{
				this.wizard.BackEnabled = true;
			}
			else if (@class == this.import)
			{
				this.wizard.NextEnabled = (oldIndex > newIndex);
				this.wizard.BackEnabled = true;
				if (oldIndex < newIndex)
				{
					this.importFile.Text = "";
					this.projectTypeLabel.Text = "";
					this.nameLabel.Text = "";
					this.importImage.Image = null;
				}
			}
			else if (@class == this.details)
			{
				Class146 class2 = this.wizard.Pages[e.OldIndex];
				if (class2 == this.import)
				{
					this.bool_1 = true;
					List<ResKey> list = this.dbpf_0.SearchEntries(new ResKey(DBPFType.PACKDESC));
					if (list.Count > 0)
					{
						PackageDescriptor packageDescriptor = this.dbpf_0.GetEntry(list[0]) as PackageDescriptor;
						this.title.Text = packageDescriptor.Title;
						this.description.Text = packageDescriptor.Description;
						this.projectName.Text = this.workshopProject_0.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Name;
						this.diagonalChoice.Visible = false;
						switch (this.workshopProject_0.Type)
						{
						case Sims3Workshop.Data.ProjectType.CLOTHING:
						case Sims3Workshop.Data.ProjectType.HAIR:
						case Sims3Workshop.Data.ProjectType.ACCESSORY:
						{
							List<ResKey> list2 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.CASP));
							if (list2.Count > 0)
							{
								this.dbpfentry_0 = this.dbpf_0.GetEntry(list2[0]);
							}
							this.unique.Visible = true;
							break;
						}
						case Sims3Workshop.Data.ProjectType.OBJECT:
						case Sims3Workshop.Data.ProjectType.BUILD:
						{
							Control control = this.unique;
							this.uniqueLabel.Visible = false;
							control.Visible = false;
							break;
						}
						}
					}
					else
					{
						switch (this.workshopProject_0.Type)
						{
						case Sims3Workshop.Data.ProjectType.OBJECT:
						{
							List<ResKey> list3 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.OBJD));
							if (list3.Count < 1)
							{
								MessageBox.Show(this, "Could not locate any OBJD-files in this package", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								this.dbpfentry_0 = this.dbpf_0.GetEntry(list3[0]);
								Control control2 = this.unique;
								this.uniqueLabel.Visible = false;
								control2.Visible = false;
								this.diagonalChoice.Visible = true;
							}
							break;
						}
						case Sims3Workshop.Data.ProjectType.BUILD:
						{
							Control control3 = this.unique;
							this.uniqueLabel.Visible = false;
							control3.Visible = false;
							break;
						}
						}
					}
				}
				else
				{
					this.bool_1 = false;
				}
				this.projectName.SelectAll();
				this.projectName.Focus();
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00030768 File Offset: 0x0002E968
		private void method_3(object sender, RunWorkerCompletedEventArgs e)
		{
			this.progress.Visible = false;
			this.treeView1.TreeViewNodeSorter = null;
			Wizard wizard = this.wizard;
			this.wizard.BackEnabled = true;
			wizard.CancelEnabled = true;
			new Dictionary<Class38, TreeNode>();
			TreeNode treeNode = new TreeNode("Fences");
			treeNode.Tag = new Class38(DBPFType.CFENCE);
			this.treeView1.Nodes.Add(treeNode);
			this.treeNode_0 = new TreeNode("Walls");
			this.treeNode_0.Tag = new Class38(DBPFType.CFENCE);
			this.treeView1.Nodes.Add(this.treeNode_0);
			TreeNode treeNode2 = new TreeNode("Railings");
			treeNode2.Tag = new Class38(DBPFType.CRAILING);
			this.treeView1.Nodes.Add(treeNode2);
			TreeNode treeNode3 = new TreeNode("Stairs");
			treeNode3.Tag = new Class38(DBPFType.CSTAIRS);
			this.treeView1.Nodes.Add(treeNode3);
			TreeNode treeNode4 = new TreeNode("Roofs");
			treeNode4.Tag = new Class38((DBPFType)4058889606U);
			this.treeView1.Nodes.Add(treeNode4);
			TreeNode treeNode5 = new TreeNode("Terrain paint");
			treeNode5.Tag = new Class38(DBPFType.CTERRAINGEOM);
			this.treeView1.Nodes.Add(treeNode5);
			TreeNode treeNode6 = new TreeNode("Walls and floors");
			treeNode6.Tag = new Class38(DBPFType.CWALL);
			this.treeView1.Nodes.Add(treeNode6);
			this.status.Text = "Done";
			this.treeView1.Enabled = true;
			treeNode3.Expand();
			treeNode2.Expand();
			treeNode4.Expand();
			treeNode.Expand();
			this.treeNode_0.Expand();
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00030940 File Offset: 0x0002EB40
		private void method_4(object sender, RunWorkerCompletedEventArgs e)
		{
			this.progress.Visible = false;
			Wizard wizard = this.wizard;
			this.wizard.BackEnabled = true;
			wizard.CancelEnabled = true;
			Dictionary<Class39, TreeNode> dictionary = new Dictionary<Class39, TreeNode>();
			new Dictionary<Class39, TreeNode>();
			TreeNode treeNode = new TreeNode(this.string_0 + " By Category");
			List<TreeNode> list = new List<TreeNode>();
			foreach (object obj in NewProjectForm.list_1)
			{
				MDLR mdlr = (MDLR)obj;
				if (mdlr != null)
				{
					TGIIndex tgiindex = mdlr.TGIIndex[0];
					if (tgiindex.Type == DBPFType.OBJD)
					{
						OBJD objd = Class76.smethod_26(tgiindex) as OBJD;
						if (objd != null)
						{
							List<OBJD.Category> categoryFlags = objd.GetCategoryFlags();
							foreach (OBJD.Category category in categoryFlags)
							{
								Class39 @class = new Class39(category, ~OBJD.SubCategory.All, (OBJD.SubRoom)0UL, ~OBJD.Room.All, ~OBJD.Build.All);
								TreeNode treeNode2 = null;
								if (dictionary.ContainsKey(@class))
								{
									treeNode2 = dictionary[@class];
								}
								if (treeNode2 == null)
								{
									treeNode2 = new TreeNode(OBJD.CategoryLabels.ContainsKey(category) ? OBJD.CategoryLabels[category] : ("unknown category " + category));
									treeNode2.Tag = @class;
									dictionary.Add(@class, treeNode2);
									list.Add(treeNode2);
								}
							}
						}
					}
				}
			}
			List<TreeNode> list2 = list;
			if (NewProjectForm.comparison_0 == null)
			{
				NewProjectForm.comparison_0 = new Comparison<TreeNode>(NewProjectForm.smethod_0);
			}
			list2.Sort(NewProjectForm.comparison_0);
			treeNode.Nodes.AddRange(list.ToArray());
			this.treeView1.Nodes.Add(treeNode);
			this.status.Text = "Done";
			this.treeView1.Enabled = true;
			treeNode.Expand();
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00030B74 File Offset: 0x0002ED74
		private void method_5(object sender, RunWorkerCompletedEventArgs e)
		{
			this.progress.Visible = false;
			Wizard wizard = this.wizard;
			this.wizard.BackEnabled = true;
			wizard.CancelEnabled = true;
			Dictionary<Class39, TreeNode> dictionary = new Dictionary<Class39, TreeNode>();
			TreeNode treeNode = new TreeNode(this.string_0 + " By Category ");
			Class39 @class = new Class39((OBJD.Category)4254U, ~OBJD.SubCategory.All, (OBJD.SubRoom)0UL, ~OBJD.Room.All, ~OBJD.Build.All);
			treeNode.Tag = @class;
			dictionary.Add(@class, treeNode);
			TreeNode treeNode2 = new TreeNode(this.string_0 + " By Room ");
			Class39 class2 = new Class39((OBJD.Category)0U, ~OBJD.SubCategory.All, (OBJD.SubRoom)0UL, OBJD.Room.Study | OBJD.Room.CommunityLot | OBJD.Room.ResidentialLot, ~OBJD.Build.All);
			treeNode2.Tag = class2;
			dictionary.Add(class2, treeNode2);
			TreeNode treeNode3 = new TreeNode(this.string_0 + " By Buildtype ");
			Class39 class3 = new Class39((OBJD.Category)0U, ~OBJD.SubCategory.All, (OBJD.SubRoom)0UL, ~OBJD.Room.All, (OBJD.Build)511U);
			treeNode3.Tag = class3;
			dictionary.Add(class3, treeNode3);
			Dictionary<Class39, TreeNode> dictionary2 = new Dictionary<Class39, TreeNode>();
			Dictionary<Class39, TreeNode> dictionary3 = new Dictionary<Class39, TreeNode>();
			Dictionary<Class39, TreeNode> dictionary4 = new Dictionary<Class39, TreeNode>();
			Dictionary<Class39, TreeNode> dictionary5 = new Dictionary<Class39, TreeNode>();
			Dictionary<Class39, TreeNode> dictionary6 = new Dictionary<Class39, TreeNode>();
			List<TreeNode> list = new List<TreeNode>();
			List<TreeNode> list2 = new List<TreeNode>();
			List<TreeNode> list3 = new List<TreeNode>();
			new List<TreeNode>();
			foreach (object obj in NewProjectForm.list_2)
			{
				if (obj is OBJD)
				{
					OBJD objd = obj as OBJD;
					Class39 class4 = new Class39((OBJD.Category)0U, ~OBJD.SubCategory.All, (OBJD.SubRoom)0UL, ~OBJD.Room.All, ~OBJD.Build.All);
					TreeNode treeNode4 = null;
					if (dictionary2.ContainsKey(class4))
					{
						treeNode4 = dictionary2[class4];
					}
					if (treeNode4 == null)
					{
						treeNode4 = new TreeNode("Uncategorized objects");
						treeNode4.Tag = class4;
						dictionary2.Add(class4, treeNode4);
						list.Add(treeNode4);
					}
					List<OBJD.Category> categoryFlags = objd.GetCategoryFlags();
					foreach (OBJD.Category category in categoryFlags)
					{
						Class39 class5 = new Class39(category, ~OBJD.SubCategory.All, (OBJD.SubRoom)0UL, ~OBJD.Room.All, ~OBJD.Build.All);
						TreeNode treeNode5 = null;
						if (dictionary2.ContainsKey(class5))
						{
							treeNode5 = dictionary2[class5];
						}
						if (treeNode5 == null)
						{
							treeNode5 = new TreeNode(OBJD.CategoryLabels.ContainsKey(category) ? OBJD.CategoryLabels[category] : ("unknown category " + category));
							treeNode5.Tag = class5;
							dictionary2.Add(class5, treeNode5);
							list.Add(treeNode5);
						}
						List<OBJD.SubCategory> subCategoryFlags = objd.GetSubCategoryFlags();
						foreach (OBJD.SubCategory subCategory in subCategoryFlags)
						{
							Class39 class6 = new Class39(category, subCategory, (OBJD.SubRoom)0UL, ~OBJD.Room.All, ~OBJD.Build.All);
							TreeNode treeNode6 = null;
							if (dictionary3.ContainsKey(class6))
							{
								treeNode6 = dictionary3[class6];
							}
							if (treeNode6 == null)
							{
								if (OBJD.SubCategoryLabels.ContainsKey(subCategory))
								{
								}
								treeNode6 = new TreeNode(OBJD.SubCategoryLabels.ContainsKey(subCategory) ? OBJD.SubCategoryLabels[subCategory] : string.Concat(new object[]
								{
									subCategory,
									" (unlabeled ",
									subCategory.ToString(),
									")"
								}));
								treeNode6.Tag = class6;
								dictionary3.Add(class6, treeNode6);
								treeNode5.Nodes.Add(treeNode6);
							}
						}
					}
					List<OBJD.Room> roomFlags = objd.GetRoomFlags();
					foreach (OBJD.Room room in roomFlags)
					{
						Class39 class7 = new Class39((OBJD.Category)0U, ~OBJD.SubCategory.All, (OBJD.SubRoom)0UL, room, ~OBJD.Build.All);
						TreeNode treeNode7 = null;
						if (dictionary4.ContainsKey(class7))
						{
							treeNode7 = dictionary4[class7];
						}
						if (treeNode7 == null)
						{
							treeNode7 = new TreeNode(OBJD.RoomLabels.ContainsKey(room) ? OBJD.RoomLabels[room] : (room + " (unlabeled)"));
							treeNode7.Tag = class7;
							dictionary4.Add(class7, treeNode7);
							list2.Add(treeNode7);
						}
						List<OBJD.SubRoom> subRoomFlags = objd.GetSubRoomFlags();
						foreach (OBJD.SubRoom subRoom in subRoomFlags)
						{
							Class39 class8 = new Class39((OBJD.Category)0U, ~OBJD.SubCategory.All, subRoom, room, ~OBJD.Build.All);
							TreeNode treeNode8 = null;
							if (dictionary6.ContainsKey(class8))
							{
								treeNode8 = dictionary6[class8];
							}
							if (treeNode8 == null)
							{
								treeNode8 = new TreeNode(OBJD.SubRoomLabels.ContainsKey(subRoom) ? OBJD.SubRoomLabels[subRoom] : (subRoom + " (unlabeled)"));
								treeNode8.Tag = class8;
								dictionary6.Add(class8, treeNode8);
								treeNode7.Nodes.Add(treeNode8);
							}
						}
					}
					List<OBJD.Build> buildFlags = objd.GetBuildFlags();
					using (List<OBJD.Build>.Enumerator enumerator6 = buildFlags.GetEnumerator())
					{
						while (enumerator6.MoveNext())
						{
							OBJD.Build build = enumerator6.Current;
							if (build != OBJD.Build.Flower && build != OBJD.Build.Rug && build != OBJD.Build.Fireplace)
							{
								Class39 class9 = new Class39((OBJD.Category)0U, ~OBJD.SubCategory.All, (OBJD.SubRoom)0UL, ~OBJD.Room.All, build);
								TreeNode treeNode9 = null;
								if (dictionary5.ContainsKey(class9))
								{
									treeNode9 = dictionary5[class9];
								}
								if (treeNode9 == null)
								{
									treeNode9 = new TreeNode(OBJD.BuildLabels.ContainsKey(build) ? OBJD.BuildLabels[build] : (build + " (unlabeled)"));
									treeNode9.Tag = class9;
									dictionary5.Add(class9, treeNode9);
									list3.Add(treeNode9);
								}
							}
						}
						continue;
					}
				}
				if (obj is FirePlace)
				{
					Class39 class10 = new Class39((OBJD.Category)0U, ~OBJD.SubCategory.All, (OBJD.SubRoom)0UL, ~OBJD.Room.All, OBJD.Build.Fireplace);
					TreeNode treeNode10 = null;
					if (dictionary5.ContainsKey(class10))
					{
						treeNode10 = dictionary5[class10];
					}
					if (treeNode10 == null)
					{
						treeNode10 = new TreeNode(OBJD.BuildLabels.ContainsKey(OBJD.Build.Fireplace) ? OBJD.BuildLabels[OBJD.Build.Fireplace] : (OBJD.Build.Fireplace + " (unlabeled)"));
						treeNode10.Tag = class10;
						dictionary5.Add(class10, treeNode10);
						list3.Add(treeNode10);
					}
				}
			}
			List<TreeNode> list4 = list;
			if (NewProjectForm.comparison_1 == null)
			{
				NewProjectForm.comparison_1 = new Comparison<TreeNode>(NewProjectForm.smethod_1);
			}
			list4.Sort(NewProjectForm.comparison_1);
			List<TreeNode> list5 = list2;
			if (NewProjectForm.comparison_2 == null)
			{
				NewProjectForm.comparison_2 = new Comparison<TreeNode>(NewProjectForm.smethod_2);
			}
			list5.Sort(NewProjectForm.comparison_2);
			List<TreeNode> list6 = list3;
			if (NewProjectForm.comparison_3 == null)
			{
				NewProjectForm.comparison_3 = new Comparison<TreeNode>(NewProjectForm.smethod_3);
			}
			list6.Sort(NewProjectForm.comparison_3);
			treeNode.Nodes.AddRange(list.ToArray());
			treeNode2.Nodes.AddRange(list2.ToArray());
			treeNode3.Nodes.AddRange(list3.ToArray());
			this.treeView1.TreeViewNodeSorter = new Class40();
			this.treeView1.Nodes.Add(treeNode);
			this.treeView1.Nodes.Add(treeNode2);
			this.treeView1.Nodes.Add(treeNode3);
			this.status.Text = "Done";
			this.treeView1.Enabled = true;
			treeNode.Expand();
		}

		// Token: 0x06000298 RID: 664 RVA: 0x000313F0 File Offset: 0x0002F5F0
		private void method_6(object sender, RunWorkerCompletedEventArgs e)
		{
			this.progress.Visible = false;
			Wizard wizard = this.wizard;
			this.wizard.BackEnabled = true;
			wizard.CancelEnabled = true;
			Dictionary<Class36, TreeNode> dictionary = new Dictionary<Class36, TreeNode>();
			CASP.Type type = this.type_0;
			TreeNode treeNode = new TreeNode("Game " + this.string_0);
			Class36 @class = new Class36((CASP.Species)0U, CASP.AgeGender.None, type, CASP.ClothingCategory.None);
			treeNode.Tag = @class;
			dictionary.Add(@class, treeNode);
			Dictionary<Class36, TreeNode> dictionary2 = new Dictionary<Class36, TreeNode>();
			Dictionary<Class36, TreeNode> dictionary3 = new Dictionary<Class36, TreeNode>();
			Dictionary<Class36, TreeNode> dictionary4 = new Dictionary<Class36, TreeNode>();
			Dictionary<Class36, TreeNode> dictionary5 = new Dictionary<Class36, TreeNode>();
			foreach (CASP casp in NewProjectForm.list_0)
			{
				if (casp != null)
				{
					List<CASP.Species> species = casp.GetSpecies();
					foreach (CASP.Species species2 in species)
					{
						TreeNode treeNode2 = null;
						Class36 class2 = new Class36(species2, CASP.AgeGender.None, type, CASP.ClothingCategory.None);
						if (dictionary2.ContainsKey(class2))
						{
							treeNode2 = dictionary2[class2];
						}
						if (treeNode2 == null)
						{
							treeNode2 = new TreeNode(CASP.SpeciesLabels[species2]);
							treeNode2.Tag = class2;
							dictionary2.Add(class2, treeNode2);
							treeNode.Nodes.Add(treeNode2);
						}
						List<CASP.AgeGender> ages = casp.GetAges();
						foreach (CASP.AgeGender ageGender in ages)
						{
							Class36 class3 = new Class36(species2, ageGender, type, CASP.ClothingCategory.None);
							TreeNode treeNode3 = null;
							if (dictionary3.ContainsKey(class3))
							{
								treeNode3 = dictionary3[class3];
							}
							if (treeNode3 == null)
							{
								treeNode3 = new TreeNode(CASP.AgeGenderLabels[ageGender]);
								treeNode3.Tag = class3;
								dictionary3.Add(class3, treeNode3);
								treeNode2.Nodes.Add(treeNode3);
							}
							List<CASP.AgeGender> gendres = casp.GetGendres();
							foreach (CASP.AgeGender ageGender2 in gendres)
							{
								Class36 class4 = new Class36(species2, ageGender | ageGender2, type, CASP.ClothingCategory.None);
								TreeNode treeNode4 = null;
								if (dictionary4.ContainsKey(class4))
								{
									treeNode4 = dictionary4[class4];
								}
								if (treeNode4 == null)
								{
									treeNode4 = new TreeNode(CASP.AgeGenderLabels[ageGender2]);
									treeNode4.Tag = class4;
									dictionary4.Add(class4, treeNode4);
									treeNode3.Nodes.Add(treeNode4);
								}
								List<CASP.ClothingCategory> categories = casp.GetCategories();
								foreach (CASP.ClothingCategory clothingCategory in categories)
								{
									Class36 class5 = new Class36(species2, ageGender | ageGender2, type, clothingCategory);
									TreeNode treeNode5 = null;
									if (dictionary5.ContainsKey(class5))
									{
										treeNode5 = dictionary5[class5];
									}
									if (treeNode5 == null)
									{
										string text = CASP.CategoryLabels[clothingCategory];
										treeNode5 = new TreeNode(text);
										text.ToLower().Contains("firefigh");
										treeNode5.Tag = class5;
										dictionary5.Add(class5, treeNode5);
										treeNode4.Nodes.Add(treeNode5);
									}
								}
							}
						}
					}
				}
			}
			this.treeView1.TreeViewNodeSorter = new Class37();
			this.treeView1.Nodes.Add(treeNode);
			this.status.Text = "Done";
			this.treeView1.Enabled = true;
			treeNode.Expand();
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0003180C File Offset: 0x0002FA0C
		private void method_7(object sender, DoWorkEventArgs e)
		{
			Sims3Workshop.Data.ProjectType projectType = this.projectType_0;
			switch (projectType)
			{
			case Sims3Workshop.Data.ProjectType.OBJECT:
				this.method_10();
				break;
			case Sims3Workshop.Data.ProjectType.BUILD:
				this.method_8();
				break;
			default:
				if (projectType != Sims3Workshop.Data.ProjectType.MODULAR)
				{
					this.method_11();
				}
				else
				{
					this.method_9();
				}
				break;
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00031858 File Offset: 0x0002FA58
		private void method_8()
		{
			List<DBPFEntry> list = Class76.smethod_25(new ResKey(DBPFType.CSTAIRS, 0, 0, 0), true);
			NewProjectForm.list_3 = new List<STAIRS>(list.Count);
			foreach (DBPFEntry dbpfentry in list)
			{
				if (dbpfentry is STAIRS)
				{
					STAIRS stairs = dbpfentry as STAIRS;
					if (stairs.Version != 3U || stairs.Materials.Count != 0)
					{
						NewProjectForm.list_3.Add(dbpfentry as STAIRS);
					}
				}
			}
			List<DBPFEntry> list2 = Class76.smethod_25(new ResKey(DBPFType.CRAILING, 0, 0, 0), true);
			NewProjectForm.list_4 = new List<RAILING>(list2.Count);
			foreach (DBPFEntry dbpfentry2 in list2)
			{
				if (dbpfentry2 is RAILING)
				{
					RAILING railing = dbpfentry2 as RAILING;
					if (railing.Version != 3U || railing.Materials.Count != 0)
					{
						NewProjectForm.list_4.Add(dbpfentry2 as RAILING);
					}
				}
			}
			List<DBPFEntry> list3 = Class76.smethod_25(new ResKey(DBPFType.CFENCE, 0, 0, 0), true);
			NewProjectForm.list_5 = new List<FENCE>(list3.Count);
			NewProjectForm.list_6 = new List<FENCE>(list3.Count);
			foreach (DBPFEntry dbpfentry3 in list3)
			{
				if (dbpfentry3 is FENCE)
				{
					FENCE fence = dbpfentry3 as FENCE;
					if (fence.Version != 7U || fence.Materials.Count != 0)
					{
						if (fence.Version == 8U)
						{
							NewProjectForm.list_6.Add(dbpfentry3 as FENCE);
						}
						else
						{
							NewProjectForm.list_5.Add(dbpfentry3 as FENCE);
						}
					}
				}
			}
			List<DBPFEntry> list4 = Class76.smethod_25(new ResKey((DBPFType)4058889606U, 0, 0, 0), true);
			NewProjectForm.list_7 = new List<ROOF>(list4.Count);
			foreach (DBPFEntry dbpfentry4 in list4)
			{
				if (dbpfentry4 is ROOF)
				{
					NewProjectForm.list_7.Add(dbpfentry4 as ROOF);
				}
			}
			List<DBPFEntry> list5 = Class76.smethod_25(new ResKey(DBPFType.CTERRAINGEOM, 0, 0, 0), true);
			NewProjectForm.list_8 = new List<TerrainPaint>(list5.Count);
			foreach (DBPFEntry dbpfentry5 in list5)
			{
				if (dbpfentry5 is TerrainPaint && (byte)((dbpfentry5 as TerrainPaint).BuildItemType & BuildItem.BuildBuyProductStatusFlags.ShowInCatalog) != 0)
				{
					NewProjectForm.list_8.Add(dbpfentry5 as TerrainPaint);
				}
			}
			List<DBPFEntry> list6 = Class76.smethod_24(new ResKey(DBPFType.CWALL));
			NewProjectForm.list_9 = new List<WALL>(list6.Count);
			foreach (DBPFEntry dbpfentry6 in list6)
			{
				if (dbpfentry6 is WALL && (byte)((dbpfentry6 as WALL).BuildItemType & BuildItem.BuildBuyProductStatusFlags.ShowInCatalog) != 0)
				{
					NewProjectForm.list_9.Add(dbpfentry6 as WALL);
				}
			}
			List<ROOF> list7 = NewProjectForm.list_7;
			if (NewProjectForm.comparison_4 == null)
			{
				NewProjectForm.comparison_4 = new Comparison<ROOF>(NewProjectForm.smethod_4);
			}
			list7.Sort(NewProjectForm.comparison_4);
			List<FENCE> list8 = NewProjectForm.list_5;
			if (NewProjectForm.comparison_5 == null)
			{
				NewProjectForm.comparison_5 = new Comparison<FENCE>(NewProjectForm.smethod_5);
			}
			list8.Sort(NewProjectForm.comparison_5);
			List<FENCE> list9 = NewProjectForm.list_6;
			if (NewProjectForm.comparison_6 == null)
			{
				NewProjectForm.comparison_6 = new Comparison<FENCE>(NewProjectForm.smethod_6);
			}
			list9.Sort(NewProjectForm.comparison_6);
			List<RAILING> list10 = NewProjectForm.list_4;
			if (NewProjectForm.comparison_7 == null)
			{
				NewProjectForm.comparison_7 = new Comparison<RAILING>(NewProjectForm.smethod_7);
			}
			list10.Sort(NewProjectForm.comparison_7);
			List<STAIRS> list11 = NewProjectForm.list_3;
			if (NewProjectForm.comparison_8 == null)
			{
				NewProjectForm.comparison_8 = new Comparison<STAIRS>(NewProjectForm.smethod_8);
			}
			list11.Sort(NewProjectForm.comparison_8);
			List<TerrainPaint> list12 = NewProjectForm.list_8;
			if (NewProjectForm.comparison_9 == null)
			{
				NewProjectForm.comparison_9 = new Comparison<TerrainPaint>(NewProjectForm.smethod_9);
			}
			list12.Sort(NewProjectForm.comparison_9);
			List<WALL> list13 = NewProjectForm.list_9;
			if (NewProjectForm.comparison_10 == null)
			{
				NewProjectForm.comparison_10 = new Comparison<WALL>(NewProjectForm.smethod_10);
			}
			list13.Sort(NewProjectForm.comparison_10);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00031CFC File Offset: 0x0002FEFC
		private void method_9()
		{
			List<DBPFEntry> list = Class76.smethod_25(new ResKey((DBPFType)3482995406U, 0, 0, 0), true);
			NewProjectForm.list_1 = new List<object>();
			foreach (DBPFEntry dbpfentry in list)
			{
				if (dbpfentry is MDLR)
				{
					NewProjectForm.list_1.Add(dbpfentry as MDLR);
				}
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00031D7C File Offset: 0x0002FF7C
		private void method_10()
		{
			List<DBPFEntry> list = Class76.smethod_25(new ResKey(DBPFType.OBJD, 0, 0, 0), true);
			NewProjectForm.list_2 = new List<object>();
			foreach (DBPFEntry dbpfentry in list)
			{
				if (dbpfentry is OBJD && ((dbpfentry as OBJD).BuildCategoryFlags & 268435456U) == 0U)
				{
					NewProjectForm.list_2.Add(dbpfentry as OBJD);
				}
			}
			List<DBPFEntry> list2 = Class76.smethod_25(new ResKey(DBPFType.FIREPLACE, 0, 0, 0), true);
			foreach (DBPFEntry dbpfentry2 in list2)
			{
				if (dbpfentry2 is FirePlace)
				{
					NewProjectForm.list_2.Add(dbpfentry2 as FirePlace);
				}
			}
			List<object> list3 = NewProjectForm.list_2;
			if (NewProjectForm.comparison_11 == null)
			{
				NewProjectForm.comparison_11 = new Comparison<object>(NewProjectForm.smethod_11);
			}
			list3.Sort(NewProjectForm.comparison_11);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00031E9C File Offset: 0x0003009C
		private void method_11()
		{
			if (NewProjectForm.list_0 == null)
			{
				List<DBPFEntry> list = Class76.smethod_25(new ResKey(55242443U, 0, 0, 0), true);
				NewProjectForm.list_0 = new List<CASP>(list.Count);
				foreach (DBPFEntry dbpfentry in list)
				{
					if (dbpfentry is CASP)
					{
						NewProjectForm.list_0.Add((CASP)dbpfentry);
					}
				}
				List<CASP> list2 = NewProjectForm.list_0;
				if (NewProjectForm.comparison_12 == null)
				{
					NewProjectForm.comparison_12 = new Comparison<CASP>(NewProjectForm.smethod_12);
				}
				list2.Sort(NewProjectForm.comparison_12);
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00031F54 File Offset: 0x00030154
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			Sims3Workshop.Data.ProjectType projectType = this.projectType_0;
			switch (projectType)
			{
			case Sims3Workshop.Data.ProjectType.OBJECT:
				this.method_14();
				break;
			case Sims3Workshop.Data.ProjectType.BUILD:
				this.method_12();
				break;
			default:
				if (projectType != Sims3Workshop.Data.ProjectType.MODULAR)
				{
					this.method_15();
				}
				else
				{
					this.method_13();
				}
				break;
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00031FA0 File Offset: 0x000301A0
		private void method_12()
		{
			this.items.Clear();
			this.items.Groups.Clear();
			this.wizard.NextEnabled = false;
			this.dbpfentry_0 = null;
			Class38 @class = (Class38)this.treeView1.SelectedNode.Tag;
			this.imageList_0 = new ImageList
			{
				ImageSize = new Size(100, 100),
				ColorDepth = ColorDepth.Depth32Bit
			};
			int num = 0;
			DBPF dbpf = null;
			string text = Class76.smethod_4() + "\\The Sims 3\\Thumbnails\\ObjectThumbnails.package";
			if (File.Exists(text))
			{
				dbpf = new DBPF(text);
			}
			if (@class.Type == DBPFType.CWALL)
			{
				foreach (WALL wall in NewProjectForm.list_9)
				{
					ListViewItem listViewItem = new ListViewItem(string.IsNullOrEmpty(wall.CatalogNameEntry) ? "No name" : StringHelpers.FromCamelCase((wall.CatalogNameEntry.IndexOf("Name:") != -1) ? wall.CatalogNameEntry.Substring(wall.CatalogNameEntry.IndexOf("Name:") + 5) : wall.CatalogNameEntry));
					PNG png = Class76.smethod_5(Class76.Enum14.const_0, new ResKey(95532326U, 0, wall.InstanceID, wall.SecondInstanceID)) as PNG;
					if (wall.PngIcon != 0L)
					{
						int instanceId = (int)(wall.PngIcon >> 32 & 4294967295L);
						int secondInstanceId = (int)(wall.PngIcon & 4294967295L);
						List<ResKey> list = Class76.smethod_20(new ResKey(DBPFType.PNG_THUMB_MEDIUM, 0, instanceId, secondInstanceId), 0, false);
						if (list.Count > 0)
						{
							png = (Class76.smethod_26(list[0]) as PNG);
						}
					}
					listViewItem.Tag = wall;
					if (png != null)
					{
						listViewItem.ImageIndex = num;
						this.imageList_0.Images.Add(png.Image);
						num++;
					}
					this.items.Items.Add(listViewItem);
				}
			}
			if (@class.Type == DBPFType.CTERRAINGEOM)
			{
				foreach (TerrainPaint terrainPaint in NewProjectForm.list_8)
				{
					ListViewItem listViewItem2 = new ListViewItem(string.IsNullOrEmpty(terrainPaint.CatalogNameEntry) ? "No name" : StringHelpers.FromCamelCase((terrainPaint.CatalogNameEntry.IndexOf("Name:") != -1) ? terrainPaint.CatalogNameEntry.Substring(terrainPaint.CatalogNameEntry.IndexOf("Name:") + 5) : terrainPaint.CatalogNameEntry));
					PNG png2 = Class76.smethod_5(Class76.Enum14.const_0, new ResKey(95532326U, 0, terrainPaint.InstanceID, terrainPaint.SecondInstanceID)) as PNG;
					if (terrainPaint.PngIcon != 0L)
					{
						int instanceId2 = (int)(terrainPaint.PngIcon >> 32 & 4294967295L);
						int secondInstanceId2 = (int)(terrainPaint.PngIcon & 4294967295L);
						List<ResKey> list2 = Class76.smethod_20(new ResKey(DBPFType.PNG_THUMB_MEDIUM, 0, instanceId2, secondInstanceId2), 0, false);
						if (list2.Count > 0)
						{
							png2 = (Class76.smethod_26(list2[0]) as PNG);
						}
					}
					listViewItem2.Tag = terrainPaint;
					if (png2 != null)
					{
						listViewItem2.ImageIndex = num;
						this.imageList_0.Images.Add(png2.Image);
						num++;
					}
					this.items.Items.Add(listViewItem2);
				}
			}
			if (@class.Type == DBPFType.CSTAIRS)
			{
				using (List<STAIRS>.Enumerator enumerator3 = NewProjectForm.list_3.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						STAIRS stairs = enumerator3.Current;
						ListViewItem listViewItem3 = new ListViewItem(string.IsNullOrEmpty(stairs.CatalogNameEntry) ? "No name" : StringHelpers.FromCamelCase(stairs.CatalogNameEntry.Substring(stairs.CatalogNameEntry.IndexOf("Name:") + 5)));
						PNG png3 = Class76.smethod_5(Class76.Enum14.const_0, new ResKey(1575607202U, 0, stairs.InstanceID, stairs.SecondInstanceID)) as PNG;
						if (stairs.PngIcon != 0L)
						{
							int instanceId3 = (int)(stairs.PngIcon >> 32 & 4294967295L);
							int secondInstanceId3 = (int)(stairs.PngIcon & 4294967295L);
							List<ResKey> list3 = Class76.smethod_20(new ResKey(DBPFType.PNG_THUMB_MEDIUM, 0, instanceId3, secondInstanceId3), 0, false);
							if (list3.Count > 0)
							{
								png3 = (Class76.smethod_26(list3[0]) as PNG);
							}
						}
						if (png3 == null && dbpf != null)
						{
							png3 = (dbpf.GetEntry(new ResKey(1575607201U, 0, stairs.InstanceID, stairs.SecondInstanceID)) as PNG);
						}
						listViewItem3.Tag = stairs;
						if (png3 != null)
						{
							listViewItem3.ImageIndex = num;
							this.imageList_0.Images.Add(png3.Image);
							num++;
						}
						this.items.Items.Add(listViewItem3);
					}
					goto IL_919;
				}
			}
			if (@class.Type == DBPFType.CRAILING)
			{
				using (List<RAILING>.Enumerator enumerator4 = NewProjectForm.list_4.GetEnumerator())
				{
					while (enumerator4.MoveNext())
					{
						RAILING railing = enumerator4.Current;
						ListViewItem listViewItem4 = new ListViewItem(string.IsNullOrEmpty(railing.CatalogNameEntry) ? "No name" : StringHelpers.FromCamelCase((railing.CatalogNameEntry.IndexOf("Name:") != -1) ? railing.CatalogNameEntry.Substring(railing.CatalogNameEntry.IndexOf("Name:") + 5) : railing.CatalogNameEntry));
						PNG png4 = Class76.smethod_5(Class76.Enum14.const_0, new ResKey(759334130U, 0, railing.InstanceID, railing.SecondInstanceID)) as PNG;
						if (railing.PngIcon != 0L)
						{
							int instanceId4 = (int)(railing.PngIcon >> 32 & 4294967295L);
							int secondInstanceId4 = (int)(railing.PngIcon & 4294967295L);
							List<ResKey> list4 = Class76.smethod_20(new ResKey(DBPFType.PNG_THUMB_MEDIUM, 0, instanceId4, secondInstanceId4), 0, false);
							if (list4.Count > 0)
							{
								png4 = (Class76.smethod_26(list4[0]) as PNG);
							}
						}
						if (png4 == null && dbpf != null)
						{
							png4 = (dbpf.GetEntry(new ResKey(759334129U, 0, railing.InstanceID, railing.SecondInstanceID)) as PNG);
						}
						listViewItem4.Tag = railing;
						if (png4 != null)
						{
							listViewItem4.ImageIndex = num;
							this.imageList_0.Images.Add(png4.Image);
							num++;
						}
						this.items.Items.Add(listViewItem4);
					}
					goto IL_919;
				}
			}
			if (@class.Type == DBPFType.CFENCE)
			{
				List<FENCE> list5 = this.treeView1.SelectedNode.Equals(this.treeNode_0) ? NewProjectForm.list_6 : NewProjectForm.list_5;
				foreach (FENCE fence in list5)
				{
					ListViewItem listViewItem5 = new ListViewItem(string.IsNullOrEmpty(fence.CatalogNameEntry) ? "No name" : StringHelpers.FromCamelCase(fence.CatalogNameEntry.Substring(fence.CatalogNameEntry.IndexOf("Name:") + 5)));
					PNG png5 = Class76.smethod_5(Class76.Enum14.const_0, new ResKey(643032010U, 0, fence.InstanceID, fence.SecondInstanceID)) as PNG;
					if (fence.PngIcon != 0L)
					{
						int instanceId5 = (int)(fence.PngIcon >> 32 & 4294967295L);
						int secondInstanceId5 = (int)(fence.PngIcon & 4294967295L);
						List<ResKey> list6 = Class76.smethod_20(new ResKey(DBPFType.PNG_THUMB_MEDIUM, 0, instanceId5, secondInstanceId5), 0, false);
						if (list6.Count > 0)
						{
							png5 = (Class76.smethod_26(list6[0]) as PNG);
						}
					}
					if (png5 == null && dbpf != null)
					{
						png5 = (dbpf.GetEntry(new ResKey(643032009U, 0, fence.InstanceID, fence.SecondInstanceID)) as PNG);
						if (png5 == null)
						{
							List<ResKey> list7 = dbpf.SearchEntries(new ResKey(DBPFType.ALL, 0, fence.InstanceID, fence.SecondInstanceID));
							if (list7.Count > 0)
							{
								png5 = (dbpf.GetEntry(list7[0]) as PNG);
							}
						}
					}
					if (png5 == null)
					{
						png5 = (Class76.smethod_5(Class76.Enum14.const_0, new ResKey(643032009U, 0, fence.InstanceID, fence.SecondInstanceID)) as PNG);
						if (png5 == null)
						{
							png5 = (Class76.smethod_5(Class76.Enum14.const_0, new ResKey(643032008U, 0, fence.InstanceID, fence.SecondInstanceID)) as PNG);
						}
					}
					listViewItem5.Tag = fence;
					if (png5 != null)
					{
						listViewItem5.ImageIndex = num;
						this.imageList_0.Images.Add(png5.Image);
						num++;
					}
					this.items.Items.Add(listViewItem5);
				}
			}
			IL_919:
			if (@class.Type == (DBPFType)4058889606U)
			{
				foreach (ROOF roof in NewProjectForm.list_7)
				{
					ListViewItem listViewItem6 = new ListViewItem(string.IsNullOrEmpty(roof.CatalogNameEntry) ? "No name" : StringHelpers.FromCamelCase(roof.CatalogNameEntry.Substring(roof.CatalogNameEntry.IndexOf("Name:") + 5)));
					PNG png6 = Class76.smethod_5(Class76.Enum14.const_0, new ResKey(92316342U, 0, roof.InstanceID, roof.SecondInstanceID)) as PNG;
					if (roof.PngIcon != 0L)
					{
						int instanceId6 = (int)(roof.PngIcon >> 32 & 4294967295L);
						int secondInstanceId6 = (int)(roof.PngIcon & 4294967295L);
						List<ResKey> list8 = Class76.smethod_20(new ResKey(DBPFType.PNG_THUMB_MEDIUM, 0, instanceId6, secondInstanceId6), 0, false);
						if (list8.Count > 0)
						{
							png6 = (Class76.smethod_26(list8[0]) as PNG);
						}
					}
					if (png6 == null && dbpf != null)
					{
						png6 = (dbpf.GetEntry(new ResKey(92316342U, 0, roof.InstanceID, roof.SecondInstanceID)) as PNG);
						if (png6 == null)
						{
							List<ResKey> list9 = dbpf.SearchEntries(new ResKey(DBPFType.ALL, 0, roof.InstanceID, roof.SecondInstanceID));
							if (list9.Count > 0)
							{
								png6 = (dbpf.GetEntry(list9[0]) as PNG);
							}
						}
					}
					listViewItem6.Tag = roof;
					if (png6 != null)
					{
						listViewItem6.ImageIndex = num;
						this.imageList_0.Images.Add(png6.Image);
						num++;
					}
					this.items.Items.Add(listViewItem6);
				}
			}
			this.items.LargeImageList = this.imageList_0;
			this.list_10 = null;
			this.filterSearch.Text = "";
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00032B54 File Offset: 0x00030D54
		private void method_13()
		{
			this.imageList_0 = new ImageList
			{
				ImageSize = new Size(100, 100),
				ColorDepth = ColorDepth.Depth32Bit
			};
			this.items.Clear();
			this.items.Groups.Clear();
			Class39 @class = (Class39)this.treeView1.SelectedNode.Tag;
			if (!Class39.smethod_0(@class, null))
			{
				int num = 0;
				foreach (object obj in NewProjectForm.list_1)
				{
					MDLR mdlr = (MDLR)obj;
					if (mdlr != null && mdlr.TGIIndex.Count > 0)
					{
						TGIIndex tgiindex = mdlr.TGIIndex[0];
						if (tgiindex.Type == DBPFType.OBJD)
						{
							OBJD objd = Class76.smethod_26(tgiindex) as OBJD;
							if (objd != null && @class.method_0((OBJD.Category)objd.CategoryFlags, (OBJD.SubCategory)objd.SubCategoryFlags, (OBJD.SubRoom)objd.SubRoomFlags, (OBJD.Room)objd.RoomFlags, (OBJD.Build)objd.BuildCategoryFlags))
							{
								ListViewItem listViewItem = new ListViewItem(string.IsNullOrEmpty(objd.CatalogNameEntry) ? "No name" : StringHelpers.FromCamelCase((objd.Version >= 22U) ? objd.DAEFilename : objd.CatalogNameEntry.Replace("CatalogObjects/Name:", "")));
								PNG png = Class76.smethod_5(Class76.Enum14.const_0, new ResKey(92316342U, objd.GroupID, objd.InstanceID, objd.SecondInstanceID)) as PNG;
								if (objd.PngIcon != 0L)
								{
									int instanceId = (int)(objd.PngIcon >> 32 & 4294967295L);
									int secondInstanceId = (int)(objd.PngIcon & 4294967295L);
									List<ResKey> list = Class76.smethod_20(new ResKey(DBPFType.PNG_THUMB_MEDIUM, 0, instanceId, secondInstanceId), 0, false);
									if (list.Count > 0)
									{
										png = (Class76.smethod_26(list[0]) as PNG);
									}
								}
								Bitmap bitmap;
								if (png == null)
								{
									bitmap = Class143.empty;
								}
								else
								{
									bitmap = png.Image;
								}
								if (bitmap != null)
								{
									listViewItem.ImageIndex = num;
									this.imageList_0.Images.Add(bitmap);
									listViewItem.Tag = mdlr;
									this.items.Items.Add(listViewItem);
									num++;
								}
							}
						}
					}
				}
				this.items.LargeImageList = this.imageList_0;
				this.list_10 = null;
				this.filterSearch.Text = "";
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00032E04 File Offset: 0x00031004
		private void method_14()
		{
			this.items.Clear();
			this.items.Groups.Clear();
			this.wizard.NextEnabled = false;
			this.dbpfentry_0 = null;
			this.imageList_0 = new ImageList
			{
				ImageSize = new Size(100, 100),
				ColorDepth = ColorDepth.Depth32Bit
			};
			Class39 @class = (Class39)this.treeView1.SelectedNode.Tag;
			int num = 0;
			foreach (object obj in NewProjectForm.list_2)
			{
				if (obj is OBJD)
				{
					OBJD objd = obj as OBJD;
					if (objd.BuildCategoryFlags != 64U)
					{
						objd.ResKey.ToString();
						bool flag = @class.method_0((OBJD.Category)objd.CategoryFlags, (OBJD.SubCategory)objd.SubCategoryFlags, (OBJD.SubRoom)objd.SubRoomFlags, (OBJD.Room)objd.RoomFlags, (OBJD.Build)objd.BuildCategoryFlags);
						if (@class.All == 0)
						{
							flag = (objd.CategoryFlags == 0U && objd.BuildCategoryFlags == 0U && objd.RoomFlags == 0U);
						}
						if (flag)
						{
							ListViewItem listViewItem = new ListViewItem(string.IsNullOrEmpty(objd.CatalogNameEntry) ? "No name" : StringHelpers.FromCamelCase((objd.Version >= 22U) ? objd.DAEFilename : objd.CatalogNameEntry.Replace("CatalogObjects/Name:", "")));
							PNG png = Class76.smethod_5(Class76.Enum14.const_0, new ResKey(92316342U, objd.GroupID, objd.InstanceID, objd.SecondInstanceID)) as PNG;
							if (objd.PngIcon != 0L)
							{
								int instanceId = (int)(objd.PngIcon >> 32 & 4294967295L);
								int secondInstanceId = (int)(objd.PngIcon & 4294967295L);
								List<ResKey> list = Class76.smethod_20(new ResKey(DBPFType.PNG_THUMB_MEDIUM, 0, instanceId, secondInstanceId), 0, false);
								if (list.Count > 0)
								{
									png = (Class76.smethod_26(list[0]) as PNG);
								}
							}
							Bitmap bitmap;
							if (png == null)
							{
								bitmap = Class143.empty;
							}
							else
							{
								bitmap = png.Image;
							}
							if (bitmap != null)
							{
								listViewItem.ImageIndex = num;
								this.imageList_0.Images.Add(bitmap);
								listViewItem.Tag = objd;
								this.items.Items.Add(listViewItem);
								num++;
							}
						}
					}
				}
				else if (obj is FirePlace && @class.BuildMask == OBJD.Build.Fireplace)
				{
					FirePlace firePlace = obj as FirePlace;
					ListViewItem listViewItem2 = new ListViewItem(string.IsNullOrEmpty(firePlace.CatalogNameEntry) ? "No name" : StringHelpers.FromCamelCase(firePlace.CatalogNameEntry.Replace("CatalogObjects/Name:", "")));
					PNG png2 = Class76.smethod_5(Class76.Enum14.const_0, new ResKey(92316342U, firePlace.GroupID, firePlace.InstanceID, firePlace.SecondInstanceID)) as PNG;
					if (png2 != null)
					{
						listViewItem2.ImageIndex = num;
						this.imageList_0.Images.Add(png2.Image);
						listViewItem2.Tag = firePlace;
						this.items.Items.Add(listViewItem2);
						num++;
					}
				}
			}
			this.items.LargeImageList = this.imageList_0;
			this.list_10 = null;
			this.filterSearch.Text = "";
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00033180 File Offset: 0x00031380
		private void method_15()
		{
			this.items.Clear();
			this.items.Groups.Clear();
			this.wizard.NextEnabled = false;
			this.dbpfentry_0 = null;
			this.imageList_0 = new ImageList
			{
				ImageSize = new Size(100, 100),
				ColorDepth = ColorDepth.Depth32Bit
			};
			Class36 @class = (Class36)this.treeView1.SelectedNode.Tag;
			int num = 0;
			Dictionary<string, ListViewGroup> dictionary = new Dictionary<string, ListViewGroup>();
			foreach (CASP casp in NewProjectForm.list_0)
			{
				if (@class.method_0((CASP.Species)casp.ageFlags, (CASP.AgeGender)casp.ageFlags, (CASP.Type)casp.typeFlags, (CASP.ClothingCategory)casp.clothingCategoryFlags))
				{
					string text = "";
					if (@class.AgeMask == CASP.AgeGender.None)
					{
						List<CASP.AgeGender> ages = casp.GetAges();
						bool flag = true;
						foreach (CASP.AgeGender key in ages)
						{
							text = text + (flag ? "" : "/ ") + CASP.AgeGenderLabels[key] + " ";
							flag = false;
						}
					}
					CASP.AgeGender ageGender = @class.AgeMask & CASP.AgeGender.GenderMask;
					if (ageGender == CASP.AgeGender.None)
					{
						if (@class.AgeMask == CASP.AgeGender.None)
						{
							text += " - ";
						}
						List<CASP.AgeGender> gendres = casp.GetGendres();
						bool flag2 = true;
						foreach (CASP.AgeGender key2 in gendres)
						{
							text = text + (flag2 ? "" : "/ ") + CASP.AgeGenderLabels[key2] + " ";
							flag2 = false;
						}
					}
					if (@class.CategoryMask == CASP.ClothingCategory.None)
					{
						if (ageGender == CASP.AgeGender.None)
						{
							text += " - ";
						}
						List<CASP.ClothingCategory> categories = casp.GetCategories();
						bool flag3 = true;
						foreach (CASP.ClothingCategory key3 in categories)
						{
							text = text + (flag3 ? "" : "/ ") + CASP.CategoryLabels[key3] + " ";
							flag3 = false;
						}
					}
					if (text == "")
					{
						text = string.Concat(new string[]
						{
							CASP.AgeGenderLabels[@class.AgeMask & CASP.AgeGender.AgeMask],
							" - ",
							CASP.AgeGenderLabels[@class.AgeMask & CASP.AgeGender.GenderMask],
							" - ",
							CASP.CategoryLabels[@class.CategoryMask]
						});
					}
					if (!dictionary.ContainsKey(text))
					{
						dictionary.Add(text, new ListViewGroup(text));
					}
					ListViewItem listViewItem = new ListViewItem(casp.str1, dictionary[text]);
					PNG png = Class76.smethod_5(Class76.Enum14.const_1, new ResKey(1651466445U, casp.GroupID, casp.InstanceID, casp.SecondInstanceID)) as PNG;
					if (png != null)
					{
						listViewItem.ImageIndex = num;
						this.imageList_0.Images.Add(png.Image);
						listViewItem.Tag = casp;
						num++;
					}
					else
					{
						Bitmap bitmap = new Bitmap(128, 128);
						Graphics.FromImage(bitmap).FillRectangle(Brushes.Beige, new Rectangle(0, 0, 128, 128));
						this.imageList_0.Images.Add(bitmap);
						listViewItem.ImageIndex = num;
						listViewItem.Tag = casp;
						num++;
					}
					this.items.Items.Add(listViewItem);
				}
			}
			ArrayList arrayList = new ArrayList(dictionary.Keys);
			arrayList.Sort();
			foreach (object arg in arrayList)
			{
				this.items.Groups.Add(dictionary[string.Concat(arg)]);
			}
			this.items.LargeImageList = this.imageList_0;
			this.list_10 = null;
			this.filterSearch.Text = "";
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00033654 File Offset: 0x00031854
		private void items_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.items.SelectedItems.Count != 1)
			{
				this.wizard.NextEnabled = false;
			}
			else
			{
				this.dbpfentry_0 = (DBPFEntry)this.items.SelectedItems[0].Tag;
				this.wizard.NextEnabled = true;
				this.dbpfentry_0.GenerateResKey();
			}
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x000336C0 File Offset: 0x000318C0
		private void method_16(object sender, EventArgs e)
		{
			this.workshopProject_0 = new WorkshopProject(this.projectName.Text + ".wrk");
			this.workshopProject_0.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Name = this.projectName.Text;
			this.workshopProject_0.Type = this.projectType_0;
			if (this.bool_0)
			{
				this.dbpf_0.ReadEntries();
				this.workshopProject_0.Package = this.dbpf_0;
				this.workshopProject_0.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Name = this.projectName.Text;
			}
			else
			{
				Random random = new Random((int)DateTime.Now.Ticks);
				PackageDescriptor packageDescriptor = new PackageDescriptor();
				Sims3Workshop.Data.ProjectType type = this.workshopProject_0.Type;
				switch (type)
				{
				case Sims3Workshop.Data.ProjectType.CLOTHING:
				case Sims3Workshop.Data.ProjectType.MAKEUP:
				case Sims3Workshop.Data.ProjectType.HAIR:
				case Sims3Workshop.Data.ProjectType.ACCESSORY:
				{
					try
					{
						Class68.smethod_1(this.dbpfentry_0 as CASP, this.workshopProject_0.Package, this.preserveGroupId.Checked, this.int_0);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Could not clone CAS Part\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					this.workshopProject_0.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Name = this.projectName.Text;
					string str = string.IsNullOrEmpty(this.title.Text) ? "New CAS Project" : this.title.Text;
					string str2 = string.IsNullOrEmpty(this.description.Text) ? "No Description" : this.description.Text;
					packageDescriptor.Manifest.Add("version", 3);
					packageDescriptor.Manifest.Add("packagetype", "CASpart");
					packageDescriptor.Manifest.Add("paidcontent", "false");
					packageDescriptor.Title = StringHelpers.XmlValue(str);
					packageDescriptor.Description = StringHelpers.XmlValue(str2);
					this.workshopProject_0.Package.AddEntry(packageDescriptor);
					goto IL_10BC;
				}
				case (Sims3Workshop.Data.ProjectType)5:
					goto IL_10BC;
				case Sims3Workshop.Data.ProjectType.OBJECT:
					break;
				case Sims3Workshop.Data.ProjectType.BUILD:
					goto IL_CC0;
				default:
					switch (type)
					{
					case Sims3Workshop.Data.ProjectType.STAIRS:
					case Sims3Workshop.Data.ProjectType.FENCE:
					case Sims3Workshop.Data.ProjectType.RAILING:
					case Sims3Workshop.Data.ProjectType.WALL:
					case Sims3Workshop.Data.ProjectType.FLOOR:
					case Sims3Workshop.Data.ProjectType.ROOF:
					case Sims3Workshop.Data.ProjectType.TERRAIN:
						goto IL_CC0;
					default:
						if (type != Sims3Workshop.Data.ProjectType.MODULAR)
						{
							goto IL_10BC;
						}
						break;
					}
					break;
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				DBPFEntry dbpfentry = this.dbpfentry_0;
				if (this.dbpfentry_0 is MDLR)
				{
					this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.OBJECT;
					dbpfentry = Class76.smethod_26((this.dbpfentry_0 as MDLR).TGIIndex[0]);
				}
				if (dbpfentry is OBJD)
				{
					OBJD objd = null;
					try
					{
						if (dbpfentry is OBJD && ((dbpfentry as OBJD).BuildCategoryFlags & 268435456U) != 0U)
						{
							objd = Class26.smethod_2(dbpfentry as OBJD, this.title.Text, this.workshopProject_0.Package, this.preserveGroupId.Checked, this.int_0, dictionary, this.dbpfentry_0 is MDLR, this.dbpfentry_0);
						}
						else
						{
							objd = Class80.smethod_1(dbpfentry as OBJD, this.title.Text, this.workshopProject_0.Package, this.preserveGroupId.Checked, this.int_0, dictionary, this.dbpfentry_0 is MDLR, this.dbpfentry_0);
						}
					}
					catch (Exception ex2)
					{
						MessageBox.Show("Could not clone OBJD Part\n\n" + ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					string str3 = string.IsNullOrEmpty(this.title.Text) ? "New OBJD Project" : this.title.Text;
					string str4 = string.IsNullOrEmpty(this.description.Text) ? "No Description" : this.description.Text;
					packageDescriptor.Manifest.Add("version", 3);
					packageDescriptor.Manifest.Add("packagetype", "object");
					packageDescriptor.Manifest.Add("paidcontent", "false");
					packageDescriptor.Title = StringHelpers.XmlValue(str3);
					packageDescriptor.Description = StringHelpers.XmlValue(str4);
					this.workshopProject_0.Package.AddEntry(packageDescriptor);
					if (this.dbpf_0 != null)
					{
						ResKey search = new ResKey(DBPFType.STBL);
						List<ResKey> list = this.dbpf_0.SearchEntries(search);
						using (List<ResKey>.Enumerator enumerator = list.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								ResKey key = enumerator.Current;
								STBL stbl = this.dbpf_0.GetEntry(key) as STBL;
								if (stbl.HasEntry((ulong)(dbpfentry as OBJD).NameGuid) || stbl.HasEntry((ulong)(dbpfentry as OBJD).DescGuid))
								{
									stbl.ChangeKey((ulong)(dbpfentry as OBJD).NameGuid, (ulong)objd.NameGuid);
									stbl.ChangeKey((ulong)(dbpfentry as OBJD).DescGuid, (ulong)objd.DescGuid);
									stbl.Entries[(ulong)objd.NameGuid].Text = this.title.Text;
									stbl.Entries[(ulong)objd.DescGuid].Text = this.description.Text;
									stbl.SecondInstanceID = objd.SecondInstanceID;
									this.workshopProject_0.Package.AddEntry(stbl);
								}
							}
							goto IL_61E;
						}
					}
					ResKey search2 = new ResKey(DBPFType.STBL);
					List<ResKey> list2 = this.workshopProject_0.Package.SearchEntries(search2);
					foreach (ResKey key2 in list2)
					{
						STBL stbl2 = this.workshopProject_0.Package.GetEntry(key2) as STBL;
						if (stbl2.HasEntry((ulong)objd.NameGuid) || stbl2.HasEntry((ulong)objd.DescGuid))
						{
							stbl2.Entries[(ulong)objd.NameGuid].Text = this.title.Text;
							stbl2.Entries[(ulong)objd.DescGuid].Text = this.description.Text;
						}
					}
					IL_61E:
					if (this.checkBox1.Enabled && this.checkBox1.Checked)
					{
						try
						{
							dictionary.Clear();
							OBJD objd2 = Class80.smethod_1(dbpfentry as OBJD, this.title.Text + " diagonal", this.workshopProject_0.Package, this.preserveGroupId.Checked, this.int_0, dictionary, this.dbpfentry_0 is MDLR, this.dbpfentry_0);
							objd2.DAEFilename += "Diag";
							TGIIndex item = new TGIIndex(objd2.GenerateResKey());
							objd.TgiIndex.Add(item);
							objd.DiagonalIndex = objd.TgiIndex.IndexOf(item);
							if (objd.Materials.Count > 0)
							{
								foreach (OBJD.Material material in objd2.Materials)
								{
									foreach (OBJD.Material.ComplateVariable complateVariable in material.Blocks[0].Variables)
									{
										if (complateVariable.VariableName.ToLower() == "daefilename")
										{
											complateVariable.SetValue(1, objd2.DAEFilename);
										}
									}
								}
							}
							objd2.WallPlacement = OBJD.WallPlacementFlags.WF01To10Diag;
							objd2.ObjectType |= OBJD.ObjectTypeFlags.IsDiagonal;
							OBJD objd3 = objd2;
							objd3.BuildBuyStatus ^= OBJD.BuildBuyProductStatusFlags.ShowInCatalog;
							TGIIndex item2 = new TGIIndex(objd.GenerateResKey());
							objd2.TgiIndex.Add(item2);
							objd2.DiagonalIndex = objd2.TgiIndex.IndexOf(item2);
							MessageBox.Show("This project do not have a default diagonal mesh so you need to update mesh, slots and footprints for the diagonal version manually.", "Diagonal item", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						catch (Exception ex3)
						{
							MessageBox.Show("Could not clone the diagonal OBJD Part\n\n" + ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return;
						}
					}
					if (dbpfentry is OBJD && ((dbpfentry as OBJD).BuildCategoryFlags & 268435456U) != 0U)
					{
						this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.BLUEPRINT;
						goto IL_10BC;
					}
					goto IL_10BC;
				}
				else
				{
					if (!(this.dbpfentry_0 is FirePlace))
					{
						goto IL_10BC;
					}
					FirePlace firePlace = this.dbpfentry_0.Clone() as FirePlace;
					firePlace.GroupID = this.int_0;
					firePlace.InstanceID = random.Next();
					firePlace.SecondInstanceID = random.Next();
					this.workshopProject_0.Package.AddEntry(firePlace);
					firePlace.CatalogNameEntry = "CatalogObjects/Name:" + StringHelpers.ToCamelCase(this.title.Text);
					firePlace.CatalogDescEntry = ((this.description.Text != "") ? ("CatalogObjects/Description:" + StringHelpers.ToCamelCase(this.description.Text)) : "");
					for (int i = 0; i < 7; i++)
					{
						if (firePlace.Index[i] != -1)
						{
							TGIIndex tgiindex = firePlace.TGIIndex[firePlace.Index[i]];
							ResKey resKey_ = new ResKey(tgiindex.AsString());
							OBJD objd4 = Class76.smethod_26(resKey_) as OBJD;
							if (objd4 == null)
							{
								Console.WriteLine("Could not clone resource: " + tgiindex.AsString());
							}
							else
							{
								try
								{
									string catalogNameEntry = objd4.CatalogNameEntry;
									string catalogDescEntry = objd4.CatalogDescEntry;
									OBJD objd5 = Class80.smethod_1(objd4, this.title.Text, this.workshopProject_0.Package, this.preserveGroupId.Checked, this.int_0, dictionary, false, null);
									if ((objd5.BuildCategoryFlags & 64U) == 0U)
									{
										objd5.CatalogDescEntry = catalogDescEntry;
										objd5.CatalogNameEntry = catalogNameEntry;
									}
									tgiindex.SetFromResKey(objd5.ResKey.ReplaceType(tgiindex.TypeId));
								}
								catch (Exception ex4)
								{
									MessageBox.Show("Could not clone OBJD Part\n\n" + ex4.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									return;
								}
							}
						}
					}
					string str5 = string.IsNullOrEmpty(this.title.Text) ? "New OBJD Project" : this.title.Text;
					string str6 = string.IsNullOrEmpty(this.description.Text) ? "No Description" : this.description.Text;
					packageDescriptor.Manifest.Add("version", 3);
					packageDescriptor.Manifest.Add("packagetype", "object");
					packageDescriptor.Manifest.Add("paidcontent", "false");
					packageDescriptor.Title = StringHelpers.XmlValue(str5);
					packageDescriptor.Description = StringHelpers.XmlValue(str6);
					this.workshopProject_0.Package.AddEntry(packageDescriptor);
					if (this.dbpf_0 != null)
					{
						ResKey search3 = new ResKey(DBPFType.STBL);
						List<ResKey> list3 = this.dbpf_0.SearchEntries(search3);
						using (List<ResKey>.Enumerator enumerator = list3.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								ResKey key3 = enumerator.Current;
								STBL stbl3 = this.dbpf_0.GetEntry(key3) as STBL;
								if (stbl3.HasEntry((ulong)(this.dbpfentry_0 as FirePlace).NameGuid) || stbl3.HasEntry((ulong)(this.dbpfentry_0 as FirePlace).DescGuid))
								{
									stbl3.ChangeKey((ulong)(this.dbpfentry_0 as FirePlace).NameGuid, (ulong)firePlace.NameGuid);
									stbl3.ChangeKey((ulong)(this.dbpfentry_0 as FirePlace).DescGuid, (ulong)firePlace.DescGuid);
									stbl3.SecondInstanceID = firePlace.SecondInstanceID;
									this.workshopProject_0.Package.AddEntry(stbl3);
								}
							}
							goto IL_10BC;
						}
					}
					ResKey search4 = new ResKey(DBPFType.STBL);
					List<ResKey> list4 = this.workshopProject_0.Package.SearchEntries(search4);
					using (List<ResKey>.Enumerator enumerator = list4.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ResKey key4 = enumerator.Current;
							STBL stbl4 = this.workshopProject_0.Package.GetEntry(key4) as STBL;
							if (stbl4.HasEntry((ulong)firePlace.NameGuid) || stbl4.HasEntry((ulong)firePlace.DescGuid))
							{
								stbl4.Entries[(ulong)firePlace.NameGuid].Text = this.title.Text;
								stbl4.Entries[(ulong)firePlace.DescGuid].Text = this.description.Text;
							}
						}
						goto IL_10BC;
					}
				}
				IL_CC0:
				string text = string.IsNullOrEmpty(this.title.Text) ? "New Builditem Project" : this.title.Text;
				string text2 = string.IsNullOrEmpty(this.description.Text) ? "No Description" : this.description.Text;
				BuildItem buildItem = null;
				try
				{
					buildItem = Class86.smethod_0(this.dbpfentry_0 as BuildItem, text, this.workshopProject_0.Package);
				}
				catch (Exception ex5)
				{
					MessageBox.Show("Could not clone builditem Part\n\n" + ex5.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				DBPFType typeID = buildItem.TypeID;
				if (typeID <= DBPFType.CRAILING)
				{
					if (typeID != DBPFType.CFENCE)
					{
						if (typeID != DBPFType.CSTAIRS)
						{
							if (typeID == DBPFType.CRAILING)
							{
								this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.RAILING;
							}
						}
						else
						{
							this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.STAIRS;
						}
					}
					else
					{
						this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.FENCE;
					}
				}
				else if (typeID != DBPFType.CTERRAINGEOM)
				{
					if (typeID != DBPFType.CWALL)
					{
						if (typeID == (DBPFType)4058889606U)
						{
							this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.ROOF;
						}
					}
					else
					{
						this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.WALL;
					}
				}
				else
				{
					this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.TERRAIN;
				}
				this.workshopProject_0.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Name = this.projectName.Text;
				buildItem.CatalogNameEntry = buildItem.CatalogNameEntry.Substring(0, buildItem.CatalogNameEntry.IndexOf("Name:") + 5) + text;
				buildItem.CatalogDescEntry = ((buildItem.CatalogDescEntry.IndexOf("Description:") == -1) ? text2 : (buildItem.CatalogDescEntry.Substring(0, buildItem.CatalogNameEntry.IndexOf("Name:")) + "Description:" + text2));
				packageDescriptor.Manifest.Add("version", 3);
				packageDescriptor.Manifest.Add("packagetype", "object");
				packageDescriptor.Manifest.Add("paidcontent", "false");
				packageDescriptor.Title = StringHelpers.XmlValue(text);
				packageDescriptor.Description = StringHelpers.XmlValue(text2);
				this.workshopProject_0.Package.AddEntry(packageDescriptor);
				if (this.dbpf_0 != null)
				{
					ResKey search5 = new ResKey(DBPFType.STBL);
					List<ResKey> list5 = this.dbpf_0.SearchEntries(search5);
					using (List<ResKey>.Enumerator enumerator = list5.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ResKey key5 = enumerator.Current;
							STBL stbl5 = this.dbpf_0.GetEntry(key5) as STBL;
							if (stbl5.HasEntry((ulong)(this.dbpfentry_0 as BuildItem).NameGuid) || stbl5.HasEntry((ulong)(this.dbpfentry_0 as BuildItem).DescGuid))
							{
								stbl5.ChangeKey((ulong)(this.dbpfentry_0 as BuildItem).NameGuid, (ulong)buildItem.NameGuid);
								stbl5.ChangeKey((ulong)(this.dbpfentry_0 as BuildItem).DescGuid, (ulong)buildItem.DescGuid);
								stbl5.SecondInstanceID = buildItem.SecondInstanceID;
								this.workshopProject_0.Package.AddEntry(stbl5);
							}
						}
						goto IL_10BC;
					}
				}
				ResKey search6 = new ResKey(DBPFType.STBL);
				List<ResKey> list6 = this.workshopProject_0.Package.SearchEntries(search6);
				foreach (ResKey key6 in list6)
				{
					STBL stbl6 = this.workshopProject_0.Package.GetEntry(key6) as STBL;
					if (stbl6.HasEntry((ulong)buildItem.NameGuid) || stbl6.HasEntry((ulong)buildItem.DescGuid))
					{
						stbl6.Entries[(ulong)buildItem.NameGuid].Text = this.title.Text;
						stbl6.Entries[(ulong)buildItem.DescGuid].Text = this.description.Text;
					}
				}
			}
			IL_10BC:
			if (this.bool_1)
			{
				List<ResKey> list7 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.DDS, 0, 0, 0));
				List<ResKey> list8 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.PRESET, 0, 0, 0));
				List<ResKey> list9 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.FABC, 0, 0, 0));
				int seed = (int)DateTime.Now.Ticks;
				Random random2 = new Random(seed);
				foreach (ResKey key7 in list7)
				{
					DBPFEntry entry = this.dbpf_0.GetEntry(key7);
					ResKey from = entry.ResKey.Clone();
					ResKey resKey = entry.ResKey.CloneUnique(Math.Abs(random2.Next()));
					int num = 0;
					foreach (DBPFEntry dbpfentry2 in this.workshopProject_0.Package.Entries.Values)
					{
						num += dbpfentry2.ReplaceReferences(from, resKey);
					}
					entry.ResKey = resKey;
					this.workshopProject_0.Package.AddEntry(entry);
				}
				foreach (ResKey key8 in list8)
				{
					DBPFEntry entry2 = this.dbpf_0.GetEntry(key8);
					ResKey from2 = entry2.ResKey.Clone();
					ResKey resKey2 = entry2.ResKey.CloneUnique(Math.Abs(random2.Next()));
					int num2 = 0;
					foreach (DBPFEntry dbpfentry3 in this.workshopProject_0.Package.Entries.Values)
					{
						num2 += dbpfentry3.ReplaceReferences(from2, resKey2);
					}
					if (num2 > 0)
					{
						entry2.ResKey = resKey2;
						this.workshopProject_0.Package.AddEntry(entry2);
					}
				}
				foreach (ResKey key9 in list9)
				{
					DBPFEntry entry3 = this.dbpf_0.GetEntry(key9);
					ResKey from3 = entry3.ResKey.Clone();
					ResKey resKey3 = entry3.ResKey.CloneUnique(Math.Abs(random2.Next()));
					int num3 = 0;
					foreach (DBPFEntry dbpfentry4 in this.workshopProject_0.Package.Entries.Values)
					{
						num3 += dbpfentry4.ReplaceReferences(from3, resKey3);
					}
					if (num3 > 0)
					{
						entry3.ResKey = resKey3;
						this.workshopProject_0.Package.AddEntry(entry3);
					}
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000399D File Offset: 0x00001B9D
		private void projectTemplate_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.wizard.method_0();
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000399D File Offset: 0x00001B9D
		private void items_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.wizard.method_0();
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00034C70 File Offset: 0x00032E70
		private void browse_Click(object sender, EventArgs e)
		{
			this.wizard.NextEnabled = false;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "TSR Workshop project (*.wrk)|*.wrk|Package (*.package)|*.package|Sims3Pack (*.sims3pack)|*.sims3pack";
			this.projectTypeLabel.Text = "";
			this.nameLabel.Text = "";
			this.importImage.Image = null;
			if (openFileDialog.ShowDialog(base.ParentForm) == DialogResult.OK)
			{
				this.importFile.Text = openFileDialog.FileName;
				try
				{
					List<DBPF> list = new List<DBPF>();
					if (this.importFile.Text.ToLower().Contains(".package"))
					{
						this.workshopProject_0 = new WorkshopProject("");
						list.Add(new DBPF(this.importFile.Text));
					}
					else if (this.importFile.Text.ToLower().Contains(".wrk"))
					{
						this.workshopProject_0 = WorkshopProject.smethod_1(this.importFile.Text);
						list.Add(this.workshopProject_0.Package);
					}
					else if (this.importFile.Text.ToLower().Contains(".sims3pack"))
					{
						this.workshopProject_0 = new WorkshopProject("");
						Sims3Package sims3Package = new Sims3Package(this.importFile.Text);
						foreach (object obj in sims3Package.PackagedFiles)
						{
							if (obj is DBPF)
							{
								list.Add(obj as DBPF);
							}
						}
					}
					foreach (DBPF dbpf in list)
					{
						this.dbpf_0 = dbpf;
						List<ResKey> list2 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.ALL));
						foreach (ResKey resKey in list2)
						{
							DBPFEntry entry = this.dbpf_0.GetEntry(resKey);
							if (entry != null)
							{
								Class76.smethod_28(resKey, entry);
							}
						}
						list2 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.CSTAIRS));
						if (list2.Count > 0)
						{
							this.dbpfentry_0 = this.dbpf_0.GetEntry(list2[0]);
							this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.STAIRS;
							this.projectType_0 = Sims3Workshop.Data.ProjectType.STAIRS;
							this.projectTypeLabel.Text = this.projectType_0.ToString();
							this.wizard.NextEnabled = true;
						}
						else
						{
							list2 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.CRAILING));
							if (list2.Count > 0)
							{
								this.dbpfentry_0 = this.dbpf_0.GetEntry(list2[0]);
								this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.RAILING;
								this.projectType_0 = Sims3Workshop.Data.ProjectType.RAILING;
								this.projectTypeLabel.Text = this.projectType_0.ToString();
								this.wizard.NextEnabled = true;
							}
							else
							{
								list2 = this.dbpf_0.SearchEntries(new ResKey((DBPFType)4058889606U));
								if (list2.Count > 0)
								{
									this.dbpfentry_0 = this.dbpf_0.GetEntry(list2[0]);
									this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.ROOF;
									this.projectType_0 = Sims3Workshop.Data.ProjectType.ROOF;
									this.projectTypeLabel.Text = this.projectType_0.ToString();
									this.wizard.NextEnabled = true;
								}
								else
								{
									list2 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.CFENCE));
									if (list2.Count > 0)
									{
										this.dbpfentry_0 = this.dbpf_0.GetEntry(list2[0]);
										this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.FENCE;
										this.projectType_0 = Sims3Workshop.Data.ProjectType.FENCE;
										this.projectTypeLabel.Text = this.projectType_0.ToString();
										this.wizard.NextEnabled = true;
									}
									else
									{
										list2 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.CWALL));
										if (list2.Count > 0)
										{
											this.dbpfentry_0 = this.dbpf_0.GetEntry(list2[0]);
											this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.BUILD;
											this.projectType_0 = Sims3Workshop.Data.ProjectType.BUILD;
											this.projectTypeLabel.Text = this.projectType_0.ToString();
											this.wizard.NextEnabled = true;
										}
										else
										{
											list2 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.OBJD));
											if (list2.Count > 0)
											{
												this.dbpfentry_0 = this.dbpf_0.GetEntry(list2[0]);
												this.workshopProject_0.Type = Sims3Workshop.Data.ProjectType.OBJECT;
												this.projectType_0 = Sims3Workshop.Data.ProjectType.OBJECT;
												this.projectTypeLabel.Text = this.projectType_0.ToString();
												this.wizard.NextEnabled = true;
											}
											else
											{
												list2 = this.dbpf_0.SearchEntries(new ResKey(DBPFType.CASP));
												if (list2.Count <= 0)
												{
													MessageBox.Show(Class132.mainForm, "Found no suitable entries in package", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
													break;
												}
												this.dbpfentry_0 = this.dbpf_0.GetEntry(list2[0]);
												this.projectType_0 = Sims3Workshop.Data.ProjectType.CLOTHING;
												this.projectTypeLabel.Text = this.projectType_0.ToString();
												this.wizard.NextEnabled = true;
											}
										}
									}
								}
							}
						}
						this.nameLabel.Text = this.workshopProject_0.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Name;
						if (this.workshopProject_0.Sims3WorkshopSDK.Interfaces.IWorkshopProject.ThumbnailData != null)
						{
							MemoryStream memoryStream = new MemoryStream(this.workshopProject_0.Sims3WorkshopSDK.Interfaces.IWorkshopProject.ThumbnailData);
							this.importImage.Image = Image.FromStream(memoryStream);
							memoryStream.Dispose();
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(Class132.mainForm, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x000352E4 File Offset: 0x000334E4
		private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.items.SelectedItems.Count > 0)
			{
				ListViewItem listViewItem = this.items.SelectedItems[0];
				object tag = listViewItem.Tag;
				string text = tag.ToString();
				if (tag is BuildItem)
				{
					text = string.Concat(new object[]
					{
						"Type: Builditem\nReskey: ",
						(tag as BuildItem).GenerateResKey(),
						"\nLocated in: ",
						(tag as DBPFEntry).Package
					});
				}
				else if (tag is OBJD)
				{
					text = string.Concat(new object[]
					{
						"Type: Object\nReskey: ",
						(tag as OBJD).GenerateResKey(),
						"\nLocated in: ",
						(tag as DBPFEntry).Package
					});
				}
				else if (tag is MDLR)
				{
					text = string.Concat(new object[]
					{
						"Type: Modular\nReskey: ",
						(tag as OBJD).GenerateResKey(),
						"\nLocated in: ",
						(tag as DBPFEntry).Package
					});
				}
				else if (tag is CASP)
				{
					text = string.Concat(new object[]
					{
						"Type: CAS Part\nReskey: ",
						(tag as CASP).GenerateResKey(),
						"\nLocated in: ",
						(tag as DBPFEntry).Package
					});
				}
				MessageBox.Show(Class132.mainForm, text, "Iteminfo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00035464 File Offset: 0x00033664
		private void copyReskeyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.items.SelectedItems.Count > 0)
			{
				ListViewItem listViewItem = this.items.SelectedItems[0];
				object tag = listViewItem.Tag;
				if (tag is DBPFEntry)
				{
					Clipboard.SetText((tag as DBPFEntry).GenerateResKey());
				}
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000354B8 File Offset: 0x000336B8
		private void filterSearch_TextChanged(object sender, EventArgs e)
		{
			if (this.list_10 == null)
			{
				this.list_10 = new List<ListViewItem>();
				foreach (object obj in this.items.Items)
				{
					ListViewItem item = (ListViewItem)obj;
					this.list_10.Add(item);
				}
			}
			this.items.BeginUpdate();
			this.items.Clear();
			foreach (ListViewItem listViewItem in this.list_10)
			{
				if (listViewItem.Text.ToLower().Contains(this.filterSearch.Text.ToLower()) || string.IsNullOrEmpty(this.filterSearch.Text))
				{
					this.items.Items.Add(listViewItem);
				}
			}
			this.items.EndUpdate();
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00002A71 File Offset: 0x00000C71
		private void panel6_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060002AC RID: 684 RVA: 0x000039AC File Offset: 0x00001BAC
		private void filterSearch_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.filterSearch.Text = "";
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000039CA File Offset: 0x00001BCA
		private void filterSearch_Enter(object sender, EventArgs e)
		{
			this.filterSearch.Select();
		}

		// Token: 0x060002AE RID: 686 RVA: 0x000039D9 File Offset: 0x00001BD9
		private void preserveGroupId_CheckedChanged(object sender, EventArgs e)
		{
			this.newGroupId.Enabled = !this.preserveGroupId.Checked;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00002A71 File Offset: 0x00000C71
		private void method_17(object sender, EventArgs e)
		{
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x000355D8 File Offset: 0x000337D8
		private void newGroupId_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int num = Convert.ToInt32(this.newGroupId.Text, 16);
				this.int_0 = num;
				this.newGroupId.BackColor = Color.White;
			}
			catch (Exception)
			{
				this.newGroupId.BackColor = Color.FromArgb(255, 255, 200, 200);
			}
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x000039F6 File Offset: 0x00001BF6
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0003767C File Offset: 0x0003587C
		[CompilerGenerated]
		private static int smethod_0(TreeNode treeNode_1, TreeNode treeNode_2)
		{
			return treeNode_2.Text.CompareTo(treeNode_1.Text);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0003767C File Offset: 0x0003587C
		[CompilerGenerated]
		private static int smethod_1(TreeNode treeNode_1, TreeNode treeNode_2)
		{
			return treeNode_2.Text.CompareTo(treeNode_1.Text);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0003767C File Offset: 0x0003587C
		[CompilerGenerated]
		private static int smethod_2(TreeNode treeNode_1, TreeNode treeNode_2)
		{
			return treeNode_2.Text.CompareTo(treeNode_1.Text);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0003767C File Offset: 0x0003587C
		[CompilerGenerated]
		private static int smethod_3(TreeNode treeNode_1, TreeNode treeNode_2)
		{
			return treeNode_2.Text.CompareTo(treeNode_1.Text);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x000376A0 File Offset: 0x000358A0
		[CompilerGenerated]
		private static int smethod_4(ROOF roof_0, ROOF roof_1)
		{
			return StringHelpers.FromCamelCase(roof_0.CatalogNameEntry.Replace("CatalogObjects/Name:", "")).CompareTo(StringHelpers.FromCamelCase(roof_1.CatalogNameEntry.Replace("CatalogObjects/Name:", "")));
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x000376A0 File Offset: 0x000358A0
		[CompilerGenerated]
		private static int smethod_5(FENCE fence_0, FENCE fence_1)
		{
			return StringHelpers.FromCamelCase(fence_0.CatalogNameEntry.Replace("CatalogObjects/Name:", "")).CompareTo(StringHelpers.FromCamelCase(fence_1.CatalogNameEntry.Replace("CatalogObjects/Name:", "")));
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x000376A0 File Offset: 0x000358A0
		[CompilerGenerated]
		private static int smethod_6(FENCE fence_0, FENCE fence_1)
		{
			return StringHelpers.FromCamelCase(fence_0.CatalogNameEntry.Replace("CatalogObjects/Name:", "")).CompareTo(StringHelpers.FromCamelCase(fence_1.CatalogNameEntry.Replace("CatalogObjects/Name:", "")));
		}

		// Token: 0x060002BA RID: 698 RVA: 0x000376A0 File Offset: 0x000358A0
		[CompilerGenerated]
		private static int smethod_7(RAILING railing_0, RAILING railing_1)
		{
			return StringHelpers.FromCamelCase(railing_0.CatalogNameEntry.Replace("CatalogObjects/Name:", "")).CompareTo(StringHelpers.FromCamelCase(railing_1.CatalogNameEntry.Replace("CatalogObjects/Name:", "")));
		}

		// Token: 0x060002BB RID: 699 RVA: 0x000376EC File Offset: 0x000358EC
		[CompilerGenerated]
		private static int smethod_8(STAIRS stairs_0, STAIRS stairs_1)
		{
			string s = stairs_0.CatalogNameEntry.Replace("CatalogObjects/Name:", "");
			string s2 = stairs_1.CatalogNameEntry.Replace("CatalogObjects/Name:", "");
			return StringHelpers.FromCamelCase(s).CompareTo(StringHelpers.FromCamelCase(s2));
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000376A0 File Offset: 0x000358A0
		[CompilerGenerated]
		private static int smethod_9(TerrainPaint terrainPaint_0, TerrainPaint terrainPaint_1)
		{
			return StringHelpers.FromCamelCase(terrainPaint_0.CatalogNameEntry.Replace("CatalogObjects/Name:", "")).CompareTo(StringHelpers.FromCamelCase(terrainPaint_1.CatalogNameEntry.Replace("CatalogObjects/Name:", "")));
		}

		// Token: 0x060002BD RID: 701 RVA: 0x000376A0 File Offset: 0x000358A0
		[CompilerGenerated]
		private static int smethod_10(WALL wall_0, WALL wall_1)
		{
			return StringHelpers.FromCamelCase(wall_0.CatalogNameEntry.Replace("CatalogObjects/Name:", "")).CompareTo(StringHelpers.FromCamelCase(wall_1.CatalogNameEntry.Replace("CatalogObjects/Name:", "")));
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0003773C File Offset: 0x0003593C
		[CompilerGenerated]
		private static int smethod_11(object object_0, object object_1)
		{
			string text = "";
			if (object_0 is OBJD)
			{
				StringHelpers.FromCamelCase(((object_0 as OBJD).CatalogNameEntry == null) ? "" : (object_0 as OBJD).CatalogNameEntry.Replace("CatalogObjects/Name:", ""));
			}
			else if (object_0 is FirePlace)
			{
				StringHelpers.FromCamelCase(((object_0 as FirePlace).CatalogNameEntry == null) ? "" : (object_0 as FirePlace).CatalogNameEntry.Replace("CatalogObjects/Name:", ""));
			}
			string strB = "";
			if (object_1 is OBJD)
			{
				StringHelpers.FromCamelCase(((object_1 as OBJD).CatalogNameEntry == null) ? "" : (object_1 as OBJD).CatalogNameEntry.Replace("CatalogObjects/Name:", ""));
			}
			else if (object_1 is FirePlace)
			{
				StringHelpers.FromCamelCase(((object_1 as FirePlace).CatalogNameEntry == null) ? "" : (object_1 as FirePlace).CatalogNameEntry.Replace("CatalogObjects/Name:", ""));
			}
			return text.CompareTo(strB);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00037854 File Offset: 0x00035A54
		[CompilerGenerated]
		private static int smethod_12(CASP casp_0, CASP casp_1)
		{
			int result;
			if (casp_0.str1 != null && casp_1.str1 != null)
			{
				result = casp_0.str1.CompareTo(casp_1.str1);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x04000234 RID: 564
		private WorkshopProject workshopProject_0;

		// Token: 0x04000235 RID: 565
		private CASP.Type type_0;

		// Token: 0x04000236 RID: 566
		private Sims3Workshop.Data.ProjectType projectType_0;

		// Token: 0x04000237 RID: 567
		private string string_0 = "";

		// Token: 0x04000238 RID: 568
		private static List<CASP> list_0;

		// Token: 0x04000239 RID: 569
		private static List<object> list_1;

		// Token: 0x0400023A RID: 570
		private static List<object> list_2;

		// Token: 0x0400023B RID: 571
		private static List<STAIRS> list_3;

		// Token: 0x0400023C RID: 572
		private static List<RAILING> list_4;

		// Token: 0x0400023D RID: 573
		private static List<FENCE> list_5;

		// Token: 0x0400023E RID: 574
		private static List<FENCE> list_6;

		// Token: 0x0400023F RID: 575
		private static List<ROOF> list_7;

		// Token: 0x04000240 RID: 576
		private static List<TerrainPaint> list_8;

		// Token: 0x04000241 RID: 577
		private static List<WALL> list_9;

		// Token: 0x04000242 RID: 578
		private DBPFEntry dbpfentry_0;

		// Token: 0x04000243 RID: 579
		private bool bool_0;

		// Token: 0x04000244 RID: 580
		private bool bool_1;

		// Token: 0x04000245 RID: 581
		private DBPF dbpf_0;

		// Token: 0x04000246 RID: 582
		private TreeNode treeNode_0;

		// Token: 0x04000247 RID: 583
		private ImageList imageList_0;

		// Token: 0x04000248 RID: 584
		private List<ListViewItem> list_10;

		// Token: 0x04000249 RID: 585
		private int int_0;

		// Token: 0x0400027D RID: 637
		[CompilerGenerated]
		private static Comparison<TreeNode> comparison_0;

		// Token: 0x0400027E RID: 638
		[CompilerGenerated]
		private static Comparison<TreeNode> comparison_1;

		// Token: 0x0400027F RID: 639
		[CompilerGenerated]
		private static Comparison<TreeNode> comparison_2;

		// Token: 0x04000280 RID: 640
		[CompilerGenerated]
		private static Comparison<TreeNode> comparison_3;

		// Token: 0x04000281 RID: 641
		[CompilerGenerated]
		private static Comparison<ROOF> comparison_4;

		// Token: 0x04000282 RID: 642
		[CompilerGenerated]
		private static Comparison<FENCE> comparison_5;

		// Token: 0x04000283 RID: 643
		[CompilerGenerated]
		private static Comparison<FENCE> comparison_6;

		// Token: 0x04000284 RID: 644
		[CompilerGenerated]
		private static Comparison<RAILING> comparison_7;

		// Token: 0x04000285 RID: 645
		[CompilerGenerated]
		private static Comparison<STAIRS> comparison_8;

		// Token: 0x04000286 RID: 646
		[CompilerGenerated]
		private static Comparison<TerrainPaint> comparison_9;

		// Token: 0x04000287 RID: 647
		[CompilerGenerated]
		private static Comparison<WALL> comparison_10;

		// Token: 0x04000288 RID: 648
		[CompilerGenerated]
		private static Comparison<object> comparison_11;

		// Token: 0x04000289 RID: 649
		[CompilerGenerated]
		private static Comparison<CASP> comparison_12;
	}
}
