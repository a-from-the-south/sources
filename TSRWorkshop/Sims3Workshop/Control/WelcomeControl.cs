using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using ns14;
using ns17;
using ns2;
using ns8;
using Sims3Workshop.Data;
using Sims3Workshop.Properties;

namespace Sims3Workshop.Control
{
	// Token: 0x0200009C RID: 156
	public sealed class WelcomeControl : UserControl
	{
		// Token: 0x0600062F RID: 1583 RVA: 0x000052E3 File Offset: 0x000034E3
		public WelcomeControl()
		{
			this.InitializeComponent();
			this.list_0 = new List<LinkLabel>();
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0005DC00 File Offset: 0x0005BE00
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			NewProjectForm newProjectForm = new NewProjectForm();
			if (newProjectForm.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					Class132.mainForm.OpenProject(newProjectForm.Project);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x000052FE File Offset: 0x000034FE
		private void WelcomeControl_Resize(object sender, EventArgs e)
		{
			this.BackgroundImage = null;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0005DC50 File Offset: 0x0005BE50
		private void linkLabel10_Click(object sender, EventArgs e)
		{
			string text = (string)((LinkLabel)sender).Tag;
			if (text == "soon")
			{
				MessageBox.Show("This feature will be available soon!");
			}
			else
			{
				Process.Start(text);
			}
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0005DC94 File Offset: 0x0005BE94
		private void WelcomeControl_Load(object sender, EventArgs e)
		{
			this.method_4();
			if (!WelcomeControl.bool_0)
			{
				this.method_2(this, new RunWorkerCompletedEventArgs(null, null, false));
			}
			else if (Settings.Default.AskAllowInternet)
			{
				AskAllowInternetDialog askAllowInternetDialog = new AskAllowInternetDialog();
				if (askAllowInternetDialog.ShowDialog() == DialogResult.Yes)
				{
					this.method_0();
				}
				else
				{
					this.method_2(this, new RunWorkerCompletedEventArgs(null, null, false));
				}
			}
			else if (Settings.Default.AllowInternet)
			{
				this.method_0();
			}
			else
			{
				this.method_2(this, new RunWorkerCompletedEventArgs(null, null, false));
			}
			WelcomeControl.bool_0 = false;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0005DD20 File Offset: 0x0005BF20
		private void method_0()
		{
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.WorkerReportsProgress = false;
			backgroundWorker.DoWork += this.method_1;
			backgroundWorker.RunWorkerCompleted += this.method_2;
			backgroundWorker.RunWorkerAsync();
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0005DD68 File Offset: 0x0005BF68
		private void method_1(object sender, DoWorkEventArgs e)
		{
			try
			{
				WebClient webClient = new WebClient();
				WelcomeControl.string_0 = webClient.DownloadString("http://www.thesimsresource.com/workshop/welcome");
				webClient.Dispose();
			}
			catch (Exception ex)
			{
				Class132.mainForm.SetStatus(ex.Message);
			}
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0005DDB8 File Offset: 0x0005BFB8
		private void method_2(object sender, RunWorkerCompletedEventArgs e)
		{
			if (WelcomeControl.string_0 == null)
			{
				Control control = this.fetchData1;
				Control fetchData = this.FetchData2;
				Control fetchData2 = this.FetchData3;
				Control fetchData3 = this.FetchData4;
				Control fetchData4 = this.FetchData5;
				Control fetchData5 = this.FetchData6;
				this.FetchData7.Visible = true;
				fetchData5.Visible = true;
				fetchData4.Visible = true;
				fetchData3.Visible = true;
				fetchData2.Visible = true;
				fetchData.Visible = true;
				control.Visible = true;
				this.latestVersionLabel.Text = "";
			}
			else
			{
				Control control2 = this.fetchData1;
				Control fetchData6 = this.FetchData2;
				Control fetchData7 = this.FetchData3;
				Control fetchData8 = this.FetchData4;
				Control fetchData9 = this.FetchData5;
				Control fetchData10 = this.FetchData6;
				this.FetchData7.Visible = false;
				fetchData10.Visible = false;
				fetchData9.Visible = false;
				fetchData8.Visible = false;
				fetchData7.Visible = false;
				fetchData6.Visible = false;
				control2.Visible = false;
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(WelcomeControl.string_0);
					string innerText = xmlDocument.SelectSingleNode("/welcome/latestversion").InnerText;
					string productVersion = Application.ProductVersion;
					if (productVersion != innerText)
					{
						this.latestVersionLabel.Text = "Latest version is " + innerText + ", this is version " + productVersion;
					}
					else
					{
						this.latestVersionLabel.Text = "You have the latest version (" + productVersion + ")";
					}
					XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/welcome/showcase/image");
					if (xmlNodeList != null)
					{
						if (xmlNodeList.Count > 0)
						{
							this.method_3(xmlNodeList[0].InnerText, this.showcase1);
						}
						if (xmlNodeList.Count > 1)
						{
							this.method_3(xmlNodeList[1].InnerText, this.showcase2);
						}
						if (xmlNodeList.Count > 2)
						{
							this.method_3(xmlNodeList[2].InnerText, this.showcase3);
						}
						if (xmlNodeList.Count > 3)
						{
							this.method_3(xmlNodeList[3].InnerText, this.showcase4);
						}
					}
					XmlNodeList xmlNodeList2 = xmlDocument.SelectNodes("/welcome/news/workshop/post");
					this.workshopnews.Clear();
					this.workshopnews.Refresh();
					foreach (object obj in xmlNodeList2)
					{
						XmlNode xmlNode = (XmlNode)obj;
						string text = xmlNode.Attributes["date"].Value;
						text = DateTime.Parse(text, CultureInfo.InvariantCulture).ToString("d MMM", CultureInfo.CreateSpecificCulture("en-US"));
						string value = xmlNode.Attributes["title"].Value;
						string str = xmlNode.InnerText.Trim();
						this.workshopnews.method_0("{\\rtf1\\ansi \\b " + value + "\\b0}");
						this.workshopnews.AppendText("\n");
						this.workshopnews.method_0("{\\rtf1\\ansi \\i Posted: " + text + "\\i0.}");
						this.workshopnews.AppendText("\n" + str + "\n\n");
					}
					XmlNodeList xmlNodeList3 = xmlDocument.SelectNodes("/welcome/news/tsr/post");
					this.tsrnews.Clear();
					this.tsrnews.Refresh();
					foreach (object obj2 in xmlNodeList3)
					{
						XmlNode xmlNode2 = (XmlNode)obj2;
						string text2 = xmlNode2.Attributes["date"].Value;
						text2 = DateTime.Parse(text2, CultureInfo.InvariantCulture).ToString("d MMM", CultureInfo.CreateSpecificCulture("en-US"));
						string value2 = xmlNode2.Attributes["title"].Value;
						string str2 = xmlNode2.InnerText.Trim();
						this.tsrnews.method_0("{\\rtf1\\ansi \\b " + value2 + "\\b0}");
						this.tsrnews.AppendText("\n");
						this.tsrnews.method_0("{\\rtf1\\ansi \\i Posted: " + text2 + "\\i0.}");
						this.tsrnews.AppendText("\n" + str2 + "\n\n");
					}
				}
				catch (Exception ex)
				{
					Class132.mainForm.SetStatus(ex.Message);
				}
			}
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0005E268 File Offset: 0x0005C468
		private void method_3(string string_1, PictureBox pictureBox_0)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_1);
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Image image = Image.FromStream(httpWebResponse.GetResponseStream());
			httpWebResponse.Close();
			pictureBox_0.Image = image;
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0005E2A8 File Offset: 0x0005C4A8
		public void method_4()
		{
			foreach (LinkLabel value in this.list_0)
			{
				this.mainPanel.Controls.Remove(value);
			}
			this.list_0.Clear();
			if (Settings.Default.RecentProjects != null)
			{
				for (int i = 0; i < Settings.Default.RecentProjects.Count; i++)
				{
					if (this.list_0.Count > 7)
					{
						break;
					}
					string text = Settings.Default.RecentProjects[i];
					if (File.Exists(text))
					{
						try
						{
							if (WorkshopProject.smethod_1(text) != null)
							{
								LinkLabel linkLabel = new LinkLabel();
								linkLabel.Tag = text;
								linkLabel.Text = Path.GetFileName(text);
								linkLabel.AutoSize = false;
								linkLabel.Left = 40;
								linkLabel.Top = ((this.list_0.Count > 0) ? (this.list_0[this.list_0.Count - 1].Bottom + 2) : 227);
								linkLabel.Size = new Size(160, (int)linkLabel.Font.GetHeight(72f) + 4);
								linkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
								linkLabel.VisitedLinkColor = Color.Black;
								linkLabel.LinkColor = Color.Black;
								linkLabel.BackColor = Color.Transparent;
								linkLabel.Parent = this.mainPanel;
								linkLabel.LinkClicked += this.method_5;
								this.list_0.Add(linkLabel);
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine("Could not open old project, skipping: " + ex.Message);
						}
					}
				}
			}
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0005E490 File Offset: 0x0005C690
		private void method_5(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				string string_ = (string)((LinkLabel)sender).Tag;
				WorkshopProject workshopProject = WorkshopProject.smethod_1(string_);
				if (workshopProject != null)
				{
					Class132.mainForm.OpenProject(workshopProject);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0005E4E8 File Offset: 0x0005C6E8
		private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				WorkshopProject workshopProject = WorkshopProject.smethod_0();
				if (workshopProject != null)
				{
					Class132.mainForm.OpenProject(workshopProject);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x00005309 File Offset: 0x00003509
		public void method_6()
		{
			this.WelcomeControl_Load(this, new EventArgs());
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x00005319 File Offset: 0x00003519
		private void fetchData1_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00005323 File Offset: 0x00003523
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0005E530 File Offset: 0x0005C730
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(WelcomeControl));
			this.mainPanel = new Panel();
			this.FetchData7 = new LinkLabel();
			this.FetchData6 = new LinkLabel();
			this.FetchData5 = new LinkLabel();
			this.FetchData4 = new LinkLabel();
			this.FetchData3 = new LinkLabel();
			this.FetchData2 = new LinkLabel();
			this.fetchData1 = new LinkLabel();
			this.tsrnews = new Class65();
			this.workshopnews = new Class65();
			this.latestVersionLabel = new Label();
			this.linkLabel1 = new LinkLabel();
			this.linkLabel2 = new LinkLabel();
			this.linkLabel12 = new LinkLabel();
			this.label2 = new Label();
			this.linkLabel4 = new LinkLabel();
			this.showcase4 = new PictureBox();
			this.linkLabel3 = new LinkLabel();
			this.showcase3 = new PictureBox();
			this.showcase2 = new PictureBox();
			this.linkLabel6 = new LinkLabel();
			this.showcase1 = new PictureBox();
			this.linkLabel7 = new LinkLabel();
			this.label5 = new Label();
			this.linkLabel8 = new LinkLabel();
			this.label4 = new Label();
			this.linkLabel11 = new LinkLabel();
			this.linkLabel10 = new LinkLabel();
			this.label3 = new Label();
			this.label1 = new Label();
			this.mainPanel.SuspendLayout();
			((ISupportInitialize)this.showcase4).BeginInit();
			((ISupportInitialize)this.showcase3).BeginInit();
			((ISupportInitialize)this.showcase2).BeginInit();
			((ISupportInitialize)this.showcase1).BeginInit();
			base.SuspendLayout();
			this.mainPanel.Anchor = AnchorStyles.Top;
			this.mainPanel.BackgroundImage = Class143.startbackground;
			this.mainPanel.BackgroundImageLayout = ImageLayout.None;
			this.mainPanel.Controls.Add(this.FetchData7);
			this.mainPanel.Controls.Add(this.FetchData6);
			this.mainPanel.Controls.Add(this.FetchData5);
			this.mainPanel.Controls.Add(this.FetchData4);
			this.mainPanel.Controls.Add(this.FetchData3);
			this.mainPanel.Controls.Add(this.FetchData2);
			this.mainPanel.Controls.Add(this.fetchData1);
			this.mainPanel.Controls.Add(this.tsrnews);
			this.mainPanel.Controls.Add(this.workshopnews);
			this.mainPanel.Controls.Add(this.latestVersionLabel);
			this.mainPanel.Controls.Add(this.linkLabel1);
			this.mainPanel.Controls.Add(this.linkLabel2);
			this.mainPanel.Controls.Add(this.linkLabel12);
			this.mainPanel.Controls.Add(this.label2);
			this.mainPanel.Controls.Add(this.linkLabel4);
			this.mainPanel.Controls.Add(this.showcase4);
			this.mainPanel.Controls.Add(this.linkLabel3);
			this.mainPanel.Controls.Add(this.showcase3);
			this.mainPanel.Controls.Add(this.showcase2);
			this.mainPanel.Controls.Add(this.linkLabel6);
			this.mainPanel.Controls.Add(this.showcase1);
			this.mainPanel.Controls.Add(this.linkLabel7);
			this.mainPanel.Controls.Add(this.label5);
			this.mainPanel.Controls.Add(this.linkLabel8);
			this.mainPanel.Controls.Add(this.label4);
			this.mainPanel.Controls.Add(this.linkLabel11);
			this.mainPanel.Controls.Add(this.linkLabel10);
			this.mainPanel.Controls.Add(this.label3);
			this.mainPanel.Controls.Add(this.label1);
			this.mainPanel.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.mainPanel.Location = new Point(5, 0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new Size(946, 656);
			this.mainPanel.TabIndex = 26;
			this.FetchData7.AutoSize = true;
			this.FetchData7.BackColor = Color.Transparent;
			this.FetchData7.LinkColor = Color.White;
			this.FetchData7.Location = new Point(569, 546);
			this.FetchData7.Name = "FetchData7";
			this.FetchData7.Size = new Size(59, 13);
			this.FetchData7.TabIndex = 36;
			this.FetchData7.TabStop = true;
			this.FetchData7.Text = "Fetch data";
			this.FetchData7.Visible = false;
			this.FetchData7.Click += this.fetchData1_Click;
			this.FetchData6.AutoSize = true;
			this.FetchData6.BackColor = Color.Transparent;
			this.FetchData6.LinkColor = Color.White;
			this.FetchData6.Location = new Point(405, 546);
			this.FetchData6.Name = "FetchData6";
			this.FetchData6.Size = new Size(59, 13);
			this.FetchData6.TabIndex = 35;
			this.FetchData6.TabStop = true;
			this.FetchData6.Text = "Fetch data";
			this.FetchData6.Visible = false;
			this.FetchData6.Click += this.fetchData1_Click;
			this.FetchData5.AutoSize = true;
			this.FetchData5.BackColor = Color.Transparent;
			this.FetchData5.LinkColor = Color.White;
			this.FetchData5.Location = new Point(233, 546);
			this.FetchData5.Name = "FetchData5";
			this.FetchData5.Size = new Size(59, 13);
			this.FetchData5.TabIndex = 34;
			this.FetchData5.TabStop = true;
			this.FetchData5.Text = "Fetch data";
			this.FetchData5.Visible = false;
			this.FetchData5.Click += this.fetchData1_Click;
			this.FetchData4.AutoSize = true;
			this.FetchData4.BackColor = Color.Transparent;
			this.FetchData4.LinkColor = Color.White;
			this.FetchData4.Location = new Point(70, 546);
			this.FetchData4.Name = "FetchData4";
			this.FetchData4.Size = new Size(59, 13);
			this.FetchData4.TabIndex = 33;
			this.FetchData4.TabStop = true;
			this.FetchData4.Text = "Fetch data";
			this.FetchData4.Visible = false;
			this.FetchData4.Click += this.fetchData1_Click;
			this.FetchData3.AutoSize = true;
			this.FetchData3.BackColor = Color.Transparent;
			this.FetchData3.LinkColor = SystemColors.ControlText;
			this.FetchData3.Location = new Point(244, 370);
			this.FetchData3.Name = "FetchData3";
			this.FetchData3.Size = new Size(74, 13);
			this.FetchData3.TabIndex = 32;
			this.FetchData3.TabStop = true;
			this.FetchData3.Text = "Check version";
			this.FetchData3.Visible = false;
			this.FetchData3.Click += this.fetchData1_Click;
			this.FetchData2.AutoSize = true;
			this.FetchData2.BackColor = Color.Transparent;
			this.FetchData2.LinkColor = SystemColors.ControlText;
			this.FetchData2.Location = new Point(716, 159);
			this.FetchData2.Name = "FetchData2";
			this.FetchData2.Size = new Size(59, 13);
			this.FetchData2.TabIndex = 31;
			this.FetchData2.TabStop = true;
			this.FetchData2.Text = "Fetch data";
			this.FetchData2.Visible = false;
			this.FetchData2.Click += this.fetchData1_Click;
			this.fetchData1.AutoSize = true;
			this.fetchData1.BackColor = Color.Transparent;
			this.fetchData1.LinkColor = SystemColors.ControlText;
			this.fetchData1.Location = new Point(433, 159);
			this.fetchData1.Name = "fetchData1";
			this.fetchData1.Size = new Size(59, 13);
			this.fetchData1.TabIndex = 30;
			this.fetchData1.TabStop = true;
			this.fetchData1.Text = "Fetch data";
			this.fetchData1.Visible = false;
			this.fetchData1.Click += this.fetchData1_Click;
			this.tsrnews.BorderStyle = BorderStyle.None;
			this.tsrnews.HiglightColor = RtfColor.White;
			this.tsrnews.Location = new Point(719, 159);
			this.tsrnews.Name = "tsrnews";
			this.tsrnews.ReadOnly = true;
			this.tsrnews.Size = new Size(207, 211);
			this.tsrnews.TabIndex = 29;
			this.tsrnews.Text = "";
			this.tsrnews.TextColor = RtfColor.Black;
			this.workshopnews.BorderStyle = BorderStyle.None;
			this.workshopnews.HiglightColor = RtfColor.White;
			this.workshopnews.Location = new Point(433, 159);
			this.workshopnews.Name = "workshopnews";
			this.workshopnews.ReadOnly = true;
			this.workshopnews.Size = new Size(243, 211);
			this.workshopnews.TabIndex = 28;
			this.workshopnews.Text = "";
			this.workshopnews.TextColor = RtfColor.Black;
			this.latestVersionLabel.BackColor = Color.Transparent;
			this.latestVersionLabel.Location = new Point(244, 370);
			this.latestVersionLabel.Name = "latestVersionLabel";
			this.latestVersionLabel.Size = new Size(148, 36);
			this.latestVersionLabel.TabIndex = 27;
			this.latestVersionLabel.Text = "Checking latest version...";
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.BackColor = Color.Transparent;
			this.linkLabel1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.linkLabel1.Image = Class143.newproject;
			this.linkLabel1.ImageAlign = ContentAlignment.MiddleLeft;
			this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel1.LinkColor = Color.Black;
			this.linkLabel1.Location = new Point(18, 131);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Padding = new Padding(20, 3, 0, 3);
			this.linkLabel1.Size = new Size(146, 19);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Create New Project »";
			this.linkLabel1.LinkClicked += this.linkLabel1_LinkClicked;
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.BackColor = Color.Transparent;
			this.linkLabel2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.linkLabel2.Image = Class143.documentation;
			this.linkLabel2.ImageAlign = ContentAlignment.MiddleLeft;
			this.linkLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel2.LinkColor = Color.Black;
			this.linkLabel2.Location = new Point(224, 131);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Padding = new Padding(20, 3, 0, 3);
			this.linkLabel2.Size = new Size(168, 19);
			this.linkLabel2.TabIndex = 2;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Tag = "http://wiki.thesimsresource.com/index.php?title=Category:TSR_Workshop";
			this.linkLabel2.Text = "On-line Documentation »";
			this.linkLabel2.Click += this.linkLabel10_Click;
			this.linkLabel12.AutoSize = true;
			this.linkLabel12.BackColor = Color.Transparent;
			this.linkLabel12.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.linkLabel12.Image = (Image)componentResourceManager.GetObject("linkLabel12.Image");
			this.linkLabel12.ImageAlign = ContentAlignment.MiddleLeft;
			this.linkLabel12.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel12.LinkColor = Color.Black;
			this.linkLabel12.Location = new Point(716, 605);
			this.linkLabel12.Name = "linkLabel12";
			this.linkLabel12.Padding = new Padding(20, 3, 0, 3);
			this.linkLabel12.Size = new Size(102, 19);
			this.linkLabel12.TabIndex = 23;
			this.linkLabel12.TabStop = true;
			this.linkLabel12.Tag = "http://www.thesimsresource.com/helpcenter/view-post/post/2743/Reasons%20to%20subscribe";
			this.linkLabel12.Text = "Learn More »";
			this.linkLabel12.Click += this.linkLabel10_Click;
			this.label2.BackColor = Color.Transparent;
			this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label2.Image = Class143.recentprojects;
			this.label2.ImageAlign = ContentAlignment.MiddleLeft;
			this.label2.Location = new Point(18, 199);
			this.label2.Name = "label2";
			this.label2.Size = new Size(138, 25);
			this.label2.TabIndex = 3;
			this.label2.Text = "Recent Projects:";
			this.label2.TextAlign = ContentAlignment.MiddleCenter;
			this.label2.UseMnemonic = false;
			this.linkLabel4.AutoSize = true;
			this.linkLabel4.BackColor = Color.Transparent;
			this.linkLabel4.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.linkLabel4.Image = (Image)componentResourceManager.GetObject("linkLabel4.Image");
			this.linkLabel4.ImageAlign = ContentAlignment.MiddleLeft;
			this.linkLabel4.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel4.LinkColor = Color.Black;
			this.linkLabel4.Location = new Point(430, 394);
			this.linkLabel4.Name = "linkLabel4";
			this.linkLabel4.Padding = new Padding(20, 3, 0, 3);
			this.linkLabel4.Size = new Size(198, 19);
			this.linkLabel4.TabIndex = 5;
			this.linkLabel4.TabStop = true;
			this.linkLabel4.Tag = "http://www.thesimsresource.com/workshop/news";
			this.linkLabel4.Text = "TSR Workshop News Archive »";
			this.linkLabel4.Click += this.linkLabel10_Click;
			this.showcase4.BackColor = Color.Transparent;
			this.showcase4.Location = new Point(529, 478);
			this.showcase4.Name = "showcase4";
			this.showcase4.Size = new Size(146, 146);
			this.showcase4.SizeMode = PictureBoxSizeMode.CenterImage;
			this.showcase4.TabIndex = 21;
			this.showcase4.TabStop = false;
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.BackColor = Color.Transparent;
			this.linkLabel3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.linkLabel3.Image = Class143.tutorials;
			this.linkLabel3.ImageAlign = ContentAlignment.MiddleLeft;
			this.linkLabel3.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel3.LinkColor = Color.Black;
			this.linkLabel3.Location = new Point(224, 167);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Padding = new Padding(20, 3, 0, 3);
			this.linkLabel3.Size = new Size(131, 19);
			this.linkLabel3.TabIndex = 6;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Tag = "http://wiki.thesimsresource.com/index.php?title=Workshop_Tutorials";
			this.linkLabel3.Text = "On-line Tutorials »";
			this.linkLabel3.Click += this.linkLabel10_Click;
			this.showcase3.BackColor = Color.Transparent;
			this.showcase3.Location = new Point(361, 478);
			this.showcase3.Name = "showcase3";
			this.showcase3.Size = new Size(146, 146);
			this.showcase3.SizeMode = PictureBoxSizeMode.CenterImage;
			this.showcase3.TabIndex = 20;
			this.showcase3.TabStop = false;
			this.showcase2.BackColor = Color.Transparent;
			this.showcase2.Location = new Point(193, 478);
			this.showcase2.Name = "showcase2";
			this.showcase2.Size = new Size(146, 146);
			this.showcase2.SizeMode = PictureBoxSizeMode.CenterImage;
			this.showcase2.TabIndex = 19;
			this.showcase2.TabStop = false;
			this.linkLabel6.AutoSize = true;
			this.linkLabel6.BackColor = Color.Transparent;
			this.linkLabel6.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.linkLabel6.Image = Class143.open;
			this.linkLabel6.ImageAlign = ContentAlignment.MiddleLeft;
			this.linkLabel6.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel6.LinkColor = Color.Black;
			this.linkLabel6.Location = new Point(18, 167);
			this.linkLabel6.Name = "linkLabel6";
			this.linkLabel6.Padding = new Padding(20, 3, 0, 3);
			this.linkLabel6.Size = new Size(111, 19);
			this.linkLabel6.TabIndex = 8;
			this.linkLabel6.TabStop = true;
			this.linkLabel6.Text = "Open Project »";
			this.linkLabel6.LinkClicked += this.linkLabel6_LinkClicked;
			this.showcase1.BackColor = Color.Transparent;
			this.showcase1.Location = new Point(25, 478);
			this.showcase1.Name = "showcase1";
			this.showcase1.Size = new Size(146, 146);
			this.showcase1.SizeMode = PictureBoxSizeMode.CenterImage;
			this.showcase1.TabIndex = 18;
			this.showcase1.TabStop = false;
			this.linkLabel7.AutoSize = true;
			this.linkLabel7.BackColor = Color.Transparent;
			this.linkLabel7.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.linkLabel7.Image = Class143.eula;
			this.linkLabel7.ImageAlign = ContentAlignment.MiddleLeft;
			this.linkLabel7.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel7.LinkColor = Color.Black;
			this.linkLabel7.Location = new Point(224, 204);
			this.linkLabel7.Name = "linkLabel7";
			this.linkLabel7.Padding = new Padding(20, 3, 0, 3);
			this.linkLabel7.Size = new Size(151, 19);
			this.linkLabel7.TabIndex = 9;
			this.linkLabel7.TabStop = true;
			this.linkLabel7.Tag = "http://www.thesimsresource.com/workshop/articles/view-post/post/12110/TSR%20Workshop%20EULA";
			this.linkLabel7.Text = "TSR Workshop EULA »";
			this.linkLabel7.Click += this.linkLabel10_Click;
			this.label5.AutoSize = true;
			this.label5.BackColor = Color.Transparent;
			this.label5.Location = new Point(102, 449);
			this.label5.Name = "label5";
			this.label5.Size = new Size(263, 13);
			this.label5.TabIndex = 17;
			this.label5.Text = "Custom Content recently created with TSR Workshop";
			this.linkLabel8.AutoSize = true;
			this.linkLabel8.BackColor = Color.Transparent;
			this.linkLabel8.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.linkLabel8.Image = Class143.forums;
			this.linkLabel8.ImageAlign = ContentAlignment.MiddleLeft;
			this.linkLabel8.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel8.LinkColor = Color.Black;
			this.linkLabel8.Location = new Point(224, 239);
			this.linkLabel8.Name = "linkLabel8";
			this.linkLabel8.Padding = new Padding(20, 3, 0, 3);
			this.linkLabel8.Size = new Size(142, 19);
			this.linkLabel8.TabIndex = 10;
			this.linkLabel8.TabStop = true;
			this.linkLabel8.Tag = "http://forums2.thesimsresource.com/forumdisplay.php?f=660";
			this.linkLabel8.Text = "Discussion Forums »";
			this.linkLabel8.Click += this.linkLabel10_Click;
			this.label4.BackColor = Color.Transparent;
			this.label4.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Image = Class143.showcase;
			this.label4.ImageAlign = ContentAlignment.MiddleLeft;
			this.label4.Location = new Point(21, 443);
			this.label4.Name = "label4";
			this.label4.Size = new Size(102, 25);
			this.label4.TabIndex = 16;
			this.label4.Text = "Showcase:";
			this.label4.TextAlign = ContentAlignment.MiddleCenter;
			this.label4.UseMnemonic = false;
			this.linkLabel11.AutoSize = true;
			this.linkLabel11.BackColor = Color.Transparent;
			this.linkLabel11.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.linkLabel11.Image = (Image)componentResourceManager.GetObject("linkLabel11.Image");
			this.linkLabel11.ImageAlign = ContentAlignment.MiddleLeft;
			this.linkLabel11.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel11.LinkColor = Color.Black;
			this.linkLabel11.Location = new Point(716, 394);
			this.linkLabel11.Name = "linkLabel11";
			this.linkLabel11.Padding = new Padding(20, 3, 0, 3);
			this.linkLabel11.Size = new Size(138, 19);
			this.linkLabel11.TabIndex = 15;
			this.linkLabel11.TabStop = true;
			this.linkLabel11.Tag = "http://www.thesimsresource.com/news";
			this.linkLabel11.Text = "TSR News Archive »";
			this.linkLabel11.Click += this.linkLabel10_Click;
			this.linkLabel10.AutoSize = true;
			this.linkLabel10.BackColor = Color.Transparent;
			this.linkLabel10.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.linkLabel10.Image = Class143.getlatest;
			this.linkLabel10.ImageAlign = ContentAlignment.MiddleLeft;
			this.linkLabel10.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel10.LinkColor = Color.Black;
			this.linkLabel10.Location = new Point(224, 347);
			this.linkLabel10.Name = "linkLabel10";
			this.linkLabel10.Padding = new Padding(20, 3, 0, 3);
			this.linkLabel10.Size = new Size(142, 19);
			this.linkLabel10.TabIndex = 12;
			this.linkLabel10.TabStop = true;
			this.linkLabel10.Tag = "http://www.thesimsresource.com/workshop/";
			this.linkLabel10.Text = "Get Latest Version »";
			this.linkLabel10.Click += this.linkLabel10_Click;
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.Transparent;
			this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.ImageAlign = ContentAlignment.MiddleLeft;
			this.label3.Location = new Point(716, 134);
			this.label3.Name = "label3";
			this.label3.Size = new Size(126, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "TSR News & Updates:";
			this.label3.TextAlign = ContentAlignment.MiddleLeft;
			this.label3.UseMnemonic = false;
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.ImageAlign = ContentAlignment.MiddleLeft;
			this.label1.Location = new Point(430, 134);
			this.label1.Name = "label1";
			this.label1.Size = new Size(161, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Workshop News & Updates:";
			this.label1.TextAlign = ContentAlignment.MiddleLeft;
			this.label1.UseMnemonic = false;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = Color.White;
			this.BackgroundImageLayout = ImageLayout.None;
			base.Controls.Add(this.mainPanel);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Name = "WelcomeControl";
			base.Size = new Size(955, 661);
			base.Load += this.WelcomeControl_Load;
			base.Resize += this.WelcomeControl_Resize;
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			((ISupportInitialize)this.showcase4).EndInit();
			((ISupportInitialize)this.showcase3).EndInit();
			((ISupportInitialize)this.showcase2).EndInit();
			((ISupportInitialize)this.showcase1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000591 RID: 1425
		private List<LinkLabel> list_0;

		// Token: 0x04000592 RID: 1426
		private static string string_0;

		// Token: 0x04000593 RID: 1427
		private static bool bool_0 = true;

		// Token: 0x04000594 RID: 1428
		private IContainer icontainer_0;

		// Token: 0x04000595 RID: 1429
		private Panel mainPanel;

		// Token: 0x04000596 RID: 1430
		private LinkLabel linkLabel1;

		// Token: 0x04000597 RID: 1431
		private LinkLabel linkLabel2;

		// Token: 0x04000598 RID: 1432
		private LinkLabel linkLabel12;

		// Token: 0x04000599 RID: 1433
		private Label label2;

		// Token: 0x0400059A RID: 1434
		private LinkLabel linkLabel4;

		// Token: 0x0400059B RID: 1435
		private PictureBox showcase4;

		// Token: 0x0400059C RID: 1436
		private LinkLabel linkLabel3;

		// Token: 0x0400059D RID: 1437
		private PictureBox showcase3;

		// Token: 0x0400059E RID: 1438
		private PictureBox showcase2;

		// Token: 0x0400059F RID: 1439
		private LinkLabel linkLabel6;

		// Token: 0x040005A0 RID: 1440
		private PictureBox showcase1;

		// Token: 0x040005A1 RID: 1441
		private LinkLabel linkLabel7;

		// Token: 0x040005A2 RID: 1442
		private Label label5;

		// Token: 0x040005A3 RID: 1443
		private LinkLabel linkLabel8;

		// Token: 0x040005A4 RID: 1444
		private Label label4;

		// Token: 0x040005A5 RID: 1445
		private LinkLabel linkLabel11;

		// Token: 0x040005A6 RID: 1446
		private LinkLabel linkLabel10;

		// Token: 0x040005A7 RID: 1447
		private Label label3;

		// Token: 0x040005A8 RID: 1448
		private Label label1;

		// Token: 0x040005A9 RID: 1449
		private Label latestVersionLabel;

		// Token: 0x040005AA RID: 1450
		private Class65 tsrnews;

		// Token: 0x040005AB RID: 1451
		private LinkLabel fetchData1;

		// Token: 0x040005AC RID: 1452
		private LinkLabel FetchData7;

		// Token: 0x040005AD RID: 1453
		private LinkLabel FetchData6;

		// Token: 0x040005AE RID: 1454
		private LinkLabel FetchData5;

		// Token: 0x040005AF RID: 1455
		private LinkLabel FetchData4;

		// Token: 0x040005B0 RID: 1456
		private LinkLabel FetchData3;

		// Token: 0x040005B1 RID: 1457
		private LinkLabel FetchData2;

		// Token: 0x040005B2 RID: 1458
		private Class65 workshopnews;
	}
}
