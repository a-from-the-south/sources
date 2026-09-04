using System;
using System.IO;

namespace Package
{
	// Token: 0x02000002 RID: 2
	public class BinaryReaderBE : BinaryReader
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002E54 File Offset: 0x00001054
		public BinaryReaderBE(Stream stream) : base(stream)
		{
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002E81 File Offset: 0x00001081
		public override int ReadInt32()
		{
			this.a32 = base.ReadBytes(4);
			Array.Reverse(this.a32);
			return BitConverter.ToInt32(this.a32, 0);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002EA7 File Offset: 0x000010A7
		public override short ReadInt16()
		{
			this.a16 = base.ReadBytes(2);
			Array.Reverse(this.a16);
			return BitConverter.ToInt16(this.a16, 0);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002ECD File Offset: 0x000010CD
		public override ushort ReadUInt16()
		{
			this.a16 = base.ReadBytes(2);
			Array.Reverse(this.a16);
			return BitConverter.ToUInt16(this.a16, 0);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002EF3 File Offset: 0x000010F3
		public override long ReadInt64()
		{
			this.a64 = base.ReadBytes(8);
			Array.Reverse(this.a64);
			return BitConverter.ToInt64(this.a64, 0);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002F19 File Offset: 0x00001119
		public override uint ReadUInt32()
		{
			this.a32 = base.ReadBytes(4);
			Array.Reverse(this.a32);
			return BitConverter.ToUInt32(this.a32, 0);
		}

		// Token: 0x04000001 RID: 1
		private byte[] a16 = new byte[2];

		// Token: 0x04000002 RID: 2
		private byte[] a32 = new byte[4];

		// Token: 0x04000003 RID: 3
		private byte[] a64 = new byte[8];
	}
}
