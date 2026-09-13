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
using ns16;
using ns17;
using ns21;
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
using Sims3Workshop.Data;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;
using VisualHint.SmartPropertyGrid;

namespace ns18
{
	// Token: 0x020000A4 RID: 164
	internal sealed class Class68 : IProjectModel
	{
		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x000601E0 File Offset: 0x0005E3E0
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x00005384 File Offset: 0x00003584
		public Class104 Renderable { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x000601F8 File Offset: 0x0005E3F8
		public CASP Casp
		{
			get
			{
				return this.casp_0;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x00060210 File Offset: 0x0005E410
		// (set) Token: 0x0600064B RID: 1611 RVA: 0x0006022C File Offset: 0x0005E42C
		[PropertyFeel("button")]
		public string Title
		{
			get
			{
				return this.packageDescriptor_0.Title;
			}
			set
			{
				string text = value;
				if (text.Length > 240)
				{
					text = text.Substring(0, 240);
				}
				this.packageDescriptor_0.Title = StringHelpers.XmlValue(text);
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x00060268 File Offset: 0x0005E468
		// (set) Token: 0x0600064D RID: 1613 RVA: 0x0000538F File Offset: 0x0000358F
		public Image LauncherThumbnail
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x00060280 File Offset: 0x0005E480
		// (set) Token: 0x0600064F RID: 1615 RVA: 0x0000539A File Offset: 0x0000359A
		public string BottomPart
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000650 RID: 1616 RVA: 0x00060298 File Offset: 0x0005E498
		// (set) Token: 0x06000651 RID: 1617 RVA: 0x000053A5 File Offset: 0x000035A5
		public string TopPart
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x000602B0 File Offset: 0x0005E4B0
		// (set) Token: 0x06000653 RID: 1619 RVA: 0x000053B0 File Offset: 0x000035B0
		public string ShoesPart
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x000602C8 File Offset: 0x0005E4C8
		// (set) Token: 0x06000655 RID: 1621 RVA: 0x000053BB File Offset: 0x000035BB
		public string Filename
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
				this.casp_0.str1 = this.string_3;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000656 RID: 1622 RVA: 0x000602E0 File Offset: 0x0005E4E0
		// (set) Token: 0x06000657 RID: 1623 RVA: 0x000053D7 File Offset: 0x000035D7
		public string Filename2
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
				this.casp_0.str2 = this.string_4;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000658 RID: 1624 RVA: 0x000602F8 File Offset: 0x0005E4F8
		// (set) Token: 0x06000659 RID: 1625 RVA: 0x000053F3 File Offset: 0x000035F3
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
		public Age Age { get; set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600065A RID: 1626 RVA: 0x00060310 File Offset: 0x0005E510
		// (set) Token: 0x0600065B RID: 1627 RVA: 0x000053FE File Offset: 0x000035FE
		[PropertyFeel("radiobutton")]
		[PropertyLook(typeof(PropertyRadioButtonLook))]
		public CASP.ClothingType ClothingType { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600065C RID: 1628 RVA: 0x00060328 File Offset: 0x0005E528
		// (set) Token: 0x0600065D RID: 1629 RVA: 0x00005409 File Offset: 0x00003609
		[PropertyLook(typeof(PropertyRadioButtonLook))]
		[PropertyFeel("radiobutton")]
		public CASP.Type Type { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x00060340 File Offset: 0x0005E540
		// (set) Token: 0x0600065F RID: 1631 RVA: 0x00005414 File Offset: 0x00003614
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
		public CASP.ClothingCategory Category { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x00060358 File Offset: 0x0005E558
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x0000541F File Offset: 0x0000361F
		[PropertyFeel("checkbox")]
		[PropertyLook(typeof(PropertyCheckboxLook))]
		public Gender Gender { get; set; }

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x00060370 File Offset: 0x0005E570
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x0000542A File Offset: 0x0000362A
		[PropertyLook(typeof(PropertyRadioButtonLook))]
		[PropertyFeel("radiobutton")]
		public Enum12 Species { get; set; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x00060388 File Offset: 0x0005E588
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x00005435 File Offset: 0x00003635
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
		public Enum11 Handedness { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x000603A0 File Offset: 0x0005E5A0
		public CaspModelControl Control
		{
			get
			{
				return this.caspModelControl_0;
			}
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x000603B8 File Offset: 0x0005E5B8
		public Class68(WorkshopProject project)
		{
			this.project = project;
			this.lod_0 = Class132.mainForm.GetCurrentLOD();
			this.list_0 = new List<Lod>();
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("launcherThumbnail"))
			{
				string key = this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["launcherThumbnail"];
				PNG png = this.project.Package.GetEntry(new ResKey(key)) as PNG;
				this.image_0 = png.Image;
			}
			this.caspModelControl_0 = new CaspModelControl(this)
			{
				Parent = Class132.mainForm.ProjectPanel,
				Dock = DockStyle.Fill
			};
			this.caspModelControl_0.method_0(false);
			this.caspModelControl_0.PresetPropertyGrid.OnPresetChanged += this.method_10;
			List<ResKey> list = this.project.Package.SearchEntries(new ResKey(DBPFType.CASP));
			if (list.Count != 1)
			{
				throw new Exception("The project format is invalid, expected to find 1 CASP, found " + list.Count);
			}
			this.casp_0 = (this.project.Package.GetEntry(list[0]) as CASP);
			List<ResKey> list2 = this.project.Package.SearchEntries(new ResKey(DBPFType.PACKDESC));
			if (list2.Count == 0)
			{
				this.packageDescriptor_0 = new PackageDescriptor();
				this.packageDescriptor_0.Manifest.Add("version", 3);
				this.packageDescriptor_0.Manifest.Add("packagetype", "CASpart");
				this.packageDescriptor_0.Manifest.Add("paidcontent", "false");
				this.Title = "new cas project";
				project.Package.AddEntry(this.packageDescriptor_0);
			}
			else
			{
				this.packageDescriptor_0 = (this.project.Package.GetEntry(list2[0]) as PackageDescriptor);
			}
			Control threeChannelsRadio = this.caspModelControl_0.threeChannelsRadio;
			this.caspModelControl_0.fourChannelsRadio.Enabled = false;
			threeChannelsRadio.Enabled = false;
			VisualHint.SmartPropertyGrid.PropertyGrid meshPropertyGrid = this.caspModelControl_0.MeshPropertyGrid;
			meshPropertyGrid.PropertyChanged += this.method_17;
			meshPropertyGrid.PropertySelected += this.method_8;
			meshPropertyGrid.PropertyButtonClicked += this.method_19;
			meshPropertyGrid.PropertyChanged += this.method_7;
			meshPropertyGrid.DisableModeGrayedOut = true;
			this.method_9();
			this.method_20(this.casp_0);
			this.caspModelControl_0.exportToolStripMenuItem.Click += this.method_11;
			this.caspModelControl_0.PresetComboBox.SelectedIndexChanged += this.method_14;
			this.caspModelControl_0.PresetPropertyGrid.PropertyChanged += this.method_22;
			this.caspModelControl_0.AdvancedMode.CheckedChanged += this.method_12;
			this.caspModelControl_0.meshgroupCombo.SelectedIndexChanged += this.method_6;
			this.caspModelControl_0.exportMeshgroupButton.Click += this.method_5;
			this.caspModelControl_0.importMeshgroupButton.Click += this.method_3;
			this.caspModelControl_0.MeshPropertyGrid.PropertySelected += this.method_1;
			this.caspModelControl_0.CaspPropertyGrid.PropertyButtonClicked += this.method_0;
			if (this.caspModelControl_0.PresetComboBox.Items.Count > 0)
			{
				this.caspModelControl_0.PresetComboBox.SelectedIndex = 0;
			}
			this.caspModelControl_0.threeChannelsRadio.CheckedChanged += this.method_2;
			this.caspModelControl_0.fourChannelsRadio.CheckedChanged += this.method_2;
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x000607B4 File Offset: 0x0005E9B4
		private void method_0(object sender, PropertyButtonClickedEventArgs e)
		{
			if (e.PropertyEnum.Property != null && e.PropertyEnum.Property.DisplayName == "Title")
			{
				StblEditor stblEditor = new StblEditor(this.project, "Title", this.Title);
				if (stblEditor.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					this.Title = stblEditor.text;
					e.PropertyEnum.Property.Value.SetValue(stblEditor.text);
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				}
			}
			else if (e.PropertyEnum.Property != null && e.PropertyEnum.Property.Tag.Equals("bottomPart"))
			{
				CASPartSelector caspartSelector = new CASPartSelector(this.Renderable.PossibleBottoms);
				if (caspartSelector.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					ResKey reskey = caspartSelector.Reskey;
					this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["bottomPart"] = reskey.AsString();
					this.Renderable.imethod_7(Class140.smethod_0().Device);
					this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
				}
			}
			else if (e.PropertyEnum.Property != null && e.PropertyEnum.Property.Tag.Equals("topPart"))
			{
				CASPartSelector caspartSelector2 = new CASPartSelector(this.Renderable.PossibleTops);
				if (caspartSelector2.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					ResKey reskey2 = caspartSelector2.Reskey;
					this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["topPart"] = reskey2.AsString();
					this.Renderable.imethod_7(Class140.smethod_0().Device);
					this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
				}
			}
			else if (e.PropertyEnum.Property != null && e.PropertyEnum.Property.Tag.Equals("shoesPart"))
			{
				CASPartSelector caspartSelector3 = new CASPartSelector(this.Renderable.PossibleShoes);
				if (caspartSelector3.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					ResKey reskey3 = caspartSelector3.Reskey;
					this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["shoesPart"] = reskey3.AsString();
					this.Renderable.imethod_7(Class140.smethod_0().Device);
					this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
				}
			}
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00060A34 File Offset: 0x0005EC34
		private void method_1(object sender, PropertySelectedEventArgs e)
		{
			if (this.class109_0 != null)
			{
				this.class109_0.Selected = false;
			}
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag is GEOM)
			{
				object tag = e.PropertyEnum.Property.Value.Tag;
				foreach (Class104.Class110 @class in this.Renderable.Containers)
				{
					foreach (Class104.Class109 class2 in @class.Items)
					{
						GEOM geom = class2.Geom;
						class2.Selected = tag.Equals(geom);
						if (tag.Equals(geom))
						{
							this.class109_0 = class2;
						}
					}
				}
			}
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x00060B48 File Offset: 0x0005ED48
		private void method_2(object sender, EventArgs e)
		{
			int num = this.caspModelControl_0.threeChannelsRadio.Checked ? 3 : (this.caspModelControl_0.fourChannelsRadio.Checked ? 4 : 0);
			foreach (XmlDocument xmlDocument in this.casp_0.documents)
			{
				XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/preset/complate/pattern");
				int num2 = 0;
				foreach (object obj in xmlNodeList)
				{
					XmlElement xmlElement = (XmlElement)obj;
					if (xmlElement.GetAttribute("variable").ToLower().Contains("pattern ".ToLower()))
					{
						num2++;
					}
				}
				this.caspModelControl_0.threeChannelsRadio.Enabled = (this.caspModelControl_0.fourChannelsRadio.Enabled = (num2 > 0));
				string text = "key:0333406C:00000000:E37696463F6B2D6E";
				string text2 = "key:0333406C:00000000:52E8BE209C703561";
				string text3 = "CasRgbaMask";
				string text4 = "CasRgbMask";
				switch (this.project.Type)
				{
				case Sims3Workshop.Data.ProjectType.HAIR:
					text3 = "HairUniversal";
					text = "key:0333406C:00000000:70F0C0F9CB4A79E0";
					if (num2 > 0)
					{
						this.caspModelControl_0.threeChannelsRadio.Enabled = false;
					}
					break;
				case Sims3Workshop.Data.ProjectType.ACCESSORY:
					if (this.casp_0.clothingType == 12U)
					{
						text3 = "Glasses";
						text4 = "Glasses";
						text = "key:0333406C:00000000:4FDFCA2116D2088B";
						text2 = "key:0333406C:00000000:4FDFCA2116D2088B";
						this.caspModelControl_0.fourChannelsRadio.Enabled = false;
					}
					break;
				}
				if (num2 != num && num != 0)
				{
					if (num2 == 3 && num == 4)
					{
						string attribute = (xmlDocument.SelectSingleNode("/preset/complate") as XmlElement).GetAttribute("reskey");
						if (!attribute.ToLower().Equals(text2.ToLower()) && MessageBox.Show(null, "This CAS doesn´t use the standard complate, do you still want to change the number of channels?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
						{
							return;
						}
					}
					if (num2 == 4 && num == 3)
					{
						string attribute2 = (xmlDocument.SelectSingleNode("/preset/complate") as XmlElement).GetAttribute("reskey");
						if (!attribute2.ToLower().Equals(text.ToLower()) && MessageBox.Show(null, "This CAS doesn´t use the standard complate, do you still want to change the number of channels?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
						{
							return;
						}
					}
					string text5 = (num == 4) ? text : ((num == 3) ? text2 : null);
					if (text5 != null)
					{
						string attribute3 = (xmlDocument.SelectSingleNode("/preset/complate") as XmlElement).GetAttribute("reskey");
						foreach (IGTIndex igtindex in this.casp_0.igtIndex)
						{
							if (igtindex.Reskey.ToLower().Equals(attribute3.ToLower()))
							{
								igtindex.Reskey = text5;
							}
						}
						if (this.casp_0.hasDiffuse == 1)
						{
							IGTIndex igtindex2 = this.casp_0.igtIndex[(int)this.casp_0.diffuseIndex];
							if (igtindex2.IsType(DBPFType.TXTC))
							{
								Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(igtindex2.AsString()));
							}
						}
						(xmlDocument.SelectSingleNode("/preset/complate") as XmlElement).SetAttribute("reskey", text5);
						(xmlDocument.SelectSingleNode("/preset/complate") as XmlElement).SetAttribute("name", (num == 4) ? text3 : text4);
						if (num2 == 4 && num == 3)
						{
							for (int i = xmlNodeList.Count - 1; i >= 0; i--)
							{
								XmlElement xmlElement2 = xmlNodeList[i] as XmlElement;
								if (xmlElement2.GetAttribute("variable").ToLower().Contains("pattern ".ToLower()))
								{
									XmlNodeList xmlNodeList2 = xmlDocument.SelectNodes("/preset/complate/value");
									foreach (object obj2 in xmlNodeList2)
									{
										XmlElement xmlElement3 = (XmlElement)obj2;
										if (xmlElement3.GetAttribute("key").ToLower().Contains(xmlElement2.GetAttribute("variable").ToLower()))
										{
											xmlDocument.SelectSingleNode("/preset/complate").RemoveChild(xmlElement3);
										}
									}
									xmlDocument.SelectSingleNode("/preset/complate").RemoveChild(xmlElement2);
									break;
								}
							}
						}
						else if (num2 == 3 && num == 4)
						{
							for (int j = xmlNodeList.Count - 1; j >= 0; j--)
							{
								XmlElement xmlElement4 = xmlNodeList[j] as XmlElement;
								if (xmlElement4.GetAttribute("variable").ToLower().Contains("pattern ".ToLower()))
								{
									XmlElement xmlElement5 = xmlElement4.Clone() as XmlElement;
									xmlElement5.SetAttribute("variable", "Pattern D");
									xmlDocument.SelectSingleNode("/preset/complate").AppendChild(xmlElement5);
									XmlNodeList xmlNodeList3 = xmlDocument.SelectNodes("/preset/complate/value");
									foreach (object obj3 in xmlNodeList3)
									{
										XmlElement xmlElement6 = (XmlElement)obj3;
										if (xmlElement6.GetAttribute("key").ToLower().Contains(xmlElement4.GetAttribute("variable").ToLower()))
										{
											XmlElement xmlElement7 = xmlElement6.Clone() as XmlElement;
											xmlElement7.SetAttribute("key", xmlElement7.GetAttribute("key").Replace(xmlElement4.GetAttribute("variable"), xmlElement5.GetAttribute("variable")));
											xmlDocument.SelectSingleNode("/preset/complate").AppendChild(xmlElement7);
										}
									}
									break;
								}
							}
						}
					}
				}
			}
			this.method_15();
			this.method_23();
			Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x000611C4 File Offset: 0x0005F3C4
		private void method_3(object sender, EventArgs e)
		{
			if (this.caspModelControl_0.meshgroupCombo.SelectedIndex != -1)
			{
				Class67 @class = this.caspModelControl_0.meshgroupCombo.SelectedItem as Class67;
				int selectedIndex = this.caspModelControl_0.meshgroupCombo.SelectedIndex;
				bool flag = false;
				bool flag2 = false;
				foreach (int index in @class.Entry.index)
				{
					TGIIndex tgiindex = @class.VPXY.TGIIndex[index];
					Geometry geometry = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.Reskey)) as Geometry;
					foreach (RCOLItem rcolitem in geometry.Entries)
					{
						GEOM geom = (GEOM)rcolitem;
						if (geom.HasMorphData)
						{
							flag2 = true;
						}
						bool hasTangentData = geom.HasTangentData;
					}
				}
				List<IFileImportPlugin> fileImportPluginsForType = Class132.mainForm.GetFileImportPluginsForType(DBPFType.GEOM);
				string text = "";
				List<ICASPImport> list = new List<ICASPImport>();
				foreach (IFileImportPlugin fileImportPlugin in fileImportPluginsForType)
				{
					if (fileImportPlugin is ICASPImport)
					{
						string text2 = text;
						text = string.Concat(new string[]
						{
							text2,
							(text != "") ? "|" : "",
							fileImportPlugin.GetExtensionNameForType(DBPFType.GEOM),
							"(*.",
							fileImportPlugin.GetExtensionForType(DBPFType.GEOM),
							")|*.",
							fileImportPlugin.GetExtensionForType(DBPFType.GEOM)
						});
						list.Add(fileImportPlugin as ICASPImport);
					}
				}
				int startVertexId = 0;
				if (this.casp_0.clothingType == 5U)
				{
					startVertexId = 5000;
				}
				else if (this.casp_0.clothingType == 6U)
				{
					startVertexId = 15000;
				}
				else if (this.casp_0.clothingType == 1U)
				{
					startVertexId = 20000;
				}
				else if (this.casp_0.clothingType == 7U)
				{
					startVertexId = 30000;
				}
				else
				{
					if (this.casp_0.clothingType != 32U && this.casp_0.clothingType != 24U && this.casp_0.clothingType != 15U && this.casp_0.clothingType != 14U)
					{
						if (this.casp_0.clothingType != 13U)
						{
							if (this.casp_0.clothingType == 9U)
							{
								startVertexId = 31850;
								goto IL_2FC;
							}
							if (this.casp_0.clothingType == 16U)
							{
								startVertexId = 3000;
								goto IL_2FC;
							}
							if (this.casp_0.clothingType == 3U)
							{
								startVertexId = 0;
								goto IL_2FC;
							}
							startVertexId = 5000;
							goto IL_2FC;
						}
					}
					startVertexId = 32300;
				}
				IL_2FC:
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = text;
				if (flag2)
				{
					if (@class.Entry.index.Count > 1 && flag2)
					{
						MultiPartCaspFilePicker multiPartCaspFilePicker = new MultiPartCaspFilePicker(openFileDialog.Filter, @class.VPXY, @class.Entry, true);
						if (multiPartCaspFilePicker.ShowDialog(Class132.mainForm) == DialogResult.OK)
						{
							foreach (int num in @class.Entry.index)
							{
								MultiPartCaspFilePicker.Class95 class2 = multiPartCaspFilePicker.Parts[num];
								string fileName = class2.FileName;
								if (File.Exists(fileName) && class2.Checked)
								{
									TGIIndex tgiindex2 = @class.VPXY.TGIIndex[num];
									Geometry geometry2 = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex2.Reskey)) as Geometry;
									foreach (RCOLItem rcolitem2 in geometry2.Entries)
									{
										GEOM geom2 = (GEOM)rcolitem2;
										if (list[class2.FilterIndex - 1].ImportGeom(fileName, this.casp_0, geom2, (Lod)@class.Entry.msIndex, startVertexId) == PluginResult.FAIL)
										{
											MessageBox.Show(Class132.mainForm, "Import failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
											goto IL_60A;
										}
									}
								}
							}
							flag = true;
							goto IL_611;
						}
						goto IL_611;
					}
					else
					{
						if (openFileDialog.ShowDialog(Class132.mainForm) == DialogResult.OK)
						{
							foreach (int index2 in @class.Entry.index)
							{
								string fileName2 = openFileDialog.FileName;
								TGIIndex tgiindex3 = @class.VPXY.TGIIndex[index2];
								Geometry geometry3 = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex3.Reskey)) as Geometry;
								foreach (RCOLItem rcolitem3 in geometry3.Entries)
								{
									GEOM geom3 = (GEOM)rcolitem3;
									if (list[openFileDialog.FilterIndex - 1].ImportGeom(fileName2, this.casp_0, geom3, (Lod)@class.Entry.msIndex, startVertexId) == PluginResult.FAIL)
									{
										MessageBox.Show(Class132.mainForm, "Import failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										goto IL_60A;
									}
								}
							}
							flag = true;
							goto IL_611;
						}
						goto IL_611;
					}
				}
				else
				{
					if (openFileDialog.ShowDialog(Class132.mainForm) != DialogResult.OK)
					{
						goto IL_611;
					}
					string fileName3 = openFileDialog.FileName;
					if (list[openFileDialog.FilterIndex - 1].ImportCASP(fileName3, this.casp_0, @class.VPXY, @class.Entry, (Lod)@class.Entry.msIndex) != PluginResult.FAIL)
					{
						flag = true;
						goto IL_611;
					}
					MessageBox.Show(Class132.mainForm, "Import failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				IL_60A:
				return;
				IL_611:
				if (flag)
				{
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
					if (MessageBox.Show(Class132.mainForm, "You have imported a new mesh, do you want to update the bounding box values automatically?", "Bounding box", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Vector3[] array = new Vector3[2];
						Vector3[] array2 = array;
						int num2 = 0;
						Vector3[] array3 = array;
						int num3 = 0;
						Vector3[] array4 = array;
						int num4 = 0;
						float maxValue = float.MaxValue;
						float maxValue2 = float.MaxValue;
						array4[num4].Z = maxValue;
						float y = maxValue2;
						float maxValue3 = float.MaxValue;
						array3[num3].Y = y;
						array2[num2].X = maxValue3;
						Vector3[] array5 = array;
						int num5 = 1;
						Vector3[] array6 = array;
						int num6 = 1;
						Vector3[] array7 = array;
						int num7 = 1;
						float minValue = float.MinValue;
						float minValue2 = float.MinValue;
						array7[num7].Z = minValue;
						float y2 = minValue2;
						float minValue3 = float.MinValue;
						array6[num6].Y = y2;
						array5[num5].X = minValue3;
						foreach (int index3 in @class.Entry.index)
						{
							TGIIndex tgiindex4 = @class.VPXY.TGIIndex[index3];
							Geometry geometry4 = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex4.Reskey)) as Geometry;
							foreach (RCOLItem rcolitem4 in geometry4.Entries)
							{
								GEOM geom4 = (GEOM)rcolitem4;
								foreach (GEOM.GEOMVertex geomvertex in geom4.vertices)
								{
									array[0].X = Math.Min(array[0].X, geomvertex.posX);
									array[0].Y = Math.Min(array[0].Y, geomvertex.posY);
									array[0].Z = Math.Min(array[0].Z, geomvertex.posZ);
									array[1].X = Math.Max(array[1].X, geomvertex.posX);
									array[1].Y = Math.Max(array[1].Y, geomvertex.posY);
									array[1].Z = Math.Max(array[1].Z, geomvertex.posX);
								}
							}
						}
						@class.VPXY.BoundingBox[0] = array[0].X;
						@class.VPXY.BoundingBox[1] = array[0].Y;
						@class.VPXY.BoundingBox[2] = array[0].Z;
						@class.VPXY.BoundingBox[3] = array[1].X;
						@class.VPXY.BoundingBox[4] = array[1].Y;
						@class.VPXY.BoundingBox[5] = array[1].Z;
					}
					this.method_9();
					this.method_4();
					MessageBox.Show(Class132.mainForm, "Import complete!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.caspModelControl_0.meshgroupCombo.SelectedIndex = selectedIndex;
				}
			}
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x00061C34 File Offset: 0x0005FE34
		public void method_4()
		{
			Class132.smethod_0().method_3(this.Renderable);
			Class81 @class = this.caspModelControl_0.PresetComboBox.SelectedItem as Class81;
			if (@class.Data.GetType().Equals(typeof(XmlDocument)))
			{
				this.Renderable.vmethod_3(@class.Data as XmlDocument);
			}
			else
			{
				this.Renderable.vmethod_3(null);
			}
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00061CAC File Offset: 0x0005FEAC
		private void method_5(object sender, EventArgs e)
		{
			if (this.caspModelControl_0.meshgroupCombo.SelectedIndex != -1)
			{
				Class67 @class = this.caspModelControl_0.meshgroupCombo.SelectedItem as Class67;
				bool flag = false;
				foreach (int index in @class.Entry.index)
				{
					TGIIndex tgiindex = @class.VPXY.TGIIndex[index];
					Geometry geometry = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.Reskey)) as Geometry;
					foreach (RCOLItem rcolitem in geometry.Entries)
					{
						GEOM geom = (GEOM)rcolitem;
						if (geom.HasMorphData)
						{
							flag = true;
						}
					}
				}
				if (@class.Entry.index.Count > 1 && flag)
				{
					MessageBox.Show(Class132.mainForm, "This CASP has multiple groups and morphstates, each group will be exported into a separate file.", "Multiple groups", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				Lod msIndex = (Lod)@class.Entry.msIndex;
				string text = "";
				List<IFileExportPlugin> fileExportPluginsForType = Class132.mainForm.GetFileExportPluginsForType(DBPFType.GEOM);
				List<ICASPExport> list = new List<ICASPExport>();
				foreach (IFileExportPlugin fileExportPlugin in fileExportPluginsForType)
				{
					if (fileExportPlugin is ICASPExport)
					{
						string text2 = text;
						text = string.Concat(new string[]
						{
							text2,
							(text != "") ? "|" : "",
							fileExportPlugin.GetExtensionNameForType(DBPFType.GEOM),
							"(*.",
							fileExportPlugin.GetExtensionForType(DBPFType.GEOM),
							")|*.",
							fileExportPlugin.GetExtensionForType(DBPFType.GEOM)
						});
						list.Add(fileExportPlugin as ICASPExport);
					}
				}
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = text;
				bool flag2 = false;
				if (@class.Entry.index.Count > 1 && flag)
				{
					MultiPartCaspFilePicker multiPartCaspFilePicker = new MultiPartCaspFilePicker(text, @class.VPXY, @class.Entry, false);
					if (multiPartCaspFilePicker.ShowDialog(Class132.mainForm) != DialogResult.OK)
					{
						goto IL_579;
					}
					using (List<int>.Enumerator enumerator4 = @class.Entry.index.GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							int num = enumerator4.Current;
							MultiPartCaspFilePicker.Class95 class2 = multiPartCaspFilePicker.Parts[num];
							string fileName = class2.FileName;
							if (class2.Checked)
							{
								TGIIndex tgiindex2 = @class.VPXY.TGIIndex[num];
								Geometry geometry2 = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex2.Reskey)) as Geometry;
								foreach (RCOLItem rcolitem2 in geometry2.Entries)
								{
									GEOM geom2 = (GEOM)rcolitem2;
									if (list[class2.FilterIndex - 1].ExportGeom(fileName, this.casp_0, geom2, msIndex) == PluginResult.FAIL)
									{
										MessageBox.Show(Class132.mainForm, "Export failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										flag2 = true;
									}
								}
							}
						}
						goto IL_579;
					}
				}
				if (@class.Entry.index.Count == 1 && flag && saveFileDialog.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					string fileName2 = saveFileDialog.FileName;
					Path.GetFileName(fileName2);
					int num2 = 0;
					using (List<int>.Enumerator enumerator6 = @class.Entry.index.GetEnumerator())
					{
						while (enumerator6.MoveNext())
						{
							int index2 = enumerator6.Current;
							TGIIndex tgiindex3 = @class.VPXY.TGIIndex[index2];
							Geometry geometry3 = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex3.Reskey)) as Geometry;
							foreach (RCOLItem rcolitem3 in geometry3.Entries)
							{
								GEOM geom3 = (GEOM)rcolitem3;
								string text3 = fileName2;
								if (@class.Entry.index.Count > 1)
								{
									text3 = string.Concat(new object[]
									{
										text3.Substring(0, text3.Length - Path.GetExtension(text3).Length),
										"_part_",
										num2++,
										Path.GetExtension(text3)
									});
								}
								if (list[saveFileDialog.FilterIndex - 1].ExportGeom(text3, this.casp_0, geom3, msIndex) == PluginResult.FAIL)
								{
									MessageBox.Show(Class132.mainForm, "Export failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									flag2 = true;
								}
							}
						}
						goto IL_579;
					}
				}
				if (!flag && saveFileDialog.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					string fileName3 = saveFileDialog.FileName;
					if (list[saveFileDialog.FilterIndex - 1].ExportCASP(fileName3, this.casp_0, @class.VPXY, @class.Entry, msIndex) != PluginResult.OK)
					{
						MessageBox.Show(Class132.mainForm, "Export failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						flag2 = true;
					}
				}
				IL_579:
				if (!flag2)
				{
					MessageBox.Show(Class132.mainForm, "Export completed!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x000622FC File Offset: 0x000604FC
		private void method_6(object sender, EventArgs e)
		{
			if (this.caspModelControl_0.meshgroupCombo.SelectedIndex != -1)
			{
				Class2 meshPropertyGrid = this.caspModelControl_0.MeshPropertyGrid;
				meshPropertyGrid.Clear();
				int num = 100;
				Class67 @class = this.caspModelControl_0.meshgroupCombo.SelectedItem as Class67;
				int num2 = 0;
				foreach (int index in @class.Entry.index)
				{
					TGIIndex tgiindex = @class.VPXY.TGIIndex[index];
					BONE bone = null;
					foreach (TGIIndex tgiindex2 in @class.VPXY.TGIIndex)
					{
						if (tgiindex2.IsType(DBPFType.BONE))
						{
							bone = (Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex2.AsString())) as BONE);
						}
					}
					Geometry geometry = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.Reskey)) as Geometry;
					foreach (RCOLItem rcolitem in geometry.Entries)
					{
						GEOM geom = (GEOM)rcolitem;
						PropertyEnumerator underCategory = meshPropertyGrid.AppendRootCategory(num++, "Group " + num2++);
						PropertyEnumerator propertyEnumerator = meshPropertyGrid.AppendManagedProperty(underCategory, num++, "Mesh ", typeof(string), geom.ToString(), "geom");
						propertyEnumerator.Property.Feel = meshPropertyGrid.GetRegisteredFeel("button");
						propertyEnumerator.Property.Tag = "mesh";
						propertyEnumerator.Property.Value.Tag = geom;
						propertyEnumerator.Property.Value.ReadOnly = false;
						PropertyEnumerator propertyEnumerator2 = meshPropertyGrid.AppendManagedProperty(underCategory, num++, "Material", typeof(string), "", "");
						propertyEnumerator2.Property.Tag = geom.MATD;
						propertyEnumerator2.Property.Value.Tag = "visible";
						propertyEnumerator2.Property.Feel = meshPropertyGrid.GetRegisteredFeel("button");
						PropertyEnumerator propertyEnumerator3 = meshPropertyGrid.AppendSubCategory(underCategory, num++, "Bones (" + geom.boneHashes.Count + ")");
						Class132.mainForm.CurrentProject.Package.SearchEntries(new ResKey(DBPFType.BONE));
						foreach (uint num3 in geom.boneHashes)
						{
							string text = num3.ToString("X8");
							if (bone != null)
							{
								foreach (BONE.BoneEntry boneEntry in bone.Bones)
								{
									if (FNV32.GetHash(boneEntry.Name) == num3)
									{
										text = boneEntry.Name;
									}
								}
							}
							Class17 class2 = new Class17(FNV32.GetHash(text), 0f, 0f, 0f, 0f, 0f, 0f);
							PropertyEnumerator propertyEnumerator4 = meshPropertyGrid.AppendManagedProperty(propertyEnumerator3, num++, text, typeof(Class17), class2, "wrapper");
							propertyEnumerator4.Property.Value.Tag = class2;
						}
						meshPropertyGrid.ExpandProperty(propertyEnumerator3, false);
					}
				}
				Class132.mainForm.SetCurrentLOD((@class.Entry.msIndex == 0) ? Lod.UltraHigh : ((@class.Entry.msIndex == 1) ? Lod.High : ((@class.Entry.msIndex == 2) ? Lod.Medium : Lod.Low)));
			}
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x00005440 File Offset: 0x00003640
		private void method_7(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			e.PropertyEnum.Property.Value.GetValue();
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x00062784 File Offset: 0x00060984
		private void method_8(object sender, PropertySelectedEventArgs e)
		{
			if (this.class17_0 != null)
			{
				this.Renderable.imethod_10(-1);
				this.class17_0 = null;
			}
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.GetType() == typeof(Class17))
			{
				this.class17_0 = (e.PropertyEnum.Property.Value.Tag as Class17);
			}
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x00062820 File Offset: 0x00060A20
		public void method_9()
		{
			this.caspModelControl_0.MeshPropertyGrid.Clear();
			this.caspModelControl_0.meshgroupCombo.Items.Clear();
			IGTIndex igtindex = this.casp_0.igtIndex[(int)this.casp_0.vpxyIndex];
			VisualProxy visualProxy_ = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(igtindex.Reskey)) as VisualProxy;
			this.method_18(visualProxy_);
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0000545A File Offset: 0x0000365A
		private void method_10(object object_0, Class48 class48_0)
		{
			this.method_23();
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0006289C File Offset: 0x00060A9C
		private void method_11(object sender, EventArgs e)
		{
			Class81 @class = (Class81)this.caspModelControl_0.PresetComboBox.SelectedItem;
			if (@class.Data.GetType().Equals(typeof(XmlDocument)))
			{
				ComplateToImageForm complateToImageForm = new ComplateToImageForm(@class.Data as XmlDocument, new Size(1024, 1024));
				if (!complateToImageForm.Completed)
				{
					complateToImageForm.ShowDialog(Class132.mainForm);
				}
			}
			else
			{
				ComplateToImageForm complateToImageForm2 = new ComplateToImageForm((@class.Data as TXTC).ToComplate("CasRgbMask", TXTC.ComplateType.Other), new Size(1024, 1024));
				if (!complateToImageForm2.Completed)
				{
					complateToImageForm2.ShowDialog(Class132.mainForm);
				}
			}
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00005464 File Offset: 0x00003664
		private void method_12(object sender, EventArgs e)
		{
			this.caspModelControl_0.PresetPropertyGrid.AdvancedMode = this.caspModelControl_0.AdvancedMode.Checked;
			this.caspModelControl_0.PresetPropertyGrid.method_9();
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x00062954 File Offset: 0x00060B54
		private void method_13(object sender, PropertyButtonClickedEventArgs e)
		{
			object previousValue = e.PropertyEnum.Property.Value.PreviousValue;
			object tag = e.PropertyEnum.Property.Tag;
			if (tag is string && tag.Equals("steps"))
			{
				TextureStepEditor textureStepEditor = new TextureStepEditor();
				textureStepEditor.Complate = (XmlDocument)e.PropertyEnum.Property.Value.Tag;
				textureStepEditor.Override = this.xmlDocument_0;
				textureStepEditor.ComplateReskey = (this.xmlDocument_0.SelectNodes("/preset/complate").Item(0) as XmlElement).GetAttribute("reskey");
				if (textureStepEditor.ShowDialog() == DialogResult.OK && textureStepEditor.bool_0)
				{
					Preset preset = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(textureStepEditor.ComplateReskey)) as Preset;
					(this.xmlDocument_0.SelectNodes("/preset/complate").Item(0) as XmlElement).SetAttribute("reskey", preset.GenerateResKey());
					this.Renderable.vmethod_3(this.xmlDocument_0);
				}
			}
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x00062A74 File Offset: 0x00060C74
		private void method_14(object sender, EventArgs e)
		{
			int selectedIndex = this.caspModelControl_0.PresetComboBox.SelectedIndex;
			if (selectedIndex != -1)
			{
				Class81 @class = (Class81)this.caspModelControl_0.PresetComboBox.SelectedItem;
				if (@class.Data.GetType().Equals(typeof(XmlDocument)))
				{
					this.xmlDocument_0 = (XmlDocument)@class.Data;
					XmlNodeList xmlNodeList = this.xmlDocument_0.SelectNodes("/preset/complate/pattern");
					int num = 0;
					foreach (object obj in xmlNodeList)
					{
						XmlElement xmlElement = (XmlElement)obj;
						if (xmlElement.GetAttribute("variable").ToLower().Contains("pattern ".ToLower()))
						{
							num++;
						}
					}
					this.caspModelControl_0.threeChannelsRadio.Checked = (num == 3);
					this.caspModelControl_0.fourChannelsRadio.Checked = (num == 4);
					this.caspModelControl_0.fourChannelsRadio.Enabled = (this.caspModelControl_0.threeChannelsRadio.Enabled = (num > 0));
					switch (this.project.Type)
					{
					case Sims3Workshop.Data.ProjectType.HAIR:
						if (num > 0)
						{
							this.caspModelControl_0.threeChannelsRadio.Enabled = false;
						}
						break;
					case Sims3Workshop.Data.ProjectType.ACCESSORY:
						if (this.casp_0.clothingType == 12U)
						{
							this.caspModelControl_0.fourChannelsRadio.Enabled = false;
						}
						break;
					}
					this.method_15();
				}
				else
				{
					this.method_26(@class.Data as TXTC);
					this.xmlDocument_0 = null;
					Control fourChannelsRadio = this.caspModelControl_0.fourChannelsRadio;
					this.caspModelControl_0.threeChannelsRadio.Enabled = false;
					fourChannelsRadio.Enabled = false;
				}
			}
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00062C5C File Offset: 0x00060E5C
		private void method_15()
		{
			this.caspModelControl_0.PresetPropertyGrid.Preset = this.xmlDocument_0;
			Class8 presetPropertyGrid = this.caspModelControl_0.PresetPropertyGrid;
			PropertyEnumerator underCategory = presetPropertyGrid.Categories["Misc"];
			PropertyEnumerator propertyEnumerator = presetPropertyGrid.AppendManagedProperty(underCategory, this.int_0 + 50, "Texture Builder", typeof(string), "", "The texture creation steps");
			propertyEnumerator.Property.Feel = presetPropertyGrid.GetRegisteredFeel("editbutton");
			propertyEnumerator.Property.Tag = "steps";
			propertyEnumerator.Property.Value.Tag = presetPropertyGrid.Complate;
			this.int_0++;
			Image initialValue = null;
			ResKey key = new ResKey(DBPFType.PNG_PREVIEW, this.caspModelControl_0.PresetComboBox.SelectedIndex + 1, this.casp_0.InstanceID, this.casp_0.SecondInstanceID);
			DBPFEntry entry = this.project.Package.GetEntry(key);
			if (entry != null)
			{
				initialValue = ((PNG)entry).Image;
			}
			PropertyEnumerator propertyEnumerator2 = presetPropertyGrid.AppendManagedProperty(underCategory, this.int_0 + 51, "CAS Thumbnail", typeof(Image), initialValue, "Custom image to display in Create a Sim, leave empty for the default game created thumbnail");
			propertyEnumerator2.Property.Tag = "CAS Thumbnail";
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00062DA8 File Offset: 0x00060FA8
		private Type method_16(DBPFType dbpftype_0)
		{
			Type typeFromHandle;
			if (dbpftype_0 == DBPFType.DDS)
			{
				typeFromHandle = typeof(TextureResKey);
			}
			else
			{
				typeFromHandle = typeof(ResKey);
			}
			return typeFromHandle;
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x00005498 File Offset: 0x00003698
		private void method_17(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			Class132.smethod_0().method_3(this.Renderable);
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00062DDC File Offset: 0x00060FDC
		private void method_18(VisualProxy visualProxy_0)
		{
			VisualHint.SmartPropertyGrid.PropertyGrid meshPropertyGrid = this.caspModelControl_0.MeshPropertyGrid;
			meshPropertyGrid.BeginUpdate();
			meshPropertyGrid.Clear();
			foreach (RCOLItem rcolitem in visualProxy_0.Entries)
			{
				VPXY vpxy = (VPXY)rcolitem;
				foreach (VPXY.VPXEntryEntry vpxentryEntry in vpxy.entries)
				{
					if (vpxentryEntry.type == 0)
					{
						switch (vpxentryEntry.msIndex)
						{
						case 0:
							this.list_0.Add(Lod.UltraHigh);
							break;
						case 1:
							this.list_0.Add(Lod.High);
							break;
						case 2:
							this.list_0.Add(Lod.Medium);
							break;
						case 3:
							goto IL_AA;
						default:
							goto IL_AA;
						}
						IL_B6:
						Class67 item = new Class67(vpxy, vpxentryEntry);
						this.caspModelControl_0.meshgroupCombo.Items.Add(item);
						continue;
						IL_AA:
						this.list_0.Add(Lod.Low);
						goto IL_B6;
					}
				}
			}
			meshPropertyGrid.EndUpdate();
			if (this.caspModelControl_0.meshgroupCombo.Items.Count == 0)
			{
				this.caspModelControl_0.TabControl.TabPages.Remove(this.caspModelControl_0.meshTab);
			}
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00062F54 File Offset: 0x00061154
		private void method_19(object sender, PropertyButtonClickedEventArgs e)
		{
			object tag = e.PropertyEnum.Property.Tag;
			object previousValue = e.PropertyEnum.Property.Value.PreviousValue;
			if (tag is MATD.InternalMATD)
			{
				MaterialEditor materialEditor = new MaterialEditor((MATD.InternalMATD)e.PropertyEnum.Property.Tag);
				if (materialEditor.ShowDialog() == DialogResult.OK)
				{
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
					Class132.smethod_0().method_3(this.Renderable);
					Class81 @class = this.caspModelControl_0.PresetComboBox.SelectedItem as Class81;
					if (@class.Data.GetType().Equals(typeof(XmlDocument)))
					{
						this.Renderable.vmethod_3(@class.Data as XmlDocument);
					}
					else
					{
						this.Renderable.vmethod_3(null);
					}
				}
			}
			else if (tag is string && tag.Equals("mesh") && Class132.mainForm.EditFile(DBPFType.GEOM, (e.PropertyEnum.Property.Value.Tag as GEOM).Parent) == PluginResult.OK)
			{
				Class132.smethod_0().method_3(this.Renderable);
				Class81 class2 = this.caspModelControl_0.PresetComboBox.SelectedItem as Class81;
				if (class2.Data.GetType().Equals(typeof(XmlDocument)))
				{
					this.Renderable.vmethod_3(class2.Data as XmlDocument);
				}
				else
				{
					this.Renderable.vmethod_3(null);
				}
			}
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x000630EC File Offset: 0x000612EC
		private void method_20(CASP casp_1)
		{
			this.method_24(casp_1);
			DBPFEntry dbpfentry = Class76.smethod_26(new ResKey("{key:6b20c4f3:00000000:4aebd332140768c2}"));
			if ((casp_1.ageFlags & 52992U) != 0U)
			{
				if ((casp_1.ageFlags & 52992U) != 256U)
				{
					Class132.smethod_0().method_49(null);
					return;
				}
			}
			if (dbpfentry != null)
			{
				Class132.smethod_0().method_49(dbpfentry as S_CLIP);
			}
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x000054AC File Offset: 0x000036AC
		public void method_21(object object_0, PropertyEnumerator propertyEnumerator_0)
		{
			this.method_22(object_0, new VisualHint.SmartPropertyGrid.PropertyChangedEventArgs(propertyEnumerator_0));
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00063158 File Offset: 0x00061358
		private void method_22(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			try
			{
				object value = e.PropertyEnum.Property.Value.GetValue();
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				if (value is PatternResKey)
				{
					object previousValue = e.PropertyEnum.Property.Value.PreviousValue;
				}
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
						png2.GroupID = this.casp_0.GroupID;
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("launcherThumbnail", png2.GenerateResKey());
						this.project.Package.AddEntry(png2);
					}
				}
				else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("CAS Thumbnail"))
				{
					ResKey key2 = new ResKey(DBPFType.PNG_PREVIEW, this.caspModelControl_0.PresetComboBox.SelectedIndex + 1, this.casp_0.InstanceID, this.casp_0.SecondInstanceID);
					PNG png3 = this.project.Package.GetEntry(key2) as PNG;
					if (png3 != null)
					{
						png3.Image = (value as Bitmap);
					}
					else
					{
						png3 = new PNG(DBPFType.PNG_PREVIEW);
						png3.Image = (value as Bitmap);
						png3.InstanceID = this.casp_0.InstanceID;
						png3.SecondInstanceID = this.casp_0.SecondInstanceID;
						png3.GroupID = this.caspModelControl_0.PresetComboBox.SelectedIndex + 1;
						this.project.Package.AddEntry(png3);
					}
				}
				else if (e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.GetType().Equals(typeof(TXTC.PropertySet)))
				{
					if (value.GetType().Equals(typeof(Color)))
					{
						TXTC.PropertySet propertySet = e.PropertyEnum.Property.Value.Tag as TXTC.PropertySet;
						Color color = (Color)value;
						propertySet.GetEntry((TXTC.EntryType)2954315994U).data = new byte[]
						{
							color.B,
							color.G,
							color.R,
							color.A
						};
					}
					Class132.smethod_0().method_1(null);
				}
				else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_str1"))
				{
					this.casp_0.str1 = (value as string);
				}
				else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_str2"))
				{
					this.casp_0.str2 = (value as string);
				}
				else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_type"))
				{
					this.Type = (CASP.Type)value;
					this.casp_0.typeFlags = (uint)this.Type;
				}
				else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_clothingtype"))
				{
					this.ClothingType = (CASP.ClothingType)value;
					this.casp_0.clothingType = (uint)this.ClothingType;
				}
				else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_age"))
				{
					this.casp_0.ageFlags = (uint)(this.Age | (Age)this.Gender | (Age)this.Species | (Age)this.Handedness);
					this.Age = (Age)value;
					if (this.Age != (Age)0U && MessageBox.Show("You have changed the age flags. Do you want to reload the CAS Parts to match the new age selection?", "Age Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						if (this.Renderable.PossibleTops != null)
						{
							this.Renderable.PossibleTops = null;
						}
						if (this.Renderable.PossibleBottoms != null)
						{
							this.Renderable.PossibleBottoms = null;
						}
						if (this.Renderable.PossibleShoes != null)
						{
							this.Renderable.PossibleShoes = null;
						}
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("bottomPart");
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("topPart");
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("shoesPart");
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("facePart");
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("hairPart");
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("scalpPart");
						this.Renderable.imethod_7(Class140.smethod_0().Device);
						this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
					}
				}
				else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_gender"))
				{
					this.casp_0.ageFlags = (uint)(this.Age | (Age)this.Gender | (Age)this.Species | (Age)this.Handedness);
					this.Gender = (Gender)value;
					if (this.Gender != (Gender)0U && MessageBox.Show("You have changed the gender flags. Do you want to reload the CAS Parts to match the new gender selection?", "Gender Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						if (this.Renderable.PossibleTops != null)
						{
							this.Renderable.PossibleTops = null;
						}
						if (this.Renderable.PossibleBottoms != null)
						{
							this.Renderable.PossibleBottoms = null;
						}
						if (this.Renderable.PossibleShoes != null)
						{
							this.Renderable.PossibleShoes = null;
						}
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("bottomPart");
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("topPart");
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("shoesPart");
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("facePart");
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("hairPart");
						this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Remove("scalpPart");
						this.Renderable.imethod_7(Class140.smethod_0().Device);
						this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
					}
				}
				else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_species"))
				{
					this.casp_0.ageFlags = (uint)(this.Age | (Age)this.Gender | (Age)this.Species | (Age)this.Handedness);
					this.Gender = (Gender)value;
				}
				else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_handedness"))
				{
					this.casp_0.ageFlags = (uint)(this.Age | (Age)this.Gender | (Age)this.Species | (Age)this.Handedness);
					this.Gender = (Gender)value;
				}
				else if (e.PropertyEnum.Property.Tag != null && e.PropertyEnum.Property.Tag.Equals("_category"))
				{
					this.casp_0.clothingCategoryFlags = (uint)this.Category;
					this.Category = (CASP.ClothingCategory)value;
				}
				else if (value.GetType() == typeof(TextureResKey))
				{
					object previousValue2 = e.PropertyEnum.Property.Value.PreviousValue;
					object tag = e.PropertyEnum.Property.Tag;
					TextureResKey reskey = (TextureResKey)value;
					for (int i = 0; i < this.casp_0.igtIndex.Count; i++)
					{
						IGTIndex igtindex = this.casp_0.igtIndex[i];
						string text = previousValue2.ToString();
						if (igtindex.Reskey.ToLower().Equals(text.ToLower()))
						{
							int index = this.casp_0.igtIndex.IndexOf(igtindex);
							IGTIndex value2 = new IGTIndex(reskey);
							this.casp_0.igtIndex[index] = value2;
						}
					}
				}
				this.method_23();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not set property\n\n" + ex.Message);
			}
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x000054BD File Offset: 0x000036BD
		private void method_23()
		{
			Class132.smethod_0().method_1(this.xmlDocument_0);
			Class132.smethod_0().method_35();
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00063AFC File Offset: 0x00061CFC
		private void method_24(CASP casp_1)
		{
			GeneralProgress.Class93 @class = GeneralProgress.smethod_0("Adding mesh, please wait...");
			casp_1.GenerateResKey();
			@class.ProgressForm.FormClosed += Class132.mainForm.ProgressForm_FormClosed;
			@class.DoWork += this.method_28;
			@class.RunWorkerCompleted += this.method_25;
			@class.Disposed += Class68.smethod_0;
			@class.Arguments.Add(casp_1);
			@class.method_0();
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x000054DB File Offset: 0x000036DB
		private static void smethod_0(object sender, EventArgs e)
		{
			MessageBox.Show("DISPOSED");
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00063B80 File Offset: 0x00061D80
		private void method_25(object sender, RunWorkerCompletedEventArgs e)
		{
			((GeneralProgress.Class93)sender).method_1();
			CASP casp = ((GeneralProgress.Class93)sender).Arguments[1] as CASP;
			VisualHint.SmartPropertyGrid.PropertyGrid caspPropertyGrid = this.caspModelControl_0.CaspPropertyGrid;
			caspPropertyGrid.DisableModeGrayedOut = true;
			caspPropertyGrid.Clear();
			caspPropertyGrid.PropertyChanged += this.method_22;
			PropertyEnumerator underCategory = caspPropertyGrid.AppendRootCategory(1, "Clothing Project");
			PropertyEnumerator underCategory2 = caspPropertyGrid.AppendSubCategory(underCategory, 100, "Basic data");
			caspPropertyGrid.AppendProperty(underCategory2, 101, "Title", this, "Title", "The title displayed by the launcher.");
			PropertyEnumerator propertyEnumerator = caspPropertyGrid.AppendSubCategory(underCategory, 103, "Type");
			PropertyEnumerator propertyEnumerator2 = caspPropertyGrid.AppendProperty(propertyEnumerator, 151, "Type", this, "Type", "What clothing type.");
			propertyEnumerator2.Property.Tag = "_type";
			caspPropertyGrid.ExpandProperty(propertyEnumerator, false);
			PropertyEnumerator propertyEnumerator3 = caspPropertyGrid.AppendSubCategory(underCategory, 103, "Clothing Type");
			PropertyEnumerator propertyEnumerator4 = caspPropertyGrid.AppendProperty(propertyEnumerator3, 151, "Clothing Type", this, "ClothingType", "What clothing type.");
			propertyEnumerator4.Property.Tag = "_clothingtype";
			caspPropertyGrid.ExpandProperty(propertyEnumerator3, false);
			PropertyEnumerator propertyEnumerator5 = caspPropertyGrid.AppendProperty(underCategory2, 103, "Age", this, "Age", "What ages this applies to.");
			propertyEnumerator5.Property.Tag = "_age";
			PropertyEnumerator propertyEnumerator6 = caspPropertyGrid.AppendProperty(underCategory2, 104, "Gender", this, "Gender", "What gender this should be used for.");
			propertyEnumerator6.Property.Tag = "_gender";
			PropertyEnumerator propertyEnumerator7 = caspPropertyGrid.AppendProperty(underCategory2, 104, "Species", this, "Species", "What species this should be used for.");
			propertyEnumerator7.Property.Tag = "_species";
			PropertyEnumerator propertyEnumerator8 = caspPropertyGrid.AppendProperty(underCategory2, 104, "Handedness", this, "Handedness", "What handedness this should be used for.");
			propertyEnumerator8.Property.Tag = "_handedness";
			PropertyEnumerator propertyEnumerator9 = caspPropertyGrid.AppendSubCategory(underCategory, 105, "Categories");
			PropertyEnumerator propertyEnumerator10 = caspPropertyGrid.AppendProperty(propertyEnumerator9, 151, "Category", this, "Category", "What clothing categories.");
			propertyEnumerator10.Property.Tag = "_category";
			caspPropertyGrid.ExpandProperty(propertyEnumerator9, false);
			PropertyEnumerator underCategory3 = caspPropertyGrid.AppendSubCategory(underCategory, 105, "Parts");
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.TryGetValue("bottomPart", out this.string_0))
			{
				PropertyEnumerator propertyEnumerator11 = caspPropertyGrid.AppendProperty(underCategory3, 151, "Bottom", this, "BottomPart", "Bottom");
				propertyEnumerator11.Property.Tag = "bottomPart";
				propertyEnumerator11.Property.Feel = caspPropertyGrid.GetRegisteredFeel("editbutton");
			}
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.TryGetValue("topPart", out this.string_1))
			{
				this.string_1 = this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["topPart"];
				PropertyEnumerator propertyEnumerator12 = caspPropertyGrid.AppendProperty(underCategory3, 151, "Top", this, "TopPart", "Top");
				propertyEnumerator12.Property.Tag = "topPart";
				propertyEnumerator12.Property.Feel = caspPropertyGrid.GetRegisteredFeel("editbutton");
			}
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.TryGetValue("shoesPart", out this.string_2))
			{
				this.string_2 = this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["shoesPart"];
				PropertyEnumerator propertyEnumerator13 = caspPropertyGrid.AppendProperty(underCategory3, 151, "Shoes", this, "ShoesPart", "Shoes");
				propertyEnumerator13.Property.Tag = "shoesPart";
				propertyEnumerator13.Property.Feel = caspPropertyGrid.GetRegisteredFeel("editbutton");
			}
			PropertyEnumerator propertyEnumerator14 = caspPropertyGrid.AppendSubCategory(underCategory, 105, "Extras");
			PropertyEnumerator propertyEnumerator15 = caspPropertyGrid.AppendProperty(propertyEnumerator14, 151, "Filename", this, "Filename", "CASP Filename");
			propertyEnumerator15.Property.Tag = "_str1";
			PropertyEnumerator propertyEnumerator16 = caspPropertyGrid.AppendProperty(propertyEnumerator14, 151, "Filename2", this, "Filename2", "CASP Filename2");
			propertyEnumerator16.Property.Tag = "_str2";
			caspPropertyGrid.ExpandProperty(propertyEnumerator14, false);
			PropertyEnumerator propertyEnumerator17 = caspPropertyGrid.AppendProperty(propertyEnumerator14, 151, "Launcher thumbnail", this, "LauncherThumbnail", "Launcher thumbnail");
			propertyEnumerator17.Property.Tag = "_launcherThumbnail";
			caspPropertyGrid.ExpandProperty(propertyEnumerator14, false);
			this.Age = (Age)(casp.ageFlags & 127U);
			this.Gender = (Gender)(casp.ageFlags & 12288U);
			this.Species = (Enum12)(casp.ageFlags & 52992U);
			this.Handedness = (Enum11)(casp.ageFlags & 3145728U);
			this.Category = (CASP.ClothingCategory)casp.clothingCategoryFlags;
			this.Type = (CASP.Type)casp.typeFlags;
			this.ClothingType = (CASP.ClothingType)casp.clothingType;
			this.Filename = casp.str1;
			this.Filename2 = casp.str2;
			if (this.caspModelControl_0.PresetComboBox.Items.Count == 0)
			{
				this.caspModelControl_0.PresetComboBox.Enabled = false;
			}
			this.caspModelControl_0.TabControl.TabPages.Remove(this.caspModelControl_0.slotsTab);
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0006408C File Offset: 0x0006228C
		public void method_26(TXTC txtc_0)
		{
			VisualHint.SmartPropertyGrid.PropertyGrid presetPropertyGrid = this.caspModelControl_0.PresetPropertyGrid;
			presetPropertyGrid.Clear();
			presetPropertyGrid.BeginUpdate();
			PropertyEnumerator underCategory = presetPropertyGrid.AppendRootCategory(9000, "Default properties");
			PropertyEnumerator propertyEnumerator = presetPropertyGrid.AppendManagedProperty(underCategory, this.int_0 + 50, "Texture Builder", typeof(string), "", "The texture creation steps");
			propertyEnumerator.Property.Feel = presetPropertyGrid.GetRegisteredFeel("editbutton");
			propertyEnumerator.Property.Tag = "steps";
			propertyEnumerator.Property.Value.Tag = txtc_0;
			int num = 0;
			foreach (TXTC.PropertySet propertySet in txtc_0.PropertySets)
			{
				try
				{
					TXTC.PROPEntry entry = propertySet.GetEntry(TXTC.EntryType.ID);
					if (entry != null)
					{
						uint uintData = entry.GetUIntData();
						TXTC.PROPEntry entry2 = propertySet.GetEntry(TXTC.EntryType.Description);
						string comment = (entry2 == null) ? "" : (entry2.data as string);
						Type valueType = this.method_27(uintData);
						object obj = null;
						if (uintData == 2630952605U)
						{
							TXTC.PROPEntry entry3 = propertySet.GetEntry((TXTC.EntryType)2954315994U);
							obj = ((entry3 == null) ? Color.White : Color.FromArgb((int)entry3.GetUIntData()));
						}
						else if (uintData == 2706505905U)
						{
							TXTC.PROPEntry entry4 = propertySet.GetEntry((TXTC.EntryType)4140598385U);
							if (entry4 == null)
							{
								continue;
							}
							object data = entry4.data;
							obj = new TextureResKey(txtc_0.IGTIndex[(int)((byte)data)].Reskey);
						}
						if (obj != null)
						{
							PropertyEnumerator propertyEnumerator2 = presetPropertyGrid.AppendManagedProperty(underCategory, num++, "Param " + num, valueType, obj, comment);
							if (uintData == 2630952605U)
							{
								propertyEnumerator2.Property.Value.SetAttribute(new PropertyDropDownContentAttribute(typeof(AlphaColorPicker), new object[]
								{
									false
								}));
								propertyEnumerator2.Property.Feel = presetPropertyGrid.GetRegisteredFeel("list");
								propertyEnumerator2.Property.Value.Look = new PropertyColorLook();
							}
							else if (uintData == 2706505905U)
							{
								propertyEnumerator2.Property.Feel = presetPropertyGrid.GetRegisteredFeel("texture");
								propertyEnumerator2.Property.Value.Look = new Class61();
							}
							propertyEnumerator2.Property.Value.Tag = propertySet;
						}
					}
				}
				catch (Exception ex)
				{
					Class132.mainForm.SetStatus(ex.Message);
				}
			}
			presetPropertyGrid.EndUpdate();
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x00064364 File Offset: 0x00062564
		public Type method_27(uint uint_0)
		{
			Type typeFromHandle;
			if (uint_0 == 506870683U)
			{
				typeFromHandle = typeof(string);
			}
			else if (uint_0 == 2630952605U)
			{
				typeFromHandle = typeof(Color);
			}
			else if (uint_0 == 2706505905U)
			{
				typeFromHandle = typeof(TextureResKey);
			}
			else
			{
				typeFromHandle = typeof(string);
			}
			return typeFromHandle;
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x000643C0 File Offset: 0x000625C0
		private void method_28(object sender, DoWorkEventArgs e)
		{
			GeneralProgress progressForm = ((GeneralProgress.Class93)sender).ProgressForm;
			CASP casp = ((GeneralProgress.Class93)sender).Arguments[1] as CASP;
			progressForm.method_3(0f, "Loading meshes");
			this.Renderable = new Class104(this.project, casp, this.lod_0);
			Class132.smethod_0().method_2(this.Renderable);
			Class132.smethod_0().method_46();
			progressForm.method_3(50f, "Rendering thumbnails");
			List<XmlDocument> list = new List<XmlDocument>();
			list.AddRange(casp.Documents);
			new Random((int)DateTime.Now.Ticks);
			int num = 1;
			foreach (XmlDocument data in list)
			{
				progressForm.method_3((float)((int)Math.Round((double)(50f + (float)num++ / (float)list.Count * 100f))), "Rendering thumbnails");
				Class81 @class = new Class81(data, false);
				Class68.Delegate17 method = new Class68.Delegate17(this.method_29);
				this.caspModelControl_0.Invoke(method, new object[]
				{
					@class
				});
			}
			if (list.Count == 0)
			{
				this.caspModelControl_0.TabControl.TabPages.Remove(this.caspModelControl_0.PresetsTab);
			}
			progressForm.method_3(100f, "Done");
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00064548 File Offset: 0x00062748
		private void method_29(Class81 class81_0)
		{
			if (this.caspModelControl_0.InvokeRequired)
			{
				Class68.Delegate17 method = new Class68.Delegate17(this.method_29);
				this.caspModelControl_0.Invoke(method, new object[]
				{
					class81_0
				});
			}
			else
			{
				this.caspModelControl_0.PresetComboBox.Items.Add(class81_0);
				if (this.caspModelControl_0.PresetComboBox.Items.Count > 1)
				{
					this.caspModelControl_0.method_0(true);
				}
			}
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x000645C8 File Offset: 0x000627C8
		public object GetThumbnail()
		{
			return this.method_30(this.Renderable.CurrentPreset);
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x000645EC File Offset: 0x000627EC
		public object method_30(XmlDocument xmlDocument_1)
		{
			Bitmap bitmap = Class132.smethod_0().method_19(this.Renderable, xmlDocument_1, new Size(256, 256)) as Bitmap;
			Bitmap bitmap2 = new Bitmap(256, 256);
			Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.DrawImage(bitmap, new Rectangle(18, 18, 222, 222), 0, 0, 256, 256, GraphicsUnit.Pixel);
			bitmap.Dispose();
			return bitmap2;
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00064668 File Offset: 0x00062868
		public static CASP smethod_1(CASP casp_1, DBPF dbpf_0, bool bool_0, int int_1)
		{
			Random random = new Random((int)DateTime.Now.Ticks);
			CASP casp = casp_1.Clone() as CASP;
			if (!bool_0)
			{
				casp.GroupID = int_1;
			}
			casp.InstanceID = random.Next();
			casp.SecondInstanceID = random.Next();
			casp.str1 = casp.InstanceID + ":" + casp.SecondInstanceID;
			dbpf_0.AddEntry(casp);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (IGTIndex igtindex in casp.igtIndex)
			{
				if (!igtindex.IsType(DBPFType.DDS) && !igtindex.IsType(DBPFType.CASP) && !igtindex.IsType(DBPFType.PRESET))
				{
					DBPFEntry dbpfentry = Class76.smethod_26(new ResKey(igtindex.AsString()));
					if (dbpfentry == null)
					{
						dbpfentry = Class76.smethod_26(igtindex.ReplaceGroup(0));
						if (dbpfentry == null)
						{
							continue;
						}
					}
					if (dictionary.ContainsKey(igtindex.Reskey))
					{
						igtindex.Reskey = dictionary[igtindex.Reskey];
					}
					else
					{
						string reskey = igtindex.Reskey;
						dbpfentry = (dbpfentry.Clone() as DBPFEntry);
						dbpfentry.GroupID = (igtindex.GroupId = casp.GroupID);
						dbpfentry.InstanceID = (igtindex.InstanceId = random.Next());
						dbpfentry.SecondInstanceID = (igtindex.SecondInstanceId = random.Next());
						if (dbpfentry is FPRT)
						{
							FPRT fprt = dbpfentry as FPRT;
							if (fprt.blendTypeId == DBPFType.BGEO)
							{
								BGEO bgeo = Class76.smethod_26(new ResKey(fprt.BGEO_Reskey)) as BGEO;
								if (bgeo != null)
								{
									try
									{
										string key = bgeo.GenerateResKey();
										BGEO bgeo2 = bgeo.Clone() as BGEO;
										bgeo2.GroupID = (fprt.blendGroupId = casp.GroupID);
										bgeo2.InstanceID = (fprt.blendInstanceId = random.Next());
										bgeo2.SecondInstanceID = (fprt.blendSecondInstanceId = random.Next());
										dbpf_0.AddEntry(bgeo2);
										dictionary.Add(key, bgeo2.GenerateResKey());
									}
									catch (Exception ex)
									{
										throw new Exception("Could not clone blend data: " + ex.Message);
									}
								}
							}
						}
						if (dbpfentry is BOND)
						{
							RCOL rcol = dbpfentry as RCOL;
							foreach (RCOLFileEntry rcolfileEntry in rcol.InternalResources)
							{
								rcolfileEntry.ResKey.InstanceId = dbpfentry.InstanceID;
								rcolfileEntry.ResKey.SecondInstanceId = dbpfentry.SecondInstanceID;
								rcolfileEntry.ResKey.GroupId = dbpfentry.GroupID;
							}
						}
						dbpf_0.AddEntry(dbpfentry);
						dictionary.Add(reskey, dbpfentry.GenerateResKey());
						if (dbpfentry is RCOL)
						{
							Class68.smethod_2(dbpfentry as RCOL, dbpf_0, casp.GroupID, ref dictionary);
						}
						if (dbpfentry is VisualProxy)
						{
							foreach (RCOLItem rcolitem in (dbpfentry as VisualProxy).Entries)
							{
								VPXY vpxy = (VPXY)rcolitem;
								foreach (TGIIndex tgiindex in vpxy.TGIIndex)
								{
									try
									{
										if (dictionary.ContainsKey(tgiindex.Reskey))
										{
											tgiindex.Reskey = dictionary[tgiindex.Reskey];
										}
										else
										{
											DBPFEntry dbpfentry2 = Class76.smethod_26(new ResKey(tgiindex.Reskey));
											if (dbpfentry2 == null)
											{
												dbpfentry2 = Class76.smethod_26(new ResKey(dbpfentry2.TypeID, 0, dbpfentry2.InstanceID, dbpfentry2.SecondInstanceID));
												if (dbpfentry2 == null)
												{
													Console.WriteLine("Failed to clone " + tgiindex.AsString() + ", reskey not found");
													continue;
												}
											}
											DBPFEntry dbpfentry3 = (DBPFEntry)dbpfentry2.Clone();
											reskey = tgiindex.Reskey;
											dbpfentry3.GroupID = (tgiindex.GroupId = casp.GroupID);
											dbpfentry3.InstanceID = (tgiindex.InstanceId = random.Next());
											dbpfentry3.SecondInstanceID = (tgiindex.SecondInstanceId = random.Next());
											dbpf_0.AddEntry(dbpfentry3);
											dictionary.Add(reskey, dbpfentry3.GenerateResKey());
											if (dbpfentry3 is RCOL)
											{
												Class68.smethod_2(dbpfentry3 as RCOL, dbpf_0, casp.GroupID, ref dictionary);
											}
										}
									}
									catch (Exception ex2)
									{
										Console.WriteLine("Failed to clone " + tgiindex.AsString() + ", " + ex2.Message);
									}
								}
							}
						}
					}
				}
			}
			if (casp.hasDiffuse > 0 && casp.Documents.Count == 0)
			{
				TXTC txtc = dbpf_0.GetEntry(new ResKey(casp.igtIndex[(int)casp.diffuseIndex].Reskey)) as TXTC;
				string text = "Body";
				string text2 = "Body";
				string text3 = "CasRgbaMask";
				TXTC.ComplateType complateType = TXTC.ComplateType.Other;
				if ((casp.typeFlags & 1U) != 0U)
				{
					text = "Hair";
					text2 = "Hair";
					complateType = TXTC.ComplateType.Hair;
				}
				else if ((casp.typeFlags & 4U) != 0U && (casp.clothingType & 16U) != 0U)
				{
					text = "Face";
					text2 = "Face";
					complateType = TXTC.ComplateType.Hair;
				}
				else if ((casp.typeFlags & 4U) != 0U)
				{
					text = "Face";
					text2 = "Face";
					text3 = "CasSkinOverlayMultiTintable";
				}
				Preset preset = new Preset();
				XmlDocument xmlDocument = txtc.ToComplate(text3, complateType);
				preset.Documents.Add(xmlDocument);
				preset.GroupID = casp.GroupID;
				preset.InstanceID = random.Next();
				preset.SecondInstanceID = random.Next();
				dbpf_0.AddEntry(preset);
				string text4 = "";
				XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/complate/variables/param");
				foreach (object obj in xmlNodeList)
				{
					XmlElement xmlElement = (XmlElement)obj;
					string attribute = xmlElement.GetAttribute("name");
					string attribute2 = xmlElement.GetAttribute("default");
					string text5 = text4;
					text4 = string.Concat(new string[]
					{
						text5,
						"<value key=\"",
						attribute,
						"\" value=\"",
						attribute2,
						"\" />\n"
					});
				}
				string xml = string.Concat(new string[]
				{
					"<preset><complate name=\"",
					text3,
					"\" reskey=\"",
					preset.GenerateResKey(),
					"\"><value key=\"bodyType\" value=\"",
					text,
					"\" /><value key=\"partType\" value=\"",
					text2,
					"\" /><value key=\"daeFileName\" value=\"",
					casp.str1,
					"\" />",
					text4,
					"</complate></preset>"
				});
				XmlDocument xmlDocument2 = new XmlDocument();
				xmlDocument2.LoadXml(xml);
				casp.documents.Add(xmlDocument2);
			}
			return casp;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00064E68 File Offset: 0x00063068
		private static void smethod_2(RCOL rcol_0, DBPF dbpf_0, int int_1, ref Dictionary<string, string> dictionary_0)
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
						DBPFEntry dbpfentry3 = dbpfentry2;
						rcolfileEntry.ResKey.GroupId = int_1;
						dbpfentry3.GroupID = int_1;
						dbpfentry2.InstanceID = (rcolfileEntry.ResKey.InstanceId = random.Next());
						dbpfentry2.SecondInstanceID = (rcolfileEntry.ResKey.InstanceId = random.Next());
						dbpf_0.AddEntry(dbpfentry2);
						dictionary_0.Add(key, dbpfentry2.GenerateResKey());
						if (dbpfentry2 is RCOL)
						{
							Class68.smethod_2(dbpfentry2 as RCOL, dbpf_0, int_1, ref dictionary_0);
						}
					}
				}
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00064FB4 File Offset: 0x000631B4
		public object GetRenderable()
		{
			return this.Renderable;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x000054EA File Offset: 0x000036EA
		public void Unload()
		{
			this.method_31();
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00064FCC File Offset: 0x000631CC
		public IWorkshopProject GetCurrentProject()
		{
			return Class132.mainForm.CurrentProject;
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00064FE8 File Offset: 0x000631E8
		private void method_31()
		{
			this.caspModelControl_0.FatThinTrackBar.Value = 0;
			this.caspModelControl_0.FitTrackbar.Value = 50;
			Class132.smethod_0().method_34(null);
			if (this.Renderable != null)
			{
				this.Renderable.imethod_8(true);
			}
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool HasShadows()
		{
			return false;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00037B84 File Offset: 0x00035D84
		public bool HasBumpMap()
		{
			return true;
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x000032ED File Offset: 0x000014ED
		public List<object> GetModels()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x000032ED File Offset: 0x000014ED
		public List<object> GetGameObjects()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x000032ED File Offset: 0x000014ED
		public object GetCurrentGameObject()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0006503C File Offset: 0x0006323C
		public string GetTitle()
		{
			return this.Title;
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00065054 File Offset: 0x00063254
		public string GetDescription()
		{
			return "Not used";
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0006506C File Offset: 0x0006326C
		public void LodChanged(Lod lod_1)
		{
			Class104 renderable = this.Renderable;
			this.lod_0 = lod_1;
			renderable.LODLevel = lod_1;
			Class132.smethod_0().method_3(this.Renderable);
			Class132.smethod_0().method_46();
			this.Renderable.vmethod_3(this.Renderable.CurrentPreset);
			foreach (object obj in this.caspModelControl_0.meshgroupCombo.Items)
			{
				Class67 @class = (Class67)obj;
				if (@class.Entry.msIndex == 0 && lod_1 == Lod.UltraHigh)
				{
					this.caspModelControl_0.meshgroupCombo.SelectedItem = @class;
				}
				else if (@class.Entry.msIndex == 1 && lod_1 == Lod.High)
				{
					this.caspModelControl_0.meshgroupCombo.SelectedItem = @class;
				}
				else if (@class.Entry.msIndex == 2 && lod_1 == Lod.Medium)
				{
					this.caspModelControl_0.meshgroupCombo.SelectedItem = @class;
				}
				else if (@class.Entry.msIndex == 3 && lod_1 == Lod.Low)
				{
					this.caspModelControl_0.meshgroupCombo.SelectedItem = @class;
				}
			}
			this.caspModelControl_0.FatThinTrackBar.Value = 0;
			this.caspModelControl_0.FitTrackbar.Value = 50;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x000651D0 File Offset: 0x000633D0
		public List<Lod> GetLodLevels()
		{
			return this.list_0;
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x000054F4 File Offset: 0x000036F4
		public void ImportPackage(object object_0)
		{
			MessageBox.Show("Import of .package has not been implemented for this type of project yet.");
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x000651E8 File Offset: 0x000633E8
		public unsafe object ExportPackage()
		{
			if (string.IsNullOrEmpty(this.Title))
			{
				throw new Exception("Title can not be empty.");
			}
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
				png.Image = (this.method_30(this.Renderable.CurrentPreset) as Bitmap);
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
				"_casp_",
				DateTime.Now.ToFileTime()
			});
			string text2 = "0x" + Class132.mainForm.CreateGuid(this.Title + "_" + text).Replace("-", "").ToLower();
			text = text2;
			this.packageDescriptor_0.Thumbnail = png.GenerateResKey().Replace("key:", "");
			this.packageDescriptor_0.Id = text;
			this.packageDescriptor_0.Manifest.Remove("packagesubtype");
			this.packageDescriptor_0.Manifest.Add("packagesubtype", this.casp_0.clothingType.ToString("X8"));
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
			dbpf.ContentType = "CASPart";
			for (int i = 0; i < this.casp_0.Documents.Count; i++)
			{
				PNG png2 = this.project.Package.GetEntry(new ResKey(DBPFType.PNG_PREVIEW, i + 1, this.casp_0.InstanceID, this.casp_0.SecondInstanceID)) as PNG;
				if (png2 != null)
				{
					dbpf.AddEntry(png2);
				}
			}
			int num = 1;
			foreach (Class104.Class110 @class in this.Renderable.Containers)
			{
				TSRModel tsrmodel = new TSRModel();
				foreach (Class104.Class109 class2 in @class.Items)
				{
					int count = tsrmodel.Vertices.Count;
					DataStream dataStream = class2.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
					DataStream dataStream2 = class2.IndexBuffer.Lock(0, 0, LockFlags.None);
					Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
					short* ptr2 = (short*)((void*)dataStream2.DataPointer);
					for (int j = 0; j < class2.VertexCount; j++)
					{
						Class112.Struct7 @struct = ptr[j];
						TSRModel.TSRModelVertex tsrmodelVertex = new TSRModel.TSRModelVertex();
						tsrmodelVertex.PositionX = @struct.position.X;
						tsrmodelVertex.PositionY = @struct.position.Y;
						tsrmodelVertex.PositionZ = @struct.position.Z;
						tsrmodelVertex.NormalX = @struct.normal.X;
						tsrmodelVertex.NormalY = @struct.normal.Y;
						tsrmodelVertex.NormalZ = @struct.normal.Z;
						tsrmodelVertex.TextureX = @struct.vector2_0.X;
						tsrmodelVertex.TextureY = @struct.vector2_0.Y;
						tsrmodel.Vertices.Add(tsrmodelVertex);
					}
					for (int k = 0; k < class2.IBUFCount; k++)
					{
						short num2 = ptr2[k];
						tsrmodel.Indicies.Add((ushort)((int)num2 + count));
					}
					class2.IndexBuffer.Unlock();
					class2.VertexBufferTransformed.Unlock();
				}
				DataStream dataStream3 = BaseTexture.ToStream(@class.FinalTexture, ImageFileFormat.Bmp);
				Bitmap bitmap = new Bitmap(dataStream3);
				Bitmap bitmap2 = new Bitmap(bitmap.Width / 4, bitmap.Height / 4);
				Graphics.FromImage(bitmap2).DrawImage(bitmap, 0, 0, bitmap.Width / 4, bitmap.Height / 4);
				DDS dds = new DDS();
				dds.AddImage(bitmap2, false, DDS.DXTFormat.DXT5);
				tsrmodel.BitmapData = dds.GetData();
				tsrmodel.BitmapWidth = bitmap.Width / 4;
				tsrmodel.BitmapHeight = bitmap.Height / 4;
				bitmap.Dispose();
				bitmap2.Dispose();
				dataStream3.Dispose();
				tsrmodel.InstanceID = (tsrmodel.SecondInstanceID = (tsrmodel.GroupID = num));
				num++;
			}
			return dbpf;
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00065904 File Offset: 0x00063B04
		public object ExportSims3Pack()
		{
			DBPF dbpf = this.Sims3WorkshopSDK.Interfaces.IProjectModel.ExportPackage() as DBPF;
			Sims3Package sims3Package = new Sims3Package();
			sims3Package.DisplayName = this.Title;
			sims3Package.Description = "";
			sims3Package.Type = "CASpart";
			sims3Package.PackageId = dbpf.Guid.Replace("-", "").ToLower();
			sims3Package.SubType = this.casp_0.clothingType.ToString("X8");
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaObjects.ContainsKey("localizedStrings"))
			{
				string[] array = new string[23];
				STBL.Locales.Keys.CopyTo(array, 0);
				Dictionary<string, Dictionary<string, string>> dictionary = (Dictionary<string, Dictionary<string, string>>)this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaObjects["localizedStrings"];
				if (dictionary.ContainsKey("Title"))
				{
					for (int i = 0; i < 23; i++)
					{
						sims3Package.LocalizedNames.Add(new LocalizedString(dictionary["Title"].ContainsKey(array[i]) ? dictionary["Title"][array[i]] : this.Title, array[i]));
					}
				}
			}
			else
			{
				sims3Package.LocalizedNames.Add(new LocalizedString(this.Title));
				sims3Package.LocalizedDescriptions.Add(new LocalizedString(""));
			}
			sims3Package.Dependencies.Add("0x050cffe800000000050cffe800000000");
			sims3Package.AddFile(dbpf);
			return sims3Package;
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool HasSlots()
		{
			return false;
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00002A71 File Offset: 0x00000C71
		public void SetSlotsVisible(bool bool_0)
		{
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool HasRig()
		{
			return false;
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00002A71 File Offset: 0x00000C71
		public void SetRigVisible(bool bool_0)
		{
		}

		// Token: 0x040005E9 RID: 1513
		private WorkshopProject project;

		// Token: 0x040005EA RID: 1514
		private CASP casp_0;

		// Token: 0x040005EB RID: 1515
		private PackageDescriptor packageDescriptor_0;

		// Token: 0x040005EC RID: 1516
		private CaspModelControl caspModelControl_0;

		// Token: 0x040005ED RID: 1517
		public Lod lod_0;

		// Token: 0x040005EE RID: 1518
		private List<Lod> list_0;

		// Token: 0x040005EF RID: 1519
		private Image image_0;

		// Token: 0x040005F0 RID: 1520
		private XmlDocument xmlDocument_0;

		// Token: 0x040005F1 RID: 1521
		[PropertyFeel("button")]
		private string string_0;

		// Token: 0x040005F2 RID: 1522
		[PropertyFeel("button")]
		private string string_1;

		// Token: 0x040005F3 RID: 1523
		[PropertyFeel("button")]
		private string string_2;

		// Token: 0x040005F4 RID: 1524
		private string string_3;

		// Token: 0x040005F5 RID: 1525
		private string string_4;

		// Token: 0x040005F6 RID: 1526
		private int int_0 = 5000;

		// Token: 0x040005F7 RID: 1527
		private Class104.Class109 class109_0;

		// Token: 0x040005F8 RID: 1528
		private Class17 class17_0;

		// Token: 0x040005F9 RID: 1529
		[CompilerGenerated]
		private Class104 class104_0;

		// Token: 0x040005FA RID: 1530
		[CompilerGenerated]
		private Age age_0;

		// Token: 0x040005FB RID: 1531
		[CompilerGenerated]
		private CASP.ClothingType clothingType_0;

		// Token: 0x040005FC RID: 1532
		[CompilerGenerated]
		private CASP.Type type_0;

		// Token: 0x040005FD RID: 1533
		[CompilerGenerated]
		private CASP.ClothingCategory clothingCategory_0;

		// Token: 0x040005FE RID: 1534
		[CompilerGenerated]
		private Gender gender_0;

		// Token: 0x040005FF RID: 1535
		[CompilerGenerated]
		private Enum12 enum12_0;

		// Token: 0x04000600 RID: 1536
		[CompilerGenerated]
		private Enum11 enum11_0;

		// Token: 0x020000A5 RID: 165
		// (Invoke) Token: 0x060006A0 RID: 1696
		private delegate void Delegate17(Class81 item);
	}
}
