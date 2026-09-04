using System;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000BE RID: 190
	public class IBUF : RCOLItem, ICloneable
	{
		// Token: 0x17000359 RID: 857
		// (get) Token: 0x060009EC RID: 2540 RVA: 0x00007A0C File Offset: 0x00005C0C
		// (set) Token: 0x060009ED RID: 2541 RVA: 0x00007A14 File Offset: 0x00005C14
		[TypeConverter(typeof(IntTypeConverter))]
		public int Type { get; set; }

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x060009EE RID: 2542 RVA: 0x00007A1D File Offset: 0x00005C1D
		// (set) Token: 0x060009EF RID: 2543 RVA: 0x00007A25 File Offset: 0x00005C25
		[TypeConverter(typeof(IntTypeConverter))]
		public int Version { get; set; }

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x060009F0 RID: 2544 RVA: 0x00007A2E File Offset: 0x00005C2E
		// (set) Token: 0x060009F1 RID: 2545 RVA: 0x00007A36 File Offset: 0x00005C36
		[TypeConverter(typeof(IntTypeConverter))]
		public int AlwaysZero { get; set; }

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x00007A3F File Offset: 0x00005C3F
		// (set) Token: 0x060009F3 RID: 2547 RVA: 0x00007A47 File Offset: 0x00005C47
		public short[] Index { get; set; }

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x060009F4 RID: 2548 RVA: 0x00007A50 File Offset: 0x00005C50
		// (set) Token: 0x060009F5 RID: 2549 RVA: 0x00007A58 File Offset: 0x00005C58
		public IBUF.IBUFFlags Flags
		{
			get
			{
				return (IBUF.IBUFFlags)this._flags;
			}
			set
			{
				this._flags = (int)value;
			}
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x0002F7C0 File Offset: 0x0002D9C0
		public override string ToString()
		{
			return "Index Buffer " + this.Index.Length.ToString() + " indicies";
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x0002F7EC File Offset: 0x0002D9EC
		public override void UnSerialize(BinaryReader reader)
		{
			this.Type = reader.ReadInt32();
			this.Version = reader.ReadInt32();
			this._flags = reader.ReadInt32();
			this.AlwaysZero = reader.ReadInt32();
			int num = (int)((reader.BaseStream.Length - 16L) / 2L);
			this.Index = new short[num];
			for (int i = 0; i < num; i++)
			{
				short num2 = reader.ReadInt16();
				if (((long)this._flags & 1L) != 0L)
				{
					if (i > 0)
					{
						this.Index[i] = this.Index[i - 1] + num2;
					}
					else
					{
						this.Index[i] = num2;
					}
				}
				else
				{
					this.Index[i] = num2;
				}
			}
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0002F8AC File Offset: 0x0002DAAC
		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(this.Type);
			writer.Write(this.Version);
			writer.Write(this._flags);
			writer.Write(this.AlwaysZero);
			short num = 0;
			for (int i = 0; i < this.Index.Length; i++)
			{
				if (((long)this._flags & 1L) != 0L)
				{
					short value = this.Index[i] - num;
					writer.Write(value);
					num = this.Index[i];
				}
				else
				{
					writer.Write(this.Index[i]);
				}
			}
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0002F940 File Offset: 0x0002DB40
		public object CloneFromIndexAndVRTF(long offset, int numFaces, VRTF format)
		{
			IBUF ibuf = new IBUF();
			ibuf.Type = this.Type;
			ibuf.Version = this.Version;
			ibuf.Flags = this.Flags;
			ibuf.AlwaysZero = this.AlwaysZero;
			ibuf.Index = new short[numFaces * 3];
			Array.Copy(this.Index, offset, ibuf.Index, 0L, (long)(numFaces * 3));
			return ibuf;
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x0002F9B4 File Offset: 0x0002DBB4
		public object Clone()
		{
			IBUF ibuf = new IBUF();
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			this.Serialize(binaryWriter);
			MemoryStream memoryStream2 = new MemoryStream(memoryStream.ToArray());
			BinaryReader binaryReader = new BinaryReader(memoryStream2);
			ibuf.UnSerialize(binaryReader);
			memoryStream.Dispose();
			memoryStream2.Dispose();
			binaryWriter.Close();
			binaryReader.Close();
			return ibuf;
		}

		// Token: 0x040004CF RID: 1231
		private int _flags;

		// Token: 0x020001AF RID: 431
		[Flags]
		public enum IBUFFlags : uint
		{
			// Token: 0x04000D13 RID: 3347
			DifferencedIndicies = 1U,
			// Token: 0x04000D14 RID: 3348
			Is32BitIndicies = 2U,
			// Token: 0x04000D15 RID: 3349
			DisplayList = 4U
		}
	}
}
