using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns1;
using ns14;
using ns17;
using ns20;
using ns3;
using ns7;
using ns8;
using Package.Geometry;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK.Classes;
using Skybound.VisualTips;
using SlimDX;
using SplitButtonDemo;
using VisualHint.SmartPropertyGrid;

namespace ns4
{
	// Token: 0x0200008A RID: 138
	internal sealed class ObjdModelControl : UserControl
	{
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x00058A28 File Offset: 0x00056C28
		public ComboBox VariationCombo
		{
			get
			{
				return this.presetCombo;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x00058A40 File Offset: 0x00056C40
		public Class8 PresetPropertyGrid
		{
			get
			{
				return this.presetPropertyGrid;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x00058A58 File Offset: 0x00056C58
		public Class3 MLODPropertyGrid
		{
			get
			{
				return this.mlodPropertyGrid;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x00058A70 File Offset: 0x00056C70
		public Class11 ObjdPropertyGrid
		{
			get
			{
				return this.objdPropertyGrid;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x00058A88 File Offset: 0x00056C88
		public Class2 MiscPropertyGrid
		{
			get
			{
				return this.miscPropertyGrid;
			}
		}

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x0600058A RID: 1418 RVA: 0x00058AA0 File Offset: 0x00056CA0
		// (remove) Token: 0x0600058B RID: 1419 RVA: 0x00058AD8 File Offset: 0x00056CD8
		private event ObjdModelControl.Delegate14 DoClearPresets
		{
			add
			{
				ObjdModelControl.Delegate14 @delegate = this.delegate14_0;
				ObjdModelControl.Delegate14 delegate2;
				do
				{
					delegate2 = @delegate;
					ObjdModelControl.Delegate14 value2 = (ObjdModelControl.Delegate14)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<ObjdModelControl.Delegate14>(ref this.delegate14_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				ObjdModelControl.Delegate14 @delegate = this.delegate14_0;
				ObjdModelControl.Delegate14 delegate2;
				do
				{
					delegate2 = @delegate;
					ObjdModelControl.Delegate14 value2 = (ObjdModelControl.Delegate14)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<ObjdModelControl.Delegate14>(ref this.delegate14_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x0600058C RID: 1420 RVA: 0x00058B10 File Offset: 0x00056D10
		// (remove) Token: 0x0600058D RID: 1421 RVA: 0x00058B48 File Offset: 0x00056D48
		private event ObjdModelControl.Delegate14 DoAddPreset
		{
			add
			{
				ObjdModelControl.Delegate14 @delegate = this.delegate14_1;
				ObjdModelControl.Delegate14 delegate2;
				do
				{
					delegate2 = @delegate;
					ObjdModelControl.Delegate14 value2 = (ObjdModelControl.Delegate14)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<ObjdModelControl.Delegate14>(ref this.delegate14_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				ObjdModelControl.Delegate14 @delegate = this.delegate14_1;
				ObjdModelControl.Delegate14 delegate2;
				do
				{
					delegate2 = @delegate;
					ObjdModelControl.Delegate14 value2 = (ObjdModelControl.Delegate14)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<ObjdModelControl.Delegate14>(ref this.delegate14_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x0600058E RID: 1422 RVA: 0x00058B80 File Offset: 0x00056D80
		// (remove) Token: 0x0600058F RID: 1423 RVA: 0x00058BB8 File Offset: 0x00056DB8
		private event ObjdModelControl.Delegate14 DoClearMeshes
		{
			add
			{
				ObjdModelControl.Delegate14 @delegate = this.delegate14_2;
				ObjdModelControl.Delegate14 delegate2;
				do
				{
					delegate2 = @delegate;
					ObjdModelControl.Delegate14 value2 = (ObjdModelControl.Delegate14)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<ObjdModelControl.Delegate14>(ref this.delegate14_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				ObjdModelControl.Delegate14 @delegate = this.delegate14_2;
				ObjdModelControl.Delegate14 delegate2;
				do
				{
					delegate2 = @delegate;
					ObjdModelControl.Delegate14 value2 = (ObjdModelControl.Delegate14)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<ObjdModelControl.Delegate14>(ref this.delegate14_2, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000590 RID: 1424 RVA: 0x00058BF0 File Offset: 0x00056DF0
		// (remove) Token: 0x06000591 RID: 1425 RVA: 0x00058C28 File Offset: 0x00056E28
		private event ObjdModelControl.Delegate14 DoAddMesh
		{
			add
			{
				ObjdModelControl.Delegate14 @delegate = this.delegate14_3;
				ObjdModelControl.Delegate14 delegate2;
				do
				{
					delegate2 = @delegate;
					ObjdModelControl.Delegate14 value2 = (ObjdModelControl.Delegate14)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<ObjdModelControl.Delegate14>(ref this.delegate14_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				ObjdModelControl.Delegate14 @delegate = this.delegate14_3;
				ObjdModelControl.Delegate14 delegate2;
				do
				{
					delegate2 = @delegate;
					ObjdModelControl.Delegate14 value2 = (ObjdModelControl.Delegate14)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<ObjdModelControl.Delegate14>(ref this.delegate14_3, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x00058C60 File Offset: 0x00056E60
		public TabControl Tabs
		{
			get
			{
				return this.tabControl1;
			}
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00058C78 File Offset: 0x00056E78
		public ObjdModelControl(Class80 model)
		{
			this.model = model;
			this.InitializeComponent();
			this.DoClearPresets += this.method_3;
			this.DoAddPreset += this.method_2;
			this.DoClearMeshes += this.method_1;
			this.DoAddMesh += this.method_0;
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00058CE4 File Offset: 0x00056EE4
		private void method_0(object object_0)
		{
			if (base.InvokeRequired)
			{
				ObjdModelControl.Delegate14 method = new ObjdModelControl.Delegate14(this.method_0);
				base.Invoke(method, new object[]
				{
					object_0
				});
			}
			else
			{
				this.meshgroupCombo.Items.Add(object_0 as Class3.Class22);
			}
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00058D38 File Offset: 0x00056F38
		private void method_1(object object_0)
		{
			if (base.InvokeRequired)
			{
				ObjdModelControl.Delegate14 method = new ObjdModelControl.Delegate14(this.method_1);
				base.Invoke(method, new object[]
				{
					object_0
				});
			}
			else
			{
				this.meshgroupCombo.Items.Clear();
			}
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00058D84 File Offset: 0x00056F84
		private void method_2(object object_0)
		{
			if (base.InvokeRequired)
			{
				ObjdModelControl.Delegate14 method = new ObjdModelControl.Delegate14(this.method_2);
				base.Invoke(method, new object[]
				{
					object_0
				});
			}
			else
			{
				this.presetCombo.Items.Add(object_0 as Class81);
				this.splitButton1.Enabled = true;
			}
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00058DE4 File Offset: 0x00056FE4
		private void method_3(object object_0)
		{
			if (base.InvokeRequired)
			{
				ObjdModelControl.Delegate14 method = new ObjdModelControl.Delegate14(this.method_3);
				base.Invoke(method, new object[]
				{
					object_0
				});
			}
			else
			{
				this.presetCombo.Items.Clear();
			}
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00058E30 File Offset: 0x00057030
		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (this.VariationCombo.Items.Count < 2)
			{
				MessageBox.Show("You must have at least one variation.");
			}
			else if (MessageBox.Show(this, "Are you sure you want to delete this variation?", "Remove variation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.model.method_38(this.VariationCombo.SelectedIndex);
				this.VariationCombo.SelectedIndex = 0;
			}
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00004CE1 File Offset: 0x00002EE1
		private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.model.method_39(this.VariationCombo.SelectedIndex);
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00004CFB File Offset: 0x00002EFB
		public void method_4()
		{
			if (this.delegate14_0 != null)
			{
				this.delegate14_0(null);
			}
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00004D13 File Offset: 0x00002F13
		public void method_5(Class81 class81_0)
		{
			if (this.delegate14_1 != null)
			{
				this.delegate14_1(class81_0);
			}
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00004D2B File Offset: 0x00002F2B
		public void method_6(Class3.Class22 class22_0)
		{
			if (this.delegate14_3 != null)
			{
				this.delegate14_3(class22_0);
			}
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00004D43 File Offset: 0x00002F43
		public void method_7()
		{
			if (this.delegate14_2 != null)
			{
				this.delegate14_2(null);
			}
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00058E9C File Offset: 0x0005709C
		private void Rotationtrackbar_ValueChanged(object sender, EventArgs e)
		{
			int num = this.Rotationtrackbar.Value * 45;
			Class132.smethod_0().ObjectRotation = (float)num;
			this.rotationLabel.Text = "Rotation (" + num + " degrees):";
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x00058EE8 File Offset: 0x000570E8
		private void GeostateCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.GeostateCombo.SelectedIndex > 0)
			{
				this.mlodPropertyGrid.SelectedGeostate = Convert.ToUInt32(this.GeostateCombo.SelectedItem as string, 16);
			}
			else
			{
				this.mlodPropertyGrid.SelectedGeostate = 0U;
			}
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x00058F38 File Offset: 0x00057138
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

		// Token: 0x060005A1 RID: 1441 RVA: 0x00058F98 File Offset: 0x00057198
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

		// Token: 0x060005A2 RID: 1442 RVA: 0x00059010 File Offset: 0x00057210
		private void button2_Click(object sender, EventArgs e)
		{
			Class3.Class24 @class = this.mlodPropertyGrid.CurrentWrapper as Class3.Class24;
			MLOD mlod = @class.MLOD;
			object[] array = new object[mlod.Entries.Count];
			int num = 0;
			foreach (MLOD.MLODEntry mlodentry in mlod.Entries)
			{
				array[num++] = new object[]
				{
					"Group " + num,
					mlodentry
				};
			}
			AutoBoneAssigment autoBoneAssigment = new AutoBoneAssigment(array, false);
			if (autoBoneAssigment.ShowDialog(Class132.mainForm) == DialogResult.OK)
			{
				foreach (AutoBoneAssigment.Class35 class2 in autoBoneAssigment.Entries)
				{
					if (autoBoneAssigment.DoBones)
					{
						List<WSOFile.WSOVertex> list = new List<WSOFile.WSOVertex>();
						foreach (string value in class2.UsedGroups)
						{
							foreach (WSOFile.WSOMesh wsomesh in autoBoneAssigment.WSO.Meshes)
							{
								if (wsomesh.Name.Equals(value))
								{
									foreach (WSOFile.WSOVertex item in wsomesh.Vertices)
									{
										list.Add(item);
									}
								}
							}
						}
						MLOD.MLODEntry mlodentry2 = class2.Tag as MLOD.MLODEntry;
						MLOD parent = mlodentry2.Parent;
						RCOL parent2 = parent.Parent;
						VRTF vrtf = parent2.Entries[mlodentry2.VRTFIndex + ((parent2.dataType == 2) ? 1 : 0)] as VRTF;
						VBUF vbuf = (VBUF)parent2.Entries[mlodentry2.VBUFIndex + ((parent2.dataType == 2) ? 1 : 0)];
						if (vrtf == null)
						{
							vrtf = VRTF.GetDefaultForLength((mlodentry2.Type == 20483U) ? 8 : 16);
						}
						mlodentry2.Bones.Clear();
						for (int i = 0; i < mlodentry2.VertexCount; i++)
						{
							Package.Geometry.Vector4 position = vbuf.GetPosition(vrtf, i, mlodentry2.VBUFOffset, 0);
							vbuf.GetWeights(vrtf, i, mlodentry2.VBUFOffset, 0);
							vbuf.GetAssignment(vrtf, i, mlodentry2.VBUFOffset, 0);
							float num2 = float.MaxValue;
							WSOFile.WSOVertex wsovertex = null;
							foreach (WSOFile.WSOVertex wsovertex2 in list)
							{
								float num3 = SlimDX.Vector3.Distance(new SlimDX.Vector3(wsovertex2.X, wsovertex2.Y, wsovertex2.Z), new SlimDX.Vector3(position.X, position.Y, position.Z));
								if (num3 < num2)
								{
									wsovertex = wsovertex2;
									num2 = num3;
								}
							}
							if (wsovertex != null)
							{
								sbyte b = (sbyte)wsovertex.BoneAssigment1;
								sbyte b2 = (sbyte)wsovertex.BoneAssigment2;
								sbyte b3 = (sbyte)wsovertex.BoneAssigment3;
								sbyte b4 = (sbyte)wsovertex.BoneAssigment4;
								float num4 = wsovertex.BoneWeight1 / 100f;
								float num5 = wsovertex.BoneWeight2 / 100f;
								float num6 = wsovertex.BoneWeight3 / 100f;
								float num7 = wsovertex.BoneWeight4 / 100f;
								if (b > -1)
								{
									uint hash = autoBoneAssigment.WSO.Bones[(int)b].Hash;
									if (!mlodentry2.Bones.Contains(hash))
									{
										mlodentry2.Bones.Add(hash);
									}
									b = (sbyte)mlodentry2.Bones.IndexOf(hash);
								}
								if (b2 > -1)
								{
									uint hash2 = autoBoneAssigment.WSO.Bones[(int)b2].Hash;
									if (!mlodentry2.Bones.Contains(hash2))
									{
										mlodentry2.Bones.Add(hash2);
									}
									b2 = (sbyte)mlodentry2.Bones.IndexOf(hash2);
								}
								if (b3 > -1)
								{
									uint hash3 = autoBoneAssigment.WSO.Bones[(int)b3].Hash;
									if (!mlodentry2.Bones.Contains(hash3))
									{
										mlodentry2.Bones.Add(hash3);
									}
									b3 = (sbyte)mlodentry2.Bones.IndexOf(hash3);
								}
								if (b4 > -1)
								{
									uint hash4 = autoBoneAssigment.WSO.Bones[(int)b4].Hash;
									if (!mlodentry2.Bones.Contains(hash4))
									{
										mlodentry2.Bones.Add(hash4);
									}
									b4 = (sbyte)mlodentry2.Bones.IndexOf(hash4);
								}
								vbuf.SetAssignment(vrtf, i, mlodentry2.VBUFOffset, new sbyte[]
								{
									b,
									b2,
									b3,
									b4
								});
								vbuf.SetWeights(vrtf, i, mlodentry2.VBUFOffset, new float[]
								{
									num4,
									num5,
									num6,
									num7
								});
							}
						}
					}
				}
				this.model.method_16(true);
			}
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00004D5B File Offset: 0x00002F5B
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x000595F0 File Offset: 0x000577F0
		private void InitializeComponent()
		{
			this.icontainer_0 = new Container();
			Class161 @class = new Class161();
			Class161 class2 = new Class161();
			Class161 class3 = new Class161();
			Class161 class4 = new Class161();
			Class161 class5 = new Class161();
			Class161 class6 = new Class161();
			Class157 renderer = new Class157();
			this.tabControl1 = new TabControl();
			this.project = new TabPage();
			this.objdPropertyGrid = new Class11();
			this.objdSelectorPanel = new Panel();
			this.objdComboBox = new ComboBox();
			this.textures = new TabPage();
			this.panel2 = new Panel();
			this.presetPropertyGrid = new Class8();
			this.selectPresetPanel = new Panel();
			this.presetCombo = new ComboBox();
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
			this.mlodPropertyGrid = new Class3();
			this.panel1 = new Panel();
			this.panel6 = new Panel();
			this.panel7 = new Panel();
			this.Rotationtrackbar = new TrackBar();
			this.rotationLabel = new Label();
			this.panel8 = new Panel();
			this.panel9 = new Panel();
			this.GeostateCombo = new ComboBox();
			this.label1 = new Label();
			this.panel3 = new Panel();
			this.meshgroupCombo = new ComboBox();
			this.panel5 = new Panel();
			this.button2 = new Button();
			this.generateShadowMeshButton = new Button();
			this.importMeshgroupButton = new Button();
			this.exportMeshgroupButton = new Button();
			this.slots = new TabPage();
			this.SlotsPropertyGrid = new Class9();
			this.misc = new TabPage();
			this.miscPropertyGrid = new Class2();
			this.tabPage1 = new TabPage();
			this.visualTipProvider_0 = new VisualTipProvider(this.icontainer_0);
			this.button1 = new Button();
			this.tabControl1.SuspendLayout();
			this.project.SuspendLayout();
			((ISupportInitialize)this.objdPropertyGrid).BeginInit();
			this.objdSelectorPanel.SuspendLayout();
			this.textures.SuspendLayout();
			this.panel2.SuspendLayout();
			((ISupportInitialize)this.presetPropertyGrid).BeginInit();
			this.selectPresetPanel.SuspendLayout();
			this.panel4.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.meshTab.SuspendLayout();
			((ISupportInitialize)this.mlodPropertyGrid).BeginInit();
			this.panel1.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			((ISupportInitialize)this.Rotationtrackbar).BeginInit();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.slots.SuspendLayout();
			((ISupportInitialize)this.SlotsPropertyGrid).BeginInit();
			this.misc.SuspendLayout();
			((ISupportInitialize)this.miscPropertyGrid).BeginInit();
			base.SuspendLayout();
			this.tabControl1.Controls.Add(this.project);
			this.tabControl1.Controls.Add(this.textures);
			this.tabControl1.Controls.Add(this.meshTab);
			this.tabControl1.Controls.Add(this.slots);
			this.tabControl1.Controls.Add(this.misc);
			this.tabControl1.Dock = DockStyle.Fill;
			this.tabControl1.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
			this.tabControl1.Location = new Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new Size(349, 506);
			this.tabControl1.TabIndex = 0;
			this.project.Controls.Add(this.objdPropertyGrid);
			this.project.Controls.Add(this.objdSelectorPanel);
			this.project.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.project.Location = new Point(4, 25);
			this.project.Name = "project";
			this.project.Padding = new Padding(3);
			this.project.Size = new Size(341, 477);
			this.project.TabIndex = 0;
			this.project.Text = "Project";
			this.project.UseVisualStyleBackColor = true;
			this.objdPropertyGrid.BorderStyle = BorderStyle.None;
			this.objdPropertyGrid.Dock = DockStyle.Fill;
			this.objdPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.objdPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.objdPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.objdPropertyGrid.Location = new Point(3, 27);
			this.objdPropertyGrid.Name = "objdPropertyGrid";
			this.objdPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.objdPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.objdPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.objdPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.objdPropertyGrid.Size = new Size(335, 447);
			this.objdPropertyGrid.TabIndex = 0;
			this.objdPropertyGrid.Text = "objdPropertyGrid1";
			this.objdSelectorPanel.Controls.Add(this.objdComboBox);
			this.objdSelectorPanel.Dock = DockStyle.Top;
			this.objdSelectorPanel.Location = new Point(3, 3);
			this.objdSelectorPanel.Name = "objdSelectorPanel";
			this.objdSelectorPanel.Padding = new Padding(0, 0, 0, 5);
			this.objdSelectorPanel.Size = new Size(335, 24);
			this.objdSelectorPanel.TabIndex = 1;
			this.objdComboBox.Dock = DockStyle.Fill;
			this.objdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.objdComboBox.FormattingEnabled = true;
			this.objdComboBox.Location = new Point(0, 0);
			this.objdComboBox.Name = "objdComboBox";
			this.objdComboBox.Size = new Size(335, 21);
			this.objdComboBox.TabIndex = 0;
			this.textures.Controls.Add(this.panel2);
			this.textures.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.textures.Location = new Point(4, 25);
			this.textures.Name = "textures";
			this.textures.Padding = new Padding(3);
			this.textures.Size = new Size(341, 477);
			this.textures.TabIndex = 1;
			this.textures.Text = "Textures";
			this.textures.UseVisualStyleBackColor = true;
			this.panel2.Controls.Add(this.presetPropertyGrid);
			this.panel2.Controls.Add(this.selectPresetPanel);
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Location = new Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(335, 471);
			this.panel2.TabIndex = 2;
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
			this.presetPropertyGrid.Size = new Size(335, 444);
			this.presetPropertyGrid.TabIndex = 6;
			this.presetPropertyGrid.Text = "presetPropertyGrid1";
			this.presetPropertyGrid.WallCategory = WALL.WallCategory.Masonry;
			this.selectPresetPanel.BackColor = Color.Transparent;
			this.selectPresetPanel.Controls.Add(this.presetCombo);
			this.selectPresetPanel.Controls.Add(this.panel4);
			this.selectPresetPanel.Dock = DockStyle.Top;
			this.selectPresetPanel.Location = new Point(0, 0);
			this.selectPresetPanel.Name = "selectPresetPanel";
			this.selectPresetPanel.Padding = new Padding(0, 2, 0, 2);
			this.selectPresetPanel.Size = new Size(335, 27);
			this.selectPresetPanel.TabIndex = 4;
			this.presetCombo.Dock = DockStyle.Fill;
			this.presetCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.presetCombo.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.presetCombo.FormattingEnabled = true;
			this.presetCombo.ItemHeight = 14;
			this.presetCombo.Location = new Point(0, 2);
			this.presetCombo.Name = "presetCombo";
			this.presetCombo.Size = new Size(286, 22);
			this.presetCombo.TabIndex = 2;
			@class.Text = "Select a texture variation to display and edit";
			@class.Title = "Variation";
			this.visualTipProvider_0.method_3(this.presetCombo, @class);
			this.panel4.Controls.Add(this.splitButton1);
			this.panel4.Dock = DockStyle.Right;
			this.panel4.Location = new Point(286, 2);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new Padding(4, 0, 0, 0);
			this.panel4.Size = new Size(49, 23);
			this.panel4.TabIndex = 1;
			this.splitButton1.BackgroundImage = Class143._new;
			this.splitButton1.BackgroundImageLayout = ImageLayout.None;
			this.splitButton1.ClickedImage = "Clicked";
			this.splitButton1.ContextMenuStrip = this.contextMenuStrip1;
			this.splitButton1.DisabledImage = "Disabled";
			this.splitButton1.Enabled = false;
			this.splitButton1.FocusedImage = "Focused";
			this.splitButton1.HoverImage = "Hover";
			this.splitButton1.ImageAlign = ContentAlignment.MiddleRight;
			this.splitButton1.ImageKey = "Normal";
			this.splitButton1.Location = new Point(4, -1);
			this.splitButton1.Name = "splitButton1";
			this.splitButton1.NormalImage = "Normal";
			this.splitButton1.Size = new Size(46, 24);
			this.splitButton1.TabIndex = 8;
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
			this.meshTab.Controls.Add(this.mlodPropertyGrid);
			this.meshTab.Controls.Add(this.panel1);
			this.meshTab.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.meshTab.Location = new Point(4, 25);
			this.meshTab.Name = "meshTab";
			this.meshTab.Padding = new Padding(3);
			this.meshTab.Size = new Size(341, 477);
			this.meshTab.TabIndex = 2;
			this.meshTab.Text = "Mesh";
			this.meshTab.UseVisualStyleBackColor = true;
			this.mlodPropertyGrid.AdvancedMode = false;
			this.mlodPropertyGrid.BorderStyle = BorderStyle.None;
			this.mlodPropertyGrid.CurrentWrapper = null;
			this.mlodPropertyGrid.Dock = DockStyle.Fill;
			this.mlodPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.mlodPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.mlodPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.mlodPropertyGrid.Location = new Point(3, 86);
			this.mlodPropertyGrid.Model = null;
			this.mlodPropertyGrid.Name = "mlodPropertyGrid";
			this.mlodPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.mlodPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.mlodPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.mlodPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.mlodPropertyGrid.Size = new Size(335, 388);
			this.mlodPropertyGrid.TabIndex = 6;
			this.mlodPropertyGrid.Text = "mlodPropertyGrid1";
			this.panel1.BackColor = Color.Transparent;
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(0, 2, 0, 2);
			this.panel1.Size = new Size(335, 83);
			this.panel1.TabIndex = 5;
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Controls.Add(this.panel8);
			this.panel6.Dock = DockStyle.Fill;
			this.panel6.Location = new Point(0, 28);
			this.panel6.Name = "panel6";
			this.panel6.Size = new Size(335, 53);
			this.panel6.TabIndex = 11;
			this.panel7.Controls.Add(this.Rotationtrackbar);
			this.panel7.Controls.Add(this.rotationLabel);
			this.panel7.Dock = DockStyle.Fill;
			this.panel7.Location = new Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new Size(173, 53);
			this.panel7.TabIndex = 0;
			this.Rotationtrackbar.BackColor = Color.White;
			this.Rotationtrackbar.Dock = DockStyle.Fill;
			this.Rotationtrackbar.LargeChange = 1;
			this.Rotationtrackbar.Location = new Point(0, 19);
			this.Rotationtrackbar.Maximum = 8;
			this.Rotationtrackbar.Name = "Rotationtrackbar";
			this.Rotationtrackbar.Size = new Size(173, 34);
			this.Rotationtrackbar.TabIndex = 16;
			this.Rotationtrackbar.ValueChanged += this.Rotationtrackbar_ValueChanged;
			this.rotationLabel.BackColor = Color.White;
			this.rotationLabel.Dock = DockStyle.Top;
			this.rotationLabel.Location = new Point(0, 0);
			this.rotationLabel.Name = "rotationLabel";
			this.rotationLabel.Padding = new Padding(0, 4, 8, 0);
			this.rotationLabel.Size = new Size(173, 19);
			this.rotationLabel.TabIndex = 15;
			this.rotationLabel.Text = "Rotation (0 degrees):";
			this.panel8.Controls.Add(this.panel9);
			this.panel8.Controls.Add(this.label1);
			this.panel8.Dock = DockStyle.Right;
			this.panel8.Location = new Point(173, 0);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new Padding(3, 0, 3, 0);
			this.panel8.Size = new Size(162, 53);
			this.panel8.TabIndex = 1;
			this.panel9.Controls.Add(this.GeostateCombo);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(3, 19);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new Padding(0, 2, 0, 0);
			this.panel9.Size = new Size(156, 34);
			this.panel9.TabIndex = 17;
			this.GeostateCombo.Dock = DockStyle.Fill;
			this.GeostateCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.GeostateCombo.Enabled = false;
			this.GeostateCombo.FormattingEnabled = true;
			this.GeostateCombo.Location = new Point(0, 2);
			this.GeostateCombo.Name = "GeostateCombo";
			this.GeostateCombo.Size = new Size(156, 21);
			this.GeostateCombo.TabIndex = 18;
			this.GeostateCombo.SelectedIndexChanged += this.GeostateCombo_SelectedIndexChanged;
			this.label1.BackColor = Color.White;
			this.label1.Dock = DockStyle.Top;
			this.label1.Location = new Point(3, 0);
			this.label1.Margin = new Padding(3, 0, 0, 3);
			this.label1.Name = "label1";
			this.label1.Padding = new Padding(0, 4, 8, 0);
			this.label1.Size = new Size(156, 19);
			this.label1.TabIndex = 16;
			this.label1.Text = "Visible geostate:";
			this.panel3.Controls.Add(this.meshgroupCombo);
			this.panel3.Controls.Add(this.panel5);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(0, 2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(335, 26);
			this.panel3.TabIndex = 10;
			this.meshgroupCombo.Dock = DockStyle.Fill;
			this.meshgroupCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.meshgroupCombo.Font = new Font("Tahoma", 9.5f);
			this.meshgroupCombo.FormattingEnabled = true;
			this.meshgroupCombo.ItemHeight = 16;
			this.meshgroupCombo.Location = new Point(0, 0);
			this.meshgroupCombo.Name = "meshgroupCombo";
			this.meshgroupCombo.Size = new Size(216, 24);
			this.meshgroupCombo.TabIndex = 10;
			class2.Text = "Select a mesh to show properties for";
			class2.Title = "Mesh";
			this.visualTipProvider_0.method_3(this.meshgroupCombo, class2);
			this.panel5.Controls.Add(this.button2);
			this.panel5.Controls.Add(this.generateShadowMeshButton);
			this.panel5.Controls.Add(this.importMeshgroupButton);
			this.panel5.Controls.Add(this.exportMeshgroupButton);
			this.panel5.Dock = DockStyle.Right;
			this.panel5.Location = new Point(216, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(119, 26);
			this.panel5.TabIndex = 9;
			this.button2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.button2.Image = Class143.bone;
			this.button2.Location = new Point(94, 0);
			this.button2.Name = "button2";
			this.button2.Size = new Size(26, 26);
			this.button2.TabIndex = 10;
			this.button2.UseVisualStyleBackColor = true;
			class3.Text = "Generate shadow mesh from existing LODS";
			class3.Title = "Generate shadow mesh";
			this.visualTipProvider_0.method_3(this.button2, class3);
			this.button2.Click += this.button2_Click;
			this.generateShadowMeshButton.Enabled = false;
			this.generateShadowMeshButton.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.generateShadowMeshButton.Image = Class143.recreate;
			this.generateShadowMeshButton.Location = new Point(64, -1);
			this.generateShadowMeshButton.Name = "generateShadowMeshButton";
			this.generateShadowMeshButton.Size = new Size(26, 26);
			this.generateShadowMeshButton.TabIndex = 9;
			this.generateShadowMeshButton.UseVisualStyleBackColor = true;
			class4.Text = "Generate shadow mesh from existing LODS";
			class4.Title = "Generate shadow mesh";
			this.visualTipProvider_0.method_3(this.generateShadowMeshButton, class4);
			this.importMeshgroupButton.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.importMeshgroupButton.Image = Class143.import;
			this.importMeshgroupButton.Location = new Point(34, -1);
			this.importMeshgroupButton.Name = "importMeshgroupButton";
			this.importMeshgroupButton.Size = new Size(26, 26);
			this.importMeshgroupButton.TabIndex = 8;
			this.importMeshgroupButton.UseVisualStyleBackColor = true;
			class5.Text = "Import a mesh to the current selection";
			class5.Title = "Import";
			this.visualTipProvider_0.method_3(this.importMeshgroupButton, class5);
			this.exportMeshgroupButton.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.exportMeshgroupButton.Image = Class143.export;
			this.exportMeshgroupButton.Location = new Point(4, -1);
			this.exportMeshgroupButton.Name = "exportMeshgroupButton";
			this.exportMeshgroupButton.Size = new Size(26, 26);
			this.exportMeshgroupButton.TabIndex = 7;
			this.exportMeshgroupButton.UseVisualStyleBackColor = true;
			class6.Text = "Export selected mesh";
			class6.Title = "Export";
			this.visualTipProvider_0.method_3(this.exportMeshgroupButton, class6);
			this.slots.Controls.Add(this.SlotsPropertyGrid);
			this.slots.Location = new Point(4, 25);
			this.slots.Name = "slots";
			this.slots.Padding = new Padding(3);
			this.slots.Size = new Size(341, 477);
			this.slots.TabIndex = 4;
			this.slots.Text = "Slots";
			this.slots.UseVisualStyleBackColor = true;
			this.SlotsPropertyGrid.BorderStyle = BorderStyle.None;
			this.SlotsPropertyGrid.Dock = DockStyle.Fill;
			this.SlotsPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.SlotsPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.SlotsPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.SlotsPropertyGrid.Location = new Point(3, 3);
			this.SlotsPropertyGrid.Name = "SlotsPropertyGrid";
			this.SlotsPropertyGrid.Project = null;
			this.SlotsPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.SlotsPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.SlotsPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.SlotsPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.SlotsPropertyGrid.Size = new Size(335, 471);
			this.SlotsPropertyGrid.TabIndex = 2;
			this.SlotsPropertyGrid.Text = "genericPropertyGrid1";
			this.misc.Controls.Add(this.miscPropertyGrid);
			this.misc.Location = new Point(4, 25);
			this.misc.Name = "misc";
			this.misc.Padding = new Padding(3);
			this.misc.Size = new Size(341, 477);
			this.misc.TabIndex = 3;
			this.misc.Text = "Misc";
			this.misc.UseVisualStyleBackColor = true;
			this.miscPropertyGrid.AdvancedMode = false;
			this.miscPropertyGrid.BorderStyle = BorderStyle.None;
			this.miscPropertyGrid.Dock = DockStyle.Fill;
			this.miscPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.miscPropertyGrid.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.miscPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.miscPropertyGrid.Location = new Point(3, 3);
			this.miscPropertyGrid.Name = "miscPropertyGrid";
			this.miscPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.miscPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.miscPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.miscPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.miscPropertyGrid.Size = new Size(335, 471);
			this.miscPropertyGrid.TabIndex = 0;
			this.miscPropertyGrid.Text = "genericPropertyGrid1";
			this.tabPage1.Location = new Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new Size(341, 477);
			this.tabPage1.TabIndex = 4;
			this.tabPage1.Text = "Slots";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.visualTipProvider_0.Animation = Enum24.const_2;
			this.visualTipProvider_0.InitialDelay = 750;
			this.visualTipProvider_0.Renderer = renderer;
			this.visualTipProvider_0.Shadow = Enum26.const_2;
			this.visualTipProvider_0.ShowAlways = true;
			this.button1.Image = Class143.saveas;
			this.button1.Location = new Point(249, 3);
			this.button1.Name = "button1";
			this.button1.Size = new Size(26, 26);
			this.button1.TabIndex = 4;
			this.button1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.tabControl1);
			base.Name = "ObjdModelControl";
			base.Size = new Size(349, 506);
			this.tabControl1.ResumeLayout(false);
			this.project.ResumeLayout(false);
			((ISupportInitialize)this.objdPropertyGrid).EndInit();
			this.objdSelectorPanel.ResumeLayout(false);
			this.textures.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((ISupportInitialize)this.presetPropertyGrid).EndInit();
			this.selectPresetPanel.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.meshTab.ResumeLayout(false);
			((ISupportInitialize)this.mlodPropertyGrid).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			((ISupportInitialize)this.Rotationtrackbar).EndInit();
			this.panel8.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.slots.ResumeLayout(false);
			((ISupportInitialize)this.SlotsPropertyGrid).EndInit();
			this.misc.ResumeLayout(false);
			((ISupportInitialize)this.miscPropertyGrid).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040004F2 RID: 1266
		private Class80 model;

		// Token: 0x040004F3 RID: 1267
		private ObjdModelControl.Delegate14 delegate14_0;

		// Token: 0x040004F4 RID: 1268
		private ObjdModelControl.Delegate14 delegate14_1;

		// Token: 0x040004F5 RID: 1269
		private ObjdModelControl.Delegate14 delegate14_2;

		// Token: 0x040004F6 RID: 1270
		private ObjdModelControl.Delegate14 delegate14_3;

		// Token: 0x040004F7 RID: 1271
		private IContainer icontainer_0;

		// Token: 0x040004F8 RID: 1272
		private TabControl tabControl1;

		// Token: 0x040004F9 RID: 1273
		private TabPage project;

		// Token: 0x040004FA RID: 1274
		private TabPage textures;

		// Token: 0x040004FB RID: 1275
		public TabPage meshTab;

		// Token: 0x040004FC RID: 1276
		private Panel panel2;

		// Token: 0x040004FD RID: 1277
		private Panel selectPresetPanel;

		// Token: 0x040004FE RID: 1278
		private Class8 presetPropertyGrid;

		// Token: 0x040004FF RID: 1279
		private Class11 objdPropertyGrid;

		// Token: 0x04000500 RID: 1280
		private Button button1;

		// Token: 0x04000501 RID: 1281
		private Class2 miscPropertyGrid;

		// Token: 0x04000502 RID: 1282
		public TabPage misc;

		// Token: 0x04000503 RID: 1283
		private Class3 mlodPropertyGrid;

		// Token: 0x04000504 RID: 1284
		private Panel panel1;

		// Token: 0x04000505 RID: 1285
		private TabPage slots;

		// Token: 0x04000506 RID: 1286
		private TabPage tabPage1;

		// Token: 0x04000507 RID: 1287
		public Class9 SlotsPropertyGrid;

		// Token: 0x04000508 RID: 1288
		public ComboBox presetCombo;

		// Token: 0x04000509 RID: 1289
		private Panel panel4;

		// Token: 0x0400050A RID: 1290
		private VisualTipProvider visualTipProvider_0;

		// Token: 0x0400050B RID: 1291
		public Panel objdSelectorPanel;

		// Token: 0x0400050C RID: 1292
		public ComboBox objdComboBox;

		// Token: 0x0400050D RID: 1293
		private Panel panel3;

		// Token: 0x0400050E RID: 1294
		public ComboBox meshgroupCombo;

		// Token: 0x0400050F RID: 1295
		private Panel panel5;

		// Token: 0x04000510 RID: 1296
		public Button generateShadowMeshButton;

		// Token: 0x04000511 RID: 1297
		public Button importMeshgroupButton;

		// Token: 0x04000512 RID: 1298
		public Button exportMeshgroupButton;

		// Token: 0x04000513 RID: 1299
		private Panel panel6;

		// Token: 0x04000514 RID: 1300
		private Panel panel7;

		// Token: 0x04000515 RID: 1301
		public TrackBar Rotationtrackbar;

		// Token: 0x04000516 RID: 1302
		private Label rotationLabel;

		// Token: 0x04000517 RID: 1303
		private Panel panel8;

		// Token: 0x04000518 RID: 1304
		private Label label1;

		// Token: 0x04000519 RID: 1305
		private Panel panel9;

		// Token: 0x0400051A RID: 1306
		public ComboBox GeostateCombo;

		// Token: 0x0400051B RID: 1307
		private SplitButton splitButton1;

		// Token: 0x0400051C RID: 1308
		private ContextMenuStrip contextMenuStrip1;

		// Token: 0x0400051D RID: 1309
		private ToolStripMenuItem duplicateToolStripMenuItem;

		// Token: 0x0400051E RID: 1310
		private ToolStripSeparator toolStripMenuItem1;

		// Token: 0x0400051F RID: 1311
		private ToolStripMenuItem moveUpToolStripMenuItem;

		// Token: 0x04000520 RID: 1312
		private ToolStripMenuItem moveDownToolStripMenuItem;

		// Token: 0x04000521 RID: 1313
		private ToolStripMenuItem toolStripMenuItem2;

		// Token: 0x04000522 RID: 1314
		public ToolStripMenuItem exportToolStripMenuItem;

		// Token: 0x04000523 RID: 1315
		public Button button2;

		// Token: 0x0200008B RID: 139
		// (Invoke) Token: 0x060005A6 RID: 1446
		private delegate void Delegate14(object o);
	}
}
