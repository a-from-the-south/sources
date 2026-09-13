using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns16;

namespace ns12
{
	// Token: 0x02000187 RID: 391
	internal sealed class Class178
	{
		// Token: 0x060011F1 RID: 4593 RVA: 0x000BEB70 File Offset: 0x000BCD70
		public Class178(Stream s)
		{
			using (BinaryReader binaryReader = new BinaryReader(s))
			{
				Class178.Struct18 @struct = default(Class178.Struct18);
				@struct.method_0(binaryReader);
				if (@struct.short_0 == 0)
				{
					if (@struct.short_1 == 1)
					{
						Class178.Struct19 struct2 = default(Class178.Struct19);
						this.struct23_0 = new Struct23[checked((uint)(unchecked((int)@struct.ushort_0)))];
						this.hashtable_0 = new Hashtable();
						this.hashtable_1 = new Hashtable();
						for (int i = 0; i < (int)@struct.ushort_0; i++)
						{
							struct2.method_0(binaryReader);
							this.struct23_0[i] = new Struct23(new Size((int)struct2.byte_0, (int)struct2.byte_1), this.method_0((int)(struct2.short_1 * struct2.short_0)));
							long position = s.Position;
							s.Position = (long)struct2.int_1;
							byte[] array = new byte[checked((uint)struct2.int_0)];
							s.Read(array, 0, struct2.int_0);
							this.hashtable_0[this.struct23_0[i]] = array;
							this.hashtable_1[this.struct23_0[i]] = struct2;
							s.Position = position;
						}
						return;
					}
				}
				throw new Exception("The specified stream did not contain a valid icon.");
			}
		}

		// Token: 0x060011F2 RID: 4594 RVA: 0x000BED00 File Offset: 0x000BCF00
		private ColorDepth method_0(int int_0)
		{
			if (int_0 <= 8)
			{
				if (int_0 == 4)
				{
					return ColorDepth.Depth4Bit;
				}
				if (int_0 == 8)
				{
					return ColorDepth.Depth8Bit;
				}
			}
			else
			{
				if (int_0 == 16)
				{
					return ColorDepth.Depth16Bit;
				}
				if (int_0 == 24)
				{
					return ColorDepth.Depth24Bit;
				}
				if (int_0 == 32)
				{
					return ColorDepth.Depth32Bit;
				}
			}
			return ColorDepth.Depth4Bit;
		}

		// Token: 0x060011F3 RID: 4595 RVA: 0x000BED48 File Offset: 0x000BCF48
		public Icon method_1(Struct23 struct23_1)
		{
			byte[] array = (byte[])this.hashtable_0[struct23_1];
			Icon result = null;
			if (array != null)
			{
				Stream stream = new MemoryStream();
				BinaryWriter binaryWriter_ = new BinaryWriter(stream);
				Class178.Struct18 @struct = default(Class178.Struct18);
				@struct.ushort_0 = 1;
				@struct.short_1 = 1;
				@struct.method_1(binaryWriter_);
				Class178.Struct19 struct2 = (Class178.Struct19)this.hashtable_1[struct23_1];
				struct2.int_1 = Marshal.SizeOf(typeof(Class178.Struct18)) + Marshal.SizeOf(typeof(Class178.Struct19));
				struct2.method_1(binaryWriter_);
				stream.Write(array, 0, array.Length);
				stream.Position = 0L;
				result = new Icon(stream, (int)struct2.byte_0, (int)struct2.byte_1);
			}
			return result;
		}

		// Token: 0x060011F4 RID: 4596 RVA: 0x000BEE24 File Offset: 0x000BD024
		public Icon method_2(Size size_0)
		{
			Struct23 struct23_ = this.method_5(size_0);
			Icon result;
			if (!(struct23_.x437e3b626c0fdd43 != Size.Empty))
			{
				result = null;
			}
			else
			{
				result = this.method_1(struct23_);
			}
			return result;
		}

