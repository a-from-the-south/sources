using System;
using System.Collections.Generic;

namespace ns4
{
	// Token: 0x020000A7 RID: 167
	internal sealed class Class70
	{
		// Token: 0x060006A5 RID: 1701 RVA: 0x00005503 File Offset: 0x00003703
		private Class70(int level)
		{
			this.interface7_0 = Class70.smethod_3(level, out this.bruteforcelength);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0000551F File Offset: 0x0000371F
		private Class70(int blockinterval, int lookupstart, int windowlength, int bucketdepth, int bruteforcelength)
		{
			this.interface7_0 = Class70.smethod_2(blockinterval, lookupstart, windowlength, bucketdepth);
			this.bruteforcelength = bruteforcelength;
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00065AA8 File Offset: 0x00063CA8
		public static bool smethod_0(ref byte[] byte_1, out byte[] byte_2)
		{
			Class70 @class = new Class70(5);
			byte_2 = @class.method_0(ref byte_1);
			return byte_2 != null;
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00065AD4 File Offset: 0x00063CD4
		private static bool smethod_1(ref byte[] byte_1, out byte[] byte_2, int int_3)
		{
			Class70 @class = new Class70(int_3);
			byte_2 = @class.method_0(ref byte_1);
			return byte_2 != null;
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00065B00 File Offset: 0x00063D00
		private byte[] method_0(ref byte[] byte_1)
		{
			bool flag = false;
			List<byte[]> list = new List<byte[]>();
			int i = 0;
			int num = 0;
			byte[] result;
			if (byte_1.Length >= 16 && byte_1.LongLength <= 4294967295L)
			{
				this.byte_0 = byte_1;
				byte[] array5;
				try
				{
					int num2 = 0;
					while (i < byte_1.Length)
					{
						if (byte_1.Length - i < 4)
						{
							byte[] array = new byte[byte_1.Length - i + 1];
							array[0] = (byte)(252 | byte_1.Length - i);
							Array.Copy(byte_1, i, array, 1, byte_1.Length - i);
							list.Add(array);
							i += array.Length - 1;
							num += array.Length;
							flag = true;
						}
						else
						{
							while (i > num2 - 3)
							{
								this.interface7_0.imethod_2(byte_1[num2++]);
							}
							this.int_0 = 0;
							this.int_1 = 0;
							this.int_2 = int.MaxValue;
							this.bool_0 = false;
							do
							{
								for (int j = 0; j < 4; j++)
								{
									if (num2 < byte_1.Length)
									{
										this.interface7_0.imethod_2(byte_1[num2++]);
									}
									this.method_1(num2 - 4);
								}
							}
							while (!this.bool_0 && num2 + 4 <= byte_1.Length);
							if (!this.bool_0)
							{
								this.int_2 = this.byte_0.Length;
							}
							while (this.int_2 - i >= 4)
							{
								int num3 = this.int_2 - i & -4;
								if (num3 > 112)
								{
									num3 = 112;
								}
								byte[] array2 = new byte[num3 + 1];
								array2[0] = (byte)(224 | (num3 >> 2) - 1);
								Array.Copy(byte_1, i, array2, 1, num3);
								list.Add(array2);
								i += num3;
								num += array2.Length;
							}
							if (this.bool_0)
							{
								while (this.int_1 > 0)
								{
									int num4 = this.int_1;
									if (num4 > 1028)
									{
										num4 = 1028;
									}
									this.int_1 -= num4;
									int num5 = this.int_2 - this.int_0 - 1;
									int num6 = this.int_2 - i;
									this.int_0 += num4;
									this.int_2 += num4;
									byte[] array3;
									if (num4 <= 67 && num5 <= 16383)
									{
										if (num4 <= 10 && num5 <= 1023)
										{
											array3 = new byte[num6 + 2];
											array3[0] = (byte)((num6 & 3) | (num4 - 3 << 2 & 28) | (num5 >> 3 & 96));
											array3[1] = (byte)(num5 & 255);
										}
										else
										{
											array3 = new byte[num6 + 3];
											array3[0] = (byte)(128 | (num4 - 4 & 63));
											array3[1] = (byte)((num6 << 6 & 192) | (num5 >> 8 & 63));
											array3[2] = (byte)(num5 & 255);
										}
									}
									else
									{
										array3 = new byte[num6 + 4];
										array3[0] = (byte)(192 | num6 | (num4 - 5 >> 6 & 12) | (num5 >> 12 & 16));
										array3[1] = (byte)(num5 >> 8 & 255);
										array3[2] = (byte)(num5 & 255);
										array3[3] = (byte)(num4 - 5 & 255);
									}
									if (num6 > 0)
									{
										Array.Copy(byte_1, i, array3, array3.Length - num6, num6);
									}
									list.Add(array3);
									i += num4 + num6;
									num += array3.Length;
								}
							}
						}
					}
					if (num + 6 < byte_1.Length)
					{
						byte[] array4;
						int num7;
						if (byte_1.Length > 16777215)
						{
							array4 = new byte[num + 6 + (flag ? 0 : 1)];
							array4[0] = 144;
							array4[1] = 251;
							array4[2] = (byte)(byte_1.Length >> 24);
							array4[3] = (byte)(byte_1.Length >> 16);
							array4[4] = (byte)(byte_1.Length >> 8);
							array4[5] = (byte)byte_1.Length;
							num7 = 6;
						}
						else
						{
							array4 = new byte[num + 5 + (flag ? 0 : 1)];
							array4[0] = 16;
							array4[1] = 251;
							array4[2] = (byte)(byte_1.Length >> 16);
							array4[3] = (byte)(byte_1.Length >> 8);
							array4[4] = (byte)byte_1.Length;
							num7 = 5;
						}
						for (int k = 0; k < list.Count; k++)
						{
							Array.Copy(list[k], 0, array4, num7, list[k].Length);
							num7 += list[k].Length;
						}
						if (!flag)
						{
							array4[array4.Length - 1] = 252;
						}
						array5 = array4;
					}
					else
					{
						array5 = null;
					}
				}
				finally
				{
					this.byte_0 = null;
					this.interface7_0.imethod_3();
				}
				result = array5;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00065F98 File Offset: 0x00064198
		private void method_1(int int_3)
		{
			int num = -this.bruteforcelength;
			if (int_3 < this.bruteforcelength)
			{
				num = -int_3;
			}
			byte b = this.byte_0[int_3];
			int num2 = -1;
			while (num2 >= num && this.int_1 < 1028)
			{
				byte b2 = this.byte_0[num2 + int_3];
				if (b2 == b)
				{
					int num3 = this.method_2(int_3 + num2, int_3);
					if (num3 > this.int_1 && num3 >= 3 && (num3 >= 4 || num2 > -1024) && (num3 >= 5 || num2 > -16384))
					{
						this.bool_0 = true;
						this.int_0 = int_3 + num2;
						this.int_1 = num3;
						this.int_2 = int_3;
					}
				}
				num2--;
			}
			int int_4;
			if (this.int_1 < 1028 && this.interface7_0.imethod_0(out int_4))
			{
				do
				{
					int num4 = this.method_2(int_4, int_3);
					if (num4 >= 5)
					{
						this.bool_0 = true;
						this.int_0 = int_4;
						this.int_1 = num4;
						this.int_2 = int_3;
					}
					if (this.int_1 >= 1028)
					{
						break;
					}
				}
				while (this.interface7_0.imethod_1(out int_4));
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x000660B0 File Offset: 0x000642B0
		private int method_2(int int_3, int int_4)
		{
			int num = int_3 + 1;
			int num2 = int_4 + 1;
			while (num2 < this.byte_0.Length && this.byte_0[num] == this.byte_0[num2] && num2 - int_4 < 1028)
			{
				num++;
				num2++;
			}
			return num2 - int_4;
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00066100 File Offset: 0x00064300
		private static Class70.Interface7 smethod_2(int int_3, int int_4, int int_5, int int_6)
		{
			Class70.Interface7 result;
			if (int_6 <= 1)
			{
				result = new Class70.Class71(int_3, int_4, int_5);
			}
			else
			{
				result = new Class70.Class72(int_3, int_4, int_5, int_6);
			}
			return result;
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0006612C File Offset: 0x0006432C
		private static Class70.Interface7 smethod_3(int int_3, out int int_4)
		{
			Class70.Interface7 result;
			switch (int_3)
			{
			case 0:
				int_4 = 0;
				result = Class70.smethod_2(4, 0, 16384, 1);
				break;
			case 1:
				int_4 = 0;
				result = Class70.smethod_2(2, 0, 32768, 1);
				break;
			case 2:
				int_4 = 0;
				result = Class70.smethod_2(1, 0, 65536, 1);
				break;
			case 3:
				int_4 = 0;
				result = Class70.smethod_2(1, 0, 131000, 2);
				break;
			case 4:
				int_4 = 16;
				result = Class70.smethod_2(1, 16, 131000, 2);
				break;
			case 5:
				int_4 = 16;
				result = Class70.smethod_2(1, 16, 131000, 5);
				break;
			case 6:
				int_4 = 32;
				result = Class70.smethod_2(1, 32, 131000, 5);
				break;
			case 7:
				int_4 = 32;
				result = Class70.smethod_2(1, 32, 131000, 10);
				break;
			case 8:
				int_4 = 64;
				result = Class70.smethod_2(1, 64, 131000, 10);
				break;
			case 9:
				int_4 = 128;
				result = Class70.smethod_2(1, 128, 131000, 20);
				break;
			default:
				result = Class70.smethod_3(5, out int_4);
				break;
			}
			return result;
		}

		// Token: 0x04000601 RID: 1537
		private int bruteforcelength;

		// Token: 0x04000602 RID: 1538
		private Class70.Interface7 interface7_0;

		// Token: 0x04000603 RID: 1539
		private byte[] byte_0;

		// Token: 0x04000604 RID: 1540
		private int int_0;

		// Token: 0x04000605 RID: 1541
		private int int_1;

		// Token: 0x04000606 RID: 1542
		private int int_2;

		// Token: 0x04000607 RID: 1543
		private bool bool_0;

		// Token: 0x020000A8 RID: 168
		private interface Interface7
		{
			// Token: 0x060006AE RID: 1710
			bool imethod_0(out int int_0);

			// Token: 0x060006AF RID: 1711
			bool imethod_1(out int int_0);

			// Token: 0x060006B0 RID: 1712
			void imethod_2(byte byte_0);

			// Token: 0x060006B1 RID: 1713
			void imethod_3();
		}

		// Token: 0x020000A9 RID: 169
		private sealed class Class71 : Class70.Interface7
		{
			// Token: 0x060006B2 RID: 1714 RVA: 0x00066258 File Offset: 0x00064458
			public Class71(int blockinterval, int lookupstart, int windowlength)
			{
				this.blockinterval = blockinterval;
				if (lookupstart > 0)
				{
					this.uint_1 = new uint[lookupstart / blockinterval];
					this.int_1 = this.uint_1.Length * blockinterval;
				}
				else
				{
					this.int_1 = 0;
				}
				this.uint_2 = new uint[windowlength / blockinterval - lookupstart / blockinterval];
				this.int_4 = -(this.uint_2.Length + lookupstart / blockinterval) * blockinterval - 4;
			}

			// Token: 0x060006B3 RID: 1715 RVA: 0x000662D4 File Offset: 0x000644D4
			public void imethod_3()
			{
				this.dictionary_0.Clear();
				this.uint_0 = 0U;
				this.int_0 = 0;
				this.int_4 = -(this.uint_2.Length + ((this.uint_1 != null) ? this.uint_1.Length : 0)) * this.blockinterval - 4;
				this.int_3 = 0;
				this.bool_0 = false;
				this.int_5 = 0;
				this.int_2 = 0;
			}

			// Token: 0x060006B4 RID: 1716 RVA: 0x0003A1B4 File Offset: 0x000383B4
			public bool imethod_1(out int int_6)
			{
				int_6 = 0;
				return false;
			}

			// Token: 0x060006B5 RID: 1717 RVA: 0x00066344 File Offset: 0x00064544
			public void imethod_2(byte byte_0)
			{
				if (this.bool_0)
				{
					this.int_0++;
					if (this.int_0 == this.blockinterval)
					{
						this.int_0 = 0;
						if (this.int_4 >= 0)
						{
							if (this.int_5 == this.uint_2.Length)
							{
								this.int_5 = 0;
							}
							uint key = this.uint_2[this.int_5];
							int num;
							if (this.dictionary_0.TryGetValue(key, out num) && num == this.int_4)
							{
								this.dictionary_0.Remove(key);
							}
						}
						if (this.uint_1 != null)
						{
							if (this.int_3 > this.int_1 + 4)
							{
								uint num2 = this.uint_1[this.int_2];
								this.uint_2[this.int_5] = num2;
								this.int_5++;
								if (this.int_5 > this.uint_2.Length)
								{
									this.int_5 = 0;
								}
								this.dictionary_0[num2] = this.int_3 - this.int_1 - 4;
							}
							this.uint_1[this.int_2] = this.uint_0;
							this.int_2++;
							if (this.int_2 == this.uint_1.Length)
							{
								this.int_2 = 0;
							}
						}
						else
						{
							this.uint_2[this.int_5] = this.uint_0;
							this.int_5++;
							if (this.int_5 > this.uint_2.Length)
							{
								this.int_5 = 0;
							}
							this.dictionary_0[this.uint_0] = this.int_3 - 4;
						}
					}
				}
				else
				{
					this.int_0++;
					if (this.int_0 == this.blockinterval)
					{
						this.int_0 = 0;
					}
					this.bool_0 = (this.int_3 == 3);
				}
				this.uint_0 = (this.uint_0 << 8 | (uint)byte_0);
				this.int_3++;
				this.int_4++;
			}

			// Token: 0x060006B6 RID: 1718 RVA: 0x00066540 File Offset: 0x00064740
			public bool imethod_0(out int int_6)
			{
				return this.dictionary_0.TryGetValue(this.uint_0, out int_6);
			}

			// Token: 0x04000608 RID: 1544
			private uint uint_0;

			// Token: 0x04000609 RID: 1545
			private int blockinterval;

			// Token: 0x0400060A RID: 1546
			private int int_0;

			// Token: 0x0400060B RID: 1547
			private int int_1;

			// Token: 0x0400060C RID: 1548
			private uint[] uint_1;

			// Token: 0x0400060D RID: 1549
			private int int_2;

			// Token: 0x0400060E RID: 1550
			private int int_3;

			// Token: 0x0400060F RID: 1551
			private int int_4;

			// Token: 0x04000610 RID: 1552
			private bool bool_0;

			// Token: 0x04000611 RID: 1553
			private uint[] uint_2;

			// Token: 0x04000612 RID: 1554
			private int int_5;

			// Token: 0x04000613 RID: 1555
			private Dictionary<uint, int> dictionary_0 = new Dictionary<uint, int>();
		}

		// Token: 0x020000AA RID: 170
		private sealed class Class72 : Class70.Interface7
		{
			// Token: 0x060006B7 RID: 1719 RVA: 0x00066564 File Offset: 0x00064764
			public Class72(int blockinterval, int lookupstart, int windowlength, int bucketdepth)
			{
				this.blockinterval = blockinterval;
				if (lookupstart > 0)
				{
					this.uint_1 = new uint[lookupstart / blockinterval];
					this.int_1 = this.uint_1.Length * blockinterval;
				}
				else
				{
					this.int_1 = 0;
				}
				this.uint_2 = new uint[windowlength / blockinterval - lookupstart / blockinterval];
				this.int_4 = -(this.uint_2.Length + lookupstart / blockinterval) * blockinterval - 4;
				this.bucketdepth = bucketdepth;
			}

			// Token: 0x060006B8 RID: 1720 RVA: 0x000665F4 File Offset: 0x000647F4
			public void imethod_3()
			{
				this.dictionary_0.Clear();
				this.uint_0 = 0U;
				this.int_0 = 0;
				this.int_4 = -(this.uint_2.Length + ((this.uint_1 != null) ? this.uint_1.Length : 0)) * this.blockinterval - 4;
				this.int_3 = 0;
				this.bool_0 = false;
				this.int_5 = 0;
				this.int_2 = 0;
				this.list_0 = null;
			}

			// Token: 0x060006B9 RID: 1721 RVA: 0x0006666C File Offset: 0x0006486C
			public void imethod_2(byte byte_0)
			{
				if (this.bool_0)
				{
					this.int_0++;
					if (this.int_0 == this.blockinterval)
					{
						this.int_0 = 0;
						if (this.int_4 > 0)
						{
							if (this.int_5 == this.uint_2.Length)
							{
								this.int_5 = 0;
							}
							uint key = this.uint_2[this.int_5];
							List<int> list;
							if (this.dictionary_0.TryGetValue(key, out list) && list[0] == this.int_4)
							{
								list.RemoveAt(0);
								if (list.Count == 0)
								{
									this.dictionary_0.Remove(key);
									this.stack_0.Push(list);
								}
							}
						}
						if (this.uint_1 != null)
						{
							if (this.int_3 > this.int_1 + 4)
							{
								uint num = this.uint_1[this.int_2];
								this.uint_2[this.int_5] = num;
								this.int_5++;
								if (this.int_5 > this.uint_2.Length)
								{
									this.int_5 = 0;
								}
								List<int> list2;
								if (this.dictionary_0.TryGetValue(num, out list2))
								{
									if (list2.Count == this.bucketdepth)
									{
										list2.RemoveAt(0);
									}
								}
								else
								{
									if (this.stack_0.Count > 0)
									{
										list2 = this.stack_0.Pop();
									}
									else
									{
										list2 = new List<int>();
									}
									this.dictionary_0[num] = list2;
								}
								list2.Add(this.int_3 - this.int_1 - 4);
							}
							this.uint_1[this.int_2] = this.uint_0;
							this.int_2++;
							if (this.int_2 == this.uint_1.Length)
							{
								this.int_2 = 0;
							}
						}
						else
						{
							this.uint_2[this.int_5] = this.uint_0;
							this.int_5++;
							if (this.int_5 > this.uint_2.Length)
							{
								this.int_5 = 0;
							}
							List<int> list3;
							if (this.dictionary_0.TryGetValue(this.uint_0, out list3))
							{
								if (list3.Count == this.bucketdepth)
								{
									list3.RemoveAt(0);
								}
							}
							else
							{
								if (this.stack_0.Count > 0)
								{
									list3 = this.stack_0.Pop();
								}
								else
								{
									list3 = new List<int>();
								}
								this.dictionary_0[this.uint_0] = list3;
							}
							list3.Add(this.int_3 - 4);
						}
					}
				}
				else
				{
					this.int_0++;
					if (this.int_0 == this.blockinterval)
					{
						this.int_0 = 0;
					}
					this.bool_0 = (this.int_3 == 3);
				}
				this.uint_0 = (this.uint_0 << 8 | (uint)byte_0);
				this.int_3++;
				this.int_4++;
			}

			// Token: 0x060006BA RID: 1722 RVA: 0x00066938 File Offset: 0x00064B38
			public bool imethod_1(out int int_7)
			{
				bool result;
				if (this.list_0 != null && this.int_6 < this.list_0.Count)
				{
					int_7 = this.list_0[this.int_6];
					this.int_6++;
					result = true;
				}
				else
				{
					int_7 = -1;
					result = false;
				}
				return result;
			}

			// Token: 0x060006BB RID: 1723 RVA: 0x00066990 File Offset: 0x00064B90
			public bool imethod_0(out int int_7)
			{
				bool result;
				if (this.dictionary_0.TryGetValue(this.uint_0, out this.list_0))
				{
					this.int_6 = 1;
					int_7 = this.list_0[0];
					result = true;
				}
				else
				{
					this.list_0 = null;
					int_7 = -1;
					result = false;
				}
				return result;
			}

			// Token: 0x04000614 RID: 1556
			private int bucketdepth;

			// Token: 0x04000615 RID: 1557
			private uint uint_0;

			// Token: 0x04000616 RID: 1558
			private int blockinterval;

			// Token: 0x04000617 RID: 1559
			private int int_0;

			// Token: 0x04000618 RID: 1560
			private int int_1;

			// Token: 0x04000619 RID: 1561
			private uint[] uint_1;

			// Token: 0x0400061A RID: 1562
			private int int_2;

			// Token: 0x0400061B RID: 1563
			private int int_3;

			// Token: 0x0400061C RID: 1564
			private int int_4;

			// Token: 0x0400061D RID: 1565
			private bool bool_0;

			// Token: 0x0400061E RID: 1566
			private uint[] uint_2;

			// Token: 0x0400061F RID: 1567
			private int int_5;

			// Token: 0x04000620 RID: 1568
			private Dictionary<uint, List<int>> dictionary_0 = new Dictionary<uint, List<int>>();

			// Token: 0x04000621 RID: 1569
			private Stack<List<int>> stack_0 = new Stack<List<int>>();

			// Token: 0x04000622 RID: 1570
			private List<int> list_0;

			// Token: 0x04000623 RID: 1571
			private int int_6;
		}
	}
}
