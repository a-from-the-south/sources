using System;

namespace Sims3WorkshopSDK.Classes
{
	// Token: 0x0200003F RID: 63
	public class FNV64_ : FNVHash
	{
		// Token: 0x0600011F RID: 287 RVA: 0x0000275E File Offset: 0x0000095E
		public FNV64_() : base(1099511694146UL, 14695981039346656037UL)
		{
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000120 RID: 288 RVA: 0x0000268E File Offset: 0x0000088E
		public override byte[] Hash
		{
			get
			{
				return BitConverter.GetBytes(this.hash);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00002733 File Offset: 0x00000933
		public override int HashSize
		{
			get
			{
				return 64;
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00002778 File Offset: 0x00000978
		public static ulong GetHash(string text)
		{
			return BitConverter.ToUInt64(new FNV64_().ComputeHash(text), 0);
		}
	}
}
