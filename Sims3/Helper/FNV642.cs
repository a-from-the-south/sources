using System;

namespace Package.Helper
{
	// Token: 0x020000DE RID: 222
	public class FNV642 : FNVHash
	{
		// Token: 0x06000B93 RID: 2963 RVA: 0x000085DD File Offset: 0x000067DD
		public FNV642() : base(1099511628211UL, 14695981039346656037UL)
		{
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000B94 RID: 2964 RVA: 0x00008591 File Offset: 0x00006791
		public override byte[] Hash
		{
			get
			{
				return BitConverter.GetBytes(this.hash);
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x000085F7 File Offset: 0x000067F7
		public override int HashSize
		{
			get
			{
				return 64;
			}
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x000085FB File Offset: 0x000067FB
		public static ulong GetHash(string text)
		{
			return BitConverter.ToUInt64(new FNV642().ComputeHash(text), 0);
		}
	}
}
