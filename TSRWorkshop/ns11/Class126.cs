using System;
using ns12;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns11
{
	// Token: 0x02000116 RID: 278
	internal sealed class Class126 : MeshContainer
	{
		// Token: 0x06000C7D RID: 3197 RVA: 0x0009E1B8 File Offset: 0x0009C3B8
		public Texture[] method_0()
		{
			return this.texture_0;
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x00007150 File Offset: 0x00005350
		public void method_1(Texture[] texture_1)
		{
			this.texture_0 = texture_1;
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0009E1D0 File Offset: 0x0009C3D0
		public BoneCombination[] method_2()
		{
			return this.boneCombination_0;
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x0000715B File Offset: 0x0000535B
		public void method_3(BoneCombination[] boneCombination_1)
		{
			this.boneCombination_0 = boneCombination_1;
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x0009E1E8 File Offset: 0x0009C3E8
		public Class127[] method_4()
		{
			return this.class127_0;
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00007166 File Offset: 0x00005366
		public void method_5(Class127[] class127_1)
		{
			this.class127_0 = class127_1;
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x0009E200 File Offset: 0x0009C400
		public Matrix[] method_6()
		{
			return this.matrix_0;
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00007171 File Offset: 0x00005371
		public void method_7(Matrix[] matrix_1)
		{
			this.matrix_0 = matrix_1;
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x0009E218 File Offset: 0x0009C418
		// (set) Token: 0x06000C86 RID: 3206 RVA: 0x0000717C File Offset: 0x0000537C
		public int iAttributeSW
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x0009E230 File Offset: 0x0009C430
		// (set) Token: 0x06000C88 RID: 3208 RVA: 0x00007187 File Offset: 0x00005387
		public bool UseSoftwareVP
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000C89 RID: 3209 RVA: 0x0009E248 File Offset: 0x0009C448
		// (set) Token: 0x06000C8A RID: 3210 RVA: 0x00007192 File Offset: 0x00005392
		public int NumberAttributes
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000C8B RID: 3211 RVA: 0x0009E260 File Offset: 0x0009C460
		// (set) Token: 0x06000C8C RID: 3212 RVA: 0x0000719D File Offset: 0x0000539D
		public int NumberInfluences
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000C8D RID: 3213 RVA: 0x0009E278 File Offset: 0x0009C478
		// (set) Token: 0x06000C8E RID: 3214 RVA: 0x000071A8 File Offset: 0x000053A8
		public int NumberPaletteEntries
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
			}
		}

		// Token: 0x04000992 RID: 2450
		private Texture[] texture_0;

		// Token: 0x04000993 RID: 2451
		private BoneCombination[] boneCombination_0;

		// Token: 0x04000994 RID: 2452
		private Matrix[] matrix_0;

		// Token: 0x04000995 RID: 2453
		private Class127[] class127_0;

		// Token: 0x04000996 RID: 2454
		private bool bool_0;

		// Token: 0x04000997 RID: 2455
		private int int_0;

		// Token: 0x04000998 RID: 2456
		private int int_1;

		// Token: 0x04000999 RID: 2457
		private int int_2;

		// Token: 0x0400099A RID: 2458
		private int int_3;
	}
}
