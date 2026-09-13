using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns18;
using ns2;
using ns3;
using ns4;
using ns9;
using VisualHint.SmartPropertyGrid;

namespace ns0
{
	// Token: 0x02000002 RID: 2
	internal sealed class BlueprintModelControl : UserControl
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x0000A660 File Offset: 0x00008860
		// (set) Token: 0x06000002 RID: 2 RVA: 0x000028BC File Offset: 0x00000ABC
		public BlueprintModelControl.Enum0 ToolMode { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x0000A678 File Offset: 0x00008878
		// (set) Token: 0x06000004 RID: 4 RVA: 0x000028C7 File Offset: 0x00000AC7
		public Form CurrentWindow { get; set; }

		// Token: 0x06000005 RID: 5 RVA: 0x000028D2 File Offset: 0x00000AD2
		public BlueprintModelControl(Class26 model)
		{
			this.model = model;
			this.InitializeComponent();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000A690 File Offset: 0x00008890
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				this.checkBox3.Checked = true;
				CheckBox checkBox = this.checkBox2;
				this.checkBox4.Checked = false;
				checkBox.Checked = false;
				this.ToolMode = BlueprintModelControl.Enum0.const_1;
				if (this.CurrentWindow != null)
				{
					this.CurrentWindow.Close();
				}
				this.CurrentWindow = new ObjectToolWindow();
				this.CurrentWindow.Show(this);
				this.CurrentWindow.Location = base.PointToScreen(base.Location);
				this.bool_0 = false;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000A728 File Offset: 0x00008928
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				this.checkBox2.Checked = true;
				CheckBox checkBox = this.checkBox3;
				this.checkBox4.Checked = false;
				checkBox.Checked = false;
				this.ToolMode = BlueprintModelControl.Enum0.const_0;
				if (this.CurrentWindow != null)
				{
					this.CurrentWindow.Close();
				}
				this.CurrentWindow = new BuildToolWindow();
				this.CurrentWindow.Show(this);
				this.CurrentWindow.Location = base.PointToScreen(base.Location);
				this.bool_0 = false;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000A7C0 File Offset: 0x000089C0
		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				this.checkBox4.Checked = true;
				CheckBox checkBox = this.checkBox3;
				this.checkBox2.Checked = false;
				checkBox.Checked = false;
				this.ToolMode = BlueprintModelControl.Enum0.const_2;
				if (this.CurrentWindow != null)
				{
					this.CurrentWindow.Close();
				}
				this.CurrentWindow = new SymbolToolWindow();
				this.CurrentWindow.Show(this);
				this.CurrentWindow.Location = base.PointToScreen(base.Location);
				this.bool_0 = false;
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000028E9 File Offset: 0x00000AE9
		private void button1_Click(object sender, EventArgs e)
		{
			this.model.method_15();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000028F8 File Offset: 0x00000AF8
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000A858 File Offset: 0x00008A58
		private void InitializeComponent()
		{
			this.tabPage1 = new TabPage();
			this.tabControl1 = new TabControl();
			this.tabPage2 = new TabPage();
			this.MiscPropertyGrid = new Class2();
			this.tabPage3 = new TabPage();
			this.MLODPropertyGrid = new Class3();
			this.tabPage4 = new TabPage();
			this.ObjectsPropertyGrid = new Class1();
			this.tabPage5 = new TabPage();
			this.tableLayoutPanel2 = new TableLayoutPanel();
			this.checkBox4 = new CheckBox();
			this.label2 = new Label();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.checkBox3 = new CheckBox();
			this.checkBox2 = new CheckBox();
			this.label1 = new Label();
			this.panel1 = new Panel();
			this.BlueprintPropertyGrid = new Class1();
			this.button1 = new Button();
			this.tabPage1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((ISupportInitialize)this.MiscPropertyGrid).BeginInit();
			this.tabPage3.SuspendLayout();
			((ISupportInitialize)this.MLODPropertyGrid).BeginInit();
			this.tabPage4.SuspendLayout();
			((ISupportInitialize)this.ObjectsPropertyGrid).BeginInit();
			this.tabPage5.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.BlueprintPropertyGrid).BeginInit();
			base.SuspendLayout();
			this.tabPage1.Controls.Add(this.BlueprintPropertyGrid);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Font = new Font("Tahoma", 8.25f);
			this.tabPage1.Location = new Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new Padding(3);
			this.tabPage1.Size = new Size(276, 463);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Blueprint";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Dock = DockStyle.Fill;
			this.tabControl1.Font = new Font("Tahoma", 9f, FontStyle.Bold);
			this.tabControl1.Location = new Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new Size(284, 490);
			this.tabControl1.TabIndex = 0;
			this.tabPage2.Controls.Add(this.MiscPropertyGrid);
			this.tabPage2.Location = new Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new Size(276, 463);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Misc";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.MiscPropertyGrid.AdvancedMode = false;
			this.MiscPropertyGrid.BorderStyle = BorderStyle.None;
			this.MiscPropertyGrid.Dock = DockStyle.Fill;
			this.MiscPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.MiscPropertyGrid.Font = new Font("Tahoma", 8.25f);
			this.MiscPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.MiscPropertyGrid.Location = new Point(0, 0);
			this.MiscPropertyGrid.Name = "MiscPropertyGrid";
			this.MiscPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.MiscPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.MiscPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.MiscPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.MiscPropertyGrid.Size = new Size(276, 463);
			this.MiscPropertyGrid.TabIndex = 1;
			this.tabPage3.Controls.Add(this.MLODPropertyGrid);
			this.tabPage3.Location = new Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new Size(276, 463);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Mesh";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.MLODPropertyGrid.AdvancedMode = false;
			this.MLODPropertyGrid.BorderStyle = BorderStyle.None;
			this.MLODPropertyGrid.CurrentWrapper = null;
			this.MLODPropertyGrid.Dock = DockStyle.Fill;
			this.MLODPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.MLODPropertyGrid.Font = new Font("Tahoma", 8.25f);
			this.MLODPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.MLODPropertyGrid.Location = new Point(0, 0);
			this.MLODPropertyGrid.Model = null;
			this.MLODPropertyGrid.Name = "MLODPropertyGrid";
			this.MLODPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.MLODPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.MLODPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.MLODPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.MLODPropertyGrid.Size = new Size(276, 463);
			this.MLODPropertyGrid.TabIndex = 0;
			this.MLODPropertyGrid.Text = "MLODPropertyGrid";
			this.tabPage4.Controls.Add(this.ObjectsPropertyGrid);
			this.tabPage4.Location = new Point(4, 23);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new Size(276, 463);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Objects";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.ObjectsPropertyGrid.BorderStyle = BorderStyle.None;
			this.ObjectsPropertyGrid.Dock = DockStyle.Fill;
			this.ObjectsPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.ObjectsPropertyGrid.Font = new Font("Tahoma", 8.25f);
			this.ObjectsPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.ObjectsPropertyGrid.Location = new Point(0, 0);
			this.ObjectsPropertyGrid.Name = "ObjectsPropertyGrid";
			this.ObjectsPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.ObjectsPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.ObjectsPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.ObjectsPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.ObjectsPropertyGrid.Size = new Size(276, 463);
			this.ObjectsPropertyGrid.TabIndex = 1;
			this.tabPage5.Controls.Add(this.tableLayoutPanel2);
			this.tabPage5.Controls.Add(this.label2);
			this.tabPage5.Controls.Add(this.tableLayoutPanel1);
			this.tabPage5.Controls.Add(this.label1);
			this.tabPage5.Font = new Font("Tahoma", 8.25f);
			this.tabPage5.Location = new Point(4, 23);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new Size(276, 463);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Tools";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel2.Controls.Add(this.checkBox4, 0, 0);
			this.tableLayoutPanel2.Dock = DockStyle.Top;
			this.tableLayoutPanel2.Location = new Point(0, 97);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel2.Size = new Size(276, 100);
			this.tableLayoutPanel2.TabIndex = 8;
			this.checkBox4.Appearance = Appearance.Button;
			this.checkBox4.AutoSize = true;
			this.checkBox4.Dock = DockStyle.Fill;
			this.checkBox4.Location = new Point(3, 3);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new Size(132, 44);
			this.checkBox4.TabIndex = 11;
			this.checkBox4.Text = "Symbol Tool";
			this.checkBox4.TextAlign = ContentAlignment.MiddleCenter;
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckedChanged += this.checkBox4_CheckedChanged;
			this.label2.BackColor = Color.Gray;
			this.label2.Dock = DockStyle.Top;
			this.label2.ForeColor = Color.White;
			this.label2.Location = new Point(0, 74);
			this.label2.Name = "label2";
			this.label2.Padding = new Padding(4);
			this.label2.Size = new Size(276, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Footprint Tools";
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.checkBox3, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.checkBox2, 0, 0);
			this.tableLayoutPanel1.Dock = DockStyle.Top;
			this.tableLayoutPanel1.Location = new Point(0, 23);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51f));
			this.tableLayoutPanel1.Size = new Size(276, 51);
			this.tableLayoutPanel1.TabIndex = 6;
			this.checkBox3.Appearance = Appearance.Button;
			this.checkBox3.AutoSize = true;
			this.checkBox3.Dock = DockStyle.Fill;
			this.checkBox3.Location = new Point(3, 3);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new Size(132, 45);
			this.checkBox3.TabIndex = 11;
			this.checkBox3.Text = "Object Tool";
			this.checkBox3.TextAlign = ContentAlignment.MiddleCenter;
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += this.checkBox3_CheckedChanged;
			this.checkBox2.Appearance = Appearance.Button;
			this.checkBox2.AutoSize = true;
			this.checkBox2.Dock = DockStyle.Fill;
			this.checkBox2.Location = new Point(141, 3);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new Size(132, 45);
			this.checkBox2.TabIndex = 10;
			this.checkBox2.Text = "Build Tool";
			this.checkBox2.TextAlign = ContentAlignment.MiddleCenter;
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += this.checkBox2_CheckedChanged;
			this.label1.BackColor = Color.Gray;
			this.label1.Dock = DockStyle.Top;
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new Padding(4);
			this.label1.Size = new Size(276, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Object Tools";
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(270, 28);
			this.panel1.TabIndex = 1;
			this.BlueprintPropertyGrid.BorderStyle = BorderStyle.None;
			this.BlueprintPropertyGrid.Dock = DockStyle.Fill;
			this.BlueprintPropertyGrid.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.BlueprintPropertyGrid.Font = new Font("Tahoma", 8.25f);
			this.BlueprintPropertyGrid.GridColor = Color.FromArgb(199, 221, 167);
			this.BlueprintPropertyGrid.Location = new Point(3, 31);
			this.BlueprintPropertyGrid.Name = "BlueprintPropertyGrid";
			this.BlueprintPropertyGrid.PropertyLabelBackColor = SystemColors.Window;
			this.BlueprintPropertyGrid.PropertyValueBackColor = SystemColors.Window;
			this.BlueprintPropertyGrid.SelectedBackColor = Color.FromArgb(74, 88, 43);
			this.BlueprintPropertyGrid.SelectedNotFocusedBackColor = Color.FromArgb(199, 221, 167);
			this.BlueprintPropertyGrid.Size = new Size(270, 429);
			this.BlueprintPropertyGrid.TabIndex = 2;
			this.button1.Dock = DockStyle.Fill;
			this.button1.Location = new Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new Size(270, 28);
			this.button1.TabIndex = 0;
			this.button1.Text = "Generate New";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += this.button1_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.tabControl1);
			base.Name = "BlueprintModelControl";
			base.Size = new Size(284, 490);
			this.tabPage1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((ISupportInitialize)this.MiscPropertyGrid).EndInit();
			this.tabPage3.ResumeLayout(false);
			((ISupportInitialize)this.MLODPropertyGrid).EndInit();
			this.tabPage4.ResumeLayout(false);
			((ISupportInitialize)this.ObjectsPropertyGrid).EndInit();
			this.tabPage5.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			((ISupportInitialize)this.BlueprintPropertyGrid).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private Class26 model;

		// Token: 0x04000002 RID: 2
		private bool bool_0;

		// Token: 0x04000003 RID: 3
		private IContainer icontainer_0;

		// Token: 0x04000004 RID: 4
		private TabPage tabPage1;

		// Token: 0x04000005 RID: 5
		private TabControl tabControl1;

		// Token: 0x04000006 RID: 6
		private TabPage tabPage2;

		// Token: 0x04000007 RID: 7
		public Class2 MiscPropertyGrid;

		// Token: 0x04000008 RID: 8
		private TabPage tabPage3;

		// Token: 0x04000009 RID: 9
		public Class3 MLODPropertyGrid;

		// Token: 0x0400000A RID: 10
		private TabPage tabPage4;

		// Token: 0x0400000B RID: 11
		public Class1 ObjectsPropertyGrid;

		// Token: 0x0400000C RID: 12
		private TabPage tabPage5;

		// Token: 0x0400000D RID: 13
		private TableLayoutPanel tableLayoutPanel2;

		// Token: 0x0400000E RID: 14
		private Label label2;

		// Token: 0x0400000F RID: 15
		private Label label1;

		// Token: 0x04000010 RID: 16
		private TableLayoutPanel tableLayoutPanel1;

		// Token: 0x04000011 RID: 17
		private CheckBox checkBox2;

		// Token: 0x04000012 RID: 18
		private CheckBox checkBox4;

		// Token: 0x04000013 RID: 19
		private CheckBox checkBox3;

		// Token: 0x04000014 RID: 20
		public Class1 BlueprintPropertyGrid;

		// Token: 0x04000015 RID: 21
		private Panel panel1;

		// Token: 0x04000016 RID: 22
		private Button button1;

		// Token: 0x04000017 RID: 23
		[CompilerGenerated]
		private BlueprintModelControl.Enum0 enum0_0;

		// Token: 0x04000018 RID: 24
		[CompilerGenerated]
		private Form form_0;

		// Token: 0x02000003 RID: 3
		public enum Enum0
		{
			// Token: 0x0400001A RID: 26
			const_0 = 1,
			// Token: 0x0400001B RID: 27
			const_1,
			// Token: 0x0400001C RID: 28
			const_2
		}
	}
}
