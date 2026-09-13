using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns10;
using ns13;
using ns15;
using ns16;
using ns17;
using ns6;
using ns8;
using Package;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3Workshop.Data;
using Sims3Workshop.Properties;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns12
{
	// Token: 0x020000FA RID: 250
	internal sealed class Class104 : Class102
	{
		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000A39 RID: 2617 RVA: 0x00087270 File Offset: 0x00085470
		// (set) Token: 0x06000A3A RID: 2618 RVA: 0x000066EC File Offset: 0x000048EC
		public bool Selected { get; set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000A3B RID: 2619 RVA: 0x00087288 File Offset: 0x00085488
		// (set) Token: 0x06000A3C RID: 2620 RVA: 0x000066F7 File Offset: 0x000048F7
		public bool Visible { get; set; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000A3D RID: 2621 RVA: 0x000872A0 File Offset: 0x000854A0
		// (set) Token: 0x06000A3E RID: 2622 RVA: 0x00006702 File Offset: 0x00004902
		public XmlDocument CurrentPreset { get; set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000A3F RID: 2623 RVA: 0x000872B8 File Offset: 0x000854B8
		// (set) Token: 0x06000A40 RID: 2624 RVA: 0x000872FC File Offset: 0x000854FC
		public Lod LODLevel
		{
			get
			{
				switch (this.int_0)
				{
				case 0:
					return Lod.UltraHigh;
				case 1:
					return Lod.High;
				case 2:
					return Lod.Medium;
				}
				return Lod.Low;
			}
			set
			{
				switch (value)
				{
				case Lod.High:
					this.int_0 = 1;
					break;
				case Lod.Medium:
					this.int_0 = 2;
					break;
				case Lod.Low:
					this.int_0 = 3;
					break;
				default:
					if (value == Lod.UltraHigh)
					{
						this.int_0 = 0;
					}
					break;
				}
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x0008734C File Offset: 0x0008554C
		// (set) Token: 0x06000A42 RID: 2626 RVA: 0x0000670D File Offset: 0x0000490D
		private Texture _emptyTexture { get; set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x00087364 File Offset: 0x00085564
		// (set) Token: 0x06000A44 RID: 2628 RVA: 0x00006718 File Offset: 0x00004918
		private Texture _bodyTexture { get; set; }

		// Token: 0x06000A45 RID: 2629 RVA: 0x00006723 File Offset: 0x00004923
		public Class104(WorkshopProject project, CASP casp, Lod lodLevel)
		{
			this.LODLevel = lodLevel;
			this.Selected = false;
			this.Visible = true;
			this.project = project;
			this.casp = casp;
			this.list_10 = new List<Class104.Class110>();
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00006762 File Offset: 0x00004962
		public override void imethod_6(Device device_0)
		{
			this.method_3(device_0);
			this.method_4(device_0);
			this.imethod_7(device_0);
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0008737C File Offset: 0x0008557C
		private void method_3(Device device_0)
		{
			this._emptyTexture = new Texture(device_0, 1024, 1024, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
			Bitmap bitmap = new Bitmap(1024, 1024);
			Graphics.FromImage(bitmap).FillRectangle(new SolidBrush(Settings.Default.SkinColor), new Rectangle(0, 0, 1024, 1024));
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, ImageFormat.Bmp);
				memoryStream.Position = 0L;
				this._bodyTexture = Texture.FromStream(device_0, memoryStream, Usage.None, Pool.Managed);
			}
			bitmap.Dispose();
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x0000677B File Offset: 0x0000497B
		private void method_4(Device device_0)
		{
			this.interface3_0 = new Class27(new Size(1024, 1024));
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x00087434 File Offset: 0x00085634
		public override void imethod_7(Device device_0)
		{
			foreach (Class104.Class110 @class in this.list_10)
			{
				@class.method_4();
			}
			this.list_10.Clear();
			Class104.Class110 class2 = this.method_19(device_0, this.casp, true);
			this.method_5(class2, device_0);
			this.list_10.Add(class2);
			this.imethod_11(0);
			this.method_17();
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x000874C4 File Offset: 0x000856C4
		private void method_5(Class104.Class110 class110_0, Device device_0)
		{
			CASP.AgeGender ageGender_ = CASP.AgeGender.None;
			CASP.AgeGender ageGender_2 = CASP.AgeGender.None;
			if ((this.casp.ageFlags & 4096U) != 0U && (this.casp.ageFlags & 8192U) != 0U)
			{
				ageGender_ = ((new Random((int)DateTime.Now.Ticks).Next(0, 2) == 1) ? CASP.AgeGender.Male : CASP.AgeGender.Female);
			}
			List<CASP.AgeGender> list = new List<CASP.AgeGender>();
			if ((this.casp.ageFlags & 1U) != 0U)
			{
				list.Add(CASP.AgeGender.Baby);
			}
			if ((this.casp.ageFlags & 2U) != 0U)
			{
				list.Add(CASP.AgeGender.Toddler);
			}
			if ((this.casp.ageFlags & 4U) != 0U)
			{
				list.Add(CASP.AgeGender.Child);
			}
			if ((this.casp.ageFlags & 8U) != 0U)
			{
				list.Add(CASP.AgeGender.Teen);
			}
			if ((this.casp.ageFlags & 16U) != 0U)
			{
				list.Add(CASP.AgeGender.YoungAdult);
			}
			if ((this.casp.ageFlags & 32U) != 0U)
			{
				list.Add(CASP.AgeGender.Adult);
			}
			if ((this.casp.ageFlags & 64U) != 0U)
			{
				list.Add(CASP.AgeGender.Elder);
			}
			if (list.Count > 1)
			{
				ageGender_2 = list[new Random((int)DateTime.Now.Ticks).Next(0, list.Count - 1)];
			}
			if ((this.casp.typeFlags & 16U) == 16U)
			{
				try
				{
					CASP casp = this.method_7(this.casp, ageGender_, ageGender_2);
					if (casp != null)
					{
						Class104.Class110 @class = this.method_19(device_0, casp, false);
						@class.IsBaseMesh = false;
						@class.IsFace = false;
						this.list_10.Add(@class);
						@class.method_0(this.interface3_0, (casp.Documents.Count > 0) ? casp.Documents[0] : null);
						CASP casp2 = this.method_8(casp, ageGender_, ageGender_2);
						if (casp2 != null)
						{
							Class104.Class110 class2 = this.method_19(device_0, casp2, false);
							class2.IsBaseMesh = false;
							class2.IsFace = false;
							this.list_10.Add(class2);
							class2.method_0(this.interface3_0, (casp2.Documents.Count > 0) ? casp2.Documents[0] : null);
						}
						CASP casp3 = this.method_6(casp, ageGender_, ageGender_2);
						if (casp3 != null)
						{
							Class104.Class110 class3 = this.method_19(device_0, casp3, false);
							class3.IsBaseMesh = false;
							class3.IsFace = false;
							this.list_10.Add(class3);
							class3.method_0(this.interface3_0, (casp3.Documents.Count > 0) ? casp3.Documents[0] : null);
						}
					}
					CASP casp4 = this.method_11(this.casp, ageGender_, ageGender_2);
					if (casp4 != null)
					{
						Class104.Class110 class4 = this.method_19(device_0, casp4, false);
						class4.IsBaseMesh = false;
						class4.IsFace = false;
						this.list_10.Add(class4);
						class4.method_0(this.interface3_0, (casp4.Documents.Count > 0) ? casp4.Documents[0] : null);
					}
					CASP casp5 = this.method_10(this.casp, ageGender_, ageGender_2);
					if (casp5 != null)
					{
						Class104.Class110 class5 = this.method_19(device_0, casp5, false);
						class5.IsBaseMesh = false;
						class5.IsFace = false;
						this.list_10.Add(class5);
						class5.method_0(this.interface3_0, (casp5.Documents.Count > 0) ? casp5.Documents[0] : null);
					}
					CASP casp6 = this.method_9(this.casp, ageGender_, ageGender_2);
					if (casp6 != null)
					{
						Class104.Class110 class6 = this.method_19(device_0, casp6, false);
						class6.IsBaseMesh = false;
						class6.IsFace = false;
						this.list_10.Add(class6);
						class6.method_0(this.interface3_0, (casp6.Documents.Count > 0) ? casp6.Documents[0] : null);
					}
				}
				catch (Exception)
				{
				}
			}
			if ((this.casp.typeFlags & 4U) == 4U)
			{
				try
				{
					CASP casp7 = this.method_7(this.casp, ageGender_, ageGender_2);
					if (casp7 != null)
					{
						Class104.Class110 class7 = this.method_19(device_0, casp7, false);
						class7.IsBaseMesh = false;
						class7.IsFace = false;
						this.list_10.Add(class7);
						class7.method_0(this.interface3_0, (casp7.Documents.Count > 0) ? casp7.Documents[0] : null);
						CASP casp8 = this.method_8(casp7, ageGender_, ageGender_2);
						if (casp8 != null)
						{
							Class104.Class110 class8 = this.method_19(device_0, casp8, false);
							class8.IsBaseMesh = false;
							class8.IsFace = false;
							this.list_10.Add(class8);
							class8.method_0(this.interface3_0, (casp8.Documents.Count > 0) ? casp8.Documents[0] : null);
						}
						CASP casp9 = this.method_6(casp7, ageGender_, ageGender_2);
						if (casp9 != null)
						{
							Class104.Class110 class9 = this.method_19(device_0, casp9, false);
							class9.IsBaseMesh = false;
							class9.IsFace = false;
							this.list_10.Add(class9);
							class9.method_0(this.interface3_0, (casp9.Documents.Count > 0) ? casp9.Documents[0] : null);
						}
					}
					CASP casp10 = this.method_11(this.casp, ageGender_, ageGender_2);
					if (casp10 != null)
					{
						Class104.Class110 class10 = this.method_19(device_0, casp10, false);
						class10.IsBaseMesh = false;
						class10.IsFace = true;
						class110_0.FaceMesh = class10;
						this.list_10.Add(class10);
						class10.method_0(this.interface3_0, (casp10.Documents.Count > 0) ? casp10.Documents[0] : null);
					}
					CASP casp11 = this.method_10(this.casp, ageGender_, ageGender_2);
					if (casp11 != null)
					{
						Class104.Class110 class11 = this.method_19(device_0, casp11, false);
						class11.IsBaseMesh = false;
						class11.IsFace = false;
						this.list_10.Add(class11);
						class11.method_0(this.interface3_0, (casp11.Documents.Count > 0) ? casp11.Documents[0] : null);
					}
					CASP casp12 = this.method_9(this.casp, ageGender_, ageGender_2);
					if (casp12 != null)
					{
						Class104.Class110 class12 = this.method_19(device_0, casp12, false);
						class12.IsBaseMesh = false;
						class12.IsFace = false;
						this.list_10.Add(class12);
						class12.method_0(this.interface3_0, (casp12.Documents.Count > 0) ? casp12.Documents[0] : null);
					}
				}
				catch (Exception)
				{
				}
			}
			if ((this.casp.typeFlags & 1U) == 1U)
			{
				try
				{
					CASP casp13 = this.method_7(this.casp, ageGender_, ageGender_2);
					if (casp13 != null)
					{
						Class104.Class110 class13 = this.method_19(device_0, casp13, false);
						class13.IsBaseMesh = false;
						class13.IsFace = false;
						this.list_10.Add(class13);
						class13.method_0(this.interface3_0, (casp13.Documents.Count > 0) ? casp13.Documents[0] : null);
						CASP casp14 = this.method_8(casp13, ageGender_, ageGender_2);
						if (casp14 != null)
						{
							Class104.Class110 class14 = this.method_19(device_0, casp14, false);
							class14.IsBaseMesh = false;
							class14.IsFace = false;
							this.list_10.Add(class14);
							class14.method_0(this.interface3_0, (casp14.Documents.Count > 0) ? casp14.Documents[0] : null);
						}
						CASP casp15 = this.method_6(casp13, ageGender_, ageGender_2);
						if (casp15 != null)
						{
							Class104.Class110 class15 = this.method_19(device_0, casp15, false);
							class15.IsBaseMesh = false;
							class15.IsFace = false;
							this.list_10.Add(class15);
							class15.method_0(this.interface3_0, (casp15.Documents.Count > 0) ? casp15.Documents[0] : null);
						}
					}
					CASP casp16 = this.method_11(this.casp, ageGender_, ageGender_2);
					if (casp16 != null)
					{
						Class104.Class110 class16 = this.method_19(device_0, casp16, false);
						class16.IsBaseMesh = false;
						class16.IsFace = false;
						this.list_10.Add(class16);
						class16.method_0(this.interface3_0, (casp16.Documents.Count > 0) ? casp16.Documents[0] : null);
					}
					CASP casp17 = this.method_10(this.casp, ageGender_, ageGender_2);
					if (casp17 != null)
					{
						Class104.Class110 class17 = this.method_19(device_0, casp17, false);
						class17.IsBaseMesh = false;
						class17.IsFace = false;
						this.list_10.Add(class17);
						class17.method_0(this.interface3_0, (casp17.Documents.Count > 0) ? casp17.Documents[0] : null);
					}
				}
				catch (Exception)
				{
				}
			}
			if ((this.casp.typeFlags & 8U) == 8U)
			{
				if ((this.casp.ageFlags & 52992U) != 0U)
				{
					if ((this.casp.ageFlags & 52992U) != 256U)
					{
						return;
					}
				}
				try
				{
					if (this.casp.clothingType == 5U)
					{
						CASP casp18 = this.method_7(this.casp, ageGender_, ageGender_2);
						if (casp18 != null)
						{
							Class104.Class110 class18 = this.method_19(device_0, casp18, false);
							class18.IsBaseMesh = false;
							class18.IsFace = false;
							this.list_10.Add(class18);
							class18.method_0(this.interface3_0, (casp18.Documents.Count > 0) ? casp18.Documents[0] : null);
						}
					}
					else if (this.casp.clothingType == 6U)
					{
						CASP casp19 = this.method_8(this.casp, ageGender_, ageGender_2);
						if (casp19 != null)
						{
							Class104.Class110 class19 = this.method_19(device_0, casp19, false);
							class19.IsBaseMesh = false;
							class19.IsFace = false;
							this.list_10.Add(class19);
							class19.method_0(this.interface3_0, (casp19.Documents.Count > 0) ? casp19.Documents[0] : null);
						}
					}
					else if (this.casp.clothingType == 7U)
					{
						CASP casp20 = this.method_8(this.casp, ageGender_, ageGender_2);
						if (casp20 != null)
						{
							Class104.Class110 class20 = this.method_19(device_0, casp20, false);
							class20.IsBaseMesh = false;
							class20.IsFace = false;
							this.list_10.Add(class20);
							class20.method_0(this.interface3_0, (casp20.Documents.Count > 0) ? casp20.Documents[0] : null);
						}
						CASP casp21 = this.method_7(this.casp, ageGender_, ageGender_2);
						if (casp21 != null)
						{
							Class104.Class110 class21 = this.method_19(device_0, casp21, false);
							class21.IsBaseMesh = false;
							class21.IsFace = false;
							this.list_10.Add(class21);
							class21.method_0(this.interface3_0, (casp21.Documents.Count > 0) ? casp21.Documents[0] : null);
						}
					}
					else if (this.casp.clothingType == 33U)
					{
						CASP casp22 = this.method_8(this.casp, ageGender_, ageGender_2);
						if (casp22 != null)
						{
							Class104.Class110 class22 = this.method_19(device_0, casp22, false);
							class22.IsBaseMesh = false;
							class22.IsFace = false;
							this.list_10.Add(class22);
							class22.method_0(this.interface3_0, (casp22.Documents.Count > 0) ? casp22.Documents[0] : null);
						}
						CASP casp23 = this.method_7(this.casp, ageGender_, ageGender_2);
						if (casp23 != null)
						{
							Class104.Class110 class23 = this.method_19(device_0, casp23, false);
							class23.IsBaseMesh = false;
							class23.IsFace = false;
							this.list_10.Add(class23);
							class23.method_0(this.interface3_0, (casp23.Documents.Count > 0) ? casp23.Documents[0] : null);
						}
					}
					CASP casp24 = this.method_6(this.casp, ageGender_, ageGender_2);
					if (casp24 != null && this.casp.clothingType != 7U)
					{
						Class104.Class110 class24 = this.method_19(device_0, casp24, false);
						class24.IsBaseMesh = false;
						class24.IsFace = false;
						this.list_10.Add(class24);
						class24.method_0(this.interface3_0, (casp24.Documents.Count > 0) ? casp24.Documents[0] : null);
					}
					CASP casp25 = this.method_11(this.casp, ageGender_, ageGender_2);
					if (casp25 != null)
					{
						Class104.Class110 class25 = this.method_19(device_0, casp25, false);
						class25.IsBaseMesh = false;
						class25.IsFace = false;
						this.list_10.Add(class25);
						class25.method_0(this.interface3_0, (casp25.Documents.Count > 0) ? casp25.Documents[0] : null);
					}
					CASP casp26 = this.method_10(this.casp, ageGender_, ageGender_2);
					if (casp26 != null)
					{
						Class104.Class110 class26 = this.method_19(device_0, casp26, false);
						class26.IsBaseMesh = false;
						class26.IsFace = false;
						this.list_10.Add(class26);
						class26.method_0(this.interface3_0, (casp26.Documents.Count > 0) ? casp26.Documents[0] : null);
					}
					CASP casp27 = this.method_9(this.casp, ageGender_, ageGender_2);
					if (casp27 != null)
					{
						Class104.Class110 class27 = this.method_19(device_0, casp27, false);
						class27.IsBaseMesh = false;
						class27.IsFace = false;
						this.list_10.Add(class27);
						class27.method_0(this.interface3_0, (casp27.Documents.Count > 0) ? casp27.Documents[0] : null);
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x00088260 File Offset: 0x00086460
		// (set) Token: 0x06000A4C RID: 2636 RVA: 0x00006799 File Offset: 0x00004999
		public List<string> PossibleShoes { get; set; }

		// Token: 0x06000A4D RID: 2637 RVA: 0x00088278 File Offset: 0x00086478
		private CASP method_6(CASP casp_0, CASP.AgeGender ageGender_0, CASP.AgeGender ageGender_1)
		{
			if (this.PossibleShoes == null)
			{
				this.PossibleShoes = new List<string>();
				List<DBPFEntry> list = Class76.smethod_24(new ResKey(DBPFType.CASP));
				foreach (DBPFEntry dbpfentry in list)
				{
					CASP casp = (CASP)dbpfentry;
					if (casp.clothingType == 7U && this.method_13(casp_0, casp) && (ageGender_0 == CASP.AgeGender.None || (casp.ageFlags & (uint)ageGender_0) != 0U) && (ageGender_1 == CASP.AgeGender.None || (casp.ageFlags & (uint)ageGender_1) != 0U) && (casp_0.clothingType != 33U || casp.str1.ToLower().Contains("nude")))
					{
						this.PossibleShoes.Add(casp.GenerateResKey());
						casp.Dispose();
					}
				}
			}
			CASP result;
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("shoesPart"))
			{
				result = (Class76.smethod_26(new ResKey(this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["shoesPart"])) as CASP);
			}
			else if (this.PossibleShoes.Count == 0)
			{
				result = null;
			}
			else
			{
				Random random = new Random((int)DateTime.Now.Ticks);
				int index = random.Next(0, this.PossibleShoes.Count - 1);
				string text = this.PossibleShoes[index];
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("shoesPart", text);
				result = (Class76.smethod_26(new ResKey(text)) as CASP);
			}
			return result;
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000A4E RID: 2638 RVA: 0x00088408 File Offset: 0x00086608
		// (set) Token: 0x06000A4F RID: 2639 RVA: 0x000067A4 File Offset: 0x000049A4
		public List<string> PossibleBottoms { get; set; }

		// Token: 0x06000A50 RID: 2640 RVA: 0x00088420 File Offset: 0x00086620
		private CASP method_7(CASP casp_0, CASP.AgeGender ageGender_0, CASP.AgeGender ageGender_1)
		{
			if (this.PossibleBottoms == null)
			{
				this.PossibleBottoms = new List<string>();
				List<DBPFEntry> list = Class76.smethod_24(new ResKey(DBPFType.CASP));
				foreach (DBPFEntry dbpfentry in list)
				{
					CASP casp = (CASP)dbpfentry;
					if (casp.clothingType == 6U && this.method_13(casp_0, casp) && (ageGender_0 == CASP.AgeGender.None || (casp.ageFlags & (uint)ageGender_0) != 0U) && (ageGender_1 == CASP.AgeGender.None || (casp.ageFlags & (uint)ageGender_1) != 0U) && (casp_0.clothingType != 33U || casp.str1.ToLower().Contains("nude")))
					{
						this.PossibleBottoms.Add(casp.GenerateResKey());
						casp.Dispose();
					}
				}
			}
			CASP result;
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("bottomPart"))
			{
				result = (Class76.smethod_26(new ResKey(this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["bottomPart"])) as CASP);
			}
			else if (this.PossibleBottoms.Count == 0)
			{
				result = null;
			}
			else
			{
				Random random = new Random((int)DateTime.Now.Ticks);
				int index = random.Next(0, this.PossibleBottoms.Count - 1);
				string text = this.PossibleBottoms[index];
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("bottomPart", text);
				result = (Class76.smethod_26(new ResKey(text)) as CASP);
			}
			return result;
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000A51 RID: 2641 RVA: 0x000885B0 File Offset: 0x000867B0
		// (set) Token: 0x06000A52 RID: 2642 RVA: 0x000067AF File Offset: 0x000049AF
		public List<string> PossibleTops { get; set; }

		// Token: 0x06000A53 RID: 2643 RVA: 0x000885C8 File Offset: 0x000867C8
		private CASP method_8(CASP casp_0, CASP.AgeGender ageGender_0, CASP.AgeGender ageGender_1)
		{
			if (this.PossibleTops == null)
			{
				this.PossibleTops = new List<string>();
				List<DBPFEntry> list = Class76.smethod_24(new ResKey(DBPFType.CASP));
				foreach (DBPFEntry dbpfentry in list)
				{
					CASP casp = (CASP)dbpfentry;
					if (casp.clothingType == 5U && this.method_13(casp_0, casp) && (ageGender_0 == CASP.AgeGender.None || (casp.ageFlags & (uint)ageGender_0) != 0U) && (ageGender_1 == CASP.AgeGender.None || (casp.ageFlags & (uint)ageGender_1) != 0U) && casp_0.clothingType != 33U)
					{
						this.PossibleTops.Add(casp.GenerateResKey());
						casp.Dispose();
					}
				}
			}
			CASP result;
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("topPart"))
			{
				result = (Class76.smethod_26(new ResKey(this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["topPart"])) as CASP);
			}
			else if (this.PossibleTops.Count == 0)
			{
				result = null;
			}
			else
			{
				Random random = new Random((int)DateTime.Now.Ticks);
				int index = random.Next(0, this.PossibleTops.Count - 1);
				string text = this.PossibleTops[index];
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("topPart", text);
				result = (Class76.smethod_26(new ResKey(text)) as CASP);
			}
			return result;
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x00088744 File Offset: 0x00086944
		private CASP method_9(CASP casp_0, CASP.AgeGender ageGender_0, CASP.AgeGender ageGender_1)
		{
			CASP result;
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("hairPart"))
			{
				result = (Class76.smethod_26(new ResKey(this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["hairPart"])) as CASP);
			}
			else
			{
				string text = "Hair";
				if ((casp_0.ageFlags & 8192U) != 0U && ageGender_0 == CASP.AgeGender.None)
				{
					text = "f" + text + "Bun";
				}
				else if ((casp_0.ageFlags & 4096U) != 0U && ageGender_0 == CASP.AgeGender.None)
				{
					text = "m" + text + "ShortMessy";
				}
				else if ((casp_0.ageFlags & 4096U) != 0U && ageGender_0 == CASP.AgeGender.Male)
				{
					text = "m" + text + "ShortMessy";
				}
				else if ((casp_0.ageFlags & 4096U) != 0U && ageGender_0 == CASP.AgeGender.Female)
				{
					text = "f" + text + "Bun";
				}
				if (ageGender_1 == CASP.AgeGender.None)
				{
					if ((casp_0.ageFlags & 32U) == 0U && (casp_0.ageFlags & 16U) == 0U)
					{
						if ((casp_0.ageFlags & 64U) != 0U)
						{
							text = "e" + text;
						}
						else if ((casp_0.ageFlags & 8U) != 0U)
						{
							text = "a" + text;
						}
						else if ((casp_0.ageFlags & 4U) != 0U && (casp_0.ageFlags & 8192U) != 0U)
						{
							text = "cfHairPigtailsMid";
						}
						else if ((casp_0.ageFlags & 4U) != 0U && (casp_0.ageFlags & 4096U) != 0U)
						{
							text = "cmHairShortMessy";
						}
					}
					else
					{
						text = "a" + text;
					}
				}
				else if (ageGender_1 == CASP.AgeGender.Elder)
				{
					text = "a" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.Adult)
				{
					text = "a" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.YoungAdult)
				{
					text = "a" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.Teen)
				{
					text = "a" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.Child && (casp_0.ageFlags & 4096U) != 0U)
				{
					text = "cmHairShortMessy";
				}
				else if (ageGender_1 == CASP.AgeGender.Child && (casp_0.ageFlags & 8192U) != 0U)
				{
					text = "cfHairPigtailsMid";
				}
				CASP casp = this.method_12(text, 1U);
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("hairPart", casp.GenerateResKey());
				result = casp;
			}
			return result;
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0008898C File Offset: 0x00086B8C
		private CASP method_10(CASP casp_0, CASP.AgeGender ageGender_0, CASP.AgeGender ageGender_1)
		{
			CASP result;
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("scalpPart"))
			{
				result = (Class76.smethod_26(new ResKey(this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["scalpPart"])) as CASP);
			}
			else
			{
				string text = "Scalp";
				if ((casp_0.ageFlags & 8192U) != 0U && ageGender_0 == CASP.AgeGender.None)
				{
					text = "f" + text;
				}
				else if ((casp_0.ageFlags & 4096U) != 0U && ageGender_0 == CASP.AgeGender.None)
				{
					text = "m" + text;
				}
				else if ((casp_0.ageFlags & 4096U) != 0U && ageGender_0 == CASP.AgeGender.Male)
				{
					text = "m" + text;
				}
				else if ((casp_0.ageFlags & 4096U) != 0U && ageGender_0 == CASP.AgeGender.Female)
				{
					text = "f" + text;
				}
				if (ageGender_1 == CASP.AgeGender.None)
				{
					if ((casp_0.ageFlags & 32U) == 0U && (casp_0.ageFlags & 16U) == 0U)
					{
						if ((casp_0.ageFlags & 64U) != 0U)
						{
							text = "e" + text;
						}
						else if ((casp_0.ageFlags & 8U) != 0U)
						{
							text = "t" + text;
						}
						else if ((casp_0.ageFlags & 4U) != 0U)
						{
							text = "cuScalp";
						}
						else if ((casp_0.ageFlags & 2U) != 0U)
						{
							text = "puScalp";
						}
					}
					else
					{
						text = "a" + text;
					}
				}
				else if (ageGender_1 == CASP.AgeGender.Elder)
				{
					text = "a" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.Adult)
				{
					text = "a" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.YoungAdult)
				{
					text = "e" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.Teen)
				{
					text = "t" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.Child)
				{
					text = "cuScalp";
				}
				else if (ageGender_1 == CASP.AgeGender.Toddler)
				{
					text = "puScalp";
				}
				CASP casp = this.method_12(text, 2U);
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("scalpPart", casp.GenerateResKey());
				result = casp;
			}
			return result;
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00088B78 File Offset: 0x00086D78
		private CASP method_11(CASP casp_0, CASP.AgeGender ageGender_0, CASP.AgeGender ageGender_1)
		{
			CASP result;
			if (this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("facePart"))
			{
				result = (Class76.smethod_26(new ResKey(this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["facePart"])) as CASP);
			}
			else
			{
				string text = "Face";
				if ((casp_0.ageFlags & 8192U) != 0U && ageGender_0 == CASP.AgeGender.None)
				{
					text = "f" + text;
				}
				else if ((casp_0.ageFlags & 4096U) != 0U && ageGender_0 == CASP.AgeGender.None)
				{
					text = "m" + text;
				}
				else if ((casp_0.ageFlags & 4096U) != 0U && ageGender_0 == CASP.AgeGender.Male)
				{
					text = "m" + text;
				}
				else if ((casp_0.ageFlags & 4096U) != 0U && ageGender_0 == CASP.AgeGender.Female)
				{
					text = "f" + text;
				}
				if (ageGender_1 == CASP.AgeGender.None)
				{
					if ((casp_0.ageFlags & 32U) != 0U)
					{
						text = "a" + text;
					}
					else if ((casp_0.ageFlags & 16U) != 0U)
					{
						text = "y" + text;
					}
					else if ((casp_0.ageFlags & 64U) != 0U)
					{
						text = "e" + text;
					}
					else if ((casp_0.ageFlags & 8U) != 0U)
					{
						text = "t" + text;
					}
					else if ((casp_0.ageFlags & 4U) != 0U)
					{
						text = "cuFace";
					}
					else if ((casp_0.ageFlags & 2U) != 0U)
					{
						text = "puFace";
					}
				}
				else if (ageGender_1 == CASP.AgeGender.Elder)
				{
					text = "e" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.Adult)
				{
					text = "a" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.YoungAdult)
				{
					text = "y" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.Teen)
				{
					text = "t" + text;
				}
				else if (ageGender_1 == CASP.AgeGender.Child)
				{
					text = "cuFace";
				}
				else if (ageGender_1 == CASP.AgeGender.Toddler)
				{
					text = "puFace";
				}
				CASP casp = this.method_12(text, 4U);
				this.project.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("facePart", casp.GenerateResKey());
				result = casp;
			}
			return result;
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x00088D74 File Offset: 0x00086F74
		private CASP method_12(string string_0, uint uint_0)
		{
			List<ResKey> list = Class76.smethod_19(new ResKey(DBPFType.CASP));
			CASP result;
			foreach (ResKey resKey_ in list)
			{
				try
				{
					CASP casp = Class76.smethod_26(resKey_) as CASP;
					if ((casp.typeFlags & uint_0) != 0U && casp.str1.ToLower().Equals(string_0.ToLower()))
					{
						result = casp;
						goto IL_89;
					}
				}
				catch (Exception ex)
				{
					Class132.mainForm.SetStatus(ex.Message);
				}
			}
			return null;
			IL_89:
			return result;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x00088E30 File Offset: 0x00087030
		private bool method_13(CASP casp_0, CASP casp_1)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if ((casp_0.ageFlags & 4096U) != 0U && (casp_1.ageFlags & 4096U) != 0U)
			{
				num++;
			}
			if ((casp_0.ageFlags & 8192U) != 0U && (casp_1.ageFlags & 8192U) != 0U)
			{
				num++;
			}
			if ((casp_0.ageFlags & 1U) != 0U && (casp_1.ageFlags & 1U) != 0U)
			{
				num2++;
			}
			if ((casp_0.ageFlags & 2U) != 0U && (casp_1.ageFlags & 2U) != 0U)
			{
				num2++;
			}
			if ((casp_0.ageFlags & 4U) != 0U && (casp_1.ageFlags & 4U) != 0U)
			{
				num2++;
			}
			if ((casp_0.ageFlags & 8U) != 0U && (casp_1.ageFlags & 8U) != 0U)
			{
				num2++;
			}
			if ((casp_0.ageFlags & 16U) != 0U && (casp_1.ageFlags & 16U) != 0U)
			{
				num2++;
			}
			if ((casp_0.ageFlags & 32U) != 0U && (casp_1.ageFlags & 32U) != 0U)
			{
				num2++;
			}
			if ((casp_0.ageFlags & 64U) != 0U && (casp_1.ageFlags & 64U) != 0U)
			{
				num2++;
			}
			if ((casp_0.clothingCategoryFlags & 8U) != 0U && (casp_1.clothingCategoryFlags & 8U) != 0U)
			{
				num3++;
			}
			if ((casp_0.clothingCategoryFlags & 16U) != 0U && (casp_1.clothingCategoryFlags & 16U) != 0U)
			{
				num3++;
			}
			if ((casp_0.clothingCategoryFlags & 1U) != 0U && (casp_1.clothingCategoryFlags & 1U) != 0U)
			{
				num3++;
			}
			if ((casp_0.clothingCategoryFlags & 32U) != 0U && (casp_1.clothingCategoryFlags & 32U) != 0U)
			{
				num3++;
			}
			if ((casp_0.clothingCategoryFlags & 4U) != 0U && (casp_1.clothingCategoryFlags & 4U) != 0U)
			{
				num3++;
			}
			if ((casp_0.clothingCategoryFlags & 256U) != 0U && (casp_1.clothingCategoryFlags & 256U) != 0U)
			{
				num3++;
			}
			if ((casp_0.clothingCategoryFlags & 2U) != 0U && (casp_1.clothingCategoryFlags & 2U) != 0U)
			{
				num3++;
			}
			bool result;
			if (num > 0 && num2 > 0)
			{
				result = (num3 > 0);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x000067BA File Offset: 0x000049BA
		public void method_14(float float_3)
		{
			this.float_0 = float_3;
			this.method_18();
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x000067CB File Offset: 0x000049CB
		public void method_15(float float_3)
		{
			this.float_1 = float_3;
			this.method_18();
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x000067DC File Offset: 0x000049DC
		public void method_16(float float_3)
		{
			this.float_2 = float_3;
			this.method_18();
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x00088FFC File Offset: 0x000871FC
		private void method_17()
		{
			if (this.list_11 == null)
			{
				this.list_11 = new List<float[,]>();
				for (int i = 0; i < 50000; i++)
				{
					this.list_11.Add(new float[3, 4]);
				}
			}
			for (int j = 0; j < this.list_11.Count; j++)
			{
				float[,] array = this.list_11[j];
				int num = 0;
				int num2 = 0;
				float[,] array2 = this.list_11[j];
				int num3 = 0;
				int num4 = 1;
				float[,] array3 = this.list_11[j];
				int num5 = 0;
				int num6 = 2;
				float[,] array4 = this.list_11[j];
				int num7 = 0;
				int num8 = 3;
				float num9 = 0f;
				float num10 = 0f;
				array4[num7, num8] = num9;
				float num11 = num10;
				float num12 = 0f;
				array3[num5, num6] = num11;
				float num13 = num12;
				float num14 = 0f;
				array2[num3, num4] = num13;
				array[num, num2] = num14;
				float[,] array5 = this.list_11[j];
				int num15 = 1;
				int num16 = 0;
				float[,] array6 = this.list_11[j];
				int num17 = 1;
				int num18 = 1;
				float[,] array7 = this.list_11[j];
				int num19 = 1;
				int num20 = 2;
				float[,] array8 = this.list_11[j];
				int num21 = 1;
				int num22 = 3;
				float num23 = 0f;
				float num24 = 0f;
				array8[num21, num22] = num23;
				float num25 = num24;
				float num26 = 0f;
				array7[num19, num20] = num25;
				float num27 = num26;
				float num28 = 0f;
				array6[num17, num18] = num27;
				array5[num15, num16] = num28;
				float[,] array9 = this.list_11[j];
				int num29 = 2;
				int num30 = 0;
				float[,] array10 = this.list_11[j];
				int num31 = 2;
				int num32 = 1;
				float[,] array11 = this.list_11[j];
				int num33 = 2;
				int num34 = 2;
				float[,] array12 = this.list_11[j];
				int num35 = 2;
				int num36 = 3;
				float num37 = 0f;
				float num38 = 0f;
				array12[num35, num36] = num37;
				float num39 = num38;
				float num40 = 0f;
				array11[num33, num34] = num39;
				float num41 = num40;
				float num42 = 0f;
				array10[num31, num32] = num41;
				array9[num29, num30] = num42;
				this.list_11[j][0, 3] = 0f;
				this.list_11[j][1, 3] = 0f;
				this.list_11[j][2, 3] = 0f;
			}
			foreach (Class104.Class110 @class in this.list_10)
			{
				if (@class.FatBlend != null)
				{
					foreach (BGEO.S1SubEntry s1SubEntry in @class.FatBlend.S1Entries[0].SubEntries)
					{
						foreach (BGEO.BlendVertex blendVertex in s1SubEntry.Vertices)
						{
							if (blendVertex.HasPosition && this.list_11[blendVertex.VertexID][0, 3] == 0f)
							{
								this.list_11[blendVertex.VertexID][0, 0] = blendVertex.Position[0];
								this.list_11[blendVertex.VertexID][0, 1] = blendVertex.Position[1];
								this.list_11[blendVertex.VertexID][0, 2] = blendVertex.Position[2];
								this.list_11[blendVertex.VertexID][0, 3] = 1f;
							}
						}
					}
				}
				if (@class.FitBlend != null)
				{
					foreach (BGEO.S1SubEntry s1SubEntry2 in @class.FitBlend.S1Entries[0].SubEntries)
					{
						foreach (BGEO.BlendVertex blendVertex2 in s1SubEntry2.Vertices)
						{
							if (blendVertex2.HasPosition && this.list_11[blendVertex2.VertexID][1, 3] == 0f)
							{
								this.list_11[blendVertex2.VertexID][1, 0] = blendVertex2.Position[0];
								this.list_11[blendVertex2.VertexID][1, 1] = blendVertex2.Position[1];
								this.list_11[blendVertex2.VertexID][1, 2] = blendVertex2.Position[2];
								this.list_11[blendVertex2.VertexID][1, 3] = 1f;
							}
						}
					}
				}
				if (@class.ThinBlend != null)
				{
					foreach (BGEO.S1SubEntry s1SubEntry3 in @class.ThinBlend.S1Entries[0].SubEntries)
					{
						foreach (BGEO.BlendVertex blendVertex3 in s1SubEntry3.Vertices)
						{
							if (blendVertex3.HasPosition && this.list_11[blendVertex3.VertexID][2, 3] == 0f)
							{
								this.list_11[blendVertex3.VertexID][2, 0] = blendVertex3.Position[0];
								this.list_11[blendVertex3.VertexID][2, 1] = blendVertex3.Position[1];
								this.list_11[blendVertex3.VertexID][2, 2] = blendVertex3.Position[2];
								this.list_11[blendVertex3.VertexID][2, 3] = 1f;
							}
						}
					}
				}
			}
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x00089688 File Offset: 0x00087888
		private unsafe void method_18()
		{
			foreach (Class104.Class110 @class in this.list_10)
			{
				foreach (Class104.Class109 class2 in @class.Items)
				{
					DataStream dataStream = class2.VertexBuffer.Lock(0, 0, LockFlags.None);
					Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
					for (int i = 0; i < class2.VertexCount; i++)
					{
						int index = ptr[i].int_0;
						ptr[i].vector3_0 = Vector3.Zero;
						float[,] array = this.list_11[index];
						ptr[i].vector3_0 += new Vector3(this.list_11[index][0, 0], this.list_11[index][0, 1], this.list_11[index][0, 2]) * this.float_0;
						ptr[i].vector3_0 += new Vector3(this.list_11[index][1, 0], this.list_11[index][1, 1], this.list_11[index][1, 2]) * this.float_1;
						ptr[i].vector3_0 += new Vector3(this.list_11[index][2, 0], this.list_11[index][2, 1], this.list_11[index][2, 2]) * this.float_2;
					}
					class2.VertexBuffer.Unlock();
				}
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000A5E RID: 2654 RVA: 0x000898EC File Offset: 0x00087AEC
		public List<Class104.Class110> Containers
		{
			get
			{
				return this.list_10;
			}
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x000067ED File Offset: 0x000049ED
		public override void imethod_10(int int_3)
		{
			this.int_1 = int_3;
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x00002A71 File Offset: 0x00000C71
		public override void imethod_9(uint uint_0, Matrix matrix_0)
		{
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00089904 File Offset: 0x00087B04
		private Class104.Class110 method_19(Device device_0, CASP casp_0, bool bool_7)
		{
			Class104.Class110 @class = new Class104.Class110(device_0, casp_0);
			@class.IsBaseMesh = bool_7;
			IGTIndex igtindex = casp_0.igtIndex[(int)casp_0.vpxyIndex];
			this.method_20(device_0, @class, Class76.smethod_26(new ResKey(igtindex.Reskey)) as VisualProxy);
			return @class;
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x00089954 File Offset: 0x00087B54
		private void method_20(Device device_0, Class104.Class110 class110_0, VisualProxy visualProxy_0)
		{
			if (visualProxy_0 != null)
			{
				try
				{
					if ((this.casp.ageFlags & 256U) == 0U && (this.casp.ageFlags & 52992U) != 0U)
					{
						string text = "auRig";
						CASP.Species species = (CASP.Species)(this.casp.ageFlags & 52992U);
						CASP.Species species2 = species;
						if (species2 <= CASP.Species.Cat)
						{
							if (species2 != CASP.Species.Horse)
							{
								if (species2 == CASP.Species.Cat)
								{
									text = "acRig";
								}
							}
							else
							{
								text = "ahRig";
							}
						}
						else if (species2 != CASP.Species.Dog)
						{
							if (species2 != CASP.Species.Deer)
							{
								if (species2 == CASP.Species.Raccoon)
								{
									text = "arRig";
								}
							}
							else
							{
								text = "abRig";
							}
						}
						else
						{
							text = "adRig";
						}
						ResKey resKey_ = new ResKey("key:8EAF13DE:00000000:" + FNV64.GetHash(text).ToString("X16"));
						RIG rig = Class76.smethod_30(resKey_, false, false) as RIG;
						if (rig != null && !rig.Encrypted)
						{
							Class28 @class = class110_0.GrannyInfo = new Class28();
							@class.Skeletons = new Class34[]
							{
								new Class34()
							};
							Class34 class2 = @class.Skeletons[0];
							class2.Bones = new Class33[rig.Bones.Count];
							for (int i = 0; i < rig.Bones.Count; i++)
							{
								RIG.Bone bone = rig.Bones[i];
								Class33 class3 = new Class33();
								class2.Bones[i] = class3;
								class3.Sims3WorkshopSDK.Interfaces.IBone.Name = bone.BoneName;
								class3.NameHash = bone.BoneHash;
								class3.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex = bone.ParentIndex;
								class3.InverseMatrix = new float[16];
								class3.Transformation = new Class32();
								class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin = new float[]
								{
									bone.Position[0],
									bone.Position[1],
									bone.Position[2]
								};
								class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat = new float[]
								{
									bone.Quaternion[0],
									bone.Quaternion[1],
									bone.Quaternion[2],
									bone.Quaternion[3]
								};
								class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Scale = new float[]
								{
									bone.Scaling[0],
									bone.Scaling[1],
									bone.Scaling[2]
								};
								class2.HashedBones.Add(bone.BoneHash, class3);
							}
							for (int j = 0; j < class2.Bones.Length; j++)
							{
								Class33 class4 = class2.Bones[j];
								for (int k = 0; k < class2.Bones.Length; k++)
								{
									Class33 class5 = class2.Bones[k];
									if (class5.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex == j)
									{
										class4.ChildBones.Add(class5);
										class5.ParentBone = class4;
									}
								}
							}
							class2.Sims3WorkshopSDK.Interfaces.ISkeleton.Name = rig.SkeletonName;
						}
					}
					else
					{
						string text2 = "auRig";
						ResKey resKey_2 = new ResKey("key:8EAF13DF:00000000:" + FNV64.GetHash(text2).ToString("X16"));
						RIGRAW rigraw = Class76.smethod_26(resKey_2) as RIGRAW;
						if (rigraw != null)
						{
							class110_0.GrannyInfo = new Class28();
							byte[] data = rigraw.GetData();
							MemoryStream memoryStream = new MemoryStream(data);
							BinaryReader binaryReader = new BinaryReader(memoryStream);
							class110_0.GrannyInfo.Sims3WorkshopSDK.Interfaces.IRIG.Read(binaryReader);
							binaryReader.Close();
							memoryStream.Dispose();
							rigraw.Dispose();
						}
					}
				}
				catch (Exception)
				{
					class110_0.GrannyInfo = null;
				}
				foreach (RCOLItem rcolitem in visualProxy_0.Entries)
				{
					VPXY vpxy = (VPXY)rcolitem;
					foreach (TGIIndex tgiindex in vpxy.TGIIndex)
					{
						if (tgiindex.IsType(DBPFType.BONE))
						{
							DBPFEntry dbpfentry = Class132.mainForm.CurrentProject.Package.GetEntry(tgiindex);
							if (dbpfentry == null)
							{
								dbpfentry = Class76.smethod_26(new ResKey(tgiindex.AsString()));
							}
							class110_0.BoneFile = (dbpfentry as BONE);
						}
					}
					foreach (VPXY.VPXEntryEntry vpxentryEntry in vpxy.entries)
					{
						if (vpxentryEntry.type == 0 && ((int)vpxentryEntry.msIndex == this.int_0 || ((class110_0.Casp.clothingType & 4U & 6U) != 0U && this.int_0 == 0)))
						{
							foreach (int index in vpxentryEntry.index)
							{
								TGIIndex tgiindex2 = vpxy.TGIIndex[index];
								Geometry geometry_ = Class76.smethod_26(new ResKey(tgiindex2.Reskey)) as Geometry;
								this.method_22(device_0, class110_0, geometry_);
							}
							break;
						}
					}
				}
				int num = 0;
				foreach (uint index2 in this.casp.boneDeltaIndex)
				{
					IGTIndex igtindex = this.casp.igtIndex[(int)index2];
					BOND bond = Class76.smethod_26(new ResKey(igtindex.AsString())) as BOND;
					if (bond != null)
					{
						switch (num)
						{
						case 0:
							class110_0.BaseAdjust = bond;
							break;
						case 1:
							class110_0.FatAdjust = bond;
							break;
						case 2:
							class110_0.FitAdjust = bond;
							break;
						case 3:
							class110_0.ThinAdjust = bond;
							break;
						case 4:
							class110_0.SpecialAdjust = bond;
							break;
						}
					}
					num++;
				}
			}
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x00089FD4 File Offset: 0x000881D4
		private BGEO method_21(Class104.Enum17 enum17_0, CASP casp_0)
		{
			int index = -1;
			switch (enum17_0)
			{
			case Class104.Enum17.const_0:
				index = (int)casp_0.blendFatRef;
				break;
			case Class104.Enum17.const_1:
				index = (int)casp_0.blendFitRef;
				break;
			case Class104.Enum17.const_2:
				index = (int)casp_0.blendThinRef;
				break;
			case Class104.Enum17.const_3:
				index = (int)casp_0.blendSpecialRef;
				break;
			}
			IGTIndex igtindex = casp_0.igtIndex[index];
			FPRT fprt = Class76.smethod_26(new ResKey(igtindex.Reskey)) as FPRT;
			BGEO result;
			if (fprt == null)
			{
				result = null;
			}
			else
			{
				ResKey resKey_ = new ResKey(fprt.BGEO_Reskey);
				BGEO bgeo = Class76.smethod_26(resKey_) as BGEO;
				result = bgeo;
			}
			return result;
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0008A070 File Offset: 0x00088270
		private void method_22(Device device_0, Class104.Class110 class110_0, Geometry geometry_0)
		{
			class110_0.FatBlend = this.method_21(Class104.Enum17.const_0, class110_0.Casp);
			class110_0.FitBlend = this.method_21(Class104.Enum17.const_1, class110_0.Casp);
			class110_0.ThinBlend = this.method_21(Class104.Enum17.const_2, class110_0.Casp);
			class110_0.SpecialBlend = this.method_21(Class104.Enum17.const_3, class110_0.Casp);
			foreach (RCOLItem rcolitem in geometry_0.Entries)
			{
				GEOM geom = (GEOM)rcolitem;
				Class104.Class109 @class = new Class104.Class109(geom, class110_0);
				@class.VertexCount = geom.vertices.Count;
				@class.IBUFOffset = 0;
				@class.IBUFCount = geom.faces.Count;
				@class.Buffer = new Class112.Struct7[geom.vertices.Count];
				@class.Palette = new Matrix[geom.boneHashes.Count];
				if (@class.ColorPalette == null)
				{
					@class.ColorPalette = new Matrix[geom.boneHashes.Count];
				}
				for (int i = 0; i < @class.Palette.Length; i++)
				{
					@class.Palette[i] = Matrix.Identity;
				}
				@class.material_0 = default(Material);
				@class.material_0.Diffuse = Color.White;
				@class.material_0.Ambient = Settings.Default.AmbientLighting;
				@class.material_0.Specular = Color.FromArgb(255, 255, 255, 255);
				@class.material_0.Power = 10f;
				foreach (MATD.MATDEntry matdentry in geom.MATD.Entries)
				{
					if (matdentry.Type == MATD.MATDEntryType.DiffuseMap)
					{
						int index = matdentry.GetIntValue()[0];
						string key = geom.tgiIndex[index].AsString();
						DDS dds = Class76.smethod_26(new ResKey(key)) as DDS;
						if (dds != null)
						{
							MemoryStream memoryStream = new MemoryStream(dds.GetData());
							@class.texture_1 = Texture.FromStream(device_0, memoryStream);
							memoryStream.Dispose();
						}
					}
					if (matdentry.Type == MATD.MATDEntryType.NormalMap)
					{
						int index2 = matdentry.GetIntValue()[0];
						string key2 = geom.tgiIndex[index2].AsString();
						DDS dds2 = Class76.smethod_26(new ResKey(key2)) as DDS;
						if (dds2 != null)
						{
							MemoryStream memoryStream2 = new MemoryStream(dds2.GetData());
							@class.texture_2 = Texture.FromStream(device_0, memoryStream2);
							memoryStream2.Dispose();
						}
					}
					if (matdentry.Type == (MATD.MATDEntryType)2907867744U)
					{
						int index3 = matdentry.GetIntValue()[0];
						string key3 = geom.tgiIndex[index3].AsString();
						DDS dds3 = Class76.smethod_26(new ResKey(key3)) as DDS;
						if (dds3 != null)
						{
							MemoryStream memoryStream3 = new MemoryStream(dds3.GetData());
							@class.texture_0 = Texture.FromStream(device_0, memoryStream3);
							memoryStream3.Dispose();
						}
					}
				}
				Class112.Struct7[] array = new Class112.Struct7[geom.vertices.Count * 2];
				int color = Color.Yellow.ToArgb();
				int num = 0;
				Color.Green.ToArgb();
				int val = 0;
				int val2 = int.MaxValue;
				for (int j = 0; j < geom.vertices.Count; j++)
				{
					GEOM.GEOMVertex geomvertex = geom.vertices[j];
					@class.Buffer[j] = default(Class112.Struct7);
					@class.Buffer[j].position = new Vector3(geomvertex.posX, geomvertex.posY, geomvertex.posZ);
					@class.Buffer[j].normal = new Vector3(geomvertex.norX, geomvertex.norY, geomvertex.norZ);
					@class.Buffer[j].vector2_0 = new Vector2(geomvertex.tx, geomvertex.ty);
					@class.Buffer[j].uint_0 = (uint)(((int)geomvertex.boneAssignment[3] << 24) + ((int)geomvertex.boneAssignment[2] << 16) + ((int)geomvertex.boneAssignment[1] << 8) + (int)geomvertex.boneAssignment[0]);
					@class.Buffer[j].float_0 = geomvertex.boneWeights[0];
					@class.Buffer[j].float_1 = geomvertex.boneWeights[1];
					@class.Buffer[j].float_2 = geomvertex.boneWeights[2];
					@class.Buffer[j].float_3 = geomvertex.boneWeights[3];
					@class.Buffer[j].int_0 = geomvertex.vertexId;
					if (geomvertex.tagVal[3] == 0 && geomvertex.tagVal[2] == 0 && geomvertex.tagVal[1] == 0 && geomvertex.tagVal[0] == 0)
					{
						@class.Buffer[j].color = int.MaxValue;
					}
					else
					{
						@class.Buffer[j].color = ((int)geomvertex.tagVal[3] << 24) + ((int)geomvertex.tagVal[2] << 16) + ((int)geomvertex.tagVal[1] << 8) + (int)geomvertex.tagVal[0];
					}
					Vector3 position = Class104.smethod_0(new Vector3(@class.Buffer[j].position.X, @class.Buffer[j].position.Y, @class.Buffer[j].position.Z), new Vector3(@class.Buffer[j].position.X + @class.Buffer[j].normal.X, @class.Buffer[j].position.Y + @class.Buffer[j].normal.Y, @class.Buffer[j].position.Z + @class.Buffer[j].normal.Z), 0.1f);
					array[num] = new Class112.Struct7(new Vector3(@class.Buffer[j].position.X, @class.Buffer[j].position.Y, @class.Buffer[j].position.Z), 0.5f, color);
					array[num].uint_0 = (uint)(((int)geomvertex.boneAssignment[3] << 24) + ((int)geomvertex.boneAssignment[2] << 16) + ((int)geomvertex.boneAssignment[1] << 8) + (int)geomvertex.boneAssignment[0]);
					array[num].float_0 = geomvertex.boneWeights[0];
					array[num].float_1 = geomvertex.boneWeights[1];
					array[num].float_2 = geomvertex.boneWeights[2];
					array[num].float_3 = geomvertex.boneWeights[3];
					num++;
					array[num] = new Class112.Struct7(position, 0.5f, color);
					array[num].uint_0 = (uint)(((int)geomvertex.boneAssignment[3] << 24) + ((int)geomvertex.boneAssignment[2] << 16) + ((int)geomvertex.boneAssignment[1] << 8) + (int)geomvertex.boneAssignment[0]);
					array[num].float_0 = geomvertex.boneWeights[0];
					array[num].float_1 = geomvertex.boneWeights[1];
					array[num].float_2 = geomvertex.boneWeights[2];
					array[num].float_3 = geomvertex.boneWeights[3];
					num++;
					val = Math.Max(geomvertex.vertexId, val);
					val2 = Math.Min(geomvertex.vertexId, val2);
				}
				@class.vertexBuffer_0 = new VertexBuffer(device_0, geom.vertices.Count * Class112.Struct7.SizeInBytes * 2, Usage.None, VertexFormat.None, Pool.Managed);
				DataStream dataStream = @class.vertexBuffer_0.Lock(0, 0, LockFlags.None);
				dataStream.WriteRange<Class112.Struct7>(array, 0, geom.vertices.Count * 2);
				@class.vertexBuffer_0.Unlock();
				dataStream.Dispose();
				VertexBuffer vertexBuffer = new VertexBuffer(device_0, @class.Buffer.Length * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
				DataStream dataStream2 = vertexBuffer.Lock(0, 0, LockFlags.None);
				dataStream2.WriteRange<Class112.Struct7>(@class.Buffer);
				vertexBuffer.Unlock();
				dataStream2.Dispose();
				@class.VertexBuffer = vertexBuffer;
				VertexBuffer vertexBuffer2 = new VertexBuffer(device_0, @class.Buffer.Length * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
				dataStream2 = vertexBuffer2.Lock(0, 0, LockFlags.None);
				dataStream2.WriteRange<Class112.Struct7>(@class.Buffer);
				vertexBuffer2.Unlock();
				@class.VertexBufferTransformed = vertexBuffer2;
				dataStream2.Dispose();
				@class.IBuffer = new short[@class.IBUFCount];
				for (int k = 0; k < geom.faces.Count; k++)
				{
					@class.IBuffer[k] = Convert.ToInt16(geom.faces[k]);
				}
				IndexBuffer indexBuffer = new IndexBuffer(device_0, @class.IBUFCount * 2, Usage.None, Pool.Managed, true);
				DataStream dataStream3 = indexBuffer.Lock(0, @class.IBUFCount * 2, LockFlags.None);
				dataStream3.WriteRange<short>(@class.IBuffer);
				indexBuffer.Unlock();
				@class.IndexBuffer = indexBuffer;
				@class.SelectedIndexBuffer = new IndexBuffer(device_0, Math.Max(@class.VertexCount, @class.FaceCount) * 3 * 2, Usage.None, Pool.Managed, true);
				@class.imethod_3();
				class110_0.Items.Add(@class);
			}
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0008AA84 File Offset: 0x00088C84
		public static Vector3 smethod_0(Vector3 vector3_0, Vector3 vector3_1, float float_3)
		{
			return Vector3.Lerp(vector3_0, vector3_1, (float)((double)(float_3 / Vector3.Distance(vector3_0, vector3_1))));
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0008AAA8 File Offset: 0x00088CA8
		public override Vector3[] imethod_13()
		{
			Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			foreach (Class104.Class110 @class in this.list_10)
			{
				foreach (Class104.Class109 class2 in @class.Items)
				{
					for (int i = 0; i < class2.IBUFCount; i++)
					{
						Class112.Struct7 @struct = class2.Buffer[(int)class2.IBuffer[i]];
						vector.X = Math.Min(@struct.position.X, vector.X);
						vector.Y = Math.Min(@struct.position.Y, vector.Y);
						vector.Z = Math.Min(@struct.position.Z, vector.Z);
						vector2.X = Math.Max(@struct.position.X, vector2.X);
						vector2.Y = Math.Max(@struct.position.Y, vector2.Y);
						vector2.Z = Math.Max(@struct.position.Z, vector2.Z);
					}
				}
			}
			return new Vector3[]
			{
				vector,
				vector2
			};
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x000067F8 File Offset: 0x000049F8
		public override void vmethod_3(XmlDocument xmlDocument_1)
		{
			this.method_23(xmlDocument_1, false);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0008ACA0 File Offset: 0x00088EA0
		public void method_23(XmlDocument xmlDocument_1, bool bool_7)
		{
			foreach (Class104.Class110 @class in this.list_10)
			{
				if (@class.IsBaseMesh)
				{
					if ((@class.Casp.typeFlags & 4U) == 4U)
					{
						Class132.smethod_0().method_14(@class.FaceMesh.DiffuseRenderTexture);
						Class132.smethod_0().method_14(@class.FaceMesh.FinalTexture);
						Class132.smethod_0().method_14(@class.DiffuseRenderTexture);
						@class.FaceMesh.method_0(this.interface3_0, null);
						@class.method_0(this.interface3_0, xmlDocument_1);
						Class132.smethod_0().method_17(@class.FaceMesh.DiffuseRenderTexture, @class.DiffuseRenderTexture);
					}
					else
					{
						@class.method_0(this.interface3_0, xmlDocument_1);
					}
				}
				else if (bool_7)
				{
					if (@class.Casp.Documents.Count > 0)
					{
						@class.method_0(this.interface3_0, @class.Casp.Documents[0]);
					}
					else
					{
						@class.method_0(this.interface3_0, null);
					}
				}
			}
			this.CurrentPreset = xmlDocument_1;
			List<Texture> list = new List<Texture>();
			list.Add(this._bodyTexture);
			Hashtable hashtable = new Hashtable();
			List<Class104.Class110> list2 = new List<Class104.Class110>();
			foreach (Class104.Class110 class2 in this.list_10)
			{
				Class132.smethod_0().method_14(class2.FinalTexture);
				if ((class2.Casp.typeFlags & 8U) != 0U && (class2.Casp.clothingType == 6U || class2.Casp.clothingType == 7U || class2.Casp.clothingType == 4U || class2.Casp.clothingType == 5U))
				{
					list.Add(class2.DiffuseRenderTexture);
					hashtable.Add(class2, class2.DiffuseRenderTexture);
					list2.Add(class2);
				}
			}
			List<Class104.Class110> list3 = list2;
			if (Class104.comparison_0 == null)
			{
				Class104.comparison_0 = new Comparison<Class104.Class110>(Class104.smethod_1);
			}
			list3.Sort(Class104.comparison_0);
			foreach (Class104.Class110 key in list2)
			{
				list.Add(hashtable[key] as Texture);
			}
			foreach (Class104.Class110 class3 in this.list_10)
			{
				if (class3.Casp.clothingType != 6U && class3.Casp.clothingType != 7U && class3.Casp.clothingType != 4U)
				{
					if (class3.Casp.clothingType != 5U)
					{
						if ((class3.Casp.typeFlags & 4U) != 4U)
						{
							if ((class3.Casp.typeFlags & 2U) != 2U)
							{
								Class132.smethod_0().method_17(class3.FinalTexture, class3.DiffuseRenderTexture);
								continue;
							}
						}
						Class132.smethod_0().method_16(class3.FinalTexture, new Texture[]
						{
							this._bodyTexture,
							class3.DiffuseRenderTexture
						});
						continue;
					}
				}
				Class132.smethod_0().method_16(class3.FinalTexture, list.ToArray());
			}
			list.Clear();
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x00006804 File Offset: 0x00004A04
		public override void imethod_1(bool bool_7)
		{
			this.Selected = bool_7;
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0008B04C File Offset: 0x0008924C
		public override bool imethod_2()
		{
			return this.Selected;
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0000680F File Offset: 0x00004A0F
		public override void imethod_3(bool bool_7)
		{
			this.Visible = bool_7;
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x0008B064 File Offset: 0x00089264
		public override bool imethod_4()
		{
			return this.Visible;
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x0008B07C File Offset: 0x0008927C
		public override void imethod_5(Device device_0)
		{
			this._emptyTexture.Dispose();
			this._bodyTexture.Dispose();
			this.interface3_0.imethod_2(false);
			foreach (Class104.Class110 @class in this.Containers)
			{
				@class.method_2(device_0);
			}
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0008B0F4 File Offset: 0x000892F4
		public override void vmethod_7(Device device_0)
		{
			this.method_3(device_0);
			this.method_4(device_0);
			foreach (Class104.Class110 @class in this.Containers)
			{
				@class.method_3(device_0);
			}
			this.method_23(this.CurrentPreset, true);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x0008B168 File Offset: 0x00089368
		public override Image vmethod_4(Device device_0, XmlDocument xmlDocument_1, Size size_0)
		{
			this.vmethod_3(xmlDocument_1);
			Surface renderTarget = device_0.GetRenderTarget(0);
			Surface surfaceLevel = this._emptyTexture.GetSurfaceLevel(0);
			device_0.SetRenderTarget(0, surfaceLevel);
			Surface surface = Surface.CreateDepthStencil(device_0, 1024, 1024, Format.D16, surfaceLevel.Description.MultisampleType, surfaceLevel.Description.MultisampleQuality, true);
			Surface depthStencilSurface = device_0.DepthStencilSurface;
			device_0.DepthStencilSurface = surface;
			device_0.BeginScene();
			Class140.smethod_0().method_9(RenderState.ZEnable, true);
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.AlphaTestEnable, true);
			device_0.Clear(ClearFlags.ZBuffer | ClearFlags.Target, Color.White, 1f, 0);
			Class132.smethod_0().method_26();
			Class132.smethod_0().method_27();
			Class140.smethod_0().method_9(RenderState.Lighting, true);
			this.method_28(Class132.smethod_0().WorldMatrix, Class132.smethod_0().ViewMatrix, device_0, true);
			device_0.EndScene();
			device_0.Present();
			device_0.DepthStencilSurface = depthStencilSurface;
			device_0.SetRenderTarget(0, renderTarget);
			surface.Dispose();
			DataStream dataStream = BaseTexture.ToStream(this._emptyTexture, ImageFileFormat.Bmp);
			Image image = Image.FromStream(dataStream);
			Image thumbnailImage = image.GetThumbnailImage(size_0.Width, size_0.Height, new Image.GetThumbnailImageAbort(base.method_2), IntPtr.Zero);
			image.Dispose();
			dataStream.Dispose();
			return thumbnailImage;
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x0008B2EC File Offset: 0x000894EC
		public override void imethod_11(int int_3)
		{
			if (this.s_CLIP_0 != null)
			{
				this.int_2 = int_3;
				foreach (S_CLIP.JointMovementRule jointMovementRule in this.s_CLIP_0.GetJointMovementRules())
				{
					S_CLIP.Frame frame = null;
					if (jointMovementRule.IndexedFrames.TryGetValue(int_3, out frame))
					{
						if (jointMovementRule.frameDataType == 274)
						{
							float num = (frame.data[0] & 1023U) / 1023f;
							float num2 = (frame.data[0] >> 10 & 1023U) / 1023f;
							float num3 = (frame.data[0] >> 20 & 1023U) / 1023f;
							if ((frame.signedBits & 1) != 0)
							{
								num = -num;
							}
							if ((frame.signedBits & 2) != 0)
							{
								num2 = -num2;
							}
							if ((frame.signedBits & 4) != 0)
							{
								num3 = -num3;
							}
							num *= jointMovementRule.scale;
							num2 *= jointMovementRule.scale;
							num3 *= jointMovementRule.scale;
							num += jointMovementRule.frameOffset;
							num2 += jointMovementRule.frameOffset;
							num3 += jointMovementRule.frameOffset;
							Matrix translationMatrix = Matrix.Translation(num, num2, num3);
							foreach (Class104.Class110 @class in this.list_10)
							{
								if (@class.GrannyInfo != null)
								{
									Class33 class2 = @class.GrannyInfo.Skeletons[0].HashedBones[jointMovementRule.jointName] as Class33;
									if (class2 != null)
									{
										class2.TranslationMatrix = translationMatrix;
									}
								}
							}
						}
						if (jointMovementRule.frameDataType == 532)
						{
							float num4 = (frame.data[0] & 4095U) / 4095f;
							float num5 = (frame.data[1] & 4095U) / 4095f;
							float num6 = (frame.data[2] & 4095U) / 4095f;
							float num7 = (frame.data[3] & 4095U) / 4095f;
							if ((frame.signedBits & 1) != 0)
							{
								num4 = -num4;
							}
							if ((frame.signedBits & 2) != 0)
							{
								num5 = -num5;
							}
							if ((frame.signedBits & 4) != 0)
							{
								num6 = -num6;
							}
							if ((frame.signedBits & 8) != 0)
							{
								num7 = -num7;
							}
							num4 *= jointMovementRule.scale;
							num5 *= jointMovementRule.scale;
							num6 *= jointMovementRule.scale;
							num7 *= jointMovementRule.scale;
							num4 += jointMovementRule.frameOffset;
							num5 += jointMovementRule.frameOffset;
							num6 += jointMovementRule.frameOffset;
							num7 += jointMovementRule.frameOffset;
							Quaternion rotation = new Quaternion(num4, num5, num6, num7);
							Matrix.RotationQuaternion(rotation);
							foreach (Class104.Class110 class3 in this.list_10)
							{
								if (class3.GrannyInfo != null)
								{
									Class33 class4 = class3.GrannyInfo.Skeletons[0].HashedBones[jointMovementRule.jointName] as Class33;
									if (class4 != null)
									{
										class4.Rotation = rotation;
									}
								}
							}
						}
					}
				}
				this.method_24();
				Class132.mainForm.Render();
			}
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0000681A File Offset: 0x00004A1A
		public override void imethod_14()
		{
			this.method_24();
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x0008B690 File Offset: 0x00089890
		private unsafe void method_24()
		{
			if (this.s_CLIP_0 != null)
			{
				foreach (Class104.Class110 @class in this.list_10)
				{
					if (@class.BoneFile != null && @class.GrannyInfo != null)
					{
						foreach (Class33 class2 in @class.GrannyInfo.Skeletons[0].Bones)
						{
							if (class2.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex == -1)
							{
								this.method_25(class2, null, Matrix.Identity, Matrix.Identity, @class);
							}
						}
						foreach (Class104.Class109 class3 in @class.Items)
						{
							GEOM geom = class3.Geom;
							foreach (uint num in geom.boneHashes)
							{
								Class33 class4 = @class.GrannyInfo.Skeletons[0].HashedBones[num] as Class33;
								int num2 = geom.boneHashes.IndexOf(num);
								if (class4 != null && num2 != -1)
								{
									class3.Palette[num2] = class4.CombinedTransformationMatrix;
								}
							}
						}
					}
				}
				foreach (Class104.Class110 class5 in this.Containers)
				{
					foreach (Class104.Class109 class6 in class5.Items)
					{
						DataStream dataStream = class6.VertexBuffer.Lock(0, 0, LockFlags.None);
						Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
						DataStream dataStream2 = class6.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
						Class112.Struct7* ptr2 = (Class112.Struct7*)((void*)dataStream2.DataPointer);
						for (int j = 0; j < class6.VertexCount; j++)
						{
							Vector3 vector = ptr[j].position;
							vector += ptr[j].vector3_0;
							Vector3 vector2 = Vector3.Zero;
							sbyte b = (sbyte)(ptr[j].uint_0 >> 24 & 255U);
							sbyte b2 = (sbyte)(ptr[j].uint_0 >> 16 & 255U);
							sbyte b3 = (sbyte)(ptr[j].uint_0 >> 8 & 255U);
							sbyte b4 = (sbyte)(ptr[j].uint_0 & 255U);
							Matrix transformation = Matrix.Identity;
							Matrix transformation2 = Matrix.Identity;
							Matrix transformation3 = Matrix.Identity;
							Matrix transformation4 = Matrix.Identity;
							if (b > -1)
							{
								transformation = class6.Palette[(int)b];
							}
							if (b2 > -1)
							{
								transformation2 = class6.Palette[(int)b2];
							}
							if (b3 > -1)
							{
								transformation3 = class6.Palette[(int)b3];
							}
							if (b4 > -1)
							{
								transformation4 = class6.Palette[(int)b4];
							}
							if (b == -1 && b2 == -1 && b3 == -1 && b4 == -1)
							{
								vector2 = vector;
							}
							vector2 += Vector3.TransformCoordinate(vector, transformation4) * ptr[j].float_0;
							vector2 += Vector3.TransformCoordinate(vector, transformation3) * ptr[j].float_1;
							vector2 += Vector3.TransformCoordinate(vector, transformation2) * ptr[j].float_2;
							vector2 += Vector3.TransformCoordinate(vector, transformation) * ptr[j].float_3;
							ptr2[j].position = vector2;
						}
						class6.VertexBuffer.Unlock();
						class6.VertexBufferTransformed.Unlock();
					}
				}
				EditorToolBox.smethod_0().method_1();
			}
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x0008BB74 File Offset: 0x00089D74
		private void method_25(Class33 class33_0, Class33 class33_1, Matrix matrix_0, Matrix matrix_1, Class104.Class110 class110_0)
		{
			Matrix matrix = this.method_27(FNV32.GetHash(class33_0.Sims3WorkshopSDK.Interfaces.IBone.Name), class110_0);
			Matrix matrix2 = this.method_27(FNV32.GetHash(class33_0.Sims3WorkshopSDK.Interfaces.IBone.Name), class110_0);
			matrix2.Invert();
			Matrix left = Matrix.RotationQuaternion(new Quaternion(class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[0], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[1], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[2], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[3]));
			Matrix right = Matrix.Translation(new Vector3(class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[0], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[1], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[2]));
			class33_0.CombinedBoneTransformationMatrix = left * right * matrix_1;
			left.Invert();
			right.Invert();
			Matrix right2 = left * matrix2;
			Matrix right3 = Matrix.Identity;
			if (!class33_0.TranslationMatrix.IsIdentity)
			{
				right3 = class33_0.TranslationMatrix * right;
			}
			class33_0.OffsetMatrix = matrix;
			class33_0.CombinedTransformationMatrix = matrix * Matrix.RotationQuaternion(class33_0.Rotation) * right3 * right2 * matrix_0;
			class33_0.CombinedBoneTransformationMatrix = matrix2 * class33_0.CombinedTransformationMatrix;
			List<Class33> list = this.method_26(class33_0, class110_0);
			foreach (Class33 class33_2 in list)
			{
				this.method_25(class33_2, class33_0, class33_0.CombinedTransformationMatrix, class33_0.CombinedBoneTransformationMatrix, class110_0);
			}
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x0008BD18 File Offset: 0x00089F18
		private List<Class33> method_26(Class33 class33_0, Class104.Class110 class110_0)
		{
			List<Class33> list = new List<Class33>();
			foreach (Class33 @class in class110_0.GrannyInfo.Skeletons[0].Bones)
			{
				if (@class.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex != -1)
				{
					Class33 class2 = class110_0.GrannyInfo.Skeletons[0].Bones[@class.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex];
					if (class2 == class33_0)
					{
						list.Add(@class);
					}
				}
			}
			return list;
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x0008BD8C File Offset: 0x00089F8C
		private Matrix method_27(uint uint_0, Class104.Class110 class110_0)
		{
			Matrix identity = Matrix.Identity;
			Matrix result;
			if (class110_0.BoneFile != null && class110_0.GrannyInfo != null)
			{
				BONE.BoneEntry boneEntry = class110_0.BoneFile.HashedBoneNames[uint_0] as BONE.BoneEntry;
				if (boneEntry == null)
				{
					result = identity;
				}
				else
				{
					identity.M11 = boneEntry.x1;
					identity.M12 = boneEntry.x2;
					identity.M13 = boneEntry.x3;
					identity.M21 = boneEntry.y1;
					identity.M22 = boneEntry.y2;
					identity.M23 = boneEntry.y3;
					identity.M31 = boneEntry.z1;
					identity.M32 = boneEntry.z2;
					identity.M33 = boneEntry.z3;
					identity.M41 = boneEntry.o1;
					identity.M42 = boneEntry.o2;
					identity.M43 = boneEntry.o3;
					result = identity;
				}
			}
			else
			{
				result = identity;
			}
			return result;
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x00002A71 File Offset: 0x00000C71
		public override void vmethod_6(Matrix matrix_0, Matrix matrix_1, Device device_0)
		{
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0008BE80 File Offset: 0x0008A080
		public override void vmethod_5(Matrix matrix_0, Device device_0)
		{
			foreach (Class104.Class110 @class in this.list_10)
			{
				foreach (Class104.Class109 class2 in @class.Items)
				{
					if (@class.IsBaseMesh)
					{
						device_0.Indices = class2.IndexBuffer;
						device_0.SetStreamSource(0, class2.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
						Class140.smethod_0().method_40("FlatShade");
						Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
						Class140.smethod_0().method_9(RenderState.ZEnable, true);
						Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
						Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
						Class140.smethod_0().method_28("g_forcedTransparency", 1f);
						Class140.smethod_0().method_30("g_ambient", Color.Gray.ToArgb());
						Class140.smethod_0().method_35();
						int num = Class140.smethod_0().method_36();
						for (int i = 0; i < num; i++)
						{
							Class140.smethod_0().method_38(i);
							device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, class2.VertexCount, class2.IBUFOffset, class2.IBUFCount / 3);
							Class140.smethod_0().method_39();
						}
						Class140.smethod_0().method_37();
						Class140.smethod_0().method_40("Line");
						Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Wireframe);
						num = Class140.smethod_0().method_36();
						for (int j = 0; j < num; j++)
						{
							Class140.smethod_0().method_38(j);
							device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, class2.VertexCount, class2.IBUFOffset, class2.IBUFCount / 3);
							Class140.smethod_0().method_39();
						}
						Class140.smethod_0().method_37();
						Class140.smethod_0().method_9(RenderState.ZWriteEnable, false);
						Class140.smethod_0().method_40("Line");
						Class140.smethod_0().method_30("g_ambient", Color.White.ToArgb());
						Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Point);
						Class140.smethod_0().method_9(RenderState.PointSize, 3f);
						num = Class140.smethod_0().method_36();
						for (int k = 0; k < num; k++)
						{
							Class140.smethod_0().method_38(k);
							device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, class2.VertexCount, class2.IBUFOffset, class2.IBUFCount / 3);
							Class140.smethod_0().method_39();
						}
						Class140.smethod_0().method_37();
						Class140.smethod_0().method_30("g_ambient", Color.Red.ToArgb());
						device_0.Indices = class2.SelectedIndexBuffer;
						num = Class140.smethod_0().method_36();
						for (int l = 0; l < num; l++)
						{
							Class140.smethod_0().method_38(l);
							device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, class2.VertexCount, 0, class2.CurrentSelectionIndex.Count);
							Class140.smethod_0().method_39();
						}
						Class140.smethod_0().method_37();
					}
				}
			}
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00006824 File Offset: 0x00004A24
		public override void imethod_0(Matrix matrix_0, Matrix matrix_1, Device device_0)
		{
			Class140.smethod_0().method_10();
			this.method_28(matrix_0, matrix_1, device_0, false);
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x0008C1FC File Offset: 0x0008A3FC
		public void method_28(Matrix matrix_0, Matrix matrix_1, Device device_0, bool bool_7)
		{
			Class140.smethod_0().method_13(this.int_1);
			foreach (Class104.Class110 @class in this.list_10)
			{
				foreach (Class104.Class109 class2 in @class.Items)
				{
					if (class2.Visible)
					{
						Class140.smethod_0().method_33(class2.Palette);
						device_0.SetRenderState<FillMode>(RenderState.FillMode, Class132.smethod_0().Wireframe ? FillMode.Wireframe : FillMode.Solid);
						device_0.Indices = class2.IndexBuffer;
						device_0.SetStreamSource(0, class2.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
						device_0.SetTransform(TransformState.World, matrix_0);
						Class140.smethod_0().method_32(matrix_0, matrix_1);
						device_0.Material = class2.material_0;
						Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
						Class132.smethod_0().method_31(class2.Geom.MATD);
						Class140.smethod_0().method_11(new Vector2(1f, 1f), new Vector2(1f, 1f), new Vector2(1f, 1f));
						Class140.smethod_0().method_12(new Vector4(1f, 1f, 1f, 1f), new Vector4(1f, 1f, 1f, 1f));
						Class140.smethod_0().method_34(class2.Palette.Length > 0);
						Class140.smethod_0().method_14(@class.FinalTexture);
						Class140.smethod_0().method_19(@class.SpecularRenderTexture);
						if ((@class.Casp.typeFlags & 1U) == 1U)
						{
							Class140.smethod_0().method_40("Hair");
						}
						else
						{
							Class140.smethod_0().method_40("Geom");
						}
						if (class2.texture_1 != null)
						{
							Class140.smethod_0().method_18(class2.texture_1);
						}
						if (class2.texture_0 != null)
						{
							Class140.smethod_0().method_19(class2.texture_0);
						}
						if (@class.IsBaseMesh)
						{
							uint typeFlags = @class.Casp.typeFlags;
						}
						Class140.smethod_0().method_27("g_alphaBlend", true);
						Class140.smethod_0().method_27("g_selected", class2.Selected);
						Class140.smethod_0().method_27("g_showBump", Class132.smethod_0().BumpMapEnabled);
						Class140.smethod_0().method_27("hasNormalMap", false);
						if (class2.texture_2 != null)
						{
							Class140.smethod_0().method_27("hasNormalMap", false);
							Class140.smethod_0().method_20(class2.texture_2);
						}
						if ((@class.Casp.typeFlags & 1U) == 1U)
						{
							Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
							Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
							Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
							Class140.smethod_0().method_9(RenderState.AlphaTestEnable, true);
							Class140.smethod_0().method_9(RenderState.AlphaFunc, Compare.GreaterEqual);
							Class140.smethod_0().method_9(RenderState.AlphaRef, 254);
						}
						else
						{
							Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
							Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
							Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
							Class140.smethod_0().method_9(RenderState.AlphaTestEnable, false);
						}
						Class140.smethod_0().method_35();
						int num = Class140.smethod_0().method_36();
						for (int i = 0; i < num; i++)
						{
							Class140.smethod_0().method_38(i);
							device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, class2.VertexCount, class2.IBUFOffset, class2.IBUFCount / 3);
							Class140.smethod_0().method_39();
						}
						Class140.smethod_0().method_37();
						if ((@class.Casp.typeFlags & 1U) == 1U)
						{
							num = Class140.smethod_0().method_36();
							for (int j = 0; j < num; j++)
							{
								Class140.smethod_0().method_38(j);
								Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
								Class140.smethod_0().method_9(RenderState.SourceBlend, Blend.SourceAlpha);
								Class140.smethod_0().method_9(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
								Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
								Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
								Class140.smethod_0().method_9(RenderState.AlphaTestEnable, true);
								Class140.smethod_0().method_9(RenderState.AlphaFunc, Compare.LessEqual);
								Class140.smethod_0().method_9(RenderState.AlphaRef, 254);
								device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, class2.VertexCount, class2.IBUFOffset, class2.IBUFCount / 3);
								Class140.smethod_0().method_39();
							}
							Class140.smethod_0().method_37();
						}
						Class140.smethod_0().method_9(RenderState.AlphaTestEnable, false);
						Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
						Class140.smethod_0().method_9(RenderState.Lighting, false);
						Material material = default(Material);
						material.Ambient = (material.Diffuse = (material.Specular = Color.FromArgb(200, 200, 200, 200)));
						device_0.Material = material;
						Class140.smethod_0().method_9(RenderState.IndexedVertexBlendEnable, false);
						Class140.smethod_0().method_9(RenderState.VertexBlend, VertexBlend.Disable);
						if (Class132.smethod_0().NormalsEnabled && !bool_7)
						{
							Class140.smethod_0().method_40("GeomNormal");
							Class140.smethod_0().method_9(RenderState.Lighting, false);
							Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
							num = Class140.smethod_0().method_36();
							for (int k = 0; k < num; k++)
							{
								Class140.smethod_0().method_38(k);
								device_0.SetStreamSource(0, class2.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
								device_0.DrawPrimitives(PrimitiveType.LineList, 0, class2.VertexCount);
								Class140.smethod_0().method_39();
							}
							Class140.smethod_0().method_37();
							Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
						}
					}
				}
			}
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x0008C88C File Offset: 0x0008AA8C
		public override void imethod_8(bool bool_7)
		{
			base.imethod_8(bool_7);
			this._emptyTexture.Dispose();
			this._bodyTexture.Dispose();
			this.interface3_0.imethod_2(bool_7);
			foreach (Class104.Class110 @class in this.list_10)
			{
				@class.method_4();
			}
			this.list_10.Clear();
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0000683C File Offset: 0x00004A3C
		public override void imethod_12(S_CLIP s_CLIP_1)
		{
			this.s_CLIP_0 = s_CLIP_1;
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x0008C918 File Offset: 0x0008AB18
		public string ToString()
		{
			return this.casp.str1;
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0008C934 File Offset: 0x0008AB34
		[CompilerGenerated]
		private static int smethod_1(Class104.Class110 class110_0, Class104.Class110 class110_1)
		{
			return class110_0.Casp.typeFlags.CompareTo(class110_1.Casp.typeFlags);
		}

		// Token: 0x0400083A RID: 2106
		private CASP casp;

		// Token: 0x0400083B RID: 2107
		private Interface3 interface3_0;

		// Token: 0x0400083C RID: 2108
		private List<Class104.Class110> list_10;

		// Token: 0x0400083D RID: 2109
		private int int_0;

		// Token: 0x0400083E RID: 2110
		private int int_1 = -1;

		// Token: 0x0400083F RID: 2111
		private S_CLIP s_CLIP_0;

		// Token: 0x04000840 RID: 2112
		private WorkshopProject project;

		// Token: 0x04000841 RID: 2113
		private float float_0;

		// Token: 0x04000842 RID: 2114
		private float float_1;

		// Token: 0x04000843 RID: 2115
		private float float_2;

		// Token: 0x04000844 RID: 2116
		private List<float[,]> list_11;

		// Token: 0x04000845 RID: 2117
		private int int_2;

		// Token: 0x04000846 RID: 2118
		[CompilerGenerated]
		private bool bool_5;

		// Token: 0x04000847 RID: 2119
		[CompilerGenerated]
		private bool bool_6;

		// Token: 0x04000848 RID: 2120
		[CompilerGenerated]
		private XmlDocument xmlDocument_0;

		// Token: 0x04000849 RID: 2121
		[CompilerGenerated]
		private Texture texture_0;

		// Token: 0x0400084A RID: 2122
		[CompilerGenerated]
		private Texture texture_1;

		// Token: 0x0400084B RID: 2123
		[CompilerGenerated]
		private List<string> list_12;

		// Token: 0x0400084C RID: 2124
		[CompilerGenerated]
		private List<string> list_13;

		// Token: 0x0400084D RID: 2125
		[CompilerGenerated]
		private List<string> list_14;

		// Token: 0x0400084E RID: 2126
		[CompilerGenerated]
		private static Comparison<Class104.Class110> comparison_0;

		// Token: 0x020000FB RID: 251
		public sealed class Class109 : Interface9
		{
			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x06000A7E RID: 2686 RVA: 0x0008C964 File Offset: 0x0008AB64
			// (set) Token: 0x06000A7F RID: 2687 RVA: 0x00006847 File Offset: 0x00004A47
			public IndexBuffer IndexBuffer { get; set; }

			// Token: 0x170001B3 RID: 435
			// (get) Token: 0x06000A80 RID: 2688 RVA: 0x0008C97C File Offset: 0x0008AB7C
			// (set) Token: 0x06000A81 RID: 2689 RVA: 0x00006852 File Offset: 0x00004A52
			public VertexBuffer VertexBuffer { get; set; }

			// Token: 0x170001B4 RID: 436
			// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0008C994 File Offset: 0x0008AB94
			// (set) Token: 0x06000A83 RID: 2691 RVA: 0x0000685D File Offset: 0x00004A5D
			public VertexBuffer VertexBufferTransformed { get; set; }

			// Token: 0x170001B5 RID: 437
			// (get) Token: 0x06000A84 RID: 2692 RVA: 0x0008C9AC File Offset: 0x0008ABAC
			// (set) Token: 0x06000A85 RID: 2693 RVA: 0x00006868 File Offset: 0x00004A68
			public IndexBuffer SelectedIndexBuffer { get; set; }

			// Token: 0x170001B6 RID: 438
			// (get) Token: 0x06000A86 RID: 2694 RVA: 0x0008C9C4 File Offset: 0x0008ABC4
			// (set) Token: 0x06000A87 RID: 2695 RVA: 0x00006873 File Offset: 0x00004A73
			public List<Class102.Class107> CurrentSelectionIndex { get; set; }

			// Token: 0x170001B7 RID: 439
			// (get) Token: 0x06000A88 RID: 2696 RVA: 0x0008C9DC File Offset: 0x0008ABDC
			// (set) Token: 0x06000A89 RID: 2697 RVA: 0x0000687E File Offset: 0x00004A7E
			public int VertexCount { get; set; }

			// Token: 0x170001B8 RID: 440
			// (get) Token: 0x06000A8A RID: 2698 RVA: 0x0008C9F4 File Offset: 0x0008ABF4
			// (set) Token: 0x06000A8B RID: 2699 RVA: 0x00006889 File Offset: 0x00004A89
			public int IBUFOffset { get; set; }

			// Token: 0x170001B9 RID: 441
			// (get) Token: 0x06000A8C RID: 2700 RVA: 0x0008CA0C File Offset: 0x0008AC0C
			// (set) Token: 0x06000A8D RID: 2701 RVA: 0x00006894 File Offset: 0x00004A94
			public int VBUFOffset { get; set; }

			// Token: 0x170001BA RID: 442
			// (get) Token: 0x06000A8E RID: 2702 RVA: 0x0008CA24 File Offset: 0x0008AC24
			// (set) Token: 0x06000A8F RID: 2703 RVA: 0x0000689F File Offset: 0x00004A9F
			public int IBUFCount { get; set; }

			// Token: 0x170001BB RID: 443
			// (get) Token: 0x06000A90 RID: 2704 RVA: 0x0008CA3C File Offset: 0x0008AC3C
			// (set) Token: 0x06000A91 RID: 2705 RVA: 0x000068AA File Offset: 0x00004AAA
			public bool Selected { get; set; }

			// Token: 0x170001BC RID: 444
			// (get) Token: 0x06000A92 RID: 2706 RVA: 0x0008CA54 File Offset: 0x0008AC54
			// (set) Token: 0x06000A93 RID: 2707 RVA: 0x000068B5 File Offset: 0x00004AB5
			public bool Visible { get; set; }

			// Token: 0x170001BD RID: 445
			// (get) Token: 0x06000A94 RID: 2708 RVA: 0x0008CA6C File Offset: 0x0008AC6C
			// (set) Token: 0x06000A95 RID: 2709 RVA: 0x000068C0 File Offset: 0x00004AC0
			public GEOM Geom { get; set; }

			// Token: 0x170001BE RID: 446
			// (get) Token: 0x06000A96 RID: 2710 RVA: 0x0008CA84 File Offset: 0x0008AC84
			// (set) Token: 0x06000A97 RID: 2711 RVA: 0x000068CB File Offset: 0x00004ACB
			public Class112.Struct7[] Buffer { get; set; }

			// Token: 0x170001BF RID: 447
			// (get) Token: 0x06000A98 RID: 2712 RVA: 0x0008CA9C File Offset: 0x0008AC9C
			// (set) Token: 0x06000A99 RID: 2713 RVA: 0x000068D6 File Offset: 0x00004AD6
			public short[] IBuffer { get; set; }

			// Token: 0x170001C0 RID: 448
			// (get) Token: 0x06000A9A RID: 2714 RVA: 0x0008CAB4 File Offset: 0x0008ACB4
			// (set) Token: 0x06000A9B RID: 2715 RVA: 0x000068E1 File Offset: 0x00004AE1
			public Matrix[] Palette { get; set; }

			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x06000A9C RID: 2716 RVA: 0x0008CACC File Offset: 0x0008ACCC
			// (set) Token: 0x06000A9D RID: 2717 RVA: 0x000068EC File Offset: 0x00004AEC
			public Matrix[] ColorPalette { get; set; }

			// Token: 0x170001C2 RID: 450
			// (get) Token: 0x06000A9E RID: 2718 RVA: 0x0008CAE4 File Offset: 0x0008ACE4
			// (set) Token: 0x06000A9F RID: 2719 RVA: 0x000068F7 File Offset: 0x00004AF7
			public Class104.Class110 Container { get; private set; }

			// Token: 0x06000AA0 RID: 2720 RVA: 0x00006902 File Offset: 0x00004B02
			public Class109(GEOM geom, Class104.Class110 container)
			{
				this.Container = container;
				this.CurrentSelectionIndex = new List<Class102.Class107>();
				this.Geom = geom;
				this.Visible = true;
			}

			// Token: 0x06000AA1 RID: 2721 RVA: 0x0008CAFC File Offset: 0x0008ACFC
			public void imethod_1(bool bool_2)
			{
				this.SelectedIndexBuffer.Dispose();
				this.IndexBuffer.Dispose();
				this.VertexBuffer.Dispose();
				this.VertexBufferTransformed.Dispose();
				if (this.texture_0 != null)
				{
					this.texture_0.Dispose();
				}
				if (this.texture_2 != null)
				{
					this.texture_2.Dispose();
				}
				if (this.texture_1 != null)
				{
					this.texture_1.Dispose();
				}
				if (this.vertexBuffer_0 != null)
				{
					this.vertexBuffer_0.Dispose();
				}
				if (this.IndexBuffer != null)
				{
					this.IndexBuffer.Dispose();
				}
				if (this.VertexBuffer != null)
				{
					this.VertexBuffer.Dispose();
				}
				this.Buffer = null;
			}

			// Token: 0x06000AA2 RID: 2722 RVA: 0x00002A71 File Offset: 0x00000C71
			public void method_10(Device device_0)
			{
			}

			// Token: 0x06000AA3 RID: 2723 RVA: 0x00002A71 File Offset: 0x00000C71
			public void method_11(Device device_0)
			{
			}

			// Token: 0x170001C3 RID: 451
			// (get) Token: 0x06000AA4 RID: 2724 RVA: 0x0008CBB0 File Offset: 0x0008ADB0
			// (set) Token: 0x06000AA5 RID: 2725 RVA: 0x00002A71 File Offset: 0x00000C71
			public int FaceCount
			{
				get
				{
					return this.Geom.faces.Count / 3;
				}
				set
				{
				}
			}

			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x06000AA6 RID: 2726 RVA: 0x0008CBD4 File Offset: 0x0008ADD4
			// (set) Token: 0x06000AA7 RID: 2727 RVA: 0x0000692C File Offset: 0x00004B2C
			public Lod LOD { get; set; }

			// Token: 0x170001C5 RID: 453
			// (get) Token: 0x06000AA8 RID: 2728 RVA: 0x0008CBEC File Offset: 0x0008ADEC
			public MATD Matd
			{
				get
				{
					return this.matd_0;
				}
			}

			// Token: 0x06000AA9 RID: 2729 RVA: 0x0008CC04 File Offset: 0x0008AE04
			public void imethod_3()
			{
				if (this.CurrentSelectionIndex.Count > 0)
				{
					DataStream dataStream = this.SelectedIndexBuffer.Lock(0, this.CurrentSelectionIndex.Count * 2 * 3, LockFlags.None);
					foreach (Class102.Class107 @class in this.CurrentSelectionIndex)
					{
						dataStream.WriteRange<short>(new short[]
						{
							@class.short_0,
							@class.short_1,
							@class.short_2
						}, 0, 3);
					}
					this.SelectedIndexBuffer.Unlock();
				}
				EditorToolBox.smethod_0().method_4();
			}

			// Token: 0x06000AAA RID: 2730 RVA: 0x0008CCC4 File Offset: 0x0008AEC4
			public bool imethod_0(Device device_0, Matrix matrix_2, Vector3 vector3_0, Vector3 vector3_1, out float float_0)
			{
				float_0 = 0f;
				return false;
			}

			// Token: 0x06000AAB RID: 2731 RVA: 0x00006937 File Offset: 0x00004B37
			public void imethod_2(Device device_0, MATD matd_1)
			{
				this.matd_0 = matd_1;
			}

			// Token: 0x170001C6 RID: 454
			// (get) Token: 0x06000AAC RID: 2732 RVA: 0x0008CBEC File Offset: 0x0008ADEC
			public MATD DefaultMaterial
			{
				get
				{
					return this.matd_0;
				}
			}

			// Token: 0x170001C7 RID: 455
			// (get) Token: 0x06000AAD RID: 2733 RVA: 0x0008CCE0 File Offset: 0x0008AEE0
			// (set) Token: 0x06000AAE RID: 2734 RVA: 0x00006942 File Offset: 0x00004B42
			public object Tag { get; set; }

			// Token: 0x0400084F RID: 2127
			public VertexBuffer vertexBuffer_0;

			// Token: 0x04000850 RID: 2128
			private MATD matd_0;

			// Token: 0x04000851 RID: 2129
			public Texture texture_0;

			// Token: 0x04000852 RID: 2130
			public Texture texture_1;

			// Token: 0x04000853 RID: 2131
			public Texture texture_2;

			// Token: 0x04000854 RID: 2132
			public Material material_0;

			// Token: 0x04000855 RID: 2133
			[CompilerGenerated]
			private IndexBuffer indexBuffer_0;

			// Token: 0x04000856 RID: 2134
			[CompilerGenerated]
			private VertexBuffer vertexBuffer_1;

			// Token: 0x04000857 RID: 2135
			[CompilerGenerated]
			private VertexBuffer vertexBuffer_2;

			// Token: 0x04000858 RID: 2136
			[CompilerGenerated]
			private IndexBuffer indexBuffer_1;

			// Token: 0x04000859 RID: 2137
			[CompilerGenerated]
			private List<Class102.Class107> list_0;

			// Token: 0x0400085A RID: 2138
			[CompilerGenerated]
			private int int_0;

			// Token: 0x0400085B RID: 2139
			[CompilerGenerated]
			private int int_1;

			// Token: 0x0400085C RID: 2140
			[CompilerGenerated]
			private int int_2;

			// Token: 0x0400085D RID: 2141
			[CompilerGenerated]
			private int int_3;

			// Token: 0x0400085E RID: 2142
			[CompilerGenerated]
			private bool bool_0;

			// Token: 0x0400085F RID: 2143
			[CompilerGenerated]
			private bool bool_1;

			// Token: 0x04000860 RID: 2144
			[CompilerGenerated]
			private GEOM geom_0;

			// Token: 0x04000861 RID: 2145
			[CompilerGenerated]
			private Class112.Struct7[] struct7_0;

			// Token: 0x04000862 RID: 2146
			[CompilerGenerated]
			private short[] short_0;

			// Token: 0x04000863 RID: 2147
			[CompilerGenerated]
			private Matrix[] matrix_0;

			// Token: 0x04000864 RID: 2148
			[CompilerGenerated]
			private Matrix[] matrix_1;

			// Token: 0x04000865 RID: 2149
			[CompilerGenerated]
			private Class104.Class110 class110_0;

			// Token: 0x04000866 RID: 2150
			[CompilerGenerated]
			private Lod lod_0;

			// Token: 0x04000867 RID: 2151
			[CompilerGenerated]
			private object object_0;
		}

		// Token: 0x020000FC RID: 252
		public sealed class Class110
		{
			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x06000AAF RID: 2735 RVA: 0x0008CCF8 File Offset: 0x0008AEF8
			// (set) Token: 0x06000AB0 RID: 2736 RVA: 0x0000694D File Offset: 0x00004B4D
			public BGEO FatBlend { get; set; }

			// Token: 0x170001C9 RID: 457
			// (get) Token: 0x06000AB1 RID: 2737 RVA: 0x0008CD10 File Offset: 0x0008AF10
			// (set) Token: 0x06000AB2 RID: 2738 RVA: 0x00006958 File Offset: 0x00004B58
			public BGEO FitBlend { get; set; }

			// Token: 0x170001CA RID: 458
			// (get) Token: 0x06000AB3 RID: 2739 RVA: 0x0008CD28 File Offset: 0x0008AF28
			// (set) Token: 0x06000AB4 RID: 2740 RVA: 0x00006963 File Offset: 0x00004B63
			public BGEO ThinBlend { get; set; }

			// Token: 0x170001CB RID: 459
			// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x0008CD40 File Offset: 0x0008AF40
			// (set) Token: 0x06000AB6 RID: 2742 RVA: 0x0000696E File Offset: 0x00004B6E
			public BGEO SpecialBlend { get; set; }

			// Token: 0x170001CC RID: 460
			// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x0008CD58 File Offset: 0x0008AF58
			// (set) Token: 0x06000AB8 RID: 2744 RVA: 0x00006979 File Offset: 0x00004B79
			public BONE BoneFile { get; set; }

			// Token: 0x170001CD RID: 461
			// (get) Token: 0x06000AB9 RID: 2745 RVA: 0x0008CD70 File Offset: 0x0008AF70
			// (set) Token: 0x06000ABA RID: 2746 RVA: 0x00006984 File Offset: 0x00004B84
			public BOND BaseAdjust { get; set; }

			// Token: 0x170001CE RID: 462
			// (get) Token: 0x06000ABB RID: 2747 RVA: 0x0008CD88 File Offset: 0x0008AF88
			// (set) Token: 0x06000ABC RID: 2748 RVA: 0x0000698F File Offset: 0x00004B8F
			public BOND FatAdjust { get; set; }

			// Token: 0x170001CF RID: 463
			// (get) Token: 0x06000ABD RID: 2749 RVA: 0x0008CDA0 File Offset: 0x0008AFA0
			// (set) Token: 0x06000ABE RID: 2750 RVA: 0x0000699A File Offset: 0x00004B9A
			public BOND FitAdjust { get; set; }

			// Token: 0x170001D0 RID: 464
			// (get) Token: 0x06000ABF RID: 2751 RVA: 0x0008CDB8 File Offset: 0x0008AFB8
			// (set) Token: 0x06000AC0 RID: 2752 RVA: 0x000069A5 File Offset: 0x00004BA5
			public BOND ThinAdjust { get; set; }

			// Token: 0x170001D1 RID: 465
			// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x0008CDD0 File Offset: 0x0008AFD0
			// (set) Token: 0x06000AC2 RID: 2754 RVA: 0x000069B0 File Offset: 0x00004BB0
			public BOND SpecialAdjust { get; set; }

			// Token: 0x170001D2 RID: 466
			// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x0008CDE8 File Offset: 0x0008AFE8
			// (set) Token: 0x06000AC4 RID: 2756 RVA: 0x000069BB File Offset: 0x00004BBB
			public Class28 GrannyInfo { get; set; }

			// Token: 0x170001D3 RID: 467
			// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x0008CE00 File Offset: 0x0008B000
			// (set) Token: 0x06000AC6 RID: 2758 RVA: 0x000069C6 File Offset: 0x00004BC6
			public List<Class104.Class109> Items { get; set; }

			// Token: 0x170001D4 RID: 468
			// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x0008CE18 File Offset: 0x0008B018
			// (set) Token: 0x06000AC8 RID: 2760 RVA: 0x000069D1 File Offset: 0x00004BD1
			public Texture DiffuseRenderTexture { get; set; }

			// Token: 0x170001D5 RID: 469
			// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x0008CE30 File Offset: 0x0008B030
			// (set) Token: 0x06000ACA RID: 2762 RVA: 0x000069DC File Offset: 0x00004BDC
			public Texture FinalTexture { get; set; }

			// Token: 0x170001D6 RID: 470
			// (get) Token: 0x06000ACB RID: 2763 RVA: 0x0008CE48 File Offset: 0x0008B048
			// (set) Token: 0x06000ACC RID: 2764 RVA: 0x000069E7 File Offset: 0x00004BE7
			public Texture SpecularRenderTexture { get; set; }

			// Token: 0x170001D7 RID: 471
			// (get) Token: 0x06000ACD RID: 2765 RVA: 0x0008CE60 File Offset: 0x0008B060
			// (set) Token: 0x06000ACE RID: 2766 RVA: 0x000069F2 File Offset: 0x00004BF2
			public Texture PartMask { get; set; }

			// Token: 0x170001D8 RID: 472
			// (get) Token: 0x06000ACF RID: 2767 RVA: 0x0008CE78 File Offset: 0x0008B078
			// (set) Token: 0x06000AD0 RID: 2768 RVA: 0x000069FD File Offset: 0x00004BFD
			public bool IsBaseMesh { get; set; }

			// Token: 0x170001D9 RID: 473
			// (get) Token: 0x06000AD1 RID: 2769 RVA: 0x0008CE90 File Offset: 0x0008B090
			// (set) Token: 0x06000AD2 RID: 2770 RVA: 0x00006A08 File Offset: 0x00004C08
			public bool IsFace { get; set; }

			// Token: 0x170001DA RID: 474
			// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x0008CEA8 File Offset: 0x0008B0A8
			public CASP Casp
			{
				get
				{
					return this.casp;
				}
			}

			// Token: 0x170001DB RID: 475
			// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x0008CEC0 File Offset: 0x0008B0C0
			// (set) Token: 0x06000AD5 RID: 2773 RVA: 0x00006A13 File Offset: 0x00004C13
			public Class104.Class110 FaceMesh { get; set; }

			// Token: 0x06000AD6 RID: 2774 RVA: 0x0008CED8 File Offset: 0x0008B0D8
			public Class110(Device device, CASP casp)
			{
				this.casp = casp;
				this.Items = new List<Class104.Class109>();
				this.material_0 = default(Material);
				this.material_0.Diffuse = Color.White;
				this.material_0.Specular = Color.Black;
				this.material_1 = default(Material);
				this.material_1.Diffuse = (this.material_1.Specular = Color.White);
				this.material_1.Ambient = (this.material_0.Ambient = Color.White);
				this.method_1(device);
			}

			// Token: 0x06000AD7 RID: 2775 RVA: 0x0008CF90 File Offset: 0x0008B190
			public void method_0(Interface3 interface3_0, XmlDocument xmlDocument_0)
			{
				if (this.PartMask != null)
				{
					this.PartMask.Dispose();
				}
				Class132.smethod_0().method_14(this.DiffuseRenderTexture);
				if (xmlDocument_0 == null)
				{
					if (this.casp.hasDiffuse > 0)
					{
						TXTC txtc = Class76.smethod_26(new ResKey(this.casp.igtIndex[(int)this.casp.diffuseIndex].Reskey)) as TXTC;
						if (txtc != null)
						{
							xmlDocument_0 = txtc.ToPreset();
							if (!Class132.smethod_0().method_15(interface3_0, xmlDocument_0, "DiffuseMap", (xmlDocument_0.SelectNodes("preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value"), this.DiffuseRenderTexture))
							{
								MessageBox.Show("Error when rendering complate: " + interface3_0.Errors);
							}
						}
					}
				}
				else if (!Class132.smethod_0().method_15(interface3_0, xmlDocument_0, "diffuse", (xmlDocument_0.SelectNodes("preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value"), this.DiffuseRenderTexture))
				{
					MessageBox.Show("Error when rendering diffuse complate: " + interface3_0.Errors);
				}
			}

			// Token: 0x06000AD8 RID: 2776 RVA: 0x0008D0B8 File Offset: 0x0008B2B8
			private void method_1(Device device_0)
			{
				try
				{
					this.DiffuseRenderTexture = new Texture(device_0, 1024, 1024, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
					this.FinalTexture = new Texture(device_0, 1024, 1024, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
					this.SpecularRenderTexture = new Texture(device_0, 1024, 1024, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
				}
				catch (Exception ex)
				{
					Class132.mainForm.SetStatus(ex.Message);
				}
			}

			// Token: 0x06000AD9 RID: 2777 RVA: 0x0008D140 File Offset: 0x0008B340
			public void method_2(Device device_0)
			{
				this.DiffuseRenderTexture.Dispose();
				this.FinalTexture.Dispose();
				this.SpecularRenderTexture.Dispose();
				foreach (Class104.Class109 @class in this.Items)
				{
					@class.method_10(device_0);
				}
			}

			// Token: 0x06000ADA RID: 2778 RVA: 0x0008D1B8 File Offset: 0x0008B3B8
			public void method_3(Device device_0)
			{
				this.method_1(device_0);
				foreach (Class104.Class109 @class in this.Items)
				{
					@class.method_11(device_0);
				}
			}

			// Token: 0x06000ADB RID: 2779 RVA: 0x0008D218 File Offset: 0x0008B418
			public void method_4()
			{
				if (this.PartMask != null)
				{
					this.PartMask.Dispose();
				}
				this.DiffuseRenderTexture.Dispose();
				this.FinalTexture.Dispose();
				this.SpecularRenderTexture.Dispose();
				foreach (Class104.Class109 @class in this.Items)
				{
					@class.imethod_1(true);
				}
			}

			// Token: 0x04000868 RID: 2152
			public Material material_0;

			// Token: 0x04000869 RID: 2153
			public Material material_1;

			// Token: 0x0400086A RID: 2154
			private CASP casp;

			// Token: 0x0400086B RID: 2155
			[CompilerGenerated]
			private BGEO bgeo_0;

			// Token: 0x0400086C RID: 2156
			[CompilerGenerated]
			private BGEO bgeo_1;

			// Token: 0x0400086D RID: 2157
			[CompilerGenerated]
			private BGEO bgeo_2;

			// Token: 0x0400086E RID: 2158
			[CompilerGenerated]
			private BGEO bgeo_3;

			// Token: 0x0400086F RID: 2159
			[CompilerGenerated]
			private BONE bone_0;

			// Token: 0x04000870 RID: 2160
			[CompilerGenerated]
			private BOND bond_0;

			// Token: 0x04000871 RID: 2161
			[CompilerGenerated]
			private BOND bond_1;

			// Token: 0x04000872 RID: 2162
			[CompilerGenerated]
			private BOND bond_2;

			// Token: 0x04000873 RID: 2163
			[CompilerGenerated]
			private BOND bond_3;

			// Token: 0x04000874 RID: 2164
			[CompilerGenerated]
			private BOND bond_4;

			// Token: 0x04000875 RID: 2165
			[CompilerGenerated]
			private Class28 class28_0;

			// Token: 0x04000876 RID: 2166
			[CompilerGenerated]
			private List<Class104.Class109> list_0;

			// Token: 0x04000877 RID: 2167
			[CompilerGenerated]
			private Texture texture_0;

			// Token: 0x04000878 RID: 2168
			[CompilerGenerated]
			private Texture texture_1;

			// Token: 0x04000879 RID: 2169
			[CompilerGenerated]
			private Texture texture_2;

			// Token: 0x0400087A RID: 2170
			[CompilerGenerated]
			private Texture texture_3;

			// Token: 0x0400087B RID: 2171
			[CompilerGenerated]
			private bool bool_0;

			// Token: 0x0400087C RID: 2172
			[CompilerGenerated]
			private bool bool_1;

			// Token: 0x0400087D RID: 2173
			[CompilerGenerated]
			private Class104.Class110 class110_0;
		}

		// Token: 0x020000FD RID: 253
		public enum Enum17
		{
			// Token: 0x0400087F RID: 2175
			const_0,
			// Token: 0x04000880 RID: 2176
			const_1,
			// Token: 0x04000881 RID: 2177
			const_2,
			// Token: 0x04000882 RID: 2178
			const_3
		}
	}
}
