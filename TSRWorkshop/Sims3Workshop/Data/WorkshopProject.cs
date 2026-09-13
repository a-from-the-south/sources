using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using ns1;
using ns21;
using ns8;
using Package;
using Sims3Workshop.Properties;
using Sims3WorkshopSDK.Interfaces;

namespace Sims3Workshop.Data
{
	// Token: 0x020000C6 RID: 198
	[Serializable]
	public sealed class WorkshopProject : IWorkshopProject
	{
		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000844 RID: 2116 RVA: 0x00076C48 File Offset: 0x00074E48
		// (remove) Token: 0x06000845 RID: 2117 RVA: 0x00076C80 File Offset: 0x00074E80
		public event Delegate21 OnSave
		{
			add
			{
				Delegate21 @delegate = this.delegate21_0;
				Delegate21 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate21 value2 = (Delegate21)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate21>(ref this.delegate21_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate21 @delegate = this.delegate21_0;
				Delegate21 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate21 value2 = (Delegate21)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate21>(ref this.delegate21_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x00076CB8 File Offset: 0x00074EB8
		// (set) Token: 0x06000847 RID: 2119 RVA: 0x00005C58 File Offset: 0x00003E58
		public Dictionary<string, string> MetaData { get; set; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x00076CD0 File Offset: 0x00074ED0
		// (set) Token: 0x06000849 RID: 2121 RVA: 0x00005C63 File Offset: 0x00003E63
		public Dictionary<string, object> MetaObjects { get; set; }

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x00076CE8 File Offset: 0x00074EE8
		public byte[] ThumbnailData
		{
			get
			{
				return this._thumbnailData;
			}
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x00076D00 File Offset: 0x00074F00
		public WorkshopProject(string name)
		{
			this.type = ProjectType.EMPTY;
			this.dbpf_0 = new DBPF();
			this.name = name;
			this.bool_0 = false;
			this.string_0 = null;
			this.class89_0 = new Class89();
			this.bool_0 = true;
			this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData = new Dictionary<string, string>();
			this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaObjects = new Dictionary<string, object>();
			this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("CreatedVersion", Application.ProductVersion);
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x00076D7C File Offset: 0x00074F7C
		public static WorkshopProject smethod_0()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = ((WorkshopProject.lastOpenedProjectFolder != null) ? WorkshopProject.lastOpenedProjectFolder : Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
			openFileDialog.Filter = "workshop project(*.wrk)|*.wrk";
			WorkshopProject result;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
				WorkshopProject.lastOpenedProjectFolder = Path.GetFullPath(fileName);
				result = WorkshopProject.smethod_1(fileName);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x00076DE0 File Offset: 0x00074FE0
		public static WorkshopProject smethod_1(string string_1)
		{
			FileStream fileStream = null;
			WorkshopProject workshopProject = null;
			try
			{
				fileStream = new FileStream(string_1, FileMode.Open);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				int num = (int)binaryFormatter.Deserialize(fileStream);
				int num2 = (int)binaryFormatter.Deserialize(fileStream);
				if (num < WorkshopProject.int_0)
				{
					throw new Exception("This project is created with an older version of workshop and can not opened.");
				}
				workshopProject = (WorkshopProject)binaryFormatter.Deserialize(fileStream);
				workshopProject.Package = new DBPF("package", workshopProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.PackageData);
				workshopProject.Package.ReadEntries();
				workshopProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Filename = string_1;
				if (workshopProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaObjects == null)
				{
					workshopProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaObjects = new Dictionary<string, object>();
				}
				workshopProject.class89_0 = new Class89();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
			return workshopProject;
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x00076EB4 File Offset: 0x000750B4
		public DialogResult method_2()
		{
			DialogResult dialogResult = DialogResult.OK;
			if (this.bool_0)
			{
				dialogResult = MessageBox.Show("You have unsaved changes, do you want to save them now?", "Close project", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Save();
				}
			}
			return dialogResult;
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00005C6E File Offset: 0x00003E6E
		private void method_3()
		{
			this.packageData = this.dbpf_0.Save(false);
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x00076EF0 File Offset: 0x000750F0
		public bool Save()
		{
			bool result;
			if (this.string_0 == null)
			{
				result = this.method_4(false);
			}
			else
			{
				result = this.method_5(this.string_0);
			}
			return result;
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00076F20 File Offset: 0x00075120
		public bool method_4(bool bool_1)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = (WorkshopProject.lastOpenedProjectFolder ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
			saveFileDialog.Filter = "workshop project(*.wrk)|*.wrk";
			string text = this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Name;
			if (text.Contains("/"))
			{
				text = text.Substring(text.IndexOf("/") + 1);
			}
			if (!string.IsNullOrEmpty(text))
			{
				saveFileDialog.FileName = text;
			}
			bool result;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (string.IsNullOrEmpty(this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Name))
				{
					this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.Name = Path.GetFileName(saveFileDialog.FileName);
				}
				this.string_0 = saveFileDialog.FileName;
				if (bool_1)
				{
					result = this.method_6(saveFileDialog.FileName);
				}
				else
				{
					result = this.method_5(saveFileDialog.FileName);
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00076FE4 File Offset: 0x000751E4
		public bool method_5(string string_1)
		{
			if (this.delegate21_0 != null)
			{
				this.delegate21_0();
			}
			this.method_3();
			this.string_0 = string_1;
			FileStream fileStream = null;
			try
			{
				try
				{
					Bitmap bitmap = Class132.mainForm.CurrentProjectModel.GetThumbnail() as Bitmap;
					if (bitmap != null)
					{
						MemoryStream memoryStream = new MemoryStream();
						bitmap.Save(memoryStream, ImageFormat.Bmp);
						this._thumbnailData = memoryStream.ToArray();
						memoryStream.Dispose();
					}
				}
				catch (Exception)
				{
				}
				string productVersion = Application.ProductVersion;
				if (!this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("LastSavedVersion"))
				{
					this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("LastSavedVersion", productVersion);
				}
				else
				{
					this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["LastSavedVersion"] = productVersion;
				}
				fileStream = new FileStream(string_1, FileMode.Create);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(fileStream, WorkshopProject.int_0);
				binaryFormatter.Serialize(fileStream, WorkshopProject.int_1);
				binaryFormatter.Serialize(fileStream, this);
				this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = false;
				if (Settings.Default.RecentProjects == null)
				{
					Settings.Default.RecentProjects = new StringCollection();
				}
				if (!Settings.Default.RecentProjects.Contains(string_1))
				{
					Settings.Default.RecentProjects.Insert(0, string_1);
					Settings.Default.Save();
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
			return true;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00077180 File Offset: 0x00075380
		public bool method_6(string string_1)
		{
			if (this.delegate21_0 != null)
			{
				this.delegate21_0();
			}
			FileStream fileStream = null;
			try
			{
				byte[] array = this.packageData;
				try
				{
					Bitmap bitmap = Class132.mainForm.CurrentProjectModel.GetThumbnail() as Bitmap;
					if (bitmap != null)
					{
						MemoryStream memoryStream = new MemoryStream();
						bitmap.Save(memoryStream, ImageFormat.Bmp);
						this._thumbnailData = memoryStream.ToArray();
						memoryStream.Dispose();
					}
				}
				catch (Exception)
				{
				}
				string productVersion = Application.ProductVersion;
				if (!this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("LastSavedVersion"))
				{
					this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.Add("LastSavedVersion", productVersion);
				}
				else
				{
					this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["LastSavedVersion"] = productVersion;
				}
				fileStream = new FileStream(string_1, FileMode.Create);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				this.method_3();
				binaryFormatter.Serialize(fileStream, WorkshopProject.int_0);
				binaryFormatter.Serialize(fileStream, WorkshopProject.int_1);
				binaryFormatter.Serialize(fileStream, this);
				this.packageData = array;
				this.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = false;
				if (Settings.Default.RecentProjects == null)
				{
					Settings.Default.RecentProjects = new StringCollection();
				}
				if (!Settings.Default.RecentProjects.Contains(string_1))
				{
					Settings.Default.RecentProjects.Insert(0, string_1);
					Settings.Default.Save();
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
			return true;
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x00077328 File Offset: 0x00075528
		// (set) Token: 0x06000855 RID: 2133 RVA: 0x00005C84 File Offset: 0x00003E84
		public ProjectType Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x00077340 File Offset: 0x00075540
		// (set) Token: 0x06000857 RID: 2135 RVA: 0x00005C84 File Offset: 0x00003E84
		public ProjectType ProjectType
		{
			get
			{
				return (ProjectType)this.type;
			}
			set
			{
				this.type = (ProjectType)value;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000858 RID: 2136 RVA: 0x00077358 File Offset: 0x00075558
		// (set) Token: 0x06000859 RID: 2137 RVA: 0x00005C8F File Offset: 0x00003E8F
		public string Filename
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x0600085A RID: 2138 RVA: 0x00077370 File Offset: 0x00075570
		// (set) Token: 0x0600085B RID: 2139 RVA: 0x00005C9A File Offset: 0x00003E9A
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x00077388 File Offset: 0x00075588
		// (set) Token: 0x0600085D RID: 2141 RVA: 0x00005CA5 File Offset: 0x00003EA5
		public bool HasChanges
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.class89_0.method_0(new EventArgs());
			}
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x000773A0 File Offset: 0x000755A0
		public string ToString()
		{
			return (this.bool_0 ? "* " : "") + this.name + ((this.string_0 == null) ? "" : (" (" + Path.GetFileName(this.string_0) + ")"));
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x000773FC File Offset: 0x000755FC
		// (set) Token: 0x06000860 RID: 2144 RVA: 0x00005CC0 File Offset: 0x00003EC0
		public DBPF Package
		{
			get
			{
				return this.dbpf_0;
			}
			set
			{
				this.dbpf_0 = value;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x00077414 File Offset: 0x00075614
		public object CurrentPackage
		{
			get
			{
				return this.dbpf_0;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x0007742C File Offset: 0x0007562C
		// (set) Token: 0x06000863 RID: 2147 RVA: 0x00005CCB File Offset: 0x00003ECB
		public byte[] PackageData
		{
			get
			{
				return this.packageData;
			}
			set
			{
				this.packageData = value;
			}
		}

		// Token: 0x0400069B RID: 1691
		[NonSerialized]
		private string string_0;

		// Token: 0x0400069C RID: 1692
		[NonSerialized]
		private bool bool_0;

		// Token: 0x0400069D RID: 1693
		[NonSerialized]
		private static int int_0 = 2;

		// Token: 0x0400069E RID: 1694
		[NonSerialized]
		private static int int_1 = 1;

		// Token: 0x0400069F RID: 1695
		[NonSerialized]
		public Class89 class89_0;

		// Token: 0x040006A0 RID: 1696
		[NonSerialized]
		private DBPF dbpf_0;

		// Token: 0x040006A1 RID: 1697
		[NonSerialized]
		private Delegate21 delegate21_0;

		// Token: 0x040006A2 RID: 1698
		private byte[] packageData;

		// Token: 0x040006A3 RID: 1699
		private byte[] _thumbnailData;

		// Token: 0x040006A4 RID: 1700
		private string name;

		// Token: 0x040006A5 RID: 1701
		private ProjectType type;

		// Token: 0x040006A6 RID: 1702
		private static string lastOpenedProjectFolder = null;
	}
}
