using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns10;
using ns11;
using ns12;
using ns13;
using ns15;
using ns16;
using ns17;
using ns19;
using ns2;
using ns21;
using ns3;
using ns4;
using ns6;
using ns8;
using Package;
using Package.Geometry;
using Package.Helper;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3Workshop.Data;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using VisualHint.SmartPropertyGrid;

namespace ns7
{
	// Token: 0x020000B5 RID: 181
	internal sealed class Class80 : IProjectModel
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x00068B30 File Offset: 0x00066D30
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x00068B48 File Offset: 0x00066D48
		[PropertyFeel("button")]
		public string Title
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = ((value.Length > 240) ? value.Substring(0, 240) : value);
				this.objd_0.CatalogNameEntry = "CatalogObjects/Name:" + StringHelpers.ToCamelCase(this.string_0);
				if (this.packageDescriptor_0 != null)
				{
					this.packageDescriptor_0.Title = this.string_0;
				}
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00068BB4 File Offset: 0x00066DB4
		// (set) Token: 0x0600071A RID: 1818 RVA: 0x00068BCC File Offset: 0x00066DCC
		[PropertyHeightMultiplier(3)]
		[PropertyFeel("button")]
		[PropertyLook(typeof(PropertyMultilineEditLook))]
		public string Description
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = ((value.Length > 240) ? value.Substring(0, 240) : value);
				this.objd_0.CatalogDescEntry = "CatalogObjects/Description:" + StringHelpers.ToCamelCase(this.string_1);
				if (this.packageDescriptor_0 != null)
				{
					this.packageDescriptor_0.Description = this.string_1;
				}
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00068C38 File Offset: 0x00066E38
		// (set) Token: 0x0600071C RID: 1820 RVA: 0x00068C54 File Offset: 0x00066E54
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
		public OBJD.ObjectTypeFlags ObjectTypeFlags
		{
			get
			{
				return this.objd_0.ObjectType;
			}
			set
			{
				try
				{
					this.objd_0.ObjectType = value;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x00068C90 File Offset: 0x00066E90
		// (set) Token: 0x0600071E RID: 1822 RVA: 0x00068CAC File Offset: 0x00066EAC
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
		public OBJD.ObjectTypeFlags2 ObjectTypeFlags2
		{
			get
			{
				return this.objd_0.ObjectType2;
			}
			set
			{
				try
				{
					this.objd_0.ObjectType2 = value;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x00068CE8 File Offset: 0x00066EE8
		// (set) Token: 0x06000720 RID: 1824 RVA: 0x00068D04 File Offset: 0x00066F04
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
		public OBJD.WallPlacementFlags WallPlacementFlags
		{
			get
			{
				return this.objd_0.WallPlacement;
			}
			set
			{
				try
				{
					this.objd_0.WallPlacement = value;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x00068D40 File Offset: 0x00066F40
		// (set) Token: 0x06000722 RID: 1826 RVA: 0x00068D5C File Offset: 0x00066F5C
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
		public OBJD.MovementFlags MovementFlags
		{
			get
			{
				return this.objd_0.Movement;
			}
			set
			{
				try
				{
					this.objd_0.Movement = value;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x00068D98 File Offset: 0x00066F98
		// (set) Token: 0x06000724 RID: 1828 RVA: 0x00068DB4 File Offset: 0x00066FB4
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
		public OBJD.SlotPlacementFlags SlotPlacementFlags
		{
			get
			{
				return this.objd_0.SlotsFlags;
			}
			set
			{
				try
				{
					this.objd_0.SlotsFlags = value;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x00068DF0 File Offset: 0x00066FF0
		public ObjdModelControl Control
		{
			get
			{
				return this.objdModelControl_0;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x00068E08 File Offset: 0x00067008
		// (set) Token: 0x06000727 RID: 1831 RVA: 0x00005643 File Offset: 0x00003843
		[PropertyDisable]
		public Class105 Renderable { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00068E20 File Offset: 0x00067020
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x0000564E File Offset: 0x0000384E
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
		public OBJD.Room Room
		{
			get
			{
				return (OBJD.Room)this.objd_0.RoomFlags;
			}
			set
			{
				this.objd_0.RoomFlags = (uint)value;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x00068E3C File Offset: 0x0006703C
		// (set) Token: 0x0600072B RID: 1835 RVA: 0x0000565E File Offset: 0x0000385E
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
		public OBJD.Category Category
		{
			get
			{
				return (OBJD.Category)this.objd_0.CategoryFlags;
			}
			set
			{
				this.objd_0.CategoryFlags = (uint)value;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x00068E58 File Offset: 0x00067058
		// (set) Token: 0x0600072D RID: 1837 RVA: 0x0000566E File Offset: 0x0000386E
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
		public OBJD.BuildBuyProductStatusFlags BuildBuyStatusFlags
		{
			get
			{
				return this.objd_0.BuildBuyStatus;
			}
			set
			{
				this.objd_0.BuildBuyStatus = value;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x00068E74 File Offset: 0x00067074
		// (set) Token: 0x0600072F RID: 1839 RVA: 0x0000567E File Offset: 0x0000387E
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
		public OBJD.SubCategory SubCategory
		{
			get
			{
				return (OBJD.SubCategory)this.objd_0.SubCategoryFlags;
			}
			set
			{
				this.objd_0.SubCategoryFlags = (ulong)value;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x00068E90 File Offset: 0x00067090
		// (set) Token: 0x06000731 RID: 1841 RVA: 0x0000568E File Offset: 0x0000388E
		[PropertyFeel("checkbox")]
		public OBJD.SubCategory2 SubCategory2
		{
			get
			{
				return (OBJD.SubCategory2)this.objd_0.SubCategoryFlags2;
			}
			set
			{
				this.objd_0.SubCategoryFlags2 = (ulong)value;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000732 RID: 1842 RVA: 0x00068EAC File Offset: 0x000670AC
		// (set) Token: 0x06000733 RID: 1843 RVA: 0x0000569E File Offset: 0x0000389E
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
		public OBJD.SubRoom SubRoom
		{
			get
			{
				return (OBJD.SubRoom)this.objd_0.SubRoomFlags;
			}
			set
			{
				this.objd_0.SubRoomFlags = (ulong)value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x00068EC8 File Offset: 0x000670C8
		// (set) Token: 0x06000735 RID: 1845 RVA: 0x000056AE File Offset: 0x000038AE
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
		public OBJD.Build BuildType
		{
			get
			{
				return (OBJD.Build)this.objd_0.BuildCategoryFlags;
			}
			set
			{
				this.objd_0.BuildCategoryFlags = (uint)value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x00068EE4 File Offset: 0x000670E4
		// (set) Token: 0x06000737 RID: 1847 RVA: 0x000056BE File Offset: 0x000038BE
		public bool ShowWall
		{
			get
			{
				return this.Renderable.DisplayWall;
			}
			set
			{
				this.Renderable.DisplayWall = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x00068F00 File Offset: 0x00067100
		// (set) Token: 0x06000739 RID: 1849 RVA: 0x000056CE File Offset: 0x000038CE
		public bool ShowFloorMask
		{
			get
			{
				return this.Renderable.DisplayFloorMask;
			}
			set
			{
				this.Renderable.DisplayFloorMask = value;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x00068F1C File Offset: 0x0006711C
		// (set) Token: 0x0600073B RID: 1851 RVA: 0x000056DE File Offset: 0x000038DE
		public Image LauncherThumbnail { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x00068F34 File Offset: 0x00067134
		// (set) Token: 0x0600073D RID: 1853 RVA: 0x00068F50 File Offset: 0x00067150
		public float Price
		{
			get
			{
				return this.objd_0.Price;
			}
			set
			{
				this.objd_0.Price = value;
				if ((this.objd_0.BuildCategoryFlags & 64U) != 0U)
				{
					List<ResKey> list = this.project.Package.SearchEntries(new ResKey(DBPFType.FIREPLACE));
					if (list.Count > 0)
					{
						foreach (ResKey key in list)
						{
							FirePlace firePlace = (FirePlace)this.project.Package.GetEntry(key);
							firePlace.Price = this.objd_0.Price;
						}
					}
				}
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x00069004 File Offset: 0x00067204
		// (set) Token: 0x0600073F RID: 1855 RVA: 0x00069020 File Offset: 0x00067220
		public uint Version
		{
			get
			{
				return this.objd_0.Version;
			}
			set
			{
				uint version = value;
				if (this.objd_0.Version < 23U && value >= 23U)
				{
					TGIIndex tgiindex = null;
					foreach (TGIIndex tgiindex2 in this.objd_0.TgiIndex)
					{
						if (tgiindex2.Type == DBPFType.DDS && tgiindex2.InstanceId == 0)
						{
							tgiindex = tgiindex2;
						}
					}
					if (value >= 23U && tgiindex != null)
					{
						this.objd_0.FloorMaskIndex = this.objd_0.AddTgi(this.objd_0.TgiIndex, tgiindex);
					}
				}
				bool flag = false;
				if (this.objd_0.Version < 23U && value >= 23U)
				{
					OBJK objk_ = this.method_27();
					VisualProxy visualProxy = this.method_26(objk_);
					foreach (RCOLItem rcolitem in visualProxy.Entries)
					{
						VPXY vpxy = (VPXY)rcolitem;
						float[] boundingBox = vpxy.BoundingBox;
						float num = Math.Abs(boundingBox[3] - boundingBox[0]);
						float num2 = Math.Abs(boundingBox[5] - boundingBox[2]);
						this.objd_0.FloorCutoutBoundsLength = (float)Math.Ceiling((double)num / 1.0);
						this.objd_0.FloorCutoutBoundsWidth = (float)Math.Ceiling((double)num2 / 1.0);
					}
					flag = true;
				}
				if (this.objd_0.Version < 25U && value >= 25U)
				{
					uint version2 = this.objd_0.Version;
					TGIIndex tgiindex3 = null;
					foreach (TGIIndex tgiindex4 in this.objd_0.TgiIndex)
					{
						if (tgiindex4.Type == DBPFType.ALL && tgiindex4.InstanceId == 0)
						{
							tgiindex3 = tgiindex4;
						}
					}
					if (value >= 25U && tgiindex3 != null)
					{
						DialogResult dialogResult = MessageBox.Show(Class132.mainForm, string.Concat(new object[]
						{
							"EXPERIMENTAL!!!\n\nVersion 25 (0x19) uses a OBJD for the level below. Do you want to clone this object and use as the object below?\n\nClicking NO will use a NULL object and CANCEL will rever to version ",
							version2,
							" (0x",
							version2.ToString("X2"),
							")"
						}), "OBJD Below", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if (dialogResult == DialogResult.Yes)
						{
							Dictionary<string, string> dictionary_ = new Dictionary<string, string>();
							OBJD objd = Class80.smethod_1(this.objd_0, this.objd_0.DAEFilename + "_below", this.project.Package, true, 0, dictionary_, false, null);
							tgiindex3 = new TGIIndex(objd.GenerateResKey());
							this.objd_0.LevelBelowIndex = this.objd_0.AddTgi(this.objd_0.TgiIndex, tgiindex3);
							objd.Version = 22U;
							objd.DAEFilename = this.objd_0.DAEFilename + "_below";
							objd.CatalogDescEntry = objd + "below";
							if (objd.Materials.Count > 0)
							{
								foreach (OBJD.Material.ComplateVariable complateVariable in objd.Materials[0].Blocks[0].Variables)
								{
									if (complateVariable.VariableName.ToLower() == "daefilename")
									{
										complateVariable.SetValue(1, objd.DAEFilename);
									}
								}
							}
							this.project.Package.AddEntry(objd);
							flag = true;
						}
						else if (dialogResult == DialogResult.No)
						{
							tgiindex3 = new TGIIndex(new ResKey(DBPFType.OBJD, 0, 0, 0));
							this.objd_0.LevelBelowIndex = this.objd_0.AddTgi(this.objd_0.TgiIndex, tgiindex3);
						}
						else if (dialogResult == DialogResult.Cancel)
						{
							version = version2;
						}
					}
				}
				if (flag)
				{
					this.method_17();
				}
				this.objd_0.Version = version;
				this.method_2();
			}
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00069444 File Offset: 0x00067644
		public Class80(WorkshopProject project)
		{
			Class132.smethod_0().GroundEffect = MeshEditor.Enum8.const_0;
			this.list_0 = new List<Lod>();
			this.project = project;
			this.project.OnSave += this.method_32;
			this.lod_0 = Class132.mainForm.GetCurrentLOD();
			if (this.lod_0 != Lod.High)
			{
				this.lod_0 = Lod.High;
			}
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("launcherThumbnail"))
			{
				string key = this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["launcherThumbnail"];
				PNG png = this.project.Package.GetEntry(new ResKey(key)) as PNG;
				this.LauncherThumbnail = png.Image;
			}
			this.objdModelControl_0 = new ObjdModelControl(this)
			{
				Parent = Class132.mainForm.ProjectPanel,
				Dock = DockStyle.Fill
			};
			this.objdModelControl_0.SlotsPropertyGrid.Project = this;
			this.objdModelControl_0.PresetPropertyGrid.AdvancedMode = true;
			this.objdModelControl_0.PresetPropertyGrid.OnPresetChanged += this.method_34;
			this.objdModelControl_0.MLODPropertyGrid.Model = this;
			this.objdModelControl_0.SlotsPropertyGrid.PropertySelected += this.method_0;
			this.objdModelControl_0.ObjdPropertyGrid.PropertyChanged += this.method_12;
			this.objdModelControl_0.ObjdPropertyGrid.PropertyButtonClicked += this.method_1;
			this.objdModelControl_0.MiscPropertyGrid.PropertyButtonClicked += this.method_4;
			this.objdModelControl_0.MiscPropertyGrid.PropertySelected += this.method_3;
			this.method_17();
			this.objdModelControl_0.ObjdPropertyGrid.RegisterFeel("texture", new Class58(this.objdModelControl_0.ObjdPropertyGrid, false));
			this.objdModelControl_0.ObjdPropertyGrid.RegisterFeelAttachment(typeof(TextureResKey), "texture");
			this.objdModelControl_0.ObjdPropertyGrid.RegisterFeelAttachment(typeof(PatternResKey), "texture");
			PropertyEnumerator underCategory = this.objdModelControl_0.ObjdPropertyGrid.AppendRootCategory(0, "Object settings");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory, 1, "Name", this, "Title", "Title of object");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory, 2, "Description", this, "Description", "Title of object");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory, 3, "Price", this, "Price", "Price of object");
			PropertyEnumerator propertyEnumerator = this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory, 4, "Version", this, "Version", "Version of object");
			propertyEnumerator.Property.Feel = this.objdModelControl_0.ObjdPropertyGrid.GetRegisteredFeel("button");
			propertyEnumerator.Property.Tag = "versionProperty";
			PropertyEnumerator propertyEnumerator2 = this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory, 5, "Launcher thumbnail", this, "LauncherThumbnail", "Thumbnail image used in game launcher");
			propertyEnumerator2.Property.Tag = "_launcherThumbnail";
			PropertyEnumerator underCategory2 = this.objdModelControl_0.ObjdPropertyGrid.AppendSubCategory(underCategory, 6, "Category flags");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 7, "Build Buy Flags", this, "BuildBuyStatusFlags", "");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 8, "Function category", this, "Category", "");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 9, "Function sub category", this, "SubCategory", "");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 10, "Room category", this, "Room", "");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 11, "Room sub category", this, "SubRoom", "");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 12, "Build category", this, "BuildType", "");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 13, "ObjectTypeFlags", this, "ObjectTypeFlags", "ObjectTypeFlags of object");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 14, "ObjectTypeFlags2", this, "ObjectTypeFlags2", "ObjectTypeFlags2 of object");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 15, "WallPlacementFlags", this, "WallPlacementFlags", "WallPlacementFlags of object");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 16, "MovementFlags", this, "MovementFlags", "MovementFlags of object");
			this.objdModelControl_0.ObjdPropertyGrid.AppendProperty(underCategory2, 17, "SlotPlacementFlags", this, "SlotPlacementFlags", "SlotPlacementFlags of object");
			this.objdModelControl_0.MLODPropertyGrid.MeshChanged += this.method_16;
			this.objdModelControl_0.misc.Enabled = false;
			this.method_2();
			if (!this.objdModelControl_0.misc.Enabled)
			{
				this.objdModelControl_0.Tabs.TabPages.Remove(this.objdModelControl_0.misc);
			}
			this.objdModelControl_0.meshgroupCombo.SelectedIndexChanged += this.method_11;
			if (this.objdModelControl_0.meshgroupCombo.Items.Count > 0)
			{
				this.objdModelControl_0.meshgroupCombo.SelectedIndex = 0;
			}
			this.objdModelControl_0.objdComboBox.SelectedIndexChanged += this.method_10;
			this.objdModelControl_0.importMeshgroupButton.Click += this.method_21;
			this.objdModelControl_0.exportMeshgroupButton.Click += this.method_20;
			this.objdModelControl_0.generateShadowMeshButton.Click += this.method_5;
			this.objdModelControl_0.SlotsPropertyGrid.PropertyChanged += this.method_9;
			this.objdModelControl_0.MiscPropertyGrid.PropertyChanged += this.method_8;
			this.objdModelControl_0.ObjdPropertyGrid.PropertyChanged += this.method_12;
			this.objdModelControl_0.MLODPropertyGrid.PropertyChanged += this.method_7;
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00069AE4 File Offset: 0x00067CE4
		private void method_0(object sender, PropertySelectedEventArgs e)
		{
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag is Class17)
			{
				Class17 @class = e.PropertyEnum.Property.Value.Tag as Class17;
				if (this.class124_0 != null)
				{
					this.class124_0.Selected = false;
				}
				if (this.class124_0 != null && !Class132.mainForm.DisplayJointsButton.Checked)
				{
					this.class124_0.Visible = false;
				}
				if (this.class119_0 != null)
				{
					this.class119_0.Selected = false;
				}
				if (this.class119_0 != null && !Class132.mainForm.DisplayJointsButton.Checked)
				{
					this.class119_0.Visible = false;
				}
				foreach (Class124 class2 in this.Renderable.SkinEntries)
				{
					if (class2.GrannyBone.NameHash == @class.BoneHash)
					{
						Class124 class3 = class2;
						class2.Selected = true;
						class3.Visible = true;
						this.class124_0 = class2;
					}
				}
				foreach (Class119 class4 in this.Renderable.JointEntries)
				{
					if (class4.BoneEntry.NameHash == @class.BoneHash)
					{
						Class119 class5 = class4;
						class4.Selected = true;
						class5.Visible = true;
						this.class119_0 = class4;
					}
				}
			}
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00069C94 File Offset: 0x00067E94
		private void method_1(object sender, PropertyButtonClickedEventArgs e)
		{
			if (e.PropertyEnum.Property.DisplayName == "Description")
			{
				StblEditor stblEditor = new StblEditor(this.project.Package, (ulong)this.objd_0.DescGuid, this.Description, this.objd_0.SecondInstanceID);
				if (stblEditor.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					this.Description = stblEditor.text;
					e.PropertyEnum.Property.Value.SetValue(stblEditor.text);
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				}
			}
			else if (e.PropertyEnum.Property.DisplayName == "Name")
			{
				StblEditor stblEditor2 = new StblEditor(this.project.Package, (ulong)this.objd_0.NameGuid, this.Title, this.objd_0.SecondInstanceID);
				if (stblEditor2.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					this.Title = stblEditor2.text;
					e.PropertyEnum.Property.Value.SetValue(stblEditor2.text);
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				}
			}
			else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("versionProperty"))
			{
				ObjdVersionDialog objdVersionDialog = new ObjdVersionDialog(this.objd_0);
				if (objdVersionDialog.ShowDialog(Class132.mainForm) == DialogResult.OK && objdVersionDialog.Version != 0U)
				{
					this.Version = objdVersionDialog.Version;
				}
			}
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00069E2C File Offset: 0x0006802C
		public void method_2()
		{
			int num = 0;
			Class2 miscPropertyGrid = this.objdModelControl_0.MiscPropertyGrid;
			miscPropertyGrid.Clear();
			VisualHint.SmartPropertyGrid.PropertyGrid propertyGrid = miscPropertyGrid;
			int id = 0;
			num = 1;
			PropertyEnumerator underCategory = propertyGrid.AppendRootCategory(id, "Misc masks");
			if (this.objd_0.Version > 0U)
			{
				this.objdModelControl_0.misc.Enabled = true;
				TextureResKey initialValue = new TextureResKey(this.objd_0.TgiIndex[this.objd_0.SinkMask].Reskey);
				PropertyEnumerator propertyEnumerator = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Sink mask", typeof(TextureResKey), initialValue, "");
				propertyEnumerator.Property.Value.Tag = this.objd_0.TgiIndex[this.objd_0.SinkMask];
				Class61 @class = new Class61();
				propertyEnumerator.Property.Value.Look = @class;
				@class.PropertyChanged += this.method_14;
			}
			if (this.objd_0.Version >= 23U)
			{
				this.objdModelControl_0.misc.Enabled = true;
				PropertyEnumerator propertyEnumerator2 = miscPropertyGrid.AppendProperty(underCategory, num++, "Show floor mask", this, "ShowFloorMask", "");
				propertyEnumerator2.Property.Feel = miscPropertyGrid.GetRegisteredFeel("checkbox");
				TextureResKey initialValue2 = new TextureResKey(this.objd_0.TgiIndex[this.objd_0.FloorMaskIndex].Reskey);
				PropertyEnumerator propertyEnumerator3 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Floor mask", typeof(TextureResKey), initialValue2, "");
				propertyEnumerator3.Property.Value.Tag = this.objd_0.TgiIndex[this.objd_0.FloorMaskIndex];
				Class61 class2 = new Class61();
				propertyEnumerator3.Property.Value.Look = class2;
				class2.PropertyChanged += this.method_13;
				propertyEnumerator3 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Floor Cutout Level Offset", typeof(uint), this.objd_0.FloorCutoutLevelOffset, "");
				propertyEnumerator3.Property.Tag = "FloorCutoutLevelOffset";
				propertyEnumerator3 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Floor Cutout Bounds Length", typeof(float), this.objd_0.FloorCutoutBoundsLength, "");
				propertyEnumerator3.Property.Tag = "FloorCutoutBoundsLength";
				if (this.objd_0.Version >= 32U)
				{
					propertyEnumerator3 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Floor Cutout Bounds Width", typeof(float), this.objd_0.FloorCutoutBoundsWidth, "");
					propertyEnumerator3.Property.Tag = "FloorCutoutBoundsWidth";
					if (this.objd_0.Version >= 33U)
					{
						propertyEnumerator3 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Floor Cutout Offset X", typeof(float), this.objd_0.FloorCutoutOffsetX, "");
						propertyEnumerator3.Property.Tag = "FloorCutoutOffsetX";
						propertyEnumerator3 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Floor Cutout Offset Y", typeof(float), this.objd_0.FloorCutoutOffsetY, "");
						propertyEnumerator3.Property.Tag = "FloorCutoutOffsetY";
					}
				}
			}
			if (this.objd_0.Version >= 25U)
			{
				this.objdModelControl_0.misc.Enabled = true;
				TextureResKey initialValue3 = new TextureResKey(this.objd_0.TgiIndex[this.objd_0.LevelBelowIndex].Reskey);
				PropertyEnumerator propertyEnumerator4 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Level below", typeof(ResKey), initialValue3, "");
				propertyEnumerator4.Property.Value.Tag = this.objd_0.TgiIndex[this.objd_0.LevelBelowIndex];
			}
			if (this.objd_0.Version >= 30U)
			{
				this.objdModelControl_0.misc.Enabled = true;
				TextureResKey textureResKey = new TextureResKey(this.objd_0.TgiIndex[this.objd_0.BluePrintIconIndex].Reskey);
				if (textureResKey.TypeId == 11720834U)
				{
					PropertyEnumerator propertyEnumerator5 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Blueprint Icon", typeof(TextureResKey), textureResKey, "");
					propertyEnumerator5.Property.Value.Tag = this.objd_0.TgiIndex[this.objd_0.BluePrintIconIndex];
					Class61 class3 = new Class61();
					propertyEnumerator5.Property.Value.Look = class3;
					class3.PropertyChanged += this.method_14;
				}
				if (this.objd_0.Version >= 31U)
				{
					PropertyEnumerator propertyEnumerator6 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Blueprint Icon OFfset Min X", typeof(float), this.objd_0.BluePrintIconOffsetMinX, "");
					propertyEnumerator6.Property.Tag = "BluePrintIconOffsetMinX";
					propertyEnumerator6 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Blueprint Icon OFfset Max X", typeof(float), this.objd_0.BluePrintIconOffsetMaxX, "");
					propertyEnumerator6.Property.Tag = "BluePrintIconOffsetMaxX";
					propertyEnumerator6 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Blueprint Icon OFfset Min Z", typeof(float), this.objd_0.BluePrintIconOffsetMinZ, "");
					propertyEnumerator6.Property.Tag = "BluePrintIconOffsetMinZ";
					propertyEnumerator6 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Blueprint Icon OFfset Max Z", typeof(float), this.objd_0.BluePrintIconOffsetMaxZ, "");
					propertyEnumerator6.Property.Tag = "BluePrintIconOffsetMaxZ";
				}
			}
			if (this.objd_0.WallMaskCount > 0 || (this.objd_0.ObjectType & OBJD.ObjectTypeFlags.IsWindow) != (OBJD.ObjectTypeFlags)0U || (this.objd_0.ObjectType & OBJD.ObjectTypeFlags.IsDoor) != (OBJD.ObjectTypeFlags)0U)
			{
				this.objdModelControl_0.misc.Enabled = true;
				PropertyEnumerator underCategory2 = miscPropertyGrid.AppendRootCategory(num++, "Wall masks");
				PropertyEnumerator propertyEnumerator7 = miscPropertyGrid.AppendProperty(underCategory2, num++, "Show wall", this, "ShowWall", "");
				propertyEnumerator7.Property.Feel = miscPropertyGrid.GetRegisteredFeel("checkbox");
				miscPropertyGrid.AppendProperty(underCategory2, num++, "Wall color", this.Renderable, "WallColor", "");
				int num2 = 0;
				foreach (OBJD.WallMask wallMask in this.objd_0.WallMasks)
				{
					TextureResKey initialValue4 = new TextureResKey(this.objd_0.TgiIndex[wallMask.DdsIndex].Reskey);
					PropertyEnumerator propertyEnumerator8 = miscPropertyGrid.AppendManagedProperty(underCategory2, num++, string.Concat(new object[]
					{
						"Tile ",
						(num2 < 2) ? 1 : ((num2 < 4) ? 2 : 3),
						" ",
						(num2 % 2 == 0) ? "Inside" : "Outside"
					}), typeof(TextureResKey), initialValue4, "");
					propertyEnumerator8.Property.Value.Tag = this.objd_0.TgiIndex[wallMask.DdsIndex];
					propertyEnumerator8.Property.Tag = wallMask;
					Class61 class4 = new Class61();
					propertyEnumerator8.Property.Value.Look = class4;
					class4.PropertyChanged += this.method_15;
					PropertyEnumerator propertyEnumerator9 = miscPropertyGrid.AppendManagedProperty(propertyEnumerator8, num++, "Float 1", typeof(float), wallMask.F1, "");
					propertyEnumerator9.Property.Value.Tag = "float1";
					propertyEnumerator9.Property.Tag = wallMask;
					PropertyEnumerator propertyEnumerator10 = miscPropertyGrid.AppendManagedProperty(propertyEnumerator8, num++, "Float 2", typeof(float), wallMask.F2, "");
					propertyEnumerator10.Property.Value.Tag = "float2";
					propertyEnumerator10.Property.Tag = wallMask;
					PropertyEnumerator propertyEnumerator11 = miscPropertyGrid.AppendManagedProperty(propertyEnumerator8, num++, "Float 3", typeof(float), wallMask.F3, "");
					propertyEnumerator11.Property.Value.Tag = "float3";
					propertyEnumerator11.Property.Tag = wallMask;
					PropertyEnumerator propertyEnumerator12 = miscPropertyGrid.AppendManagedProperty(propertyEnumerator8, num++, "Float 4", typeof(float), wallMask.F4, "");
					propertyEnumerator12.Property.Value.Tag = "float4";
					propertyEnumerator12.Property.Tag = wallMask;
					num2++;
				}
				PropertyEnumerator propertyEnumerator13 = miscPropertyGrid.AppendManagedProperty(underCategory2, num++, "Generate", typeof(string), "", "");
				propertyEnumerator13.Property.Feel = miscPropertyGrid.GetRegisteredFeel("button");
				propertyEnumerator13.Property.Tag = "genereateWallmask";
				PropertyEnumerator propertyEnumerator14 = miscPropertyGrid.AppendManagedProperty(underCategory2, num++, "Edit", typeof(string), "", "");
				propertyEnumerator14.Property.Feel = miscPropertyGrid.GetRegisteredFeel("button");
				propertyEnumerator14.Property.Tag = "freehandWallmask";
			}
			List<ResKey> list = this.project.Package.SearchEntries(new ResKey(DBPFType.LITE));
			if (list.Count > 0)
			{
				this.objdModelControl_0.misc.Enabled = true;
				PropertyEnumerator underCategory3 = miscPropertyGrid.AppendRootCategory(num++, "Lights");
				int num3 = 0;
				foreach (ResKey resKey in list)
				{
					PropertyEnumerator propertyEnumerator15 = miscPropertyGrid.AppendManagedProperty(underCategory3, num++, "Light " + num3++, typeof(string), "", "");
					propertyEnumerator15.Property.Feel = miscPropertyGrid.GetRegisteredFeel("button");
					propertyEnumerator15.Property.Tag = resKey;
					LightResource lightResource = Class76.smethod_26(resKey) as LightResource;
					if (lightResource != null)
					{
						foreach (RCOLItem rcolitem in lightResource.Entries)
						{
							LITE lite = (LITE)rcolitem;
							foreach (LITE.LightEntry tag in lite.Entries128)
							{
								PropertyEnumerator propertyEnumerator16 = miscPropertyGrid.AppendManagedProperty(propertyEnumerator15, num++, "Light 128", typeof(string), "", "");
								propertyEnumerator16.Property.Tag = tag;
							}
							foreach (LITE.LightEntry tag2 in lite.Entries56)
							{
								PropertyEnumerator propertyEnumerator17 = miscPropertyGrid.AppendManagedProperty(propertyEnumerator15, num++, "Light 56", typeof(string), "", "");
								propertyEnumerator17.Property.Tag = tag2;
							}
						}
					}
				}
			}
			Class132.smethod_0().ShadowMapDirty = true;
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x0006AA80 File Offset: 0x00068C80
		private void method_3(object sender, PropertySelectedEventArgs e)
		{
			foreach (Class120 @class in this.Renderable.Lites)
			{
				@class.Visible = false;
				object tag = e.PropertyEnum.Property.Tag;
				if (tag is ResKey)
				{
					@class.Visible = @class.Reskey.Equals(tag as ResKey);
				}
				else if (tag is Class120)
				{
					@class.Visible = @class.Equals(tag as Class120);
				}
				else if (tag != null)
				{
					@class.Visible = @class.Tag.Equals(tag);
				}
			}
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0006AB40 File Offset: 0x00068D40
		private void method_4(object sender, PropertyButtonClickedEventArgs e)
		{
			if (e.PropertyEnum.Property.Tag is ResKey && (e.PropertyEnum.Property.Tag as ResKey).TypeId == 62178845U)
			{
				LiteEditor liteEditor = new LiteEditor(e.PropertyEnum.Property.Tag as ResKey);
				if (liteEditor.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
					RCOL literesource = liteEditor.LITEResource;
					ResKey resKey_ = e.PropertyEnum.Property.Tag as ResKey;
					RCOL rcol = Class76.smethod_26(resKey_) as RCOL;
					if (liteEditor.AddedLights)
					{
						for (int i = 0; i < literesource.Entries.Count; i++)
						{
							rcol.Entries[i] = literesource.Entries[i];
						}
						this.project.Package.AddEntry(rcol);
						this.method_16(true);
					}
					else
					{
						for (int j = 0; j < literesource.Entries.Count; j++)
						{
							for (int k = 0; k < (rcol.Entries[j] as LITE).Entries128.Count; k++)
							{
								LITE.LightEntry lightEntry = (rcol.Entries[j] as LITE).Entries128[k];
								LITE.LightEntry lightEntry2 = (literesource.Entries[j] as LITE).Entries128[k];
								foreach (Class120 @class in this.Renderable.Lites)
								{
									if (@class.Tag.Equals(lightEntry))
									{
										@class.Tag = lightEntry2;
										@class.method_1(Class140.smethod_0().Device);
									}
								}
								foreach (object obj in this.objdModelControl_0.MiscPropertyGrid)
								{
									if (obj is Property)
									{
										Property property = obj as Property;
										if (property.Tag == lightEntry)
										{
											property.Tag = lightEntry2;
										}
									}
								}
								(rcol.Entries[j] as LITE).Entries128[k] = lightEntry2;
							}
							for (int l = 0; l < (rcol.Entries[j] as LITE).Entries56.Count; l++)
							{
								LITE.LightEntry lightEntry3 = (rcol.Entries[j] as LITE).Entries56[l];
								LITE.LightEntry lightEntry4 = (literesource.Entries[j] as LITE).Entries56[l];
								foreach (Class120 class2 in this.Renderable.Lites)
								{
									if (class2.Tag.Equals(lightEntry3))
									{
										class2.Tag = lightEntry4;
										class2.method_1(Class140.smethod_0().Device);
									}
								}
								foreach (object obj2 in this.objdModelControl_0.MiscPropertyGrid)
								{
									if (obj2 is Property)
									{
										Property property2 = obj2 as Property;
										if (property2.Tag == lightEntry3)
										{
											property2.Tag = lightEntry4;
										}
									}
								}
								(rcol.Entries[j] as LITE).Entries56[l] = lightEntry4;
							}
						}
					}
				}
			}
			else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.ToString() == "genereateWallmask")
			{
				GenerateWallmask generateWallmask = new GenerateWallmask();
				if (generateWallmask.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					this.method_2();
				}
			}
			else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.ToString() == "freehandWallmask")
			{
				if (Class132.smethod_0().SelectionDialog == null)
				{
					WallmaskControls wallmaskControls = WallmaskControls.smethod_0();
					Class132.smethod_0().SelectionDialog = wallmaskControls;
					wallmaskControls.Visible = true;
					wallmaskControls.Parent = Class132.smethod_0().RenderPanel;
					wallmaskControls.Dock = DockStyle.Top;
					wallmaskControls.Visible = true;
					Class132.mainForm.Render();
				}
				else
				{
					WallmaskControls.smethod_0().Visible = false;
					Class132.smethod_0().SelectionDialog = null;
				}
			}
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0006AFFC File Offset: 0x000691FC
		private void method_5(object sender, EventArgs e)
		{
			Class3.Class24 @class = this.objdModelControl_0.meshgroupCombo.SelectedItem as Class3.Class24;
			if (@class.MLOD.Entries.Count > 1)
			{
				MessageBox.Show("Can not generate multigrouped shadow mesh.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				List<MLOD> list = new List<MLOD>();
				foreach (object obj in this.objdModelControl_0.meshgroupCombo.Items)
				{
					Class3.Class24 class2 = (Class3.Class24)obj;
					list.Add(class2.MLOD);
				}
				PickMLOD pickMLOD = new PickMLOD(list);
				if (pickMLOD.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					this.method_6(pickMLOD.Entries);
					this.method_22(@class.MLOD.Parent as MLODModel);
					this.method_16(true);
				}
			}
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0006B0F4 File Offset: 0x000692F4
		private void method_6(List<object[]> list_1)
		{
			Class3.Class24 @class = this.objdModelControl_0.meshgroupCombo.SelectedItem as Class3.Class24;
			MLOD.MLODEntry mlodentry = @class.MLOD.Entries[0];
			List<short> list = new List<short>();
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			foreach (object[] array in list_1)
			{
				MLOD mlod = array[0] as MLOD;
				MLOD.MLODEntry mlodentry2 = array[1] as MLOD.MLODEntry;
				RCOL parent = mlod.Parent;
				VBUF vbuf = parent.Entries[mlodentry2.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)] as VBUF;
				IBUF ibuf = parent.Entries[mlodentry2.IBUFIndex + ((parent.dataType == 2) ? 1 : 0)] as IBUF;
				VRTF vrtf = parent.Entries[mlodentry2.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] as VRTF;
				if (vrtf == null)
				{
					vrtf = VRTF.GetDefaultForLength(vbuf.BufferLength / mlodentry2.VertexCount);
				}
				for (int i = 0; i < mlodentry2.VertexCount; i++)
				{
					Package.Geometry.Vector4 position = vbuf.GetPosition(vrtf, i, mlodentry2.VBUFOffset, 0);
					float num5 = position.X;
					float num6 = position.Y;
					float num7 = position.Z;
					float num8 = 32767f;
					float num9 = Math.Max(Math.Max(Math.Abs(num5), Math.Abs(num6)), Math.Abs(num7));
					if (num9 > 1f)
					{
						num8 = (float)(32767 / (int)Math.Ceiling((double)num9));
					}
					num5 = num8 * num5;
					num6 = num8 * num6;
					num7 = num8 * num7;
					binaryWriter.Write((short)num5);
					binaryWriter.Write((short)num6);
					binaryWriter.Write((short)num7);
					binaryWriter.Write((short)num8);
					num3++;
				}
				for (int j = 0; j < mlodentry2.FaceCount * 3; j++)
				{
					list.Add((short)((int)ibuf.Index[(int)(checked((IntPtr)(unchecked((long)j + mlodentry2.IBUFOffset))))] + num));
					num4++;
				}
				num += mlodentry2.VertexCount;
				num2 += mlodentry2.FaceCount * 3;
			}
			RCOL parent2 = @class.MLOD.Parent;
			VBUF vbuf2 = parent2.Entries[mlodentry.VBUFIndex + ((parent2.dataType == 2) ? 1 : 0)] as VBUF;
			IBUF ibuf2 = parent2.Entries[mlodentry.IBUFIndex + ((parent2.dataType == 2) ? 1 : 0)] as IBUF;
			mlodentry.VertexCount = num3;
			mlodentry.FaceCount = num4 / 3;
			vbuf2.Buffer = memoryStream.ToArray();
			mlodentry.VBUFOffset = 0L;
			ibuf2.Index = list.ToArray();
			mlodentry.IBUFOffset = 0L;
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00002A71 File Offset: 0x00000C71
		private void method_7(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0006B420 File Offset: 0x00069620
		private void method_8(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			bool flag = false;
			if (e.PropertyEnum.Property.Tag is OBJD.WallMask)
			{
				if (e.PropertyEnum.Property.Value.Tag.Equals("float1"))
				{
					(e.PropertyEnum.Property.Tag as OBJD.WallMask).F1 = (float)e.PropertyEnum.Property.Value.GetValue();
				}
				if (e.PropertyEnum.Property.Value.Tag.Equals("float2"))
				{
					(e.PropertyEnum.Property.Tag as OBJD.WallMask).F2 = (float)e.PropertyEnum.Property.Value.GetValue();
				}
				if (e.PropertyEnum.Property.Value.Tag.Equals("float3"))
				{
					(e.PropertyEnum.Property.Tag as OBJD.WallMask).F3 = (float)e.PropertyEnum.Property.Value.GetValue();
				}
				if (e.PropertyEnum.Property.Value.Tag.Equals("float4"))
				{
					(e.PropertyEnum.Property.Tag as OBJD.WallMask).F4 = (float)e.PropertyEnum.Property.Value.GetValue();
				}
				using (List<Class102>.Enumerator enumerator = Class132.smethod_0().Renderables.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Class102 @class = enumerator.Current;
						Class105 class2 = (Class105)@class;
						if (class2 != null)
						{
							class2.method_15(Class140.smethod_0().Device);
						}
					}
					goto IL_32F;
				}
			}
			if ("FloorCutoutLevelOffset".Equals(e.PropertyEnum.Property.Tag))
			{
				this.objd_0.FloorCutoutLevelOffset = (uint)e.PropertyEnum.Property.Value.GetValue();
				flag = true;
			}
			else if ("FloorCutoutBoundsLength".Equals(e.PropertyEnum.Property.Tag))
			{
				this.objd_0.FloorCutoutBoundsLength = (float)e.PropertyEnum.Property.Value.GetValue();
				flag = true;
			}
			else if ("FloorCutoutBoundsWidth".Equals(e.PropertyEnum.Property.Tag))
			{
				this.objd_0.FloorCutoutBoundsWidth = (float)e.PropertyEnum.Property.Value.GetValue();
				flag = true;
			}
			else if ("FloorCutoutOffsetX".Equals(e.PropertyEnum.Property.Tag))
			{
				this.objd_0.FloorCutoutOffsetX = (float)e.PropertyEnum.Property.Value.GetValue();
				flag = true;
			}
			else if ("FloorCutoutOffsetY".Equals(e.PropertyEnum.Property.Tag))
			{
				this.objd_0.FloorCutoutOffsetY = (float)e.PropertyEnum.Property.Value.GetValue();
				flag = true;
			}
			IL_32F:
			if (flag)
			{
				Class132.smethod_0().method_3(this.Renderable);
				this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
			}
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x000056E9 File Offset: 0x000038E9
		private void method_9(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0006B798 File Offset: 0x00069998
		private void method_10(object sender, EventArgs e)
		{
			if (!this.bool_1)
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
				this.int_0 = this.objdModelControl_0.objdComboBox.SelectedIndex;
				this.method_17();
				if (this.objdModelControl_0.meshgroupCombo.Items.Count > 0)
				{
					this.objdModelControl_0.meshgroupCombo.SelectedIndex = 0;
				}
			}
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x0006B848 File Offset: 0x00069A48
		private void method_11(object sender, EventArgs e)
		{
			Class3.Class22 @class = this.objdModelControl_0.meshgroupCombo.SelectedItem as Class3.Class22;
			if (@class != null)
			{
				this.objdModelControl_0.MLODPropertyGrid.method_9(@class);
				this.objdModelControl_0.GeostateCombo.Enabled = false;
				if (this.objdModelControl_0.MLODPropertyGrid.list_1.Count > 0)
				{
					this.objdModelControl_0.GeostateCombo.Enabled = true;
					this.objdModelControl_0.GeostateCombo.Items.Clear();
					this.objdModelControl_0.GeostateCombo.Items.Add("None");
					this.objdModelControl_0.GeostateCombo.Items.AddRange(this.objdModelControl_0.MLODPropertyGrid.list_1.ToArray());
				}
				if (@class is Class3.Class24)
				{
					this.objdModelControl_0.Rotationtrackbar.Enabled = true;
					Class3.Class24 class2 = @class as Class3.Class24;
					this.objdModelControl_0.generateShadowMeshButton.Enabled = (class2.MODLEntry.LOD == 65536U || class2.MODLEntry.LOD == 65537U || class2.MODLEntry.LOD == 65538U);
					Class132.mainForm.SetCurrentLOD((Lod)class2.MODLEntry.LOD);
				}
				else
				{
					this.objdModelControl_0.Rotationtrackbar.Enabled = false;
				}
				this.method_2();
			}
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0006B9B4 File Offset: 0x00069BB4
		private void method_12(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			object value = e.PropertyEnum.Property.Value.GetValue();
			Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_launcherThumbnail"))
			{
				if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("launcherThumbnail"))
				{
					string key = this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["launcherThumbnail"];
					PNG png = this.project.Package.GetEntry(new ResKey(key)) as PNG;
					png.Image = (value as Bitmap);
				}
				else
				{
					PNG png2 = new PNG();
					png2.Image = (value as Bitmap);
					Random random = new Random((int)DateTime.Now.Ticks);
					png2.InstanceID = random.Next();
					png2.SecondInstanceID = random.Next();
					png2.GroupID = this.objd_0.GroupID;
					this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("launcherThumbnail", png2.GenerateResKey());
					this.project.Package.AddEntry(png2);
				}
			}
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0006BAF8 File Offset: 0x00069CF8
		private void method_13(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
		{
			TGIIndex tgiindex = null;
			if (propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.Tag is TGIIndex)
			{
				tgiindex = (propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.Tag as TGIIndex);
			}
			tgiindex.Reskey = resKey_0.AsString();
			propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.SetValue(resKey_0);
			(propertyButtonClickedEventArgs_0.PropertyEnum.Property.Look as Class61).NeedsUpdate = true;
			Class132.smethod_0().method_3(this.Renderable);
			this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00021008 File Offset: 0x0001F208
		private void method_14(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
		{
			TGIIndex tgiindex = null;
			if (propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.Tag is TGIIndex)
			{
				tgiindex = (propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.Tag as TGIIndex);
			}
			tgiindex.Reskey = resKey_0.AsString();
			propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.SetValue(resKey_0);
			(propertyButtonClickedEventArgs_0.PropertyEnum.Property.Look as Class61).NeedsUpdate = true;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0006BBA4 File Offset: 0x00069DA4
		private void method_15(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
		{
			TGIIndex tgiindex = null;
			if (propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.Tag is TGIIndex)
			{
				tgiindex = (propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.Tag as TGIIndex);
			}
			DialogResult dialogResult = MessageBox.Show("Do you want to update the wallmask on all tiles referencing this mask?", "Update wallmask", MessageBoxButtons.YesNoCancel);
			if (dialogResult != DialogResult.Cancel)
			{
				if (dialogResult == DialogResult.No)
				{
					OBJD.WallMask wallMask = propertyButtonClickedEventArgs_0.PropertyEnum.Property.Tag as OBJD.WallMask;
					TGIIndex newtgi = new TGIIndex(resKey_0);
					wallMask.DdsIndex = this.objd_0.AddTgi(this.objd_0.TgiIndex, newtgi);
					(propertyButtonClickedEventArgs_0.PropertyEnum.Property.Look as Class61).NeedsUpdate = true;
					propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.SetValue(resKey_0);
				}
				else
				{
					tgiindex.Reskey = resKey_0.AsString();
					IEnumerator enumerator = this.objdModelControl_0.MiscPropertyGrid.GetEnumerator();
					do
					{
						object obj = enumerator.Current;
						if (obj != null)
						{
							obj.GetType();
							if (obj is Property && (obj as Property).Value != null && (obj as Property).Value.Tag is TGIIndex)
							{
								TGIIndex tgiindex2 = (obj as Property).Value.Tag as TGIIndex;
								if (tgiindex2.Equals(resKey_0))
								{
									((obj as Property).Look as Class61).NeedsUpdate = true;
									(obj as Property).Value.SetValue(resKey_0);
								}
							}
						}
					}
					while (enumerator.MoveNext());
				}
				Class132.smethod_0().method_3(this.Renderable);
				this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
			}
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0006BD74 File Offset: 0x00069F74
		public void method_16(bool bool_3)
		{
			int selectedIndex = this.objdModelControl_0.meshgroupCombo.SelectedIndex;
			int selectedIndex2 = this.objdModelControl_0.GeostateCombo.SelectedIndex;
			if (bool_3)
			{
				Class132.smethod_0().method_3(this.Renderable);
				this.method_24();
				this.objdModelControl_0.MLODPropertyGrid.Clear();
				this.objdModelControl_0.SlotsPropertyGrid.method_0(this.Renderable);
				this.objdModelControl_0.meshgroupCombo.SelectedIndex = selectedIndex;
				this.objdModelControl_0.GeostateCombo.SelectedIndex = selectedIndex2;
				Class132.smethod_0().ShadowMapDirty = true;
			}
			this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0006BE28 File Offset: 0x0006A028
		private void method_17()
		{
			this.bool_1 = true;
			this.method_41();
			List<ResKey> list = this.project.Package.SearchEntries(new ResKey(DBPFType.OBJD));
			if (list.Count > 1)
			{
				int selectedIndex = this.objdModelControl_0.objdComboBox.SelectedIndex;
				this.objdModelControl_0.objdComboBox.Items.Clear();
				this.objdModelControl_0.objdSelectorPanel.Visible = true;
				foreach (ResKey key in list)
				{
					OBJD objd = this.project.Package.GetEntry(key) as OBJD;
					bool flag = false;
					if (objd.Materials.Count > 0)
					{
						foreach (OBJD.Material.ComplateVariable complateVariable in objd.Materials[0].Blocks[0].Variables)
						{
							if (complateVariable.VariableName.ToLower() == "daefilename")
							{
								this.objdModelControl_0.objdComboBox.Items.Add(complateVariable.GetValue());
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						this.objdModelControl_0.objdComboBox.Items.Add(objd.DAEFilename);
					}
				}
				this.objdModelControl_0.objdComboBox.SelectedIndex = ((selectedIndex == -1) ? 0 : selectedIndex);
			}
			else
			{
				this.objdModelControl_0.objdSelectorPanel.Visible = false;
				this.objdModelControl_0.objdComboBox.Items.Clear();
			}
			this.objd_0 = (this.project.Package.GetEntry(list[this.int_0]) as OBJD);
			List<ResKey> list2 = this.project.Package.SearchEntries(new ResKey(DBPFType.PACKDESC));
			if (list2.Count == 0)
			{
				this.packageDescriptor_0 = new PackageDescriptor();
				this.packageDescriptor_0.Manifest.Add("version", 3);
				this.packageDescriptor_0.Manifest.Add("packagetype", "object");
				this.packageDescriptor_0.Manifest.Add("paidContent", "false");
				this.Title = "new objd project";
				this.Description = "no description";
				this.project.Package.AddEntry(this.packageDescriptor_0);
			}
			else
			{
				this.packageDescriptor_0 = (this.project.Package.GetEntry(list2[0]) as PackageDescriptor);
				this.Title = this.packageDescriptor_0.Title;
				this.Description = this.packageDescriptor_0.Description;
			}
			if (this.Renderable != null)
			{
				Class132.smethod_0().method_25(this.Renderable);
			}
			GeneralProgress.Class93 @class = GeneralProgress.smethod_0("Adding mesh, please wait...");
			@class.ProgressForm.FormClosed += Class132.mainForm.ProgressForm_FormClosed;
			@class.ProgressForm.MaxValue = 3;
			@class.DoWork += this.method_19;
			@class.RunWorkerCompleted += this.method_18;
			@class.Disposed += Class80.smethod_0;
			@class.method_0();
			this.bool_1 = false;
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0006C1B0 File Offset: 0x0006A3B0
		private void method_18(object sender, RunWorkerCompletedEventArgs e)
		{
			this.objdModelControl_0.MLODPropertyGrid.Clear();
			this.objdModelControl_0.SlotsPropertyGrid.method_0(this.Renderable);
			if (this.objdModelControl_0.VariationCombo.Items.Count > 0)
			{
				this.objdModelControl_0.VariationCombo.SelectedIndex = 0;
			}
			((GeneralProgress.Class93)sender).method_1();
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0006C21C File Offset: 0x0006A41C
		private void method_19(object sender, DoWorkEventArgs e)
		{
			((GeneralProgress.Class93)sender).ProgressForm.method_3(1f, "Loading meshes...");
			this.Renderable = new Class105(this.objd_0, this.lod_0);
			this.Renderable.IsDiagonal = ((this.objd_0.ObjectType & OBJD.ObjectTypeFlags.IsDiagonal) != (OBJD.ObjectTypeFlags)0U);
			Class132.smethod_0().method_2(this.Renderable);
			Class132.smethod_0().method_46();
			((GeneralProgress.Class93)sender).ProgressForm.method_3(2f, "Loading materials...");
			this.method_28();
			((GeneralProgress.Class93)sender).ProgressForm.method_3(3f, "Loading models...");
			this.method_24();
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x000054DB File Offset: 0x000036DB
		private static void smethod_0(object sender, EventArgs e)
		{
			MessageBox.Show("DISPOSED");
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0006C2D8 File Offset: 0x0006A4D8
		private void method_20(object sender, EventArgs e)
		{
			Class3.Class22 @class = this.objdModelControl_0.meshgroupCombo.SelectedItem as Class3.Class22;
			if (@class != null)
			{
				if (@class is Class3.Class24)
				{
					Class3.Class24 class2 = @class as Class3.Class24;
					RCOL rcol = class2.MLOD.Parent.Clone() as RCOL;
					RCOL parent = class2.MLOD.Parent;
					RCOL rcol2 = rcol;
					MLOD mlod = null;
					MLOD mlod2 = null;
					if (parent is MLODModel)
					{
						mlod = (parent.Entries[0] as MLOD);
						mlod2 = (rcol2.Entries[0] as MLOD);
					}
					else
					{
						for (int i = 0; i < parent.Entries.Count; i++)
						{
							RCOLItem rcolitem = parent.Entries[i];
							RCOLItem rcolitem2 = parent.Entries[i];
							if (rcolitem is MLOD)
							{
								mlod = (rcolitem as MLOD);
								mlod2 = (rcolitem2 as MLOD);
							}
						}
					}
					for (int j = 0; j < mlod.Entries.Count; j++)
					{
						mlod2.Entries[j].Name = mlod.Entries[j].Name;
					}
					if (Class132.mainForm.ExportFile(DBPFType.MLOD, rcol) == PluginResult.OK)
					{
						MessageBox.Show(null, "Export complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else if (@class is Class3.Class23)
				{
					Class3.Class23 class3 = @class as Class3.Class23;
					if (Class132.mainForm.ExportFile(DBPFType.SPTR, class3.SpeedTree) == PluginResult.OK)
					{
						MessageBox.Show(null, "Export complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0006C470 File Offset: 0x0006A670
		private void method_21(object sender, EventArgs e)
		{
			Class3.Class22 @class = this.objdModelControl_0.meshgroupCombo.SelectedItem as Class3.Class22;
			if (@class != null)
			{
				if (@class is Class3.Class24)
				{
					Class3.Class24 class2 = @class as Class3.Class24;
					RCOL parent = class2.MLOD.Parent;
					RCOL rcol = parent.Clone() as RCOL;
					if (rcol is MODLModel)
					{
						MODLModel modlmodel = rcol as MODLModel;
						for (int i = 0; i < modlmodel.Entries.Count; i++)
						{
							RCOLItem rcolitem = modlmodel.Entries[i];
							if (rcolitem is MLOD)
							{
								MLOD mlod = rcolitem as MLOD;
								for (int j = 0; j < mlod.Entries.Count; j++)
								{
									mlod.Entries[j].Visible = (parent.Entries[i] as MLOD).Entries[j].Visible;
									mlod.Entries[j].Expanded = (parent.Entries[i] as MLOD).Entries[j].Expanded;
								}
							}
						}
					}
					if (Class132.mainForm.ImportFile(DBPFType.MLOD, rcol) == PluginResult.OK)
					{
						MessageBox.Show(null, "Import complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						Class132.mainForm.CurrentProject.Package.AddEntry(rcol);
						if ((class2.MODLEntry.LOD == 65536U || class2.MODLEntry.LOD == 65538U || class2.MODLEntry.LOD == 65537U) && MessageBox.Show(null, "You have imported a shadow mesh.\nDo you want workshop to autogenerate a shadow mesh from this mesh?", "Shadow mesh", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							this.method_22(rcol as MLODModel);
						}
						this.method_23();
						this.method_16(true);
					}
				}
				else if (@class is Class3.Class23)
				{
					Class3.Class23 class3 = @class as Class3.Class23;
					if (Class132.mainForm.ImportFile(DBPFType.SPTR, class3.SpeedTree) == PluginResult.OK)
					{
						MessageBox.Show(null, "Import complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
						class3.SpeedTree.UnSerialize();
						this.method_16(true);
					}
				}
			}
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0006C6B0 File Offset: 0x0006A8B0
		private void method_22(MLODModel mlodmodel_0)
		{
			OBJK objk_ = this.method_27();
			this.method_26(objk_);
			SlimDX.Vector3 left = new SlimDX.Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			SlimDX.Vector3 right = new SlimDX.Vector3(float.MinValue, float.MinValue, float.MinValue);
			MLOD.MLODEntry mlodentry = (mlodmodel_0.Entries[0] as MLOD).Entries[0];
			VRTF vrtf = mlodmodel_0.Entries[mlodentry.VRTFIndex + ((mlodmodel_0.dataType == 2) ? 1 : 0)] as VRTF;
			VBUF vbuf = mlodmodel_0.Entries[mlodentry.VBUFIndex + ((mlodmodel_0.dataType == 2) ? 1 : 0)] as VBUF;
			if (vrtf == null)
			{
				vrtf = VRTF.GetDefaultForLength((mlodentry.Type == 20483U) ? 8 : 16);
			}
			for (int i = 0; i < mlodentry.VertexCount; i++)
			{
				Package.Geometry.Vector4 position = vbuf.GetPosition(vrtf, i, mlodentry.VBUFOffset, 0);
				left.X = Math.Min(left.X, position.X);
				left.Y = Math.Min(left.Y, position.Y);
				left.Z = Math.Min(left.Z, position.Z);
				right.X = Math.Max(right.X, position.X);
				right.Y = Math.Max(right.Y, position.Y);
				right.Z = Math.Max(right.Z, position.Z);
			}
			float num = float.MaxValue;
			float num2 = float.MaxValue;
			float num3 = float.MaxValue;
			for (int j = 0; j < mlodentry.VertexCount; j++)
			{
				Package.Geometry.Vector4 position2 = vbuf.GetPosition(vrtf, j, mlodentry.VBUFOffset, 0);
				SlimDX.Vector4 vector = SlimDX.Vector3.Transform(new SlimDX.Vector3(position2.X, position2.Y, position2.Z), Matrix.Scaling(2f, 2f, 2f));
				position2.X = vector.X;
				position2.Y = vector.Y;
				position2.Z = vector.Z;
				vbuf.SetPosition(vrtf, j, mlodentry.VBUFOffset, position2);
				num = Math.Min(vector.X, num);
				num2 = Math.Min(vector.Y, num2);
				num3 = Math.Min(vector.Z, num3);
			}
			float x = -1f - num;
			float y = -1f - num2;
			float z = -1f - num3;
			float num4 = float.MinValue;
			float num5 = float.MinValue;
			float num6 = float.MinValue;
			for (int k = 0; k < mlodentry.VertexCount; k++)
			{
				Package.Geometry.Vector4 position3 = vbuf.GetPosition(vrtf, k, mlodentry.VBUFOffset, 0);
				SlimDX.Vector4 vector2 = SlimDX.Vector3.Transform(new SlimDX.Vector3(position3.X, position3.Y, position3.Z), Matrix.Translation(x, y, z));
				position3.X = vector2.X;
				position3.Y = vector2.Y;
				position3.Z = vector2.Z;
				vbuf.SetPosition(vrtf, k, mlodentry.VBUFOffset, position3);
				num4 = Math.Max(vector2.X, num4);
				num5 = Math.Max(vector2.Y, num5);
				num6 = Math.Max(vector2.Z, num6);
			}
			float num7 = (num4 > 1f) ? (2f / (num4 + 1f)) : 1f;
			float num8 = (num5 > 1f) ? (2f / (num5 + 1f)) : 1f;
			float num9 = (num6 > 1f) ? (2f / (num6 + 1f)) : 1f;
			num = float.MaxValue;
			num2 = float.MaxValue;
			num3 = float.MaxValue;
			for (int l = 0; l < mlodentry.VertexCount; l++)
			{
				Package.Geometry.Vector4 position4 = vbuf.GetPosition(vrtf, l, mlodentry.VBUFOffset, 0);
				SlimDX.Vector4 vector3 = SlimDX.Vector3.Transform(new SlimDX.Vector3(position4.X, position4.Y, position4.Z), Matrix.Scaling(num7, num8, num9));
				position4.X = vector3.X;
				position4.Y = vector3.Y;
				position4.Z = vector3.Z;
				vbuf.SetPosition(vrtf, l, mlodentry.VBUFOffset, position4);
				num = Math.Min(vector3.X, num);
				num2 = Math.Min(vector3.Y, num2);
				num3 = Math.Min(vector3.Z, num3);
			}
			x = -1f - num;
			y = -1f - num2;
			z = -1f - num3;
			for (int m = 0; m < mlodentry.VertexCount; m++)
			{
				Package.Geometry.Vector4 position5 = vbuf.GetPosition(vrtf, m, mlodentry.VBUFOffset, 0);
				SlimDX.Vector4 vector4 = SlimDX.Vector3.Transform(new SlimDX.Vector3(position5.X, position5.Y, position5.Z), Matrix.Translation(x, y, z));
				position5.X = vector4.X;
				position5.Y = vector4.Y;
				position5.Z = vector4.Z;
				vbuf.SetPosition(vrtf, m, mlodentry.VBUFOffset, position5);
			}
			num4 = float.MinValue;
			num5 = float.MinValue;
			num6 = float.MinValue;
			num = float.MaxValue;
			num2 = float.MaxValue;
			num3 = float.MaxValue;
			for (int n = 0; n < mlodentry.VertexCount; n++)
			{
				Package.Geometry.Vector4 position6 = vbuf.GetPosition(vrtf, n, mlodentry.VBUFOffset, 0);
				num4 = Math.Max(position6.X, num4);
				num5 = Math.Max(position6.Y, num5);
				num6 = Math.Max(position6.Z, num6);
				num = Math.Min(position6.X, num);
				num2 = Math.Min(position6.Y, num2);
				num3 = Math.Min(position6.Z, num3);
			}
			SlimDX.Vector3 vector5 = (new SlimDX.Vector3(num, num2, num3) + new SlimDX.Vector3(num4, num5, num6)) / 2f;
			SlimDX.Vector3 vector6 = (left + right) / 2f;
			float num10 = 0f - vector5.X + vector6.X * 2f;
			float num11 = 0f - vector5.Y + vector6.Y * 2f;
			float num12 = 0f - vector5.Z + vector6.Z * 2f;
			float num13 = 0.5f;
			SlimDX.Vector4 vector7 = new SlimDX.Vector4(num10 * num13, num11 * num13, num12 * num13, num13);
			int geostateIndex = mlodentry.GEOStateIndex;
			RCOLItem rcolitem = mlodmodel_0.Entries[geostateIndex + ((mlodmodel_0.dataType == 2) ? 1 : 0)];
			if (rcolitem is MATD)
			{
				foreach (MATD.MATDEntry matdentry in (rcolitem as MATD).Entries)
				{
					if (matdentry.Type == MATD.MATDEntryType.PosOffset)
					{
						matdentry.Values = new object[]
						{
							vector7.X,
							vector7.Y,
							vector7.Z,
							vector7.W
						};
					}
					if (matdentry.Type == MATD.MATDEntryType.PosScale)
					{
						matdentry.Values = new object[]
						{
							1f / num7 * 1.5259255E-05f,
							1f / num8 * 1.5259255E-05f,
							1f / num9 * 1.5259255E-05f,
							1.525972E-05f
						};
					}
				}
			}
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0006CEF4 File Offset: 0x0006B0F4
		private void method_23()
		{
			OBJK objk_ = this.method_27();
			VisualProxy visualProxy = this.method_26(objk_);
			SlimDX.Vector3[] array = new SlimDX.Vector3[2];
			SlimDX.Vector3[] array2 = array;
			int num = 0;
			SlimDX.Vector3[] array3 = array;
			int num2 = 0;
			SlimDX.Vector3[] array4 = array;
			int num3 = 0;
			float maxValue = float.MaxValue;
			float maxValue2 = float.MaxValue;
			array4[num3].Z = maxValue;
			float y = maxValue2;
			float maxValue3 = float.MaxValue;
			array3[num2].Y = y;
			array2[num].X = maxValue3;
			SlimDX.Vector3[] array5 = array;
			int num4 = 1;
			SlimDX.Vector3[] array6 = array;
			int num5 = 1;
			SlimDX.Vector3[] array7 = array;
			int num6 = 1;
			float minValue = float.MinValue;
			float minValue2 = float.MinValue;
			array7[num6].Z = minValue;
			float y2 = minValue2;
			float minValue3 = float.MinValue;
			array6[num5].Y = y2;
			array5[num4].X = minValue3;
			SlimDX.Vector3[] array8 = new SlimDX.Vector3[2];
			SlimDX.Vector3[] array9 = array8;
			int num7 = 0;
			SlimDX.Vector3[] array10 = array8;
			int num8 = 0;
			SlimDX.Vector3[] array11 = array8;
			int num9 = 0;
			float maxValue4 = float.MaxValue;
			float maxValue5 = float.MaxValue;
			array11[num9].Z = maxValue4;
			float y3 = maxValue5;
			float maxValue6 = float.MaxValue;
			array10[num8].Y = y3;
			array9[num7].X = maxValue6;
			SlimDX.Vector3[] array12 = array8;
			int num10 = 1;
			SlimDX.Vector3[] array13 = array8;
			int num11 = 1;
			SlimDX.Vector3[] array14 = array8;
			int num12 = 1;
			float minValue4 = float.MinValue;
			float minValue5 = float.MinValue;
			array14[num12].Z = minValue4;
			float y4 = minValue5;
			float minValue6 = float.MinValue;
			array13[num11].Y = y4;
			array12[num10].X = minValue6;
			List<MODLModel> list = this.method_25();
			foreach (RCOL rcol in list)
			{
				foreach (RCOLItem rcolitem in rcol.Entries)
				{
					if (rcolitem.GetType().Equals(typeof(MODL)))
					{
						MODL modl = rcolitem as MODL;
						foreach (MODL.MODLEntry modlentry in modl.Entries)
						{
							if (modlentry.LOD != 65536U && modlentry.LOD != 65538U && modlentry.LOD != 65537U)
							{
								if (modlentry.IndexType == 12288)
								{
									RCOLFileEntry rcolfileEntry = rcol.ExternalResources[modlentry.Index - 1];
									RCOL rcol2 = Class132.mainForm.CurrentProject.Package.GetEntry(rcolfileEntry.ResKey) as RCOL;
									MLOD mlod = rcol2.Entries[0] as MLOD;
									using (List<MLOD.MLODEntry>.Enumerator enumerator4 = mlod.Entries.GetEnumerator())
									{
										while (enumerator4.MoveNext())
										{
											MLOD.MLODEntry mlodentry = enumerator4.Current;
											array8[0].X = Math.Min(array8[0].X, mlodentry.BoundingBox[0]);
											array8[0].Y = Math.Min(array8[0].Y, mlodentry.BoundingBox[1]);
											array8[0].Z = Math.Min(array8[0].Z, mlodentry.BoundingBox[2]);
											array8[1].X = Math.Max(array8[1].X, mlodentry.BoundingBox[3]);
											array8[1].Y = Math.Max(array8[1].Y, mlodentry.BoundingBox[4]);
											array8[1].Z = Math.Max(array8[1].Z, mlodentry.BoundingBox[5]);
											if (mlodentry.Type != 18435U)
											{
												array[0].X = Math.Min(array[0].X, mlodentry.BoundingBox[0]);
												array[0].Y = Math.Min(array[0].Y, mlodentry.BoundingBox[1]);
												array[0].Z = Math.Min(array[0].Z, mlodentry.BoundingBox[2]);
												array[1].X = Math.Max(array[1].X, mlodentry.BoundingBox[3]);
												array[1].Y = Math.Max(array[1].Y, mlodentry.BoundingBox[4]);
												array[1].Z = Math.Max(array[1].Z, mlodentry.BoundingBox[5]);
											}
										}
										continue;
									}
								}
								MLOD mlod2 = rcol.Entries[modlentry.Index - 1] as MLOD;
								foreach (MLOD.MLODEntry mlodentry2 in mlod2.Entries)
								{
									array8[0].X = Math.Min(array8[0].X, mlodentry2.BoundingBox[0]);
									array8[0].Y = Math.Min(array8[0].Y, mlodentry2.BoundingBox[1]);
									array8[0].Z = Math.Min(array8[0].Z, mlodentry2.BoundingBox[2]);
									array8[1].X = Math.Max(array8[1].X, mlodentry2.BoundingBox[3]);
									array8[1].Y = Math.Max(array8[1].Y, mlodentry2.BoundingBox[4]);
									array8[1].Z = Math.Max(array8[1].Z, mlodentry2.BoundingBox[5]);
									if (mlodentry2.Type != 18435U)
									{
										array[0].X = Math.Min(array[0].X, mlodentry2.BoundingBox[0]);
										array[0].Y = Math.Min(array[0].Y, mlodentry2.BoundingBox[1]);
										array[0].Z = Math.Min(array[0].Z, mlodentry2.BoundingBox[2]);
										array[1].X = Math.Max(array[1].X, mlodentry2.BoundingBox[3]);
										array[1].Y = Math.Max(array[1].Y, mlodentry2.BoundingBox[4]);
										array[1].Z = Math.Max(array[1].Z, mlodentry2.BoundingBox[5]);
									}
								}
							}
						}
					}
				}
			}
			if ((array[0].Y >= 3f || array[1].Y >= 3f || array8[1].Y >= 3f || array8[1].Y >= 3f) && MessageBox.Show(null, "Your object is taller than the standard wall height.\nIf this object is placed on a wall, it could cause game errors.\n\nWould you like Workshop to correct the bounding box for you to prevent this?  (your mesh height will not be changed)", "Update bounds", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				array[0].Y = Math.Max(0f, Math.Min(array[0].Y, 2.95f));
				array[1].Y = Math.Max(0f, Math.Min(array[1].Y, 2.95f));
				array8[0].Y = Math.Max(0f, Math.Min(array8[0].Y, 2.95f));
				array8[1].Y = Math.Max(0f, Math.Min(array8[1].Y, 2.95f));
			}
			bool flag = false;
			foreach (RCOLItem rcolitem2 in visualProxy.Entries)
			{
				VPXY vpxy = (VPXY)rcolitem2;
				vpxy.BoundingBox = new float[]
				{
					array[0].X,
					array[0].Y,
					array[0].Z,
					array[1].X,
					array[1].Y,
					array[1].Z
				};
				foreach (TGIIndex tgiindex in vpxy.TGIIndex)
				{
					if (tgiindex.Type == (DBPFType)3540272417U)
					{
						RCOL rcol3 = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.AsString())) as RCOL;
						if (rcol3 != null)
						{
							foreach (RCOLItem rcolitem3 in rcol3.Entries)
							{
								if (rcolitem3 is RSLT)
								{
									RSLT rslt = rcolitem3 as RSLT;
								}
							}
						}
					}
					if (tgiindex.Type == (DBPFType)3548561239U)
					{
						RCOL rcol4 = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.AsString())) as RCOL;
						if (rcol4 != null)
						{
							foreach (RCOLItem rcolitem4 in rcol4.Entries)
							{
								if (rcolitem4 is FTPT && flag)
								{
									FTPT ftpt = rcolitem4 as FTPT;
									if (ftpt != null)
									{
										foreach (FTPT.FootprintEntry footprintEntry in ftpt.FootprintEntries)
										{
											footprintEntry.BoundingBox[0] = array[0].X;
											footprintEntry.BoundingBox[1] = array[0].Z;
											footprintEntry.BoundingBox[2] = array[1].X;
											footprintEntry.BoundingBox[3] = array[1].Z;
											if (footprintEntry.Entries.Count == 4)
											{
												footprintEntry.Entries[0][0] = array[0].X;
												footprintEntry.Entries[0][1] = array[0].Z;
												footprintEntry.Entries[1][0] = array[0].X;
												footprintEntry.Entries[1][1] = array[1].Z;
												footprintEntry.Entries[2][0] = array[1].X;
												footprintEntry.Entries[2][1] = array[1].Z;
												footprintEntry.Entries[3][0] = array[1].X;
												footprintEntry.Entries[3][1] = array[0].Z;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			foreach (RCOL rcol5 in list)
			{
				foreach (RCOLItem rcolitem5 in rcol5.Entries)
				{
					if (rcolitem5.GetType().Equals(typeof(MODL)))
					{
						MODL modl2 = rcolitem5 as MODL;
						modl2.BoundingBox[0] = array8[0].X;
						modl2.BoundingBox[1] = 0f;
						modl2.BoundingBox[2] = array8[0].Z;
						modl2.BoundingBox[3] = array8[1].X;
						modl2.BoundingBox[4] = array8[1].Y;
						modl2.BoundingBox[5] = array8[1].Z;
					}
				}
			}
			foreach (RCOL rcol6 in list)
			{
				foreach (RCOLItem rcolitem6 in rcol6.Entries)
				{
					if (rcolitem6.GetType().Equals(typeof(MODL)))
					{
						MODL modl3 = rcolitem6 as MODL;
						foreach (MODL.MODLEntry modlentry2 in modl3.Entries)
						{
							if (modlentry2.LOD == 65536U || modlentry2.LOD == 65538U || modlentry2.LOD == 65537U)
							{
								if (modlentry2.IndexType == 12288)
								{
									RCOLFileEntry rcolfileEntry2 = rcol6.ExternalResources[modlentry2.Index - 1];
									RCOL rcol7 = Class132.mainForm.CurrentProject.Package.GetEntry(rcolfileEntry2.ResKey) as RCOL;
									MLOD mlod3 = rcol7.Entries[0] as MLOD;
									using (List<MLOD.MLODEntry>.Enumerator enumerator4 = mlod3.Entries.GetEnumerator())
									{
										while (enumerator4.MoveNext())
										{
											MLOD.MLODEntry mlodentry3 = enumerator4.Current;
											if (mlodentry3.Type != 18435U)
											{
												mlodentry3.BoundingBox[0] = array[0].X;
												mlodentry3.BoundingBox[1] = array[0].Y;
												mlodentry3.BoundingBox[2] = array[0].Z;
												mlodentry3.BoundingBox[3] = array[1].X;
												mlodentry3.BoundingBox[4] = array[1].Y;
												mlodentry3.BoundingBox[5] = array[1].Z;
											}
										}
										continue;
									}
								}
								MLOD mlod4 = rcol6.Entries[modlentry2.Index - 1] as MLOD;
								foreach (MLOD.MLODEntry mlodentry4 in mlod4.Entries)
								{
									if (mlodentry4.Type != 18435U)
									{
										mlodentry4.BoundingBox[0] = array[0].X;
										mlodentry4.BoundingBox[1] = array[0].Y;
										mlodentry4.BoundingBox[2] = array[0].Z;
										mlodentry4.BoundingBox[3] = array[1].X;
										mlodentry4.BoundingBox[4] = array[1].Y;
										mlodentry4.BoundingBox[5] = array[1].Z;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0006DFE8 File Offset: 0x0006C1E8
		private void method_24()
		{
			this.objdModelControl_0.method_7();
			OBJK objk = this.method_27();
			if (objk == null)
			{
				throw new Exception("Could not locate objk, bailing out.");
			}
			OBJK.KeyEntry keyEntry = objk.GetKeyEntry("modelKey");
			TGIIndex tgiindex = objk.TGIIndex[keyEntry.TgiIndex];
			if (tgiindex.Type == DBPFType.SPTR)
			{
				SpeedTree tree = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.AsString())) as SpeedTree;
				Class3.Class23 class22_ = new Class3.Class23(tree);
				this.objdModelControl_0.method_6(class22_);
			}
			else if (tgiindex.Type == DBPFType.VPXY)
			{
				VisualProxy visualProxy = this.method_26(objk);
				if (visualProxy != null)
				{
					foreach (RCOLItem rcolitem in visualProxy.Entries)
					{
						VPXY vpxy = (VPXY)rcolitem;
						foreach (VPXY.VPXEntryEntry vpxentryEntry in vpxy.entries)
						{
							if (vpxentryEntry.type == 1)
							{
								foreach (int index in vpxentryEntry.index)
								{
									TGIIndex tgiindex2 = vpxy.TGIIndex[index];
									if (tgiindex2.Type == DBPFType.MODL)
									{
										ResKey key = new ResKey(tgiindex2.Reskey);
										MODLModel modlmodel = Class132.mainForm.CurrentProject.Package.GetEntry(key) as MODLModel;
										foreach (RCOLItem rcolitem2 in modlmodel.Entries)
										{
											if (rcolitem2.GetType().Equals(typeof(MODL)))
											{
												MODL modl = rcolitem2 as MODL;
												foreach (MODL.MODLEntry modlentry in modl.Entries)
												{
													Class3.Class24 class22_2 = new Class3.Class24(modl, modlmodel, modlentry, vpxy);
													this.objdModelControl_0.method_6(class22_2);
													if (!this.list_0.Contains((Lod)modlentry.LOD))
													{
														this.list_0.Add((Lod)modlentry.LOD);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0006E2F8 File Offset: 0x0006C4F8
		private List<MODLModel> method_25()
		{
			List<MODLModel> list = new List<MODLModel>();
			OBJK objk_ = this.method_27();
			VisualProxy visualProxy = this.method_26(objk_);
			if (visualProxy != null)
			{
				foreach (RCOLItem rcolitem in visualProxy.Entries)
				{
					VPXY vpxy = (VPXY)rcolitem;
					foreach (VPXY.VPXEntryEntry vpxentryEntry in vpxy.entries)
					{
						if (vpxentryEntry.type == 1)
						{
							foreach (int index in vpxentryEntry.index)
							{
								TGIIndex tgiindex = vpxy.TGIIndex[index];
								if (tgiindex.Type == DBPFType.MODL)
								{
									ResKey key = new ResKey(tgiindex.Reskey);
									MODLModel item = Class132.mainForm.CurrentProject.Package.GetEntry(key) as MODLModel;
									list.Add(item);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00024A98 File Offset: 0x00022C98
		private VisualProxy method_26(OBJK objk_0)
		{
			OBJK.KeyEntry keyEntry = objk_0.GetKeyEntry("modelKey");
			TGIIndex tgiindex = objk_0.TGIIndex[keyEntry.TgiIndex];
			return Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.Reskey)) as VisualProxy;
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x0006E454 File Offset: 0x0006C654
		private OBJK method_27()
		{
			return Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(this.objd_0.OBJK.Reskey)) as OBJK;
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0006E494 File Offset: 0x0006C694
		private void method_28()
		{
			this.objdModelControl_0.method_4();
			this.method_29();
			if (!this.bool_2)
			{
				this.objdModelControl_0.exportToolStripMenuItem.Click += this.method_30;
				this.objdModelControl_0.VariationCombo.SelectedIndexChanged += this.method_36;
				this.objdModelControl_0.PresetPropertyGrid.PropertyChanged += this.method_35;
			}
			this.bool_2 = true;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0006E518 File Offset: 0x0006C718
		private void method_29()
		{
			this.objdModelControl_0.method_4();
			foreach (OBJD.Material material in this.objd_0.Materials)
			{
				TGIIndex tgiindex = material.TGIIndex[0];
				foreach (OBJD.Material.MaterialBlock materialBlock in material.Blocks)
				{
					string text = string.Concat(new string[]
					{
						"<preset><complate name=\"",
						materialBlock.Ref1Name,
						"\" reskey=\"",
						tgiindex.Reskey,
						"\">"
					});
					foreach (OBJD.Material.ComplateVariable complateVariable in materialBlock.Variables)
					{
						string text2 = complateVariable.GetValue();
						if (complateVariable.ValueTypeCode == 3)
						{
							text2 = material.TGIIndex[Convert.ToInt32(text2)].Reskey;
						}
						object obj = text;
						text = string.Concat(new object[]
						{
							obj,
							"<value key=\"",
							complateVariable.VariableName,
							"\" value=\"",
							text2,
							"\" type=\"",
							complateVariable.ValueTypeCode,
							"\" />"
						});
					}
					int num = 0;
					foreach (OBJD.Material.MaterialBlock materialBlock2 in materialBlock.Patterns)
					{
						string text3 = text;
						text = string.Concat(new string[]
						{
							text3,
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
							string text4 = complateVariable2.GetValue();
							if (complateVariable2.ValueTypeCode == 3)
							{
								text4 = material.TGIIndex[Convert.ToInt32(text4)].Reskey;
							}
							object obj2 = text;
							text = string.Concat(new object[]
							{
								obj2,
								"<value key=\"",
								complateVariable2.VariableName,
								"\" value=\"",
								text4,
								"\" type=\"",
								complateVariable2.ValueTypeCode,
								"\" />"
							});
						}
						text += "</pattern>";
						num++;
					}
					text += "</complate></preset>";
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(text);
					this.objdModelControl_0.method_5(new Class81(xmlDocument, false));
				}
			}
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0006E8DC File Offset: 0x0006CADC
		private void method_30(object sender, EventArgs e)
		{
			if (this.objdModelControl_0.VariationCombo.SelectedItem != null)
			{
				XmlDocument xmlDocument = (this.objdModelControl_0.VariationCombo.SelectedItem as Class81).Data as XmlDocument;
				if (xmlDocument != null)
				{
					Size size = this.Renderable.vmethod_1();
					ComplateToImageForm complateToImageForm = new ComplateToImageForm(xmlDocument, size);
					if (!complateToImageForm.Completed)
					{
						complateToImageForm.ShowDialog(Class132.mainForm);
					}
				}
			}
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0006E94C File Offset: 0x0006CB4C
		public void method_31()
		{
			bool value = Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges;
			Dictionary<ulong, string> entries = new Dictionary<ulong, string>
			{
				{
					(ulong)this.objd_0.NameGuid,
					this.Title
				},
				{
					(ulong)this.objd_0.DescGuid,
					this.Description
				}
			};
			STBL.SaveStrings(Class132.mainForm.CurrentProject.Package, entries, new ResKey(this.objd_0.GenerateResKey()));
			List<ResKey> list = this.project.Package.SearchEntries(new ResKey(DBPFType.OBJD));
			if (list.Count > 1)
			{
				foreach (ResKey key in list)
				{
					OBJD objd = (OBJD)this.project.Package.GetEntry(key);
					objd.NameGuid = this.objd_0.NameGuid;
					objd.DescGuid = this.objd_0.DescGuid;
					objd.CatalogNameEntry = this.objd_0.CatalogNameEntry;
					objd.CatalogDescEntry = this.objd_0.CatalogDescEntry;
				}
			}
			list = this.project.Package.SearchEntries(new ResKey(DBPFType.FIREPLACE));
			if (list.Count > 0)
			{
				foreach (ResKey key2 in list)
				{
					FirePlace firePlace = (FirePlace)this.project.Package.GetEntry(key2);
					firePlace.NameGuid = this.objd_0.NameGuid;
					firePlace.DescGuid = this.objd_0.DescGuid;
					firePlace.CatalogNameEntry = this.objd_0.CatalogNameEntry;
					firePlace.CatalogDescEntry = this.objd_0.CatalogDescEntry;
				}
			}
			this.method_32();
			Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = value;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0006EB64 File Offset: 0x0006CD64
		private void method_32()
		{
			uint[] array = new uint[this.objd_0.Materials.Count];
			int num = 0;
			uint num2 = 1U;
			foreach (OBJD.Material material in this.objd_0.Materials)
			{
				array[num++] = num2++;
			}
			this.objd_0.Materials.Clear();
			num = 0;
			foreach (object obj in this.objdModelControl_0.VariationCombo.Items)
			{
				Class81 @class = (Class81)obj;
				if (!@class.IsProp)
				{
					OBJD.Material material2 = new OBJD.Material(array[num++]);
					OBJD.Material.MaterialBlock materialBlock = material2.AddBlock();
					XmlDocument xmlDocument = @class.Data as XmlDocument;
					if (xmlDocument != null)
					{
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
											XmlElement xmlElement = (XmlElement)obj3;
											XmlAttribute xmlAttribute5 = xmlElement.Attributes["key"];
											if (xmlAttribute5 != null)
											{
												XmlAttribute xmlAttribute6 = xmlElement.Attributes["value"];
												if (xmlAttribute6 != null)
												{
													XmlAttribute xmlAttribute7 = xmlElement.Attributes["type"];
													if (xmlAttribute7 != null)
													{
														XmlAttribute xmlAttribute8 = xmlElement.Attributes["cloneDefault"];
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
								this.objd_0.Materials.Add(material2);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0006F018 File Offset: 0x0006D218
		private void method_33()
		{
			if (this.objdModelControl_0.VariationCombo.SelectedIndex != -1)
			{
				XmlDocument xmlDocument_ = (this.objdModelControl_0.VariationCombo.SelectedItem as Class81).Data as XmlDocument;
				this.Renderable.vmethod_3(xmlDocument_);
				Class132.mainForm.Render();
			}
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x000056FD File Offset: 0x000038FD
		private void method_34(object object_0, Class48 class48_0)
		{
			this.method_33();
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0006F070 File Offset: 0x0006D270
		private void method_35(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			Property property = e.PropertyEnum.Property;
			object previousValue = e.PropertyEnum.Property.Value.PreviousValue;
			object value = e.PropertyEnum.Property.Value.GetValue();
			if (value == null || value.GetType() != typeof(PatternResKey))
			{
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
					foreach (DBPFEntry dbpfentry in this.project.Package.Entries.Values)
					{
						dbpfentry.ReplaceReferences(textureResKey2, textureResKey);
					}
					foreach (TGIIndex tgiindex in this.objd_0.TgiIndex)
					{
						if (tgiindex.Equals(textureResKey2))
						{
							tgiindex.SetFromResKey(textureResKey, true);
						}
					}
					List<ResKey> list3 = Class132.mainForm.CurrentProject.Package.SearchEntries(new ResKey(DBPFType.ALL));
					foreach (ResKey key in list3)
					{
						DBPFEntry entry = Class132.mainForm.CurrentProject.Package.GetEntry(key);
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
			}
			this.method_33();
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0006F6F8 File Offset: 0x0006D8F8
		private void method_36(object sender, EventArgs e)
		{
			if (this.objdModelControl_0.VariationCombo.SelectedIndex != -1)
			{
				XmlDocument xmlDocument = (this.objdModelControl_0.VariationCombo.SelectedItem as Class81).Data as XmlDocument;
				try
				{
					this.Renderable.vmethod_3(xmlDocument);
				}
				catch (Exception)
				{
				}
				this.objdModelControl_0.PresetPropertyGrid.Preset = xmlDocument;
			}
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x0006F76C File Offset: 0x0006D96C
		public void ImportPackage(object object_0)
		{
			DBPF dbpf = object_0 as DBPF;
			this.method_31();
			if (dbpf == null)
			{
				MessageBox.Show("Package was null, aborting.");
			}
			else
			{
				ArrayList resKeys = dbpf.GetResKeys();
				int num = 0;
				int num2 = 0;
				foreach (object obj in resKeys)
				{
					ResKey key = (ResKey)obj;
					if (Class132.mainForm.CurrentProject.Package.HasEntry(key))
					{
						num++;
					}
					else
					{
						num2++;
					}
					Class132.mainForm.CurrentProject.Package.AddEntry(dbpf.GetEntry(key));
				}
				MessageBox.Show(string.Concat(new object[]
				{
					"Import done, added ",
					num2,
					" and replaced ",
					num,
					" entries in the project package"
				}));
				this.method_17();
			}
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0006F878 File Offset: 0x0006DA78
		public object ExportPackage()
		{
			if (string.IsNullOrEmpty(this.Title))
			{
				throw new Exception("Title can not be empty.");
			}
			if (string.IsNullOrEmpty(this.Description))
			{
				throw new Exception("Description can not be empty.");
			}
			this.method_31();
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
			string text2 = "0x" + Class132.mainForm.CreateGuid(this.Title + "_" + text).Replace("-", "").ToLower();
			text = text2;
			this.packageDescriptor_0.Title = this.string_0;
			this.packageDescriptor_0.Description = this.string_1;
			this.packageDescriptor_0.Thumbnail = png.GenerateResKey().Replace("key:", "");
			this.packageDescriptor_0.Id = text;
			this.packageDescriptor_0.Manifest.Remove("packagesubtype");
			this.packageDescriptor_0.Manifest.Add("packagesubtype", "0x" + this.objd_0.CategoryFlags.ToString("X8"));
			this.packageDescriptor_0.KeyyList.Clear();
			this.packageDescriptor_0.DependencyList.Clear();
			this.packageDescriptor_0.DependencyList.Add("0x050cffe800000000050cffe800000000");
			this.packageDescriptor_0.DependencyList.Add(text);
			foreach (object obj2 in dbpf.GetResKeys())
			{
				ResKey resKey2 = (ResKey)obj2;
				this.packageDescriptor_0.KeyyList.Add(resKey2.AsString().Replace("key", "1"));
			}
			this.packageDescriptor_0.MetaTags.Clear();
			this.packageDescriptor_0.MetaTags.Add("numofthumbs", 1);
			dbpf.AddEntry(this.packageDescriptor_0);
			dbpf.Guid = text2.Replace("-", "").ToLower();
			dbpf.Name = dbpf.Guid + ".package";
			dbpf.ContentType = "Object";
			return dbpf;
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0006FC5C File Offset: 0x0006DE5C
		public object ExportSims3Pack()
		{
			DBPF dbpf = this.Sims3WorkshopSDK.Interfaces.IProjectModel.ExportPackage() as DBPF;
			Sims3Package sims3Package = new Sims3Package();
			sims3Package.DisplayName = this.Title;
			sims3Package.Description = this.Description;
			sims3Package.Type = "object";
			sims3Package.PackageId = dbpf.Guid.Replace("-", "").ToLower();
			sims3Package.SubType = "0x" + this.objd_0.CategoryFlags.ToString("X8");
			string[] array = new string[23];
			STBL.Locales.Keys.CopyTo(array, 0);
			string[] localizedStrings = STBL.GetLocalizedStrings(dbpf, (ulong)this.objd_0.NameGuid, this.objd_0.SecondInstanceID);
			this.packageDescriptor_0.StringTables.Clear();
			for (int i = 0; i < localizedStrings.Length; i++)
			{
				if (localizedStrings[i] != null)
				{
					this.packageDescriptor_0.StringTables.Add(new ResKey(DBPFType.STBL, 0, i << 24, this.objd_0.SecondInstanceID));
				}
			}
			for (int j = 0; j < localizedStrings.Length; j++)
			{
				if (localizedStrings[j] != null)
				{
					sims3Package.LocalizedNames.Add(new LocalizedString(localizedStrings[j], array[j]));
					if (j > 0)
					{
						this.packageDescriptor_0.LocalizedNames.Add(new LocalizedString(localizedStrings[j], array[j]));
					}
				}
			}
			localizedStrings = STBL.GetLocalizedStrings(dbpf, (ulong)this.objd_0.DescGuid, this.objd_0.SecondInstanceID);
			for (int k = 0; k < localizedStrings.Length; k++)
			{
				if (localizedStrings[k] != null)
				{
					sims3Package.LocalizedDescriptions.Add(new LocalizedString(localizedStrings[k], array[k]));
					if (k > 0)
					{
						this.packageDescriptor_0.LocalizedDescriptions.Add(new LocalizedString(localizedStrings[k], array[k]));
					}
				}
			}
			sims3Package.Dependencies.Add("0x050cffe800000000050cffe800000000");
			sims3Package.AddFile(dbpf);
			return sims3Package;
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0006FE50 File Offset: 0x0006E050
		public object GetThumbnail()
		{
			return this.method_37(this.Renderable.CurrentPreset);
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0006FE74 File Offset: 0x0006E074
		public object method_37(XmlDocument xmlDocument_0)
		{
			Bitmap bitmap = Class132.smethod_0().method_19(this.Renderable, xmlDocument_0, new Size(256, 256)) as Bitmap;
			Bitmap bitmap2 = new Bitmap(256, 256);
			Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.DrawImage(bitmap, new Rectangle(18, 18, 222, 222), 0, 0, 256, 256, GraphicsUnit.Pixel);
			bitmap.Dispose();
			return bitmap2;
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0006FEF0 File Offset: 0x0006E0F0
		public string GetTitle()
		{
			return this.Title;
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0006FF08 File Offset: 0x0006E108
		public string GetDescription()
		{
			return this.Description;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0006FF20 File Offset: 0x0006E120
		public void LodChanged(Lod lod_1)
		{
			Class105 renderable = this.Renderable;
			this.lod_0 = lod_1;
			renderable.LODLevel = lod_1;
			Class132.smethod_0().ShadowMapDirty = true;
			foreach (object obj in this.objdModelControl_0.meshgroupCombo.Items)
			{
				Class3.Class24 @class = (Class3.Class24)obj;
				if (@class.MODLEntry.LOD == (uint)this.lod_0)
				{
					this.objdModelControl_0.meshgroupCombo.SelectedItem = @class;
				}
				else if (@class.MODLEntry.LOD == (uint)this.lod_0)
				{
					this.objdModelControl_0.meshgroupCombo.SelectedItem = @class;
				}
				else if (@class.MODLEntry.LOD == (uint)this.lod_0)
				{
					this.objdModelControl_0.meshgroupCombo.SelectedItem = @class;
				}
				else if (@class.MODLEntry.LOD == (uint)this.lod_0)
				{
					this.objdModelControl_0.meshgroupCombo.SelectedItem = @class;
				}
			}
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0007003C File Offset: 0x0006E23C
		public List<Lod> GetLodLevels()
		{
			return this.list_0;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x00070054 File Offset: 0x0006E254
		public void method_38(int int_1)
		{
			try
			{
				this.method_32();
				this.objd_0.Materials.RemoveAt(int_1);
				this.method_29();
				this.objdModelControl_0.VariationCombo.SelectedIndex = 0;
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			}
			catch (Exception)
			{
				MessageBox.Show("Could not remove at index " + int_1 + " because this is a hack, try removing them in order.");
			}
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x000700D0 File Offset: 0x0006E2D0
		public void method_39(int int_1)
		{
			this.method_32();
			OBJD.Material material = this.objd_0.Materials[int_1];
			OBJD.Material item = material.Clone();
			this.objd_0.Materials.Add(item);
			this.method_29();
			this.objdModelControl_0.VariationCombo.SelectedIndex = this.objdModelControl_0.VariationCombo.Items.Count - 1;
			this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x00070148 File Offset: 0x0006E348
		public static OBJD smethod_1(OBJD objd_1, string string_2, DBPF dbpf_0, bool bool_3, int int_1, Dictionary<string, string> dictionary_0, bool bool_4, object object_0)
		{
			if ((objd_1.GroupID & 1207959552) == 1207959552)
			{
				int_1 = 671088640;
				bool_3 = false;
			}
			if (objd_1.CatalogNameEntry.IndexOf("Name:") == -1)
			{
				string catalogNameEntry = objd_1.CatalogNameEntry;
			}
			else
			{
				objd_1.CatalogNameEntry.Substring(objd_1.CatalogNameEntry.IndexOf("Name:") + 5);
			}
			Random random = new Random((int)DateTime.Now.Ticks);
			OBJD objd = Class80.smethod_2(objd_1, string_2, ref dbpf_0, ref dictionary_0, random, bool_3, int_1);
			if (objd.TgiIndex[objd.DiagonalIndex].TypeId != 0U)
			{
				TGIIndex tgiindex = objd.TgiIndex[objd.DiagonalIndex];
				DBPFEntry dbpfentry = Class76.smethod_26(new ResKey(tgiindex.AsString()));
				if (dbpfentry is OBJD)
				{
					OBJD objd_2 = dbpfentry as OBJD;
					OBJD objd2 = Class80.smethod_2(objd_2, string_2, ref dbpf_0, ref dictionary_0, random, bool_3, int_1);
					tgiindex.SetFromResKey(objd2.ResKey, true);
					if (objd2.TgiIndex[objd2.DiagonalIndex].Equals(new ResKey(objd_1.GenerateResKey())))
					{
						objd2.TgiIndex[objd2.DiagonalIndex].Reskey = objd.GenerateResKey();
					}
					dbpf_0.AddEntry(objd2);
				}
			}
			if (objd.Version >= 25U)
			{
				TGIIndex tgiindex2 = objd.TgiIndex[objd.LevelBelowIndex];
				DBPFEntry dbpfentry2 = Class76.smethod_26(new ResKey(tgiindex2.AsString()));
				if (dbpfentry2 is OBJD)
				{
					OBJD objd_3 = dbpfentry2 as OBJD;
					OBJD objd3 = Class80.smethod_2(objd_3, string_2, ref dbpf_0, ref dictionary_0, random, bool_3, int_1);
					tgiindex2.SetFromResKey(objd3.ResKey, true);
					if (objd3.TgiIndex[objd3.DiagonalIndex].Equals(new ResKey(objd_1.GenerateResKey())))
					{
						objd3.TgiIndex[objd3.DiagonalIndex].Reskey = objd.GenerateResKey();
					}
					dbpf_0.AddEntry(objd3);
				}
			}
			if (objd.Version >= 29U)
			{
				TGIIndex tgiindex3 = objd.TgiIndex[objd.BluePrintIndex];
				DBPFEntry dbpfentry3 = Class76.smethod_26(new ResKey(tgiindex3.AsString()));
				if (dbpfentry3 is XML)
				{
					XML xml = dbpfentry3 as XML;
					XML xml2 = xml.Clone() as XML;
					xml2.InstanceID = random.Next();
					xml2.SecondInstanceID = random.Next();
					tgiindex3.SetFromResKey(xml2.ResKey, true);
					dbpf_0.AddEntry(xml2);
				}
			}
			if (object_0 is MDLR)
			{
				MDLR mdlr = object_0 as MDLR;
				MDLR mdlr2 = mdlr.Clone() as MDLR;
				ulong hash = FNV64.GetHash(StringHelpers.ToCamelCase(string_2));
				ResKey resKey = new ResKey(string.Concat(new string[]
				{
					"{key:",
					3482995406U.ToString("X8"),
					":",
					mdlr2.GroupID.ToString("X8"),
					":",
					hash.ToString("X16"),
					"}"
				}));
				mdlr2.GroupID = resKey.GroupId;
				mdlr2.InstanceID = resKey.InstanceId;
				mdlr2.SecondInstanceID = resKey.SecondInstanceId;
				dbpf_0.AddEntry(mdlr2);
				mdlr2.TGIIndex[0].SetFromResKey(objd.ResKey, true);
				for (int i = 1; i < mdlr2.TGIIndex.Count; i++)
				{
					TGIIndex tgiindex4 = mdlr2.TGIIndex[i];
					DBPFEntry dbpfentry4 = Class76.smethod_26(new ResKey(tgiindex4.AsString()));
					if (dbpfentry4 is OBJD)
					{
						OBJD objd_4 = dbpfentry4 as OBJD;
						OBJD objd4 = Class80.smethod_2(objd_4, string_2, ref dbpf_0, ref dictionary_0, random, bool_3, int_1);
						tgiindex4.SetFromResKey(objd4.ResKey, true);
					}
				}
			}
			for (byte b = 0; b < 23; b += 1)
			{
				int instanceId = (int)b << 24;
				List<ResKey> list = dbpf_0.SearchEntries(new ResKey(DBPFType.STBL, 0, instanceId, objd.SecondInstanceID));
				STBL stbl;
				if (list.Count > 0)
				{
					stbl = (STBL)dbpf_0.GetEntry(list[0]);
				}
				else
				{
					stbl = new STBL
					{
						ResKey = new ResKey(DBPFType.STBL, 0, instanceId, objd.SecondInstanceID)
					};
					dbpf_0.AddEntry(stbl);
				}
				stbl.SetEntry((ulong)objd.NameGuid, string_2);
				stbl.SetEntry((ulong)objd.DescGuid, string_2);
			}
			return objd;
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x000705D0 File Offset: 0x0006E7D0
		private static OBJD smethod_2(OBJD objd_1, string string_2, ref DBPF dbpf_0, ref Dictionary<string, string> dictionary_0, Random random_0, bool bool_3, int int_1)
		{
			string key = objd_1.GenerateResKey();
			OBJD result;
			if (dictionary_0.ContainsKey(key))
			{
				result = (dbpf_0.GetEntry(new ResKey(dictionary_0[key])) as OBJD);
			}
			else
			{
				random_0.Next();
				OBJD objd = objd_1.Clone() as OBJD;
				string key2 = objd.GenerateResKey();
				TGIIndex tgiindex = objd.TgiIndex[objd.FallbackOBJD];
				if (tgiindex.TypeId == 0U)
				{
					objd.FallbackOBJD = objd.AddTgi(objd.TgiIndex, new TGIIndex(key2));
				}
				if (!bool_3)
				{
					objd.GroupID = int_1;
				}
				objd.InstanceID = random_0.Next();
				objd.SecondInstanceID = random_0.Next();
				objd.CatalogNameEntry = ((objd.CatalogNameEntry.IndexOf("Name:") != -1) ? (objd.CatalogNameEntry.Substring(0, objd.CatalogNameEntry.IndexOf("Name:") + 5) + string_2) : string_2);
				objd.NameGuid = (long)StringHelpers.FNV64(objd.InstanceID.ToString("X8") + objd.SecondInstanceID.ToString("X8") + "_titleguid");
				objd.DescGuid = (long)StringHelpers.FNV64(objd.InstanceID.ToString("X8") + objd.SecondInstanceID.ToString("X8") + "_descriptionguid");
				dbpf_0.AddEntry(objd);
				dictionary_0.Add(key2, objd.GenerateResKey());
				TGIIndex tgiindex2 = objd.TgiIndex[objd.ObjkIndex];
				string key3 = tgiindex2.AsString();
				OBJK objk;
				if (dictionary_0.ContainsKey(key3))
				{
					objk = (dbpf_0.GetEntry(new ResKey(dictionary_0[key3])) as OBJK);
				}
				else
				{
					OBJK objk2 = Class76.smethod_26(tgiindex2) as OBJK;
					if (objk2 == null)
					{
						return objd;
					}
					objk = (objk2.Clone() as OBJK);
					objk = (Class76.smethod_26(tgiindex2).Clone() as OBJK);
					string key4 = objk.GenerateResKey();
					objk.GroupID = (tgiindex2.GroupId = objd.GroupID);
					objk.InstanceID = (tgiindex2.InstanceId = objd.InstanceID);
					objk.SecondInstanceID = (tgiindex2.SecondInstanceId = objd.SecondInstanceID);
					dbpf_0.AddEntry(objk);
					dictionary_0.Add(key4, objk.GenerateResKey());
				}
				OBJK.KeyEntry keyEntry = objk.GetKeyEntry("modelKey");
				TGIIndex tgiindex3 = objk.TGIIndex[keyEntry.TgiIndex];
				tgiindex3.SecondInstanceId |= (bool_3 ? objk.ResKey.GroupId : 0);
				tgiindex3.GroupId |= (bool_3 ? objk.ResKey.GroupId : 0);
				string key5 = tgiindex3.AsString();
				if (tgiindex3.Type == DBPFType.SPTR)
				{
					SpeedTree speedTree = Class76.smethod_26(new ResKey(key5)).Clone() as SpeedTree;
					if (speedTree != null)
					{
						DBPFEntry dbpfentry = Class76.smethod_26(tgiindex3.ReplaceType(35487372U));
						dbpfentry.InstanceID = (speedTree.InstanceID = (tgiindex3.InstanceId = random_0.Next()));
						dbpfentry.SecondInstanceID = (speedTree.SecondInstanceID = (tgiindex3.SecondInstanceId = random_0.Next()));
						dbpf_0.AddEntry(speedTree);
						if (dbpfentry != null)
						{
							dbpfentry.InstanceID = speedTree.InstanceID;
							dbpfentry.SecondInstanceID = speedTree.SecondInstanceID;
							dbpf_0.AddEntry(dbpfentry);
						}
					}
					OBJK.KeyEntry keyEntry2 = objk.GetKeyEntry("footprintKey");
					TGIIndex tgiindex4 = objk.TGIIndex[keyEntry2.TgiIndex];
					RCOL rcol = Class76.smethod_26(new ResKey(tgiindex4.AsString())).Clone() as RCOL;
					if (rcol != null)
					{
						rcol.InstanceID = (tgiindex4.InstanceId = speedTree.InstanceID);
						rcol.SecondInstanceID = (tgiindex4.SecondInstanceId = speedTree.SecondInstanceID);
						dbpf_0.AddEntry(rcol);
					}
				}
				else if (tgiindex3.Type == DBPFType.VPXY)
				{
					VisualProxy visualProxy = null;
					ResKey resKey = new ResKey(key5);
					if (dictionary_0.ContainsKey(key5))
					{
						visualProxy = (dbpf_0.GetEntry(new ResKey(key5)) as VisualProxy);
					}
					else
					{
						visualProxy = (Class76.smethod_26(new ResKey(tgiindex3.AsString())).Clone() as VisualProxy);
						resKey = new ResKey(visualProxy.GenerateResKey());
						visualProxy.InstanceID = (tgiindex3.InstanceId = objd.InstanceID);
						visualProxy.SecondInstanceID = (tgiindex3.SecondInstanceId = objd.SecondInstanceID);
						if (!bool_3)
						{
							visualProxy.GroupID = (tgiindex3.GroupId = (objd.GroupID | 1));
						}
						dbpf_0.AddEntry(visualProxy);
						dictionary_0.Add(resKey.AsString(), visualProxy.GenerateResKey());
					}
					ResKey resKey_ = new ResKey(DBPFType.PRESET, resKey.GroupId, resKey.InstanceId, resKey.SecondInstanceId);
					List<DBPFEntry> list = Class76.smethod_24(resKey_);
					foreach (DBPFEntry dbpfentry2 in list)
					{
						TGIIndex tgiindex5 = new TGIIndex(dbpfentry2.GenerateResKey());
						XML xml = Class76.smethod_26(new ResKey(tgiindex5.AsString())).Clone() as XML;
						string reskey = tgiindex5.Reskey;
						if (dictionary_0.ContainsKey(reskey))
						{
							tgiindex5.SetFromString(dictionary_0[tgiindex5.Reskey]);
						}
						else
						{
							tgiindex5.InstanceId = visualProxy.InstanceID;
							tgiindex5.SecondInstanceId = visualProxy.SecondInstanceID;
							tgiindex5.GroupId = visualProxy.GroupID;
							xml.GroupID = tgiindex5.GroupId;
							xml.InstanceID = tgiindex5.InstanceId;
							xml.SecondInstanceID = tgiindex5.SecondInstanceId;
							dbpf_0.AddEntry(xml);
							dictionary_0.Add(reskey, xml.GenerateResKey());
							objd.ReplaceReferences(new ResKey(reskey), new ResKey(tgiindex5.AsString()));
							foreach (XmlDocument xmlDocument in xml.Documents)
							{
								XmlElement xmlElement = xmlDocument.SelectSingleNode("/preset/complate") as XmlElement;
								if (xmlElement != null)
								{
									string attribute = xmlElement.GetAttribute("reskey");
									XML xml2 = Class76.smethod_26(new ResKey(attribute)) as XML;
									if (xml2 != null)
									{
										string key6 = xml2.GenerateResKey();
										if (dictionary_0.ContainsKey(key6))
										{
											xmlElement.SetAttribute("reskey", dictionary_0[key6]);
											objd.ReplaceReferences(new ResKey(key6), new ResKey(dictionary_0[key6]));
										}
										else
										{
											XML xml3 = xml2.Clone() as XML;
											xml3.InstanceID = random_0.Next();
											xml3.SecondInstanceID = random_0.Next();
											dbpf_0.AddEntry(xml3);
											xmlElement.SetAttribute("reskey", xml3.GenerateResKey());
											dictionary_0.Add(key6, xml3.GenerateResKey());
											objd.ReplaceReferences(new ResKey(key6), new ResKey(dictionary_0[key6]));
										}
									}
								}
								XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/preset/complate/pattern");
								foreach (object obj in xmlNodeList)
								{
									XmlElement xmlElement2 = (XmlElement)obj;
									string attribute2 = xmlElement2.GetAttribute("reskey");
									XML xml4 = Class76.smethod_26(new ResKey(attribute2)) as XML;
									if (xml4 != null)
									{
										string key7 = xml4.GenerateResKey();
										if (dictionary_0.ContainsKey(key7))
										{
											xmlElement2.SetAttribute("reskey", dictionary_0[key7]);
											objd.ReplaceReferences(new ResKey(key7), new ResKey(dictionary_0[key7]));
										}
										else
										{
											XML xml5 = xml4.Clone() as XML;
											xml5.InstanceID = random_0.Next();
											xml5.SecondInstanceID = random_0.Next();
											dbpf_0.AddEntry(xml5);
											xmlElement2.SetAttribute("reskey", xml5.GenerateResKey());
											dictionary_0.Add(key7, xml5.GenerateResKey());
											objd.ReplaceReferences(new ResKey(key7), new ResKey(xml5.GenerateResKey()));
										}
										string attribute3 = xmlElement2.GetAttribute("variable");
										XmlNodeList xmlNodeList2 = xmlDocument.SelectNodes("/preset/complate/value[@key=\"" + attribute3 + "\"]");
										foreach (object obj2 in xmlNodeList2)
										{
											XmlElement xmlElement3 = (XmlElement)obj2;
											string attribute4 = xmlElement3.GetAttribute("value");
											xmlElement3.SetAttribute("value", xmlElement2.GetAttribute("reskey"));
											foreach (OBJD.Material material in objd.Materials)
											{
												foreach (OBJD.Material.MaterialBlock materialBlock in material.Blocks)
												{
													foreach (OBJD.Material.ComplateVariable complateVariable in materialBlock.Variables)
													{
														if (complateVariable.VariableName.ToLower().Equals(attribute3.ToLower()) && complateVariable.GetValue().Equals(attribute4))
														{
															ResKey reskey2 = new ResKey(xmlElement2.GetAttribute("reskey"));
															int num = material.TGIIndex.IndexOf(new TGIIndex(reskey2));
															if (num > -1)
															{
																complateVariable.SetValue(3, string.Concat(num));
															}
														}
													}
												}
											}
										}
									}
								}
							}
							if ((objd_1.SubCategoryFlags & 35184372088832UL) != 0UL)
							{
								using (List<OBJD.Material>.Enumerator enumerator5 = objd.Materials.GetEnumerator())
								{
									if (enumerator5.MoveNext())
									{
										OBJD.Material material2 = enumerator5.Current;
										using (List<OBJD.Material.MaterialBlock>.Enumerator enumerator6 = material2.Blocks.GetEnumerator())
										{
											if (enumerator6.MoveNext())
											{
												OBJD.Material.MaterialBlock materialBlock2 = enumerator6.Current;
												foreach (OBJD.Material.MaterialBlock materialBlock3 in materialBlock2.Patterns)
												{
													XmlElement xmlElement4 = xml.Documents[0].SelectSingleNode("/preset/complate/pattern[@variable='" + materialBlock3.Ref2Name + "']") as XmlElement;
													if (xmlElement4 != null)
													{
														materialBlock3.Ref1Name = xmlElement4.GetAttribute("name");
														string attribute5 = xmlElement4.GetAttribute("reskey");
														material2.TGIIndex[(int)materialBlock3.XMLIndex].SetFromString(attribute5);
													}
												}
											}
										}
									}
								}
							}
						}
					}
					foreach (RCOLItem rcolitem in visualProxy.Entries)
					{
						VPXY vpxy = (VPXY)rcolitem;
						foreach (TGIIndex tgiindex6 in vpxy.TGIIndex)
						{
							try
							{
								DBPFType type = tgiindex6.Type;
								if (dictionary_0.ContainsKey(tgiindex6.Reskey))
								{
									tgiindex6.Reskey = dictionary_0[tgiindex6.Reskey];
								}
								else
								{
									DBPFEntry dbpfentry3 = Class76.smethod_26(new ResKey(tgiindex6.Reskey));
									if (tgiindex6.Type == DBPFType.MLOD && tgiindex6.GroupId == 1)
									{
										tgiindex6.InstanceId = objd.InstanceID;
										tgiindex6.SecondInstanceId = objd.SecondInstanceID;
									}
									if (dbpfentry3 == null)
									{
										Console.WriteLine("Failed to clone " + tgiindex6 + ", reskey not found");
									}
									else
									{
										string reskey3 = tgiindex6.Reskey;
										DBPFEntry dbpfentry4 = (DBPFEntry)dbpfentry3.Clone();
										dbpfentry4.InstanceID = (tgiindex6.InstanceId = random_0.Next());
										dbpfentry4.SecondInstanceID = (tgiindex6.SecondInstanceId = random_0.Next());
										if (!bool_3)
										{
											dbpfentry4.GroupID = (tgiindex6.GroupId = objd.GroupID);
										}
										if (dbpfentry4 is MODLModel)
										{
											MODLModel modlmodel = dbpfentry4 as MODLModel;
											dbpfentry4.InstanceID = (tgiindex6.InstanceId = objd.InstanceID);
											dbpfentry4.SecondInstanceID = (tgiindex6.SecondInstanceId = objd.SecondInstanceID);
											dbpfentry4.GroupID = (tgiindex6.GroupId = (objd.GroupID | 1));
											foreach (RCOLFileEntry rcolfileEntry in modlmodel.InternalResources)
											{
												if (rcolfileEntry.TypeID == RCOLItemType.MLOD)
												{
													rcolfileEntry.ResKey.InstanceId = dbpfentry4.InstanceID;
													rcolfileEntry.ResKey.SecondInstanceId = dbpfentry4.SecondInstanceID;
													rcolfileEntry.ResKey.GroupId = dbpfentry4.GroupID;
												}
											}
										}
										dbpf_0.AddEntry(dbpfentry4);
										dictionary_0.Add(reskey3, dbpfentry4.GenerateResKey());
										if (dbpfentry4 is RCOL)
										{
											Class80.smethod_4(dbpfentry4 as RCOL, dbpf_0, objd.GroupID, objd.InstanceID, objd.SecondInstanceID, ref dictionary_0, int_1, bool_3);
										}
									}
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine("Failed to clone " + tgiindex6.AsString() + ", " + ex.Message);
							}
						}
					}
					foreach (OBJD.Material material3 in objd.Materials)
					{
						foreach (TGIIndex tgiindex7 in material3.TGIIndex)
						{
							if (tgiindex7.Type != DBPFType.ALL && tgiindex7.Type != DBPFType.DDS && tgiindex7.InstanceId == resKey.InstanceId && tgiindex7.SecondInstanceId == resKey.SecondInstanceId)
							{
								if (dictionary_0.ContainsKey(tgiindex7.Reskey))
								{
									tgiindex7.SetFromString(dictionary_0[tgiindex7.Reskey]);
								}
								else
								{
									DBPFEntry dbpfentry5 = Class76.smethod_26(tgiindex7);
									if (dbpfentry5 != null)
									{
										dbpfentry5 = (dbpfentry5.Clone() as DBPFEntry);
										string key8 = dbpfentry5.GenerateResKey();
										dbpfentry5.InstanceID = (tgiindex7.InstanceId = ((tgiindex7.InstanceId == resKey.InstanceId) ? visualProxy.InstanceID : random_0.Next()));
										dbpfentry5.SecondInstanceID = (tgiindex7.SecondInstanceId = ((tgiindex7.SecondInstanceId == resKey.SecondInstanceId) ? visualProxy.SecondInstanceID : random_0.Next()));
										dbpf_0.AddEntry(dbpfentry5);
										dictionary_0.Add(key8, dbpfentry5.GenerateResKey());
									}
								}
							}
						}
					}
				}
				result = objd;
			}
			return result;
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x00071708 File Offset: 0x0006F908
		private static void smethod_3(List<TGIIndex> list_1, DBPF dbpf_0, ref Dictionary<string, string> dictionary_0, Random random_0)
		{
			foreach (TGIIndex tgiindex in list_1)
			{
				if (tgiindex.Type != DBPFType.ALL && tgiindex.Type != DBPFType.DDS)
				{
					if (dictionary_0.ContainsKey(tgiindex.AsString()))
					{
						tgiindex.SetFromString(dictionary_0[tgiindex.AsString()]);
					}
					else
					{
						DBPFEntry dbpfentry = Class76.smethod_26(tgiindex);
						if (dbpfentry != null)
						{
							dbpfentry = (dbpfentry.Clone() as DBPFEntry);
							string key = dbpfentry.GenerateResKey();
							dbpfentry.InstanceID = (tgiindex.InstanceId = random_0.Next());
							dbpfentry.SecondInstanceID = (tgiindex.SecondInstanceId = random_0.Next());
							dbpf_0.AddEntry(dbpfentry);
							dictionary_0.Add(key, dbpfentry.GenerateResKey());
						}
					}
				}
			}
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x000717F8 File Offset: 0x0006F9F8
		private static void smethod_4(RCOL rcol_0, DBPF dbpf_0, int int_1, int int_2, int int_3, ref Dictionary<string, string> dictionary_0, int int_4, bool bool_3)
		{
			Random random = new Random((int)DateTime.Now.Ticks);
			foreach (RCOLFileEntry rcolfileEntry in rcol_0.ExternalResources)
			{
				if (rcolfileEntry.TypeID != RCOLItemType.DDS)
				{
					ResKey resKey = rcolfileEntry.ResKey;
					if (dictionary_0.ContainsKey(resKey.AsString()))
					{
						rcolfileEntry.ResKey = new ResKey(dictionary_0[resKey.AsString()]);
					}
					else
					{
						string key = resKey.AsString();
						DBPFEntry dbpfentry = Class76.smethod_26(resKey);
						DBPFEntry dbpfentry2 = (DBPFEntry)dbpfentry.Clone();
						if (!bool_3)
						{
							dbpfentry2.GroupID = (rcolfileEntry.ResKey.GroupId = (int_4 | ((dbpfentry2 is MLODModel) ? (rcolfileEntry.ResKey.GroupId & 16777215) : 0)));
						}
						dbpfentry2.InstanceID = (rcolfileEntry.ResKey.InstanceId = random.Next());
						dbpfentry2.SecondInstanceID = (rcolfileEntry.ResKey.SecondInstanceId = random.Next());
						if (dbpfentry2 is MLODModel)
						{
							DBPFEntry dbpfentry3 = dbpfentry2;
							rcolfileEntry.ResKey.InstanceId = int_2;
							dbpfentry3.InstanceID = int_2;
							DBPFEntry dbpfentry4 = dbpfentry2;
							rcolfileEntry.ResKey.SecondInstanceId = int_3;
							dbpfentry4.SecondInstanceID = int_3;
						}
						dbpf_0.AddEntry(dbpfentry2);
						dictionary_0.Add(key, dbpfentry2.GenerateResKey());
						if (dbpfentry2 is RCOL)
						{
							Class80.smethod_4(dbpfentry2 as RCOL, dbpf_0, int_1, int_2, int_3, ref dictionary_0, int_4, bool_3);
						}
					}
				}
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x000719B8 File Offset: 0x0006FBB8
		public object GetRenderable()
		{
			return this.Renderable;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00064FCC File Offset: 0x000631CC
		public IWorkshopProject GetCurrentProject()
		{
			return Class132.mainForm.CurrentProject;
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00037B84 File Offset: 0x00035D84
		public bool HasSlots()
		{
			return true;
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x00005707 File Offset: 0x00003907
		public void SetSlotsVisible(bool bool_3)
		{
			this.Renderable.DisplaySlots = bool_3;
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00002A71 File Offset: 0x00000C71
		public void method_40()
		{
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00037B84 File Offset: 0x00035D84
		public bool HasRig()
		{
			return true;
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00005717 File Offset: 0x00003917
		public void SetRigVisible(bool bool_3)
		{
			this.Renderable.DisplayRig = bool_3;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x000719D0 File Offset: 0x0006FBD0
		public List<object> GetModels()
		{
			return new List<object>(this.method_25().ToArray());
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x000719F4 File Offset: 0x0006FBF4
		public List<object> GetGameObjects()
		{
			List<object> list = new List<object>();
			List<ResKey> list2 = this.project.Package.SearchEntries(new ResKey(DBPFType.OBJD));
			foreach (ResKey key in list2)
			{
				OBJD item = this.project.Package.GetEntry(key) as OBJD;
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x00071A84 File Offset: 0x0006FC84
		public object GetCurrentGameObject()
		{
			return this.objd_0;
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x00071A9C File Offset: 0x0006FC9C
		public bool HasShadows()
		{
			bool result;
			if ((this.objd_0.BuildCategoryFlags & 256U) > 0U)
			{
				result = false;
			}
			else if ((this.objd_0.BuildCategoryFlags & 2U) > 0U)
			{
				result = false;
			}
			else if ((this.objd_0.BuildCategoryFlags & 4U) > 0U)
			{
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00037B84 File Offset: 0x00035D84
		public bool HasBumpMap()
		{
			return true;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00005727 File Offset: 0x00003927
		public void Unload()
		{
			this.method_41();
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x00005731 File Offset: 0x00003931
		private void method_41()
		{
			Class132.smethod_0().method_34(null);
			Class132.smethod_0().method_25(this.Renderable);
			if (this.Renderable != null)
			{
				this.Renderable.imethod_8(true);
			}
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00071AF0 File Offset: 0x0006FCF0
		public static void smethod_5(float float_0, OBJD objd_1, DBPF dbpf_0)
		{
			OBJK objk = dbpf_0.GetEntry(new ResKey(objd_1.OBJK.Reskey)) as OBJK;
			if (objk != null)
			{
				OBJK.KeyEntry keyEntry = objk.GetKeyEntry("modelKey");
				TGIIndex tgiindex = objk.TGIIndex[keyEntry.TgiIndex];
				if (tgiindex != null)
				{
					VisualProxy visualProxy = dbpf_0.GetEntry(new ResKey(tgiindex.Reskey)) as VisualProxy;
					if (visualProxy == null)
					{
						throw new Exception("Model was not supported");
					}
					foreach (RCOLItem rcolitem in visualProxy.Entries)
					{
						VPXY vpxy = (VPXY)rcolitem;
						foreach (VPXY.VPXEntryEntry vpxentryEntry in vpxy.entries)
						{
							if (vpxentryEntry.type == 1)
							{
								foreach (int index in vpxentryEntry.index)
								{
									TGIIndex tgiindex2 = vpxy.TGIIndex[index];
									if (tgiindex2.IsType((DBPFType)3548561239U))
									{
										ResKey key = new ResKey(tgiindex2.Reskey);
										FTPTResource ftptresource = dbpf_0.GetEntry(key) as FTPTResource;
										foreach (RCOLItem rcolitem2 in ftptresource.Entries)
										{
											FTPT ftpt = (FTPT)rcolitem2;
											foreach (FTPT.FootprintEntry footprintEntry in ftpt.FootprintEntries)
											{
												for (int i = 0; i < footprintEntry.Entries.Count; i++)
												{
													SlimDX.Vector3 coordinate = new SlimDX.Vector3(footprintEntry.Entries[i][0], 0f, footprintEntry.Entries[i][1]);
													coordinate = SlimDX.Vector3.TransformCoordinate(coordinate, Matrix.RotationY(0.017453292f * float_0));
													footprintEntry.Entries[i][0] = coordinate.X;
													footprintEntry.Entries[i][1] = coordinate.Z;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04000637 RID: 1591
		private string string_0;

		// Token: 0x04000638 RID: 1592
		private string string_1;

		// Token: 0x04000639 RID: 1593
		private WorkshopProject project;

		// Token: 0x0400063A RID: 1594
		private PackageDescriptor packageDescriptor_0;

		// Token: 0x0400063B RID: 1595
		private OBJD objd_0;

		// Token: 0x0400063C RID: 1596
		private ObjdModelControl objdModelControl_0;

		// Token: 0x0400063D RID: 1597
		private List<Lod> list_0;

		// Token: 0x0400063E RID: 1598
		private Lod lod_0;

		// Token: 0x0400063F RID: 1599
		private Class124 class124_0;

		// Token: 0x04000640 RID: 1600
		private Class119 class119_0;

		// Token: 0x04000641 RID: 1601
		private bool bool_0;

		// Token: 0x04000642 RID: 1602
		private bool bool_1;

		// Token: 0x04000643 RID: 1603
		private int int_0;

		// Token: 0x04000644 RID: 1604
		private bool bool_2;

		// Token: 0x04000645 RID: 1605
		[CompilerGenerated]
		private Class105 class105_0;

		// Token: 0x04000646 RID: 1606
		[CompilerGenerated]
		private Image image_0;
	}
}
