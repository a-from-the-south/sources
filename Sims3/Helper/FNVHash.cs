using System;
using System.Security.Cryptography;
using System.Text;

namespace Package.Helper
{
	// Token: 0x020000DC RID: 220
	public abstract class FNVHash : HashAlgorithm
	{
		// Token: 0x06000B8A RID: 2954 RVA: 0x0000855C File Offset: 0x0000675C
		protected FNVHash(ulong prime, ulong offset)
		{
			this.prime = prime;
			this.offset = offset;
			this.hash = offset;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x00008579 File Offset: 0x00006779
		public byte[] ComputeHash(string value)
		{
			return base.ComputeHash(Encoding.ASCII.GetBytes(value.ToLowerInvariant()));
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x000032EA File Offset: 0x000014EA
		public override void Initialize()
		{
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x00039DD4 File Offset: 0x00037FD4
		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			for (int i = ibStart; i < ibStart + cbSize; i++)
			{
				this.hash *= this.prime;
				this.hash ^= (ulong)array[i];
			}
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x00008591 File Offset: 0x00006791
		protected override byte[] HashFinal()
		{
			return BitConverter.GetBytes(this.hash);
		}

		// Token: 0x0400058E RID: 1422
		private ulong prime;

		// Token: 0x0400058F RID: 1423
		private ulong offset;

		// Token: 0x04000590 RID: 1424
		protected ulong hash;
	}
}
