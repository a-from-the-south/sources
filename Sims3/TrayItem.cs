using System;
using System.IO;

namespace Package
{
	// Token: 0x0200000F RID: 15
	public class TrayItem
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x0000FB2C File Offset: 0x0000DD2C
		public TrayItem(string filename)
		{
			BinaryReader binaryReader = new BinaryReader(new FileStream(filename, FileMode.Open));
			binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			binaryReader.ReadByte();
			binaryReader.ReadInt64();
			binaryReader.ReadBytes(21);
			PackageUtil.ReadString(binaryReader, (int)binaryReader.ReadByte());
			binaryReader.ReadBytes(9);
			PackageUtil.ReadString(binaryReader, (int)binaryReader.ReadByte());
			binaryReader.ReadBytes(18);
			byte count = binaryReader.ReadByte();
			binaryReader.ReadBytes((int)count);
			binaryReader.ReadByte();
			PackageUtil.ReadString(binaryReader, (int)binaryReader.ReadByte());
			binaryReader.ReadByte();
			PackageUtil.ReadString(binaryReader, (int)binaryReader.ReadByte());
			binaryReader.ReadByte();
			binaryReader.ReadBytes(26);
			binaryReader.ReadByte();
			PackageUtil.ReadString(binaryReader, (int)binaryReader.ReadByte());
			binaryReader.ReadByte();
			binaryReader.ReadBytes(5);
			binaryReader.ReadByte();
			PackageUtil.ReadString(binaryReader, (int)binaryReader.ReadByte());
			binaryReader.ReadByte();
			binaryReader.ReadBytes(26);
			binaryReader.BaseStream.Close();
			binaryReader.Close();
		}
	}
}
