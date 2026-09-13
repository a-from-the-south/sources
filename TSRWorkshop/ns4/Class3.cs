using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns10;
using ns13;
using ns15;
using ns17;
using ns19;
using ns2;
using ns3;
using ns6;
using ns7;
using ns8;
using ns9;
using Package;
using Package.Geometry;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3Workshop.Data;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;
using VisualHint.SmartPropertyGrid;

namespace ns4
{
	// Token: 0x0200001B RID: 27
	internal sealed class Class3 : Class2
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00016B14 File Offset: 0x00014D14
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x00002F42 File Offset: 0x00001142
		public Class3.Class22 CurrentWrapper { get; set; }

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060000B9 RID: 185 RVA: 0x00016B2C File Offset: 0x00014D2C
		// (remove) Token: 0x060000BA RID: 186 RVA: 0x00016B64 File Offset: 0x00014D64
		public event Class3.Delegate3 MeshChanged
		{
			add
			{
				Class3.Delegate3 @delegate = this.delegate3_0;
				Class3.Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate3 value2 = (Class3.Delegate3)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate3>(ref this.delegate3_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Class3.Delegate3 @delegate = this.delegate3_0;
				Class3.Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					Class3.Delegate3 value2 = (Class3.Delegate3)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class3.Delegate3>(ref this.delegate3_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00016B9C File Offset: 0x00014D9C
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00002F4D File Offset: 0x0000114D
		public IProjectModel Model { get; set; }

		// Token: 0x060000BD RID: 189 RVA: 0x00002F58 File Offset: 0x00001158
		public Class3()
		{
			base.PropertyButtonClicked += this.Class3_PropertyButtonClicked;
			base.PropertyExpanded += this.Class3_PropertyExpanded;
			this.list_1 = new List<string>();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00016BB4 File Offset: 0x00014DB4
		private void Class3_PropertyExpanded(object sender, PropertyExpandedEventArgs e)
		{
			PropertyEnumerator propertyEnum = e.PropertyEnum;
			object tag = propertyEnum.Property.Tag;
			if (tag is MLOD.MLODEntry)
			{
				(tag as MLOD.MLODEntry).Expanded = e.Expanded;
			}
		}

		// Token: 0x17000012 RID: 18
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00016BF0 File Offset: 0x00014DF0
		public uint SelectedGeostate
		{
			set
			{
				if (this.CurrentWrapper is Class3.Class24)
				{
					Class3.Class24 @class = this.CurrentWrapper as Class3.Class24;
					foreach (MLOD.MLODEntry mlodentry in @class.MLOD.Entries)
					{
						Class121 class2 = ((Class102)this.Model.GetRenderable()).vmethod_2()[mlodentry] as Class121;
						int num = 0;
						class2.GeoStateIndex = -1;
						foreach (MLOD.GeoStateEntry geoStateEntry in mlodentry.GeoStateEntries)
						{
							if (geoStateEntry.NameHash == value)
							{
								class2.GeoStateIndex = num;
							}
							num++;
						}
					}
				}
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002F91 File Offset: 0x00001191
		public void method_9(Class3.Class22 class22_1)
		{
			this.list_1.Clear();
			base.Clear();
			this.CurrentWrapper = class22_1;
			this.CurrentWrapper.vmethod_0(this);
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00016CE4 File Offset: 0x00014EE4
		public Class121 MLODRenderable
		{
			get
			{
				return this.class121_0;
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00016CFC File Offset: 0x00014EFC
		private void Class3_PropertyButtonClicked(object sender, PropertyButtonClickedEventArgs e)
		{
			if (e.PropertyEnum.Property.Tag is VertexFormatEntry)
			{
				object[] array = (object[])e.PropertyEnum.Property.Value.Tag;
				MLOD.MLODEntry mlodEntry = array[0] as MLOD.MLODEntry;
				VRTF vrtf = array[1] as VRTF;
				VertexFormatEntry vertexFormatEntry = e.PropertyEnum.Property.Tag as VertexFormatEntry;
				if (vertexFormatEntry.Usage == VertexEntryUsage.UV)
				{
					UVMapEditor uvmapEditor = new UVMapEditor(mlodEntry, vertexFormatEntry);
					if (uvmapEditor.ShowDialog(Class132.mainForm) == DialogResult.OK && uvmapEditor.HasChanges)
					{
						Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = uvmapEditor.HasChanges;
						if (this.delegate3_0 != null)
						{
							this.delegate3_0(true);
						}
					}
				}
				else
				{
					GenericValueListEditor genericValueListEditor = new GenericValueListEditor(mlodEntry, vrtf, vertexFormatEntry);
					genericValueListEditor.Show(Class132.mainForm);
				}
			}
			if (e.PropertyEnum.Property.Value.Tag is MLOD.GeoStateEntry && !this.bool_1)
			{
				List<Class102> renderables = Class132.smethod_0().Renderables;
				this.mlodentry_0 = (e.PropertyEnum.Property.Tag as MLOD.MLODEntry);
				this.geoStateEntry_0 = (e.PropertyEnum.Property.Value.Tag as MLOD.GeoStateEntry);
				using (List<Class102>.Enumerator enumerator = renderables.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Class102 @class = enumerator.Current;
						foreach (Interface9 @interface in @class.Objects.Values)
						{
							if (@interface is Class121 && (@interface as Class121).MLODEntry == this.mlodentry_0)
							{
								this.bool_1 = true;
								this.class121_0 = (@interface as Class121);
								this.class121_0.CurrentSelectionIndex.Clear();
								for (int i = 0; i < this.geoStateEntry_0.FaceCount * 3; i += 3)
								{
									short short_ = this.class121_0.FaceData[i + this.geoStateEntry_0.IBUFOffset];
									short short_2 = this.class121_0.FaceData[i + this.geoStateEntry_0.IBUFOffset + 1];
									short short_3 = this.class121_0.FaceData[i + this.geoStateEntry_0.IBUFOffset + 2];
									Class102.Class107 class2 = new Class102.Class107();
									class2.short_0 = short_;
									class2.short_1 = short_2;
									class2.short_2 = short_3;
									this.class121_0.CurrentSelectionIndex.Add(class2);
								}
								this.class121_0.imethod_3();
								Point point = base.PointToScreen(new Point(0, 0));
								Class132.smethod_0().SelectionDialog = new GeostateSelector(false);
								Class132.smethod_0().SelectionDialog.Done += this.method_12;
								Class132.smethod_0().SelectionDialog.OnClear += this.method_11;
								(Class132.smethod_0().SelectionDialog as Form).Show(this);
								(Class132.smethod_0().SelectionDialog as Form).Left = point.X;
								(Class132.smethod_0().SelectionDialog as Form).Top = point.Y;
								Class132.smethod_0().SelectionDialog.imethod_4(this.class121_0.CurrentSelectionIndex.Count);
								Class132.smethod_0().method_35();
							}
						}
					}
					return;
				}
			}
			if (!(e.PropertyEnum.Property.Tag is VertexFormatEntry))
			{
				if (e.PropertyEnum.Property.Value.Tag.GetType() == typeof(SKIN.SKINEntry))
				{
					SKIN.SKINEntry skinentry = e.PropertyEnum.Property.Value.Tag as SKIN.SKINEntry;
					SkinEntryEditor skinEntryEditor = new SkinEntryEditor(skinentry);
					if (skinEntryEditor.ShowDialog(Class132.mainForm) == DialogResult.OK)
					{
						if (skinentry.Tag is Class124)
						{
							(skinentry.Tag as Class124).imethod_2();
						}
						Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
					}
				}
				else if (e.PropertyEnum.Property.Value.Tag.GetType() == typeof(MATD))
				{
					MLOD.MLODEntry mlodentry = e.PropertyEnum.Property.Tag as MLOD.MLODEntry;
					MATD matd = e.PropertyEnum.Property.Value.Tag as MATD;
					bool flag = false;
					foreach (MLOD.MLODEntry mlodentry2 in mlodentry.Parent.Entries)
					{
						if (mlodentry2 != null && mlodentry2 != mlodentry)
						{
							RCOLItem rcolitem = mlodentry.Parent.Parent.Entries[mlodentry2.MATDIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)];
							if (rcolitem is MATD && rcolitem == matd)
							{
								flag = true;
							}
							else if (rcolitem is MTST)
							{
								MTST mtst = rcolitem as MTST;
								RCOLItem rcolitem2 = mlodentry.Parent.Parent.Entries[mtst.MATDIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)];
								if (rcolitem2 == matd)
								{
									flag = true;
								}
								foreach (MTST.MTSTEntry mtstentry in mtst.Entries)
								{
									rcolitem2 = (mlodentry.Parent.Parent.Entries[mtstentry.MATDIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as MATD);
									if (rcolitem2 == matd)
									{
										flag = true;
									}
								}
							}
							MATD matd2 = mlodentry.Parent.Parent.Entries[mlodentry2.GEOStateIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as MATD;
							if (matd2 != null && matd2 == matd)
							{
								flag = true;
							}
						}
					}
					MATD matd3 = matd.Clone() as MATD;
					MaterialEditor materialEditor = new MaterialEditor(matd);
					materialEditor.PropChanged += this.method_13;
					if (materialEditor.ShowDialog() == DialogResult.OK && materialEditor.IsDirty)
					{
						if (flag)
						{
							DialogResult dialogResult = MessageBox.Show(this, "This material is used by other groups too, do you want to remove this reference?\n\nIf you choose Yes the material will be duplicated and linked to this group only.", "Linked material", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
							if (dialogResult == DialogResult.Yes)
							{
								MATD matd4 = null;
								int matdindex = 0;
								RCOLItem rcolitem3 = mlodentry.Parent.Parent.Entries[mlodentry.MATDIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)];
								if (rcolitem3 is MATD && rcolitem3 == matd)
								{
									matd4 = ((rcolitem3 as MATD).Clone() as MATD);
									matdindex = (mlodentry.MATDIndex = mlodentry.Parent.Parent.AddEntry(RCOLItemType.MATD, matd4));
								}
								else if (rcolitem3 is MTST)
								{
									MTST mtst2 = rcolitem3 as MTST;
									foreach (MLOD.MLODEntry mlodentry3 in mlodentry.Parent.Entries)
									{
										if (mlodentry3 != mlodentry)
										{
											RCOLItem rcolitem4 = mlodentry3.Parent.Parent.Entries[mlodentry3.MATDIndex + ((mlodentry3.Parent.Parent.dataType == 2) ? 1 : 0)];
											if (rcolitem4 == mtst2)
											{
												MTST mtst3 = mtst2.Clone() as MTST;
												int matdindex2 = mlodentry.Parent.Parent.AddEntry(RCOLItemType.MTST, mtst3);
												mlodentry.MATDIndex = matdindex2;
												mtst2 = mtst3;
											}
										}
									}
									RCOLItem rcolitem5 = mlodentry.Parent.Parent.Entries[mtst2.MATDIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)];
									if (rcolitem5 == matd)
									{
										matd4 = ((rcolitem5 as MATD).Clone() as MATD);
										matdindex = (mtst2.MATDIndex = mlodentry.Parent.Parent.AddEntry(RCOLItemType.MATD, matd4));
									}
									foreach (MTST.MTSTEntry mtstentry2 in mtst2.Entries)
									{
										rcolitem5 = (mlodentry.Parent.Parent.Entries[mtstentry2.MATDIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as MATD);
										if (rcolitem5 == matd)
										{
											if (matd4 != null)
											{
												mtstentry2.MATDIndex = matdindex;
											}
											else
											{
												matd4 = ((rcolitem5 as MATD).Clone() as MATD);
												matdindex = (mtstentry2.MATDIndex = mlodentry.Parent.Parent.AddEntry(RCOLItemType.MATD, matd4));
											}
										}
									}
									MATD matd5 = mlodentry.Parent.Parent.Entries[mlodentry.GEOStateIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as MATD;
									if (matd5 == matd)
									{
										matd4 = (matd5.Clone() as MATD);
										matdindex = (mlodentry.GEOStateIndex = mlodentry.Parent.Parent.AddEntry(RCOLItemType.MATD, matd4));
									}
								}
								matd3.CopyTo(matd);
								e.PropertyEnum.Property.Value.Tag = matd4;
							}
						}
						if (MessageBox.Show(this, "Do you want to update material definitions in all LOD´s?", "Update MATD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && Class132.mainForm.CurrentProjectModel is Class80)
						{
							ObjdModelControl control = (Class132.mainForm.CurrentProjectModel as Class80).Control;
							foreach (object obj in control.meshgroupCombo.Items)
							{
								Class3.Class24 class3 = (Class3.Class24)obj;
								foreach (RCOLItem rcolitem6 in class3.MLOD.Parent.Entries)
								{
									if (rcolitem6 is MATD)
									{
										MATD matd6 = rcolitem6 as MATD;
										if (matd6.NameHash == matd.NameHash && matd6 != matd)
										{
											matd.CopyTo(matd6);
										}
									}
								}
							}
						}
						Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
						if (this.delegate3_0 != null)
						{
							this.delegate3_0(true);
						}
					}
				}
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000178B8 File Offset: 0x00015AB8
		private unsafe void method_10(DialogResult dialogResult_0)
		{
			RCOL parent = this.class121_0.MLODEntry.Parent.Parent;
			VRTF vrtf = parent.Entries[this.class121_0.MLODEntry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] as VRTF;
			VBUF vbuf = parent.Entries[this.class121_0.MLODEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)] as VBUF;
			if (vrtf == null)
			{
				vrtf = VRTF.GetDefaultForLength((this.class121_0.MLODEntry.Type == 20483U) ? 8 : 16);
			}
			DataStream dataStream = this.class121_0.VertexBuffer.Lock(0, 0, LockFlags.None);
			Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
			if (dialogResult_0 == DialogResult.Cancel)
			{
				for (int i = 0; i < this.class121_0.MLODEntry.VertexCount; i++)
				{
					Package.Geometry.Vector4 position = vbuf.GetPosition(vrtf, i, this.class121_0.MLODEntry.VBUFOffset, 0);
					ptr[i].position.X = position.X;
					ptr[i].position.Y = position.Y;
					ptr[i].position.Z = position.Z;
				}
			}
			else
			{
				for (int j = 0; j < this.class121_0.MLODEntry.VertexCount; j++)
				{
					SlimDX.Vector3 position2 = ptr[j].position;
					Package.Geometry.Vector4 position3 = new Package.Geometry.Vector4(position2.X, position2.Y, position2.Z, 0f);
					vbuf.SetPosition(vrtf, j, this.class121_0.MLODEntry.VBUFOffset, position3);
				}
			}
			this.class121_0.VertexBuffer.Unlock();
			this.bool_1 = false;
			Class132.smethod_0().SelectionDialog = null;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00002FB9 File Offset: 0x000011B9
		private void method_11()
		{
			this.class121_0.CurrentSelectionIndex.Clear();
			this.class121_0.imethod_3();
			Class132.smethod_0().method_35();
			Class132.smethod_0().method_35();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00017AB4 File Offset: 0x00015CB4
		private void method_12(DialogResult dialogResult_0)
		{
			this.bool_1 = false;
			Class132.smethod_0().SelectionDialog = null;
			if (dialogResult_0 == DialogResult.OK)
			{
				short[] faceData = this.class121_0.FaceData;
				int faceCount = this.mlodentry_0.FaceCount;
				MLOD parent = this.mlodentry_0.Parent;
				RCOL parent2 = parent.Parent;
				IBUF ibuf = parent2.Entries[this.mlodentry_0.IBUFIndex + ((parent2.dataType == 2) ? 1 : 0)] as IBUF;
				List<short> list = new List<short>();
				foreach (MLOD.MLODEntry mlodentry in parent.Entries)
				{
					IBUF ibuf2 = parent2.Entries[mlodentry.IBUFIndex + ((parent2.dataType == 2) ? 1 : 0)] as IBUF;
					if (ibuf2 == ibuf)
					{
						if (mlodentry != this.mlodentry_0)
						{
							int count = list.Count;
							for (int i = 0; i < mlodentry.FaceCount * 3; i++)
							{
								list.Add(ibuf2.Index[(int)(checked((IntPtr)(unchecked(mlodentry.IBUFOffset + (long)i))))]);
							}
							mlodentry.IBUFOffset = (long)count;
							using (List<MLOD.GeoStateEntry>.Enumerator enumerator2 = mlodentry.GeoStateEntries.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									MLOD.GeoStateEntry geoStateEntry = enumerator2.Current;
									int count2 = list.Count;
									for (int j = 0; j < geoStateEntry.FaceCount * 3; j++)
									{
										list.Add(ibuf2.Index[j + geoStateEntry.IBUFOffset]);
									}
									geoStateEntry.IBUFOffset = count2;
								}
								continue;
							}
						}
						int count3 = list.Count;
						for (int k = 0; k < mlodentry.FaceCount * 3; k++)
						{
							list.Add(ibuf2.Index[(int)(checked((IntPtr)(unchecked(mlodentry.IBUFOffset + (long)k))))]);
						}
						mlodentry.IBUFOffset = (long)count3;
						foreach (MLOD.GeoStateEntry geoStateEntry2 in this.mlodentry_0.GeoStateEntries)
						{
							if (geoStateEntry2 == this.geoStateEntry_0)
							{
								count3 = list.Count;
								geoStateEntry2.FaceCount = this.class121_0.CurrentSelectionIndex.Count;
								int num = int.MaxValue;
								int num2 = int.MinValue;
								List<short> list2 = new List<short>();
								foreach (Class102.Class107 @class in this.class121_0.CurrentSelectionIndex)
								{
									list.Add(@class.short_0);
									list.Add(@class.short_1);
									list.Add(@class.short_2);
									if (!list2.Contains(@class.short_0))
									{
										list2.Add(@class.short_0);
									}
									if (!list2.Contains(@class.short_1))
									{
										list2.Add(@class.short_1);
									}
									if (!list2.Contains(@class.short_2))
									{
										list2.Add(@class.short_2);
									}
									num = Math.Min(num, (int)@class.short_0);
									num = Math.Min(num, (int)@class.short_1);
									num = Math.Min(num, (int)@class.short_2);
									num2 = Math.Max(num2, (int)@class.short_0);
									num2 = Math.Max(num2, (int)@class.short_1);
									num2 = Math.Max(num2, (int)@class.short_2);
								}
								geoStateEntry2.IBUFOffset = count3;
								geoStateEntry2.VBUFOffset = ((num == int.MaxValue) ? 0 : num);
								geoStateEntry2.VertexCount = ((num == int.MaxValue) ? 0 : (num2 + 1 - num));
							}
							else
							{
								count3 = list.Count;
								for (int l = 0; l < geoStateEntry2.FaceCount * 3; l++)
								{
									list.Add(ibuf2.Index[l + geoStateEntry2.IBUFOffset]);
								}
								geoStateEntry2.IBUFOffset = count3;
							}
						}
					}
				}
				ibuf.Index = list.ToArray();
				Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				this.delegate3_0(true);
				foreach (object obj in this)
				{
					if (obj is Property)
					{
						Property property = obj as Property;
						if (property != null && property.Value != null)
						{
							object tag = property.Value.Tag;
							if (tag is MLOD.GeoStateEntry)
							{
								MLOD.GeoStateEntry geoStateEntry3 = tag as MLOD.GeoStateEntry;
								if (geoStateEntry3 == this.geoStateEntry_0)
								{
									base.SelectAndFocusProperty(property.Value.OwnerEnumerator, false);
								}
							}
						}
					}
				}
			}
			Class132.smethod_0().method_35();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00017FD0 File Offset: 0x000161D0
		private void method_13(object sender, PropertyChangedEventArgs e)
		{
			base.NotifyPropertyChanged(e);
			if (e.PropertyEnum.Property.Value.GetValue().GetType() == typeof(PropResKey) && this.delegate3_0 != null)
			{
				this.delegate3_0(true);
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00018020 File Offset: 0x00016220
		protected override void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			if (e.PropertyEnum.Parent != null && e.PropertyEnum.Parent.Property.Tag is VPXY)
			{
				object value = e.PropertyEnum.Parent.Property.Value.GetValue(0);
				(e.PropertyEnum.Parent.Property.Tag as VPXY).BoundingBox = (float[])value;
			}
			if (e.PropertyEnum.Property.Tag is MODLModel)
			{
				object value2 = e.PropertyEnum.Property.Value.GetValue(0);
				if (e.PropertyEnum.Property.Value.Tag.ToString().Contains("extboundingbox"))
				{
					int num = Convert.ToInt32(e.PropertyEnum.Property.Value.Tag.ToString().Substring(14));
					((e.PropertyEnum.Property.Tag as MODLModel).Entries[0] as MODL).ExtendedBoundingBoxes[num] = (float[])value2;
				}
				else
				{
					((e.PropertyEnum.Property.Tag as MODLModel).Entries[0] as MODL).BoundingBox = (float[])value2;
				}
			}
			if (e.PropertyEnum.Property.Name == "Visible")
			{
				MLOD.MLODEntry key = (MLOD.MLODEntry)e.PropertyEnum.Property.Tag;
				Interface9 @interface = ((Class102)this.Model.GetRenderable()).vmethod_2()[key];
				@interface.Visible = (bool)e.PropertyEnum.Property.Value.GetValue();
				Class132.smethod_0().ShadowMapDirty = true;
			}
			if (e.PropertyEnum.Property.Tag is MODL.MODLEntry)
			{
				if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.ToString().Contains("lodinfo"))
				{
					PropertyValue value3 = e.PropertyEnum.Property.Value;
					(this.CurrentWrapper as Class3.Class24).MODLEntry.LodInfoFlags = (MODL.MODLEntry.LodInfo)value3.GetValue();
				}
				if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.ToString().Contains("fadetype"))
				{
					PropertyValue value4 = e.PropertyEnum.Property.Value;
					(this.CurrentWrapper as Class3.Class24).MODL.FadeType = (uint)value4.GetValue();
				}
				if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.ToString().Contains("customfade"))
				{
					PropertyValue value5 = e.PropertyEnum.Property.Value;
					(this.CurrentWrapper as Class3.Class24).MODL.CustomFadeDistance = (float)value5.GetValue();
				}
				if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.ToString().Contains("minz"))
				{
					PropertyValue value6 = e.PropertyEnum.Property.Value;
					(this.CurrentWrapper as Class3.Class24).MODLEntry.MinZ = (float)value6.GetValue();
				}
				if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.ToString().Contains("maxz"))
				{
					PropertyValue value7 = e.PropertyEnum.Property.Value;
					(this.CurrentWrapper as Class3.Class24).MODLEntry.MaxZ = (float)value7.GetValue();
				}
			}
			if (e.PropertyEnum.Property.Tag is MLOD.MLODEntry)
			{
				if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.Equals("meshFlags"))
				{
					PropertyValue value8 = e.PropertyEnum.Property.Value;
					MLOD.MeshFlags meshFlags = (MLOD.MeshFlags)value8.GetValue();
					(e.PropertyEnum.Property.Tag as MLOD.MLODEntry).MeshFlags = meshFlags;
				}
				if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.Equals("primitiveType"))
				{
					PropertyValue value9 = e.PropertyEnum.Property.Value;
					MLOD.PrimitiveType primitiveType = (MLOD.PrimitiveType)value9.GetValue();
					(e.PropertyEnum.Property.Tag as MLOD.MLODEntry).PrimitiveType = primitiveType;
				}
				if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.ToString().Contains("ffboundingbox"))
				{
					object value10 = e.PropertyEnum.Property.Value.GetValue(0);
					(e.PropertyEnum.Property.Tag as MLOD.MLODEntry).BoundingBox = (float[])value10;
				}
			}
			base.OnPropertyChanged(e);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00018668 File Offset: 0x00016868
		protected void OnPropertySelected(PropertySelectedEventArgs e)
		{
			if (this.class124_0 != null)
			{
				this.class124_0.Visible = ((Class102)this.Model.GetRenderable()).DisplayRig;
			}
			if (this.interface9_0 != null)
			{
				this.interface9_0.Selected = false;
			}
			Class132.smethod_0().method_34(null);
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.ToString().Contains("extboundingbox"))
			{
				float[] float_ = (float[])e.PropertyEnum.Property.Value.GetValue(0);
				Class132.smethod_0().method_34(float_);
			}
			else if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.Equals("boundingbox"))
			{
				object value = e.PropertyEnum.Property.Value.GetValue(0);
				Class132.smethod_0().method_34((float[])value);
			}
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag is SKIN.SKINEntry)
			{
				SKIN.SKINEntry skinentry = e.PropertyEnum.Property.Value.Tag as SKIN.SKINEntry;
				Class102 @class = (Class102)this.Model.GetRenderable();
				foreach (Class124 class2 in @class.SkinEntries)
				{
					if (class2.Entry == skinentry)
					{
						class2.Visible = true;
						this.class124_0 = class2;
					}
				}
			}
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag is MATD)
			{
				MLOD.MLODEntry key = e.PropertyEnum.Property.Tag as MLOD.MLODEntry;
				Class121 class3 = ((Class102)this.Model.GetRenderable()).vmethod_2()[key] as Class121;
				if (class3.LOD != Lod.ShadowHigh && class3.LOD != Lod.ShadowLow)
				{
					Class132.smethod_0().method_28(class3, e.PropertyEnum.Property.Value.Tag as MATD);
				}
			}
			else if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag is MLOD.GeoStateEntry)
			{
				MLOD.GeoStateEntry item = e.PropertyEnum.Property.Value.Tag as MLOD.GeoStateEntry;
				MLOD.MLODEntry mlodentry = e.PropertyEnum.Property.Tag as MLOD.MLODEntry;
				Class121 class4 = ((Class102)this.Model.GetRenderable()).vmethod_2()[mlodentry] as Class121;
				class4.GeoStateIndex = mlodentry.GeoStateEntries.IndexOf(item);
				this.interface9_0 = class4;
			}
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag is Class3.Class21)
			{
				MLOD.MLODEntry key2 = e.PropertyEnum.Property.Tag as MLOD.MLODEntry;
				Class121 class5 = ((Class102)this.Model.GetRenderable()).vmethod_2()[key2] as Class121;
				class5.GeoStateIndex = -1;
				class5.Selected = true;
				this.interface9_0 = class5;
			}
			if (e.PreviousSelectedPropertyEnum.Property != null && e.PreviousSelectedPropertyEnum.Property.Value != null && e.PreviousSelectedPropertyEnum.Property.Value.Tag is Class3.Class21)
			{
				MLOD.MLODEntry key3 = e.PreviousSelectedPropertyEnum.Property.Tag as MLOD.MLODEntry;
				Interface9 @interface = ((Class102)this.Model.GetRenderable()).vmethod_2()[key3];
				@interface.Selected = false;
				this.interface9_0 = @interface;
			}
			base.OnPropertySelected(e);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00018AC8 File Offset: 0x00016CC8
		protected void OnDisplayedValuesNeeded(DisplayedValuesNeededEventArgs e)
		{
			if (e.PropertyEnum.Property.Tag is MLOD.MLODEntry)
			{
				e.DisplayedValues = new object[]
				{
					0,
					1
				};
			}
			base.OnDisplayedValuesNeeded(e);
		}

		// Token: 0x040000F2 RID: 242
		public List<string> list_1;

		// Token: 0x040000F3 RID: 243
		private Class3.Delegate3 delegate3_0;

		// Token: 0x040000F4 RID: 244
		private bool bool_1;

		// Token: 0x040000F5 RID: 245
		private Class121 class121_0;

		// Token: 0x040000F6 RID: 246
		private MLOD.MLODEntry mlodentry_0;

		// Token: 0x040000F7 RID: 247
		private MLOD.GeoStateEntry geoStateEntry_0;

		// Token: 0x040000F8 RID: 248
		private Interface9 interface9_0;

		// Token: 0x040000F9 RID: 249
		private Class124 class124_0;

		// Token: 0x040000FA RID: 250
		[CompilerGenerated]
		private Class3.Class22 class22_0;

		// Token: 0x040000FB RID: 251
		[CompilerGenerated]
		private IProjectModel iprojectModel_0;

		// Token: 0x0200001C RID: 28
		[ShowChildProperties(true)]
		internal sealed class Class20
		{
			// Token: 0x17000014 RID: 20
			// (get) Token: 0x060000CA RID: 202 RVA: 0x00018B18 File Offset: 0x00016D18
			// (set) Token: 0x060000CB RID: 203 RVA: 0x00002FEC File Offset: 0x000011EC
			public int FaceCount
			{
				get
				{
					return this.geoState.FaceCount;
				}
				set
				{
					this.geoState.FaceCount = value;
				}
			}

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x060000CC RID: 204 RVA: 0x00018B34 File Offset: 0x00016D34
			// (set) Token: 0x060000CD RID: 205 RVA: 0x00002FFC File Offset: 0x000011FC
			public int VertexCount
			{
				get
				{
					return this.geoState.VertexCount;
				}
				set
				{
					this.geoState.VertexCount = value;
				}
			}

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x060000CE RID: 206 RVA: 0x00018B50 File Offset: 0x00016D50
			// (set) Token: 0x060000CF RID: 207 RVA: 0x0000300C File Offset: 0x0000120C
			public int IndexBufferOffset
			{
				get
				{
					return this.geoState.IBUFOffset;
				}
				set
				{
					this.geoState.IBUFOffset = value;
				}
			}

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x060000D0 RID: 208 RVA: 0x00018B6C File Offset: 0x00016D6C
			// (set) Token: 0x060000D1 RID: 209 RVA: 0x0000301C File Offset: 0x0000121C
			public int VertexBufferOffset
			{
				get
				{
					return this.geoState.VBUFOffset;
				}
				set
				{
					this.geoState.VBUFOffset = value;
				}
			}

			// Token: 0x060000D2 RID: 210 RVA: 0x00018B88 File Offset: 0x00016D88
			public Class20(MLOD.GeoStateEntry geoState)
			{
				this.geoState = geoState;
				this.FaceCount = geoState.FaceCount;
				this.VertexCount = geoState.VertexCount;
				this.IndexBufferOffset = geoState.IBUFOffset;
				this.VertexBufferOffset = geoState.VBUFOffset;
			}

			// Token: 0x060000D3 RID: 211 RVA: 0x00018BD4 File Offset: 0x00016DD4
			public string ToString()
			{
				return string.Concat(new object[]
				{
					this.VertexCount,
					" vertices, ",
					this.FaceCount,
					" faces"
				});
			}

			// Token: 0x040000FC RID: 252
			private MLOD.GeoStateEntry geoState;
		}

		// Token: 0x0200001D RID: 29
		[ShowChildProperties(true)]
		public sealed class Class21
		{
			// Token: 0x17000018 RID: 24
			// (get) Token: 0x060000D4 RID: 212 RVA: 0x00018C20 File Offset: 0x00016E20
			// (set) Token: 0x060000D5 RID: 213 RVA: 0x0000302C File Offset: 0x0000122C
			private PropertyEnumerator PropertyEnum { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x060000D6 RID: 214 RVA: 0x00018C38 File Offset: 0x00016E38
			// (set) Token: 0x060000D7 RID: 215 RVA: 0x00003037 File Offset: 0x00001237
			private MLOD.MLODEntry MLODEntry { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x060000D8 RID: 216 RVA: 0x00018C50 File Offset: 0x00016E50
			// (set) Token: 0x060000D9 RID: 217 RVA: 0x00003042 File Offset: 0x00001242
			private Class3.Class24 MLODWrapper { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x060000DA RID: 218 RVA: 0x00018C68 File Offset: 0x00016E68
			// (set) Token: 0x060000DB RID: 219 RVA: 0x0000304D File Offset: 0x0000124D
			public MLOD MLOD { get; set; }

			// Token: 0x060000DC RID: 220 RVA: 0x00003058 File Offset: 0x00001258
			public Class21(Class3.Class24 wrapper, MLOD mlod, MLOD.MLODEntry entry, Class3 grid)
			{
				this.MLODWrapper = wrapper;
				this.MLODEntry = entry;
				this.MLOD = mlod;
				this.grid = grid;
			}

			// Token: 0x060000DD RID: 221 RVA: 0x00018C80 File Offset: 0x00016E80
			public PropertyEnumerator method_0()
			{
				return this.PropertyEnum;
			}

			// Token: 0x060000DE RID: 222 RVA: 0x0000307F File Offset: 0x0000127F
			public void method_1(PropertyEnumerator propertyEnumerator_1)
			{
				this.PropertyEnum = propertyEnumerator_1;
			}

			// Token: 0x060000DF RID: 223 RVA: 0x00018C98 File Offset: 0x00016E98
			public MLOD method_2()
			{
				return this.MLOD;
			}

			// Token: 0x060000E0 RID: 224 RVA: 0x00018CB0 File Offset: 0x00016EB0
			public MLOD.MLODEntry method_3()
			{
				return this.MLODEntry;
			}

			// Token: 0x060000E1 RID: 225 RVA: 0x00018CC8 File Offset: 0x00016EC8
			public string ToString()
			{
				string result;
				if (this.MLODEntry == null)
				{
					result = "Empty";
				}
				else
				{
					result = string.Concat(new object[]
					{
						this.MLODEntry.VertexCount,
						" vertices, ",
						this.MLODEntry.FaceCount,
						" faces"
					});
				}
				return result;
			}

			// Token: 0x040000FD RID: 253
			private Class3 grid;

			// Token: 0x040000FE RID: 254
			[CompilerGenerated]
			private PropertyEnumerator propertyEnumerator_0;

			// Token: 0x040000FF RID: 255
			[CompilerGenerated]
			private MLOD.MLODEntry mlodentry_0;

			// Token: 0x04000100 RID: 256
			[CompilerGenerated]
			private Class3.Class24 class24_0;

			// Token: 0x04000101 RID: 257
			[CompilerGenerated]
			private MLOD mlod_0;
		}

		// Token: 0x0200001E RID: 30
		public abstract class Class22
		{
			// Token: 0x060000E2 RID: 226
			public abstract void vmethod_0(Class3 class3_0);
		}

		// Token: 0x0200001F RID: 31
		[PropertyFeel("button")]
		public sealed class Class23 : Class3.Class22
		{
			// Token: 0x1700001C RID: 28
			// (get) Token: 0x060000E4 RID: 228 RVA: 0x00018D2C File Offset: 0x00016F2C
			// (set) Token: 0x060000E5 RID: 229 RVA: 0x0000308A File Offset: 0x0000128A
			public SpeedTree SpeedTree { get; private set; }

			// Token: 0x060000E6 RID: 230 RVA: 0x00003095 File Offset: 0x00001295
			public Class23(SpeedTree tree)
			{
				this.SpeedTree = tree;
			}

			// Token: 0x060000E7 RID: 231 RVA: 0x00018D44 File Offset: 0x00016F44
			public override void vmethod_0(Class3 class3_0)
			{
				int id = 0;
				int num = 1;
				PropertyEnumerator underCategory = class3_0.AppendRootCategory(id, "Textures");
				foreach (SpeedTree.TextureValue textureValue in this.SpeedTree.TextureValues)
				{
					string fileName = Path.GetFileName(textureValue.Value);
					ulong hash = FNV64.GetHash(fileName.Substring(0, (fileName.IndexOf(".") != -1) ? fileName.IndexOf(".") : fileName.Length));
					int instanceId = (int)(hash >> 32);
					int secondInstanceId = (int)(hash & 4294967295UL);
					TextureResKey initialValue = new TextureResKey(new ResKey(DBPFType.DDS, 0, instanceId, secondInstanceId).AsString());
					PropertyEnumerator propertyEnumerator = class3_0.AppendManagedProperty(underCategory, num++, fileName, typeof(TextureResKey), initialValue, "Texturevalue");
					propertyEnumerator.Property.Tag = textureValue;
					Class61 @class = new Class61();
					propertyEnumerator.Property.Value.Look = @class;
					@class.PropertyChanged += this.method_0;
					propertyEnumerator.Property.Value.Tag = "texturevalue";
				}
			}

			// Token: 0x060000E8 RID: 232 RVA: 0x00018E90 File Offset: 0x00017090
			protected void method_0(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
			{
				DBPFEntry entry = Class132.mainForm.CurrentProject.Package.GetEntry(resKey_0);
				SpeedTree.TextureValue textureValue = propertyButtonClickedEventArgs_0.PropertyEnum.Property.Tag as SpeedTree.TextureValue;
				string fileName = Path.GetFileName(textureValue.Value);
				ulong hash = FNV64.GetHash(fileName.Substring(0, (fileName.IndexOf(".") != -1) ? fileName.IndexOf(".") : fileName.Length));
				int instanceID = (int)(hash >> 32);
				int secondInstanceID = (int)(hash & 4294967295UL);
				Class132.mainForm.CurrentProject.Package.RemoveEntry(entry);
				entry.InstanceID = instanceID;
				entry.SecondInstanceID = secondInstanceID;
				Class132.mainForm.CurrentProject.Package.AddEntry(entry);
				Class132.mainForm.Refresh();
			}

			// Token: 0x060000E9 RID: 233 RVA: 0x00018F60 File Offset: 0x00017160
			public string ToString()
			{
				return "Speedtree ®";
			}

			// Token: 0x04000102 RID: 258
			[CompilerGenerated]
			private SpeedTree speedTree_0;
		}

		// Token: 0x02000020 RID: 32
		[PropertyFeel("button")]
		public sealed class Class24 : Class3.Class22
		{
			// Token: 0x1700001D RID: 29
			// (get) Token: 0x060000EA RID: 234 RVA: 0x00018F78 File Offset: 0x00017178
			// (set) Token: 0x060000EB RID: 235 RVA: 0x000030A6 File Offset: 0x000012A6
			public MODL.MODLEntry MODLEntry { get; private set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x060000EC RID: 236 RVA: 0x00018F90 File Offset: 0x00017190
			// (set) Token: 0x060000ED RID: 237 RVA: 0x000030B1 File Offset: 0x000012B1
			public MLOD MLOD { get; private set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x060000EE RID: 238 RVA: 0x00018FA8 File Offset: 0x000171A8
			// (set) Token: 0x060000EF RID: 239 RVA: 0x000030BC File Offset: 0x000012BC
			public MODL MODL { get; private set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x060000F0 RID: 240 RVA: 0x00018FC0 File Offset: 0x000171C0
			// (set) Token: 0x060000F1 RID: 241 RVA: 0x000030C7 File Offset: 0x000012C7
			public RCOL Model { get; private set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x060000F2 RID: 242 RVA: 0x00018FD8 File Offset: 0x000171D8
			// (set) Token: 0x060000F3 RID: 243 RVA: 0x000030D2 File Offset: 0x000012D2
			public VPXY VisualProxy { get; private set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x060000F4 RID: 244 RVA: 0x00018FF0 File Offset: 0x000171F0
			// (set) Token: 0x060000F5 RID: 245 RVA: 0x000030DD File Offset: 0x000012DD
			public string Section { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x060000F6 RID: 246 RVA: 0x00019008 File Offset: 0x00017208
			// (set) Token: 0x060000F7 RID: 247 RVA: 0x000030E8 File Offset: 0x000012E8
			public Class3 PropertyGrid { get; private set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x060000F8 RID: 248 RVA: 0x00019020 File Offset: 0x00017220
			public PropertyEnumerator RootProperty
			{
				get
				{
					return this.propertyEnumerator_0;
				}
			}

			// Token: 0x060000F9 RID: 249 RVA: 0x00019038 File Offset: 0x00017238
			public Class24(MODL modl, RCOL model, MODL.MODLEntry modlEntry, VPXY vpxy)
			{
				this.MODL = modl;
				this.Model = model;
				this.VisualProxy = vpxy;
				this.MODLEntry = modlEntry;
				if (this.MODLEntry.IndexType == 12288)
				{
					RCOLFileEntry rcolfileEntry = this.Model.ExternalResources[this.MODLEntry.Index - 1];
					RCOL rcol = Class132.mainForm.CurrentProject.Package.GetEntry(rcolfileEntry.ResKey) as RCOL;
					this.MLOD = (rcol.Entries[0] as MLOD);
				}
				else if (this.MODLEntry.IndexType == 4096)
				{
					this.MLOD = (this.Model.Entries[this.MODLEntry.Index] as MLOD);
				}
				else
				{
					this.MLOD = (this.Model.Entries[this.MODLEntry.Index - 1] as MLOD);
				}
			}

			// Token: 0x060000FA RID: 250 RVA: 0x00019138 File Offset: 0x00017338
			public override void vmethod_0(Class3 class3_1)
			{
				this.PropertyGrid = class3_1;
				int num = 0;
				int num2 = 0;
				int id = 0;
				num = 1;
				PropertyEnumerator propertyEnumerator = class3_1.AppendRootCategory(id, "Visual Proxy");
				PropertyEnumerator underCategory = propertyEnumerator;
				int id2 = 1;
				num = 2;
				PropertyEnumerator propertyEnumerator2 = class3_1.AppendManagedProperty(underCategory, id2, "Boundingbox", typeof(float[]), this.VisualProxy.BoundingBox, "Bounding box values");
				propertyEnumerator2.Property.Tag = this.VisualProxy;
				propertyEnumerator2.Property.Value.Tag = "boundingbox";
				class3_1.ExpandProperty(propertyEnumerator, false);
				int id3 = 2;
				num = 3;
				PropertyEnumerator propertyEnumerator3 = class3_1.AppendRootCategory(id3, "Model");
				PropertyEnumerator underCategory2 = propertyEnumerator3;
				int id4 = 3;
				num = 4;
				PropertyEnumerator propertyEnumerator4 = class3_1.AppendManagedProperty(underCategory2, id4, "Boundingbox", typeof(float[]), this.MODL.BoundingBox, "Bounding box values");
				propertyEnumerator4.Property.Tag = this.Model;
				propertyEnumerator4.Property.Value.Tag = "boundingbox";
				class3_1.ExpandProperty(propertyEnumerator3, false);
				int id5 = 4;
				num = 5;
				PropertyEnumerator propertyEnumerator5 = class3_1.AppendRootCategory(id5, "MODL Entry");
				PropertyEnumerator underCategory3 = propertyEnumerator5;
				int id6 = 5;
				num = 6;
				PropertyEnumerator propertyEnumerator6 = class3_1.AppendManagedProperty(underCategory3, id6, "LOD Info", typeof(MODL.MODLEntry.LodInfo), this.MODLEntry.LodInfoFlags, "LOD Info");
				propertyEnumerator6.Property.Feel = class3_1.GetRegisteredFeel("checkbox");
				propertyEnumerator6.Property.Look = new PropertyCheckboxLook();
				propertyEnumerator6.Property.Tag = this.MODLEntry;
				propertyEnumerator6.Property.Value.Tag = "lodinfo";
				PropertyEnumerator underCategory4 = propertyEnumerator5;
				int id7 = 6;
				num = 7;
				PropertyEnumerator propertyEnumerator7 = class3_1.AppendManagedProperty(underCategory4, id7, "FadeType", typeof(uint), this.MODL.FadeType, "Fade Type");
				propertyEnumerator7.Property.Tag = this.MODLEntry;
				propertyEnumerator7.Property.Value.Tag = "fadetype";
				class3_1.ExpandProperty(propertyEnumerator5, false);
				PropertyEnumerator underCategory5 = propertyEnumerator5;
				int id8 = 7;
				num = 8;
				PropertyEnumerator propertyEnumerator8 = class3_1.AppendManagedProperty(underCategory5, id8, "Maximum Z", typeof(float), this.MODL.CustomFadeDistance, "Custom Fade Value");
				propertyEnumerator8.Property.Tag = this.MODLEntry;
				propertyEnumerator8.Property.Value.Tag = "customfade";
				class3_1.ExpandProperty(propertyEnumerator5, false);
				PropertyEnumerator underCategory6 = propertyEnumerator5;
				int id9 = 8;
				num = 9;
				PropertyEnumerator propertyEnumerator9 = class3_1.AppendManagedProperty(underCategory6, id9, "Minimum Z", typeof(float), this.MODLEntry.MinZ, "Minimum Z");
				propertyEnumerator9.Property.Tag = this.MODLEntry;
				propertyEnumerator9.Property.Value.Tag = "minz";
				PropertyEnumerator underCategory7 = propertyEnumerator5;
				int id10 = 9;
				num = 10;
				PropertyEnumerator propertyEnumerator10 = class3_1.AppendManagedProperty(underCategory7, id10, "Maximum Z", typeof(float), this.MODLEntry.MaxZ, "Maximum Z");
				propertyEnumerator10.Property.Tag = this.MODLEntry;
				propertyEnumerator10.Property.Value.Tag = "maxz";
				class3_1.ExpandProperty(propertyEnumerator5, false);
				if (this.MODL.NumExtendedBoundingBoxes > 0U)
				{
					PropertyEnumerator propertyEnumerator11 = class3_1.AppendRootCategory(num++, "Extended Boundingboxes");
					for (int i = 0; i < this.MODL.ExtendedBoundingBoxes.Length; i++)
					{
						PropertyEnumerator propertyEnumerator12 = class3_1.AppendManagedProperty(propertyEnumerator11, num++, "Boundingbox " + i, typeof(float[]), this.MODL.ExtendedBoundingBoxes[i], "Boundingbox");
						propertyEnumerator12.Property.Tag = this.Model;
						propertyEnumerator12.Property.Value.Tag = "extboundingbox" + i;
						class3_1.ExpandProperty(propertyEnumerator11, false);
					}
				}
				ContextMenu contextMenu = new ContextMenu();
				MenuItem menuItem = new MenuItem("Rename");
				contextMenu.MenuItems.Add(menuItem);
				contextMenu.Popup += this.method_5;
				menuItem.Click += this.method_8;
				menuItem.Tag = "renameGroup";
				class3_1.ContextMenu = contextMenu;
				MenuItem menuItem2 = new MenuItem("Duplicate");
				contextMenu.MenuItems.Add(menuItem2);
				contextMenu.Popup += this.method_5;
				menuItem2.Click += this.method_10;
				menuItem2.Tag = "duplicateGroup";
				class3_1.ContextMenu = contextMenu;
				MenuItem menuItem3 = new MenuItem("Remove");
				contextMenu.MenuItems.Add(menuItem3);
				menuItem3.Click += this.method_9;
				menuItem3.Tag = "removeGroup";
				MenuItem item = new MenuItem("-");
				contextMenu.MenuItems.Add(item);
				MenuItem menuItem4 = new MenuItem("Copy from geostate");
				menuItem4.Tag = "copyGeostate";
				contextMenu.MenuItems.Add(menuItem4);
				MenuItem item2 = new MenuItem("-");
				contextMenu.MenuItems.Add(item2);
				MenuItem menuItem5 = new MenuItem("Link");
				menuItem5.Tag = "linkMaterial";
				contextMenu.MenuItems.Add(menuItem5);
				item2 = new MenuItem("-");
				contextMenu.MenuItems.Add(item2);
				MenuItem menuItem6 = new MenuItem("Copy");
				menuItem6.Tag = "copySkinInfo";
				menuItem6.Click += this.method_4;
				contextMenu.MenuItems.Add(menuItem6);
				MenuItem menuItem7 = new MenuItem("Paste");
				menuItem7.Tag = "pasteSkinInfo";
				menuItem7.Click += this.method_3;
				contextMenu.MenuItems.Add(menuItem7);
				item2 = new MenuItem("-");
				contextMenu.MenuItems.Add(item2);
				MenuItem menuItem8 = new MenuItem("Duplicate VRTF Entry");
				menuItem8.Tag = "duplicateVRTFEntry";
				menuItem8.Click += this.method_0;
				contextMenu.MenuItems.Add(menuItem8);
				if (Class132.mainForm.RIGEditor != null)
				{
					item2 = new MenuItem("-");
					contextMenu.MenuItems.Add(item2);
					MenuItem menuItem9 = new MenuItem("Copy from RIG");
					menuItem9.Tag = "copyFromRIG";
					menuItem9.Click += this.method_2;
					contextMenu.MenuItems.Add(menuItem9);
				}
				WorkshopProject currentProject = Class132.mainForm.CurrentProject;
				foreach (MLOD.MLODEntry mlodentry in this.MLOD.Entries)
				{
					Interface9 @interface = ((Class102)class3_1.Model.GetRenderable()).vmethod_2()[mlodentry];
					string text = "Group " + num2++;
					if (mlodentry.Name == null)
					{
						mlodentry.Name = text;
						string text2 = text;
						mlodentry.AliasKey = text + " alias " + @interface.LOD;
						if (!currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.TryGetValue(mlodentry.AliasKey, out text2))
						{
							currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add(mlodentry.AliasKey, text);
						}
						else
						{
							mlodentry.Name = text2;
							currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData[mlodentry.AliasKey] = text2;
						}
					}
					foreach (MLOD.GeoStateEntry geoStateEntry in mlodentry.GeoStateEntries)
					{
						if (!class3_1.list_1.Contains("0x" + geoStateEntry.NameHash.ToString("X8")))
						{
							class3_1.list_1.Add("0x" + geoStateEntry.NameHash.ToString("X8"));
						}
					}
					Class3.Class21 @class = new Class3.Class21(this, this.MLOD, mlodentry, class3_1);
					this.propertyEnumerator_0 = class3_1.AppendRootCategory(num++, mlodentry.Name);
					this.propertyEnumerator_0.Property.Tag = mlodentry;
					List<MATD> list = (@interface as Class121).method_12(0);
					foreach (MATD matd in list)
					{
						if (@interface.DefaultMaterial == matd)
						{
							PropertyEnumerator propertyEnumerator13 = class3_1.AppendManagedProperty(this.propertyEnumerator_0, num++, "Default material (0x" + matd.NameHash.ToString("X8") + ")", typeof(string), "material", "");
							propertyEnumerator13.Property.Value.Tag = matd;
							propertyEnumerator13.Property.Tag = mlodentry;
							propertyEnumerator13.Property.Feel = class3_1.GetRegisteredFeel("button");
						}
					}
					PropertyEnumerator propertyEnumerator14 = class3_1.AppendManagedProperty(this.propertyEnumerator_0, num++, "Mesh", typeof(string), @class.ToString(), "mesh");
					@class.method_1(propertyEnumerator14);
					propertyEnumerator14.Property.Value.Tag = @class;
					propertyEnumerator14.Property.Tag = mlodentry;
					propertyEnumerator14.Property.Feel = class3_1.GetRegisteredFeel("button");
					propertyEnumerator14.Property.Value.ReadOnly = false;
					if (mlodentry.GeoStateEntries.Count > 0)
					{
						foreach (MLOD.GeoStateEntry geoStateEntry2 in mlodentry.GeoStateEntries)
						{
							Class3.Class20 initialValue = new Class3.Class20(geoStateEntry2);
							PropertyEnumerator propertyEnumerator15 = class3_1.AppendManagedProperty(this.propertyEnumerator_0, num++, "Geostate 0x" + geoStateEntry2.NameHash.ToString("X8"), typeof(Class3.Class20), initialValue, "Geostate");
							propertyEnumerator15.Property.Value.Tag = geoStateEntry2;
							propertyEnumerator15.Property.Tag = mlodentry;
							propertyEnumerator15.Property.Feel = class3_1.GetRegisteredFeel("button");
						}
					}
					PropertyEnumerator propertyEnumerator16 = class3_1.AppendManagedProperty(this.propertyEnumerator_0, num++, "Visible", typeof(bool), @interface.Visible, "Toggle visibilty of this mesh in workshop");
					propertyEnumerator16.Property.Feel = class3_1.GetRegisteredFeel("checkbox");
					propertyEnumerator16.Property.Tag = mlodentry;
					PropertyEnumerator propertyEnumerator17 = class3_1.AppendSubCategory(this.propertyEnumerator_0, num++, "Extra");
					PropertyEnumerator propertyEnumerator18 = class3_1.AppendManagedProperty(propertyEnumerator17, num++, "PrimitiveType", typeof(MLOD.PrimitiveType), mlodentry.PrimitiveType, "primitiveType");
					propertyEnumerator18.Property.Tag = mlodentry;
					propertyEnumerator18.Property.Value.Tag = "primitiveType";
					PropertyEnumerator propertyEnumerator19 = class3_1.AppendManagedProperty(propertyEnumerator17, num++, "MeshFlags", typeof(MLOD.MeshFlags), mlodentry.MeshFlags, "meshFlags");
					propertyEnumerator19.Property.Feel = class3_1.GetRegisteredFeel("checkbox");
					propertyEnumerator19.Property.Tag = mlodentry;
					propertyEnumerator19.Property.Value.Tag = "meshFlags";
					PropertyCheckboxLook look = new PropertyCheckboxLook();
					propertyEnumerator19.Property.Value.Look = look;
					class3_1.ExpandProperty(propertyEnumerator17, false);
					foreach (MATD matd2 in list)
					{
						if (@interface.DefaultMaterial != matd2)
						{
							PropertyEnumerator propertyEnumerator20 = class3_1.AppendManagedProperty(propertyEnumerator17, num++, matd2.ToString(), typeof(string), "material", "");
							propertyEnumerator20.Property.Value.Tag = matd2;
							propertyEnumerator20.Property.Tag = mlodentry;
							propertyEnumerator20.Property.Feel = class3_1.GetRegisteredFeel("button");
						}
					}
					if (mlodentry.SkinIndex != -1)
					{
						PropertyEnumerator propertyEnumerator21 = class3_1.AppendSubCategory(this.propertyEnumerator_0, num++, "Skin info");
						class3_1.ExpandProperty(propertyEnumerator21, false);
						SKIN skin = mlodentry.Parent.Parent.Entries[mlodentry.SkinIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as SKIN;
						if (skin != null)
						{
							foreach (SKIN.SKINEntry skinentry in skin.Entries)
							{
								PropertyEnumerator propertyEnumerator22 = class3_1.AppendManagedProperty(propertyEnumerator21, num++, "0x" + skinentry.BoneHash.ToString("X8"), typeof(string), "skin entry", "");
								propertyEnumerator22.Property.Value.Tag = skinentry;
								propertyEnumerator22.Property.Tag = mlodentry;
								propertyEnumerator22.Property.Feel = class3_1.GetRegisteredFeel("button");
							}
						}
					}
					if (mlodentry.VRTFIndex != -1)
					{
						PropertyEnumerator propertyEnumerator23 = class3_1.AppendSubCategory(this.propertyEnumerator_0, num++, "Vertexformat");
						class3_1.ExpandProperty(propertyEnumerator23, false);
						VRTF vrtf = mlodentry.Parent.Parent.Entries[mlodentry.VRTFIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as VRTF;
						if (vrtf == null)
						{
							vrtf = VRTF.GetDefaultForLength((mlodentry.Type == 20483U) ? 8 : 16);
						}
						if (vrtf != null)
						{
							foreach (VertexFormatEntry vertexFormatEntry in vrtf.Entries)
							{
								PropertyEnumerator propertyEnumerator24 = class3_1.AppendManagedProperty(propertyEnumerator23, num++, vertexFormatEntry.Usage.ToString(), typeof(string), string.Concat(new object[]
								{
									vertexFormatEntry.Type.ToString(),
									"  (",
									vertexFormatEntry.Offset,
									", ",
									vertexFormatEntry.Index,
									")"
								}), "");
								propertyEnumerator24.Property.Value.Tag = new object[]
								{
									mlodentry,
									vrtf
								};
								propertyEnumerator24.Property.Tag = vertexFormatEntry;
								propertyEnumerator24.Property.Feel = class3_1.GetRegisteredFeel("button");
							}
						}
					}
					PropertyEnumerator propertyEnumerator25 = class3_1.AppendManagedProperty(propertyEnumerator17, num++, "Boundingbox", typeof(float[]), mlodentry.BoundingBox, "Bounding box values");
					propertyEnumerator25.Property.Tag = mlodentry;
					propertyEnumerator25.Property.Value.Tag = "ffboundingbox";
					class3_1.ExpandProperty(this.propertyEnumerator_0, mlodentry.Expanded);
				}
			}

			// Token: 0x060000FB RID: 251 RVA: 0x0001A154 File Offset: 0x00018354
			private void method_0(object sender, EventArgs e)
			{
				if (MessageBox.Show(Class132.mainForm, "Adding a VRTF Entry will generate a new vertex buffer with a different index and this can not be undone. Use at own risk", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
				{
					PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.PropertyGrid.SelectedPropertyEnumerator;
					VertexFormatEntry vertexFormatEntry = selectedPropertyEnumerator.Property.Tag as VertexFormatEntry;
					VRTF vrtf = ((object[])selectedPropertyEnumerator.Property.Value.Tag)[1] as VRTF;
					MLOD.MLODEntry mlodentry = ((object[])selectedPropertyEnumerator.Property.Value.Tag)[0] as MLOD.MLODEntry;
					VertexFormatEntry vertexFormatEntry2 = vertexFormatEntry.Clone();
					vertexFormatEntry2.SetOffset((byte)((long)vertexFormatEntry2.Offset + (long)((ulong)vertexFormatEntry2.SizeBytes)));
					AddEditVRTFEntry addEditVRTFEntry = new AddEditVRTFEntry(vertexFormatEntry2);
					if (addEditVRTFEntry.ShowDialog(Class132.mainForm) != DialogResult.Cancel)
					{
						VBUF vbuf = mlodentry.Parent.Parent.Entries[mlodentry.VBUFIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as VBUF;
						VBUF vbuf2 = new VBUF();
						vbuf2.Buffer = new byte[(ulong)(vrtf.BytesPerVertex + vertexFormatEntry2.SizeBytes) * (ulong)((long)mlodentry.VertexCount)];
						for (int i = 0; i < mlodentry.VertexCount; i++)
						{
							long num = (long)(vrtf.Length * i) + mlodentry.VBUFOffset;
							foreach (VertexFormatEntry vertexFormatEntry3 in vrtf.Entries)
							{
								int num2 = 0;
								while ((long)num2 < (long)((ulong)vertexFormatEntry3.SizeBytes))
								{
									long num3 = ((long)vrtf.Length + (long)((ulong)vertexFormatEntry2.SizeBytes)) * (long)i + (long)vertexFormatEntry3.Offset + (long)num2;
									long num4 = num + (long)num2 + (long)vertexFormatEntry3.Offset;
									checked
									{
										vbuf2.Buffer[(int)((IntPtr)num3)] = vbuf.Buffer[(int)((IntPtr)num4)];
									}
									num2++;
								}
							}
							int num5 = 0;
							while ((long)num5 < (long)((ulong)vertexFormatEntry2.SizeBytes))
							{
								long num6 = ((long)vrtf.Length + (long)((ulong)vertexFormatEntry2.SizeBytes)) * (long)i + (long)vrtf.Length + (long)num5;
								vbuf2.Buffer[(int)(checked((IntPtr)num6))] = ((vertexFormatEntry2.Usage == VertexEntryUsage.ASSIGNMENT) ? byte.MaxValue : 0);
								num5++;
							}
						}
						bool flag = false;
						bool flag2 = false;
						foreach (MLOD.MLODEntry mlodentry2 in mlodentry.Parent.Entries)
						{
							if (mlodentry2 != mlodentry)
							{
								if (mlodentry2.VBUFIndex == mlodentry.VBUFIndex)
								{
									flag = true;
								}
								if (mlodentry2.VRTFIndex == mlodentry.VRTFIndex)
								{
									flag2 = true;
								}
							}
						}
						if (flag)
						{
							mlodentry.VBUFIndex = mlodentry.Parent.Parent.AddEntry(RCOLItemType.VBUF, vbuf2);
							mlodentry.VBUFOffset = 0L;
						}
						else
						{
							vbuf.Buffer = vbuf2.Buffer;
						}
						if (flag2)
						{
							VRTF vrtf2 = vrtf.Clone() as VRTF;
							mlodentry.VRTFIndex = mlodentry.Parent.Parent.AddEntry(RCOLItemType.VRTF, vrtf2);
							vrtf2.Entries.Add(vertexFormatEntry2);
							vrtf2.BytesPerVertex += vertexFormatEntry2.SizeBytes;
						}
						else
						{
							vrtf.Entries.Add(vertexFormatEntry2);
							vrtf.BytesPerVertex += vertexFormatEntry2.SizeBytes;
						}
						if (this.PropertyGrid.delegate3_0 != null)
						{
							this.PropertyGrid.delegate3_0(true);
						}
					}
				}
			}

			// Token: 0x060000FC RID: 252 RVA: 0x0001A4EC File Offset: 0x000186EC
			private void method_1(object sender, EventArgs e)
			{
				PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.PropertyGrid.SelectedPropertyEnumerator;
				VertexFormatEntry item = selectedPropertyEnumerator.Property.Tag as VertexFormatEntry;
				VRTF vrtf = ((object[])selectedPropertyEnumerator.Property.Value.Tag)[0] as VRTF;
				object obj = ((object[])selectedPropertyEnumerator.Property.Value.Tag)[0];
				vrtf.Entries.Remove(item);
				if (this.PropertyGrid.delegate3_0 != null)
				{
					this.PropertyGrid.delegate3_0(true);
				}
			}

			// Token: 0x060000FD RID: 253 RVA: 0x0001A578 File Offset: 0x00018778
			private void method_2(object sender, EventArgs e)
			{
				PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.PropertyGrid.SelectedPropertyEnumerator;
				SKIN.SKINEntry skinentry = selectedPropertyEnumerator.Property.Value.Tag as SKIN.SKINEntry;
				Class105 @class = this.PropertyGrid.Model.GetRenderable() as Class105;
				if (@class.GrannyInfo != null)
				{
					foreach (Class34 class2 in @class.GrannyInfo.Skeletons)
					{
						Class33 class3 = class2.HashedBones[skinentry.BoneHash] as Class33;
						if (class3 != null)
						{
							new SlimDX.Vector3(class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[0], class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[1], class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[2]);
							new Quaternion(class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[0], class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[1], class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[2], class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[3]);
							Matrix combinedTransformationMatrix = class3.CombinedTransformationMatrix;
							combinedTransformationMatrix.Invert();
							skinentry.BoneMatrix[0] = (float)Math.Round((double)combinedTransformationMatrix.M11, 3);
							skinentry.BoneMatrix[4] = (float)Math.Round((double)combinedTransformationMatrix.M12, 3);
							skinentry.BoneMatrix[8] = (float)Math.Round((double)combinedTransformationMatrix.M13, 3);
							skinentry.BoneMatrix[1] = (float)Math.Round((double)combinedTransformationMatrix.M21, 3);
							skinentry.BoneMatrix[5] = (float)Math.Round((double)combinedTransformationMatrix.M22, 3);
							skinentry.BoneMatrix[9] = (float)Math.Round((double)combinedTransformationMatrix.M23, 3);
							skinentry.BoneMatrix[2] = (float)Math.Round((double)combinedTransformationMatrix.M31, 3);
							skinentry.BoneMatrix[6] = (float)Math.Round((double)combinedTransformationMatrix.M32, 3);
							skinentry.BoneMatrix[10] = (float)Math.Round((double)combinedTransformationMatrix.M33, 3);
							skinentry.BoneMatrix[3] = (float)Math.Round((double)combinedTransformationMatrix.M41, 3);
							skinentry.BoneMatrix[7] = (float)Math.Round((double)combinedTransformationMatrix.M42, 3);
							skinentry.BoneMatrix[11] = (float)Math.Round((double)combinedTransformationMatrix.M43, 3);
							if (skinentry.Tag is Class124)
							{
								(skinentry.Tag as Class124).imethod_2();
							}
						}
					}
				}
			}

			// Token: 0x060000FE RID: 254 RVA: 0x0001A7CC File Offset: 0x000189CC
			private void method_3(object sender, EventArgs e)
			{
				PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.PropertyGrid.SelectedPropertyEnumerator;
				SKIN.SKINEntry skinentry = selectedPropertyEnumerator.Property.Value.Tag as SKIN.SKINEntry;
				for (int i = 0; i < 12; i++)
				{
					skinentry.BoneMatrix[i] = this.skinentry_0.BoneMatrix[i];
				}
			}

			// Token: 0x060000FF RID: 255 RVA: 0x0001A820 File Offset: 0x00018A20
			private void method_4(object sender, EventArgs e)
			{
				PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.PropertyGrid.SelectedPropertyEnumerator;
				this.skinentry_0 = (selectedPropertyEnumerator.Property.Value.Tag as SKIN.SKINEntry);
			}

			// Token: 0x06000100 RID: 256 RVA: 0x0001A858 File Offset: 0x00018A58
			private void method_5(object sender, EventArgs e)
			{
				ContextMenu contextMenu = sender as ContextMenu;
				PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.PropertyGrid.SelectedPropertyEnumerator;
				foreach (object obj in contextMenu.MenuItems)
				{
					MenuItem menuItem = (MenuItem)obj;
					if (menuItem.Tag != null)
					{
						if (menuItem.Tag.Equals("linkMaterial"))
						{
							menuItem.Enabled = (selectedPropertyEnumerator.Property.Value != null && selectedPropertyEnumerator.Property.Value.Tag is MATD);
							if (menuItem.Enabled)
							{
								menuItem.MenuItems.Clear();
								MLOD.MLODEntry mlodentry = selectedPropertyEnumerator.Property.Tag as MLOD.MLODEntry;
								int num = 0;
								foreach (MLOD.MLODEntry mlodentry2 in mlodentry.Parent.Entries)
								{
									MenuItem menuItem2 = menuItem.MenuItems.Add("Group " + num++);
									foreach (KeyValuePair<int, MATD> keyValuePair in mlodentry2.GetAllMaterials())
									{
										MenuItem menuItem3 = menuItem2.MenuItems.Add(string.Concat(new object[]
										{
											keyValuePair.Value.ToString(),
											" [",
											keyValuePair.Key,
											"]"
										}));
										menuItem3.Click += this.method_6;
										menuItem3.Tag = new object[]
										{
											mlodentry,
											selectedPropertyEnumerator.Property.Value.Tag as MATD,
											keyValuePair.Value,
											keyValuePair.Key,
											selectedPropertyEnumerator
										};
									}
								}
							}
						}
						if (menuItem.Tag.Equals("duplicateVRTFEntry"))
						{
							menuItem.Enabled = (selectedPropertyEnumerator.Property.Value != null && selectedPropertyEnumerator.Property.Tag is VertexFormatEntry);
						}
						if (menuItem.Tag.Equals("removeVRTFEntry"))
						{
							menuItem.Enabled = (selectedPropertyEnumerator.Property.Value != null && selectedPropertyEnumerator.Property.Tag is VertexFormatEntry);
						}
						if (menuItem.Tag.Equals("copyFromRIG"))
						{
							menuItem.Enabled = (selectedPropertyEnumerator.Property.Value != null && selectedPropertyEnumerator.Property.Value.Tag is SKIN.SKINEntry);
						}
						if (menuItem.Tag.Equals("copySkinInfo"))
						{
							menuItem.Enabled = (selectedPropertyEnumerator.Property.Value != null && selectedPropertyEnumerator.Property.Value.Tag is SKIN.SKINEntry);
						}
						if (menuItem.Tag.Equals("pasteSkinInfo"))
						{
							menuItem.Enabled = (selectedPropertyEnumerator.Property.Value != null && selectedPropertyEnumerator.Property.Value.Tag is SKIN.SKINEntry && this.skinentry_0 != null);
						}
						if (menuItem.Tag.Equals("renameGroup"))
						{
							menuItem.Enabled = (selectedPropertyEnumerator.Property.Value == null && selectedPropertyEnumerator.Property.Tag is MLOD.MLODEntry);
						}
						if (menuItem.Tag.Equals("duplicateGroup"))
						{
							menuItem.Enabled = (selectedPropertyEnumerator.Property.Value == null && selectedPropertyEnumerator.Property.Tag is MLOD.MLODEntry);
						}
						if (menuItem.Tag.Equals("removeGroup"))
						{
							menuItem.Enabled = (selectedPropertyEnumerator.Property.Value == null && selectedPropertyEnumerator.Property.Tag is MLOD.MLODEntry);
						}
						if (menuItem.Tag.Equals("copyGeostate"))
						{
							menuItem.Enabled = (selectedPropertyEnumerator.Property.Value != null && selectedPropertyEnumerator.Property.Value.Tag is MLOD.GeoStateEntry);
							menuItem.MenuItems.Clear();
							MLOD.MLODEntry mlodentry3 = selectedPropertyEnumerator.Property.Tag as MLOD.MLODEntry;
							if (mlodentry3 != null)
							{
								int num2 = 1;
								foreach (MLOD.GeoStateEntry tag in mlodentry3.GeoStateEntries)
								{
									MenuItem menuItem4 = new MenuItem("Geostate " + num2++);
									menuItem4.Tag = tag;
									menuItem4.Click += this.method_7;
									menuItem.MenuItems.Add(menuItem4);
								}
							}
						}
					}
				}
			}

			// Token: 0x06000101 RID: 257 RVA: 0x0001ADB8 File Offset: 0x00018FB8
			private void method_6(object sender, EventArgs e)
			{
				MenuItem menuItem = sender as MenuItem;
				object[] array = menuItem.Tag as object[];
				MLOD.MLODEntry mlodentry = array[0] as MLOD.MLODEntry;
				MATD matd = array[1] as MATD;
				int num = (int)array[3];
				PropertyEnumerator propertyEnumerator = array[4] as PropertyEnumerator;
				RCOLItem rcolitem = mlodentry.Parent.Parent.Entries[mlodentry.MATDIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)];
				if (rcolitem == matd)
				{
					mlodentry.MATDIndex = num;
				}
				else if (rcolitem is MTST)
				{
					MTST mtst = rcolitem as MTST;
					MATD matd2 = mlodentry.Parent.Parent.Entries[mtst.MATDIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as MATD;
					if (matd2 == matd)
					{
						mtst.MATDIndex = num;
					}
					foreach (MTST.MTSTEntry mtstentry in mtst.Entries)
					{
						matd2 = (mlodentry.Parent.Parent.Entries[mtstentry.MATDIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as MATD);
						if (matd2 == matd)
						{
							mtstentry.MATDIndex = num;
						}
					}
				}
				MATD matd3 = mlodentry.Parent.Parent.Entries[mlodentry.GEOStateIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as MATD;
				if (matd3 == matd)
				{
					mlodentry.GEOStateIndex = num;
				}
				propertyEnumerator.Property.Value.Tag = mlodentry.Parent.Parent.Entries[num + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)];
				if (this.PropertyGrid.delegate3_0 != null)
				{
					this.PropertyGrid.delegate3_0(true);
				}
			}

			// Token: 0x06000102 RID: 258 RVA: 0x0001AFD8 File Offset: 0x000191D8
			private void method_7(object sender, EventArgs e)
			{
				MenuItem menuItem = sender as MenuItem;
				PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.PropertyGrid.SelectedPropertyEnumerator;
				MLOD.GeoStateEntry geoStateEntry = menuItem.Tag as MLOD.GeoStateEntry;
				MLOD.GeoStateEntry geoStateEntry2 = selectedPropertyEnumerator.Property.Value.Tag as MLOD.GeoStateEntry;
				geoStateEntry2.FaceCount = geoStateEntry.FaceCount;
				geoStateEntry2.IBUFOffset = geoStateEntry.IBUFOffset;
				geoStateEntry2.VBUFOffset = geoStateEntry.VBUFOffset;
				geoStateEntry2.VertexCount = geoStateEntry.VertexCount;
				if (this.PropertyGrid.delegate3_0 != null)
				{
					this.PropertyGrid.delegate3_0(true);
				}
				foreach (object obj in this.PropertyGrid)
				{
					if (obj is Property)
					{
						Property property = obj as Property;
						if (property != null && property.Value != null)
						{
							object tag = property.Value.Tag;
							if (tag is MLOD.GeoStateEntry)
							{
								MLOD.GeoStateEntry geoStateEntry3 = tag as MLOD.GeoStateEntry;
								if (geoStateEntry3 == geoStateEntry2)
								{
									this.PropertyGrid.SelectAndFocusProperty(property.Value.OwnerEnumerator, false);
								}
							}
						}
					}
				}
			}

			// Token: 0x06000103 RID: 259 RVA: 0x0001B0E8 File Offset: 0x000192E8
			private void method_8(object sender, EventArgs e)
			{
				PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.PropertyGrid.SelectedPropertyEnumerator;
				MLOD.MLODEntry mlodentry = selectedPropertyEnumerator.Property.Tag as MLOD.MLODEntry;
				InputForm inputForm = new InputForm();
				inputForm.textField.Text = mlodentry.Name;
				if (inputForm.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData[mlodentry.AliasKey] = (mlodentry.Name = inputForm.textField.Text);
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
					if (this.PropertyGrid.delegate3_0 != null)
					{
						this.PropertyGrid.delegate3_0(true);
					}
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				}
			}

			// Token: 0x06000104 RID: 260 RVA: 0x0001B1A8 File Offset: 0x000193A8
			private void method_9(object sender, EventArgs e)
			{
				if (MessageBox.Show("Removing a group is experimental and may not work as suspected. Do you want to continue?", "Remove group", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
				{
					PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.PropertyGrid.SelectedPropertyEnumerator;
					MLOD.MLODEntry mlodentry = selectedPropertyEnumerator.Property.Tag as MLOD.MLODEntry;
					mlodentry.Parent.Entries.Remove(mlodentry);
					if (this.PropertyGrid.delegate3_0 != null)
					{
						this.PropertyGrid.delegate3_0(true);
					}
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				}
			}

			// Token: 0x06000105 RID: 261 RVA: 0x0001B22C File Offset: 0x0001942C
			private void method_10(object sender, EventArgs e)
			{
				if (MessageBox.Show("Duplicating a group is experimental and may not work as suspected. Do you want to continue?", "Duplicate group", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
				{
					PropertyVisibleDeepEnumerator selectedPropertyEnumerator = this.PropertyGrid.SelectedPropertyEnumerator;
					MLOD.MLODEntry mlodentry = selectedPropertyEnumerator.Property.Tag as MLOD.MLODEntry;
					mlodentry.Clone();
					if (this.PropertyGrid.delegate3_0 != null)
					{
						this.PropertyGrid.delegate3_0(true);
					}
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				}
			}

			// Token: 0x06000106 RID: 262 RVA: 0x0001B2A4 File Offset: 0x000194A4
			public string ToString()
			{
				Lod lod = (Lod)this.MODLEntry.LOD;
				return this.Section + ((lod == Lod.High) ? "High level of detail" : ((lod == Lod.Low) ? "Low level of detail" : ((lod == Lod.Medium) ? "Medium level of detail" : ((lod == Lod.ShadowHigh) ? "Shadow high level of detail" : ((lod == Lod.ShadowMedium) ? "Shadow medium level of detail" : ((lod == Lod.ShadowLow) ? "Shadow low level of detail" : ("LOD " + this.MODLEntry.LOD.ToString("X8"))))))));
			}

			// Token: 0x04000103 RID: 259
			private PropertyEnumerator propertyEnumerator_0;

			// Token: 0x04000104 RID: 260
			private SKIN.SKINEntry skinentry_0;

			// Token: 0x04000105 RID: 261
			[CompilerGenerated]
			private MODL.MODLEntry modlentry_0;

			// Token: 0x04000106 RID: 262
			[CompilerGenerated]
			private MLOD mlod_0;

			// Token: 0x04000107 RID: 263
			[CompilerGenerated]
			private MODL modl_0;

			// Token: 0x04000108 RID: 264
			[CompilerGenerated]
			private RCOL rcol_0;

			// Token: 0x04000109 RID: 265
			[CompilerGenerated]
			private VPXY vpxy_0;

			// Token: 0x0400010A RID: 266
			[CompilerGenerated]
			private string string_0;

			// Token: 0x0400010B RID: 267
			[CompilerGenerated]
			private Class3 class3_0;
		}

		// Token: 0x02000021 RID: 33
		// (Invoke) Token: 0x06000108 RID: 264
		public delegate void Delegate3(bool reloadMesh);
	}
}
