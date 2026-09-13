using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using ns1;
using ns10;
using ns11;
using ns14;
using ns19;
using ns21;
using ns4;
using Skybound.VisualTips;

namespace ns17
{
	// Token: 0x0200015F RID: 351
	[TypeConverter(typeof(Class179))]
	[Editor(typeof(Class162), typeof(UITypeEditor))]
	internal sealed class Class161 : ICustomTypeDescriptor, Interface12
	{
		// Token: 0x06001071 RID: 4209 RVA: 0x000B9AEC File Offset: 0x000B7CEC
		public Class161()
		{
			this.class152_0.x236e2b71e0b477c3 += this.method_7;
			this.class152_0.x0ad6cb77c00e4e89 += this.method_8;
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x000089F3 File Offset: 0x00006BF3
		public Class161(string text) : this(text, null, null, null, Shortcut.None, false)
		{
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x00008A01 File Offset: 0x00006C01
		public Class161(string text, string title) : this(text, title, null, null, Shortcut.None, false)
		{
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x00008A0F File Offset: 0x00006C0F
		public Class161(string text, string title, Image image) : this(text, title, image, null, Shortcut.None, false)
		{
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x00008A1D File Offset: 0x00006C1D
		public Class161(string text, string title, Image image, string disabledText, Shortcut shortcut, bool hideFooter) : this()
		{
			this.Text = text;
			this.Title = title;
			this.Image = image;
			this.DisabledText = disabledText;
			this.Shortcut = shortcut;
			this.HideFooter = hideFooter;
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06001076 RID: 4214 RVA: 0x000B9B3C File Offset: 0x000B7D3C
		[Browsable(false)]
		public VisualTipProvider Provider
		{
			get
			{
				return this.visualTipProvider_0;
			}
		}

		// Token: 0x06001077 RID: 4215 RVA: 0x00008A54 File Offset: 0x00006C54
		internal void method_0(VisualTipProvider visualTipProvider_1)
		{
			this.method_4();
			this.visualTipProvider_0 = visualTipProvider_1;
			this.control_0 = null;
			this.object_0 = null;
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x00008A73 File Offset: 0x00006C73
		internal void method_1(Control control_1, object object_1)
		{
			this.control_0 = control_1;
			this.object_0 = object_1;
			this.method_3();
		}

		// Token: 0x06001079 RID: 4217 RVA: 0x00008A8B File Offset: 0x00006C8B
		internal void method_2(EventArgs eventArgs_0)
		{
			this.method_4();
			this.method_3();
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x000B9B54 File Offset: 0x000B7D54
		private void method_3()
		{
			if (this.Provider != null && this.control_0 != null && this.object_0 == null && this.Provider.DisplayMode == Enum27.const_1)
			{
				this.control_0.KeyDown += this.control_0_KeyDown;
				this.control_0.HelpRequested += this.control_0_HelpRequested;
				this.bool_0 = true;
			}
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x000B9BC0 File Offset: 0x000B7DC0
		private void method_4()
		{
			if (this.bool_0)
			{
				this.control_0.KeyDown -= this.control_0_KeyDown;
				this.control_0.HelpRequested -= this.control_0_HelpRequested;
				this.bool_0 = false;
			}
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x00008A9B File Offset: 0x00006C9B
		private void control_0_HelpRequested(object sender, HelpEventArgs e)
		{
			if (Control.MouseButtons == MouseButtons.Left)
			{
				this.Provider.method_12(this.control_0, Enum29.flag_6 | Enum29.flag_10);
			}
			e.Handled = true;
		}

		// Token: 0x0600107D RID: 4221 RVA: 0x00008AC8 File Offset: 0x00006CC8
		private void control_0_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.F1)
			{
				this.Provider.method_12(this.control_0, Enum29.flag_10);
				e.Handled = true;
			}
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x00008AF3 File Offset: 0x00006CF3
		internal void method_5(Rectangle rectangle_1)
		{
			this.rectangle_0 = rectangle_1;
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x000B9C0C File Offset: 0x000B7E0C
		internal Rectangle method_6()
		{
			return this.rectangle_0;
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x000B9C24 File Offset: 0x000B7E24
		Class152 Interface12.imethod_0()
		{
			return this.class152_0;
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x00072108 File Offset: 0x00070308
		TypeConverter ICustomTypeDescriptor.GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x000721BC File Offset: 0x000703BC
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x000721A4 File Offset: 0x000703A4
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		// Token: 0x06001084 RID: 4228 RVA: 0x000720F0 File Offset: 0x000702F0
		string ICustomTypeDescriptor.GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x000059F2 File Offset: 0x00003BF2
		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x000720C0 File Offset: 0x000702C0
		AttributeCollection ICustomTypeDescriptor.GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, true);
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x000B88F0 File Offset: 0x000B6AF0
		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
		{
			return ((ICustomTypeDescriptor)this).GetProperties(null);
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x00072188 File Offset: 0x00070388
		object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x000B8908 File Offset: 0x000B6B08
		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x00072120 File Offset: 0x00070320
		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x000720D8 File Offset: 0x000702D8
		string ICustomTypeDescriptor.GetClassName()
		{
			return TypeDescriptor.GetClassName(this, true);
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x000B8920 File Offset: 0x000B6B20
		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
		{
			return Class152.smethod_0(this, attributes);
		}

		// Token: 0x0600108D RID: 4237 RVA: 0x00008AFE File Offset: 0x00006CFE
		private void method_7(object sender, PropertyChangedEventArgs e)
		{
			if (!this.x3d61f462e31dafa7 && !this.x1ee21b7088908641)
			{
				throw new InvalidOperationException("New visual tips may not be created while the form is being localized. Set the Language property of the Form or UserControl to (Default) and create a tip in the default language before localizing it.");
			}
		}

		// Token: 0x0600108E RID: 4238 RVA: 0x00008B1D File Offset: 0x00006D1D
		private void method_8(object sender, PropertyChangedEventArgs e)
		{
			if (this.x3d61f462e31dafa7)
			{
				this.x1ee21b7088908641 = this.class152_0.method_5();
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x0600108F RID: 4239 RVA: 0x000B9C3C File Offset: 0x000B7E3C
		// (set) Token: 0x06001090 RID: 4240 RVA: 0x00008B3A File Offset: 0x00006D3A
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		private bool x1ee21b7088908641
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

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06001091 RID: 4241 RVA: 0x000B9C54 File Offset: 0x000B7E54
		private bool x3d61f462e31dafa7
		{
			get
			{
				return Class161.smethod_0(this.Provider) == CultureInfo.InvariantCulture;
			}
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x000B9C78 File Offset: 0x000B7E78
		internal static CultureInfo smethod_0(IComponent icomponent_0)
		{
			if (icomponent_0 != null && icomponent_0.Site != null && icomponent_0.Site.DesignMode)
			{
				IDesignerHost designerHost = (IDesignerHost)icomponent_0.Site.GetService(typeof(IDesignerHost));
				PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(designerHost.RootComponent)["Language"];
				if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof(CultureInfo))
				{
					return propertyDescriptor.GetValue(designerHost.RootComponent) as CultureInfo;
				}
			}
			return CultureInfo.InvariantCulture;
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x000B9D00 File Offset: 0x000B7F00
		internal bool method_9()
		{
			bool result;
			if (!this.x1ee21b7088908641)
			{
				result = this.class152_0.method_5();
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x00008B45 File Offset: 0x00006D45
		internal void method_10()
		{
			this.class152_0.method_7();
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06001095 RID: 4245 RVA: 0x000B9D28 File Offset: 0x000B7F28
		// (set) Token: 0x06001096 RID: 4246 RVA: 0x000B9D64 File Offset: 0x000B7F64
		[AmbientValue(null)]
		[Description("The image displayed beside the title.")]
		[Localizable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Attribute1]
		[Editor(typeof(Class177), typeof(UITypeEditor))]
		public Image TitleImage
		{
			get
			{
				return (Image)this.class152_0.method_2("TitleImage", (this.Provider == null) ? null : this.Provider.TitleImage);
			}
			set
			{
				if (value != null && (value.Width > 128 || value.Height > 128))
				{
					throw new InvalidOperationException("The maximum image size is 128x128.");
				}
				this.class152_0.method_3("TitleImage", value, (this.Provider == null) ? null : this.Provider.TitleImage);
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06001097 RID: 4247 RVA: 0x000B9DC4 File Offset: 0x000B7FC4
		// (set) Token: 0x06001098 RID: 4248 RVA: 0x00008B54 File Offset: 0x00006D54
		[Localizable(true)]
		[Description("The title displayed in bold at the top of the tip.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Attribute1]
		public string Title
		{
			get
			{
				return (string)this.class152_0.method_2("Title", "");
			}
			set
			{
				this.class152_0.method_3("Title", (value == null) ? "" : value, "");
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06001099 RID: 4249 RVA: 0x000B9DF0 File Offset: 0x000B7FF0
		// (set) Token: 0x0600109A RID: 4250 RVA: 0x00008B78 File Offset: 0x00006D78
		[Localizable(true)]
		[Description("The shortcut key displayed beside the title, if it is not Shortcut.None.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Attribute1]
		public Shortcut Shortcut
		{
			get
			{
				return (Shortcut)this.class152_0.method_2("Shortcut", Shortcut.None);
			}
			set
			{
				this.class152_0.method_3("Shortcut", value, Shortcut.None);
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x0600109B RID: 4251 RVA: 0x000B9E20 File Offset: 0x000B8020
		// (set) Token: 0x0600109C RID: 4252 RVA: 0x00008B98 File Offset: 0x00006D98
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[Attribute1]
		[Description("The text displayed on the tooltip.")]
		public string Text
		{
			get
			{
				return (string)this.class152_0.method_2("Text", "");
			}
			set
			{
				this.class152_0.method_3("Text", (value == null) ? "" : value, "");
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x0600109D RID: 4253 RVA: 0x000B9E4C File Offset: 0x000B804C
		// (set) Token: 0x0600109E RID: 4254 RVA: 0x00008BBC File Offset: 0x00006DBC
		[Editor(typeof(Class177), typeof(UITypeEditor))]
		[Localizable(true)]
		[Attribute1]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Description("The image displayed beside the text.")]
		public Image Image
		{
			get
			{
				return (Image)this.class152_0.method_2("Image", null);
			}
			set
			{
				if (value != null && (value.Width > 128 || value.Height > 128))
				{
					throw new InvalidOperationException("The maximum image size is 128x128.");
				}
				this.class152_0.method_3("Image", value, null);
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x0600109F RID: 4255 RVA: 0x000B9E74 File Offset: 0x000B8074
		// (set) Token: 0x060010A0 RID: 4256 RVA: 0x00008BFA File Offset: 0x00006DFA
		[AmbientValue(null)]
		[Attribute1]
		[Description("The message displayed above the text when the tool is disabled.")]
		[Localizable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		public string DisabledMessage
		{
			get
			{
				return (string)this.class152_0.method_2("DisabledMessage", (this.Provider == null) ? "" : this.Provider.DisabledMessage);
			}
			set
			{
				this.class152_0.method_3("DisabledMessage", (value == null) ? "" : value, (this.Provider == null) ? "" : this.Provider.DisabledMessage);
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x060010A1 RID: 4257 RVA: 0x000B9EB4 File Offset: 0x000B80B4
		// (set) Token: 0x060010A2 RID: 4258 RVA: 0x00008C33 File Offset: 0x00006E33
		[Attribute1]
		[Localizable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Description("The alternate text displayed when the tool is disabled.  When this property is blank, the regular text is always used.")]
		[AmbientValue(null)]
		public string DisabledText
		{
			get
			{
				return (string)this.class152_0.method_2("DisabledText", "");
			}
			set
			{
				this.class152_0.method_3("DisabledText", (value == null) ? "" : value, "");
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x060010A3 RID: 4259 RVA: 0x000B9EE0 File Offset: 0x000B80E0
		// (set) Token: 0x060010A4 RID: 4260 RVA: 0x00008C57 File Offset: 0x00006E57
		[Description("Specifies whether the footer text and image are hidden on this tip.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[Attribute1]
		public bool HideFooter
		{
			get
			{
				return (bool)this.class152_0.method_2("HideFooter", false);
			}
			set
			{
				this.class152_0.method_3("HideFooter", value, false);
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x060010A5 RID: 4261 RVA: 0x000B9F10 File Offset: 0x000B8110
		// (set) Token: 0x060010A6 RID: 4262 RVA: 0x00008C77 File Offset: 0x00006E77
		[RefreshProperties(RefreshProperties.Repaint)]
		[Attribute1]
		[Localizable(true)]
		[AmbientValue(null)]
		[Description("The text displayed in the footer.")]
		public string FooterText
		{
			get
			{
				return (string)this.class152_0.method_2("FooterText", (this.Provider == null) ? "" : this.Provider.FooterText);
			}
			set
			{
				this.class152_0.method_3("FooterText", (value == null) ? "" : value, (this.Provider == null) ? "" : this.Provider.FooterText);
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x060010A7 RID: 4263 RVA: 0x000B9F50 File Offset: 0x000B8150
		// (set) Token: 0x060010A8 RID: 4264 RVA: 0x00008CB0 File Offset: 0x00006EB0
		[AmbientValue(null)]
		[Editor(typeof(Class177), typeof(UITypeEditor))]
		[Localizable(true)]
		[Attribute1]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Description("The image displayed in the footer.")]
		public Image FooterImage
		{
			get
			{
				return (Image)this.class152_0.method_2("FooterImage", (this.Provider == null) ? null : this.Provider.FooterImage);
			}
			set
			{
				this.class152_0.method_3("FooterImage", value, (this.Provider == null) ? null : this.Provider.FooterImage);
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x060010A9 RID: 4265 RVA: 0x000B9F8C File Offset: 0x000B818C
		// (set) Token: 0x060010AA RID: 4266 RVA: 0x00008CDB File Offset: 0x00006EDB
		[AmbientValue(Shortcut.F1)]
		[Description("The keyboard shortcut that may be pressed to raise the AccessKeyPressed event when the tip is displayed.")]
		[Attribute1]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		public Shortcut AccessKey
		{
			get
			{
				return (Shortcut)this.class152_0.method_2("AccessKey", (this.Provider == null) ? Shortcut.F1 : this.Provider.AccessKey);
			}
			set
			{
				this.class152_0.method_3("AccessKey", value, (this.Provider == null) ? Shortcut.F1 : this.Provider.AccessKey);
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x060010AB RID: 4267 RVA: 0x000B9FD0 File Offset: 0x000B81D0
		// (set) Token: 0x060010AC RID: 4268 RVA: 0x000BA018 File Offset: 0x000B8218
		[Localizable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[AmbientValue(256)]
		[Description("The maximum width of the tip.")]
		[Attribute1]
		public int MaximumWidth
		{
			get
			{
				return (int)this.class152_0.method_2("MaximumWidth", (this.Provider == null) ? 256 : this.Provider.MaximumWidth);
			}
			set
			{
				this.class152_0.method_3("MaximumWidth", Math.Max(value, 192), (this.Provider == null) ? 256 : this.Provider.MaximumWidth);
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x060010AD RID: 4269 RVA: 0x000BA068 File Offset: 0x000B8268
		// (set) Token: 0x060010AE RID: 4270 RVA: 0x00008D11 File Offset: 0x00006F11
		[RefreshProperties(RefreshProperties.Repaint)]
		[Attribute1]
		[Description("Specifies whether the tip will be displayed.")]
		[Localizable(true)]
		public bool Active
		{
			get
			{
				return (bool)this.class152_0.method_2("Active", true);
			}
			set
			{
				this.class152_0.method_3("Active", value, true);
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x060010AF RID: 4271 RVA: 0x000BA098 File Offset: 0x000B8298
		// (set) Token: 0x060010B0 RID: 4272 RVA: 0x00008D31 File Offset: 0x00006F31
		[Attribute1]
		[Description("Determines where a visual tip is displayed in relation to the tool area.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[AmbientValue(Enum28.flag_0)]
		public Enum28 DisplayPosition
		{
			get
			{
				return (Enum28)this.class152_0.method_2("DisplayPosition", (this.Provider == null) ? Enum28.flag_0 : this.Provider.DisplayPosition);
			}
			set
			{
				this.class152_0.method_3("DisplayPosition", value, -1);
			}
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x000BA0DC File Offset: 0x000B82DC
		private bool method_11(string string_0, Type type_0, out object object_1)
		{
			if (this.object_0 != null)
			{
				PropertyInfo property = this.object_0.GetType().GetProperty(string_0);
				if (property != null && property.PropertyType == type_0)
				{
					object_1 = property.GetValue(this.object_0, null);
					return true;
				}
			}
			object_1 = null;
			return false;
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x060010B2 RID: 4274 RVA: 0x000BA12C File Offset: 0x000B832C
		// (set) Token: 0x060010B3 RID: 4275 RVA: 0x00008D51 File Offset: 0x00006F51
		[Description("When this property is false, the disabled message and text and displayed on the tip.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Attribute1]
		public bool Enabled
		{
			get
			{
				return (bool)this.class152_0.method_2("Enabled", this.x97c8edeeedaec96e);
			}
			set
			{
				this.class152_0.method_3("Enabled", value, this.x97c8edeeedaec96e);
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x060010B4 RID: 4276 RVA: 0x000BA160 File Offset: 0x000B8360
		private bool x97c8edeeedaec96e
		{
			get
			{
				object obj;
				bool result;
				if (this.method_11("Enabled", typeof(bool), out obj))
				{
					result = (bool)obj;
				}
				else if (this.control_0 == null)
				{
					result = true;
				}
				else
				{
					result = this.control_0.Enabled;
				}
				return result;
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x060010B5 RID: 4277 RVA: 0x000BA1AC File Offset: 0x000B83AC
		// (set) Token: 0x060010B6 RID: 4278 RVA: 0x00008D76 File Offset: 0x00006F76
		[Description("The font used to display the tip text.")]
		[Localizable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[AmbientValue(null)]
		[Attribute1]
		public Font Font
		{
			get
			{
				return (Font)this.class152_0.method_2("Font", this.xbbfda0f74367649b);
			}
			set
			{
				this.class152_0.method_3("Font", (value == null) ? this.xbbfda0f74367649b : value, this.xbbfda0f74367649b);
			}
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x060010B7 RID: 4279 RVA: 0x000BA1D8 File Offset: 0x000B83D8
		private Font xbbfda0f74367649b
		{
			get
			{
				object obj;
				Font result;
				if (this.method_11("Font", typeof(Font), out obj))
				{
					result = (Font)obj;
				}
				else if (this.control_0 == null)
				{
					result = Control.DefaultFont;
				}
				else
				{
					result = this.control_0.Font;
				}
				return result;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x060010B8 RID: 4280 RVA: 0x000BA228 File Offset: 0x000B8428
		// (set) Token: 0x060010B9 RID: 4281 RVA: 0x00008D9C File Offset: 0x00006F9C
		[Attribute1]
		[Description("Whether the tip text is displayed using a right-to-left reading order.")]
		[Localizable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		public RightToLeft RightToLeft
		{
			get
			{
				return (RightToLeft)this.class152_0.method_2("RightToLeft", this.xbf0959fbe407afb3);
			}
			set
			{
				this.class152_0.method_3("RightToLeft", value, this.xbf0959fbe407afb3);
			}
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x060010BA RID: 4282 RVA: 0x000BA25C File Offset: 0x000B845C
		private RightToLeft xbf0959fbe407afb3
		{
			get
			{
				object obj;
				RightToLeft result;
				if (this.method_11("RightToLeft", typeof(RightToLeft), out obj))
				{
					result = (RightToLeft)obj;
				}
				else if (this.control_0 == null)
				{
					result = RightToLeft.No;
				}
				else
				{
					result = this.control_0.RightToLeft;
				}
				return result;
			}
		}

		// Token: 0x04000B98 RID: 2968
		private VisualTipProvider visualTipProvider_0;

		// Token: 0x04000B99 RID: 2969
		private Control control_0;

		// Token: 0x04000B9A RID: 2970
		private object object_0;

		// Token: 0x04000B9B RID: 2971
		private bool bool_0;

		// Token: 0x04000B9C RID: 2972
		private Rectangle rectangle_0;

		// Token: 0x04000B9D RID: 2973
		private Class152 class152_0 = new Class152();

		// Token: 0x04000B9E RID: 2974
		private bool bool_1;
	}
}
