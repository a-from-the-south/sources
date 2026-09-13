using System;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns12
{
	// Token: 0x02000117 RID: 279
	internal sealed class Class127 : Frame
	{
		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000C90 RID: 3216 RVA: 0x0009E290 File Offset: 0x0009C490
		// (set) Token: 0x06000C91 RID: 3217 RVA: 0x000071BB File Offset: 0x000053BB
		public Matrix CombinedTransformationMatrix
		{
			get
			{
				return this.matrix_0;
			}
			set
			{
				this.matrix_0 = value;
			}
		}

		// Token: 0x0400099B RID: 2459
		private Matrix matrix_0 = Matrix.Identity;
	}
}
