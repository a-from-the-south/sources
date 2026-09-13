using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ns0;
using ns1;
using ns10;
using ns14;
using ns16;
using ns18;
using ns21;
using ns6;
using ns7;
using ns8;
using ns9;
using Package.Sims3Files;
using Package.Squish;
using Sims3WorkshopSDK;
using SlimDX;
using VisualHint.SmartPropertyGrid;

namespace ns3
{
	// Token: 0x0200001A RID: 26
	internal class Class2 : Class0
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000A5 RID: 165 RVA: 0x00015368 File Offset: 0x00013568
		// (remove) Token: 0x060000A6 RID: 166 RVA: 0x000153A0 File Offset: 0x000135A0
		public event Delegate8 OnPresetChanged
		{
			add
			{
				Delegate8 @delegate = this.delegate8_0;
				Delegate8 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate8 value2 = (Delegate8)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate8>(ref this.delegate8_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate8 @delegate = this.delegate8_0;
				Delegate8 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate8 value2 = (Delegate8)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate8>(ref this.delegate8_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x000153D8 File Offset: 0x000135D8
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x00002F0E File Offset: 0x0000110E
		public bool AdvancedMode { get; set; }

		// Token: 0x060000A9 RID: 169 RVA: 0x000153F0 File Offset: 0x000135F0
		public Class2()
		{
			base.RegisterFeel("texture", new Class58(this, false));
			base.RegisterFeelAttachment(typeof(TextureResKey), "texture");
			base.RegisterFeelAttachment(typeof(PatternResKey), "texture");
			base.RegisterFeelAttachment(typeof(PropResKey), "texture");
			base.RegisterFeelAttachment(typeof(ImageReskey), "texture");
			this.contextMenuStrip_0 = new ContextMenuStrip();
			ToolStripMenuItem value = new ToolStripMenuItem("Copy", null, new EventHandler(this.method_0));
			ToolStripMenuItem value2 = new ToolStripMenuItem("Paste", null, new EventHandler(this.vmethod_0));
			this.contextMenuStrip_0.Items.Add(value);
			this.contextMenuStrip_0.Items.Add(value2);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000154CC File Offset: 0x000136CC
		protected void method_0(object sender, EventArgs e)
		{
			PropertyVisibleDeepEnumerator selectedPropertyEnumerator = base.SelectedPropertyEnumerator;
			if (selectedPropertyEnumerator != null)
			{
				Class2.list_0.Clear();
				Class2.list_0.Add(selectedPropertyEnumerator.Clone() as PropertyEnumerator);
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00002A71 File Offset: 0x00000C71
		protected virtual void vmethod_0(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0001550C File Offset: 0x0001370C
		protected void method_1(Class48 class48_0)
		{
			Delegate8 @delegate = this.delegate8_0;
			if (@delegate != null)
			{
				@delegate(this, class48_0);
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00015530 File Offset: 0x00013730
		protected override void OnPropertyButtonClicked(PropertyButtonClickedEventArgs e)
		{
			object previousValue = e.PropertyEnum.Property.Value.PreviousValue;
			if (previousValue.GetType() == typeof(TextureResKey))
			{
				ImageEditor imageEditor = new ImageEditor();
				imageEditor.Image = (TextureResKey)previousValue;
				if (imageEditor.ShowDialog(Class132.mainForm) != DialogResult.Cancel)
				{
					((Class61)e.PropertyEnum.Property.Look).method_0(e, imageEditor.Image);
					((Class61)e.PropertyEnum.Property.Look).NeedsUpdate = true;
					base.NotifyPropertyChanged(new VisualHint.SmartPropertyGrid.PropertyChangedEventArgs(e.PropertyEnum));
				}
			}
			else if (previousValue.GetType() == typeof(PropResKey))
			{
				PropEditor propEditor = new PropEditor();
				propEditor.Prop = (PropResKey)previousValue;
				propEditor.OnPresetChanged += this.method_2;
				if (propEditor.ShowDialog(Class132.mainForm) != DialogResult.Cancel)
				{
					((Class62)e.PropertyEnum.Property.Look).method_0(e, propEditor.Prop);
					((Class62)e.PropertyEnum.Property.Look).NeedsUpdate = true;
					base.NotifyPropertyChanged(new VisualHint.SmartPropertyGrid.PropertyChangedEventArgs(e.PropertyEnum));
				}
				propEditor.method_1();
			}
			base.OnPropertyButtonClicked(e);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002A71 File Offset: 0x00000C71
		private void method_2(object object_0, Class48 class48_0)
		{
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00015680 File Offset: 0x00013880
		protected override void OnPropertyChanged(VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			object value = e.PropertyEnum.Property.Value.GetValue();
			if (e.PropertyEnum.Property.Value.TargetInstance is PropertyValueManaged)
			{
				if (e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.GetType() == typeof(XmlAttribute))
				{
					XmlAttribute xmlAttribute = (XmlAttribute)e.PropertyEnum.Property.Value.Tag;
					if (xmlAttribute.OwnerElement != null && xmlAttribute.OwnerElement.Attributes.GetNamedItem("cloneDefault") == null)
					{
						xmlAttribute.OwnerElement.Attributes.Append(XML.CreateAttribute(xmlAttribute.OwnerElement.OwnerDocument, "cloneDefault", xmlAttribute.InnerText));
					}
					if (value.GetType() == typeof(Class77))
					{
						Class77 @class = (Class77)value;
						string str = e.PropertyEnum.Property.Name.Replace("HSVShift ", "");
						XmlNode xmlNode = xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='Base H " + str + "']");
						XmlNode xmlNode2 = xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='H " + str + "']");
						string text = (@class.H / 360.0 - double.Parse(xmlNode.Attributes["value"].Value, CultureInfo.InvariantCulture.NumberFormat)).ToString("0.00000", CultureInfo.InvariantCulture.NumberFormat);
						xmlNode2.Attributes["value"].Value = text;
						XmlNode xmlNode3 = xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='Base S " + str + "']");
						XmlNode xmlNode4 = xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='S " + str + "']");
						string text2 = (@class.S - double.Parse(xmlNode3.Attributes["value"].Value, CultureInfo.InvariantCulture.NumberFormat)).ToString("0.00000", CultureInfo.InvariantCulture.NumberFormat);
						xmlNode4.Attributes["value"].Value = text2;
						XmlNode xmlNode5 = xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='Base V " + str + "']");
						XmlNode xmlNode6 = xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='V " + str + "']");
						string text3 = (@class.V - double.Parse(xmlNode5.Attributes["value"].Value, CultureInfo.InvariantCulture.NumberFormat)).ToString("0.00000", CultureInfo.InvariantCulture.NumberFormat);
						xmlNode6.Attributes["value"].Value = text3;
						xmlAttribute.InnerText = string.Concat(new string[]
						{
							text,
							",",
							text2,
							",",
							text3
						});
					}
					else
					{
						if (value.GetType() == typeof(TextureResKey))
						{
							string name = e.PropertyEnum.Property.Name;
							Match match = Regex.Match(name, "^Background Image|Channel|Texture ([0-9])+");
							if (match.Success)
							{
								string str2 = (name == "Background Image") ? "Bg" : match.Groups[1].Value;
								if (xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='Base H " + str2 + "']") != null)
								{
									Bitmap bitmap = new Bitmap(1, 1);
									DDS dds = (DDS)Class76.smethod_26((TextureResKey)value);
									Bitmap image = (Bitmap)ImageLoader.Load(dds.MipMaps[0]);
									using (Graphics graphics = Graphics.FromImage(bitmap))
									{
										graphics.DrawImage(image, new Rectangle(0, 0, 1, 1));
									}
									Color pixel = bitmap.GetPixel(0, 0);
									Class77 class2 = Class77.smethod_0(pixel);
									xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='Base H " + str2 + "']").Attributes["value"].Value = class2.BaseH.ToString("0.00000", CultureInfo.InvariantCulture.NumberFormat);
									xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='Base S " + str2 + "']").Attributes["value"].Value = class2.BaseS.ToString("0.00000", CultureInfo.InvariantCulture.NumberFormat);
									xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='Base V " + str2 + "']").Attributes["value"].Value = class2.BaseV.ToString("0.00000", CultureInfo.InvariantCulture.NumberFormat);
									xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='H " + str2 + "']").Attributes["value"].Value = "0";
									xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='S " + str2 + "']").Attributes["value"].Value = "0";
									xmlAttribute.OwnerElement.ParentNode.SelectSingleNode("value[@key='V " + str2 + "']").Attributes["value"].Value = "0";
									xmlAttribute.InnerText = this.method_6(value);
									this.method_1(new Class48());
								}
							}
						}
						string innerText = this.method_6(value);
						xmlAttribute.InnerText = innerText;
					}
				}
			}
			else if (e.PropertyEnum.HasParent && e.PropertyEnum.Parent.Property.Value != null && e.PropertyEnum.Parent.Property.Value.TargetInstance is PropertyValueManaged)
			{
				base.NotifyPropertyChanged(new VisualHint.SmartPropertyGrid.PropertyChangedEventArgs(e.PropertyEnum.Parent));
			}
			else
			{
				e.PropertyEnum.Property.Value.GetType();
				typeof(TextureResKey);
			}
			base.OnPropertyChanged(e);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00002F19 File Offset: 0x00001119
		protected void method_3(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
		{
			propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.SetValue(resKey_0);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00015D48 File Offset: 0x00013F48
		protected Type method_4(string string_2, string string_3)
		{
			Type typeFromHandle;
			if (string.IsNullOrEmpty(string_2))
			{
				typeFromHandle = typeof(string);
			}
			else if (string_2 == "bool")
			{
				typeFromHandle = typeof(bool);
			}
			else if (string_2 == "float")
			{
				typeFromHandle = typeof(float);
			}
			else if (string_2 == "vec2")
			{
				typeFromHandle = typeof(Vector2);
			}
			else if (string_2 == "color")
			{
				typeFromHandle = typeof(Color);
			}
			else if (string_2 == "texture")
			{
				typeFromHandle = typeof(TextureResKey);
			}
			else if (string_2 == "string" && string_3 != null && string_3.Contains("HSVShiftTypeEditor"))
			{
				typeFromHandle = typeof(Class77);
			}
			else if (string_2 == "pattern")
			{
				typeFromHandle = typeof(PatternResKey);
			}
			else if (string_2 == "floorcategory")
			{
				typeFromHandle = typeof(WALL.FloorCategory);
			}
			else if (string_2 == "wallcategory")
			{
				typeFromHandle = typeof(WALL.WallCategory);
			}
			else
			{
				typeFromHandle = typeof(string);
			}
			return typeFromHandle;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00015E84 File Offset: 0x00014084
		protected object method_5(string string_2, Type type_0, string string_3, XmlNode xmlNode_0)
		{
			object result;
			if (type_0 == typeof(float))
			{
				result = Class76.smethod_34(string_2);
			}
			else if (type_0 == typeof(Vector2))
			{
				string[] array = string_2.Split(new char[]
				{
					','
				});
				result = new Vector2(Class76.smethod_34(array[0]), Class76.smethod_34(array[1]));
			}
			else if (type_0 == typeof(bool))
			{
				result = bool.Parse(string_2);
			}
			else if (type_0 == typeof(Color))
			{
				result = Class76.smethod_32(string_2);
			}
			else if (type_0 == typeof(TextureResKey))
			{
				if (!ResKey.IsValid(string_2))
				{
					ResKey resKey = Class76.smethod_2(string_2, DBPFType.DDS);
					if (resKey == null)
					{
						result = new TextureResKey();
					}
					else
					{
						result = new TextureResKey(resKey.AsString());
					}
				}
				else
				{
					result = new TextureResKey(string_2);
				}
			}
			else if (type_0 == typeof(PatternResKey))
			{
				if (!ResKey.IsValid(string_2))
				{
					ResKey resKey2 = Class76.smethod_2(string_2, DBPFType.PRESET);
					if (resKey2 == null)
					{
						result = new PatternResKey();
					}
					else
					{
						result = new PatternResKey(resKey2.AsString());
					}
				}
				else
				{
					result = new PatternResKey(string_2);
				}
			}
			else if (type_0 == typeof(Class77))
			{
				string str = string_3.Replace("HSVShift ", "");
				XmlNode xmlNode = xmlNode_0.SelectSingleNode("value[@key='Base H " + str + "']");
				XmlNode xmlNode2 = xmlNode_0.SelectSingleNode("value[@key='H " + str + "']");
				string text = (double.Parse(xmlNode.Attributes["value"].Value, CultureInfo.InvariantCulture.NumberFormat) + double.Parse(xmlNode2.Attributes["value"].Value, CultureInfo.InvariantCulture.NumberFormat)).ToString("0.00000", CultureInfo.InvariantCulture.NumberFormat);
				XmlNode xmlNode3 = xmlNode_0.SelectSingleNode("value[@key='Base S " + str + "']");
				XmlNode xmlNode4 = xmlNode_0.SelectSingleNode("value[@key='S " + str + "']");
				string text2 = (double.Parse(xmlNode3.Attributes["value"].Value, CultureInfo.InvariantCulture.NumberFormat) + double.Parse(xmlNode4.Attributes["value"].Value, CultureInfo.InvariantCulture.NumberFormat)).ToString("0.00000", CultureInfo.InvariantCulture.NumberFormat);
				XmlNode xmlNode5 = xmlNode_0.SelectSingleNode("value[@key='Base V " + str + "']");
				XmlNode xmlNode6 = xmlNode_0.SelectSingleNode("value[@key='V " + str + "']");
				string text3 = (double.Parse(xmlNode5.Attributes["value"].Value, CultureInfo.InvariantCulture.NumberFormat) + double.Parse(xmlNode6.Attributes["value"].Value, CultureInfo.InvariantCulture.NumberFormat)).ToString("0.00000", CultureInfo.InvariantCulture.NumberFormat);
				result = new Class77(string.Concat(new string[]
				{
					text,
					",",
					text2,
					",",
					text3
				}));
			}
			else
			{
				result = string_2;
			}
			return result;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000161FC File Offset: 0x000143FC
		public string method_6(object object_0)
		{
			Type type = object_0.GetType();
			string result;
			if (type == typeof(float))
			{
				result = ((float)object_0).ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat);
			}
			else if (type == typeof(Color))
			{
				result = Class76.smethod_33((Color)object_0);
			}
			else if (type == typeof(Vector2))
			{
				float x = ((Vector2)object_0).X;
				string str = x.ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat);
				string str2 = ",";
				float y = ((Vector2)object_0).Y;
				result = str + str2 + y.ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat);
			}
			else if (typeof(ResKey).IsAssignableFrom(type))
			{
				result = (object_0 as ResKey).AsString();
			}
			else
			{
				result = string.Concat(object_0);
			}
			return result;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000162EC File Offset: 0x000144EC
		protected string method_7(string string_2, Dictionary<string, string> dictionary_0)
		{
			string text = string_2;
			string pattern = "\\(\\(\\$([a-zA-Z0-9]+)\\)\\)";
			foreach (object obj in Regex.Matches(string_2, pattern))
			{
				Match match = (Match)obj;
				string value = match.Groups[0].Value;
				string newValue = dictionary_0[match.Groups[1].Value];
				text = text.Replace(value, newValue);
			}
			return text;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0001638C File Offset: 0x0001458C
		protected void method_8(XmlNode xmlNode_0, PropertyEnumerator propertyEnumerator_0, int int_1, Dictionary<string, PropertyEnumerator> dictionary_0, XmlNode xmlNode_1)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			XmlNodeList xmlNodeList = xmlNode_1.SelectNodes("./value");
			if (xmlNodeList != null)
			{
				foreach (object obj in xmlNodeList)
				{
					XmlNode xmlNode = (XmlNode)obj;
					string value = xmlNode.Attributes["key"].Value;
					if (!dictionary.ContainsKey(value))
					{
						dictionary.Add(value, xmlNode.Attributes["value"].Value);
					}
				}
			}
			string text = (xmlNode_0.Attributes["uiCategory"] == null) ? null : xmlNode_0.Attributes["uiCategory"].Value;
			string value2 = xmlNode_0.Attributes["name"].Value;
			string propName = value2;
			if (Regex.IsMatch(value2, "^Stencil [A|B|C|D|E|F]$"))
			{
				text = value2;
				propName = "Texture";
			}
			else if (Regex.IsMatch(value2, "^Pattern [A|B|C|D]$"))
			{
				text = value2;
			}
			else if (value2.StartsWith("Stencil "))
			{
				propName = value2.Substring(10);
			}
			else if (value2.StartsWith("Pattern "))
			{
				propName = value2.Substring(10);
			}
			PropertyEnumerator propertyEnumerator = propertyEnumerator_0;
			if (!string.IsNullOrEmpty(text))
			{
				if (dictionary_0.ContainsKey(text))
				{
					propertyEnumerator = dictionary_0[text];
				}
				else
				{
					PropertyEnumerator propertyEnumerator2 = propertyEnumerator_0;
					if (Regex.IsMatch(text, "^Stencil [A|B|C|D|E|F]$"))
					{
						propertyEnumerator2 = dictionary_0["Stencils"];
					}
					else if (text.StartsWith("Pattern "))
					{
						propertyEnumerator2 = dictionary_0["Patterns"];
					}
					if (propertyEnumerator2 == null)
					{
						propertyEnumerator = base.AppendRootCategory(int_1, text);
					}
					else
					{
						propertyEnumerator = base.AppendSubCategory(propertyEnumerator2, int_1, text);
					}
					dictionary_0.Add(text, propertyEnumerator);
				}
			}
			else if (propertyEnumerator == null)
			{
				propertyEnumerator = dictionary_0["default"];
			}
			string text2 = xmlNode_0.Attributes["default"].Value;
			string text3 = text2;
			XmlNode xmlNode2 = xmlNode_1.SelectSingleNode("./value[@key='" + value2 + "']");
			if (xmlNode2 == null)
			{
				xmlNode2 = xmlNode_1.OwnerDocument.CreateElement("value");
				xmlNode2.Attributes.Append(XML.CreateAttribute(xmlNode_1.OwnerDocument, "key", value2));
				xmlNode2.Attributes.Append(XML.CreateAttribute(xmlNode_1.OwnerDocument, "value", text2));
				xmlNode2.Attributes.Append(XML.CreateAttribute(xmlNode_1.OwnerDocument, "cloneDefault", text2));
				xmlNode_1.AppendChild(xmlNode2);
			}
			else
			{
				text3 = xmlNode2.Attributes["value"].Value;
				XmlNode namedItem = xmlNode2.Attributes.GetNamedItem("cloneDefault");
				if (namedItem != null)
				{
					text2 = namedItem.InnerText;
				}
				else
				{
					text2 = text3;
				}
			}
			string value3 = xmlNode_0.Attributes["type"].Value;
			Type type = this.method_4(value3, (xmlNode_0.Attributes["uiEditor"] == null) ? null : xmlNode_0.Attributes["uiEditor"].Value);
			object obj2 = this.method_5(text3, type, value2, xmlNode_1);
			object value4 = this.method_5(text2, type, value2, xmlNode_1);
			if (xmlNode2.Attributes["type"] == null)
			{
				if (value3 == "color")
				{
					xmlNode2.Attributes.Append(XML.CreateAttribute(xmlNode_1.OwnerDocument, "type", "2"));
				}
				else if (value3 == "texture")
				{
					xmlNode2.Attributes.Append(XML.CreateAttribute(xmlNode_1.OwnerDocument, "type", "3"));
				}
				else if (value3 == "float")
				{
					xmlNode2.Attributes.Append(XML.CreateAttribute(xmlNode_1.OwnerDocument, "type", "4"));
				}
				else if (value3 == "vec2")
				{
					xmlNode2.Attributes.Append(XML.CreateAttribute(xmlNode_1.OwnerDocument, "type", "5"));
				}
				else if (value3 == "bool")
				{
					xmlNode2.Attributes.Append(XML.CreateAttribute(xmlNode_1.OwnerDocument, "type", "7"));
				}
				else
				{
					xmlNode2.Attributes.Append(XML.CreateAttribute(xmlNode_1.OwnerDocument, "type", "1"));
				}
			}
			XmlAttribute xmlAttribute = xmlNode_0.Attributes["uiDescription"];
			string text4;
			if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
			{
				text4 = this.method_7(xmlAttribute.Value, dictionary);
			}
			else
			{
				text4 = type.Name;
			}
			string text5 = text4;
			text4 = string.Concat(new string[]
			{
				text5,
				"\n",
				(xmlNode_0.Attributes["uiEditor"] == null) ? null : xmlNode_0.Attributes["uiEditor"].Value,
				" : ",
				value3
			});
			PropertyEnumerator propertyEnumerator3 = base.AppendManagedProperty(propertyEnumerator, this.int_0++, propName, type, obj2, text4);
			propertyEnumerator3.Property.Value.SetAttribute(new DefaultValueAttribute(value4));
			propertyEnumerator3.Property.Value.Tag = xmlNode2.Attributes.GetNamedItem("value");
			string a = (xmlNode_0.Attributes["uiVisible"] == null) ? null : xmlNode_0.Attributes["uiVisible"].Value;
			if (a == "false" && !this.AdvancedMode)
			{
				base.ShowProperty(propertyEnumerator3, false);
			}
			if ((value2 == "MaskHeight" || value2 == "MaskWidth") && !this.AdvancedMode)
			{
				base.ShowProperty(propertyEnumerator3, false);
			}
			if (Regex.IsMatch(value2, "^(Base )?[H|S|V] "))
			{
				base.ShowProperty(propertyEnumerator3, false);
			}
			if (type == typeof(Color))
			{
				propertyEnumerator3.Property.Value.SetAttribute(new PropertyDropDownContentAttribute(typeof(AlphaColorPicker), new object[]
				{
					true
				}));
				propertyEnumerator3.Property.Feel = base.GetRegisteredFeel("list");
				propertyEnumerator3.Property.Value.Look = new PropertyColorLook();
			}
			else if (type == typeof(Class77))
			{
				propertyEnumerator3.Property.Value.SetAttribute(new PropertyDropDownContentAttribute(typeof(Control2), new object[]
				{
					false
				}));
				propertyEnumerator3.Property.Tag = obj2;
				propertyEnumerator3.Property.Feel = base.GetRegisteredFeel("list");
				propertyEnumerator3.Property.Value.Look = new Class52();
			}
			else if (type == typeof(TextureResKey))
			{
				Class61 @class = new Class61();
				propertyEnumerator3.Property.Value.Look = @class;
				@class.PropertyChanged += this.method_3;
			}
			else if (type == typeof(PatternResKey))
			{
				propertyEnumerator3.Property.Value.Look = new Class63();
			}
		}

		// Token: 0x040000EB RID: 235
		public const string string_0 = "texture";

		// Token: 0x040000EC RID: 236
		public const string string_1 = "pattern";

		// Token: 0x040000ED RID: 237
		private Delegate8 delegate8_0;

		// Token: 0x040000EE RID: 238
		protected int int_0;

		// Token: 0x040000EF RID: 239
		private ContextMenuStrip contextMenuStrip_0;

		// Token: 0x040000F0 RID: 240
		protected static List<PropertyEnumerator> list_0 = new List<PropertyEnumerator>();

		// Token: 0x040000F1 RID: 241
		[CompilerGenerated]
		private bool bool_0;
	}
}
