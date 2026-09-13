using System;
using System.Runtime.CompilerServices;
using Package.Sims3Files;

namespace ns7
{
	// Token: 0x02000046 RID: 70
	internal sealed class Class36
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0003788C File Offset: 0x00035A8C
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x00003A17 File Offset: 0x00001C17
		public CASP.AgeGender AgeMask { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x000378A4 File Offset: 0x00035AA4
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00003A22 File Offset: 0x00001C22
		public CASP.Type TypeMask { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x000378BC File Offset: 0x00035ABC
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00003A2D File Offset: 0x00001C2D
		public CASP.ClothingCategory CategoryMask { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x000378D4 File Offset: 0x00035AD4
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00003A38 File Offset: 0x00001C38
		public CASP.Species SpeciesMask { get; set; }

		// Token: 0x060002C8 RID: 712 RVA: 0x00003A43 File Offset: 0x00001C43
		public Class36(CASP.Species species, CASP.AgeGender age, CASP.Type type, CASP.ClothingCategory category)
		{
			this.AgeMask = age;
			this.TypeMask = type;
			this.CategoryMask = category;
			this.SpeciesMask = species;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x000378EC File Offset: 0x00035AEC
		public bool method_0(CASP.Species species_1, CASP.AgeGender ageGender_1, CASP.Type type_1, CASP.ClothingCategory clothingCategory_1)
		{
			bool result;
			if (((species_1 & CASP.Species.SpeciesMask) != this.SpeciesMask && this.SpeciesMask != (CASP.Species)0U && ((species_1 & CASP.Species.SpeciesMask) != (CASP.Species)0U || this.SpeciesMask != CASP.Species.Human)) || ((ageGender_1 & this.AgeMask) != this.AgeMask && this.AgeMask != CASP.AgeGender.None) || ((type_1 & this.TypeMask) != this.TypeMask && this.TypeMask != CASP.Type.None))
			{
				result = false;
			}
			else if ((clothingCategory_1 & this.CategoryMask) != this.CategoryMask)
			{
				result = (this.CategoryMask == CASP.ClothingCategory.None);
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0003797C File Offset: 0x00035B7C
		public bool Equals(object obj)
		{
			bool result;
			if (object.ReferenceEquals(null, obj))
			{
				result = false;
			}
			else if (object.ReferenceEquals(this, obj))
			{
				result = true;
			}
			else if (obj.GetType() != typeof(Class36))
			{
				result = false;
			}
			else
			{
				result = this.method_1((Class36)obj);
			}
			return result;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000379CC File Offset: 0x00035BCC
		public bool method_1(Class36 class36_0)
		{
			bool result;
			if (object.ReferenceEquals(null, class36_0))
			{
				result = false;
			}
			else if (object.ReferenceEquals(this, class36_0))
			{
				result = true;
			}
			else if (object.Equals(class36_0.SpeciesMask, this.SpeciesMask) && object.Equals(class36_0.AgeMask, this.AgeMask) && object.Equals(class36_0.TypeMask, this.TypeMask))
			{
				result = object.Equals(class36_0.CategoryMask, this.CategoryMask);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00037A70 File Offset: 0x00035C70
		public int GetHashCode()
		{
			int num = this.AgeMask.GetHashCode();
			num = (num * 397 ^ this.TypeMask.GetHashCode());
			num = (num * 397 ^ this.CategoryMask.GetHashCode());
			return num * 397 ^ this.SpeciesMask.GetHashCode();
		}

		// Token: 0x0400028A RID: 650
		[CompilerGenerated]
		private CASP.AgeGender ageGender_0;

		// Token: 0x0400028B RID: 651
		[CompilerGenerated]
		private CASP.Type type_0;

		// Token: 0x0400028C RID: 652
		[CompilerGenerated]
		private CASP.ClothingCategory clothingCategory_0;

		// Token: 0x0400028D RID: 653
		[CompilerGenerated]
		private CASP.Species species_0;
	}
}
