using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ns1;
using ns16;
using ns17;
using ns19;
using ns2;
using ns20;
using ns6;
using ns8;
using Package;
using Package.Helper;
using Package.Sims3Files;
using PatternTool;
using Sims3WorkshopSDK;
using Skybound.VisualTips;
using SlimDX;
using SlimDX.Direct3D9;
using VisualHint.SmartPropertyGrid;

namespace ns3
{
	// Token: 0x02000080 RID: 128
	internal sealed partial class PatternEditor : Form
	{
		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060004E7 RID: 1255 RVA: 0x0004E4B0 File Offset: 0x0004C6B0
		// (remove) Token: 0x060004E8 RID: 1256 RVA: 0x0004E4E8 File Offset: 0x0004C6E8
		public event Delegate13 OnPatternChanged
		{
			add
			{
				Delegate13 @delegate = this.delegate13_0;
				Delegate13 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate13 value2 = (Delegate13)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate13>(ref this.delegate13_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate13 @delegate = this.delegate13_0;
				Delegate13 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate13 value2 = (Delegate13)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate13>(ref this.delegate13_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x0004E520 File Offset: 0x0004C720
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x000049B0 File Offset: 0x00002BB0
		public string PatternName { get; private set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0004E538 File Offset: 0x0004C738
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x000049BB File Offset: 0x00002BBB
		public PatternResKey Pattern
		{
			get
			{
				return this.patternResKey_0;
			}
			set
			{
				this.patternResKey_0 = value;
				this.patternResKey_1 = (PatternResKey)this.patternResKey_0.Clone();
				this.preset_1 = (Preset)Class76.smethod_26(this.patternResKey_0);
			}
		}

		// Token: 0x170000CC RID: 204
		// (set) Token: 0x060004ED RID: 1261 RVA: 0x000049F2 File Offset: 0x00002BF2
		public XmlElement Preset
		{
			set
			{
				this.xmlElement_0 = value;
				this.xmlElement_1 = (XmlElement)this.xmlElement_0.CloneNode(true);
				this.patternPropertyGrid1.PatternNode = this.xmlElement_0;
				this.method_0();
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0004E550 File Offset: 0x0004C750
		private void method_0()
		{
			if (this.patternResKey_0 != null)
			{
				if (this.xmlElement_0 != null)
				{
					this.method_2(this.patternResKey_0.AsString(), this.xmlElement_0, null, "", "", this.resKey_0);
					DataStream dataStream = BaseTexture.ToStream(this.texture_0, ImageFileFormat.Bmp);
					this.pictureBox1.Image = Image.FromStream(dataStream);
					dataStream.Dispose();
					this.statusLabel.Text = this.preset_1.Documents[0].FirstChild.Attributes["type"].Value + " / " + this.preset_1.Documents[0].FirstChild.Attributes["name"].Value;
					this.PatternName = this.preset_1.Documents[0].FirstChild.Attributes["name"].Value;
				}
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0004E660 File Offset: 0x0004C860
		public PatternEditor()
		{
			this.InitializeComponent();
			this.resKey_0 = new ResKey(DBPFType.PRESET, 0, (int)StringHelpers.FNV32("TSRW"), (int)StringHelpers.FNV32("presetSwatch"));
			this.device_0 = Class132.smethod_0().Device;
			this.texture_0 = Class132.smethod_0().method_4(new Size(256, 256));
			this.interface3_0 = Class132.smethod_0().method_8(new Size(256, 256));
			this.patternPropertyGrid1.PropertyChanged += this.patternPropertyGrid1_PropertyChanged;
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00004A2B File Offset: 0x00002C2B
		public void method_1()
		{
			if (this.interface3_0 != null)
			{
				this.interface3_0.imethod_2(true);
			}
			if (!this.texture_0.Disposed)
			{
				this.texture_0.Dispose();
			}
			base.Dispose(true);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0004E708 File Offset: 0x0004C908
		private void method_2(string string_1, XmlElement xmlElement_2, XmlElement xmlElement_3, string string_2, string string_3, ResKey resKey_1)
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.CreateElement("preset");
			XmlElement xmlElement2 = xmlDocument.CreateElement("complate");
			if (resKey_1 == null)
			{
				resKey_1 = new ResKey("key:0333406c:00000000:c6781323ce337c54");
			}
			xmlElement2.Attributes.Append(XML.CreateAttribute(xmlDocument, "reskey", string_1.ToString()));
			xmlElement.AppendChild(xmlElement2);
			if (xmlElement_2 != null)
			{
				XmlNodeList xmlNodeList = xmlElement_2.SelectNodes("value");
				foreach (object obj in xmlNodeList)
				{
					XmlNode xmlNode = (XmlNode)obj;
					XmlElement xmlElement3 = xmlDocument.CreateElement("value");
					xmlElement3.Attributes.Append(XML.CreateAttribute(xmlDocument, "key", xmlNode.Attributes["key"].Value));
					xmlElement3.Attributes.Append(XML.CreateAttribute(xmlDocument, "value", xmlNode.Attributes["value"].Value));
					xmlElement2.AppendChild(xmlElement3);
				}
			}
			xmlDocument.AppendChild(xmlElement);
			this.interface3_0.imethod_0(this.device_0, xmlDocument, xmlElement_3, string_2, string_3, this.texture_0);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00004A62 File Offset: 0x00002C62
		private void patternPropertyGrid1_PropertyChanged(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			if (this.liveUpdate.Checked)
			{
				this.method_5(new Class55());
			}
			this.method_0();
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0004E864 File Offset: 0x0004CA64
		private void doneBtn_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			DBPF package = Class132.mainForm.CurrentProject.Package;
			if (this.dds_0 != null)
			{
				package.AddEntry(this.dds_0);
			}
			if (this.preset_0 != null)
			{
				package.AddEntry(this.preset_0);
			}
			base.Close();
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0004E8B8 File Offset: 0x0004CAB8
		private XmlAttribute method_3(XmlDocument xmlDocument_0, string string_1, string string_2)
		{
			XmlAttribute xmlAttribute = xmlDocument_0.CreateAttribute(string_1);
			xmlAttribute.Value = string_2;
			return xmlAttribute;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0004E8DC File Offset: 0x0004CADC
		private void browseBtn_Click(object sender, EventArgs e)
		{
			PatternBrowseDialog patternBrowseDialog = new PatternBrowseDialog(this.patternResKey_0);
			if (patternBrowseDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.patternResKey_0 = patternBrowseDialog.SelectedPattern;
				this.method_4();
			}
			this.method_0();
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0004E91C File Offset: 0x0004CB1C
		private void method_4()
		{
			this.dds_0 = null;
			this.preset_0 = null;
			Preset preset = Class76.smethod_26(this.patternResKey_0) as Preset;
			XmlDocument xmlDocument = preset.Documents[0];
			for (int i = 0; i < this.xmlElement_0.ChildNodes.Count; i++)
			{
				XmlElement xmlElement = this.xmlElement_0.ChildNodes[i] as XmlElement;
				if (xmlDocument.SelectSingleNode("/complate/variables/param[@name='" + xmlElement.Attributes["key"].Value + "']") != null)
				{
					Console.WriteLine("Removing: /complate/variables/param[@name='" + xmlElement.Attributes["key"].Value + "']");
					this.xmlElement_0.RemoveChild(xmlElement);
					i--;
				}
			}
			this.xmlElement_0.Attributes.GetNamedItem("reskey").InnerText = this.patternResKey_0.AsString();
			this.patternPropertyGrid1.PatternNode = this.xmlElement_0;
			this.preset_1 = (Preset)Class76.smethod_26(this.patternResKey_0);
			this.method_0();
			if (this.liveUpdate.Checked)
			{
				this.method_5(new Class55());
			}
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0004EA60 File Offset: 0x0004CC60
		private void newBtn_Click(object sender, EventArgs e)
		{
			PatternForm patternForm = new PatternForm(true);
			patternForm.SetWorkshopInstance(Class132.mainForm);
			if (this.dds_0 != null)
			{
				DBPF package = Class132.mainForm.CurrentProject.Package;
				package.RemoveEntry(this.dds_0);
			}
			if (patternForm.ShowDialog(this) == DialogResult.OK)
			{
				this.preset_0 = patternForm.Complate;
				this.dds_0 = patternForm.RGBMask;
				DBPF package2 = Class132.mainForm.CurrentProject.Package;
				package2.AddEntry(this.preset_0);
				if (this.dds_0 != null)
				{
					package2.AddEntry(this.dds_0);
				}
				this.patternResKey_0 = new PatternResKey(this.preset_0.GenerateResKey());
				this.method_4();
			}
			else
			{
				this.preset_0 = null;
				this.dds_0 = null;
			}
			this.method_0();
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0004EB2C File Offset: 0x0004CD2C
		private void exportBtn_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "TSR Workshop Pattern (*.wsp)|*.wsp";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				DBPF dbpf = new DBPF();
				Preset preset = new Preset();
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(this.preset_1.Documents[0].InnerXml);
				XmlNodeList xmlNodeList = this.xmlElement_0.SelectNodes("value");
				foreach (object obj in xmlNodeList)
				{
					XmlNode xmlNode = (XmlNode)obj;
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/complate/variables/param[@name='" + xmlNode.Attributes["key"].Value + "']");
					if (xmlNode2 != null)
					{
						xmlNode2.Attributes["default"].Value = xmlNode.Attributes["value"].Value;
					}
					if (ResKey.IsValid(xmlNode.Attributes["value"].Value))
					{
						ResKey resKey = new ResKey(xmlNode.Attributes["value"].Value);
						DBPFEntry entry = Class76.smethod_26(resKey);
						dbpf.AddEntry(entry);
					}
				}
				preset.Documents.Add(xmlDocument);
				preset.ResKey = preset.ResKey.CloneUnique(0);
				dbpf.AddEntry(preset);
				dbpf.SaveToFile(saveFileDialog.FileName);
			}
			this.method_0();
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0004ECC8 File Offset: 0x0004CEC8
		private void importBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "TSR Workshop Pattern (*.wsp)|*.wsp";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				DBPF dbpf = new DBPF(openFileDialog.FileName);
				dbpf.NumEntries();
				List<ResKey> list = dbpf.SearchEntries(new ResKey(DBPFType.PRESET));
				if (list.Count != 1)
				{
					MessageBox.Show("Invalid pattern file, expected to find 1 preset but found " + list.Count);
					return;
				}
				List<ResKey> list2 = dbpf.SearchEntries(new ResKey(0U, 0, 0, 0));
				foreach (ResKey key in list2)
				{
					Class132.mainForm.CurrentProject.Package.AddEntry(dbpf.GetEntry(key));
				}
				this.patternResKey_0 = new PatternResKey(list[0].AsString());
				Preset preset = dbpf.GetEntry(list[0]) as Preset;
				if (preset != null)
				{
					using (List<XmlDocument>.Enumerator enumerator2 = preset.Documents.GetEnumerator())
					{
						if (enumerator2.MoveNext())
						{
							XmlDocument xmlDocument = enumerator2.Current;
							XmlNode xmlNode = xmlDocument.SelectSingleNode("/complate");
							if (xmlNode != null && xmlNode.Attributes["reskey"] != null && xmlNode.Attributes["reskey"].Value != list[0].AsString())
							{
								(xmlNode as XmlElement).SetAttribute("reskey", list[0].AsString());
							}
						}
					}
				}
				this.method_4();
			}
			this.method_0();
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0004EE90 File Offset: 0x0004D090
		private void cancelBtn_Click(object sender, EventArgs e)
		{
			if (this.dds_0 != null)
			{
				DBPF package = Class132.mainForm.CurrentProject.Package;
				package.RemoveEntry(this.dds_0);
			}
			this.patternResKey_0 = (PatternResKey)this.patternResKey_1.Clone();
			this.xmlElement_0.ParentNode.ReplaceChild(this.xmlElement_1, this.xmlElement_0);
			this.method_5(new Class55());
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0004EF04 File Offset: 0x0004D104
		private void method_5(Class55 class55_0)
		{
			Delegate13 @delegate = this.delegate13_0;
			if (@delegate != null)
			{
				@delegate(this, class55_0);
			}
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00004A84 File Offset: 0x00002C84
		private void method_6(object sender, EventArgs e)
		{
			this.method_5(new Class55());
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00002A71 File Offset: 0x00000C71
		private void PatternEditor_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00004A93 File Offset: 0x00002C93
		private void PatternEditor_Shown(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00004A9D File Offset: 0x00002C9D
		private void liveUpdate_CheckedChanged(object sender, EventArgs e)
		{
			this.method_6(sender, e);
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00004A93 File Offset: 0x00002C93
		private void PatternEditor_ResizeEnd(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00002A71 File Offset: 0x00000C71
		private void PatternEditor_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00004AA9 File Offset: 0x00002CA9
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000467 RID: 1127
		private PatternResKey patternResKey_0;

		// Token: 0x04000468 RID: 1128
		private XmlElement xmlElement_0;

		// Token: 0x04000469 RID: 1129
		private Preset preset_0;

		// Token: 0x0400046A RID: 1130
		private DDS dds_0;

		// Token: 0x0400046B RID: 1131
		private Preset preset_1;

		// Token: 0x0400046C RID: 1132
		private PatternResKey patternResKey_1;

		// Token: 0x0400046D RID: 1133
		private XmlElement xmlElement_1;

		// Token: 0x0400046E RID: 1134
		private Delegate13 delegate13_0;

		// Token: 0x0400046F RID: 1135
		private ResKey resKey_0;

		// Token: 0x04000470 RID: 1136
		private Device device_0;

		// Token: 0x04000471 RID: 1137
		private Texture texture_0;

		// Token: 0x04000472 RID: 1138
		private Interface3 interface3_0;

		// Token: 0x04000487 RID: 1159
		[CompilerGenerated]
		private string string_0;
	}
}
