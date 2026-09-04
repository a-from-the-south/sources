using System;
using System.Collections.Generic;

namespace Package.Helper
{
	// Token: 0x020000D6 RID: 214
	public class Compression
	{
		// Token: 0x06000B65 RID: 2917 RVA: 0x00008491 File Offset: 0x00006691
		public static bool Compress(byte[] input, out byte[] output)
		{
			return Compression.Compress(input, out output, CompressionLevel.Max);
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0003834C File Offset: 0x0003654C
		public static bool Compress(byte[] input, out byte[] output, CompressionLevel level)
		{
			if ((long)input.Length >= 4294967295L)
			{
				throw new InvalidOperationException("input data is too large");
			}
			bool flag = false;
			List<byte[]> list = new List<byte[]>();
			int i = 0;
			int num = 0;
			output = null;
			if (input.Length < 16)
			{
				return false;
			}
			Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
			Queue<KeyValuePair<int, int>> queue2 = new Queue<KeyValuePair<int, int>>();
			Queue<List<int>> queue3 = new Queue<List<int>>();
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			int num2 = 0;
			while (i < input.Length)
			{
				while (i > num2 + level.BlockInterval && input.Length - i > 16)
				{
					if (queue2.Count >= level.PrequeueLength)
					{
						KeyValuePair<int, int> item = queue2.Dequeue();
						queue.Enqueue(item);
						List<int> list2;
						if (!dictionary.TryGetValue(item.Key, out list2))
						{
							if (queue3.Count > 0)
							{
								list2 = queue3.Dequeue();
							}
							else
							{
								list2 = new List<int>();
							}
							dictionary[item.Key] = list2;
						}
						if (list2.Count >= level.SameValToTrack)
						{
							int index = 0;
							int num3 = list2[0];
							for (int j = 1; j < list2.Count; j++)
							{
								if (list2[j] < num3)
								{
									index = j;
									num3 = list2[j];
								}
							}
							list2[index] = item.Value;
						}
						else
						{
							list2.Add(item.Value);
						}
						if (queue.Count > level.QueueLength)
						{
							KeyValuePair<int, int> keyValuePair = queue.Dequeue();
							list2 = dictionary[keyValuePair.Key];
							int k = 0;
							while (k < list2.Count)
							{
								if (list2[k] == keyValuePair.Value)
								{
									list2.RemoveAt(k);
									IL_18E:
									if (list2.Count == 0)
									{
										dictionary.Remove(keyValuePair.Key);
										queue3.Enqueue(list2);
										goto IL_1AF;
									}
									goto IL_1AF;
								}
								else
								{
									k++;
								}
							}
							goto IL_18E;
						}
					}
					IL_1AF:
					KeyValuePair<int, int> item2 = new KeyValuePair<int, int>(BitConverter.ToInt32(input, num2), num2);
					num2 += level.BlockInterval;
					queue2.Enqueue(item2);
				}
				if (input.Length - i < 4)
				{
					byte[] array = new byte[input.Length - i + 1];
					array[0] = (byte)(252 | input.Length - i);
					Array.Copy(input, i, array, 1, input.Length - i);
					list.Add(array);
					i += array.Length - 1;
					num += array.Length;
					flag = true;
				}
				else
				{
					int num4 = 0;
					int l = 0;
					int m = 0;
					bool flag2 = false;
					if (Compression.FindSequence(input, i, ref num4, ref l, ref m, dictionary, level))
					{
						flag2 = true;
					}
					else
					{
						int num5 = i + 4;
						while (!flag2 && num5 + 3 < input.Length)
						{
							if (Compression.FindSequence(input, num5, ref num4, ref l, ref m, dictionary, level))
							{
								m += num5 - i;
								flag2 = true;
							}
							num5 += 4;
						}
						if (m == 2147483647)
						{
							m = input.Length - i;
						}
						while (m >= 4)
						{
							int num6 = m & -4;
							if (num6 > 112)
							{
								num6 = 112;
							}
							byte[] array2 = new byte[num6 + 1];
							array2[0] = (byte)(224 | (num6 >> 2) - 1);
							Array.Copy(input, i, array2, 1, num6);
							list.Add(array2);
							i += num6;
							num += array2.Length;
							m -= num6;
						}
					}
					if (flag2)
					{
						if (Compression.FindRunLength(input, num4, i + m) < l)
						{
							break;
						}
						while (l > 0)
						{
							int num7 = l;
							if (num7 > 1028)
							{
								num7 = 1028;
							}
							l -= num7;
							int num8 = i - num4 + m - 1;
							byte[] array3;
							if (num7 <= 67 && num8 <= 16383)
							{
								if (num7 <= 10 && num8 <= 1023)
								{
									array3 = new byte[m + 2];
									array3[0] = (byte)((m & 3) | (num7 - 3 << 2 & 28) | (num8 >> 3 & 96));
									array3[1] = (byte)(num8 & 255);
								}
								else
								{
									array3 = new byte[m + 3];
									array3[0] = (byte)(128 | (num7 - 4 & 63));
									array3[1] = (byte)((m << 6 & 192) | (num8 >> 8 & 63));
									array3[2] = (byte)(num8 & 255);
								}
							}
							else
							{
								array3 = new byte[m + 4];
								array3[0] = (byte)(192 | m | (num7 - 5 >> 6 & 12) | (num8 >> 12 & 16));
								array3[1] = (byte)(num8 >> 8 & 255);
								array3[2] = (byte)(num8 & 255);
								array3[3] = (byte)(num7 - 5 & 255);
							}
							if (m > 0)
							{
								Array.Copy(input, i, array3, array3.Length - m, m);
							}
							list.Add(array3);
							i += num7 + m;
							num += array3.Length;
							num4 += num7;
							m = 0;
						}
					}
				}
			}
			if (num + 6 < input.Length)
			{
				int num9;
				if (input.Length > 16777215)
				{
					output = new byte[num + 5 + (flag ? 0 : 1)];
					output[0] = 144;
					output[1] = 251;
					output[2] = (byte)(input.Length >> 24);
					output[3] = (byte)(input.Length >> 16);
					output[4] = (byte)(input.Length >> 8);
					output[5] = (byte)input.Length;
					num9 = 6;
				}
				else
				{
					output = new byte[num + 5 + (flag ? 0 : 1)];
					output[0] = 16;
					output[1] = 251;
					output[2] = (byte)(input.Length >> 16);
					output[3] = (byte)(input.Length >> 8);
					output[4] = (byte)input.Length;
					num9 = 5;
				}
				for (int n = 0; n < list.Count; n++)
				{
					Array.Copy(list[n], 0, output, num9, list[n].Length);
					num9 += list[n].Length;
				}
				if (!flag)
				{
					output[output.Length - 1] = 252;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x000388DC File Offset: 0x00036ADC
		private static bool FindSequence(byte[] data, int offset, ref int bestStart, ref int bestLength, ref int bestIndex, Dictionary<int, List<int>> blockTracking, CompressionLevel level)
		{
			int num = -level.BruteForceLength;
			if (offset < level.BruteForceLength)
			{
				num = -offset;
			}
			int num2;
			if (offset > 4)
			{
				num2 = -3;
			}
			else
			{
				num2 = offset - 3;
			}
			bool result = false;
			try
			{
				if (bestLength < 3)
				{
					bestLength = 3;
					bestIndex = int.MaxValue;
				}
				byte[] array = new byte[(data.Length - offset > 4) ? 4 : (data.Length - offset)];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = data[offset + i];
				}
				while (num2 >= num && bestLength < 1028)
				{
					byte b = data[num2 + offset];
					for (int j = 0; j < array.Length; j++)
					{
						if (b == array[j] && num2 < j && num2 - j >= -131072)
						{
							int num3 = Compression.FindRunLength(data, offset + num2, offset + j);
							if ((num3 > bestLength || (num3 == bestLength && j < bestIndex)) && (num3 >= 5 || (num3 >= 4 && num2 - j > -16384) || (num3 >= 3 && num2 - j > -1024)))
							{
								result = true;
								bestStart = offset + num2;
								bestLength = num3;
								bestIndex = j;
							}
						}
					}
					num2--;
				}
				if (blockTracking.Count > 0 && data.Length - offset > 16 && bestLength < 1028)
				{
					for (int k = 0; k < 4; k++)
					{
						int num4 = offset + 3 - k;
						int num5 = (k > 3) ? (k - 3) : 0;
						int key = BitConverter.ToInt32(data, num4);
						List<int> list;
						if (blockTracking.TryGetValue(key, out list))
						{
							foreach (int num6 in list)
							{
								int num7 = num5;
								if (num6 + 131072 >= offset + 8)
								{
									int num8 = Compression.FindRunLength(data, num6 + num7, num4 + num7);
									if (num8 >= 5 && num8 > bestLength)
									{
										result = true;
										bestStart = num6 + num7;
										bestLength = num8;
										if (k < 3)
										{
											bestIndex = 3 - k;
										}
										else
										{
											bestIndex = 0;
										}
									}
									if (bestLength > 1028)
									{
										break;
									}
								}
							}
						}
						if (bestLength > 1028)
						{
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
			return result;
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x00038B34 File Offset: 0x00036D34
		private static int FindRunLength(byte[] data, int source, int destination)
		{
			int num = source + 1;
			int num2 = destination + 1;
			while (num2 < data.Length && data[num] == data[num2] && num2 - destination < 1028)
			{
				num++;
				num2++;
			}
			return num2 - destination;
		}
	}
}
