using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns1;
using ns10;
using ns13;
using ns16;
using ns17;
using ns18;
using ns19;
using ns3;
using ns8;
using ns9;

namespace ns6
{
	// Token: 0x02000158 RID: 344
	[Attribute2("Standard")]
	[TypeConverter(typeof(Class154.Class160))]
	internal class Class154 : ICustomTypeDescriptor, Interface12
	{
		// Token: 0x0600102A RID: 4138 RVA: 0x000087E8 File Offset: 0x000069E8
		public static void smethod_0(Class154 class154_2)
		{
			if (class154_2 != Class154.DefaultRenderer)
			{
				if (Class154.class154_0 != class154_2)
				{
					Class154.class154_0 = class154_2;
					Class154.smethod_2(EventArgs.Empty);
				}
			}
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x000B88A8 File Offset: 0x000B6AA8
		public static Class154 smethod_1()
		{
			return Class154.class154_0;
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x0600102C RID: 4140 RVA: 0x000B88C0 File Offset: 0x000B6AC0
		public static Class154 DefaultRenderer
		{
			get
			{
				return Class154.class154_1;
			}
		}

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x0600102D RID: 4141 RVA: 0x0000880E File Offset: 0x00006A0E
		// (remove) Token: 0x0600102E RID: 4142 RVA: 0x00008827 File Offset: 0x00006A27
		public static event EventHandler DefaultRendererChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				Class154.eventHandler_0 = (EventHandler)Delegate.Combine(Class154.eventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				Class154.eventHandler_0 = (EventHandler)Delegate.Remove(Class154.eventHandler_0, value);
			}
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x00008840 File Offset: 0x00006A40
		private static void smethod_2(EventArgs eventArgs_0)
		{
			if (Class154.eventHandler_0 != null)
			{
				Class154.eventHandler_0(null, eventArgs_0);
			}
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x00008857 File Offset: 0x00006A57
		internal void method_0(string string_0)
		{
			this.class152_0.method_1(string_0);
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x000B88D8 File Offset: 0x000B6AD8
		Class152 Interface12.imethod_0()
		{
			return this.class152_0;
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x00072108 File Offset: 0x00070308
		TypeConverter ICustomTypeDescriptor.GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x000721BC File Offset: 0x000703BC
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x000721A4 File Offset: 0x000703A4
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x000720F0 File Offset: 0x000702F0
		string ICustomTypeDescriptor.GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x000059F2 File Offset: 0x00003BF2
		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x000720C0 File Offset: 0x000702C0
		AttributeCollection ICustomTypeDescriptor.GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, true);
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x000B88F0 File Offset: 0x000B6AF0
		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
		{
			return ((ICustomTypeDescriptor)this).GetProperties(null);
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x00072188 File Offset: 0x00070388
		object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x000B8908 File Offset: 0x000B6B08
		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x00072120 File Offset: 0x00070320
		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x000720D8 File Offset: 0x000702D8
		string ICustomTypeDescriptor.GetClassName()
		{
			return TypeDescriptor.GetClassName(this, true);
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x000B8920 File Offset: 0x000B6B20
		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
		{
			return Class152.smethod_0(this, attributes);
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x00008867 File Offset: 0x00006A67
		private void method_1(PaintEventArgs paintEventArgs_0, Class161 class161_0, ref Class163 class163_0)
		{
			this.method_3(paintEventArgs_0);
			this.method_2(class161_0);
			if (class163_0 == null)
			{
				class163_0 = this.method_9(class161_0);
			}
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x00008886 File Offset: 0x00006A86
		private void method_2(Class161 class161_0)
		{
			if (class161_0 == null)
			{
				throw new ArgumentNullException("tip");
			}
			if (class161_0.Provider == null)
			{
				throw new ArgumentException("The tip must be associated with a VisualTipProvider before it is rendered.");
			}
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x000088AB File Offset: 0x00006AAB
		private void method_3(PaintEventArgs paintEventArgs_0)
		{
			if (paintEventArgs_0 == null)
			{
				throw new ArgumentNullException("e");
			}
			if (paintEventArgs_0.Graphics == null)
			{
				throw new ArgumentException("The Graphics specified by PaintEventArgs may not be a null reference.", "e");
			}
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x000B8938 File Offset: 0x000B6B38
		internal Color method_4(Color color_0)
		{
			if (!color_0.Equals(Color.Empty))
			{
				if (color_0.A != 255)
				{
					return Color.FromArgb(255, color_0);
				}
			}
			return color_0;
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x000B897C File Offset: 0x000B6B7C
		protected bool method_5(Class161 class161_0)
		{
			this.method_2(class161_0);
			bool result;
			if (!class161_0.HideFooter)
			{
				if (class161_0.FooterText.Length <= 0)
				{
					result = (class161_0.FooterImage != null);
				}
				else
				{
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x000B89C0 File Offset: 0x000B6BC0
		protected string method_6(Class161 class161_0)
		{
			this.method_2(class161_0);
			string text = "";
			if (class161_0.Shortcut != Shortcut.None)
			{
				text = "(" + TypeDescriptor.GetConverter(typeof(Keys)).ConvertToString((Keys)class161_0.Shortcut) + ")";
			}
			string result;
			if (class161_0.Title.Length <= 0)
			{
				result = text;
			}
			else
			{
				result = class161_0.Title + " " + text;
			}
			return result;
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x000B8A38 File Offset: 0x000B6C38
		protected string method_7(Class161 class161_0)
		{
			this.method_2(class161_0);
			string result;
			if (!class161_0.Enabled && class161_0.DisabledText.Length > 0)
			{
				result = class161_0.DisabledText;
			}
			else
			{
				result = class161_0.Text;
			}
			return result;
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x000B8A78 File Offset: 0x000B6C78
		protected virtual Font vmethod_0(Class161 class161_0, Enum23 enum23_0)
		{
			this.method_2(class161_0);
			if (enum23_0 != Enum23.const_1 && enum23_0 != Enum23.const_2)
			{
				if (enum23_0 != Enum23.const_4)
				{
					return class161_0.Font;
				}
			}
			return new Font(class161_0.Font, FontStyle.Bold);
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x000B8AB4 File Offset: 0x000B6CB4
		protected virtual Color vmethod_1(Class161 class161_0, Enum23 enum23_0)
		{
			this.method_2(class161_0);
			return SystemColors.InfoText;
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x000B8AD4 File Offset: 0x000B6CD4
		protected bool method_8(Class161 class161_0)
		{
			this.method_2(class161_0);
			if (Class154.x9843c083bd22e3f5)
			{
				if (class161_0.Provider.Shadow == Enum26.const_2)
				{
					return true;
				}
				if (class161_0.Provider.Shadow == Enum26.const_0)
				{
					return Class174.x003e94eb365fa7c9;
				}
			}
			return false;
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x000B8B1C File Offset: 0x000B6D1C
		public Class163 method_9(Class161 class161_0)
		{
			this.method_2(class161_0);
			Class163 @class = this.vmethod_2(class161_0);
			if (@class == null)
			{
				throw new InvalidOperationException("A null value may not be returned by OnCreateLayout.");
			}
			return @class;
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x000B8B4C File Offset: 0x000B6D4C
		protected virtual Class163 vmethod_2(Class161 class161_0)
		{
			Class163 @class = new Class163();
			string text = this.method_6(class161_0);
			string text2 = this.method_7(class161_0);
			bool flag = text.Length > 0;
			bool flag2 = text2.Length > 0 || class161_0.Image != null;
			Font font_ = this.vmethod_0(class161_0, Enum23.const_1);
			Font font_2 = this.vmethod_0(class161_0, Enum23.const_3);
			Font font_3 = this.vmethod_0(class161_0, Enum23.const_4);
			Font font_4 = this.vmethod_0(class161_0, Enum23.const_2);
			int num = flag ? this.method_10(text, font_, 0).Width : 0;
			int num2 = flag2 ? this.method_10(text2, font_2, 0).Width : 0;
			int num3 = this.method_5(class161_0) ? this.method_10(class161_0.FooterText, font_3, 0).Width : 0;
			if (!class161_0.Enabled && class161_0.DisabledMessage.Length > 0)
			{
				num2 = Math.Max(this.method_10(class161_0.DisabledMessage, font_4, 0).Width, num2);
			}
			if (class161_0.TitleImage != null)
			{
				num += class161_0.TitleImage.Width + 6;
			}
			if (class161_0.Image != null)
			{
				num2 += class161_0.Image.Width + 6;
			}
			if (this.method_5(class161_0) && class161_0.FooterImage != null)
			{
				num3 += class161_0.FooterImage.Width + 6;
			}
			int val = Math.Max(Math.Max(num, num2), num3);
			int num4 = Math.Min(class161_0.MaximumWidth - 6 - 6, val);
			int num5 = 6;
			Class154.Class158 class2 = new Class154.Class158(this, class161_0.TitleImage, this.vmethod_0(class161_0, Enum23.const_1), text, null, "", num4, 6);
			class2.method_0(6, 6);
			if (class2.rectangle_2.Height > 0)
			{
				num5 += class2.rectangle_2.Height + 6;
			}
			Class154.Class158 class3;
			if (class161_0.Enabled)
			{
				class3 = new Class154.Class158(this, class161_0.Image, null, "", this.vmethod_0(class161_0, Enum23.const_3), text2, num4, 6);
			}
			else
			{
				class3 = new Class154.Class158(this, class161_0.Image, this.vmethod_0(class161_0, Enum23.const_2), class161_0.DisabledMessage, this.vmethod_0(class161_0, Enum23.const_3), text2, num4, 6);
			}
			class3.method_0(6, num5);
			if (class161_0.RightToLeft == RightToLeft.Yes)
			{
				class3.method_1();
			}
			if (class3.rectangle_2.Height > 0)
			{
				num5 += class3.rectangle_2.Height + 6;
			}
			Class154.Class158 class4 = this.method_5(class161_0) ? new Class154.Class158(this, class161_0.FooterImage, this.vmethod_0(class161_0, Enum23.const_4), class161_0.FooterText, null, "", num4, 6) : new Class154.Class158(this, null, null, "", null, "", num4, 6);
			class4.method_0(6, num5);
			if (class161_0.RightToLeft == RightToLeft.Yes)
			{
				class4.method_1();
			}
			if (class4.rectangle_2.Height > 0)
			{
				class4.method_0(0, 6);
			}
			@class.WindowBounds = new Rectangle(0, 0, 6 + num4 + 6, class4.rectangle_2.Bottom + (this.method_5(class161_0) ? 6 : 0));
			@class.method_4(Enum23.const_0, class2.rectangle_0);
			@class.method_4(Enum23.const_1, class2.rectangle_1);
			@class.method_4(Enum23.const_5, class3.rectangle_0);
			@class.method_4(Enum23.const_6, class4.rectangle_0);
			@class.method_4(Enum23.const_4, class4.rectangle_1);
			if (class3.int_0 > 0)
			{
				Rectangle rectangle_ = class3.rectangle_1;
				rectangle_.Height = class3.int_0;
				@class.method_4(Enum23.const_2, rectangle_);
				rectangle_.Y = rectangle_.Bottom;
				rectangle_.Height = class3.rectangle_1.Height - class3.int_0;
				@class.method_4(Enum23.const_3, rectangle_);
			}
			else
			{
				@class.method_4(Enum23.const_2, Rectangle.Empty);
				@class.method_4(Enum23.const_3, class3.rectangle_1);
			}
			if (this.method_8(class161_0))
			{
				@class.ShadowBounds = new Rectangle(@class.WindowBounds.Location, @class.WindowBounds.Size + new Size(5, 5));
				if (class161_0.RightToLeft == RightToLeft.Yes)
				{
					@class.method_1(5, 0);
				}
			}
			else
			{
				@class.ShadowBounds = @class.WindowBounds;
			}
			return @class;
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x000B8F60 File Offset: 0x000B7160
		private Size method_10(string string_0, Font font_0, int int_1)
		{
			return Class148.smethod_2(string_0, font_0, new Size((int_1 == 0) ? 32767 : int_1, 0), (Enum25)2064);
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x000B8F90 File Offset: 0x000B7190
		protected Size method_11(Class161 class161_0, Enum23 enum23_0, int int_1)
		{
			this.method_2(class161_0);
			Size result;
			if (enum23_0 == Enum23.const_5)
			{
				if (class161_0.Image != null)
				{
					result = class161_0.Image.Size;
				}
				else
				{
					result = Size.Empty;
				}
			}
			else if (enum23_0 == Enum23.const_6)
			{
				if (class161_0.FooterImage != null)
				{
					result = class161_0.FooterImage.Size;
				}
				else
				{
					result = Size.Empty;
				}
			}
			else if (enum23_0 == Enum23.const_0)
			{
				if (class161_0.TitleImage != null)
				{
					result = class161_0.TitleImage.Size;
				}
				else
				{
					result = Size.Empty;
				}
			}
			else
			{
				string text = null;
				switch (enum23_0)
				{
				case Enum23.const_1:
					text = this.method_6(class161_0);
					break;
				case Enum23.const_2:
					text = class161_0.DisabledMessage;
					break;
				case Enum23.const_3:
					text = this.method_7(class161_0);
					break;
				case Enum23.const_4:
					text = class161_0.FooterText;
					break;
				}
				if (text != null)
				{
					result = this.method_10(text, this.vmethod_0(class161_0, enum23_0), class161_0.Provider.MaximumWidth);
				}
				else
				{
					result = Size.Empty;
				}
			}
			return result;
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x000B9080 File Offset: 0x000B7280
		public void method_12(PaintEventArgs paintEventArgs_0, Class161 class161_0, Class163 class163_0)
		{
			this.method_1(paintEventArgs_0, class161_0, ref class163_0);
			this.vmethod_3(paintEventArgs_0, class161_0, class163_0);
			this.vmethod_4(paintEventArgs_0, class161_0, class163_0);
			foreach (object obj in Enum.GetValues(typeof(Enum23)))
			{
				Enum23 enum23_ = (Enum23)obj;
				this.vmethod_5(paintEventArgs_0, class161_0, class163_0, enum23_);
			}
		}

		// Token: 0x0600104D RID: 4173 RVA: 0x000B9108 File Offset: 0x000B7308
		protected virtual void vmethod_3(PaintEventArgs paintEventArgs_0, Class161 class161_0, Class163 class163_0)
		{
			if (this.method_8(class161_0) && Rectangle.Intersect(class163_0.ShadowBounds, class163_0.WindowBounds) != class163_0.ShadowBounds)
			{
				Class154.smethod_4(paintEventArgs_0.Graphics, class163_0.ShadowBounds, 8, Color.FromArgb(128, Color.Black));
			}
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x000B9160 File Offset: 0x000B7360
		protected virtual void vmethod_4(PaintEventArgs paintEventArgs_0, Class161 class161_0, Class163 class163_0)
		{
			Rectangle windowBounds = class163_0.WindowBounds;
			paintEventArgs_0.Graphics.FillRectangle(SystemBrushes.Info, windowBounds);
			paintEventArgs_0.Graphics.DrawRectangle(SystemPens.InfoText, new Rectangle(windowBounds.X, windowBounds.Y, windowBounds.Width - 1, windowBounds.Height - 1));
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x000B91BC File Offset: 0x000B73BC
		protected virtual void vmethod_5(PaintEventArgs paintEventArgs_0, Class161 class161_0, Class163 class163_0, Enum23 enum23_0)
		{
			Rectangle rectangle = class163_0.method_3(enum23_0);
			string text = "";
			Image image = null;
			if (!rectangle.Size.IsEmpty)
			{
				switch (enum23_0)
				{
				case Enum23.const_0:
					image = class161_0.TitleImage;
					break;
				case Enum23.const_1:
					text = this.method_6(class161_0);
					break;
				case Enum23.const_2:
					text = class161_0.DisabledMessage;
					break;
				case Enum23.const_3:
					text = this.method_7(class161_0);
					break;
				case Enum23.const_4:
					text = class161_0.FooterText;
					break;
				case Enum23.const_5:
					image = class161_0.Image;
					break;
				case Enum23.const_6:
					image = class161_0.FooterImage;
					break;
				}
				if (text.Length > 0)
				{
					using (Class164 @class = new Class164())
					{
						@class.method_0(paintEventArgs_0.Graphics, rectangle);
						Rectangle rectangle2 = new Rectangle(0, 0, rectangle.Width, rectangle.Height);
						class163_0.method_0(-rectangle.X, -rectangle.Y);
						this.vmethod_4(new PaintEventArgs(@class.xbc626ed723e04991, rectangle2), class161_0, class163_0);
						class163_0.method_0(rectangle.X, rectangle.Y);
						Enum25 @enum = (Enum25)2064;
						if (class161_0.RightToLeft == RightToLeft.Yes)
						{
							@enum |= (Enum25)131074;
						}
						Class148.smethod_0(@class.xbc626ed723e04991, text, this.vmethod_0(class161_0, enum23_0), this.vmethod_1(class161_0, enum23_0), Color.Transparent, rectangle2, @enum);
						@class.method_3();
						goto IL_168;
					}
				}
				if (image != null)
				{
					paintEventArgs_0.Graphics.DrawImage(image, rectangle);
				}
				IL_168:;
			}
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x000B9344 File Offset: 0x000B7544
		internal static GraphicsPath smethod_3(Rectangle rectangle_0, int int_1, Class154.Enum22 enum22_0)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if ((enum22_0 & Class154.Enum22.flag_1) == (Class154.Enum22)0)
			{
				graphicsPath.AddLine(rectangle_0.X, rectangle_0.Y, rectangle_0.X, rectangle_0.Y);
			}
			else
			{
				graphicsPath.AddArc(new Rectangle(rectangle_0.X, rectangle_0.Y, int_1, int_1), 180f, 90f);
			}
			if ((enum22_0 & Class154.Enum22.flag_2) == (Class154.Enum22)0)
			{
				graphicsPath.AddLine(rectangle_0.Right - 1, rectangle_0.Y, rectangle_0.Right - 1, rectangle_0.Y);
			}
			else
			{
				graphicsPath.AddArc(new Rectangle(rectangle_0.Right - int_1 - 1, rectangle_0.Y, int_1, int_1), 270f, 90f);
			}
			if ((enum22_0 & Class154.Enum22.flag_4) == (Class154.Enum22)0)
			{
				graphicsPath.AddLine(rectangle_0.Right - 1, rectangle_0.Bottom - 1, rectangle_0.Right - 1, rectangle_0.Bottom - 1);
			}
			else
			{
				graphicsPath.AddArc(new Rectangle(rectangle_0.Right - int_1 - 1, rectangle_0.Bottom - int_1 - 1, int_1, int_1), 0f, 90f);
			}
			if ((enum22_0 & Class154.Enum22.flag_3) == (Class154.Enum22)0)
			{
				graphicsPath.AddLine(rectangle_0.X, rectangle_0.Bottom - 1, rectangle_0.X, rectangle_0.Bottom - 1);
			}
			else
			{
				graphicsPath.AddArc(new Rectangle(rectangle_0.X, rectangle_0.Bottom - int_1 - 1, int_1, int_1), 90f, 90f);
			}
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x000B94BC File Offset: 0x000B76BC
		internal static void smethod_4(Graphics graphics_0, Rectangle rectangle_0, int int_1, Color color_0)
		{
			graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
			using (Brush brush = new SolidBrush(Color.FromArgb((int)(color_0.A / 4), (int)color_0.R, (int)color_0.G, (int)color_0.B)))
			{
				for (int i = 0; i < 4; i++)
				{
					rectangle_0.Inflate(-1, -1);
					using (GraphicsPath graphicsPath = Class154.smethod_3(rectangle_0, int_1, Class154.Enum22.flag_0))
					{
						graphics_0.FillPath(brush, graphicsPath);
					}
				}
			}
			graphics_0.SmoothingMode = SmoothingMode.Default;
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x000B9560 File Offset: 0x000B7760
		public Region method_13(Class161 class161_0, Class163 class163_0)
		{
			this.method_2(class161_0);
			if (class163_0 == null)
			{
				class163_0 = this.vmethod_2(class161_0);
			}
			return this.vmethod_6(class161_0, class163_0);
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x000B958C File Offset: 0x000B778C
		protected virtual Region vmethod_6(Class161 class161_0, Class163 class163_0)
		{
			return null;
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06001054 RID: 4180 RVA: 0x000B95A0 File Offset: 0x000B77A0
		internal static bool x9843c083bd22e3f5
		{
			get
			{
				return OSFeature.Feature.IsPresent(OSFeature.LayeredWindows);
			}
		}

		// Token: 0x04000B85 RID: 2949
		private const int int_0 = 6;

		// Token: 0x04000B86 RID: 2950
		private static Class154 class154_0;

		// Token: 0x04000B87 RID: 2951
		private static Class154 class154_1 = new Class154.Class155();

		// Token: 0x04000B88 RID: 2952
		private static EventHandler eventHandler_0;

		// Token: 0x04000B89 RID: 2953
		internal Class152 class152_0 = new Class152();

		// Token: 0x02000159 RID: 345
		internal sealed class Class160 : Class159
		{
			// Token: 0x06001056 RID: 4182 RVA: 0x000088E3 File Offset: 0x00006AE3
			public Class160() : base(typeof(Class154))
			{
			}
		}

		// Token: 0x0200015A RID: 346
		private sealed class Class158
		{
			// Token: 0x06001057 RID: 4183 RVA: 0x000B95C0 File Offset: 0x000B77C0
			public Class158(Class154 renderer, Image image, Font titleFont, string titleText, Font textFont, string text, int width, int pad)
			{
				this.rectangle_0.Size = ((image != null) ? image.Size : Size.Empty);
				if (image != null)
				{
					this.rectangle_1.X = this.rectangle_0.Width + pad;
					this.rectangle_1.Width = width - this.rectangle_0.Width - pad;
				}
				else
				{
					this.rectangle_1.Width = width;
				}
				this.rectangle_1.Height = 0;
				if (titleText.Length > 0)
				{
					this.rectangle_1.Height = (this.int_0 = Class148.smethod_2(titleText, titleFont, new Size(this.rectangle_1.Width, 0), (Enum25)2064).Height);
				}
				if (text.Length > 0)
				{
					this.rectangle_1.Height = this.rectangle_1.Height + Class148.smethod_2(text, textFont, new Size(this.rectangle_1.Width, 0), (Enum25)2064).Height;
				}
				this.rectangle_2 = Rectangle.FromLTRB(0, 0, width, Math.Max(this.rectangle_0.Bottom, this.rectangle_1.Bottom));
			}

			// Token: 0x06001058 RID: 4184 RVA: 0x000088F5 File Offset: 0x00006AF5
			public void method_0(int int_1, int int_2)
			{
				this.rectangle_0.Offset(int_1, int_2);
				this.rectangle_1.Offset(int_1, int_2);
				this.rectangle_2.Offset(int_1, int_2);
			}

			// Token: 0x06001059 RID: 4185 RVA: 0x00008920 File Offset: 0x00006B20
			public void method_1()
			{
				this.rectangle_1.X = this.rectangle_2.X;
				this.rectangle_0.X = this.rectangle_2.Right - this.rectangle_0.Width;
			}

			// Token: 0x04000B8A RID: 2954
			public Rectangle rectangle_0 = Rectangle.Empty;

			// Token: 0x04000B8B RID: 2955
			public Rectangle rectangle_1 = Rectangle.Empty;

			// Token: 0x04000B8C RID: 2956
			public Rectangle rectangle_2;

			// Token: 0x04000B8D RID: 2957
			public int int_0;
		}

		// Token: 0x0200015B RID: 347
		[Flags]
		internal enum Enum22
		{
			// Token: 0x04000B8F RID: 2959
			flag_0 = 15,
			// Token: 0x04000B90 RID: 2960
			flag_1 = 1,
			// Token: 0x04000B91 RID: 2961
			flag_2 = 2,
			// Token: 0x04000B92 RID: 2962
			flag_3 = 4,
			// Token: 0x04000B93 RID: 2963
			flag_4 = 8
		}

		// Token: 0x0200015C RID: 348
		[Attribute2("(Default)")]
		private sealed class Class155 : Class154
		{
			// Token: 0x0600105A RID: 4186 RVA: 0x000B970C File Offset: 0x000B790C
			protected override Class163 vmethod_2(Class161 class161_0)
			{
				Class163 result;
				if (Class154.smethod_1() != null)
				{
					result = Class154.smethod_1().vmethod_2(class161_0);
				}
				else
				{
					result = base.vmethod_2(class161_0);
				}
				return result;
			}

			// Token: 0x0600105B RID: 4187 RVA: 0x0000895C File Offset: 0x00006B5C
			protected override void vmethod_3(PaintEventArgs paintEventArgs_0, Class161 class161_0, Class163 class163_0)
			{
				if (Class154.smethod_1() == null)
				{
					base.vmethod_3(paintEventArgs_0, class161_0, class163_0);
				}
				else
				{
					Class154.smethod_1().vmethod_3(paintEventArgs_0, class161_0, class163_0);
				}
			}

			// Token: 0x0600105C RID: 4188 RVA: 0x0000897F File Offset: 0x00006B7F
			protected override void vmethod_4(PaintEventArgs paintEventArgs_0, Class161 class161_0, Class163 class163_0)
			{
				if (Class154.smethod_1() == null)
				{
					base.vmethod_4(paintEventArgs_0, class161_0, class163_0);
				}
				else
				{
					Class154.smethod_1().vmethod_4(paintEventArgs_0, class161_0, class163_0);
				}
			}

			// Token: 0x0600105D RID: 4189 RVA: 0x000089A2 File Offset: 0x00006BA2
			protected override void vmethod_5(PaintEventArgs paintEventArgs_0, Class161 class161_0, Class163 class163_0, Enum23 enum23_0)
			{
				if (Class154.smethod_1() == null)
				{
					base.vmethod_5(paintEventArgs_0, class161_0, class163_0, enum23_0);
				}
				else
				{
					Class154.smethod_1().vmethod_5(paintEventArgs_0, class161_0, class163_0, enum23_0);
				}
			}

			// Token: 0x0600105E RID: 4190 RVA: 0x000B973C File Offset: 0x000B793C
			protected override Font vmethod_0(Class161 class161_0, Enum23 enum23_0)
			{
				Font result;
				if (Class154.smethod_1() != null)
				{
					result = Class154.smethod_1().vmethod_0(class161_0, enum23_0);
				}
				else
				{
					result = base.vmethod_0(class161_0, enum23_0);
				}
				return result;
			}

			// Token: 0x0600105F RID: 4191 RVA: 0x000B976C File Offset: 0x000B796C
			protected override Color vmethod_1(Class161 class161_0, Enum23 enum23_0)
			{
				Color result;
				if (Class154.smethod_1() != null)
				{
					result = Class154.smethod_1().vmethod_1(class161_0, enum23_0);
				}
				else
				{
					result = base.vmethod_1(class161_0, enum23_0);
				}
				return result;
			}

			// Token: 0x06001060 RID: 4192 RVA: 0x000B979C File Offset: 0x000B799C
			protected override Region vmethod_6(Class161 class161_0, Class163 class163_0)
			{
				Region result;
				if (Class154.smethod_1() != null)
				{
					result = Class154.smethod_1().vmethod_6(class161_0, class163_0);
				}
				else
				{
					result = base.vmethod_6(class161_0, class163_0);
				}
				return result;
			}
		}
	}
}