		// Token: 0x060011F5 RID: 4597 RVA: 0x000BEE5C File Offset: 0x000BD05C
		public Bitmap method_3(Struct23 struct23_1)
		{
			return Class178.smethod_0(this.method_1(struct23_1), struct23_1);
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x000BEE7C File Offset: 0x000BD07C
		public static Bitmap smethod_0(Icon icon_0, Struct23 struct23_1)
		{
			Bitmap bitmap = null;
			if (icon_0 != null)
			{
				if (struct23_1.x94af564f5d0fedbf == ColorDepth.Depth32Bit)
				{
					Class178.Struct20 @struct;
					Class178.GetIconInfo(icon_0.Handle, out @struct);
					Class178.Struct21 struct2 = default(Class178.Struct21);
					Class178.GetObject(@struct.intptr_1, Marshal.SizeOf(typeof(Class178.Struct21)), ref struct2);
					int num = struct2.int_3 * struct2.int_2;
					int[] array = new int[checked((uint)(num / 4))];
					Class178.GetBitmapBits(@struct.intptr_1, num, array);
					GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
					Bitmap bitmap2 = new Bitmap(struct2.int_1, struct2.int_2, struct2.int_3, PixelFormat.Format32bppArgb, Marshal.UnsafeAddrOfPinnedArrayElement(array, 0));
					bitmap = new Bitmap(bitmap2.Width, bitmap2.Height);
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
					}
					gchandle.Free();
					Class178.DeleteObject(@struct.intptr_0);
					Class178.DeleteObject(@struct.intptr_1);
				}
				else
				{
					bitmap = icon_0.ToBitmap();
				}
			}
			return bitmap;
		}

		// Token: 0x060011F7 RID: 4599 RVA: 0x000BEFB8 File Offset: 0x000BD1B8
		public Bitmap method_4(Size size_0)
		{
			Struct23 struct23_ = this.method_5(size_0);
			Bitmap result;
			if (!(struct23_.x437e3b626c0fdd43 != Size.Empty))
			{
				result = null;
			}
			else
			{
				result = this.method_3(struct23_);
			}
			return result;
		}

		// Token: 0x060011F8 RID: 4600 RVA: 0x000BEFF0 File Offset: 0x000BD1F0
		private Struct23 method_5(Size size_0)
		{
			Struct23 result = new Struct23(Size.Empty, ColorDepth.Depth4Bit);
			foreach (Struct23 @struct in this.struct23_0)
			{
				if (@struct.x437e3b626c0fdd43 == size_0 && @struct.x94af564f5d0fedbf >= result.x94af564f5d0fedbf)
				{
					result = @struct;
				}
			}
			return result;
		}

		// Token: 0x060011F9 RID: 4601 RVA: 0x000BF054 File Offset: 0x000BD254
		public Struct23[] method_6()
		{
			return (Struct23[])this.struct23_0.Clone();
		}

		// Token: 0x060011FA RID: 4602
		[DllImport("gdi32", CharSet = CharSet.Auto)]
		private static extern int GetObject(IntPtr intptr_0, int int_0, ref Class178.Struct21 struct21_0);

		// Token: 0x060011FB RID: 4603
		[DllImport("gdi32")]
		private static extern int GetBitmapBits(IntPtr intptr_0, int int_0, int[] int_1);

		// Token: 0x060011FC RID: 4604
		[DllImport("user32")]
		private static extern int GetIconInfo(IntPtr intptr_0, out Class178.Struct20 struct20_0);

		// Token: 0x060011FD RID: 4605
		[DllImport("gdi32")]
		private static extern int DeleteObject(IntPtr intptr_0);

		// Token: 0x04000C63 RID: 3171
		private Hashtable hashtable_0;

		// Token: 0x04000C64 RID: 3172
		private Hashtable hashtable_1;

		// Token: 0x04000C65 RID: 3173
		private Struct23[] struct23_0;

		// Token: 0x02000188 RID: 392
		private struct Struct18
		{
			// Token: 0x060011FE RID: 4606 RVA: 0x00009855 File Offset: 0x00007A55
			public void method_0(BinaryReader binaryReader_0)
			{
				this.short_0 = binaryReader_0.ReadInt16();
				this.short_1 = binaryReader_0.ReadInt16();
				this.ushort_0 = binaryReader_0.ReadUInt16();
			}

			// Token: 0x060011FF RID: 4607 RVA: 0x0000987D File Offset: 0x00007A7D
			public void method_1(BinaryWriter binaryWriter_0)
			{
				binaryWriter_0.Write(this.short_0);
				binaryWriter_0.Write(this.short_1);
				binaryWriter_0.Write(this.ushort_0);
			}

