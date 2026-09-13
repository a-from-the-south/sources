using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using ns0;
using ns15;
using VisualHint.SmartPropertyGrid;

namespace ns10
{
	// Token: 0x02000078 RID: 120
	[ToolboxItem(false)]
	internal sealed class Control2 : Control, IDropDownContent, Interface5
	{
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x0004A988 File Offset: 0x00048B88
		protected Control3 ValueBar
		{
			get
			{
				return this.control3_0;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x0004A9A0 File Offset: 0x00048BA0
		protected Control4 HueSaturationMapPicker
		{
			get
			{
				return this.control4_0;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x0004A9B8 File Offset: 0x00048BB8
		protected TextBox HEdit
		{
			get
			{
				return this.textBox_0;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0004A9D0 File Offset: 0x00048BD0
		protected TextBox SEdit
		{
			get
			{
				return this.textBox_1;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x0004A9E8 File Offset: 0x00048BE8
		protected TextBox VEdit
		{
			get
			{
				return this.textBox_2;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x0004AA00 File Offset: 0x00048C00
		protected Label HLabel
		{
			get
			{
				return this.label_0;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x0004AA18 File Offset: 0x00048C18
		protected Label SLabel
		{
			get
			{
				return this.label_1;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0004AA30 File Offset: 0x00048C30
		protected Label VLabel
		{
			get
			{
				return this.label_2;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0004AA48 File Offset: 0x00048C48
		// (set) Token: 0x06000486 RID: 1158 RVA: 0x000046F9 File Offset: 0x000028F9
		protected Class77 HsvShift
		{
			get
			{
				return this.class77_0;
			}
			set
			{
				this.class77_0 = value;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x0004AA60 File Offset: 0x00048C60
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x00002A71 File Offset: 0x00000C71
		public Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0004AA78 File Offset: 0x00048C78
		public int GetSelectedIndex()
		{
			return this.propertyEnumerator_0.Property.Value.ImageIndex;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0004AAA0 File Offset: 0x00048CA0
		public Control2()
		{
			base.TabStop = false;
			this.control3_0 = new Control3(this);
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x0004AB18 File Offset: 0x00048D18
		// (set) Token: 0x0600048B RID: 1163 RVA: 0x00004704 File Offset: 0x00002904
		protected PropertyEnumerator OwnerPropertyEnumerator
		{
			get
			{
				return this.propertyEnumerator_0;
			}
			set
			{
				this.propertyEnumerator_0 = value;
			}
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0004AB30 File Offset: 0x00048D30
		public void InitializeContent(PropertyEnumerator propEnum, string currentValue, object valueKey)
		{
			this.propertyEnumerator_0 = propEnum;
			if (propEnum.Property.Value.HasMultipleValues)
			{
				this.class77_0 = null;
			}
			else
			{
				this.class77_0 = (Class77)propEnum.Property.Value.GetValue();
			}
			base.Width = 200;
			base.Height = 212;
			this.BackColor = SystemColors.Control;
			this.control3_0.Bounds = new Rectangle(40, 8, 150, 20);
			this.control3_0.Margins = new Win32Calls.RECT(1, 1, 1, 1);
			this.control3_0.Label = "";
			this.control3_0.Value = (int)Math.Round(this.class77_0.H / 360.0 * 255.0);
			this.control3_0.ValueChanged += this.vmethod_0;
			this.control3_0.TabIndex = 2;
			this.control3_0.MouseUp += this.control3_0_MouseUp;
			this.control3_0.KeyUp += this.control3_0_KeyUp;
			this.control4_0.Color = this.class77_0.method_1();
			this.control4_0.Bounds = new Rectangle(40, 30, 150, 150);
			this.control4_0.ValueChanged += this.method_1;
			this.control4_0.TabIndex = 3;
			this.control4_0.MouseUp += this.control4_0_MouseUp;
			this.control4_0.KeyUp += this.control4_0_KeyUp;
			this.label_0.TextAlign = ContentAlignment.MiddleLeft;
			this.label_0.Bounds = new Rectangle(39, 185, 15, 19);
			this.label_0.Text = "H";
			this.textBox_0.AutoSize = false;
			this.textBox_0.Bounds = new Rectangle(53, 185, 26, 19);
			this.textBox_0.Text = Math.Round(this.class77_0.H).ToString("0");
			this.textBox_0.MaxLength = 10;
			this.textBox_0.KeyPress += this.textBox_2_KeyPress;
			this.textBox_0.TextChanged += this.textBox_2_TextChanged;
			this.textBox_0.TabIndex = 4;
			this.label_1.TextAlign = ContentAlignment.MiddleLeft;
			this.label_1.Bounds = new Rectangle(82, 185, 15, 19);
			this.label_1.Text = "S";
			this.textBox_1.AutoSize = false;
			this.textBox_1.Bounds = new Rectangle(95, 185, 33, 19);
			this.textBox_1.Text = this.class77_0.S.ToString("0.000");
			this.textBox_1.MaxLength = 5;
			this.textBox_1.KeyPress += this.textBox_2_KeyPress;
			this.textBox_1.TextChanged += this.textBox_2_TextChanged;
			this.textBox_1.TabIndex = 5;
			this.label_2.TextAlign = ContentAlignment.MiddleLeft;
			this.label_2.Bounds = new Rectangle(131, 185, 15, 19);
			this.label_2.Text = "V";
			this.textBox_2.AutoSize = false;
			this.textBox_2.Bounds = new Rectangle(145, 185, 33, 19);
			this.textBox_2.Text = this.class77_0.V.ToString("0.000");
			this.textBox_2.MaxLength = 5;
			this.textBox_2.KeyPress += this.textBox_2_KeyPress;
			this.textBox_2.TextChanged += this.textBox_2_TextChanged;
			this.textBox_2.TabIndex = 6;
			base.Controls.Add(this.control3_0);
			base.Controls.Add(this.control4_0);
			base.Controls.Add(this.textBox_0);
			base.Controls.Add(this.textBox_1);
			base.Controls.Add(this.textBox_2);
			base.Controls.Add(this.label_0);
			base.Controls.Add(this.label_1);
			base.Controls.Add(this.label_2);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0004AFD8 File Offset: 0x000491D8
		public object GetValue()
		{
			return this.class77_0;
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool HasToBeClosedOnClick()
		{
			return false;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0004AFF0 File Offset: 0x000491F0
		public void imethod_0(Control control_0, Graphics graphics_0, Rectangle rectangle_0)
		{
			if (control_0 == this.control3_0)
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle_0, Color.Black, Color.Black, 0f, false))
				{
					linearGradientBrush.InterpolationColors = new ColorBlend
					{
						Colors = new Color[]
						{
							Color.FromArgb(255, 0, 0),
							Color.FromArgb(255, 255, 0),
							Color.FromArgb(0, 255, 0),
							Color.FromArgb(0, 255, 255),
							Color.FromArgb(0, 0, 255),
							Color.FromArgb(255, 0, 255),
							Color.FromArgb(255, 0, 0)
						},
						Positions = new float[]
						{
							0f,
							0.1667f,
							0.3372f,
							0.502f,
							0.6686f,
							0.8313f,
							1f
						}
					};
					graphics_0.FillRectangle(linearGradientBrush, rectangle_0);
				}
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0004B12C File Offset: 0x0004932C
		protected void method_0()
		{
			PropInPlaceList propInPlaceList = this.propertyEnumerator_0.Property.ParentGrid.InPlaceControl as PropInPlaceList;
			if (propInPlaceList.RealtimeChange)
			{
				propInPlaceList.CommitChangesFromLiveDropDown();
			}
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000470F File Offset: 0x0000290F
		protected void control3_0_KeyUp(object sender, KeyEventArgs e)
		{
			this.method_0();
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0000470F File Offset: 0x0000290F
		protected void control3_0_MouseUp(object sender, MouseEventArgs e)
		{
			this.method_0();
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0004B164 File Offset: 0x00049364
		protected void vmethod_0(object sender, EventArgs e)
		{
			if (!this.bool_0 && sender == this.control3_0)
			{
				double hue = (double)this.control3_0.Value / 255.0 * 359.0;
				this.control4_0.Hue = hue;
				this.method_1(sender, EventArgs.Empty);
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0000470F File Offset: 0x0000290F
		protected void control4_0_KeyUp(object sender, KeyEventArgs e)
		{
			this.method_0();
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0000470F File Offset: 0x0000290F
		protected void control4_0_MouseUp(object sender, MouseEventArgs e)
		{
			this.method_0();
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0004B1C0 File Offset: 0x000493C0
		protected void method_1(object sender, EventArgs e)
		{
			this.class77_0 = Class77.smethod_0(this.control4_0.Color);
			this.bool_0 = true;
			this.textBox_0.Text = this.class77_0.H.ToString("0");
			this.textBox_1.Text = this.class77_0.S.ToString("0.000");
			this.textBox_2.Text = this.class77_0.V.ToString("0.000");
			this.bool_0 = false;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00004719 File Offset: 0x00002919
		protected void textBox_2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '\b' && e.KeyChar != CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0] && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0004B25C File Offset: 0x0004945C
		protected void textBox_2_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				TextBox textBox = sender as TextBox;
				double num = (textBox.Text.Length > 0) ? double.Parse(textBox.Text) : 0.0;
				if (sender == this.textBox_0)
				{
					if (num > 360.0)
					{
						num = 360.0;
					}
					this.class77_0.H = num / 360.0;
				}
				else
				{
					if (num > 1.0)
					{
						num = 1.0;
					}
					if (sender == this.textBox_1)
					{
						this.class77_0.S = num;
					}
					else if (sender == this.textBox_2)
					{
						this.class77_0.V = num;
					}
				}
				this.control4_0.ResetColor();
				this.control4_0.Color = this.class77_0.method_1();
				this.bool_0 = true;
				this.control3_0.Value = (int)Math.Round(this.class77_0.H / 360.0 * 255.0);
				this.bool_0 = false;
				this.method_0();
				VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e2 = new VisualHint.SmartPropertyGrid.PropertyChangedEventArgs(this.propertyEnumerator_0);
				this.propertyEnumerator_0.Property.ParentGrid.NotifyPropertyChanged(e2);
			}
		}

		// Token: 0x04000420 RID: 1056
		private Control3 control3_0;

		// Token: 0x04000421 RID: 1057
		private Control4 control4_0 = new Control4();

		// Token: 0x04000422 RID: 1058
		private TextBox textBox_0 = new TextBox();

		// Token: 0x04000423 RID: 1059
		private TextBox textBox_1 = new TextBox();

		// Token: 0x04000424 RID: 1060
		private TextBox textBox_2 = new TextBox();

		// Token: 0x04000425 RID: 1061
		private Label label_0 = new Label();

		// Token: 0x04000426 RID: 1062
		private Label label_1 = new Label();

		// Token: 0x04000427 RID: 1063
		private Label label_2 = new Label();

		// Token: 0x04000428 RID: 1064
		private bool bool_0;

		// Token: 0x04000429 RID: 1065
		private Class77 class77_0;

		// Token: 0x0400042A RID: 1066
		private PropertyEnumerator propertyEnumerator_0;
	}
}
