using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ns10;
using ns8;
using Package;
using Package.Helper;
using Package.Sims3Files;
using Sims3Workshop.Properties;
using Sims3WorkshopSDK;

namespace ns16
{
	// Token: 0x020000AF RID: 175
	internal sealed class Class76
	{
		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060006CE RID: 1742 RVA: 0x00066C88 File Offset: 0x00064E88
		// (remove) Token: 0x060006CF RID: 1743 RVA: 0x00066CC0 File Offset: 0x00064EC0
		public static event Class76.Delegate18 Progress
		{
			add
			{
				Class76.Delegate18 @delegate = Class76.delegate18_0;
				Class76.Delegate18 delegate2;
				do
				{
					delegate2 = @delegate;
					Class76.Delegate18 value2 = (Class76.Delegate18)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class76.Delegate18>(ref Class76.delegate18_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Class76.Delegate18 @delegate = Class76.delegate18_0;
				Class76.Delegate18 delegate2;
				do
				{
					delegate2 = @delegate;
					Class76.Delegate18 value2 = (Class76.Delegate18)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class76.Delegate18>(ref Class76.delegate18_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x00066CF8 File Offset: 0x00064EF8
		public static Size smethod_0(XmlDocument xmlDocument_0)
		{
			Size result = new Size(1024, 1024);
			XmlNode xmlNode = xmlDocument_0.SelectSingleNode("/preset/complate/value[@key='Mask']");
			if (xmlNode != null)
			{
				string attribute = (xmlNode as XmlElement).GetAttribute("value");
				DDS dds = Class76.smethod_26(new ResKey(attribute)) as DDS;
				if (dds != null)
				{
					XmlNode xmlNode2 = xmlDocument_0.SelectSingleNode("/preset/complate/value[@key='MaskWidth']");
					XmlNode xmlNode3 = xmlDocument_0.SelectSingleNode("/preset/complate/value[@key='MaskHeight']");
					float num = -1f;
					float num2 = -1f;
					if (xmlNode2 != null)
					{
						num = Convert.ToSingle((xmlNode2 as XmlElement).GetAttribute("value"), CultureInfo.InvariantCulture);
					}
					if (xmlNode3 != null)
					{
						num2 = Convert.ToSingle((xmlNode3 as XmlElement).GetAttribute("value"), CultureInfo.InvariantCulture);
					}
					result.Width = (int)num;
					result.Height = (int)num2;
				}
			}
			return result;
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x00066DD4 File Offset: 0x00064FD4
		public static DDS smethod_1(string string_0)
		{
			ResKey resKey = Class76.smethod_2(string_0, DBPFType.DDS);
			DDS result;
			if (resKey == null)
			{
				result = null;
			}
			else
			{
				result = (DDS)Class76.smethod_26(resKey);
			}
			return result;
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00066E04 File Offset: 0x00065004
		public static ResKey smethod_2(string string_0, DBPFType dbpftype_0)
		{
			string text = Path.GetFileName(string_0);
			if (text.LastIndexOf('.') > 0)
			{
				text = text.Substring(0, text.LastIndexOf('.'));
			}
			ulong num = StringHelpers.HashString64(text);
			return new ResKey(dbpftype_0, 0, (int)(num >> 32), (int)(num & 4294967295UL));
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00066E58 File Offset: 0x00065058
		public static DBPFEntry smethod_3(string string_0, DBPFType dbpftype_0)
		{
			ResKey resKey = Class76.smethod_2(string_0, dbpftype_0);
			DBPFEntry result;
			if (resKey == null)
			{
				result = null;
			}
			else
			{
				result = Class76.smethod_26(resKey);
			}
			return result;
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00066E80 File Offset: 0x00065080
		public static string smethod_4()
		{
			string myDocumentsFolder = Settings.Default.myDocumentsFolder;
			if (string.IsNullOrEmpty(myDocumentsFolder))
			{
				string text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Electronic Arts";
				if (Directory.Exists(text))
				{
					Settings.Default.myDocumentsFolder = text;
				}
				else
				{
					MessageBox.Show("Workshop could not locate the default folder where Sims 3 stores game data and saved games. This is usually 'My Documents/Electronic Arts'.\n\nYou need to specify the folder path manually.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					FolderBrowserDialog folderBrowserDialog;
					do
					{
						folderBrowserDialog = new FolderBrowserDialog();
						folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
						if (folderBrowserDialog.ShowDialog(Class132.mainForm) == DialogResult.OK)
						{
							goto Block_4;
						}
					}
					while (MessageBox.Show("Workshop will not function properly without this information.", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel);
					goto IL_98;
					Block_4:
					Settings.Default.myDocumentsFolder = folderBrowserDialog.SelectedPath;
				}
			}
			IL_98:
			return Settings.Default.myDocumentsFolder;
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x00066F34 File Offset: 0x00065134
		public static DBPFEntry smethod_5(Class76.Enum14 enum14_0, ResKey resKey_0)
		{
			List<string> list = new List<string>();
			list.AddRange(Class76.smethod_11());
			string string_ = Class76.smethod_4();
			DBPFEntry result;
			try
			{
				Class76.smethod_12(string_, ref list);
			}
			catch (Exception)
			{
				result = null;
				goto IL_22C;
			}
			foreach (string text in list)
			{
				string text2 = text;
				switch (enum14_0)
				{
				case Class76.Enum14.const_0:
					text2 = text + "\\Thumbnails\\AllThumbnails.package";
					if (!File.Exists(text2))
					{
						text2 = text + "\\Thumbnails\\ObjectThumbnails.package";
					}
					break;
				case Class76.Enum14.const_1:
					text2 = text + "\\Thumbnails\\CasThumbnails.package";
					break;
				}
				if (File.Exists(text2))
				{
					DBPF dbpf = Class76.smethod_6(text2);
					DBPFEntry entry = dbpf.GetEntry(resKey_0);
					if (entry != null)
					{
						dbpf.CloseFiles();
						result = entry;
						goto IL_22C;
					}
					dbpf.CloseFiles();
				}
			}
			foreach (string text3 in list)
			{
				string text4 = text3;
				switch (enum14_0)
				{
				case Class76.Enum14.const_0:
					text4 = text3 + "\\Thumbnails\\AllThumbnails.package";
					if (!File.Exists(text4))
					{
						text4 = text3 + "\\Thumbnails\\ObjectThumbnails.package";
					}
					break;
				case Class76.Enum14.const_1:
					text4 = text3 + "\\Thumbnails\\CasThumbnails.package";
					break;
				}
				if (File.Exists(text4))
				{
					DBPF dbpf2 = Class76.smethod_6(text4);
					List<ResKey> list2 = dbpf2.SearchEntries(new ResKey(DBPFType.ALL, resKey_0.GroupId, resKey_0.InstanceId, resKey_0.SecondInstanceId));
					if (list2.Count > 0)
					{
						DBPFEntry dbpfentry = null;
						foreach (ResKey resKey in list2)
						{
							if (resKey.TypeId == 92316342U)
							{
								dbpfentry = dbpf2.GetEntry(resKey);
							}
							else
							{
								if (resKey.TypeId != 1651466445U)
								{
									continue;
								}
								dbpfentry = dbpf2.GetEntry(resKey);
							}
							break;
						}
						if (dbpfentry == null)
						{
							dbpfentry = dbpf2.GetEntry(list2[0]);
						}
						dbpf2.CloseFiles();
						result = dbpfentry;
						goto IL_22C;
					}
					dbpf2.CloseFiles();
				}
			}
			return null;
			IL_22C:
			return result;
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x000671DC File Offset: 0x000653DC
		private static DBPF smethod_6(string string_0)
		{
			return Class76.smethod_7(string_0, false);
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x000671F4 File Offset: 0x000653F4
		private static DBPF smethod_7(string string_0, bool bool_0)
		{
			return Class76.smethod_8(string_0, bool_0, null);
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00067210 File Offset: 0x00065410
		private static DBPF smethod_8(string string_0, bool bool_0, DBPF.OnOpenProgress onOpenProgress_0)
		{
			if (bool_0)
			{
				try
				{
					string text = Class76.smethod_14();
					if (string.IsNullOrEmpty(text))
					{
						throw new Exception("Could not get game path.");
					}
					string_0 = text + "\\" + string_0;
				}
				catch (Exception0)
				{
					MessageBox.Show(null, Application.ProductName + " can not run without access to the game files, exiting.", "Error");
					Application.Exit();
				}
			}
			DBPF dbpf;
			DBPF result;
			if (Class76.dictionary_0.TryGetValue(string_0, out dbpf))
			{
				result = dbpf;
			}
			else
			{
				DBPF dbpf2 = new DBPF(string_0, onOpenProgress_0);
				Class76.dictionary_0.Add(string_0, dbpf2);
				result = dbpf2;
			}
			return result;
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x000672A8 File Offset: 0x000654A8
		public static int smethod_9(string string_0)
		{
			FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			binaryReader.BaseStream.Position = 36L;
			int result = binaryReader.ReadInt32();
			binaryReader.Close();
			fileStream.Close();
			fileStream.Dispose();
			return result;
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x000672F8 File Offset: 0x000654F8
		public static void smethod_10()
		{
			foreach (KeyValuePair<string, DBPF> keyValuePair in Class76.dictionary_0)
			{
				keyValuePair.Value.CloseFiles();
			}
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x00067354 File Offset: 0x00065554
		public static string[] smethod_11()
		{
			List<string> list = new List<string>();
			string text = null;
			try
			{
				text = Class76.smethod_14();
			}
			catch (Exception0)
			{
				MessageBox.Show(null, Application.ProductName + " can not run without access to the game files, exiting.", "Error");
				Application.Exit();
			}
			if (text != null)
			{
				list.Add(text);
			}
			list.AddRange(Class76.smethod_13());
			return list.ToArray();
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x000673C4 File Offset: 0x000655C4
		private static void smethod_12(string string_0, ref List<string> list_0)
		{
			if (Directory.Exists(string_0))
			{
				string[] directories = Directory.GetDirectories(string_0);
				foreach (string string_ in directories)
				{
					Class76.smethod_12(string_, ref list_0);
				}
				string[] files = Directory.GetFiles(string_0, "*.package");
				if (files.Length > 0)
				{
					list_0.Add(string_0);
				}
			}
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x00067420 File Offset: 0x00065620
		private static List<string> smethod_13()
		{
			List<string> list = new List<string>();
			string sims3WorldAdventuresGamePath = Settings.Default.Sims3WorldAdventuresGamePath;
			if (Directory.Exists(sims3WorldAdventuresGamePath) && Settings.Default.worldAdventuresEnabled)
			{
				string text = sims3WorldAdventuresGamePath;
				if (Directory.Exists(text))
				{
					list.Add(text);
				}
			}
			string sims3HelsGamePath = Settings.Default.Sims3HelsGamePath;
			if (Directory.Exists(sims3HelsGamePath) && Settings.Default.highendEnabled)
			{
				string text2 = sims3HelsGamePath;
				if (Directory.Exists(text2))
				{
					list.Add(text2);
				}
			}
			string sims3AmbitiationGamePath = Settings.Default.Sims3AmbitiationGamePath;
			if (Directory.Exists(sims3AmbitiationGamePath) && Settings.Default.ambitionsEnabled)
			{
				string text3 = sims3AmbitiationGamePath;
				if (Directory.Exists(text3))
				{
					list.Add(text3);
				}
			}
			string sims3FastLaneGamePath = Settings.Default.Sims3FastLaneGamePath;
			if (Directory.Exists(sims3FastLaneGamePath) && Settings.Default.fastlaneEnabled)
			{
				string text4 = sims3FastLaneGamePath;
				if (Directory.Exists(text4))
				{
					list.Add(text4);
				}
			}
			string sims3OutDoorLifeGamePath = Settings.Default.Sims3OutDoorLifeGamePath;
			if (Directory.Exists(sims3OutDoorLifeGamePath) && Settings.Default.outdoorEnabled)
			{
				string text5 = sims3OutDoorLifeGamePath;
				if (Directory.Exists(text5))
				{
					list.Add(text5);
				}
			}
			string sims3LateNightGamePath = Settings.Default.Sims3LateNightGamePath;
			if (Directory.Exists(sims3LateNightGamePath) && Settings.Default.lateNightEnabled)
			{
				string text6 = sims3LateNightGamePath;
				if (Directory.Exists(text6))
				{
					list.Add(text6);
				}
			}
			string sims3GenerationsGamePath = Settings.Default.Sims3GenerationsGamePath;
			if (Directory.Exists(sims3GenerationsGamePath) && Settings.Default.generationsEnabled)
			{
				string text7 = sims3GenerationsGamePath;
				if (Directory.Exists(text7))
				{
					list.Add(text7);
				}
			}
			string sims3TownLifeGameFolder = Settings.Default.Sims3TownLifeGameFolder;
			if (Directory.Exists(sims3TownLifeGameFolder) && Settings.Default.townlifeEnabled)
			{
				string text8 = sims3TownLifeGameFolder;
				if (Directory.Exists(text8))
				{
					list.Add(text8);
				}
			}
			string sims3PetsGamePath = Settings.Default.Sims3PetsGamePath;
			if (Directory.Exists(sims3PetsGamePath) && Settings.Default.petsEnabled)
			{
				string text9 = sims3PetsGamePath;
				if (Directory.Exists(text9))
				{
					list.Add(text9);
				}
			}
			string sims3ShowtimeGamePath = Settings.Default.Sims3ShowtimeGamePath;
			if (Directory.Exists(sims3ShowtimeGamePath) && Settings.Default.showtimeEnabled)
			{
				string text10 = sims3ShowtimeGamePath;
				if (Directory.Exists(text10))
				{
					list.Add(text10);
				}
			}
			string sims3MasterSuiteGameFolder = Settings.Default.Sims3MasterSuiteGameFolder;
			if (Directory.Exists(sims3MasterSuiteGameFolder) && Settings.Default.mastersuiteEnabled)
			{
				string text11 = sims3MasterSuiteGameFolder;
				if (Directory.Exists(text11))
				{
					list.Add(text11);
				}
			}
			string sims3KatyPerryGameFolder = Settings.Default.Sims3KatyPerryGameFolder;
			if (Directory.Exists(sims3KatyPerryGameFolder) && Settings.Default.katyperryEnabled)
			{
				string text12 = sims3KatyPerryGameFolder;
				if (Directory.Exists(text12))
				{
					list.Add(text12);
				}
			}
			string sims3DieselGameFolder = Settings.Default.Sims3DieselGameFolder;
			if (Directory.Exists(sims3DieselGameFolder) && Settings.Default.dieselEnabled)
			{
				string text13 = sims3DieselGameFolder;
				if (Directory.Exists(text13))
				{
					list.Add(text13);
				}
			}
			string sims3SupernaturalGameFolder = Settings.Default.Sims3SupernaturalGameFolder;
			if (Directory.Exists(sims3SupernaturalGameFolder) && Settings.Default.supernaturalEnabled)
			{
				string text14 = sims3SupernaturalGameFolder;
				if (Directory.Exists(text14))
				{
					list.Add(text14);
				}
			}
			string sims3SeasonsGameFolder = Settings.Default.Sims3SeasonsGameFolder;
			if (Directory.Exists(sims3SeasonsGameFolder) && Settings.Default.seasonsEnabled)
			{
				string text15 = sims3SeasonsGameFolder;
				if (Directory.Exists(text15))
				{
					list.Add(text15);
				}
			}
			string sims3SeventyGameFolder = Settings.Default.Sims3SeventyGameFolder;
			if (Directory.Exists(sims3SeventyGameFolder) && Settings.Default.seventyEnabled)
			{
				string text16 = sims3SeventyGameFolder;
				if (Directory.Exists(text16))
				{
					list.Add(text16);
				}
			}
			string sims3UniversityGameFolder = Settings.Default.Sims3UniversityGameFolder;
			if (Directory.Exists(sims3UniversityGameFolder) && Settings.Default.universityEnabled)
			{
				string text17 = sims3UniversityGameFolder;
				if (Directory.Exists(text17))
				{
					list.Add(text17);
				}
			}
			string sims3IslandParadiseGameFolder = Settings.Default.Sims3IslandParadiseGameFolder;
			if (Directory.Exists(sims3IslandParadiseGameFolder) && Settings.Default.islandParadiseEnabled)
			{
				string text18 = sims3IslandParadiseGameFolder;
				if (Directory.Exists(text18))
				{
					list.Add(text18);
				}
			}
			string sims3MovieStuffGameFolder = Settings.Default.Sims3MovieStuffGameFolder;
			if (Directory.Exists(sims3MovieStuffGameFolder) && Settings.Default.moviestuffEnabled)
			{
				string text19 = sims3MovieStuffGameFolder;
				if (Directory.Exists(text19))
				{
					list.Add(text19);
				}
			}
			string sims3IntoTheFutureGameFolder = Settings.Default.Sims3IntoTheFutureGameFolder;
			if (Directory.Exists(sims3IntoTheFutureGameFolder) && Settings.Default.intothefutureEnabled)
			{
				string text20 = sims3IntoTheFutureGameFolder;
				if (Directory.Exists(text20))
				{
					list.Add(text20);
				}
			}
			return list;
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x0006786C File Offset: 0x00065A6C
		private static string smethod_14()
		{
			string text = Settings.Default.Sims3InstallationPath;
			if (string.IsNullOrEmpty(text))
			{
				goto IL_152;
			}
			try
			{
				if (!Directory.Exists(text))
				{
					text = null;
				}
				else
				{
					string path = text + "\\GameData\\Shared\\Packages";
					if (!Directory.Exists(path))
					{
						text = null;
					}
				}
				goto IL_152;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to probe directory: " + ex.Message + ", please restart the app and select the Sims 3 directory in program files.");
				Settings.Default.Sims3InstallationPath = null;
				Settings.Default.Save();
				goto IL_152;
			}
			IL_73:
			text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Electronic Arts\\The Sims 3";
			if (!Directory.Exists(text + "\\GameData\\Shared\\Packages"))
			{
				text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Origin Games\\The Sims 3";
				if (!Directory.Exists(text + "\\GameData\\Shared\\Packages"))
				{
					if (MessageBox.Show(null, Application.ProductName + " could not locate the game folder. Would you like to browse for it manually?", Application.ProductName, MessageBoxButtons.YesNo) != DialogResult.Yes)
					{
						throw new Exception0();
					}
					FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
					folderBrowserDialog.Description = "Please select the Sims 3 directory (in program files)";
					if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
					{
						goto IL_15D;
					}
					text = folderBrowserDialog.SelectedPath;
					try
					{
						if (!Directory.Exists(text + "\\GameData\\Shared\\Packages"))
						{
							text = null;
						}
						else
						{
							Settings.Default.Sims3InstallationPath = text;
							Settings.Default.Save();
						}
					}
					catch (Exception ex2)
					{
						MessageBox.Show("Failed to probe directory: " + ex2.Message + ", please select the Sims 3 directory in program files.");
						text = null;
					}
				}
			}
			IL_152:
			if (string.IsNullOrEmpty(text))
			{
				goto IL_73;
			}
			IL_15D:
			return text;
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00067A00 File Offset: 0x00065C00
		public static int smethod_15()
		{
			int num = 0;
			string[] array = Class76.smethod_11();
			foreach (string text in array)
			{
				try
				{
					string path = text + "\\GameData\\Shared\\Packages";
					string[] fileSystemEntries = Directory.GetFileSystemEntries(path, "*.package");
					foreach (string string_ in fileSystemEntries)
					{
						num += Class76.smethod_9(string_);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Failed to count game files: " + text + ", please restart the app and select the Sims 3 directory in program files.\n\n" + ex.Message);
					Settings.Default.Sims3InstallationPath = null;
					Settings.Default.Save();
				}
			}
			return num;
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00067AC8 File Offset: 0x00065CC8
		public static ResKey smethod_16(ResKey resKey_0)
		{
			return Class76.smethod_17(resKey_0, false);
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00067AE0 File Offset: 0x00065CE0
		public static ResKey smethod_17(ResKey resKey_0, bool bool_0)
		{
			List<ResKey> list = Class76.smethod_21(resKey_0, 1, bool_0, false);
			ResKey result;
			if (list.Count == 0)
			{
				result = null;
			}
			else
			{
				result = list[list.Count - 1];
			}
			return result;
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00067B18 File Offset: 0x00065D18
		public static ResKey smethod_18(ResKey resKey_0, bool bool_0, bool bool_1)
		{
			List<ResKey> list = Class76.smethod_21(resKey_0, 1, bool_0, bool_1);
			ResKey result;
			if (list.Count == 0)
			{
				result = null;
			}
			else
			{
				result = list[list.Count - 1];
			}
			return result;
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00067B50 File Offset: 0x00065D50
		public static List<ResKey> smethod_19(ResKey resKey_0)
		{
			return Class76.smethod_21(resKey_0, 0, false, false);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00067B6C File Offset: 0x00065D6C
		public static List<ResKey> smethod_20(ResKey resKey_0, int int_0, bool bool_0)
		{
			return Class76.smethod_21(resKey_0, int_0, bool_0, false);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00067B88 File Offset: 0x00065D88
		public static List<ResKey> smethod_21(ResKey resKey_0, int int_0, bool bool_0, bool bool_1)
		{
			List<ResKey> list = new List<ResKey>();
			string[] array = Class76.smethod_11();
			List<ResKey> result;
			if (array.Length == 0)
			{
				result = list;
			}
			else
			{
				foreach (string str in array)
				{
					string text = str + "\\GameData\\Shared\\Packages";
					try
					{
						string[] fileSystemEntries = Directory.GetFileSystemEntries(text, "*.package");
						string path = str + "\\Game\\Bin\\Jazz";
						string[] array3 = null;
						if (Directory.Exists(path))
						{
							array3 = Directory.GetFileSystemEntries(path, "*.package");
						}
						string path2 = str + "\\Game\\Bin\\";
						string[] array4 = null;
						if (Directory.Exists(path2))
						{
							array4 = Directory.GetFileSystemEntries(path2, "*.package");
						}
						string path3 = str + "\\GameData\\Shared\\DeltaPackages";
						string[] array5 = null;
						if (Directory.Exists(path3))
						{
							List<string> list2 = new List<string>();
							list2.AddRange(Directory.GetFileSystemEntries(path3, "*.package"));
							string[] directories = Directory.GetDirectories(path3);
							foreach (string path4 in directories)
							{
								list2.AddRange(Directory.GetFileSystemEntries(path4, "*.package"));
							}
							array5 = list2.ToArray();
						}
						List<string> list3 = new List<string>();
						list3.AddRange(fileSystemEntries);
						if (array3 != null)
						{
							list3.AddRange(array3);
						}
						if (array4 != null)
						{
							list3.AddRange(array4);
						}
						if (array5 != null)
						{
							list3.AddRange(array5);
						}
						foreach (string string_ in list3)
						{
							DBPF dbpf = Class76.smethod_8(string_, false, new DBPF.OnOpenProgress(Class76.smethod_23));
							if (dbpf != null)
							{
								List<ResKey> list4 = dbpf.SearchEntries(resKey_0, int_0, bool_0);
								foreach (ResKey item in list4)
								{
									if (bool_1 && list.Contains(item))
									{
										list.Remove(item);
										list.Add(item);
									}
									else if (!list.Contains(item))
									{
										list.Add(item);
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(Class132.mainForm, "Could not load game folder contents.\n\nFolder: " + text + "\n\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				DBPF dbpf2 = Class76.smethod_8(Path.GetDirectoryName(Application.ExecutablePath) + "\\tsrw.package", false, new DBPF.OnOpenProgress(Class76.smethod_23));
				list.AddRange(dbpf2.SearchEntries(resKey_0, int_0, bool_0));
				DBPF dbpf3 = Class76.smethod_8(Path.GetDirectoryName(Application.ExecutablePath) + "\\rigs.package", false, new DBPF.OnOpenProgress(Class76.smethod_23));
				list.AddRange(dbpf3.SearchEntries(resKey_0, int_0, bool_0));
				List<object> list5 = new List<object>();
				foreach (object obj in Class76.hashtable_0.Values)
				{
					DBPFEntry dbpfentry = (DBPFEntry)obj;
					if (dbpfentry.Package != null && !list5.Contains(dbpfentry.Package))
					{
						List<ResKey> list6 = (dbpfentry.Package as DBPF).SearchEntries(resKey_0, int_0, bool_0);
						foreach (ResKey item2 in list6)
						{
							if (!list.Contains(item2))
							{
								list.Add(item2);
							}
						}
						list5.Add(dbpfentry.Package);
					}
				}
				list5.Clear();
				list5 = null;
				result = list;
			}
			return result;
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00067F98 File Offset: 0x00066198
		public static void smethod_22(DBPFEntry dbpfentry_0)
		{
			DBPF dbpf = Class76.smethod_8(Path.GetDirectoryName(Application.ExecutablePath) + "\\rigs.package", false, null);
			dbpf.AddEntry(dbpfentry_0);
			dbpf.Save(true);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00005553 File Offset: 0x00003753
		private static void smethod_23(int int_0, int int_1)
		{
			if (Class76.delegate18_0 != null)
			{
				Class76.delegate18_0(int_0, int_1);
			}
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00067FD4 File Offset: 0x000661D4
		public static List<DBPFEntry> smethod_24(ResKey resKey_0)
		{
			return Class76.smethod_25(resKey_0, false);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00067FEC File Offset: 0x000661EC
		public static List<DBPFEntry> smethod_25(ResKey resKey_0, bool bool_0)
		{
			List<DBPFEntry> list = new List<DBPFEntry>();
			List<ResKey> list2 = Class76.smethod_20(resKey_0, 0, false);
			foreach (ResKey resKey in list2)
			{
				try
				{
					resKey.AsString();
					DBPFEntry dbpfentry = Class76.smethod_27(resKey, true);
					if (dbpfentry != null)
					{
						list.Add(dbpfentry);
					}
				}
				catch (Exception)
				{
				}
			}
			return list;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00068078 File Offset: 0x00066278
		public static DBPFEntry smethod_26(ResKey resKey_0)
		{
			return Class76.smethod_31(resKey_0, false, true, false);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00068094 File Offset: 0x00066294
		public static DBPFEntry smethod_27(ResKey resKey_0, bool bool_0)
		{
			return Class76.smethod_30(resKey_0, bool_0, false);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0000556A File Offset: 0x0000376A
		public static void smethod_28(ResKey resKey_0, DBPFEntry dbpfentry_0)
		{
			if (!Class76.hashtable_0.Contains(resKey_0.AsString()))
			{
				Class76.hashtable_0.Add(resKey_0.AsString(), dbpfentry_0);
			}
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00005591 File Offset: 0x00003791
		public static void smethod_29()
		{
			Class76.hashtable_0.Clear();
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x000680B0 File Offset: 0x000662B0
		public static DBPFEntry smethod_30(ResKey resKey_0, bool bool_0, bool bool_1)
		{
			return Class76.smethod_31(resKey_0, bool_0, bool_1, false);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x000680CC File Offset: 0x000662CC
		public static DBPFEntry smethod_31(ResKey resKey_0, bool bool_0, bool bool_1, bool bool_2)
		{
			DBPFEntry dbpfentry = null;
			if (Class132.mainForm.CurrentProject != null)
			{
				DBPF dbpf = Class132.mainForm.CurrentProject.Package;
				dbpfentry = dbpf.GetEntry(resKey_0);
				if (dbpfentry != null)
				{
					return dbpfentry;
				}
			}
			resKey_0.AsString();
			if (Class76.hashtable_0.Contains(resKey_0.AsString()))
			{
				dbpfentry = (Class76.hashtable_0[resKey_0.AsString()] as DBPFEntry);
			}
			if (dbpfentry == null)
			{
				if (string.IsNullOrEmpty(resKey_0.FileName))
				{
					resKey_0.AsString().Equals("key:319e4f1d:00000000:4d594dd0547a049a");
					ResKey resKey = Class76.smethod_18(resKey_0, bool_1, bool_2);
					resKey_0 = resKey;
					if (resKey_0 == null)
					{
						return null;
					}
				}
				if (resKey_0.FileName == null)
				{
					return null;
				}
				DBPF dbpf = Class76.smethod_6(resKey_0.FileName);
				if (dbpf == null)
				{
					return null;
				}
				dbpf.KeepOpen = bool_0;
				dbpfentry = dbpf.GetEntry(resKey_0);
			}
			DBPFEntry result;
			if (dbpfentry == null)
			{
				result = null;
			}
			else
			{
				if (Class76.hashtable_0.Contains(resKey_0.AsString()))
				{
					Class76.hashtable_0.Remove(resKey_0.AsString());
				}
				Class76.hashtable_0.Add(resKey_0.AsString(), dbpfentry);
				result = dbpfentry;
			}
			return result;
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x000681DC File Offset: 0x000663DC
		public static Color smethod_32(string string_0)
		{
			Color result;
			try
			{
				string[] array = string_0.Split(new char[]
				{
					','
				});
				if (array.Length != 4)
				{
					result = Color.White;
				}
				else
				{
					Color color = Color.FromArgb((int)(255f * float.Parse(array[3], CultureInfo.InvariantCulture.NumberFormat)), (int)(255f * float.Parse(array[0], CultureInfo.InvariantCulture.NumberFormat)), (int)(255f * float.Parse(array[1], CultureInfo.InvariantCulture.NumberFormat)), (int)(255f * float.Parse(array[2], CultureInfo.InvariantCulture.NumberFormat)));
					result = color;
				}
			}
			catch (Exception)
			{
				result = Color.White;
			}
			return result;
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0006829C File Offset: 0x0006649C
		public static string smethod_33(Color color_0)
		{
			float num = (float)color_0.R / 255f;
			float num2 = (float)color_0.G / 255f;
			float num3 = (float)color_0.B / 255f;
			float num4 = (float)color_0.A / 255f;
			string str = num.ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",";
			str = str + num2.ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",";
			str = str + num3.ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat) + ",";
			return str + num4.ToString("0.0000000", CultureInfo.InvariantCulture.NumberFormat);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00068378 File Offset: 0x00066578
		public static float smethod_34(string string_0)
		{
			float result;
			try
			{
				result = float.Parse(string_0, CultureInfo.InvariantCulture.NumberFormat);
			}
			catch (Exception)
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x000683B8 File Offset: 0x000665B8
		public static string smethod_35(byte byte_0, ulong ulong_0)
		{
			List<DBPFEntry> list = Class76.smethod_24(new ResKey(DBPFType.STBL, 0, 0, 0));
			string text;
			foreach (DBPFEntry dbpfentry in list)
			{
				STBL stbl = (STBL)dbpfentry;
				if (stbl.InstanceID >> 24 == (int)byte_0)
				{
					STBL.STBLEntry stblentry = null;
					if (stbl.Entries.TryGetValue(ulong_0, out stblentry))
					{
						text = stblentry.Text;
						goto IL_70;
					}
				}
			}
			return null;
			IL_70:
			return text;
		}

		// Token: 0x04000626 RID: 1574
		private static Class76.Delegate18 delegate18_0;

		// Token: 0x04000627 RID: 1575
		private static Dictionary<string, DBPF> dictionary_0 = new Dictionary<string, DBPF>();

		// Token: 0x04000628 RID: 1576
		private static Hashtable hashtable_0 = new Hashtable();

		// Token: 0x020000B0 RID: 176
		// (Invoke) Token: 0x060006F7 RID: 1783
		public delegate void Delegate18(int percent, int filecount);

		// Token: 0x020000B1 RID: 177
		public enum Enum14
		{
			// Token: 0x0400062A RID: 1578
			const_0 = 1,
			// Token: 0x0400062B RID: 1579
			const_1
		}
	}
}
