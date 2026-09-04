using System;

namespace Sims3WorkshopSDK.Classes
{
	// Token: 0x0200003D RID: 61
	public class FNV32_ : FNVHash
	{
		// Token: 0x06000115 RID: 277 RVA: 0x000026ED File Offset: 0x000008ED
		public FNV32_() : base(66370UL, 2166136261UL)
		{
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000116 RID: 278 RVA: 0x000026C8 File Offset: 0x000008C8
		public override byte[] Hash
		{
			get
			{
				return BitConverter.GetBytes((uint)this.hash);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000117 RID: 279 RVA: 0x000026D6 File Offset: 0x000008D6
		public override int HashSize
		{
			get
			{
				return 32;
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000026DA File Offset: 0x000008DA
		public static uint GetHash(string text)
		{
			return BitConverter.ToUInt32(new FNV32().ComputeHash(text), 0);
		}
	}
}
