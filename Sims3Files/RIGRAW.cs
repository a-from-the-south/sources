using System;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000041 RID: 65
	public class RIGRAW : DBPFEntry
	{
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000370 RID: 880 RVA: 0x00004AF9 File Offset: 0x00002CF9
		public byte[] GrannyData
		{
			get
			{
				return this._grannyData;
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00004B01 File Offset: 0x00002D01
		public RIGRAW()
		{
			this.typeId = 2393838559U;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00004B14 File Offset: 0x00002D14
		public override void UnSerialize()
		{
			this._grannyData = this.data;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00004AF9 File Offset: 0x00002CF9
		public override byte[] Serialize()
		{
			return this._grannyData;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00004AF9 File Offset: 0x00002CF9
		public byte[] GetGrannyData()
		{
			return this._grannyData;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00004B22 File Offset: 0x00002D22
		public void SetGrannyData(byte[] data)
		{
			this._grannyData = data;
		}

		// Token: 0x040001B4 RID: 436
		private byte[] _grannyData;
	}
}
