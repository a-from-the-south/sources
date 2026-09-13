using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns10;
using ns8;
using Sims3Workshop.Properties;

namespace ns13
{
	// Token: 0x02000132 RID: 306
	internal sealed class Control7 : UserControl, Interface11
	{
		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000E36 RID: 3638 RVA: 0x000B2970 File Offset: 0x000B0B70
		// (set) Token: 0x06000E37 RID: 3639 RVA: 0x00002A71 File Offset: 0x00000C71
		public new string Name
		{
			get
			{
				return "Mesh Editor";
			}
			set
			{
			}
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x000B2988 File Offset: 0x000B0B88
		public Control7()
		{
			this.method_1();
			this.color_1 = (this.meshEditorColor.BackColor = Settings.Default.MesheditorBackgroundColor);
			this.color_2 = (this.skinColor.BackColor = Settings.Default.SkinColor);
			this.color_0 = (this.ambientColor.BackColor = Settings.Default.AmbientLighting);
			this.color_3 = (this.groundColor.BackColor = Settings.Default.GroundColor);
			this.float_0 = (float)(this.redAdjustBar.Value = (int)Settings.Default.redAdjust);
			this.float_1 = (float)(this.greenAdjustBar.Value = (int)Settings.Default.greenAdjust);
			this.float_2 = (float)(this.blueAdjustBar.Value = (int)Settings.Default.blueAdjust);
			this.color_4 = (this.gridColor.BackColor = Settings.Default.GridColor);
			this.trackBar1.Value = (int)Settings.Default.AmbientLighting.R;
			this.redLabel.Text = "Red (" + this.redAdjustBar.Value + ")";
			this.greenLabel.Text = "Green (" + this.greenAdjustBar.Value + ")";
			this.blueLabel.Text = "Blue (" + this.blueAdjustBar.Value + ")";
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x000B2B40 File Offset: 0x000B0D40
		public void imethod_0()
		{
			Settings.Default.SkinColor = this.skinColor.BackColor;
			Settings.Default.AmbientLighting = this.ambientColor.BackColor;
			Settings.Default.MesheditorBackgroundColor = this.meshEditorColor.BackColor;
			Settings.Default.GroundColor = this.groundColor.BackColor;
			Settings.Default.redAdjust = (float)this.redAdjustBar.Value;
			Settings.Default.greenAdjust = (float)this.greenAdjustBar.Value;
			Settings.Default.blueAdjust = (float)this.blueAdjustBar.Value;
			Settings.Default.GridColor = this.gridColor.BackColor;
			Settings.Default.Save();
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x000B2C04 File Offset: 0x000B0E04
		public void imethod_1()
		{
			Settings.Default.AmbientLighting = this.color_0;
			Settings.Default.MesheditorBackgroundColor = this.color_1;
			Settings.Default.SkinColor = this.color_2;
			Settings.Default.GroundColor = this.color_3;
			Settings.Default.redAdjust = this.float_0;
			Settings.Default.greenAdjust = this.float_1;
			Settings.Default.blueAdjust = this.float_2;
			Settings.Default.GridColor = this.color_4;
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x000B2C94 File Offset: 0x000B0E94
		private void meshEditorColor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				Settings.Default.MesheditorBackgroundColor = (this.meshEditorColor.BackColor = colorDialog.Color);
			}
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x000B2CD4 File Offset: 0x000B0ED4
		private void skinColor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				Settings.Default.SkinColor = (this.skinColor.BackColor = colorDialog.Color);
			}
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x000B2D14 File Offset: 0x000B0F14
		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default.AmbientLighting = (this.ambientColor.BackColor = Color.FromArgb(255, this.trackBar1.Value, this.trackBar1.Value, this.trackBar1.Value));
			Class132.smethod_0().method_35();
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x000B2D70 File Offset: 0x000B0F70
		private void groundColor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				Settings.Default.GroundColor = (this.groundColor.BackColor = colorDialog.Color);
			}
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x000B2DB0 File Offset: 0x000B0FB0
		private void redAdjustBar_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default.redAdjust = (float)this.redAdjustBar.Value;
			this.redLabel.Text = "Red (" + this.redAdjustBar.Value + ")";
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x000B2E00 File Offset: 0x000B1000
		private void greenAdjustBar_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default.greenAdjust = (float)this.greenAdjustBar.Value;
			this.greenLabel.Text = "Green (" + this.greenAdjustBar.Value + ")";
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x000B2E50 File Offset: 0x000B1050
		private void blueAdjustBar_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default.blueAdjust = (float)this.blueAdjustBar.Value;
			this.blueLabel.Text = "Blue (" + this.blueAdjustBar.Value + ")";
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x00002A71 File Offset: 0x00000C71
		private void meshEditorColor_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x000B2EA0 File Offset: 0x000B10A0
		private void gridColor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				Settings.Default.GridColor = (this.gridColor.BackColor = colorDialog.Color);
				MessageBox.Show("Changing the grid color requires a restart before you can see the changes.", "Grid color");
			}
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x00007BAB File Offset: 0x00005DAB
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x000B2EF0 File Offset: 0x000B10F0
		private void method_1()
		{
			this.panel1 = new Panel();
			this.groupBox1 = new GroupBox();
			this.groundColor = new Panel();
			this.label3 = new Label();
			this.skinColor = new Panel();
			this.label2 = new Label();
			this.meshEditorColor = new Panel();
			this.label1 = new Label();
			this.panel3 = new Panel();
			this.groupBox2 = new GroupBox();
			this.ambientColor = new Panel();
			this.trackBar1 = new TrackBar();
			this.panel2 = new Panel();
			this.groupBox3 = new GroupBox();
			this.blueAdjustBar = new TrackBar();
			this.greenAdjustBar = new TrackBar();
			this.blueLabel = new Label();
			this.greenLabel = new Label();
			this.redLabel = new Label();
			this.redAdjustBar = new TrackBar();
			this.gridColor = new Panel();
			this.label4 = new Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.trackBar1).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((ISupportInitialize)this.blueAdjustBar).BeginInit();
			((ISupportInitialize)this.greenAdjustBar).BeginInit();
			((ISupportInitialize)this.redAdjustBar).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(397, 95);
			this.panel1.TabIndex = 0;
			this.groupBox1.Controls.Add(this.gridColor);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.groundColor);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.skinColor);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.meshEditorColor);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(397, 95);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Colors";
			this.groundColor.Location = new Point(258, 20);
			this.groundColor.Name = "groundColor";
			this.groundColor.Size = new Size(24, 24);
			this.groundColor.TabIndex = 9;
			this.groundColor.Click += this.groundColor_Click;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(287, 26);
			this.label3.Name = "label3";
			this.label3.Size = new Size(69, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Ground Color";
			this.skinColor.Location = new Point(147, 20);
			this.skinColor.Name = "skinColor";
			this.skinColor.Size = new Size(24, 24);
			this.skinColor.TabIndex = 7;
			this.skinColor.Click += this.skinColor_Click;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(176, 26);
			this.label2.Name = "label2";
			this.label2.Size = new Size(55, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Skin Color";
			this.meshEditorColor.Location = new Point(12, 20);
			this.meshEditorColor.Name = "meshEditorColor";
			this.meshEditorColor.Size = new Size(24, 24);
			this.meshEditorColor.TabIndex = 5;
			this.meshEditorColor.Paint += this.meshEditorColor_Paint;
			this.meshEditorColor.Click += this.meshEditorColor_Click;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(41, 26);
			this.label1.Name = "label1";
			this.label1.Size = new Size(92, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Background Color";
			this.panel3.Controls.Add(this.groupBox2);
			this.panel3.Dock = DockStyle.Top;
			this.panel3.Location = new Point(0, 95);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new Padding(0, 8, 0, 0);
			this.panel3.Size = new Size(397, 79);
			this.panel3.TabIndex = 1;
			this.groupBox2.Controls.Add(this.ambientColor);
			this.groupBox2.Controls.Add(this.trackBar1);
			this.groupBox2.Dock = DockStyle.Fill;
			this.groupBox2.Location = new Point(0, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(397, 71);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Ambient light";
			this.ambientColor.Location = new Point(12, 23);
			this.ambientColor.Name = "ambientColor";
			this.ambientColor.Size = new Size(24, 24);
			this.ambientColor.TabIndex = 7;
			this.trackBar1.Location = new Point(44, 23);
			this.trackBar1.Maximum = 255;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new Size(214, 45);
			this.trackBar1.TabIndex = 8;
			this.trackBar1.TickStyle = TickStyle.None;
			this.trackBar1.ValueChanged += this.trackBar1_ValueChanged;
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(0, 174);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new Padding(0, 8, 0, 0);
			this.panel2.Size = new Size(397, 75);
			this.panel2.TabIndex = 2;
			this.groupBox3.Controls.Add(this.blueAdjustBar);
			this.groupBox3.Controls.Add(this.greenAdjustBar);
			this.groupBox3.Controls.Add(this.blueLabel);
			this.groupBox3.Controls.Add(this.greenLabel);
			this.groupBox3.Controls.Add(this.redLabel);
			this.groupBox3.Controls.Add(this.redAdjustBar);
			this.groupBox3.Dock = DockStyle.Fill;
			this.groupBox3.Location = new Point(0, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(397, 67);
			this.groupBox3.TabIndex = 10;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Color adjust";
			this.blueAdjustBar.Location = new Point(308, 19);
			this.blueAdjustBar.Maximum = 100;
			this.blueAdjustBar.Minimum = -100;
			this.blueAdjustBar.Name = "blueAdjustBar";
			this.blueAdjustBar.Size = new Size(77, 45);
			this.blueAdjustBar.TabIndex = 15;
			this.blueAdjustBar.TickStyle = TickStyle.None;
			this.blueAdjustBar.ValueChanged += this.blueAdjustBar_ValueChanged;
			this.greenAdjustBar.Location = new Point(175, 19);
			this.greenAdjustBar.Maximum = 100;
			this.greenAdjustBar.Minimum = -100;
			this.greenAdjustBar.Name = "greenAdjustBar";
			this.greenAdjustBar.Size = new Size(77, 45);
			this.greenAdjustBar.TabIndex = 14;
			this.greenAdjustBar.TickStyle = TickStyle.None;
			this.greenAdjustBar.ValueChanged += this.greenAdjustBar_ValueChanged;
			this.blueLabel.AutoSize = true;
			this.blueLabel.Location = new Point(262, 23);
			this.blueLabel.Name = "blueLabel";
			this.blueLabel.Size = new Size(28, 13);
			this.blueLabel.TabIndex = 13;
			this.blueLabel.Text = "Blue";
			this.greenLabel.AutoSize = true;
			this.greenLabel.Location = new Point(123, 23);
			this.greenLabel.Name = "greenLabel";
			this.greenLabel.Size = new Size(36, 13);
			this.greenLabel.TabIndex = 11;
			this.greenLabel.Text = "Green";
			this.redLabel.AutoSize = true;
			this.redLabel.Location = new Point(7, 23);
			this.redLabel.Name = "redLabel";
			this.redLabel.Size = new Size(27, 13);
			this.redLabel.TabIndex = 9;
			this.redLabel.Text = "Red";
			this.redAdjustBar.Location = new Point(46, 19);
			this.redAdjustBar.Maximum = 100;
			this.redAdjustBar.Minimum = -100;
			this.redAdjustBar.Name = "redAdjustBar";
			this.redAdjustBar.Size = new Size(77, 45);
			this.redAdjustBar.TabIndex = 8;
			this.redAdjustBar.TickStyle = TickStyle.None;
			this.redAdjustBar.ValueChanged += this.redAdjustBar_ValueChanged;
			this.gridColor.Location = new Point(12, 58);
			this.gridColor.Name = "gridColor";
			this.gridColor.Size = new Size(24, 24);
			this.gridColor.TabIndex = 11;
			this.gridColor.Click += this.gridColor_Click;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(41, 64);
			this.label4.Name = "label4";
			this.label4.Size = new Size(56, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = " Grid Color";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel1);
			this.Name = "MeshEditorSettings";
			base.Size = new Size(397, 407);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize)this.trackBar1).EndInit();
			this.panel2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((ISupportInitialize)this.blueAdjustBar).EndInit();
			((ISupportInitialize)this.greenAdjustBar).EndInit();
			((ISupportInitialize)this.redAdjustBar).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000ADE RID: 2782
		private Color color_0;

		// Token: 0x04000ADF RID: 2783
		private Color color_1;

		// Token: 0x04000AE0 RID: 2784
		private Color color_2;

		// Token: 0x04000AE1 RID: 2785
		private Color color_3;

		// Token: 0x04000AE2 RID: 2786
		private Color color_4;

		// Token: 0x04000AE3 RID: 2787
		private float float_0;

		// Token: 0x04000AE4 RID: 2788
		private float float_1;

		// Token: 0x04000AE5 RID: 2789
		private float float_2;

		// Token: 0x04000AE6 RID: 2790
		private IContainer icontainer_0;

		// Token: 0x04000AE7 RID: 2791
		private Panel panel1;

		// Token: 0x04000AE8 RID: 2792
		private GroupBox groupBox1;

		// Token: 0x04000AE9 RID: 2793
		private Panel skinColor;

		// Token: 0x04000AEA RID: 2794
		private Label label2;

		// Token: 0x04000AEB RID: 2795
		private Panel meshEditorColor;

		// Token: 0x04000AEC RID: 2796
		private Label label1;

		// Token: 0x04000AED RID: 2797
		private Panel panel3;

		// Token: 0x04000AEE RID: 2798
		private GroupBox groupBox2;

		// Token: 0x04000AEF RID: 2799
		private Panel ambientColor;

		// Token: 0x04000AF0 RID: 2800
		private TrackBar trackBar1;

		// Token: 0x04000AF1 RID: 2801
		private Panel groundColor;

		// Token: 0x04000AF2 RID: 2802
		private Label label3;

		// Token: 0x04000AF3 RID: 2803
		private Panel panel2;

		// Token: 0x04000AF4 RID: 2804
		private GroupBox groupBox3;

		// Token: 0x04000AF5 RID: 2805
		private TrackBar blueAdjustBar;

		// Token: 0x04000AF6 RID: 2806
		private TrackBar greenAdjustBar;

		// Token: 0x04000AF7 RID: 2807
		private Label blueLabel;

		// Token: 0x04000AF8 RID: 2808
		private Label greenLabel;

		// Token: 0x04000AF9 RID: 2809
		private Label redLabel;

		// Token: 0x04000AFA RID: 2810
		private TrackBar redAdjustBar;

		// Token: 0x04000AFB RID: 2811
		private Panel gridColor;

		// Token: 0x04000AFC RID: 2812
		private Label label4;
	}
}
