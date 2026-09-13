using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns0;
using ns1;
using ns10;
using ns11;
using ns13;
using ns17;
using ns20;
using ns21;
using ns3;
using ns4;
using ns6;

namespace Skybound.VisualTips
{
	// Token: 0x02000164 RID: 356
	[DefaultEvent("AccessKeyPressed")]
	[ProvideProperty("VisualTip", typeof(object))]
	public sealed class VisualTipProvider : Component, IExtenderProvider
	{
		// Token: 0x060010DA RID: 4314 RVA: 0x000BA91C File Offset: 0x000B8B1C
		public VisualTipProvider()
		{
			Class175.smethod_2(this.InitialDelay, new EventHandler(this.method_7));
			VisualTipProvider.arrayList_0.Add(this);
			Class175.smethod_0();
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x00008E34 File Offset: 0x00007034
		public VisualTipProvider(IContainer container) : this()
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}
			container.Add(this);
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x060010DC RID: 4316 RVA: 0x000BA9B8 File Offset: 0x000B8BB8
		// (set) Token: 0x060010DD RID: 4317 RVA: 0x00008E53 File Offset: 0x00007053
		public ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				if (value != null && value.DesignMode)
				{
					this.method_0();
				}
				base.Site = value;
			}
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x00008E6F File Offset: 0x0000706F
		private void method_0()
		{
			if (VisualTipProvider.arrayList_0.Contains(this))
			{
				VisualTipProvider.arrayList_0.Remove(this);
				if (VisualTipProvider.arrayList_0.Count == 0)
				{
					Class175.smethod_1();
				}
			}
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x000BA9D0 File Offset: 0x000B8BD0
		static VisualTipProvider()
		{
			VisualTipProvider.smethod_0(typeof(ToolBar), new VisualTipProvider.Class166());
			VisualTipProvider.smethod_0(typeof(StatusBar), new VisualTipProvider.Class167());
			if (Environment.Version.Major >= 2)
			{
				VisualTipProvider.smethod_0(Class151.type_0, new VisualTipProvider.Class168());
			}
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x000BAA60 File Offset: 0x000B8C60
		public static void smethod_0(Type type_0, Interface14 interface14_0)
		{
			if (type_0 == null)
			{
				throw new ArgumentNullException("controlType");
			}
			if (interface14_0 == null)
			{
				throw new ArgumentNullException("extender");
			}
			VisualTipProvider.hashtable_0[type_0] = interface14_0;
			Type[] array = interface14_0.imethod_2();
			if (array != null)
			{
				foreach (Type key in array)
				{
					VisualTipProvider.hashtable_0[key] = interface14_0;
				}
			}
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x000BAAC4 File Offset: 0x000B8CC4
		[Description]
		private static void smethod_1(Type type_0, object object_4)
		{
			if (type_0 == null)
			{
				throw new ArgumentNullException("controlType");
			}
			if (object_4 == null)
			{
				throw new ArgumentNullException("extender");
			}
			if (!Class176.smethod_1(object_4))
			{
				throw new ArgumentException("The object did not provide the required methods.  Extenders must have 2 methods withthe following signatures:\r\n\r\nObject GetChildAtPoint(Control,Int32,Int32)\r\nObject GetParent(Object)", "extender");
			}
			VisualTipProvider.smethod_0(type_0, new Class176(object_4));
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x000BAB14 File Offset: 0x000B8D14
		internal static Interface14 smethod_2(Type type_0)
		{
			Interface14 @interface = VisualTipProvider.hashtable_0[type_0] as Interface14;
			if (@interface == null)
			{
				foreach (object obj in VisualTipProvider.hashtable_0)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					if (type_0.IsSubclassOf(dictionaryEntry.Key as Type))
					{
						return dictionaryEntry.Value as Interface14;
					}
				}
			}
			return @interface;
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x000BAB8C File Offset: 0x000B8D8C
		private static object smethod_3(Control control_1, Point point_0)
		{
			Interface14 @interface = VisualTipProvider.smethod_2(control_1.GetType());
			object obj = (@interface != null) ? @interface.imethod_0(control_1, point_0.X, point_0.Y) : null;
			Control control = VisualTipProvider.smethod_4(control_1, control_1.PointToScreen(point_0));
			object result;
			if (control != control_1)
			{
				result = control;
			}
			else
			{
				result = obj;
			}
			return result;
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x000BABDC File Offset: 0x000B8DDC
		private static Control smethod_4(Control control_1, Point point_0)
		{
			Control childAtPoint = control_1.GetChildAtPoint(control_1.PointToClient(point_0));
			Control result;
			if (childAtPoint != null)
			{
				result = VisualTipProvider.smethod_4(childAtPoint, point_0);
			}
			else
			{
				result = control_1;
			}
			return result;
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x000BAC0C File Offset: 0x000B8E0C
		private Rectangle method_1(Control control_1, object object_4)
		{
			Rectangle rectangle = Rectangle.Empty;
			if (!this.DisplayAtMousePosition)
			{
				if (object_4 == null)
				{
					if (!(control_1 is Form))
					{
						return control_1.Parent.RectangleToScreen(control_1.Bounds);
					}
					rectangle = Rectangle.Empty;
				}
				else
				{
					Interface14 @interface = VisualTipProvider.smethod_2(control_1.GetType());
					rectangle = ((@interface != null) ? @interface.imethod_3(object_4) : Rectangle.Empty);
				}
			}
			Rectangle result;
			if (!(rectangle == Rectangle.Empty))
			{
				result = control_1.RectangleToScreen(rectangle);
			}
			else
			{
				result = new Rectangle(Cursor.Position, new Size(16, 16));
			}
			return result;
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x00008E9C File Offset: 0x0000709C
		protected void Dispose(bool disposing)
		{
			Class175.smethod_3(this.InitialDelay, new EventHandler(this.method_7));
			this.method_0();
			base.Dispose(disposing);
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x060010E7 RID: 4327 RVA: 0x000BAC9C File Offset: 0x000B8E9C
		// (set) Token: 0x060010E8 RID: 4328 RVA: 0x00008EC4 File Offset: 0x000070C4
		[Category("Appearance")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Description("The renderer used to draw and measure a tip.")]
		public Class154 Renderer
		{
			get
			{
				return this.class154_0;
			}
			set
			{
				if (value == null)
				{
					value = Class154.DefaultRenderer;
				}
				if (this.class154_0 != value)
				{
					this.class154_0 = value;
					this.vmethod_0(EventArgs.Empty);
				}
			}
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x000BACB4 File Offset: 0x000B8EB4
		private bool ShouldSerializeRenderer()
		{
			return this.class154_0 != Class154.DefaultRenderer;
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x00008EED File Offset: 0x000070ED
		private void ResetRenderer()
		{
			this.Renderer = Class154.DefaultRenderer;
		}

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x060010EB RID: 4331 RVA: 0x00008EFC File Offset: 0x000070FC
		// (remove) Token: 0x060010EC RID: 4332 RVA: 0x00008F11 File Offset: 0x00007111
		[Category("Property Changed")]
		[Description("Occurs when the value of the Renderer property is changed.")]
		public event EventHandler RendererChanged
		{
			add
			{
				base.Events.AddHandler(VisualTipProvider.object_0, value);
			}
			remove
			{
				base.Events.RemoveHandler(VisualTipProvider.object_0, value);
			}
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x00008F26 File Offset: 0x00007126
		protected void vmethod_0(EventArgs eventArgs_0)
		{
			if ((EventHandler)base.Events[VisualTipProvider.object_0] != null)
			{
				((EventHandler)base.Events[VisualTipProvider.object_0])(this, eventArgs_0);
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x060010EE RID: 4334 RVA: 0x000BACD8 File Offset: 0x000B8ED8
		// (set) Token: 0x060010EF RID: 4335 RVA: 0x00008F5D File Offset: 0x0000715D
		[Editor(typeof(Class177), typeof(UITypeEditor))]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("The default image displayed beside the footer text on a VisualTip.")]
		[Localizable(true)]
		public Image FooterImage
		{
			get
			{
				return this.image_0;
			}
			set
			{
				if (value != null && (value.Width > 128 || value.Height > 128))
				{
					throw new InvalidOperationException("The maximum image size is 128x128.");
				}
				this.image_0 = value;
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x060010F0 RID: 4336 RVA: 0x000BACF0 File Offset: 0x000B8EF0
		// (set) Token: 0x060010F1 RID: 4337 RVA: 0x00008F90 File Offset: 0x00007190
		[DefaultValue("")]
		[Category("Appearance")]
		[Description("The default footer text on a VisualTip.")]
		[Localizable(true)]
		public string FooterText
		{
			get
			{
				string result;
				if (this.string_0 != null)
				{
					result = this.string_0;
				}
				else
				{
					result = "";
				}
				return result;
			}
			set
			{
				this.string_0 = value;
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x060010F2 RID: 4338 RVA: 0x000BAD18 File Offset: 0x000B8F18
		// (set) Token: 0x060010F3 RID: 4339 RVA: 0x00008F9B File Offset: 0x0000719B
		[Localizable(true)]
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("The title message written in bold above the text when the control is disabled.")]
		public string DisabledMessage
		{
			get
			{
				string result;
				if (this.string_1 != null)
				{
					result = this.string_1;
				}
				else
				{
					result = "";
				}
				return result;
			}
			set
			{
				this.string_1 = value;
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x060010F4 RID: 4340 RVA: 0x000BAD40 File Offset: 0x000B8F40
		// (set) Token: 0x060010F5 RID: 4341 RVA: 0x00008FA6 File Offset: 0x000071A6
		[Description("The image displayed beside the title of a visual tip which does not have another image assigned.")]
		[Category("Appearance")]
		[Editor(typeof(Class177), typeof(UITypeEditor))]
		[Localizable(true)]
		[DefaultValue(null)]
		public Image TitleImage
		{
			get
			{
				return this.image_1;
			}
			set
			{
				if (value != null && (value.Width > 128 || value.Height > 128))
				{
					throw new InvalidOperationException("The maximum image size is 128x128.");
				}
				this.image_1 = value;
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x060010F6 RID: 4342 RVA: 0x000BAD58 File Offset: 0x000B8F58
		// (set) Token: 0x060010F7 RID: 4343 RVA: 0x00008FD9 File Offset: 0x000071D9
		[TypeConverter(typeof(OpacityConverter))]
		[Description("The opacity level of the tip, ranging from 0% (transparent) to 100% (opaque).")]
		[Category("Appearance")]
		[DefaultValue(0.94)]
		public double Opacity
		{
			get
			{
				return this.double_0;
			}
			set
			{
				if (value < 0.0)
				{
					value = 0.0;
				}
				else if (value > 1.0)
				{
					value = 1.0;
				}
				this.double_0 = value;
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x060010F8 RID: 4344 RVA: 0x000BAD70 File Offset: 0x000B8F70
		// (set) Token: 0x060010F9 RID: 4345 RVA: 0x00009014 File Offset: 0x00007214
		[DefaultValue(256)]
		[Description("The maximum width of a VisualTip.")]
		[Category("Appearance")]
		[Localizable(true)]
		public int MaximumWidth
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = Math.Max(value, 192);
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x060010FA RID: 4346 RVA: 0x000BAD88 File Offset: 0x000B8F88
		// (set) Token: 0x060010FB RID: 4347 RVA: 0x00009029 File Offset: 0x00007229
		[Category("Behavior")]
		[Localizable(true)]
		[Description("The keyboard shortcut that may be pressed to raise the AccessKeyPressed event when a tip is displayed.")]
		public Shortcut AccessKey
		{
			get
			{
				Shortcut result;
				if (!this.ShouldSerializeAccessKey())
				{
					if (this.DisplayMode != Enum27.const_0)
					{
						result = Shortcut.None;
					}
					else
					{
						result = Shortcut.F1;
					}
				}
				else
				{
					result = this.shortcut_1;
				}
				return result;
			}
			set
			{
				this.shortcut_1 = value;
			}
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x000BADB8 File Offset: 0x000B8FB8
		private bool ShouldSerializeAccessKey()
		{
			return this.shortcut_1 != (Shortcut)(-1);
		}

		// Token: 0x060010FD RID: 4349 RVA: 0x00009034 File Offset: 0x00007234
		private void ResetAccessKey()
		{
			this.shortcut_1 = (Shortcut)(-1);
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x060010FE RID: 4350 RVA: 0x000BADD8 File Offset: 0x000B8FD8
		// (set) Token: 0x060010FF RID: 4351 RVA: 0x000BADF0 File Offset: 0x000B8FF0
		[Category("Behavior")]
		[Description("The amount of time which passes, in milliseconds, before a tip is displayed.")]
		public int InitialDelay
		{
			get
			{
				return this.int_2;
			}
			set
			{
				if (this.int_2 != value)
				{
					Class175.smethod_3(this.int_2, new EventHandler(this.method_7));
					this.int_2 = value;
					Class175.smethod_2(this.int_2, new EventHandler(this.method_7));
				}
			}
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x000BAE40 File Offset: 0x000B9040
		private bool ShouldSerializeInitialDelay()
		{
			return this.int_2 != SystemInformation.DoubleClickTime * 2;
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x0000903F File Offset: 0x0000723F
		private void ResetInitialDelay()
		{
			this.int_2 = SystemInformation.DoubleClickTime * 2;
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06001102 RID: 4354 RVA: 0x000BAE64 File Offset: 0x000B9064
		// (set) Token: 0x06001103 RID: 4355 RVA: 0x00009050 File Offset: 0x00007250
		[Category("Behavior")]
		[Description("The amount of time which must pass, in milliseconds, before a tip is displayed when the mouse is moved from one component to another.")]
		public int ReshowDelay
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
			}
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x000BAE7C File Offset: 0x000B907C
		private bool ShouldSerializeReshowDelay()
		{
			return this.int_3 != SystemInformation.DoubleClickTime;
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x0000905B File Offset: 0x0000725B
		private void ResetReshowDelay()
		{
			this.int_3 = SystemInformation.DoubleClickTime;
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06001106 RID: 4358 RVA: 0x000BAEA0 File Offset: 0x000B90A0
		// (set) Token: 0x06001107 RID: 4359 RVA: 0x0000906A File Offset: 0x0000726A
		[DefaultValue(false)]
		[Category("Behavior")]
		[Description("Whether VisualTips are displayed even when the form does not have the input focus.")]
		public bool ShowAlways
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06001108 RID: 4360 RVA: 0x000BAEB8 File Offset: 0x000B90B8
		// (set) Token: 0x06001109 RID: 4361 RVA: 0x00009075 File Offset: 0x00007275
		[Category("Appearance")]
		[DefaultValue(Enum24.const_0)]
		[Description("Determines if and how a VisualTip is animated when it is displayed.")]
		public Enum24 Animation
		{
			get
			{
				return this.enum24_0;
			}
			set
			{
				if (!Enum.IsDefined(typeof(Enum24), value))
				{
					throw new InvalidEnumArgumentException("Animation", (int)value, typeof(Enum24));
				}
				this.enum24_0 = value;
			}
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x0600110A RID: 4362 RVA: 0x000BAED0 File Offset: 0x000B90D0
		// (set) Token: 0x0600110B RID: 4363 RVA: 0x000090AD File Offset: 0x000072AD
		[Description("Determines whether a VisualTip has a shadow.")]
		[DefaultValue(Enum26.const_0)]
		[Category("Appearance")]
		public Enum26 Shadow
		{
			get
			{
				return this.enum26_0;
			}
			set
			{
				if (!Enum.IsDefined(typeof(Enum26), value))
				{
					throw new InvalidEnumArgumentException("Shadow", (int)value, typeof(Enum26));
				}
				this.enum26_0 = value;
			}
		}

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x0600110C RID: 4364 RVA: 0x000BAEE8 File Offset: 0x000B90E8
		// (set) Token: 0x0600110D RID: 4365 RVA: 0x000BAF00 File Offset: 0x000B9100
		[Category("Behavior")]
		[DefaultValue(Enum27.const_0)]
		[Description("Determines when a visual tip is displayed.")]
		public Enum27 DisplayMode
		{
			get
			{
				return this.enum27_0;
			}
			set
			{
				if (!Enum.IsDefined(typeof(Enum27), value))
				{
					throw new InvalidEnumArgumentException("DisplayMode", (int)value, typeof(Enum27));
				}
				if (this.enum27_0 != value)
				{
					this.enum27_0 = value;
					foreach (object obj in this.hashtable_1.Values)
					{
						Class161 @class = (Class161)obj;
						if (@class != null)
						{
							@class.method_2(EventArgs.Empty);
						}
					}
					this.vmethod_1(EventArgs.Empty);
				}
			}
		}

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x0600110E RID: 4366 RVA: 0x000090E5 File Offset: 0x000072E5
		// (remove) Token: 0x0600110F RID: 4367 RVA: 0x000090FA File Offset: 0x000072FA
		[Category("Property Changed")]
		[Description("Occurs when the value of the DisplayMode property is changed.")]
		public event EventHandler DisplayModeChanged
		{
			add
			{
				base.Events.AddHandler(VisualTipProvider.object_1, value);
			}
			remove
			{
				base.Events.RemoveHandler(VisualTipProvider.object_1, value);
			}
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x0000910F File Offset: 0x0000730F
		protected void vmethod_1(EventArgs eventArgs_0)
		{
			if ((EventHandler)base.Events[VisualTipProvider.object_1] != null)
			{
				((EventHandler)base.Events[VisualTipProvider.object_1])(this, eventArgs_0);
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06001111 RID: 4369 RVA: 0x000BAFB0 File Offset: 0x000B91B0
		// (set) Token: 0x06001112 RID: 4370 RVA: 0x000BAFC8 File Offset: 0x000B91C8
		[DefaultValue(Enum28.flag_0)]
		[Category("Behavior")]
		[Description("Determines where a visual tip is displayed in relation to the tool area.")]
		public Enum28 DisplayPosition
		{
			get
			{
				return this.enum28_0;
			}
			set
			{
				if (!Enum.IsDefined(typeof(Enum28), value))
				{
					throw new InvalidEnumArgumentException("DisplayPosition", (int)value, typeof(Enum28));
				}
				if (this.enum28_0 != value)
				{
					this.enum28_0 = value;
					this.vmethod_2(EventArgs.Empty);
				}
			}
		}

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x06001113 RID: 4371 RVA: 0x00009146 File Offset: 0x00007346
		// (remove) Token: 0x06001114 RID: 4372 RVA: 0x0000915B File Offset: 0x0000735B
		[Description("Occurs when the value of the DisplayPosition property is changed.")]
		[Category("Property Changed")]
		public event EventHandler DisplayPositionChanged
		{
			add
			{
				base.Events.AddHandler(VisualTipProvider.object_2, value);
			}
			remove
			{
				base.Events.RemoveHandler(VisualTipProvider.object_2, value);
			}
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x00009170 File Offset: 0x00007370
		protected void vmethod_2(EventArgs eventArgs_0)
		{
			if ((EventHandler)base.Events[VisualTipProvider.object_2] != null)
			{
				((EventHandler)base.Events[VisualTipProvider.object_2])(this, eventArgs_0);
			}
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06001116 RID: 4374 RVA: 0x000BB020 File Offset: 0x000B9220
		// (set) Token: 0x06001117 RID: 4375 RVA: 0x000091A7 File Offset: 0x000073A7
		[DefaultValue(true)]
		[Description("Whether VisualTips are displayed at the mouse position.")]
		[Category("Behavior")]
		public bool DisplayAtMousePosition
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x000BB038 File Offset: 0x000B9238
		public bool CanExtend(object extendee)
		{
			bool result;
			if (extendee == null)
			{
				result = false;
			}
			else
			{
				Type type = extendee.GetType();
				if (type.IsSubclassOf(typeof(Control)))
				{
					result = true;
				}
				else if (typeof(ToolBarButton).IsAssignableFrom(type))
				{
					result = true;
				}
				else if (typeof(StatusBarPanel).IsAssignableFrom(type))
				{
					result = true;
				}
				else if (type.GetEvent("MouseEnter") != null && type.GetEvent("MouseLeave") != null)
				{
					result = true;
				}
				else
				{
					result = (type.GetField("IsVisualTipComponent", BindingFlags.Static | BindingFlags.NonPublic) != null);
				}
			}
			return result;
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x000BB0CC File Offset: 0x000B92CC
		[Description("The VisualTip displayed when the mouse hovers over the current component.")]
		[MergableProperty(false)]
		public Class161 method_2(object object_4)
		{
			Class161 @class = this.hashtable_1[object_4] as Class161;
			if (@class == null)
			{
				@class = (this.hashtable_1[object_4] = new Class161());
				@class.method_0(this);
				VisualTipProvider.smethod_5(@class, object_4);
			}
			return @class;
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x000BB114 File Offset: 0x000B9314
		public void method_3(object object_4, Class161 class161_2)
		{
			Class161 @class = this.hashtable_1[object_4] as Class161;
			if (@class != null)
			{
				@class.method_0(null);
			}
			if (class161_2 != null && class161_2.Provider != null)
			{
				class161_2.Provider.method_3(object_4, null);
			}
			this.hashtable_1[object_4] = class161_2;
			if (class161_2 != null)
			{
				class161_2.method_0(this);
				VisualTipProvider.smethod_5(class161_2, object_4);
			}
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x000BB178 File Offset: 0x000B9378
		private static void smethod_5(Class161 class161_2, object object_4)
		{
			if (object_4 == null)
			{
				class161_2.method_1(null, null);
			}
			else if (object_4 is Control)
			{
				class161_2.method_1(object_4 as Control, null);
			}
			else
			{
				Interface14 @interface = VisualTipProvider.smethod_2(object_4.GetType());
				if (@interface != null)
				{
					class161_2.method_1(@interface.imethod_1(object_4) as Control, object_4);
				}
				else
				{
					class161_2.method_1(null, object_4);
				}
			}
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x000BB1D8 File Offset: 0x000B93D8
		private bool method_4(object object_4)
		{
			bool result;
			if (!this.hashtable_1.Contains(object_4))
			{
				result = false;
			}
			else
			{
				result = this.method_2(object_4).method_9();
			}
			return result;
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x000091B2 File Offset: 0x000073B2
		private void method_5(object object_4)
		{
			if (this.hashtable_1.Contains(object_4))
			{
				this.method_2(object_4).method_10();
			}
		}

		// Token: 0x0600111E RID: 4382 RVA: 0x000BB208 File Offset: 0x000B9408
		private Class161 method_6(Control control_1, object object_4)
		{
			Class161 @class = null;
			if (object_4 != null)
			{
				@class = (this.hashtable_1[object_4] as Class161);
			}
			if (@class == null)
			{
				@class = (this.hashtable_1[control_1] as Class161);
			}
			if (@class != null && !@class.Active)
			{
				@class = null;
			}
			return @class;
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x000BB254 File Offset: 0x000B9454
		internal void method_7(object sender, EventArgs e)
		{
			if (this.DisplayMode == Enum27.const_0 && this.x2795ceea9a4a3d4f == null)
			{
				if (Class175.xce630b15ef968765 == null || Class175.xce630b15ef968765 == this)
				{
					Control x2ae3d24e2dae102a = Class175.x2ae3d24e2dae102a;
					if (x2ae3d24e2dae102a != null && !x2ae3d24e2dae102a.IsDisposed)
					{
						Form activeForm = Form.ActiveForm;
						if (activeForm != null)
						{
							if (!this.ShowAlways)
							{
								Form form = x2ae3d24e2dae102a.FindForm();
								if (form != null && form != activeForm && (!form.IsMdiChild || form.MdiParent != activeForm || form.MdiParent.ActiveMdiChild != form))
								{
									return;
								}
							}
							object object_ = VisualTipProvider.smethod_3(x2ae3d24e2dae102a, x2ae3d24e2dae102a.PointToClient(Cursor.Position));
							Class161 @class = this.method_6(x2ae3d24e2dae102a, object_);
							if (@class != null)
							{
								if (@class == VisualTipProvider.class161_1)
								{
									Class175.xce630b15ef968765 = this;
								}
								else if (@class != this.x2795ceea9a4a3d4f)
								{
									this.method_24(x2ae3d24e2dae102a, object_, @class, this.method_1(x2ae3d24e2dae102a, object_), (Enum29)((Enum28)72 | @class.DisplayPosition));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x000BB340 File Offset: 0x000B9540
		internal void method_8(MouseEventArgs mouseEventArgs_0)
		{
			Control x2ae3d24e2dae102a = Class175.x2ae3d24e2dae102a;
			if (x2ae3d24e2dae102a != null)
			{
				Class161 @class = this.method_6(x2ae3d24e2dae102a, VisualTipProvider.smethod_3(x2ae3d24e2dae102a, new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y)));
				if (VisualTipProvider.class161_1 != null && @class != VisualTipProvider.class161_1)
				{
					VisualTipProvider.class161_1 = null;
				}
				else if (@class != this.x2795ceea9a4a3d4f)
				{
					Class175.smethod_5(this.ReshowDelay, new EventHandler(this.method_7));
					VisualTipProvider.smethod_6();
				}
			}
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x000091D0 File Offset: 0x000073D0
		internal void method_9()
		{
			if ((VisualTipProvider.form1_1.x73979cef1002ed01 & Enum29.flag_9) != Enum29.flag_0)
			{
				if (VisualTipProvider.TrackedTip != null)
				{
					VisualTipProvider.class161_1 = VisualTipProvider.TrackedTip;
				}
				VisualTipProvider.smethod_6();
			}
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x000BB3B4 File Offset: 0x000B95B4
		internal void method_10(EventArgs eventArgs_0)
		{
			if ((VisualTipProvider.form1_1.x73979cef1002ed01 & Enum29.flag_9) != Enum29.flag_0)
			{
				if (VisualTipProvider.form1_1.Bounds.Contains(Cursor.Position))
				{
					VisualTipProvider.class161_1 = this.x2795ceea9a4a3d4f;
				}
				else
				{
					VisualTipProvider.class161_1 = null;
					Class175.smethod_5(this.ReshowDelay, new EventHandler(this.method_7));
				}
				VisualTipProvider.smethod_6();
			}
		}

		// Token: 0x06001123 RID: 4387 RVA: 0x000BB41C File Offset: 0x000B961C
		internal void method_11(KeyEventArgs keyEventArgs_0)
		{
			if (this.x2795ceea9a4a3d4f != null)
			{
				if (keyEventArgs_0.KeyCode == Keys.Escape)
				{
					VisualTipProvider.class161_1 = this.x2795ceea9a4a3d4f;
					VisualTipProvider.smethod_6();
					keyEventArgs_0.Handled = true;
				}
				else if (keyEventArgs_0.KeyCode == (Keys)this.x2795ceea9a4a3d4f.AccessKey)
				{
					EventArgs7 eventArgs7_ = new EventArgs7(this.x2795ceea9a4a3d4f, (this.object_3 != null) ? this.object_3 : this.control_0);
					VisualTipProvider.class161_1 = this.x2795ceea9a4a3d4f;
					VisualTipProvider.smethod_6();
					keyEventArgs_0.Handled = true;
					this.vmethod_3(eventArgs7_);
				}
			}
		}

		// Token: 0x06001124 RID: 4388 RVA: 0x000091FB File Offset: 0x000073FB
		public void method_12(Control control_1, Enum29 enum29_0)
		{
			if (control_1 == null)
			{
				throw new ArgumentNullException("control");
			}
			this.method_13(control_1, enum29_0, (control_1.Parent == null) ? control_1.Bounds : control_1.Parent.RectangleToScreen(control_1.Bounds));
		}

		// Token: 0x06001125 RID: 4389 RVA: 0x000BB4AC File Offset: 0x000B96AC
		public void method_13(Control control_1, Enum29 enum29_0, Rectangle rectangle_0)
		{
			if (control_1 == null)
			{
				throw new ArgumentNullException("control");
			}
			Class161 @class = this.method_6(control_1, null);
			if (@class != null)
			{
				this.method_15(@class, rectangle_0, control_1, enum29_0);
			}
		}

		// Token: 0x06001126 RID: 4390 RVA: 0x00009236 File Offset: 0x00007436
		public void method_14(Class161 class161_2, Rectangle rectangle_0)
		{
			this.method_15(class161_2, rectangle_0, null, (Enum29)class161_2.DisplayPosition);
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x000BB4E0 File Offset: 0x000B96E0
		public void method_15(Class161 class161_2, Rectangle rectangle_0, Control control_1, Enum29 enum29_0)
		{
			if (class161_2 == null)
			{
				throw new ArgumentNullException("tip", "The tip parameter may not be null.");
			}
			if (control_1 != null && !control_1.IsDisposed)
			{
				if ((enum29_0 & Enum29.flag_7) == Enum29.flag_7)
				{
					control_1.KeyDown += this.method_16;
				}
				if ((enum29_0 & Enum29.flag_8) == Enum29.flag_8)
				{
					control_1.KeyPress += this.method_17;
				}
				if ((enum29_0 & Enum29.flag_10) == Enum29.flag_10)
				{
					control_1.LostFocus += this.method_18;
				}
				if ((enum29_0 & Enum29.flag_9) == Enum29.flag_9)
				{
					control_1.MouseDown += this.method_19;
				}
				if ((enum29_0 & Enum29.flag_11) == Enum29.flag_11)
				{
					control_1.TextChanged += this.method_21;
				}
				control_1.HandleDestroyed += this.method_20;
				Form form = control_1.FindForm();
				if (form != null)
				{
					form.Deactivate += this.method_22;
				}
			}
			this.method_24(control_1, null, class161_2, rectangle_0, enum29_0);
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x00009249 File Offset: 0x00007449
		private void method_16(object sender, KeyEventArgs e)
		{
			this.method_23(sender as Control);
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x00009249 File Offset: 0x00007449
		private void method_17(object sender, KeyPressEventArgs e)
		{
			this.method_23(sender as Control);
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x00009249 File Offset: 0x00007449
		private void method_18(object sender, EventArgs e)
		{
			this.method_23(sender as Control);
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x00009249 File Offset: 0x00007449
		private void method_19(object sender, MouseEventArgs e)
		{
			this.method_23(sender as Control);
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x00009249 File Offset: 0x00007449
		private void method_20(object sender, EventArgs e)
		{
			this.method_23(sender as Control);
		}

		// Token: 0x0600112D RID: 4397 RVA: 0x00009249 File Offset: 0x00007449
		private void method_21(object sender, EventArgs e)
		{
			this.method_23(sender as Control);
		}

		// Token: 0x0600112E RID: 4398 RVA: 0x00009259 File Offset: 0x00007459
		private void method_22(object sender, EventArgs e)
		{
			if (this.control_0 != null)
			{
				this.method_23(this.control_0);
			}
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x000BB5E0 File Offset: 0x000B97E0
		private void method_23(Control control_1)
		{
			control_1.MouseDown -= this.method_19;
			control_1.LostFocus -= this.method_18;
			control_1.KeyDown -= this.method_16;
			control_1.KeyPress -= this.method_17;
			control_1.HandleDestroyed -= this.method_20;
			Form form = control_1.FindForm();
			if (form != null)
			{
				form.Deactivate -= this.method_22;
			}
			if (this.control_0 == control_1)
			{
				this.method_25();
			}
		}

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x06001130 RID: 4400 RVA: 0x00009271 File Offset: 0x00007471
		// (remove) Token: 0x06001131 RID: 4401 RVA: 0x0000928C File Offset: 0x0000748C
		[Description("Occurs when the access key is pressed for a VisualTip.")]
		[Category("Key")]
		public event Delegate33 AccessKeyPressed
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.delegate33_0 = (Delegate33)Delegate.Combine(this.delegate33_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.delegate33_0 = (Delegate33)Delegate.Remove(this.delegate33_0, value);
			}
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x000092A7 File Offset: 0x000074A7
		protected void vmethod_3(EventArgs7 eventArgs7_0)
		{
			if (this.delegate33_0 != null)
			{
				this.delegate33_0(this, eventArgs7_0);
			}
		}

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x06001133 RID: 4403 RVA: 0x000092C0 File Offset: 0x000074C0
		// (remove) Token: 0x06001134 RID: 4404 RVA: 0x000092DB File Offset: 0x000074DB
		[Description("Occurs before a VisualTip is displayed.")]
		public event Delegate33 TipPopup
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.delegate33_1 = (Delegate33)Delegate.Combine(this.delegate33_1, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.delegate33_1 = (Delegate33)Delegate.Remove(this.delegate33_1, value);
			}
		}

		// Token: 0x06001135 RID: 4405 RVA: 0x000092F6 File Offset: 0x000074F6
		protected void vmethod_4(EventArgs7 eventArgs7_0)
		{
			if (this.delegate33_1 != null)
			{
				this.delegate33_1(this, eventArgs7_0);
			}
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06001136 RID: 4406 RVA: 0x000BB674 File Offset: 0x000B9874
		private Class161 x2795ceea9a4a3d4f
		{
			get
			{
				return this.class161_0;
			}
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x000BB68C File Offset: 0x000B988C
		private void method_24(Control control_1, object object_4, Class161 class161_2, Rectangle rectangle_0, Enum29 enum29_0)
		{
			if (control_1 != null && control_1.InvokeRequired)
			{
				control_1.BeginInvoke(new VisualTipProvider.Delegate32(this.method_24), new object[]
				{
					control_1,
					object_4,
					class161_2,
					rectangle_0,
					enum29_0
				});
			}
			else
			{
				bool flag;
				Form1 form = (flag = ((enum29_0 & Enum29.flag_6) == Enum29.flag_6)) ? VisualTipProvider.form1_1 : this.form1_0;
				if (form == null)
				{
					if (flag)
					{
						form = (VisualTipProvider.form1_1 = new Form1());
					}
					else
					{
						form = (this.form1_0 = new Form1());
					}
				}
				if (form.x8c3cc20aa74dd99c != class161_2)
				{
					form.method_4();
					EventArgs7 eventArgs = new EventArgs7(class161_2, (object_4 == null) ? control_1 : object_4);
					class161_2.method_0(this);
					VisualTipProvider.smethod_5(class161_2, eventArgs.Instance);
					this.vmethod_4(eventArgs);
					if (eventArgs.Cancel)
					{
						VisualTipProvider.class161_1 = class161_2;
					}
					else
					{
						this.class161_0 = class161_2;
						this.control_0 = control_1;
						this.object_3 = object_4;
						if (flag)
						{
							Class175.xce630b15ef968765 = this;
						}
						VisualTipProvider.xde1abe0aa61e3828.method_0(form, control_1);
						form.method_2(this, class161_2, rectangle_0, enum29_0);
					}
				}
				else
				{
					form.method_0(rectangle_0, enum29_0);
				}
			}
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06001138 RID: 4408 RVA: 0x000BB7B0 File Offset: 0x000B99B0
		internal static VisualTipProvider.Class165 xde1abe0aa61e3828
		{
			get
			{
				return VisualTipProvider.class165_0;
			}
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x0000930F File Offset: 0x0000750F
		public void method_25()
		{
			if (this.form1_0 != null)
			{
				this.form1_0.method_4();
			}
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x00009326 File Offset: 0x00007526
		internal void method_26(Form1 form1_2)
		{
			if (form1_2 == VisualTipProvider.form1_1 && Class175.xce630b15ef968765 == this)
			{
				Class175.xce630b15ef968765 = null;
			}
			this.class161_0 = null;
			this.control_0 = null;
			this.object_3 = null;
			VisualTipProvider.xde1abe0aa61e3828.method_3(form1_2);
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x0600113B RID: 4411 RVA: 0x000BB7C8 File Offset: 0x000B99C8
		[Browsable(false)]
		public bool IsTipDisplayed
		{
			get
			{
				bool result;
				if (this.form1_0 != null)
				{
					result = this.form1_0.x7965faace5d79aa4;
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x0600113C RID: 4412 RVA: 0x000BB7F0 File Offset: 0x000B99F0
		public static Class161 TrackedTip
		{
			get
			{
				Class161 result;
				if (Class175.xce630b15ef968765 != null)
				{
					result = Class175.xce630b15ef968765.x2795ceea9a4a3d4f;
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x0600113D RID: 4413 RVA: 0x000BB818 File Offset: 0x000B9A18
		internal static Control x0cb6bb318112e288
		{
			get
			{
				Control result;
				if (Class175.xce630b15ef968765 != null)
				{
					result = Class175.xce630b15ef968765.control_0;
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x0600113E RID: 4414 RVA: 0x00009360 File Offset: 0x00007560
		public static void smethod_6()
		{
			if (VisualTipProvider.form1_1 != null)
			{
				VisualTipProvider.form1_1.method_4();
			}
		}

		// Token: 0x0600113F RID: 4415
		[DllImport("user32", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr intptr_0, int int_4, IntPtr intptr_1, IntPtr intptr_2);

		// Token: 0x06001140 RID: 4416 RVA: 0x00009375 File Offset: 0x00007575
		public static void smethod_7(Control control_1, string string_2, string string_3)
		{
			VisualTipProvider.smethod_10(control_1, string_2, string_3, Enum31.const_0, Enum29.flag_0);
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x00009383 File Offset: 0x00007583
		public static void smethod_8(Control control_1, string string_2, string string_3, Enum31 enum31_0)
		{
			VisualTipProvider.smethod_10(control_1, string_2, string_3, enum31_0, Enum29.flag_0);
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x00009391 File Offset: 0x00007591
		public static void smethod_9(Control control_1, string string_2, string string_3, Enum31 enum31_0, Rectangle rectangle_0)
		{
			VisualTipProvider.smethod_12(control_1, string_2, string_3, enum31_0, Enum29.flag_0, rectangle_0);
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x000093A1 File Offset: 0x000075A1
		public static void smethod_10(Control control_1, string string_2, string string_3, Enum31 enum31_0, Enum29 enum29_0)
		{
			if (control_1 == null)
			{
				throw new ArgumentNullException("control");
			}
			VisualTipProvider.smethod_12(control_1, string_2, string_3, enum31_0, enum29_0, (control_1.Parent == null) ? control_1.Bounds : control_1.Parent.RectangleToScreen(control_1.Bounds));
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x000BB840 File Offset: 0x000B9A40
		public static void smethod_11(TextBox textBox_0, string string_2, string string_3, Enum31 enum31_0, int int_4)
		{
			if (textBox_0 == null || textBox_0.IsDisposed)
			{
				throw new ArgumentNullException("textBox", "textBox may not be null or disposed.");
			}
			if (int_4 >= 0 && int_4 <= textBox_0.TextLength)
			{
				if (int_4 == textBox_0.TextLength)
				{
					int_4 = Math.Max(int_4 - 1, 0);
				}
				int dw = VisualTipProvider.SendMessage(textBox_0.Handle, 214, new IntPtr(Math.Max(int_4, 0)), IntPtr.Zero).ToInt32();
				Point location = textBox_0.PointToScreen(new Point(dw));
				Rectangle rectangle_ = new Rectangle(location, new Size(1, textBox_0.Font.Height));
				VisualTipProvider.smethod_12(textBox_0, string_2, string_3, enum31_0, Enum29.flag_8 | Enum29.flag_10, rectangle_);
				return;
			}
			throw new ArgumentNullException("charIndex", "charIndex may not be less than zero or greater than the length of the TextBox text.");
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x000BB908 File Offset: 0x000B9B08
		public static void smethod_12(Control control_1, string string_2, string string_3, Enum31 enum31_0, Enum29 enum29_0, Rectangle rectangle_0)
		{
			if (control_1 == null)
			{
				throw new ArgumentNullException("control");
			}
			if (control_1.IsDisposed)
			{
				throw new ArgumentOutOfRangeException("control", control_1, "A tip may not be displayed for a control which has already been disposed.");
			}
			if (VisualTipProvider.visualTipProvider_0 == null)
			{
				VisualTipProvider.visualTipProvider_0 = new VisualTipProvider();
				VisualTipProvider.visualTipProvider_0.Renderer = new Class156();
			}
			rectangle_0.X -= 12;
			Class161 @class = new Class161(string_2, string_3);
			@class.TitleImage = VisualTipProvider.x6db34da0365f631e.smethod_0(enum31_0);
			VisualTipProvider.visualTipProvider_0.method_15(@class, rectangle_0, control_1, enum29_0);
		}

		// Token: 0x04000BB3 RID: 2995
		private const Shortcut shortcut_0 = (Shortcut)(-1);

		// Token: 0x04000BB4 RID: 2996
		private const int int_0 = 214;

		// Token: 0x04000BB5 RID: 2997
		private static ArrayList arrayList_0 = new ArrayList();

		// Token: 0x04000BB6 RID: 2998
		private static Hashtable hashtable_0 = new Hashtable();

		// Token: 0x04000BB7 RID: 2999
		private Class154 class154_0 = Class154.DefaultRenderer;

		// Token: 0x04000BB8 RID: 3000
		private static object object_0 = new object();

		// Token: 0x04000BB9 RID: 3001
		private Image image_0;

		// Token: 0x04000BBA RID: 3002
		private string string_0;

		// Token: 0x04000BBB RID: 3003
		private string string_1;

		// Token: 0x04000BBC RID: 3004
		private Image image_1;

		// Token: 0x04000BBD RID: 3005
		private double double_0 = 0.94;

		// Token: 0x04000BBE RID: 3006
		private int int_1 = 256;

		// Token: 0x04000BBF RID: 3007
		private Shortcut shortcut_1 = (Shortcut)(-1);

		// Token: 0x04000BC0 RID: 3008
		private int int_2 = SystemInformation.DoubleClickTime * 2;

		// Token: 0x04000BC1 RID: 3009
		private int int_3 = SystemInformation.DoubleClickTime;

		// Token: 0x04000BC2 RID: 3010
		private bool bool_0;

		// Token: 0x04000BC3 RID: 3011
		private Enum24 enum24_0 = Enum24.const_0;

		// Token: 0x04000BC4 RID: 3012
		private Enum26 enum26_0;

		// Token: 0x04000BC5 RID: 3013
		private Enum27 enum27_0;

		// Token: 0x04000BC6 RID: 3014
		private static object object_1 = new object();

		// Token: 0x04000BC7 RID: 3015
		private Enum28 enum28_0;

		// Token: 0x04000BC8 RID: 3016
		private static object object_2 = new object();

		// Token: 0x04000BC9 RID: 3017
		private bool bool_1 = true;

		// Token: 0x04000BCA RID: 3018
		private Hashtable hashtable_1 = new Hashtable();

		// Token: 0x04000BCB RID: 3019
		private Delegate33 delegate33_0;

		// Token: 0x04000BCC RID: 3020
		private Delegate33 delegate33_1;

		// Token: 0x04000BCD RID: 3021
		private Class161 class161_0;

		// Token: 0x04000BCE RID: 3022
		private Control control_0;

		// Token: 0x04000BCF RID: 3023
		private object object_3;

		// Token: 0x04000BD0 RID: 3024
		private static VisualTipProvider.Class165 class165_0 = new VisualTipProvider.Class165();

		// Token: 0x04000BD1 RID: 3025
		private Form1 form1_0;

		// Token: 0x04000BD2 RID: 3026
		private static Class161 class161_1;

		// Token: 0x04000BD3 RID: 3027
		private static Form1 form1_1;

		// Token: 0x04000BD4 RID: 3028
		private static VisualTipProvider visualTipProvider_0;

		// Token: 0x02000165 RID: 357
		internal sealed class Class165 : ReadOnlyCollectionBase
		{
			// Token: 0x06001146 RID: 4422 RVA: 0x000BB994 File Offset: 0x000B9B94
			public void method_0(Form1 form1_0, Control control_0)
			{
				this.method_1(control_0);
				VisualTipProvider.Class165.Struct14 @struct = default(VisualTipProvider.Class165.Struct14);
				@struct.form1_0 = form1_0;
				@struct.control_0 = control_0;
				base.InnerList.Add(@struct);
			}

			// Token: 0x06001147 RID: 4423 RVA: 0x000BB9D8 File Offset: 0x000B9BD8
			private bool method_1(Control control_0)
			{
				for (int i = base.InnerList.Count - 1; i >= 0; i--)
				{
					VisualTipProvider.Class165.Struct14 @struct = (VisualTipProvider.Class165.Struct14)base.InnerList[i];
					if (@struct.form1_0.x7965faace5d79aa4)
					{
						if (control_0 != null)
						{
							if (@struct.control_0 != control_0)
							{
								goto IL_50;
							}
						}
						bool result = (@struct.form1_0.x73979cef1002ed01 & Enum29.flag_12) == Enum29.flag_0;
						@struct.form1_0.method_4();
						return result;
					}
					base.InnerList.RemoveAt(i);
					IL_50:;
				}
				return false;
			}

			// Token: 0x06001148 RID: 4424 RVA: 0x000BBA68 File Offset: 0x000B9C68
			public bool method_2(Keys keys_0)
			{
				bool result;
				if (keys_0 == Keys.Escape)
				{
					result = this.method_1(null);
				}
				else
				{
					if (base.InnerList.Count > 0)
					{
						VisualTipProvider.Class165.Struct14 @struct = (VisualTipProvider.Class165.Struct14)base.InnerList[base.InnerList.Count - 1];
						Class161 x8c3cc20aa74dd99c = @struct.form1_0.x8c3cc20aa74dd99c;
						if (x8c3cc20aa74dd99c.AccessKey == (Shortcut)keys_0)
						{
							EventArgs7 eventArgs7_ = new EventArgs7(x8c3cc20aa74dd99c.Provider.x2795ceea9a4a3d4f, (x8c3cc20aa74dd99c.Provider.object_3 != null) ? x8c3cc20aa74dd99c.Provider.object_3 : x8c3cc20aa74dd99c.Provider.control_0);
							this.method_1(null);
							x8c3cc20aa74dd99c.Provider.vmethod_3(eventArgs7_);
							return true;
						}
					}
					result = false;
				}
				return result;
			}

			// Token: 0x06001149 RID: 4425 RVA: 0x000BBB24 File Offset: 0x000B9D24
			public void method_3(Form1 form1_0)
			{
				for (int i = base.InnerList.Count - 1; i >= 0; i--)
				{
					VisualTipProvider.Class165.Struct14 @struct = (VisualTipProvider.Class165.Struct14)base.InnerList[i];
					if (@struct.form1_0 == form1_0)
					{
						base.InnerList.RemoveAt(i);
						return;
					}
				}
			}

			// Token: 0x02000166 RID: 358
			private struct Struct14
			{
				// Token: 0x04000BD5 RID: 3029
				public Form1 form1_0;

				// Token: 0x04000BD6 RID: 3030
				public Control control_0;
			}
		}

		// Token: 0x02000167 RID: 359
		// (Invoke) Token: 0x0600114C RID: 4428
		private delegate void Delegate32(Control control, object component, Class161 tip, Rectangle toolArea, Enum29 options);

		// Token: 0x02000168 RID: 360
		private sealed class Class166 : Interface14
		{
			// Token: 0x0600114F RID: 4431 RVA: 0x000BBB7C File Offset: 0x000B9D7C
			public object imethod_0(Control control_0, int int_0, int int_1)
			{
				ToolBar toolBar = control_0 as ToolBar;
				object result;
				foreach (object obj in toolBar.Buttons)
				{
					ToolBarButton toolBarButton = (ToolBarButton)obj;
					if (toolBarButton.Rectangle.Contains(int_0, int_1))
					{
						result = toolBarButton;
						goto IL_5C;
					}
				}
				return null;
				IL_5C:
				return result;
			}

			// Token: 0x06001150 RID: 4432 RVA: 0x000BBBFC File Offset: 0x000B9DFC
			public object imethod_1(object object_0)
			{
				return (object_0 as ToolBarButton).Parent;
			}

			// Token: 0x06001151 RID: 4433 RVA: 0x000BBC18 File Offset: 0x000B9E18
			public Type[] imethod_2()
			{
				return new Type[]
				{
					typeof(ToolBarButton)
				};
			}

			// Token: 0x06001152 RID: 4434 RVA: 0x000BBC40 File Offset: 0x000B9E40
			public Rectangle imethod_3(object object_0)
			{
				return (object_0 as ToolBarButton).Rectangle;
			}
		}

		// Token: 0x02000169 RID: 361
		private sealed class Class167 : Interface14
		{
			// Token: 0x06001154 RID: 4436 RVA: 0x000BBC5C File Offset: 0x000B9E5C
			public object imethod_0(Control control_0, int int_1, int int_2)
			{
				StatusBar statusBar = control_0 as StatusBar;
				Size border3DSize = SystemInformation.Border3DSize;
				Rectangle rectangle = new Rectangle(border3DSize.Width, border3DSize.Height, 0, statusBar.Height - border3DSize.Height * 2);
				object result;
				foreach (object obj in statusBar.Panels)
				{
					StatusBarPanel statusBarPanel = (StatusBarPanel)obj;
					rectangle.Width = statusBarPanel.Width;
					if (rectangle.Contains(int_1, int_2))
					{
						result = statusBarPanel;
						goto IL_AF;
					}
					rectangle.X += rectangle.Width + border3DSize.Width;
				}
				return null;
				IL_AF:
				return result;
			}

			// Token: 0x06001155 RID: 4437 RVA: 0x000BBD30 File Offset: 0x000B9F30
			public object imethod_1(object object_0)
			{
				return (object_0 as StatusBarPanel).Parent;
			}

			// Token: 0x06001156 RID: 4438 RVA: 0x000BBD4C File Offset: 0x000B9F4C
			public Type[] imethod_2()
			{
				return new Type[]
				{
					typeof(StatusBarPanel)
				};
			}

			// Token: 0x06001157 RID: 4439
			[DllImport("user32")]
			private static extern IntPtr SendMessage(IntPtr intptr_0, int int_1, IntPtr intptr_1, int[] int_2);

			// Token: 0x06001158 RID: 4440 RVA: 0x000BBD74 File Offset: 0x000B9F74
			public Rectangle imethod_3(object object_0)
			{
				StatusBar parent = (object_0 as StatusBarPanel).Parent;
				int[] array = new int[4];
				VisualTipProvider.Class167.SendMessage(parent.Handle, 1034, new IntPtr(parent.Panels.IndexOf(object_0 as StatusBarPanel)), array);
				return Rectangle.FromLTRB(array[0], array[1], array[2], array[3]);
			}

			// Token: 0x04000BD7 RID: 3031
			private const int int_0 = 1034;
		}

		// Token: 0x0200016A RID: 362
		private sealed class Class168 : Interface14
		{
			// Token: 0x0600115A RID: 4442 RVA: 0x000BBDD4 File Offset: 0x000B9FD4
			public object imethod_0(Control control_0, int int_0, int int_1)
			{
				return control_0.GetType().GetMethod("GetItemAt", new Type[]
				{
					typeof(int),
					typeof(int)
				}).Invoke(control_0, new object[]
				{
					int_0,
					int_1
				});
			}

			// Token: 0x0600115B RID: 4443 RVA: 0x000BBE38 File Offset: 0x000BA038
			public object imethod_1(object object_0)
			{
				return object_0.GetType().GetMethod("GetCurrentParent", Type.EmptyTypes).Invoke(object_0, null);
			}

			// Token: 0x0600115C RID: 4444 RVA: 0x000BBE68 File Offset: 0x000BA068
			public Type[] imethod_2()
			{
				return new Type[]
				{
					Class151.type_1
				};
			}

			// Token: 0x0600115D RID: 4445 RVA: 0x000BBE8C File Offset: 0x000BA08C
			public Rectangle imethod_3(object object_0)
			{
				return (Rectangle)object_0.GetType().GetMethod("get_Bounds", Type.EmptyTypes).Invoke(object_0, null);
			}
		}

		// Token: 0x0200016B RID: 363
		private sealed class x6db34da0365f631e
		{
			// Token: 0x0600115F RID: 4447 RVA: 0x000BBEC4 File Offset: 0x000BA0C4
			static x6db34da0365f631e()
			{
				Assembly assembly = typeof(VisualTipProvider.x6db34da0365f631e).Assembly;
				Type typeFromHandle = typeof(VisualTipProvider.x6db34da0365f631e);
				VisualTipProvider.x6db34da0365f631e.image_0 = Image.FromStream(assembly.GetManifestResourceStream(typeFromHandle, "NotifyError.png"));
				VisualTipProvider.x6db34da0365f631e.image_1 = Image.FromStream(assembly.GetManifestResourceStream(typeFromHandle, "NotifyWarning.png"));
				VisualTipProvider.x6db34da0365f631e.image_2 = Image.FromStream(assembly.GetManifestResourceStream(typeFromHandle, "NotifyInformation.png"));
			}

			// Token: 0x06001160 RID: 4448 RVA: 0x000BBF30 File Offset: 0x000BA130
			public static Image smethod_0(Enum31 enum31_0)
			{
				Image result;
				switch (enum31_0)
				{
				case Enum31.const_1:
					result = VisualTipProvider.x6db34da0365f631e.image_2;
					break;
				case Enum31.const_2:
					result = VisualTipProvider.x6db34da0365f631e.image_1;
					break;
				case Enum31.const_3:
					result = VisualTipProvider.x6db34da0365f631e.image_0;
					break;
				default:
					result = null;
					break;
				}
				return result;
			}

			// Token: 0x04000BD8 RID: 3032
			public static readonly Image image_0;

			// Token: 0x04000BD9 RID: 3033
			public static readonly Image image_1;

			// Token: 0x04000BDA RID: 3034
			public static readonly Image image_2;
		}
	}
}
