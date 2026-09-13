using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns10;
using ns12;
using ns13;
using ns15;
using ns16;
using ns3;
using ns8;
using Package.Sims3Files;
using Sims3WorkshopSDK.Classes;

namespace ns7
{
	// Token: 0x02000006 RID: 6
	internal sealed class BoneWeightControl : UserControl
	{
		// Token: 0x0600000F RID: 15 RVA: 0x0000B9B8 File Offset: 0x00009BB8
		public BoneWeightControl()
		{
			this.InitializeComponent();
			ToolTip toolTip = new ToolTip();
			toolTip.SetToolTip(this.PickFromVertex, "Pick Bone Weight From Vertex");
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002932 File Offset: 0x00000B32
		public void method_0(bool bool_1)
		{
			if (bool_1)
			{
				this.bone1Combo_SelectedIndexChanged(null, null);
				this.bone2Combo_SelectedIndexChanged(null, null);
				this.bone3Combo_SelectedIndexChanged(null, null);
				this.bone4Combo_SelectedIndexChanged(null, null);
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000B9F8 File Offset: 0x00009BF8
		public void method_1(uint[] uint_0)
		{
			this.bone1Combo.SelectedIndex = (int)((uint_0[0] == 0U) ? -1 : this.hashtable_0[uint_0[0]]);
			this.bone2Combo.SelectedIndex = (int)((uint_0[1] == 0U) ? -1 : this.hashtable_0[uint_0[1]]);
			this.bone3Combo.SelectedIndex = (int)((uint_0[2] == 0U) ? -1 : this.hashtable_0[uint_0[2]]);
			this.bone4Combo.SelectedIndex = (int)((uint_0[3] == 0U) ? -1 : this.hashtable_0[uint_0[3]]);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000BAC8 File Offset: 0x00009CC8
		public void method_2(float[] float_0)
		{
			this.trackBar1.Value = (int)(100f * float_0[0]);
			this.trackBar2.Value = (int)(100f * float_0[1]);
			this.trackBar3.Value = (int)(100f * float_0[2]);
			this.trackBar4.Value = (int)(100f * float_0[3]);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000BB2C File Offset: 0x00009D2C
		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				float num = (float)this.trackBar1.Value / 100f;
				this.bone1Weight.Text = Math.Round((double)num, 2).ToString("0.00");
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000BB78 File Offset: 0x00009D78
		private void trackBar2_ValueChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				float num = (float)this.trackBar2.Value / 100f;
				this.bone2Weight.Text = Math.Round((double)num, 2).ToString("0.00");
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000BBC4 File Offset: 0x00009DC4
		private void trackBar3_ValueChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				float num = (float)this.trackBar3.Value / 100f;
				this.bone3Weight.Text = Math.Round((double)num, 2).ToString("0.00");
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000BC10 File Offset: 0x00009E10
		private void trackBar4_ValueChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				float num = (float)this.trackBar4.Value / 100f;
				this.bone4Weight.Text = Math.Round((double)num, 2).ToString("0.00");
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002959 File Offset: 0x00000B59
		private void bone1Combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.bone1Combo.SelectedIndex != -1)
			{
				Class134.smethod_1((this.bone1Combo.SelectedItem as BoneWeightControl.Class12).Hash, 0);
			}
			else
			{
				Class134.smethod_1(0U, 0);
			}
			Class132.mainForm.Render();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002999 File Offset: 0x00000B99
		private void bone2Combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.bone2Combo.SelectedIndex != -1)
			{
				Class134.smethod_1((this.bone2Combo.SelectedItem as BoneWeightControl.Class12).Hash, 1);
			}
			else
			{
				Class134.smethod_1(0U, 1);
			}
			Class132.mainForm.Render();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000029D9 File Offset: 0x00000BD9
		private void bone3Combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.bone3Combo.SelectedIndex != -1)
			{
				Class134.smethod_1((this.bone3Combo.SelectedItem as BoneWeightControl.Class12).Hash, 2);
			}
			else
			{
				Class134.smethod_1(0U, 2);
			}
			Class132.mainForm.Render();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002A19 File Offset: 0x00000C19
		private void bone4Combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.bone4Combo.SelectedIndex != -1)
			{
				Class134.smethod_1((this.bone4Combo.SelectedItem as BoneWeightControl.Class12).Hash, 3);
			}
			else
			{
				Class134.smethod_1(0U, 3);
			}
			Class132.mainForm.Render();
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001B RID: 27 RVA: 0x0000BC5C File Offset: 0x00009E5C
		public float[] Weights
		{
			get
			{
				return new float[]
				{
					(float)this.trackBar1.Value / 100f,
					(float)this.trackBar2.Value / 100f,
					(float)this.trackBar3.Value / 100f,
					(float)this.trackBar4.Value / 100f
				};
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002A59 File Offset: 0x00000C59
		private void BoneWeightControl_Load(object sender, EventArgs e)
		{
			this.method_3();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000BCCC File Offset: 0x00009ECC
		public void method_3()
		{
			this.hashtable_0 = new Hashtable();
			this.bone1Combo.Items.Clear();
			this.bone2Combo.Items.Clear();
			this.bone3Combo.Items.Clear();
			this.bone4Combo.Items.Clear();
			MeshEditor meshEditor = Class132.smethod_0();
			int num = this.bone1Combo.Items.Add(new BoneWeightControl.Class12("none", 0U));
			this.bone2Combo.Items.Add(new BoneWeightControl.Class12("none", 0U));
			this.bone3Combo.Items.Add(new BoneWeightControl.Class12("none", 0U));
			this.bone4Combo.Items.Add(new BoneWeightControl.Class12("none", 0U));
			foreach (Class102 @class in meshEditor.Renderables)
			{
				if (@class is Class104)
				{
					using (List<Class104.Class110>.Enumerator enumerator2 = (@class as Class104).Containers.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							Class104.Class110 class2 = enumerator2.Current;
							if (class2.IsBaseMesh && class2.BoneFile != null)
							{
								foreach (BONE.BoneEntry boneEntry in class2.BoneFile.Bones)
								{
									uint hash = FNV32.GetHash(boneEntry.Name);
									num = this.bone1Combo.Items.Add(new BoneWeightControl.Class12(boneEntry.Name, hash));
									this.bone2Combo.Items.Add(new BoneWeightControl.Class12(boneEntry.Name, hash));
									this.bone3Combo.Items.Add(new BoneWeightControl.Class12(boneEntry.Name, hash));
									this.bone4Combo.Items.Add(new BoneWeightControl.Class12(boneEntry.Name, hash));
									this.hashtable_0.Add(hash, num);
								}
							}
						}
						continue;
					}
				}
				if (@class is Class105)
				{
					foreach (uint num2 in (@class as Class105).Bones)
					{
						string name = "0x" + num2.ToString("X8");
						if ((@class as Class105).GrannyInfo != null)
						{
							foreach (Class34 class3 in (@class as Class105).GrannyInfo.Skeletons)
							{
								if (class3.HashedBones.Contains(num2))
								{
									Class33 class4 = class3.HashedBones[num2] as Class33;
									name = class4.Sims3WorkshopSDK.Interfaces.IBone.Name;
								}
							}
						}
						num = this.bone1Combo.Items.Add(new BoneWeightControl.Class12(name, num2));
						this.bone2Combo.Items.Add(new BoneWeightControl.Class12(name, num2));
						this.bone3Combo.Items.Add(new BoneWeightControl.Class12(name, num2));
						this.bone4Combo.Items.Add(new BoneWeightControl.Class12(name, num2));
						this.hashtable_0.Add(num2, num);
					}
				}
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002A63 File Offset: 0x00000C63
		private void method_4(object sender, EventArgs e)
		{
			Class134.smethod_0().method_1();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002A71 File Offset: 0x00000C71
		private void PickFromVertex_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002A63 File Offset: 0x00000C63
		private void button1_Click(object sender, EventArgs e)
		{
			Class134.smethod_0().method_1();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002A73 File Offset: 0x00000C73
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000C0C8 File Offset: 0x0000A2C8
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BoneWeightControl));
			this.bone4Combo = new ComboBox();
			this.bone1Weight = new TextBox();
			this.bone4Weight = new TextBox();
			this.trackBar1 = new TrackBar();
			this.trackBar2 = new TrackBar();
			this.trackBar3 = new TrackBar();
			this.trackBar4 = new TrackBar();
			this.bone3Combo = new ComboBox();
			this.bone3Weight = new TextBox();
			this.bone1Combo = new ComboBox();
			this.bone2Weight = new TextBox();
			this.bone2Combo = new ComboBox();
			this.PickFromVertex = new CheckBox();
			this.button1 = new Button();
			((ISupportInitialize)this.trackBar1).BeginInit();
			((ISupportInitialize)this.trackBar2).BeginInit();
			((ISupportInitialize)this.trackBar3).BeginInit();
			((ISupportInitialize)this.trackBar4).BeginInit();
			base.SuspendLayout();
			this.bone4Combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.bone4Combo.FormattingEnabled = true;
			this.bone4Combo.Location = new Point(5, 175);
			this.bone4Combo.Name = "bone4Combo";
			this.bone4Combo.Size = new Size(188, 21);
			this.bone4Combo.TabIndex = 25;
			this.bone4Combo.SelectedIndexChanged += this.bone4Combo_SelectedIndexChanged;
			this.bone1Weight.Enabled = false;
			this.bone1Weight.Location = new Point(148, 37);
			this.bone1Weight.Name = "bone1Weight";
			this.bone1Weight.Size = new Size(45, 20);
			this.bone1Weight.TabIndex = 18;
			this.bone1Weight.Text = "0,0";
			this.bone4Weight.Enabled = false;
			this.bone4Weight.Location = new Point(148, 202);
			this.bone4Weight.Name = "bone4Weight";
			this.bone4Weight.Size = new Size(45, 20);
			this.bone4Weight.TabIndex = 27;
			this.bone4Weight.Text = "0,0";
			this.trackBar1.LargeChange = 1;
			this.trackBar1.Location = new Point(-1, 35);
			this.trackBar1.Maximum = 100;
			this.trackBar1.MaximumSize = new Size(150, 23);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new Size(143, 45);
			this.trackBar1.TabIndex = 17;
			this.trackBar1.TickStyle = TickStyle.None;
			this.trackBar1.ValueChanged += this.trackBar1_ValueChanged;
			this.trackBar2.LargeChange = 1;
			this.trackBar2.Location = new Point(-1, 91);
			this.trackBar2.Maximum = 100;
			this.trackBar2.MaximumSize = new Size(150, 23);
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new Size(143, 45);
			this.trackBar2.TabIndex = 20;
			this.trackBar2.TickStyle = TickStyle.None;
			this.trackBar2.ValueChanged += this.trackBar2_ValueChanged;
			this.trackBar3.LargeChange = 1;
			this.trackBar3.Location = new Point(-1, 147);
			this.trackBar3.Maximum = 100;
			this.trackBar3.MaximumSize = new Size(150, 23);
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new Size(143, 45);
			this.trackBar3.TabIndex = 23;
			this.trackBar3.TickStyle = TickStyle.None;
			this.trackBar3.ValueChanged += this.trackBar3_ValueChanged;
			this.trackBar4.LargeChange = 1;
			this.trackBar4.Location = new Point(-1, 202);
			this.trackBar4.Maximum = 100;
			this.trackBar4.MaximumSize = new Size(150, 23);
			this.trackBar4.Name = "trackBar4";
			this.trackBar4.Size = new Size(143, 45);
			this.trackBar4.TabIndex = 26;
			this.trackBar4.TickStyle = TickStyle.None;
			this.trackBar4.ValueChanged += this.trackBar4_ValueChanged;
			this.bone3Combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.bone3Combo.FormattingEnabled = true;
			this.bone3Combo.Location = new Point(5, 120);
			this.bone3Combo.Name = "bone3Combo";
			this.bone3Combo.Size = new Size(188, 21);
			this.bone3Combo.TabIndex = 22;
			this.bone3Combo.SelectedIndexChanged += this.bone3Combo_SelectedIndexChanged;
			this.bone3Weight.Enabled = false;
			this.bone3Weight.Location = new Point(148, 149);
			this.bone3Weight.Name = "bone3Weight";
			this.bone3Weight.Size = new Size(45, 20);
			this.bone3Weight.TabIndex = 24;
			this.bone3Weight.Text = "0,0";
			this.bone1Combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.bone1Combo.FormattingEnabled = true;
			this.bone1Combo.Location = new Point(7, 8);
			this.bone1Combo.Name = "bone1Combo";
			this.bone1Combo.Size = new Size(186, 21);
			this.bone1Combo.TabIndex = 16;
			this.bone1Combo.SelectedIndexChanged += this.bone1Combo_SelectedIndexChanged;
			this.bone2Weight.Enabled = false;
			this.bone2Weight.Location = new Point(148, 93);
			this.bone2Weight.Name = "bone2Weight";
			this.bone2Weight.Size = new Size(45, 20);
			this.bone2Weight.TabIndex = 21;
			this.bone2Weight.Text = "0,0";
			this.bone2Combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.bone2Combo.FormattingEnabled = true;
			this.bone2Combo.Location = new Point(5, 66);
			this.bone2Combo.Name = "bone2Combo";
			this.bone2Combo.Size = new Size(188, 21);
			this.bone2Combo.TabIndex = 19;
			this.bone2Combo.SelectedIndexChanged += this.bone2Combo_SelectedIndexChanged;
			this.PickFromVertex.Appearance = Appearance.Button;
			this.PickFromVertex.Image = (Image)componentResourceManager.GetObject("PickFromVertex.Image");
			this.PickFromVertex.Location = new Point(165, 230);
			this.PickFromVertex.Name = "PickFromVertex";
			this.PickFromVertex.Size = new Size(28, 28);
			this.PickFromVertex.TabIndex = 29;
			this.PickFromVertex.UseVisualStyleBackColor = true;
			this.PickFromVertex.Click += this.PickFromVertex_Click;
			this.button1.Location = new Point(5, 230);
			this.button1.Name = "button1";
			this.button1.Size = new Size(154, 28);
			this.button1.TabIndex = 30;
			this.button1.Text = "Assign To Selected";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += this.button1_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(182, 225, 131);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.PickFromVertex);
			base.Controls.Add(this.bone1Combo);
			base.Controls.Add(this.bone4Combo);
			base.Controls.Add(this.bone1Weight);
			base.Controls.Add(this.bone4Weight);
			base.Controls.Add(this.trackBar3);
			base.Controls.Add(this.trackBar4);
			base.Controls.Add(this.bone3Combo);
			base.Controls.Add(this.bone3Weight);
			base.Controls.Add(this.bone2Weight);
			base.Controls.Add(this.bone2Combo);
			base.Controls.Add(this.trackBar1);
			base.Controls.Add(this.trackBar2);
			base.Name = "BoneWeightControl";
			base.Padding = new Padding(4);
			base.Size = new Size(200, 337);
			base.Load += this.BoneWeightControl_Load;
			((ISupportInitialize)this.trackBar1).EndInit();
			((ISupportInitialize)this.trackBar2).EndInit();
			((ISupportInitialize)this.trackBar3).EndInit();
			((ISupportInitialize)this.trackBar4).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400001D RID: 29
		private bool bool_0;

		// Token: 0x0400001E RID: 30
		private Hashtable hashtable_0 = new Hashtable();

		// Token: 0x0400001F RID: 31
		private IContainer icontainer_0;

		// Token: 0x04000020 RID: 32
		private ComboBox bone4Combo;

		// Token: 0x04000021 RID: 33
		private TextBox bone1Weight;

		// Token: 0x04000022 RID: 34
		private TextBox bone4Weight;

		// Token: 0x04000023 RID: 35
		private TrackBar trackBar1;

		// Token: 0x04000024 RID: 36
		private TrackBar trackBar2;

		// Token: 0x04000025 RID: 37
		private TrackBar trackBar3;

		// Token: 0x04000026 RID: 38
		private TrackBar trackBar4;

		// Token: 0x04000027 RID: 39
		private ComboBox bone3Combo;

		// Token: 0x04000028 RID: 40
		private TextBox bone3Weight;

		// Token: 0x04000029 RID: 41
		private ComboBox bone1Combo;

		// Token: 0x0400002A RID: 42
		private TextBox bone2Weight;

		// Token: 0x0400002B RID: 43
		private ComboBox bone2Combo;

		// Token: 0x0400002C RID: 44
		public CheckBox PickFromVertex;

		// Token: 0x0400002D RID: 45
		private Button button1;

		// Token: 0x02000007 RID: 7
		private sealed class Class12
		{
			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000023 RID: 35 RVA: 0x0000CA40 File Offset: 0x0000AC40
			// (set) Token: 0x06000024 RID: 36 RVA: 0x00002A94 File Offset: 0x00000C94
			public uint Hash { get; set; }

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000025 RID: 37 RVA: 0x0000CA58 File Offset: 0x0000AC58
			// (set) Token: 0x06000026 RID: 38 RVA: 0x00002A9F File Offset: 0x00000C9F
			public string Name { get; set; }

			// Token: 0x06000027 RID: 39 RVA: 0x00002AAA File Offset: 0x00000CAA
			public Class12(string name, uint hash)
			{
				this.Hash = hash;
				this.Name = name;
			}

			// Token: 0x06000028 RID: 40 RVA: 0x0000CA70 File Offset: 0x0000AC70
			public string ToString()
			{
				return this.Name;
			}

			// Token: 0x0400002E RID: 46
			[CompilerGenerated]
			private uint uint_0;

			// Token: 0x0400002F RID: 47
			[CompilerGenerated]
			private string string_0;
		}
	}
}
