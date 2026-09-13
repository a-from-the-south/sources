using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ns14;
using ns17;
using ns4;
using ns8;
using Package.Helper;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using VisualHint.SmartPropertyGrid;

namespace ns6
{
	// Token: 0x020000D9 RID: 217
	internal sealed partial class MaterialEditor : Form
	{
		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060008F3 RID: 2291 RVA: 0x0007C8DC File Offset: 0x0007AADC
		// (remove) Token: 0x060008F4 RID: 2292 RVA: 0x0007C914 File Offset: 0x0007AB14
		public event MaterialEditor.Delegate25 PropChanged
		{
			add
			{
				MaterialEditor.Delegate25 @delegate = this.delegate25_0;
				MaterialEditor.Delegate25 delegate2;
				do
				{
					delegate2 = @delegate;
					MaterialEditor.Delegate25 value2 = (MaterialEditor.Delegate25)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<MaterialEditor.Delegate25>(ref this.delegate25_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				MaterialEditor.Delegate25 @delegate = this.delegate25_0;
				MaterialEditor.Delegate25 delegate2;
				do
				{
					delegate2 = @delegate;
					MaterialEditor.Delegate25 value2 = (MaterialEditor.Delegate25)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<MaterialEditor.Delegate25>(ref this.delegate25_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x0007C94C File Offset: 0x0007AB4C
		// (set) Token: 0x060008F6 RID: 2294 RVA: 0x000060E3 File Offset: 0x000042E3
		public bool ShaderEnabled
		{
			get
			{
				return this.shader.Enabled;
			}
			set
			{
				this.shader.Enabled = value;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x0007C968 File Offset: 0x0007AB68
		// (set) Token: 0x060008F8 RID: 2296 RVA: 0x000060F3 File Offset: 0x000042F3
		public bool IsDirty
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

		// Token: 0x060008F9 RID: 2297 RVA: 0x0007C980 File Offset: 0x0007AB80
		public MaterialEditor(object matd)
		{
			this.IsDirty = false;
			this.matd = matd;
			this.string_0 = Application.StartupPath + "\\shadermap.xml";
			if (matd is MATD.InternalMATD)
			{
				this.object_0 = (this.matd as MATD.InternalMATD).Clone();
			}
			else
			{
				this.object_0 = (this.matd as MATD).Clone();
			}
			this.InitializeComponent();
			this.addLink.Enabled = File.Exists(this.string_0);
			if (MaterialEditor.size_0.Width != 0 && MaterialEditor.size_0.Height != 0)
			{
				base.Size = MaterialEditor.size_0;
			}
			if (MaterialEditor.point_0 != Point.Empty)
			{
				base.Location = MaterialEditor.point_0;
			}
			else
			{
				base.Location = new Point(Class132.mainForm.Left + Class132.mainForm.Width / 2 - base.Size.Width / 2, Class132.mainForm.Top + Class132.mainForm.Height / 2 - base.Size.Height / 2);
			}
			string[] names = Enum.GetNames(typeof(MATD.MATDShader));
			Array.Sort<string>(names);
			if (matd is MATD)
			{
				int selectedIndex = 0;
				foreach (string text in names)
				{
					MATD.MATDShader matdshader = (MATD.MATDShader)Enum.Parse(typeof(MATD.MATDShader), text);
					this.shader.Items.Add(new MaterialEditor.Class94(StringHelpers.FromCamelCase(text), matdshader));
					if (matdshader == (matd as MATD).Shader)
					{
						selectedIndex = this.shader.Items.Count - 1;
					}
				}
				this.shader.SelectedIndex = selectedIndex;
			}
			else
			{
				this.shader.Enabled = false;
			}
			if (matd is MATD.InternalMATD)
			{
				this.nameBox.Enabled = false;
			}
			else
			{
				this.nameBox.Enabled = true;
				this.nameBox.Text = "0x" + (this.matd as MATD).NameHash.ToString("X8");
			}
			this.materialPropertyGrid.PropertyChanged += this.materialPropertyGrid_PropertyChanged;
			this.materialPropertyGrid.Matd = matd;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x000060FE File Offset: 0x000042FE
		private void materialPropertyGrid_PropertyChanged(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
		{
			this.IsDirty = true;
			if (this.delegate25_0 != null)
			{
				this.delegate25_0(sender, e);
			}
			Class132.mainForm.Render();
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x0007CBD0 File Offset: 0x0007ADD0
		private void shader_SelectedIndexChanged(object sender, EventArgs e)
		{
			MATD matd = this.matd as MATD;
			MATD.MATDShader matdshader = ((MaterialEditor.Class94)this.shader.SelectedItem).Shader;
			if (matd.Shader != matdshader)
			{
				this.IsDirty = true;
				matd.Shader = matdshader;
				this.method_0(matd, matdshader);
			}
			this.materialPropertyGrid.method_10();
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x0007CC2C File Offset: 0x0007AE2C
		private void method_0(MATD matd_0, MATD.MATDShader matdshader_0)
		{
			this.IsDirty = true;
			if (File.Exists(this.string_0))
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					FileStream fileStream = new FileStream(this.string_0, FileMode.Open);
					StreamReader streamReader = new StreamReader(fileStream);
					string xml = streamReader.ReadToEnd();
					fileStream.Dispose();
					streamReader.Dispose();
					xmlDocument.LoadXml(xml);
					XmlNode xmlNode = xmlDocument.SelectSingleNode("/shadermap/shader[@name='" + matd_0.Shader.ToString() + "']");
					if (xmlNode != null)
					{
						DialogResult dialogResult = MessageBox.Show(this, "You have selected a new shader. You want to fill the propertylist with the most common values used for this shader?", "New shader", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if (dialogResult != DialogResult.Cancel)
						{
							if (dialogResult != DialogResult.No)
							{
								MATD matd = matd_0.Clone() as MATD;
								matd.Entries.Clear();
								XmlNodeList xmlNodeList = xmlNode.SelectNodes("./property");
								foreach (object obj in xmlNodeList)
								{
									XmlElement xmlElement = (XmlElement)obj;
									string attribute = xmlElement.GetAttribute("name");
									MATD.MATDDataType matddataType = (MATD.MATDDataType)Convert.ToUInt32(xmlElement.GetAttribute("datatype"));
									int num = Convert.ToInt32(xmlElement.GetAttribute("numvalues"));
									MATD.MATDEntry matdentry = new MATD.MATDEntry();
									Array values = Enum.GetValues(typeof(MATD.MATDEntryType));
									foreach (object obj2 in values)
									{
										uint num2 = (uint)obj2;
										if (((MATD.MATDEntryType)num2).ToString().Equals(attribute))
										{
											matdentry.Type = (MATD.MATDEntryType)num2;
										}
									}
									if (matdentry.Type == (MATD.MATDEntryType)0U)
									{
										matdentry.Type = (MATD.MATDEntryType)FNV32.GetHash(attribute);
									}
									matdentry.DataType = matddataType;
									matdentry.numValues = num;
									XmlNodeList xmlNodeList2 = xmlElement.SelectNodes("./values/value");
									int num3 = -1;
									XmlElement xmlElement2 = null;
									foreach (object obj3 in xmlNodeList2)
									{
										XmlElement xmlElement3 = (XmlElement)obj3;
										int num4 = Convert.ToInt32(xmlElement3.GetAttribute("occurrences"));
										if (num4 > num3)
										{
											xmlElement2 = xmlElement3;
											num3 = num4;
										}
									}
									if (xmlElement2 != null)
									{
										string[] array = xmlElement2.InnerText.Split(new char[]
										{
											','
										});
										object[] array2 = new object[num];
										for (int i = 0; i < num; i++)
										{
											MATD.MATDDataType matddataType2 = matddataType;
											if (matddataType2 == MATD.MATDDataType.FloatType)
											{
												array2[i] = 0f;
											}
											else
											{
												array2[i] = 0;
											}
										}
										switch (matddataType)
										{
										case MATD.MATDDataType.FloatType:
											for (int j = 0; j < array.Length; j++)
											{
												array2[j] = Convert.ToSingle(array[j], CultureInfo.InvariantCulture);
											}
											break;
										case MATD.MATDDataType.IntType:
											for (int k = 0; k < array.Length; k++)
											{
												array2[k] = Convert.ToInt32(array[k]);
											}
											break;
										case (MATD.MATDDataType)3U:
											goto IL_30A;
										case MATD.MATDDataType.ReskeyType:
											for (int l = 0; l < array.Length; l++)
											{
												ResKey resKey = new ResKey(array[l]);
												bool flag = false;
												for (int m = 0; m < matd_0.Parent.ExternalResources.Count; m++)
												{
													RCOLFileEntry rcolfileEntry = matd_0.Parent.ExternalResources[m];
													if (rcolfileEntry.ResKey.Equals(resKey))
													{
														flag = true;
														array2[l] = 805306368 + m;
													}
												}
												if (!flag)
												{
													if (resKey.TypeId == 0U)
													{
														array2[l] = 0;
													}
													else
													{
														RCOLFileEntry item = new RCOLFileEntry((RCOLItemType)resKey.TypeId, resKey.InstanceId, resKey.SecondInstanceId, resKey.GroupId);
														array2[l] = 805306368 + matd_0.Parent.ExternalResources.Count;
														matd_0.Parent.ExternalResources.Add(item);
													}
												}
											}
											break;
										default:
											goto IL_30A;
										}
										try
										{
											IL_426:
											matdentry.Values = array2;
										}
										catch (Exception)
										{
											continue;
										}
										matd.Entries.Add(matdentry);
										continue;
										IL_30A:
										for (int n = 0; n < array.Length; n++)
										{
											array2[n] = Convert.ToInt32(array[n]);
										}
										goto IL_426;
									}
								}
								foreach (MATD.MATDEntry matdentry2 in matd.Entries)
								{
								}
								MemoryStream memoryStream = new MemoryStream();
								BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
								matd.Serialize(binaryWriter);
								memoryStream.Position = 0L;
								BinaryReader binaryReader = new BinaryReader(memoryStream);
								matd.UnSerialize(binaryReader);
								binaryReader.Close();
								binaryWriter.Close();
								memoryStream.Dispose();
								matd_0.Entries = matd.Entries;
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x0007D1DC File Offset: 0x0007B3DC
		private void doneBtn_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			if (this.nameBox.Enabled)
			{
				try
				{
					uint num = Convert.ToUInt32(this.nameBox.Text, 16);
					if (num != (this.matd as MATD).NameHash)
					{
						this.IsDirty = true;
					}
					(this.matd as MATD).NameHash = num;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
			}
			base.Close();
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x0007D264 File Offset: 0x0007B464
		private void cancelBtn_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			if (this.matd is MATD)
			{
				(this.object_0 as MATD).CopyTo(this.matd as MATD);
			}
			else
			{
				(this.object_0 as MATD.InternalMATD).CopyTo(this.matd as MATD.InternalMATD);
			}
			base.Close();
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00006128 File Offset: 0x00004328
		private void MaterialEditor_LocationChanged(object sender, EventArgs e)
		{
			MaterialEditor.point_0 = base.Location;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00006137 File Offset: 0x00004337
		private void MaterialEditor_SizeChanged(object sender, EventArgs e)
		{
			MaterialEditor.size_0 = base.Size;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x0007D2C8 File Offset: 0x0007B4C8
		private void addLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			XmlDocument xmlDocument = new XmlDocument();
			FileStream fileStream = new FileStream(this.string_0, FileMode.Open);
			StreamReader streamReader = new StreamReader(fileStream);
			string xml = streamReader.ReadToEnd();
			fileStream.Dispose();
			streamReader.Dispose();
			xmlDocument.LoadXml(xml);
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/shadermap/shader/property");
			Dictionary<string, object[]> dictionary = new Dictionary<string, object[]>();
			List<XmlElement> list = new List<XmlElement>();
			foreach (object obj in xmlNodeList)
			{
				XmlElement item = (XmlElement)obj;
				list.Add(item);
			}
			List<XmlElement> list2 = list;
			if (MaterialEditor.comparison_0 == null)
			{
				MaterialEditor.comparison_0 = new Comparison<XmlElement>(MaterialEditor.smethod_0);
			}
			list2.Sort(MaterialEditor.comparison_0);
			foreach (XmlElement xmlElement in list)
			{
				string attribute = xmlElement.GetAttribute("name");
				int num = Convert.ToInt32(xmlElement.GetAttribute("occurrences"));
				object[] array = null;
				if (!dictionary.TryGetValue(attribute, out array))
				{
					dictionary.Add(attribute, new object[]
					{
						1,
						xmlElement
					});
				}
				else if (num > (int)array[0])
				{
					array[0] = num;
					array[1] = xmlElement;
					dictionary[attribute] = array;
				}
			}
			List<string> list3 = new List<string>();
			foreach (string text in dictionary.Keys)
			{
				List<MATD.MATDEntry> list4 = new List<MATD.MATDEntry>();
				if (this.matd is MATD)
				{
					list4.AddRange((this.matd as MATD).Entries);
				}
				else if (this.matd is MATD.InternalMATD)
				{
					list4.AddRange((this.matd as MATD.InternalMATD).Entries);
				}
				foreach (MATD.MATDEntry matdentry in list4)
				{
					if (matdentry.Type.ToString().Equals(text))
					{
						list3.Add(text);
					}
				}
			}
			foreach (string key in list3)
			{
				dictionary.Remove(key);
			}
			MATDEntrySelector matdentrySelector = new MATDEntrySelector(dictionary);
			if (matdentrySelector.ShowDialog(this) == DialogResult.OK)
			{
				if (matdentrySelector.DropdownList.SelectedIndex != -1)
				{
					this.IsDirty = true;
					string text2 = matdentrySelector.DropdownList.Items[matdentrySelector.DropdownList.SelectedIndex].ToString();
					object[] array2 = dictionary[text2];
					XmlElement xmlElement2 = array2[1] as XmlElement;
					MATD.MATDEntry matdentry2 = new MATD.MATDEntry();
					Array values = Enum.GetValues(typeof(MATD.MATDEntryType));
					foreach (object obj2 in values)
					{
						uint num2 = (uint)obj2;
						if (((MATD.MATDEntryType)num2).ToString().Equals(text2))
						{
							matdentry2.Type = (MATD.MATDEntryType)num2;
						}
					}
					if (matdentry2.Type == (MATD.MATDEntryType)0U)
					{
						matdentry2.Type = (MATD.MATDEntryType)Convert.ToUInt32(text2);
					}
					MATD.MATDDataType matddataType = matdentry2.DataType = (MATD.MATDDataType)Convert.ToUInt32(xmlElement2.GetAttribute("datatype"));
					int num3 = matdentry2.numValues = Convert.ToInt32(xmlElement2.GetAttribute("numvalues"));
					XmlNodeList xmlNodeList2 = xmlElement2.SelectNodes("./values/value");
					int num4 = -1;
					XmlElement xmlElement3 = null;
					foreach (object obj3 in xmlNodeList2)
					{
						XmlElement xmlElement4 = (XmlElement)obj3;
						int num5 = Convert.ToInt32(xmlElement4.GetAttribute("occurrences"));
						if (num5 > num4)
						{
							xmlElement3 = xmlElement4;
							num4 = num5;
						}
					}
					if (xmlElement3 != null)
					{
						string[] array3 = xmlElement3.InnerText.Split(new char[]
						{
							','
						});
						object[] array4 = new object[num3];
						for (int i = 0; i < num3; i++)
						{
							MATD.MATDDataType matddataType2 = matddataType;
							if (matddataType2 == MATD.MATDDataType.FloatType)
							{
								array4[i] = 0f;
							}
							else
							{
								array4[i] = 0;
							}
						}
						switch (matddataType)
						{
						case MATD.MATDDataType.FloatType:
							for (int j = 0; j < array3.Length; j++)
							{
								array4[j] = Convert.ToSingle(array3[j], CultureInfo.InvariantCulture);
							}
							goto IL_64A;
						case MATD.MATDDataType.IntType:
							for (int k = 0; k < array3.Length; k++)
							{
								array4[k] = Convert.ToInt32(array3[k]);
							}
							goto IL_64A;
						case MATD.MATDDataType.ReskeyType:
							for (int l = 0; l < array3.Length; l++)
							{
								ResKey resKey = new ResKey(array3[l]);
								bool flag = false;
								RCOL rcol = (this.matd is MATD.InternalMATD) ? (this.matd as MATD.InternalMATD).Parent.Parent : (this.matd as MATD).Parent;
								for (int m = 0; m < rcol.ExternalResources.Count; m++)
								{
									RCOLFileEntry rcolfileEntry = rcol.ExternalResources[m];
									if (rcolfileEntry.ResKey.Equals(resKey))
									{
										flag = true;
										array4[l] = 805306368 + m;
									}
								}
								if (!flag)
								{
									if (resKey.TypeId == 0U)
									{
										array4[l] = 0;
									}
									else
									{
										RCOLFileEntry item2 = new RCOLFileEntry((RCOLItemType)resKey.TypeId, resKey.InstanceId, resKey.SecondInstanceId, resKey.GroupId);
										array4[l] = 805306368 + rcol.ExternalResources.Count;
										rcol.ExternalResources.Add(item2);
									}
								}
							}
							goto IL_64A;
						}
						for (int n = 0; n < array3.Length; n++)
						{
							array4[n] = Convert.ToInt32(array3[n]);
						}
						IL_64A:
						matdentry2.Values = array4;
						if (this.matd is MATD)
						{
							(this.matd as MATD).Entries.Add(matdentry2);
						}
						else if (this.matd is MATD.InternalMATD)
						{
							(this.matd as MATD.InternalMATD).Entries.Add(matdentry2);
						}
					}
					MemoryStream memoryStream = new MemoryStream();
					BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
					if (this.matd is MATD)
					{
						(this.matd as MATD).Serialize(binaryWriter);
					}
					else if (this.matd is MATD.InternalMATD)
					{
						(this.matd as MATD.InternalMATD).Serialize(binaryWriter);
					}
					memoryStream.Position = 0L;
					BinaryReader binaryReader = new BinaryReader(memoryStream);
					if (this.matd is MATD)
					{
						(this.matd as MATD).UnSerialize(binaryReader);
					}
					else if (this.matd is MATD.InternalMATD)
					{
						(this.matd as MATD.InternalMATD).Unserialize(binaryReader);
					}
					binaryReader.Close();
					binaryWriter.Close();
					memoryStream.Dispose();
					this.materialPropertyGrid.method_10();
				}
			}
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00006146 File Offset: 0x00004346
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x0007E558 File Offset: 0x0007C758
		[CompilerGenerated]
		private static int smethod_0(XmlElement xmlElement_0, XmlElement xmlElement_1)
		{
			return xmlElement_0.GetAttribute("name").CompareTo(xmlElement_1.GetAttribute("name"));
		}

		// Token: 0x04000724 RID: 1828
		private object matd;

		// Token: 0x04000725 RID: 1829
		private object object_0;

		// Token: 0x04000726 RID: 1830
		private static Point point_0;

		// Token: 0x04000727 RID: 1831
		private static Size size_0;

		// Token: 0x04000728 RID: 1832
		private MaterialEditor.Delegate25 delegate25_0;

		// Token: 0x04000729 RID: 1833
		private string string_0;

		// Token: 0x0400072A RID: 1834
		private bool bool_0;

		// Token: 0x0400072B RID: 1835
		private IContainer icontainer_0;

		// Token: 0x0400073B RID: 1851
		[CompilerGenerated]
		private static Comparison<XmlElement> comparison_0;

		// Token: 0x020000DA RID: 218
		private sealed class Class94
		{
			// Token: 0x17000179 RID: 377
			// (get) Token: 0x06000905 RID: 2309 RVA: 0x0007E584 File Offset: 0x0007C784
			// (set) Token: 0x06000906 RID: 2310 RVA: 0x00006167 File Offset: 0x00004367
			public string Label { get; set; }

			// Token: 0x1700017A RID: 378
			// (get) Token: 0x06000907 RID: 2311 RVA: 0x0007E59C File Offset: 0x0007C79C
			// (set) Token: 0x06000908 RID: 2312 RVA: 0x00006172 File Offset: 0x00004372
			public MATD.MATDShader Shader { get; set; }

			// Token: 0x06000909 RID: 2313 RVA: 0x0000617D File Offset: 0x0000437D
			public Class94(string label, MATD.MATDShader shader)
			{
				this.Label = label;
				this.Shader = shader;
			}

			// Token: 0x0600090A RID: 2314 RVA: 0x0007E5B4 File Offset: 0x0007C7B4
			public string ToString()
			{
				return this.Label;
			}

			// Token: 0x0600090B RID: 2315 RVA: 0x0007E5CC File Offset: 0x0007C7CC
			public bool Equals(object obj)
			{
				bool result;
				if (!(obj is MATD.MATDShader))
				{
					result = false;
				}
				else
				{
					result = ((MATD.MATDShader)obj == this.Shader);
				}
				return result;
			}

			// Token: 0x0600090C RID: 2316 RVA: 0x00037C14 File Offset: 0x00035E14
			public int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x0400073C RID: 1852
			[CompilerGenerated]
			private string string_0;

			// Token: 0x0400073D RID: 1853
			[CompilerGenerated]
			private MATD.MATDShader matdshader_0;
		}

		// Token: 0x020000DB RID: 219
		// (Invoke) Token: 0x0600090E RID: 2318
		public delegate void Delegate25(object sender, VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e);
	}
}
