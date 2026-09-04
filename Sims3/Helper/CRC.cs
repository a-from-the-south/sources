using System;
using System.Collections;
using System.Security.Cryptography;

namespace Package.Helper
{
	// Token: 0x020000D8 RID: 216
	public class CRC : HashAlgorithm
	{
		// Token: 0x06000B73 RID: 2931 RVA: 0x00039640 File Offset: 0x00037840
		public CRC(CRCParameters param)
		{
			lock (this)
			{
				if (param == null)
				{
					throw new ArgumentNullException("param", "The CRCParameters cannot be null.");
				}
				this.parameters = param;
				this.HashSizeValue = param.Order;
				CRC.BuildLookup(param);
				this.lookup = (long[])CRC.lookupTables[param];
				this.registerMask = (long)(Math.Pow(2.0, (double)(param.Order - 8)) - 1.0);
				this.Initialize();
			}
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0000849F File Offset: 0x0000669F
		static CRC()
		{
			CRC.BuildLookup(CRCParameters.GetParameters(CRCStandard.CRC32_REVERSED));
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x000396EC File Offset: 0x000378EC
		private static void BuildLookup(CRCParameters param)
		{
			if (CRC.lookupTables.Contains(param))
			{
				return;
			}
			long[] array = new long[256];
			long num = 1L << param.Order - 1;
			long num2 = (long)((1 << param.Order - 1) - 1 << 1 | 1);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (long)i;
				if (param.ReflectInput)
				{
					array[i] = CRC.Reflect((long)i, 8);
				}
				array[i] <<= param.Order - 8;
				for (int j = 0; j < 8; j++)
				{
					if ((array[i] & num) != 0L)
					{
						array[i] = (array[i] << 1 ^ param.Polynomial);
					}
					else
					{
						array[i] <<= 1;
					}
				}
				if (param.ReflectInput)
				{
					array[i] = CRC.Reflect(array[i], param.Order);
				}
				array[i] &= num2;
			}
			CRC.lookupTables.Add(param, array);
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x000397E0 File Offset: 0x000379E0
		public override void Initialize()
		{
			lock (this)
			{
				this.State = 0;
				this.checksum = this.parameters.InitialValue;
				if (this.parameters.ReflectInput)
				{
					this.checksum = CRC.Reflect(this.checksum, this.parameters.Order);
				}
			}
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x00039858 File Offset: 0x00037A58
		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			lock (this)
			{
				for (int i = ibStart; i < cbSize - ibStart; i++)
				{
					checked
					{
						if (this.parameters.ReflectInput)
						{
							this.checksum = ((this.checksum >> 8 & this.registerMask) ^ this.lookup[(int)((IntPtr)((this.checksum ^ (long)(unchecked((ulong)array[i]))) & 255L))]);
						}
						else
						{
							this.checksum = (this.checksum << 8 ^ this.lookup[(int)((IntPtr)(unchecked(this.checksum >> this.parameters.Order - 8 ^ (long)((ulong)array[i])) & 255L))]);
						}
					}
				}
			}
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x00039920 File Offset: 0x00037B20
		protected override byte[] HashFinal()
		{
			byte[] result;
			lock (this)
			{
				this.checksum ^= (long)((ulong)((uint)this.parameters.FinalXORValue));
				int num = this.parameters.Order / 8;
				if (this.parameters.Order - num * 8 > 0)
				{
					num++;
				}
				byte[] array = new byte[num];
				int i = num - 1;
				int num2 = 0;
				while (i >= 0)
				{
					array[i] = (byte)(this.checksum >> num2 & 255L);
					i--;
					num2 += 8;
				}
				result = array;
			}
			return result;
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x000399D8 File Offset: 0x00037BD8
		private static long Reflect(long data, int numBits)
		{
			long num = data;
			for (int i = 0; i < numBits; i++)
			{
				long num2 = 1L << numBits - 1 - i;
				if ((num & 1L) != 0L)
				{
					data |= num2;
				}
				else
				{
					data &= ~num2;
				}
				num >>= 1;
			}
			return data;
		}

		// Token: 0x04000574 RID: 1396
		private static Hashtable lookupTables = new Hashtable();

		// Token: 0x04000575 RID: 1397
		private CRCParameters parameters;

		// Token: 0x04000576 RID: 1398
		private long[] lookup;

		// Token: 0x04000577 RID: 1399
		private long checksum;

		// Token: 0x04000578 RID: 1400
		private long registerMask;
	}
}
