using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns0;
using ns11;
using ns13;
using ns14;
using ns16;
using ns18;
using ns3;
using ns4;
using ns6;
using ns7;
using ns8;
using ns9;
using Package;
using Package.Helper;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3Workshop.Data;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;
using VisualHint.SmartPropertyGrid;

namespace ns2
{
	// Token: 0x0200002A RID: 42
	internal sealed class Class26 : IProjectModel, Interface1
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600014C RID: 332 RVA: 0x0001F3BC File Offset: 0x0001D5BC
		// (set) Token: 0x0600014D RID: 333 RVA: 0x0001F3D8 File Offset: 0x0001D5D8
		public uint Version
		{
			get
			{
				return this.objd_0.Version;
			}
			set
			{
				if (this.objd_0.Version < 30U && value >= 30U)
				{
					TGIIndex tgiindex = new TGIIndex(new ResKey(DBPFType.DDS, 0, this.objd_0.InstanceID, this.objd_0.SecondInstanceID));
					this.objd_0.BluePrintIconIndex = this.objd_0.AddTgi(this.objd_0.TgiIndex, tgiindex);
					DDS dds = new DDS();
					dds.GroupID = tgiindex.GroupId;
					dds.InstanceID = tgiindex.InstanceId;
					dds.SecondInstanceID = tgiindex.SecondInstanceId;
					Bitmap image = new Bitmap(512, 512);
					Graphics graphics = Graphics.FromImage(image);
					graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, 512, 512));
					dds.AddImage(image, true, DDS.DXTFormat.DXT5);
					Class132.mainForm.CurrentProject.Package.AddEntry(dds);
				}
				this.objd_0.Version = value;
				this.method_4();
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600014E RID: 334 RVA: 0x0001F4E0 File Offset: 0x0001D6E0
		// (set) Token: 0x0600014F RID: 335 RVA: 0x0001F4F8 File Offset: 0x0001D6F8
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

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000150 RID: 336 RVA: 0x0001F564 File Offset: 0x0001D764
		// (set) Token: 0x06000151 RID: 337 RVA: 0x0001F57C File Offset: 0x0001D77C
		[PropertyLook(typeof(PropertyMultilineEditLook))]
		[PropertyHeightMultiplier(3)]
		[PropertyFeel("button")]
		public string Description
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = ((value.Length > 240) ? value.Substring(0, 240) : value);
				this.objd_0.CatalogDescEntry = "Gameplay/Objects/Blueprints:" + StringHelpers.ToCamelCase(this.string_1);
				if (this.packageDescriptor_0 != null)
				{
					this.packageDescriptor_0.Description = this.string_1;
				}
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000152 RID: 338 RVA: 0x0001F5E8 File Offset: 0x0001D7E8
		// (set) Token: 0x06000153 RID: 339 RVA: 0x0001F604 File Offset: 0x0001D804
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

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000154 RID: 340 RVA: 0x0001F640 File Offset: 0x0001D840
		// (set) Token: 0x06000155 RID: 341 RVA: 0x0001F65C File Offset: 0x0001D85C
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
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

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000156 RID: 342 RVA: 0x0001F698 File Offset: 0x0001D898
		// (set) Token: 0x06000157 RID: 343 RVA: 0x0001F6B4 File Offset: 0x0001D8B4
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

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000158 RID: 344 RVA: 0x0001F6F0 File Offset: 0x0001D8F0
		// (set) Token: 0x06000159 RID: 345 RVA: 0x0001F70C File Offset: 0x0001D90C
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

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600015A RID: 346 RVA: 0x0001F748 File Offset: 0x0001D948
		// (set) Token: 0x0600015B RID: 347 RVA: 0x0001F764 File Offset: 0x0001D964
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

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600015C RID: 348 RVA: 0x0001F7A0 File Offset: 0x0001D9A0
		// (set) Token: 0x0600015D RID: 349 RVA: 0x00003236 File Offset: 0x00001436
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
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

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0001F7BC File Offset: 0x0001D9BC
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00003246 File Offset: 0x00001446
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

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000160 RID: 352 RVA: 0x0001F7D8 File Offset: 0x0001D9D8
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00003256 File Offset: 0x00001456
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
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

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000162 RID: 354 RVA: 0x0001F7F4 File Offset: 0x0001D9F4
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00003266 File Offset: 0x00001466
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
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

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000164 RID: 356 RVA: 0x0001F810 File Offset: 0x0001DA10
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00003276 File Offset: 0x00001476
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

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000166 RID: 358 RVA: 0x0001F82C File Offset: 0x0001DA2C
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00003286 File Offset: 0x00001486
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

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000168 RID: 360 RVA: 0x0001F848 File Offset: 0x0001DA48
		// (set) Token: 0x06000169 RID: 361 RVA: 0x00003296 File Offset: 0x00001496
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
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

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600016A RID: 362 RVA: 0x0001F864 File Offset: 0x0001DA64
		// (set) Token: 0x0600016B RID: 363 RVA: 0x000032A6 File Offset: 0x000014A6
		public Image LauncherThumbnail { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600016C RID: 364 RVA: 0x0001F87C File Offset: 0x0001DA7C
		// (set) Token: 0x0600016D RID: 365 RVA: 0x000032B1 File Offset: 0x000014B1
		public Image PNGIcon { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600016E RID: 366 RVA: 0x0001F894 File Offset: 0x0001DA94
		// (set) Token: 0x0600016F RID: 367 RVA: 0x0001F8B0 File Offset: 0x0001DAB0
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

		// Token: 0x06000170 RID: 368 RVA: 0x0001F964 File Offset: 0x0001DB64
		public Class26(WorkshopProject project)
		{
			this.list_0 = new List<Lod>();
			this.project = project;
			this.project.OnSave += this.method_7;
			this.class103_0 = new Class103();
			this.list_1 = new List<object>();
			this.blueprintModelControl_0 = new BlueprintModelControl(this)
			{
				Parent = Class132.mainForm.ProjectPanel,
				Dock = DockStyle.Fill
			};
			this.blueprintModelControl_0.MLODPropertyGrid.Model = this;
			List<ResKey> list = project.Package.SearchEntries(new ResKey(DBPFType.OBJD));
			foreach (ResKey resKey_ in list)
			{
				this.objd_0 = (Class76.smethod_26(resKey_) as OBJD);
				if (this.objd_0 != null)
				{
					XML xml = Class76.smethod_26(this.objd_0.TgiIndex[this.objd_0.BluePrintIndex]) as XML;
					if (xml != null)
					{
						XmlDocument xmlDocument = xml.Documents[0];
						XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/Blueprint/Partitions");
						foreach (object obj in xmlNodeList)
						{
							XmlElement xmlElement = (XmlElement)obj;
							XmlNodeList xmlNodeList2 = xmlElement.SelectNodes("Wall");
							foreach (object obj2 in xmlNodeList2)
							{
								XmlElement xmlElement_ = (XmlElement)obj2;
								this.class103_0.method_4(xmlElement_);
							}
						}
						XmlNodeList xmlNodeList3 = xmlDocument.SelectNodes("/Blueprint/Floors");
						foreach (object obj3 in xmlNodeList3)
						{
							XmlElement xmlElement2 = (XmlElement)obj3;
							XmlNodeList xmlNodeList4 = xmlElement2.SelectNodes("Floor");
							foreach (object obj4 in xmlNodeList4)
							{
								XmlElement xmlElement_2 = (XmlElement)obj4;
								this.class103_0.method_5(xmlElement_2);
							}
						}
						XmlNodeList xmlNodeList5 = xmlDocument.SelectNodes("/Blueprint/Objects");
						foreach (object obj5 in xmlNodeList5)
						{
							XmlElement xmlElement3 = (XmlElement)obj5;
							XmlNodeList xmlNodeList6 = xmlElement3.SelectNodes("Object");
							foreach (object obj6 in xmlNodeList6)
							{
								XmlElement xmlElement_3 = (XmlElement)obj6;
								this.class103_0.method_6(xmlElement_3);
							}
							XmlNodeList xmlNodeList7 = xmlElement3.SelectNodes("Door");
							foreach (object obj7 in xmlNodeList7)
							{
								XmlElement xmlElement_4 = (XmlElement)obj7;
								this.class103_0.method_7(xmlElement_4);
							}
							XmlNodeList xmlNodeList8 = xmlElement3.SelectNodes("Window");
							foreach (object obj8 in xmlNodeList8)
							{
								XmlElement xmlElement_5 = (XmlElement)obj8;
								this.class103_0.method_8(xmlElement_5);
							}
						}
					}
				}
			}
			this.method_11();
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("launcherThumbnail"))
			{
				string key = this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["launcherThumbnail"];
				PNG png = this.project.Package.GetEntry(new ResKey(key)) as PNG;
				this.LauncherThumbnail = png.Image;
			}
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("pngIcon"))
			{
				string key2 = this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["pngIcon"];
				PNG png2 = this.project.Package.GetEntry(new ResKey(key2)) as PNG;
				this.PNGIcon = png2.Image;
			}
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
			this.blueprintModelControl_0.BlueprintPropertyGrid.PropertyButtonClicked += this.method_9;
			this.blueprintModelControl_0.BlueprintPropertyGrid.PropertyChanged += this.method_10;
			PropertyEnumerator underCategory = this.blueprintModelControl_0.BlueprintPropertyGrid.AppendRootCategory(0, "Blueprint settings");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory, 1, "Name", this, "Title", "Title of blueprint");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory, 2, "Description", this, "Description", "Title of blueprint");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory, 3, "Price", this, "Price", "Price of object");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory, 4, "Version", this, "Version", "Version of object");
			PropertyEnumerator propertyEnumerator = this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory, 5, "Launcher thumbnail", this, "LauncherThumbnail", "Thumbnail image used in game launcher");
			propertyEnumerator.Property.Tag = "_launcherThumbnail";
			PropertyEnumerator propertyEnumerator2 = this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory, 6, "Catalog thumbnail", this, "PNGIcon", "Icon used in game catalog");
			propertyEnumerator2.Property.Tag = "_pngIcon";
			PropertyEnumerator underCategory2 = this.blueprintModelControl_0.BlueprintPropertyGrid.AppendSubCategory(underCategory, 7, "Category flags");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 8, "Build Buy Flags", this, "BuildBuyStatusFlags", "");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 9, "Function category", this, "Category", "");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 10, "Function sub category", this, "SubCategory", "");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 11, "Room category", this, "Room", "");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 12, "Room sub category", this, "SubRoom", "");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 13, "Build category", this, "BuildType", "");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 14, "ObjectTypeFlags", this, "ObjectTypeFlags", "ObjectTypeFlags of object");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 15, "ObjectTypeFlags2", this, "ObjectTypeFlags2", "ObjectTypeFlags2 of object");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 16, "WallPlacementFlags", this, "WallPlacementFlags", "WallPlacementFlags of object");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 17, "MovementFlags", this, "MovementFlags", "MovementFlags of object");
			this.blueprintModelControl_0.BlueprintPropertyGrid.AppendProperty(underCategory2, 18, "SlotPlacementFlags", this, "SlotPlacementFlags", "SlotPlacementFlags of object");
			this.blueprintModelControl_0.MiscPropertyGrid.RegisterFeel("texture", new Class58(this.blueprintModelControl_0.MiscPropertyGrid, false));
			this.blueprintModelControl_0.MiscPropertyGrid.RegisterFeelAttachment(typeof(TextureResKey), "texture");
			this.blueprintModelControl_0.MiscPropertyGrid.RegisterFeelAttachment(typeof(PatternResKey), "texture");
			this.blueprintModelControl_0.MiscPropertyGrid.PropertyChanged += this.method_3;
			this.blueprintModelControl_0.MiscPropertyGrid.PropertySelected += this.method_2;
			this.blueprintModelControl_0.MiscPropertyGrid.PropertyButtonClicked += this.method_1;
			this.blueprintModelControl_0.MLODPropertyGrid.MeshChanged += this.method_0;
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.TryGetValue("ShowFloors", out text);
			this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.TryGetValue("ShowWalls", out text2);
			this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.TryGetValue("ShowDoors", out text3);
			this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.TryGetValue("ShowObjects", out text4);
			this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.TryGetValue("ShowFootprint", out text5);
			this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.TryGetValue("ShowSlots", out text6);
			if (string.IsNullOrEmpty(text))
			{
				text = "true";
			}
			if (string.IsNullOrEmpty(text2))
			{
				text2 = "true";
			}
			if (string.IsNullOrEmpty(text3))
			{
				text3 = "true";
			}
			if (string.IsNullOrEmpty(text4))
			{
				text4 = "true";
			}
			if (string.IsNullOrEmpty(text5))
			{
				text5 = "false";
			}
			if (string.IsNullOrEmpty(text6))
			{
				text6 = "false";
			}
			this.class103_0.ShowFloors = text.Equals("true");
			this.class103_0.ShowWalls = text2.Equals("true");
			this.class103_0.ShowDoorsAndWindows = text3.Equals("true");
			this.class103_0.ShowObjects = text4.Equals("true");
			this.class103_0.ShowFootprint = text5.Equals("true");
			this.class103_0.DisplaySlots = text6.Equals("true");
			this.blueprintModelControl_0.ObjectsPropertyGrid.PropertySelected += this.method_6;
			this.method_4();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000032BC File Offset: 0x000014BC
		private void method_0(bool bool_1)
		{
			if (bool_1)
			{
				Class132.smethod_0().method_3(this.class103_0);
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00020590 File Offset: 0x0001E790
		private void method_1(object sender, PropertyButtonClickedEventArgs e)
		{
			if (e.PropertyEnum.Property.Value.Tag.GetType() == typeof(Class19))
			{
				Class19 @class = e.PropertyEnum.Property.Value.Tag as Class19;
				FTPT.FootprintEntry slot = @class.method_0().Slot;
				FootprintEditor footprintEditor = new FootprintEditor(this.Sims3WorkshopSDK.Interfaces.IProjectModel.GetModels(), slot);
				if (footprintEditor.ShowDialog(this.blueprintModelControl_0.MiscPropertyGrid) == DialogResult.OK)
				{
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
					slot.BoundingBox[0] = footprintEditor.MinX;
					slot.BoundingBox[1] = footprintEditor.MinZ;
					slot.BoundingBox[2] = footprintEditor.MaxX;
					slot.BoundingBox[3] = footprintEditor.MaxZ;
					@class.method_0().method_0();
					e.PropertyChanged = true;
				}
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0002066C File Offset: 0x0001E86C
		private void method_2(object sender, PropertySelectedEventArgs e)
		{
			if (this.class129_0 != null)
			{
				this.class129_0.Visible = this.class103_0.DisplaySlots;
			}
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.GetType() == typeof(Class19))
			{
				Class19 @class = (Class19)e.PropertyEnum.Property.Value.Tag;
				this.class129_0 = @class.method_0();
				this.class129_0.Visible = true;
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0002071C File Offset: 0x0001E91C
		private void method_3(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("changedBlueprintBool") && e.PropertyEnum.Property.Value.GetValue().Equals(true))
			{
				this.Version = 31U;
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			}
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("showObjects"))
			{
				this.class103_0.ShowObjects = (bool)e.PropertyEnum.Property.Value.GetValue();
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["ShowObjects"] = this.class103_0.ShowObjects.ToString().ToLower();
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			}
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("showWalls"))
			{
				this.class103_0.ShowWalls = (bool)e.PropertyEnum.Property.Value.GetValue();
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["ShowWalls"] = this.class103_0.ShowWalls.ToString().ToLower();
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			}
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("showFloors"))
			{
				this.class103_0.ShowFloors = (bool)e.PropertyEnum.Property.Value.GetValue();
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["ShowFloors"] = this.class103_0.ShowFloors.ToString().ToLower();
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			}
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("showDoors"))
			{
				this.class103_0.ShowDoorsAndWindows = (bool)e.PropertyEnum.Property.Value.GetValue();
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["ShowDoors"] = this.class103_0.ShowDoorsAndWindows.ToString().ToLower();
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			}
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("showFootprint"))
			{
				this.class103_0.ShowFootprint = (bool)e.PropertyEnum.Property.Value.GetValue();
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["ShowFootprint"] = this.class103_0.ShowFootprint.ToString().ToLower();
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			}
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("showSlots"))
			{
				this.class103_0.DisplaySlots = (bool)e.PropertyEnum.Property.Value.GetValue();
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["ShowSlots"] = this.class103_0.DisplaySlots.ToString().ToLower();
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00020AF8 File Offset: 0x0001ECF8
		private void method_4()
		{
			int num = 0;
			Class2 miscPropertyGrid = this.blueprintModelControl_0.MiscPropertyGrid;
			miscPropertyGrid.Clear();
			VisualHint.SmartPropertyGrid.PropertyGrid propertyGrid = miscPropertyGrid;
			int id = 0;
			num = 1;
			PropertyEnumerator underCategory = propertyGrid.AppendRootCategory(id, "Misc properties");
			if (this.objd_0.Version >= 30U)
			{
				TextureResKey initialValue = new TextureResKey(this.objd_0.TgiIndex[this.objd_0.BluePrintIconIndex].Reskey);
				PropertyEnumerator propertyEnumerator = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Blueprint Icon", typeof(TextureResKey), initialValue, "");
				propertyEnumerator.Property.Value.Tag = this.objd_0.TgiIndex[this.objd_0.FloorMaskIndex];
				Class61 @class = new Class61();
				propertyEnumerator.Property.Value.Look = @class;
				@class.PropertyChanged += this.method_5;
			}
			else
			{
				PropertyEnumerator propertyEnumerator2 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Blueprint Icon", typeof(bool), false, "Does this blueprint have a custom icon?");
				propertyEnumerator2.Property.Tag = "changedBlueprintBool";
			}
			if (this.objd_0.Version >= 31U)
			{
				miscPropertyGrid.AppendProperty(underCategory, num++, "BluePrintIconOffsetMinX", this.objd_0, "BluePrintIconOffsetMinX", "BluePrintIconOffsetMinX");
				miscPropertyGrid.AppendProperty(underCategory, num++, "BluePrintIconOffsetMinZ", this.objd_0, "BluePrintIconOffsetMinZ", "BluePrintIconOffsetMinZ");
				miscPropertyGrid.AppendProperty(underCategory, num++, "BluePrintIconOffsetMaxX", this.objd_0, "BluePrintIconOffsetMaxX", "BluePrintIconOffsetMaxX");
				miscPropertyGrid.AppendProperty(underCategory, num++, "BluePrintIconOffsetMaxZ", this.objd_0, "BluePrintIconOffsetMaxZ", "BluePrintIconOffsetMaxZ");
			}
			PropertyEnumerator propertyEnumerator3 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Show floors", typeof(bool), this.class103_0.ShowFloors, "Show floors in editor");
			propertyEnumerator3.Property.Tag = "showFloors";
			PropertyEnumerator propertyEnumerator4 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Show walls", typeof(bool), this.class103_0.ShowWalls, "Show walls in editor");
			propertyEnumerator4.Property.Tag = "showWalls";
			PropertyEnumerator propertyEnumerator5 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Show door & windows", typeof(bool), this.class103_0.ShowDoorsAndWindows, "Show doors and windows in editor");
			propertyEnumerator5.Property.Tag = "showDoors";
			PropertyEnumerator propertyEnumerator6 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Show objects", typeof(bool), this.class103_0.ShowObjects, "Show footprint in editor");
			propertyEnumerator6.Property.Tag = "showObjects";
			PropertyEnumerator propertyEnumerator7 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Show footprint", typeof(bool), this.class103_0.ShowFootprint, "Show footprint in editor");
			propertyEnumerator7.Property.Tag = "showFootprint";
			PropertyEnumerator propertyEnumerator8 = miscPropertyGrid.AppendManagedProperty(underCategory, num++, "Show slots", typeof(bool), this.class103_0.DisplaySlots, "Show slots in editor");
			propertyEnumerator8.Property.Tag = "showSlots";
			PropertyEnumerator propertyEnumerator9 = miscPropertyGrid.AppendRootCategory(num++, "Footprint");
			foreach (Class129 class2 in this.class103_0.Footprints)
			{
				Class19 class3 = new Class19(class2);
				PropertyEnumerator propertyEnumerator10 = miscPropertyGrid.AppendManagedProperty(propertyEnumerator9, num++, string.Concat(new object[]
				{
					"Slot type ",
					class2.Slot.TypeFlags,
					" 0x",
					class2.Slot.NameHash.ToString("X8")
				}), typeof(Class19), class3, "wrapper");
				propertyEnumerator10.Property.Value.Tag = class3;
			}
			miscPropertyGrid.ExpandProperty(propertyEnumerator9, true);
			PropertyEnumerator underCategory2 = this.blueprintModelControl_0.ObjectsPropertyGrid.AppendRootCategory(num++, "Game Objects");
			foreach (Class115 class4 in this.class103_0.list_12)
			{
				PropertyEnumerator propertyEnumerator11 = this.blueprintModelControl_0.ObjectsPropertyGrid.AppendManagedProperty(underCategory2, num++, class4.objd_0.CatalogNameEntry.Substring(class4.objd_0.CatalogNameEntry.IndexOf("Name:") + 5), typeof(ResKey), class4.objd_0.ResKey, "Game object");
				propertyEnumerator11.Property.Tag = class4;
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00021008 File Offset: 0x0001F208
		private void method_5(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
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

		// Token: 0x06000177 RID: 375 RVA: 0x00021090 File Offset: 0x0001F290
		private void method_6(object sender, PropertySelectedEventArgs e)
		{
			foreach (Class115 @class in this.class103_0.list_12)
			{
				@class.IsHighlighted = false;
			}
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag is Class115)
			{
				Class115 class2 = e.PropertyEnum.Property.Tag as Class115;
				class2.IsHighlighted = true;
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000032D3 File Offset: 0x000014D3
		private void method_7()
		{
			this.method_8();
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00021134 File Offset: 0x0001F334
		public void method_8()
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
			XML xml = Class76.smethod_26(this.objd_0.TgiIndex[this.objd_0.BluePrintIndex]) as XML;
			if (xml != null)
			{
				XmlDocument xmlDocument = xml.Documents[0];
				XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/Blueprint/Objects");
				foreach (object obj in xmlNodeList)
				{
					XmlElement xmlElement = (XmlElement)obj;
					XmlNodeList xmlNodeList2 = xmlElement.SelectNodes("Object");
					foreach (object obj2 in xmlNodeList2)
					{
						XmlElement xmlElement2 = (XmlElement)obj2;
						xmlElement2.ParentNode.RemoveChild(xmlElement2);
					}
					foreach (Class115 @class in this.class103_0.list_12)
					{
						XmlElement xmlElement3 = xmlDocument.CreateElement("Object");
						XmlElement xmlElement4 = xmlElement3;
						string name = "X";
						float x = @class.Position.X;
						xmlElement4.SetAttribute(name, x.ToString().Replace(",", "."));
						XmlElement xmlElement5 = xmlElement3;
						string name2 = "Y";
						float y = @class.Position.Y;
						xmlElement5.SetAttribute(name2, y.ToString().Replace(",", "."));
						XmlElement xmlElement6 = xmlElement3;
						string name3 = "Z";
						float z = @class.Position.Z;
						xmlElement6.SetAttribute(name3, z.ToString().Replace(",", "."));
						xmlElement3.SetAttribute("Facing", @class.RotationAngle.ToString().Replace(",", "."));
						if (@class.presetId > -1)
						{
							xmlElement3.SetAttribute("PresetId", @class.presetId.ToString());
						}
						else if (@class.customPresetIndex > -1)
						{
							xmlElement3.SetAttribute("CustomPresetIndex", @class.customPresetIndex.ToString());
						}
						xmlElement3.SetAttribute("IsDiagonalShifted", @class.isDiagonalShifted.ToString());
						string value2 = string.Concat(new string[]
						{
							((uint)@class.objd_0.TypeID).ToString(),
							",",
							@class.objd_0.GroupID.ToString(),
							",",
							@class.objd_0.SecondInstanceID.ToString(),
							",",
							@class.objd_0.InstanceID.ToString()
						});
						xmlElement3.SetAttribute("ResourceKey", value2);
						if (@class.list_2.Count > 0)
						{
							xmlElement3.SetAttribute("NumChildren", @class.list_2.Count.ToString());
							foreach (Class115 class2 in @class.list_2)
							{
								XmlElement xmlElement7 = xmlDocument.CreateElement("SlottedObject");
								xmlElement7.SetAttribute("SlotID", class2.slotId.ToString());
								xmlElement7.SetAttribute("Facing", class2.RotationAngle.ToString().Replace(",", "."));
								if (class2.presetId > -1)
								{
									xmlElement7.SetAttribute("PresetId", class2.presetId.ToString());
								}
								else if (class2.customPresetIndex > -1)
								{
									xmlElement7.SetAttribute("CustomPresetIndex", class2.customPresetIndex.ToString());
								}
								value2 = string.Concat(new string[]
								{
									((uint)class2.objd_0.TypeID).ToString(),
									",",
									class2.objd_0.GroupID.ToString(),
									",",
									class2.objd_0.SecondInstanceID.ToString(),
									",",
									class2.objd_0.InstanceID.ToString()
								});
								xmlElement7.SetAttribute("ResourceKey", value2);
								xmlElement3.AppendChild(xmlElement7);
							}
						}
						xmlElement.AppendChild(xmlElement3);
					}
				}
			}
			Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = value;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x000032DD File Offset: 0x000014DD
		public void Unload()
		{
			this.class103_0.imethod_8(true);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00021858 File Offset: 0x0001FA58
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
			this.method_8();
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

		// Token: 0x0600017C RID: 380 RVA: 0x000032ED File Offset: 0x000014ED
		public void ImportPackage(object object_0)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00021C3C File Offset: 0x0001FE3C
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

		// Token: 0x0600017E RID: 382 RVA: 0x00021E30 File Offset: 0x00020030
		private void method_9(object sender, PropertyButtonClickedEventArgs e)
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
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00021F68 File Offset: 0x00020168
		private void method_10(object sender, PropertyChangedEventArgs e)
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
			if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_pngIcon"))
			{
				if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("pngIcon"))
				{
					ResKey resKey = new ResKey(this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["pngIcon"]);
					ResKey key2 = new ResKey(DBPFType.PNG_THUMB_MEDIUM, resKey.GroupId, resKey.InstanceId, resKey.SecondInstanceId);
					ResKey key3 = new ResKey(DBPFType.PNG_THUMB_SMALL, resKey.GroupId, resKey.InstanceId, resKey.SecondInstanceId);
					ResKey key4 = new ResKey(DBPFType.PNG_THUMB_LARGE, resKey.GroupId, resKey.InstanceId, resKey.SecondInstanceId);
					PNG png3 = this.project.Package.GetEntry(key2) as PNG;
					PNG png4 = this.project.Package.GetEntry(key3) as PNG;
					PNG png5 = this.project.Package.GetEntry(key4) as PNG;
					Bitmap image = new Bitmap(128, 128);
					Bitmap image2 = new Bitmap(64, 64);
					Bitmap image3 = new Bitmap(32, 32);
					Size size = (value as Bitmap).Size;
					Graphics.FromImage(image).DrawImage(value as Bitmap, new Rectangle(0, 0, 128, 128), new Rectangle(0, 0, size.Width, size.Height), GraphicsUnit.Pixel);
					Graphics.FromImage(image2).DrawImage(value as Bitmap, new Rectangle(0, 0, 64, 64), new Rectangle(0, 0, size.Width, size.Height), GraphicsUnit.Pixel);
					Graphics.FromImage(image3).DrawImage(value as Bitmap, new Rectangle(0, 0, 32, 32), new Rectangle(0, 0, size.Width, size.Height), GraphicsUnit.Pixel);
					png3.Image = image;
					png4.Image = image2;
					png5.Image = image3;
					this.project.Package.AddEntry(png3);
					this.project.Package.AddEntry(png4);
					this.project.Package.AddEntry(png5);
					png3.Image.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\apa.png", ImageFormat.Png);
				}
				else
				{
					PNG png6 = new PNG(DBPFType.PNG_THUMB_LARGE);
					PNG png7 = new PNG(DBPFType.PNG_THUMB_MEDIUM);
					PNG png8 = new PNG(DBPFType.PNG_THUMB_SMALL);
					Bitmap image4 = new Bitmap(128, 128);
					Bitmap image5 = new Bitmap(64, 64);
					Bitmap image6 = new Bitmap(32, 32);
					Size size2 = (value as Bitmap).Size;
					Graphics.FromImage(image4).DrawImage(value as Bitmap, new Rectangle(0, 0, 128, 128), new Rectangle(0, 0, size2.Width, size2.Height), GraphicsUnit.Pixel);
					Graphics.FromImage(image5).DrawImage(value as Bitmap, new Rectangle(0, 0, 64, 64), new Rectangle(0, 0, size2.Width, size2.Height), GraphicsUnit.Pixel);
					Graphics.FromImage(image6).DrawImage(value as Bitmap, new Rectangle(0, 0, 32, 32), new Rectangle(0, 0, size2.Width, size2.Height), GraphicsUnit.Pixel);
					png6.Image = image4;
					png7.Image = image5;
					png8.Image = image6;
					png6.InstanceID = (png7.InstanceID = (png8.InstanceID = this.objd_0.TgiIndex[this.objd_0.BluePrintIndex].InstanceId));
					png6.SecondInstanceID = (png7.SecondInstanceID = (png8.SecondInstanceID = this.objd_0.TgiIndex[this.objd_0.BluePrintIndex].SecondInstanceId));
					png6.GroupID = (png7.GroupID = (png8.GroupID = this.objd_0.GroupID));
					this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("pngIcon", png6.GenerateResKey());
					long pngIcon = ((long)png6.InstanceID << 32) + (long)png6.SecondInstanceID;
					this.objd_0.PngIcon = pngIcon;
					this.project.Package.AddEntry(png6);
					this.project.Package.AddEntry(png7);
					this.project.Package.AddEntry(png8);
				}
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00022538 File Offset: 0x00020738
		public bool imethod_0(object object_0, MouseEventArgs mouseEventArgs_0, Viewport viewport_0)
		{
			Matrix worldMatrix = Class132.smethod_0().WorldMatrix;
			Matrix viewMatrix = Class132.smethod_0().ViewMatrix;
			Matrix projectionMatrix = Class132.smethod_0().ProjectionMatrix;
			bool result;
			if (this.bool_0 && this.class115_0 != null)
			{
				this.class115_0.bool_0 = false;
				if ((Control.ModifierKeys & Keys.Control) != Keys.None)
				{
					this.class115_0.RotationAngle += this.class115_0.float_0;
					foreach (Class115 @class in this.class115_0.list_2)
					{
						@class.RotationAngle += this.class115_0.float_0;
					}
					this.class115_0.float_0 = 0f;
				}
				else
				{
					Vector3 vector = this.vector3_1;
					float x = (float)((int)(vector.X * 2f + ((vector.X < 0f) ? -0.5f : 0.5f))) / 2f;
					float z = (float)((int)(vector.Z * 2f + ((vector.Z < 0f) ? -0.5f : 0.5f))) / 2f;
					this.class115_0.Position = new Vector3(x, 0f, z);
				}
				this.bool_0 = false;
				this.class115_0 = null;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000226C4 File Offset: 0x000208C4
		public bool imethod_1(object object_0, MouseEventArgs mouseEventArgs_0, Viewport viewport_0)
		{
			Matrix worldMatrix = Class132.smethod_0().WorldMatrix;
			Matrix viewMatrix = Class132.smethod_0().ViewMatrix;
			Matrix projectionMatrix = Class132.smethod_0().ProjectionMatrix;
			if (this.blueprintModelControl_0.ToolMode == BlueprintModelControl.Enum0.const_0)
			{
				if ((this.blueprintModelControl_0.CurrentWindow as BuildToolWindow).Mode == 0)
				{
					Vector3 vector = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, worldMatrix * viewMatrix * projectionMatrix);
					Vector3 vector2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, worldMatrix * viewMatrix * projectionMatrix);
					Ray ray = new Ray(vector, vector2);
					float num = 0f;
					if (Ray.Intersects(ray, new BoundingBox(new Vector3(10f, 0f, 10f), new Vector3(-10f, 0f, -10f)), out num))
					{
						Vector3 vector3 = Vector3.Lerp(vector, vector2, num / Vector3.Distance(vector, vector2));
						float num2 = (float)((int)(vector3.X * 2f + ((vector3.X < 0f) ? -0.5f : 0.5f))) / 2f;
						float num3 = (float)((int)(vector3.Z * 2f + ((vector3.Z < 0f) ? -0.5f : 0.5f))) / 2f;
						Console.WriteLine(string.Concat(new object[]
						{
							"point on floor = ",
							num2,
							"x",
							num3
						}));
					}
				}
			}
			else if (this.blueprintModelControl_0.ToolMode == BlueprintModelControl.Enum0.const_1 && (this.blueprintModelControl_0.CurrentWindow as ObjectToolWindow).Mode == 0)
			{
				List<Class115> list = new List<Class115>();
				if (this.class103_0.ShowObjects)
				{
					foreach (Class115 @class in this.class103_0.list_12)
					{
						list.Add(@class);
						list.AddRange(@class.list_2);
					}
				}
				float num4 = float.MaxValue;
				foreach (Class115 class2 in list)
				{
					Matrix matrix_ = class2.matrix_4;
					Vector3 position = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_ * worldMatrix * viewMatrix * projectionMatrix);
					Vector3 direction = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_ * worldMatrix * viewMatrix * projectionMatrix);
					Ray ray2 = new Ray(position, direction);
					float num5 = 0f;
					if (Ray.Intersects(ray2, class2.boundingBox_0, out num5) && num5 < num4)
					{
						this.class115_0 = class2;
						num4 = num5;
					}
				}
				if (this.class115_0 != null)
				{
					this.class115_0.bool_0 = true;
					this.bool_0 = true;
					Vector3 vector4 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, worldMatrix * viewMatrix * projectionMatrix);
					Vector3 vector5 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, worldMatrix * viewMatrix * projectionMatrix);
					Ray ray3 = new Ray(vector4, vector5);
					float num6 = 0f;
					if (Ray.Intersects(ray3, new BoundingBox(new Vector3(100f, 0f, 100f), new Vector3(-100f, 0f, -100f)), out num6))
					{
						this.vector3_0 = Vector3.Lerp(vector4, vector5, num6 / Vector3.Distance(vector4, vector5));
					}
					if (this.class115_0.class115_0 != null)
					{
						Class115 class3 = this.class115_0.class115_0;
						class3.list_2.Remove(this.class115_0);
						float x = (float)((int)(this.vector3_0.X * 2f + ((this.vector3_0.X < 0f) ? -0.5f : 0.5f))) / 2f;
						float z = (float)((int)(this.vector3_0.Z * 2f + ((this.vector3_0.Z < 0f) ? -0.5f : 0.5f))) / 2f;
						this.class115_0.Position = new Vector3(x, 0f, z);
						this.class103_0.list_12.Add(this.class115_0);
					}
					this.vector3_1 = this.class115_0.Position;
					if ((Control.ModifierKeys & Keys.Control) != Keys.None)
					{
						Matrix matrix_2 = this.class115_0.matrix_0;
						matrix_2.Invert();
						Vector3 vector6 = Vector3.TransformCoordinate(new Vector3(0f, 0f, 10f), this.class115_0.matrix_1);
						Vector3 vector7 = Vector3.TransformCoordinate(new Vector3(this.vector3_0.X, 0f, this.vector3_0.Z), matrix_2);
						this.double_0 = Math.Atan2((double)vector7.Z, (double)vector7.X) - Math.Atan2((double)vector6.Z, (double)vector6.X);
					}
				}
			}
			return false;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00022DA4 File Offset: 0x00020FA4
		public bool imethod_2(object object_0, MouseEventArgs mouseEventArgs_0, Viewport viewport_0)
		{
			Matrix worldMatrix = Class132.smethod_0().WorldMatrix;
			Matrix viewMatrix = Class132.smethod_0().ViewMatrix;
			Matrix projectionMatrix = Class132.smethod_0().ProjectionMatrix;
			bool result;
			if (this.bool_0 && this.class115_0 != null)
			{
				Vector3 vector = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, worldMatrix * viewMatrix * projectionMatrix);
				Vector3 vector2 = Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, worldMatrix * viewMatrix * projectionMatrix);
				Ray ray = new Ray(vector, vector2);
				float num = 0f;
				if (Ray.Intersects(ray, new BoundingBox(new Vector3(10f, 0f, 10f), new Vector3(-10f, 0f, -10f)), out num))
				{
					Vector3 left = Vector3.Lerp(vector, vector2, num / Vector3.Distance(vector, vector2));
					if ((Control.ModifierKeys & Keys.Control) == Keys.None)
					{
						Vector3 right = left - this.vector3_0;
						Vector3 vector3 = this.vector3_1 + right;
						float x = (float)((int)(vector3.X * 2f + ((vector3.X < 0f) ? -0.5f : 0.5f))) / 2f;
						float z = (float)((int)(vector3.Z * 2f + ((vector3.Z < 0f) ? -0.5f : 0.5f))) / 2f;
						this.class115_0.Position = new Vector3(x, 0f, z);
						this.vector3_1 = vector3;
						this.vector3_0 = left;
						return true;
					}
					Matrix matrix_ = this.class115_0.matrix_0;
					matrix_.Invert();
					Vector3 vector4 = Vector3.TransformCoordinate(new Vector3(0f, 0f, 10f), this.class115_0.matrix_1);
					Vector3 vector5 = Vector3.TransformCoordinate(new Vector3(left.X, 0f, left.Z), matrix_);
					double num2 = Math.Atan2((double)vector5.Z, (double)vector5.X) - Math.Atan2((double)vector4.Z, (double)vector4.X) - this.double_0;
					double num3 = num2 / 3.141592653589793;
					num3 *= 4.0;
					num3 += (double)((num3 < 0.0) ? -0.25f : 0.25f);
					num3 = (double)((float)((int)num3) / 4f);
					this.class115_0.float_0 = (float)(-(float)(num3 * 3.141592653589793));
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000230C0 File Offset: 0x000212C0
		private static OBJD smethod_0(OBJD objd_1, string string_2, ref DBPF dbpf_0, ref Dictionary<string, string> dictionary_0, Random random_0, bool bool_1, int int_0)
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
				uint typeId = tgiindex.TypeId;
				if (!bool_1)
				{
					objd.GroupID = int_0;
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
				if (dictionary_0.ContainsKey(key3))
				{
					OBJK objk = dbpf_0.GetEntry(new ResKey(dictionary_0[key3])) as OBJK;
				}
				else
				{
					OBJK objk2 = Class76.smethod_26(tgiindex2) as OBJK;
					if (objk2 == null)
					{
						return objd;
					}
					OBJK objk = objk2.Clone() as OBJK;
					objk = (Class76.smethod_26(tgiindex2).Clone() as OBJK);
					string key4 = objk.GenerateResKey();
					objk.GroupID = (tgiindex2.GroupId = objd.GroupID);
					objk.InstanceID = (tgiindex2.InstanceId = objd.InstanceID);
					objk.SecondInstanceID = (tgiindex2.SecondInstanceId = objd.SecondInstanceID);
					dbpf_0.AddEntry(objk);
					dictionary_0.Add(key4, objk.GenerateResKey());
				}
				result = objd;
			}
			return result;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00023324 File Offset: 0x00021524
		private static void smethod_1(RCOL rcol_0, DBPF dbpf_0, int int_0, int int_1, int int_2, ref Dictionary<string, string> dictionary_0, int int_3, bool bool_1)
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
						if (!bool_1)
						{
							dbpfentry2.GroupID = (rcolfileEntry.ResKey.GroupId = (int_3 | ((dbpfentry2 is MLODModel) ? (rcolfileEntry.ResKey.GroupId & 16777215) : 0)));
						}
						dbpfentry2.InstanceID = (rcolfileEntry.ResKey.InstanceId = random.Next());
						dbpfentry2.SecondInstanceID = (rcolfileEntry.ResKey.SecondInstanceId = random.Next());
						if (dbpfentry2 is MLODModel)
						{
							DBPFEntry dbpfentry3 = dbpfentry2;
							rcolfileEntry.ResKey.InstanceId = int_1;
							dbpfentry3.InstanceID = int_1;
							DBPFEntry dbpfentry4 = dbpfentry2;
							rcolfileEntry.ResKey.SecondInstanceId = int_2;
							dbpfentry4.SecondInstanceID = int_2;
						}
						dbpf_0.AddEntry(dbpfentry2);
						dictionary_0.Add(key, dbpfentry2.GenerateResKey());
						if (dbpfentry2 is RCOL)
						{
							Class26.smethod_1(dbpfentry2 as RCOL, dbpf_0, int_0, int_1, int_2, ref dictionary_0, int_3, bool_1);
						}
					}
				}
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000234E4 File Offset: 0x000216E4
		public static OBJD smethod_2(OBJD objd_1, string string_2, DBPF dbpf_0, bool bool_1, int int_0, Dictionary<string, string> dictionary_0, bool bool_2, object object_0)
		{
			if ((objd_1.GroupID & 1207959552) == 1207959552)
			{
				int_0 = 671088640;
				bool_1 = false;
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
			OBJD objd = Class26.smethod_0(objd_1, string_2, ref dbpf_0, ref dictionary_0, random, bool_1, int_0);
			if (objd.TgiIndex[objd.DiagonalIndex].TypeId != 0U)
			{
				TGIIndex tgiindex = objd.TgiIndex[objd.DiagonalIndex];
				DBPFEntry dbpfentry = Class76.smethod_26(new ResKey(tgiindex.AsString()));
				if (dbpfentry is OBJD)
				{
					OBJD objd_2 = dbpfentry as OBJD;
					OBJD objd2 = Class26.smethod_0(objd_2, string_2, ref dbpf_0, ref dictionary_0, random, bool_1, int_0);
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
					OBJD objd3 = Class26.smethod_0(objd_3, string_2, ref dbpf_0, ref dictionary_0, random, bool_1, int_0);
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
				ResKey resKey = new ResKey(tgiindex3.AsString());
				DBPFEntry dbpfentry3 = Class76.smethod_26(new ResKey(tgiindex3.AsString()));
				if (dbpfentry3 is XML)
				{
					XML xml = dbpfentry3 as XML;
					XML xml2 = xml.Clone() as XML;
					xml2.InstanceID = random.Next();
					xml2.SecondInstanceID = random.Next();
					dictionary_0.Add(new ResKey(tgiindex3.AsString()).AsString(), xml2.GenerateResKey());
					dbpf_0.AddEntry(xml2);
					List<ResKey> list = Class76.smethod_19(new ResKey(DBPFType.VPXY, resKey.GroupId, resKey.InstanceId, resKey.SecondInstanceId));
					foreach (ResKey resKey2 in list)
					{
						if (resKey2.Type == DBPFType.VPXY)
						{
							new ResKey(resKey2.AsString());
							VisualProxy visualProxy;
							if (dictionary_0.ContainsKey(resKey2.AsString()))
							{
								visualProxy = (dbpf_0.GetEntry(dictionary_0[resKey2.AsString()]) as VisualProxy);
							}
							else
							{
								visualProxy = (Class76.smethod_26(resKey2).Clone() as VisualProxy);
								visualProxy.InstanceID = xml2.InstanceID;
								visualProxy.SecondInstanceID = xml2.SecondInstanceID;
								if (!bool_1)
								{
									visualProxy.GroupID = (objd.GroupID | 1);
								}
								dbpf_0.AddEntry(visualProxy);
								dictionary_0.Add(resKey2.AsString(), visualProxy.GenerateResKey());
							}
							foreach (RCOLItem rcolitem in visualProxy.Entries)
							{
								VPXY vpxy = (VPXY)rcolitem;
								foreach (TGIIndex tgiindex4 in vpxy.TGIIndex)
								{
									try
									{
										if (dictionary_0.ContainsKey(tgiindex4.Reskey))
										{
											tgiindex4.Reskey = dictionary_0[tgiindex4.Reskey];
										}
										else
										{
											DBPFEntry dbpfentry4 = Class76.smethod_26(new ResKey(tgiindex4.Reskey));
											if (tgiindex4.Type == DBPFType.MLOD && tgiindex4.GroupId == 1)
											{
												tgiindex4.InstanceId = objd.InstanceID;
												tgiindex4.SecondInstanceId = objd.SecondInstanceID;
											}
											if (dbpfentry4 == null)
											{
												Console.WriteLine("Failed to clone " + tgiindex4 + ", reskey not found");
											}
											else
											{
												string reskey = tgiindex4.Reskey;
												DBPFEntry dbpfentry5 = (DBPFEntry)dbpfentry4.Clone();
												dbpfentry5.InstanceID = (tgiindex4.InstanceId = xml2.InstanceID);
												dbpfentry5.SecondInstanceID = (tgiindex4.SecondInstanceId = xml2.SecondInstanceID);
												if (!bool_1)
												{
													dbpfentry5.GroupID = (tgiindex4.GroupId = objd.GroupID);
												}
												if (dbpfentry5 is MODLModel)
												{
													MODLModel modlmodel = dbpfentry5 as MODLModel;
													dbpfentry5.InstanceID = (tgiindex4.InstanceId = xml2.InstanceID);
													dbpfentry5.SecondInstanceID = (tgiindex4.SecondInstanceId = xml2.SecondInstanceID);
													dbpfentry5.GroupID = (tgiindex4.GroupId = objd.GroupID);
													foreach (RCOLFileEntry rcolfileEntry in modlmodel.InternalResources)
													{
														if (rcolfileEntry.TypeID == RCOLItemType.MLOD)
														{
															rcolfileEntry.ResKey.InstanceId = random.Next();
															rcolfileEntry.ResKey.SecondInstanceId = random.Next();
															rcolfileEntry.ResKey.GroupId = 0;
														}
													}
												}
												dbpf_0.AddEntry(dbpfentry5);
												dictionary_0.Add(reskey, dbpfentry5.GenerateResKey());
												if (dbpfentry5 is RCOL)
												{
													Class26.smethod_1(dbpfentry5 as RCOL, dbpf_0, objd.GroupID, objd.InstanceID, objd.SecondInstanceID, ref dictionary_0, int_0, bool_1);
												}
											}
										}
									}
									catch (Exception ex)
									{
										Console.WriteLine("Failed to clone " + tgiindex4.AsString() + ", " + ex.Message);
									}
								}
							}
						}
					}
					tgiindex3.SetFromResKey(new ResKey(xml2.GenerateResKey()));
				}
			}
			for (byte b = 0; b < 23; b += 1)
			{
				int instanceId = (int)b << 24;
				List<ResKey> list2 = dbpf_0.SearchEntries(new ResKey(DBPFType.STBL, 0, instanceId, objd.SecondInstanceID));
				STBL stbl;
				if (list2.Count > 0)
				{
					stbl = (STBL)dbpf_0.GetEntry(list2[0]);
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

		// Token: 0x06000186 RID: 390 RVA: 0x00023C6C File Offset: 0x00021E6C
		private void method_11()
		{
			TGIIndex tgiindex = this.objd_0.TgiIndex[this.objd_0.BluePrintIndex];
			List<ResKey> list = Class132.mainForm.CurrentProject.Package.SearchEntries(new ResKey(DBPFType.VPXY, tgiindex.GroupId, tgiindex.InstanceId, tgiindex.SecondInstanceId));
			foreach (ResKey key in list)
			{
				VisualProxy visualProxy = Class132.mainForm.CurrentProject.Package.GetEntry(key) as VisualProxy;
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
									ResKey key2 = new ResKey(tgiindex2.Reskey);
									MODLModel modlmodel_ = Class132.mainForm.CurrentProject.Package.GetEntry(key2) as MODLModel;
									this.method_13(Class140.smethod_0().Device, modlmodel_, vpxy);
								}
								else if (tgiindex2.Type == (DBPFType)3548561239U)
								{
									ResKey key3 = new ResKey(tgiindex2.Reskey);
									FTPTResource ftptresource = Class132.mainForm.CurrentProject.Package.GetEntry(key3) as FTPTResource;
									if (ftptresource != null)
									{
										foreach (RCOLItem rcolitem2 in ftptresource.Entries)
										{
											FTPT ftpt = (FTPT)rcolitem2;
											foreach (FTPT.FootprintEntry footprintEntry_ in ftpt.FootprintEntries)
											{
												this.method_12(Class140.smethod_0().Device, ftpt, footprintEntry_);
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

		// Token: 0x06000187 RID: 391 RVA: 0x00023F88 File Offset: 0x00022188
		private void method_12(Device device_0, FTPT ftpt_0, FTPT.FootprintEntry footprintEntry_0)
		{
			Class129 item = new Class129(device_0, ftpt_0, footprintEntry_0);
			this.class103_0.Footprints.Add(item);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00023FB4 File Offset: 0x000221B4
		private void method_13(Device device_0, MODLModel modlmodel_0, VPXY vpxy_0)
		{
			if (modlmodel_0 != null)
			{
				this.list_1.Add(modlmodel_0);
				foreach (RCOLItem rcolitem in modlmodel_0.Entries)
				{
					if (rcolitem.GetType().Equals(typeof(MODL)))
					{
						MODL modl = rcolitem as MODL;
						foreach (MODL.MODLEntry modlentry in modl.Entries)
						{
							if (!this.list_0.Contains((Lod)modlentry.LOD))
							{
								this.list_0.Add((Lod)modlentry.LOD);
							}
							if (modlentry.IndexType == 12288)
							{
								RCOLFileEntry rcolfileEntry = modlmodel_0.ExternalResources[modlentry.Index - 1];
								RCOL rcol = Class132.mainForm.CurrentProject.Package.GetEntry(rcolfileEntry.ResKey) as RCOL;
								this.method_14(modlentry, modlmodel_0, rcol.Entries[0] as MLOD, (Lod)modlentry.LOD, device_0);
							}
							else if (modlentry.IndexType == 4096)
							{
								MLOD mlod_ = modlmodel_0.Entries[modlentry.Index] as MLOD;
								this.method_14(modlentry, modlmodel_0, mlod_, (Lod)modlentry.LOD, device_0);
							}
							else
							{
								MLOD mlod_2 = modlmodel_0.Entries[modlentry.Index - 1] as MLOD;
								this.method_14(modlentry, modlmodel_0, mlod_2, (Lod)modlentry.LOD, device_0);
							}
							Class3.Class24 class22_ = new Class3.Class24(modl, modlmodel_0, modlentry, vpxy_0);
							this.blueprintModelControl_0.MLODPropertyGrid.method_9(class22_);
						}
					}
				}
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000241A4 File Offset: 0x000223A4
		private void method_14(MODL.MODLEntry modlentry_0, RCOL rcol_0, MLOD mlod_0, Lod lod_0, Device device_0)
		{
			foreach (MLOD.MLODEntry mlodentry in mlod_0.Entries)
			{
				Class121 value = new Class121(device_0, lod_0, mlod_0, mlodentry);
				this.class103_0.Objects.Add(mlodentry, value);
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00024214 File Offset: 0x00022414
		public void method_15()
		{
			MLOD mlod = null;
			using (Dictionary<MLOD.MLODEntry, Interface9>.ValueCollection.Enumerator enumerator = this.class103_0.Objects.Values.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					Class121 @class = (Class121)enumerator.Current;
					mlod = @class.MLODEntry.Parent;
				}
			}
			MODLModel modlmodel = mlod.Parent.Clone() as MODLModel;
			MODL modl = modlmodel.Entries[0] as MODL;
			MLOD mlod2 = modlmodel.Entries[modl.Entries[0].Index] as MLOD;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			List<RCOLItem> list = new List<RCOLItem>();
			for (int i = 0; i < modlmodel.Entries.Count; i++)
			{
				RCOLItem rcolitem = modlmodel.Entries[i];
				if (rcolitem is VBUF)
				{
					num = i;
				}
				if (rcolitem is IBUF)
				{
					num2 = i;
				}
				if (rcolitem is VRTF)
				{
					num3 = i;
				}
				if (rcolitem is MATD)
				{
					list.Add(rcolitem);
				}
			}
			VBUF vbuf = modlmodel.Entries[num] as VBUF;
			IBUF ibuf = modlmodel.Entries[num2] as IBUF;
			RCOLItem rcolitem2 = modlmodel.Entries[num3];
			foreach (RCOLItem item in list)
			{
				modlmodel.RemoveEntry(item);
			}
			mlod2.Entries.Clear();
			int num4 = 0;
			int num5 = 0;
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
			float num6 = 0.085f;
			float[] array = new float[]
			{
				float.MaxValue,
				float.MaxValue,
				float.MaxValue,
				float.MinValue,
				float.MinValue,
				float.MinValue
			};
			foreach (Class131 class2 in this.class103_0.list_10)
			{
				Vector3 vector3_ = Vector3.TransformCoordinate(new Vector3(1f, 0.02f, -num6), class2.RotationMatrix * class2.TranslationMatrix);
				this.method_16(VertexEntryType.Short4, vector3_, binaryWriter);
				binaryWriter.Write(0f);
				binaryWriter.Write(0f);
				binaryWriter2.Write((short)num4);
				num4++;
				Vector3 vector3_2 = Vector3.TransformCoordinate(new Vector3(0f, 0.02f, -num6), class2.RotationMatrix * class2.TranslationMatrix);
				this.method_16(VertexEntryType.Short4, vector3_2, binaryWriter);
				binaryWriter.Write(1f);
				binaryWriter.Write(0f);
				binaryWriter2.Write((short)num4);
				num4++;
				Vector3 vector3_3 = Vector3.TransformCoordinate(new Vector3(0f, 0.02f, num6), class2.RotationMatrix * class2.TranslationMatrix);
				this.method_16(VertexEntryType.Short4, vector3_3, binaryWriter);
				binaryWriter.Write(1f);
				binaryWriter.Write(0.15f);
				binaryWriter2.Write((short)num4);
				num4++;
				Vector3 vector3_4 = Vector3.TransformCoordinate(new Vector3(1f, 0.02f, -num6), class2.RotationMatrix * class2.TranslationMatrix);
				this.method_16(VertexEntryType.Short4, vector3_4, binaryWriter);
				binaryWriter.Write(0f);
				binaryWriter.Write(0f);
				binaryWriter2.Write((short)num4);
				num4++;
				Vector3 vector3_5 = Vector3.TransformCoordinate(new Vector3(0f, 0.02f, num6), class2.RotationMatrix * class2.TranslationMatrix);
				this.method_16(VertexEntryType.Short4, vector3_5, binaryWriter);
				binaryWriter.Write(1f);
				binaryWriter.Write(0.15f);
				binaryWriter2.Write((short)num4);
				num4++;
				Vector3 vector3_6 = Vector3.TransformCoordinate(new Vector3(1f, 0.02f, num6), class2.RotationMatrix * class2.TranslationMatrix);
				this.method_16(VertexEntryType.Short4, vector3_6, binaryWriter);
				binaryWriter.Write(0f);
				binaryWriter.Write(0.15f);
				binaryWriter2.Write((short)num4);
				num4++;
				num5 += 2;
				array[0] = Math.Min(array[0], Math.Min(vector3_.X, Math.Min(vector3_2.X, Math.Min(vector3_3.X, Math.Min(vector3_4.X, Math.Min(vector3_5.X, vector3_6.X))))));
				array[1] = Math.Min(array[1], Math.Min(vector3_.Y, Math.Min(vector3_2.Y, Math.Min(vector3_3.Y, Math.Min(vector3_4.Y, Math.Min(vector3_5.Y, vector3_6.Y))))));
				array[2] = Math.Min(array[2], Math.Min(vector3_.Z, Math.Min(vector3_2.Z, Math.Min(vector3_3.Z, Math.Min(vector3_4.Z, Math.Min(vector3_5.Z, vector3_6.Z))))));
				array[3] = Math.Max(array[3], Math.Max(vector3_.X, Math.Max(vector3_2.X, Math.Max(vector3_3.X, Math.Max(vector3_4.X, Math.Max(vector3_5.X, vector3_6.X))))));
				array[4] = Math.Max(array[4], Math.Max(vector3_.Y, Math.Max(vector3_2.Y, Math.Max(vector3_3.Y, Math.Max(vector3_4.Y, Math.Max(vector3_5.Y, vector3_6.Y))))));
				array[5] = Math.Max(array[5], Math.Max(vector3_.Z, Math.Max(vector3_2.Z, Math.Max(vector3_3.Z, Math.Max(vector3_4.Z, Math.Max(vector3_5.Z, vector3_6.Z))))));
			}
			MLOD.MLODEntry mlodentry = new MLOD.MLODEntry(mlod2);
			mlodentry.VBUFIndex = num;
			mlodentry.IBUFIndex = num2;
			mlodentry.VRTFIndex = num3;
			mlodentry.FaceCount = num5;
			mlodentry.VertexCount = num4;
			mlodentry.PrimitiveType = MLOD.PrimitiveType.TriangleList;
			mlodentry.MeshFlags = MLOD.MeshFlags.Pickable;
			mlodentry.MATDIndex = modlmodel.AddEntry(RCOLItemType.MATD, MATD.CreateMatdForFloor(modlmodel));
			mlodentry.BoundingBox[0] = array[0];
			mlodentry.BoundingBox[1] = array[1];
			mlodentry.BoundingBox[2] = array[2];
			mlodentry.BoundingBox[3] = array[3];
			mlodentry.BoundingBox[4] = array[4];
			mlodentry.BoundingBox[5] = array[5];
			mlod2.Entries.Add(mlodentry);
			vbuf.Buffer = memoryStream.ToArray();
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(memoryStream2.ToArray()));
			ibuf.Index = new short[num5 * 3];
			for (int j = 0; j < num5 * 3; j++)
			{
				ibuf.Index[j] = binaryReader.ReadInt16();
			}
			mlod.Parent.SetData(modlmodel.Serialize());
			Class132.mainForm.CurrentProject.Package.AddEntry(mlod.Parent);
			this.class103_0.Footprints.Clear();
			this.class103_0.Objects.Clear();
			this.list_1.Clear();
			this.method_11();
			this.method_4();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000249F8 File Offset: 0x00022BF8
		private void method_16(VertexEntryType vertexEntryType_0, Vector3 vector3_2, BinaryWriter binaryWriter_0)
		{
			if (vertexEntryType_0 == VertexEntryType.Short4)
			{
				float num = vector3_2.X;
				float num2 = vector3_2.Y;
				float num3 = vector3_2.Z;
				float num4 = 32767f;
				float num5 = Math.Max(Math.Max(Math.Abs(num), Math.Abs(num2)), Math.Abs(num3));
				if (num5 > 1f)
				{
					num4 = (float)(32767 / (int)Math.Ceiling((double)num5));
				}
				num = num4 * num;
				num2 = num4 * num2;
				num3 = num4 * num3;
				binaryWriter_0.Write((short)num);
				binaryWriter_0.Write((short)num2);
				binaryWriter_0.Write((short)num3);
				binaryWriter_0.Write((short)num4);
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00024A98 File Offset: 0x00022C98
		private VisualProxy method_17(OBJK objk_0)
		{
			OBJK.KeyEntry keyEntry = objk_0.GetKeyEntry("modelKey");
			TGIIndex tgiindex = objk_0.TGIIndex[keyEntry.TgiIndex];
			return Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.Reskey)) as VisualProxy;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00024AF0 File Offset: 0x00022CF0
		private OBJK method_18()
		{
			return Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(this.objd_0.OBJK.Reskey)) as OBJK;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00024B30 File Offset: 0x00022D30
		public object GetThumbnail()
		{
			Bitmap bitmap = Class132.smethod_0().method_19(this.class103_0, null, new Size(256, 256)) as Bitmap;
			Bitmap bitmap2 = new Bitmap(256, 256);
			Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.DrawImage(bitmap, new Rectangle(18, 18, 222, 222), 0, 0, 256, 256, GraphicsUnit.Pixel);
			bitmap.Dispose();
			return bitmap2;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00024BAC File Offset: 0x00022DAC
		public string GetTitle()
		{
			return "";
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00024BAC File Offset: 0x00022DAC
		public string GetDescription()
		{
			return "";
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00002A71 File Offset: 0x00000C71
		public void LodChanged(Lod lod_0)
		{
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00024BC4 File Offset: 0x00022DC4
		public List<Lod> GetLodLevels()
		{
			return new List<Lod>(this.list_0);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool HasSlots()
		{
			return false;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool HasShadows()
		{
			return false;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool HasBumpMap()
		{
			return false;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool HasRig()
		{
			return false;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00002A71 File Offset: 0x00000C71
		public void SetSlotsVisible(bool bool_1)
		{
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00002A71 File Offset: 0x00000C71
		public void SetRigVisible(bool bool_1)
		{
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00024BF4 File Offset: 0x00022DF4
		public object GetRenderable()
		{
			return this.class103_0;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00024C0C File Offset: 0x00022E0C
		public IWorkshopProject GetCurrentProject()
		{
			return this.project;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00024C24 File Offset: 0x00022E24
		public List<object> GetModels()
		{
			return this.list_1;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00024C3C File Offset: 0x00022E3C
		public List<object> GetGameObjects()
		{
			return null;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00024C50 File Offset: 0x00022E50
		public object GetCurrentGameObject()
		{
			return null;
		}

		// Token: 0x04000139 RID: 313
		private WorkshopProject project;

		// Token: 0x0400013A RID: 314
		private Class103 class103_0;

		// Token: 0x0400013B RID: 315
		private List<Lod> list_0;

		// Token: 0x0400013C RID: 316
		private string string_0;

		// Token: 0x0400013D RID: 317
		private string string_1;

		// Token: 0x0400013E RID: 318
		private PackageDescriptor packageDescriptor_0;

		// Token: 0x0400013F RID: 319
		private OBJD objd_0;

		// Token: 0x04000140 RID: 320
		private BlueprintModelControl blueprintModelControl_0;

		// Token: 0x04000141 RID: 321
		private Class129 class129_0;

		// Token: 0x04000142 RID: 322
		private List<object> list_1;

		// Token: 0x04000143 RID: 323
		private bool bool_0;

		// Token: 0x04000144 RID: 324
		private Class115 class115_0;

		// Token: 0x04000145 RID: 325
		private Vector3 vector3_0 = Vector3.Zero;

		// Token: 0x04000146 RID: 326
		private Vector3 vector3_1 = Vector3.Zero;

		// Token: 0x04000147 RID: 327
		private double double_0;

		// Token: 0x04000148 RID: 328
		[CompilerGenerated]
		private Image image_0;

		// Token: 0x04000149 RID: 329
		[CompilerGenerated]
		private Image image_1;
	}
}
