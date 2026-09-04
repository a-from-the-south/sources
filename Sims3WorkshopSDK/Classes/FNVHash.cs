using System;
using System.Security.Cryptography;
using System.Text;

namespace Sims3WorkshopSDK.Classes
{
	// Token: 0x0200003B RID: 59
	public abstract class FNVHash : HashAlgorithm
	{
		// Token: 0x0600010B RID: 267 RVA: 0x0000265E File Offset: 0x0000085E
		protected FNVHash(ulong prime, ulong offset)
		{
			this.prime = prime;
			this.hash = offset;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00002674 File Offset: 0x00000874
		public byte[] ComputeHash(string value)
		{
			return base.ComputeHash(Encoding.ASCII.GetBytes(value.ToLowerInvariant()));
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000268C File Offset: 0x0000088C
		public override void Initialize()
		{
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000048A0 File Offset: 0x00002AA0
		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			for (int i = ibStart; i < ibStart + cbSize; i++)
			{
				this.hash *= this.prime;
				this.hash ^= (ulong)array[i];
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000268E File Offset: 0x0000088E
		protected override byte[] HashFinal()
		{
			return BitConverter.GetBytes(this.hash);
		}

		// Token: 0x04000144 RID: 324
		private ulong prime;

		// Token: 0x04000145 RID: 325
		protected ulong hash;
	}
}
