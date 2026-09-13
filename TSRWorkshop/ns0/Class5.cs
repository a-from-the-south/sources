using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns8;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using VisualHint.SmartPropertyGrid;

namespace ns0
{
	// Token: 0x0200005A RID: 90
	internal sealed class Class5 : Class2
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000377 RID: 887 RVA: 0x0003FE5C File Offset: 0x0003E05C
		// (set) Token: 0x06000378 RID: 888 RVA: 0x00003DFA File Offset: 0x00001FFA
		public Dictionary<string, PropertyEnumerator> Categories { get; private set; }

		// Token: 0x06000379 RID: 889 RVA: 0x00003E05 File Offset: 0x00002005
		public Class5()
		{
			base.PropertyChanged += this.Class5_PropertyChanged;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0003FE74 File Offset: 0x0003E074
		private void Class5_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			object tag = e.PropertyEnum.Property.Tag;
			object tag2 = e.PropertyEnum.Property.Value.Tag;
			object value = e.PropertyEnum.Property.Value.GetValue();
			TXTC.PROPEntry propentry = tag2 as TXTC.PROPEntry;
			if (propentry != null)
			{
				if (tag != null && tag.Equals("fabc"))
				{
					propentry.TypedData = value;
				}
				else if (value.GetType() == typeof(TextureResKey))
				{
					byte index = (byte)propentry.data;
					this.txtc_0.IGTIndex[(int)index].Reskey = (value as TextureResKey).AsString();
				}
				else if (value.GetType() == typeof(int))
				{
					propentry.data = BitConverter.GetBytes((int)value);
				}
				else if (value.GetType() == typeof(Color))
				{
					propentry.data = BitConverter.GetBytes(((Color)value).ToArgb());
				}
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600037B RID: 891 RVA: 0x0003FF80 File Offset: 0x0003E180
		// (set) Token: 0x0600037C RID: 892 RVA: 0x00003E21 File Offset: 0x00002021
		public TXTC PROP
		{
			get
			{
				return this.txtc_0;
			}
			set
			{
				this.txtc_0 = value;
				this.method_9();
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0003FF98 File Offset: 0x0003E198
		public void method_9()
		{
			if (this.txtc_0 != null)
			{
				base.BeginUpdate();
				base.Clear();
				int num = 1;
				foreach (TXTC.PropertySet propertySet in this.txtc_0.PropertySets)
				{
					int num2 = 0;
					int id = 0;
					num2 = 1;
					PropertyEnumerator propertyEnumerator = base.AppendRootCategory(id, "Block " + num++);
					propertyEnumerator.Property.Tag = new object[]
					{
						propertySet,
						this.txtc_0
					};
					int num3 = 0;
					foreach (TXTC.PROPEntry propentry in propertySet.Properties)
					{
						if (propentry.guid == TXTC.EntryType.ID)
						{
							uint uintData = propentry.GetUIntData();
							propertyEnumerator.Property.DisplayName = ((TXTC.StepType)uintData).ToString();
						}
						else if (propentry.guid == (TXTC.EntryType)2954315994U)
						{
							Color color = Color.FromArgb(BitConverter.ToInt32((byte[])propentry.data, 0));
							PropertyEnumerator propertyEnumerator2 = base.AppendManagedProperty(propertyEnumerator, num2++, propentry.Guid, typeof(Color), color, "Width");
							propertyEnumerator2.Property.Value.Tag = propentry;
							propertyEnumerator2.Property.Value.SetAttribute(new PropertyDropDownContentAttribute(typeof(AlphaColorPicker), new object[]
							{
								false
							}));
							propertyEnumerator2.Property.Feel = base.GetRegisteredFeel("list");
							propertyEnumerator2.Property.Value.Look = new PropertyColorLook();
							num3++;
						}
						else if (propentry.guid == (TXTC.EntryType)4140598385U)
						{
							byte index = (byte)propentry.data;
							IGTIndex igtindex = this.txtc_0.IGTIndex[(int)index];
							TextureResKey initialValue = new TextureResKey(igtindex.Reskey);
							PropertyEnumerator propertyEnumerator3 = base.AppendManagedProperty(propertyEnumerator, num2++, propentry.Guid, typeof(TextureResKey), initialValue, "Texture");
							Class61 @class = new Class61();
							@class.PropertyChanged += this.method_10;
							propertyEnumerator3.Property.Look = @class;
							propertyEnumerator3.Property.Value.Tag = propentry;
							num3++;
						}
						else if (propentry.guid == (TXTC.EntryType)3707727227U)
						{
							byte index2 = (byte)propentry.data;
							IGTIndex igtindex2 = this.txtc_0.IGTIndex[(int)index2];
							PropertyEnumerator propertyEnumerator4 = base.AppendSubCategory(propertyEnumerator, num2++, "Pattern properties");
							foreach (TXTC.FABC fabc in this.txtc_0.SuperBlocks)
							{
								if (fabc.IGTIndex.AsString().ToLower() == igtindex2.AsString().ToLower())
								{
									foreach (TXTC.PropertySet propertySet2 in fabc.txtc.PropertySets)
									{
										PropertyEnumerator propertyEnumerator5 = base.AppendSubCategory(propertyEnumerator4, num2++, "Step");
										foreach (TXTC.PROPEntry propentry2 in propertySet2.Properties)
										{
											if (propentry2.guid != TXTC.EntryType.NULL)
											{
												if (propentry2.guid == TXTC.EntryType.ID)
												{
													uint uintData2 = propentry2.GetUIntData();
													propertyEnumerator5.Property.DisplayName = ((TXTC.StepType)uintData2).ToString();
												}
												else
												{
													PropertyEnumerator propertyEnumerator6 = base.AppendManagedProperty(propertyEnumerator5, num2++, propentry2.Guid, propentry2.TypedData.GetType(), propentry2.TypedData, propentry2.Guid.ToString());
													propertyEnumerator6.Property.Tag = "fabc";
													propertyEnumerator6.Property.Value.Tag = propentry2;
													base.ExpandProperty(propertyEnumerator5, false);
												}
											}
										}
									}
								}
							}
							base.ExpandProperty(propertyEnumerator4, false);
							num3++;
						}
						else if (propentry.guid == TXTC.EntryType.Width)
						{
							int num4 = BitConverter.ToInt32((byte[])propentry.data, 0);
							PropertyEnumerator propertyEnumerator7 = base.AppendManagedProperty(propertyEnumerator, num2++, propentry.Guid, typeof(int), num4, "Width");
							propertyEnumerator7.Property.Value.Tag = propentry;
							num3++;
						}
						else if (propentry.guid == TXTC.EntryType.Height)
						{
							int num5 = BitConverter.ToInt32((byte[])propentry.data, 0);
							PropertyEnumerator propertyEnumerator8 = base.AppendManagedProperty(propertyEnumerator, num2++, propentry.Guid, typeof(int), num5, "Height");
							propertyEnumerator8.Property.Value.Tag = propentry;
							num3++;
						}
					}
					if (num3 == 0)
					{
						base.DeleteProperty(propertyEnumerator);
					}
				}
				base.EndUpdate();
			}
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00003E32 File Offset: 0x00002032
		private void method_10(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
		{
			propertyButtonClickedEventArgs_0.PropertyEnum.Property.Value.SetValue(resKey_0);
			(propertyButtonClickedEventArgs_0.PropertyEnum.Property.Look as Class61).NeedsUpdate = true;
		}

		// Token: 0x04000335 RID: 821
		private TXTC txtc_0;

		// Token: 0x04000336 RID: 822
		[CompilerGenerated]
		private Dictionary<string, PropertyEnumerator> dictionary_0;
	}
}
