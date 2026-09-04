using System;
using System.Collections.Generic;
using System.IO;

namespace Package.SharedFiles.S_CLIP
{
	// Token: 0x020000CC RID: 204
	public class ActorSlotEntry
	{
		// Token: 0x06000AE4 RID: 2788 RVA: 0x0000810C File Offset: 0x0000630C
		public ActorSlotEntry()
		{
			this.entries = new List<ActorSlotEntry.Entry>();
			this.offsets = new List<int>();
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x000342F8 File Offset: 0x000324F8
		public void UnSerialize(BinaryReader r)
		{
			this.pad = r.ReadUInt32();
			this.count2 = r.ReadInt32();
			for (int i = 0; i < this.count2; i++)
			{
				int item = r.ReadInt32();
				this.offsets.Add(item);
			}
			for (int j = 0; j < this.count2; j++)
			{
				ActorSlotEntry.Entry entry = new ActorSlotEntry.Entry();
				entry.index = r.ReadInt32();
				entry.actor = r.ReadBytes(512);
				entry.slot = r.ReadBytes(512);
				this.entries.Add(entry);
			}
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00034394 File Offset: 0x00032594
		public void Serialize(BinaryWriter w)
		{
			w.Write(this.pad);
			w.Write(this.count2);
			foreach (int value in this.offsets)
			{
				w.Write(value);
			}
			foreach (ActorSlotEntry.Entry entry in this.entries)
			{
				w.Write(entry.index);
				w.Write(entry.actor);
				w.Write(entry.slot);
			}
		}

		// Token: 0x04000544 RID: 1348
		private uint pad;

		// Token: 0x04000545 RID: 1349
		private int count2;

		// Token: 0x04000546 RID: 1350
		private List<int> offsets;

		// Token: 0x04000547 RID: 1351
		private List<ActorSlotEntry.Entry> entries;

		// Token: 0x020001C1 RID: 449
		private class Entry
		{
			// Token: 0x04001525 RID: 5413
			public int index;

			// Token: 0x04001526 RID: 5414
			public byte[] actor;

			// Token: 0x04001527 RID: 5415
			public byte[] slot;
		}
	}
}
