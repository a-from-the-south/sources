using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns16;
using ns8;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using SlimDX.Direct3D9;

namespace ns13
{
	// Token: 0x020000CC RID: 204
	internal sealed partial class ComplateToImageForm : Form
	{
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x000797F4 File Offset: 0x000779F4
		// (set) Token: 0x06000894 RID: 2196 RVA: 0x00005DF9 File Offset: 0x00003FF9
		public bool Completed { get; set; }

		// Token: 0x06000895 RID: 2197 RVA: 0x0007980C File Offset: 0x00077A0C
		public ComplateToImageForm(XmlDocument preset, Size size)
		{
			this.preset = preset;
			this.size = size;
			XmlElement xmlElement = this.preset.SelectSingleNode("/preset/complate") as XmlElement;
			ResKey resKey_ = new ResKey(xmlElement.GetAttribute("reskey"));
			XML xml = Class76.smethod_26(resKey_) as XML;
			XmlDocument xmlDocument = xml.Documents[0];
			XmlElement xmlElement2 = this.preset.SelectSingleNode("/preset/complate/value[@key='partType']") as XmlElement;
			this.string_0 = xmlElement2.GetAttribute("value");
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/complate/texturePart/destination");
			if (xmlNodeList.Count > 1)
			{
				this.bool_0 = true;
				this.InitializeComponent();
				foreach (object obj in xmlNodeList)
				{
					XmlElement xmlElement3 = (XmlElement)obj;
					this.comboBox.Items.Add(xmlElement3.GetAttribute("textureName"));
				}
				this.comboBox.SelectedIndex = 0;
			}
			else
			{
				this.string_1 = (xmlNodeList[0] as XmlElement).GetAttribute("textureName");
				this.okButton_Click(null, null);
			}
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00002B20 File Offset: 0x00000D20
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x00079958 File Offset: 0x00077B58
		private void okButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "DDS (*.dds)|*.dds|PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp|JPG (*.jpg)|*.jpg";
			saveFileDialog.FilterIndex = ComplateToImageForm.int_0;
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string fileName = saveFileDialog.FileName;
				ComplateToImageForm.int_0 = saveFileDialog.FilterIndex;
				ImageFileFormat imageFileFormat_ = ImageFileFormat.Bmp;
				if (fileName.Contains(".dds"))
				{
					imageFileFormat_ = ImageFileFormat.Dds;
				}
				else if (fileName.Contains(".png"))
				{
					imageFileFormat_ = ImageFileFormat.Png;
				}
				else if (fileName.Contains(".jpg"))
				{
					imageFileFormat_ = ImageFileFormat.Jpg;
				}
				Class132.smethod_0().method_11(fileName, imageFileFormat_, this.preset, this.size, this.string_1, this.string_0);
			}
			this.Completed = true;
			MessageBox.Show(this, "Export complete!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			if (this.bool_0)
			{
				base.Close();
			}
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00005E04 File Offset: 0x00004004
		private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.string_1 = (this.comboBox.SelectedItem as string);
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00005E1E File Offset: 0x0000401E
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040006DA RID: 1754
		private XmlDocument preset;

		// Token: 0x040006DB RID: 1755
		private string string_0;

		// Token: 0x040006DC RID: 1756
		private string string_1;

		// Token: 0x040006DD RID: 1757
		private Size size;

		// Token: 0x040006DE RID: 1758
		private bool bool_0;

		// Token: 0x040006DF RID: 1759
		private static int int_0;

		// Token: 0x040006E0 RID: 1760
		private IContainer icontainer_0;

		// Token: 0x040006E5 RID: 1765
		[CompilerGenerated]
		private bool bool_1;
	}
}
