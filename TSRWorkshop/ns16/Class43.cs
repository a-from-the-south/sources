using System;
using System.Collections.Generic;

namespace ns16
{
	// Token: 0x0200004F RID: 79
	internal sealed class Class43
	{
		// Token: 0x0600030A RID: 778 RVA: 0x00003BEA File Offset: 0x00001DEA
		public Class43(int level)
		{
			this.interface4_0 = Class43.smethod_3(level, out this.bruteforcelength);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00003C06 File Offset: 0x00001E06
		public Class43(int blockinterval, int lookupstart, int windowlength, int bucketdepth, int bruteforcelength)
		{
			this.interface4_0 = Class43.smethod_2(blockinterval, lookupstart, windowlength, bucketdepth);
			this.bruteforcelength = bruteforcelength;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00039930 File Offset: 0x00037B30
		public static bool smethod_0(byte[] byte_1, out byte[] byte_2)
		{
			Class43 @class = new Class43(5);
			byte_2 = @class.method_0(byte_1);
			return byte_2 != null;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0003995C File Offset: 0x00037B5C
		public static bool smethod_1(byte[] byte_1, out byte[] byte_2, int int_3)
		{
			Class43 @class = new Class43(int_3);
			byte_2 = @class.method_0(byte_1);
			return byte_2 != null;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00039988 File Offset: 0x00037B88
		public byte[] method_0(byte[] byte_1)
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
								this.interface4_0.imethod_2(byte_1[num2++]);
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
										this.interface4_0.imethod_2(byte_1[num2++]);
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
					this.interface4_0.imethod_3();
				}
				result = array5;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00039E08 File Offset: 0x00038008
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
			if (this.int_1 < 1028 && this.interface4_0.imethod_0(out int_4))
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
				while (this.interface4_0.imethod_1(out int_4));
			}
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00039F20 File Offset: 0x00038120
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

		// Token: 0x06000311 RID: 785 RVA: 0x00039F70 File Offset: 0x00038170
		private static Class43.Interface4 smethod_2(int int_3, int int_4, int int_5, int int_6)
		{
			Class43.Interface4 result;
			if (int_6 <= 1)
			{
				result = new Class43.Class44(int_3, int_4, int_5);
			}
			else
			{
				result = new Class43.Class45(int_3, int_4, int_5, int_6);
			}
			return result;
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00039F9C File Offset: 0x0003819C
		private static Class43.Interface4 smethod_3(int int_3, out int int_4)
		{
			Class43.Interface4 result;
			switch (int_3)
			{
			case 0:
				int_4 = 0;
				result = Class43.smethod_2(4, 0, 16384, 1);
				break;
			case 1:
				int_4 = 0;
				result = Class43.smethod_2(2, 0, 32768, 1);
				break;
			case 2:
				int_4 = 0;
				result = Class43.smethod_2(1, 0, 65536, 1);
				break;
			case 3:
				int_4 = 0;
				result = Class43.smethod_2(1, 0, 131000, 2);
				break;
			case 4:
				int_4 = 16;
				result = Class43.smethod_2(1, 16, 131000, 2);
				break;
			case 5:
				int_4 = 16;
				result = Class43.smethod_2(1, 16, 131000, 5);
				break;
			case 6:
				int_4 = 32;
				result = Class43.smethod_2(1, 32, 131000, 5);
				break;
			case 7:
				int_4 = 32;
				result = Class43.smethod_2(1, 32, 131000, 10);
				break;
			case 8:
				int_4 = 64;
				result = Class43.smethod_2(1, 64, 131000, 10);
				break;
			case 9:
				int_4 = 128;
				result = Class43.smethod_2(1, 128, 131000, 20);
				break;
			default:
				result = Class43.smethod_3(5, out int_4);
				break;
			}
			return result;
		}

		// Token: 0x040002BC RID: 700
		private int bruteforcelength;

		// Token: 0x040002BD RID: 701
		private Class43.Interface4 interface4_0;

		// Token: 0x040002BE RID: 702
		private byte[] byte_0;

		// Token: 0x040002BF RID: 703
		private int int_0;

		// Token: 0x040002C0 RID: 704
		private int int_1;

		// Token: 0x040002C1 RID: 705
		private int int_2;

		// Token: 0x040002C2 RID: 706
		private bool bool_0;

		// Token: 0x02000050 RID: 80
		private interface Interface4
		{
			// Token: 0x06000313 RID: 787
			bool imethod_0(out int int_0);

			// Token: 0x06000314 RID: 788
			bool imethod_1(out int int_0);

			// Token: 0x06000315 RID: 789
			void imethod_2(byte byte_0);

			// Token: 0x06000316 RID: 790
			void imethod_3();
		}

		// Token: 0x02000051 RID: 81
		private sealed class Class44 : Class43.Interface4
		{
			// Token: 0x06000317 RID: 791 RVA: 0x0003A0C8 File Offset: 0x000382C8
			public Class44(int blockinterval, int lookupstart, int windowlength)
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

			// Token: 0x06000318 RID: 792 RVA: 0x0003A144 File Offset: 0x00038344
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

			// Token: 0x06000319 RID: 793 RVA: 0x0003A1B4 File Offset: 0x000383B4
			public bool imethod_1(out int int_6)
			{
				int_6 = 0;
				return false;
			}

			// Token: 0x0600031A RID: 794 RVA: 0x0003A1CC File Offset: 0x000383CC
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

			// Token: 0x0600031B RID: 795 RVA: 0x0003A3C8 File Offset: 0x000385C8
			public bool imethod_0(out int int_6)
			{
				return this.dictionary_0.TryGetValue(this.uint_0, out int_6);
			}

			// Token: 0x040002C3 RID: 707
			private uint uint_0;

			// Token: 0x040002C4 RID: 708
			private int blockinterval;

			// Token: 0x040002C5 RID: 709
			private int int_0;

			// Token: 0x040002C6 RID: 710
			private int int_1;

			// Token: 0x040002C7 RID: 711
			private uint[] uint_1;

			// Token: 0x040002C8 RID: 712
			private int int_2;

			// Token: 0x040002C9 RID: 713
			private int int_3;

			// Token: 0x040002CA RID: 714
			private int int_4;

			// Token: 0x040002CB RID: 715
			private bool bool_0;

			// Token: 0x040002CC RID: 716
			private uint[] uint_2;

			// Token: 0x040002CD RID: 717
			private int int_5;

			// Token: 0x040002CE RID: 718
			private Dictionary<uint, int> dictionary_0 = new Dictionary<uint, int>();
		}

		// Token: 0x02000052 RID: 82
		private sealed class Class45 : Class43.Interface4
		{
			// Token: 0x0600031C RID: 796 RVA: 0x0003A3EC File Offset: 0x000385EC
			public Class45(int blockinterval, int lookupstart, int windowlength, int bucketdepth)
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

			// Token: 0x0600031D RID: 797 RVA: 0x0003A47C File Offset: 0x0003867C
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

			// Token: 0x0600031E RID: 798 RVA: 0x0003A4F4 File Offset: 0x000386F4
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

			// Token: 0x0600031F RID: 799 RVA: 0x0003A7C0 File Offset: 0x000389C0
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

			// Token: 0x06000320 RID: 800 RVA: 0x0003A818 File Offset: 0x00038A18
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

			// Token: 0x040002CF RID: 719
			private int bucketdepth;

			// Token: 0x040002D0 RID: 720
			private uint uint_0;

			// Token: 0x040002D1 RID: 721
			private int blockinterval;

			// Token: 0x040002D2 RID: 722
			private int int_0;

			// Token: 0x040002D3 RID: 723
			private int int_1;

			// Token: 0x040002D4 RID: 724
			private uint[] uint_1;

			// Token: 0x040002D5 RID: 725
			private int int_2;

			// Token: 0x040002D6 RID: 726
			private int int_3;

			// Token: 0x040002D7 RID: 727
			private int int_4;

			// Token: 0x040002D8 RID: 728
			private bool bool_0;

			// Token: 0x040002D9 RID: 729
			private uint[] uint_2;

			// Token: 0x040002DA RID: 730
			private int int_5;

			// Token: 0x040002DB RID: 731
			private Dictionary<uint, List<int>> dictionary_0 = new Dictionary<uint, List<int>>();

			// Token: 0x040002DC RID: 732
			private Stack<List<int>> stack_0 = new Stack<List<int>>();

			// Token: 0x040002DD RID: 733
			private List<int> list_0;

			// Token: 0x040002DE RID: 734
			private int int_6;
		}
	}
}
