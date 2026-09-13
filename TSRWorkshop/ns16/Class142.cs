using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ns14;
using ns6;
using ns8;
using Sims3Workshop;
using Sims3Workshop.Properties;
using Sims3WorkshopSDK;

namespace ns16
{
	// Token: 0x02000137 RID: 311
	internal static class Class142
	{
		// Token: 0x06000E5B RID: 3675 RVA: 0x000B4800 File Offset: 0x000B2A00
		[STAThread]
		private static void Main(string[] args)
		{
			if (Class211.smethod_4())
			{
				Class132.smethod_1(Environment.CurrentDirectory);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TSRWorkshop";
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				if (Settings.Default.IsFirstRun)
				{
					try
					{
						Settings.Default.Upgrade();
					}
					catch (Exception)
					{
					}
					Settings.Default.IsFirstRun = false;
					Settings.Default.Save();
				}
				Form form = Class132.mainForm;
				if (args.Length > 0 && args[0].ToLower().Equals("/run"))
				{
					string text = args[1];
					string[] array = text.Split(new char[]
					{
						'#'
					});
					string text2 = array[1];
					string path2 = Application.StartupPath + "\\" + array[0];
					if (File.Exists(path2))
					{
						Assembly assembly = Assembly.LoadFile(path2);
						Type[] types = assembly.GetTypes();
						foreach (Type type in types)
						{
							if (type.Name.ToLower().Equals(text2.ToLower()) && typeof(RunnableWorkshopExtensionForm).IsAssignableFrom(type))
							{
								form = (assembly.CreateInstance(type.FullName) as Form);
								(form as RunnableWorkshopExtensionForm).SetWorkshopInstance(Class132.mainForm);
							}
						}
					}
				}
				if (form is Mainform)
				{
					int num = (form as Mainform).SetupDevice();
					if (num < 0)
					{
						if (num != -2)
						{
							if (num != -3)
							{
								MessageBox.Show(form, "Could not setup device (errcode: " + num + ")\n\nThis is probably because the requirements for SlimDX are not met. Reinstalling DirectX may solve this problem.", "No Device", MessageBoxButtons.OK);
								Process.Start("http://www.microsoft.com/en-us/download/details.aspx?id=35");
								return;
							}
						}
						if (MessageBox.Show(form, "Could not setup device (errcode: " + num + ")\n\nSlimDX requires the latest DirectX9 runtime.\n\nClick Yes to open the download page for the latest DirectX runtime.\n\nClicking No will exit.", "No Device", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							Process.Start("http://www.microsoft.com/en-us/download/details.aspx?id=35");
						}
					}
					else
					{
						form.Show();
						while (form.Created)
						{
							(form as Mainform).Render(false);
							Application.DoEvents();
						}
						Class140.smethod_0().method_7();
					}
				}
				else
				{
					Application.Run(form);
				}
			}
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x000B4A38 File Offset: 0x000B2C38
		public static uint smethod_0(uint uint_0)
		{
			return (uint_0 & 255U) << 24 | (uint_0 & 65280U) << 8 | (uint_0 & 16711680U) >> 8 | (uint_0 & 4278190080U) >> 24;
		}
	}
}
