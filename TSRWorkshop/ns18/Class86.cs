using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns0;
using ns11;
using ns13;
using ns16;
using ns2;
using ns3;
using ns4;
using ns5;
using ns6;
using ns7;
using ns8;
using Package;
using Package.Helper;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Package.Squish;
using Sims3Workshop.Data;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using VisualHint.SmartPropertyGrid;

namespace ns18
{
	// Token: 0x020000BF RID: 191
	internal sealed class Class86 : IProjectModel
	{
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x0007270C File Offset: 0x0007090C
		// (set) Token: 0x060007F8 RID: 2040 RVA: 0x00005B74 File Offset: 0x00003D74
		public Class106 Renderable { get; set; }

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x00072724 File Offset: 0x00070924
		public BuildItemModelControl Control
		{
			get
			{
				return this.buildItemModelControl_0;
			}
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0007273C File Offset: 0x0007093C
		public Class86(WorkshopProject project, Sims3Workshop.Data.ProjectType projectType)
		{
			this.lod_0 = Class132.mainForm.GetCurrentLOD();
			if (this.lod_0 != Lod.High)
			{
				this.lod_0 = Lod.High;
			}
			Class132.smethod_0().GroundEffect = MeshEditor.Enum8.const_1;
			this.project = project;
			this.projectType = projectType;
			this.project.OnSave += this.method_20;
			this.dictionary_0 = new Dictionary<object, Class106>();
			this.buildItemModelControl_0 = new BuildItemModelControl(this)
			{
				Parent = Class132.mainForm.ProjectPanel,
				Dock = DockStyle.Fill
			};
			this.method_5();
			this.buildItemModelControl_0.PresetPropertyGrid.OnPresetChanged += this.method_21;
			this.buildItemModelControl_0.PresetPropertyGrid.PropertyChanged += this.method_24;
			this.buildItemModelControl_0.BuilditemPropertyGrid.PropertyChanged += this.method_3;
			this.buildItemModelControl_0.BuilditemPropertyGrid.PropertyButtonClicked += this.method_1;
			this.buildItemModelControl_0.importMeshgroupButton.Click += this.method_10;
			this.buildItemModelControl_0.exportMeshgroupButton.Click += this.method_9;
			this.buildItemModelControl_0.meshgroupCombo.SelectedIndexChanged += this.method_8;
			this.buildItemModelControl_0.MiscPropertyGrid.PropertyChanged += this.method_17;
			this.buildItemModelControl_0.MiscPropertyGrid.PropertyButtonClicked += this.method_16;
			this.buildItemModelControl_0.meshPropertyGrid.PropertyChanged += this.method_4;
			this.buildItemModelControl_0.objdComboBox.SelectedIndexChanged += this.method_6;
			this.buildItemModelControl_0.meshPropertyGrid.MeshChanged += this.method_0;
			this.project.OnSave += this.method_2;
			if (this.buildItemModelControl_0.meshgroupCombo.Items.Count > 1)
			{
				this.buildItemModelControl_0.meshgroupCombo.SelectedIndex = 0;
			}
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x00072974 File Offset: 0x00070B74
		private void method_0(bool bool_2)
		{
			int selectedIndex = this.buildItemModelControl_0.meshgroupCombo.SelectedIndex;
			if (bool_2)
			{
				Class132.smethod_0().method_3(this.Renderable);
				this.method_5();
				Class132.smethod_0().ShadowMapDirty = true;
			}
			if (this.Renderable.CurrentPreset != null)
			{
				this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
			}
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x000729DC File Offset: 0x00070BDC
		private void method_1(object sender, PropertyButtonClickedEventArgs e)
		{
			if (e.PropertyEnum.Property.DisplayName == "Description")
			{
				StblEditor stblEditor = new StblEditor(this.project.Package, (ulong)this.buildItem_0.DescGuid, ((Class4)this.buildItemModelControl_0.BuilditemPropertyGrid).Wrapper.Description, this.buildItem_0.SecondInstanceID);
				if (stblEditor.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					((Class4)this.buildItemModelControl_0.BuilditemPropertyGrid).Wrapper.Description = stblEditor.text;
					e.PropertyEnum.Property.Value.SetValue(stblEditor.text);
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				}
			}
			else if (e.PropertyEnum.Property.DisplayName == "Name")
			{
				StblEditor stblEditor2 = new StblEditor(this.project.Package, (ulong)this.buildItem_0.NameGuid, ((Class4)this.buildItemModelControl_0.BuilditemPropertyGrid).Wrapper.Title, this.buildItem_0.SecondInstanceID);
				if (stblEditor2.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					((Class4)this.buildItemModelControl_0.BuilditemPropertyGrid).Wrapper.Title = stblEditor2.text;
					e.PropertyEnum.Property.Value.SetValue(stblEditor2.text);
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				}
			}
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00005B7F File Offset: 0x00003D7F
		private void method_2()
		{
			this.method_29();
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00072B68 File Offset: 0x00070D68
		private void method_3(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyEnum.Property.Value.GetValue() is TextureResKey)
			{
				Class132.smethod_0().method_3(this.Renderable);
			}
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_launcherThumbnail"))
			{
				if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("launcherThumbnail"))
				{
					string key = this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["launcherThumbnail"];
					PNG png = this.project.Package.GetEntry(new ResKey(key)) as PNG;
					png.Image = (e.PropertyEnum.Property.Value.GetValue() as Bitmap);
				}
				else
				{
					PNG png2 = new PNG();
					png2.Image = (e.PropertyEnum.Property.Value.GetValue() as Bitmap);
					Random random = new Random((int)DateTime.Now.Ticks);
					png2.InstanceID = random.Next();
					png2.SecondInstanceID = random.Next();
					png2.GroupID = this.buildItem_0.GroupID;
					this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("launcherThumbnail", png2.GenerateResKey());
					this.project.Package.AddEntry(png2);
				}
			}
			Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00072CE8 File Offset: 0x00070EE8
		private void method_4(object sender, PropertyChangedEventArgs e)
		{
			object previousValue = e.PropertyEnum.Property.Value.PreviousValue;
			if (previousValue is TextureResKey)
			{
				TextureResKey textureResKey = (TextureResKey)e.PropertyEnum.Property.Value.GetValue();
				if (textureResKey != null && textureResKey.GetType() == typeof(TextureResKey))
				{
					List<ResKey> list = Class132.mainForm.CurrentProject.Package.SearchEntries(new ResKey(DBPFType.ALL));
					foreach (ResKey key in list)
					{
						DBPFEntry entry = Class132.mainForm.CurrentProject.Package.GetEntry(key);
						if (entry is RCOL)
						{
							RCOL rcol = entry as RCOL;
							foreach (RCOLFileEntry rcolfileEntry in rcol.ExternalResources)
							{
								if (rcolfileEntry.ResKey.AsString().ToLower().Equals(previousValue.ToString().ToLower()))
								{
									rcolfileEntry.ResKey = textureResKey;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00072E40 File Offset: 0x00071040
		private void method_5()
		{
			this.bool_0 = true;
			this.method_18();
			List<ResKey> list = new List<ResKey>();
			List<ResKey> list2 = this.project.Package.SearchEntries(new ResKey(DBPFType.ALL));
			foreach (ResKey resKey in list2)
			{
				DBPFEntry entry = this.project.Package.GetEntry(resKey);
				if (entry is BuildItem)
				{
					list.Add(resKey);
				}
			}
			if (list.Count > 1)
			{
				int selectedIndex = this.buildItemModelControl_0.objdComboBox.SelectedIndex;
				this.buildItemModelControl_0.objdComboBox.Items.Clear();
				this.buildItemModelControl_0.objdSelectorPanel.Visible = true;
				foreach (ResKey key in list)
				{
					BuildItem buildItem = this.project.Package.GetEntry(key) as BuildItem;
					int num = buildItem.CatalogNameEntry.IndexOf("Name:");
					this.buildItemModelControl_0.objdComboBox.Items.Add(buildItem.CatalogNameEntry.Substring((num != -1) ? (num + 5) : 0));
				}
				this.buildItemModelControl_0.objdComboBox.SelectedIndex = ((selectedIndex == -1) ? 0 : selectedIndex);
			}
			else
			{
				this.buildItemModelControl_0.objdSelectorPanel.Visible = false;
				this.buildItemModelControl_0.objdComboBox.Items.Clear();
			}
			this.buildItem_0 = (this.project.Package.GetEntry(list[this.int_1]) as BuildItem);
			this.buildItemModelControl_0.StairsPropertyGrid.method_9(this.buildItem_0);
			this.Renderable = new Class106(this.buildItem_0);
			this.Renderable.method_10(this.lod_0);
			Class132.smethod_0().method_2(this.Renderable);
			Class132.smethod_0().method_46();
			if (this.buildItem_0 is TerrainPaint)
			{
				Class132.smethod_0().CameraPosition = new Vector3(Class132.smethod_0().CameraPosition.X, Class132.smethod_0().CameraPosition.Y + 3f, Class132.smethod_0().CameraPosition.Z);
			}
			else if (this.buildItem_0 is ROOF)
			{
				Class132.smethod_0().CameraPosition = new Vector3(Class132.smethod_0().CameraPosition.X, Class132.smethod_0().CameraPosition.Y + 5f, Class132.smethod_0().CameraPosition.Z + 5f);
			}
			else if (this.buildItem_0 is WALL)
			{
				Class132.smethod_0().CameraPosition = new Vector3(Class132.smethod_0().CameraPosition.X, Class132.smethod_0().CameraPosition.Y, Class132.smethod_0().CameraPosition.Z);
				Class132.smethod_0().Yaw = 0f;
				Class132.smethod_0().Pitch = 1.27f;
				if (this.buildItem_0.CatalogNameEntry.ToLower().Contains("wall"))
				{
					Class132.smethod_0().CameraPosition = new Vector3(0f, Class132.smethod_0().CameraPosition.Y, 14f);
					Class132.smethod_0().Yaw = -0.5f;
					Class132.smethod_0().Pitch = 0f;
					Class132.smethod_0().Pitch = 0.3f;
				}
			}
			if (this.buildItem_0 is STAIRS && (this.buildItem_0 as STAIRS).Materials.Count == 0)
			{
				this.buildItemModelControl_0.tabControl.TabPages.Remove(this.buildItemModelControl_0.presetTab);
			}
			else if (this.buildItem_0 is FENCE && (this.buildItem_0 as FENCE).Materials.Count == 0)
			{
				this.buildItemModelControl_0.tabControl.TabPages.Remove(this.buildItemModelControl_0.presetTab);
			}
			else if (this.buildItem_0 is RAILING && (this.buildItem_0 as RAILING).Materials.Count == 0)
			{
				this.buildItemModelControl_0.tabControl.TabPages.Remove(this.buildItemModelControl_0.presetTab);
			}
			else if (this.buildItem_0 is ROOF && (this.buildItem_0 as ROOF).Materials.Count == 0)
			{
				this.buildItemModelControl_0.tabControl.TabPages.Remove(this.buildItemModelControl_0.presetTab);
			}
			if (this.project.Type != Sims3Workshop.Data.ProjectType.TERRAIN)
			{
				this.method_13();
				this.method_15();
				this.method_23();
				if (this.buildItemModelControl_0.PresetCombo.Items.Count > 0)
				{
					this.buildItemModelControl_0.PresetCombo.SelectedIndex = 0;
				}
			}
			else if (this.project.Type == Sims3Workshop.Data.ProjectType.TERRAIN)
			{
				if (this.buildItemModelControl_0.tabControl.TabPages.Contains(this.buildItemModelControl_0.presetTab))
				{
					this.buildItemModelControl_0.tabControl.TabPages.Remove(this.buildItemModelControl_0.presetTab);
				}
				if (this.buildItemModelControl_0.tabControl.TabPages.Contains(this.buildItemModelControl_0.meshTab))
				{
					this.buildItemModelControl_0.tabControl.TabPages.Remove(this.buildItemModelControl_0.meshTab);
				}
			}
			this.bool_0 = false;
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x000733FC File Offset: 0x000715FC
		private void method_6(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				if (Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges)
				{
					DialogResult dialogResult = MessageBox.Show(Class132.mainForm, "Current project has unsaved changes, any unsaved changes be lost.\n\nDo you want to save before switching object?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
					if (dialogResult == DialogResult.Cancel)
					{
						return;
					}
					if (dialogResult == DialogResult.Yes)
					{
						Class132.mainForm.SaveCurrentProject();
					}
					else
					{
						Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = false;
					}
				}
				this.int_1 = this.buildItemModelControl_0.objdComboBox.SelectedIndex;
				this.method_5();
				if (this.buildItemModelControl_0.meshgroupCombo.Items.Count > 0)
				{
					this.buildItemModelControl_0.meshgroupCombo.SelectedIndex = 0;
				}
			}
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x000734AC File Offset: 0x000716AC
		private void method_7(Interface9 interface9_0)
		{
			if (this.buildItemModelControl_0.meshPropertyGrid.Visible)
			{
				Class121 @class = (Class121)interface9_0;
				MLOD.MLODEntry mlodentry = @class.MLODEntry;
				foreach (object obj in this.buildItemModelControl_0.meshgroupCombo.Items)
				{
					Class3.Class24 class2 = (Class3.Class24)obj;
					if (class2.MLOD == mlodentry.Parent)
					{
						this.buildItemModelControl_0.meshgroupCombo.SelectedItem = class2;
					}
				}
				IEnumerator enumerator2 = this.buildItemModelControl_0.meshPropertyGrid.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current is Property)
					{
						Property property = enumerator2.Current as Property;
						if (property.Value != null && property.Value.Tag is Class3.Class21)
						{
							Class3.Class21 class3 = property.Value.Tag as Class3.Class21;
							if (class3.method_3() == mlodentry)
							{
								this.buildItemModelControl_0.meshPropertyGrid.SelectAndFocusProperty(class3.method_0(), false);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x000735DC File Offset: 0x000717DC
		private void method_8(object sender, EventArgs e)
		{
			Class3.Class24 @class = this.buildItemModelControl_0.meshgroupCombo.SelectedItem as Class3.Class24;
			if (@class != null)
			{
				foreach (object obj in this.buildItemModelControl_0.meshgroupCombo.Items)
				{
					Class3.Class24 class2 = (Class3.Class24)obj;
					foreach (MLOD.MLODEntry key in class2.MLOD.Entries)
					{
						Interface9 @interface = this.Renderable.vmethod_2()[key];
						@interface.Selected = false;
					}
				}
				this.buildItemModelControl_0.MeshPropertyGrid.method_9(@class);
			}
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x000736CC File Offset: 0x000718CC
		private void method_9(object sender, EventArgs e)
		{
			Class3.Class24 @class = this.buildItemModelControl_0.meshgroupCombo.SelectedItem as Class3.Class24;
			if (@class != null)
			{
				RCOL f = @class.MLOD.Parent.Clone() as RCOL;
				if (Class132.mainForm.ExportFile(DBPFType.MLOD, f) == PluginResult.OK)
				{
					MessageBox.Show(null, "Export complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00073734 File Offset: 0x00071934
		private void method_10(object sender, EventArgs e)
		{
			Class3.Class24 @class = this.buildItemModelControl_0.meshgroupCombo.SelectedItem as Class3.Class24;
			if (@class != null)
			{
				RCOL rcol = @class.MLOD.Parent.Clone() as RCOL;
				int selectedIndex = this.buildItemModelControl_0.meshgroupCombo.SelectedIndex;
				if (Class132.mainForm.ImportFile(DBPFType.MLOD, rcol) == PluginResult.OK)
				{
					MessageBox.Show(null, "Import complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Class132.mainForm.CurrentProject.Package.AddEntry(rcol);
					Class132.smethod_0().method_3(this.Renderable);
					this.method_13();
					if (this.buildItemModelControl_0.meshgroupCombo.Items.Count > 1)
					{
						this.buildItemModelControl_0.meshgroupCombo.SelectedIndex = selectedIndex;
					}
				}
			}
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00073804 File Offset: 0x00071A04
		private void method_11(Class87 class87_0)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Workshop project (*.wrk)|*.wrk|Package (*.package)|*.package|Sims3Package (*.sims3pack)|*.sims3pack";
			if (openFileDialog.ShowDialog(Class132.mainForm) == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
				List<DBPFEntry> list = new List<DBPFEntry>();
				if (fileName.Contains(".wrk"))
				{
					WorkshopProject workshopProject = WorkshopProject.smethod_1(fileName);
					List<ResKey> list2 = workshopProject.Package.SearchEntries(new ResKey(class87_0.TGIIndex.TypeId));
					using (List<ResKey>.Enumerator enumerator = list2.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ResKey key = enumerator.Current;
							DBPFEntry entry = workshopProject.Package.GetEntry(key);
							if (entry is BuildItem)
							{
								(entry as BuildItem).Package = workshopProject.Package;
								list.Add(entry as BuildItem);
							}
						}
						goto IL_246;
					}
				}
				if (fileName.Contains(".sims3pack"))
				{
					Sims3Package sims3Package = new Sims3Package(fileName);
					using (List<object>.Enumerator enumerator2 = sims3Package.PackagedFiles.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							object obj = enumerator2.Current;
							PackagedFile packagedFile = (PackagedFile)obj;
							if (packagedFile is DBPF)
							{
								List<ResKey> list3 = (packagedFile as DBPF).SearchEntries(new ResKey(class87_0.TGIIndex.TypeId));
								foreach (ResKey key2 in list3)
								{
									DBPFEntry entry2 = (packagedFile as DBPF).GetEntry(key2);
									if (entry2 is BuildItem)
									{
										(entry2 as BuildItem).Package = packagedFile;
										list.Add(entry2 as BuildItem);
									}
								}
							}
						}
						goto IL_246;
					}
				}
				if (fileName.Contains(".package"))
				{
					DBPF dbpf = new DBPF(fileName);
					List<ResKey> list4 = dbpf.SearchEntries(new ResKey(class87_0.TGIIndex.TypeId));
					using (List<ResKey>.Enumerator enumerator4 = list4.GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							ResKey key3 = enumerator4.Current;
							DBPFEntry entry3 = dbpf.GetEntry(key3);
							if (entry3 is BuildItem)
							{
								(entry3 as BuildItem).Package = dbpf;
								list.Add(entry3 as BuildItem);
							}
						}
						goto IL_246;
					}
				}
				MessageBox.Show("Invalid extension.");
				IL_246:
				if (list.Count == 0)
				{
					MessageBox.Show("No suitable items in package");
				}
				else
				{
					if (list.Count > 1)
					{
						ResourceSelector resourceSelector = new ResourceSelector(list);
						if (resourceSelector.ShowDialog(Class132.mainForm) == DialogResult.OK)
						{
							this.method_12(resourceSelector.Resource as BuildItem, class87_0);
						}
					}
					else
					{
						this.method_12(list[0] as BuildItem, class87_0);
					}
					this.method_5();
				}
			}
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00073AF0 File Offset: 0x00071CF0
		private void method_12(BuildItem buildItem_1, Class87 class87_0)
		{
			DBPF dbpf = buildItem_1.Package as DBPF;
			DBPF package = Class132.mainForm.CurrentProject.Package;
			List<ResKey> list = dbpf.SearchEntries(new ResKey(DBPFType.ALL));
			foreach (ResKey key in list)
			{
				DBPFEntry entry = dbpf.GetEntry(key);
				package.AddEntry(entry);
			}
			class87_0.TGIIndex.SetFromResKey(buildItem_1.ResKey.ReplaceType(class87_0.TGIIndex.TypeId));
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x00073B98 File Offset: 0x00071D98
		private void method_13()
		{
			this.buildItemModelControl_0.MeshPropertyGrid.Clear();
			this.buildItemModelControl_0.meshgroupCombo.Items.Clear();
			this.buildItemModelControl_0.MeshPropertyGrid.Model = this;
			VisualProxy visualProxy_ = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(this.buildItem_0.TGIIndex[this.buildItem_0.VPXYIndex].AsString())) as VisualProxy;
			this.method_14(visualProxy_, "");
			if (this.buildItem_0.DiagonalModelIndex != -1)
			{
				VisualProxy visualProxy = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(this.buildItem_0.TGIIndex[this.buildItem_0.DiagonalModelIndex].AsString())) as VisualProxy;
				if (visualProxy != null)
				{
					this.method_14(visualProxy, "Modular 1 - ");
				}
			}
			if (this.buildItem_0.PostModel != -1)
			{
				VisualProxy visualProxy2 = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(this.buildItem_0.TGIIndex[this.buildItem_0.PostModel].AsString())) as VisualProxy;
				if (visualProxy2 != null)
				{
					this.method_14(visualProxy2, "Modular 2 - ");
				}
			}
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x00073CE0 File Offset: 0x00071EE0
		private void method_14(VisualProxy visualProxy_0, string string_0)
		{
			foreach (object obj in visualProxy_0.Entries)
			{
				if (obj is VPXY)
				{
					VPXY vpxy = obj as VPXY;
					foreach (VPXY.VPXEntryEntry vpxentryEntry in vpxy.entries)
					{
					}
					foreach (TGIIndex tgiindex in vpxy.TGIIndex)
					{
						if (tgiindex.IsType(DBPFType.MODL))
						{
							MODLModel modlmodel = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.AsString())) as MODLModel;
							foreach (RCOLItem rcolitem in modlmodel.Entries)
							{
								if (rcolitem is MODL)
								{
									MODL modl = rcolitem as MODL;
									foreach (MODL.MODLEntry modlEntry in modl.Entries)
									{
										Class3.Class24 @class = new Class3.Class24(modl, modlmodel, modlEntry, vpxy);
										@class.Section = string_0;
										if (this.buildItemModelControl_0.meshgroupCombo.Items.Count == 0)
										{
											this.buildItemModelControl_0.MeshPropertyGrid.method_9(@class);
										}
										this.buildItemModelControl_0.meshgroupCombo.Items.Add(@class);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00073F28 File Offset: 0x00072128
		private void method_15()
		{
			this.buildItemModelControl_0.MiscPropertyGrid.Project = this;
			this.buildItemModelControl_0.MiscPropertyGrid.method_0(this.Renderable);
			if (this.buildItem_0 is ROOF)
			{
				Dictionary<MLOD.MLODEntry, Interface9> dictionary = this.Renderable.vmethod_2();
				int num = 0;
				foreach (KeyValuePair<MLOD.MLODEntry, Interface9> keyValuePair in dictionary)
				{
					keyValuePair.Value.Visible = (num == 0);
					num++;
				}
			}
			if (this.buildItem_0 is STAIRS)
			{
				TGIIndex tgiindex = this.buildItem_0.TGIIndex[(this.buildItem_0 as STAIRS).Railing];
				ResKey resKey = new ResKey(tgiindex.AsString());
				RAILING railing = Class76.smethod_26(resKey) as RAILING;
				if (railing != null)
				{
					Class87 @class = new Class87(resKey, tgiindex);
					Class9 miscPropertyGrid = this.buildItemModelControl_0.MiscPropertyGrid;
					PropertyEnumerator underCategory = miscPropertyGrid.AppendRootCategory(0, "Railing");
					miscPropertyGrid.AppendManagedProperty(underCategory, 1, "Default railing", typeof(Class87), @class, "Default railing").Property.Value.Tag = @class;
					miscPropertyGrid.AppendManagedProperty(underCategory, 1, "Visible", typeof(bool), false, "Visible").Property.Tag = resKey;
					Class106 class2 = new Class106(railing);
					Class132.smethod_0().method_2(class2);
					class2.imethod_3(false);
					this.dictionary_0.Add(resKey, class2);
				}
				TGIIndex tgiindex2 = this.buildItem_0.TGIIndex[(this.buildItem_0 as STAIRS).Fence];
				ResKey resKey2 = new ResKey(tgiindex2.AsString());
				FENCE fence = Class76.smethod_26(resKey2) as FENCE;
				if (fence != null)
				{
					Class87 class3 = new Class87(resKey2, tgiindex2);
					Class9 miscPropertyGrid2 = this.buildItemModelControl_0.MiscPropertyGrid;
					PropertyEnumerator underCategory2 = miscPropertyGrid2.AppendRootCategory(0, "Fence");
					miscPropertyGrid2.AppendManagedProperty(underCategory2, 1, "Default fence", typeof(Class87), class3, "Default fence").Property.Value.Tag = class3;
					miscPropertyGrid2.AppendManagedProperty(underCategory2, 1, "Visible", typeof(bool), false, "Visible").Property.Tag = resKey2;
					Class106 class4 = new Class106(fence);
					Class132.smethod_0().method_2(class4);
					class4.imethod_3(false);
					this.dictionary_0.Add(resKey2, class4);
				}
			}
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x000741C8 File Offset: 0x000723C8
		private void method_16(object sender, PropertyButtonClickedEventArgs e)
		{
			object tag = e.PropertyEnum.Property.Tag;
			object value = e.PropertyEnum.Property.Value.GetValue();
			if (value is Class87)
			{
				Class87 class87_ = value as Class87;
				this.method_11(class87_);
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00074214 File Offset: 0x00072414
		private void method_17(object sender, PropertyChangedEventArgs e)
		{
			object tag = e.PropertyEnum.Property.Tag;
			object value = e.PropertyEnum.Property.Value.GetValue();
			if (tag is ResKey && value is bool)
			{
				Class106 @class = this.dictionary_0[tag];
				foreach (Interface9 @interface in @class.vmethod_2().Values)
				{
					@interface.Visible = (bool)value;
				}
			}
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00005B89 File Offset: 0x00003D89
		public void Unload()
		{
			this.method_18();
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x000742BC File Offset: 0x000724BC
		private void method_18()
		{
			Class132.smethod_0().method_34(null);
			Class132.smethod_0().method_25(this.Renderable);
			if (this.Renderable != null)
			{
				this.Renderable.imethod_8(true);
			}
			foreach (KeyValuePair<object, Class106> keyValuePair in this.dictionary_0)
			{
				Class132.smethod_0().method_25(keyValuePair.Value);
				keyValuePair.Value.imethod_8(true);
			}
			this.dictionary_0.Clear();
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x00074368 File Offset: 0x00072568
		public static BuildItem smethod_0(BuildItem buildItem_1, string string_0, DBPF dbpf_0)
		{
			Random random = new Random((int)DateTime.Now.Ticks);
			BuildItem buildItem = buildItem_1.Clone() as BuildItem;
			if (buildItem.Materials.Count > 2 && buildItem is WALL && MessageBox.Show(Class132.mainForm, "This floor/wall contains more than 2 variations and cant be used as a Sims3Pack unless you remove all except 2 variations. Do you want workshop to automatically remove them for you?\n\nIf you really want the extra variations you can install the floor as a .package file using \"Edit->Project Contents\"", "Too many variations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				while (buildItem.Materials.Count > 2)
				{
					buildItem.Materials.Remove(buildItem.Materials[buildItem.Materials.Count - 1]);
				}
			}
			buildItem.InstanceID = random.Next();
			buildItem.SecondInstanceID = random.Next();
			buildItem.NameGuid = (long)FNV64.GetHash(string_0.Replace(" ", ""));
			buildItem.DescGuid = (long)FNV64.GetHash(string_0.Replace(" ", "") + "desc");
			if (buildItem is TerrainPaint)
			{
				ulong hash = FNV64.GetHash(string_0.Replace(" ", "") + ((buildItem_1.BuildItemType == BuildItem.BuildBuyProductStatusFlags.ObjProductMadeUsingNewEntryScheme) ? "square" : ""));
				buildItem.InstanceID = (int)(hash >> 32);
				buildItem.SecondInstanceID = (int)(hash & 4294967295UL);
				(buildItem as TerrainPaint).uiSortIndex = (uint)random.Next();
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (TGIIndex tgiindex in buildItem.TGIIndex)
			{
				if (tgiindex.IsType(DBPFType.VPXY))
				{
					VisualProxy visualProxy = Class76.smethod_26(new ResKey(tgiindex.AsString())) as VisualProxy;
					if (visualProxy == null)
					{
						Console.WriteLine("Could not get resource: " + tgiindex.AsString());
					}
					else if (dictionary.ContainsKey(tgiindex.Reskey))
					{
						tgiindex.Reskey = dictionary[tgiindex.Reskey];
					}
					else
					{
						string reskey = tgiindex.Reskey;
						DBPFEntry dbpfentry = (DBPFEntry)visualProxy.Clone();
						dbpfentry.InstanceID = (tgiindex.InstanceId = random.Next());
						dbpfentry.SecondInstanceID = (tgiindex.SecondInstanceId = random.Next());
						int instanceID = dbpfentry.InstanceID;
						int secondInstanceID = dbpfentry.SecondInstanceID;
						int groupID = dbpfentry.GroupID;
						dbpf_0.AddEntry(dbpfentry);
						dictionary.Add(reskey, dbpfentry.GenerateResKey());
						if (dbpfentry is RCOL)
						{
							Class86.smethod_1(dbpfentry as RCOL, dbpf_0, buildItem.GroupID, buildItem.InstanceID, buildItem.SecondInstanceID, ref dictionary);
						}
						foreach (RCOLItem rcolitem in (dbpfentry as VisualProxy).Entries)
						{
							VPXY vpxy = (VPXY)rcolitem;
							foreach (TGIIndex tgiindex2 in vpxy.TGIIndex)
							{
								if (dictionary.ContainsKey(tgiindex2.Reskey))
								{
									tgiindex2.Reskey = dictionary[tgiindex2.Reskey];
								}
								else
								{
									DBPFEntry dbpfentry2 = Class76.smethod_26(new ResKey(tgiindex2.AsString()));
									if (tgiindex2.IsType(DBPFType.MLOD) && tgiindex2.GroupId == 1)
									{
										tgiindex2.InstanceId = instanceID;
										tgiindex2.SecondInstanceId = secondInstanceID;
									}
									if (dbpfentry2 == null)
									{
										Console.WriteLine("Failed to clone " + tgiindex.AsString() + ", reskey not found");
									}
									else
									{
										reskey = tgiindex2.Reskey;
										dbpfentry = (DBPFEntry)dbpfentry2.Clone();
										dbpfentry.InstanceID = (tgiindex2.InstanceId = random.Next());
										dbpfentry.SecondInstanceID = (tgiindex2.SecondInstanceId = random.Next());
										if (dbpfentry is MODLModel)
										{
											MODLModel modlmodel = dbpfentry as MODLModel;
											dbpfentry.InstanceID = (tgiindex2.InstanceId = instanceID);
											dbpfentry.SecondInstanceID = (tgiindex2.SecondInstanceId = secondInstanceID);
											foreach (RCOLFileEntry rcolfileEntry in modlmodel.InternalResources)
											{
												if (rcolfileEntry.TypeID == RCOLItemType.MLOD)
												{
													rcolfileEntry.ResKey.InstanceId = dbpfentry.InstanceID;
													rcolfileEntry.ResKey.SecondInstanceId = dbpfentry.SecondInstanceID;
												}
											}
										}
										dbpf_0.AddEntry(dbpfentry);
										dictionary.Add(reskey, dbpfentry.GenerateResKey());
										if (dbpfentry is RCOL)
										{
											Class86.smethod_1(dbpfentry as RCOL, dbpf_0, buildItem.GroupID, instanceID, secondInstanceID, ref dictionary);
										}
									}
								}
							}
						}
					}
				}
			}
			for (byte b = 0; b < 23; b += 1)
			{
				int instanceId = (int)b << 24;
				List<ResKey> list = dbpf_0.SearchEntries(new ResKey(DBPFType.STBL, 0, instanceId, buildItem.SecondInstanceID));
				STBL stbl;
				if (list.Count > 0)
				{
					stbl = (STBL)dbpf_0.GetEntry(list[0]);
				}
				else
				{
					stbl = new STBL
					{
						ResKey = new ResKey(DBPFType.STBL, 0, instanceId, buildItem.SecondInstanceID)
					};
					dbpf_0.AddEntry(stbl);
				}
				stbl.SetEntry((ulong)buildItem.NameGuid, string_0);
				stbl.SetEntry((ulong)buildItem.DescGuid, string_0);
			}
			dbpf_0.AddEntry(buildItem);
			return buildItem;
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00074950 File Offset: 0x00072B50
		private static void smethod_1(RCOL rcol_0, DBPF dbpf_0, int int_2, int int_3, int int_4, ref Dictionary<string, string> dictionary_1)
		{
			Random random = new Random((int)DateTime.Now.Ticks);
			foreach (RCOLFileEntry rcolfileEntry in rcol_0.ExternalResources)
			{
				if (rcolfileEntry.TypeID != RCOLItemType.DDS)
				{
					ResKey resKey = rcolfileEntry.ResKey;
					if (dictionary_1.ContainsKey(resKey.AsString()))
					{
						rcolfileEntry.ResKey = new ResKey(dictionary_1[resKey.AsString()]);
					}
					else
					{
						string key = resKey.AsString();
						DBPFEntry dbpfentry = Class76.smethod_26(resKey);
						DBPFEntry dbpfentry2 = (DBPFEntry)dbpfentry.Clone();
						dbpfentry2.InstanceID = (rcolfileEntry.ResKey.InstanceId = random.Next());
						dbpfentry2.SecondInstanceID = (rcolfileEntry.ResKey.SecondInstanceId = random.Next());
						if (dbpfentry2 is MLODModel)
						{
							DBPFEntry dbpfentry3 = dbpfentry2;
							rcolfileEntry.ResKey.InstanceId = int_3;
							dbpfentry3.InstanceID = int_3;
							DBPFEntry dbpfentry4 = dbpfentry2;
							rcolfileEntry.ResKey.SecondInstanceId = int_4;
							dbpfentry4.SecondInstanceID = int_4;
						}
						dbpf_0.AddEntry(dbpfentry2);
						dictionary_1.Add(key, dbpfentry2.GenerateResKey());
						if (dbpfentry2 is RCOL)
						{
							Class86.smethod_1(dbpfentry2 as RCOL, dbpf_0, int_2, int_3, int_4, ref dictionary_1);
						}
					}
				}
			}
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00074AD4 File Offset: 0x00072CD4
		private void method_19()
		{
			this.buildItemModelControl_0.method_2();
			foreach (OBJD.Material material in this.buildItem_0.Materials)
			{
				TGIIndex tgiindex = material.TGIIndex[0];
				Class76.smethod_26(new ResKey(tgiindex.Reskey));
				foreach (OBJD.Material.MaterialBlock materialBlock in material.Blocks)
				{
					string text = "";
					if (material.IsFloorOrWall)
					{
						text = string.Concat(new object[]
						{
							" isWall=\"true\" unk1=\"",
							material.CategoryFlags,
							"\" unk2=\"",
							material.UInt2,
							"\" unk3=\"",
							material.UInt3,
							"\""
						});
					}
					string text2 = string.Concat(new string[]
					{
						"<preset",
						text,
						"><complate name=\"",
						materialBlock.Ref1Name,
						"\" reskey=\"",
						tgiindex.Reskey,
						"\">"
					});
					foreach (OBJD.Material.ComplateVariable complateVariable in materialBlock.Variables)
					{
						string text3 = complateVariable.GetValue();
						if (complateVariable.ValueTypeCode == 3)
						{
							text3 = material.TGIIndex[Convert.ToInt32(text3)].Reskey;
						}
						object obj = text2;
						text2 = string.Concat(new object[]
						{
							obj,
							"<value key=\"",
							complateVariable.VariableName,
							"\" value=\"",
							text3,
							"\" type=\"",
							complateVariable.ValueTypeCode,
							"\" />"
						});
					}
					int num = 0;
					foreach (OBJD.Material.MaterialBlock materialBlock2 in materialBlock.Patterns)
					{
						string text4 = text2;
						text2 = string.Concat(new string[]
						{
							text4,
							"<pattern name=\"",
							materialBlock2.Ref1Name,
							"\" reskey=\"",
							material.TGIIndex[(int)materialBlock2.XMLIndex].Reskey,
							"\" variable=\"",
							materialBlock2.Ref2Name,
							"\">"
						});
						foreach (OBJD.Material.ComplateVariable complateVariable2 in materialBlock2.Variables)
						{
							string text5 = complateVariable2.GetValue();
							if (complateVariable2.ValueTypeCode == 3)
							{
								text5 = material.TGIIndex[Convert.ToInt32(text5)].Reskey;
							}
							object obj2 = text2;
							text2 = string.Concat(new object[]
							{
								obj2,
								"<value key=\"",
								complateVariable2.VariableName,
								"\" value=\"",
								text5,
								"\" type=\"",
								complateVariable2.ValueTypeCode,
								"\" />"
							});
						}
						text2 += "</pattern>";
						num++;
					}
					text2 += "</complate></preset>";
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(text2);
					this.buildItemModelControl_0.method_3(new Class81(xmlDocument, false));
				}
			}
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00074F34 File Offset: 0x00073134
		private void method_20()
		{
			List<uint> list = new List<uint>();
			int num = 0;
			uint num2 = 1U;
			foreach (OBJD.Material material in this.buildItem_0.Materials)
			{
				list.Add(num2++);
			}
			this.buildItem_0.Materials.Clear();
			num = 0;
			foreach (object obj in this.buildItemModelControl_0.PresetCombo.Items)
			{
				Class81 @class = (Class81)obj;
				if (!@class.IsProp)
				{
					OBJD.Material material2 = new OBJD.Material(list[num++]);
					material2.IsFloorOrWall = (this.buildItem_0 is WALL);
					OBJD.Material.MaterialBlock materialBlock = material2.AddBlock();
					XmlDocument xmlDocument = @class.Data as XmlDocument;
					if (xmlDocument != null)
					{
						if (material2.IsFloorOrWall)
						{
							XmlElement xmlElement = xmlDocument.SelectSingleNode("/preset") as XmlElement;
							material2.CategoryFlags = Convert.ToUInt32(xmlElement.GetAttribute("unk1"));
							material2.UInt2 = Convert.ToUInt32(xmlElement.GetAttribute("unk2"));
							material2.UInt3 = Convert.ToUInt32(xmlElement.GetAttribute("unk3"));
						}
						XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/preset/complate/value");
						if (xmlNodeList != null)
						{
							XmlNode xmlNode = xmlDocument.SelectSingleNode("/preset/complate");
							string attribute = (xmlNode as XmlElement).GetAttribute("reskey");
							string attribute2 = (xmlNode as XmlElement).GetAttribute("name");
							int num3 = material2.AddTGI(new TGIIndex(new ResKey(attribute)));
							materialBlock.Ref1Name = attribute2;
							materialBlock.XMLIndex = (byte)num3;
							foreach (object obj2 in xmlNodeList)
							{
								XmlNode xmlNode2 = (XmlNode)obj2;
								XmlAttribute xmlAttribute = xmlNode2.Attributes["key"];
								if (xmlAttribute != null)
								{
									XmlAttribute xmlAttribute2 = xmlNode2.Attributes["value"];
									if (xmlAttribute2 != null)
									{
										XmlAttribute xmlAttribute3 = xmlNode2.Attributes["type"];
										if (xmlAttribute3 != null)
										{
											XmlAttribute xmlAttribute4 = xmlNode2.Attributes["cloneDefault"];
											string value = xmlAttribute.Value;
											string value2 = xmlAttribute2.Value;
											byte b = Convert.ToByte(xmlAttribute3.Value);
											if (b == 3)
											{
												materialBlock.AddVariable(b, value, material2.AddTGI(new TGIIndex(new ResKey(value2))).ToString());
											}
											else
											{
												materialBlock.AddVariable(b, value, value2);
											}
										}
									}
								}
							}
							XmlNodeList xmlNodeList2 = xmlDocument.SelectNodes("/preset/complate/pattern");
							if (xmlNodeList2 != null)
							{
								for (int i = 0; i < xmlNodeList2.Count; i++)
								{
									XmlNode xmlNode3 = xmlNodeList2[i];
									XmlNodeList xmlNodeList3 = xmlNode3.SelectNodes("./value");
									if (xmlNodeList3 != null)
									{
										OBJD.Material.MaterialBlock materialBlock2 = materialBlock.AddPattern();
										materialBlock2.Ref1Name = (xmlNode3 as XmlElement).GetAttribute("name");
										materialBlock2.Ref2Name = (xmlNode3 as XmlElement).GetAttribute("variable");
										string attribute3 = (xmlNode3 as XmlElement).GetAttribute("reskey");
										num3 = material2.AddTGI(new TGIIndex(new ResKey(attribute3)));
										materialBlock2.XMLIndex = (byte)num3;
										foreach (object obj3 in xmlNodeList3)
										{
											XmlElement xmlElement2 = (XmlElement)obj3;
											XmlAttribute xmlAttribute5 = xmlElement2.Attributes["key"];
											if (xmlAttribute5 != null)
											{
												XmlAttribute xmlAttribute6 = xmlElement2.Attributes["value"];
												if (xmlAttribute6 != null)
												{
													XmlAttribute xmlAttribute7 = xmlElement2.Attributes["type"];
													if (xmlAttribute7 != null)
													{
														XmlAttribute xmlAttribute8 = xmlElement2.Attributes["cloneDefault"];
														if (xmlAttribute8 == null || !(xmlAttribute8.Value == xmlAttribute6.Value))
														{
															string value3 = xmlAttribute5.Value;
															string value4 = xmlAttribute6.Value;
															byte b2 = Convert.ToByte(xmlAttribute7.Value);
															if (b2 == 3)
															{
																materialBlock2.AddVariable(b2, value3, material2.AddTGI(new TGIIndex(new ResKey(value4))).ToString());
															}
															else
															{
																materialBlock2.AddVariable(b2, value3, value4);
															}
														}
													}
												}
											}
										}
									}
								}
								this.buildItem_0.Materials.Add(material2);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00005B93 File Offset: 0x00003D93
		private void method_21(object object_0, Class48 class48_0)
		{
			this.method_22();
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x00075454 File Offset: 0x00073654
		private void method_22()
		{
			if (this.buildItemModelControl_0.PresetCombo.SelectedIndex != -1)
			{
				XmlDocument xmlDocument_ = (this.buildItemModelControl_0.PresetCombo.SelectedItem as Class81).Data as XmlDocument;
				this.Renderable.vmethod_3(xmlDocument_);
			}
			Class132.mainForm.Render();
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x000754AC File Offset: 0x000736AC
		private void method_23()
		{
			this.buildItemModelControl_0.method_2();
			this.method_19();
			if (!this.bool_1)
			{
				this.buildItemModelControl_0.exportToolStripMenuItem.Click += this.method_25;
				this.buildItemModelControl_0.PresetCombo.SelectedIndexChanged += this.method_26;
				this.buildItemModelControl_0.PresetPropertyGrid.PropertyChanged += this.method_24;
			}
			this.bool_1 = true;
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00075530 File Offset: 0x00073730
		private void method_24(object sender, PropertyChangedEventArgs e)
		{
			Property property = e.PropertyEnum.Property;
			object previousValue = e.PropertyEnum.Property.Value.PreviousValue;
			object value = e.PropertyEnum.Property.Value.GetValue();
			if (value != null && value.GetType() == typeof(TextureResKey))
			{
				TextureResKey textureResKey = (TextureResKey)value;
				TextureResKey textureResKey2 = (TextureResKey)previousValue;
				DDS dds = Class76.smethod_26(textureResKey) as DDS;
				List<MATD> list = new List<MATD>();
				foreach (Interface9 @interface in this.Renderable.vmethod_2().Values)
				{
					Class121 @class = (Class121)@interface;
					List<MATD> list2 = @class.method_12(0);
					foreach (MATD matd in list2)
					{
						if (matd.NameHash != 1262059857U)
						{
							foreach (MATD.MATDEntry matdentry in matd.Entries)
							{
								if (matdentry.DataType == MATD.MATDDataType.ReskeyType)
								{
									int num = matdentry.GetIntValue()[0] & 16777215;
									RCOLFileEntry rcolfileEntry = @class.MLODEntry.Parent.Parent.ExternalResources[num - 1];
									if ((long)rcolfileEntry.TypeID == (long)((ulong)textureResKey2.TypeId) && rcolfileEntry.ResKey.InstanceId == textureResKey2.InstanceId && rcolfileEntry.ResKey.SecondInstanceId == textureResKey2.SecondInstanceId)
									{
										int groupId = rcolfileEntry.ResKey.GroupId;
										int groupId2 = textureResKey2.GroupId;
									}
									if (rcolfileEntry.TypeID == (RCOLItemType)54137909U)
									{
										TXTC txtc = Class76.smethod_26(rcolfileEntry.ResKey) as TXTC;
										foreach (IGTIndex igtindex in txtc.IGTIndex)
										{
											if (igtindex.Equals(textureResKey2))
											{
												Size size = default(Size);
												foreach (MATD.MATDEntry matdentry2 in matd.Entries)
												{
													if (matdentry2.Type == MATD.MATDEntryType.MaskWidth)
													{
														size.Width = matdentry2.GetIntValue()[0];
													}
													if (matdentry2.Type == (MATD.MATDEntryType)2224872156U)
													{
														size.Height = matdentry2.GetIntValue()[0];
													}
												}
												if ((size.Width != dds.Width || size.Height != dds.Height) && !list.Contains(matd))
												{
													list.Add(matd);
												}
											}
										}
									}
								}
							}
						}
					}
				}
				if (list != null && list.Count > 0)
				{
					DialogResult dialogResult = MessageBox.Show(null, list.Count + " material(s) that uses this texture has a smaller maskwidth and/or maskheight than the imported texture.\n\nDo you want to update the materials mask width and height?", "Mask width and mask height", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Yes)
					{
						foreach (MATD matd2 in list)
						{
							foreach (MATD.MATDEntry matdentry3 in matd2.Entries)
							{
								if (matdentry3.Type == MATD.MATDEntryType.MaskWidth)
								{
									matdentry3.bytes = BitConverter.GetBytes(dds.Width);
								}
								if (matdentry3.Type == (MATD.MATDEntryType)2224872156U)
								{
									matdentry3.bytes = BitConverter.GetBytes(dds.Height);
								}
							}
						}
					}
				}
				List<ResKey> list3 = Class132.mainForm.CurrentProject.Package.SearchEntries(new ResKey(DBPFType.TXTC));
				foreach (ResKey key in list3)
				{
					TXTC txtc2 = Class132.mainForm.CurrentProject.Package.GetEntry(key) as TXTC;
					foreach (IGTIndex igtindex2 in txtc2.IGTIndex)
					{
						if (igtindex2.Equals(textureResKey2))
						{
							igtindex2.SetFromResKey(textureResKey, true);
						}
					}
				}
				foreach (TGIIndex tgiindex in this.buildItem_0.TGIIndex)
				{
					if (tgiindex.Equals(textureResKey2))
					{
						tgiindex.SetFromResKey(textureResKey, true);
					}
				}
				List<ResKey> list4 = Class132.mainForm.CurrentProject.Package.SearchEntries(new ResKey(DBPFType.ALL));
				foreach (ResKey key2 in list4)
				{
					DBPFEntry entry = Class132.mainForm.CurrentProject.Package.GetEntry(key2);
					if (entry is RCOL)
					{
						RCOL rcol = entry as RCOL;
						foreach (RCOLFileEntry rcolfileEntry2 in rcol.ExternalResources)
						{
							if (rcolfileEntry2.ResKey.InstanceId == textureResKey2.InstanceId && rcolfileEntry2.ResKey.SecondInstanceId == textureResKey2.SecondInstanceId && rcolfileEntry2.TypeID == (RCOLItemType)textureResKey2.TypeId && rcolfileEntry2.ResKey.GroupId == textureResKey2.GroupId)
							{
								rcolfileEntry2.ResKey.InstanceId = textureResKey.InstanceId;
								rcolfileEntry2.ResKey.SecondInstanceId = textureResKey.SecondInstanceId;
								rcolfileEntry2.ResKey.GroupId = textureResKey.GroupId;
							}
						}
					}
				}
			}
			this.method_22();
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x00075C68 File Offset: 0x00073E68
		private void method_25(object sender, EventArgs e)
		{
			XmlDocument preset = (this.buildItemModelControl_0.PresetCombo.SelectedItem as Class81).Data as XmlDocument;
			Size size = this.Renderable.vmethod_1();
			ComplateToImageForm complateToImageForm = new ComplateToImageForm(preset, size);
			if (!complateToImageForm.Completed)
			{
				complateToImageForm.ShowDialog(Class132.mainForm);
			}
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00075CC0 File Offset: 0x00073EC0
		private void method_26(object sender, EventArgs e)
		{
			if (this.buildItemModelControl_0.PresetCombo.SelectedIndex != -1)
			{
				XmlDocument xmlDocument = (this.buildItemModelControl_0.PresetCombo.SelectedItem as Class81).Data as XmlDocument;
				this.Renderable.vmethod_3(xmlDocument);
				this.buildItemModelControl_0.PresetPropertyGrid.Preset = xmlDocument;
			}
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x00075D20 File Offset: 0x00073F20
		public void method_27(int int_2)
		{
			try
			{
				this.method_20();
				this.buildItem_0.Materials.RemoveAt(int_2);
				this.method_19();
				this.buildItemModelControl_0.PresetCombo.SelectedIndex = 0;
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			}
			catch (Exception)
			{
				MessageBox.Show("Could not remove at index " + int_2 + " because this is a hack, try removing them in order.");
			}
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00075D9C File Offset: 0x00073F9C
		public void method_28(int int_2)
		{
			this.method_20();
			this.buildItem_0.Materials.Add(this.buildItem_0.Materials[int_2].Clone());
			this.method_19();
			this.buildItemModelControl_0.PresetCombo.SelectedIndex = this.buildItemModelControl_0.PresetCombo.Items.Count - 1;
			this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x00075E10 File Offset: 0x00074010
		public void method_29()
		{
			DBPF package = Class132.mainForm.CurrentProject.Package;
			Dictionary<ulong, string> entries = new Dictionary<ulong, string>
			{
				{
					(ulong)this.buildItem_0.NameGuid,
					this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Title
				},
				{
					(ulong)this.buildItem_0.DescGuid,
					this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Description
				}
			};
			ResKey id = new ResKey(this.buildItem_0.GenerateResKey());
			STBL.SaveStrings(package, entries, id);
			if (this.buildItem_0 is TerrainPaint)
			{
				List<ResKey> list = package.SearchEntries(new ResKey(DBPFType.NMAP));
				if (list.Count > 0)
				{
					NameMap nameMap = package.GetEntry(list[0]) as NameMap;
					nameMap.Map.Clear();
					List<ResKey> list2 = package.SearchEntries(new ResKey(DBPFType.CTERRAINGEOM));
					foreach (ResKey key in list2)
					{
						TerrainPaint terrainPaint = package.GetEntry(key) as TerrainPaint;
						NameMap.MapEntry mapEntry = new NameMap.MapEntry();
						string str = (terrainPaint.CatalogNameEntry.IndexOf("Name:") != -1) ? terrainPaint.CatalogNameEntry.Substring(terrainPaint.CatalogNameEntry.IndexOf("Name:") + 5) : terrainPaint.CatalogNameEntry;
						mapEntry.Name = str + ((terrainPaint.BuildItemType == BuildItem.BuildBuyProductStatusFlags.ObjProductMadeUsingNewEntryScheme) ? "Square" : "");
						mapEntry.Instance = ((long)terrainPaint.InstanceID << 32) + (long)terrainPaint.SecondInstanceID;
						nameMap.Map.Add(mapEntry);
					}
					package.AddEntry(nameMap);
					package.RemoveEntry(nameMap);
				}
				else
				{
					NameMap nameMap2 = new NameMap();
					Random random = new Random((int)DateTime.Now.Ticks);
					nameMap2.GroupID = this.buildItem_0.GroupID;
					nameMap2.InstanceID = random.Next();
					nameMap2.SecondInstanceID = random.Next();
					List<ResKey> list3 = package.SearchEntries(new ResKey(DBPFType.CTERRAINGEOM));
					foreach (ResKey key2 in list3)
					{
						TerrainPaint terrainPaint2 = package.GetEntry(key2) as TerrainPaint;
						NameMap.MapEntry mapEntry2 = new NameMap.MapEntry();
						string str2 = (terrainPaint2.CatalogNameEntry.IndexOf("Name:") != -1) ? terrainPaint2.CatalogNameEntry.Substring(terrainPaint2.CatalogNameEntry.IndexOf("Name:") + 5) : terrainPaint2.CatalogNameEntry;
						mapEntry2.Name = str2 + ((terrainPaint2.BuildItemType == BuildItem.BuildBuyProductStatusFlags.ObjProductMadeUsingNewEntryScheme) ? "Square" : "");
						mapEntry2.Instance = (long)(terrainPaint2.InstanceID + terrainPaint2.SecondInstanceID);
						nameMap2.Map.Add(mapEntry2);
					}
				}
			}
			this.method_20();
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00064FCC File Offset: 0x000631CC
		public IWorkshopProject GetCurrentProject()
		{
			return Class132.mainForm.CurrentProject;
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x000032ED File Offset: 0x000014ED
		public void ImportPackage(object object_0)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0007613C File Offset: 0x0007433C
		public object ExportPackage()
		{
			if (string.IsNullOrEmpty(this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Title))
			{
				throw new Exception("Title can not be empty.");
			}
			if (string.IsNullOrEmpty(this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Description))
			{
				throw new Exception("Description can not be empty.");
			}
			this.method_29();
			DBPF dbpf = new DBPF();
			ArrayList resKeys = Class132.mainForm.CurrentProject.Package.GetResKeys();
			foreach (object obj in resKeys)
			{
				ResKey resKey = (ResKey)obj;
				if (resKey.TypeId != 0U)
				{
					DBPFEntry entry = Class132.mainForm.CurrentProject.Package.GetEntry(resKey);
					dbpf.AddEntry(entry);
				}
			}
			if (this.buildItem_0 is TerrainPaint)
			{
				BuildItem buildItem = this.buildItem_0.Clone() as BuildItem;
				ulong hash = FNV64.GetHash((this.buildItemModelControl_0.BuilditemPropertyGrid as Class4).Wrapper.Title + (((this.buildItem_0 as TerrainPaint).BuildItemType != BuildItem.BuildBuyProductStatusFlags.ObjProductMadeUsingNewEntryScheme) ? "square" : ""));
				buildItem.InstanceID = (int)(hash >> 32);
				buildItem.SecondInstanceID = (int)(hash & 4294967295UL);
				(buildItem as TerrainPaint).ProfilePicture.InstanceId = 1308566215;
				(buildItem as TerrainPaint).ProfilePicture.SecondInstanceId = 681161407;
				(buildItem as TerrainPaint).BuildItemType = BuildItem.BuildBuyProductStatusFlags.ObjProductMadeUsingNewEntryScheme;
				(buildItem as TerrainPaint).uiSortIndex = (this.buildItem_0 as TerrainPaint).uiSortIndex + 1U;
				dbpf.AddEntry(buildItem);
			}
			PNG png;
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("launcherThumbnail"))
			{
				png = (this.project.Package.GetEntry(new ResKey(this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["launcherThumbnail"])) as PNG);
			}
			else
			{
				png = new PNG();
				png.TypeID = DBPFType.PNG_THUMB_MEDIUM;
				png.InstanceID = new Random((int)DateTime.Now.Ticks).Next();
				png.Image = (this.Sims3WorkshopSDK.Interfaces.IProjectModel.GetThumbnail() as Bitmap);
			}
			dbpf.AddEntry(png);
			CreatorDetails creatorDetails = Class132.mainForm.GetCreatorDetails();
			if (creatorDetails == null)
			{
				throw new Exception("No creator details set.");
			}
			string text = string.Concat(new object[]
			{
				"TSW_",
				creatorDetails.Name.Replace(" ", "_"),
				"_object_",
				DateTime.Now.ToFileTime()
			});
			string text2 = "0x" + Class132.mainForm.CreateGuid(this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Title + "_" + text).Replace("-", "").ToLower();
			text = text2;
			PackageDescriptor packageDescriptor = this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.PackageDescriptor;
			packageDescriptor.Title = this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Title;
			packageDescriptor.Description = this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Description;
			packageDescriptor.Thumbnail = png.GenerateResKey().Replace("key:", "");
			packageDescriptor.Id = text;
			packageDescriptor.Manifest.Remove("packagesubtype");
			packageDescriptor.Manifest.Add("packagesubtype", this.int_0.ToString("X8") ?? "");
			packageDescriptor.KeyyList.Clear();
			packageDescriptor.DependencyList.Clear();
			packageDescriptor.DependencyList.Add("0x050cffe800000000050cffe800000000");
			packageDescriptor.DependencyList.Add(text);
			foreach (object obj2 in dbpf.GetResKeys())
			{
				ResKey resKey2 = (ResKey)obj2;
				packageDescriptor.KeyyList.Add(resKey2.AsString().Replace("key", "1"));
			}
			packageDescriptor.MetaTags.Clear();
			packageDescriptor.MetaTags.Add("numofthumbs", 1);
			dbpf.AddEntry(packageDescriptor);
			dbpf.Guid = text2.Replace("-", "").ToLower();
			dbpf.Name = dbpf.Guid + ".package";
			dbpf.ContentType = "Object";
			return dbpf;
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00076628 File Offset: 0x00074828
		public object ExportSims3Pack()
		{
			DBPF dbpf = this.Sims3WorkshopSDK.Interfaces.IProjectModel.ExportPackage() as DBPF;
			Sims3Package sims3Package = new Sims3Package();
			sims3Package.DisplayName = this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Title;
			sims3Package.Description = this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Description;
			sims3Package.Type = "object";
			sims3Package.PackageId = dbpf.Guid.Replace("-", "").ToLower();
			sims3Package.SubType = (this.int_0.ToString("X8") ?? "");
			string[] array = new string[23];
			STBL.Locales.Keys.CopyTo(array, 0);
			string[] localizedStrings = STBL.GetLocalizedStrings(dbpf, (ulong)this.buildItem_0.NameGuid, this.buildItem_0.SecondInstanceID);
			for (int i = 0; i < 23; i++)
			{
				sims3Package.LocalizedNames.Add(new LocalizedString(localizedStrings[i], array[i]));
			}
			localizedStrings = STBL.GetLocalizedStrings(dbpf, (ulong)this.buildItem_0.DescGuid, this.buildItem_0.SecondInstanceID);
			for (int j = 0; j < 23; j++)
			{
				sims3Package.LocalizedDescriptions.Add(new LocalizedString(localizedStrings[j], array[j]));
			}
			sims3Package.Dependencies.Add("0x050cffe800000000050cffe800000000");
			sims3Package.AddFile(dbpf);
			return sims3Package;
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00024BE0 File Offset: 0x00022DE0
		private bool method_30()
		{
			return false;
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0007678C File Offset: 0x0007498C
		public object GetThumbnail()
		{
			Bitmap bitmap;
			if (this.buildItem_0 is TerrainPaint)
			{
				DDS dds = Class76.smethod_26(new ResKey((this.buildItem_0 as TerrainPaint).BrushTGI.AsString())) as DDS;
				if (dds != null)
				{
					Image image = ImageLoader.Load(dds.MipMaps[0]);
					return image.GetThumbnailImage(256, 256, new Image.GetThumbnailImageAbort(this.method_30), IntPtr.Zero);
				}
				bitmap = (Class132.smethod_0().method_19(this.Renderable, null, new Size(256, 256)) as Bitmap);
			}
			else
			{
				bitmap = (Class132.smethod_0().method_19(this.Renderable, null, new Size(256, 256)) as Bitmap);
			}
			Bitmap bitmap2 = new Bitmap(256, 256);
			Graphics graphics = Graphics.FromImage(bitmap2);
			if (bitmap != null)
			{
				graphics.DrawImage(bitmap, new Rectangle(18, 18, 222, 222), 0, 0, 256, 256, GraphicsUnit.Pixel);
			}
			bitmap.Dispose();
			return bitmap2;
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x000768AC File Offset: 0x00074AAC
		public string GetTitle()
		{
			return this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Title;
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x000768D4 File Offset: 0x00074AD4
		public string GetDescription()
		{
			return this.buildItemModelControl_0.StairsPropertyGrid.Wrapper.Description;
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00005B9D File Offset: 0x00003D9D
		public void LodChanged(Lod lod_1)
		{
			this.lod_0 = lod_1;
			this.Renderable.method_10(lod_1);
			Class132.smethod_0().ShadowMapDirty = true;
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x000768FC File Offset: 0x00074AFC
		public List<Lod> GetLodLevels()
		{
			return this.Renderable.LodLevels;
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00037B84 File Offset: 0x00035D84
		public bool HasSlots()
		{
			return true;
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool HasRig()
		{
			return false;
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x00002A71 File Offset: 0x00000C71
		public void method_31()
		{
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x00005BBF File Offset: 0x00003DBF
		public void SetSlotsVisible(bool bool_2)
		{
			if (this.Renderable != null)
			{
				this.Renderable.DisplaySlots = bool_2;
			}
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00002A71 File Offset: 0x00000C71
		public void SetRigVisible(bool bool_2)
		{
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00076918 File Offset: 0x00074B18
		public object GetRenderable()
		{
			return this.Renderable;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00076930 File Offset: 0x00074B30
		public List<object> GetModels()
		{
			List<object> list = new List<object>();
			foreach (TGIIndex tgiindex in this.buildItem_0.TGIIndex)
			{
				if (tgiindex.Type == DBPFType.VPXY)
				{
					VisualProxy visualProxy = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.Reskey)) as VisualProxy;
					if (visualProxy != null)
					{
						foreach (object obj in visualProxy.Entries)
						{
							if (obj is VPXY)
							{
								VPXY vpxy = obj as VPXY;
								foreach (TGIIndex tgiindex2 in vpxy.TGIIndex)
								{
									if (tgiindex2.Type == DBPFType.MODL)
									{
										MODLModel item = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex2.AsString())) as MODLModel;
										list.Add(item);
									}
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x00076AC4 File Offset: 0x00074CC4
		public List<object> GetGameObjects()
		{
			List<object> list = new List<object>();
			List<ResKey> list2 = this.project.Package.SearchEntries(new ResKey(DBPFType.ALL));
			foreach (ResKey key in list2)
			{
				DBPFEntry entry = this.project.Package.GetEntry(key);
				if (entry is BuildItem)
				{
					list.Add(entry);
				}
			}
			return list;
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x00076B54 File Offset: 0x00074D54
		public object GetCurrentGameObject()
		{
			return this.buildItem_0;
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x00076B6C File Offset: 0x00074D6C
		public bool HasShadows()
		{
			bool result;
			if (this.projectType == Sims3Workshop.Data.ProjectType.TERRAIN)
			{
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x00037B84 File Offset: 0x00035D84
		public bool HasBumpMap()
		{
			return true;
		}

		// Token: 0x0400065B RID: 1627
		private WorkshopProject project;

		// Token: 0x0400065C RID: 1628
		private BuildItem buildItem_0;

		// Token: 0x0400065D RID: 1629
		private BuildItemModelControl buildItemModelControl_0;

		// Token: 0x0400065E RID: 1630
		private int int_0 = 268435456;

		// Token: 0x0400065F RID: 1631
		public Dictionary<object, Class106> dictionary_0;

		// Token: 0x04000660 RID: 1632
		private Sims3Workshop.Data.ProjectType projectType;

		// Token: 0x04000661 RID: 1633
		private Lod lod_0;

		// Token: 0x04000662 RID: 1634
		private bool bool_0;

		// Token: 0x04000663 RID: 1635
		private int int_1;

		// Token: 0x04000664 RID: 1636
		private bool bool_1;

		// Token: 0x04000665 RID: 1637
		[CompilerGenerated]
		private Class106 class106_0;
	}
}
