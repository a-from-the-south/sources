using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ns13;
using ns14;
using ns16;
using ns18;

namespace ns10
{
	// Token: 0x0200016F RID: 367
	internal sealed class Class169 : UITypeEditor
	{
		// Token: 0x0600116B RID: 4459 RVA: 0x000BA2A8 File Offset: 0x000B84A8
		public UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x000BBFB8 File Offset: 0x000BA1B8
		public object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			this.iwindowsFormsEditorService_0 = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			object result;
			if (this.iwindowsFormsEditorService_0 != null)
			{
				Type type = value.GetType();
				string[] names = Enum.GetNames(type);
				object obj;
				using (Class169.Control10 control = new Class169.Control10())
				{
					using (Class169.Class171 @class = new Class169.Class171())
					{
						@class.x0cc62080d561909c = value.ToString();
						control.Controls.Add(@class);
						int num = 0;
						int num2 = 0;
						using (Graphics graphics = control.CreateGraphics())
						{
							foreach (string text in names)
							{
								Class169.Class172 class2 = this.method_1(context, type, text);
								@class.Items.Add(class2);
								if (text == value.ToString())
								{
									@class.SelectedIndex = @class.Items.Count - 1;
								}
								Size size = class2.method_0(graphics, control.Font);
								num = Math.Max(num, size.Width + 6 + SystemInformation.VerticalScrollBarWidth);
								num2 += size.Height;
							}
						}
						Rectangle bounds = Screen.PrimaryScreen.Bounds;
						if (num < bounds.Width / 4)
						{
							control.Width = num;
						}
						else
						{
							control.Width = bounds.Width / 4;
							control.x844c53236188036c = true;
							num2 += 16;
						}
						control.Height = Math.Min(bounds.Height / 4, num2);
						control.x844c53236188036c |= (num2 > Screen.PrimaryScreen.Bounds.Height / 4);
						@class.MouseUp += this.method_0;
						this.iwindowsFormsEditorService_0.DropDownControl(control);
						obj = ((@class.SelectedItem == null) ? value : Enum.Parse(type, (@class.SelectedItem as Class169.Class172).x759aa16c2016a289, false));
					}
				}
				result = obj;
			}
			else
			{
				result = base.EditValue(context, provider, value);
			}
			return result;
		}

