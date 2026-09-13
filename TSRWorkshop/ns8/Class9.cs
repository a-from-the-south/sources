using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns1;
using ns10;
using ns11;
using ns12;
using ns13;
using ns15;
using ns17;
using ns2;
using ns20;
using ns3;
using ns6;
using ns9;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using VisualHint.SmartPropertyGrid;

namespace ns8
{
	// Token: 0x02000022 RID: 34
	internal sealed class Class9 : Class0
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0001B33C File Offset: 0x0001953C
		// (set) Token: 0x0600010C RID: 268 RVA: 0x000030F3 File Offset: 0x000012F3
		public IProjectModel Project { get; set; }

		// Token: 0x0600010D RID: 269 RVA: 0x0001B354 File Offset: 0x00019554
		public Class9()
		{
			base.PropertyButtonClicked += this.Class9_PropertyButtonClicked;
			base.PropertySelected += this.Class9_PropertySelected;
			this.contextMenu_0 = new ContextMenu();
			this.contextMenu_0.Popup += this.contextMenu_0_Popup;
			this.menuItem_0 = new MenuItem("Duplicate");
			this.menuItem_0.Enabled = false;
			this.menuItem_0.Click += this.menuItem_0_Click;
			this.contextMenu_0.MenuItems.Add(this.menuItem_0);
			this.menuItem_1 = new MenuItem("Delete");
			this.menuItem_1.Enabled = false;
			this.menuItem_1.Click += this.menuItem_1_Click;
			this.contextMenu_0.MenuItems.Add(this.menuItem_1);
			this.menuItem_2 = new MenuItem("Set zero rotation");
			this.menuItem_2.Enabled = false;
			this.menuItem_2.Click += this.menuItem_2_Click;
			this.contextMenu_0.MenuItems.Add(this.menuItem_2);
			this.ContextMenu = this.contextMenu_0;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0001B49C File Offset: 0x0001969C
		private void menuItem_2_Click(object sender, EventArgs e)
		{
			Class18 @class = base.SelectedPropertyEnumerator.Property.Value.Tag as Class18;
			@class.ContainerEntry.Transformation = Matrix.Translation(new Vector3(@class.ContainerEntry.Transformation.M41, @class.ContainerEntry.Transformation.M42, @class.ContainerEntry.Transformation.M43));
			@class.ContainerEntry.imethod_0();
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0001B518 File Offset: 0x00019718
		private void menuItem_0_Click(object sender, EventArgs e)
		{
			Class18 @class = base.SelectedPropertyEnumerator.Property.Value.Tag as Class18;
			RSLT.Entry entry = @class.ContainerEntry.RSLTEntry.Clone() as RSLT.Entry;
			@class.ContainerEntry.RSLT.ContainerEntries.Add(entry);
			Class111 class2 = new Class111(Class132.smethod_0().Device, @class.ContainerEntry.RSLT, entry, Color.Yellow, @class.ContainerEntry.GrannyInfo);
			Class18 class3 = new Class18(class2);
			if (this.class102_0 is Class105)
			{
				Class105 class4 = this.class102_0 as Class105;
				if (class4.GrannyKey != null)
				{
					RIG rig = Class132.mainForm.GetGamedataInstance().GetResource(class4.GrannyKey) as RIG;
					if (rig != null && !rig.Encrypted && MessageBox.Show(this, "Do you want to add a matching bone entry and rename this container slot?", "Create bone", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
					{
						RIG.Bone bone = null;
						foreach (RIG.Bone bone2 in rig.Bones)
						{
							if (bone2.BoneHash == entry.BoneHash)
							{
								bone = bone2;
							}
						}
						if (bone != null)
						{
							RIG.Bone bone3 = bone.Clone();
							bone3.BoneName = "_deco_bone_" + @class.ContainerEntry.RSLT.ContainerEntries.Count;
							class2.ReadableName = "_deco_" + @class.ContainerEntry.RSLT.ContainerEntries.Count;
							entry.NameHash = FNV32.GetHash(class2.ReadableName);
							bone3.BoneHash = (entry.BoneHash = FNV32.GetHash(bone3.BoneName));
							rig.Bones.Add(bone3);
							Class28 grannyInfo = class4.GrannyInfo;
							Class33 class5 = new Class33();
							class5.Sims3WorkshopSDK.Interfaces.IBone.Name = bone3.BoneName;
							class5.NameHash = bone3.BoneHash;
							class5.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex = bone3.ParentIndex;
							class5.InverseMatrix = new float[16];
							class5.Transformation = new Class32();
							class5.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin = new float[]
							{
								bone3.Position[0],
								bone3.Position[1],
								bone3.Position[2]
							};
							class5.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat = new float[]
							{
								bone3.Quaternion[0],
								bone3.Quaternion[1],
								bone3.Quaternion[2],
								bone3.Quaternion[3]
							};
							class5.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Scale = new float[]
							{
								bone3.Scaling[0],
								bone3.Scaling[1],
								bone3.Scaling[2]
							};
							class5.ParentBone = grannyInfo.Skeletons[0].Bones[class5.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex];
							class5.ParentBone.ChildBones.Add(class5);
							Class33[] array = new Class33[grannyInfo.Skeletons[0].Bones.Length + 1];
							for (int i = 0; i < grannyInfo.Skeletons[0].Bones.Length; i++)
							{
								array[i] = grannyInfo.Skeletons[0].Bones[i];
							}
							array[grannyInfo.Skeletons[0].Bones.Length] = class5;
							grannyInfo.Skeletons[0].Bones = array;
							grannyInfo.Skeletons[0].HashedBones.Add(bone3.BoneHash, class5);
							Class33 parentBone = (bone3.ParentIndex != -1) ? grannyInfo.Skeletons[0].Bones[bone3.ParentIndex] : null;
							Class119 item = new Class119(Class140.smethod_0().Device, class4, class4.GrannyKey, class4.GrannyInfo, class5, parentBone, Color.Plum);
							class4.JointEntries.Add(item);
							foreach (Interface9 @interface in class4.Objects.Values)
							{
								Class121 class6 = (Class121)@interface;
								SKIN skin = class6.MLODEntry.Parent.Parent.Entries[class6.MLODEntry.SkinIndex + ((class6.MLODEntry.Parent.Parent.dataType == 2) ? 1 : 0)] as SKIN;
								if (skin != null)
								{
									SKIN.SKINEntry skinentry = skin.HashedEntries[bone.BoneHash] as SKIN.SKINEntry;
									if (skinentry != null)
									{
										new SKIN.SKINEntry();
										SKIN.SKINEntry skinentry2 = skinentry.Clone();
										skinentry2.BoneHash = bone3.BoneHash;
										skin.Entries.Add(skinentry2);
										skin.HashedEntries.Add(skinentry2.BoneHash, skinentry2);
									}
								}
							}
						}
					}
				}
			}
			PropertyEnumerator propertyEnumerator = base.AppendManagedProperty(this.propertyEnumerator_4, 0, "Slot " + @class.ContainerEntry.RSLT.ContainerEntries.Count + ((class2.ReadableName == null) ? "" : (" (" + class2.ReadableName + ")")), typeof(Class18), class3, "wrapper");
			propertyEnumerator.Property.Value.Tag = class3;
			this.class102_0.ContainerEntries.Add(class2);
			base.SelectAndFocusProperty(propertyEnumerator, false);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0001BAE4 File Offset: 0x00019CE4
		private void menuItem_1_Click(object sender, EventArgs e)
		{
			Class18 @class = base.SelectedPropertyEnumerator.Property.Value.Tag as Class18;
			@class.ContainerEntry.RSLT.ContainerEntries.Remove(@class.ContainerEntry.RSLTEntry);
			this.class102_0.ContainerEntries.Remove(@class.ContainerEntry);
			@class.ContainerEntry.imethod_1();
			PropertyEnumerator propertyEnumerator = base.SelectedPropertyEnumerator.MoveNext();
			PropertyEnumerator propertyEnumerator2 = base.SelectedPropertyEnumerator.MovePrev();
			if (propertyEnumerator != null)
			{
				base.SelectAndFocusProperty(propertyEnumerator, false);
			}
			else if (propertyEnumerator2 != null)
			{
				base.SelectAndFocusProperty(propertyEnumerator2, false);
			}
			else
			{
				base.SelectAndFocusProperty(this.propertyEnumerator_4, false);
			}
			base.DeleteProperty(base.SelectedPropertyEnumerator);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0001BBA8 File Offset: 0x00019DA8
		private void contextMenu_0_Popup(object sender, EventArgs e)
		{
			MenuItem menuItem = this.menuItem_2;
			MenuItem menuItem2 = this.menuItem_1;
			this.menuItem_0.Enabled = false;
			menuItem2.Enabled = false;
			menuItem.Enabled = false;
			if (base.SelectedPropertyEnumerator.Property.Value != null && base.SelectedPropertyEnumerator.Property.Value.Tag != null && base.SelectedPropertyEnumerator.Property.Value.Tag.GetType() == typeof(Class18))
			{
				MenuItem menuItem3 = this.menuItem_2;
				MenuItem menuItem4 = this.menuItem_1;
				this.menuItem_0.Enabled = true;
				menuItem4.Enabled = true;
				menuItem3.Enabled = true;
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0001BC58 File Offset: 0x00019E58
		public void method_0(Class102 class102_1)
		{
			this.class102_0 = class102_1;
			base.Clear();
			this.method_4(class102_1);
			this.method_3(class102_1);
			this.method_2(class102_1);
			this.method_5(class102_1);
			this.method_6(class102_1);
			this.method_7(class102_1);
			this.method_8(class102_1);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0001BCA8 File Offset: 0x00019EA8
		private void Class9_PropertySelected(object sender, PropertySelectedEventArgs e)
		{
			if (this.class129_0 != null)
			{
				this.class129_0.Visible = this.class102_0.DisplaySlots;
			}
			if (this.class129_1 != null)
			{
				this.class129_1.Visible = this.class102_0.DisplaySlots;
			}
			if (this.class111_0 != null)
			{
				this.class111_0.Visible = this.class102_0.DisplaySlots;
			}
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.GetType() == typeof(Class19))
			{
				Class19 @class = (Class19)e.PropertyEnum.Property.Value.Tag;
				this.class129_1 = @class.method_0();
				this.class129_1.Visible = true;
			}
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.GetType() == typeof(Class25))
			{
				Class25 class2 = (Class25)e.PropertyEnum.Property.Value.Tag;
				this.class129_0 = class2.method_0();
				this.class129_0.Visible = true;
			}
			if (e.PropertyEnum.Property.Value != null && e.PropertyEnum.Property.Value.Tag != null && e.PropertyEnum.Property.Value.Tag.GetType() == typeof(Class18))
			{
				Class18 class3 = (Class18)e.PropertyEnum.Property.Value.Tag;
				this.class111_0 = class3.ContainerEntry;
				this.class111_0.Visible = true;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000030FE File Offset: 0x000012FE
		private void method_1(DialogResult dialogResult_0)
		{
			Class132.mainForm.CurrentProjectModel.SetRigVisible(false);
			Class132.smethod_0().SelectionDialog = null;
			Class132.smethod_0().method_35();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0001BE98 File Offset: 0x0001A098
		private void Class9_PropertyButtonClicked(object sender, PropertyButtonClickedEventArgs e)
		{
			if (e.PropertyEnum.Property.Value.Tag.GetType() == typeof(Class19))
			{
				Class19 @class = e.PropertyEnum.Property.Value.Tag as Class19;
				FTPT.FootprintEntry slot = @class.method_0().Slot;
				FootprintEditor footprintEditor = new FootprintEditor(this.Project.GetModels(), slot);
				if (footprintEditor.ShowDialog(this) == DialogResult.OK)
				{
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
					slot.BoundingBox[0] = footprintEditor.MinX;
					slot.BoundingBox[1] = footprintEditor.MinZ;
					slot.BoundingBox[2] = footprintEditor.MaxX;
					slot.BoundingBox[3] = footprintEditor.MaxZ;
					@class.method_0().method_0();
					e.PropertyChanged = true;
				}
			}
			else if (e.PropertyEnum.Property.Value.Tag.GetType() == typeof(Class18))
			{
				Class18 class2 = (Class18)e.PropertyEnum.Property.Value.Tag;
				ContainerSlotEditor containerSlotEditor = new ContainerSlotEditor(class2);
				if (containerSlotEditor.ShowDialog(this) == DialogResult.OK)
				{
					class2.ContainerEntry.imethod_2();
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
				}
			}
			else if (e.PropertyEnum.Property.Value.Tag.GetType() == typeof(Class25))
			{
				Class25 class3 = (Class25)e.PropertyEnum.Property.Value.Tag;
				Class129 class4 = class3.method_0();
				SlotEditor slotEditor = new SlotEditor(class4);
				if (slotEditor.ShowDialog(this) == DialogResult.OK)
				{
					Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
					class4.Slot.BoundingBox[0] = class4.Slot.Entries[0][0];
					class4.Slot.BoundingBox[1] = class4.Slot.Entries[0][1];
					class4.Slot.BoundingBox[2] = class4.Slot.Entries[2][0];
					class4.Slot.BoundingBox[3] = class4.Slot.Entries[2][1];
					class4.Slot.Entries[0][0] = class4.Slot.BoundingBox[0];
					class4.Slot.Entries[0][1] = class4.Slot.BoundingBox[1];
					class4.Slot.Entries[1][0] = class4.Slot.BoundingBox[0];
					class4.Slot.Entries[1][1] = class4.Slot.BoundingBox[3];
					class4.Slot.Entries[2][0] = class4.Slot.BoundingBox[2];
					class4.Slot.Entries[2][1] = class4.Slot.BoundingBox[3];
					class4.Slot.Entries[3][0] = class4.Slot.BoundingBox[2];
					class4.Slot.Entries[3][1] = class4.Slot.BoundingBox[1];
				}
				class4.method_0();
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0001C200 File Offset: 0x0001A400
		private void method_2(Class102 class102_1)
		{
			if (this.propertyEnumerator_0 != null)
			{
				base.DeleteProperty(this.propertyEnumerator_0);
			}
			this.propertyEnumerator_0 = base.AppendRootCategory(0, "Bones - " + class102_1.Bones.Count);
			int num = 0;
			foreach (uint boneHash in class102_1.Bones)
			{
				Class17 initialValue = new Class17(boneHash, 0f, 0f, 0f, 0f, 0f, 0f);
				base.AppendManagedProperty(this.propertyEnumerator_0, num++, "0x" + boneHash.ToString("X8"), typeof(Class17), initialValue, "wrapper");
			}
			base.ExpandProperty(this.propertyEnumerator_0, false);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0001C2FC File Offset: 0x0001A4FC
		private void method_3(Class102 class102_1)
		{
			if (this.propertyEnumerator_1 != null)
			{
				base.DeleteProperty(this.propertyEnumerator_1);
			}
			this.propertyEnumerator_1 = base.AppendRootCategory(0, "Slots - " + class102_1.Slots.Count);
			int num = 0;
			foreach (Class129 entry in class102_1.Slots)
			{
				Class25 @class = new Class25(entry);
				PropertyEnumerator propertyEnumerator = base.AppendManagedProperty(this.propertyEnumerator_1, num++, "Slot " + num, typeof(Class25), @class, "wrapper");
				propertyEnumerator.Property.Value.Tag = @class;
			}
			base.ExpandProperty(this.propertyEnumerator_1, false);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0001C3E8 File Offset: 0x0001A5E8
		private void method_4(Class102 class102_1)
		{
			if (this.propertyEnumerator_2 != null)
			{
				base.DeleteProperty(this.propertyEnumerator_2);
			}
			this.propertyEnumerator_2 = base.AppendRootCategory(0, "Footprints - " + class102_1.Footprints.Count);
			int num = 0;
			foreach (Class129 @class in class102_1.Footprints)
			{
				Class19 class2 = new Class19(@class);
				PropertyEnumerator propertyEnumerator = base.AppendManagedProperty(this.propertyEnumerator_2, num++, string.Concat(new object[]
				{
					"Slot type ",
					@class.Slot.TypeFlags,
					" 0x",
					@class.Slot.NameHash.ToString("X8")
				}), typeof(Class19), class2, "wrapper");
				propertyEnumerator.Property.Value.Tag = class2;
			}
			base.ExpandProperty(this.propertyEnumerator_2, false);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0001C51C File Offset: 0x0001A71C
		private void method_5(Class102 class102_1)
		{
			if (this.propertyEnumerator_3 != null)
			{
				base.DeleteProperty(this.propertyEnumerator_3);
			}
			this.propertyEnumerator_3 = base.AppendRootCategory(0, "Route Entries - " + class102_1.RouteEntries.Count);
			int num = 0;
			foreach (Class111 entry in class102_1.RouteEntries)
			{
				Class18 @class = new Class18(entry);
				PropertyEnumerator propertyEnumerator = base.AppendManagedProperty(this.propertyEnumerator_3, num++, "Route " + num, typeof(Class18), @class, "wrapper");
				propertyEnumerator.Property.Value.Tag = @class;
			}
			base.ExpandProperty(this.propertyEnumerator_3, false);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0001C608 File Offset: 0x0001A808
		private void method_6(Class102 class102_1)
		{
			if (this.propertyEnumerator_4 != null)
			{
				base.DeleteProperty(this.propertyEnumerator_4);
			}
			this.propertyEnumerator_4 = base.AppendRootCategory(0, "Container Entries - " + class102_1.ContainerEntries.Count);
			int num = 0;
			foreach (Class111 @class in class102_1.ContainerEntries)
			{
				Class18 class2 = new Class18(@class);
				PropertyEnumerator propertyEnumerator = base.AppendManagedProperty(this.propertyEnumerator_4, num++, "Slot " + num + ((@class.ReadableName == null) ? "" : (" (" + @class.ReadableName + ")")), typeof(Class18), class2, "wrapper");
				propertyEnumerator.Property.Value.Tag = class2;
			}
			base.ExpandProperty(this.propertyEnumerator_4, false);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0001C718 File Offset: 0x0001A918
		private void method_7(Class102 class102_1)
		{
			if (this.propertyEnumerator_5 != null)
			{
				base.DeleteProperty(this.propertyEnumerator_5);
			}
			this.propertyEnumerator_5 = base.AppendRootCategory(0, "Effect Entries - " + class102_1.EffectEntries.Count);
			int num = 0;
			foreach (Class111 entry in class102_1.EffectEntries)
			{
				Class18 @class = new Class18(entry);
				PropertyEnumerator propertyEnumerator = base.AppendManagedProperty(this.propertyEnumerator_5, num++, "Slot " + num, typeof(Class18), @class, "wrapper");
				propertyEnumerator.Property.Value.Tag = @class;
			}
			base.ExpandProperty(this.propertyEnumerator_5, false);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0001C804 File Offset: 0x0001AA04
		private void method_8(Class102 class102_1)
		{
			if (this.propertyEnumerator_6 != null)
			{
				base.DeleteProperty(this.propertyEnumerator_6);
			}
			this.propertyEnumerator_6 = base.AppendRootCategory(0, "Kinematic Entries - " + class102_1.KinematicEntries.Count);
			int num = 0;
			foreach (Class111 entry in class102_1.KinematicEntries)
			{
				Class18 @class = new Class18(entry);
				PropertyEnumerator propertyEnumerator = base.AppendManagedProperty(this.propertyEnumerator_6, num++, "Slot " + num, typeof(Class18), @class, "wrapper");
				propertyEnumerator.Property.Value.Tag = @class;
			}
			base.ExpandProperty(this.propertyEnumerator_6, false);
		}

		// Token: 0x0400010C RID: 268
		private PropertyEnumerator propertyEnumerator_0;

		// Token: 0x0400010D RID: 269
		private PropertyEnumerator propertyEnumerator_1;

		// Token: 0x0400010E RID: 270
		private PropertyEnumerator propertyEnumerator_2;

		// Token: 0x0400010F RID: 271
		private PropertyEnumerator propertyEnumerator_3;

		// Token: 0x04000110 RID: 272
		private PropertyEnumerator propertyEnumerator_4;

		// Token: 0x04000111 RID: 273
		private PropertyEnumerator propertyEnumerator_5;

		// Token: 0x04000112 RID: 274
		private PropertyEnumerator propertyEnumerator_6;

		// Token: 0x04000113 RID: 275
		private Class129 class129_0;

		// Token: 0x04000114 RID: 276
		private Class129 class129_1;

		// Token: 0x04000115 RID: 277
		private Class111 class111_0;

		// Token: 0x04000116 RID: 278
		private Class102 class102_0;

		// Token: 0x04000117 RID: 279
		private ContextMenu contextMenu_0;

		// Token: 0x04000118 RID: 280
		private MenuItem menuItem_0;

		// Token: 0x04000119 RID: 281
		private MenuItem menuItem_1;

		// Token: 0x0400011A RID: 282
		private MenuItem menuItem_2;

		// Token: 0x0400011B RID: 283
		[CompilerGenerated]
		private IProjectModel iprojectModel_0;
	}
}
