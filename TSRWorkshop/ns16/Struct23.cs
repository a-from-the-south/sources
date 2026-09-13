using System;
using System.Drawing;
using System.Windows.Forms;

namespace ns16
{
	// Token: 0x0200018D RID: 397
	internal struct Struct23
	{
		// Token: 0x06001202 RID: 4610 RVA: 0x000098A5 File Offset: 0x00007AA5
		public Struct23(Size size, ColorDepth colorDepth)
		{
			this.size = size;
			this.colorDepth = colorDepth;
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06001203 RID: 4611 RVA: 0x000BF158 File Offset: 0x000BD358
		// (set) Token: 0x06001204 RID: 4612 RVA: 0x000098B7 File Offset: 0x00007AB7
		public Size x437e3b626c0fdd43
		{
			get
			{
				return this.size;
			}
			set
			{
				this.size = value;
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06001205 RID: 4613 RVA: 0x000BF170 File Offset: 0x000BD370
		// (set) Token: 0x06001206 RID: 4614 RVA: 0x000098C2 File Offset: 0x00007AC2
		public ColorDepth x94af564f5d0fedbf
		{
			get
			{
				return this.colorDepth;
			}
			set
			{
				this.colorDepth = value;
			}
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x000BF188 File Offset: 0x000BD388
		public bool Equals(object obj)
		{
			bool result;
			if (obj is Struct23)
			{
				Struct23 @struct = (Struct23)obj;
				if (@struct.size == this.size)
				{
					result = (@struct.colorDepth == this.colorDepth);
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001208 RID: 4616 RVA: 0x000BF1D8 File Offset: 0x000BD3D8
		public int GetHashCode()
		{
			return this.size.GetHashCode() ^ this.colorDepth.GetHashCode();
		}

		// Token: 0x06001209 RID: 4617 RVA: 0x000BF208 File Offset: 0x000BD408
		public string ToString()
		{
			return string.Format("{0}x{1} {2} bpp", this.x437e3b626c0fdd43.Width, this.x437e3b626c0fdd43.Height, (int)this.x94af564f5d0fedbf);
		}

		// Token: 0x04000C88 RID: 3208
		private Size size;

		// Token: 0x04000C89 RID: 3209
		private ColorDepth colorDepth;

		// Token: 0x04000C8A RID: 3210
		public static Struct23 struct23_0 = default(Struct23);
	}
}
