using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns8;
using VisualHint.SmartPropertyGrid;

namespace ns4
{
	// Token: 0x020000EA RID: 234
	internal sealed partial class TextureStepEditor : Form
	{
		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x00083AF4 File Offset: 0x00081CF4
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x00006418 File Offset: 0x00004618
		public string ComplateReskey
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

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x00083B0C File Offset: 0x00081D0C
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x00006423 File Offset: 0x00004623
		public XmlDocument Complate
		{
			get
			{
				return this.xmlDocument_0;
			}
			set
			{
				this.xmlDocument_0 = value;
				this.method_0();
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00083B24 File Offset: 0x00081D24
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x00006434 File Offset: 0x00004634
		public XmlDocument Override
		{
			get
			{
				return this.xmlDocument_1;
			}
			set
			{
				this.xmlDocument_1 = value;
				this.method_2();
			}
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x00006445 File Offset: 0x00004645
		public TextureStepEditor()
		{
			this.InitializeComponent();
			this.dictionary_0 = new Dictionary<string, string>();
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x00083B3C File Offset: 0x00081D3C
		private void method_0()
		{
			this.destinations.Items.Clear();
			this.dictionary_0.Clear();
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode("/complate/texturePart");
			XmlNodeList xmlNodeList = xmlNode.SelectNodes("./destination");
			foreach (object obj in xmlNodeList)
			{
				XmlNode xmlNode2 = (XmlNode)obj;
				string value = xmlNode2.Attributes.GetNamedItem("textureName").Value;
				this.destinations.Items.Add(new TextureStepEditor.Class98(value, xmlNode2));
			}
			XmlNodeList xmlNodeList2 = this.xmlDocument_0.SelectNodes("/complate/variables/param");
			foreach (object obj2 in xmlNodeList2)
			{
				XmlNode xmlNode3 = (XmlNode)obj2;
				string value2 = xmlNode3.Attributes.GetNamedItem("name").Value;
				string value3 = xmlNode3.Attributes.GetNamedItem("default").Value;
				this.dictionary_0.Add(value2, value3);
			}
			this.method_1();
			this.destinations.SelectedIndex = 0;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00083CA4 File Offset: 0x00081EA4
		private void method_1()
		{
			this.variables.Clear();
			VisualHint.SmartPropertyGrid.PropertyGrid propertyGrid = this.variables;
			int id = 0;
			int num = 1;
			PropertyEnumerator underCategory = propertyGrid.AppendRootCategory(id, "Variables");
			foreach (KeyValuePair<string, string> keyValuePair in this.dictionary_0)
			{
				PropertyEnumerator propertyEnumerator = this.variables.AppendManagedProperty(underCategory, num++, keyValuePair.Key, typeof(string), keyValuePair.Value, "");
				propertyEnumerator.Property.Value.ReadOnly = false;
				propertyEnumerator.Property.Value.Tag = keyValuePair;
			}
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x00083D6C File Offset: 0x00081F6C
		private void method_2()
		{
			XmlNodeList xmlNodeList = this.xmlDocument_1.SelectNodes("/preset/complate/value");
			foreach (object obj in xmlNodeList)
			{
				XmlNode xmlNode = (XmlNode)obj;
				string value = xmlNode.Attributes.GetNamedItem("key").Value;
				string value2 = xmlNode.Attributes.GetNamedItem("value").Value;
				this.dictionary_0[value] = value2;
			}
			this.method_1();
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00006460 File Offset: 0x00004660
		private void destinations_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_3();
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00083E14 File Offset: 0x00082014
		private void method_3()
		{
			this.stepsGrid.Clear();
			int num = 0;
			VisualHint.SmartPropertyGrid.PropertyGrid propertyGrid = this.stepsGrid;
			int id = 0;
			num = 1;
			PropertyEnumerator underCategory = propertyGrid.AppendRootCategory(id, "Destination steps");
			XmlNode node = ((TextureStepEditor.Class98)this.destinations.SelectedItem).Node;
			XmlNodeList xmlNodeList = node.SelectNodes("./step");
			foreach (object obj in xmlNodeList)
			{
				XmlNode xmlNode = (XmlNode)obj;
				string value = xmlNode.Attributes.GetNamedItem("type").Value;
				PropertyEnumerator propertyEnumerator = this.stepsGrid.AppendManagedProperty(underCategory, num++, "Step", typeof(string), value, "");
				propertyEnumerator.Property.Tag = xmlNode;
				foreach (object obj2 in xmlNode.Attributes)
				{
					XmlAttribute xmlAttribute = (XmlAttribute)obj2;
					if (!(xmlAttribute.Name == "type") && !(xmlAttribute.Name == "uiVisible"))
					{
						PropertyEnumerator propertyEnumerator2 = this.stepsGrid.AppendManagedProperty(propertyEnumerator, num++, xmlAttribute.Name, typeof(string), xmlAttribute.Value, "");
						propertyEnumerator2.Property.Value.ReadOnly = false;
						propertyEnumerator2.Property.Value.Tag = xmlAttribute;
						propertyEnumerator2.Property.Tag = xmlNode;
					}
				}
			}
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void doneBtn_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00083FF8 File Offset: 0x000821F8
		private void stepsGrid_Click(object sender, EventArgs e)
		{
			PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.stepsGrid.SelectedPropertyEnumerator;
			if (selectedPropertyEnumerator != null && selectedPropertyEnumerator.Property.Tag != null && selectedPropertyEnumerator.Property.Tag.GetType().Equals(typeof(XmlElement)) && this.xmlElement_0 != selectedPropertyEnumerator.Property.Tag)
			{
				object tag = selectedPropertyEnumerator.Property.Tag;
				XmlElement xmlElement = this.xmlDocument_1.SelectNodes("/preset").Item(0) as XmlElement;
				string attribute = (this.xmlDocument_1.SelectNodes("/preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value");
				Image image = Class132.smethod_0().method_13(this.string_0, new Size(1024, 1024), xmlElement.SelectNodes("./complate").Item(0) as XmlElement, tag as XmlElement, this.destinations.Text, attribute);
				this.pictureBox1.Image = image;
				this.xmlElement_0 = (selectedPropertyEnumerator.Property.Tag as XmlElement);
			}
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00084124 File Offset: 0x00082324
		private void stepsGrid_PropertyChanged(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			this.bool_0 = true;
			XmlAttribute xmlAttribute = e.PropertyEnum.Property.Value.Tag as XmlAttribute;
			xmlAttribute.Value = (e.PropertyEnum.Property.Value.GetValue() as string);
			this.stepsGrid_Click(null, e);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00084180 File Offset: 0x00082380
		private void variables_PropertyChanged(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)e.PropertyEnum.Property.Value.Tag;
			try
			{
				(this.xmlDocument_0.SelectNodes("/complate/variables/param[@name='" + keyValuePair.Key + "']").Item(0) as XmlElement).SetAttribute("default", e.PropertyEnum.Property.Value.GetValue() as string);
			}
			catch (Exception)
			{
				MessageBox.Show("This is a override, it can not be changed.");
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0000646A File Offset: 0x0000466A
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040007AD RID: 1965
		private Dictionary<string, string> dictionary_0;

		// Token: 0x040007AE RID: 1966
		private XmlDocument xmlDocument_0;

		// Token: 0x040007AF RID: 1967
		private XmlDocument xmlDocument_1;

		// Token: 0x040007B0 RID: 1968
		private string string_0;

		// Token: 0x040007B1 RID: 1969
		public bool bool_0;

		// Token: 0x040007B2 RID: 1970
		private XmlElement xmlElement_0;

		// Token: 0x040007B3 RID: 1971
		private IContainer icontainer_0;

		// Token: 0x020000EB RID: 235
		private sealed class Class98
		{
			// Token: 0x17000189 RID: 393
			// (get) Token: 0x06000994 RID: 2452 RVA: 0x00084B90 File Offset: 0x00082D90
			// (set) Token: 0x06000995 RID: 2453 RVA: 0x0000648B File Offset: 0x0000468B
			public string Label { get; set; }

			// Token: 0x1700018A RID: 394
			// (get) Token: 0x06000996 RID: 2454 RVA: 0x00084BA8 File Offset: 0x00082DA8
			// (set) Token: 0x06000997 RID: 2455 RVA: 0x00006496 File Offset: 0x00004696
			public XmlNode Node { get; set; }

			// Token: 0x06000998 RID: 2456 RVA: 0x000064A1 File Offset: 0x000046A1
			public Class98(string label, XmlNode node)
			{
				this.Label = label;
				this.Node = node;
			}

			// Token: 0x06000999 RID: 2457 RVA: 0x00084BC0 File Offset: 0x00082DC0
			public string ToString()
			{
				return this.Label;
			}

			// Token: 0x040007C2 RID: 1986
			[CompilerGenerated]
			private string string_0;

			// Token: 0x040007C3 RID: 1987
			[CompilerGenerated]
			private XmlNode xmlNode_0;
		}
	}
}
