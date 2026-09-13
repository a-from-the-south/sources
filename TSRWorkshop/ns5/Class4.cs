using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns8;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using VisualHint.SmartPropertyGrid;

namespace ns5
{
	// Token: 0x02000055 RID: 85
	internal sealed class Class4 : Class2
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600033A RID: 826 RVA: 0x0003C06C File Offset: 0x0003A26C
		// (set) Token: 0x0600033B RID: 827 RVA: 0x00003CCE File Offset: 0x00001ECE
		public Class4.Class46 Wrapper { get; set; }

		// Token: 0x0600033C RID: 828 RVA: 0x00003CD9 File Offset: 0x00001ED9
		public Class4()
		{
			base.PropertyChanged += this.Class4_PropertyChanged;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0003C084 File Offset: 0x0003A284
		public void method_9(BuildItem buildItem_0)
		{
			base.Clear();
			this.Wrapper = new Class4.Class46(buildItem_0);
			PropertyEnumerator propertyEnumerator = base.AppendRootCategory(0, "Builditem settings");
			base.AppendProperty(propertyEnumerator, 1, "Name", this.Wrapper, "Title", "Title of object");
			base.AppendProperty(propertyEnumerator, 2, "Description", this.Wrapper, "Description", "Title of object");
			base.AppendProperty(propertyEnumerator, 3, "Price", this.Wrapper, "Price", "Price of object");
			PropertyEnumerator underCategory = propertyEnumerator;
			int id = 4;
			int num = 5;
			PropertyEnumerator propertyEnumerator2 = base.AppendProperty(underCategory, id, "Launcher thumbnail", this.Wrapper, "LauncherThumbnail", "Thumbnail image used in game launcher");
			propertyEnumerator2.Property.Tag = "_launcherThumbnail";
			if (buildItem_0 is FENCE)
			{
				base.AppendProperty(propertyEnumerator, num++, "Raise Above Wall", buildItem_0 as FENCE, "RaiseFenceGeometryAboveWall", "Raise above wall");
				base.AppendProperty(propertyEnumerator, num++, "Wall TGI", buildItem_0 as FENCE, "WallTGI", "WallTGI");
			}
			if (buildItem_0 is TerrainPaint)
			{
				if ((buildItem_0 as TerrainPaint).Version >= 4U)
				{
					base.AppendProperty(propertyEnumerator, num++, "Terrain Type", buildItem_0 as TerrainPaint, "TerrainType", "Terrain paint type");
					base.AppendProperty(propertyEnumerator, num++, "Category", buildItem_0 as TerrainPaint, "Category", "Terrain paint category");
				}
				base.AppendProperty(propertyEnumerator, num++, "Normal Operation", buildItem_0 as TerrainPaint, "NormalOperation", "Normal Operation");
				base.AppendProperty(propertyEnumerator, num++, "OppositeOperation", buildItem_0 as TerrainPaint, "OppositeOperation", "Opposite Operation");
				base.AppendProperty(propertyEnumerator, num++, "Orientation", buildItem_0 as TerrainPaint, "Orientation", "Orientation");
				base.AppendProperty(propertyEnumerator, num++, "BrushWidth", buildItem_0 as TerrainPaint, "BrushWidth", "BrushWidth");
				base.AppendProperty(propertyEnumerator, num++, "BrushStrength", buildItem_0 as TerrainPaint, "BrushStrength", "BrushStrength");
				base.AppendProperty(propertyEnumerator, num++, "WiggleAmount", buildItem_0 as TerrainPaint, "WiggleAmount", "WiggleAmount");
				base.AppendProperty(propertyEnumerator, num++, "BaseTextureValue", buildItem_0 as TerrainPaint, "BaseTextureValue", "BaseTextureValue");
				PropertyEnumerator underCategory2 = base.AppendRootCategory(0, "Textures");
				TextureResKey textureResKey = new TextureResKey((buildItem_0 as TerrainPaint).BrushTGI.AsString());
				textureResKey.GroupId = (buildItem_0 as TerrainPaint).GroupID;
				PropertyEnumerator propertyEnumerator3 = base.AppendManagedProperty(underCategory2, 1, "Texture", typeof(TextureResKey), textureResKey, "The texture to use");
				Class61 @class = new Class61();
				propertyEnumerator3.Property.Value.Look = @class;
				propertyEnumerator3.Property.Tag = (buildItem_0 as TerrainPaint).BrushTGI;
				@class.PropertyChanged += this.method_11;
			}
			if (buildItem_0.Version >= 10U && buildItem_0 is FENCE)
			{
				base.AppendProperty(propertyEnumerator, num++, "ShouldNotGetThickSnow", this.Wrapper, "ShouldNotGetThickSnow", "ShouldNotGetThickSnow");
				base.AppendProperty(propertyEnumerator, num++, "SnowPostShapeIsCircle", this.Wrapper, "SnowPostShapeIsCircle", "SnowPostShapeIsCircle");
				base.AppendProperty(propertyEnumerator, num++, "SnowThicknessPostScaleFactor", this.Wrapper, "SnowThicknessPostScaleFactor", "SnowThicknessPostScaleFactor");
				base.AppendProperty(propertyEnumerator, num++, "SnowThicknessRailScaleFactor", this.Wrapper, "SnowThicknessRailScaleFactor", "SnowThicknessRailScaleFactor");
				base.AppendProperty(propertyEnumerator, num++, "SnowThicknessPostVerticalOffset", this.Wrapper, "SnowThicknessPostVerticalOffset", "SnowThicknessPostVerticalOffset");
				base.AppendProperty(propertyEnumerator, num++, "SnowThicknessRailVerticalOffset", this.Wrapper, "SnowThicknessRailVerticalOffset", "SnowThicknessRailVerticalOffset");
			}
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0003C45C File Offset: 0x0003A65C
		private void method_10(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
		{
			propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.SetValue(resKey_0);
			TGIIndex tgiindex = propertyButtonClickedEventArgs_0.PropertyEnum.Property.Tag as TGIIndex;
			tgiindex.Reskey = resKey_0.AsString();
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0003C45C File Offset: 0x0003A65C
		private void method_11(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
		{
			propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.SetValue(resKey_0);
			TGIIndex tgiindex = propertyButtonClickedEventArgs_0.PropertyEnum.Property.Tag as TGIIndex;
			tgiindex.Reskey = resKey_0.AsString();
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00002A71 File Offset: 0x00000C71
		private void Class4_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
		}

		// Token: 0x04000300 RID: 768
		[CompilerGenerated]
		private Class4.Class46 class46_0;

		// Token: 0x02000056 RID: 86
		public sealed class Class46
		{
			// Token: 0x17000075 RID: 117
			// (get) Token: 0x06000341 RID: 833 RVA: 0x0003C4A4 File Offset: 0x0003A6A4
			public PackageDescriptor PackageDescriptor
			{
				get
				{
					return this.packageDescriptor_0;
				}
			}

			// Token: 0x06000342 RID: 834 RVA: 0x0003C4BC File Offset: 0x0003A6BC
			public Class46(BuildItem buildItem)
			{
				this.buildItem = buildItem;
				List<ResKey> list = Class132.mainForm.CurrentProject.Package.SearchEntries(new ResKey(DBPFType.PACKDESC));
				if (list.Count == 0)
				{
					this.packageDescriptor_0 = new PackageDescriptor();
					this.packageDescriptor_0.Manifest.Add("version", 3);
					this.packageDescriptor_0.Manifest.Add("packagetype", "object");
					this.packageDescriptor_0.Manifest.Add("true", "false");
					Class132.mainForm.CurrentProject.Package.AddEntry(this.packageDescriptor_0);
				}
				else
				{
					this.packageDescriptor_0 = (Class132.mainForm.CurrentProject.Package.GetEntry(list[0]) as PackageDescriptor);
				}
				if (Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("launcherThumbnail"))
				{
					string key = Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["launcherThumbnail"];
					PNG png = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(key)) as PNG;
					this.LauncherThumbnail = png.Image;
				}
			}

			// Token: 0x17000076 RID: 118
			// (get) Token: 0x06000343 RID: 835 RVA: 0x0003C5FC File Offset: 0x0003A7FC
			// (set) Token: 0x06000344 RID: 836 RVA: 0x0003C65C File Offset: 0x0003A85C
			[PropertyFeel("button")]
			public string Title
			{
				get
				{
					string result;
					if (this.buildItem.CatalogNameEntry.IndexOf("Name:") == -1)
					{
						result = this.buildItem.CatalogNameEntry;
					}
					else
					{
						result = this.buildItem.CatalogNameEntry.Substring(this.buildItem.CatalogNameEntry.IndexOf("Name:") + 5);
					}
					return result;
				}
				set
				{
					string text = value;
					if (text.Length > 240)
					{
						text = text.Substring(0, 240);
					}
					if (this.buildItem.CatalogNameEntry.IndexOf("Name:") != -1)
					{
						this.buildItem.CatalogNameEntry = this.buildItem.CatalogNameEntry.Substring(0, this.buildItem.CatalogNameEntry.IndexOf("Name:") + 5) + text;
					}
					else
					{
						this.buildItem.CatalogNameEntry = text;
					}
					if (this.packageDescriptor_0 != null)
					{
						this.packageDescriptor_0.Title = text;
					}
				}
			}

			// Token: 0x17000077 RID: 119
			// (get) Token: 0x06000345 RID: 837 RVA: 0x0003C6FC File Offset: 0x0003A8FC
			// (set) Token: 0x06000346 RID: 838 RVA: 0x0003C75C File Offset: 0x0003A95C
			[PropertyFeel("button")]
			[PropertyHeightMultiplier(3)]
			[PropertyLook(typeof(PropertyMultilineEditLook))]
			public string Description
			{
				get
				{
					string result;
					if (this.buildItem.CatalogDescEntry.IndexOf("Description:") == -1)
					{
						result = this.buildItem.CatalogDescEntry;
					}
					else
					{
						result = this.buildItem.CatalogDescEntry.Substring(this.buildItem.CatalogDescEntry.IndexOf("Description:") + 12);
					}
					return result;
				}
				set
				{
					string text = value;
					if (text.Length >= 240)
					{
						text = text.Substring(0, 240);
					}
					this.buildItem.CatalogDescEntry = text;
					if (this.packageDescriptor_0 != null)
					{
						this.packageDescriptor_0.Description = text;
					}
				}
			}

			// Token: 0x17000078 RID: 120
			// (get) Token: 0x06000347 RID: 839 RVA: 0x0003C7A8 File Offset: 0x0003A9A8
			// (set) Token: 0x06000348 RID: 840 RVA: 0x00003CF5 File Offset: 0x00001EF5
			public float Price
			{
				get
				{
					return this.buildItem.Price;
				}
				set
				{
					this.buildItem.Price = value;
				}
			}

			// Token: 0x17000079 RID: 121
			// (get) Token: 0x06000349 RID: 841 RVA: 0x0003C7C4 File Offset: 0x0003A9C4
			// (set) Token: 0x0600034A RID: 842 RVA: 0x00003D05 File Offset: 0x00001F05
			public Image LauncherThumbnail { get; set; }

			// Token: 0x1700007A RID: 122
			// (get) Token: 0x0600034B RID: 843 RVA: 0x0003C7DC File Offset: 0x0003A9DC
			// (set) Token: 0x0600034C RID: 844 RVA: 0x00003D10 File Offset: 0x00001F10
			public byte ShouldNotGetThickSnow
			{
				get
				{
					return (this.buildItem as FENCE).ShouldNotGetThickSnow;
				}
				set
				{
					(this.buildItem as FENCE).ShouldNotGetThickSnow = value;
				}
			}

			// Token: 0x1700007B RID: 123
			// (get) Token: 0x0600034D RID: 845 RVA: 0x0003C800 File Offset: 0x0003AA00
			// (set) Token: 0x0600034E RID: 846 RVA: 0x00003D25 File Offset: 0x00001F25
			public byte SnowPostShapeIsCircle
			{
				get
				{
					return (this.buildItem as FENCE).SnowPostShapeIsCircle;
				}
				set
				{
					(this.buildItem as FENCE).SnowPostShapeIsCircle = value;
				}
			}

			// Token: 0x1700007C RID: 124
			// (get) Token: 0x0600034F RID: 847 RVA: 0x0003C824 File Offset: 0x0003AA24
			// (set) Token: 0x06000350 RID: 848 RVA: 0x00003D3A File Offset: 0x00001F3A
			public float SnowThicknessPostScaleFactor
			{
				get
				{
					return (this.buildItem as FENCE).SnowThicknessPostScaleFactor;
				}
				set
				{
					(this.buildItem as FENCE).SnowThicknessPostScaleFactor = value;
				}
			}

			// Token: 0x1700007D RID: 125
			// (get) Token: 0x06000351 RID: 849 RVA: 0x0003C848 File Offset: 0x0003AA48
			// (set) Token: 0x06000352 RID: 850 RVA: 0x00003D4F File Offset: 0x00001F4F
			public float SnowThicknessRailScaleFactor
			{
				get
				{
					return (this.buildItem as FENCE).SnowThicknessRailScaleFactor;
				}
				set
				{
					(this.buildItem as FENCE).SnowThicknessRailScaleFactor = value;
				}
			}

			// Token: 0x1700007E RID: 126
			// (get) Token: 0x06000353 RID: 851 RVA: 0x0003C86C File Offset: 0x0003AA6C
			// (set) Token: 0x06000354 RID: 852 RVA: 0x00003D64 File Offset: 0x00001F64
			public float SnowThicknessPostVerticalOffset
			{
				get
				{
					return (this.buildItem as FENCE).SnowThicknessPostVerticalOffset;
				}
				set
				{
					(this.buildItem as FENCE).SnowThicknessPostVerticalOffset = value;
				}
			}

			// Token: 0x1700007F RID: 127
			// (get) Token: 0x06000355 RID: 853 RVA: 0x0003C890 File Offset: 0x0003AA90
			// (set) Token: 0x06000356 RID: 854 RVA: 0x00003D79 File Offset: 0x00001F79
			public float SnowThicknessRailVerticalOffset
			{
				get
				{
					return (this.buildItem as FENCE).SnowThicknessRailVerticalOffset;
				}
				set
				{
					(this.buildItem as FENCE).SnowThicknessRailVerticalOffset = value;
				}
			}

			// Token: 0x04000301 RID: 769
			private BuildItem buildItem;

			// Token: 0x04000302 RID: 770
			private PackageDescriptor packageDescriptor_0;

			// Token: 0x04000303 RID: 771
			[CompilerGenerated]
			private Image image_0;
		}
	}
}
