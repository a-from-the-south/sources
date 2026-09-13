using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns16;
using ns6;
using ns8;
using Package;
using Package.Geometry;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Package.Squish;
using Sims3WorkshopSDK;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns0
{
	// Token: 0x02000011 RID: 17
	internal sealed partial class UVMapEditor : Form
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600005A RID: 90 RVA: 0x000134C4 File Offset: 0x000116C4
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002BED File Offset: 0x00000DED
		public bool HasChanges { get; set; }

		// Token: 0x0600005C RID: 92 RVA: 0x000134DC File Offset: 0x000116DC
		public UVMapEditor(MLOD.MLODEntry mlodEntry, VertexFormatEntry entry)
		{
			this.mlodEntry = mlodEntry;
			this.entry = entry;
			this.InitializeComponent();
			this.int_3 = this.pictureBox1.Width;
			this.int_4 = this.pictureBox1.Height;
			List<object> list = new List<object>();
			this.method_3(mlodEntry.Parent.Parent, mlodEntry, list);
			this.comboBox1.Items.AddRange(list.ToArray());
			this.comboBox1.SelectedIndexChanged += this.comboBox1_SelectedIndexChanged;
			this.method_1(this.int_0, this.int_1);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00013580 File Offset: 0x00011780
		private void method_0(object object_0, out int int_5, out int int_6)
		{
			Image image = null;
			int_5 = this.int_0;
			int_6 = this.int_1;
			if (object_0 is TXTC)
			{
				TXTC txtc = object_0 as TXTC;
				Texture texture = Class132.smethod_0().method_4(new Size(int_5, int_6));
				Interface3 @interface = Class132.smethod_0().method_8(new Size(int_5, int_6));
				XmlDocument xmlDocument_ = txtc.ToPreset();
				Class132.smethod_0().method_15(@interface, xmlDocument_, "DiffuseMap", "", texture);
				@interface.imethod_2(true);
				DataStream dataStream = BaseTexture.ToStream(texture, ImageFileFormat.Png);
				Image image2 = Image.FromStream(dataStream);
				image = image2;
				dataStream.Dispose();
			}
			if (object_0 is DDS)
			{
				Texture.FromMemory(Class140.smethod_0().Device, (object_0 as DDS).GetData());
				(object_0 as DDS).Dispose();
				DDS.MipMap mipMap = (object_0 as DDS).MipMaps[0];
				Image image3 = ImageLoader.Load(mipMap);
				image = image3;
				int_5 = image.Width;
				int_6 = image.Height;
			}
			this.image_0 = image;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0001367C File Offset: 0x0001187C
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			int int_ = 0;
			int int_2 = 0;
			this.method_0(this.comboBox1.SelectedItem, out int_, out int_2);
			this.method_1(int_, int_2);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000136AC File Offset: 0x000118AC
		private void method_1(int int_5, int int_6)
		{
			Bitmap image = new Bitmap(int_5, int_6, PixelFormat.Format32bppArgb);
			RCOL parent = this.mlodEntry.Parent.Parent;
			VRTF vrtf = parent.Entries[this.mlodEntry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] as VRTF;
			if (vrtf == null)
			{
				vrtf = VRTF.GetDefaultForLength((this.mlodEntry.Type == 20483U) ? 8 : 16);
			}
			VBUF vbuf = (VBUF)parent.Entries[this.mlodEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)];
			IBUF ibuf = (IBUF)parent.Entries[this.mlodEntry.IBUFIndex + ((parent.dataType == 2) ? 1 : 0)];
			float num = this.method_2(parent, this.mlodEntry, this.entry.Usage, this.entry.Index);
			Graphics graphics = Graphics.FromImage(image);
			if (this.image_0 != null)
			{
				graphics.DrawImage(this.image_0, 0, 0, int_5, int_6);
			}
			else
			{
				graphics.FillRectangle(Brushes.Black, 0, 0, int_5, int_6);
			}
			for (int i = 0; i < this.mlodEntry.FaceCount; i++)
			{
				Package.Geometry.Vector4 uv;
				Package.Geometry.Vector4 uv2;
				Package.Geometry.Vector4 uv3;
				checked
				{
					uv = vbuf.GetUV(vrtf, (int)ibuf.Index[(int)((IntPtr)(unchecked((long)(i * 3) + this.mlodEntry.IBUFOffset)))], this.mlodEntry.VBUFOffset, this.entry.Index);
					uv2 = vbuf.GetUV(vrtf, (int)ibuf.Index[(int)((IntPtr)(unchecked((long)(i * 3 + 1) + this.mlodEntry.IBUFOffset)))], this.mlodEntry.VBUFOffset, this.entry.Index);
					uv3 = vbuf.GetUV(vrtf, (int)ibuf.Index[(int)((IntPtr)(unchecked((long)(i * 3 + 2) + this.mlodEntry.IBUFOffset)))], this.mlodEntry.VBUFOffset, this.entry.Index);
				}
				int x = (int)(uv.X * num * (float)int_5);
				int y = (int)(uv.Y * num * (float)int_6);
				int x2 = (int)(uv2.X * num * (float)int_5);
				int y2 = (int)(uv2.Y * num * (float)int_6);
				int x3 = (int)(uv3.X * num * (float)int_5);
				int y3 = (int)(uv3.Y * num * (float)int_6);
				graphics.FillRectangle(Brushes.White, x, y, 2, 2);
				graphics.FillRectangle(Brushes.White, x2, y2, 2, 2);
				graphics.FillRectangle(Brushes.White, x3, y3, 2, 2);
				graphics.DrawLine(Pens.White, new Point(x, y), new Point(x2, y2));
				graphics.DrawLine(Pens.White, new Point(x2, y2), new Point(x3, y3));
				graphics.DrawLine(Pens.White, new Point(x3, y3), new Point(x, y));
			}
			this.pictureBox1.Location = new Point(0, 0);
			this.pictureBox1.Size = new Size(int_5, int_6);
			this.pictureBox1.Image = image;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000139C0 File Offset: 0x00011BC0
		public float method_2(RCOL rcol_0, MLOD.MLODEntry mlodentry_0, VertexEntryUsage vertexEntryUsage_0, int int_5)
		{
			float result = 3.051851E-05f;
			RCOLItem rcolitem = rcol_0.Entries[mlodentry_0.MATDIndex + ((rcol_0.dataType == 2) ? 1 : 0)];
			if (rcolitem is MATD)
			{
				MATD matd = rcolitem as MATD;
				using (List<MATD.MATDEntry>.Enumerator enumerator = matd.Entries.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MATD.MATDEntry matdentry = enumerator.Current;
						if (matdentry.Type == MATD.MATDEntryType.UVScales)
						{
							result = (float)matdentry.Values[int_5];
						}
					}
					goto IL_1D7;
				}
			}
			if (rcolitem is MTST)
			{
				MTST mtst = rcolitem as MTST;
				foreach (MTST.MTSTEntry mtstentry in mtst.Entries)
				{
					MATD matd2 = null;
					int num = mtstentry.MATDIndex + ((rcol_0.dataType == 2) ? 1 : 0);
					if ((num & 536870912) > 0)
					{
						num = (mtstentry.MATDIndex & 16777215);
						RCOLFileEntry rcolfileEntry = rcol_0.ExternalResources[num - 1];
						RCOL rcol = Class76.smethod_26(rcolfileEntry.ResKey) as RCOL;
						using (List<RCOLItem>.Enumerator enumerator3 = rcol.Entries.GetEnumerator())
						{
							while (enumerator3.MoveNext())
							{
								RCOLItem rcolitem2 = enumerator3.Current;
								if (rcolitem2 is MATD)
								{
									matd2 = (rcolitem2 as MATD);
								}
							}
							goto IL_166;
						}
						goto IL_152;
					}
					goto IL_152;
					IL_166:
					if (matd2 != null)
					{
						foreach (MATD.MATDEntry matdentry2 in matd2.Entries)
						{
							if (matdentry2.Type == MATD.MATDEntryType.UVScales)
							{
								result = (float)matdentry2.Values[int_5];
							}
						}
						continue;
					}
					continue;
					IL_152:
					matd2 = (rcol_0.Entries[num] as MATD);
					goto IL_166;
				}
			}
			IL_1D7:
			return result;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00013C10 File Offset: 0x00011E10
		public void method_3(RCOL rcol_0, MLOD.MLODEntry mlodentry_0, List<object> list_0)
		{
			List<ResKey> list = new List<ResKey>();
			List<MATD.MATDEntry> list2 = new List<MATD.MATDEntry>();
			RCOLItem rcolitem = rcol_0.Entries[mlodentry_0.MATDIndex + ((rcol_0.dataType == 2) ? 1 : 0)];
			if (rcolitem is MATD)
			{
				MATD matd = rcolitem as MATD;
				using (List<MATD.MATDEntry>.Enumerator enumerator = matd.Entries.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MATD.MATDEntry matdentry = enumerator.Current;
						if (matdentry.Type == MATD.MATDEntryType.DiffuseMap || matdentry.Type == (MATD.MATDEntryType)2907867744U || matdentry.Type == MATD.MATDEntryType.NormalMap)
						{
							list2.Add(matdentry);
						}
						if (matdentry.Type == MATD.MATDEntryType.MaskWidth)
						{
							this.int_0 = (int)matdentry.Values[0];
						}
						else if (matdentry.Type == (MATD.MATDEntryType)2224872156U)
						{
							this.int_1 = (int)matdentry.Values[0];
						}
					}
					goto IL_2A6;
				}
			}
			if (rcolitem is MTST)
			{
				MTST mtst = rcolitem as MTST;
				foreach (MTST.MTSTEntry mtstentry in mtst.Entries)
				{
					MATD matd2 = null;
					int num = mtstentry.MATDIndex + ((rcol_0.dataType == 2) ? 1 : 0);
					if ((num & 536870912) > 0)
					{
						num = (mtstentry.MATDIndex & 16777215);
						RCOLFileEntry rcolfileEntry = rcol_0.ExternalResources[num - 1];
						RCOL rcol = Class76.smethod_26(rcolfileEntry.ResKey) as RCOL;
						using (List<RCOLItem>.Enumerator enumerator3 = rcol.Entries.GetEnumerator())
						{
							while (enumerator3.MoveNext())
							{
								RCOLItem rcolitem2 = enumerator3.Current;
								if (rcolitem2 is MATD)
								{
									matd2 = (rcolitem2 as MATD);
								}
							}
							goto IL_1D2;
						}
						goto IL_1BE;
					}
					goto IL_1BE;
					IL_1D2:
					if (matd2 != null)
					{
						foreach (MATD.MATDEntry matdentry2 in matd2.Entries)
						{
							if (matdentry2.Type == MATD.MATDEntryType.DiffuseMap || matdentry2.Type == (MATD.MATDEntryType)2907867744U || matdentry2.Type == MATD.MATDEntryType.NormalMap)
							{
								list2.Add(matdentry2);
							}
							if (matdentry2.Type == MATD.MATDEntryType.MaskWidth)
							{
								this.int_0 = (int)matdentry2.Values[0];
							}
							else if (matdentry2.Type == (MATD.MATDEntryType)2224872156U)
							{
								this.int_1 = (int)matdentry2.Values[0];
							}
						}
						continue;
					}
					continue;
					IL_1BE:
					matd2 = (rcol_0.Entries[num] as MATD);
					goto IL_1D2;
				}
			}
			IL_2A6:
			foreach (MATD.MATDEntry matdentry3 in list2)
			{
				try
				{
					ResKey resKey;
					if (matdentry3.Values.Length == 4)
					{
						int num2 = matdentry3.GetIntValue()[0] & 16777215;
						resKey = rcol_0.ExternalResources[num2 - 1].ResKey;
					}
					else
					{
						int[] intValue = matdentry3.GetIntValue();
						resKey = new ResKey((DBPFType)intValue[2], intValue[3], intValue[1], intValue[0]);
					}
					DBPFEntry item = Class76.smethod_26(resKey);
					if (!list.Contains(resKey))
					{
						list_0.Add(item);
						list.Add(resKey);
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0001400C File Offset: 0x0001220C
		private void button3_Click(object sender, EventArgs e)
		{
			float scalar = this.method_2(this.mlodEntry.Parent.Parent, this.mlodEntry, this.entry.Usage, this.entry.Index);
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "WSO Files (*.wso)|*.wso";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
				FileStream fileStream = new FileStream(fileName, FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				int num = binaryReader.ReadInt32();
				if (num >= 5)
				{
					int num2 = binaryReader.ReadInt32();
					string text = "";
					for (int i = 0; i < num2; i++)
					{
						text += binaryReader.ReadChar();
					}
					int num3 = binaryReader.ReadInt32();
					if (text.Equals("milkshape") && num3 != 14 && MessageBox.Show("This WSO file was created by a incompatible version of the WSOExporter plugin for Milkshape.\n\nThere might be unexpected results if you continue. Do you want to continue?", "Incompatible plugin version", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
					{
						fileStream.Close();
						binaryReader.Close();
					}
				}
				int num4 = binaryReader.ReadInt32();
				bool flag = false;
				for (int j = 0; j < num4; j++)
				{
					int num5 = binaryReader.ReadInt32();
					new List<Vector2>();
					for (int k = 0; k < num5; k++)
					{
						binaryReader.ReadSingle();
						binaryReader.ReadSingle();
						binaryReader.ReadSingle();
						binaryReader.ReadInt32();
						if (num >= 2)
						{
							binaryReader.ReadByte();
							binaryReader.ReadByte();
							binaryReader.ReadByte();
							binaryReader.ReadByte();
						}
						binaryReader.ReadInt32();
						binaryReader.ReadInt32();
						binaryReader.ReadInt32();
						binaryReader.ReadInt32();
						binaryReader.ReadSingle();
						binaryReader.ReadSingle();
						binaryReader.ReadSingle();
						binaryReader.ReadSingle();
					}
					int num6 = binaryReader.ReadInt32();
					new List<short>();
					for (int l = 0; l < num6 * 3; l++)
					{
						short index = binaryReader.ReadInt16();
						binaryReader.ReadSingle();
						binaryReader.ReadSingle();
						binaryReader.ReadSingle();
						float x = binaryReader.ReadSingle();
						float y = binaryReader.ReadSingle();
						if (num5 == this.mlodEntry.VertexCount)
						{
							flag = true;
							RCOL parent = this.mlodEntry.Parent.Parent;
							VRTF vrtf = parent.Entries[this.mlodEntry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] as VRTF;
							if (vrtf == null)
							{
								vrtf = VRTF.GetDefaultForLength((this.mlodEntry.Type == 20483U) ? 8 : 16);
							}
							VBUF vbuf = (VBUF)parent.Entries[this.mlodEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)];
							vbuf.SetUV(vrtf, (int)index, this.mlodEntry.VBUFOffset, new Package.Geometry.Vector4(x, y, 0f, 0f), this.entry.Index, scalar);
						}
					}
					if (num >= 3)
					{
						int num7 = binaryReader.ReadInt32();
						for (int m = 0; m < num7; m++)
						{
							int num8 = binaryReader.ReadInt32();
							for (int n = 0; n < num8; n++)
							{
								binaryReader.ReadInt16();
								binaryReader.ReadSingle();
								binaryReader.ReadSingle();
								binaryReader.ReadSingle();
								binaryReader.ReadSingle();
								binaryReader.ReadSingle();
								binaryReader.ReadSingle();
								binaryReader.ReadSingle();
								binaryReader.ReadSingle();
							}
						}
					}
					string arg = "";
					if (num >= 4)
					{
						byte b = binaryReader.ReadByte();
						for (int num9 = 0; num9 < (int)b; num9++)
						{
							arg += (char)binaryReader.ReadByte();
						}
					}
				}
				if (flag)
				{
					MessageBox.Show("Imported uv-map");
					this.HasChanges = true;
				}
				else
				{
					MessageBox.Show("Did not find a mesh with matching vertexcount");
				}
				fileStream.Close();
				binaryReader.Close();
			}
			this.comboBox1_SelectedIndexChanged(null, null);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002C09 File Offset: 0x00000E09
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040000C1 RID: 193
		private MLOD.MLODEntry mlodEntry;

		// Token: 0x040000C2 RID: 194
		private VertexFormatEntry entry;

		// Token: 0x040000C3 RID: 195
		private int int_0;

		// Token: 0x040000C4 RID: 196
		private int int_1;

		// Token: 0x040000C5 RID: 197
		private Image image_0;

		// Token: 0x040000C6 RID: 198
		private int int_2;

		// Token: 0x040000C7 RID: 199
		private int int_3;

		// Token: 0x040000C8 RID: 200
		private int int_4;

		// Token: 0x040000C9 RID: 201
		private IContainer icontainer_0;

		// Token: 0x040000D3 RID: 211
		[CompilerGenerated]
		private bool bool_0;
	}
}
