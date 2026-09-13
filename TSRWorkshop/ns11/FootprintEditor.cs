using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns16;
using Package.Geometry;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;

namespace ns11
{
	// Token: 0x0200005E RID: 94
	internal sealed partial class FootprintEditor : Form
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00041660 File Offset: 0x0003F860
		// (set) Token: 0x06000399 RID: 921 RVA: 0x00003F76 File Offset: 0x00002176
		public float MaxX
		{
			get
			{
				return this.float_0;
			}
			set
			{
				this.float_0 = value;
				this._maxX.Text = value.ToString();
				this.method_1();
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00041678 File Offset: 0x0003F878
		// (set) Token: 0x0600039B RID: 923 RVA: 0x00003F99 File Offset: 0x00002199
		public float MaxZ
		{
			get
			{
				return this.float_1;
			}
			set
			{
				this.float_1 = value;
				this._maxZ.Text = value.ToString();
				this.method_1();
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00041690 File Offset: 0x0003F890
		// (set) Token: 0x0600039D RID: 925 RVA: 0x00003FBC File Offset: 0x000021BC
		public float MinX
		{
			get
			{
				return this.float_2;
			}
			set
			{
				this.float_2 = value;
				this._minX.Text = value.ToString();
				this.method_1();
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600039E RID: 926 RVA: 0x000416A8 File Offset: 0x0003F8A8
		// (set) Token: 0x0600039F RID: 927 RVA: 0x00003FDF File Offset: 0x000021DF
		public float MinZ
		{
			get
			{
				return this.float_3;
			}
			set
			{
				this.float_3 = value;
				this._minZ.Text = value.ToString();
				this.method_1();
			}
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x000416C0 File Offset: 0x0003F8C0
		public FootprintEditor(List<object> models, FTPT.FootprintEntry footprintEntry)
		{
			FootprintEditor.float_4 = new float[9][];
			this.footprintEntry = footprintEntry;
			this.float_5 = new float[this.footprintEntry.Entries.Count, 2];
			for (int i = 0; i < this.footprintEntry.Entries.Count; i++)
			{
				this.float_5[i, 0] = this.footprintEntry.Entries[i][0];
				this.float_5[i, 1] = this.footprintEntry.Entries[i][1];
			}
			FootprintEditor.float_4[0] = new float[]
			{
				0.49f,
				0.49f,
				-0.49f,
				-0.49f
			};
			FootprintEditor.float_4[1] = new float[]
			{
				0.49f,
				0.99f,
				-0.49f,
				-0.99f
			};
			FootprintEditor.float_4[2] = new float[]
			{
				0.49f,
				1.49f,
				-0.49f,
				-1.49f
			};
			FootprintEditor.float_4[3] = new float[]
			{
				0.99f,
				0.49f,
				-0.99f,
				-0.49f
			};
			FootprintEditor.float_4[4] = new float[]
			{
				0.99f,
				0.99f,
				-0.99f,
				-0.99f
			};
			FootprintEditor.float_4[5] = new float[]
			{
				0.99f,
				1.49f,
				-0.99f,
				-1.49f
			};
			FootprintEditor.float_4[6] = new float[]
			{
				1.49f,
				0.49f,
				-1.49f,
				-0.49f
			};
			FootprintEditor.float_4[7] = new float[]
			{
				1.49f,
				0.99f,
				-1.495f,
				-0.99f
			};
			FootprintEditor.float_4[8] = new float[]
			{
				1.49f,
				1.49f,
				-1.49f,
				-1.49f
			};
			this.InitializeComponent();
			this.footprintTypeFlags.SetItemChecked(0, (footprintEntry.TypeFlags & FTPT.FootprintTypeFlags.ForPlacement) != (FTPT.FootprintTypeFlags)0U);
			this.footprintTypeFlags.SetItemChecked(1, (footprintEntry.TypeFlags & FTPT.FootprintTypeFlags.ForPathing) != (FTPT.FootprintTypeFlags)0U);
			this.footprintTypeFlags.SetItemChecked(2, (footprintEntry.TypeFlags & FTPT.FootprintTypeFlags.IsEnabled) != (FTPT.FootprintTypeFlags)0U);
			this.footprintTypeFlags.SetItemChecked(3, (footprintEntry.TypeFlags & FTPT.FootprintTypeFlags.IsDiscouraged) != (FTPT.FootprintTypeFlags)0U);
			this.footprintTypeFlags.SetItemChecked(4, (footprintEntry.TypeFlags & FTPT.FootprintTypeFlags.ForShell) != (FTPT.FootprintTypeFlags)0U);
			this.allowIntersectionFlags.SetItemChecked(0, (footprintEntry.AllowIntersectionFlags & FTPT.AllowIntersectionFlags.Walls) != (FTPT.AllowIntersectionFlags)0U);
			this.allowIntersectionFlags.SetItemChecked(1, (footprintEntry.AllowIntersectionFlags & FTPT.AllowIntersectionFlags.Objects) != (FTPT.AllowIntersectionFlags)0U);
			this.allowIntersectionFlags.SetItemChecked(2, (footprintEntry.AllowIntersectionFlags & FTPT.AllowIntersectionFlags.Sims) != (FTPT.AllowIntersectionFlags)0U);
			this.allowIntersectionFlags.SetItemChecked(3, (footprintEntry.AllowIntersectionFlags & FTPT.AllowIntersectionFlags.Roofs) != (FTPT.AllowIntersectionFlags)0U);
			this.allowIntersectionFlags.SetItemChecked(4, (footprintEntry.AllowIntersectionFlags & FTPT.AllowIntersectionFlags.Fences) != (FTPT.AllowIntersectionFlags)0U);
			this.allowIntersectionFlags.SetItemChecked(5, (footprintEntry.AllowIntersectionFlags & FTPT.AllowIntersectionFlags.ModularStairs) != (FTPT.AllowIntersectionFlags)0U);
			this.allowIntersectionFlags.SetItemChecked(6, (footprintEntry.AllowIntersectionFlags & FTPT.AllowIntersectionFlags.ObjectsOfSameType) != (FTPT.AllowIntersectionFlags)0U);
			this.surfaceTypeFlags.SetItemChecked(0, (footprintEntry.SurfaceTypeFlags & FTPT.SurfaceTypeFlags.Terrain) != (FTPT.SurfaceTypeFlags)0U);
			this.surfaceTypeFlags.SetItemChecked(1, (footprintEntry.SurfaceTypeFlags & FTPT.SurfaceTypeFlags.Floor) != (FTPT.SurfaceTypeFlags)0U);
			this.surfaceTypeFlags.SetItemChecked(2, (footprintEntry.SurfaceTypeFlags & FTPT.SurfaceTypeFlags.Pool) != (FTPT.SurfaceTypeFlags)0U);
			this.surfaceTypeFlags.SetItemChecked(3, (footprintEntry.SurfaceTypeFlags & FTPT.SurfaceTypeFlags.Pond) != (FTPT.SurfaceTypeFlags)0U);
			this.surfaceTypeFlags.SetItemChecked(4, (footprintEntry.SurfaceTypeFlags & FTPT.SurfaceTypeFlags.Fence) != (FTPT.SurfaceTypeFlags)0U);
			this.surfaceTypeFlags.SetItemChecked(5, (footprintEntry.SurfaceTypeFlags & FTPT.SurfaceTypeFlags.AnySurface) != (FTPT.SurfaceTypeFlags)0U);
			this.surfaceTypeFlags.SetItemChecked(6, (footprintEntry.SurfaceTypeFlags & FTPT.SurfaceTypeFlags.Air) != (FTPT.SurfaceTypeFlags)0U);
			this.surfaceTypeFlags.SetItemChecked(7, (footprintEntry.SurfaceTypeFlags & FTPT.SurfaceTypeFlags.Roof) != (FTPT.SurfaceTypeFlags)0U);
			this.surfaceAttributeFlags.SetItemChecked(0, (footprintEntry.SurfaceAttributeFlags & FTPT.SurfaceAttributeFlags.Inside) != (FTPT.SurfaceAttributeFlags)0U);
			this.surfaceAttributeFlags.SetItemChecked(1, (footprintEntry.SurfaceAttributeFlags & FTPT.SurfaceAttributeFlags.Outside) != (FTPT.SurfaceAttributeFlags)0U);
			this.surfaceAttributeFlags.SetItemChecked(2, (footprintEntry.SurfaceAttributeFlags & FTPT.SurfaceAttributeFlags.Slope) != (FTPT.SurfaceAttributeFlags)0U);
			this.MinX = footprintEntry.BoundingBox[0];
			this.MinZ = footprintEntry.BoundingBox[1];
			this.MaxX = footprintEntry.BoundingBox[2];
			this.MaxZ = footprintEntry.BoundingBox[3];
			this._minX.Text = this.MinX.ToString();
			this._minZ.Text = this.MinZ.ToString();
			this._maxX.Text = this.MaxX.ToString();
			this._maxZ.Text = this.MaxZ.ToString();
			this.method_0();
			foreach (object obj in models)
			{
				MODLModel modlmodel = (MODLModel)obj;
				foreach (RCOLItem rcolitem in modlmodel.Entries)
				{
					if (rcolitem.GetType().Equals(typeof(MODL)))
					{
						MODL modl = rcolitem as MODL;
						foreach (MODL.MODLEntry modlentry in modl.Entries)
						{
							MLOD mlod;
							if (modlentry.IndexType == 12288)
							{
								RCOLFileEntry rcolfileEntry = modlmodel.ExternalResources[modlentry.Index - 1];
								RCOL rcol = Class76.smethod_26(rcolfileEntry.ResKey) as RCOL;
								mlod = (rcol.Entries[0] as MLOD);
							}
							else if (modlentry.IndexType == 4096)
							{
								mlod = (modlmodel.Entries[modlentry.Index] as MLOD);
							}
							else
							{
								mlod = (modlmodel.Entries[modlentry.Index - 1] as MLOD);
							}
							if (mlod != null)
							{
								foreach (MLOD.MLODEntry item in mlod.Entries)
								{
									this.meshCombo.Items.Add(item);
								}
							}
						}
					}
				}
			}
			this.levelOffset.Text = footprintEntry.LevelOffset.ToString();
			this.elevationOffset.Enabled = (footprintEntry.Version >= 7U);
			if (footprintEntry.Version >= 7U)
			{
				this.elevationOffset.Text = footprintEntry.ElevationOffset.ToString();
			}
			this.bool_0 = true;
			this.surfaceAttributeFlags_MouseUp(null, null);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00041DB4 File Offset: 0x0003FFB4
		private void doneButton_Click(object sender, EventArgs e)
		{
			FootprintEditor.Class50[] array = this.dataGridView1.DataSource as FootprintEditor.Class50[];
			for (int i = 0; i < array.Length; i++)
			{
				this.footprintEntry.Entries[i][0] = array[i].Xvalue;
				this.footprintEntry.Entries[i][1] = array[i].Zvalue;
			}
			this.footprintEntry.TypeFlags = (FTPT.FootprintTypeFlags)0U;
			this.footprintEntry.TypeFlags |= (this.footprintTypeFlags.GetItemChecked(0) ? FTPT.FootprintTypeFlags.ForPlacement : ((FTPT.FootprintTypeFlags)0U));
			this.footprintEntry.TypeFlags |= (this.footprintTypeFlags.GetItemChecked(1) ? FTPT.FootprintTypeFlags.ForPathing : ((FTPT.FootprintTypeFlags)0U));
			this.footprintEntry.TypeFlags |= (this.footprintTypeFlags.GetItemChecked(2) ? FTPT.FootprintTypeFlags.IsEnabled : ((FTPT.FootprintTypeFlags)0U));
			this.footprintEntry.TypeFlags |= (this.footprintTypeFlags.GetItemChecked(3) ? FTPT.FootprintTypeFlags.IsDiscouraged : ((FTPT.FootprintTypeFlags)0U));
			this.footprintEntry.TypeFlags |= (this.footprintTypeFlags.GetItemChecked(4) ? FTPT.FootprintTypeFlags.ForShell : ((FTPT.FootprintTypeFlags)0U));
			this.footprintEntry.AllowIntersectionFlags = (FTPT.AllowIntersectionFlags)0U;
			this.footprintEntry.AllowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(0) ? FTPT.AllowIntersectionFlags.Walls : ((FTPT.AllowIntersectionFlags)0U));
			this.footprintEntry.AllowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(1) ? FTPT.AllowIntersectionFlags.Objects : ((FTPT.AllowIntersectionFlags)0U));
			this.footprintEntry.AllowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(2) ? FTPT.AllowIntersectionFlags.Sims : ((FTPT.AllowIntersectionFlags)0U));
			this.footprintEntry.AllowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(3) ? FTPT.AllowIntersectionFlags.Roofs : ((FTPT.AllowIntersectionFlags)0U));
			this.footprintEntry.AllowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(4) ? FTPT.AllowIntersectionFlags.Fences : ((FTPT.AllowIntersectionFlags)0U));
			this.footprintEntry.AllowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(5) ? FTPT.AllowIntersectionFlags.ModularStairs : ((FTPT.AllowIntersectionFlags)0U));
			this.footprintEntry.AllowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(6) ? FTPT.AllowIntersectionFlags.ObjectsOfSameType : ((FTPT.AllowIntersectionFlags)0U));
			this.footprintEntry.SurfaceTypeFlags = (FTPT.SurfaceTypeFlags)0U;
			this.footprintEntry.SurfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(0) ? FTPT.SurfaceTypeFlags.Terrain : ((FTPT.SurfaceTypeFlags)0U));
			this.footprintEntry.SurfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(1) ? FTPT.SurfaceTypeFlags.Floor : ((FTPT.SurfaceTypeFlags)0U));
			this.footprintEntry.SurfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(2) ? FTPT.SurfaceTypeFlags.Pool : ((FTPT.SurfaceTypeFlags)0U));
			this.footprintEntry.SurfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(3) ? FTPT.SurfaceTypeFlags.Pond : ((FTPT.SurfaceTypeFlags)0U));
			this.footprintEntry.SurfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(4) ? FTPT.SurfaceTypeFlags.Fence : ((FTPT.SurfaceTypeFlags)0U));
			this.footprintEntry.SurfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(5) ? FTPT.SurfaceTypeFlags.AnySurface : ((FTPT.SurfaceTypeFlags)0U));
			this.footprintEntry.SurfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(6) ? FTPT.SurfaceTypeFlags.Air : ((FTPT.SurfaceTypeFlags)0U));
			this.footprintEntry.SurfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(7) ? FTPT.SurfaceTypeFlags.Roof : ((FTPT.SurfaceTypeFlags)0U));
			this.footprintEntry.SurfaceAttributeFlags = (FTPT.SurfaceAttributeFlags)0U;
			this.footprintEntry.SurfaceAttributeFlags |= (this.surfaceAttributeFlags.GetItemChecked(0) ? FTPT.SurfaceAttributeFlags.Inside : ((FTPT.SurfaceAttributeFlags)0U));
			this.footprintEntry.SurfaceAttributeFlags |= (this.surfaceAttributeFlags.GetItemChecked(1) ? FTPT.SurfaceAttributeFlags.Outside : ((FTPT.SurfaceAttributeFlags)0U));
			this.footprintEntry.SurfaceAttributeFlags |= (this.surfaceAttributeFlags.GetItemChecked(2) ? FTPT.SurfaceAttributeFlags.Slope : ((FTPT.SurfaceAttributeFlags)0U));
			try
			{
				this.footprintEntry.LevelOffset = byte.Parse(this.levelOffset.Text);
			}
			catch (Exception ex)
			{
				this.levelOffset.Focus();
				this.levelOffset.SelectAll();
				MessageBox.Show(ex.Message);
			}
			if (this.footprintEntry.Version >= 7U)
			{
				try
				{
					this.footprintEntry.ElevationOffset = float.Parse(this.elevationOffset.Text);
				}
				catch (Exception ex2)
				{
					this.elevationOffset.Focus();
					this.elevationOffset.SelectAll();
					MessageBox.Show(ex2.Message);
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00042250 File Offset: 0x00040450
		private void button2_Click(object sender, EventArgs e)
		{
			MLOD.MLODEntry mlodentry = this.meshCombo.SelectedItem as MLOD.MLODEntry;
			VBUF vbuf = mlodentry.Parent.Parent.Entries[mlodentry.VBUFIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as VBUF;
			VRTF vrtf = mlodentry.Parent.Parent.Entries[mlodentry.VRTFIndex + ((mlodentry.Parent.Parent.dataType == 2) ? 1 : 0)] as VRTF;
			if (vrtf == null)
			{
				vrtf = VRTF.GetDefaultForLength((mlodentry.Type == 20483U) ? 8 : 16);
			}
			float num = float.MinValue;
			float num2 = float.MinValue;
			float num3 = float.MaxValue;
			float num4 = float.MaxValue;
			for (int i = 0; i < mlodentry.VertexCount; i++)
			{
				Vector4 position = vbuf.GetPosition(vrtf, i, mlodentry.VBUFOffset, 0);
				num = Math.Max(position.X, num);
				num2 = Math.Max(position.Z, num2);
				num3 = Math.Min(position.X, num3);
				num4 = Math.Min(position.Z, num4);
			}
			this.MaxX = num;
			this.MaxZ = num2;
			this.MinX = num3;
			this.MinZ = num4;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0004239C File Offset: 0x0004059C
		private void _maxX_Leave(object sender, EventArgs e)
		{
			try
			{
				this.MaxX = float.Parse(this._maxX.Text);
			}
			catch (Exception ex)
			{
				this._maxX.Focus();
				this._maxX.SelectAll();
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x000423FC File Offset: 0x000405FC
		private void _maxZ_Leave(object sender, EventArgs e)
		{
			try
			{
				this.MaxZ = float.Parse(this._maxZ.Text);
			}
			catch (Exception ex)
			{
				this._maxZ.Focus();
				this._maxZ.SelectAll();
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0004245C File Offset: 0x0004065C
		private void _minX_Leave(object sender, EventArgs e)
		{
			try
			{
				this.MinX = float.Parse(this._minX.Text);
			}
			catch (Exception ex)
			{
				this._minX.Focus();
				this._minX.SelectAll();
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x000424BC File Offset: 0x000406BC
		private void _minZ_Leave(object sender, EventArgs e)
		{
			try
			{
				this.MinZ = float.Parse(this._minZ.Text);
			}
			catch (Exception ex)
			{
				this._minZ.Focus();
				this._minZ.SelectAll();
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0004251C File Offset: 0x0004071C
		private void predefinedCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.predefinedCombo.SelectedIndex != -1)
			{
				float[] array = FootprintEditor.float_4[this.predefinedCombo.SelectedIndex];
				this.MaxX = array[0];
				this.MaxZ = array[1];
				this.MinX = array[2];
				this.MinZ = array[3];
			}
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00042570 File Offset: 0x00040770
		private void method_0()
		{
			FootprintEditor.Class50[] array = new FootprintEditor.Class50[this.footprintEntry.Entries.Count];
			int num = 0;
			foreach (float[] array2 in this.footprintEntry.Entries)
			{
				array[num++] = new FootprintEditor.Class50(array2[0], array2[1]);
			}
			this.dataGridView1.DataSource = array;
			this.dataGridView1.Columns[0].Width = 123;
			this.dataGridView1.Columns[1].Width = 124;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0004262C File Offset: 0x0004082C
		private void method_1()
		{
			FootprintEditor.Class50[] array = this.dataGridView1.DataSource as FootprintEditor.Class50[];
			if (array != null)
			{
				if (array.Length == 4)
				{
					array[0].Xvalue = this.MinX;
					array[0].Zvalue = this.MinZ;
					array[1].Xvalue = this.MinX;
					array[1].Zvalue = this.MaxZ;
					array[2].Xvalue = this.MaxX;
					array[2].Zvalue = this.MaxZ;
					array[3].Xvalue = this.MaxX;
					array[3].Zvalue = this.MinZ;
				}
				this.dataGridView1.DataSource = array;
				this.dataGridView1.Refresh();
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x000426E4 File Offset: 0x000408E4
		private void SurfaceAttributeFlagsText_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_1)
			{
				FTPT.FootprintTypeFlags footprintTypeFlags = (FTPT.FootprintTypeFlags)Convert.ToUInt32(this.FootprintTypeFlagsText.Text, 16);
				FTPT.AllowIntersectionFlags allowIntersectionFlags = (FTPT.AllowIntersectionFlags)Convert.ToUInt32(this.AllowIntersectionFlagsText.Text, 16);
				FTPT.SurfaceTypeFlags surfaceTypeFlags = (FTPT.SurfaceTypeFlags)Convert.ToUInt32(this.SurfaceTypeFlagsText.Text, 16);
				FTPT.SurfaceAttributeFlags surfaceAttributeFlags = (FTPT.SurfaceAttributeFlags)Convert.ToUInt32(this.SurfaceAttributeFlagsText.Text, 16);
				this.footprintTypeFlags.SetItemChecked(0, (footprintTypeFlags & FTPT.FootprintTypeFlags.ForPlacement) != (FTPT.FootprintTypeFlags)0U);
				this.footprintTypeFlags.SetItemChecked(1, (footprintTypeFlags & FTPT.FootprintTypeFlags.ForPathing) != (FTPT.FootprintTypeFlags)0U);
				this.footprintTypeFlags.SetItemChecked(2, (footprintTypeFlags & FTPT.FootprintTypeFlags.IsEnabled) != (FTPT.FootprintTypeFlags)0U);
				this.footprintTypeFlags.SetItemChecked(3, (footprintTypeFlags & FTPT.FootprintTypeFlags.IsDiscouraged) != (FTPT.FootprintTypeFlags)0U);
				this.footprintTypeFlags.SetItemChecked(4, (footprintTypeFlags & FTPT.FootprintTypeFlags.ForShell) != (FTPT.FootprintTypeFlags)0U);
				this.allowIntersectionFlags.SetItemChecked(0, (allowIntersectionFlags & FTPT.AllowIntersectionFlags.Walls) != (FTPT.AllowIntersectionFlags)0U);
				this.allowIntersectionFlags.SetItemChecked(1, (allowIntersectionFlags & FTPT.AllowIntersectionFlags.Objects) != (FTPT.AllowIntersectionFlags)0U);
				this.allowIntersectionFlags.SetItemChecked(2, (allowIntersectionFlags & FTPT.AllowIntersectionFlags.Sims) != (FTPT.AllowIntersectionFlags)0U);
				this.allowIntersectionFlags.SetItemChecked(3, (allowIntersectionFlags & FTPT.AllowIntersectionFlags.Roofs) != (FTPT.AllowIntersectionFlags)0U);
				this.allowIntersectionFlags.SetItemChecked(4, (allowIntersectionFlags & FTPT.AllowIntersectionFlags.Fences) != (FTPT.AllowIntersectionFlags)0U);
				this.allowIntersectionFlags.SetItemChecked(5, (allowIntersectionFlags & FTPT.AllowIntersectionFlags.ModularStairs) != (FTPT.AllowIntersectionFlags)0U);
				this.allowIntersectionFlags.SetItemChecked(6, (allowIntersectionFlags & FTPT.AllowIntersectionFlags.ObjectsOfSameType) != (FTPT.AllowIntersectionFlags)0U);
				this.surfaceTypeFlags.SetItemChecked(0, (surfaceTypeFlags & FTPT.SurfaceTypeFlags.Terrain) != (FTPT.SurfaceTypeFlags)0U);
				this.surfaceTypeFlags.SetItemChecked(1, (surfaceTypeFlags & FTPT.SurfaceTypeFlags.Floor) != (FTPT.SurfaceTypeFlags)0U);
				this.surfaceTypeFlags.SetItemChecked(2, (surfaceTypeFlags & FTPT.SurfaceTypeFlags.Pool) != (FTPT.SurfaceTypeFlags)0U);
				this.surfaceTypeFlags.SetItemChecked(3, (surfaceTypeFlags & FTPT.SurfaceTypeFlags.Pond) != (FTPT.SurfaceTypeFlags)0U);
				this.surfaceTypeFlags.SetItemChecked(4, (surfaceTypeFlags & FTPT.SurfaceTypeFlags.Fence) != (FTPT.SurfaceTypeFlags)0U);
				this.surfaceTypeFlags.SetItemChecked(5, (surfaceTypeFlags & FTPT.SurfaceTypeFlags.AnySurface) != (FTPT.SurfaceTypeFlags)0U);
				this.surfaceTypeFlags.SetItemChecked(6, (surfaceTypeFlags & FTPT.SurfaceTypeFlags.Air) != (FTPT.SurfaceTypeFlags)0U);
				this.surfaceTypeFlags.SetItemChecked(7, (surfaceTypeFlags & FTPT.SurfaceTypeFlags.Roof) != (FTPT.SurfaceTypeFlags)0U);
				this.surfaceAttributeFlags.SetItemChecked(0, (surfaceAttributeFlags & FTPT.SurfaceAttributeFlags.Inside) != (FTPT.SurfaceAttributeFlags)0U);
				this.surfaceAttributeFlags.SetItemChecked(1, (surfaceAttributeFlags & FTPT.SurfaceAttributeFlags.Outside) != (FTPT.SurfaceAttributeFlags)0U);
				this.surfaceAttributeFlags.SetItemChecked(2, (surfaceAttributeFlags & FTPT.SurfaceAttributeFlags.Slope) != (FTPT.SurfaceAttributeFlags)0U);
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00042940 File Offset: 0x00040B40
		private void surfaceAttributeFlags_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.bool_0)
			{
				FTPT.FootprintTypeFlags footprintTypeFlags = (FTPT.FootprintTypeFlags)0U | (this.footprintTypeFlags.GetItemChecked(0) ? FTPT.FootprintTypeFlags.ForPlacement : ((FTPT.FootprintTypeFlags)0U));
				footprintTypeFlags |= (this.footprintTypeFlags.GetItemChecked(1) ? FTPT.FootprintTypeFlags.ForPathing : ((FTPT.FootprintTypeFlags)0U));
				footprintTypeFlags |= (this.footprintTypeFlags.GetItemChecked(2) ? FTPT.FootprintTypeFlags.IsEnabled : ((FTPT.FootprintTypeFlags)0U));
				footprintTypeFlags |= (this.footprintTypeFlags.GetItemChecked(3) ? FTPT.FootprintTypeFlags.IsDiscouraged : ((FTPT.FootprintTypeFlags)0U));
				footprintTypeFlags |= (this.footprintTypeFlags.GetItemChecked(4) ? FTPT.FootprintTypeFlags.ForShell : ((FTPT.FootprintTypeFlags)0U));
				FTPT.AllowIntersectionFlags allowIntersectionFlags = (FTPT.AllowIntersectionFlags)0U | (this.allowIntersectionFlags.GetItemChecked(0) ? FTPT.AllowIntersectionFlags.Walls : ((FTPT.AllowIntersectionFlags)0U));
				allowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(1) ? FTPT.AllowIntersectionFlags.Objects : ((FTPT.AllowIntersectionFlags)0U));
				allowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(2) ? FTPT.AllowIntersectionFlags.Sims : ((FTPT.AllowIntersectionFlags)0U));
				allowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(3) ? FTPT.AllowIntersectionFlags.Roofs : ((FTPT.AllowIntersectionFlags)0U));
				allowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(4) ? FTPT.AllowIntersectionFlags.Fences : ((FTPT.AllowIntersectionFlags)0U));
				allowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(5) ? FTPT.AllowIntersectionFlags.ModularStairs : ((FTPT.AllowIntersectionFlags)0U));
				allowIntersectionFlags |= (this.allowIntersectionFlags.GetItemChecked(6) ? FTPT.AllowIntersectionFlags.ObjectsOfSameType : ((FTPT.AllowIntersectionFlags)0U));
				FTPT.SurfaceTypeFlags surfaceTypeFlags = (FTPT.SurfaceTypeFlags)0U | (this.surfaceTypeFlags.GetItemChecked(0) ? FTPT.SurfaceTypeFlags.Terrain : ((FTPT.SurfaceTypeFlags)0U));
				surfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(1) ? FTPT.SurfaceTypeFlags.Floor : ((FTPT.SurfaceTypeFlags)0U));
				surfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(2) ? FTPT.SurfaceTypeFlags.Pool : ((FTPT.SurfaceTypeFlags)0U));
				surfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(3) ? FTPT.SurfaceTypeFlags.Pond : ((FTPT.SurfaceTypeFlags)0U));
				surfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(4) ? FTPT.SurfaceTypeFlags.Fence : ((FTPT.SurfaceTypeFlags)0U));
				surfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(5) ? FTPT.SurfaceTypeFlags.AnySurface : ((FTPT.SurfaceTypeFlags)0U));
				surfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(6) ? FTPT.SurfaceTypeFlags.Air : ((FTPT.SurfaceTypeFlags)0U));
				surfaceTypeFlags |= (this.surfaceTypeFlags.GetItemChecked(7) ? FTPT.SurfaceTypeFlags.Roof : ((FTPT.SurfaceTypeFlags)0U));
				FTPT.SurfaceAttributeFlags surfaceAttributeFlags = (FTPT.SurfaceAttributeFlags)0U | (this.surfaceAttributeFlags.GetItemChecked(0) ? FTPT.SurfaceAttributeFlags.Inside : ((FTPT.SurfaceAttributeFlags)0U));
				surfaceAttributeFlags |= (this.surfaceAttributeFlags.GetItemChecked(1) ? FTPT.SurfaceAttributeFlags.Outside : ((FTPT.SurfaceAttributeFlags)0U));
				surfaceAttributeFlags |= (this.surfaceAttributeFlags.GetItemChecked(2) ? FTPT.SurfaceAttributeFlags.Slope : ((FTPT.SurfaceAttributeFlags)0U));
				this.bool_1 = true;
				Control footprintTypeFlagsText = this.FootprintTypeFlagsText;
				string str = "0x";
				uint num = (uint)footprintTypeFlags;
				footprintTypeFlagsText.Text = str + num.ToString("X8");
				Control allowIntersectionFlagsText = this.AllowIntersectionFlagsText;
				string str2 = "0x";
				uint num2 = (uint)allowIntersectionFlags;
				allowIntersectionFlagsText.Text = str2 + num2.ToString("X8");
				Control surfaceTypeFlagsText = this.SurfaceTypeFlagsText;
				string str3 = "0x";
				uint num3 = (uint)surfaceTypeFlags;
				surfaceTypeFlagsText.Text = str3 + num3.ToString("X8");
				Control surfaceAttributeFlagsText = this.SurfaceAttributeFlagsText;
				string str4 = "0x";
				uint num4 = (uint)surfaceAttributeFlags;
				surfaceAttributeFlagsText.Text = str4 + num4.ToString("X8");
				this.bool_1 = false;
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00004002 File Offset: 0x00002202
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000352 RID: 850
		private float float_0;

		// Token: 0x04000353 RID: 851
		private float float_1;

		// Token: 0x04000354 RID: 852
		private float float_2;

		// Token: 0x04000355 RID: 853
		private float float_3;

		// Token: 0x04000356 RID: 854
		private static float[][] float_4;

		// Token: 0x04000357 RID: 855
		private FTPT.FootprintEntry footprintEntry;

		// Token: 0x04000358 RID: 856
		private float[,] float_5;

		// Token: 0x04000359 RID: 857
		private bool bool_0;

		// Token: 0x0400035A RID: 858
		private bool bool_1;

		// Token: 0x0400035B RID: 859
		private IContainer icontainer_0;

		// Token: 0x0200005F RID: 95
		internal sealed class Class50
		{
			// Token: 0x1700008F RID: 143
			// (get) Token: 0x060003AF RID: 943 RVA: 0x00044110 File Offset: 0x00042310
			// (set) Token: 0x060003B0 RID: 944 RVA: 0x00004023 File Offset: 0x00002223
			public float Xvalue { get; set; }

			// Token: 0x17000090 RID: 144
			// (get) Token: 0x060003B1 RID: 945 RVA: 0x00044128 File Offset: 0x00042328
			// (set) Token: 0x060003B2 RID: 946 RVA: 0x0000402E File Offset: 0x0000222E
			public float Zvalue { get; set; }

			// Token: 0x060003B3 RID: 947 RVA: 0x00004039 File Offset: 0x00002239
			public Class50(float x, float z)
			{
				this.Xvalue = x;
				this.Zvalue = z;
			}

			// Token: 0x0400037E RID: 894
			[CompilerGenerated]
			private float float_0;

			// Token: 0x0400037F RID: 895
			[CompilerGenerated]
			private float float_1;
		}
	}
}
