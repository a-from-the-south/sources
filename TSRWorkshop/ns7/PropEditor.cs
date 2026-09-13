using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ns0;
using ns15;
using ns16;
using ns21;
using ns6;
using ns8;
using Package;
using Package.Helper;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using Skybound.VisualTips;
using SlimDX;
using SlimDX.Direct3D9;
using VisualHint.SmartPropertyGrid;

namespace ns7
{
	// Token: 0x0200005B RID: 91
	internal sealed partial class PropEditor : Form
	{
		// Token: 0x14000010 RID: 16
		// (add) Token: 0x0600037F RID: 895 RVA: 0x00040574 File Offset: 0x0003E774
		// (remove) Token: 0x06000380 RID: 896 RVA: 0x000405AC File Offset: 0x0003E7AC
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

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000381 RID: 897 RVA: 0x000405E4 File Offset: 0x0003E7E4
		// (set) Token: 0x06000382 RID: 898 RVA: 0x000405FC File Offset: 0x0003E7FC
		public PropResKey Prop
		{
			get
			{
				return this.propResKey_0;
			}
			set
			{
				this.propResKey_0 = value;
				this.propResKey_1 = (PropResKey)this.propResKey_0.Clone();
				TXTC txtc = (TXTC)Class76.smethod_26(this.propResKey_0);
				this.complatePropertyGrid.PROP = txtc;
				txtc.ToComplate("kaka", TXTC.ComplateType.Other);
				this.Preset = (this.xmlDocument_0 = txtc.ToPreset());
			}
		}

		// Token: 0x1700008A RID: 138
		// (set) Token: 0x06000383 RID: 899 RVA: 0x00003E68 File Offset: 0x00002068
		public XmlDocument Preset
		{
			set
			{
				this.xmlDocument_0 = value;
				this.method_0();
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00040668 File Offset: 0x0003E868
		private void method_0()
		{
			if (this.xmlDocument_0 != null)
			{
				this.method_2();
				DataStream dataStream = BaseTexture.ToStream(this.texture_0, ImageFileFormat.Bmp);
				this.pictureBox1.Image = Image.FromStream(dataStream);
				dataStream.Dispose();
				this.statusLabel.Text = "Preset loaded";
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x000406BC File Offset: 0x0003E8BC
		public PropEditor()
		{
			this.InitializeComponent();
			this.resKey_0 = new ResKey(DBPFType.PRESET, 0, (int)StringHelpers.FNV32("TSRW"), (int)StringHelpers.FNV32("presetSwatch"));
			this.texture_0 = Class132.smethod_0().method_4(new Size(256, 256));
			this.interface3_0 = new Class27(new Size(256, 256));
			this.complatePropertyGrid.PropertyChanged += this.complatePropertyGrid_PropertyChanged;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00003E79 File Offset: 0x00002079
		public void method_1()
		{
			this.texture_0.Dispose();
			this.interface3_0.imethod_2(true);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00003E94 File Offset: 0x00002094
		private void method_2()
		{
			this.interface3_0.imethod_0(Class132.smethod_0().Device, this.xmlDocument_0, null, "DiffuseMap", "", this.texture_0);
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00003EC5 File Offset: 0x000020C5
		private void complatePropertyGrid_PropertyChanged(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			if (this.liveUpdate.Checked)
			{
				this.method_4(new Class49());
			}
			this.method_0();
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00003EE7 File Offset: 0x000020E7
		private void doneBtn_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			this.method_4(new Class49());
			base.Close();
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0004074C File Offset: 0x0003E94C
		private void exportBtn_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "TSR Workshop Texture Preset (*.wst)|*.wst";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				DBPF dbpf = new DBPF();
				Preset preset = new Preset();
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(this.xmlDocument_0.InnerXml);
				XmlNodeList xmlNodeList = this.xmlDocument_0.SelectNodes("value");
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

		// Token: 0x0600038B RID: 907 RVA: 0x000408DC File Offset: 0x0003EADC
		private void importBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "TSR Workshop Texture Preset (*.wst)|*.wst";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				DBPF dbpf = new DBPF(openFileDialog.FileName);
				dbpf.NumEntries();
				List<ResKey> list = dbpf.SearchEntries(new ResKey(DBPFType.TXTC));
				if (list.Count != 1)
				{
					MessageBox.Show("Invalid texture file, expected to find 1 prop but found " + list.Count);
					return;
				}
				List<ResKey> list2 = dbpf.SearchEntries(new ResKey(0U, 0, 0, 0));
				foreach (ResKey key in list2)
				{
					Class132.mainForm.CurrentProject.Package.AddEntry(dbpf.GetEntry(key));
				}
				this.Prop = new PropResKey(list[0].AsString());
			}
			this.method_0();
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00003F03 File Offset: 0x00002103
		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.propResKey_0 = (PropResKey)this.propResKey_1.Clone();
			this.method_4(new Class49());
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00003F28 File Offset: 0x00002128
		private void method_3(object sender, EventArgs e)
		{
			this.method_4(new Class49());
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00003F37 File Offset: 0x00002137
		private void PropEditor_Shown(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00003F41 File Offset: 0x00002141
		private void liveUpdate_CheckedChanged(object sender, EventArgs e)
		{
			this.method_3(sender, e);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00003F37 File Offset: 0x00002137
		private void PropEditor_ResizeEnd(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00002A71 File Offset: 0x00000C71
		private void PropEditor_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000392 RID: 914 RVA: 0x000409D8 File Offset: 0x0003EBD8
		private void method_4(Class48 class48_0)
		{
			Delegate8 @delegate = this.delegate8_0;
			if (@delegate != null)
			{
				@delegate(this, class48_0);
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00002A71 File Offset: 0x00000C71
		private void removeStep_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00003F4D File Offset: 0x0000214D
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000337 RID: 823
		private PropResKey propResKey_0;

		// Token: 0x04000338 RID: 824
		private XmlDocument xmlDocument_0;

		// Token: 0x04000339 RID: 825
		private PropResKey propResKey_1;

		// Token: 0x0400033A RID: 826
		private Delegate8 delegate8_0;

		// Token: 0x0400033B RID: 827
		private ResKey resKey_0;

		// Token: 0x0400033C RID: 828
		private Texture texture_0;

		// Token: 0x0400033D RID: 829
		private Interface3 interface3_0;
	}
}
