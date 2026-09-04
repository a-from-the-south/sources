using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000045 RID: 69
	public class SCRIPT : DBPFEntry
	{
		// Token: 0x06000381 RID: 897 RVA: 0x000032FA File Offset: 0x000014FA
		public SCRIPT(uint typeId)
		{
			this.typeId = typeId;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0001997C File Offset: 0x00017B7C
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			if (binaryReader.ReadByte() >= 2)
			{
				int num = binaryReader.ReadInt32();
				PackageUtil.ReadString(binaryReader, num * 2);
			}
			binaryReader.ReadUInt32();
			binaryReader.ReadBytes(64);
			ushort num2 = binaryReader.ReadUInt16();
			byte[] array = binaryReader.ReadBytes((int)(num2 * 8));
			ulong num3 = 0UL;
			for (int i = 0; i < array.Length; i += 8)
			{
				num3 += BitConverter.ToUInt64(array, i);
			}
			num3 = (ulong)((long)array.Length - 1L & (long)num3);
			MemoryStream memoryStream2 = new MemoryStream();
			for (int j = 0; j < array.Length; j += 8)
			{
				byte[] array2 = new byte[512];
				if ((array[j] & 1) == 0)
				{
					binaryReader.Read(array2, 0, array2.Length);
					for (int k = 0; k < 512; k++)
					{
						byte b = array2[k];
						array2[k] ^= array[(int)((IntPtr)((long)num3))];
						num3 = (num3 + (ulong)b) % (ulong)((long)array.Length);
					}
				}
				memoryStream2.Write(array2, 0, array2.Length);
			}
			this.DecryptedData = memoryStream2.ToArray();
			memoryStream2.Dispose();
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00019AC4 File Offset: 0x00017CC4
		public override byte[] Serialize()
		{
			byte[] decryptedData = this.DecryptedData;
			int num = decryptedData.Length / 512;
			byte[] array = new byte[num * 8];
			ulong num2 = 0UL;
			for (int i = 0; i < array.Length; i += 8)
			{
				num2 += BitConverter.ToUInt64(array, i);
			}
			num2 = (ulong)((long)array.Length - 1L & (long)num2);
			MemoryStream memoryStream = new MemoryStream();
			MemoryStream memoryStream2 = new MemoryStream(decryptedData);
			for (int j = 0; j < array.Length; j += 8)
			{
				byte[] array2 = new byte[512];
				memoryStream2.Read(array2, 0, array2.Length);
				for (int k = 0; k < 512; k++)
				{
					array2[k] ^= array[(int)((IntPtr)((long)num2))];
					num2 = (num2 + (ulong)array2[k]) % (ulong)((long)array.Length);
				}
				memoryStream.Write(array2, 0, array2.Length);
			}
			byte[] buffer = memoryStream.ToArray();
			MemoryStream memoryStream3 = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream3);
			binaryWriter.Write(true);
			binaryWriter.Write(734328735);
			binaryWriter.Write(new byte[64]);
			binaryWriter.Write((short)num);
			binaryWriter.Write(array);
			binaryWriter.Write(buffer);
			memoryStream3.Dispose();
			binaryWriter.Close();
			return memoryStream3.ToArray();
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00004B46 File Offset: 0x00002D46
		public override void SaveToFile(string fileName)
		{
			FileStream fileStream = new FileStream(fileName, FileMode.Create);
			fileStream.Write(this.DecryptedData, 0, this.DecryptedData.Length);
			fileStream.Dispose();
		}

		// Token: 0x040001DC RID: 476
		public byte[] DecryptedData;
	}
}
