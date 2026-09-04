using System;

namespace Sims3WorkshopSDK.Classes
{
	// Token: 0x0200003E RID: 62
	public class FNV64 : FNVHash
	{
		// Token: 0x06000119 RID: 281 RVA: 0x00002707 File Offset: 0x00000907
		public FNV64() : base(1099511628211UL, 14695981039346656037UL)
		{
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00002721 File Offset: 0x00000921
		public FNV64(ulong offset) : base(1099511628211UL, offset)
		{
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600011B RID: 283 RVA: 0x0000268E File Offset: 0x0000088E
		public override byte[] Hash
		{
			get
			{
				return BitConverter.GetBytes(this.hash);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00002733 File Offset: 0x00000933
		public override int HashSize
		{
			get
			{
				return 64;
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00002737 File Offset: 0x00000937
		public static ulong GetHash(string text)
		{
			return BitConverter.ToUInt64(new FNV64().ComputeHash(text), 0);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000274A File Offset: 0x0000094A
		public static ulong GetHash(string text, ulong offset)
		{
			return BitConverter.ToUInt64(new FNV64(offset).ComputeHash(text), 0);
		}
	}
}
