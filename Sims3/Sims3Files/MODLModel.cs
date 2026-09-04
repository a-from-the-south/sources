using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Package.SharedFiles;
using Package.SharedFiles.InternalRCOL;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000038 RID: 56
	public class MODLModel : RCOL
	{
		// Token: 0x0600030F RID: 783 RVA: 0x000037F4 File Offset: 0x000019F4
		public MODLModel(DBPFType type) : base(type)
		{
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000037F4 File Offset: 0x000019F4
		public MODLModel(DBPFType type, VRTF vrtf) : base(type)
		{
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00004793 File Offset: 0x00002993
		public override string ToString()
		{
			return "MODL - " + base.ToString();
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00014C9C File Offset: 0x00012E9C
		public List<MLOD> GetMLODS()
		{
			List<MLOD> list = new List<MLOD>();
			foreach (RCOLItem rcolitem in this.entries)
			{
				if (rcolitem.GetType().Equals(typeof(MLOD)))
				{
					list.Add(rcolitem as MLOD);
				}
			}
			return list;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00016D14 File Offset: 0x00014F14
		public string ToXFile()
		{
			StringWriter stringWriter = new StringWriter();
			stringWriter.WriteLine("xof 0303txt 0032");
			stringWriter.WriteLine();
			foreach (MLOD mlod in this.GetMLODS())
			{
				foreach (MLOD.MLODEntry mlodentry in mlod.Entries)
				{
					VBUF vbuf = this.entries[mlodentry.VBUFIndex] as VBUF;
					IBUF ibuf = this.entries[mlodentry.IBUFIndex] as IBUF;
					VRTF vrtf = this.entries[mlodentry.VRTFIndex] as VRTF;
					if (vrtf == null)
					{
						vrtf = VRTF.GetDefaultForLength(16);
					}
					if (vrtf != null && vbuf != null && ibuf != null)
					{
						stringWriter.WriteLine("Mesh {");
						stringWriter.WriteLine(" " + mlodentry.VertexCount.ToString() + ";");
						for (int i = 0; i < mlodentry.VertexCount; i++)
						{
							StreamVector4 position = vbuf.GetPosition(vrtf, i, mlodentry.VBUFOffset, 0, null);
							stringWriter.Write(string.Concat(new string[]
							{
								" ",
								position.X.ToString("N6", CultureInfo.InvariantCulture),
								";",
								position.Y.ToString("N6", CultureInfo.InvariantCulture),
								";",
								position.Z.ToString("N6", CultureInfo.InvariantCulture),
								";"
							}));
							if (i == mlodentry.VertexCount - 1)
							{
								stringWriter.WriteLine(";");
							}
							else
							{
								stringWriter.WriteLine(",");
							}
						}
						stringWriter.WriteLine(" " + mlodentry.FaceCount.ToString() + ";");
						for (int j = 0; j < mlodentry.FaceCount; j++)
						{
							stringWriter.Write(" 3;");
							checked
							{
								stringWriter.Write(ibuf.Index[(int)((IntPtr)(unchecked((long)(j * 3) + mlodentry.IBUFOffset)))].ToString() + ",");
								stringWriter.Write(ibuf.Index[(int)((IntPtr)(unchecked((long)(j * 3) + mlodentry.IBUFOffset + 1L)))].ToString() + ",");
								stringWriter.Write(ibuf.Index[(int)((IntPtr)(unchecked((long)(j * 3) + mlodentry.IBUFOffset + 2L)))].ToString() + ";");
							}
							if (j == mlodentry.FaceCount - 1)
							{
								stringWriter.WriteLine(";");
							}
							else
							{
								stringWriter.WriteLine(",");
							}
						}
						stringWriter.WriteLine("");
						if (vrtf.HasNormals)
						{
							stringWriter.WriteLine(" MeshNormals {");
							stringWriter.WriteLine(" " + mlodentry.VertexCount.ToString() + ";");
							for (int k = 0; k < mlodentry.VertexCount; k++)
							{
								StreamVector4 normal = vbuf.GetNormal(vrtf, k, mlodentry.VBUFOffset, 0);
								if (normal != null)
								{
									stringWriter.Write(string.Concat(new string[]
									{
										" ",
										normal.X.ToString("N6", CultureInfo.InvariantCulture),
										";",
										normal.Y.ToString("N6", CultureInfo.InvariantCulture),
										";",
										normal.Z.ToString("N6", CultureInfo.InvariantCulture),
										";"
									}));
									if (k == mlodentry.VertexCount - 1)
									{
										stringWriter.WriteLine(";");
									}
									else
									{
										stringWriter.WriteLine(",");
									}
								}
							}
							stringWriter.WriteLine(" " + mlodentry.FaceCount.ToString() + ";");
							for (int l = 0; l < mlodentry.FaceCount; l++)
							{
								stringWriter.Write(" 3;");
								checked
								{
									stringWriter.Write(ibuf.Index[(int)((IntPtr)(unchecked((long)(l * 3) + mlodentry.IBUFOffset)))].ToString() + ",");
									stringWriter.Write(ibuf.Index[(int)((IntPtr)(unchecked((long)(l * 3) + mlodentry.IBUFOffset + 1L)))].ToString() + ",");
									stringWriter.Write(ibuf.Index[(int)((IntPtr)(unchecked((long)(l * 3) + mlodentry.IBUFOffset + 2L)))].ToString() + ";");
								}
								if (l == mlodentry.FaceCount - 1)
								{
									stringWriter.WriteLine(";");
								}
								else
								{
									stringWriter.WriteLine(",");
								}
							}
							stringWriter.WriteLine(" }");
							stringWriter.WriteLine();
						}
						stringWriter.WriteLine("}");
						stringWriter.WriteLine();
					}
				}
			}
			return stringWriter.ToString();
		}

		// Token: 0x06000314 RID: 788 RVA: 0x000047A5 File Offset: 0x000029A5
		public override void SaveToFile(string fileName)
		{
			FileStream fileStream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test.x", FileMode.Create);
			StreamWriter streamWriter = new StreamWriter(fileStream);
			streamWriter.Write(this.ToXFile());
			streamWriter.Close();
			fileStream.Close();
		}

		// Token: 0x0200010D RID: 269
		public class VertexFormat
		{
			// Token: 0x17000421 RID: 1057
			// (get) Token: 0x06000D16 RID: 3350 RVA: 0x00009266 File Offset: 0x00007466
			// (set) Token: 0x06000D17 RID: 3351 RVA: 0x0000926E File Offset: 0x0000746E
			public int DataType { get; set; }

			// Token: 0x17000422 RID: 1058
			// (get) Token: 0x06000D18 RID: 3352 RVA: 0x00009277 File Offset: 0x00007477
			// (set) Token: 0x06000D19 RID: 3353 RVA: 0x0000927F File Offset: 0x0000747F
			public int SubType { get; set; }

			// Token: 0x17000423 RID: 1059
			// (get) Token: 0x06000D1A RID: 3354 RVA: 0x00009288 File Offset: 0x00007488
			// (set) Token: 0x06000D1B RID: 3355 RVA: 0x00009290 File Offset: 0x00007490
			public byte BytesPerElement { get; set; }

			// Token: 0x06000D1C RID: 3356 RVA: 0x00009299 File Offset: 0x00007499
			public void Unserialize(BinaryReader r)
			{
				this.DataType = r.ReadInt32();
				this.SubType = r.ReadInt32();
				this.BytesPerElement = r.ReadByte();
			}

			// Token: 0x06000D1D RID: 3357 RVA: 0x000092BF File Offset: 0x000074BF
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.DataType);
				w.Write(this.SubType);
				w.Write(this.BytesPerElement);
			}
		}
	}
}
