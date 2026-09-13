using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns1;
using ns14;
using ns16;
using ns17;
using ns18;
using ns20;
using ns21;
using ns3;
using ns5;
using ns6;
using ns7;
using ns8;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using Skybound.VisualTips;
using SlimDX;
using SplitButtonDemo;
using VisualHint.SmartPropertyGrid;

namespace ns10
{
	// Token: 0x02000057 RID: 87
	internal sealed class CaspModelControl : UserControl
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000357 RID: 855 RVA: 0x0003C8B4 File Offset: 0x0003AAB4
		public Class10 CaspPropertyGrid
		{
			get
			{
				return this.caspPropertyGrid;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000358 RID: 856 RVA: 0x0003C8CC File Offset: 0x0003AACC
		public Class8 PresetPropertyGrid
		{
			get
			{
				return this.presetPropertyGrid;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000359 RID: 857 RVA: 0x0003C8E4 File Offset: 0x0003AAE4
		public ComboBox PresetComboBox
		{
			get
			{
				return this.VariationCombo;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600035A RID: 858 RVA: 0x0003C8FC File Offset: 0x0003AAFC
		public CheckBox AdvancedMode
		{
			get
			{
				return this.advanced;
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0003C914 File Offset: 0x0003AB14
		public CaspModelControl(Class68 projectModel)
		{
			this.projectModel = projectModel;
			this.InitializeComponent();
			Class140.smethod_0().method_28("g_fatAmount", 0f);
			Class140.smethod_0().method_28("g_thinAmount", 0f);
			Class140.smethod_0().method_28("g_fitAmount", 0.5f);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0003C974 File Offset: 0x0003AB74
		private void VariationCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.VariationCombo.SelectedItem != null)
			{
				Class81 @class = this.VariationCombo.SelectedItem as Class81;
				if (@class.Data.GetType().Equals(typeof(XmlDocument)))
				{
					Class132.smethod_0().method_1(@class.Data as XmlDocument);
				}
				else if (@class.Data.GetType().Equals(typeof(TXTC)))
				{
					Class132.smethod_0().method_1(null);
				}
			}
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00003D8E File Offset: 0x00001F8E
		public void method_0(bool bool_0)
		{
			this.deleteMenuItem.Enabled = bool_0;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00002A71 File Offset: 0x00000C71
		private void contextMenuStrip1_1_Opening(object sender, CancelEventArgs e)
		{
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0003CA00 File Offset: 0x0003AC00
		private void resetToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			object value = this.presetPropertyGrid.SelectedPropertyEnumerator.Property.Value.GetValue();
			if (value.GetType().Equals(typeof(TextureResKey)))
			{
				Attribute attribute = this.presetPropertyGrid.SelectedPropertyEnumerator.Property.Value.GetAttribute(typeof(DefaultValueAttribute));
				object value2 = ((DefaultValueAttribute)attribute).Value;
				if (Class132.mainForm.CurrentProject.Package.HasEntry(value as ResKey))
				{
					DialogResult dialogResult = MessageBox.Show("A new texture has been created and added to the project when this property was changed.\n\nDo you want to remove the file from project after reset?\n\n", "Reset", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Cancel)
					{
						return;
					}
					if (dialogResult == DialogResult.Yes)
					{
						Class132.mainForm.CurrentProject.Package.RemoveEntry(value as TextureResKey);
					}
				}
			}
			this.presetPropertyGrid.SelectedPropertyEnumerator.Property.Value.ResetToDefaultValue();
			this.presetPropertyGrid.NotifyPropertyChanged(new VisualHint.SmartPropertyGrid.PropertyChangedEventArgs(this.presetPropertyGrid.SelectedPropertyEnumerator));
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0003CB00 File Offset: 0x0003AD00
		private void deleteMenuItem_Click(object sender, EventArgs e)
		{
			if (this.projectModel.Casp.Documents.Count < 2)
			{
				MessageBox.Show("You must have at least one variant.");
			}
			else if (MessageBox.Show(this, "Are you sure you want to delete this variation?", "Remove variation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Class81 @class = this.VariationCombo.SelectedItem as Class81;
				this.VariationCombo.Items.Remove(this.VariationCombo.SelectedItem);
				for (int i = 0; i < this.projectModel.Casp.Documents.Count; i++)
				{
					XmlDocument xmlDocument = this.projectModel.Casp.Documents[i];
					if (xmlDocument == @class.Data)
					{
						this.projectModel.Casp.Documents.RemoveAt(i);
						i--;
						if (i < 0)
						{
							i = 0;
						}
						this.VariationCombo.SelectedIndex = i;
						if (this.VariationCombo.Items.Count < 2)
						{
							this.deleteMenuItem.Enabled = false;
						}
						IL_FE:
						Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
						return;
					}
				}
				goto IL_FE;
			}
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0003CC20 File Offset: 0x0003AE20
		private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Class81 @class = this.VariationCombo.SelectedItem as Class81;
			if (@class.Data.GetType().Equals(typeof(XmlDocument)))
			{
				XmlDocument xmlDocument = (XmlDocument)(@class.Data as XmlDocument).Clone();
				XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/preset/complate/value[@cloneDefault]");
				if (xmlNodeList.Count > 0 && MessageBox.Show(Class132.mainForm, "You have made changes to this variation, do you want to keep them on the duplicate?", "Texture has changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					foreach (object obj in xmlNodeList)
					{
						XmlNode xmlNode = (XmlNode)obj;
						if (xmlNode.Name.ToLower().Equals("value"))
						{
							(xmlNode as XmlElement).SetAttribute("value", (xmlNode as XmlElement).GetAttribute("cloneDefault"));
							(xmlNode as XmlElement).RemoveAttribute("cloneDefault");
						}
					}
				}
				Class81 item = new Class81(xmlDocument, false);
				this.VariationCombo.Items.Add(item);
				this.projectModel.Casp.Documents.Add(xmlDocument);
				this.VariationCombo.SelectedIndex = this.VariationCombo.Items.Count - 1;
				this.deleteMenuItem.Enabled = true;
				Class132.mainForm.SetStatus("Variation duplicated");
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			}
			else
			{
				MessageBox.Show("Can not clone default properties");
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0003CDC0 File Offset: 0x0003AFC0
		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			object value = this.presetPropertyGrid.SelectedPropertyEnumerator.Property.Value.GetValue();
			object tag = this.presetPropertyGrid.SelectedPropertyEnumerator.Property.Tag;
			object tag2 = this.presetPropertyGrid.SelectedPropertyEnumerator.Property.Value.Tag;
			XmlElement ownerElement = (tag2 as XmlAttribute).OwnerElement;
			string attribute = ownerElement.GetAttribute("key");
			if (ownerElement.Name.ToLower().Equals("value"))
			{
				foreach (object obj in this.VariationCombo.Items)
				{
					Class81 @class = (Class81)obj;
					if (@class.Data.GetType().Equals(typeof(XmlDocument)))
					{
						XmlDocument xmlDocument = @class.Data as XmlDocument;
						string xpath = string.Concat(new string[]
						{
							"/preset/complate/",
							ownerElement.ParentNode.Name.ToLower().Equals("pattern") ? ("pattern[@variable='" + (ownerElement.ParentNode as XmlElement).GetAttribute("variable") + "']/") : "",
							"value[@key='",
							attribute,
							"']"
						});
						XmlNodeList xmlNodeList = xmlDocument.SelectNodes(xpath);
						value.ToString();
						if (xmlNodeList.Count > 0 && !xmlNodeList.Item(0).Equals(ownerElement))
						{
							if (xmlNodeList.Item(0).Attributes.GetNamedItem("cloneDefault") == null)
							{
								xmlNodeList.Item(0).Attributes.Append(xmlDocument.CreateAttribute("cloneDefault", (xmlNodeList.Item(0) as XmlElement).GetAttribute("value")));
							}
							(xmlNodeList.Item(0) as XmlElement).SetAttribute("value", this.presetPropertyGrid.method_6(value));
						}
					}
				}
			}
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0003D004 File Offset: 0x0003B204
		private void FatThinTrackBar_Scroll(object sender, EventArgs e)
		{
			float float_ = 0f;
			float float_2 = 0f;
			if (this.FatThinTrackBar.Value < 0)
			{
				float_2 = (float)Math.Abs(this.FatThinTrackBar.Value) / 100f;
			}
			if (this.FatThinTrackBar.Value > 0)
			{
				float_ = (float)Math.Abs(this.FatThinTrackBar.Value) / 100f;
			}
			this.projectModel.Renderable.method_14(float_);
			this.projectModel.Renderable.method_16(float_2);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0003D090 File Offset: 0x0003B290
		private void FitTrackbar_Scroll(object sender, EventArgs e)
		{
			float float_ = (float)Math.Abs(this.FitTrackbar.Value) / 100f;
			this.projectModel.Renderable.method_15(float_);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00002A71 File Offset: 0x00000C71
		private void advanced_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0003D0C8 File Offset: 0x0003B2C8
		private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int num = this.VariationCombo.SelectedIndex;
			int num2 = num;
			num--;
			if (num > -1)
			{
				this.VariationCombo.Items.Insert(num, this.VariationCombo.SelectedItem);
				this.VariationCombo.Items.RemoveAt(num2 + 1);
				this.VariationCombo.SelectedIndex = num;
			}
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0003D128 File Offset: 0x0003B328
		private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int num = this.VariationCombo.SelectedIndex;
			int index = num;
			num++;
			if (num < this.VariationCombo.Items.Count)
			{
				this.VariationCombo.Items.Insert(index, this.VariationCombo.Items[num]);
				this.VariationCombo.Items.RemoveAt(num + 1);
				this.VariationCombo.SelectedIndex = num;
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0003D1A0 File Offset: 0x0003B3A0
		private void button1_Click(object sender, EventArgs e)
		{
			Class67 @class = this.meshgroupCombo.SelectedItem as Class67;
			if (@class != null)
			{
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
				object[] array;
				if (!flag)
				{
					array = new object[@class.Entry.index.Count];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = new object[]
						{
							"Group " + i,
							i
						};
					}
				}
				else
				{
					CASP casp = this.projectModel.Casp;
					array = new object[]
					{
						new object[]
						{
							"Base",
							""
						},
						new object[]
						{
							"Fat",
							casp.igtIndex[(int)casp.blendFatRef]
						},
						new object[]
						{
							"Thin",
							casp.igtIndex[(int)casp.blendThinRef]
						},
						new object[]
						{
							"Fit",
							casp.igtIndex[(int)casp.blendFitRef]
						},
						new object[]
						{
							"Special",
							casp.igtIndex[(int)casp.blendSpecialRef]
						}
					};
				}
				AutoBoneAssigment autoBoneAssigment = new AutoBoneAssigment(array, flag);
				if (autoBoneAssigment.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					CaspModelControl.Class47 class2 = new CaspModelControl.Class47();
					class2.Wrapper = @class;
					class2.InterpolationLevel = autoBoneAssigment.InterpolationLevel;
					class2.AutoBoneAssignmentWindow = autoBoneAssigment;
					GeneralProgress.Class93 class3 = GeneralProgress.smethod_0("Assigning bones");
					class3.ProgressForm.FormClosed += this.method_3;
					class3.DoWork += class2.method_0;
					class3.RunWorkerCompleted += this.method_2;
					class3.Disposed += this.method_1;
					class3.method_0();
				}
				MessageBox.Show("Done");
			}
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00002A71 File Offset: 0x00000C71
		private void method_1(object sender, EventArgs e)
		{
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00003D9E File Offset: 0x00001F9E
		private void method_2(object sender, RunWorkerCompletedEventArgs e)
		{
			((GeneralProgress.Class93)sender).method_1();
			this.projectModel.method_4();
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00002A71 File Offset: 0x00000C71
		private void method_3(object sender, FormClosedEventArgs e)
		{
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00003DB8 File Offset: 0x00001FB8
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0003D4A0 File Offset: 0x0003B6A0
		private void InitializeComponent()
		{
			this.icontainer_0 = new Container();
			Class161 @class = new Class161();
			Class161 class2 = new Class161();
			Class161 class3 = new Class161();
			Class161 class4 = new Class161();
			Class161 class5 = new Class161();
			Class157 renderer = new Class157();
			this.selectPresetPanel = new Panel();
			this.splitButton1 = new SplitButton();
			this.contextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
			this.deleteMenuItem = new ToolStripMenuItem();
			this.duplicateToolStripMenuItem = new ToolStripMenuItem();
			this.exportToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.moveUpToolStripMenuItem = new ToolStripMenuItem();
			this.moveDownToolStripMenuItem = new ToolStripMenuItem();
			this.advanced = new CheckBox();
			this.VariationCombo = new ComboBox();
			this.contextMenuStrip1_1 = new ContextMenuStrip(this.icontainer_0);
			this.toolStripMenuItem1 = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.resetToDefaultToolStripMenuItem = new ToolStripMenuItem();
			this.TabControl = new TabControl();
			this.attributesTab = new TabPage();
			this.panel2 = new Panel();
			this.caspPropertyGrid = new Class10();
			this.PresetsTab = new TabPage();
			this.presetPropertyGrid = new Class8();
			this.panel6 = new Panel();
			this.fourChannelsRadio = new RadioButton();
			this.threeChannelsRadio = new RadioButton();
			this.meshTab = new TabPage();
			this.panel1 = new Panel();
			this.MeshPropertyGrid = new Class2();
			this.panel3 = new Panel();
			this.meshgroupCombo = new ComboBox();
			this.panel4 = new Panel();
			this.importMeshgroupButton = new Button();
			this.exportMeshgroupButton = new Button();
			this.panel5 = new Panel();
			this.label5 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label1 = new Label();
			this.FitTrackbar = new TrackBar();
			this.FatThinTrackBar = new TrackBar();
			this.label2 = new Label();
			this.slotsTab = new TabPage();
			this.visualTipProvider_0 = new VisualTipProvider(this.icontainer_0);
			this.button1 = new Button();
			this.selectPresetPanel.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.contextMenuStrip1_1.SuspendLayout();
			this.TabControl.SuspendLayout();
			this.attributesTab.SuspendLayout();
			this.panel2.SuspendLayout();
			((ISupportInitialize)this.caspPropertyGrid).BeginInit();
			this.PresetsTab.SuspendLayout();
			((ISupportInitialize)this.presetPropertyGrid).BeginInit();
			this.panel6.SuspendLayout();
			this.meshTab.SuspendLayout();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.MeshPropertyGrid).BeginInit();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			((ISupportInitialize)this.FitTrackbar).BeginInit();
			((ISupportInitialize)this.FatThinTrackBar).BeginInit();
			base.SuspendLayout();
			this.selectPresetPanel.BackColor = Color.Transparent;
			this.selectPresetPanel.Controls.Add(this.splitButton1);
			this.selectPresetPanel.Controls.Add(this.advanced);
			this.selectPresetPanel.Controls.Add(this.VariationCombo);
			this.selectPresetPanel.Dock = DockStyle.Top;
			this.selectPresetPanel.Location = new Point(3, 3);
			this.selectPresetPanel.Name = "selectPresetPanel";
			this.selectPresetPanel.Size = new Size(348, 30);
			this.selectPresetPanel.TabIndex = 0;
			this.splitButton1.BackgroundImage = Class143._new;
			this.splitButton1.BackgroundImageLayout = ImageLayout.None;
			this.splitButton1.ClickedImage = "Clicked";
			this.splitButton1.ContextMenuStrip = this.contextMenuStrip1;
			this.splitButton1.DisabledImage = "Disabled";
			this.splitButton1.FocusedImage = "Focused";
			this.splitButton1.HoverImage = "Hover";
			this.splitButton1.ImageAlign = ContentAlignment.MiddleRight;
			this.splitButton1.ImageKey = "Normal";
			this.splitButton1.Location = new Point(303, 3);
			this.splitButton1.Name = "splitButton1";
			this.splitButton1.NormalImage = "Normal";
			this.splitButton1.Size = new Size(46, 24);
			this.splitButton1.TabIndex = 5;
			this.splitButton1.UseVisualStyleBackColor = true;
			this.contextMenuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.deleteMenuItem,
				this.duplicateToolStripMenuItem,
				this.exportToolStripMenuItem,
				this.toolStripSeparator2,
				this.moveUpToolStripMenuItem,
				this.moveDownToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new Size(138, 120);
			this.deleteMenuItem.Name = "deleteMenuItem";
			this.deleteMenuItem.Size = new Size(137, 22);
			this.deleteMenuItem.Text = "Delete";
			this.deleteMenuItem.Click += this.deleteMenuItem_Click;
			this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
			this.duplicateToolStripMenuItem.Size = new Size(137, 22);
			this.duplicateToolStripMenuItem.Text = "Duplicate";
			this.duplicateToolStripMenuItem.Click += this.duplicateToolStripMenuItem_Click;
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new Size(137, 22);
			this.exportToolStripMenuItem.Text = "Export";
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(134, 6);
			this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
			this.moveUpToolStripMenuItem.Size = new Size(137, 22);
			this.moveUpToolStripMenuItem.Text = "Move up";
			this.moveUpToolStripMenuItem.Click += this.moveUpToolStripMenuItem_Click;
			this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
			this.moveDownToolStripMenuItem.Size = new Size(137, 22);
			this.moveDownToolStripMenuItem.Text = "Move down";
			this.moveDownToolStripMenuItem.Click += this.moveDownToolStripMenuItem_Click;
			this.advanced.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.advanced.Appearance = Appearance.Button;
			this.advanced.AutoSize = true;
			this.advanced.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.advanced.Location = new Point(275, 3);
			this.advanced.Name = "advanced";
			this.advanced.Size = new Size(26, 24);
			this.advanced.TabIndex = 4;
			this.advanced.Text = "A";
			this.advanced.UseVisualStyleBackColor = true;
			@class.Text = "When checked additional properties might be displayed depending on the complate";
			@class.Title = "Advanced Mode";
			this.visualTipProvider_0.method_3(this.advanced, @class);
			this.advanced.CheckedChanged += this.advanced_CheckedChanged;
			this.VariationCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.VariationCombo.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.VariationCombo.FormattingEnabled = true;
			this.VariationCombo.ItemHeight = 14;
			this.VariationCombo.Location = new Point(0, 4);
			this.VariationCombo.Name = "VariationCombo";
			this.VariationCombo.Size = new Size(272, 22);
			this.VariationCombo.TabIndex = 0;
			class2.Text = "This item can have one or more variations. They are listed in this dropdown.";
			class2.Title = "Variations";
			this.visualTipProvider_0.method_3(this.VariationCombo, class2);
			this.VariationCombo.SelectedIndexChanged += this.VariationCombo_SelectedIndexChanged;
			this.contextMenuStrip1_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem1,
				this.toolStripSeparator1,
				this.resetToDefaultToolStripMenuItem
			});
			this.contextMenuStrip1_1.Name = "contextMenuStrip1";
			this.contextMenuStrip1_1.Size = new Size(172, 54);
			this.contextMenuStrip1_1.Opening += this.contextMenuStrip1_1_Opening;
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new Size(171, 22);
			this.toolStripMenuItem1.Text = "Copy to all presets";
			this.toolStripMenuItem1.Click += this.toolStripMenuItem1_Click;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(168, 6);
			this.resetToDefaultToolStripMenuItem.Name = "resetToDefaultToolStripMenuItem";
			this.resetToDefaultToolStripMenuItem.Size = new Size(171, 22);
			this.resetToDefaultToolStripMenuItem.Text = "Reset to default";
			this.resetToDefaultToolStripMenuItem.Click += this.resetToDefaultToolStripMenuItem_Click;
			this.TabControl.Controls.Add(this.attributesTab);
			this.TabControl.Controls.Add(this.PresetsTab);
			this.TabControl.Controls.Add(this.meshTab);
			this.TabControl.Controls.Add(this.slotsTab);
			this.TabControl.Dock = DockStyle.Fill;
			this.TabControl.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.TabControl.Location = new Point(0, 0);
			this.TabControl.Margin = new Padding(0);
			this.TabControl.Name = "TabControl";
			this.TabControl.SelectedIndex = 0;
			this.TabControl.Size = new Size(362, 353);
			this.TabControl.TabIndex = 1;
			this.attributesTab.Controls.Add(this.panel2);
			this.attributesTab.Location = new Point(4, 25);
			this.attributesTab.Name = "attributesTab";
			this.attributesTab.Padding = new Padding(3);
			this.attributesTab.Size = new Size(354, 324);
			this.attributesTab.TabIndex = 0;
			this.attributesTab.Text = "Project";
			this.attributesTab.UseVisualStyleBackColor = true;
			class3.Text = "In this tab you can set game came category, name and so on";
			this.visualTipProvider_0.method_3(this.attributesTab, class3);
			this.panel2.Controls.Add(this.caspPropertyGrid);
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Location = new Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(348, 318);
			this.panel2.TabIndex = 2;
			this.caspPropertyGrid.BorderStyle = BorderStyle.None;
			this.caspPropertyGrid.CommentsHeight = 50;
			this.caspPropertyGrid.CommentsVisibility = true;
			this.caspPropertyGrid.Dock = DockStyle.Fill;
			this.caspPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.caspPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.caspPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.caspPropertyGrid.Location = new Point(0, 0);
			this.caspPropertyGrid.Name = "caspPropertyGrid";
			this.caspPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.caspPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.caspPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.caspPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.caspPropertyGrid.ShowDefaultValues = true;
			this.caspPropertyGrid.Size = new Size(348, 318);
			this.caspPropertyGrid.TabIndex = 7;
			this.caspPropertyGrid.Text = "caspPropertyGrid1";
			this.caspPropertyGrid.ToolTipMode = VisualHint.SmartPropertyGrid.PropertyGrid.ToolTipModes.ToolTipsOnLabels;
			this.PresetsTab.BackColor = Color.White;
			this.PresetsTab.Controls.Add(this.presetPropertyGrid);
			this.PresetsTab.Controls.Add(this.panel6);
			this.PresetsTab.Controls.Add(this.selectPresetPanel);
			this.PresetsTab.Location = new Point(4, 25);
			this.PresetsTab.Name = "PresetsTab";
			this.PresetsTab.Padding = new Padding(3);
			this.PresetsTab.Size = new Size(354, 324);
			this.PresetsTab.TabIndex = 1;
			this.PresetsTab.Text = "Texture";
			this.PresetsTab.UseVisualStyleBackColor = true;
			class4.Title = "Change textures, colors and patterns";
			this.visualTipProvider_0.method_3(this.PresetsTab, class4);
			this.presetPropertyGrid.AdvancedMode = false;
			this.presetPropertyGrid.BorderStyle = BorderStyle.None;
			this.presetPropertyGrid.CommentsHeight = 50;
			this.presetPropertyGrid.CommentsVisibility = true;
			this.presetPropertyGrid.ContextMenuStrip = this.contextMenuStrip1_1;
			this.presetPropertyGrid.Dock = DockStyle.Fill;
			this.presetPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.presetPropertyGrid.FloorCategory = WALL.FloorCategory.Unknown;
			this.presetPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.presetPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.presetPropertyGrid.Location = new Point(3, 55);
			this.presetPropertyGrid.Name = "presetPropertyGrid";
			this.presetPropertyGrid.Preset = null;
			this.presetPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.presetPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.presetPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.presetPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.presetPropertyGrid.ShowDefaultValues = true;
			this.presetPropertyGrid.Size = new Size(348, 266);
			this.presetPropertyGrid.TabIndex = 0;
			this.presetPropertyGrid.Text = "presetPropertyGrid1";
			this.presetPropertyGrid.ToolTipMode = VisualHint.SmartPropertyGrid.PropertyGrid.ToolTipModes.ToolTipsOnLabels;
			this.presetPropertyGrid.WallCategory = WALL.WallCategory.Unknown;
			this.panel6.Controls.Add(this.fourChannelsRadio);
			this.panel6.Controls.Add(this.threeChannelsRadio);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(3, 33);
			this.panel6.Name = "panel6";
			this.panel6.Size = new Size(348, 22);
			this.panel6.TabIndex = 1;
			this.fourChannelsRadio.AutoSize = true;
			this.fourChannelsRadio.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.fourChannelsRadio.Location = new Point(102, -1);
			this.fourChannelsRadio.Name = "fourChannelsRadio";
			this.fourChannelsRadio.Size = new Size(89, 20);
			this.fourChannelsRadio.TabIndex = 1;
			this.fourChannelsRadio.TabStop = true;
			this.fourChannelsRadio.Text = "4 Channels";
			this.fourChannelsRadio.UseVisualStyleBackColor = true;
			this.threeChannelsRadio.AutoSize = true;
			this.threeChannelsRadio.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.threeChannelsRadio.Location = new Point(0, -1);
			this.threeChannelsRadio.Name = "threeChannelsRadio";
			this.threeChannelsRadio.Size = new Size(89, 20);
			this.threeChannelsRadio.TabIndex = 0;
			this.threeChannelsRadio.TabStop = true;
			this.threeChannelsRadio.Text = "3 Channels";
			this.threeChannelsRadio.UseVisualStyleBackColor = true;
			this.meshTab.Controls.Add(this.panel1);
			this.meshTab.Controls.Add(this.panel5);
			this.meshTab.Controls.Add(this.label2);
			this.meshTab.Location = new Point(4, 25);
			this.meshTab.Name = "meshTab";
			this.meshTab.Padding = new Padding(3);
			this.meshTab.Size = new Size(354, 324);
			this.meshTab.TabIndex = 2;
			this.meshTab.Text = "Mesh";
			this.meshTab.UseVisualStyleBackColor = true;
			class5.Text = "Work with the mesh (experimental)";
			this.visualTipProvider_0.method_3(this.meshTab, class5);
			this.panel1.Controls.Add(this.MeshPropertyGrid);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(348, 288);
			this.panel1.TabIndex = 4;
			this.MeshPropertyGrid.AdvancedMode = false;
			this.MeshPropertyGrid.BorderStyle = BorderStyle.None;
			this.MeshPropertyGrid.Dock = DockStyle.Fill;
			this.MeshPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.MeshPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.MeshPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.MeshPropertyGrid.Location = new Point(0, 30);
			this.MeshPropertyGrid.Name = "MeshPropertyGrid";
			this.MeshPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.MeshPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.MeshPropertyGrid.ReadOnlyForeColor = Color.SteelBlue;
			this.MeshPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.MeshPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.MeshPropertyGrid.Size = new Size(348, 258);
			this.MeshPropertyGrid.TabIndex = 8;
			this.MeshPropertyGrid.Text = "meshPropertyGrid1";
			this.panel3.BackColor = Color.Transparent;
			this.panel3.Controls.Add(this.meshgroupCombo);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new Padding(0, 2, 0, 2);
			this.panel3.Size = new Size(348, 30);
			this.panel3.TabIndex = 7;
			this.meshgroupCombo.Dock = DockStyle.Fill;
			this.meshgroupCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.meshgroupCombo.Font = new Font("Tahoma", 9.5f);
			this.meshgroupCombo.FormattingEnabled = true;
			this.meshgroupCombo.ItemHeight = 16;
			this.meshgroupCombo.Location = new Point(0, 2);
			this.meshgroupCombo.Name = "meshgroupCombo";
			this.meshgroupCombo.Size = new Size(258, 24);
			this.meshgroupCombo.TabIndex = 8;
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.importMeshgroupButton);
			this.panel4.Controls.Add(this.exportMeshgroupButton);
			this.panel4.Dock = DockStyle.Right;
			this.panel4.Location = new Point(258, 2);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(90, 26);
			this.panel4.TabIndex = 0;
			this.importMeshgroupButton.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.importMeshgroupButton.Image = Class143.import;
			this.importMeshgroupButton.Location = new Point(34, -1);
			this.importMeshgroupButton.Name = "importMeshgroupButton";
			this.importMeshgroupButton.Size = new Size(26, 26);
			this.importMeshgroupButton.TabIndex = 8;
			this.importMeshgroupButton.UseVisualStyleBackColor = true;
			this.exportMeshgroupButton.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.exportMeshgroupButton.Image = Class143.export;
			this.exportMeshgroupButton.Location = new Point(4, -1);
			this.exportMeshgroupButton.Name = "exportMeshgroupButton";
			this.exportMeshgroupButton.Size = new Size(26, 26);
			this.exportMeshgroupButton.TabIndex = 7;
			this.exportMeshgroupButton.UseVisualStyleBackColor = true;
			this.panel5.Controls.Add(this.label5);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Controls.Add(this.label1);
			this.panel5.Controls.Add(this.FitTrackbar);
			this.panel5.Controls.Add(this.FatThinTrackBar);
			this.panel5.Dock = DockStyle.Top;
			this.panel5.Location = new Point(3, 3);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(348, 30);
			this.panel5.TabIndex = 5;
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(330, 8);
			this.label5.Name = "label5";
			this.label5.Size = new Size(19, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Fit";
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(185, 8);
			this.label4.Name = "label4";
			this.label4.Size = new Size(40, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Normal";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(134, 8);
			this.label3.Name = "label3";
			this.label3.Size = new Size(23, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Fat";
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new Size(27, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Thin";
			this.FitTrackbar.AutoSize = false;
			this.FitTrackbar.BackColor = Color.White;
			this.FitTrackbar.Location = new Point(222, 4);
			this.FitTrackbar.Maximum = 100;
			this.FitTrackbar.Name = "FitTrackbar";
			this.FitTrackbar.Size = new Size(106, 24);
			this.FitTrackbar.TabIndex = 1;
			this.FitTrackbar.TickStyle = TickStyle.None;
			this.FitTrackbar.Value = 50;
			this.FitTrackbar.Scroll += this.FitTrackbar_Scroll;
			this.FatThinTrackBar.AutoSize = false;
			this.FatThinTrackBar.BackColor = Color.White;
			this.FatThinTrackBar.Location = new Point(22, 4);
			this.FatThinTrackBar.Maximum = 100;
			this.FatThinTrackBar.Minimum = -100;
			this.FatThinTrackBar.Name = "FatThinTrackBar";
			this.FatThinTrackBar.Size = new Size(106, 24);
			this.FatThinTrackBar.TabIndex = 0;
			this.FatThinTrackBar.TickStyle = TickStyle.None;
			this.FatThinTrackBar.Scroll += this.FatThinTrackBar_Scroll;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(74, 158);
			this.label2.Name = "label2";
			this.label2.Size = new Size(89, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Coming soon";
			this.label2.TextAlign = ContentAlignment.MiddleCenter;
			this.slotsTab.Location = new Point(4, 25);
			this.slotsTab.Name = "slotsTab";
			this.slotsTab.Size = new Size(354, 324);
			this.slotsTab.TabIndex = 3;
			this.slotsTab.Text = "Slots";
			this.slotsTab.UseVisualStyleBackColor = true;
			this.visualTipProvider_0.Animation = Enum24.const_2;
			this.visualTipProvider_0.Renderer = renderer;
			this.visualTipProvider_0.Shadow = Enum26.const_2;
			this.button1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.button1.Image = Class143.bone;
			this.button1.Location = new Point(65, -1);
			this.button1.Name = "button1";
			this.button1.Size = new Size(26, 26);
			this.button1.TabIndex = 9;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += this.button1_Click;
			base.Controls.Add(this.TabControl);
			this.MinimumSize = new Size(362, 0);
			base.Name = "CaspModelControl";
			base.Size = new Size(362, 353);
			this.selectPresetPanel.ResumeLayout(false);
			this.selectPresetPanel.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip1_1.ResumeLayout(false);
			this.TabControl.ResumeLayout(false);
			this.attributesTab.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((ISupportInitialize)this.caspPropertyGrid).EndInit();
			this.PresetsTab.ResumeLayout(false);
			((ISupportInitialize)this.presetPropertyGrid).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.meshTab.ResumeLayout(false);
			this.meshTab.PerformLayout();
			this.panel1.ResumeLayout(false);
			((ISupportInitialize)this.MeshPropertyGrid).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((ISupportInitialize)this.FitTrackbar).EndInit();
			((ISupportInitialize)this.FatThinTrackBar).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000304 RID: 772
		private Class68 projectModel;

		// Token: 0x04000305 RID: 773
		private IContainer icontainer_0;

		// Token: 0x04000306 RID: 774
		private Class8 presetPropertyGrid;

		// Token: 0x04000307 RID: 775
		private Panel selectPresetPanel;

		// Token: 0x04000308 RID: 776
		private ComboBox VariationCombo;

		// Token: 0x04000309 RID: 777
		private TabPage attributesTab;

		// Token: 0x0400030A RID: 778
		private Label label2;

		// Token: 0x0400030B RID: 779
		private Panel panel2;

		// Token: 0x0400030C RID: 780
		private ContextMenuStrip contextMenuStrip1_1;

		// Token: 0x0400030D RID: 781
		private ToolStripMenuItem resetToDefaultToolStripMenuItem;

		// Token: 0x0400030E RID: 782
		private VisualTipProvider visualTipProvider_0;

		// Token: 0x0400030F RID: 783
		private Panel panel1;

		// Token: 0x04000310 RID: 784
		private ToolStripMenuItem toolStripMenuItem1;

		// Token: 0x04000311 RID: 785
		private ToolStripSeparator toolStripSeparator1;

		// Token: 0x04000312 RID: 786
		private CheckBox advanced;

		// Token: 0x04000313 RID: 787
		private Class10 caspPropertyGrid;

		// Token: 0x04000314 RID: 788
		public Class2 MeshPropertyGrid;

		// Token: 0x04000315 RID: 789
		private Panel panel3;

		// Token: 0x04000316 RID: 790
		public ComboBox meshgroupCombo;

		// Token: 0x04000317 RID: 791
		private Panel panel4;

		// Token: 0x04000318 RID: 792
		public Button importMeshgroupButton;

		// Token: 0x04000319 RID: 793
		public Button exportMeshgroupButton;

		// Token: 0x0400031A RID: 794
		public TabPage meshTab;

		// Token: 0x0400031B RID: 795
		public TabPage PresetsTab;

		// Token: 0x0400031C RID: 796
		public TabControl TabControl;

		// Token: 0x0400031D RID: 797
		public TabPage slotsTab;

		// Token: 0x0400031E RID: 798
		private Panel panel5;

		// Token: 0x0400031F RID: 799
		private Label label5;

		// Token: 0x04000320 RID: 800
		private Label label4;

		// Token: 0x04000321 RID: 801
		private Label label3;

		// Token: 0x04000322 RID: 802
		private Label label1;

		// Token: 0x04000323 RID: 803
		private Panel panel6;

		// Token: 0x04000324 RID: 804
		public RadioButton fourChannelsRadio;

		// Token: 0x04000325 RID: 805
		public RadioButton threeChannelsRadio;

		// Token: 0x04000326 RID: 806
		public TrackBar FatThinTrackBar;

		// Token: 0x04000327 RID: 807
		public TrackBar FitTrackbar;

		// Token: 0x04000328 RID: 808
		private SplitButton splitButton1;

		// Token: 0x04000329 RID: 809
		private ContextMenuStrip contextMenuStrip1;

		// Token: 0x0400032A RID: 810
		public ToolStripMenuItem deleteMenuItem;

		// Token: 0x0400032B RID: 811
		private ToolStripMenuItem duplicateToolStripMenuItem;

		// Token: 0x0400032C RID: 812
		public ToolStripMenuItem exportToolStripMenuItem;

		// Token: 0x0400032D RID: 813
		private ToolStripSeparator toolStripSeparator2;

		// Token: 0x0400032E RID: 814
		private ToolStripMenuItem moveUpToolStripMenuItem;

		// Token: 0x0400032F RID: 815
		private ToolStripMenuItem moveDownToolStripMenuItem;

		// Token: 0x04000330 RID: 816
		public Button button1;

		// Token: 0x02000058 RID: 88
		public sealed class Class47
		{
			// Token: 0x17000084 RID: 132
			// (set) Token: 0x0600036E RID: 878 RVA: 0x00003DD9 File Offset: 0x00001FD9
			public AutoBoneAssigment AutoBoneAssignmentWindow
			{
				set
				{
					this.autoBoneAssigment_0 = value;
				}
			}

			// Token: 0x17000085 RID: 133
			// (get) Token: 0x0600036F RID: 879 RVA: 0x0003F178 File Offset: 0x0003D378
			// (set) Token: 0x06000370 RID: 880 RVA: 0x00003DE4 File Offset: 0x00001FE4
			public Class67 Wrapper { get; set; }

			// Token: 0x17000086 RID: 134
			// (get) Token: 0x06000371 RID: 881 RVA: 0x0003F190 File Offset: 0x0003D390
			// (set) Token: 0x06000372 RID: 882 RVA: 0x00003DEF File Offset: 0x00001FEF
			public int InterpolationLevel { get; set; }

			// Token: 0x06000373 RID: 883 RVA: 0x0003F1A8 File Offset: 0x0003D3A8
			public void method_0(object sender, DoWorkEventArgs e)
			{
				GeneralProgress progressForm = ((GeneralProgress.Class93)sender).ProgressForm;
				List<WSOFile.WSOVertex> list = new List<WSOFile.WSOVertex>();
				Lod msIndex = (Lod)this.Wrapper.Entry.msIndex;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				foreach (AutoBoneAssigment.Class35 @class in this.autoBoneAssigment_0.Entries)
				{
					if (@class.Tag is IGTIndex && this.autoBoneAssigment_0.DoMorphs)
					{
						for (int i = 0; i < this.Wrapper.Entry.index.Count; i++)
						{
							TGIIndex tgiindex = this.Wrapper.VPXY.TGIIndex[this.Wrapper.Entry.index[i]];
							Geometry geometry = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.Reskey)) as Geometry;
							GEOM geom = geometry.Entries[0] as GEOM;
							num3 += geom.vertices.Count;
						}
					}
				}
				foreach (AutoBoneAssigment.Class35 class2 in this.autoBoneAssigment_0.Entries)
				{
					List<WSOFile.WSOVertex> list2 = new List<WSOFile.WSOVertex>();
					foreach (string value in class2.UsedGroups)
					{
						foreach (WSOFile.WSOMesh wsomesh in this.autoBoneAssigment_0.WSO.Meshes)
						{
							if (wsomesh.Name.Equals(value))
							{
								foreach (WSOFile.WSOVertex item in wsomesh.Vertices)
								{
									list2.Add(item);
								}
							}
						}
					}
					if (class2.Name.Equals("Base"))
					{
						list.AddRange(list2);
					}
					if (class2.Tag is IGTIndex)
					{
						if (this.autoBoneAssigment_0.DoMorphs)
						{
							FPRT fprt = Class76.smethod_26(new ResKey((class2.Tag as IGTIndex).Reskey)) as FPRT;
							ResKey resKey_ = new ResKey(fprt.BGEO_Reskey);
							BGEO bgeo = Class76.smethod_26(resKey_) as BGEO;
							int num4 = 0;
							List<BGEO.BlendVertex> list3 = new List<BGEO.BlendVertex>();
							int num5 = int.MaxValue;
							for (int j = 0; j < this.Wrapper.Entry.index.Count; j++)
							{
								string string_ = string.Concat(new object[]
								{
									"Generating morphs for ",
									class2.Name,
									" group ",
									j + 1,
									" of ",
									this.Wrapper.Entry.index.Count
								});
								progressForm.method_3((float)num2, string_);
								TGIIndex tgiindex2 = this.Wrapper.VPXY.TGIIndex[this.Wrapper.Entry.index[j]];
								Geometry geometry2 = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex2.Reskey)) as Geometry;
								GEOM geom2 = geometry2.Entries[0] as GEOM;
								foreach (GEOM.GEOMVertex geomvertex in geom2.vertices)
								{
									num2 = (int)(100f * ((float)num++ / (float)num3));
									progressForm.method_3((float)num2, string_);
									num5 = Math.Min(num5, geomvertex.vertexId);
									BGEO.BlendVertex vertex = bgeo.S1Entries[0].SubEntries[(int)msIndex].GetVertex(geomvertex.vertexId);
									Vector3 vector = (vertex == null || !vertex.HasPosition) ? Vector3.Zero : new Vector3(vertex.Position[0], vertex.Position[1], vertex.Position[2]);
									Vector3 vector2 = (vertex == null || !vertex.HasNormal) ? Vector3.Zero : new Vector3(vertex.Normal[0], vertex.Normal[1], vertex.Normal[2]);
									List<object[]> list4 = new List<object[]>();
									for (int k = 0; k < list.Count; k++)
									{
										WSOFile.WSOVertex wsovertex = list[k];
										Vector3 value2 = new Vector3(wsovertex.X, wsovertex.Y, wsovertex.Z);
										Vector3 value3 = new Vector3(geomvertex.posX, geomvertex.posY, geomvertex.posZ);
										float num6 = Vector3.Distance(value2, value3);
										list4.Add(new object[]
										{
											num6,
											wsovertex,
											k
										});
									}
									List<object[]> list5 = list4;
									if (CaspModelControl.Class47.comparison_0 == null)
									{
										CaspModelControl.Class47.comparison_0 = new Comparison<object[]>(CaspModelControl.Class47.smethod_0);
									}
									list5.Sort(CaspModelControl.Class47.comparison_0);
									if (list4.Count > 0)
									{
										Vector3 vector3 = Vector3.Zero;
										Vector3 vector4 = Vector3.Zero;
										int num7 = 0;
										for (int l = 0; l < this.InterpolationLevel; l++)
										{
											if (l < list4.Count)
											{
												int index = (int)list4[l][2];
												WSOFile.WSOVertex wsovertex2 = list2[index];
												WSOFile.WSOVertex wsovertex3 = list[index];
												vector3 += new Vector3(wsovertex2.X, wsovertex2.Y, wsovertex2.Z);
												vector4 += new Vector3(wsovertex3.X, wsovertex3.Y, wsovertex3.Z);
												num7++;
											}
										}
										vector3 /= (float)num7;
										vector4 /= (float)num7;
										vector = vector3 - vector4;
									}
									BGEO.BlendVertex blendVertex = new BGEO.BlendVertex();
									blendVertex.VertexID = geomvertex.vertexId;
									blendVertex.HasNormal = (vector2.X != 0f && vector2.Y != 0f && vector2.Z != 0f);
									if (blendVertex.HasNormal)
									{
										blendVertex.Normal = new float[]
										{
											vector2.X,
											vector2.Y,
											vector2.Z
										};
									}
									blendVertex.HasPosition = true;
									blendVertex.Position = new float[]
									{
										vector.X,
										vector.Y,
										vector.Z
									};
									blendVertex.PositionInList = list3.Count;
									list3.Add(blendVertex);
									num4++;
								}
							}
							bgeo.S1Entries[0].SubEntries[(int)msIndex].StartVertexId = num5;
							bgeo.S1Entries[0].SubEntries[(int)msIndex].NumWords = (uint)list3.Count;
							bgeo.S1Entries[0].SubEntries[(int)msIndex].Vertices = list3;
							bgeo.Update();
						}
					}
					else if (this.autoBoneAssigment_0.DoBones)
					{
						string string_2 = "";
						for (int m = 0; m < this.Wrapper.Entry.index.Count; m++)
						{
							string_2 = string.Concat(new object[]
							{
								"Assigning bones to group ",
								m + 1,
								" of ",
								this.Wrapper.Entry.index.Count
							});
							progressForm.method_3(0f, string_2);
							TGIIndex tgiindex3 = this.Wrapper.VPXY.TGIIndex[this.Wrapper.Entry.index[m]];
							Geometry geometry3 = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex3.Reskey)) as Geometry;
							GEOM geom3 = geometry3.Entries[0] as GEOM;
							geom3.boneHashes = new List<uint>();
							int num8 = 0;
							foreach (GEOM.GEOMVertex geomvertex2 in geom3.vertices)
							{
								progressForm.method_3((float)((int)(100f * ((float)num8++ / (float)geom3.vertices.Count))), string_2);
								float num9 = float.MaxValue;
								WSOFile.WSOVertex wsovertex4 = null;
								foreach (WSOFile.WSOVertex wsovertex5 in list2)
								{
									float num10 = Vector3.Distance(new Vector3(wsovertex5.X, wsovertex5.Y, wsovertex5.Z), new Vector3(geomvertex2.posX, geomvertex2.posY, geomvertex2.posZ));
									if (num10 < num9)
									{
										wsovertex4 = wsovertex5;
										num9 = num10;
									}
								}
								if (wsovertex4 != null)
								{
									sbyte b = (sbyte)wsovertex4.BoneAssigment1;
									sbyte b2 = (sbyte)wsovertex4.BoneAssigment2;
									sbyte b3 = (sbyte)wsovertex4.BoneAssigment3;
									sbyte b4 = (sbyte)wsovertex4.BoneAssigment4;
									float num11 = wsovertex4.BoneWeight1 / 100f;
									float num12 = wsovertex4.BoneWeight2 / 100f;
									float num13 = wsovertex4.BoneWeight3 / 100f;
									float num14 = wsovertex4.BoneWeight4 / 100f;
									if (b > -1)
									{
										uint hash = this.autoBoneAssigment_0.WSO.Bones[(int)b].Hash;
										if (!geom3.boneHashes.Contains(hash))
										{
											geom3.boneHashes.Add(hash);
										}
										b = (sbyte)geom3.boneHashes.IndexOf(hash);
									}
									if (b2 > -1)
									{
										uint hash2 = this.autoBoneAssigment_0.WSO.Bones[(int)b2].Hash;
										if (!geom3.boneHashes.Contains(hash2))
										{
											geom3.boneHashes.Add(hash2);
										}
										b2 = (sbyte)geom3.boneHashes.IndexOf(hash2);
									}
									if (b3 > -1)
									{
										uint hash3 = this.autoBoneAssigment_0.WSO.Bones[(int)b3].Hash;
										if (!geom3.boneHashes.Contains(hash3))
										{
											geom3.boneHashes.Add(hash3);
										}
										b3 = (sbyte)geom3.boneHashes.IndexOf(hash3);
									}
									if (b4 > -1)
									{
										uint hash4 = this.autoBoneAssigment_0.WSO.Bones[(int)b4].Hash;
										if (!geom3.boneHashes.Contains(hash4))
										{
											geom3.boneHashes.Add(hash4);
										}
										b4 = (sbyte)geom3.boneHashes.IndexOf(hash4);
									}
									geomvertex2.boneAssignment[0] = (byte)b;
									geomvertex2.boneAssignment[1] = (byte)b2;
									geomvertex2.boneAssignment[2] = (byte)b3;
									geomvertex2.boneAssignment[3] = (byte)b4;
									geomvertex2.boneWeights[0] = num11;
									geomvertex2.boneWeights[1] = num12;
									geomvertex2.boneWeights[2] = num13;
									geomvertex2.boneWeights[3] = num14;
								}
							}
						}
						progressForm.method_3(100f, "Done");
					}
				}
			}

			// Token: 0x06000375 RID: 885 RVA: 0x0003FE30 File Offset: 0x0003E030
			[CompilerGenerated]
			private static int smethod_0(object[] object_0, object[] object_1)
			{
				return ((float)object_0[0]).CompareTo((float)object_1[0]);
			}

			// Token: 0x04000331 RID: 817
			private AutoBoneAssigment autoBoneAssigment_0;

			// Token: 0x04000332 RID: 818
			[CompilerGenerated]
			private Class67 class67_0;

			// Token: 0x04000333 RID: 819
			[CompilerGenerated]
			private int int_0;

			// Token: 0x04000334 RID: 820
			[CompilerGenerated]
			private static Comparison<object[]> comparison_0;
		}
	}
}
