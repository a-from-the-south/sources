using System;
using System.Collections;
using ns19;
using ns6;

namespace ns9
{
	// Token: 0x0200014B RID: 331
	internal sealed class Class147 : CollectionBase
	{
		// Token: 0x06000FE1 RID: 4065 RVA: 0x000085EC File Offset: 0x000067EC
		internal Class147(Wizard owner)
		{
			this.owner = owner;
		}

		// Token: 0x17000391 RID: 913
		public Class146 this[int int_0]
		{
			get
			{
				return (Class146)base.List[int_0];
			}
			set
			{
				base.List[int_0] = value;
			}
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x000B7F68 File Offset: 0x000B6168
		public int Add(Class146 value)
		{
			return base.List.Add(value);
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x000B7F88 File Offset: 0x000B6188
		public void method_0(Class146[] class146_0)
		{
			foreach (Class146 value in class146_0)
			{
				this.Add(value);
			}
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x000B7FB4 File Offset: 0x000B61B4
		public int method_1(Class146 class146_0)
		{
			return base.List.IndexOf(class146_0);
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x0000860E File Offset: 0x0000680E
		public void method_2(int int_0, Class146 class146_0)
		{
			base.List.Insert(int_0, class146_0);
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x0000861F File Offset: 0x0000681F
		public void method_3(Class146 class146_0)
		{
			base.List.Remove(class146_0);
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x000B7FD4 File Offset: 0x000B61D4
		public bool method_4(Class146 class146_0)
		{
			return base.List.Contains(class146_0);
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x0000862F File Offset: 0x0000682F
		protected void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete(index, value);
			this.owner.SelectedIndex = index;
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x000B7FF4 File Offset: 0x000B61F4
		protected void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, value);
			if (this.owner.SelectedIndex == index)
			{
				if (index < base.InnerList.Count)
				{
					this.owner.SelectedIndex = index;
				}
				else
				{
					this.owner.SelectedIndex = base.InnerList.Count - 1;
				}
			}
		}

		// Token: 0x04000B56 RID: 2902
		private Wizard owner;
	}
}