			// Token: 0x04000C66 RID: 3174
			public short short_0;

			// Token: 0x04000C67 RID: 3175
			public short short_1;

			// Token: 0x04000C68 RID: 3176
			public ushort ushort_0;
		}

		// Token: 0x02000189 RID: 393
		private struct Struct19
		{
			// Token: 0x06001200 RID: 4608 RVA: 0x000BF078 File Offset: 0x000BD278
			public void method_0(BinaryReader binaryReader_0)
			{
				this.byte_0 = binaryReader_0.ReadByte();
				this.byte_1 = binaryReader_0.ReadByte();
				this.byte_2 = binaryReader_0.ReadByte();
				this.byte_3 = binaryReader_0.ReadByte();
				this.short_0 = binaryReader_0.ReadInt16();
				this.short_1 = binaryReader_0.ReadInt16();
				this.int_0 = binaryReader_0.ReadInt32();
				this.int_1 = binaryReader_0.ReadInt32();
			}

			// Token: 0x06001201 RID: 4609 RVA: 0x000BF0E8 File Offset: 0x000BD2E8
			public void method_1(BinaryWriter binaryWriter_0)
			{
				binaryWriter_0.Write(this.byte_0);
				binaryWriter_0.Write(this.byte_1);
				binaryWriter_0.Write(this.byte_2);
				binaryWriter_0.Write(this.byte_3);
				binaryWriter_0.Write(this.short_0);
				binaryWriter_0.Write(this.short_1);
				binaryWriter_0.Write(this.int_0);
				binaryWriter_0.Write(this.int_1);
			}

			// Token: 0x04000C69 RID: 3177
			public byte byte_0;

			// Token: 0x04000C6A RID: 3178
			public byte byte_1;

			// Token: 0x04000C6B RID: 3179
			public byte byte_2;

			// Token: 0x04000C6C RID: 3180
			public byte byte_3;

			// Token: 0x04000C6D RID: 3181
			public short short_0;

			// Token: 0x04000C6E RID: 3182
			public short short_1;

			// Token: 0x04000C6F RID: 3183
			public int int_0;

			// Token: 0x04000C70 RID: 3184
			public int int_1;
		}

		// Token: 0x0200018A RID: 394
		private struct Struct20
		{
			// Token: 0x04000C71 RID: 3185
			public bool bool_0;

			// Token: 0x04000C72 RID: 3186
			public int int_0;

			// Token: 0x04000C73 RID: 3187
			public int int_1;

			// Token: 0x04000C74 RID: 3188
			public IntPtr intptr_0;

			// Token: 0x04000C75 RID: 3189
			public IntPtr intptr_1;
		}

		// Token: 0x0200018B RID: 395
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		private struct Struct21
		{
			// Token: 0x04000C76 RID: 3190
			public int int_0;

			// Token: 0x04000C77 RID: 3191
			public int int_1;

			// Token: 0x04000C78 RID: 3192
			public int int_2;

			// Token: 0x04000C79 RID: 3193
			public int int_3;

			// Token: 0x04000C7A RID: 3194
			public short short_0;

			// Token: 0x04000C7B RID: 3195
			public short short_1;

			// Token: 0x04000C7C RID: 3196
			public IntPtr intptr_0;
		}

		// Token: 0x0200018C RID: 396
		private struct Struct22
		{
			// Token: 0x04000C7D RID: 3197
			public uint uint_0;

			// Token: 0x04000C7E RID: 3198
			public int int_0;

			// Token: 0x04000C7F RID: 3199
			public int int_1;

			// Token: 0x04000C80 RID: 3200
			public ushort ushort_0;

			// Token: 0x04000C81 RID: 3201
			public ushort ushort_1;

			// Token: 0x04000C82 RID: 3202
			public uint uint_1;

			// Token: 0x04000C83 RID: 3203
			public uint uint_2;

			// Token: 0x04000C84 RID: 3204
			public int int_2;

			// Token: 0x04000C85 RID: 3205
			public int int_3;

			// Token: 0x04000C86 RID: 3206
			public uint uint_3;

			// Token: 0x04000C87 RID: 3207
			public uint uint_4;
		}
	}
}
