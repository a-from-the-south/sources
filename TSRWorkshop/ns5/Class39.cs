using System;
using System.Runtime.CompilerServices;
using Package.Sims3Files;

namespace ns5
{
	// Token: 0x02000049 RID: 73
	internal sealed class Class39
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00037C2C File Offset: 0x00035E2C
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00003A86 File Offset: 0x00001C86
		public OBJD.Category CategoryMask { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060002DA RID: 730 RVA: 0x00037C44 File Offset: 0x00035E44
		// (set) Token: 0x060002DB RID: 731 RVA: 0x00003A91 File Offset: 0x00001C91
		public OBJD.SubCategory SubCategoryMask { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060002DC RID: 732 RVA: 0x00037C5C File Offset: 0x00035E5C
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00003A9C File Offset: 0x00001C9C
		public OBJD.Build BuildMask { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00037C74 File Offset: 0x00035E74
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00003AA7 File Offset: 0x00001CA7
		public OBJD.Room RoomMask { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00037C8C File Offset: 0x00035E8C
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00003AB2 File Offset: 0x00001CB2
		public OBJD.SubRoom SubRoomMask { get; set; }

		// Token: 0x060002E2 RID: 738 RVA: 0x00003ABD File Offset: 0x00001CBD
		public Class39(OBJD.Category categoryMask, OBJD.SubCategory subCategoryMask, OBJD.SubRoom subRoomMask, OBJD.Room roomMask, OBJD.Build buildMask)
		{
			this.CategoryMask = categoryMask;
			this.SubCategoryMask = subCategoryMask;
			this.SubRoomMask = subRoomMask;
			this.RoomMask = roomMask;
			this.BuildMask = buildMask;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00037CA4 File Offset: 0x00035EA4
		public int All
		{
			get
			{
				return (int)(this.CategoryMask + (uint)((int)this.SubCategoryMask) + (uint)((int)this.SubRoomMask) + (uint)this.RoomMask + (uint)this.BuildMask);
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00037B50 File Offset: 0x00035D50
		public static bool smethod_0(Class39 class39_0, Class39 class39_1)
		{
			return object.Equals(class39_0, class39_1);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00037B68 File Offset: 0x00035D68
		public static bool smethod_1(Class39 class39_0, Class39 class39_1)
		{
			return !object.Equals(class39_0, class39_1);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00037CDC File Offset: 0x00035EDC
		public bool method_0(OBJD.Category category_1, OBJD.SubCategory subCategory_1, OBJD.SubRoom subRoom_1, OBJD.Room room_1, OBJD.Build build_1)
		{
			bool result;
			if (((category_1 & this.CategoryMask) == this.CategoryMask || this.CategoryMask == (OBJD.Category)0U) && ((subCategory_1 & this.SubCategoryMask) == this.SubCategoryMask || this.SubCategoryMask == ~OBJD.SubCategory.All) && ((room_1 & this.RoomMask) == this.RoomMask || this.RoomMask == ~OBJD.Room.All))
			{
				if ((subRoom_1 & this.SubRoomMask) != this.SubRoomMask)
				{
					if (this.SubRoomMask != (OBJD.SubRoom)0UL)
					{
						goto IL_75;
					}
				}
				result = ((build_1 & this.BuildMask) == this.BuildMask || this.BuildMask == ~OBJD.Build.All);
				goto IL_95;
			}
			IL_75:
			result = false;
			IL_95:
			return result;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00037D84 File Offset: 0x00035F84
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
			else if (obj.GetType() != typeof(Class39))
			{
				result = false;
			}
			else
			{
				result = this.method_1((Class39)obj);
			}
			return result;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00037DD4 File Offset: 0x00035FD4
		public bool method_1(Class39 class39_0)
		{
			bool result;
			if (object.ReferenceEquals(null, class39_0))
			{
				result = false;
			}
			else if (object.ReferenceEquals(this, class39_0))
			{
				result = true;
			}
			else if (object.Equals(class39_0.CategoryMask, this.CategoryMask) && object.Equals(class39_0.SubCategoryMask, this.SubCategoryMask) && object.Equals(class39_0.BuildMask, this.BuildMask) && object.Equals(class39_0.RoomMask, this.RoomMask))
			{
				result = object.Equals(class39_0.SubRoomMask, this.SubRoomMask);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00037E98 File Offset: 0x00036098
		public int GetHashCode()
		{
			int num = this.CategoryMask.GetHashCode();
			num = (num * 397 ^ this.SubCategoryMask.GetHashCode());
			num = (num * 397 ^ this.BuildMask.GetHashCode());
			num = (num * 397 ^ this.RoomMask.GetHashCode());
			return num * 397 ^ this.SubRoomMask.GetHashCode();
		}

		// Token: 0x0400028F RID: 655
		[CompilerGenerated]
		private OBJD.Category category_0;

		// Token: 0x04000290 RID: 656
		[CompilerGenerated]
		private OBJD.SubCategory subCategory_0;

		// Token: 0x04000291 RID: 657
		[CompilerGenerated]
		private OBJD.Build build_0;

		// Token: 0x04000292 RID: 658
		[CompilerGenerated]
		private OBJD.Room room_0;

		// Token: 0x04000293 RID: 659
		[CompilerGenerated]
		private OBJD.SubRoom subRoom_0;
	}
}