		// Token: 0x0600116D RID: 4461 RVA: 0x0000940A File Offset: 0x0000760A
		private void method_0(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.iwindowsFormsEditorService_0.CloseDropDown();
			}
		}

		// Token: 0x0600116E RID: 4462 RVA: 0x000BC200 File Offset: 0x000BA400
		private Class169.Class172 method_1(ITypeDescriptorContext itypeDescriptorContext_0, Type type_0, string string_0)
		{
			Type type = null;
			if (itypeDescriptorContext_0 != null)
			{
				foreach (object obj in itypeDescriptorContext_0.PropertyDescriptor.Attributes)
				{
					Attribute attribute = (Attribute)obj;
					if (attribute is Attribute3)
					{
						type = (attribute as Attribute3).ProviderType;
						break;
					}
				}
			}
			Attribute[] array = null;
			if (type != null)
			{
				Interface13 @interface = Activator.CreateInstance(type) as Interface13;
				if (@interface != null)
				{
					array = @interface.imethod_0(Enum.Parse(type_0, string_0, false));
				}
			}
			if (array == null)
			{
				FieldInfo field = type_0.GetField(string_0, BindingFlags.Static | BindingFlags.Public);
				if (Attribute.IsDefined(field, typeof(DescriptionAttribute)))
				{
					array = Attribute.GetCustomAttributes(field, typeof(DescriptionAttribute));
				}
				if (Attribute.IsDefined(field, typeof(Attribute4)))
				{
					Attribute[] customAttributes = Attribute.GetCustomAttributes(field, typeof(Attribute4));
					if (array != null)
					{
						Attribute[] array2 = new Attribute[checked((uint)(unchecked(array.Length + customAttributes.Length)))];
						array.CopyTo(array2, 0);
						customAttributes.CopyTo(array2, array.Length);
						array = array2;
					}
				}
			}
			string description = string.Empty;
			Image image = null;
			foreach (Attribute attribute2 in array)
			{
				if (attribute2 is DescriptionAttribute)
				{
					description = (attribute2 as DescriptionAttribute).Description;
				}
				else if (attribute2 is Attribute4)
				{
					image = (attribute2 as Attribute4).method_0();
				}
			}
			return new Class169.Class172(string_0, description, image);
		}

		// Token: 0x04000BE2 RID: 3042
		private IWindowsFormsEditorService iwindowsFormsEditorService_0;

		// Token: 0x02000170 RID: 368
		private sealed class Control10 : ContainerControl
		{
			// Token: 0x06001170 RID: 4464 RVA: 0x00009426 File Offset: 0x00007626
			public Control10()
			{
				this.BackColor = SystemColors.Control;
				base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			}

			// Token: 0x06001171 RID: 4465 RVA: 0x000BC38C File Offset: 0x000BA58C
			protected void OnPaint(PaintEventArgs e)
			{
				if (this.x844c53236188036c)
				{
					Rectangle rect = new Rectangle(0, base.Height - base.DockPadding.Bottom, base.Width, base.DockPadding.Bottom);
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(Rectangle.Inflate(rect, 1, 1), SystemColors.ControlLightLight, SystemColors.Control, LinearGradientMode.Vertical))
					{
						e.Graphics.FillRectangle(linearGradientBrush, rect);
					}
					if (this.x0ad8a5c1615d65f3 == LeftRightAlignment.Left)
					{
						for (int i = 0; i < 3; i++)
						{
							for (int j = 0; j <= i; j++)
							{
								e.Graphics.FillRectangle(SystemBrushes.ControlLightLight, 4 + j * 4, base.Height - 11 + i * 4, 2, 2);
								e.Graphics.FillRectangle(SystemBrushes.ControlDark, 3 + j * 4, base.Height - 12 + i * 4, 2, 2);
							}
						}
					}
					else
					{
						for (int k = 0; k < 3; k++)
						{
							for (int l = 0; l <= k; l++)
							{
								e.Graphics.FillRectangle(SystemBrushes.ControlLightLight, base.Width - 4 - l * 4, base.Height - 11 + k * 4, 2, 2);
								e.Graphics.FillRectangle(SystemBrushes.ControlDark, base.Width - 3 - l * 4, base.Height - 12 + k * 4, 2, 2);
							}
						}
					}
				}
			}

			// Token: 0x170003CD RID: 973
			// (get) Token: 0x06001172 RID: 4466 RVA: 0x000BC4FC File Offset: 0x000BA6FC
			// (set) Token: 0x06001173 RID: 4467 RVA: 0x00009447 File Offset: 0x00007647
			public bool x844c53236188036c
			{
				get
				{
					return this.bool_0;
				}
				set
				{
					this.bool_0 = value;
					base.DockPadding.Bottom = (value ? 16 : 0);
				}
			}

			// Token: 0x170003CE RID: 974
			// (get) Token: 0x06001174 RID: 4468 RVA: 0x000BC514 File Offset: 0x000BA714
			public Rectangle x2574607afa6829b0
			{
				get
				{
					Rectangle result;
					if (this.x0ad8a5c1615d65f3 == LeftRightAlignment.Left)
					{
						result = new Rectangle(0, base.Height - 14, 14, 14);
					}
					else
					{
						result = new Rectangle(base.Width - 14, base.Height - 14, 14, 14);
					}
					return result;
				}
			}

			// Token: 0x170003CF RID: 975
			// (get) Token: 0x06001175 RID: 4469 RVA: 0x000BC560 File Offset: 0x000BA760
			public LeftRightAlignment x0ad8a5c1615d65f3
			{
				get
				{
					return this.leftRightAlignment_0;
				}
			}

			// Token: 0x06001176 RID: 4470 RVA: 0x000BC578 File Offset: 0x000BA778
			protected void WndProc(ref Message m)
			{
				if (m.Msg == 132 && this.x844c53236188036c)
				{
					Point pt = base.PointToClient(new Point(m.LParam.ToInt32()));
					if (this.x2574607afa6829b0.Contains(pt))
					{
						m.Result = new IntPtr(-1);
						return;
					}
				}
				base.WndProc(ref m);
			}

			// Token: 0x06001177 RID: 4471 RVA: 0x000BC5DC File Offset: 0x000BA7DC
			protected void OnVisibleChanged(EventArgs e)
			{
				base.OnVisibleChanged(e);
				if (base.Visible && base.FindForm() != null)
				{
					this.Dock = DockStyle.Fill;
					this.leftRightAlignment_0 = ((base.PointToScreen(new Point(0, 0)).X < Screen.GetBounds(this).Width / 2) ? LeftRightAlignment.Right : LeftRightAlignment.Left);
					Class169.Control10.Class170.smethod_0(this);
				}
			}

			// Token: 0x04000BE3 RID: 3043
			private const int int_0 = 132;

			// Token: 0x04000BE4 RID: 3044
			private const int int_1 = 16;

			// Token: 0x04000BE5 RID: 3045
			private const int int_2 = 17;

			// Token: 0x04000BE6 RID: 3046
			private const int int_3 = -1;

			// Token: 0x04000BE7 RID: 3047
			private bool bool_0;

			// Token: 0x04000BE8 RID: 3048
			private LeftRightAlignment leftRightAlignment_0;

			// Token: 0x02000171 RID: 369
			private sealed class Class170 : NativeWindow
			{
				// Token: 0x06001178 RID: 4472 RVA: 0x00009465 File Offset: 0x00007665
				private Class170(Form parentForm)
				{
					base.AssignHandle(parentForm.Handle);
					parentForm.Disposed += this.method_0;
				}

				// Token: 0x06001179 RID: 4473 RVA: 0x000BC640 File Offset: 0x000BA840
				public static void smethod_0(Class169.Control10 control10_1)
				{
					Form form = control10_1.FindForm();
					Class169.Control10.Class170 @class = Class169.Control10.Class170.hashtable_0[form] as Class169.Control10.Class170;
					if (@class == null)
					{
						@class = (Class169.Control10.Class170.hashtable_0[form] = new Class169.Control10.Class170(form));
					}
					@class.control10_0 = control10_1;
				}

				// Token: 0x0600117A RID: 4474 RVA: 0x000BC684 File Offset: 0x000BA884
				protected void WndProc(ref Message m)
				{
					if (this.control10_0 != null && !this.control10_0.IsDisposed && m.Msg == 132 && this.control10_0.x844c53236188036c)
					{
						Point pt = this.control10_0.PointToClient(new Point(m.LParam.ToInt32()));
						if (this.control10_0.x2574607afa6829b0.Contains(pt))
						{
							m.Result = ((this.control10_0.x0ad8a5c1615d65f3 == LeftRightAlignment.Left) ? new IntPtr(16) : new IntPtr(17));
							return;
						}
					}
					base.WndProc(ref m);
				}

				// Token: 0x0600117B RID: 4475 RVA: 0x0000948D File Offset: 0x0000768D
				private void method_0(object sender, EventArgs e)
				{
					if (Class169.Control10.Class170.hashtable_0.Contains(this))
					{
						Class169.Control10.Class170.hashtable_0.Remove(this);
					}
				}

				// Token: 0x04000BE9 RID: 3049
				private Class169.Control10 control10_0;

				// Token: 0x04000BEA RID: 3050
				private static Hashtable hashtable_0 = new Hashtable();
			}
		}

		// Token: 0x02000172 RID: 370
		private sealed class Class171 : ListBox
		{
			// Token: 0x0600117D RID: 4477 RVA: 0x000094B7 File Offset: 0x000076B7
			public Class171()
			{
				base.BorderStyle = BorderStyle.None;
				this.Dock = DockStyle.Fill;
				this.DrawMode = DrawMode.OwnerDrawVariable;
				base.SetStyle(ControlStyles.ResizeRedraw, true);
			}

			// Token: 0x170003D0 RID: 976
			// (get) Token: 0x0600117E RID: 4478 RVA: 0x000BC728 File Offset: 0x000BA928
			// (set) Token: 0x0600117F RID: 4479 RVA: 0x000094DF File Offset: 0x000076DF
			public string x0cc62080d561909c
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

			// Token: 0x06001180 RID: 4480 RVA: 0x000BC740 File Offset: 0x000BA940
			protected void OnMeasureItem(MeasureItemEventArgs e)
			{
				Class169.Class172 @class = (e.Index == -1) ? null : (base.Items[e.Index] as Class169.Class172);
				Size size = @class.method_0(e.Graphics, this.Font);
				e.ItemWidth = size.Width;
				e.ItemHeight = size.Height;
			}

			// Token: 0x06001181 RID: 4481 RVA: 0x000BC7A0 File Offset: 0x000BA9A0
			protected void OnDrawItem(DrawItemEventArgs e)
			{
				Class169.Class172 @class = (e.Index == -1) ? null : (base.Items[e.Index] as Class169.Class172);
				e.DrawBackground();
				Rectangle bounds = e.Bounds;
				bounds.X++;
				bounds.Width -= 2;
				if (@class.x3d235fc95c355365.Length > 0)
				{
					bounds.Height >>= 1;
				}
				if (@class.xa460a0b649265441 != null)
				{
					e.Graphics.DrawImage(@class.xa460a0b649265441, bounds.X + 3, bounds.Y + 2, @class.xa460a0b649265441.Width, @class.xa460a0b649265441.Height);
					bounds.X += @class.xa460a0b649265441.Width + 8;
					bounds.Width -= @class.xa460a0b649265441.Width + 8;
				}
				using (Font font = new Font(e.Font, (this.x0cc62080d561909c == @class.x759aa16c2016a289) ? FontStyle.Bold : FontStyle.Regular))
				{
					Class148.smethod_0(e.Graphics, @class.x759aa16c2016a289, font, e.ForeColor, Color.Transparent, bounds, (Enum25)36);
				}
				if (@class.x3d235fc95c355365.Length > 0)
				{
					bounds.Y += bounds.Height;
					Class148.smethod_0(e.Graphics, @class.x3d235fc95c355365, e.Font, ControlPaint.LightLight(e.ForeColor), Color.Transparent, bounds, (Enum25)32804);
				}
				e.Graphics.DrawLine(SystemPens.Control, e.Bounds.X, e.Bounds.Bottom - 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
			}

			// Token: 0x04000BEB RID: 3051
			private string string_0;
		}

		// Token: 0x02000173 RID: 371
		private sealed class Class172
		{
			// Token: 0x06001182 RID: 4482 RVA: 0x000094EA File Offset: 0x000076EA
			public Class172(string name, string description, Image image)
			{
				this.name = name;
				this.description = description;
				this.image = image;
			}

			// Token: 0x170003D1 RID: 977
			// (get) Token: 0x06001183 RID: 4483 RVA: 0x000BC990 File Offset: 0x000BAB90
			public string x759aa16c2016a289
			{
				get
				{
					return this.name;
				}
			}

			// Token: 0x170003D2 RID: 978
			// (get) Token: 0x06001184 RID: 4484 RVA: 0x000BC9A8 File Offset: 0x000BABA8
			public string x3d235fc95c355365
			{
				get
				{
					return this.description;
				}
			}

			// Token: 0x170003D3 RID: 979
			// (get) Token: 0x06001185 RID: 4485 RVA: 0x000BC9C0 File Offset: 0x000BABC0
			public Image xa460a0b649265441
			{
				get
				{
					return this.image;
				}
			}

			// Token: 0x06001186 RID: 4486 RVA: 0x000BC9D8 File Offset: 0x000BABD8
			public Size method_0(Graphics graphics_0, Font font_0)
			{
				Size size = (this.xa460a0b649265441 == null) ? Size.Empty : (this.xa460a0b649265441.Size + new Size(8, 4));
				Size size2 = Size.Round(graphics_0.MeasureString(this.x759aa16c2016a289, font_0));
				Size size3 = Size.Round(graphics_0.MeasureString(this.x3d235fc95c355365, font_0, int.MaxValue, StringFormat.GenericTypographic));
				return new Size(size.Width + Math.Max(size2.Width, size3.Width), Math.Max(size2.Height + size3.Height + 5, size.Height));
			}

			// Token: 0x04000BEC RID: 3052
			private string name;

			// Token: 0x04000BED RID: 3053
			private string description;

			// Token: 0x04000BEE RID: 3054
			private Image image;
		}
	}
}
