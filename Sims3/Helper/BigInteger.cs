using System;
using System.Runtime.CompilerServices;

namespace Package.Helper
{
	// Token: 0x020000D4 RID: 212
	public class BigInteger
	{
		// Token: 0x06000B15 RID: 2837 RVA: 0x00008316 File Offset: 0x00006516
		public BigInteger()
		{
			this.data = new uint[70];
			this.dataLength = 1;
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x00034880 File Offset: 0x00032A80
		public BigInteger(long value)
		{
			this.data = new uint[70];
			long num = value;
			this.dataLength = 0;
			while (value != 0L && this.dataLength < 70)
			{
				this.data[this.dataLength] = (uint)(value & 4294967295L);
				value >>= 32;
				this.dataLength++;
			}
			if (num > 0L)
			{
				if (value != 0L || (this.data[69] & 2147483648U) != 0U)
				{
					throw new ArithmeticException("Positive overflow in constructor.");
				}
			}
			else if (num < 0L && (value != -1L || (this.data[this.dataLength - 1] & 2147483648U) == 0U))
			{
				throw new ArithmeticException("Negative underflow in constructor.");
			}
			if (this.dataLength == 0)
			{
				this.dataLength = 1;
			}
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0003495C File Offset: 0x00032B5C
		public BigInteger(ulong value)
		{
			this.data = new uint[70];
			this.dataLength = 0;
			while (value != 0UL && this.dataLength < 70)
			{
				this.data[this.dataLength] = (uint)(value & 4294967295UL);
				value >>= 32;
				this.dataLength++;
			}
			if (value == 0UL && (this.data[69] & 2147483648U) == 0U)
			{
				if (this.dataLength == 0)
				{
					this.dataLength = 1;
				}
				return;
			}
			throw new ArithmeticException("Positive overflow in constructor.");
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x000349F0 File Offset: 0x00032BF0
		public BigInteger(BigInteger bi)
		{
			this.data = new uint[70];
			this.dataLength = bi.dataLength;
			for (int i = 0; i < this.dataLength; i++)
			{
				this.data[i] = bi.data[i];
			}
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x00034A40 File Offset: 0x00032C40
		public BigInteger(string value, int radix)
		{
			BigInteger bi = new BigInteger(1L);
			BigInteger bigInteger = new BigInteger();
			value = value.ToUpper().Trim();
			int num = 0;
			if (value[0] == '-')
			{
				num = 1;
			}
			for (int i = value.Length - 1; i >= num; i--)
			{
				int num2 = (int)value[i];
				if (num2 >= 48 && num2 <= 57)
				{
					num2 -= 48;
				}
				else if (num2 >= 65 && num2 <= 90)
				{
					num2 = num2 - 65 + 10;
				}
				else
				{
					num2 = 9999999;
				}
				if (num2 >= radix)
				{
					throw new ArithmeticException("Invalid string in constructor.");
				}
				if (value[0] == '-')
				{
					num2 = -num2;
				}
				bigInteger += bi * num2;
				if (i - 1 >= num)
				{
					bi *= radix;
				}
			}
			if (value[0] == '-')
			{
				if ((bigInteger.data[69] & 2147483648U) == 0U)
				{
					throw new ArithmeticException("Negative underflow in constructor.");
				}
			}
			else if ((bigInteger.data[69] & 2147483648U) != 0U)
			{
				throw new ArithmeticException("Positive overflow in constructor.");
			}
			this.data = new uint[70];
			for (int j = 0; j < bigInteger.dataLength; j++)
			{
				this.data[j] = bigInteger.data[j];
			}
			this.dataLength = bigInteger.dataLength;
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x00034BAC File Offset: 0x00032DAC
		public BigInteger(byte[] inData)
		{
			this.dataLength = inData.Length >> 2;
			int num = inData.Length & 3;
			if (num != 0)
			{
				this.dataLength++;
			}
			if (this.dataLength > 70)
			{
				throw new ArithmeticException("Byte overflow in constructor.");
			}
			this.data = new uint[70];
			int i = inData.Length - 1;
			int num2 = 0;
			while (i >= 3)
			{
				this.data[num2] = (uint)(((int)inData[i - 3] << 24) + ((int)inData[i - 2] << 16) + ((int)inData[i - 1] << 8) + (int)inData[i]);
				i -= 4;
				num2++;
			}
			if (num == 1)
			{
				this.data[this.dataLength - 1] = (uint)inData[0];
			}
			else if (num == 2)
			{
				this.data[this.dataLength - 1] = (uint)(((int)inData[0] << 8) + (int)inData[1]);
			}
			else if (num == 3)
			{
				this.data[this.dataLength - 1] = (uint)(((int)inData[0] << 16) + ((int)inData[1] << 8) + (int)inData[2]);
			}
			while (this.dataLength > 1 && this.data[this.dataLength - 1] == 0U)
			{
				this.dataLength--;
			}
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x00034CC4 File Offset: 0x00032EC4
		public BigInteger(byte[] inData, int inLen)
		{
			this.dataLength = inLen >> 2;
			int num = inLen & 3;
			if (num != 0)
			{
				this.dataLength++;
			}
			if (this.dataLength <= 70 && inLen <= inData.Length)
			{
				this.data = new uint[70];
				int i = inLen - 1;
				int num2 = 0;
				while (i >= 3)
				{
					this.data[num2] = (uint)(((int)inData[i - 3] << 24) + ((int)inData[i - 2] << 16) + ((int)inData[i - 1] << 8) + (int)inData[i]);
					i -= 4;
					num2++;
				}
				if (num == 1)
				{
					this.data[this.dataLength - 1] = (uint)inData[0];
				}
				else if (num == 2)
				{
					this.data[this.dataLength - 1] = (uint)(((int)inData[0] << 8) + (int)inData[1]);
				}
				else if (num == 3)
				{
					this.data[this.dataLength - 1] = (uint)(((int)inData[0] << 16) + ((int)inData[1] << 8) + (int)inData[2]);
				}
				if (this.dataLength == 0)
				{
					this.dataLength = 1;
				}
				while (this.dataLength > 1 && this.data[this.dataLength - 1] == 0U)
				{
					this.dataLength--;
				}
				return;
			}
			throw new ArithmeticException("Byte overflow in constructor.");
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x00034DF0 File Offset: 0x00032FF0
		public BigInteger(uint[] inData)
		{
			this.dataLength = inData.Length;
			if (this.dataLength > 70)
			{
				throw new ArithmeticException("Byte overflow in constructor.");
			}
			this.data = new uint[70];
			int i = this.dataLength - 1;
			int num = 0;
			while (i >= 0)
			{
				this.data[num] = inData[i];
				i--;
				num++;
			}
			while (this.dataLength > 1 && this.data[this.dataLength - 1] == 0U)
			{
				this.dataLength--;
			}
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x00008332 File Offset: 0x00006532
		public static implicit operator BigInteger(long value)
		{
			return new BigInteger(value);
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0000833A File Offset: 0x0000653A
		public static implicit operator BigInteger(ulong value)
		{
			return new BigInteger(value);
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x00008342 File Offset: 0x00006542
		public static implicit operator BigInteger(int value)
		{
			return new BigInteger((long)value);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0000834B File Offset: 0x0000654B
		public static implicit operator BigInteger(uint value)
		{
			return new BigInteger((ulong)value);
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x00034E7C File Offset: 0x0003307C
		public static BigInteger operator +(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			bigInteger.dataLength = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
			long num = 0L;
			for (int i = 0; i < bigInteger.dataLength; i++)
			{
				long num2 = (long)((ulong)bi1.data[i] + (ulong)bi2.data[i] + (ulong)num);
				num = num2 >> 32;
				bigInteger.data[i] = (uint)(num2 & 4294967295L);
			}
			if (num != 0L && bigInteger.dataLength < 70)
			{
				bigInteger.data[bigInteger.dataLength] = (uint)num;
				bigInteger.dataLength++;
			}
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0U)
			{
				bigInteger.dataLength--;
			}
			int num3 = 69;
			if ((bi1.data[69] & 2147483648U) == (bi2.data[69] & 2147483648U) && (bigInteger.data[num3] & 2147483648U) != (bi1.data[num3] & 2147483648U))
			{
				throw new ArithmeticException();
			}
			return bigInteger;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x00034F9C File Offset: 0x0003319C
		public static BigInteger operator ++(BigInteger bi1)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			long num = 1L;
			int num2 = 0;
			while (num != 0L && num2 < 70)
			{
				long num3 = (long)((ulong)bigInteger.data[num2]);
				num3 += 1L;
				bigInteger.data[num2] = (uint)(num3 & 4294967295L);
				num = num3 >> 32;
				num2++;
			}
			if (num2 > bigInteger.dataLength)
			{
				bigInteger.dataLength = num2;
			}
			else
			{
				while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0U)
				{
					bigInteger.dataLength--;
				}
			}
			int num4 = 69;
			if ((bi1.data[69] & 2147483648U) == 0U && (bigInteger.data[num4] & 2147483648U) != (bi1.data[num4] & 2147483648U))
			{
				throw new ArithmeticException("Overflow in ++.");
			}
			return bigInteger;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x00035074 File Offset: 0x00033274
		public static BigInteger operator -(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			bigInteger.dataLength = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
			long num = 0L;
			for (int i = 0; i < bigInteger.dataLength; i++)
			{
				long num2 = (long)((ulong)bi1.data[i] - (ulong)bi2.data[i] - (ulong)num);
				bigInteger.data[i] = (uint)(num2 & 4294967295L);
				if (num2 < 0L)
				{
					num = 1L;
				}
				else
				{
					num = 0L;
				}
			}
			if (num != 0L)
			{
				for (int j = bigInteger.dataLength; j < 70; j++)
				{
					bigInteger.data[j] = uint.MaxValue;
				}
				bigInteger.dataLength = 70;
			}
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0U)
			{
				bigInteger.dataLength--;
			}
			int num3 = 69;
			if ((bi1.data[69] & 2147483648U) != (bi2.data[69] & 2147483648U) && (bigInteger.data[num3] & 2147483648U) != (bi1.data[num3] & 2147483648U))
			{
				throw new ArithmeticException();
			}
			return bigInteger;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x000351B0 File Offset: 0x000333B0
		public static BigInteger operator --(BigInteger bi1)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			bool flag = true;
			int num = 0;
			while (flag && num < 70)
			{
				long num2 = (long)((ulong)bigInteger.data[num]);
				num2 -= 1L;
				bigInteger.data[num] = (uint)(num2 & 4294967295L);
				if (num2 >= 0L)
				{
					flag = false;
				}
				num++;
			}
			if (num > bigInteger.dataLength)
			{
				bigInteger.dataLength = num;
			}
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0U)
			{
				bigInteger.dataLength--;
			}
			int num3 = 69;
			if ((bi1.data[69] & 2147483648U) != 0U && (bigInteger.data[num3] & 2147483648U) != (bi1.data[num3] & 2147483648U))
			{
				throw new ArithmeticException("Underflow in --.");
			}
			return bigInteger;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0003528C File Offset: 0x0003348C
		public static BigInteger operator *(BigInteger bi1, BigInteger bi2)
		{
			int num = 69;
			bool flag = false;
			bool flag2 = false;
			try
			{
				if ((bi1.data[num] & 2147483648U) != 0U)
				{
					flag = true;
					bi1 = -bi1;
				}
				if ((bi2.data[num] & 2147483648U) != 0U)
				{
					flag2 = true;
					bi2 = -bi2;
				}
			}
			catch (Exception)
			{
			}
			BigInteger bigInteger = new BigInteger();
			try
			{
				for (int i = 0; i < bi1.dataLength; i++)
				{
					if (bi1.data[i] != 0U)
					{
						ulong num2 = 0UL;
						int j = 0;
						int num3 = i;
						while (j < bi2.dataLength)
						{
							ulong num4 = (ulong)bi1.data[i] * (ulong)bi2.data[j] + (ulong)bigInteger.data[num3] + num2;
							bigInteger.data[num3] = (uint)(num4 & 4294967295UL);
							num2 = num4 >> 32;
							j++;
							num3++;
						}
						if (num2 != 0UL)
						{
							bigInteger.data[i + bi2.dataLength] = (uint)num2;
						}
					}
				}
			}
			catch (Exception)
			{
				throw new ArithmeticException("Multiplication overflow.");
			}
			bigInteger.dataLength = bi1.dataLength + bi2.dataLength;
			if (bigInteger.dataLength > 70)
			{
				bigInteger.dataLength = 70;
			}
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0U)
			{
				bigInteger.dataLength--;
			}
			if ((bigInteger.data[num] & 2147483648U) != 0U)
			{
				if (flag != flag2 && bigInteger.data[num] == 2147483648U)
				{
					if (bigInteger.dataLength == 1)
					{
						return bigInteger;
					}
					bool flag3 = true;
					int num5 = 0;
					while (num5 < bigInteger.dataLength - 1 && flag3)
					{
						if (bigInteger.data[num5] != 0U)
						{
							flag3 = false;
						}
						num5++;
					}
					if (flag3)
					{
						return bigInteger;
					}
				}
				throw new ArithmeticException("Multiplication overflow.");
			}
			if (flag != flag2)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x00008354 File Offset: 0x00006554
		public static BigInteger operator <<(BigInteger bi1, int shiftVal)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			bigInteger.dataLength = BigInteger.shiftLeft(bigInteger.data, shiftVal);
			return bigInteger;
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0003547C File Offset: 0x0003367C
		private static int shiftLeft(uint[] buffer, int shiftVal)
		{
			int num = 32;
			int num2 = buffer.Length;
			while (num2 > 1 && buffer[num2 - 1] == 0U)
			{
				num2--;
			}
			for (int i = shiftVal; i > 0; i -= num)
			{
				if (i < num)
				{
					num = i;
				}
				ulong num3 = 0UL;
				for (int j = 0; j < num2; j++)
				{
					ulong num4 = (ulong)buffer[j] << num;
					num4 |= num3;
					buffer[j] = (uint)(num4 & 4294967295UL);
					num3 = num4 >> 32;
				}
				if (num3 != 0UL && num2 + 1 <= buffer.Length)
				{
					buffer[num2] = (uint)num3;
					num2++;
				}
			}
			return num2;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0003550C File Offset: 0x0003370C
		public static BigInteger operator >>(BigInteger bi1, int shiftVal)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			bigInteger.dataLength = BigInteger.shiftRight(bigInteger.data, shiftVal);
			if ((bi1.data[69] & 2147483648U) != 0U)
			{
				for (int i = 69; i >= bigInteger.dataLength; i--)
				{
					bigInteger.data[i] = uint.MaxValue;
				}
				uint num = 2147483648U;
				int num2 = 0;
				while (num2 < 32 && (bigInteger.data[bigInteger.dataLength - 1] & num) == 0U)
				{
					bigInteger.data[bigInteger.dataLength - 1] |= num;
					num >>= 1;
					num2++;
				}
				bigInteger.dataLength = 70;
			}
			return bigInteger;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x000355AC File Offset: 0x000337AC
		private static int shiftRight(uint[] buffer, int shiftVal)
		{
			int num = 32;
			int num2 = 0;
			int num3 = buffer.Length;
			while (num3 > 1 && buffer[num3 - 1] == 0U)
			{
				num3--;
			}
			for (int i = shiftVal; i > 0; i -= num)
			{
				if (i < num)
				{
					num = i;
					num2 = 32 - num;
				}
				ulong num4 = 0UL;
				for (int j = num3 - 1; j >= 0; j--)
				{
					ulong num5 = (ulong)buffer[j] >> num;
					num5 |= num4;
					num4 = (ulong)buffer[j] << num2;
					buffer[j] = (uint)num5;
				}
			}
			while (num3 > 1 && buffer[num3 - 1] == 0U)
			{
				num3--;
			}
			return num3;
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x00035640 File Offset: 0x00033840
		public static BigInteger operator ~(BigInteger bi1)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			for (int i = 0; i < 70; i++)
			{
				bigInteger.data[i] = ~bi1.data[i];
			}
			bigInteger.dataLength = 70;
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0U)
			{
				bigInteger.dataLength--;
			}
			return bigInteger;
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x000356A8 File Offset: 0x000338A8
		public static BigInteger operator -(BigInteger bi1)
		{
			if (bi1.dataLength == 1 && bi1.data[0] == 0U)
			{
				return new BigInteger();
			}
			BigInteger bigInteger = new BigInteger(bi1);
			for (int i = 0; i < 70; i++)
			{
				bigInteger.data[i] = ~bi1.data[i];
			}
			long num = 1L;
			int num2 = 0;
			while (num != 0L && num2 < 70)
			{
				long num3 = (long)((ulong)bigInteger.data[num2]);
				num3 += 1L;
				bigInteger.data[num2] = (uint)(num3 & 4294967295L);
				num = num3 >> 32;
				num2++;
			}
			if ((bi1.data[69] & 2147483648U) == (bigInteger.data[69] & 2147483648U))
			{
				throw new ArithmeticException("Overflow in negation.\n");
			}
			bigInteger.dataLength = 70;
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0U)
			{
				bigInteger.dataLength--;
			}
			return bigInteger;
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0000836E File Offset: 0x0000656E
		public static bool operator ==(BigInteger bi1, BigInteger bi2)
		{
			return bi1.Equals(bi2);
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x00008377 File Offset: 0x00006577
		public static bool operator !=(BigInteger bi1, BigInteger bi2)
		{
			return !bi1.Equals(bi2);
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x000357A0 File Offset: 0x000339A0
		public override bool Equals(object o)
		{
			BigInteger bigInteger = (BigInteger)o;
			if (this.dataLength != bigInteger.dataLength)
			{
				return false;
			}
			for (int i = 0; i < this.dataLength; i++)
			{
				if (this.data[i] != bigInteger.data[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x00008383 File Offset: 0x00006583
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x000357EC File Offset: 0x000339EC
		public static bool operator >(BigInteger bi1, BigInteger bi2)
		{
			int i = 69;
			if ((bi1.data[69] & 2147483648U) != 0U && (bi2.data[i] & 2147483648U) == 0U)
			{
				return false;
			}
			if ((bi1.data[i] & 2147483648U) == 0U && (bi2.data[i] & 2147483648U) != 0U)
			{
				return true;
			}
			for (i = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength) - 1; i >= 0; i--)
			{
				if (bi1.data[i] != bi2.data[i])
				{
					break;
				}
			}
			return i >= 0 && bi1.data[i] > bi2.data[i];
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0003589C File Offset: 0x00033A9C
		public static bool operator <(BigInteger bi1, BigInteger bi2)
		{
			int i = 69;
			if ((bi1.data[69] & 2147483648U) != 0U && (bi2.data[i] & 2147483648U) == 0U)
			{
				return true;
			}
			if ((bi1.data[i] & 2147483648U) == 0U && (bi2.data[i] & 2147483648U) != 0U)
			{
				return false;
			}
			for (i = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength) - 1; i >= 0; i--)
			{
				if (bi1.data[i] != bi2.data[i])
				{
					break;
				}
			}
			return i >= 0 && bi1.data[i] < bi2.data[i];
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x00008390 File Offset: 0x00006590
		public static bool operator >=(BigInteger bi1, BigInteger bi2)
		{
			return bi1 == bi2 || bi1 > bi2;
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x000083A4 File Offset: 0x000065A4
		public static bool operator <=(BigInteger bi1, BigInteger bi2)
		{
			return bi1 == bi2 || bi1 < bi2;
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0003594C File Offset: 0x00033B4C
		private static void multiByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
		{
			uint[] array = new uint[70];
			int num = bi1.dataLength + 1;
			uint[] array2 = new uint[num];
			uint num2 = 2147483648U;
			uint num3 = bi2.data[bi2.dataLength - 1];
			int num4 = 0;
			int num5 = 0;
			while (num2 != 0U && (num3 & num2) == 0U)
			{
				num4++;
				num2 >>= 1;
			}
			for (int i = 0; i < bi1.dataLength; i++)
			{
				array2[i] = bi1.data[i];
			}
			BigInteger.shiftLeft(array2, num4);
			bi2 <<= num4;
			int j = num - bi2.dataLength;
			int num6 = num - 1;
			ulong num7 = (ulong)bi2.data[bi2.dataLength - 1];
			ulong num8 = (ulong)bi2.data[bi2.dataLength - 2];
			int num9 = bi2.dataLength + 1;
			uint[] array3 = new uint[num9];
			while (j > 0)
			{
				ulong num10 = ((ulong)array2[num6] << 32) + (ulong)array2[num6 - 1];
				ulong num11 = num10 / num7;
				ulong num12 = num10 % num7;
				bool flag = false;
				while (!flag)
				{
					flag = true;
					if (num11 == 4294967296UL || num11 * num8 > (num12 << 32) + (ulong)array2[num6 - 2])
					{
						num11 -= 1UL;
						num12 += num7;
						if (num12 < 4294967296UL)
						{
							flag = false;
						}
					}
				}
				for (int k = 0; k < num9; k++)
				{
					array3[k] = array2[num6 - k];
				}
				BigInteger bigInteger = new BigInteger(array3);
				BigInteger bigInteger2 = bi2 * (long)num11;
				while (bigInteger2 > bigInteger)
				{
					num11 -= 1UL;
					bigInteger2 -= bi2;
				}
				BigInteger bigInteger3 = bigInteger - bigInteger2;
				for (int l = 0; l < num9; l++)
				{
					array2[num6 - l] = bigInteger3.data[bi2.dataLength - l];
				}
				array[num5++] = (uint)num11;
				num6--;
				j--;
			}
			outQuotient.dataLength = num5;
			int m = 0;
			int n = outQuotient.dataLength - 1;
			while (n >= 0)
			{
				outQuotient.data[m] = array[n];
				n--;
				m++;
			}
			while (m < 70)
			{
				outQuotient.data[m] = 0U;
				m++;
			}
			while (outQuotient.dataLength > 1 && outQuotient.data[outQuotient.dataLength - 1] == 0U)
			{
				outQuotient.dataLength--;
			}
			if (outQuotient.dataLength == 0)
			{
				outQuotient.dataLength = 1;
			}
			outRemainder.dataLength = BigInteger.shiftRight(array2, num4);
			for (m = 0; m < outRemainder.dataLength; m++)
			{
				outRemainder.data[m] = array2[m];
			}
			while (m < 70)
			{
				outRemainder.data[m] = 0U;
				m++;
			}
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x00035C0C File Offset: 0x00033E0C
		private static void singleByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
		{
			uint[] array = new uint[70];
			int num = 0;
			for (int i = 0; i < 70; i++)
			{
				outRemainder.data[i] = bi1.data[i];
			}
			outRemainder.dataLength = bi1.dataLength;
			while (outRemainder.dataLength > 1 && outRemainder.data[outRemainder.dataLength - 1] == 0U)
			{
				outRemainder.dataLength--;
			}
			ulong num2 = (ulong)bi2.data[0];
			int j = outRemainder.dataLength - 1;
			ulong num3 = (ulong)outRemainder.data[j];
			if (num3 >= num2)
			{
				ulong num4 = num3 / num2;
				array[num++] = (uint)num4;
				outRemainder.data[j] = (uint)(num3 % num2);
			}
			j--;
			while (j >= 0)
			{
				num3 = ((ulong)outRemainder.data[j + 1] << 32) + (ulong)outRemainder.data[j];
				ulong num5 = num3 / num2;
				array[num++] = (uint)num5;
				outRemainder.data[j + 1] = 0U;
				outRemainder.data[j--] = (uint)(num3 % num2);
			}
			outQuotient.dataLength = num;
			int k = 0;
			int l = outQuotient.dataLength - 1;
			while (l >= 0)
			{
				outQuotient.data[k] = array[l];
				l--;
				k++;
			}
			while (k < 70)
			{
				outQuotient.data[k] = 0U;
				k++;
			}
			while (outQuotient.dataLength > 1 && outQuotient.data[outQuotient.dataLength - 1] == 0U)
			{
				outQuotient.dataLength--;
			}
			if (outQuotient.dataLength == 0)
			{
				outQuotient.dataLength = 1;
			}
			while (outRemainder.dataLength > 1 && outRemainder.data[outRemainder.dataLength - 1] == 0U)
			{
				outRemainder.dataLength--;
			}
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x00035DBC File Offset: 0x00033FBC
		public static BigInteger operator /(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			BigInteger outRemainder = new BigInteger();
			int num = 69;
			bool flag = false;
			bool flag2 = false;
			if ((bi1.data[69] & 2147483648U) != 0U)
			{
				bi1 = -bi1;
				flag2 = true;
			}
			if ((bi2.data[num] & 2147483648U) != 0U)
			{
				bi2 = -bi2;
				flag = true;
			}
			if (bi1 < bi2)
			{
				return bigInteger;
			}
			if (bi2.dataLength == 1)
			{
				BigInteger.singleByteDivide(bi1, bi2, bigInteger, outRemainder);
			}
			else
			{
				BigInteger.multiByteDivide(bi1, bi2, bigInteger, outRemainder);
			}
			if (flag2 != flag)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x00035E48 File Offset: 0x00034048
		public static BigInteger operator %(BigInteger bi1, BigInteger bi2)
		{
			BigInteger outQuotient = new BigInteger();
			BigInteger bigInteger = new BigInteger(bi1);
			int num = 69;
			bool flag = false;
			if ((bi1.data[69] & 2147483648U) != 0U)
			{
				bi1 = -bi1;
				flag = true;
			}
			if ((bi2.data[num] & 2147483648U) != 0U)
			{
				bi2 = -bi2;
			}
			if (bi1 < bi2)
			{
				return bigInteger;
			}
			if (bi2.dataLength == 1)
			{
				BigInteger.singleByteDivide(bi1, bi2, outQuotient, bigInteger);
			}
			else
			{
				BigInteger.multiByteDivide(bi1, bi2, outQuotient, bigInteger);
			}
			if (flag)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x00035ED0 File Offset: 0x000340D0
		public static BigInteger operator &(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			int num = (bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength;
			for (int i = 0; i < num; i++)
			{
				uint num2 = bi1.data[i] & bi2.data[i];
				bigInteger.data[i] = num2;
			}
			bigInteger.dataLength = 70;
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0U)
			{
				bigInteger.dataLength--;
			}
			return bigInteger;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x00035F5C File Offset: 0x0003415C
		public static BigInteger operator |(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			int num = (bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength;
			for (int i = 0; i < num; i++)
			{
				uint num2 = bi1.data[i] | bi2.data[i];
				bigInteger.data[i] = num2;
			}
			bigInteger.dataLength = 70;
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0U)
			{
				bigInteger.dataLength--;
			}
			return bigInteger;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x00035FE8 File Offset: 0x000341E8
		public static BigInteger operator ^(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			int num = (bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength;
			for (int i = 0; i < num; i++)
			{
				uint num2 = bi1.data[i] ^ bi2.data[i];
				bigInteger.data[i] = num2;
			}
			bigInteger.dataLength = 70;
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0U)
			{
				bigInteger.dataLength--;
			}
			return bigInteger;
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x000083B8 File Offset: 0x000065B8
		public BigInteger max(BigInteger bi)
		{
			if (this > bi)
			{
				return new BigInteger(this);
			}
			return new BigInteger(bi);
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x000083D0 File Offset: 0x000065D0
		public BigInteger min(BigInteger bi)
		{
			if (this < bi)
			{
				return new BigInteger(this);
			}
			return new BigInteger(bi);
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x000083E8 File Offset: 0x000065E8
		public BigInteger abs()
		{
			if ((this.data[69] & 2147483648U) != 0U)
			{
				return -this;
			}
			return new BigInteger(this);
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x00008408 File Offset: 0x00006608
		public override string ToString()
		{
			return this.ToString(10);
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x00036074 File Offset: 0x00034274
		public string ToString(int radix)
		{
			if (radix >= 2 && radix <= 36)
			{
				string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				string text2 = "";
				BigInteger bigInteger = this;
				bool flag = false;
				if ((bigInteger.data[69] & 2147483648U) != 0U)
				{
					flag = true;
					try
					{
						bigInteger = -bigInteger;
					}
					catch (Exception)
					{
					}
				}
				BigInteger bigInteger2 = new BigInteger();
				BigInteger bigInteger3 = new BigInteger();
				BigInteger bi = new BigInteger((long)radix);
				if (bigInteger.dataLength == 1 && bigInteger.data[0] == 0U)
				{
					text2 = "0";
				}
				else
				{
					for (;;)
					{
						if (bigInteger.dataLength <= 1)
						{
							if (bigInteger.dataLength != 1)
							{
								break;
							}
							if (bigInteger.data[0] == 0U)
							{
								break;
							}
						}
						BigInteger.singleByteDivide(bigInteger, bi, bigInteger2, bigInteger3);
						if (bigInteger3.data[0] < 10U)
						{
							text2 = bigInteger3.data[0].ToString() + text2;
						}
						else
						{
							text2 = text[(int)(bigInteger3.data[0] - 10U)].ToString() + text2;
						}
						bigInteger = bigInteger2;
					}
					if (flag)
					{
						text2 = "-" + text2;
					}
				}
				return text2;
			}
			throw new ArgumentException("Radix must be >= 2 and <= 36");
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x000361A0 File Offset: 0x000343A0
		public string ToHexString()
		{
			string text = this.data[this.dataLength - 1].ToString("X");
			for (int i = this.dataLength - 2; i >= 0; i--)
			{
				text += this.data[i].ToString("X8");
			}
			return text;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x00008412 File Offset: 0x00006612
		public BigInteger Pow(int exp)
		{
			return BigInteger.power(this, exp);
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x000361FC File Offset: 0x000343FC
		private static BigInteger power(BigInteger number, int exponent)
		{
			if (exponent == 0)
			{
				return new BigInteger("1", 10);
			}
			if (exponent == 1)
			{
				return number;
			}
			if (exponent % 2 == 0)
			{
				return BigInteger.square(BigInteger.power(number, exponent / 2));
			}
			return number * BigInteger.square(BigInteger.power(number, (exponent - 1) / 2));
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0000841B File Offset: 0x0000661B
		private static BigInteger square(BigInteger num)
		{
			return num * num;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0003624C File Offset: 0x0003444C
		public BigInteger modPow(BigInteger exp, BigInteger n)
		{
			if ((exp.data[69] & 2147483648U) != 0U)
			{
				throw new ArithmeticException("Positive exponents only.");
			}
			BigInteger bigInteger = 1;
			bool flag = false;
			BigInteger bigInteger2;
			if ((this.data[69] & 2147483648U) != 0U)
			{
				bigInteger2 = -this % n;
				flag = true;
			}
			else
			{
				bigInteger2 = this % n;
			}
			if ((n.data[69] & 2147483648U) != 0U)
			{
				n = -n;
			}
			BigInteger bigInteger3 = new BigInteger();
			int num = n.dataLength << 1;
			bigInteger3.data[num] = 1U;
			bigInteger3.dataLength = num + 1;
			bigInteger3 /= n;
			int num2 = exp.bitCount();
			int num3 = 0;
			for (int i = 0; i < exp.dataLength; i++)
			{
				uint num4 = 1U;
				int j = 0;
				while (j < 32)
				{
					if ((exp.data[i] & num4) != 0U)
					{
						bigInteger = this.BarrettReduction(bigInteger * bigInteger2, n, bigInteger3);
					}
					num4 <<= 1;
					bigInteger2 = this.BarrettReduction(bigInteger2 * bigInteger2, n, bigInteger3);
					if (bigInteger2.dataLength == 1 && bigInteger2.data[0] == 1U)
					{
						if (flag && (exp.data[0] & 1U) != 0U)
						{
							return -bigInteger;
						}
						return bigInteger;
					}
					else
					{
						num3++;
						if (num3 == num2)
						{
							break;
						}
						j++;
					}
				}
			}
			if (flag && (exp.data[0] & 1U) != 0U)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x000363A8 File Offset: 0x000345A8
		private BigInteger BarrettReduction(BigInteger x, BigInteger n, BigInteger constant)
		{
			int num = n.dataLength;
			int num2 = num + 1;
			int num3 = num - 1;
			BigInteger bigInteger = new BigInteger();
			int i = num3;
			int num4 = 0;
			while (i < x.dataLength)
			{
				bigInteger.data[num4] = x.data[i];
				i++;
				num4++;
			}
			bigInteger.dataLength = x.dataLength - num3;
			if (bigInteger.dataLength <= 0)
			{
				bigInteger.dataLength = 1;
			}
			BigInteger bigInteger2 = bigInteger * constant;
			BigInteger bigInteger3 = new BigInteger();
			int j = num2;
			int num5 = 0;
			while (j < bigInteger2.dataLength)
			{
				bigInteger3.data[num5] = bigInteger2.data[j];
				j++;
				num5++;
			}
			bigInteger3.dataLength = bigInteger2.dataLength - num2;
			if (bigInteger3.dataLength <= 0)
			{
				bigInteger3.dataLength = 1;
			}
			BigInteger bigInteger4 = new BigInteger();
			int num6 = (x.dataLength > num2) ? num2 : x.dataLength;
			for (int k = 0; k < num6; k++)
			{
				bigInteger4.data[k] = x.data[k];
			}
			bigInteger4.dataLength = num6;
			BigInteger bigInteger5 = new BigInteger();
			for (int l = 0; l < bigInteger3.dataLength; l++)
			{
				if (bigInteger3.data[l] != 0U)
				{
					ulong num7 = 0UL;
					int num8 = l;
					int num9 = 0;
					while (num9 < n.dataLength && num8 < num2)
					{
						ulong num10 = (ulong)bigInteger3.data[l] * (ulong)n.data[num9] + (ulong)bigInteger5.data[num8] + num7;
						bigInteger5.data[num8] = (uint)(num10 & 4294967295UL);
						num7 = num10 >> 32;
						num9++;
						num8++;
					}
					if (num8 < num2)
					{
						bigInteger5.data[num8] = (uint)num7;
					}
				}
			}
			bigInteger5.dataLength = num2;
			while (bigInteger5.dataLength > 1 && bigInteger5.data[bigInteger5.dataLength - 1] == 0U)
			{
				bigInteger5.dataLength--;
			}
			bigInteger4 -= bigInteger5;
			if ((bigInteger4.data[69] & 2147483648U) != 0U)
			{
				BigInteger bigInteger6 = new BigInteger();
				bigInteger6.data[num2] = 1U;
				bigInteger6.dataLength = num2 + 1;
				bigInteger4 += bigInteger6;
			}
			while (bigInteger4 >= n)
			{
				bigInteger4 -= n;
			}
			return bigInteger4;
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x00036608 File Offset: 0x00034808
		public BigInteger gcd(BigInteger bi)
		{
			BigInteger bigInteger;
			if ((this.data[69] & 2147483648U) != 0U)
			{
				bigInteger = -this;
			}
			else
			{
				bigInteger = this;
			}
			BigInteger bigInteger2;
			if ((bi.data[69] & 2147483648U) != 0U)
			{
				bigInteger2 = -bi;
			}
			else
			{
				bigInteger2 = bi;
			}
			BigInteger bigInteger3 = bigInteger2;
			for (;;)
			{
				if (bigInteger.dataLength <= 1)
				{
					if (bigInteger.dataLength != 1)
					{
						break;
					}
					if (bigInteger.data[0] == 0U)
					{
						break;
					}
				}
				bigInteger3 = bigInteger;
				bigInteger = bigInteger2 % bigInteger;
				bigInteger2 = bigInteger3;
			}
			return bigInteger3;
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x00036680 File Offset: 0x00034880
		public void genRandomBits(int bits, Random rand)
		{
			int num = bits >> 5;
			int num2 = bits & 31;
			if (num2 != 0)
			{
				num++;
			}
			if (num > 70)
			{
				throw new ArithmeticException("Number of required bits > maxLength.");
			}
			for (int i = 0; i < num; i++)
			{
				this.data[i] = (uint)(rand.NextDouble() * 4294967296.0);
			}
			for (int j = num; j < 70; j++)
			{
				this.data[j] = 0U;
			}
			if (num2 != 0)
			{
				uint num3 = 1U << num2 - 1;
				this.data[num - 1] |= num3;
				num3 = uint.MaxValue >> 32 - num2;
				this.data[num - 1] &= num3;
			}
			else
			{
				this.data[num - 1] |= 2147483648U;
			}
			this.dataLength = num;
			if (this.dataLength == 0)
			{
				this.dataLength = 1;
			}
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x00036758 File Offset: 0x00034958
		public int bitCount()
		{
			while (this.dataLength > 1 && this.data[this.dataLength - 1] == 0U)
			{
				this.dataLength--;
			}
			uint num = this.data[this.dataLength - 1];
			uint num2 = 2147483648U;
			int num3 = 32;
			while (num3 > 0 && (num & num2) == 0U)
			{
				num3--;
				num2 >>= 1;
			}
			return num3 + (this.dataLength - 1 << 5);
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x000367CC File Offset: 0x000349CC
		public bool FermatLittleTest(int confidence)
		{
			BigInteger bigInteger;
			if ((this.data[69] & 2147483648U) != 0U)
			{
				bigInteger = -this;
			}
			else
			{
				bigInteger = this;
			}
			if (bigInteger.dataLength == 1)
			{
				if (bigInteger.data[0] != 0U)
				{
					if (bigInteger.data[0] != 1U)
					{
						if (bigInteger.data[0] == 2U || bigInteger.data[0] == 3U)
						{
							return true;
						}
						goto IL_56;
					}
				}
				return false;
			}
			IL_56:
			if ((bigInteger.data[0] & 1U) == 0U)
			{
				return false;
			}
			int num = bigInteger.bitCount();
			BigInteger bigInteger2 = new BigInteger();
			BigInteger exp = bigInteger - new BigInteger(1L);
			Random random = new Random();
			int i = 0;
			while (i < confidence)
			{
				bool flag = false;
				while (!flag)
				{
					int j;
					for (j = 0; j < 2; j = (int)(random.NextDouble() * (double)num))
					{
					}
					bigInteger2.genRandomBits(j, random);
					int num2 = bigInteger2.dataLength;
					if (num2 > 1 || (num2 == 1 && bigInteger2.data[0] != 1U))
					{
						flag = true;
					}
				}
				BigInteger bigInteger3 = bigInteger2.gcd(bigInteger);
				if (bigInteger3.dataLength == 1 && bigInteger3.data[0] != 1U)
				{
					return false;
				}
				BigInteger bigInteger4 = bigInteger2.modPow(exp, bigInteger);
				int num3 = bigInteger4.dataLength;
				if (num3 <= 1)
				{
					if (num3 != 1 || bigInteger4.data[0] == 1U)
					{
						i++;
						continue;
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x00036918 File Offset: 0x00034B18
		public bool RabinMillerTest(int confidence)
		{
			BigInteger bigInteger;
			if ((this.data[69] & 2147483648U) != 0U)
			{
				bigInteger = -this;
			}
			else
			{
				bigInteger = this;
			}
			if (bigInteger.dataLength == 1)
			{
				if (bigInteger.data[0] != 0U)
				{
					if (bigInteger.data[0] != 1U)
					{
						if (bigInteger.data[0] == 2U || bigInteger.data[0] == 3U)
						{
							return true;
						}
						goto IL_56;
					}
				}
				return false;
			}
			IL_56:
			if ((bigInteger.data[0] & 1U) == 0U)
			{
				return false;
			}
			BigInteger bigInteger2 = bigInteger - new BigInteger(1L);
			int num = 0;
			int i = 0;
			IL_BC:
			while (i < bigInteger2.dataLength)
			{
				uint num2 = 1U;
				for (int j = 0; j < 32; j++)
				{
					if ((bigInteger2.data[i] & num2) != 0U)
					{
						i = bigInteger2.dataLength;
						IL_B6:
						i++;
						goto IL_BC;
					}
					num2 <<= 1;
					num++;
				}
				goto IL_B6;
			}
			BigInteger exp = bigInteger2 >> num;
			int num3 = bigInteger.bitCount();
			BigInteger bigInteger3 = new BigInteger();
			Random random = new Random();
			for (int k = 0; k < confidence; k++)
			{
				bool flag = false;
				while (!flag)
				{
					int l;
					for (l = 0; l < 2; l = (int)(random.NextDouble() * (double)num3))
					{
					}
					bigInteger3.genRandomBits(l, random);
					int num4 = bigInteger3.dataLength;
					if (num4 > 1 || (num4 == 1 && bigInteger3.data[0] != 1U))
					{
						flag = true;
					}
				}
				BigInteger bigInteger4 = bigInteger3.gcd(bigInteger);
				if (bigInteger4.dataLength == 1 && bigInteger4.data[0] != 1U)
				{
					return false;
				}
				BigInteger bigInteger5 = bigInteger3.modPow(exp, bigInteger);
				bool flag2 = false;
				if (bigInteger5.dataLength == 1 && bigInteger5.data[0] == 1U)
				{
					flag2 = true;
				}
				int num5 = 0;
				while (!flag2 && num5 < num)
				{
					if (bigInteger5 == bigInteger2)
					{
						flag2 = true;
						break;
					}
					bigInteger5 = bigInteger5 * bigInteger5 % bigInteger;
					num5++;
				}
				if (!flag2)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x00036AF4 File Offset: 0x00034CF4
		public bool SolovayStrassenTest(int confidence)
		{
			BigInteger bigInteger;
			if ((this.data[69] & 2147483648U) != 0U)
			{
				bigInteger = -this;
			}
			else
			{
				bigInteger = this;
			}
			if (bigInteger.dataLength == 1)
			{
				if (bigInteger.data[0] != 0U)
				{
					if (bigInteger.data[0] != 1U)
					{
						if (bigInteger.data[0] == 2U || bigInteger.data[0] == 3U)
						{
							return true;
						}
						goto IL_56;
					}
				}
				return false;
			}
			IL_56:
			if ((bigInteger.data[0] & 1U) == 0U)
			{
				return false;
			}
			int num = bigInteger.bitCount();
			BigInteger bigInteger2 = new BigInteger();
			BigInteger bigInteger3 = bigInteger - 1;
			BigInteger exp = bigInteger3 >> 1;
			Random random = new Random();
			for (int i = 0; i < confidence; i++)
			{
				bool flag = false;
				while (!flag)
				{
					int j;
					for (j = 0; j < 2; j = (int)(random.NextDouble() * (double)num))
					{
					}
					bigInteger2.genRandomBits(j, random);
					int num2 = bigInteger2.dataLength;
					if (num2 > 1 || (num2 == 1 && bigInteger2.data[0] != 1U))
					{
						flag = true;
					}
				}
				BigInteger bigInteger4 = bigInteger2.gcd(bigInteger);
				if (bigInteger4.dataLength == 1 && bigInteger4.data[0] != 1U)
				{
					return false;
				}
				BigInteger bi = bigInteger2.modPow(exp, bigInteger);
				if (bi == bigInteger3)
				{
					bi = -1;
				}
				BigInteger bi2 = BigInteger.Jacobi(bigInteger2, bigInteger);
				if (bi != bi2)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x00036C4C File Offset: 0x00034E4C
		public bool LucasStrongTest()
		{
			BigInteger bigInteger;
			if ((this.data[69] & 2147483648U) != 0U)
			{
				bigInteger = -this;
			}
			else
			{
				bigInteger = this;
			}
			if (bigInteger.dataLength == 1)
			{
				if (bigInteger.data[0] != 0U)
				{
					if (bigInteger.data[0] != 1U)
					{
						if (bigInteger.data[0] == 2U || bigInteger.data[0] == 3U)
						{
							return true;
						}
						goto IL_56;
					}
				}
				return false;
			}
			IL_56:
			return (bigInteger.data[0] & 1U) != 0U && this.LucasStrongTestHelper(bigInteger);
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x00036CC4 File Offset: 0x00034EC4
		private bool LucasStrongTestHelper(BigInteger thisVal)
		{
			long num = 5L;
			long num2 = -1L;
			long num3 = 0L;
			bool flag = false;
			while (!flag)
			{
				int num4 = BigInteger.Jacobi(num, thisVal);
				if (num4 == -1)
				{
					flag = true;
				}
				else
				{
					if (num4 == 0 && Math.Abs(num) < thisVal)
					{
						return false;
					}
					if (num3 == 20L)
					{
						BigInteger bigInteger = thisVal.sqrt();
						if (bigInteger * bigInteger == thisVal)
						{
							return false;
						}
					}
					num = (Math.Abs(num) + 2L) * num2;
					num2 = -num2;
				}
				num3 += 1L;
			}
			long num5 = 1L - num >> 2;
			BigInteger bigInteger2 = thisVal + 1;
			int num6 = 0;
			int i = 0;
			IL_100:
			while (i < bigInteger2.dataLength)
			{
				uint num7 = 1U;
				for (int j = 0; j < 32; j++)
				{
					if ((bigInteger2.data[i] & num7) != 0U)
					{
						i = bigInteger2.dataLength;
						IL_FA:
						i++;
						goto IL_100;
					}
					num7 <<= 1;
					num6++;
				}
				goto IL_FA;
			}
			BigInteger k = bigInteger2 >> num6;
			BigInteger bigInteger3 = new BigInteger();
			int num8 = thisVal.dataLength << 1;
			bigInteger3.data[num8] = 1U;
			bigInteger3.dataLength = num8 + 1;
			bigInteger3 /= thisVal;
			BigInteger[] array = BigInteger.LucasSequenceHelper(1, num5, k, thisVal, bigInteger3, 0);
			bool flag2 = false;
			if ((array[0].dataLength == 1 && array[0].data[0] == 0U) || (array[1].dataLength == 1 && array[1].data[0] == 0U))
			{
				flag2 = true;
			}
			for (int l = 1; l < num6; l++)
			{
				if (!flag2)
				{
					array[1] = thisVal.BarrettReduction(array[1] * array[1], thisVal, bigInteger3);
					array[1] = (array[1] - (array[2] << 1)) % thisVal;
					if (array[1].dataLength == 1 && array[1].data[0] == 0U)
					{
						flag2 = true;
					}
				}
				array[2] = thisVal.BarrettReduction(array[2] * array[2], thisVal, bigInteger3);
			}
			if (flag2)
			{
				BigInteger bigInteger4 = thisVal.gcd(num5);
				if (bigInteger4.dataLength == 1 && bigInteger4.data[0] == 1U)
				{
					if ((array[2].data[69] & 2147483648U) != 0U)
					{
						BigInteger[] array2 = array;
						array2[2] = array2[2] + thisVal;
					}
					BigInteger bigInteger5 = num5 * (long)BigInteger.Jacobi(num5, thisVal) % thisVal;
					if ((bigInteger5.data[69] & 2147483648U) != 0U)
					{
						bigInteger5 += thisVal;
					}
					if (array[2] != bigInteger5)
					{
						flag2 = false;
					}
				}
			}
			return flag2;
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x00036F90 File Offset: 0x00035190
		public bool isProbablePrime(int confidence)
		{
			BigInteger bigInteger;
			if ((this.data[69] & 2147483648U) != 0U)
			{
				bigInteger = -this;
			}
			else
			{
				bigInteger = this;
			}
			for (int i = 0; i < BigInteger.primesBelow2000.Length; i++)
			{
				BigInteger bigInteger2 = BigInteger.primesBelow2000[i];
				if (bigInteger2 >= bigInteger)
				{
					IL_56:
					return bigInteger.RabinMillerTest(confidence);
				}
				if ((bigInteger % bigInteger2).IntValue() == 0)
				{
					return false;
				}
			}
			goto IL_56;
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x00037000 File Offset: 0x00035200
		public bool isProbablePrime()
		{
			BigInteger bigInteger;
			if ((this.data[69] & 2147483648U) != 0U)
			{
				bigInteger = -this;
			}
			else
			{
				bigInteger = this;
			}
			if (bigInteger.dataLength == 1)
			{
				if (bigInteger.data[0] != 0U)
				{
					if (bigInteger.data[0] != 1U)
					{
						if (bigInteger.data[0] == 2U || bigInteger.data[0] == 3U)
						{
							return true;
						}
						goto IL_56;
					}
				}
				return false;
			}
			IL_56:
			if ((bigInteger.data[0] & 1U) == 0U)
			{
				return false;
			}
			for (int i = 0; i < BigInteger.primesBelow2000.Length; i++)
			{
				BigInteger bigInteger2 = BigInteger.primesBelow2000[i];
				if (bigInteger2 >= bigInteger)
				{
					IL_A6:
					BigInteger bigInteger3 = bigInteger - new BigInteger(1L);
					int num = 0;
					int j = 0;
					IL_FE:
					while (j < bigInteger3.dataLength)
					{
						uint num2 = 1U;
						for (int k = 0; k < 32; k++)
						{
							if ((bigInteger3.data[j] & num2) != 0U)
							{
								j = bigInteger3.dataLength;
								IL_F8:
								j++;
								goto IL_FE;
							}
							num2 <<= 1;
							num++;
						}
						goto IL_F8;
					}
					BigInteger exp = bigInteger3 >> num;
					bigInteger.bitCount();
					BigInteger bigInteger4 = 2.modPow(exp, bigInteger);
					bool flag = false;
					if (bigInteger4.dataLength == 1 && bigInteger4.data[0] == 1U)
					{
						flag = true;
					}
					int num3 = 0;
					while (!flag && num3 < num)
					{
						if (bigInteger4 == bigInteger3)
						{
							flag = true;
							break;
						}
						bigInteger4 = bigInteger4 * bigInteger4 % bigInteger;
						num3++;
					}
					if (flag)
					{
						flag = this.LucasStrongTestHelper(bigInteger);
					}
					return flag;
				}
				if ((bigInteger % bigInteger2).IntValue() == 0)
				{
					return false;
				}
			}
			goto IL_A6;
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x00008424 File Offset: 0x00006624
		public int IntValue()
		{
			return (int)this.data[0];
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x00037194 File Offset: 0x00035394
		public long LongValue()
		{
			long num = 0L;
			num = (long)((ulong)this.data[0]);
			try
			{
				num |= (long)((long)((ulong)this.data[1]) << 32);
			}
			catch (Exception)
			{
				if ((this.data[0] & 2147483648U) != 0U)
				{
					num = (long)this.data[0];
				}
			}
			return num;
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x000371F4 File Offset: 0x000353F4
		public static int Jacobi(BigInteger a, BigInteger b)
		{
			if ((b.data[0] & 1U) == 0U)
			{
				throw new ArgumentException("Jacobi defined only for odd integers.");
			}
			if (a >= b)
			{
				a %= b;
			}
			if (a.dataLength == 1 && a.data[0] == 0U)
			{
				return 0;
			}
			if (a.dataLength == 1 && a.data[0] == 1U)
			{
				return 1;
			}
			if (a < 0)
			{
				if (((b - 1).data[0] & 2U) == 0U)
				{
					return BigInteger.Jacobi(-a, b);
				}
				return -BigInteger.Jacobi(-a, b);
			}
			else
			{
				int num = 0;
				int i = 0;
				IL_D2:
				while (i < a.dataLength)
				{
					uint num2 = 1U;
					for (int j = 0; j < 32; j++)
					{
						if ((a.data[i] & num2) != 0U)
						{
							i = a.dataLength;
							IL_CE:
							i++;
							goto IL_D2;
						}
						num2 <<= 1;
						num++;
					}
					goto IL_CE;
				}
				BigInteger bigInteger = a >> num;
				int num3 = 1;
				if ((num & 1) != 0 && ((b.data[0] & 7U) == 3U || (b.data[0] & 7U) == 5U))
				{
					num3 = -1;
				}
				if ((b.data[0] & 3U) == 3U && (bigInteger.data[0] & 3U) == 3U)
				{
					num3 = -num3;
				}
				if (bigInteger.dataLength == 1 && bigInteger.data[0] == 1U)
				{
					return num3;
				}
				return num3 * BigInteger.Jacobi(b % bigInteger, bigInteger);
			}
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x0003734C File Offset: 0x0003554C
		public static BigInteger genPseudoPrime(int bits, int confidence, Random rand)
		{
			BigInteger bigInteger = new BigInteger();
			bool flag = false;
			while (!flag)
			{
				bigInteger.genRandomBits(bits, rand);
				bigInteger.data[0] |= 1U;
				flag = bigInteger.isProbablePrime(confidence);
			}
			return bigInteger;
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x00037388 File Offset: 0x00035588
		public BigInteger genCoPrime(int bits, Random rand)
		{
			bool flag = false;
			BigInteger bigInteger = new BigInteger();
			while (!flag)
			{
				bigInteger.genRandomBits(bits, rand);
				BigInteger bigInteger2 = bigInteger.gcd(this);
				if (bigInteger2.dataLength == 1 && bigInteger2.data[0] == 1U)
				{
					flag = true;
				}
			}
			return bigInteger;
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x000373CC File Offset: 0x000355CC
		public BigInteger modInverse(BigInteger modulus)
		{
			BigInteger[] array = new BigInteger[]
			{
				0,
				1
			};
			BigInteger[] array2 = new BigInteger[2];
			BigInteger[] array3 = new BigInteger[]
			{
				0,
				0
			};
			int num = 0;
			BigInteger bi = modulus;
			BigInteger bigInteger = this;
			for (;;)
			{
				if (bigInteger.dataLength <= 1)
				{
					if (bigInteger.dataLength != 1)
					{
						break;
					}
					if (bigInteger.data[0] == 0U)
					{
						break;
					}
				}
				BigInteger bigInteger2 = new BigInteger();
				BigInteger bigInteger3 = new BigInteger();
				if (num > 1)
				{
					BigInteger bigInteger4 = (array[0] - array[1] * array2[0]) % modulus;
					array[0] = array[1];
					array[1] = bigInteger4;
				}
				if (bigInteger.dataLength == 1)
				{
					BigInteger.singleByteDivide(bi, bigInteger, bigInteger2, bigInteger3);
				}
				else
				{
					BigInteger.multiByteDivide(bi, bigInteger, bigInteger2, bigInteger3);
				}
				array2[0] = array2[1];
				array3[0] = array3[1];
				array2[1] = bigInteger2;
				array3[1] = bigInteger3;
				bi = bigInteger;
				bigInteger = bigInteger3;
				num++;
			}
			if (array3[0].dataLength <= 1)
			{
				if (array3[0].dataLength != 1 || array3[0].data[0] == 1U)
				{
					BigInteger bigInteger5 = (array[0] - array[1] * array2[0]) % modulus;
					if ((bigInteger5.data[69] & 2147483648U) != 0U)
					{
						bigInteger5 += modulus;
					}
					return bigInteger5;
				}
			}
			throw new ArithmeticException("No inverse!");
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x00037538 File Offset: 0x00035738
		public byte[] getBytes()
		{
			int num = this.bitCount();
			int num2 = num >> 3;
			if ((num & 7) != 0)
			{
				num2++;
			}
			byte[] array = new byte[num2];
			int num3 = 0;
			uint num4 = this.data[this.dataLength - 1];
			uint num5;
			if ((num5 = (num4 >> 24 & 255U)) != 0U)
			{
				array[num3++] = (byte)num5;
			}
			if ((num5 = (num4 >> 16 & 255U)) != 0U)
			{
				array[num3++] = (byte)num5;
			}
			if ((num5 = (num4 >> 8 & 255U)) != 0U)
			{
				array[num3++] = (byte)num5;
			}
			if ((num5 = (num4 & 255U)) != 0U)
			{
				array[num3++] = (byte)num5;
			}
			int i = this.dataLength - 2;
			while (i >= 0)
			{
				num4 = this.data[i];
				array[num3 + 3] = (byte)(num4 & 255U);
				num4 >>= 8;
				array[num3 + 2] = (byte)(num4 & 255U);
				num4 >>= 8;
				array[num3 + 1] = (byte)(num4 & 255U);
				num4 >>= 8;
				array[num3] = (byte)(num4 & 255U);
				i--;
				num3 += 4;
			}
			return array;
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x0003763C File Offset: 0x0003583C
		public void setBit(uint bitNum)
		{
			uint num = bitNum >> 5;
			byte b = (byte)(bitNum & 31U);
			uint num2 = 1U << (int)b;
			this.data[(int)num] |= num2;
			if ((ulong)num >= (ulong)((long)this.dataLength))
			{
				this.dataLength = (int)(num + 1U);
			}
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x00037680 File Offset: 0x00035880
		public void unsetBit(uint bitNum)
		{
			uint num = bitNum >> 5;
			if ((ulong)num < (ulong)((long)this.dataLength))
			{
				byte b = (byte)(bitNum & 31U);
				uint num2 = 1U << (int)b;
				uint num3 = uint.MaxValue ^ num2;
				this.data[(int)num] &= num3;
				if (this.dataLength > 1 && this.data[this.dataLength - 1] == 0U)
				{
					this.dataLength--;
				}
			}
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x000376E8 File Offset: 0x000358E8
		public BigInteger sqrt()
		{
			uint num = (uint)this.bitCount();
			if ((num & 1U) != 0U)
			{
				num = (num >> 1) + 1U;
			}
			else
			{
				num >>= 1;
			}
			uint num2 = num >> 5;
			byte b = (byte)(num & 31U);
			BigInteger bigInteger = new BigInteger();
			uint num3;
			if (b == 0)
			{
				num3 = 2147483648U;
			}
			else
			{
				num3 = 1U << (int)b;
				num2 += 1U;
			}
			bigInteger.dataLength = (int)num2;
			for (int i = (int)(num2 - 1U); i >= 0; i--)
			{
				while (num3 != 0U)
				{
					bigInteger.data[i] ^= num3;
					if (bigInteger * bigInteger > this)
					{
						bigInteger.data[i] ^= num3;
					}
					num3 >>= 1;
				}
				num3 = 2147483648U;
			}
			return bigInteger;
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x00037794 File Offset: 0x00035994
		public static BigInteger[] LucasSequence(BigInteger P, BigInteger Q, BigInteger k, BigInteger n)
		{
			if (k.dataLength == 1 && k.data[0] == 0U)
			{
				return new BigInteger[]
				{
					0,
					2 % n,
					1 % n
				};
			}
			BigInteger bigInteger = new BigInteger();
			int num = n.dataLength << 1;
			bigInteger.data[num] = 1U;
			bigInteger.dataLength = num + 1;
			bigInteger /= n;
			int num2 = 0;
			int i = 0;
			IL_AD:
			while (i < k.dataLength)
			{
				uint num3 = 1U;
				for (int j = 0; j < 32; j++)
				{
					if ((k.data[i] & num3) != 0U)
					{
						i = k.dataLength;
						IL_A7:
						i++;
						goto IL_AD;
					}
					num3 <<= 1;
					num2++;
				}
				goto IL_A7;
			}
			BigInteger k2 = k >> num2;
			return BigInteger.LucasSequenceHelper(P, Q, k2, n, bigInteger, num2);
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x0003786C File Offset: 0x00035A6C
		private static BigInteger[] LucasSequenceHelper(BigInteger P, BigInteger Q, BigInteger k, BigInteger n, BigInteger constant, int s)
		{
			BigInteger[] array = new BigInteger[3];
			if ((k.data[0] & 1U) == 0U)
			{
				throw new ArgumentException("Argument k must be odd.");
			}
			int num = k.bitCount();
			uint num2 = 1U << (num & 31) - 1;
			BigInteger bigInteger = 2 % n;
			BigInteger bigInteger2 = 1 % n;
			BigInteger bigInteger3 = P % n;
			BigInteger bigInteger4 = bigInteger2;
			bool flag = true;
			for (int i = k.dataLength - 1; i >= 0; i--)
			{
				while (num2 != 0U && (i != 0 || num2 != 1U))
				{
					if ((k.data[i] & num2) != 0U)
					{
						bigInteger4 = bigInteger4 * bigInteger3 % n;
						bigInteger = (bigInteger * bigInteger3 - P * bigInteger2) % n;
						bigInteger3 = n.BarrettReduction(bigInteger3 * bigInteger3, n, constant);
						bigInteger3 = (bigInteger3 - (bigInteger2 * Q << 1)) % n;
						if (flag)
						{
							flag = false;
						}
						else
						{
							bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
						}
						bigInteger2 = bigInteger2 * Q % n;
					}
					else
					{
						bigInteger4 = (bigInteger4 * bigInteger - bigInteger2) % n;
						bigInteger3 = (bigInteger * bigInteger3 - P * bigInteger2) % n;
						bigInteger = n.BarrettReduction(bigInteger * bigInteger, n, constant);
						bigInteger = (bigInteger - (bigInteger2 << 1)) % n;
						if (flag)
						{
							bigInteger2 = Q % n;
							flag = false;
						}
						else
						{
							bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
						}
					}
					num2 >>= 1;
				}
				num2 = 2147483648U;
			}
			bigInteger4 = (bigInteger4 * bigInteger - bigInteger2) % n;
			bigInteger = (bigInteger * bigInteger3 - P * bigInteger2) % n;
			if (flag)
			{
				flag = false;
			}
			else
			{
				bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
			}
			bigInteger2 = bigInteger2 * Q % n;
			for (int j = 0; j < s; j++)
			{
				bigInteger4 = bigInteger4 * bigInteger % n;
				bigInteger = (bigInteger * bigInteger - (bigInteger2 << 1)) % n;
				if (flag)
				{
					bigInteger2 = Q % n;
					flag = false;
				}
				else
				{
					bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
				}
			}
			array[0] = bigInteger4;
			array[1] = bigInteger;
			array[2] = bigInteger2;
			return array;
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x00037AFC File Offset: 0x00035CFC
		public static void MulDivTest(int rounds)
		{
			Random random = new Random();
			byte[] array = new byte[64];
			byte[] array2 = new byte[64];
			for (int i = 0; i < rounds; i++)
			{
				int num;
				for (num = 0; num == 0; num = (int)(random.NextDouble() * 65.0))
				{
				}
				int num2;
				for (num2 = 0; num2 == 0; num2 = (int)(random.NextDouble() * 65.0))
				{
				}
				bool flag = false;
				while (!flag)
				{
					for (int j = 0; j < 64; j++)
					{
						if (j < num)
						{
							array[j] = (byte)(random.NextDouble() * 256.0);
						}
						else
						{
							array[j] = 0;
						}
						if (array[j] != 0)
						{
							flag = true;
						}
					}
				}
				flag = false;
				while (!flag)
				{
					for (int k = 0; k < 64; k++)
					{
						if (k < num2)
						{
							array2[k] = (byte)(random.NextDouble() * 256.0);
						}
						else
						{
							array2[k] = 0;
						}
						if (array2[k] != 0)
						{
							flag = true;
						}
					}
				}
				while (array[0] == 0)
				{
					array[0] = (byte)(random.NextDouble() * 256.0);
				}
				while (array2[0] == 0)
				{
					array2[0] = (byte)(random.NextDouble() * 256.0);
				}
				Console.WriteLine(i);
				BigInteger bigInteger = new BigInteger(array, num);
				BigInteger bigInteger2 = new BigInteger(array2, num2);
				BigInteger bigInteger3 = bigInteger / bigInteger2;
				BigInteger bigInteger4 = bigInteger % bigInteger2;
				BigInteger bigInteger5 = bigInteger3 * bigInteger2 + bigInteger4;
				if (bigInteger5 != bigInteger)
				{
					Console.WriteLine("Error at " + i.ToString());
					BigInteger bigInteger6 = bigInteger;
					Console.WriteLine(((bigInteger6 != null) ? bigInteger6.ToString() : null) + "\n");
					BigInteger bigInteger7 = bigInteger2;
					Console.WriteLine(((bigInteger7 != null) ? bigInteger7.ToString() : null) + "\n");
					BigInteger bigInteger8 = bigInteger3;
					Console.WriteLine(((bigInteger8 != null) ? bigInteger8.ToString() : null) + "\n");
					BigInteger bigInteger9 = bigInteger4;
					Console.WriteLine(((bigInteger9 != null) ? bigInteger9.ToString() : null) + "\n");
					BigInteger bigInteger10 = bigInteger5;
					Console.WriteLine(((bigInteger10 != null) ? bigInteger10.ToString() : null) + "\n");
					return;
				}
			}
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x00037D20 File Offset: 0x00035F20
		public static void RSATest(int rounds)
		{
			Random random = new Random(1);
			byte[] array = new byte[64];
			BigInteger bigInteger = new BigInteger("a932b948feed4fb2b692609bd22164fc9edb59fae7880cc1eaff7b3c9626b7e5b241c27a974833b2622ebe09beb451917663d47232488f23a117fc97720f1e7", 16);
			BigInteger bigInteger2 = new BigInteger("4adf2f7a89da93248509347d2ae506d683dd3a16357e859a980c4f77a4e2f7a01fae289f13a851df6e9db5adaa60bfd2b162bbbe31f7c8f828261a6839311929d2cef4f864dde65e556ce43c89bbbf9f1ac5511315847ce9cc8dc92470a747b8792d6a83b0092d2e5ebaf852c85cacf34278efa99160f2f8aa7ee7214de07b7", 16);
			BigInteger bigInteger3 = new BigInteger("e8e77781f36a7b3188d711c2190b560f205a52391b3479cdb99fa010745cbeba5f2adc08e1de6bf38398a0487c4a73610d94ec36f17f3f46ad75e17bc1adfec99839589f45f95ccc94cb2a5c500b477eb3323d8cfab0c8458c96f0147a45d27e45a4d11d54d77684f65d48f15fafcc1ba208e71e921b9bd9017c16a5231af7f", 16);
			Console.WriteLine("e =\n" + bigInteger.ToString(10));
			Console.WriteLine("\nd =\n" + bigInteger2.ToString(10));
			Console.WriteLine("\nn =\n" + bigInteger3.ToString(10) + "\n");
			for (int i = 0; i < rounds; i++)
			{
				int num;
				for (num = 0; num == 0; num = (int)(random.NextDouble() * 65.0))
				{
				}
				bool flag = false;
				while (!flag)
				{
					for (int j = 0; j < 64; j++)
					{
						if (j < num)
						{
							array[j] = (byte)(random.NextDouble() * 256.0);
						}
						else
						{
							array[j] = 0;
						}
						if (array[j] != 0)
						{
							flag = true;
						}
					}
				}
				while (array[0] == 0)
				{
					array[0] = (byte)(random.NextDouble() * 256.0);
				}
				Console.Write("Round = " + i.ToString());
				BigInteger bigInteger4 = new BigInteger(array, num);
				if (bigInteger4.modPow(bigInteger, bigInteger3).modPow(bigInteger2, bigInteger3) != bigInteger4)
				{
					Console.WriteLine("\nError at round " + i.ToString());
					BigInteger bigInteger5 = bigInteger4;
					Console.WriteLine(((bigInteger5 != null) ? bigInteger5.ToString() : null) + "\n");
					return;
				}
				Console.WriteLine(" <PASSED>.");
			}
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x00037EBC File Offset: 0x000360BC
		public static void RSATest2(int rounds)
		{
			Random random = new Random();
			byte[] array = new byte[64];
			byte[] inData = new byte[]
			{
				133,
				132,
				100,
				253,
				112,
				106,
				159,
				240,
				148,
				12,
				62,
				44,
				116,
				52,
				5,
				201,
				85,
				179,
				133,
				50,
				152,
				113,
				249,
				65,
				33,
				95,
				2,
				158,
				234,
				86,
				141,
				140,
				68,
				204,
				238,
				238,
				61,
				44,
				157,
				44,
				18,
				65,
				30,
				241,
				197,
				50,
				195,
				170,
				49,
				74,
				82,
				216,
				232,
				175,
				66,
				244,
				114,
				161,
				42,
				13,
				151,
				177,
				49,
				179
			};
			byte[] inData2 = new byte[]
			{
				153,
				152,
				202,
				184,
				94,
				215,
				229,
				220,
				40,
				92,
				111,
				14,
				21,
				9,
				89,
				110,
				132,
				243,
				129,
				205,
				222,
				66,
				220,
				147,
				194,
				122,
				98,
				172,
				108,
				175,
				222,
				116,
				227,
				203,
				96,
				32,
				56,
				156,
				33,
				195,
				220,
				200,
				162,
				77,
				198,
				42,
				53,
				127,
				243,
				169,
				232,
				29,
				123,
				44,
				120,
				250,
				184,
				2,
				85,
				128,
				155,
				194,
				165,
				203
			};
			BigInteger bi = new BigInteger(inData);
			BigInteger bigInteger = new BigInteger(inData2);
			BigInteger bigInteger2 = (bi - 1) * (bigInteger - 1);
			BigInteger bigInteger3 = bi * bigInteger;
			for (int i = 0; i < rounds; i++)
			{
				BigInteger bigInteger4 = bigInteger2.genCoPrime(512, random);
				BigInteger bigInteger5 = bigInteger4.modInverse(bigInteger2);
				Console.WriteLine("\ne =\n" + bigInteger4.ToString(10));
				Console.WriteLine("\nd =\n" + bigInteger5.ToString(10));
				Console.WriteLine("\nn =\n" + bigInteger3.ToString(10) + "\n");
				int num;
				for (num = 0; num == 0; num = (int)(random.NextDouble() * 65.0))
				{
				}
				bool flag = false;
				while (!flag)
				{
					for (int j = 0; j < 64; j++)
					{
						if (j < num)
						{
							array[j] = (byte)(random.NextDouble() * 256.0);
						}
						else
						{
							array[j] = 0;
						}
						if (array[j] != 0)
						{
							flag = true;
						}
					}
				}
				while (array[0] == 0)
				{
					array[0] = (byte)(random.NextDouble() * 256.0);
				}
				Console.Write("Round = " + i.ToString());
				BigInteger bigInteger6 = new BigInteger(array, num);
				if (bigInteger6.modPow(bigInteger4, bigInteger3).modPow(bigInteger5, bigInteger3) != bigInteger6)
				{
					Console.WriteLine("\nError at round " + i.ToString());
					BigInteger bigInteger7 = bigInteger6;
					Console.WriteLine(((bigInteger7 != null) ? bigInteger7.ToString() : null) + "\n");
					return;
				}
				Console.WriteLine(" <PASSED>.");
			}
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x000380A8 File Offset: 0x000362A8
		public static void SqrtTest(int rounds)
		{
			Random random = new Random();
			for (int i = 0; i < rounds; i++)
			{
				int num;
				for (num = 0; num == 0; num = (int)(random.NextDouble() * 1024.0))
				{
				}
				Console.Write("Round = " + i.ToString());
				BigInteger bigInteger = new BigInteger();
				bigInteger.genRandomBits(num, random);
				BigInteger bi = bigInteger.sqrt();
				if ((bi + 1) * (bi + 1) <= bigInteger)
				{
					Console.WriteLine("\nError at round " + i.ToString());
					BigInteger bigInteger2 = bigInteger;
					Console.WriteLine(((bigInteger2 != null) ? bigInteger2.ToString() : null) + "\n");
					return;
				}
				Console.WriteLine(" <PASSED>.");
			}
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x00038170 File Offset: 0x00036370
		public static void Main(string[] args)
		{
			byte[] inData = new byte[]
			{
				0,
				133,
				132,
				100,
				253,
				112,
				106,
				159,
				240,
				148,
				12,
				62,
				44,
				116,
				52,
				5,
				201,
				85,
				179,
				133,
				50,
				152,
				113,
				249,
				65,
				33,
				95,
				2,
				158,
				234,
				86,
				141,
				140,
				68,
				204,
				238,
				238,
				61,
				44,
				157,
				44,
				18,
				65,
				30,
				241,
				197,
				50,
				195,
				170,
				49,
				74,
				82,
				216,
				232,
				175,
				66,
				244,
				114,
				161,
				42,
				13,
				151,
				177,
				49,
				179
			};
			RuntimeHelpers.InitializeArray(new byte[65], fieldof(<PrivateImplementationDetails>.struct5_0).FieldHandle);
			Console.WriteLine("List of primes < 2000\n---------------------");
			int num = 100;
			int num2 = 0;
			for (int i = 0; i < 2000; i++)
			{
				if (i >= num)
				{
					Console.WriteLine();
					num += 100;
				}
				if (new BigInteger((long)(-(long)i)).isProbablePrime())
				{
					Console.Write(i.ToString() + ", ");
					num2++;
				}
			}
			Console.WriteLine("\nCount = " + num2.ToString());
			BigInteger bigInteger = new BigInteger(inData);
			Console.WriteLine("\n\nPrimality testing for\n" + bigInteger.ToString() + "\n");
			Console.WriteLine("SolovayStrassenTest(5) = " + bigInteger.SolovayStrassenTest(5).ToString());
			Console.WriteLine("RabinMillerTest(5) = " + bigInteger.RabinMillerTest(5).ToString());
			Console.WriteLine("FermatLittleTest(5) = " + bigInteger.FermatLittleTest(5).ToString());
			Console.WriteLine("isProbablePrime() = " + bigInteger.isProbablePrime().ToString());
			Console.Write("\nGenerating 512-bits random pseudoprime. . .");
			Random rand = new Random();
			BigInteger bigInteger2 = BigInteger.genPseudoPrime(512, 5, rand);
			string str = "\n";
			BigInteger bigInteger3 = bigInteger2;
			Console.WriteLine(str + ((bigInteger3 != null) ? bigInteger3.ToString() : null));
		}

		// Token: 0x04000568 RID: 1384
		private const int maxLength = 70;

		// Token: 0x04000569 RID: 1385
		public static readonly int[] primesBelow2000 = new int[]
		{
			2,
			3,
			5,
			7,
			11,
			13,
			17,
			19,
			23,
			29,
			31,
			37,
			41,
			43,
			47,
			53,
			59,
			61,
			67,
			71,
			73,
			79,
			83,
			89,
			97,
			101,
			103,
			107,
			109,
			113,
			127,
			131,
			137,
			139,
			149,
			151,
			157,
			163,
			167,
			173,
			179,
			181,
			191,
			193,
			197,
			199,
			211,
			223,
			227,
			229,
			233,
			239,
			241,
			251,
			257,
			263,
			269,
			271,
			277,
			281,
			283,
			293,
			307,
			311,
			313,
			317,
			331,
			337,
			347,
			349,
			353,
			359,
			367,
			373,
			379,
			383,
			389,
			397,
			401,
			409,
			419,
			421,
			431,
			433,
			439,
			443,
			449,
			457,
			461,
			463,
			467,
			479,
			487,
			491,
			499,
			503,
			509,
			521,
			523,
			541,
			547,
			557,
			563,
			569,
			571,
			577,
			587,
			593,
			599,
			601,
			607,
			613,
			617,
			619,
			631,
			641,
			643,
			647,
			653,
			659,
			661,
			673,
			677,
			683,
			691,
			701,
			709,
			719,
			727,
			733,
			739,
			743,
			751,
			757,
			761,
			769,
			773,
			787,
			797,
			809,
			811,
			821,
			823,
			827,
			829,
			839,
			853,
			857,
			859,
			863,
			877,
			881,
			883,
			887,
			907,
			911,
			919,
			929,
			937,
			941,
			947,
			953,
			967,
			971,
			977,
			983,
			991,
			997,
			1009,
			1013,
			1019,
			1021,
			1031,
			1033,
			1039,
			1049,
			1051,
			1061,
			1063,
			1069,
			1087,
			1091,
			1093,
			1097,
			1103,
			1109,
			1117,
			1123,
			1129,
			1151,
			1153,
			1163,
			1171,
			1181,
			1187,
			1193,
			1201,
			1213,
			1217,
			1223,
			1229,
			1231,
			1237,
			1249,
			1259,
			1277,
			1279,
			1283,
			1289,
			1291,
			1297,
			1301,
			1303,
			1307,
			1319,
			1321,
			1327,
			1361,
			1367,
			1373,
			1381,
			1399,
			1409,
			1423,
			1427,
			1429,
			1433,
			1439,
			1447,
			1451,
			1453,
			1459,
			1471,
			1481,
			1483,
			1487,
			1489,
			1493,
			1499,
			1511,
			1523,
			1531,
			1543,
			1549,
			1553,
			1559,
			1567,
			1571,
			1579,
			1583,
			1597,
			1601,
			1607,
			1609,
			1613,
			1619,
			1621,
			1627,
			1637,
			1657,
			1663,
			1667,
			1669,
			1693,
			1697,
			1699,
			1709,
			1721,
			1723,
			1733,
			1741,
			1747,
			1753,
			1759,
			1777,
			1783,
			1787,
			1789,
			1801,
			1811,
			1823,
			1831,
			1847,
			1861,
			1867,
			1871,
			1873,
			1877,
			1879,
			1889,
			1901,
			1907,
			1913,
			1931,
			1933,
			1949,
			1951,
			1973,
			1979,
			1987,
			1993,
			1997,
			1999
		};

		// Token: 0x0400056A RID: 1386
		private uint[] data;

		// Token: 0x0400056B RID: 1387
		public int dataLength;
	}
}
