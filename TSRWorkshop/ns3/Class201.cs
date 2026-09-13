using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ns14;
using ns15;
using ns16;
using ns18;
using ns19;
using ns21;
using ns5;
using ns8;
using ns9;

namespace ns3
{
	// Token: 0x020001C8 RID: 456
	internal sealed class Class201 : Class200
	{
		// Token: 0x060012D0 RID: 4816 RVA: 0x000C40E4 File Offset: 0x000C22E4
		public Class201(Guid userId, Exception currentException, IWebProxy proxy)
		{
			this.userId = userId;
			this.currentException = currentException;
			this.memoryStream_0 = new MemoryStream();
			this.xmlWriter_0 = new XmlTextWriter(this.memoryStream_0, new UTF8Encoding(false));
			base.method_0(proxy);
			string a;
			if ((a = "UNICODE".ToUpper()) != null)
			{
				if (a == "ASCII")
				{
					this.char_0 = new char[]
					{
						'a',
						'b',
						'c',
						'd',
						'e',
						'f',
						'g',
						'h',
						'i',
						'j',
						'k',
						'l',
						'm',
						'n',
						'o',
						'p',
						'q',
						'r',
						's',
						't',
						'u',
						'v',
						'w',
						'x',
						'y',
						'z',
						'A',
						'B',
						'C',
						'D',
						'E',
						'F',
						'G',
						'H',
						'I',
						'J',
						'K',
						'L',
						'M',
						'N',
						'O',
						'P',
						'Q',
						'R',
						'S',
						'T',
						'U',
						'V',
						'W',
						'X',
						'Y',
						'Z',
						'0',
						'1',
						'2',
						'3',
						'4',
						'5',
						'6',
						'7',
						'8',
						'9'
					};
					return;
				}
				if (!(a == "UNICODE"))
				{
					return;
				}
				this.char_0 = new char[]
				{
					'\u0001',
					'\u0002',
					'\u0003',
					'\u0004',
					'\u0005',
					'\u0006',
					'\a',
					'\b',
					'\u000e',
					'\u000f',
					'\u0010',
					'\u0011',
					'\u0012',
					'\u0013',
					'\u0014',
					'\u0015',
					'\u0016',
					'\u0017',
					'\u0018',
					'\u0019',
					'\u001a',
					'\u001b',
					'\u001c',
					'\u001d',
					'\u001e',
					'\u001f',
					'\u007f',
					'\u0080',
					'\u0081',
					'\u0082',
					'\u0083',
					'\u0084',
					'\u0086',
					'\u0087',
					'\u0088',
					'\u0089',
					'\u008a',
					'\u008b',
					'\u008c',
					'\u008d',
					'\u008e',
					'\u008f',
					'\u0090',
					'\u0091',
					'\u0092',
					'\u0093',
					'\u0094',
					'\u0095',
					'\u0096',
					'\u0097',
					'\u0098',
					'\u0099',
					'\u009a',
					'\u009b',
					'\u009c',
					'\u009d',
					'\u009e',
					'\u009f'
				};
			}
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x000C41E4 File Offset: 0x000C23E4
		private static string smethod_0(object object_0)
		{
			try
			{
				if (object_0 == null)
				{
					return string.Empty;
				}
				if (object_0 is int)
				{
					return ((int)object_0).ToString("x");
				}
				if (object_0 is long)
				{
					return ((long)object_0).ToString("x");
				}
				if (object_0 is short)
				{
					return ((short)object_0).ToString("x");
				}
				if (object_0 is uint)
				{
					return ((uint)object_0).ToString("x");
				}
				if (object_0 is ulong)
				{
					return ((ulong)object_0).ToString("x");
				}
				if (object_0 is ushort)
				{
					return ((ushort)object_0).ToString("x");
				}
				if (object_0 is byte)
				{
					return ((byte)object_0).ToString("x");
				}
				if (object_0 is sbyte)
				{
					return ((sbyte)object_0).ToString("x");
				}
				if (object_0 is IntPtr)
				{
					return ((IntPtr)object_0).ToInt64().ToString("x");
				}
				if (object_0 is UIntPtr)
				{
					return ((UIntPtr)object_0).ToUInt64().ToString("x");
				}
			}
			catch
			{
			}
			return string.Empty;
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x00009E46 File Offset: 0x00008046
		private static string smethod_1(string string_10)
		{
			if (string_10.StartsWith("\"<RSAKeyValue>") && string_10.EndsWith("</RSAKeyValue>\""))
			{
				return "*** Information not reported for security reasons ***";
			}
			return string_10;
		}

		// Token: 0x060012D3 RID: 4819 RVA: 0x000C4380 File Offset: 0x000C2580
		private void method_5(Class205 class205_0, FieldInfo fieldInfo_0)
		{
			string text = (fieldInfo_0 == null) ? null : fieldInfo_0.Name;
			string name = (fieldInfo_0 == null) ? "Object" : "Field";
			object obj = class205_0.method_0();
			if (obj == null)
			{
				using (new Class214(this.xmlWriter_0, name))
				{
					if (fieldInfo_0 != null)
					{
						if (fieldInfo_0.IsStatic)
						{
							this.xmlWriter_0.WriteAttributeString("Static", "1");
						}
						Type fieldType = fieldInfo_0.FieldType;
						if (fieldType != null && fieldType.HasElementType)
						{
							this.method_9(fieldType.GetElementType());
							if (fieldType.IsByRef)
							{
								this.xmlWriter_0.WriteAttributeString("ByRef", "1");
							}
							if (fieldType.IsPointer)
							{
								this.xmlWriter_0.WriteAttributeString("Pointer", "1");
							}
							if (fieldType.IsArray)
							{
								this.xmlWriter_0.WriteAttributeString("Rank", fieldType.GetArrayRank().ToString());
							}
						}
						else
						{
							this.method_9(fieldType);
						}
					}
					if (text != null)
					{
						this.method_7(text);
					}
					this.xmlWriter_0.WriteAttributeString("Null", "1");
				}
				return;
			}
			Type type = class205_0.method_0().GetType();
			string text2 = null;
			string text3 = null;
			if (obj is string)
			{
				text2 = "System.String";
			}
			if (text2 == null)
			{
				if (!type.IsPrimitive && !(obj is IntPtr) && !(obj is UIntPtr))
				{
					if (type.IsValueType && type.Module != base.GetType().Module)
					{
						text2 = type.FullName;
					}
				}
				else
				{
					text2 = type.FullName;
					if (obj is char)
					{
						int num = (int)((char)obj);
						StringBuilder stringBuilder = new StringBuilder();
						if (num >= 32)
						{
							stringBuilder.Append('\'');
							stringBuilder.Append((char)obj);
							stringBuilder.Append("' ");
						}
						stringBuilder.Append("(0x");
						stringBuilder.Append(num.ToString("x"));
						stringBuilder.Append(')');
						text3 = stringBuilder.ToString();
					}
					if (obj is bool)
					{
						text3 = obj.ToString().ToLower();
					}
					if (text3 == null)
					{
						string text4 = Class201.smethod_0(obj);
						if (text4.Length > 0)
						{
							StringBuilder stringBuilder2 = new StringBuilder();
							stringBuilder2.Append(obj.ToString());
							stringBuilder2.Append(" (0x");
							stringBuilder2.Append(text4);
							stringBuilder2.Append(')');
							text3 = stringBuilder2.ToString();
						}
						else
						{
							text3 = obj.ToString();
						}
					}
				}
			}
			using (new Class214(this.xmlWriter_0, name))
			{
				if (fieldInfo_0 != null && fieldInfo_0.IsStatic)
				{
					this.xmlWriter_0.WriteAttributeString("Static", "1");
				}
				if (text2 != null)
				{
					this.method_9(type);
					if (text != null)
					{
						this.method_7(text);
					}
					if (type.IsEnum)
					{
						text3 = obj.ToString();
					}
					if (obj is Guid)
					{
						text3 = "{" + obj + "}";
					}
					if (text3 == null)
					{
						text3 = "\"" + obj + "\"";
					}
					this.xmlWriter_0.WriteAttributeString("Value", Class201.smethod_1(text3));
				}
				else
				{
					if (fieldInfo_0 != null)
					{
						this.method_9(fieldInfo_0.FieldType);
					}
					this.method_6(class205_0);
					if (text != null)
					{
						this.method_7(text);
					}
				}
			}
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x000C46EC File Offset: 0x000C28EC
		private void method_6(Class205 class205_0)
		{
			object objB = class205_0.method_0();
			int num = -1;
			for (int i = 0; i < this.list_0.Count; i++)
			{
				if (object.ReferenceEquals(this.list_0[i].method_0(), objB))
				{
					num = i;
					IL_3C:
					if (num == -1)
					{
						num = this.list_0.Count;
						this.list_0.Add(class205_0);
					}
					this.xmlWriter_0.WriteAttributeString("ID", num.ToString());
					return;
				}
			}
			goto IL_3C;
		}

		// Token: 0x060012D5 RID: 4821 RVA: 0x000C4768 File Offset: 0x000C2968
		private void method_7(string string_10)
		{
			int num = this.method_10(string_10);
			if (num != -1)
			{
				this.xmlWriter_0.WriteAttributeString("NameID", num.ToString());
				return;
			}
			this.xmlWriter_0.WriteAttributeString("Name", string_10);
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x000C47AC File Offset: 0x000C29AC
		private static Class201.Struct41 smethod_2(Type type_0)
		{
			Class201.Struct41 empty = Class201.Struct41.Empty;
			if (type_0 != null && type_0.Assembly.GetType("SmartAssembly.Attributes.PoweredByAttribute") != null)
			{
				empty.id = ((type_0.MetadataToken & 16777215) - 1).ToString();
				Assembly assembly = type_0.Assembly;
				empty.struct40_0 = new Class201.Struct40(assembly.ManifestModule.ModuleVersionId.ToString("B"), assembly.FullName);
			}
			return empty;
		}

		// Token: 0x060012D7 RID: 4823 RVA: 0x000C4824 File Offset: 0x000C2A24
		private int method_8(Class201.Struct41 struct41_0)
		{
			string key = struct41_0.struct40_0.assemblyID.ToUpper();
			if (this.dictionary_3.ContainsKey(key))
			{
				return this.dictionary_3[key];
			}
			int count = this.list_2.Count;
			this.list_2.Add(struct41_0.struct40_0);
			this.dictionary_3.Add(key, count);
			return count;
		}

		// Token: 0x060012D8 RID: 4824 RVA: 0x000C488C File Offset: 0x000C2A8C
		private void method_9(Type type_0)
		{
			if (type_0 == null)
			{
				return;
			}
			try
			{
				Class201.Struct41 struct41_ = Class201.smethod_2(type_0);
				if (!struct41_.IsEmpty)
				{
					this.xmlWriter_0.WriteAttributeString("TypeDefID", struct41_.id);
					int num = this.method_8(struct41_);
					if (num > 0)
					{
						this.xmlWriter_0.WriteAttributeString("Assembly", num.ToString());
					}
				}
				else
				{
					string fullName = type_0.FullName;
					int value;
					if (this.dictionary_2.ContainsKey(fullName))
					{
						value = this.dictionary_2[fullName];
					}
					else
					{
						StringBuilder stringBuilder = new StringBuilder();
						string name = type_0.Assembly.GetName().Name;
						if (name.Length > 0 && name != "mscorlib")
						{
							stringBuilder.Append('[');
							stringBuilder.Append(name);
							stringBuilder.Append(']');
						}
						string @namespace = type_0.Namespace;
						if (@namespace.Length > 0)
						{
							stringBuilder.Append(@namespace);
							stringBuilder.Append('.');
						}
						if (type_0.HasElementType)
						{
							type_0 = type_0.GetElementType();
						}
						int num2 = fullName.LastIndexOf("+");
						if (num2 > 0)
						{
							string value2 = fullName.Substring(@namespace.Length + 1, num2 - @namespace.Length).Replace("+", "/");
							stringBuilder.Append(value2);
						}
						stringBuilder.Append(type_0.Name);
						value = this.list_1.Count;
						this.list_1.Add(stringBuilder.ToString());
						this.dictionary_2.Add(fullName, value);
					}
					this.xmlWriter_0.WriteAttributeString("TypeName", value.ToString());
				}
			}
			catch
			{
			}
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x000C4A54 File Offset: 0x000C2C54
		private int method_10(string string_10)
		{
			int result;
			try
			{
				bool flag = this.char_0[0] == '\u0001';
				if (string_10 != null && string_10.Length != 0 && (!flag || string_10.Length <= 4))
				{
					if (flag || string_10[0] == '#')
					{
						int num = 0;
						int num2 = string_10.Length - 1;
						IL_97:
						while (num2 >= 0 && (flag || num2 != 0))
						{
							char c = string_10[num2];
							bool flag2 = false;
							int i = 0;
							while (i < this.char_0.Length)
							{
								if (this.char_0[i] == c)
								{
									num = num * this.char_0.Length + i;
									flag2 = true;
									IL_8F:
									if (flag2)
									{
										num2--;
										goto IL_97;
									}
									return -1;
								}
								else
								{
									i++;
								}
							}
							goto IL_8F;
						}
						return num;
					}
				}
				result = -1;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x000C4B24 File Offset: 0x000C2D24
		private static string smethod_3()
		{
			string result;
			try
			{
				result = Application.ExecutablePath;
			}
			catch
			{
				result = "N/A";
			}
			return result;
		}

		// Token: 0x060012DB RID: 4827 RVA: 0x000C4B54 File Offset: 0x000C2D54
		private Assembly[] method_11()
		{
			Assembly[] result;
			try
			{
				result = AppDomain.CurrentDomain.GetAssemblies();
			}
			catch
			{
				result = new Assembly[]
				{
					Class201.smethod_4()
				};
			}
			return result;
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x000C4B94 File Offset: 0x000C2D94
		private static Assembly smethod_4()
		{
			Assembly result;
			try
			{
				result = Assembly.GetExecutingAssembly();
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060012DD RID: 4829 RVA: 0x00009E69 File Offset: 0x00008069
		internal byte[] method_12()
		{
			return this.method_13();
		}

		// Token: 0x060012DE RID: 4830 RVA: 0x000C4BC0 File Offset: 0x000C2DC0
		private byte[] method_13()
		{
			if (this.byte_0 != null)
			{
				return this.byte_0;
			}
			this.xmlWriter_0.WriteStartDocument();
			using (new Class214(this.xmlWriter_0, "UnhandledExceptionReport"))
			{
				this.xmlWriter_0.WriteAttributeString("AssemblyID", "{653DB4E2-8C85-4E4A-9099-267AB2090CEE}".ToUpper());
				this.xmlWriter_0.WriteAttributeString("DateTime", DateTime.Now.ToString("s"));
				this.xmlWriter_0.WriteAttributeString("Path", Class201.smethod_3());
				if (this.userId != Guid.Empty)
				{
					this.xmlWriter_0.WriteAttributeString("UserID", this.userId.ToString("B"));
				}
				this.xmlWriter_0.WriteAttributeString("ReportID", Guid.NewGuid().ToString("B"));
				if (this.list_2.Count > 0)
				{
					this.list_2.Clear();
				}
				this.list_2.Add(new Class201.Struct40("{653DB4E2-8C85-4E4A-9099-267AB2090CEE}", string.Empty));
				if (this.dictionary_3.Count > 0)
				{
					this.dictionary_3.Clear();
				}
				this.dictionary_3.Add("{653DB4E2-8C85-4E4A-9099-267AB2090CEE}", 0);
				using (new Class214(this.xmlWriter_0, "Assemblies"))
				{
					Assembly assembly = Class201.smethod_4();
					foreach (Assembly assembly2 in this.method_11())
					{
						if (assembly2 != null)
						{
							using (new Class214(this.xmlWriter_0, "Assembly"))
							{
								try
								{
									this.xmlWriter_0.WriteAttributeString("Name", assembly2.FullName);
									this.xmlWriter_0.WriteAttributeString("CodeBase", assembly2.CodeBase);
									if (assembly2 == assembly)
									{
										this.xmlWriter_0.WriteAttributeString("This", "1");
									}
								}
								catch
								{
								}
							}
						}
					}
				}
				using (new Class214(this.xmlWriter_0, "CustomProperties"))
				{
					if (this.dictionary_0 != null && this.dictionary_0.Count > 0)
					{
						foreach (string text in this.dictionary_0.Keys)
						{
							using (new Class214(this.xmlWriter_0, "CustomProperty"))
							{
								this.xmlWriter_0.WriteAttributeString("Name", text);
								string text2 = (string)this.dictionary_0[text];
								if (text2 == null)
								{
									this.xmlWriter_0.WriteAttributeString("Null", "1");
								}
								else
								{
									this.xmlWriter_0.WriteAttributeString("Value", "\"" + text2 + "\"");
								}
							}
						}
					}
				}
				if (this.dictionary_1 != null && this.dictionary_1.Count > 0)
				{
					using (new Class214(this.xmlWriter_0, "AttachedFiles"))
					{
						foreach (string text3 in this.dictionary_1.Keys)
						{
							using (new Class214(this.xmlWriter_0, "AttachedFile"))
							{
								this.xmlWriter_0.WriteAttributeString("Key", text3);
								Class201.Struct39 @struct = this.dictionary_1[text3];
								this.xmlWriter_0.WriteAttributeString("FileName", @struct.string_0);
								this.xmlWriter_0.WriteAttributeString("Length", @struct.int_0.ToString());
								if (@struct.string_2.Length > 0)
								{
									this.xmlWriter_0.WriteAttributeString("Error", @struct.string_2);
								}
								else
								{
									this.xmlWriter_0.WriteAttributeString("Data", @struct.string_1);
								}
							}
						}
					}
				}
				using (new Class214(this.xmlWriter_0, "SystemInformation"))
				{
					try
					{
						this.xmlWriter_0.WriteElementString("NETVersion", Environment.Version.ToString());
						this.xmlWriter_0.WriteElementString("OSVersion", Environment.OSVersion.Version.ToString());
						this.xmlWriter_0.WriteElementString("OSPlatformID", Environment.OSVersion.Platform.ToString());
						this.xmlWriter_0.WriteElementString("ServicePack", Class213.ServicePack);
						this.xmlWriter_0.WriteElementString("ServerR2", Class213.IsServerR2 ? "1" : "0");
						this.xmlWriter_0.WriteElementString("X64", Class213.IsX64 ? "1" : "0");
						this.xmlWriter_0.WriteElementString("Workstation", Class213.IsWorkstation ? "1" : "0");
					}
					catch
					{
					}
				}
				List<Exception> list = new List<Exception>();
				for (Exception innerException = this.currentException; innerException != null; innerException = innerException.InnerException)
				{
					list.Add(innerException);
				}
				list.Reverse();
				using (new Class214(this.xmlWriter_0, "StackTrace"))
				{
					foreach (Exception ex in list)
					{
						try
						{
							this.method_16(ex);
							if (ex.Data.Contains("SmartStackFrames"))
							{
								ICollection collection = (ICollection)ex.Data["SmartStackFrames"];
								int count = collection.Count;
								int num = 0;
								foreach (object obj in collection)
								{
									try
									{
										Type type = obj.GetType();
										num++;
										if (num > 100 && num == count - 100)
										{
											using (new Class214(this.xmlWriter_0, "RemovedFrames"))
											{
												this.xmlWriter_0.WriteAttributeString("TotalFramesCount", count.ToString());
											}
										}
										else if (num <= 100 || num > count - 100)
										{
											int num2 = (int)type.GetField("MethodID").GetValue(obj);
											int num3 = (int)type.GetField("ILOffset").GetValue(obj);
											int num4 = (int)type.GetField("ExceptionStackDepth").GetValue(obj);
											object[] array2 = (object[])type.GetField("Objects").GetValue(obj);
											Class201.Struct41 struct41_ = Class201.smethod_2(type);
											if (!struct41_.IsEmpty)
											{
												using (new Class214(this.xmlWriter_0, "StackFrame"))
												{
													this.xmlWriter_0.WriteAttributeString("MethodID", num2.ToString());
													this.xmlWriter_0.WriteAttributeString("ExceptionStackDepth", num4.ToString());
													int num5 = this.method_8(struct41_);
													if (num5 > 0)
													{
														this.xmlWriter_0.WriteAttributeString("Assembly", num5.ToString());
													}
													if (num3 != -1)
													{
														this.xmlWriter_0.WriteAttributeString("ILOffset", num3.ToString());
													}
													foreach (object o in array2)
													{
														try
														{
															this.method_5(new Class205(o, true), null);
														}
														catch
														{
														}
													}
												}
											}
										}
									}
									catch
									{
									}
								}
							}
						}
						catch
						{
						}
					}
				}
				this.method_14();
				using (new Class214(this.xmlWriter_0, "TypeNames"))
				{
					this.xmlWriter_0.WriteAttributeString("Count", this.list_1.Count.ToString());
					for (int k = 0; k < this.list_1.Count; k++)
					{
						string value;
						try
						{
							value = this.list_1[k].ToString();
						}
						catch (Exception ex2)
						{
							value = '"' + ex2.Message + '"';
						}
						this.xmlWriter_0.WriteElementString("TypeName", value);
					}
				}
				using (new Class214(this.xmlWriter_0, "AssemblyIDs"))
				{
					this.xmlWriter_0.WriteAttributeString("Count", this.list_2.Count.ToString());
					for (int l = 0; l < this.list_2.Count; l++)
					{
						using (new Class214(this.xmlWriter_0, "AssemblyID"))
						{
							Class201.Struct40 struct2 = this.list_2[l];
							this.xmlWriter_0.WriteAttributeString("ID", struct2.assemblyID);
							if (struct2.assemblyFullName.Length > 0)
							{
								this.xmlWriter_0.WriteAttributeString("FullName", struct2.assemblyFullName);
							}
						}
					}
				}
			}
			this.xmlWriter_0.WriteEndDocument();
			this.xmlWriter_0.Flush();
			this.memoryStream_0.Flush();
			this.byte_0 = this.memoryStream_0.ToArray();
			return this.byte_0;
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x000C5798 File Offset: 0x000C3998
		private void method_14()
		{
			using (new Class214(this.xmlWriter_0, "Objects"))
			{
				for (int i = 0; i < this.list_0.Count; i++)
				{
					Class205 class2 = this.list_0[i];
					object obj = class2.method_0();
					Type type = class2.method_1();
					using (new Class214(this.xmlWriter_0, "ObjectDef"))
					{
						this.xmlWriter_0.WriteAttributeString("ID", i.ToString());
						string text = null;
						bool flag = true;
						foreach (string text2 in "".Split(new char[]
						{
							','
						}))
						{
							if (text2 != "" && type.FullName.StartsWith(text2))
							{
								flag = false;
								IL_BB:
								foreach (Attribute attribute in type.GetCustomAttributes(true))
								{
									string name = attribute.GetType().Name;
									if (!(name != "DoNotCaptureFieldsAttribute") || !(name != "DoNotCaptureAttribute"))
									{
										flag = false;
										IL_112:
										if (flag)
										{
											try
											{
												text = obj.ToString();
												if (text == type.FullName)
												{
													text = null;
												}
												else if (type.IsEnum)
												{
													text = Enum.Format(type, obj, "d");
												}
												else if (obj is Guid)
												{
													text = "{" + text + "}";
												}
												else
												{
													text = "\"" + text + "\"";
												}
											}
											catch
											{
											}
											if (text != null)
											{
												this.xmlWriter_0.WriteAttributeString("Value", Class201.smethod_1(text));
											}
										}
										if (type.HasElementType)
										{
											this.method_9(type.GetElementType());
											if (type.IsByRef)
											{
												this.xmlWriter_0.WriteAttributeString("ByRef", "1");
											}
											if (type.IsPointer)
											{
												this.xmlWriter_0.WriteAttributeString("Pointer", "1");
											}
											if (type.IsArray)
											{
												Array array2 = (Array)obj;
												this.xmlWriter_0.WriteAttributeString("Rank", array2.Rank.ToString());
												StringBuilder stringBuilder = new StringBuilder();
												for (int l = 0; l < array2.Rank; l++)
												{
													if (l > 0)
													{
														stringBuilder.Append(',');
													}
													stringBuilder.Append(array2.GetLength(l));
												}
												this.xmlWriter_0.WriteAttributeString("Length", stringBuilder.ToString());
												if (array2.Rank == 1)
												{
													int length = array2.Length;
													for (int m = 0; m < length; m++)
													{
														if (m == 10 && length > 16)
														{
															m = length - 5;
														}
														try
														{
															this.method_5(new Class205(array2.GetValue(m), false), null);
														}
														catch
														{
														}
													}
												}
											}
										}
										else
										{
											this.method_9(type);
											if (class2.FirstLevel && flag)
											{
												try
												{
													if (obj is IEnumerable)
													{
														using (new Class214(this.xmlWriter_0, "IEnumerable"))
														{
															int num = 0;
															foreach (object o in ((IEnumerable)obj))
															{
																if (num > 20)
																{
																	this.xmlWriter_0.WriteElementString("More", string.Empty);
																	break;
																}
																this.method_5(new Class205(o, false), null);
																num++;
															}
														}
													}
												}
												catch
												{
												}
												this.method_15(class2);
											}
										}
										goto IL_398;
									}
								}
								goto IL_112;
							}
						}
						goto IL_BB;
					}
					IL_398:;
				}
			}
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x000C5C0C File Offset: 0x000C3E0C
		private void method_15(Class205 class205_0)
		{
			FieldInfo[] fields = class205_0.method_1().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				try
				{
					if (!fieldInfo.IsLiteral)
					{
						if (!fieldInfo.IsStatic || !fieldInfo.IsInitOnly)
						{
							bool flag = true;
							object[] customAttributes = fieldInfo.GetCustomAttributes(true);
							int j = 0;
							while (j < customAttributes.Length)
							{
								Attribute attribute = (Attribute)customAttributes[j];
								if (!(attribute.GetType().Name == "DoNotCaptureAttribute"))
								{
									j++;
								}
								else
								{
									flag = false;
									IL_85:
									if (!flag)
									{
										goto IL_A8;
									}
									this.method_5(new Class205(fieldInfo.GetValue(class205_0.method_0()), false), fieldInfo);
									goto IL_A8;
								}
							}
							goto IL_85;
						}
					}
				}
				catch
				{
				}
				IL_A8:;
			}
			class205_0 = new Class205(class205_0.method_0(), class205_0.method_1().BaseType, class205_0.FirstLevel);
			if (class205_0.method_1() == null)
			{
				return;
			}
			using (new Class214(this.xmlWriter_0, "Field"))
			{
				this.method_7("__base");
				this.xmlWriter_0.WriteAttributeString("ID", this.list_0.Count.ToString());
			}
			this.list_0.Add(class205_0);
		}

		// Token: 0x060012E1 RID: 4833 RVA: 0x000C5D6C File Offset: 0x000C3F6C
		private void method_16(Exception exception_0)
		{
			using (new Class214(this.xmlWriter_0, "Exception"))
			{
				try
				{
					Type type = exception_0.GetType();
					this.method_9(type);
					string value = "N/A";
					try
					{
						value = exception_0.Message;
					}
					catch
					{
					}
					this.xmlWriter_0.WriteAttributeString("Message", value);
					string text = exception_0.StackTrace.Trim();
					this.xmlWriter_0.WriteAttributeString("ExceptionStackTrace", text);
					int num = text.IndexOf(' ');
					text = text.Substring(num + 1);
					num = text.IndexOf("\r\n");
					if (num != -1)
					{
						text = text.Substring(0, num);
					}
					this.xmlWriter_0.WriteAttributeString("Method", text);
					this.method_6(new Class205(exception_0, true));
				}
				catch
				{
				}
			}
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x00009E71 File Offset: 0x00008071
		internal void method_17(string string_10, object object_0)
		{
			this.dictionary_0.Add(string_10, object_0);
		}

		// Token: 0x060012E3 RID: 4835 RVA: 0x000C5E60 File Offset: 0x000C4060
		internal void method_18(string string_10, string string_11)
		{
			if (!File.Exists(string_11))
			{
				return;
			}
			Class201.Struct39 value = new Class201.Struct39(string_11);
			this.dictionary_1.Add(string_10, value);
		}

		// Token: 0x060012E4 RID: 4836 RVA: 0x000C5E8C File Offset: 0x000C408C
		internal bool method_19()
		{
			bool result;
			try
			{
				base.method_4(Enum34.const_0);
				byte[] array;
				try
				{
					array = this.method_13();
				}
				catch (Exception ex)
				{
					int num = -1;
					try
					{
						StackTrace stackTrace = new StackTrace(ex);
						if (stackTrace.FrameCount > 0)
						{
							StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
							num = frame.GetILOffset();
						}
					}
					catch
					{
					}
					base.method_3(Enum34.const_0, string.Format("ERR 2006: {0} @ 0x{1:x4}", ex.Message, num));
					return false;
				}
				Class200.Class204 class204_ = new Class200.Class204("", "TSR Workshop", "v2.0.88.0 from 2014-02-05 14:57:35");
				result = base.method_1(array, class204_);
			}
			catch (ThreadAbortException)
			{
				result = false;
			}
			catch (Exception fatalException)
			{
				this.method_20(new EventArgs8(fatalException));
				result = false;
			}
			return result;
		}

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x060012E5 RID: 4837 RVA: 0x000C5F70 File Offset: 0x000C4170
		// (remove) Token: 0x060012E6 RID: 4838 RVA: 0x000C5FA8 File Offset: 0x000C41A8
		public event Delegate34 FatalException
		{
			add
			{
				Delegate34 @delegate = this.delegate34_0;
				Delegate34 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate34 value2 = (Delegate34)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate34>(ref this.delegate34_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate34 @delegate = this.delegate34_0;
				Delegate34 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate34 value2 = (Delegate34)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate34>(ref this.delegate34_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x060012E7 RID: 4839 RVA: 0x000C5FE0 File Offset: 0x000C41E0
		public void method_20(EventArgs8 eventArgs8_0)
		{
			Delegate34 @delegate = this.delegate34_0;
			if (@delegate != null)
			{
				@delegate(this, eventArgs8_0);
			}
		}

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x060012E8 RID: 4840 RVA: 0x000C6000 File Offset: 0x000C4200
		// (remove) Token: 0x060012E9 RID: 4841 RVA: 0x000C6038 File Offset: 0x000C4238
		public event EventHandler DebuggerLaunched
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x060012EA RID: 4842 RVA: 0x000C6070 File Offset: 0x000C4270
		private void method_21()
		{
			EventHandler eventHandler = this.eventHandler_0;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
		}

		// Token: 0x060012EB RID: 4843 RVA: 0x000C6094 File Offset: 0x000C4294
		internal void method_22()
		{
			try
			{
				string tempFileName = Path.GetTempFileName();
				this.method_23(tempFileName);
				string path = Class183.smethod_0();
				Process.Start(Path.Combine(path, "SmartAssembly.exe"), "/AddExceptionReport \"" + tempFileName + "\"");
				if (this.eventHandler_0 != null)
				{
					this.eventHandler_0(this, EventArgs.Empty);
				}
			}
			catch (ThreadAbortException)
			{
			}
			catch (Exception fatalException)
			{
				this.method_20(new EventArgs8(fatalException));
			}
		}

		// Token: 0x060012EC RID: 4844 RVA: 0x000C6120 File Offset: 0x000C4320
		internal bool method_23(string string_10)
		{
			bool result;
			try
			{
				byte[] array = this.method_13();
				byte[] array2;
				try
				{
					array2 = Class187.smethod_2(array);
				}
				catch
				{
					array2 = null;
				}
				byte[] array3 = Class199.smethod_0(array2, "<RSAKeyValue><Modulus>vBsYoFg7OherL8U5xCMhUGHeZSy+EaxQttYho0Lm3A2wRMeFIkel1MmdbJ+8HaG6/4V2YgWevGpOSn2oiN634oR9Wa9ghl+9490wAns4QJPXbqvEc5fhgVrl5S19AUsXdSHBwARqYZs8Q4d2RzhvUalD2oyBC5Rlqo/69+nQxw8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
				FileStream fileStream = File.OpenWrite(string_10);
				byte[] bytes = Encoding.ASCII.GetBytes("{653DB4E2-8C85-4E4A-9099-267AB2090CEE}");
				fileStream.Write(bytes, 0, bytes.Length);
				fileStream.Write(array3, 0, array3.Length);
				fileStream.Close();
				result = true;
			}
			catch (ThreadAbortException)
			{
				result = false;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x04000D55 RID: 3413
		private const string string_3 = "{bf13b64c-b3d2-4165-b3f5-7f852d4744cf}";

		// Token: 0x04000D56 RID: 3414
		private const string string_4 = "{07572d6f-5375-47d5-8a8c-b5f0cbe5bad0}";

		// Token: 0x04000D57 RID: 3415
		private const string string_5 = "{6d3806d4-1193-4601-a7df-2249c7f0014b}";

		// Token: 0x04000D58 RID: 3416
		private const string string_6 = "{d316c294-ed40-4778-8b7b-29800a2dcbc3}";

		// Token: 0x04000D59 RID: 3417
		private const string string_7 = "{a9035fc5-7ed1-4e0c-8962-dfcb1d508afc}";

		// Token: 0x04000D5A RID: 3418
		private const string string_8 = "{73fbfb9b-41e7-4744-bf74-74b7c6c117c1}";

		// Token: 0x04000D5B RID: 3419
		private const string string_9 = "SmartAssembly.exe";

		// Token: 0x04000D5C RID: 3420
		private readonly Exception currentException;

		// Token: 0x04000D5D RID: 3421
		private readonly Guid userId;

		// Token: 0x04000D5E RID: 3422
		private readonly char[] char_0 = new char[0];

		// Token: 0x04000D5F RID: 3423
		private readonly Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		// Token: 0x04000D60 RID: 3424
		private readonly Dictionary<string, Class201.Struct39> dictionary_1 = new Dictionary<string, Class201.Struct39>();

		// Token: 0x04000D61 RID: 3425
		private readonly XmlWriter xmlWriter_0;

		// Token: 0x04000D62 RID: 3426
		private readonly List<Class205> list_0 = new List<Class205>();

		// Token: 0x04000D63 RID: 3427
		private readonly List<string> list_1 = new List<string>();

		// Token: 0x04000D64 RID: 3428
		private readonly Dictionary<string, int> dictionary_2 = new Dictionary<string, int>();

		// Token: 0x04000D65 RID: 3429
		private readonly List<Class201.Struct40> list_2 = new List<Class201.Struct40>();

		// Token: 0x04000D66 RID: 3430
		private readonly Dictionary<string, int> dictionary_3 = new Dictionary<string, int>();

		// Token: 0x04000D67 RID: 3431
		private readonly MemoryStream memoryStream_0;

		// Token: 0x04000D68 RID: 3432
		private byte[] byte_0;

		// Token: 0x04000D69 RID: 3433
		private Delegate34 delegate34_0;

		// Token: 0x04000D6A RID: 3434
		private EventHandler eventHandler_0;

		// Token: 0x020001C9 RID: 457
		private struct Struct39
		{
			// Token: 0x060012ED RID: 4845 RVA: 0x000C61C0 File Offset: 0x000C43C0
			public Struct39(string fileName)
			{
				this.string_0 = string.Empty;
				this.string_1 = string.Empty;
				this.string_2 = string.Empty;
				this.int_0 = 0;
				try
				{
					FileInfo fileInfo = new FileInfo(fileName);
					this.string_0 = Path.GetFileName(fileName);
					this.int_0 = (int)fileInfo.Length;
					byte[] array = new byte[this.int_0];
					using (FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						fileStream.Read(array, 0, this.int_0);
						fileStream.Close();
					}
					byte[] inArray;
					try
					{
						inArray = Class187.smethod_2(array);
					}
					catch
					{
						inArray = null;
					}
					this.string_1 = Convert.ToBase64String(inArray);
				}
				catch (Exception ex)
				{
					this.string_2 = ex.Message;
				}
			}

			// Token: 0x04000D6B RID: 3435
			public readonly string string_0;

			// Token: 0x04000D6C RID: 3436
			public readonly string string_1;

			// Token: 0x04000D6D RID: 3437
			public readonly string string_2;

			// Token: 0x04000D6E RID: 3438
			public readonly int int_0;
		}

		// Token: 0x020001CA RID: 458
		private struct Struct40
		{
			// Token: 0x060012EE RID: 4846 RVA: 0x00009E80 File Offset: 0x00008080
			public Struct40(string assemblyID, string assemblyFullName)
			{
				this.assemblyID = assemblyID;
				this.assemblyFullName = assemblyFullName;
			}

			// Token: 0x04000D6F RID: 3439
			public readonly string assemblyID;

			// Token: 0x04000D70 RID: 3440
			public readonly string assemblyFullName;
		}

		// Token: 0x020001CB RID: 459
		private struct Struct41
		{
			// Token: 0x17000414 RID: 1044
			// (get) Token: 0x060012EF RID: 4847 RVA: 0x00009E90 File Offset: 0x00008090
			public bool IsEmpty
			{
				get
				{
					return this.id.Length == 0;
				}
			}

			// Token: 0x17000415 RID: 1045
			// (get) Token: 0x060012F0 RID: 4848 RVA: 0x00009EA0 File Offset: 0x000080A0
			public static Class201.Struct41 Empty
			{
				get
				{
					return new Class201.Struct41(string.Empty, string.Empty, string.Empty);
				}
			}

			// Token: 0x060012F1 RID: 4849 RVA: 0x00009EB6 File Offset: 0x000080B6
			private Struct41(string id, string assemblyID, string assemblyFullName)
			{
				this.id = id;
				this.struct40_0 = new Class201.Struct40(assemblyID, assemblyFullName);
			}

			// Token: 0x04000D71 RID: 3441
			public string id;

			// Token: 0x04000D72 RID: 3442
			public Class201.Struct40 struct40_0;
		}
	}
}
