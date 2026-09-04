using System;

namespace Package.Helper
{
	// Token: 0x020000D9 RID: 217
	public class Crc16
	{
		// Token: 0x06000B7A RID: 2938 RVA: 0x00039A28 File Offset: 0x00037C28
		public ushort ComputeChecksum(byte[] bytes)
		{
			ushort num = 0;
			for (int i = 0; i < bytes.Length; i++)
			{
				byte b = (byte)(num ^ (ushort)bytes[i]);
				num = (ushort)(num >> 8 ^ (int)this.table[(int)b]);
			}
			return num;
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x00039A5C File Offset: 0x00037C5C
		public byte[] ComputeChecksumBytes(byte[] bytes)
		{
			ushort num = this.ComputeChecksum(bytes);
			return new byte[]
			{
				(byte)(num >> 8),
				(byte)(num & 255)
			};
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x00039A8C File Offset: 0x00037C8C
		public Crc16()
		{
			ushort num = 0;
			while ((int)num < this.table.Length)
			{
				ushort num2 = 0;
				ushort num3 = num;
				for (byte b = 0; b < 8; b += 1)
				{
					if (((num2 ^ num3) & 1) != 0)
					{
						num2 = (ushort)(num2 >> 1 ^ 40961);
					}
					else
					{
						num2 = (ushort)(num2 >> 1);
					}
					num3 = (ushort)(num3 >> 1);
				}
				this.table[(int)num] = num2;
				num += 1;
			}
		}

		// Token: 0x04000579 RID: 1401
		private const ushort polynomial = 40961;

		// Token: 0x0400057A RID: 1402
		private ushort[] table = new ushort[256];
	}
}
