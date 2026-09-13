using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using ns16;
using ns17;

namespace ns21
{
	// Token: 0x020001A4 RID: 420
	internal sealed class Class187
	{
		// Token: 0x0600125B RID: 4699 RVA: 0x000C075C File Offset: 0x000BE95C
		private static bool smethod_0(Assembly assembly_0, Assembly assembly_1)
		{
			byte[] publicKey = assembly_0.GetName().GetPublicKey();
			byte[] publicKey2 = assembly_1.GetName().GetPublicKey();
			bool result;
			if (publicKey2 == null != (publicKey == null))
			{
				result = false;
			}
			else
			{
				if (publicKey2 != null)
				{
					for (int i = 0; i < publicKey2.Length; i++)
					{
						if (publicKey2[i] != publicKey[i])
						{
							return false;
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x000C07B8 File Offset: 0x000BE9B8
		public static byte[] smethod_1(byte[] byte_0)
		{
			Assembly callingAssembly = Assembly.GetCallingAssembly();
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			byte[] result;
			if (callingAssembly != executingAssembly && !Class187.smethod_0(executingAssembly, callingAssembly))
			{
				result = null;
			}
			else
			{
				Class187.Stream0 stream = new Class187.Stream0(byte_0);
				byte[] array = new byte[0];
				int num = stream.method_3();
				if (num == 67324752)
				{
					short num2 = (short)stream.method_2();
					int num3 = stream.method_2();
					int num4 = stream.method_2();
					if (num == 67324752 && num2 == 20 && num3 == 0)
					{
						if (num4 == 8)
						{
							stream.method_3();
							stream.method_3();
							stream.method_3();
							int num5 = stream.method_3();
							int num6 = stream.method_2();
							int num7 = stream.method_2();
							if (num6 > 0)
							{
								byte[] buffer = new byte[num6];
								stream.Read(buffer, 0, num6);
							}
							if (num7 > 0)
							{
								byte[] buffer2 = new byte[num7];
								stream.Read(buffer2, 0, num7);
							}
							byte[] array2 = new byte[stream.Length - stream.Position];
							stream.Read(array2, 0, array2.Length);
							Class187.Class188 @class = new Class187.Class188(array2);
							array = new byte[num5];
							@class.method_2(array, 0, array.Length);
							goto IL_2A2;
						}
					}
					throw new FormatException("Wrong Header Signature");
				}
				int num8 = num >> 24;
				num -= num8 << 24;
				if (num != 8223355)
				{
					throw new FormatException("Unknown Header");
				}
				if (num8 == 1)
				{
					int num9 = stream.method_3();
					array = new byte[num9];
					int num11;
					for (int i = 0; i < num9; i += num11)
					{
						int num10 = stream.method_3();
						num11 = stream.method_3();
						byte[] array3 = new byte[num10];
						stream.Read(array3, 0, array3.Length);
						Class187.Class188 class2 = new Class187.Class188(array3);
						class2.method_2(array, i, num11);
					}
				}
				if (num8 == 2)
				{
					byte[] byte_ = new byte[]
					{
						byte.MaxValue,
						221,
						185,
						20,
						134,
						32,
						82,
						65
					};
					byte[] byte_2 = new byte[]
					{
						211,
						197,
						55,
						145,
						249,
						70,
						230,
						45
					};
					using (Class186 class3 = new Class186())
					{
						using (ICryptoTransform cryptoTransform = class3.method_0(byte_, byte_2, true))
						{
							byte[] byte_3 = cryptoTransform.TransformFinalBlock(byte_0, 4, byte_0.Length - 4);
							array = Class187.smethod_1(byte_3);
						}
					}
				}
				if (num8 == 3)
				{
					byte[] byte_4 = new byte[]
					{
						1,
						1,
						1,
						1,
						1,
						1,
						1,
						1,
						1,
						1,
						1,
						1,
						1,
						1,
						1,
						1
					};
					byte[] byte_5 = new byte[]
					{
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2
					};
					using (Class185 class4 = new Class185())
					{
						using (ICryptoTransform cryptoTransform2 = class4.method_0(byte_4, byte_5, true))
						{
							byte[] byte_6 = cryptoTransform2.TransformFinalBlock(byte_0, 4, byte_0.Length - 4);
							array = Class187.smethod_1(byte_6);
						}
					}
				}
				IL_2A2:
				stream.Close();
				stream = null;
				result = array;
			}
			return result;
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x000C0AB8 File Offset: 0x000BECB8
		public static byte[] smethod_2(byte[] byte_0)
		{
			return Class187.smethod_5(byte_0, 1, null, null);
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x000C0AD4 File Offset: 0x000BECD4
		public static byte[] smethod_3(byte[] byte_0, byte[] byte_1, byte[] byte_2)
		{
			return Class187.smethod_5(byte_0, 2, byte_1, byte_2);
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x000C0AF0 File Offset: 0x000BECF0
		public static byte[] smethod_4(byte[] byte_0, byte[] byte_1, byte[] byte_2)
		{
			return Class187.smethod_5(byte_0, 3, byte_1, byte_2);
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x000C0B0C File Offset: 0x000BED0C
		private static byte[] smethod_5(byte[] byte_0, int int_0, byte[] byte_1, byte[] byte_2)
		{
			byte[] result;
			try
			{
				Class187.Stream0 stream = new Class187.Stream0();
				if (int_0 == 0)
				{
					Class187.Class193 @class = new Class187.Class193();
					DateTime now = DateTime.Now;
					long num = (long)((ulong)((now.Year - 1980 & 127) << 25 | now.Month << 21 | now.Day << 16 | now.Hour << 11 | now.Minute << 5 | (int)((uint)now.Second >> 1)));
					uint[] array = new uint[]
					{
						0U,
						1996959894U,
						3993919788U,
						2567524794U,
						124634137U,
						1886057615U,
						3915621685U,
						2657392035U,
						249268274U,
						2044508324U,
						3772115230U,
						2547177864U,
						162941995U,
						2125561021U,
						3887607047U,
						2428444049U,
						498536548U,
						1789927666U,
						4089016648U,
						2227061214U,
						450548861U,
						1843258603U,
						4107580753U,
						2211677639U,
						325883990U,
						1684777152U,
						4251122042U,
						2321926636U,
						335633487U,
						1661365465U,
						4195302755U,
						2366115317U,
						997073096U,
						1281953886U,
						3579855332U,
						2724688242U,
						1006888145U,
						1258607687U,
						3524101629U,
						2768942443U,
						901097722U,
						1119000684U,
						3686517206U,
						2898065728U,
						853044451U,
						1172266101U,
						3705015759U,
						2882616665U,
						651767980U,
						1373503546U,
						3369554304U,
						3218104598U,
						565507253U,
						1454621731U,
						3485111705U,
						3099436303U,
						671266974U,
						1594198024U,
						3322730930U,
						2970347812U,
						795835527U,
						1483230225U,
						3244367275U,
						3060149565U,
						1994146192U,
						31158534U,
						2563907772U,
						4023717930U,
						1907459465U,
						112637215U,
						2680153253U,
						3904427059U,
						2013776290U,
						251722036U,
						2517215374U,
						3775830040U,
						2137656763U,
						141376813U,
						2439277719U,
						3865271297U,
						1802195444U,
						476864866U,
						2238001368U,
						4066508878U,
						1812370925U,
						453092731U,
						2181625025U,
						4111451223U,
						1706088902U,
						314042704U,
						2344532202U,
						4240017532U,
						1658658271U,
						366619977U,
						2362670323U,
						4224994405U,
						1303535960U,
						984961486U,
						2747007092U,
						3569037538U,
						1256170817U,
						1037604311U,
						2765210733U,
						3554079995U,
						1131014506U,
						879679996U,
						2909243462U,
						3663771856U,
						1141124467U,
						855842277U,
						2852801631U,
						3708648649U,
						1342533948U,
						654459306U,
						3188396048U,
						3373015174U,
						1466479909U,
						544179635U,
						3110523913U,
						3462522015U,
						1591671054U,
						702138776U,
						2966460450U,
						3352799412U,
						1504918807U,
						783551873U,
						3082640443U,
						3233442989U,
						3988292384U,
						2596254646U,
						62317068U,
						1957810842U,
						3939845945U,
						2647816111U,
						81470997U,
						1943803523U,
						3814918930U,
						2489596804U,
						225274430U,
						2053790376U,
						3826175755U,
						2466906013U,
						167816743U,
						2097651377U,
						4027552580U,
						2265490386U,
						503444072U,
						1762050814U,
						4150417245U,
						2154129355U,
						426522225U,
						1852507879U,
						4275313526U,
						2312317920U,
						282753626U,
						1742555852U,
						4189708143U,
						2394877945U,
						397917763U,
						1622183637U,
						3604390888U,
						2714866558U,
						953729732U,
						1340076626U,
						3518719985U,
						2797360999U,
						1068828381U,
						1219638859U,
						3624741850U,
						2936675148U,
						906185462U,
						1090812512U,
						3747672003U,
						2825379669U,
						829329135U,
						1181335161U,
						3412177804U,
						3160834842U,
						628085408U,
						1382605366U,
						3423369109U,
						3138078467U,
						570562233U,
						1426400815U,
						3317316542U,
						2998733608U,
						733239954U,
						1555261956U,
						3268935591U,
						3050360625U,
						752459403U,
						1541320221U,
						2607071920U,
						3965973030U,
						1969922972U,
						40735498U,
						2617837225U,
						3943577151U,
						1913087877U,
						83908371U,
						2512341634U,
						3803740692U,
						2075208622U,
						213261112U,
						2463272603U,
						3855990285U,
						2094854071U,
						198958881U,
						2262029012U,
						4057260610U,
						1759359992U,
						534414190U,
						2176718541U,
						4139329115U,
						1873836001U,
						414664567U,
						2282248934U,
						4279200368U,
						1711684554U,
						285281116U,
						2405801727U,
						4167216745U,
						1634467795U,
						376229701U,
						2685067896U,
						3608007406U,
						1308918612U,
						956543938U,
						2808555105U,
						3495958263U,
						1231636301U,
						1047427035U,
						2932959818U,
						3654703836U,
						1088359270U,
						936918000U,
						2847714899U,
						3736837829U,
						1202900863U,
						817233897U,
						3183342108U,
						3401237130U,
						1404277552U,
						615818150U,
						3134207493U,
						3453421203U,
						1423857449U,
						601450431U,
						3009837614U,
						3294710456U,
						1567103746U,
						711928724U,
						3020668471U,
						3272380065U,
						1510334235U,
						755167117U
					};
					uint maxValue = uint.MaxValue;
					uint num2 = uint.MaxValue;
					int num3 = 0;
					int num4 = byte_0.Length;
					while (--num4 >= 0)
					{
						num2 = (array[(int)((UIntPtr)((num2 ^ (uint)byte_0[num3++]) & 255U))] ^ num2 >> 8);
					}
					num2 ^= maxValue;
					stream.method_1(67324752);
					stream.method_0(20);
					stream.method_0(0);
					stream.method_0(8);
					stream.method_1((int)num);
					stream.method_1((int)num2);
					long position = stream.Position;
					stream.method_1(0);
					stream.method_1(byte_0.Length);
					byte[] bytes = Encoding.UTF8.GetBytes("{data}");
					stream.method_0(bytes.Length);
					stream.method_0(0);
					stream.Write(bytes, 0, bytes.Length);
					@class.method_1(byte_0);
					while (!@class.IsNeedingInput)
					{
						byte[] array2 = new byte[512];
						int num5 = @class.method_2(array2);
						if (num5 <= 0)
						{
							break;
						}
						stream.Write(array2, 0, num5);
					}
					@class.method_0();
					while (!@class.IsFinished)
					{
						byte[] array3 = new byte[512];
						int num6 = @class.method_2(array3);
						if (num6 <= 0)
						{
							break;
						}
						stream.Write(array3, 0, num6);
					}
					long totalOut = @class.TotalOut;
					stream.method_1(33639248);
					stream.method_0(20);
					stream.method_0(20);
					stream.method_0(0);
					stream.method_0(8);
					stream.method_1((int)num);
					stream.method_1((int)num2);
					stream.method_1((int)totalOut);
					stream.method_1(byte_0.Length);
					stream.method_0(bytes.Length);
					stream.method_0(0);
					stream.method_0(0);
					stream.method_0(0);
					stream.method_0(0);
					stream.method_1(0);
					stream.method_1(0);
					stream.Write(bytes, 0, bytes.Length);
					stream.method_1(101010256);
					stream.method_0(0);
					stream.method_0(0);
					stream.method_0(1);
					stream.method_0(1);
					stream.method_1(46 + bytes.Length);
					stream.method_1((int)((long)(30 + bytes.Length) + totalOut));
					stream.method_0(0);
					stream.Seek(position, SeekOrigin.Begin);
					stream.method_1((int)totalOut);
				}
				else if (int_0 == 1)
				{
					stream.method_1(25000571);
					stream.method_1(byte_0.Length);
					byte[] array4;
					for (int i = 0; i < byte_0.Length; i += array4.Length)
					{
						array4 = new byte[Math.Min(2097151, byte_0.Length - i)];
						Buffer.BlockCopy(byte_0, i, array4, 0, array4.Length);
						long position2 = stream.Position;
						stream.method_1(0);
						stream.method_1(array4.Length);
						Class187.Class193 class2 = new Class187.Class193();
						class2.method_1(array4);
						while (!class2.IsNeedingInput)
						{
							byte[] array5 = new byte[512];
							int num7 = class2.method_2(array5);
							if (num7 <= 0)
							{
								break;
							}
							stream.Write(array5, 0, num7);
						}
						class2.method_0();
						while (!class2.IsFinished)
						{
							byte[] array6 = new byte[512];
							int num8 = class2.method_2(array6);
							if (num8 <= 0)
							{
								break;
							}
							stream.Write(array6, 0, num8);
						}
						long position3 = stream.Position;
						stream.Position = position2;
						stream.method_1((int)class2.TotalOut);
						stream.Position = position3;
					}
				}
				else
				{
					if (int_0 == 2)
					{
						stream.method_1(41777787);
						byte[] array7 = Class187.smethod_5(byte_0, 1, null, null);
						using (Class186 class3 = new Class186())
						{
							using (ICryptoTransform cryptoTransform = class3.method_0(byte_1, byte_2, false))
							{
								byte[] array8 = cryptoTransform.TransformFinalBlock(array7, 0, array7.Length);
								stream.Write(array8, 0, array8.Length);
							}
							goto IL_47C;
						}
					}
					if (int_0 == 3)
					{
						stream.method_1(58555003);
						byte[] array9 = Class187.smethod_5(byte_0, 1, null, null);
						using (Class185 class4 = new Class185())
						{
							using (ICryptoTransform cryptoTransform2 = class4.method_0(byte_1, byte_2, false))
							{
								byte[] array10 = cryptoTransform2.TransformFinalBlock(array9, 0, array9.Length);
								stream.Write(array10, 0, array10.Length);
							}
						}
					}
				}
				IL_47C:
				stream.Flush();
				stream.Close();
				result = stream.ToArray();
			}
			catch (Exception ex)
			{
				Class187.string_0 = "ERR 2003: " + ex.Message;
				throw;
			}
			return result;
		}

		// Token: 0x04000CB0 RID: 3248
		public static string string_0;

		// Token: 0x020001A5 RID: 421
		internal sealed class Class188
		{
			// Token: 0x06001262 RID: 4706 RVA: 0x00009AB6 File Offset: 0x00007CB6
			public Class188(byte[] bytes)
			{
				this.class189_0 = new Class187.Class189();
				this.class190_0 = new Class187.Class190();
				this.int_17 = 2;
				this.class189_0.method_5(bytes, 0, bytes.Length);
			}

			// Token: 0x06001263 RID: 4707 RVA: 0x000C104C File Offset: 0x000BF24C
			private bool method_0()
			{
				int i = this.class190_0.method_5();
				while (i >= 258)
				{
					int num;
					switch (this.int_17)
					{
					case 7:
						while (((num = this.class191_0.method_1(this.class189_0)) & -256) == 0)
						{
							this.class190_0.method_0(num);
							if (--i < 258)
							{
								return true;
							}
						}
						if (num >= 257)
						{
							this.int_19 = Class187.Class188.int_13[num - 257];
							this.int_18 = Class187.Class188.int_14[num - 257];
							goto IL_9E;
						}
						if (num < 0)
						{
							return false;
						}
						this.class191_1 = null;
						this.class191_0 = null;
						this.int_17 = 2;
						return true;
					case 8:
						goto IL_9E;
					case 9:
						goto IL_EE;
					case 10:
						break;
					default:
						continue;
					}
					IL_121:
					if (this.int_18 > 0)
					{
						this.int_17 = 10;
						int num2 = this.class189_0.method_0(this.int_18);
						if (num2 < 0)
						{
							return false;
						}
						this.class189_0.method_1(this.int_18);
						this.int_20 += num2;
					}
					this.class190_0.method_2(this.int_19, this.int_20);
					i -= this.int_19;
					this.int_17 = 7;
					continue;
					IL_EE:
					num = this.class191_1.method_1(this.class189_0);
					if (num >= 0)
					{
						this.int_20 = Class187.Class188.int_15[num];
						this.int_18 = Class187.Class188.int_16[num];
						goto IL_121;
					}
					return false;
					IL_9E:
					if (this.int_18 > 0)
					{
						this.int_17 = 8;
						int num3 = this.class189_0.method_0(this.int_18);
						if (num3 < 0)
						{
							return false;
						}
						this.class189_0.method_1(this.int_18);
						this.int_19 += num3;
					}
					this.int_17 = 9;
					goto IL_EE;
				}
				return true;
			}

			// Token: 0x06001264 RID: 4708 RVA: 0x000C1234 File Offset: 0x000BF434
			private bool method_1()
			{
				switch (this.int_17)
				{
				case 2:
				{
					if (this.bool_0)
					{
						this.int_17 = 12;
						return false;
					}
					int num = this.class189_0.method_0(3);
					if (num < 0)
					{
						return false;
					}
					this.class189_0.method_1(3);
					if ((num & 1) != 0)
					{
						this.bool_0 = true;
					}
					switch (num >> 1)
					{
					case 0:
						this.class189_0.method_2();
						this.int_17 = 3;
						break;
					case 1:
						this.class191_0 = Class187.Class191.class191_0;
						this.class191_1 = Class187.Class191.class191_1;
						this.int_17 = 7;
						break;
					case 2:
						this.class192_0 = new Class187.Class192();
						this.int_17 = 6;
						break;
					}
					return true;
				}
				case 3:
					if ((this.int_21 = this.class189_0.method_0(16)) < 0)
					{
						return false;
					}
					this.class189_0.method_1(16);
					this.int_17 = 4;
					break;
				case 4:
					break;
				case 5:
					goto IL_151;
				case 6:
					if (!this.class192_0.method_0(this.class189_0))
					{
						return false;
					}
					this.class191_0 = this.class192_0.method_1();
					this.class191_1 = this.class192_0.method_2();
					this.int_17 = 7;
					goto IL_1DE;
				case 7:
				case 8:
				case 9:
				case 10:
					goto IL_1DE;
				case 11:
					goto IL_1E8;
				case 12:
					return false;
				default:
					goto IL_1E8;
				}
				int num2 = this.class189_0.method_0(16);
				if (num2 < 0)
				{
					return false;
				}
				this.class189_0.method_1(16);
				this.int_17 = 5;
				IL_151:
				int num3 = this.class190_0.method_3(this.class189_0, this.int_21);
				this.int_21 -= num3;
				if (this.int_21 == 0)
				{
					this.int_17 = 2;
					return true;
				}
				return !this.class189_0.IsNeedingInput;
				IL_1DE:
				return this.method_0();
				IL_1E8:
				return false;
			}

			// Token: 0x06001265 RID: 4709 RVA: 0x000C1438 File Offset: 0x000BF638
			public int method_2(byte[] byte_0, int int_22, int int_23)
			{
				int num = 0;
				for (;;)
				{
					if (this.int_17 != 11)
					{
						int num2 = this.class190_0.method_7(byte_0, int_22, int_23);
						int_22 += num2;
						num += num2;
						int_23 -= num2;
						if (int_23 == 0)
						{
							goto Block_4;
						}
					}
					if (!this.method_1())
					{
						if (this.class190_0.method_6() <= 0)
						{
							break;
						}
						if (this.int_17 == 11)
						{
							break;
						}
					}
				}
				goto IL_58;
				Block_4:
				return num;
				IL_58:
				return num;
			}

			// Token: 0x04000CB1 RID: 3249
			private const int int_0 = 0;

			// Token: 0x04000CB2 RID: 3250
			private const int int_1 = 1;

			// Token: 0x04000CB3 RID: 3251
			private const int int_2 = 2;

			// Token: 0x04000CB4 RID: 3252
			private const int int_3 = 3;

			// Token: 0x04000CB5 RID: 3253
			private const int int_4 = 4;

			// Token: 0x04000CB6 RID: 3254
			private const int int_5 = 5;

			// Token: 0x04000CB7 RID: 3255
			private const int int_6 = 6;

			// Token: 0x04000CB8 RID: 3256
			private const int int_7 = 7;

			// Token: 0x04000CB9 RID: 3257
			private const int int_8 = 8;

			// Token: 0x04000CBA RID: 3258
			private const int int_9 = 9;

			// Token: 0x04000CBB RID: 3259
			private const int int_10 = 10;

			// Token: 0x04000CBC RID: 3260
			private const int int_11 = 11;

			// Token: 0x04000CBD RID: 3261
			private const int int_12 = 12;

			// Token: 0x04000CBE RID: 3262
			private static readonly int[] int_13 = new int[]
			{
				3,
				4,
				5,
				6,
				7,
				8,
				9,
				10,
				11,
				13,
				15,
				17,
				19,
				23,
				27,
				31,
				35,
				43,
				51,
				59,
				67,
				83,
				99,
				115,
				131,
				163,
				195,
				227,
				258
			};

			// Token: 0x04000CBF RID: 3263
			private static readonly int[] int_14 = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3,
				4,
				4,
				4,
				4,
				5,
				5,
				5,
				5,
				0
			};

			// Token: 0x04000CC0 RID: 3264
			private static readonly int[] int_15 = new int[]
			{
				1,
				2,
				3,
				4,
				5,
				7,
				9,
				13,
				17,
				25,
				33,
				49,
				65,
				97,
				129,
				193,
				257,
				385,
				513,
				769,
				1025,
				1537,
				2049,
				3073,
				4097,
				6145,
				8193,
				12289,
				16385,
				24577
			};

			// Token: 0x04000CC1 RID: 3265
			private static readonly int[] int_16 = new int[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				2,
				2,
				3,
				3,
				4,
				4,
				5,
				5,
				6,
				6,
				7,
				7,
				8,
				8,
				9,
				9,
				10,
				10,
				11,
				11,
				12,
				12,
				13,
				13
			};

			// Token: 0x04000CC2 RID: 3266
			private int int_17;

			// Token: 0x04000CC3 RID: 3267
			private int int_18;

			// Token: 0x04000CC4 RID: 3268
			private int int_19;

			// Token: 0x04000CC5 RID: 3269
			private int int_20;

			// Token: 0x04000CC6 RID: 3270
			private int int_21;

			// Token: 0x04000CC7 RID: 3271
			private bool bool_0;

			// Token: 0x04000CC8 RID: 3272
			private Class187.Class189 class189_0;

			// Token: 0x04000CC9 RID: 3273
			private Class187.Class190 class190_0;

			// Token: 0x04000CCA RID: 3274
			private Class187.Class192 class192_0;

			// Token: 0x04000CCB RID: 3275
			private Class187.Class191 class191_0;

			// Token: 0x04000CCC RID: 3276
			private Class187.Class191 class191_1;
		}

		// Token: 0x020001A6 RID: 422
		internal sealed class Class189
		{
			// Token: 0x06001267 RID: 4711 RVA: 0x000C1510 File Offset: 0x000BF710
			public int method_0(int int_3)
			{
				if (this.int_2 < int_3)
				{
					if (this.int_0 == this.int_1)
					{
						return -1;
					}
					this.uint_0 |= (uint)((uint)((int)(this.byte_0[this.int_0++] & byte.MaxValue) | (int)(this.byte_0[this.int_0++] & byte.MaxValue) << 8) << this.int_2);
					this.int_2 += 16;
				}
				return (int)((ulong)this.uint_0 & (ulong)((long)((1 << int_3) - 1)));
			}

			// Token: 0x06001268 RID: 4712 RVA: 0x00009AED File Offset: 0x00007CED
			public void method_1(int int_3)
			{
				this.uint_0 >>= int_3;
				this.int_2 -= int_3;
			}

			// Token: 0x17000409 RID: 1033
			// (get) Token: 0x06001269 RID: 4713 RVA: 0x000C15B4 File Offset: 0x000BF7B4
			public int AvailableBits
			{
				get
				{
					return this.int_2;
				}
			}

			// Token: 0x1700040A RID: 1034
			// (get) Token: 0x0600126A RID: 4714 RVA: 0x000C15CC File Offset: 0x000BF7CC
			public int AvailableBytes
			{
				get
				{
					return this.int_1 - this.int_0 + (this.int_2 >> 3);
				}
			}

			// Token: 0x0600126B RID: 4715 RVA: 0x00009B10 File Offset: 0x00007D10
			public void method_2()
			{
				this.uint_0 >>= (this.int_2 & 7);
				this.int_2 &= -8;
			}

			// Token: 0x1700040B RID: 1035
			// (get) Token: 0x0600126C RID: 4716 RVA: 0x000C15F4 File Offset: 0x000BF7F4
			public bool IsNeedingInput
			{
				get
				{
					return this.int_0 == this.int_1;
				}
			}

			// Token: 0x0600126D RID: 4717 RVA: 0x000C1614 File Offset: 0x000BF814
			public int method_3(byte[] byte_1, int int_3, int int_4)
			{
				int num = 0;
				while (this.int_2 > 0 && int_4 > 0)
				{
					byte_1[int_3++] = (byte)this.uint_0;
					this.uint_0 >>= 8;
					this.int_2 -= 8;
					int_4--;
					num++;
				}
				int result;
				if (int_4 == 0)
				{
					result = num;
				}
				else
				{
					int num2 = this.int_1 - this.int_0;
					if (int_4 > num2)
					{
						int_4 = num2;
					}
					Array.Copy(this.byte_0, this.int_0, byte_1, int_3, int_4);
					this.int_0 += int_4;
					if ((this.int_0 - this.int_1 & 1) != 0)
					{
						this.uint_0 = (uint)(this.byte_0[this.int_0++] & byte.MaxValue);
						this.int_2 = 8;
					}
					result = num + int_4;
				}
				return result;
			}

			// Token: 0x0600126F RID: 4719 RVA: 0x000C16E8 File Offset: 0x000BF8E8
			public void method_4()
			{
				this.int_2 = 0;
				this.int_1 = 0;
				this.int_0 = 0;
				this.uint_0 = 0U;
			}

			// Token: 0x06001270 RID: 4720 RVA: 0x000C171C File Offset: 0x000BF91C
			public void method_5(byte[] byte_1, int int_3, int int_4)
			{
				if (this.int_0 < this.int_1)
				{
					throw new InvalidOperationException();
				}
				int num = int_3 + int_4;
				if (0 <= int_3 && int_3 <= num && num <= byte_1.Length)
				{
					if ((int_4 & 1) != 0)
					{
						this.uint_0 |= (uint)((uint)(byte_1[int_3++] & byte.MaxValue) << this.int_2);
						this.int_2 += 8;
					}
					this.byte_0 = byte_1;
					this.int_0 = int_3;
					this.int_1 = num;
					return;
				}
				throw new ArgumentOutOfRangeException();
			}

			// Token: 0x04000CCD RID: 3277
			private byte[] byte_0;

			// Token: 0x04000CCE RID: 3278
			private int int_0 = 0;

			// Token: 0x04000CCF RID: 3279
			private int int_1 = 0;

			// Token: 0x04000CD0 RID: 3280
			private uint uint_0 = 0U;

			// Token: 0x04000CD1 RID: 3281
			private int int_2 = 0;
		}

		// Token: 0x020001A7 RID: 423
		internal sealed class Class190
		{
			// Token: 0x06001271 RID: 4721 RVA: 0x000C17A4 File Offset: 0x000BF9A4
			public void method_0(int int_4)
			{
				if (this.int_3++ == 32768)
				{
					throw new InvalidOperationException();
				}
				this.byte_0[this.int_2++] = (byte)int_4;
				this.int_2 &= 32767;
			}

			// Token: 0x06001272 RID: 4722 RVA: 0x000C1800 File Offset: 0x000BFA00
			private void method_1(int int_4, int int_5, int int_6)
			{
				while (int_5-- > 0)
				{
					this.byte_0[this.int_2++] = this.byte_0[int_4++];
					this.int_2 &= 32767;
					int_4 &= 32767;
				}
			}

			// Token: 0x06001273 RID: 4723 RVA: 0x000C185C File Offset: 0x000BFA5C
			public void method_2(int int_4, int int_5)
			{
				if ((this.int_3 += int_4) > 32768)
				{
					throw new InvalidOperationException();
				}
				int num = this.int_2 - int_5 & 32767;
				int num2 = 32768 - int_4;
				if (num <= num2 && this.int_2 < num2)
				{
					if (int_4 <= int_5)
					{
						Array.Copy(this.byte_0, num, this.byte_0, this.int_2, int_4);
						this.int_2 += int_4;
					}
					else
					{
						while (int_4-- > 0)
						{
							this.byte_0[this.int_2++] = this.byte_0[num++];
						}
					}
				}
				else
				{
					this.method_1(num, int_4, int_5);
				}
			}

			// Token: 0x06001274 RID: 4724 RVA: 0x000C1914 File Offset: 0x000BFB14
			public int method_3(Class187.Class189 class189_0, int int_4)
			{
				int_4 = Math.Min(Math.Min(int_4, 32768 - this.int_3), class189_0.AvailableBytes);
				int num = 32768 - this.int_2;
				int num2;
				if (int_4 > num)
				{
					num2 = class189_0.method_3(this.byte_0, this.int_2, num);
					if (num2 == num)
					{
						num2 += class189_0.method_3(this.byte_0, 0, int_4 - num);
					}
				}
				else
				{
					num2 = class189_0.method_3(this.byte_0, this.int_2, int_4);
				}
				this.int_2 = (this.int_2 + num2 & 32767);
				this.int_3 += num2;
				return num2;
			}

			// Token: 0x06001275 RID: 4725 RVA: 0x000C19BC File Offset: 0x000BFBBC
			public void method_4(byte[] byte_1, int int_4, int int_5)
			{
				if (this.int_3 > 0)
				{
					throw new InvalidOperationException();
				}
				if (int_5 > 32768)
				{
					int_4 += int_5 - 32768;
					int_5 = 32768;
				}
				Array.Copy(byte_1, int_4, this.byte_0, 0, int_5);
				this.int_2 = (int_5 & 32767);
			}

			// Token: 0x06001276 RID: 4726 RVA: 0x000C1A10 File Offset: 0x000BFC10
			public int method_5()
			{
				return 32768 - this.int_3;
			}

			// Token: 0x06001277 RID: 4727 RVA: 0x000C1A30 File Offset: 0x000BFC30
			public int method_6()
			{
				return this.int_3;
			}

			// Token: 0x06001278 RID: 4728 RVA: 0x000C1A48 File Offset: 0x000BFC48
			public int method_7(byte[] byte_1, int int_4, int int_5)
			{
				int num = this.int_2;
				if (int_5 > this.int_3)
				{
					int_5 = this.int_3;
				}
				else
				{
					num = (this.int_2 - this.int_3 + int_5 & 32767);
				}
				int num2 = int_5;
				int num3 = int_5 - num;
				if (num3 > 0)
				{
					Array.Copy(this.byte_0, 32768 - num3, byte_1, int_4, num3);
					int_4 += num3;
					int_5 = num;
				}
				Array.Copy(this.byte_0, num - int_5, byte_1, int_4, int_5);
				this.int_3 -= num2;
				if (this.int_3 < 0)
				{
					throw new InvalidOperationException();
				}
				return num2;
			}

			// Token: 0x06001279 RID: 4729 RVA: 0x000C1AE0 File Offset: 0x000BFCE0
			public void method_8()
			{
				this.int_2 = 0;
				this.int_3 = 0;
			}

			// Token: 0x04000CD2 RID: 3282
			private const int int_0 = 32768;

			// Token: 0x04000CD3 RID: 3283
			private const int int_1 = 32767;

			// Token: 0x04000CD4 RID: 3284
			private byte[] byte_0 = new byte[32768];

			// Token: 0x04000CD5 RID: 3285
			private int int_2 = 0;

			// Token: 0x04000CD6 RID: 3286
			private int int_3 = 0;
		}

		// Token: 0x020001A8 RID: 424
		internal sealed class Class191
		{
			// Token: 0x0600127B RID: 4731 RVA: 0x000C1B00 File Offset: 0x000BFD00
			static Class191()
			{
				byte[] array = new byte[288];
				int i = 0;
				while (i < 144)
				{
					array[i++] = 8;
				}
				while (i < 256)
				{
					array[i++] = 9;
				}
				while (i < 280)
				{
					array[i++] = 7;
				}
				while (i < 288)
				{
					array[i++] = 8;
				}
				Class187.Class191.class191_0 = new Class187.Class191(array);
				array = new byte[32];
				i = 0;
				while (i < 32)
				{
					array[i++] = 5;
				}
				Class187.Class191.class191_1 = new Class187.Class191(array);
			}

			// Token: 0x0600127C RID: 4732 RVA: 0x00009B85 File Offset: 0x00007D85
			public Class191(byte[] codeLengths)
			{
				this.method_0(codeLengths);
			}

			// Token: 0x0600127D RID: 4733 RVA: 0x000C1B94 File Offset: 0x000BFD94
			private void method_0(byte[] byte_0)
			{
				int[] array = new int[16];
				int[] array2 = new int[16];
				foreach (int num in byte_0)
				{
					if (num > 0)
					{
						int[] array3;
						IntPtr intPtr;
						(array3 = array)[(int)(intPtr = (IntPtr)num)] = array3[(int)intPtr] + 1;
					}
				}
				int num2 = 0;
				int num3 = 512;
				for (int j = 1; j <= 15; j++)
				{
					array2[j] = num2;
					num2 += array[j] << 16 - j;
					if (j >= 10)
					{
						int num4 = array2[j] & 130944;
						int num5 = num2 & 130944;
						num3 += num5 - num4 >> 16 - j;
					}
				}
				this.short_0 = new short[num3];
				int num6 = 512;
				for (int k = 15; k >= 10; k--)
				{
					int num7 = num2 & 130944;
					num2 -= array[k] << 16 - k;
					int num8 = num2 & 130944;
					for (int l = num8; l < num7; l += 128)
					{
						this.short_0[(int)Class187.Class194.smethod_0(l)] = (short)(-num6 << 4 | k);
						num6 += 1 << k - 9;
					}
				}
				for (int m = 0; m < byte_0.Length; m++)
				{
					int num9 = (int)byte_0[m];
					if (num9 != 0)
					{
						num2 = array2[num9];
						int num10 = (int)Class187.Class194.smethod_0(num2);
						if (num9 <= 9)
						{
							do
							{
								this.short_0[num10] = (short)(m << 4 | num9);
								num10 += 1 << num9;
							}
							while (num10 < 512);
						}
						else
						{
							int num11 = (int)this.short_0[num10 & 511];
							int num12 = 1 << (num11 & 15);
							num11 = -(num11 >> 4);
							do
							{
								this.short_0[num11 | num10 >> 9] = (short)(m << 4 | num9);
								num10 += 1 << num9;
							}
							while (num10 < num12);
						}
						array2[num9] = num2 + (1 << 16 - num9);
					}
				}
			}

			// Token: 0x0600127E RID: 4734 RVA: 0x000C1D84 File Offset: 0x000BFF84
			public int method_1(Class187.Class189 class189_0)
			{
				int num;
				int result;
				if ((num = class189_0.method_0(9)) >= 0)
				{
					int num2;
					if ((num2 = (int)this.short_0[num]) >= 0)
					{
						class189_0.method_1(num2 & 15);
						result = num2 >> 4;
					}
					else
					{
						int num3 = -(num2 >> 4);
						int int_ = num2 & 15;
						if ((num = class189_0.method_0(int_)) >= 0)
						{
							num2 = (int)this.short_0[num3 | num >> 9];
							class189_0.method_1(num2 & 15);
							result = num2 >> 4;
						}
						else
						{
							int availableBits = class189_0.AvailableBits;
							num = class189_0.method_0(availableBits);
							num2 = (int)this.short_0[num3 | num >> 9];
							if ((num2 & 15) <= availableBits)
							{
								class189_0.method_1(num2 & 15);
								result = num2 >> 4;
							}
							else
							{
								result = -1;
							}
						}
					}
				}
				else
				{
					int availableBits2 = class189_0.AvailableBits;
					num = class189_0.method_0(availableBits2);
					int num2 = (int)this.short_0[num];
					if (num2 >= 0 && (num2 & 15) <= availableBits2)
					{
						class189_0.method_1(num2 & 15);
						result = num2 >> 4;
					}
					else
					{
						result = -1;
					}
				}
				return result;
			}

			// Token: 0x04000CD7 RID: 3287
			private const int int_0 = 15;

			// Token: 0x04000CD8 RID: 3288
			private short[] short_0;

			// Token: 0x04000CD9 RID: 3289
			public static readonly Class187.Class191 class191_0;

			// Token: 0x04000CDA RID: 3290
			public static readonly Class187.Class191 class191_1;
		}

		// Token: 0x020001A9 RID: 425
		internal sealed class Class192
		{
			// Token: 0x06001280 RID: 4736 RVA: 0x000C1E74 File Offset: 0x000C0074
			public bool method_0(Class187.Class189 class189_0)
			{
				for (;;)
				{
					switch (this.int_8)
					{
					case 0:
						this.int_9 = class189_0.method_0(5);
						if (this.int_9 >= 0)
						{
							this.int_9 += 257;
							class189_0.method_1(5);
							this.int_8 = 1;
							goto IL_1DD;
						}
						goto IL_27C;
					case 1:
						goto IL_1DD;
					case 2:
						goto IL_18F;
					case 3:
						goto IL_156;
					case 4:
						break;
					case 5:
						goto IL_2C;
					default:
						continue;
					}
					IL_E1:
					int num;
					while (((num = this.class191_0.method_1(class189_0)) & -16) == 0)
					{
						this.byte_1[this.int_14++] = (this.byte_2 = (byte)num);
						if (this.int_14 == this.int_12)
						{
							goto Block_4;
						}
					}
					if (num >= 0)
					{
						if (num >= 17)
						{
							this.byte_2 = 0;
						}
						this.int_13 = num - 16;
						this.int_8 = 5;
						goto IL_2C;
					}
					goto IL_290;
					IL_156:
					while (this.int_14 < this.int_11)
					{
						int num2 = class189_0.method_0(3);
						if (num2 < 0)
						{
							goto IL_28B;
						}
						class189_0.method_1(3);
						this.byte_0[Class187.Class192.int_15[this.int_14]] = (byte)num2;
						this.int_14++;
					}
					this.class191_0 = new Class187.Class191(this.byte_0);
					this.byte_0 = null;
					this.int_14 = 0;
					this.int_8 = 4;
					goto IL_E1;
					IL_2C:
					int num3 = Class187.Class192.int_7[this.int_13];
					int num4 = class189_0.method_0(num3);
					if (num4 < 0)
					{
						goto IL_29A;
					}
					class189_0.method_1(num3);
					num4 += Class187.Class192.int_6[this.int_13];
					while (num4-- > 0)
					{
						this.byte_1[this.int_14++] = this.byte_2;
					}
					if (this.int_14 == this.int_12)
					{
						break;
					}
					this.int_8 = 4;
					continue;
					IL_18F:
					this.int_11 = class189_0.method_0(4);
					if (this.int_11 >= 0)
					{
						this.int_11 += 4;
						class189_0.method_1(4);
						this.byte_0 = new byte[19];
						this.int_14 = 0;
						this.int_8 = 3;
						goto IL_156;
					}
					goto IL_286;
					IL_1DD:
					this.int_10 = class189_0.method_0(5);
					if (this.int_10 >= 0)
					{
						this.int_10++;
						class189_0.method_1(5);
						this.int_12 = this.int_9 + this.int_10;
						this.byte_1 = new byte[this.int_12];
						this.int_8 = 2;
						goto IL_18F;
					}
					goto IL_281;
				}
				return true;
				Block_4:
				return true;
				IL_27C:
				return false;
				IL_281:
				return false;
				IL_286:
				return false;
				IL_28B:
				return false;
				IL_290:
				return false;
				IL_29A:
				return false;
			}

			// Token: 0x06001281 RID: 4737 RVA: 0x000C2128 File Offset: 0x000C0328
			public Class187.Class191 method_1()
			{
				byte[] array = new byte[this.int_9];
				Array.Copy(this.byte_1, 0, array, 0, this.int_9);
				return new Class187.Class191(array);
			}

			// Token: 0x06001282 RID: 4738 RVA: 0x000C2160 File Offset: 0x000C0360
			public Class187.Class191 method_2()
			{
				byte[] array = new byte[this.int_10];
				Array.Copy(this.byte_1, this.int_9, array, 0, this.int_10);
				return new Class187.Class191(array);
			}

			// Token: 0x04000CDB RID: 3291
			private const int int_0 = 0;

			// Token: 0x04000CDC RID: 3292
			private const int int_1 = 1;

			// Token: 0x04000CDD RID: 3293
			private const int int_2 = 2;

			// Token: 0x04000CDE RID: 3294
			private const int int_3 = 3;

			// Token: 0x04000CDF RID: 3295
			private const int int_4 = 4;

			// Token: 0x04000CE0 RID: 3296
			private const int int_5 = 5;

			// Token: 0x04000CE1 RID: 3297
			private static readonly int[] int_6 = new int[]
			{
				3,
				3,
				11
			};

			// Token: 0x04000CE2 RID: 3298
			private static readonly int[] int_7 = new int[]
			{
				2,
				3,
				7
			};

			// Token: 0x04000CE3 RID: 3299
			private byte[] byte_0;

			// Token: 0x04000CE4 RID: 3300
			private byte[] byte_1;

			// Token: 0x04000CE5 RID: 3301
			private Class187.Class191 class191_0;

			// Token: 0x04000CE6 RID: 3302
			private int int_8;

			// Token: 0x04000CE7 RID: 3303
			private int int_9;

			// Token: 0x04000CE8 RID: 3304
			private int int_10;

			// Token: 0x04000CE9 RID: 3305
			private int int_11;

			// Token: 0x04000CEA RID: 3306
			private int int_12;

			// Token: 0x04000CEB RID: 3307
			private int int_13;

			// Token: 0x04000CEC RID: 3308
			private byte byte_2;

			// Token: 0x04000CED RID: 3309
			private int int_14;

			// Token: 0x04000CEE RID: 3310
			private static readonly int[] int_15 = new int[]
			{
				16,
				17,
				18,
				0,
				8,
				7,
				9,
				6,
				10,
				5,
				11,
				4,
				12,
				3,
				13,
				2,
				14,
				1,
				15
			};
		}

		// Token: 0x020001AA RID: 426
		internal sealed class Class193
		{
			// Token: 0x06001284 RID: 4740 RVA: 0x00009B96 File Offset: 0x00007D96
			public Class193()
			{
				this.class197_0 = new Class187.Class197();
				this.class196_0 = new Class187.Class196(this.class197_0);
			}

			// Token: 0x1700040C RID: 1036
			// (get) Token: 0x06001285 RID: 4741 RVA: 0x000C21F0 File Offset: 0x000C03F0
			public long TotalOut
			{
				get
				{
					return this.long_0;
				}
			}

			// Token: 0x06001286 RID: 4742 RVA: 0x00009BD3 File Offset: 0x00007DD3
			public void method_0()
			{
				this.int_6 |= 12;
			}

			// Token: 0x1700040D RID: 1037
			// (get) Token: 0x06001287 RID: 4743 RVA: 0x000C2208 File Offset: 0x000C0408
			public bool IsFinished
			{
				get
				{
					bool result;
					if (this.int_6 == 30)
					{
						result = this.class197_0.IsFlushed;
					}
					else
					{
						result = false;
					}
					return result;
				}
			}

			// Token: 0x1700040E RID: 1038
			// (get) Token: 0x06001288 RID: 4744 RVA: 0x000C2234 File Offset: 0x000C0434
			public bool IsNeedingInput
			{
				get
				{
					return this.class196_0.method_8();
				}
			}

			// Token: 0x06001289 RID: 4745 RVA: 0x00009BE6 File Offset: 0x00007DE6
			public void method_1(byte[] byte_0)
			{
				this.class196_0.method_7(byte_0);
			}

			// Token: 0x0600128A RID: 4746 RVA: 0x000C2250 File Offset: 0x000C0450
			public int method_2(byte[] byte_0)
			{
				int num = 0;
				int num2 = byte_0.Length;
				int num3 = num2;
				for (;;)
				{
					int num4 = this.class197_0.method_4(byte_0, num, num2);
					num += num4;
					this.long_0 += (long)num4;
					num2 -= num4;
					if (num2 == 0 || this.int_6 == 30)
					{
						goto IL_E6;
					}
					if (!this.class196_0.method_6((this.int_6 & 4) != 0, (this.int_6 & 8) != 0))
					{
						if (this.int_6 == 16)
						{
							break;
						}
						if (this.int_6 == 20)
						{
							for (int i = 8 + (-this.class197_0.BitCount & 7); i > 0; i -= 10)
							{
								this.class197_0.method_3(2, 10);
							}
							this.int_6 = 16;
						}
						else if (this.int_6 == 28)
						{
							this.class197_0.method_2();
							this.int_6 = 30;
						}
					}
				}
				return num3 - num2;
				IL_E6:
				return num3 - num2;
			}

			// Token: 0x04000CEF RID: 3311
			private const int int_0 = 4;

			// Token: 0x04000CF0 RID: 3312
			private const int int_1 = 8;

			// Token: 0x04000CF1 RID: 3313
			private const int int_2 = 16;

			// Token: 0x04000CF2 RID: 3314
			private const int int_3 = 20;

			// Token: 0x04000CF3 RID: 3315
			private const int int_4 = 28;

			// Token: 0x04000CF4 RID: 3316
			private const int int_5 = 30;

			// Token: 0x04000CF5 RID: 3317
			private int int_6 = 16;

			// Token: 0x04000CF6 RID: 3318
			private long long_0 = 0L;

			// Token: 0x04000CF7 RID: 3319
			private Class187.Class197 class197_0;

			// Token: 0x04000CF8 RID: 3320
			private Class187.Class196 class196_0;
		}

		// Token: 0x020001AB RID: 427
		internal sealed class Class194
		{
			// Token: 0x0600128B RID: 4747 RVA: 0x000C234C File Offset: 0x000C054C
			public static short smethod_0(int int_11)
			{
				return (short)((int)Class187.Class194.byte_0[int_11 & 15] << 12 | (int)Class187.Class194.byte_0[int_11 >> 4 & 15] << 8 | (int)Class187.Class194.byte_0[int_11 >> 8 & 15] << 4 | (int)Class187.Class194.byte_0[int_11 >> 12]);
			}

			// Token: 0x0600128C RID: 4748 RVA: 0x000C2394 File Offset: 0x000C0594
			static Class194()
			{
				int i = 0;
				while (i < 144)
				{
					Class187.Class194.short_1[i] = Class187.Class194.smethod_0(48 + i << 8);
					Class187.Class194.byte_2[i++] = 8;
				}
				while (i < 256)
				{
					Class187.Class194.short_1[i] = Class187.Class194.smethod_0(256 + i << 7);
					Class187.Class194.byte_2[i++] = 9;
				}
				while (i < 280)
				{
					Class187.Class194.short_1[i] = Class187.Class194.smethod_0(-256 + i << 9);
					Class187.Class194.byte_2[i++] = 7;
				}
				while (i < 286)
				{
					Class187.Class194.short_1[i] = Class187.Class194.smethod_0(-88 + i << 8);
					Class187.Class194.byte_2[i++] = 8;
				}
				Class187.Class194.short_2 = new short[30];
				Class187.Class194.byte_3 = new byte[30];
				for (i = 0; i < 30; i++)
				{
					Class187.Class194.short_2[i] = Class187.Class194.smethod_0(i << 11);
					Class187.Class194.byte_3[i] = 5;
				}
			}

			// Token: 0x0600128D RID: 4749 RVA: 0x000C24D8 File Offset: 0x000C06D8
			public Class194(Class187.Class197 pending)
			{
				this.pending = pending;
				this.class195_0 = new Class187.Class194.Class195(this, 286, 257, 15);
				this.class195_1 = new Class187.Class194.Class195(this, 30, 1, 15);
				this.class195_2 = new Class187.Class194.Class195(this, 19, 4, 7);
				this.short_0 = new short[16384];
				this.byte_1 = new byte[16384];
			}

			// Token: 0x0600128E RID: 4750 RVA: 0x00009BF6 File Offset: 0x00007DF6
			public void method_0()
			{
				this.int_9 = 0;
				this.int_10 = 0;
			}

			// Token: 0x0600128F RID: 4751 RVA: 0x000C2550 File Offset: 0x000C0750
			private int method_1(int int_11)
			{
				int result;
				if (int_11 == 255)
				{
					result = 285;
				}
				else
				{
					int num = 257;
					while (int_11 >= 8)
					{
						num += 4;
						int_11 >>= 1;
					}
					result = num + int_11;
				}
				return result;
			}

			// Token: 0x06001290 RID: 4752 RVA: 0x000C258C File Offset: 0x000C078C
			private int method_2(int int_11)
			{
				int num = 0;
				while (int_11 >= 4)
				{
					num += 2;
					int_11 >>= 1;
				}
				return num + int_11;
			}

			// Token: 0x06001291 RID: 4753 RVA: 0x000C25B4 File Offset: 0x000C07B4
			public void method_3(int int_11)
			{
				this.class195_2.method_2();
				this.class195_0.method_2();
				this.class195_1.method_2();
				this.pending.method_3(this.class195_0.int_0 - 257, 5);
				this.pending.method_3(this.class195_1.int_0 - 1, 5);
				this.pending.method_3(int_11 - 4, 4);
				for (int i = 0; i < int_11; i++)
				{
					this.pending.method_3((int)this.class195_2.byte_0[Class187.Class194.int_8[i]], 3);
				}
				this.class195_0.method_7(this.class195_2);
				this.class195_1.method_7(this.class195_2);
			}

			// Token: 0x06001292 RID: 4754 RVA: 0x000C2678 File Offset: 0x000C0878
			public void method_4()
			{
				for (int i = 0; i < this.int_9; i++)
				{
					int num = (int)(this.byte_1[i] & byte.MaxValue);
					int num2 = (int)this.short_0[i];
					if (num2-- != 0)
					{
						int num3 = this.method_1(num);
						this.class195_0.method_0(num3);
						int num4 = (num3 - 261) / 4;
						if (num4 > 0 && num4 <= 5)
						{
							this.pending.method_3(num & (1 << num4) - 1, num4);
						}
						int num5 = this.method_2(num2);
						this.class195_1.method_0(num5);
						num4 = num5 / 2 - 1;
						if (num4 > 0)
						{
							this.pending.method_3(num2 & (1 << num4) - 1, num4);
						}
					}
					else
					{
						this.class195_0.method_0(num);
					}
				}
				this.class195_0.method_0(256);
			}

			// Token: 0x06001293 RID: 4755 RVA: 0x000C2758 File Offset: 0x000C0958
			public void method_5(byte[] byte_4, int int_11, int int_12, bool bool_0)
			{
				this.pending.method_3(bool_0 ? 1 : 0, 3);
				this.pending.method_2();
				this.pending.method_0(int_12);
				this.pending.method_0(~int_12);
				this.pending.method_1(byte_4, int_11, int_12);
				this.method_0();
			}

			// Token: 0x06001294 RID: 4756 RVA: 0x000C27B4 File Offset: 0x000C09B4
			public void method_6(byte[] byte_4, int int_11, int int_12, bool bool_0)
			{
				short[] array;
				(array = this.class195_0.short_0)[256] = array[256] + 1;
				this.class195_0.method_4();
				this.class195_1.method_4();
				this.class195_0.method_6(this.class195_2);
				this.class195_1.method_6(this.class195_2);
				this.class195_2.method_4();
				int num = 4;
				for (int i = 18; i > num; i--)
				{
					if (this.class195_2.byte_0[Class187.Class194.int_8[i]] > 0)
					{
						num = i + 1;
					}
				}
				int num2 = 14 + num * 3 + this.class195_2.method_5() + this.class195_0.method_5() + this.class195_1.method_5() + this.int_10;
				int num3 = this.int_10;
				for (int j = 0; j < 286; j++)
				{
					num3 += (int)(this.class195_0.short_0[j] * (short)Class187.Class194.byte_2[j]);
				}
				for (int k = 0; k < 30; k++)
				{
					num3 += (int)(this.class195_1.short_0[k] * (short)Class187.Class194.byte_3[k]);
				}
				if (num2 >= num3)
				{
					num2 = num3;
				}
				if (int_11 >= 0 && int_12 + 4 < num2 >> 3)
				{
					this.method_5(byte_4, int_11, int_12, bool_0);
				}
				else if (num2 == num3)
				{
					this.pending.method_3(2 + (bool_0 ? 1 : 0), 3);
					this.class195_0.method_1(Class187.Class194.short_1, Class187.Class194.byte_2);
					this.class195_1.method_1(Class187.Class194.short_2, Class187.Class194.byte_3);
					this.method_4();
					this.method_0();
				}
				else
				{
					this.pending.method_3(4 + (bool_0 ? 1 : 0), 3);
					this.method_3(num);
					this.method_4();
					this.method_0();
				}
			}

			// Token: 0x06001295 RID: 4757 RVA: 0x000C297C File Offset: 0x000C0B7C
			public bool method_7()
			{
				return this.int_9 >= 16384;
			}

			// Token: 0x06001296 RID: 4758 RVA: 0x000C29A0 File Offset: 0x000C0BA0
			public bool method_8(int int_11)
			{
				this.short_0[this.int_9] = 0;
				this.byte_1[this.int_9++] = (byte)int_11;
				short[] array;
				(array = this.class195_0.short_0)[int_11] = array[int_11] + 1;
				return this.method_7();
			}

			// Token: 0x06001297 RID: 4759 RVA: 0x000C29F8 File Offset: 0x000C0BF8
			public bool method_9(int int_11, int int_12)
			{
				this.short_0[this.int_9] = (short)int_11;
				this.byte_1[this.int_9++] = (byte)(int_12 - 3);
				int num = this.method_1(int_12 - 3);
				short[] array;
				IntPtr intPtr;
				(array = this.class195_0.short_0)[(int)(intPtr = (IntPtr)num)] = array[(int)intPtr] + 1;
				if (num >= 265 && num < 285)
				{
					this.int_10 += (num - 261) / 4;
				}
				int num2 = this.method_2(int_11 - 1);
				(array = this.class195_1.short_0)[(int)(intPtr = (IntPtr)num2)] = array[(int)intPtr] + 1;
				if (num2 >= 4)
				{
					this.int_10 += num2 / 2 - 1;
				}
				return this.method_7();
			}

			// Token: 0x04000CF9 RID: 3321
			private const int int_0 = 16384;

			// Token: 0x04000CFA RID: 3322
			private const int int_1 = 286;

			// Token: 0x04000CFB RID: 3323
			private const int int_2 = 30;

			// Token: 0x04000CFC RID: 3324
			private const int int_3 = 19;

			// Token: 0x04000CFD RID: 3325
			private const int int_4 = 16;

			// Token: 0x04000CFE RID: 3326
			private const int int_5 = 17;

			// Token: 0x04000CFF RID: 3327
			private const int int_6 = 18;

			// Token: 0x04000D00 RID: 3328
			private const int int_7 = 256;

			// Token: 0x04000D01 RID: 3329
			private static readonly int[] int_8 = new int[]
			{
				16,
				17,
				18,
				0,
				8,
				7,
				9,
				6,
				10,
				5,
				11,
				4,
				12,
				3,
				13,
				2,
				14,
				1,
				15
			};

			// Token: 0x04000D02 RID: 3330
			private static readonly byte[] byte_0 = new byte[]
			{
				0,
				8,
				4,
				12,
				2,
				10,
				6,
				14,
				1,
				9,
				5,
				13,
				3,
				11,
				7,
				15
			};

			// Token: 0x04000D03 RID: 3331
			private Class187.Class197 pending;

			// Token: 0x04000D04 RID: 3332
			private Class187.Class194.Class195 class195_0;

			// Token: 0x04000D05 RID: 3333
			private Class187.Class194.Class195 class195_1;

			// Token: 0x04000D06 RID: 3334
			private Class187.Class194.Class195 class195_2;

			// Token: 0x04000D07 RID: 3335
			private short[] short_0;

			// Token: 0x04000D08 RID: 3336
			private byte[] byte_1;

			// Token: 0x04000D09 RID: 3337
			private int int_9;

			// Token: 0x04000D0A RID: 3338
			private int int_10;

			// Token: 0x04000D0B RID: 3339
			private static readonly short[] short_1 = new short[286];

			// Token: 0x04000D0C RID: 3340
			private static readonly byte[] byte_2 = new byte[286];

			// Token: 0x04000D0D RID: 3341
			private static readonly short[] short_2;

			// Token: 0x04000D0E RID: 3342
			private static readonly byte[] byte_3;

			// Token: 0x020001AC RID: 428
			public sealed class Class195
			{
				// Token: 0x06001298 RID: 4760 RVA: 0x00009C08 File Offset: 0x00007E08
				public Class195(Class187.Class194 dh, int elems, int minCodes, int maxLength)
				{
					this.dh = dh;
					this.minCodes = minCodes;
					this.maxLength = maxLength;
					this.short_0 = new short[elems];
					this.int_1 = new int[maxLength];
				}

				// Token: 0x06001299 RID: 4761 RVA: 0x00009C41 File Offset: 0x00007E41
				public void method_0(int int_2)
				{
					this.dh.pending.method_3((int)this.short_1[int_2] & 65535, (int)this.byte_0[int_2]);
				}

				// Token: 0x0600129A RID: 4762 RVA: 0x00009C6B File Offset: 0x00007E6B
				public void method_1(short[] short_2, byte[] byte_1)
				{
					this.short_1 = short_2;
					this.byte_0 = byte_1;
				}

				// Token: 0x0600129B RID: 4763 RVA: 0x000C2AC0 File Offset: 0x000C0CC0
				public void method_2()
				{
					int[] array = new int[this.maxLength];
					int num = 0;
					this.short_1 = new short[this.short_0.Length];
					for (int i = 0; i < this.maxLength; i++)
					{
						array[i] = num;
						num += this.int_1[i] << 15 - i;
					}
					for (int j = 0; j < this.int_0; j++)
					{
						int num2 = (int)this.byte_0[j];
						if (num2 > 0)
						{
							this.short_1[j] = Class187.Class194.smethod_0(array[num2 - 1]);
							int[] array2;
							IntPtr intPtr;
							(array2 = array)[(int)(intPtr = (IntPtr)(num2 - 1))] = array2[(int)intPtr] + (1 << 16 - num2);
						}
					}
				}

				// Token: 0x0600129C RID: 4764 RVA: 0x000C2B68 File Offset: 0x000C0D68
				private void method_3(int[] int_2)
				{
					this.byte_0 = new byte[this.short_0.Length];
					int num = int_2.Length / 2;
					int num2 = (num + 1) / 2;
					int num3 = 0;
					for (int i = 0; i < this.maxLength; i++)
					{
						this.int_1[i] = 0;
					}
					int[] array = new int[num];
					array[num - 1] = 0;
					for (int j = num - 1; j >= 0; j--)
					{
						if (int_2[2 * j + 1] != -1)
						{
							int num4 = array[j] + 1;
							if (num4 > this.maxLength)
							{
								num4 = this.maxLength;
								num3++;
							}
							array[int_2[2 * j]] = (array[int_2[2 * j + 1]] = num4);
						}
						else
						{
							int num5 = array[j];
							int[] array2;
							IntPtr intPtr;
							(array2 = this.int_1)[(int)(intPtr = (IntPtr)(num5 - 1))] = array2[(int)intPtr] + 1;
							this.byte_0[int_2[2 * j]] = (byte)array[j];
						}
					}
					if (num3 != 0)
					{
						int num6 = this.maxLength - 1;
						int[] array2;
						IntPtr intPtr;
						for (;;)
						{
							if (this.int_1[--num6] != 0)
							{
								do
								{
									(array2 = this.int_1)[(int)(intPtr = (IntPtr)num6)] = array2[(int)intPtr] - 1;
									(array2 = this.int_1)[(int)(intPtr = (IntPtr)(++num6))] = array2[(int)intPtr] + 1;
									num3 -= 1 << this.maxLength - 1 - num6;
								}
								while (num3 > 0 && num6 < this.maxLength - 1);
								if (num3 <= 0)
								{
									break;
								}
							}
						}
						(array2 = this.int_1)[(int)(intPtr = (IntPtr)(this.maxLength - 1))] = array2[(int)intPtr] + num3;
						(array2 = this.int_1)[(int)(intPtr = (IntPtr)(this.maxLength - 2))] = array2[(int)intPtr] - num3;
						int num7 = 2 * num2;
						for (int num8 = this.maxLength; num8 != 0; num8--)
						{
							int k = this.int_1[num8 - 1];
							while (k > 0)
							{
								int num9 = 2 * int_2[num7++];
								if (int_2[num9 + 1] == -1)
								{
									this.byte_0[int_2[num9]] = (byte)num8;
									k--;
								}
							}
						}
					}
				}

				// Token: 0x0600129D RID: 4765 RVA: 0x000C2D5C File Offset: 0x000C0F5C
				public void method_4()
				{
					int num = this.short_0.Length;
					int[] array = new int[num];
					int i = 0;
					int num2 = 0;
					for (int j = 0; j < num; j++)
					{
						int num3 = (int)this.short_0[j];
						if (num3 != 0)
						{
							int num4 = i++;
							int num5;
							while (num4 > 0 && (int)this.short_0[array[num5 = (num4 - 1) / 2]] > num3)
							{
								array[num4] = array[num5];
								num4 = num5;
							}
							array[num4] = j;
							num2 = j;
						}
					}
					while (i < 2)
					{
						int num6 = (num2 < 2) ? (++num2) : 0;
						array[i++] = num6;
					}
					this.int_0 = Math.Max(num2 + 1, this.minCodes);
					int num7 = i;
					int[] array2 = new int[4 * i - 2];
					int[] array3 = new int[2 * i - 1];
					int num8 = num7;
					for (int k = 0; k < i; k++)
					{
						int num9 = array[k];
						array2[2 * k] = num9;
						array2[2 * k + 1] = -1;
						array3[k] = (int)this.short_0[num9] << 8;
						array[k] = k;
					}
					do
					{
						int num10 = array[0];
						int num11 = array[--i];
						int num12 = 0;
						int l;
						for (l = 1; l < i; l = l * 2 + 1)
						{
							if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
							{
								l++;
							}
							array[num12] = array[l];
							num12 = l;
						}
						int num13 = array3[num11];
						while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
						{
							array[l] = array[num12];
						}
						array[l] = num11;
						int num14 = array[0];
						num11 = num8++;
						array2[2 * num11] = num10;
						array2[2 * num11 + 1] = num14;
						int num15 = Math.Min(array3[num10] & 255, array3[num14] & 255);
						num13 = (array3[num11] = array3[num10] + array3[num14] - num15 + 1);
						num12 = 0;
						for (l = 1; l < i; l = num12 * 2 + 1)
						{
							if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
							{
								l++;
							}
							array[num12] = array[l];
							num12 = l;
						}
						while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
						{
							array[l] = array[num12];
						}
						array[l] = num11;
					}
					while (i > 1);
					this.method_3(array2);
				}

				// Token: 0x0600129E RID: 4766 RVA: 0x000C2FBC File Offset: 0x000C11BC
				public int method_5()
				{
					int num = 0;
					for (int i = 0; i < this.short_0.Length; i++)
					{
						num += (int)(this.short_0[i] * (short)this.byte_0[i]);
					}
					return num;
				}

				// Token: 0x0600129F RID: 4767 RVA: 0x000C2FF8 File Offset: 0x000C11F8
				public void method_6(Class187.Class194.Class195 class195_0)
				{
					int num = -1;
					int i = 0;
					while (i < this.int_0)
					{
						int num2 = 1;
						int num3 = (int)this.byte_0[i];
						int num4;
						int num5;
						if (num3 == 0)
						{
							num4 = 138;
							num5 = 3;
						}
						else
						{
							num4 = 6;
							num5 = 3;
							if (num != num3)
							{
								short[] array;
								IntPtr intPtr;
								(array = class195_0.short_0)[(int)(intPtr = (IntPtr)num3)] = array[(int)intPtr] + 1;
								num2 = 0;
							}
						}
						num = num3;
						i++;
						while (i < this.int_0)
						{
							if (num != (int)this.byte_0[i])
							{
								break;
							}
							i++;
							if (++num2 >= num4)
							{
								break;
							}
						}
						if (num2 < num5)
						{
							short[] array;
							IntPtr intPtr;
							(array = class195_0.short_0)[(int)(intPtr = (IntPtr)num)] = array[(int)intPtr] + (short)num2;
						}
						else if (num != 0)
						{
							short[] array;
							(array = class195_0.short_0)[16] = array[16] + 1;
						}
						else if (num2 <= 10)
						{
							short[] array;
							(array = class195_0.short_0)[17] = array[17] + 1;
						}
						else
						{
							short[] array;
							(array = class195_0.short_0)[18] = array[18] + 1;
						}
					}
				}

				// Token: 0x060012A0 RID: 4768 RVA: 0x000C30F4 File Offset: 0x000C12F4
				public void method_7(Class187.Class194.Class195 class195_0)
				{
					int num = -1;
					int i = 0;
					while (i < this.int_0)
					{
						int num2 = 1;
						int num3 = (int)this.byte_0[i];
						int num4;
						int num5;
						if (num3 == 0)
						{
							num4 = 138;
							num5 = 3;
						}
						else
						{
							num4 = 6;
							num5 = 3;
							if (num != num3)
							{
								class195_0.method_0(num3);
								num2 = 0;
							}
						}
						num = num3;
						i++;
						while (i < this.int_0)
						{
							if (num != (int)this.byte_0[i])
							{
								break;
							}
							i++;
							if (++num2 >= num4)
							{
								break;
							}
						}
						if (num2 < num5)
						{
							while (num2-- > 0)
							{
								class195_0.method_0(num);
							}
						}
						else if (num != 0)
						{
							class195_0.method_0(16);
							this.dh.pending.method_3(num2 - 3, 2);
						}
						else if (num2 <= 10)
						{
							class195_0.method_0(17);
							this.dh.pending.method_3(num2 - 3, 3);
						}
						else
						{
							class195_0.method_0(18);
							this.dh.pending.method_3(num2 - 11, 7);
						}
					}
				}

				// Token: 0x04000D0F RID: 3343
				public short[] short_0;

				// Token: 0x04000D10 RID: 3344
				public byte[] byte_0;

				// Token: 0x04000D11 RID: 3345
				public int minCodes;

				// Token: 0x04000D12 RID: 3346
				public int int_0;

				// Token: 0x04000D13 RID: 3347
				private short[] short_1;

				// Token: 0x04000D14 RID: 3348
				private int[] int_1;

				// Token: 0x04000D15 RID: 3349
				private int maxLength;

				// Token: 0x04000D16 RID: 3350
				private Class187.Class194 dh;
			}
		}

		// Token: 0x020001AD RID: 429
		internal sealed class Class196
		{
			// Token: 0x060012A1 RID: 4769 RVA: 0x000C31F4 File Offset: 0x000C13F4
			public Class196(Class187.Class197 pending)
			{
				this.pending = pending;
				this.class194_0 = new Class187.Class194(pending);
				this.byte_0 = new byte[65536];
				this.short_0 = new short[32768];
				this.short_1 = new short[32768];
				this.int_14 = 1;
				this.int_13 = 1;
			}

			// Token: 0x060012A2 RID: 4770 RVA: 0x00009C7D File Offset: 0x00007E7D
			private void method_0()
			{
				this.int_10 = ((int)this.byte_0[this.int_14] << 5 ^ (int)this.byte_0[this.int_14 + 1]);
			}

			// Token: 0x060012A3 RID: 4771 RVA: 0x000C325C File Offset: 0x000C145C
			private int method_1()
			{
				int num = (this.int_10 << 5 ^ (int)this.byte_0[this.int_14 + 2]) & 32767;
				short num2 = this.short_1[this.int_14 & 32767] = this.short_0[num];
				this.short_0[num] = (short)this.int_14;
				this.int_10 = num;
				return (int)num2 & 65535;
			}

			// Token: 0x060012A4 RID: 4772 RVA: 0x000C32C8 File Offset: 0x000C14C8
			private void method_2()
			{
				Array.Copy(this.byte_0, 32768, this.byte_0, 0, 32768);
				this.int_11 -= 32768;
				this.int_14 -= 32768;
				this.int_13 -= 32768;
				for (int i = 0; i < 32768; i++)
				{
					int num = (int)this.short_0[i] & 65535;
					this.short_0[i] = (short)((num >= 32768) ? (num - 32768) : 0);
				}
				for (int j = 0; j < 32768; j++)
				{
					int num2 = (int)this.short_1[j] & 65535;
					this.short_1[j] = (short)((num2 >= 32768) ? (num2 - 32768) : 0);
				}
			}

			// Token: 0x060012A5 RID: 4773 RVA: 0x000C33A0 File Offset: 0x000C15A0
			public void method_3()
			{
				if (this.int_14 >= 65274)
				{
					this.method_2();
				}
				while (this.int_15 < 262 && this.int_17 < this.int_18)
				{
					int num = 65536 - this.int_15 - this.int_14;
					if (num > this.int_18 - this.int_17)
					{
						num = this.int_18 - this.int_17;
					}
					Array.Copy(this.byte_1, this.int_17, this.byte_0, this.int_14 + this.int_15, num);
					this.int_17 += num;
					this.int_16 += num;
					this.int_15 += num;
				}
				if (this.int_15 >= 3)
				{
					this.method_0();
				}
			}

			// Token: 0x060012A6 RID: 4774 RVA: 0x000C347C File Offset: 0x000C167C
			private bool method_4(int int_19)
			{
				int num = 128;
				int num2 = 128;
				short[] array = this.short_1;
				int num3 = this.int_14;
				int num4 = this.int_14 + this.int_12;
				int num5 = Math.Max(this.int_12, 2);
				int num6 = Math.Max(this.int_14 - 32506, 0);
				int num7 = this.int_14 + 258 - 1;
				byte b = this.byte_0[num4 - 1];
				byte b2 = this.byte_0[num4];
				if (num5 >= 8)
				{
					num >>= 2;
				}
				if (num2 > this.int_15)
				{
					num2 = this.int_15;
				}
				do
				{
					if (this.byte_0[int_19 + num5] == b2 && this.byte_0[int_19 + num5 - 1] == b && this.byte_0[int_19] == this.byte_0[num3] && this.byte_0[int_19 + 1] == this.byte_0[num3 + 1])
					{
						int num8 = int_19 + 2;
						num3 += 2;
						while (this.byte_0[++num3] == this.byte_0[++num8] && this.byte_0[++num3] == this.byte_0[++num8] && this.byte_0[++num3] == this.byte_0[++num8] && this.byte_0[++num3] == this.byte_0[++num8] && this.byte_0[++num3] == this.byte_0[++num8] && this.byte_0[++num3] == this.byte_0[++num8] && this.byte_0[++num3] == this.byte_0[++num8] && this.byte_0[++num3] == this.byte_0[++num8] && num3 < num7)
						{
						}
						if (num3 > num4)
						{
							this.int_11 = int_19;
							num4 = num3;
							num5 = num3 - this.int_14;
							if (num5 >= num2)
							{
								break;
							}
							b = this.byte_0[num4 - 1];
							b2 = this.byte_0[num4];
						}
						num3 = this.int_14;
					}
					if ((int_19 = ((int)array[int_19 & 32767] & 65535)) <= num6)
					{
						break;
					}
				}
				while (--num != 0);
				this.int_12 = Math.Min(num5, this.int_15);
				return this.int_12 >= 3;
			}

			// Token: 0x060012A7 RID: 4775 RVA: 0x000C3700 File Offset: 0x000C1900
			private bool method_5(bool bool_1, bool bool_2)
			{
				bool result;
				if (this.int_15 < 262 && !bool_1)
				{
					result = false;
				}
				else
				{
					while (this.int_15 >= 262 || bool_1)
					{
						if (this.int_15 == 0)
						{
							if (this.bool_0)
							{
								this.class194_0.method_8((int)(this.byte_0[this.int_14 - 1] & byte.MaxValue));
							}
							this.bool_0 = false;
							this.class194_0.method_6(this.byte_0, this.int_13, this.int_14 - this.int_13, bool_2);
							this.int_13 = this.int_14;
							return false;
						}
						if (this.int_14 >= 65274)
						{
							this.method_2();
						}
						int num = this.int_11;
						int num2 = this.int_12;
						if (this.int_15 >= 3)
						{
							int num3 = this.method_1();
							if (num3 != 0 && this.int_14 - num3 <= 32506 && this.method_4(num3) && this.int_12 <= 5 && this.int_12 == 3 && this.int_14 - this.int_11 > 4096)
							{
								this.int_12 = 2;
							}
						}
						if (num2 >= 3 && this.int_12 <= num2)
						{
							this.class194_0.method_9(this.int_14 - 1 - num, num2);
							num2 -= 2;
							do
							{
								this.int_14++;
								this.int_15--;
								if (this.int_15 >= 3)
								{
									this.method_1();
								}
							}
							while (--num2 > 0);
							this.int_14++;
							this.int_15--;
							this.bool_0 = false;
							this.int_12 = 2;
						}
						else
						{
							if (this.bool_0)
							{
								this.class194_0.method_8((int)(this.byte_0[this.int_14 - 1] & byte.MaxValue));
							}
							this.bool_0 = true;
							this.int_14++;
							this.int_15--;
						}
						if (this.class194_0.method_7())
						{
							int num4 = this.int_14 - this.int_13;
							if (this.bool_0)
							{
								num4--;
							}
							bool flag = bool_2 && this.int_15 == 0 && !this.bool_0;
							this.class194_0.method_6(this.byte_0, this.int_13, num4, flag);
							this.int_13 += num4;
							return !flag;
						}
					}
					result = true;
				}
				return result;
			}

			// Token: 0x060012A8 RID: 4776 RVA: 0x000C3994 File Offset: 0x000C1B94
			public bool method_6(bool bool_1, bool bool_2)
			{
				bool flag;
				do
				{
					this.method_3();
					bool bool_3 = bool_1 && this.int_17 == this.int_18;
					flag = this.method_5(bool_3, bool_2);
					if (!this.pending.IsFlushed)
					{
						break;
					}
				}
				while (flag);
				return flag;
			}

			// Token: 0x060012A9 RID: 4777 RVA: 0x00009CA6 File Offset: 0x00007EA6
			public void method_7(byte[] byte_2)
			{
				this.byte_1 = byte_2;
				this.int_17 = 0;
				this.int_18 = byte_2.Length;
			}

			// Token: 0x060012AA RID: 4778 RVA: 0x000C39DC File Offset: 0x000C1BDC
			public bool method_8()
			{
				return this.int_18 == this.int_17;
			}

			// Token: 0x04000D17 RID: 3351
			private const int int_0 = 258;

			// Token: 0x04000D18 RID: 3352
			private const int int_1 = 3;

			// Token: 0x04000D19 RID: 3353
			private const int int_2 = 32768;

			// Token: 0x04000D1A RID: 3354
			private const int int_3 = 32767;

			// Token: 0x04000D1B RID: 3355
			private const int int_4 = 32768;

			// Token: 0x04000D1C RID: 3356
			private const int int_5 = 32767;

			// Token: 0x04000D1D RID: 3357
			private const int int_6 = 5;

			// Token: 0x04000D1E RID: 3358
			private const int int_7 = 262;

			// Token: 0x04000D1F RID: 3359
			private const int int_8 = 32506;

			// Token: 0x04000D20 RID: 3360
			private const int int_9 = 4096;

			// Token: 0x04000D21 RID: 3361
			private int int_10;

			// Token: 0x04000D22 RID: 3362
			private short[] short_0;

			// Token: 0x04000D23 RID: 3363
			private short[] short_1;

			// Token: 0x04000D24 RID: 3364
			private int int_11;

			// Token: 0x04000D25 RID: 3365
			private int int_12;

			// Token: 0x04000D26 RID: 3366
			private bool bool_0;

			// Token: 0x04000D27 RID: 3367
			private int int_13;

			// Token: 0x04000D28 RID: 3368
			private int int_14;

			// Token: 0x04000D29 RID: 3369
			private int int_15;

			// Token: 0x04000D2A RID: 3370
			private byte[] byte_0;

			// Token: 0x04000D2B RID: 3371
			private byte[] byte_1;

			// Token: 0x04000D2C RID: 3372
			private int int_16;

			// Token: 0x04000D2D RID: 3373
			private int int_17;

			// Token: 0x04000D2E RID: 3374
			private int int_18;

			// Token: 0x04000D2F RID: 3375
			private Class187.Class197 pending;

			// Token: 0x04000D30 RID: 3376
			private Class187.Class194 class194_0;
		}

		// Token: 0x020001AE RID: 430
		internal sealed class Class197
		{
			// Token: 0x060012AB RID: 4779 RVA: 0x000C39FC File Offset: 0x000C1BFC
			public void method_0(int int_3)
			{
				this.byte_0[this.int_1++] = (byte)int_3;
				this.byte_0[this.int_1++] = (byte)(int_3 >> 8);
			}

			// Token: 0x060012AC RID: 4780 RVA: 0x00009CC1 File Offset: 0x00007EC1
			public void method_1(byte[] byte_1, int int_3, int int_4)
			{
				Array.Copy(byte_1, int_3, this.byte_0, this.int_1, int_4);
				this.int_1 += int_4;
			}

			// Token: 0x1700040F RID: 1039
			// (get) Token: 0x060012AD RID: 4781 RVA: 0x000C3A44 File Offset: 0x000C1C44
			public int BitCount
			{
				get
				{
					return this.int_2;
				}
			}

			// Token: 0x060012AE RID: 4782 RVA: 0x000C3A5C File Offset: 0x000C1C5C
			public void method_2()
			{
				if (this.int_2 > 0)
				{
					this.byte_0[this.int_1++] = (byte)this.uint_0;
					if (this.int_2 > 8)
					{
						this.byte_0[this.int_1++] = (byte)(this.uint_0 >> 8);
					}
				}
				this.uint_0 = 0U;
				this.int_2 = 0;
			}

			// Token: 0x060012AF RID: 4783 RVA: 0x000C3ACC File Offset: 0x000C1CCC
			public void method_3(int int_3, int int_4)
			{
				this.uint_0 |= (uint)((uint)int_3 << this.int_2);
				this.int_2 += int_4;
				if (this.int_2 >= 16)
				{
					this.byte_0[this.int_1++] = (byte)this.uint_0;
					this.byte_0[this.int_1++] = (byte)(this.uint_0 >> 8);
					this.uint_0 >>= 16;
					this.int_2 -= 16;
				}
			}

			// Token: 0x17000410 RID: 1040
			// (get) Token: 0x060012B0 RID: 4784 RVA: 0x000C3B6C File Offset: 0x000C1D6C
			public bool IsFlushed
			{
				get
				{
					return this.int_1 == 0;
				}
			}

			// Token: 0x060012B1 RID: 4785 RVA: 0x000C3B88 File Offset: 0x000C1D88
			public int method_4(byte[] byte_1, int int_3, int int_4)
			{
				if (this.int_2 >= 8)
				{
					this.byte_0[this.int_1++] = (byte)this.uint_0;
					this.uint_0 >>= 8;
					this.int_2 -= 8;
				}
				if (int_4 > this.int_1 - this.int_0)
				{
					int_4 = this.int_1 - this.int_0;
					Array.Copy(this.byte_0, this.int_0, byte_1, int_3, int_4);
					this.int_0 = 0;
					this.int_1 = 0;
				}
				else
				{
					Array.Copy(this.byte_0, this.int_0, byte_1, int_3, int_4);
					this.int_0 += int_4;
				}
				return int_4;
			}

			// Token: 0x04000D31 RID: 3377
			protected byte[] byte_0 = new byte[65536];

			// Token: 0x04000D32 RID: 3378
			private int int_0 = 0;

			// Token: 0x04000D33 RID: 3379
			private int int_1 = 0;

			// Token: 0x04000D34 RID: 3380
			private uint uint_0 = 0U;

			// Token: 0x04000D35 RID: 3381
			private int int_2 = 0;
		}

		// Token: 0x020001AF RID: 431
		internal sealed class Stream0 : MemoryStream
		{
			// Token: 0x060012B3 RID: 4787 RVA: 0x00009D1B File Offset: 0x00007F1B
			public void method_0(int int_0)
			{
				this.WriteByte((byte)(int_0 & 255));
				this.WriteByte((byte)(int_0 >> 8 & 255));
			}

			// Token: 0x060012B4 RID: 4788 RVA: 0x00009D3D File Offset: 0x00007F3D
			public void method_1(int int_0)
			{
				this.method_0(int_0);
				this.method_0(int_0 >> 16);
			}

			// Token: 0x060012B5 RID: 4789 RVA: 0x000C3C44 File Offset: 0x000C1E44
			public int method_2()
			{
				return this.ReadByte() | this.ReadByte() << 8;
			}

			// Token: 0x060012B6 RID: 4790 RVA: 0x000C3C64 File Offset: 0x000C1E64
			public int method_3()
			{
				return this.method_2() | this.method_2() << 16;
			}

			// Token: 0x060012B7 RID: 4791 RVA: 0x00009D52 File Offset: 0x00007F52
			public Stream0()
			{
			}

			// Token: 0x060012B8 RID: 4792 RVA: 0x00009D5A File Offset: 0x00007F5A
			public Stream0(byte[] buffer) : base(buffer, false)
			{
			}
		}
	}
}
