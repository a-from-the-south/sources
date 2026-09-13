using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns1;
using ns17;
using ns18;
using ns20;
using ns3;
using ns4;
using ns5;
using ns7;
using ns8;
using Package.Sims3Files;
using Skybound.VisualTips;
using SplitButtonDemo;
using VisualHint.SmartPropertyGrid;

namespace ns0
{
	// Token: 0x02000053 RID: 83
	internal sealed class BuildItemModelControl : UserControl
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000321 RID: 801 RVA: 0x0003A868 File Offset: 0x00038A68
		public ComboBox PresetCombo
		{
			get
			{
				return this.VariationCombo;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000322 RID: 802 RVA: 0x0003A880 File Offset: 0x00038A80
		public Class2 BuilditemPropertyGrid
		{
			get
			{
				return this.builditemPropertyGrid;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000323 RID: 803 RVA: 0x0003A898 File Offset: 0x00038A98
		public Class8 PresetPropertyGrid
		{
			get
			{
				return this.presetPropertyGrid;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0003A8B0 File Offset: 0x00038AB0
		public Class4 StairsPropertyGrid
		{
			get
			{
				return this.builditemPropertyGrid;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000325 RID: 805 RVA: 0x0003A8C8 File Offset: 0x00038AC8
		public Class3 MeshPropertyGrid
		{
			get
			{
				return this.meshPropertyGrid;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000326 RID: 806 RVA: 0x0003A8E0 File Offset: 0x00038AE0
		public Class9 MiscPropertyGrid
		{
			get
			{
				return this.miscPropertyGrid;
			}
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000327 RID: 807 RVA: 0x0003A8F8 File Offset: 0x00038AF8
		// (remove) Token: 0x06000328 RID: 808 RVA: 0x0003A930 File Offset: 0x00038B30
		private event BuildItemModelControl.Delegate6 DoClearPresets
		{
			add
			{
				BuildItemModelControl.Delegate6 @delegate = this.delegate6_0;
				BuildItemModelControl.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					BuildItemModelControl.Delegate6 value2 = (BuildItemModelControl.Delegate6)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<BuildItemModelControl.Delegate6>(ref this.delegate6_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				BuildItemModelControl.Delegate6 @delegate = this.delegate6_0;
				BuildItemModelControl.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					BuildItemModelControl.Delegate6 value2 = (BuildItemModelControl.Delegate6)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<BuildItemModelControl.Delegate6>(ref this.delegate6_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000329 RID: 809 RVA: 0x0003A968 File Offset: 0x00038B68
		// (remove) Token: 0x0600032A RID: 810 RVA: 0x0003A9A0 File Offset: 0x00038BA0
		private event BuildItemModelControl.Delegate6 DoAddPreset
		{
			add
			{
				BuildItemModelControl.Delegate6 @delegate = this.delegate6_1;
				BuildItemModelControl.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					BuildItemModelControl.Delegate6 value2 = (BuildItemModelControl.Delegate6)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<BuildItemModelControl.Delegate6>(ref this.delegate6_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				BuildItemModelControl.Delegate6 @delegate = this.delegate6_1;
				BuildItemModelControl.Delegate6 delegate2;
				do
				{
					delegate2 = @delegate;
					BuildItemModelControl.Delegate6 value2 = (BuildItemModelControl.Delegate6)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<BuildItemModelControl.Delegate6>(ref this.delegate6_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00003C28 File Offset: 0x00001E28
		public BuildItemModelControl(Class86 model)
		{
			this.model = model;
			this.InitializeComponent();
			this.DoAddPreset += this.method_0;
			this.DoClearPresets += this.method_1;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00003C63 File Offset: 0x00001E63
		private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.model.method_28(this.VariationCombo.SelectedIndex);
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0003A9D8 File Offset: 0x00038BD8
		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (this.VariationCombo.Items.Count < 2)
			{
				MessageBox.Show("You must have at least one variant.");
			}
			else if (MessageBox.Show(this, "Are you sure you want to delete this variation?", "Remove variation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.model.method_27(this.VariationCombo.SelectedIndex);
				this.VariationCombo.SelectedIndex = 0;
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0003AA44 File Offset: 0x00038C44
		private void method_0(object object_0)
		{
			if (base.InvokeRequired)
			{
				BuildItemModelControl.Delegate6 method = new BuildItemModelControl.Delegate6(this.method_0);
				base.Invoke(method, new object[]
				{
					object_0
				});
			}
			else
			{
				this.VariationCombo.Items.Add(object_0 as Class81);
			}
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0003AA98 File Offset: 0x00038C98
		private void method_1(object object_0)
		{
			if (base.InvokeRequired)
			{
				BuildItemModelControl.Delegate6 method = new BuildItemModelControl.Delegate6(this.method_1);
				base.Invoke(method, new object[]
				{
					object_0
				});
			}
			else
			{
				this.VariationCombo.Items.Clear();
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00003C7D File Offset: 0x00001E7D
		public void method_2()
		{
			if (this.delegate6_0 != null)
			{
				this.delegate6_0(null);
			}
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00003C95 File Offset: 0x00001E95
		public void method_3(Class81 class81_0)
		{
			if (this.delegate6_1 != null)
			{
				this.delegate6_1(class81_0);
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0003AAE4 File Offset: 0x00038CE4
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

		// Token: 0x06000333 RID: 819 RVA: 0x0003AB44 File Offset: 0x00038D44
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

		// Token: 0x06000334 RID: 820 RVA: 0x00003CAD File Offset: 0x00001EAD
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0003ABBC File Offset: 0x00038DBC
		private void InitializeComponent()
		{
			this.icontainer_0 = new Container();
			Class161 @class = new Class161();
			Class161 class2 = new Class161();
			Class161 class3 = new Class161();
			Class161 class4 = new Class161();
			Class157 renderer = new Class157();
			this.tabControl = new TabControl();
			this.projectTab = new TabPage();
			this.builditemPropertyGrid = new Class4();
			this.objdSelectorPanel = new Panel();
			this.objdComboBox = new ComboBox();
			this.presetTab = new TabPage();
			this.panel2 = new Panel();
			this.presetPropertyGrid = new Class8();
			this.selectPresetPanel = new Panel();
			this.VariationCombo = new ComboBox();
			this.panel4 = new Panel();
			this.splitButton1 = new SplitButton();
			this.contextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
			this.toolStripMenuItem2 = new ToolStripMenuItem();
			this.duplicateToolStripMenuItem = new ToolStripMenuItem();
			this.exportToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripMenuItem1 = new ToolStripSeparator();
			this.moveUpToolStripMenuItem = new ToolStripMenuItem();
			this.moveDownToolStripMenuItem = new ToolStripMenuItem();
			this.meshTab = new TabPage();
			this.meshPropertyGrid = new Class3();
			this.panel1 = new Panel();
			this.meshgroupCombo = new ComboBox();
			this.panel3 = new Panel();
			this.importMeshgroupButton = new Button();
			this.exportMeshgroupButton = new Button();
			this.miscTab = new TabPage();
			this.miscPropertyGrid = new Class9();
			this.visualTipProvider_0 = new VisualTipProvider(this.icontainer_0);
			this.tabControl.SuspendLayout();
			this.projectTab.SuspendLayout();
			((ISupportInitialize)this.builditemPropertyGrid).BeginInit();
			this.objdSelectorPanel.SuspendLayout();
			this.presetTab.SuspendLayout();
			this.panel2.SuspendLayout();
			((ISupportInitialize)this.presetPropertyGrid).BeginInit();
			this.selectPresetPanel.SuspendLayout();
			this.panel4.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.meshTab.SuspendLayout();
			((ISupportInitialize)this.meshPropertyGrid).BeginInit();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.miscTab.SuspendLayout();
			((ISupportInitialize)this.miscPropertyGrid).BeginInit();
			base.SuspendLayout();
			this.tabControl.Controls.Add(this.projectTab);
			this.tabControl.Controls.Add(this.presetTab);
			this.tabControl.Controls.Add(this.meshTab);
			this.tabControl.Controls.Add(this.miscTab);
			this.tabControl.Dock = DockStyle.Fill;
			this.tabControl.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.tabControl.Location = new Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new Size(323, 458);
			this.tabControl.TabIndex = 0;
			this.projectTab.Controls.Add(this.builditemPropertyGrid);
			this.projectTab.Controls.Add(this.objdSelectorPanel);
			this.projectTab.Location = new Point(4, 23);
			this.projectTab.Name = "projectTab";
			this.projectTab.Padding = new Padding(3);
			this.projectTab.Size = new Size(315, 431);
			this.projectTab.TabIndex = 0;
			this.projectTab.Text = "Project";
			this.projectTab.UseVisualStyleBackColor = true;
			this.builditemPropertyGrid.AdvancedMode = false;
			this.builditemPropertyGrid.BorderStyle = BorderStyle.None;
			this.builditemPropertyGrid.Dock = DockStyle.Fill;
			this.builditemPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.builditemPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.builditemPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.builditemPropertyGrid.Location = new Point(3, 27);
			this.builditemPropertyGrid.Name = "builditemPropertyGrid";
			this.builditemPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.builditemPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.builditemPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.builditemPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.builditemPropertyGrid.Size = new Size(309, 401);
			this.builditemPropertyGrid.TabIndex = 0;
			this.builditemPropertyGrid.Text = "stairsPropertyGrid1";
			this.builditemPropertyGrid.Wrapper = null;
			this.objdSelectorPanel.Controls.Add(this.objdComboBox);
			this.objdSelectorPanel.Dock = DockStyle.Top;
			this.objdSelectorPanel.Location = new Point(3, 3);
			this.objdSelectorPanel.Name = "objdSelectorPanel";
			this.objdSelectorPanel.Padding = new Padding(0, 0, 0, 5);
			this.objdSelectorPanel.Size = new Size(309, 24);
			this.objdSelectorPanel.TabIndex = 2;
			this.objdComboBox.Dock = DockStyle.Fill;
			this.objdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.objdComboBox.FormattingEnabled = true;
			this.objdComboBox.Location = new Point(0, 0);
			this.objdComboBox.Name = "objdComboBox";
			this.objdComboBox.Size = new Size(309, 22);
			this.objdComboBox.TabIndex = 0;
			this.presetTab.Controls.Add(this.panel2);
			this.presetTab.Location = new Point(4, 23);
			this.presetTab.Name = "presetTab";
			this.presetTab.Size = new Size(315, 431);
			this.presetTab.TabIndex = 3;
			this.presetTab.Text = "Textures";
			this.presetTab.UseVisualStyleBackColor = true;
			this.panel2.Controls.Add(this.presetPropertyGrid);
			this.panel2.Controls.Add(this.selectPresetPanel);
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(315, 431);
			this.panel2.TabIndex = 3;
			this.presetPropertyGrid.AdvancedMode = false;
			this.presetPropertyGrid.BorderStyle = BorderStyle.None;
			this.presetPropertyGrid.Dock = DockStyle.Fill;
			this.presetPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.presetPropertyGrid.FloorCategory = WALL.FloorCategory.Unknown;
			this.presetPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.presetPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.presetPropertyGrid.Location = new Point(0, 27);
			this.presetPropertyGrid.Name = "presetPropertyGrid";
			this.presetPropertyGrid.Padding = new Padding(4, 0, 0, 0);
			this.presetPropertyGrid.Preset = null;
			this.presetPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.presetPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.presetPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.presetPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.presetPropertyGrid.Size = new Size(315, 404);
			this.presetPropertyGrid.TabIndex = 6;
			this.presetPropertyGrid.Text = "presetPropertyGrid1";
			this.presetPropertyGrid.WallCategory = WALL.WallCategory.Unknown;
			this.selectPresetPanel.BackColor = Color.Transparent;
			this.selectPresetPanel.Controls.Add(this.VariationCombo);
			this.selectPresetPanel.Controls.Add(this.panel4);
			this.selectPresetPanel.Dock = DockStyle.Top;
			this.selectPresetPanel.Location = new Point(0, 0);
			this.selectPresetPanel.Name = "selectPresetPanel";
			this.selectPresetPanel.Padding = new Padding(0, 2, 0, 2);
			this.selectPresetPanel.Size = new Size(315, 27);
			this.selectPresetPanel.TabIndex = 4;
			this.VariationCombo.Dock = DockStyle.Fill;
			this.VariationCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.VariationCombo.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.VariationCombo.FormattingEnabled = true;
			this.VariationCombo.ItemHeight = 14;
			this.VariationCombo.Location = new Point(0, 2);
			this.VariationCombo.Name = "VariationCombo";
			this.VariationCombo.Size = new Size(266, 22);
			this.VariationCombo.TabIndex = 2;
			@class.Text = "Select a texture variation to display and edit";
			@class.Title = "Variation";
			this.visualTipProvider_0.method_3(this.VariationCombo, @class);
			this.panel4.Controls.Add(this.splitButton1);
			this.panel4.Dock = DockStyle.Right;
			this.panel4.Location = new Point(266, 2);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new Padding(4, 0, 0, 0);
			this.panel4.Size = new Size(49, 23);
			this.panel4.TabIndex = 1;
			this.splitButton1.BackgroundImage = Class143._new;
			this.splitButton1.BackgroundImageLayout = ImageLayout.None;
			this.splitButton1.ClickedImage = "Clicked";
			this.splitButton1.ContextMenuStrip = this.contextMenuStrip1;
			this.splitButton1.DisabledImage = "Disabled";
			this.splitButton1.FocusedImage = "Focused";
			this.splitButton1.HoverImage = "Hover";
			this.splitButton1.ImageAlign = ContentAlignment.MiddleRight;
			this.splitButton1.ImageKey = "Normal";
			this.splitButton1.Location = new Point(4, -1);
			this.splitButton1.Name = "splitButton1";
			this.splitButton1.NormalImage = "Normal";
			this.splitButton1.Size = new Size(46, 24);
			this.splitButton1.TabIndex = 9;
			this.splitButton1.TextAlign = ContentAlignment.MiddleRight;
			this.splitButton1.UseVisualStyleBackColor = true;
			this.contextMenuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem2,
				this.duplicateToolStripMenuItem,
				this.exportToolStripMenuItem,
				this.toolStripMenuItem1,
				this.moveUpToolStripMenuItem,
				this.moveDownToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new Size(138, 120);
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new Size(137, 22);
			this.toolStripMenuItem2.Text = "Delete";
			this.toolStripMenuItem2.Click += this.toolStripMenuItem2_Click;
			this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
			this.duplicateToolStripMenuItem.Size = new Size(137, 22);
			this.duplicateToolStripMenuItem.Text = "Duplicate";
			this.duplicateToolStripMenuItem.Click += this.duplicateToolStripMenuItem_Click;
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new Size(137, 22);
			this.exportToolStripMenuItem.Text = "Export";
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new Size(134, 6);
			this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
			this.moveUpToolStripMenuItem.Size = new Size(137, 22);
			this.moveUpToolStripMenuItem.Text = "Move up";
			this.moveUpToolStripMenuItem.Click += this.moveUpToolStripMenuItem_Click;
			this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
			this.moveDownToolStripMenuItem.Size = new Size(137, 22);
			this.moveDownToolStripMenuItem.Text = "Move down";
			this.moveDownToolStripMenuItem.Click += this.moveDownToolStripMenuItem_Click;
			this.meshTab.Controls.Add(this.meshPropertyGrid);
			this.meshTab.Controls.Add(this.panel1);
			this.meshTab.Location = new Point(4, 23);
			this.meshTab.Name = "meshTab";
			this.meshTab.Size = new Size(315, 431);
			this.meshTab.TabIndex = 1;
			this.meshTab.Text = "Mesh";
			this.meshTab.UseVisualStyleBackColor = true;
			this.meshPropertyGrid.AdvancedMode = false;
			this.meshPropertyGrid.BorderStyle = BorderStyle.None;
			this.meshPropertyGrid.CurrentWrapper = null;
			this.meshPropertyGrid.Dock = DockStyle.Fill;
			this.meshPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.meshPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.meshPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.meshPropertyGrid.Location = new Point(0, 30);
			this.meshPropertyGrid.Model = null;
			this.meshPropertyGrid.Name = "meshPropertyGrid";
			this.meshPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.meshPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.meshPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.meshPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.meshPropertyGrid.Size = new Size(315, 401);
			this.meshPropertyGrid.TabIndex = 7;
			this.meshPropertyGrid.Text = "MeshPropertyGrid";
			this.panel1.BackColor = Color.Transparent;
			this.panel1.Controls.Add(this.meshgroupCombo);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(0, 2, 0, 2);
			this.panel1.Size = new Size(315, 30);
			this.panel1.TabIndex = 6;
			this.meshgroupCombo.Dock = DockStyle.Fill;
			this.meshgroupCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.meshgroupCombo.Font = new Font("Tahoma", 9.5f);
			this.meshgroupCombo.FormattingEnabled = true;
			this.meshgroupCombo.ItemHeight = 16;
			this.meshgroupCombo.Location = new Point(0, 2);
			this.meshgroupCombo.Name = "meshgroupCombo";
			this.meshgroupCombo.Size = new Size(256, 24);
			this.meshgroupCombo.TabIndex = 8;
			class2.Text = "Select the mesh to show properties for ";
			class2.Title = "Mesh";
			this.visualTipProvider_0.method_3(this.meshgroupCombo, class2);
			this.panel3.Controls.Add(this.importMeshgroupButton);
			this.panel3.Controls.Add(this.exportMeshgroupButton);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(256, 2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(59, 26);
			this.panel3.TabIndex = 0;
			this.importMeshgroupButton.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.importMeshgroupButton.Image = Class143.import;
			this.importMeshgroupButton.Location = new Point(34, -1);
			this.importMeshgroupButton.Name = "importMeshgroupButton";
			this.importMeshgroupButton.Size = new Size(26, 26);
			this.importMeshgroupButton.TabIndex = 8;
			this.importMeshgroupButton.UseVisualStyleBackColor = true;
			class3.Text = "Import mesh to current selection";
			class3.Title = "Import";
			this.visualTipProvider_0.method_3(this.importMeshgroupButton, class3);
			this.exportMeshgroupButton.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.exportMeshgroupButton.Image = Class143.export;
			this.exportMeshgroupButton.Location = new Point(4, -1);
			this.exportMeshgroupButton.Name = "exportMeshgroupButton";
			this.exportMeshgroupButton.Size = new Size(26, 26);
			this.exportMeshgroupButton.TabIndex = 7;
			this.exportMeshgroupButton.UseVisualStyleBackColor = true;
			class4.Text = "Export selected mesh";
			class4.Title = "Export";
			this.visualTipProvider_0.method_3(this.exportMeshgroupButton, class4);
			this.miscTab.Controls.Add(this.miscPropertyGrid);
			this.miscTab.Location = new Point(4, 23);
			this.miscTab.Name = "miscTab";
			this.miscTab.Size = new Size(315, 431);
			this.miscTab.TabIndex = 2;
			this.miscTab.Text = "Misc";
			this.miscTab.UseVisualStyleBackColor = true;
			this.miscPropertyGrid.BorderStyle = BorderStyle.None;
			this.miscPropertyGrid.Dock = DockStyle.Fill;
			this.miscPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.miscPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.miscPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.miscPropertyGrid.Location = new Point(0, 0);
			this.miscPropertyGrid.Name = "miscPropertyGrid";
			this.miscPropertyGrid.Project = null;
			this.miscPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.miscPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.miscPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.miscPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.miscPropertyGrid.Size = new Size(315, 431);
			this.miscPropertyGrid.TabIndex = 0;
			this.miscPropertyGrid.Text = "miscPropertyGrid";
			this.visualTipProvider_0.Animation = Enum24.const_2;
			this.visualTipProvider_0.InitialDelay = 750;
			this.visualTipProvider_0.Renderer = renderer;
			this.visualTipProvider_0.Shadow = Enum26.const_2;
			this.visualTipProvider_0.ShowAlways = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.tabControl);
			base.Name = "BuildItemModelControl";
			base.Size = new Size(323, 458);
			this.tabControl.ResumeLayout(false);
			this.projectTab.ResumeLayout(false);
			((ISupportInitialize)this.builditemPropertyGrid).EndInit();
			this.objdSelectorPanel.ResumeLayout(false);
			this.presetTab.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((ISupportInitialize)this.presetPropertyGrid).EndInit();
			this.selectPresetPanel.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.meshTab.ResumeLayout(false);
			((ISupportInitialize)this.meshPropertyGrid).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.miscTab.ResumeLayout(false);
			((ISupportInitialize)this.miscPropertyGrid).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040002DF RID: 735
		private BuildItemModelControl.Delegate6 delegate6_0;

		// Token: 0x040002E0 RID: 736
		private BuildItemModelControl.Delegate6 delegate6_1;

		// Token: 0x040002E1 RID: 737
		private Class86 model;

		// Token: 0x040002E2 RID: 738
		private IContainer icontainer_0;

		// Token: 0x040002E3 RID: 739
		private TabPage projectTab;

		// Token: 0x040002E4 RID: 740
		public Class3 meshPropertyGrid;

		// Token: 0x040002E5 RID: 741
		private Panel panel1;

		// Token: 0x040002E6 RID: 742
		public ComboBox meshgroupCombo;

		// Token: 0x040002E7 RID: 743
		private Panel panel3;

		// Token: 0x040002E8 RID: 744
		public Button importMeshgroupButton;

		// Token: 0x040002E9 RID: 745
		public Button exportMeshgroupButton;

		// Token: 0x040002EA RID: 746
		private TabPage miscTab;

		// Token: 0x040002EB RID: 747
		private Class9 miscPropertyGrid;

		// Token: 0x040002EC RID: 748
		private VisualTipProvider visualTipProvider_0;

		// Token: 0x040002ED RID: 749
		public Panel objdSelectorPanel;

		// Token: 0x040002EE RID: 750
		public ComboBox objdComboBox;

		// Token: 0x040002EF RID: 751
		public TabControl tabControl;

		// Token: 0x040002F0 RID: 752
		public TabPage presetTab;

		// Token: 0x040002F1 RID: 753
		private Panel panel2;

		// Token: 0x040002F2 RID: 754
		private Class8 presetPropertyGrid;

		// Token: 0x040002F3 RID: 755
		private Panel selectPresetPanel;

		// Token: 0x040002F4 RID: 756
		private Panel panel4;

		// Token: 0x040002F5 RID: 757
		private ComboBox VariationCombo;

		// Token: 0x040002F6 RID: 758
		private Class4 builditemPropertyGrid;

		// Token: 0x040002F7 RID: 759
		public TabPage meshTab;

		// Token: 0x040002F8 RID: 760
		private SplitButton splitButton1;

		// Token: 0x040002F9 RID: 761
		private ContextMenuStrip contextMenuStrip1;

		// Token: 0x040002FA RID: 762
		private ToolStripMenuItem toolStripMenuItem2;

		// Token: 0x040002FB RID: 763
		private ToolStripMenuItem duplicateToolStripMenuItem;

		// Token: 0x040002FC RID: 764
		public ToolStripMenuItem exportToolStripMenuItem;

		// Token: 0x040002FD RID: 765
		private ToolStripSeparator toolStripMenuItem1;

		// Token: 0x040002FE RID: 766
		private ToolStripMenuItem moveUpToolStripMenuItem;

		// Token: 0x040002FF RID: 767
		private ToolStripMenuItem moveDownToolStripMenuItem;

		// Token: 0x02000054 RID: 84
		// (Invoke) Token: 0x06000337 RID: 823
		private delegate void Delegate6(object o);
	}
}
