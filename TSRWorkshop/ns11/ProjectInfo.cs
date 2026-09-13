using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns8;
using Sims3Workshop.Data;

namespace ns11
{
	// Token: 0x020000E7 RID: 231
	internal sealed partial class ProjectInfo : Form
	{
		// Token: 0x06000973 RID: 2419 RVA: 0x00083348 File Offset: 0x00081548
		public ProjectInfo()
		{
			this.InitializeComponent();
			WorkshopProject currentProject = Class132.mainForm.CurrentProject;
			if (currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("CreatedVersion"))
			{
				TextBox textBox = this.info;
				textBox.Text = textBox.Text + "Created with version " + currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["CreatedVersion"] + Environment.NewLine;
			}
			else
			{
				TextBox textBox2 = this.info;
				textBox2.Text = textBox2.Text + "Could not find created version for this project" + Environment.NewLine;
			}
			if (currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData.ContainsKey("LastSavedVersion"))
			{
				TextBox textBox3 = this.info;
				textBox3.Text = textBox3.Text + "Last saved with version " + currentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.MetaData["LastSavedVersion"] + Environment.NewLine;
			}
			else
			{
				TextBox textBox4 = this.info;
				textBox4.Text = textBox4.Text + "Could not find last saved version for this project" + Environment.NewLine;
			}
			this.info.Select(0, 0);
			this.info.SelectionStart = 0;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x00002A71 File Offset: 0x00000C71
		private void ProjectInfo_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x00006327 File Offset: 0x00004527
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040007A1 RID: 1953
		private IContainer icontainer_0;
	}
}
