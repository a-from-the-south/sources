using System;
using System.Collections.Generic;
using System.IO;

namespace Sims3WorkshopSDK.Classes
{
	// Token: 0x02000040 RID: 64
	public class WSOFile
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000123 RID: 291 RVA: 0x0000278B File Offset: 0x0000098B
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00002793 File Offset: 0x00000993
		public List<WSOFile.WSOMesh> Meshes { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000125 RID: 293 RVA: 0x0000279C File Offset: 0x0000099C
		// (set) Token: 0x06000126 RID: 294 RVA: 0x000027A4 File Offset: 0x000009A4
		public List<WSOFile.WSOBone> Bones { get; private set; }

		// Token: 0x06000127 RID: 295 RVA: 0x000027AD File Offset: 0x000009AD
		public WSOFile()
		{
			this.pluginName = "";
			this.pluginVersion = 0;
			this.Meshes = new List<WSOFile.WSOMesh>();
			this.Bones = new List<WSOFile.WSOBone>();
			this.Version = 6;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000027E4 File Offset: 0x000009E4
		public WSOFile(int version) : this()
		{
			this.Version = version;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000048E0 File Offset: 0x00002AE0
		public void ToFile(string fileName)
		{
			byte[] buffer = this.ToArray();
			BinaryWriter binaryWriter = new BinaryWriter(new FileStream(fileName, FileMode.Create));
			binaryWriter.Write(buffer);
			binaryWriter.Close();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000490C File Offset: 0x00002B0C
		private byte[] ToArray()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.Version);
			if (this.Version >= 5)
			{
				binaryWriter.Write(this.pluginName.Length);
				for (int i = 0; i < this.pluginName.Length; i++)
				{
					binaryWriter.Write((byte)this.pluginName[i]);
				}
				binaryWriter.Write(this.pluginVersion);
			}
			binaryWriter.Write(this.Meshes.Count);
			foreach (WSOFile.WSOMesh wsomesh in this.Meshes)
			{
				binaryWriter.Write(wsomesh.Vertices.Count);
				foreach (WSOFile.WSOVertex wsovertex in wsomesh.Vertices)
				{
					binaryWriter.Write(wsovertex.X);
					binaryWriter.Write(wsovertex.Y);
					binaryWriter.Write(wsovertex.Z);
					binaryWriter.Write(wsovertex.VertexID);
					if (this.Version >= 6)
					{
						float value = (float)wsovertex.UnknownByte1 / 255f;
						float value2 = (float)wsovertex.UnknownByte2 / 255f;
						float value3 = (float)wsovertex.UnknownByte3 / 255f;
						float value4 = (float)wsovertex.UnknownByte4 / 255f;
						binaryWriter.Write(value);
						binaryWriter.Write(value2);
						binaryWriter.Write(value3);
						binaryWriter.Write(value4);
					}
					else if (this.Version >= 2)
					{
						binaryWriter.Write(wsovertex.UnknownByte1);
						binaryWriter.Write(wsovertex.UnknownByte2);
						binaryWriter.Write(wsovertex.UnknownByte3);
						binaryWriter.Write(wsovertex.UnknownByte4);
					}
					binaryWriter.Write(wsovertex.BoneAssigment1);
					binaryWriter.Write(wsovertex.BoneAssigment2);
					binaryWriter.Write(wsovertex.BoneAssigment3);
					binaryWriter.Write(wsovertex.BoneAssigment4);
					if (this.Version >= 6)
					{
						binaryWriter.Write(wsovertex.BoneWeight1);
						binaryWriter.Write(wsovertex.BoneWeight2);
						binaryWriter.Write(wsovertex.BoneWeight3);
						binaryWriter.Write(wsovertex.BoneWeight4);
					}
					else
					{
						binaryWriter.Write(wsovertex.BoneWeight1 * 100f);
						binaryWriter.Write(wsovertex.BoneWeight2 * 100f);
						binaryWriter.Write(wsovertex.BoneWeight3 * 100f);
						binaryWriter.Write(wsovertex.BoneWeight4 * 100f);
					}
				}
				binaryWriter.Write(wsomesh.Faces.Count / 3);
				foreach (WSOFile.WSOFace wsoface in wsomesh.Faces)
				{
					binaryWriter.Write(wsoface.VertexIndex);
					binaryWriter.Write(wsoface.NormalX);
					binaryWriter.Write(wsoface.NormalY);
					binaryWriter.Write(wsoface.NormalZ);
					binaryWriter.Write(wsoface.Tx[0]);
					binaryWriter.Write(wsoface.Ty[0]);
					if (this.Version >= 6)
					{
						binaryWriter.Write(wsoface.Tx.Count - 1);
						if (wsoface.Tx.Count > 1)
						{
							for (int j = 1; j < wsoface.Tx.Count; j++)
							{
								binaryWriter.Write(wsoface.Tx[j]);
							}
						}
						binaryWriter.Write(wsoface.Ty.Count - 1);
						if (wsoface.Ty.Count > 1)
						{
							for (int k = 1; k < wsoface.Ty.Count; k++)
							{
								binaryWriter.Write(wsoface.Ty[k]);
							}
						}
					}
				}
				if (this.Version >= 3)
				{
					binaryWriter.Write(wsomesh.GeoStates.Count);
					foreach (WSOFile.WSOGeoState wsogeoState in wsomesh.GeoStates)
					{
						binaryWriter.Write(wsogeoState.FaceCount);
						for (int l = 0; l < wsogeoState.FaceCount; l++)
						{
							binaryWriter.Write(wsogeoState.Indicies[l]);
							binaryWriter.Write(wsogeoState.Data[l][0]);
							binaryWriter.Write(wsogeoState.Data[l][1]);
							binaryWriter.Write(wsogeoState.Data[l][2]);
							binaryWriter.Write(wsogeoState.Data[l][3]);
							binaryWriter.Write(wsogeoState.Data[l][4]);
							binaryWriter.Write(wsogeoState.Data[l][5]);
							binaryWriter.Write(wsogeoState.Data[l][6]);
							binaryWriter.Write(wsogeoState.Data[l][7]);
						}
					}
				}
				if (this.Version >= 4)
				{
					if (this.Version >= 6)
					{
						binaryWriter.Write(wsomesh.Name.Length);
					}
					else
					{
						binaryWriter.Write((byte)wsomesh.Name.Length);
					}
					for (int m = 0; m < wsomesh.Name.Length; m++)
					{
						binaryWriter.Write((byte)wsomesh.Name[m]);
					}
				}
				if (this.Version >= 6)
				{
					binaryWriter.Write(wsomesh.Bones.Count);
					foreach (WSOFile.WSOBone wsobone in wsomesh.Bones)
					{
						binaryWriter.Write(wsobone.Name.Length);
						for (int n = 0; n < wsobone.Name.Length; n++)
						{
							binaryWriter.Write((byte)wsobone.Name[n]);
						}
					}
				}
			}
			binaryWriter.Write(this.Bones.Count);
			foreach (WSOFile.WSOBone wsobone2 in this.Bones)
			{
				if (this.Version >= 6)
				{
					binaryWriter.Write(wsobone2.Name.Length);
				}
				else
				{
					binaryWriter.Write((byte)wsobone2.Name.Length);
				}
				for (int num = 0; num < wsobone2.Name.Length; num++)
				{
					binaryWriter.Write((byte)wsobone2.Name[num]);
				}
				if (this.Version >= 2)
				{
					binaryWriter.Write(wsobone2.TranslationX);
					binaryWriter.Write(wsobone2.TranslationY);
					binaryWriter.Write(wsobone2.TranslationZ);
					binaryWriter.Write(wsobone2.RotationX);
					binaryWriter.Write(wsobone2.RotationY);
					binaryWriter.Write(wsobone2.RotationZ);
					if (this.Version >= 6)
					{
						binaryWriter.Write(wsobone2.ParentName.Length);
						for (int num2 = 0; num2 < wsobone2.ParentName.Length; num2++)
						{
							binaryWriter.Write((byte)wsobone2.ParentName[num2]);
						}
					}
				}
			}
			byte[] result = memoryStream.ToArray();
			memoryStream.Dispose();
			return result;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00005124 File Offset: 0x00003324
		public WSOFile.WSOMesh AddMesh()
		{
			WSOFile.WSOMesh wsomesh = new WSOFile.WSOMesh(this);
			this.Meshes.Add(wsomesh);
			return wsomesh;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00005148 File Offset: 0x00003348
		public WSOFile.WSOBone AddBone()
		{
			WSOFile.WSOBone wsobone = new WSOFile.WSOBone(null);
			this.Bones.Add(wsobone);
			return wsobone;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000516C File Offset: 0x0000336C
		public void OpenFromFile(string fileName)
		{
			FileStream fileStream = new FileStream(fileName, FileMode.Open);
			this.FromStream(fileStream);
			fileStream.Close();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00005190 File Offset: 0x00003390
		public void FromStream(Stream stream)
		{
			BinaryReader binaryReader = null;
			try
			{
				binaryReader = new BinaryReader(stream);
				this.Version = binaryReader.ReadInt32();
				if (this.Version >= 5)
				{
					int num = binaryReader.ReadInt32();
					this.pluginName = "";
					for (int i = 0; i < num; i++)
					{
						this.pluginName += binaryReader.ReadChar().ToString();
					}
					this.pluginVersion = binaryReader.ReadInt32();
				}
				int num2 = binaryReader.ReadInt32();
				for (int j = 0; j < num2; j++)
				{
					WSOFile.WSOMesh wsomesh = this.AddMesh();
					int num3 = binaryReader.ReadInt32();
					for (int k = 0; k < num3; k++)
					{
						WSOFile.WSOVertex wsovertex = wsomesh.AddVertex();
						wsovertex.X = binaryReader.ReadSingle();
						wsovertex.Y = binaryReader.ReadSingle();
						wsovertex.Z = binaryReader.ReadSingle();
						wsovertex.VertexID = binaryReader.ReadInt32();
						if (this.Version >= 2)
						{
							if (this.Version >= 6)
							{
								float num4 = binaryReader.ReadSingle();
								float num5 = binaryReader.ReadSingle();
								float num6 = binaryReader.ReadSingle();
								float num7 = binaryReader.ReadSingle();
								wsovertex.UnknownByte1 = (byte)(255.0 * (double)num4);
								wsovertex.UnknownByte2 = (byte)(255.0 * (double)num5);
								wsovertex.UnknownByte3 = (byte)(255.0 * (double)num6);
								wsovertex.UnknownByte4 = (byte)(255.0 * (double)num7);
							}
							else
							{
								wsovertex.UnknownByte1 = binaryReader.ReadByte();
								wsovertex.UnknownByte2 = binaryReader.ReadByte();
								wsovertex.UnknownByte3 = binaryReader.ReadByte();
								wsovertex.UnknownByte4 = binaryReader.ReadByte();
							}
						}
						wsovertex.BoneAssigment1 = binaryReader.ReadInt32();
						wsovertex.BoneAssigment2 = binaryReader.ReadInt32();
						wsovertex.BoneAssigment3 = binaryReader.ReadInt32();
						wsovertex.BoneAssigment4 = binaryReader.ReadInt32();
						wsovertex.BoneWeight1 = binaryReader.ReadSingle();
						wsovertex.BoneWeight2 = binaryReader.ReadSingle();
						wsovertex.BoneWeight3 = binaryReader.ReadSingle();
						wsovertex.BoneWeight4 = binaryReader.ReadSingle();
						if (this.Version < 6)
						{
							wsovertex.BoneWeight1 /= 100f;
							wsovertex.BoneWeight2 /= 100f;
							wsovertex.BoneWeight3 /= 100f;
							wsovertex.BoneWeight4 /= 100f;
						}
					}
					int num8 = binaryReader.ReadInt32();
					for (int l = 0; l < num8 * 3; l++)
					{
						WSOFile.WSOFace wsoface = wsomesh.AddFace();
						wsoface.VertexIndex = binaryReader.ReadInt16();
						wsoface.NormalX = binaryReader.ReadSingle();
						wsoface.NormalY = binaryReader.ReadSingle();
						wsoface.NormalZ = binaryReader.ReadSingle();
						wsoface.Tx.Add(binaryReader.ReadSingle());
						wsoface.Ty.Add(binaryReader.ReadSingle());
						if (this.Version >= 6)
						{
							int num9 = binaryReader.ReadInt32();
							while (num9-- > 0)
							{
								wsoface.Tx.Add(binaryReader.ReadSingle());
							}
							int num10 = binaryReader.ReadInt32();
							while (num10-- > 0)
							{
								wsoface.Ty.Add(binaryReader.ReadSingle());
							}
						}
					}
					if (this.Version >= 3)
					{
						int num11 = binaryReader.ReadInt32();
						for (int m = 0; m < num11; m++)
						{
							WSOFile.WSOGeoState wsogeoState = new WSOFile.WSOGeoState();
							wsogeoState.FaceCount = binaryReader.ReadInt32();
							wsogeoState.Indicies = new short[wsogeoState.FaceCount];
							wsogeoState.Data = new float[wsogeoState.FaceCount][];
							for (int n = 0; n < wsogeoState.FaceCount; n++)
							{
								wsogeoState.Indicies[n] = binaryReader.ReadInt16();
								wsogeoState.Data[n] = new float[8];
								wsogeoState.Data[n][0] = binaryReader.ReadSingle();
								wsogeoState.Data[n][1] = binaryReader.ReadSingle();
								wsogeoState.Data[n][2] = binaryReader.ReadSingle();
								wsogeoState.Data[n][3] = binaryReader.ReadSingle();
								wsogeoState.Data[n][4] = binaryReader.ReadSingle();
								wsogeoState.Data[n][5] = binaryReader.ReadSingle();
								wsogeoState.Data[n][6] = binaryReader.ReadSingle();
								wsogeoState.Data[n][7] = binaryReader.ReadSingle();
							}
							wsomesh.GeoStates.Add(wsogeoState);
						}
					}
					if (this.Version >= 4)
					{
						wsomesh.Name = this.ReadString(binaryReader, (this.Version >= 6) ? binaryReader.ReadInt32() : ((int)binaryReader.ReadByte()));
					}
					if (this.Version >= 6)
					{
						int num12 = binaryReader.ReadInt32();
						while (num12-- > 0)
						{
							WSOFile.WSOBone wsobone = wsomesh.AddBone();
							wsobone.Name = this.ReadString(binaryReader, binaryReader.ReadInt32());
							wsobone.Hash = FNV32.GetHash(wsobone.Name);
						}
					}
				}
				int num13 = binaryReader.ReadInt32();
				int num14 = 0;
				while (num14 < num13)
				{
					WSOFile.WSOBone wsobone2 = this.AddBone();
					wsobone2.Name = this.ReadString(binaryReader, (this.Version >= 6) ? binaryReader.ReadInt32() : ((int)binaryReader.ReadByte()));
					try
					{
						wsobone2.Hash = Convert.ToUInt32(wsobone2.Name, 16);
						goto IL_5E3;
					}
					catch (Exception)
					{
						wsobone2.Hash = FNV32.GetHash(wsobone2.Name);
						goto IL_5E3;
					}
					goto IL_567;
					IL_5D8:
					num14++;
					continue;
					IL_567:
					wsobone2.TranslationX = (float)binaryReader.ReadInt32();
					wsobone2.TranslationY = (float)binaryReader.ReadInt32();
					wsobone2.TranslationZ = (float)binaryReader.ReadInt32();
					wsobone2.RotationX = (float)binaryReader.ReadInt32();
					wsobone2.RotationY = (float)binaryReader.ReadInt32();
					wsobone2.RotationZ = (float)binaryReader.ReadInt32();
					if (this.Version >= 6)
					{
						wsobone2.ParentName = this.ReadString(binaryReader, binaryReader.ReadInt32());
						goto IL_5D8;
					}
					goto IL_5D8;
					IL_5E3:
					if (this.Version >= 2)
					{
						goto IL_567;
					}
					goto IL_5D8;
				}
			}
			catch (Exception ex)
			{
				stream.Close();
				throw new Exception("Could not read from file stream\n\n" + ex.Message);
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000057E4 File Offset: 0x000039E4
		public string ReadString(BinaryReader reader, int length)
		{
			string text = "";
			for (int i = 0; i < length; i++)
			{
				text += ((char)reader.ReadByte()).ToString();
			}
			return text;
		}

		// Token: 0x04000146 RID: 326
		public int Version;

		// Token: 0x04000147 RID: 327
		public string pluginName;

		// Token: 0x04000148 RID: 328
		public int pluginVersion;

		// Token: 0x02000045 RID: 69
		public class WSOMesh
		{
			// Token: 0x17000057 RID: 87
			// (get) Token: 0x06000159 RID: 345 RVA: 0x0000294D File Offset: 0x00000B4D
			// (set) Token: 0x0600015A RID: 346 RVA: 0x00002955 File Offset: 0x00000B55
			public List<WSOFile.WSOVertex> Vertices { get; private set; }

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x0600015B RID: 347 RVA: 0x0000295E File Offset: 0x00000B5E
			// (set) Token: 0x0600015C RID: 348 RVA: 0x00002966 File Offset: 0x00000B66
			public List<WSOFile.WSOFace> Faces { get; private set; }

			// Token: 0x17000059 RID: 89
			// (get) Token: 0x0600015D RID: 349 RVA: 0x0000296F File Offset: 0x00000B6F
			// (set) Token: 0x0600015E RID: 350 RVA: 0x00002977 File Offset: 0x00000B77
			public List<WSOFile.WSOGeoState> GeoStates { get; private set; }

			// Token: 0x1700005A RID: 90
			// (get) Token: 0x0600015F RID: 351 RVA: 0x00002980 File Offset: 0x00000B80
			// (set) Token: 0x06000160 RID: 352 RVA: 0x00002988 File Offset: 0x00000B88
			public List<WSOFile.WSOBone> Bones { get; private set; }

			// Token: 0x1700005B RID: 91
			// (get) Token: 0x06000161 RID: 353 RVA: 0x00002991 File Offset: 0x00000B91
			// (set) Token: 0x06000162 RID: 354 RVA: 0x00002999 File Offset: 0x00000B99
			public string Name { get; set; }

			// Token: 0x1700005C RID: 92
			// (get) Token: 0x06000163 RID: 355 RVA: 0x000029A2 File Offset: 0x00000BA2
			// (set) Token: 0x06000164 RID: 356 RVA: 0x000029AA File Offset: 0x00000BAA
			public WSOFile File { get; set; }

			// Token: 0x06000165 RID: 357 RVA: 0x00005A80 File Offset: 0x00003C80
			public WSOMesh(WSOFile file)
			{
				this.Name = "Unnamed group";
				this.File = file;
				this.Vertices = new List<WSOFile.WSOVertex>();
				this.Faces = new List<WSOFile.WSOFace>();
				this.GeoStates = new List<WSOFile.WSOGeoState>();
				this.Bones = new List<WSOFile.WSOBone>();
			}

			// Token: 0x06000166 RID: 358 RVA: 0x00005AD4 File Offset: 0x00003CD4
			public WSOFile.WSOVertex AddVertex()
			{
				WSOFile.WSOVertex wsovertex = new WSOFile.WSOVertex(this);
				this.Vertices.Add(wsovertex);
				return wsovertex;
			}

			// Token: 0x06000167 RID: 359 RVA: 0x00005AF8 File Offset: 0x00003CF8
			public WSOFile.WSOFace AddFace()
			{
				WSOFile.WSOFace wsoface = new WSOFile.WSOFace(this);
				this.Faces.Add(wsoface);
				return wsoface;
			}

			// Token: 0x06000168 RID: 360 RVA: 0x00005B1C File Offset: 0x00003D1C
			public WSOFile.WSOBone AddBone()
			{
				WSOFile.WSOBone wsobone = new WSOFile.WSOBone(this);
				this.Bones.Add(wsobone);
				return wsobone;
			}
		}

		// Token: 0x02000046 RID: 70
		public class WSOVertex
		{
			// Token: 0x1700005D RID: 93
			// (get) Token: 0x06000169 RID: 361 RVA: 0x000029B3 File Offset: 0x00000BB3
			// (set) Token: 0x0600016A RID: 362 RVA: 0x000029BB File Offset: 0x00000BBB
			public float X { get; set; }

			// Token: 0x1700005E RID: 94
			// (get) Token: 0x0600016B RID: 363 RVA: 0x000029C4 File Offset: 0x00000BC4
			// (set) Token: 0x0600016C RID: 364 RVA: 0x000029CC File Offset: 0x00000BCC
			public float Y { get; set; }

			// Token: 0x1700005F RID: 95
			// (get) Token: 0x0600016D RID: 365 RVA: 0x000029D5 File Offset: 0x00000BD5
			// (set) Token: 0x0600016E RID: 366 RVA: 0x000029DD File Offset: 0x00000BDD
			public float Z { get; set; }

			// Token: 0x17000060 RID: 96
			// (get) Token: 0x0600016F RID: 367 RVA: 0x000029E6 File Offset: 0x00000BE6
			// (set) Token: 0x06000170 RID: 368 RVA: 0x000029EE File Offset: 0x00000BEE
			public int VertexID { get; set; }

			// Token: 0x17000061 RID: 97
			// (get) Token: 0x06000171 RID: 369 RVA: 0x000029F7 File Offset: 0x00000BF7
			// (set) Token: 0x06000172 RID: 370 RVA: 0x000029FF File Offset: 0x00000BFF
			public int BoneAssigment1 { get; set; }

			// Token: 0x17000062 RID: 98
			// (get) Token: 0x06000173 RID: 371 RVA: 0x00002A08 File Offset: 0x00000C08
			// (set) Token: 0x06000174 RID: 372 RVA: 0x00002A10 File Offset: 0x00000C10
			public int BoneAssigment2 { get; set; }

			// Token: 0x17000063 RID: 99
			// (get) Token: 0x06000175 RID: 373 RVA: 0x00002A19 File Offset: 0x00000C19
			// (set) Token: 0x06000176 RID: 374 RVA: 0x00002A21 File Offset: 0x00000C21
			public int BoneAssigment3 { get; set; }

			// Token: 0x17000064 RID: 100
			// (get) Token: 0x06000177 RID: 375 RVA: 0x00002A2A File Offset: 0x00000C2A
			// (set) Token: 0x06000178 RID: 376 RVA: 0x00002A32 File Offset: 0x00000C32
			public int BoneAssigment4 { get; set; }

			// Token: 0x17000065 RID: 101
			// (get) Token: 0x06000179 RID: 377 RVA: 0x00002A3B File Offset: 0x00000C3B
			// (set) Token: 0x0600017A RID: 378 RVA: 0x00002A43 File Offset: 0x00000C43
			public float BoneWeight1 { get; set; }

			// Token: 0x17000066 RID: 102
			// (get) Token: 0x0600017B RID: 379 RVA: 0x00002A4C File Offset: 0x00000C4C
			// (set) Token: 0x0600017C RID: 380 RVA: 0x00002A54 File Offset: 0x00000C54
			public float BoneWeight2 { get; set; }

			// Token: 0x17000067 RID: 103
			// (get) Token: 0x0600017D RID: 381 RVA: 0x00002A5D File Offset: 0x00000C5D
			// (set) Token: 0x0600017E RID: 382 RVA: 0x00002A65 File Offset: 0x00000C65
			public float BoneWeight3 { get; set; }

			// Token: 0x17000068 RID: 104
			// (get) Token: 0x0600017F RID: 383 RVA: 0x00002A6E File Offset: 0x00000C6E
			// (set) Token: 0x06000180 RID: 384 RVA: 0x00002A76 File Offset: 0x00000C76
			public float BoneWeight4 { get; set; }

			// Token: 0x17000069 RID: 105
			// (get) Token: 0x06000181 RID: 385 RVA: 0x00002A7F File Offset: 0x00000C7F
			// (set) Token: 0x06000182 RID: 386 RVA: 0x00002A87 File Offset: 0x00000C87
			public byte UnknownByte1 { get; set; }

			// Token: 0x1700006A RID: 106
			// (get) Token: 0x06000183 RID: 387 RVA: 0x00002A90 File Offset: 0x00000C90
			// (set) Token: 0x06000184 RID: 388 RVA: 0x00002A98 File Offset: 0x00000C98
			public byte UnknownByte2 { get; set; }

			// Token: 0x1700006B RID: 107
			// (get) Token: 0x06000185 RID: 389 RVA: 0x00002AA1 File Offset: 0x00000CA1
			// (set) Token: 0x06000186 RID: 390 RVA: 0x00002AA9 File Offset: 0x00000CA9
			public byte UnknownByte3 { get; set; }

			// Token: 0x1700006C RID: 108
			// (get) Token: 0x06000187 RID: 391 RVA: 0x00002AB2 File Offset: 0x00000CB2
			// (set) Token: 0x06000188 RID: 392 RVA: 0x00002ABA File Offset: 0x00000CBA
			public byte UnknownByte4 { get; set; }

			// Token: 0x1700006D RID: 109
			// (get) Token: 0x06000189 RID: 393 RVA: 0x00002AC3 File Offset: 0x00000CC3
			// (set) Token: 0x0600018A RID: 394 RVA: 0x00002ACB File Offset: 0x00000CCB
			public WSOFile.WSOMesh Mesh { get; set; }

			// Token: 0x0600018B RID: 395 RVA: 0x00002AD4 File Offset: 0x00000CD4
			public WSOVertex(WSOFile.WSOMesh mesh)
			{
				this.Mesh = mesh;
			}
		}

		// Token: 0x02000047 RID: 71
		public class WSOFace
		{
			// Token: 0x1700006E RID: 110
			// (get) Token: 0x0600018C RID: 396 RVA: 0x00002AE3 File Offset: 0x00000CE3
			// (set) Token: 0x0600018D RID: 397 RVA: 0x00002AEB File Offset: 0x00000CEB
			public WSOFile.WSOMesh Mesh { get; set; }

			// Token: 0x0600018E RID: 398 RVA: 0x00002AF4 File Offset: 0x00000CF4
			public WSOFace(WSOFile.WSOMesh mesh)
			{
				this.Mesh = mesh;
				this.Tx = new List<float>();
				this.Ty = new List<float>();
			}

			// Token: 0x1700006F RID: 111
			// (get) Token: 0x0600018F RID: 399 RVA: 0x00002B19 File Offset: 0x00000D19
			// (set) Token: 0x06000190 RID: 400 RVA: 0x00002B21 File Offset: 0x00000D21
			public short VertexIndex { get; set; }

			// Token: 0x17000070 RID: 112
			// (get) Token: 0x06000191 RID: 401 RVA: 0x00002B2A File Offset: 0x00000D2A
			// (set) Token: 0x06000192 RID: 402 RVA: 0x00002B32 File Offset: 0x00000D32
			public float NormalX { get; set; }

			// Token: 0x17000071 RID: 113
			// (get) Token: 0x06000193 RID: 403 RVA: 0x00002B3B File Offset: 0x00000D3B
			// (set) Token: 0x06000194 RID: 404 RVA: 0x00002B43 File Offset: 0x00000D43
			public float NormalY { get; set; }

			// Token: 0x17000072 RID: 114
			// (get) Token: 0x06000195 RID: 405 RVA: 0x00002B4C File Offset: 0x00000D4C
			// (set) Token: 0x06000196 RID: 406 RVA: 0x00002B54 File Offset: 0x00000D54
			public float NormalZ { get; set; }

			// Token: 0x17000073 RID: 115
			// (get) Token: 0x06000197 RID: 407 RVA: 0x00002B5D File Offset: 0x00000D5D
			// (set) Token: 0x06000198 RID: 408 RVA: 0x00002B65 File Offset: 0x00000D65
			public List<float> Tx { get; set; }

			// Token: 0x17000074 RID: 116
			// (get) Token: 0x06000199 RID: 409 RVA: 0x00002B6E File Offset: 0x00000D6E
			// (set) Token: 0x0600019A RID: 410 RVA: 0x00002B76 File Offset: 0x00000D76
			public List<float> Ty { get; set; }
		}

		// Token: 0x02000048 RID: 72
		public class WSOGeoState
		{
			// Token: 0x17000075 RID: 117
			// (get) Token: 0x0600019B RID: 411 RVA: 0x00002B7F File Offset: 0x00000D7F
			// (set) Token: 0x0600019C RID: 412 RVA: 0x00002B87 File Offset: 0x00000D87
			public int FaceCount { get; set; }

			// Token: 0x17000076 RID: 118
			// (get) Token: 0x0600019D RID: 413 RVA: 0x00002B90 File Offset: 0x00000D90
			// (set) Token: 0x0600019E RID: 414 RVA: 0x00002B98 File Offset: 0x00000D98
			public short[] Indicies { get; set; }

			// Token: 0x17000077 RID: 119
			// (get) Token: 0x0600019F RID: 415 RVA: 0x00002BA1 File Offset: 0x00000DA1
			// (set) Token: 0x060001A0 RID: 416 RVA: 0x00002BA9 File Offset: 0x00000DA9
			public float[][] Data { get; set; }
		}

		// Token: 0x02000049 RID: 73
		public class WSOBone
		{
			// Token: 0x17000078 RID: 120
			// (get) Token: 0x060001A2 RID: 418 RVA: 0x00002BB2 File Offset: 0x00000DB2
			// (set) Token: 0x060001A3 RID: 419 RVA: 0x00002BBA File Offset: 0x00000DBA
			public WSOFile.WSOMesh Mesh { get; set; }

			// Token: 0x17000079 RID: 121
			// (get) Token: 0x060001A4 RID: 420 RVA: 0x00002BC3 File Offset: 0x00000DC3
			// (set) Token: 0x060001A5 RID: 421 RVA: 0x00002BCB File Offset: 0x00000DCB
			public string Name { get; set; }

			// Token: 0x1700007A RID: 122
			// (get) Token: 0x060001A6 RID: 422 RVA: 0x00002BD4 File Offset: 0x00000DD4
			// (set) Token: 0x060001A7 RID: 423 RVA: 0x00002BDC File Offset: 0x00000DDC
			public string ParentName { get; set; }

			// Token: 0x1700007B RID: 123
			// (get) Token: 0x060001A8 RID: 424 RVA: 0x00002BE5 File Offset: 0x00000DE5
			// (set) Token: 0x060001A9 RID: 425 RVA: 0x00002BED File Offset: 0x00000DED
			public uint Hash { get; set; }

			// Token: 0x1700007C RID: 124
			// (get) Token: 0x060001AA RID: 426 RVA: 0x00002BF6 File Offset: 0x00000DF6
			// (set) Token: 0x060001AB RID: 427 RVA: 0x00002BFE File Offset: 0x00000DFE
			public float TranslationX { get; set; }

			// Token: 0x1700007D RID: 125
			// (get) Token: 0x060001AC RID: 428 RVA: 0x00002C07 File Offset: 0x00000E07
			// (set) Token: 0x060001AD RID: 429 RVA: 0x00002C0F File Offset: 0x00000E0F
			public float TranslationY { get; set; }

			// Token: 0x1700007E RID: 126
			// (get) Token: 0x060001AE RID: 430 RVA: 0x00002C18 File Offset: 0x00000E18
			// (set) Token: 0x060001AF RID: 431 RVA: 0x00002C20 File Offset: 0x00000E20
			public float TranslationZ { get; set; }

			// Token: 0x1700007F RID: 127
			// (get) Token: 0x060001B0 RID: 432 RVA: 0x00002C29 File Offset: 0x00000E29
			// (set) Token: 0x060001B1 RID: 433 RVA: 0x00002C31 File Offset: 0x00000E31
			public float RotationX { get; set; }

			// Token: 0x17000080 RID: 128
			// (get) Token: 0x060001B2 RID: 434 RVA: 0x00002C3A File Offset: 0x00000E3A
			// (set) Token: 0x060001B3 RID: 435 RVA: 0x00002C42 File Offset: 0x00000E42
			public float RotationY { get; set; }

			// Token: 0x17000081 RID: 129
			// (get) Token: 0x060001B4 RID: 436 RVA: 0x00002C4B File Offset: 0x00000E4B
			// (set) Token: 0x060001B5 RID: 437 RVA: 0x00002C53 File Offset: 0x00000E53
			public float RotationZ { get; set; }

			// Token: 0x060001B6 RID: 438 RVA: 0x00002C5C File Offset: 0x00000E5C
			public WSOBone(WSOFile.WSOMesh mesh)
			{
				this.Mesh = mesh;
				this.Name = "";
				this.ParentName = "";
			}
		}
	}
}
