using System;
using System.ComponentModel;
using System.Drawing;
using ns19;

namespace ns13
{
	// Token: 0x02000161 RID: 353
	internal sealed class Class163
	{
		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x060010C2 RID: 4290 RVA: 0x000BA4C0 File Offset: 0x000B86C0
		// (set) Token: 0x060010C3 RID: 4291 RVA: 0x00008DF8 File Offset: 0x00006FF8
		public Rectangle ShadowBounds
		{
			get
			{
				return this.rectangle_0[0];
			}
			set
			{
				this.rectangle_0[0] = value;
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x060010C4 RID: 4292 RVA: 0x000BA4E4 File Offset: 0x000B86E4
		// (set) Token: 0x060010C5 RID: 4293 RVA: 0x00008E0E File Offset: 0x0000700E
		public Rectangle WindowBounds
		{
			get
			{
				return this.rectangle_0[1];
			}
			set
			{
				this.rectangle_0[1] = value;
			}
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x000BA508 File Offset: 0x000B8708
		public void method_0(int int_0, int int_1)
		{
			for (int i = 0; i < this.rectangle_0.Length; i++)
			{
				this.rectangle_0[i].Offset(int_0, int_1);
			}
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x000BA540 File Offset: 0x000B8740
		internal void method_1(int int_0, int int_1)
		{
			for (int i = 1; i < this.rectangle_0.Length; i++)
			{
				this.rectangle_0[i].Offset(int_0, int_1);
			}
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x000BA578 File Offset: 0x000B8778
		public Size method_2()
		{
			return Rectangle.Union(this.rectangle_0[0], this.rectangle_0[1]).Size;
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x000BA5B8 File Offset: 0x000B87B8
		public Rectangle method_3(Enum23 enum23_0)
		{
			if (!Enum.IsDefined(typeof(Enum23), enum23_0))
			{
				throw new InvalidEnumArgumentException("element", (int)enum23_0, typeof(Enum23));
			}
			return this.rectangle_0[(int)(enum23_0 + 2)];
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x000BA60C File Offset: 0x000B880C
		public void method_4(Enum23 enum23_0, Rectangle rectangle_1)
		{
			if (!Enum.IsDefined(typeof(Enum23), enum23_0))
			{
				throw new InvalidEnumArgumentException("element", (int)enum23_0, typeof(Enum23));
			}
			this.rectangle_0[(int)(enum23_0 + 2)] = rectangle_1;
		}

		// Token: 0x04000BA3 RID: 2979
		private Rectangle[] rectangle_0 = new Rectangle[9];
	}
}
