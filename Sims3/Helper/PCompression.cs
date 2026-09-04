using System;
using System.IO;

namespace Package.Helper
{
	// Token: 0x020000D7 RID: 215
	internal static class PCompression
	{
		// Token: 0x06000B6A RID: 2922 RVA: 0x00038B70 File Offset: 0x00036D70
		public static byte[] UncompressStream(Stream stream, int filesize, int memsize)
		{
			BinaryReader binaryReader = new BinaryReader(stream);
			long num = stream.Position + (long)filesize;
			byte[] array = new byte[memsize];
			BinaryWriter binaryWriter = new BinaryWriter(new MemoryStream(array));
			byte[] array2 = binaryReader.ReadBytes(2);
			if (PCompression.checking && array2.Length != 2)
			{
				throw new InvalidDataException("Hit unexpected end of file at " + stream.Position.ToString());
			}
			int num2 = (((array2[0] & 128) != 0) ? 4 : 3) * (((array2[0] & 1) != 0) ? 2 : 1);
			array2 = binaryReader.ReadBytes(num2);
			if (PCompression.checking && array2.Length != num2)
			{
				throw new InvalidDataException("Hit unexpected end of file at " + stream.Position.ToString());
			}
			long num3 = 0L;
			for (int i = 0; i < array2.Length; i++)
			{
				num3 = (num3 << 8) + (long)((ulong)array2[i]);
			}
			if (PCompression.checking && num3 != (long)memsize)
			{
				throw new InvalidDataException(string.Format("Resource data indicates size does not match index at 0x{0}.  Read 0x{1}.  Expected 0x{2}.", stream.Position.ToString("X8"), num3.ToString("X8"), memsize.ToString("X8")));
			}
			while (stream.Position < num)
			{
				PCompression.Dechunk(stream, binaryWriter);
			}
			if (PCompression.checking && binaryWriter.BaseStream.Position != (long)memsize)
			{
				throw new InvalidDataException(string.Format("Read 0x{0:X8} bytes.  Expected 0x{1:X8}.", binaryWriter.BaseStream.Position, memsize));
			}
			binaryWriter.Close();
			return array;
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x00038CEC File Offset: 0x00036EEC
		public static void Dechunk(Stream stream, BinaryWriter bw)
		{
			BinaryReader binaryReader = new BinaryReader(stream);
			int num = 0;
			int num2 = 0;
			byte b = binaryReader.ReadByte();
			int num3;
			if (b < 128)
			{
				byte[] array = binaryReader.ReadBytes(1);
				if (PCompression.checking && array.Length != 1)
				{
					throw new InvalidDataException("Hit unexpected end of file at " + stream.Position.ToString());
				}
				num3 = (int)(b & 3);
				num = (b >> 2 & 7) + 3;
				num2 = (((int)b << 3 & 768) | (int)array[0]) + 1;
			}
			else if (b < 192)
			{
				byte[] array = binaryReader.ReadBytes(2);
				if (PCompression.checking && array.Length != 2)
				{
					throw new InvalidDataException("Hit unexpected end of file at " + stream.Position.ToString());
				}
				num3 = (array[0] >> 6 & 3);
				num = (int)((b & 63) + 4);
				num2 = (((int)array[0] << 8 & 16128) | (int)array[1]) + 1;
			}
			else if (b < 224)
			{
				byte[] array = binaryReader.ReadBytes(3);
				if (PCompression.checking && array.Length != 3)
				{
					throw new InvalidDataException("Hit unexpected end of file at " + stream.Position.ToString());
				}
				num3 = (int)(b & 3);
				num = (((int)b << 6 & 768) | (int)array[2]) + 5;
				num2 = (((int)b << 12 & 65536) | (int)array[0] << 8 | (int)array[1]) + 1;
			}
			else if (b < 252)
			{
				num3 = (int)((b & 31) + 1) << 2;
			}
			else
			{
				num3 = (int)(b & 3);
			}
			if (num3 > 0)
			{
				byte[] array = binaryReader.ReadBytes(num3);
				if (PCompression.checking && array.Length != num3)
				{
					throw new InvalidDataException("Hit unexpected end of file at " + stream.Position.ToString());
				}
				bw.Write(array);
			}
			if (PCompression.checking && (long)num2 > bw.BaseStream.Position)
			{
				throw new InvalidDataException(string.Format("Invalid copy offset 0x{0:X8} at {1}.", num2, stream.Position));
			}
			if (num < num2 && num2 > 8)
			{
				PCompression.CopyA(bw.BaseStream, num2, num);
				return;
			}
			PCompression.CopyB(bw.BaseStream, num2, num);
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x00038F04 File Offset: 0x00037104
		private static void CopyA(Stream s, int offset, int len)
		{
			while (len > 0)
			{
				long position = s.Position;
				byte[] array = new byte[Math.Min(offset, len)];
				len -= array.Length;
				s.Position -= (long)offset;
				s.Read(array, 0, array.Length);
				s.Position = position;
				s.Write(array, 0, array.Length);
			}
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x00038F60 File Offset: 0x00037160
		private static void CopyB(Stream s, int offset, int len)
		{
			while (len > 0)
			{
				long position = s.Position;
				len--;
				s.Position -= (long)offset;
				byte value = (byte)s.ReadByte();
				s.Position = position;
				s.WriteByte(value);
			}
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x00038FA8 File Offset: 0x000371A8
		public static byte[] CompressStream(byte[] data)
		{
			if (data.Length < 10)
			{
				return data;
			}
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			int num;
			if ((long)data.Length >= 140737488355328L)
			{
				num = 8;
			}
			else if ((long)data.Length >= 2147483648L)
			{
				num = 6;
			}
			else if ((long)data.Length >= 16777216L)
			{
				num = 4;
			}
			else
			{
				num = 3;
			}
			binaryWriter.Write((ushort)(64272 | ((num == 8) ? 129 : ((num == 6) ? 1 : ((num == 4) ? 128 : 0)))));
			byte[] bytes = BitConverter.GetBytes((long)data.Length);
			for (int i = num; i > 0; i--)
			{
				binaryWriter.Write(bytes[i - 1]);
			}
			for (int j = 0; j < data.Length; j += PCompression.Enchunk(data, j, binaryWriter))
			{
			}
			binaryWriter.Flush();
			memoryStream.Position = 0L;
			if (memoryStream.Length >= (long)data.Length)
			{
				return data;
			}
			return new BinaryReader(memoryStream).ReadBytes((int)memoryStream.Length);
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x000390A4 File Offset: 0x000372A4
		public static int Enchunk(byte[] buffer, int pos, BinaryWriter bw)
		{
			if (buffer.Length - pos < 4)
			{
				return PCompression.WriteChunk(bw, buffer, pos, buffer.Length - pos, -1, 0);
			}
			if (buffer.Length - pos < 6)
			{
				return PCompression.WriteChunk(bw, buffer, pos, buffer.Length - pos & -4, -1, 0);
			}
			int num = 3;
			int num2 = (pos < 3) ? 3 : 0;
			int num3 = (buffer.Length & -4) - 1;
			int num4 = PCompression.Search(buffer, pos + num2, num, -1);
			while (num4 == -1 && num2 < 112 && pos + num2 + num < num3)
			{
				num2++;
				num4 = PCompression.Search(buffer, pos + num2, num, -1);
			}
			int num5 = num4;
			if (num4 != -1)
			{
				while (num <= 1027 && num < pos + num2 && pos + num2 + num < num3)
				{
					num4 = PCompression.Search(buffer, pos + num2, num + 1, num5);
					if (num4 == -1)
					{
						break;
					}
					num++;
					num5 = num4;
				}
			}
			else if (num2 + num <= 112)
			{
				num2 += num;
			}
			int datalen = num2 & 3;
			num2 &= -4;
			if (num2 > 0)
			{
				num2 = PCompression.WriteChunk(bw, buffer, pos, num2, -1, 0);
			}
			if (num5 != -1)
			{
				num2 += PCompression.WriteChunk(bw, buffer, pos + num2, datalen, num5, (num5 == -1) ? 0 : num);
			}
			return num2;
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x000391AC File Offset: 0x000373AC
		private static int Search(byte[] buffer, int keypos, int keylen, int start)
		{
			if (PCompression.checking && keypos < keylen)
			{
				throw new InvalidOperationException(string.Format("At position 0x{0:X8}, requested key length 0x{1:X4} exceeds current position.", keypos, keylen));
			}
			if (PCompression.checking && keypos + keylen - 1 > buffer.Length)
			{
				throw new InvalidOperationException(string.Format("At position 0x{0:X8}, requested key length 0x{1:X4} exceeds input data length 0x{2:X8}.", keypos, keylen, buffer.Length));
			}
			if (start == -1)
			{
				start = keypos - 1;
			}
			int num = (keylen < 4) ? 1024 : ((keylen < 5) ? 16384 : 131072);
			for (;;)
			{
				IL_C1:
				if (buffer[start] == buffer[keypos])
				{
					int i = 1;
					while (i < keylen)
					{
						if (buffer[start + i] != buffer[keypos + i])
						{
							if (start == 0)
							{
								return -1;
							}
							if (keypos - start == num)
							{
								return -1;
							}
							start--;
							goto IL_C1;
						}
						else
						{
							i++;
						}
					}
					return start;
				}
				if (start == 0)
				{
					break;
				}
				if (keypos - start == num)
				{
					break;
				}
				start--;
			}
			return -1;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0003928C File Offset: 0x0003748C
		private static int WriteChunk(BinaryWriter bw, byte[] data, int posn, int datalen, int copypos, int copysize)
		{
			if (PCompression.checking && posn + datalen > data.Length)
			{
				throw new InvalidOperationException(string.Format("At position 0x{0:X8}, requested uncompressed length 0x{1:X4} exceeds input data length 0x{2:X8}.", posn, datalen, data.Length));
			}
			byte[] array = null;
			int result = datalen + copysize;
			byte b;
			if (copypos == -1)
			{
				if (PCompression.checking)
				{
					if (datalen > 112)
					{
						throw new InvalidOperationException(string.Format("At position 0x{0:X8}, requested uncompressed length 0x{1:X4} greater than 112.", posn, datalen));
					}
					if (copysize != 0)
					{
						throw new ArgumentException(string.Format("At position 0x{0:X8}, must pass zero copysize (got 0x{1:X4}) when copypos is -1.", posn, copysize));
					}
				}
				if (datalen > 3)
				{
					if (PCompression.checking && (datalen & 3) != 0)
					{
						throw new InvalidOperationException(string.Format("At position 0x{0:X8}, requested uncompressed length 0x{1:X4} not a multiple of 4.", posn, datalen));
					}
					if (PCompression.checking && datalen > 112)
					{
						throw new InvalidOperationException(string.Format("At position 0x{0:X8}, requested uncompressed length 0x{1:X4} greater than 0x70.", posn, datalen));
					}
					b = (byte)((datalen >> 2) - 1);
					b |= 224;
				}
				else
				{
					if (PCompression.checking && data.Length - posn > 3)
					{
						throw new InvalidOperationException(string.Format("At position 0x{0:X8}, requested end of file with 0x{1:X4} bytes remaining: must be 3 or less.", posn, data.Length - posn));
					}
					b = (byte)datalen;
					b |= 252;
				}
			}
			else
			{
				int num = posn + datalen - copypos - 1;
				if (PCompression.checking)
				{
					if (copypos > posn + datalen)
					{
						throw new InvalidOperationException(string.Format("At position 0x{0:X8}, invalid copy position 0x{1:X8}.", posn + datalen, copypos));
					}
					if (num > 131071)
					{
						throw new InvalidOperationException(string.Format("At position 0x{0:X8}, requested copy offset 0x{1:X8} exceeds 0x1ffff.", posn, num));
					}
					if (num + 1 > posn + datalen)
					{
						throw new InvalidOperationException(string.Format("At position 0x{0:X8}, requested copy offset 0x{1:X8} exceeds uncompressed position.", posn, num));
					}
					if (datalen > 3)
					{
						throw new InvalidOperationException(string.Format("At position 0x{0:X8}, requested uncompressed length 0x{1:X4} greater than 3.", posn, datalen));
					}
				}
				if (num < 1024 && copysize <= 10)
				{
					array = new byte[1];
					b = (byte)((num & 768) >> 3);
					array[0] = (byte)(num & 255);
					copysize -= 3;
					b |= (byte)((copysize & 7) << 2);
					b |= (byte)(datalen & 3);
				}
				else if (num < 16384 && copysize <= 67)
				{
					array = new byte[]
					{
						(byte)((num & 16128) >> 8),
						(byte)(num & 255)
					};
					copysize -= 4;
					b = (byte)(copysize & 63);
					byte[] array2 = array;
					int num2 = 0;
					array2[num2] |= (byte)((datalen & 3) << 6);
					b |= 128;
				}
				else
				{
					array = new byte[3];
					b = (byte)((num & 65536) >> 12);
					array[0] = (byte)((num & 65280) >> 8);
					array[1] = (byte)(num & 255);
					copysize -= 5;
					b |= (byte)((copysize & 768) >> 6);
					array[2] = (byte)(copysize & 255);
					b |= (byte)(datalen & 3);
					b |= 192;
				}
			}
			bw.Write(b);
			if (array != null)
			{
				bw.Write(array);
			}
			if (datalen > 0)
			{
				bw.BaseStream.Write(data, posn, datalen);
			}
			return result;
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x00039590 File Offset: 0x00037790
		private static string[] foo(MemoryStream bar, byte[] data, long srcpos, long pos)
		{
			MemoryStream memoryStream = new MemoryStream((byte[])data.Clone());
			memoryStream.Position = srcpos;
			long position = bar.Position;
			bar.Position = pos;
			PCompression.Dechunk(bar, new BinaryWriter(memoryStream));
			long position2 = bar.Position;
			bar.Position = position;
			position = memoryStream.Position;
			memoryStream.Position = srcpos;
			return new string[]
			{
				new string(new BinaryReader(memoryStream).ReadChars((int)(position - srcpos))),
				(position - srcpos).ToString("X"),
				position.ToString("X") + ", " + position2.ToString("X")
			};
		}

		// Token: 0x04000573 RID: 1395
		private static bool checking;
	}
}
