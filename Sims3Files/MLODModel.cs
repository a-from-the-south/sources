using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Package.SharedFiles;
using Package.SharedFiles.InternalRCOL;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000034 RID: 52
	public class MLODModel : RCOL
	{
		// Token: 0x0600026A RID: 618 RVA: 0x000037F4 File Offset: 0x000019F4
		public MLODModel(DBPFType type) : base(type)
		{
		}

		// Token: 0x0600026B RID: 619 RVA: 0x000037F4 File Offset: 0x000019F4
		public MLODModel(DBPFType type, VRTF vrtf) : base(type)
		{
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00004243 File Offset: 0x00002443
		public override string ToString()
		{
			return "MLOD - " + base.ToString();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00014C9C File Offset: 0x00012E9C
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

		// Token: 0x0600026E RID: 622 RVA: 0x00014D14 File Offset: 0x00012F14
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

		// Token: 0x0600026F RID: 623 RVA: 0x00004255 File Offset: 0x00002455
		public override void SaveToFile(string fileName)
		{
			FileStream fileStream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test.x", FileMode.Create);
			StreamWriter streamWriter = new StreamWriter(fileStream);
			streamWriter.Write(this.ToXFile());
			streamWriter.Close();
			fileStream.Close();
		}

		// Token: 0x02000104 RID: 260
		public class VertexFormat
		{
			// Token: 0x1700040D RID: 1037
			// (get) Token: 0x06000CDA RID: 3290 RVA: 0x0000908C File Offset: 0x0000728C
			// (set) Token: 0x06000CDB RID: 3291 RVA: 0x00009094 File Offset: 0x00007294
			public int DataType { get; set; }

			// Token: 0x1700040E RID: 1038
			// (get) Token: 0x06000CDC RID: 3292 RVA: 0x0000909D File Offset: 0x0000729D
			// (set) Token: 0x06000CDD RID: 3293 RVA: 0x000090A5 File Offset: 0x000072A5
			public int SubType { get; set; }

			// Token: 0x1700040F RID: 1039
			// (get) Token: 0x06000CDE RID: 3294 RVA: 0x000090AE File Offset: 0x000072AE
			// (set) Token: 0x06000CDF RID: 3295 RVA: 0x000090B6 File Offset: 0x000072B6
			public byte BytesPerElement { get; set; }

			// Token: 0x06000CE0 RID: 3296 RVA: 0x000090BF File Offset: 0x000072BF
			public void Unserialize(BinaryReader r)
			{
				this.DataType = r.ReadInt32();
				this.SubType = r.ReadInt32();
				this.BytesPerElement = r.ReadByte();
			}

			// Token: 0x06000CE1 RID: 3297 RVA: 0x000090E5 File Offset: 0x000072E5
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.DataType);
				w.Write(this.SubType);
				w.Write(this.BytesPerElement);
			}
		}
	}
}
