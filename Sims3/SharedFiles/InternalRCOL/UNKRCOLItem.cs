using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000CB RID: 203
	public class UNKRCOLItem : RCOLItem
	{
		// Token: 0x06000ADF RID: 2783 RVA: 0x000080CD File Offset: 0x000062CD
		public UNKRCOLItem(uint typeId)
		{
			this.typeId = typeId;
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x000080DC File Offset: 0x000062DC
		public byte[] Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x000080E4 File Offset: 0x000062E4
		public override void UnSerialize(BinaryReader reader)
		{
			this.data = reader.ReadBytes((int)reader.BaseStream.Length);
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x000080FE File Offset: 0x000062FE
		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(this.data);
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x04000542 RID: 1346
		protected uint typeId;

		// Token: 0x04000543 RID: 1347
		private byte[] data;
	}
}
