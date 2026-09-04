using System;

namespace Sims3WorkshopSDK.Classes
{
	// Token: 0x0200003C RID: 60
	public class FNV32 : FNVHash
	{
		// Token: 0x06000110 RID: 272 RVA: 0x0000269B File Offset: 0x0000089B
		public FNV32() : base(16777619UL, 2166136261UL)
		{
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000026B5 File Offset: 0x000008B5
		public FNV32(uint offset) : base(16777619UL, (ulong)offset)
		{
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000112 RID: 274 RVA: 0x000026C8 File Offset: 0x000008C8
		public override byte[] Hash
		{
			get
			{
				return BitConverter.GetBytes((uint)this.hash);
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000113 RID: 275 RVA: 0x000026D6 File Offset: 0x000008D6
		public override int HashSize
		{
			get
			{
				return 32;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000026DA File Offset: 0x000008DA
		public static uint GetHash(string text)
		{
			return BitConverter.ToUInt32(new FNV32().ComputeHash(text), 0);
		}
	}
}
