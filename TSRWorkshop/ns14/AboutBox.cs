using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ns17;

namespace ns14
{
	// Token: 0x020000C7 RID: 199
	internal sealed partial class AboutBox : Form
	{
		// Token: 0x06000865 RID: 2149 RVA: 0x00077444 File Offset: 0x00075644
		public AboutBox()
		{
			this.InitializeComponent();
			this.Text = string.Format("About {0}", this.AssemblyTitle);
			this.labelProductName.Text = this.AssemblyProduct;
			this.labelVersion.Text = string.Format("Version {0} {0}", this.AssemblyVersion);
			this.labelCopyright.Text = this.AssemblyCopyright;
			this.labelCompanyName.Text = this.AssemblyCompany;
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x000774C4 File Offset: 0x000756C4
		public string AssemblyTitle
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (customAttributes.Length > 0)
				{
					AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
					if (assemblyTitleAttribute.Title != "")
					{
						return assemblyTitleAttribute.Title;
					}
				}
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x00077524 File Offset: 0x00075724
		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x0007754C File Offset: 0x0007574C
		public string AssemblyDescription
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				string result;
				if (customAttributes.Length == 0)
				{
					result = "";
				}
				else
				{
					result = ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
				}
				return result;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x00077590 File Offset: 0x00075790
		public string AssemblyProduct
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				string result;
				if (customAttributes.Length == 0)
				{
					result = "";
				}
				else
				{
					result = ((AssemblyProductAttribute)customAttributes[0]).Product;
				}
				return result;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x000775D4 File Offset: 0x000757D4
		public string AssemblyCopyright
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				string result;
				if (customAttributes.Length == 0)
				{
					result = "";
				}
				else
				{
					result = ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
				}
				return result;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x0600086B RID: 2155 RVA: 0x00077618 File Offset: 0x00075818
		public string AssemblyCompany
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				string result;
				if (customAttributes.Length == 0)
				{
					result = "";
				}
				else
				{
					result = ((AssemblyCompanyAttribute)customAttributes[0]).Company;
				}
				return result;
			}
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x00005CEC File Offset: 0x00003EEC
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040006A9 RID: 1705
		private IContainer icontainer_0;
	}
}
