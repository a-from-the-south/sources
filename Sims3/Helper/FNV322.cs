using System;

namespace Package.Helper
{
	// Token: 0x020000DD RID: 221
	public class FNV322 : FNVHash
	{
		// Token: 0x06000B8F RID: 2959 RVA: 0x0000859E File Offset: 0x0000679E
		public FNV322() : base(16777619UL, 2166136261UL)
		{
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x000085B8 File Offset: 0x000067B8
		public override byte[] Hash
		{
			get
			{
				return BitConverter.GetBytes((uint)this.hash);
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x000085C6 File Offset: 0x000067C6
		public override int HashSize
		{
			get
			{
				return 32;
			}
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x000085CA File Offset: 0x000067CA
		public static uint GetHash(string text)
		{
			return BitConverter.ToUInt32(new FNV322().ComputeHash(text), 0);
		}
	}
}
