using System;
using System.Runtime.CompilerServices;
using Sims3WorkshopSDK;

namespace ns17
{
	// Token: 0x02000048 RID: 72
	internal sealed class Class38
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060002CF RID: 719 RVA: 0x00037B38 File Offset: 0x00035D38
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x00003A6A File Offset: 0x00001C6A
		public DBPFType Type { get; set; }

		// Token: 0x060002D1 RID: 721 RVA: 0x00003A75 File Offset: 0x00001C75
		public Class38(DBPFType type)
		{
			this.Type = type;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00037B50 File Offset: 0x00035D50
		public static bool smethod_0(Class38 class38_0, Class38 class38_1)
		{
			return object.Equals(class38_0, class38_1);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00037B68 File Offset: 0x00035D68
		public static bool smethod_1(Class38 class38_0, Class38 class38_1)
		{
			return !object.Equals(class38_0, class38_1);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00037B84 File Offset: 0x00035D84
		public bool method_0()
		{
			return true;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00037B98 File Offset: 0x00035D98
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
			else if (obj.GetType() != typeof(Class38))
			{
				result = false;
			}
			else
			{
				result = this.method_1((Class38)obj);
			}
			return result;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00037BE8 File Offset: 0x00035DE8
		public bool method_1(Class38 class38_0)
		{
			bool result;
			if (object.ReferenceEquals(null, class38_0))
			{
				result = false;
			}
			else if (object.ReferenceEquals(this, class38_0))
			{
				result = true;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00037C14 File Offset: 0x00035E14
		public int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x0400028E RID: 654
		[CompilerGenerated]
		private DBPFType dbpftype_0;
	}
}
