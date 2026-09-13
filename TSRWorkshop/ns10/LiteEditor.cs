using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns16;
using Package.Sims3Files;
using Sims3WorkshopSDK;

namespace ns10
{
	// Token: 0x0200000A RID: 10
	internal sealed partial class LiteEditor : Form
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000033 RID: 51 RVA: 0x0000EC50 File Offset: 0x0000CE50
		// (set) Token: 0x06000034 RID: 52 RVA: 0x00002B15 File Offset: 0x00000D15
		public bool AddedLights { get; private set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000035 RID: 53 RVA: 0x0000EC68 File Offset: 0x0000CE68
		public RCOL LITEResource
		{
			get
			{
				return this.rcol_0;
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000EC80 File Offset: 0x0000CE80
		public LiteEditor(ResKey liteResource)
		{
			this.InitializeComponent();
			this.liteResource = liteResource;
			this.comboBox3.Items.Add(new LiteEditor.Class13(3U, "Point"));
			this.comboBox3.Items.Add(new LiteEditor.Class13(4U, "Spot"));
			this.comboBox3.Items.Add(new LiteEditor.Class13(7U, "Window"));
			this.comboBox3.Items.Add(new LiteEditor.Class13(9U, "Area"));
			this.comboBox3.Items.Add(new LiteEditor.Class13(5U, "Type5"));
			this.comboBox3.Items.Add(new LiteEditor.Class13(17U, "Type11"));
			this.comboBox3.Items.Add(new LiteEditor.Class13(11U, "TypeB"));
			RCOL rcol = Class76.smethod_26(this.liteResource) as RCOL;
			this.rcol_0 = (rcol.Clone() as RCOL);
			LITE lite = this.rcol_0.Entries[0] as LITE;
			int num = 1;
			foreach (object obj in lite.Entries128)
			{
				LiteEditor.Class15 @class = new LiteEditor.Class15();
				@class.object_0 = obj;
				@class.string_0 = "Entry " + num++;
				this.comboBox1.Items.Add(@class);
			}
			num = 1;
			foreach (object obj2 in lite.Entries56)
			{
				LiteEditor.Class16 class2 = new LiteEditor.Class16();
				class2.object_0 = obj2;
				class2.string_0 = "Entry " + num++;
				this.comboBox2.Items.Add(class2);
			}
			if (this.comboBox1.Items.Count > 0)
			{
				this.comboBox1.SelectedIndex = 0;
			}
			if (this.comboBox2.Items.Count > 0)
			{
				this.comboBox2.SelectedIndex = 0;
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002A71 File Offset: 0x00000C71
		private void method_0(object sender, EventArgs e)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000EEE0 File Offset: 0x0000D0E0
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool enabled = this.comboBox1.SelectedIndex > -1;
			if (!this.bool_0 || this.method_1())
			{
				LITE.LightEntry lightEntry = (this.comboBox1.SelectedItem as LiteEditor.Class15).object_0 as LITE.LightEntry;
				float[] floats = lightEntry.Floats;
				this.posx.Text = floats[0].ToString("0.0000000");
				this.posy.Text = floats[1].ToString("0.0000000");
				this.posz.Text = floats[2].ToString("0.0000000");
				string text = floats[3].ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",";
				text = text + floats[4].ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",";
				text = text + floats[5].ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",1.0000000";
				this.color.BackColor = Class76.smethod_32(text);
				this.comboBox3.SelectedIndex = -1;
				LITE.LightType type = lightEntry.Type;
				switch (type)
				{
				case LITE.LightType.Point:
					this.comboBox3.SelectedIndex = 0;
					goto IL_20E;
				case LITE.LightType.Spot:
					this.comboBox3.SelectedIndex = 1;
					goto IL_20E;
				case LITE.LightType.Type5:
					this.comboBox3.SelectedIndex = 4;
					goto IL_20E;
				case (LITE.LightType)6U:
				case (LITE.LightType)8U:
				case (LITE.LightType)10U:
					break;
				case LITE.LightType.Window:
					this.comboBox3.SelectedIndex = 2;
					goto IL_20E;
				case LITE.LightType.Area:
					this.comboBox3.SelectedIndex = 3;
					goto IL_20E;
				case LITE.LightType.TypeB:
					this.comboBox3.SelectedIndex = 6;
					goto IL_20E;
				default:
					if (type == LITE.LightType.Type11)
					{
						this.comboBox3.SelectedIndex = 5;
						goto IL_20E;
					}
					break;
				}
				this.comboBox3.Items.Add(new LiteEditor.Class13((uint)lightEntry.Type, "Unknown"));
				this.comboBox3.SelectedIndex = this.comboBox3.Items.Count - 1;
				IL_20E:
				this.intensity.Text = floats[6].ToString("0.00000000");
				this.rotationx.Text = floats[7].ToString("0.00000000");
				this.rotationy.Text = floats[8].ToString("0.00000000");
				this.rotationz.Text = floats[9].ToString("0.00000000");
				this.angle.Text = floats[10].ToString("0.00000000");
				this.width.Text = floats[13].ToString("0.00000000");
				this.height.Text = floats[14].ToString("0.00000000");
				LiteEditor.Class14[] array = new LiteEditor.Class14[16];
				for (int i = 0; i < 15; i++)
				{
					array[i] = new LiteEditor.Class14();
					array[i].Value = floats[i + 16].ToString("0.00000000");
				}
				this.otherFloatsGrid.DataSource = array;
				this.posx.Enabled = (this.posy.Enabled = (this.posz.Enabled = (this.color.Enabled = (this.intensity.Enabled = (this.angle.Enabled = enabled)))));
				this.rotationx.Enabled = (this.rotationz.Enabled = (this.rotationy.Enabled = enabled));
				this.width.Enabled = (this.height.Enabled = (this.otherFloatsGrid.Enabled = enabled));
				this.comboBox3.Enabled = enabled;
				this.bool_0 = enabled;
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000F2DC File Offset: 0x0000D4DC
		private void comboBox3_Click(object sender, EventArgs e)
		{
			if (this.comboBox3.SelectedIndex != -1)
			{
				this.object_0 = this.comboBox1.SelectedItem;
				LITE.LightEntry lightEntry = (this.object_0 as LiteEditor.Class15).object_0 as LITE.LightEntry;
				lightEntry.Type = (LITE.LightType)(this.comboBox3.SelectedItem as LiteEditor.Class13).type;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000F340 File Offset: 0x0000D540
		private bool method_1()
		{
			LITE.LightEntry lightEntry = (this.object_0 as LiteEditor.Class15).object_0 as LITE.LightEntry;
			lightEntry.Floats[0] = Convert.ToSingle(this.posx.Text);
			lightEntry.Floats[1] = Convert.ToSingle(this.posy.Text);
			lightEntry.Floats[2] = Convert.ToSingle(this.posz.Text);
			string text = Class76.smethod_33(this.color.BackColor);
			string[] array = text.Split(new char[]
			{
				','
			});
			float value = Convert.ToSingle(array[0], CultureInfo.InvariantCulture.NumberFormat);
			float value2 = Convert.ToSingle(array[1], CultureInfo.InvariantCulture.NumberFormat);
			float value3 = Convert.ToSingle(array[2], CultureInfo.InvariantCulture.NumberFormat);
			string str = "";
			bool result;
			try
			{
				str = "Red";
				lightEntry.Floats[3] = Convert.ToSingle(value);
				str = "Green";
				lightEntry.Floats[4] = Convert.ToSingle(value2);
				str = "Blue";
				lightEntry.Floats[5] = Convert.ToSingle(value3);
				str = "Intensity";
				lightEntry.Floats[6] = Convert.ToSingle(this.intensity.Text);
				str = "Direction X";
				lightEntry.Floats[7] = Convert.ToSingle(this.rotationx.Text);
				str = "Direction Y";
				lightEntry.Floats[8] = Convert.ToSingle(this.rotationy.Text);
				str = "Direction Z";
				lightEntry.Floats[9] = Convert.ToSingle(this.rotationz.Text);
				str = "Angle";
				lightEntry.Floats[10] = Convert.ToSingle(this.angle.Text);
				str = "Width";
				lightEntry.Floats[13] = Convert.ToSingle(this.width.Text);
				str = "Height";
				lightEntry.Floats[14] = Convert.ToSingle(this.height.Text);
				goto IL_20E;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + ":" + str);
				result = false;
			}
			return result;
			IL_20E:
			return true;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000F580 File Offset: 0x0000D780
		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool enabled = this.comboBox2.SelectedIndex > -1;
			this.textBox1.Enabled = (this.textBox2.Enabled = (this.textBox3.Enabled = enabled));
			this.textBox4.Enabled = (this.textBox5.Enabled = (this.textBox6.Enabled = enabled));
			this.textBox7.Enabled = (this.textBox8.Enabled = (this.textBox9.Enabled = enabled));
			this.textBox10.Enabled = (this.textBox11.Enabled = (this.textBox12.Enabled = enabled));
			this.textBox13.Enabled = enabled;
			if (!this.bool_1 || this.method_2())
			{
				this.object_1 = this.comboBox2.SelectedItem;
				LITE.LightEntry lightEntry = (this.object_1 as LiteEditor.Class16).object_0 as LITE.LightEntry;
				float[] floats = lightEntry.Floats;
				this.textBox1.Text = floats[0].ToString("0.00000000");
				this.textBox2.Text = floats[1].ToString("0.00000000");
				this.textBox3.Text = floats[2].ToString("0.00000000");
				this.textBox4.Text = floats[3].ToString("0.00000000");
				this.textBox5.Text = floats[4].ToString("0.00000000");
				this.textBox6.Text = floats[5].ToString("0.00000000");
				this.textBox7.Text = floats[6].ToString("0.00000000");
				this.textBox8.Text = floats[7].ToString("0.00000000");
				this.textBox9.Text = floats[8].ToString("0.00000000");
				this.textBox10.Text = floats[9].ToString("0.00000000");
				this.textBox11.Text = floats[10].ToString("0.00000000");
				this.textBox12.Text = floats[11].ToString("0.00000000");
				this.textBox13.Text = floats[12].ToString("0.00000000");
				this.bool_1 = true;
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000F814 File Offset: 0x0000DA14
		private bool method_2()
		{
			LITE.LightEntry lightEntry = (this.object_1 as LiteEditor.Class16).object_0 as LITE.LightEntry;
			bool result;
			try
			{
				lightEntry.Floats[0] = Convert.ToSingle(this.textBox1.Text);
				lightEntry.Floats[1] = Convert.ToSingle(this.textBox2.Text);
				lightEntry.Floats[2] = Convert.ToSingle(this.textBox3.Text);
				lightEntry.Floats[3] = Convert.ToSingle(this.textBox4.Text);
				lightEntry.Floats[4] = Convert.ToSingle(this.textBox5.Text);
				lightEntry.Floats[5] = Convert.ToSingle(this.textBox6.Text);
				lightEntry.Floats[6] = Convert.ToSingle(this.textBox7.Text);
				lightEntry.Floats[7] = Convert.ToSingle(this.textBox8.Text);
				lightEntry.Floats[8] = Convert.ToSingle(this.textBox9.Text);
				lightEntry.Floats[9] = Convert.ToSingle(this.textBox10.Text);
				lightEntry.Floats[10] = Convert.ToSingle(this.textBox11.Text);
				lightEntry.Floats[11] = Convert.ToSingle(this.textBox12.Text);
				lightEntry.Floats[12] = Convert.ToSingle(this.textBox13.Text);
				goto IL_169;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				result = false;
			}
			return result;
			IL_169:
			return true;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002B20 File Offset: 0x00000D20
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002B2A File Offset: 0x00000D2A
		private void button2_Click(object sender, EventArgs e)
		{
			if (!this.bool_0 || this.method_1())
			{
				if (!this.bool_1 || this.method_2())
				{
					base.DialogResult = DialogResult.OK;
					base.Close();
				}
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000F9AC File Offset: 0x0000DBAC
		private void color_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.AnyColor = true;
			int[] customColors = new int[]
			{
				((int)this.color.BackColor.B << 16) + ((int)this.color.BackColor.G << 8) + (int)this.color.BackColor.R
			};
			colorDialog.CustomColors = customColors;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				this.color.BackColor = colorDialog.Color;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000FA38 File Offset: 0x0000DC38
		private void button4_Click(object sender, EventArgs e)
		{
			LiteEditor.Class15 @class = this.comboBox1.SelectedItem as LiteEditor.Class15;
			LITE lite = this.rcol_0.Entries[0] as LITE;
			if (@class != null)
			{
				LITE.LightType type = (@class.object_0 as LITE.LightEntry).Type;
				float[] floats = (@class.object_0 as LITE.LightEntry).Floats;
				float[] array = new float[floats.Length];
				int num = 0;
				foreach (float num2 in floats)
				{
					array[num++] = num2;
				}
				LITE.LightEntry item = new LITE.LightEntry(type, array);
				lite.Entries128.Add(item);
				LiteEditor.Class15 class2 = new LiteEditor.Class15();
				class2.object_0 = item;
				class2.string_0 = "Entry " + (this.comboBox1.Items.Count + 1);
				int selectedIndex = this.comboBox1.Items.Add(class2);
				this.comboBox1.SelectedIndex = selectedIndex;
				this.AddedLights = true;
			}
			else
			{
				LITE lite2 = LITE.CreatePointLight();
				LITE.LightEntry item2 = lite2.Entries128[0];
				lite.Entries128.Add(item2);
				LiteEditor.Class15 class3 = new LiteEditor.Class15();
				class3.object_0 = item2;
				class3.string_0 = "Entry " + (this.comboBox1.Items.Count + 1);
				int selectedIndex2 = this.comboBox1.Items.Add(class3);
				this.comboBox1.SelectedIndex = selectedIndex2;
				this.AddedLights = true;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000FBD0 File Offset: 0x0000DDD0
		private void button3_Click(object sender, EventArgs e)
		{
			LiteEditor.Class15 @class = this.comboBox1.SelectedItem as LiteEditor.Class15;
			LITE lite = this.rcol_0.Entries[0] as LITE;
			if (MessageBox.Show(this, "Are you sure you want to delete this light?", "Delete light", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
			{
				lite.Entries128.Remove(@class.object_0 as LITE.LightEntry);
				this.comboBox1.Items.Remove(@class);
				if (this.comboBox1.Items.Count > 0)
				{
					this.comboBox1.SelectedIndex = 0;
				}
				else
				{
					Control control = this.rotationx;
					Control control2 = this.rotationy;
					this.rotationz.Enabled = false;
					control2.Enabled = false;
					control.Enabled = false;
					this.intensity.Enabled = false;
					Control control3 = this.posx;
					Control control4 = this.posy;
					this.posz.Enabled = false;
					control4.Enabled = false;
					control3.Enabled = false;
					Control control5 = this.angle;
					Control control6 = this.width;
					this.height.Enabled = false;
					control6.Enabled = false;
					control5.Enabled = false;
				}
				this.AddedLights = true;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000FD00 File Offset: 0x0000DF00
		private void button5_Click(object sender, EventArgs e)
		{
			LITE lite = this.rcol_0.Entries[0] as LITE;
			LITE.LightEntry lightEntry = (this.object_1 as LiteEditor.Class16).object_0 as LITE.LightEntry;
			LITE.LightEntry lightEntry2 = new LITE.LightEntry(lightEntry.Type, lightEntry.Floats);
			lite.Entries56.Add(lightEntry);
			LiteEditor.Class16 @class = new LiteEditor.Class16();
			@class.object_0 = lightEntry2;
			@class.string_0 = "Entry " + (this.comboBox2.Items.Count + 1);
			this.comboBox2.Items.Add(@class);
			this.AddedLights = true;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000FDA8 File Offset: 0x0000DFA8
		private void button6_Click(object sender, EventArgs e)
		{
			LITE lite = this.rcol_0.Entries[0] as LITE;
			LITE.LightEntry item = (this.object_1 as LiteEditor.Class16).object_0 as LITE.LightEntry;
			lite.Entries56.Remove(item);
			this.comboBox2.Items.Remove(this.object_1);
			this.AddedLights = true;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002B5F File Offset: 0x00000D5F
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000053 RID: 83
		private ResKey liteResource;

		// Token: 0x04000054 RID: 84
		private RCOL rcol_0;

		// Token: 0x04000055 RID: 85
		private bool bool_0;

		// Token: 0x04000056 RID: 86
		private object object_0;

		// Token: 0x04000057 RID: 87
		private bool bool_1;

		// Token: 0x04000058 RID: 88
		private object object_1;

		// Token: 0x04000059 RID: 89
		private IContainer icontainer_0;

		// Token: 0x04000097 RID: 151
		[CompilerGenerated]
		private bool bool_2;

		// Token: 0x0200000B RID: 11
		internal sealed class Class13
		{
			// Token: 0x06000046 RID: 70 RVA: 0x00002B80 File Offset: 0x00000D80
			public Class13(uint type, string text)
			{
				this.text = text;
				this.type = type;
			}

			// Token: 0x06000047 RID: 71 RVA: 0x00011F88 File Offset: 0x00010188
			public string ToString()
			{
				return this.text;
			}

			// Token: 0x04000098 RID: 152
			public uint type;

			// Token: 0x04000099 RID: 153
			public string text;
		}

		// Token: 0x0200000C RID: 12
		internal sealed class Class14
		{
			// Token: 0x17000008 RID: 8
			// (get) Token: 0x06000048 RID: 72 RVA: 0x00011FA0 File Offset: 0x000101A0
			// (set) Token: 0x06000049 RID: 73 RVA: 0x00002B98 File Offset: 0x00000D98
			public string Value { get; set; }

			// Token: 0x0400009A RID: 154
			[CompilerGenerated]
			private string string_0;
		}

		// Token: 0x0200000D RID: 13
		private sealed class Class15
		{
			// Token: 0x0600004B RID: 75 RVA: 0x00011FB8 File Offset: 0x000101B8
			public string ToString()
			{
				return this.string_0;
			}

			// Token: 0x0400009B RID: 155
			public object object_0;

			// Token: 0x0400009C RID: 156
			public string string_0;
		}

		// Token: 0x0200000E RID: 14
		private sealed class Class16
		{
			// Token: 0x0600004D RID: 77 RVA: 0x00011FD0 File Offset: 0x000101D0
			public string ToString()
			{
				return this.string_0;
			}

			// Token: 0x0400009D RID: 157
			public object object_0;

			// Token: 0x0400009E RID: 158
			public string string_0;
		}
	}
}
