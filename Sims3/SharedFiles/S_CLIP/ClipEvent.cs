using System;
using System.Collections.Generic;
using System.IO;

namespace Package.SharedFiles.S_CLIP
{
	// Token: 0x020000CD RID: 205
	public class ClipEvent
	{
		// Token: 0x06000AE7 RID: 2791 RVA: 0x0000812A File Offset: 0x0000632A
		public ClipEvent()
		{
			this.entries = new List<ClipEvent.Entry>();
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x00034460 File Offset: 0x00032660
		public void UnSerialize(BinaryReader r)
		{
			this.identifier = r.ReadUInt32();
			this.version = r.ReadUInt32();
			this.count = r.ReadUInt32();
			this.endoffset = r.ReadUInt32();
			this.startoffset = r.ReadUInt32();
			int num = 0;
			while ((long)num < (long)((ulong)this.count))
			{
				ClipEvent.Entry entry = new ClipEvent.Entry();
				entry.UnSerialize(r);
				this.entries.Add(entry);
				num++;
			}
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x000344D8 File Offset: 0x000326D8
		public void Serialize(BinaryWriter w)
		{
			w.Write(this.identifier);
			w.Write(this.version);
			w.Write(this.count);
			w.Write(this.endoffset);
			w.Write(this.startoffset);
			foreach (ClipEvent.Entry entry in this.entries)
			{
				entry.Serialize(w);
			}
		}

		// Token: 0x04000548 RID: 1352
		private uint identifier;

		// Token: 0x04000549 RID: 1353
		private uint version;

		// Token: 0x0400054A RID: 1354
		private uint count;

		// Token: 0x0400054B RID: 1355
		private uint endoffset;

		// Token: 0x0400054C RID: 1356
		private uint startoffset;

		// Token: 0x0400054D RID: 1357
		private List<ClipEvent.Entry> entries;

		// Token: 0x020001C2 RID: 450
		private class Entry
		{
			// Token: 0x060010F1 RID: 4337 RVA: 0x00046200 File Offset: 0x00044400
			public void UnSerialize(BinaryReader r)
			{
				this.eventType = r.ReadInt16();
				this.unknown = r.ReadInt16();
				this.id = r.ReadUInt32();
				this.timecode = r.ReadSingle();
				this.unkFloat1 = r.ReadSingle();
				this.unkFloat2 = r.ReadSingle();
				this.unknown2 = r.ReadUInt32();
				this.length = r.ReadUInt32();
				int num = 0;
				while ((long)num < (long)((ulong)this.length))
				{
					this.eventName += ((char)r.ReadByte()).ToString();
					num++;
				}
				this.eventName += ((char)r.ReadByte()).ToString();
				double num2 = Math.Ceiling((double)((float)r.BaseStream.Position / 4f)) * 4.0;
				r.BaseStream.Position = (long)num2;
				switch (this.eventType)
				{
				case 1:
					this.theEvent = new ClipEvent.Entry.Event1();
					this.theEvent.UnSerialize(r);
					return;
				case 2:
					this.theEvent = new ClipEvent.Entry.Event2();
					this.theEvent.UnSerialize(r);
					return;
				case 3:
					this.theEvent = new ClipEvent.Entry.Event3();
					this.theEvent.UnSerialize(r);
					return;
				case 4:
					this.theEvent = new ClipEvent.Entry.Event4();
					this.theEvent.UnSerialize(r);
					return;
				case 5:
					this.theEvent = new ClipEvent.Entry.Event5();
					this.theEvent.UnSerialize(r);
					return;
				case 6:
					this.theEvent = new ClipEvent.Entry.Event6();
					this.theEvent.UnSerialize(r);
					return;
				case 7:
				case 8:
					break;
				case 9:
					this.theEvent = new ClipEvent.Entry.Event9();
					this.theEvent.UnSerialize(r);
					return;
				case 10:
					this.theEvent = new ClipEvent.Entry.Event10();
					this.theEvent.UnSerialize(r);
					break;
				default:
					return;
				}
			}

			// Token: 0x060010F2 RID: 4338 RVA: 0x000463E8 File Offset: 0x000445E8
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.eventType);
				w.Write(this.unknown);
				w.Write(this.id);
				w.Write(this.timecode);
				w.Write(this.unkFloat1);
				w.Write(this.unkFloat2);
				w.Write(this.unknown2);
				w.Write(this.length);
				int num = 0;
				while ((long)num < (long)((ulong)this.length))
				{
					w.Write((byte)this.eventName[num]);
					num++;
				}
				w.Write(0);
				long num2 = (long)(Math.Ceiling((double)((float)w.BaseStream.Position / 4f)) * 4.0) - w.BaseStream.Position;
				int num3 = 0;
				while ((long)num3 < num2)
				{
					w.Write(0);
					num3++;
				}
				this.theEvent.Serialize(w);
			}

			// Token: 0x04001528 RID: 5416
			public short eventType;

			// Token: 0x04001529 RID: 5417
			public short unknown;

			// Token: 0x0400152A RID: 5418
			public uint id;

			// Token: 0x0400152B RID: 5419
			public float timecode;

			// Token: 0x0400152C RID: 5420
			public float unkFloat1;

			// Token: 0x0400152D RID: 5421
			public float unkFloat2;

			// Token: 0x0400152E RID: 5422
			public uint unknown2;

			// Token: 0x0400152F RID: 5423
			public uint length;

			// Token: 0x04001530 RID: 5424
			public string eventName;

			// Token: 0x04001531 RID: 5425
			public ClipEvent.Entry.Event theEvent;

			// Token: 0x020001DD RID: 477
			public abstract class Event
			{
				// Token: 0x06001163 RID: 4451
				public abstract void UnSerialize(BinaryReader r);

				// Token: 0x06001164 RID: 4452
				public abstract void Serialize(BinaryWriter w);
			}

			// Token: 0x020001DE RID: 478
			public class Event1 : ClipEvent.Entry.Event
			{
				// Token: 0x06001166 RID: 4454 RVA: 0x0000BC6C File Offset: 0x00009E6C
				public override void UnSerialize(BinaryReader r)
				{
					this.propActorName = r.ReadUInt32();
					this.objectActorName = r.ReadUInt32();
					this.slotName = r.ReadUInt32();
					this.blank = r.ReadUInt32();
				}

				// Token: 0x06001167 RID: 4455 RVA: 0x0000BC9E File Offset: 0x00009E9E
				public override void Serialize(BinaryWriter w)
				{
					w.Write(this.propActorName);
					w.Write(this.objectActorName);
					w.Write(this.slotName);
					w.Write(this.blank);
				}

				// Token: 0x0400260B RID: 9739
				public uint propActorName;

				// Token: 0x0400260C RID: 9740
				public uint objectActorName;

				// Token: 0x0400260D RID: 9741
				public uint slotName;

				// Token: 0x0400260E RID: 9742
				public uint blank;
			}

			// Token: 0x020001DF RID: 479
			public class Event2 : ClipEvent.Entry.Event
			{
				// Token: 0x06001169 RID: 4457 RVA: 0x0000BCD8 File Offset: 0x00009ED8
				public override void UnSerialize(BinaryReader r)
				{
					this.hash = r.ReadUInt32();
				}

				// Token: 0x0600116A RID: 4458 RVA: 0x0000BCE6 File Offset: 0x00009EE6
				public override void Serialize(BinaryWriter w)
				{
					w.Write(this.hash);
				}

				// Token: 0x0400260F RID: 9743
				public uint hash;
			}

			// Token: 0x020001E0 RID: 480
			public class Event3 : ClipEvent.Entry.Event
			{
				// Token: 0x0600116C RID: 4460 RVA: 0x0000BCF4 File Offset: 0x00009EF4
				public override void UnSerialize(BinaryReader r)
				{
					this.bytes = r.ReadBytes(128);
				}

				// Token: 0x0600116D RID: 4461 RVA: 0x0000BD07 File Offset: 0x00009F07
				public override void Serialize(BinaryWriter w)
				{
					w.Write(this.bytes);
				}

				// Token: 0x04002610 RID: 9744
				public byte[] bytes;
			}

			// Token: 0x020001E1 RID: 481
			public class Event4 : ClipEvent.Entry.Event
			{
				// Token: 0x0600116F RID: 4463 RVA: 0x000032EA File Offset: 0x000014EA
				public override void UnSerialize(BinaryReader r)
				{
				}

				// Token: 0x06001170 RID: 4464 RVA: 0x000032EA File Offset: 0x000014EA
				public override void Serialize(BinaryWriter w)
				{
				}
			}

			// Token: 0x020001E2 RID: 482
			public class Event5 : ClipEvent.Entry.Event
			{
				// Token: 0x06001172 RID: 4466 RVA: 0x00047BE0 File Offset: 0x00045DE0
				public override void UnSerialize(BinaryReader r)
				{
					this.unkWord1 = r.ReadUInt32();
					this.unkWord2 = r.ReadUInt32();
					this.effectName = r.ReadUInt32();
					this.actorName = r.ReadUInt32();
					this.slotEffectName = r.ReadUInt32();
					this.anotherHash = r.ReadUInt32();
				}

				// Token: 0x06001173 RID: 4467 RVA: 0x00047C38 File Offset: 0x00045E38
				public override void Serialize(BinaryWriter w)
				{
					w.Write(this.unkWord1);
					w.Write(this.unkWord2);
					w.Write(this.effectName);
					w.Write(this.actorName);
					w.Write(this.slotEffectName);
					w.Write(this.anotherHash);
				}

				// Token: 0x04002611 RID: 9745
				public uint unkWord1;

				// Token: 0x04002612 RID: 9746
				public uint unkWord2;

				// Token: 0x04002613 RID: 9747
				public uint effectName;

				// Token: 0x04002614 RID: 9748
				public uint actorName;

				// Token: 0x04002615 RID: 9749
				public uint slotEffectName;

				// Token: 0x04002616 RID: 9750
				public uint anotherHash;
			}

			// Token: 0x020001E3 RID: 483
			public class Event6 : ClipEvent.Entry.Event
			{
				// Token: 0x06001175 RID: 4469 RVA: 0x0000BD15 File Offset: 0x00009F15
				public override void UnSerialize(BinaryReader r)
				{
					this.aFloat = r.ReadSingle();
				}

				// Token: 0x06001176 RID: 4470 RVA: 0x0000BD23 File Offset: 0x00009F23
				public override void Serialize(BinaryWriter w)
				{
					w.Write(this.aFloat);
				}

				// Token: 0x04002617 RID: 9751
				public float aFloat;
			}

			// Token: 0x020001E4 RID: 484
			public class Event9 : ClipEvent.Entry.Event
			{
				// Token: 0x06001178 RID: 4472 RVA: 0x0000BD31 File Offset: 0x00009F31
				public override void UnSerialize(BinaryReader r)
				{
					this.hash = r.ReadUInt32();
				}

				// Token: 0x06001179 RID: 4473 RVA: 0x0000BD3F File Offset: 0x00009F3F
				public override void Serialize(BinaryWriter w)
				{
					w.Write(this.hash);
				}

				// Token: 0x04002618 RID: 9752
				public uint hash;
			}

			// Token: 0x020001E5 RID: 485
			public class Event10 : ClipEvent.Entry.Event
			{
				// Token: 0x0600117B RID: 4475 RVA: 0x0000BD4D File Offset: 0x00009F4D
				public override void UnSerialize(BinaryReader r)
				{
					this.hash = r.ReadUInt32();
					this.blank = r.ReadUInt32();
				}

				// Token: 0x0600117C RID: 4476 RVA: 0x0000BD67 File Offset: 0x00009F67
				public override void Serialize(BinaryWriter w)
				{
					w.Write(this.hash);
					w.Write(this.blank);
				}

				// Token: 0x04002619 RID: 9753
				public uint hash;

				// Token: 0x0400261A RID: 9754
				public uint blank;
			}
		}
	}
}
