using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns14;
using ns16;
using ns3;
using ns7;
using ns8;
using Package;
using Package.Helper;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;
using SlimDX;
using VisualHint.SmartPropertyGrid;

namespace ns4
{
	// Token: 0x0200006A RID: 106
	internal sealed class Class6 : Class2
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x000470F8 File Offset: 0x000452F8
		// (set) Token: 0x06000415 RID: 1045 RVA: 0x000043D1 File Offset: 0x000025D1
		public RCOL ParentRCOL { get; set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x00047110 File Offset: 0x00045310
		// (set) Token: 0x06000417 RID: 1047 RVA: 0x000043DC File Offset: 0x000025DC
		public object Matd
		{
			get
			{
				return this.object_0;
			}
			set
			{
				this.object_0 = value;
				this.method_10();
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00047128 File Offset: 0x00045328
		public Class6()
		{
			this.ContextMenu = new ContextMenu();
			this.ContextMenu.Popup += this.method_9;
			this.menuItem_0 = new MenuItem("Remove");
			this.menuItem_1 = new MenuItem("Browse");
			this.ContextMenu.MenuItems.Add(this.menuItem_1);
			this.ContextMenu.MenuItems.Add(new MenuItem("-"));
			this.ContextMenu.MenuItems.Add(this.menuItem_0);
			this.menuItem_0.Click += this.menuItem_0_Click;
			this.menuItem_1.Click += this.menuItem_1_Click;
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000471F8 File Offset: 0x000453F8
		private void menuItem_1_Click(object sender, EventArgs e)
		{
			ProjectContentsBrowser projectContentsBrowser = new ProjectContentsBrowser(Class132.mainForm.CurrentProject.Package);
			projectContentsBrowser.TypeFilter = new List<DBPFType>
			{
				DBPFType.DDS,
				DBPFType.TXTC
			};
			if (projectContentsBrowser.ShowDialog(this) == DialogResult.OK && projectContentsBrowser.SelectedItems.Count > 0)
			{
				ResKey resKey_ = projectContentsBrowser.SelectedItems[0];
				DBPFEntry dbpfentry = Class76.smethod_26(resKey_);
				PropertyVisibleDeepEnumerator selectedPropertyEnumerator = base.SelectedPropertyEnumerator;
				object tag = selectedPropertyEnumerator.Property.Value.Tag;
				if (dbpfentry is DDS)
				{
					if (tag is RCOLFileEntry)
					{
						(tag as RCOLFileEntry).ResKey = new ResKey(dbpfentry.GenerateResKey());
					}
					else if (tag is TGIIndex)
					{
						(tag as TGIIndex).SetFromResKey(dbpfentry.ResKey);
					}
				}
				else if (dbpfentry is TXTC)
				{
					if (tag is RCOLFileEntry)
					{
						(tag as RCOLFileEntry).ResKey = new ResKey(dbpfentry.GenerateResKey());
					}
					else if (tag is TGIIndex)
					{
						(tag as TGIIndex).SetFromResKey(dbpfentry.ResKey);
					}
				}
				this.method_10();
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00047320 File Offset: 0x00045520
		private void menuItem_0_Click(object sender, EventArgs e)
		{
			PropertyVisibleDeepEnumerator selectedPropertyEnumerator = base.SelectedPropertyEnumerator;
			if (selectedPropertyEnumerator != null)
			{
				MATD.MATDEntry matdentry = selectedPropertyEnumerator.Property.Tag as MATD.MATDEntry;
				if (matdentry != null)
				{
					if (this.object_0 is MATD)
					{
						(this.object_0 as MATD).Entries.Remove(matdentry);
					}
					else
					{
						(this.object_0 as MATD.InternalMATD).Entries.Remove(matdentry);
					}
				}
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				if (this.object_0 is MATD)
				{
					(this.object_0 as MATD).Serialize(binaryWriter);
				}
				else if (this.object_0 is MATD.InternalMATD)
				{
					(this.object_0 as MATD.InternalMATD).Serialize(binaryWriter);
				}
				memoryStream.Position = 0L;
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				if (this.object_0 is MATD)
				{
					(this.object_0 as MATD).UnSerialize(binaryReader);
				}
				else if (this.object_0 is MATD.InternalMATD)
				{
					(this.object_0 as MATD.InternalMATD).Unserialize(binaryReader);
				}
				binaryReader.Close();
				binaryWriter.Close();
				memoryStream.Dispose();
				this.method_10();
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00047450 File Offset: 0x00045650
		private void method_9(object sender, EventArgs e)
		{
			MenuItem menuItem = this.menuItem_1;
			this.menuItem_0.Enabled = false;
			menuItem.Enabled = false;
			PropertyVisibleDeepEnumerator selectedPropertyEnumerator = base.SelectedPropertyEnumerator;
			if (selectedPropertyEnumerator != null)
			{
				MATD.MATDEntry matdentry = selectedPropertyEnumerator.Property.Tag as MATD.MATDEntry;
				object tag = selectedPropertyEnumerator.Property.Value.Tag;
				if (matdentry != null && matdentry.DataType == MATD.MATDDataType.IntType)
				{
					this.menuItem_1.Enabled = true;
				}
				if (matdentry != null)
				{
					this.menuItem_0.Enabled = true;
				}
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x000474D4 File Offset: 0x000456D4
		public void method_10()
		{
			if (this.object_0 != null)
			{
				base.Clear();
				int id = 0;
				int num = 1;
				PropertyEnumerator underCategory = base.AppendRootCategory(id, "Parameters");
				List<MATD.MATDEntry> list = new List<MATD.MATDEntry>();
				if (this.object_0 is MATD)
				{
					list.AddRange((this.object_0 as MATD).Entries.ToArray());
				}
				else if (this.object_0 is MATD.InternalMATD)
				{
					list.AddRange((this.object_0 as MATD.InternalMATD).Entries.ToArray());
				}
				List<MATD.MATDEntry> list2 = list;
				if (Class6.comparison_0 == null)
				{
					Class6.comparison_0 = new Comparison<MATD.MATDEntry>(Class6.smethod_0);
				}
				list2.Sort(Class6.comparison_0);
				foreach (MATD.MATDEntry matdentry in list)
				{
					string propName = StringHelpers.FromCamelCase(matdentry.Type.ToString());
					PropertyEnumerator propertyEnumerator = null;
					switch (matdentry.DataType)
					{
					case MATD.MATDDataType.FloatType:
					{
						float[] floatValue = matdentry.GetFloatValue();
						MATD.MATDEntryType type = matdentry.Type;
						if (type == MATD.MATDEntryType.Ambient || type == MATD.MATDEntryType.Specular || type == MATD.MATDEntryType.Diffuse)
						{
							int argb = 0;
							if (matdentry.numValues == 4)
							{
								argb = ((int)(floatValue[3] * 255f) << 24) + ((int)(floatValue[0] * 255f) << 16) + (((int)(floatValue[1] * 255f) << 8) + (int)(floatValue[2] * 255f));
							}
							else if (matdentry.numValues == 3)
							{
								argb = -16777216 + ((int)(floatValue[0] * 255f) << 16) + (((int)(floatValue[1] * 255f) << 8) + (int)(floatValue[2] * 255f));
							}
							propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(Color), Color.FromArgb(argb), "");
							propertyEnumerator.Property.Value.SetAttribute(new PropertyDropDownContentAttribute(typeof(AlphaColorPicker), new object[]
							{
								matdentry.numValues == 4
							}));
							propertyEnumerator.Property.Feel = base.GetRegisteredFeel("list");
							propertyEnumerator.Property.Value.Look = new PropertyColorLook();
						}
						if (propertyEnumerator == null)
						{
							switch (matdentry.numValues)
							{
							case 1:
								propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(float), floatValue[0], "");
								break;
							case 2:
								propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(Vector2), new Vector2(floatValue[0], floatValue[1]), "");
								break;
							case 3:
								propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(Vector3), new Vector3(floatValue[0], floatValue[1], floatValue[2]), "");
								break;
							default:
								propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(float[]), floatValue, "");
								break;
							}
						}
						break;
					}
					case MATD.MATDDataType.IntType:
					{
						int[] intValue = matdentry.GetIntValue();
						switch (matdentry.numValues)
						{
						case 1:
							propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(int), intValue[0], "");
							break;
						case 2:
							propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(Point), new Point(intValue[0], intValue[1]), "");
							break;
						default:
							propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(int[]), intValue, "");
							break;
						}
						break;
					}
					case MATD.MATDDataType.ReskeyType:
					{
						byte[] byteValue = matdentry.GetByteValue();
						int numValues = matdentry.numValues;
						if (numValues == 1)
						{
							propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(byte), byteValue[0], "");
						}
						else
						{
							ResKey resKey = null;
							object obj = null;
							if (matdentry.Values.Length == 4)
							{
								int num2 = (matdentry.GetIntValue()[0] & 16777215) - 1;
								if (this.object_0 is MATD)
								{
									obj = (this.object_0 as MATD).Parent.ExternalResources[num2];
								}
								else if (this.object_0 is MATD.InternalMATD)
								{
									obj = (this.object_0 as MATD.InternalMATD).Parent.tgiIndex[num2 + 1];
								}
								resKey = ((obj is TGIIndex) ? new ResKey((obj as TGIIndex).Reskey) : (obj as RCOLFileEntry).ResKey);
							}
							else if (matdentry.Values.Length == 5)
							{
								int[] intValue2 = matdentry.GetIntValue();
								resKey = new ResKey((DBPFType)intValue2[2], intValue2[3], intValue2[1], intValue2[0]);
								obj = resKey;
							}
							DBPFType typeId = (DBPFType)resKey.TypeId;
							if (typeId != DBPFType.DDS)
							{
								if (typeId == DBPFType.TXTC)
								{
									propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(PropResKey), new PropResKey(resKey.AsString()), "");
									propertyEnumerator.Property.Value.Tag = obj;
									propertyEnumerator.Property.Value.Look = new Class62();
								}
							}
							else
							{
								propertyEnumerator = base.AppendManagedProperty(underCategory, num++, propName, typeof(TextureResKey), new TextureResKey(resKey.AsString()), "");
								propertyEnumerator.Property.Value.Tag = obj;
								propertyEnumerator.Property.Value.Look = new Class61();
								(propertyEnumerator.Property.Value.Look as Class61).PropertyChanged += this.method_11;
							}
						}
						break;
					}
					}
					if (propertyEnumerator != null)
					{
						propertyEnumerator.Property.Tag = matdentry;
					}
				}
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00003E32 File Offset: 0x00002032
		private void method_11(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
		{
			propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.SetValue(resKey_0);
			(propertyButtonClickedEventArgs_0.PropertyEnum.Property.Look as Class61).NeedsUpdate = true;
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00047B0C File Offset: 0x00045D0C
		protected override void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			MATD.MATDEntry matdentry = e.PropertyEnum.Property.Tag as MATD.MATDEntry;
			PropertyValue value = e.PropertyEnum.Property.Value;
			if (matdentry == null)
			{
				matdentry = (e.PropertyEnum.Parent.Property.Tag as MATD.MATDEntry);
				value = e.PropertyEnum.Parent.Property.Value;
			}
			object[] array = new object[matdentry.numValues];
			bool flag = true;
			switch (matdentry.DataType)
			{
			case MATD.MATDDataType.FloatType:
				switch (matdentry.numValues)
				{
				case 1:
					array[0] = (float)value.GetValue(0);
					break;
				case 2:
					array[0] = ((Vector2)value.GetValue(0)).X;
					array[1] = ((Vector2)value.GetValue(0)).Y;
					break;
				case 3:
					if (value.GetValue(0).GetType() == typeof(Color))
					{
						array[0] = (float)((Color)value.GetValue(0)).R / 255f;
						array[1] = (float)((Color)value.GetValue(0)).G / 255f;
						array[2] = (float)((Color)value.GetValue(0)).B / 255f;
					}
					else
					{
						array[0] = ((Vector3)value.GetValue(0)).X;
						array[1] = ((Vector3)value.GetValue(0)).Y;
						array[2] = ((Vector3)value.GetValue(0)).Z;
					}
					break;
				case 4:
					if (value.GetValue(0).GetType() == typeof(Color))
					{
						array[0] = (float)((Color)value.GetValue(0)).R / 255f;
						array[1] = (float)((Color)value.GetValue(0)).G / 255f;
						array[2] = (float)((Color)value.GetValue(0)).B / 255f;
						array[3] = (float)((Color)value.GetValue(0)).A / 255f;
					}
					else
					{
						array[0] = ((float[])value.GetValue(0))[0];
						array[1] = ((float[])value.GetValue(0))[1];
						array[2] = ((float[])value.GetValue(0))[2];
						array[3] = ((float[])value.GetValue(0))[3];
					}
					break;
				}
				break;
			case MATD.MATDDataType.IntType:
				switch (matdentry.numValues)
				{
				case 1:
					array[0] = (int)value.GetValue(0);
					break;
				case 2:
					array[0] = ((Point)value.GetValue(0)).X;
					array[1] = ((Point)value.GetValue(0)).Y;
					break;
				default:
					for (int i = 0; i < matdentry.numValues; i++)
					{
						array[i] = ((object[])value.GetValue(0))[i];
					}
					break;
				}
				break;
			case MATD.MATDDataType.ReskeyType:
			{
				int numValues = matdentry.numValues;
				if (numValues != 1)
				{
					if (numValues != 5)
					{
						int num = (matdentry.GetIntValue()[0] & 16777215) - 1;
						object obj = null;
						if (this.object_0 is MATD)
						{
							obj = (this.object_0 as MATD).Parent.ExternalResources[num];
						}
						else if (this.object_0 is MATD.InternalMATD)
						{
							obj = (this.object_0 as MATD.InternalMATD).Parent.tgiIndex[num + 1];
						}
						ResKey resKey = (obj is TGIIndex) ? new ResKey((obj as TGIIndex).Reskey) : (obj as RCOLFileEntry).ResKey;
						DBPFType typeId = (DBPFType)resKey.TypeId;
						if (typeId != DBPFType.DDS)
						{
							if (typeId == DBPFType.TXTC)
							{
								flag = false;
							}
							else
							{
								for (int i = 0; i < matdentry.numValues; i++)
								{
									array[i] = ((int[])value.GetValue(0))[i];
								}
							}
						}
						else
						{
							if (obj is RCOLFileEntry)
							{
								(obj as RCOLFileEntry).ResKey = (TextureResKey)value.GetValue();
							}
							else
							{
								(obj as TGIIndex).Reskey = ((TextureResKey)value.GetValue()).AsString();
							}
							flag = false;
						}
					}
					else
					{
						object value2 = value.GetValue();
						if (value2 is ResKey)
						{
							ResKey resKey2 = value2 as ResKey;
							array = new object[]
							{
								resKey2.SecondInstanceId,
								resKey2.InstanceId,
								(int)resKey2.TypeId,
								resKey2.GroupId,
								0
							};
						}
					}
				}
				else
				{
					array[0] = (byte)value.GetValue(0);
				}
				break;
			}
			}
			if (flag)
			{
				matdentry.Values = array;
			}
			base.OnPropertyChanged(e);
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00048080 File Offset: 0x00046280
		[CompilerGenerated]
		private static int smethod_0(MATD.MATDEntry matdentry_0, MATD.MATDEntry matdentry_1)
		{
			return StringHelpers.FromCamelCase(matdentry_0.Type.ToString()).CompareTo(StringHelpers.FromCamelCase(matdentry_1.Type.ToString()));
		}

		// Token: 0x040003F6 RID: 1014
		private object object_0;

		// Token: 0x040003F7 RID: 1015
		private MenuItem menuItem_0;

		// Token: 0x040003F8 RID: 1016
		private MenuItem menuItem_1;

		// Token: 0x040003F9 RID: 1017
		[CompilerGenerated]
		private RCOL rcol_0;

		// Token: 0x040003FA RID: 1018
		[CompilerGenerated]
		private static Comparison<MATD.MATDEntry> comparison_0;
	}
}
