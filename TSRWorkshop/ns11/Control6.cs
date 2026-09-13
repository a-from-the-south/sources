using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns10;
using Sims3Workshop.Properties;

namespace ns11
{
	// Token: 0x02000131 RID: 305
	internal sealed class Control6 : UserControl, Interface11
	{
		// Token: 0x06000E17 RID: 3607 RVA: 0x000AE9DC File Offset: 0x000ACBDC
		public Control6()
		{
			this.method_2();
			this.askAllowedInternet.Checked = Settings.Default.AskAllowInternet;
			this.allowInternet.Checked = Settings.Default.AllowInternet;
			this.gamePath.Text = Settings.Default.Sims3InstallationPath;
			this.string_0 = (string.IsNullOrEmpty(this.gamePath.Text) ? this.string_0 : this.gamePath.Text);
			this.waPath.Text = Settings.Default.Sims3WorldAdventuresGamePath;
			this.string_0 = (string.IsNullOrEmpty(this.waPath.Text) ? this.string_0 : this.waPath.Text);
			this.helsPath.Text = Settings.Default.Sims3HelsGamePath;
			this.string_0 = (string.IsNullOrEmpty(this.waPath.Text) ? this.string_0 : this.helsPath.Text);
			this.ambitionsFolder.Text = Settings.Default.Sims3AmbitiationGamePath;
			this.string_0 = (string.IsNullOrEmpty(this.ambitionsFolder.Text) ? this.string_0 : this.ambitionsFolder.Text);
			this.fastLaneFolder.Text = Settings.Default.Sims3FastLaneGamePath;
			this.string_0 = (string.IsNullOrEmpty(this.fastLaneFolder.Text) ? this.string_0 : this.fastLaneFolder.Text);
			this.outdoorLifeFolder.Text = Settings.Default.Sims3OutDoorLifeGamePath;
			this.string_0 = (string.IsNullOrEmpty(this.outdoorLifeFolder.Text) ? this.string_0 : this.outdoorLifeFolder.Text);
			this.lateNightFolder.Text = Settings.Default.Sims3LateNightGamePath;
			this.string_0 = (string.IsNullOrEmpty(this.lateNightFolder.Text) ? this.string_0 : this.lateNightFolder.Text);
			this.generationsFolder.Text = Settings.Default.Sims3GenerationsGamePath;
			this.string_0 = (string.IsNullOrEmpty(this.generationsFolder.Text) ? this.string_0 : this.generationsFolder.Text);
			this.townlifeFolder.Text = Settings.Default.Sims3TownLifeGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.townlifeFolder.Text) ? this.string_0 : this.townlifeFolder.Text);
			this.petsFolder.Text = Settings.Default.Sims3PetsGamePath;
			this.string_0 = (string.IsNullOrEmpty(this.petsFolder.Text) ? this.string_0 : this.petsFolder.Text);
			this.showtimeFolder.Text = Settings.Default.Sims3ShowtimeGamePath;
			this.string_0 = (string.IsNullOrEmpty(this.showtimeFolder.Text) ? this.string_0 : this.showtimeFolder.Text);
			this.mastersuiteFolder.Text = Settings.Default.Sims3MasterSuiteGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.mastersuiteFolder.Text) ? this.string_0 : this.mastersuiteFolder.Text);
			this.katyperryFolder.Text = Settings.Default.Sims3KatyPerryGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.katyperryFolder.Text) ? this.string_0 : this.katyperryFolder.Text);
			this.dieselFolder.Text = Settings.Default.Sims3DieselGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.dieselFolder.Text) ? this.string_0 : this.dieselFolder.Text);
			this.superNaturalFolder.Text = Settings.Default.Sims3SupernaturalGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.superNaturalFolder.Text) ? this.string_0 : this.superNaturalFolder.Text);
			this.seasonsFolder.Text = Settings.Default.Sims3SeasonsGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.seasonsFolder.Text) ? this.string_0 : this.seasonsFolder.Text);
			this.seventiesFolder.Text = Settings.Default.Sims3SeventyGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.seventiesFolder.Text) ? this.string_0 : this.seventiesFolder.Text);
			this.universityFolder.Text = Settings.Default.Sims3UniversityGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.universityFolder.Text) ? this.string_0 : this.universityFolder.Text);
			this.islandParadiseFolder.Text = Settings.Default.Sims3IslandParadiseGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.islandParadiseFolder.Text) ? this.string_0 : this.islandParadiseFolder.Text);
			this.moviestuffFolder.Text = Settings.Default.Sims3MovieStuffGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.moviestuffFolder.Text) ? this.string_0 : this.moviestuffFolder.Text);
			this.intothefutureFolder.Text = Settings.Default.Sims3IntoTheFutureGameFolder;
			this.string_0 = (string.IsNullOrEmpty(this.intothefutureFolder.Text) ? this.string_0 : this.intothefutureFolder.Text);
			this.worldAdventuresCheckbox.Checked = !string.IsNullOrEmpty(this.waPath.Text);
			this.highEndCheckbox.Checked = !string.IsNullOrEmpty(this.helsPath.Text);
			this.ambitionsCheckbox.Checked = !string.IsNullOrEmpty(this.ambitionsFolder.Text);
			this.fastLaneCheckbox.Checked = !string.IsNullOrEmpty(this.fastLaneFolder.Text);
			this.latenightCheckbox.Checked = !string.IsNullOrEmpty(this.lateNightFolder.Text);
			this.outdoorCheckbox.Checked = !string.IsNullOrEmpty(this.outdoorLifeFolder.Text);
			this.generationsCheckBox.Checked = !string.IsNullOrEmpty(this.generationsFolder.Text);
			this.townlifeCheckbox.Checked = !string.IsNullOrEmpty(this.townlifeFolder.Text);
			this.petsCheckbox.Checked = !string.IsNullOrEmpty(this.petsFolder.Text);
			this.showtimeCheckbox.Checked = !string.IsNullOrEmpty(this.showtimeFolder.Text);
			this.mastersuiteCheckbox.Checked = !string.IsNullOrEmpty(this.mastersuiteFolder.Text);
			this.katyPerryCheckbox.Checked = !string.IsNullOrEmpty(this.katyperryFolder.Text);
			this.dieselCheckbox.Checked = !string.IsNullOrEmpty(this.dieselFolder.Text);
			this.supernaturalCheckbox.Checked = !string.IsNullOrEmpty(this.superNaturalFolder.Text);
			this.seasonsCheckbox.Checked = !string.IsNullOrEmpty(this.seasonsFolder.Text);
			this.seventiesCheckbox.Checked = !string.IsNullOrEmpty(this.seventiesFolder.Text);
			this.universityCheckbox.Checked = !string.IsNullOrEmpty(this.universityFolder.Text);
			this.islandParadiseCheckbox.Checked = !string.IsNullOrEmpty(this.islandParadiseFolder.Text);
			this.moviestuffCheckbox.Checked = !string.IsNullOrEmpty(this.moviestuffFolder.Text);
			this.intothefutureCheckbox.Checked = !string.IsNullOrEmpty(this.intothefutureFolder.Text);
			this.worldAdventuresCheckbox_Click(null, null);
			this.method_0();
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x000AF1C8 File Offset: 0x000AD3C8
		private void worldAdventuresCheckbox_Click(object sender, EventArgs e)
		{
			Settings.Default.worldAdventuresEnabled = this.worldAdventuresCheckbox.Checked;
			Settings.Default.highendEnabled = this.highEndCheckbox.Checked;
			Settings.Default.ambitionsEnabled = this.ambitionsCheckbox.Checked;
			Settings.Default.fastlaneEnabled = this.fastLaneCheckbox.Checked;
			Settings.Default.lateNightEnabled = this.latenightCheckbox.Checked;
			Settings.Default.outdoorEnabled = this.outdoorCheckbox.Checked;
			Settings.Default.generationsEnabled = this.generationsCheckBox.Checked;
			Settings.Default.townlifeEnabled = this.townlifeCheckbox.Checked;
			Settings.Default.petsEnabled = this.petsCheckbox.Checked;
			Settings.Default.showtimeEnabled = this.showtimeCheckbox.Checked;
			Settings.Default.mastersuiteEnabled = this.mastersuiteCheckbox.Checked;
			Settings.Default.katyperryEnabled = this.katyPerryCheckbox.Checked;
			Settings.Default.dieselEnabled = this.dieselCheckbox.Checked;
			Settings.Default.supernaturalEnabled = this.supernaturalCheckbox.Checked;
			Settings.Default.seasonsEnabled = this.seasonsCheckbox.Checked;
			Settings.Default.seventyEnabled = this.seventiesCheckbox.Checked;
			Settings.Default.universityEnabled = this.universityCheckbox.Checked;
			Settings.Default.islandParadiseEnabled = this.islandParadiseCheckbox.Checked;
			Settings.Default.moviestuffEnabled = this.moviestuffCheckbox.Checked;
			Settings.Default.intothefutureEnabled = this.intothefutureCheckbox.Checked;
			this.method_0();
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x000AF384 File Offset: 0x000AD584
		private void method_0()
		{
			this.gameDataFolder.Text = Settings.Default.myDocumentsFolder;
			this.browseWAButton.Enabled = (this.worldAdventuresCheckbox.Checked = Settings.Default.worldAdventuresEnabled);
			this.waPath.Enabled = Settings.Default.worldAdventuresEnabled;
			this.button2.Enabled = (this.highEndCheckbox.Checked = Settings.Default.highendEnabled);
			this.helsPath.Enabled = Settings.Default.highendEnabled;
			this.button3.Enabled = (this.ambitionsCheckbox.Checked = Settings.Default.ambitionsEnabled);
			this.ambitionsFolder.Enabled = Settings.Default.ambitionsEnabled;
			this.button4.Enabled = (this.fastLaneCheckbox.Checked = Settings.Default.fastlaneEnabled);
			this.fastLaneFolder.Enabled = Settings.Default.fastlaneEnabled;
			this.button5.Enabled = (this.latenightCheckbox.Checked = Settings.Default.lateNightEnabled);
			this.lateNightFolder.Enabled = Settings.Default.lateNightEnabled;
			this.button6.Enabled = (this.outdoorCheckbox.Checked = Settings.Default.outdoorEnabled);
			this.outdoorLifeFolder.Enabled = Settings.Default.outdoorEnabled;
			this.button7.Enabled = (this.generationsCheckBox.Checked = Settings.Default.generationsEnabled);
			this.generationsFolder.Enabled = Settings.Default.generationsEnabled;
			this.button8.Enabled = (this.townlifeCheckbox.Checked = Settings.Default.townlifeEnabled);
			this.townlifeFolder.Enabled = Settings.Default.townlifeEnabled;
			this.button9.Enabled = (this.petsCheckbox.Checked = Settings.Default.petsEnabled);
			this.petsFolder.Enabled = Settings.Default.petsEnabled;
			this.button10.Enabled = (this.showtimeCheckbox.Checked = Settings.Default.showtimeEnabled);
			this.showtimeFolder.Enabled = Settings.Default.showtimeEnabled;
			this.button11.Enabled = (this.mastersuiteCheckbox.Checked = Settings.Default.mastersuiteEnabled);
			this.mastersuiteFolder.Enabled = Settings.Default.mastersuiteEnabled;
			this.button12.Enabled = (this.katyPerryCheckbox.Checked = Settings.Default.katyperryEnabled);
			this.katyperryFolder.Enabled = Settings.Default.katyperryEnabled;
			this.button13.Enabled = (this.dieselCheckbox.Checked = Settings.Default.dieselEnabled);
			this.dieselFolder.Enabled = Settings.Default.dieselEnabled;
			this.button15.Enabled = (this.supernaturalCheckbox.Checked = Settings.Default.supernaturalEnabled);
			this.superNaturalFolder.Enabled = Settings.Default.supernaturalEnabled;
			this.button16.Enabled = (this.seasonsCheckbox.Checked = Settings.Default.seasonsEnabled);
			this.seasonsFolder.Enabled = Settings.Default.seasonsEnabled;
			this.button17.Enabled = (this.seventiesCheckbox.Checked = Settings.Default.seventyEnabled);
			this.seventiesFolder.Enabled = Settings.Default.seventyEnabled;
			this.button18.Enabled = (this.universityCheckbox.Checked = Settings.Default.universityEnabled);
			this.universityFolder.Enabled = Settings.Default.universityEnabled;
			this.button19.Enabled = (this.islandParadiseCheckbox.Checked = Settings.Default.islandParadiseEnabled);
			this.islandParadiseFolder.Enabled = Settings.Default.islandParadiseEnabled;
			this.button20.Enabled = (this.moviestuffCheckbox.Checked = Settings.Default.moviestuffEnabled);
			this.moviestuffFolder.Enabled = Settings.Default.moviestuffEnabled;
			this.button21.Enabled = (this.intothefutureCheckbox.Checked = Settings.Default.intothefutureEnabled);
			this.intothefutureFolder.Enabled = Settings.Default.intothefutureEnabled;
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000E1A RID: 3610 RVA: 0x000AF828 File Offset: 0x000ADA28
		// (set) Token: 0x06000E1B RID: 3611 RVA: 0x00002A71 File Offset: 0x00000C71
		public new string Name
		{
			get
			{
				return "Workshop";
			}
			set
			{
			}
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x000AF840 File Offset: 0x000ADA40
		public void imethod_0()
		{
			Settings.Default.AskAllowInternet = this.askAllowedInternet.Checked;
			Settings.Default.AllowInternet = this.allowInternet.Checked;
			Settings.Default.myDocumentsFolder = this.gameDataFolder.Text;
			Settings.Default.Sims3WorldAdventuresGamePath = this.waPath.Text;
			Settings.Default.Sims3InstallationPath = this.gamePath.Text;
			Settings.Default.Sims3HelsGamePath = this.helsPath.Text;
			Settings.Default.Sims3AmbitiationGamePath = this.ambitionsFolder.Text;
			Settings.Default.Sims3FastLaneGamePath = this.fastLaneFolder.Text;
			Settings.Default.Sims3LateNightGamePath = this.lateNightFolder.Text;
			Settings.Default.Sims3OutDoorLifeGamePath = this.outdoorLifeFolder.Text;
			Settings.Default.Sims3GenerationsGamePath = this.generationsFolder.Text;
			Settings.Default.Sims3TownLifeGameFolder = this.townlifeFolder.Text;
			Settings.Default.Sims3PetsGamePath = this.petsFolder.Text;
			Settings.Default.Sims3ShowtimeGamePath = this.showtimeFolder.Text;
			Settings.Default.Sims3MasterSuiteGameFolder = this.mastersuiteFolder.Text;
			Settings.Default.Sims3KatyPerryGameFolder = this.katyperryFolder.Text;
			Settings.Default.Sims3DieselGameFolder = this.dieselFolder.Text;
			Settings.Default.Sims3SupernaturalGameFolder = this.superNaturalFolder.Text;
			Settings.Default.Sims3SeasonsGameFolder = this.seasonsFolder.Text;
			Settings.Default.Sims3SeventyGameFolder = this.seventiesFolder.Text;
			Settings.Default.Sims3UniversityGameFolder = this.universityFolder.Text;
			Settings.Default.Sims3IslandParadiseGameFolder = this.islandParadiseFolder.Text;
			Settings.Default.Sims3MovieStuffGameFolder = this.moviestuffFolder.Text;
			Settings.Default.Sims3IntoTheFutureGameFolder = this.intothefutureFolder.Text;
			Settings.Default.Save();
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00002A71 File Offset: 0x00000C71
		public void imethod_1()
		{
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x000AFA54 File Offset: 0x000ADC54
		private void browseWAButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.waPath.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x000AFAA4 File Offset: 0x000ADCA4
		private void button1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.gamePath.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x000AFAF4 File Offset: 0x000ADCF4
		private void button2_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.helsPath.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x000AFB44 File Offset: 0x000ADD44
		private void button3_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.ambitionsFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x000AFB94 File Offset: 0x000ADD94
		private void button4_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.fastLaneFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x000AFBE4 File Offset: 0x000ADDE4
		private void button5_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.lateNightFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x000AFC34 File Offset: 0x000ADE34
		private void button6_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.outdoorLifeFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x000AFC84 File Offset: 0x000ADE84
		private void button7_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.generationsFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x000AFCD4 File Offset: 0x000ADED4
		private void button9_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.petsFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x000AFD24 File Offset: 0x000ADF24
		private void button8_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.townlifeFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x000AFD74 File Offset: 0x000ADF74
		private void button10_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.showtimeFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x000AFDC4 File Offset: 0x000ADFC4
		private void button11_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.mastersuiteFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x000AFE14 File Offset: 0x000AE014
		private void button12_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.katyperryFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x000AFE64 File Offset: 0x000AE064
		private void button13_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.dieselFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x000AFEB4 File Offset: 0x000AE0B4
		private void button14_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.gameDataFolder.Text = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x000AFEF0 File Offset: 0x000AE0F0
		private void button15_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.superNaturalFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x000AFF40 File Offset: 0x000AE140
		private void button16_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.seasonsFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x000AFF90 File Offset: 0x000AE190
		private void button17_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.seventiesFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x000AFFE0 File Offset: 0x000AE1E0
		private void button18_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.universityFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x000B0030 File Offset: 0x000AE230
		private void button19_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.islandParadiseFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x000B0080 File Offset: 0x000AE280
		private void button20_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.moviestuffFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x000B00D0 File Offset: 0x000AE2D0
		private void button21_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (this.string_0 != null)
			{
				folderBrowserDialog.SelectedPath = this.string_0;
			}
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.intothefutureFolder.Text = folderBrowserDialog.SelectedPath;
				this.string_0 = folderBrowserDialog.SelectedPath;
			}
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x00007B8A File Offset: 0x00005D8A
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x000B0120 File Offset: 0x000AE320
		private void method_2()
		{
			this.groupBox1 = new GroupBox();
			this.allowInternet = new CheckBox();
			this.askAllowedInternet = new CheckBox();
			this.panel1 = new Panel();
			this.browseHels = new GroupBox();
			this.intothefutureCheckbox = new CheckBox();
			this.button21 = new Button();
			this.intothefutureFolder = new TextBox();
			this.moviestuffCheckbox = new CheckBox();
			this.button20 = new Button();
			this.moviestuffFolder = new TextBox();
			this.islandParadiseCheckbox = new CheckBox();
			this.button19 = new Button();
			this.islandParadiseFolder = new TextBox();
			this.universityCheckbox = new CheckBox();
			this.button18 = new Button();
			this.universityFolder = new TextBox();
			this.seventiesCheckbox = new CheckBox();
			this.button17 = new Button();
			this.seventiesFolder = new TextBox();
			this.seasonsCheckbox = new CheckBox();
			this.button16 = new Button();
			this.seasonsFolder = new TextBox();
			this.supernaturalCheckbox = new CheckBox();
			this.button15 = new Button();
			this.superNaturalFolder = new TextBox();
			this.label2 = new Label();
			this.button14 = new Button();
			this.gameDataFolder = new TextBox();
			this.dieselCheckbox = new CheckBox();
			this.button13 = new Button();
			this.dieselFolder = new TextBox();
			this.katyPerryCheckbox = new CheckBox();
			this.button12 = new Button();
			this.katyperryFolder = new TextBox();
			this.mastersuiteCheckbox = new CheckBox();
			this.button11 = new Button();
			this.mastersuiteFolder = new TextBox();
			this.showtimeCheckbox = new CheckBox();
			this.townlifeCheckbox = new CheckBox();
			this.button10 = new Button();
			this.button8 = new Button();
			this.townlifeFolder = new TextBox();
			this.showtimeFolder = new TextBox();
			this.petsCheckbox = new CheckBox();
			this.button9 = new Button();
			this.petsFolder = new TextBox();
			this.generationsCheckBox = new CheckBox();
			this.button7 = new Button();
			this.generationsFolder = new TextBox();
			this.label1 = new Label();
			this.outdoorCheckbox = new CheckBox();
			this.latenightCheckbox = new CheckBox();
			this.fastLaneCheckbox = new CheckBox();
			this.ambitionsCheckbox = new CheckBox();
			this.highEndCheckbox = new CheckBox();
			this.worldAdventuresCheckbox = new CheckBox();
			this.button6 = new Button();
			this.outdoorLifeFolder = new TextBox();
			this.button5 = new Button();
			this.lateNightFolder = new TextBox();
			this.button4 = new Button();
			this.fastLaneFolder = new TextBox();
			this.button3 = new Button();
			this.ambitionsFolder = new TextBox();
			this.button2 = new Button();
			this.helsPath = new TextBox();
			this.button1 = new Button();
			this.gamePath = new TextBox();
			this.browseWAButton = new Button();
			this.waPath = new TextBox();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.browseHels.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.allowInternet);
			this.groupBox1.Controls.Add(this.askAllowedInternet);
			this.groupBox1.Location = new Point(4, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(384, 76);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Internet settings";
			this.allowInternet.AutoSize = true;
			this.allowInternet.Location = new Point(9, 45);
			this.allowInternet.Name = "allowInternet";
			this.allowInternet.Size = new Size(321, 17);
			this.allowInternet.TabIndex = 3;
			this.allowInternet.Text = "Fetch updates from the Internet when the application launches";
			this.allowInternet.UseVisualStyleBackColor = true;
			this.askAllowedInternet.AutoSize = true;
			this.askAllowedInternet.Location = new Point(9, 21);
			this.askAllowedInternet.Name = "askAllowedInternet";
			this.askAllowedInternet.Size = new Size(285, 17);
			this.askAllowedInternet.TabIndex = 2;
			this.askAllowedInternet.Text = "Ask before attempting to load updates from the Internet";
			this.askAllowedInternet.UseVisualStyleBackColor = true;
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.browseHels);
			this.panel1.Location = new Point(4, 85);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(381, 198);
			this.panel1.TabIndex = 5;
			this.browseHels.Controls.Add(this.intothefutureCheckbox);
			this.browseHels.Controls.Add(this.button21);
			this.browseHels.Controls.Add(this.intothefutureFolder);
			this.browseHels.Controls.Add(this.moviestuffCheckbox);
			this.browseHels.Controls.Add(this.button20);
			this.browseHels.Controls.Add(this.moviestuffFolder);
			this.browseHels.Controls.Add(this.islandParadiseCheckbox);
			this.browseHels.Controls.Add(this.button19);
			this.browseHels.Controls.Add(this.islandParadiseFolder);
			this.browseHels.Controls.Add(this.universityCheckbox);
			this.browseHels.Controls.Add(this.button18);
			this.browseHels.Controls.Add(this.universityFolder);
			this.browseHels.Controls.Add(this.seventiesCheckbox);
			this.browseHels.Controls.Add(this.button17);
			this.browseHels.Controls.Add(this.seventiesFolder);
			this.browseHels.Controls.Add(this.seasonsCheckbox);
			this.browseHels.Controls.Add(this.button16);
			this.browseHels.Controls.Add(this.seasonsFolder);
			this.browseHels.Controls.Add(this.supernaturalCheckbox);
			this.browseHels.Controls.Add(this.button15);
			this.browseHels.Controls.Add(this.superNaturalFolder);
			this.browseHels.Controls.Add(this.label2);
			this.browseHels.Controls.Add(this.button14);
			this.browseHels.Controls.Add(this.gameDataFolder);
			this.browseHels.Controls.Add(this.dieselCheckbox);
			this.browseHels.Controls.Add(this.button13);
			this.browseHels.Controls.Add(this.dieselFolder);
			this.browseHels.Controls.Add(this.katyPerryCheckbox);
			this.browseHels.Controls.Add(this.button12);
			this.browseHels.Controls.Add(this.katyperryFolder);
			this.browseHels.Controls.Add(this.mastersuiteCheckbox);
			this.browseHels.Controls.Add(this.button11);
			this.browseHels.Controls.Add(this.mastersuiteFolder);
			this.browseHels.Controls.Add(this.showtimeCheckbox);
			this.browseHels.Controls.Add(this.townlifeCheckbox);
			this.browseHels.Controls.Add(this.button10);
			this.browseHels.Controls.Add(this.button8);
			this.browseHels.Controls.Add(this.townlifeFolder);
			this.browseHels.Controls.Add(this.showtimeFolder);
			this.browseHels.Controls.Add(this.petsCheckbox);
			this.browseHels.Controls.Add(this.button9);
			this.browseHels.Controls.Add(this.petsFolder);
			this.browseHels.Controls.Add(this.generationsCheckBox);
			this.browseHels.Controls.Add(this.button7);
			this.browseHels.Controls.Add(this.generationsFolder);
			this.browseHels.Controls.Add(this.label1);
			this.browseHels.Controls.Add(this.outdoorCheckbox);
			this.browseHels.Controls.Add(this.latenightCheckbox);
			this.browseHels.Controls.Add(this.fastLaneCheckbox);
			this.browseHels.Controls.Add(this.ambitionsCheckbox);
			this.browseHels.Controls.Add(this.highEndCheckbox);
			this.browseHels.Controls.Add(this.worldAdventuresCheckbox);
			this.browseHels.Controls.Add(this.button6);
			this.browseHels.Controls.Add(this.outdoorLifeFolder);
			this.browseHels.Controls.Add(this.button5);
			this.browseHels.Controls.Add(this.lateNightFolder);
			this.browseHels.Controls.Add(this.button4);
			this.browseHels.Controls.Add(this.fastLaneFolder);
			this.browseHels.Controls.Add(this.button3);
			this.browseHels.Controls.Add(this.ambitionsFolder);
			this.browseHels.Controls.Add(this.button2);
			this.browseHels.Controls.Add(this.helsPath);
			this.browseHels.Controls.Add(this.button1);
			this.browseHels.Controls.Add(this.gamePath);
			this.browseHels.Controls.Add(this.browseWAButton);
			this.browseHels.Controls.Add(this.waPath);
			this.browseHels.Location = new Point(0, 3);
			this.browseHels.Name = "browseHels";
			this.browseHels.Size = new Size(361, 966);
			this.browseHels.TabIndex = 4;
			this.browseHels.TabStop = false;
			this.browseHels.Text = "Game and EP settings";
			this.intothefutureCheckbox.AutoSize = true;
			this.intothefutureCheckbox.Location = new Point(14, 889);
			this.intothefutureCheckbox.Name = "intothefutureCheckbox";
			this.intothefutureCheckbox.Size = new Size(134, 17);
			this.intothefutureCheckbox.TabIndex = 79;
			this.intothefutureCheckbox.Text = "Into The Future Folder:";
			this.intothefutureCheckbox.UseVisualStyleBackColor = true;
			this.intothefutureCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button21.Location = new Point(297, 905);
			this.button21.Name = "button21";
			this.button21.Size = new Size(51, 23);
			this.button21.TabIndex = 78;
			this.button21.Text = "browse";
			this.button21.UseVisualStyleBackColor = true;
			this.button21.Click += this.button21_Click;
			this.intothefutureFolder.Location = new Point(13, 906);
			this.intothefutureFolder.Name = "intothefutureFolder";
			this.intothefutureFolder.Size = new Size(278, 20);
			this.intothefutureFolder.TabIndex = 77;
			this.moviestuffCheckbox.AutoSize = true;
			this.moviestuffCheckbox.Location = new Point(14, 850);
			this.moviestuffCheckbox.Name = "moviestuffCheckbox";
			this.moviestuffCheckbox.Size = new Size(115, 17);
			this.moviestuffCheckbox.TabIndex = 76;
			this.moviestuffCheckbox.Text = "Movie Stuff Folder:";
			this.moviestuffCheckbox.UseVisualStyleBackColor = true;
			this.moviestuffCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button20.Location = new Point(297, 866);
			this.button20.Name = "button20";
			this.button20.Size = new Size(51, 23);
			this.button20.TabIndex = 75;
			this.button20.Text = "browse";
			this.button20.UseVisualStyleBackColor = true;
			this.button20.Click += this.button20_Click;
			this.moviestuffFolder.Location = new Point(13, 867);
			this.moviestuffFolder.Name = "moviestuffFolder";
			this.moviestuffFolder.Size = new Size(278, 20);
			this.moviestuffFolder.TabIndex = 74;
			this.islandParadiseCheckbox.AutoSize = true;
			this.islandParadiseCheckbox.Location = new Point(15, 810);
			this.islandParadiseCheckbox.Name = "islandParadiseCheckbox";
			this.islandParadiseCheckbox.Size = new Size(130, 17);
			this.islandParadiseCheckbox.TabIndex = 73;
			this.islandParadiseCheckbox.Text = "Island Paradise folder:";
			this.islandParadiseCheckbox.UseVisualStyleBackColor = true;
			this.islandParadiseCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button19.Location = new Point(298, 826);
			this.button19.Name = "button19";
			this.button19.Size = new Size(51, 23);
			this.button19.TabIndex = 72;
			this.button19.Text = "browse";
			this.button19.UseVisualStyleBackColor = true;
			this.button19.Click += this.button19_Click;
			this.islandParadiseFolder.Location = new Point(14, 827);
			this.islandParadiseFolder.Name = "islandParadiseFolder";
			this.islandParadiseFolder.Size = new Size(278, 20);
			this.islandParadiseFolder.TabIndex = 71;
			this.universityCheckbox.AutoSize = true;
			this.universityCheckbox.Location = new Point(15, 770);
			this.universityCheckbox.Name = "universityCheckbox";
			this.universityCheckbox.Size = new Size(104, 17);
			this.universityCheckbox.TabIndex = 70;
			this.universityCheckbox.Text = "University folder:";
			this.universityCheckbox.UseVisualStyleBackColor = true;
			this.universityCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button18.Location = new Point(298, 786);
			this.button18.Name = "button18";
			this.button18.Size = new Size(51, 23);
			this.button18.TabIndex = 69;
			this.button18.Text = "browse";
			this.button18.UseVisualStyleBackColor = true;
			this.button18.Click += this.button18_Click;
			this.universityFolder.Location = new Point(14, 787);
			this.universityFolder.Name = "universityFolder";
			this.universityFolder.Size = new Size(278, 20);
			this.universityFolder.TabIndex = 68;
			this.seventiesCheckbox.AutoSize = true;
			this.seventiesCheckbox.Location = new Point(15, 729);
			this.seventiesCheckbox.Name = "seventiesCheckbox";
			this.seventiesCheckbox.Size = new Size(127, 17);
			this.seventiesCheckbox.TabIndex = 67;
			this.seventiesCheckbox.Text = "70, 80, 90 stuff pack:";
			this.seventiesCheckbox.UseVisualStyleBackColor = true;
			this.seventiesCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button17.Location = new Point(298, 745);
			this.button17.Name = "button17";
			this.button17.Size = new Size(51, 23);
			this.button17.TabIndex = 66;
			this.button17.Text = "browse";
			this.button17.UseVisualStyleBackColor = true;
			this.button17.Click += this.button17_Click;
			this.seventiesFolder.Location = new Point(14, 746);
			this.seventiesFolder.Name = "seventiesFolder";
			this.seventiesFolder.Size = new Size(278, 20);
			this.seventiesFolder.TabIndex = 65;
			this.seasonsCheckbox.AutoSize = true;
			this.seasonsCheckbox.Location = new Point(15, 689);
			this.seasonsCheckbox.Name = "seasonsCheckbox";
			this.seasonsCheckbox.Size = new Size(99, 17);
			this.seasonsCheckbox.TabIndex = 64;
			this.seasonsCheckbox.Text = "Seasons folder:";
			this.seasonsCheckbox.UseVisualStyleBackColor = true;
			this.seasonsCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button16.Location = new Point(298, 705);
			this.button16.Name = "button16";
			this.button16.Size = new Size(51, 23);
			this.button16.TabIndex = 63;
			this.button16.Text = "browse";
			this.button16.UseVisualStyleBackColor = true;
			this.button16.Click += this.button16_Click;
			this.seasonsFolder.Location = new Point(14, 706);
			this.seasonsFolder.Name = "seasonsFolder";
			this.seasonsFolder.Size = new Size(278, 20);
			this.seasonsFolder.TabIndex = 62;
			this.supernaturalCheckbox.AutoSize = true;
			this.supernaturalCheckbox.Location = new Point(15, 648);
			this.supernaturalCheckbox.Name = "supernaturalCheckbox";
			this.supernaturalCheckbox.Size = new Size(118, 17);
			this.supernaturalCheckbox.TabIndex = 61;
			this.supernaturalCheckbox.Text = "Supernatural folder:";
			this.supernaturalCheckbox.UseVisualStyleBackColor = true;
			this.supernaturalCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button15.Location = new Point(298, 664);
			this.button15.Name = "button15";
			this.button15.Size = new Size(51, 23);
			this.button15.TabIndex = 60;
			this.button15.Text = "browse";
			this.button15.UseVisualStyleBackColor = true;
			this.button15.Click += this.button15_Click;
			this.superNaturalFolder.Location = new Point(14, 665);
			this.superNaturalFolder.Name = "superNaturalFolder";
			this.superNaturalFolder.Size = new Size(278, 20);
			this.superNaturalFolder.TabIndex = 59;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(12, 21);
			this.label2.Name = "label2";
			this.label2.Size = new Size(91, 13);
			this.label2.TabIndex = 58;
			this.label2.Text = "Game data folder:";
			this.button14.Location = new Point(298, 35);
			this.button14.Name = "button14";
			this.button14.Size = new Size(51, 23);
			this.button14.TabIndex = 57;
			this.button14.Text = "browse";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += this.button14_Click;
			this.gameDataFolder.Location = new Point(14, 37);
			this.gameDataFolder.Name = "gameDataFolder";
			this.gameDataFolder.Size = new Size(278, 20);
			this.gameDataFolder.TabIndex = 56;
			this.dieselCheckbox.AutoSize = true;
			this.dieselCheckbox.Location = new Point(15, 607);
			this.dieselCheckbox.Name = "dieselCheckbox";
			this.dieselCheckbox.Size = new Size(87, 17);
			this.dieselCheckbox.TabIndex = 55;
			this.dieselCheckbox.Text = "Diesel folder:";
			this.dieselCheckbox.UseVisualStyleBackColor = true;
			this.dieselCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button13.Location = new Point(298, 623);
			this.button13.Name = "button13";
			this.button13.Size = new Size(51, 23);
			this.button13.TabIndex = 54;
			this.button13.Text = "browse";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += this.button13_Click;
			this.dieselFolder.Location = new Point(14, 624);
			this.dieselFolder.Name = "dieselFolder";
			this.dieselFolder.Size = new Size(278, 20);
			this.dieselFolder.TabIndex = 53;
			this.katyPerryCheckbox.AutoSize = true;
			this.katyPerryCheckbox.Location = new Point(15, 564);
			this.katyPerryCheckbox.Name = "katyPerryCheckbox";
			this.katyPerryCheckbox.Size = new Size(177, 17);
			this.katyPerryCheckbox.TabIndex = 52;
			this.katyPerryCheckbox.Text = "Katy Perrys Sweet Treats folder:";
			this.katyPerryCheckbox.UseVisualStyleBackColor = true;
			this.katyPerryCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button12.Location = new Point(298, 580);
			this.button12.Name = "button12";
			this.button12.Size = new Size(51, 23);
			this.button12.TabIndex = 51;
			this.button12.Text = "browse";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += this.button12_Click;
			this.katyperryFolder.Location = new Point(14, 581);
			this.katyperryFolder.Name = "katyperryFolder";
			this.katyperryFolder.Size = new Size(278, 20);
			this.katyperryFolder.TabIndex = 50;
			this.mastersuiteCheckbox.AutoSize = true;
			this.mastersuiteCheckbox.Location = new Point(15, 522);
			this.mastersuiteCheckbox.Name = "mastersuiteCheckbox";
			this.mastersuiteCheckbox.Size = new Size(117, 17);
			this.mastersuiteCheckbox.TabIndex = 49;
			this.mastersuiteCheckbox.Text = "Master Suite folder:";
			this.mastersuiteCheckbox.UseVisualStyleBackColor = true;
			this.mastersuiteCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button11.Location = new Point(298, 538);
			this.button11.Name = "button11";
			this.button11.Size = new Size(51, 23);
			this.button11.TabIndex = 48;
			this.button11.Text = "browse";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += this.button11_Click;
			this.mastersuiteFolder.Location = new Point(14, 539);
			this.mastersuiteFolder.Name = "mastersuiteFolder";
			this.mastersuiteFolder.Size = new Size(278, 20);
			this.mastersuiteFolder.TabIndex = 47;
			this.showtimeCheckbox.AutoSize = true;
			this.showtimeCheckbox.Location = new Point(15, 481);
			this.showtimeCheckbox.Name = "showtimeCheckbox";
			this.showtimeCheckbox.Size = new Size(104, 17);
			this.showtimeCheckbox.TabIndex = 46;
			this.showtimeCheckbox.Text = "Showtime folder:";
			this.showtimeCheckbox.UseVisualStyleBackColor = true;
			this.showtimeCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.townlifeCheckbox.AutoSize = true;
			this.townlifeCheckbox.Location = new Point(15, 400);
			this.townlifeCheckbox.Name = "townlifeCheckbox";
			this.townlifeCheckbox.Size = new Size(105, 17);
			this.townlifeCheckbox.TabIndex = 43;
			this.townlifeCheckbox.Text = "Town Life folder:";
			this.townlifeCheckbox.UseVisualStyleBackColor = true;
			this.townlifeCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button10.Location = new Point(298, 497);
			this.button10.Name = "button10";
			this.button10.Size = new Size(51, 23);
			this.button10.TabIndex = 45;
			this.button10.Text = "browse";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += this.button10_Click;
			this.button8.Location = new Point(298, 416);
			this.button8.Name = "button8";
			this.button8.Size = new Size(51, 23);
			this.button8.TabIndex = 42;
			this.button8.Text = "browse";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += this.button8_Click;
			this.townlifeFolder.Location = new Point(14, 417);
			this.townlifeFolder.Name = "townlifeFolder";
			this.townlifeFolder.Size = new Size(278, 20);
			this.townlifeFolder.TabIndex = 41;
			this.showtimeFolder.Location = new Point(14, 498);
			this.showtimeFolder.Name = "showtimeFolder";
			this.showtimeFolder.Size = new Size(278, 20);
			this.showtimeFolder.TabIndex = 44;
			this.petsCheckbox.AutoSize = true;
			this.petsCheckbox.Location = new Point(15, 441);
			this.petsCheckbox.Name = "petsCheckbox";
			this.petsCheckbox.Size = new Size(79, 17);
			this.petsCheckbox.TabIndex = 40;
			this.petsCheckbox.Text = "Pets folder:";
			this.petsCheckbox.UseVisualStyleBackColor = true;
			this.petsCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button9.Location = new Point(298, 457);
			this.button9.Name = "button9";
			this.button9.Size = new Size(51, 23);
			this.button9.TabIndex = 39;
			this.button9.Text = "browse";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += this.button9_Click;
			this.petsFolder.Location = new Point(14, 458);
			this.petsFolder.Name = "petsFolder";
			this.petsFolder.Size = new Size(278, 20);
			this.petsFolder.TabIndex = 38;
			this.generationsCheckBox.AutoSize = true;
			this.generationsCheckBox.Location = new Point(15, 358);
			this.generationsCheckBox.Name = "generationsCheckBox";
			this.generationsCheckBox.Size = new Size(115, 17);
			this.generationsCheckBox.TabIndex = 34;
			this.generationsCheckBox.Text = "Generations folder:";
			this.generationsCheckBox.UseVisualStyleBackColor = true;
			this.generationsCheckBox.Click += this.worldAdventuresCheckbox_Click;
			this.button7.Location = new Point(298, 374);
			this.button7.Name = "button7";
			this.button7.Size = new Size(51, 23);
			this.button7.TabIndex = 33;
			this.button7.Text = "browse";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += this.button7_Click;
			this.generationsFolder.Location = new Point(14, 375);
			this.generationsFolder.Name = "generationsFolder";
			this.generationsFolder.Size = new Size(278, 20);
			this.generationsFolder.TabIndex = 32;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 65);
			this.label1.Name = "label1";
			this.label1.Size = new Size(92, 13);
			this.label1.TabIndex = 31;
			this.label1.Text = "Base game folder:";
			this.outdoorCheckbox.AutoSize = true;
			this.outdoorCheckbox.Location = new Point(15, 317);
			this.outdoorCheckbox.Name = "outdoorCheckbox";
			this.outdoorCheckbox.Size = new Size(112, 17);
			this.outdoorCheckbox.TabIndex = 30;
			this.outdoorCheckbox.Text = "Outdoor life folder:";
			this.outdoorCheckbox.UseVisualStyleBackColor = true;
			this.outdoorCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.latenightCheckbox.AutoSize = true;
			this.latenightCheckbox.Location = new Point(15, 276);
			this.latenightCheckbox.Name = "latenightCheckbox";
			this.latenightCheckbox.Size = new Size(107, 17);
			this.latenightCheckbox.TabIndex = 29;
			this.latenightCheckbox.Text = "Late Night folder:";
			this.latenightCheckbox.UseVisualStyleBackColor = true;
			this.latenightCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.fastLaneCheckbox.AutoSize = true;
			this.fastLaneCheckbox.Location = new Point(15, 234);
			this.fastLaneCheckbox.Name = "fastLaneCheckbox";
			this.fastLaneCheckbox.Size = new Size(105, 17);
			this.fastLaneCheckbox.TabIndex = 28;
			this.fastLaneCheckbox.Text = "Fast Lane folder:";
			this.fastLaneCheckbox.UseVisualStyleBackColor = true;
			this.fastLaneCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.ambitionsCheckbox.AutoSize = true;
			this.ambitionsCheckbox.Location = new Point(14, 192);
			this.ambitionsCheckbox.Name = "ambitionsCheckbox";
			this.ambitionsCheckbox.Size = new Size(103, 17);
			this.ambitionsCheckbox.TabIndex = 27;
			this.ambitionsCheckbox.Text = "Ambitions folder:";
			this.ambitionsCheckbox.UseVisualStyleBackColor = true;
			this.ambitionsCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.highEndCheckbox.AutoSize = true;
			this.highEndCheckbox.Location = new Point(14, 151);
			this.highEndCheckbox.Name = "highEndCheckbox";
			this.highEndCheckbox.Size = new Size(182, 17);
			this.highEndCheckbox.TabIndex = 26;
			this.highEndCheckbox.Text = "High End Living Stuffpack folder:";
			this.highEndCheckbox.UseVisualStyleBackColor = true;
			this.highEndCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.worldAdventuresCheckbox.AutoSize = true;
			this.worldAdventuresCheckbox.Location = new Point(14, 107);
			this.worldAdventuresCheckbox.Name = "worldAdventuresCheckbox";
			this.worldAdventuresCheckbox.Size = new Size(143, 17);
			this.worldAdventuresCheckbox.TabIndex = 25;
			this.worldAdventuresCheckbox.Text = "World Adventures folder:";
			this.worldAdventuresCheckbox.UseVisualStyleBackColor = true;
			this.worldAdventuresCheckbox.Click += this.worldAdventuresCheckbox_Click;
			this.button6.Location = new Point(298, 333);
			this.button6.Name = "button6";
			this.button6.Size = new Size(51, 23);
			this.button6.TabIndex = 23;
			this.button6.Text = "browse";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += this.button6_Click;
			this.outdoorLifeFolder.Location = new Point(14, 334);
			this.outdoorLifeFolder.Name = "outdoorLifeFolder";
			this.outdoorLifeFolder.Size = new Size(278, 20);
			this.outdoorLifeFolder.TabIndex = 21;
			this.button5.Location = new Point(298, 292);
			this.button5.Name = "button5";
			this.button5.Size = new Size(51, 23);
			this.button5.TabIndex = 17;
			this.button5.Text = "browse";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += this.button5_Click;
			this.lateNightFolder.Location = new Point(14, 293);
			this.lateNightFolder.Name = "lateNightFolder";
			this.lateNightFolder.Size = new Size(278, 20);
			this.lateNightFolder.TabIndex = 15;
			this.button4.Location = new Point(298, 250);
			this.button4.Name = "button4";
			this.button4.Size = new Size(51, 23);
			this.button4.TabIndex = 14;
			this.button4.Text = "browse";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += this.button4_Click;
			this.fastLaneFolder.Location = new Point(14, 251);
			this.fastLaneFolder.Name = "fastLaneFolder";
			this.fastLaneFolder.Size = new Size(278, 20);
			this.fastLaneFolder.TabIndex = 12;
			this.button3.Location = new Point(298, 207);
			this.button3.Name = "button3";
			this.button3.Size = new Size(51, 23);
			this.button3.TabIndex = 11;
			this.button3.Text = "browse";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += this.button3_Click;
			this.ambitionsFolder.Location = new Point(14, 209);
			this.ambitionsFolder.Name = "ambitionsFolder";
			this.ambitionsFolder.Size = new Size(278, 20);
			this.ambitionsFolder.TabIndex = 9;
			this.button2.Location = new Point(298, 166);
			this.button2.Name = "button2";
			this.button2.Size = new Size(51, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "browse";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += this.button2_Click;
			this.helsPath.Location = new Point(14, 168);
			this.helsPath.Name = "helsPath";
			this.helsPath.Size = new Size(278, 20);
			this.helsPath.TabIndex = 6;
			this.button1.Location = new Point(298, 79);
			this.button1.Name = "button1";
			this.button1.Size = new Size(51, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "browse";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += this.button1_Click;
			this.gamePath.Location = new Point(14, 81);
			this.gamePath.Name = "gamePath";
			this.gamePath.Size = new Size(278, 20);
			this.gamePath.TabIndex = 3;
			this.browseWAButton.Location = new Point(298, 123);
			this.browseWAButton.Name = "browseWAButton";
			this.browseWAButton.Size = new Size(51, 23);
			this.browseWAButton.TabIndex = 2;
			this.browseWAButton.Text = "browse";
			this.browseWAButton.UseVisualStyleBackColor = true;
			this.browseWAButton.Click += this.browseWAButton_Click;
			this.waPath.Location = new Point(14, 125);
			this.waPath.Name = "waPath";
			this.waPath.Size = new Size(278, 20);
			this.waPath.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.groupBox1);
			this.Name = "WorkshopSettings";
			base.Size = new Size(397, 286);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.browseHels.ResumeLayout(false);
			this.browseHels.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000A95 RID: 2709
		private string string_0;

		// Token: 0x04000A96 RID: 2710
		private IContainer icontainer_0;

		// Token: 0x04000A97 RID: 2711
		private GroupBox groupBox1;

		// Token: 0x04000A98 RID: 2712
		private CheckBox allowInternet;

		// Token: 0x04000A99 RID: 2713
		private CheckBox askAllowedInternet;

		// Token: 0x04000A9A RID: 2714
		private Panel panel1;

		// Token: 0x04000A9B RID: 2715
		private GroupBox browseHels;

		// Token: 0x04000A9C RID: 2716
		private CheckBox outdoorCheckbox;

		// Token: 0x04000A9D RID: 2717
		private CheckBox latenightCheckbox;

		// Token: 0x04000A9E RID: 2718
		private CheckBox fastLaneCheckbox;

		// Token: 0x04000A9F RID: 2719
		private CheckBox ambitionsCheckbox;

		// Token: 0x04000AA0 RID: 2720
		private CheckBox highEndCheckbox;

		// Token: 0x04000AA1 RID: 2721
		private CheckBox worldAdventuresCheckbox;

		// Token: 0x04000AA2 RID: 2722
		private Button button6;

		// Token: 0x04000AA3 RID: 2723
		private TextBox outdoorLifeFolder;

		// Token: 0x04000AA4 RID: 2724
		private Button button5;

		// Token: 0x04000AA5 RID: 2725
		private TextBox lateNightFolder;

		// Token: 0x04000AA6 RID: 2726
		private Button button4;

		// Token: 0x04000AA7 RID: 2727
		private TextBox fastLaneFolder;

		// Token: 0x04000AA8 RID: 2728
		private Button button3;

		// Token: 0x04000AA9 RID: 2729
		private TextBox ambitionsFolder;

		// Token: 0x04000AAA RID: 2730
		private Button button2;

		// Token: 0x04000AAB RID: 2731
		private TextBox helsPath;

		// Token: 0x04000AAC RID: 2732
		private Button button1;

		// Token: 0x04000AAD RID: 2733
		private TextBox gamePath;

		// Token: 0x04000AAE RID: 2734
		private Button browseWAButton;

		// Token: 0x04000AAF RID: 2735
		private TextBox waPath;

		// Token: 0x04000AB0 RID: 2736
		private Label label1;

		// Token: 0x04000AB1 RID: 2737
		private CheckBox generationsCheckBox;

		// Token: 0x04000AB2 RID: 2738
		private Button button7;

		// Token: 0x04000AB3 RID: 2739
		private TextBox generationsFolder;

		// Token: 0x04000AB4 RID: 2740
		private CheckBox petsCheckbox;

		// Token: 0x04000AB5 RID: 2741
		private Button button9;

		// Token: 0x04000AB6 RID: 2742
		private TextBox petsFolder;

		// Token: 0x04000AB7 RID: 2743
		private CheckBox townlifeCheckbox;

		// Token: 0x04000AB8 RID: 2744
		private Button button8;

		// Token: 0x04000AB9 RID: 2745
		private TextBox townlifeFolder;

		// Token: 0x04000ABA RID: 2746
		private CheckBox showtimeCheckbox;

		// Token: 0x04000ABB RID: 2747
		private Button button10;

		// Token: 0x04000ABC RID: 2748
		private TextBox showtimeFolder;

		// Token: 0x04000ABD RID: 2749
		private CheckBox mastersuiteCheckbox;

		// Token: 0x04000ABE RID: 2750
		private Button button11;

		// Token: 0x04000ABF RID: 2751
		private TextBox mastersuiteFolder;

		// Token: 0x04000AC0 RID: 2752
		private CheckBox dieselCheckbox;

		// Token: 0x04000AC1 RID: 2753
		private Button button13;

		// Token: 0x04000AC2 RID: 2754
		private TextBox dieselFolder;

		// Token: 0x04000AC3 RID: 2755
		private CheckBox katyPerryCheckbox;

		// Token: 0x04000AC4 RID: 2756
		private Button button12;

		// Token: 0x04000AC5 RID: 2757
		private TextBox katyperryFolder;

		// Token: 0x04000AC6 RID: 2758
		private Label label2;

		// Token: 0x04000AC7 RID: 2759
		private Button button14;

		// Token: 0x04000AC8 RID: 2760
		private TextBox gameDataFolder;

		// Token: 0x04000AC9 RID: 2761
		private CheckBox seasonsCheckbox;

		// Token: 0x04000ACA RID: 2762
		private Button button16;

		// Token: 0x04000ACB RID: 2763
		private TextBox seasonsFolder;

		// Token: 0x04000ACC RID: 2764
		private CheckBox supernaturalCheckbox;

		// Token: 0x04000ACD RID: 2765
		private Button button15;

		// Token: 0x04000ACE RID: 2766
		private TextBox superNaturalFolder;

		// Token: 0x04000ACF RID: 2767
		private CheckBox seventiesCheckbox;

		// Token: 0x04000AD0 RID: 2768
		private Button button17;

		// Token: 0x04000AD1 RID: 2769
		private TextBox seventiesFolder;

		// Token: 0x04000AD2 RID: 2770
		private CheckBox islandParadiseCheckbox;

		// Token: 0x04000AD3 RID: 2771
		private Button button19;

		// Token: 0x04000AD4 RID: 2772
		private TextBox islandParadiseFolder;

		// Token: 0x04000AD5 RID: 2773
		private CheckBox universityCheckbox;

		// Token: 0x04000AD6 RID: 2774
		private Button button18;

		// Token: 0x04000AD7 RID: 2775
		private TextBox universityFolder;

		// Token: 0x04000AD8 RID: 2776
		private CheckBox intothefutureCheckbox;

		// Token: 0x04000AD9 RID: 2777
		private Button button21;

		// Token: 0x04000ADA RID: 2778
		private TextBox intothefutureFolder;

		// Token: 0x04000ADB RID: 2779
		private CheckBox moviestuffCheckbox;

		// Token: 0x04000ADC RID: 2780
		private Button button20;

		// Token: 0x04000ADD RID: 2781
		private TextBox moviestuffFolder;
	}
}
