using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ns11;
using ns6;
using ns9;

namespace ns19
{
	// Token: 0x02000142 RID: 322
	[Designer(typeof(Wizard.Control8))]
	internal sealed class Wizard : UserControl
	{
		// Token: 0x06000F7E RID: 3966 RVA: 0x000B6C24 File Offset: 0x000B4E24
		public Wizard()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			base.Dock = DockStyle.Fill;
			this.class147_0 = new Class147(this);
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x00008253 File Offset: 0x00006453
		protected void Dispose(bool disposing)
		{
			if (disposing && this.container_0 != null)
			{
				this.container_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x000B6CB0 File Offset: 0x000B4EB0
		private void InitializeComponent()
		{
			this.buttonCancel = new Button();
			this.buttonNext = new Button();
			this.buttonBack = new Button();
			this.buttonHelp = new Button();
			base.SuspendLayout();
			this.buttonCancel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.buttonCancel.DialogResult = DialogResult.Cancel;
			this.buttonCancel.FlatStyle = FlatStyle.System;
			this.buttonCancel.Location = new Point(344, 224);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += this.buttonCancel_Click;
			this.buttonNext.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.buttonNext.FlatStyle = FlatStyle.System;
			this.buttonNext.Location = new Point(260, 224);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.TabIndex = 7;
			this.buttonNext.Text = "&Next >";
			this.buttonNext.Click += this.buttonNext_Click;
			this.buttonBack.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.buttonBack.FlatStyle = FlatStyle.System;
			this.buttonBack.Location = new Point(184, 224);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.TabIndex = 6;
			this.buttonBack.Text = "< &Back";
			this.buttonBack.Click += this.buttonBack_Click;
			this.buttonHelp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.buttonHelp.FlatStyle = FlatStyle.System;
			this.buttonHelp.Location = new Point(8, 224);
			this.buttonHelp.Name = "buttonHelp";
			this.buttonHelp.TabIndex = 9;
			this.buttonHelp.Text = "&Help";
			this.buttonHelp.Visible = false;
			this.buttonHelp.Click += this.buttonHelp_Click;
			base.Controls.Add(this.buttonHelp);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonNext);
			base.Controls.Add(this.buttonBack);
			base.Name = "Wizard";
			base.Size = new Size(428, 256);
			base.ResumeLayout(false);
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000F81 RID: 3969 RVA: 0x000B6F48 File Offset: 0x000B5148
		// (set) Token: 0x06000F82 RID: 3970 RVA: 0x00008274 File Offset: 0x00006474
		[Category("Layout")]
		[Description("Gets or sets which edge of the parent container a control is docked to.")]
		[DefaultValue(DockStyle.Fill)]
		public new DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x000B6F60 File Offset: 0x000B5160
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Gets the collection of wizard pages in this tab control.")]
		[Category("Wizard")]
		public Class147 Pages
		{
			get
			{
				return this.class147_0;
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000F84 RID: 3972 RVA: 0x000B6F78 File Offset: 0x000B5178
		// (set) Token: 0x06000F85 RID: 3973 RVA: 0x0000827F File Offset: 0x0000647F
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Class146 SelectedPage
		{
			get
			{
				return this.class146_0;
			}
			set
			{
				this.method_3(value);
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000F86 RID: 3974 RVA: 0x000B6F90 File Offset: 0x000B5190
		// (set) Token: 0x06000F87 RID: 3975 RVA: 0x000B6FB4 File Offset: 0x000B51B4
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal int SelectedIndex
		{
			get
			{
				return this.class147_0.method_1(this.class146_0);
			}
			set
			{
				if (this.class147_0.Count == 0)
				{
					this.method_2(-1);
				}
				else
				{
					if (value < -1 || value >= this.class147_0.Count)
					{
						throw new ArgumentOutOfRangeException("SelectedIndex", value, "The page index must be between 0 and " + Convert.ToString(this.class147_0.Count - 1));
					}
					this.method_2(value);
				}
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000F88 RID: 3976 RVA: 0x000B7020 File Offset: 0x000B5220
		// (set) Token: 0x06000F89 RID: 3977 RVA: 0x0000828A File Offset: 0x0000648A
		[Description("Gets or sets the image displayed on the header of the standard pages.")]
		[DefaultValue(null)]
		[Category("Wizard")]
		public Image HeaderImage
		{
			get
			{
				return this.image_0;
			}
			set
			{
				if (this.image_0 != value)
				{
					this.image_0 = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000F8A RID: 3978 RVA: 0x000B7038 File Offset: 0x000B5238
		// (set) Token: 0x06000F8B RID: 3979 RVA: 0x000082A4 File Offset: 0x000064A4
		[Description("Gets or sets the image displayed on the welcome and finish pages.")]
		[DefaultValue(null)]
		[Category("Wizard")]
		public Image WelcomeImage
		{
			get
			{
				return this.image_1;
			}
			set
			{
				if (this.image_1 != value)
				{
					this.image_1 = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000F8C RID: 3980 RVA: 0x000B7050 File Offset: 0x000B5250
		// (set) Token: 0x06000F8D RID: 3981 RVA: 0x000082BE File Offset: 0x000064BE
		[Description("Gets or sets the font used to display the description of a standard page.")]
		[Category("Appearance")]
		public Font HeaderFont
		{
			get
			{
				Font font;
				if (this.font_0 == null)
				{
					font = this.Font;
				}
				else
				{
					font = this.font_0;
				}
				return font;
			}
			set
			{
				if (this.font_0 != value)
				{
					this.font_0 = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x000B7078 File Offset: 0x000B5278
		protected bool ShouldSerializeHeaderFont()
		{
			return this.font_0 != null;
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000F8F RID: 3983 RVA: 0x000B7098 File Offset: 0x000B5298
		// (set) Token: 0x06000F90 RID: 3984 RVA: 0x000082D8 File Offset: 0x000064D8
		[Description("Gets or sets the font used to display the title of a standard page.")]
		[Category("Appearance")]
		public Font HeaderTitleFont
		{
			get
			{
				Font result;
				if (this.font_1 == null)
				{
					result = new Font(this.Font.FontFamily, this.Font.Size + 2f, FontStyle.Bold);
				}
				else
				{
					result = this.font_1;
				}
				return result;
			}
			set
			{
				if (this.font_1 != value)
				{
					this.font_1 = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x000B70DC File Offset: 0x000B52DC
		protected bool ShouldSerializeHeaderTitleFont()
		{
			return this.font_1 != null;
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000F92 RID: 3986 RVA: 0x000B70FC File Offset: 0x000B52FC
		// (set) Token: 0x06000F93 RID: 3987 RVA: 0x000082F2 File Offset: 0x000064F2
		[Description("Gets or sets the font used to display the description of a welcome of finish page.")]
		[Category("Appearance")]
		public Font WelcomeFont
		{
			get
			{
				Font font;
				if (this.font_2 == null)
				{
					font = this.Font;
				}
				else
				{
					font = this.font_2;
				}
				return font;
			}
			set
			{
				if (this.font_2 != value)
				{
					this.font_2 = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x000B7124 File Offset: 0x000B5324
		protected bool ShouldSerializeWelcomeFont()
		{
			return this.font_2 != null;
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x000B7144 File Offset: 0x000B5344
		// (set) Token: 0x06000F96 RID: 3990 RVA: 0x0000830C File Offset: 0x0000650C
		[Description("Gets or sets the font used to display the title of a welcome of finish page.")]
		[Category("Appearance")]
		public Font WelcomeTitleFont
		{
			get
			{
				Font result;
				if (this.font_3 == null)
				{
					result = new Font(this.Font.FontFamily, this.Font.Size + 10f, FontStyle.Bold);
				}
				else
				{
					result = this.font_3;
				}
				return result;
			}
			set
			{
				if (this.font_3 != value)
				{
					this.font_3 = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x000B7188 File Offset: 0x000B5388
		protected bool ShouldSerializeWelcomeTitleFont()
		{
			return this.font_3 != null;
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000F98 RID: 3992 RVA: 0x000B71A8 File Offset: 0x000B53A8
		// (set) Token: 0x06000F99 RID: 3993 RVA: 0x00008326 File Offset: 0x00006526
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool NextEnabled
		{
			get
			{
				return this.buttonNext.Enabled;
			}
			set
			{
				this.buttonNext.Enabled = value;
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000F9A RID: 3994 RVA: 0x000B71C4 File Offset: 0x000B53C4
		// (set) Token: 0x06000F9B RID: 3995 RVA: 0x00008336 File Offset: 0x00006536
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool BackEnabled
		{
			get
			{
				return this.buttonBack.Enabled;
			}
			set
			{
				this.buttonBack.Enabled = value;
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000F9C RID: 3996 RVA: 0x000B71E0 File Offset: 0x000B53E0
		// (set) Token: 0x06000F9D RID: 3997 RVA: 0x00008346 File Offset: 0x00006546
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CancelEnabled
		{
			get
			{
				return this.buttonCancel.Enabled;
			}
			set
			{
				this.buttonCancel.Enabled = value;
			}
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000F9E RID: 3998 RVA: 0x000B71FC File Offset: 0x000B53FC
		// (set) Token: 0x06000F9F RID: 3999 RVA: 0x00008356 File Offset: 0x00006556
		[DefaultValue(false)]
		[Category("Behavior")]
		[Description("Gets or sets the visible state of the help button. ")]
		public bool HelpVisible
		{
			get
			{
				return this.buttonHelp.Visible;
			}
			set
			{
				this.buttonHelp.Visible = value;
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000FA0 RID: 4000 RVA: 0x000B7218 File Offset: 0x000B5418
		// (set) Token: 0x06000FA1 RID: 4001 RVA: 0x00008366 File Offset: 0x00006566
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string NextText
		{
			get
			{
				return this.buttonNext.Text;
			}
			set
			{
				this.buttonNext.Text = value;
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000FA2 RID: 4002 RVA: 0x000B7234 File Offset: 0x000B5434
		// (set) Token: 0x06000FA3 RID: 4003 RVA: 0x00008376 File Offset: 0x00006576
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string BackText
		{
			get
			{
				return this.buttonBack.Text;
			}
			set
			{
				this.buttonBack.Text = value;
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000FA4 RID: 4004 RVA: 0x000B7250 File Offset: 0x000B5450
		// (set) Token: 0x06000FA5 RID: 4005 RVA: 0x00008386 File Offset: 0x00006586
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string CancelText
		{
			get
			{
				return this.buttonCancel.Text;
			}
			set
			{
				this.buttonCancel.Text = value;
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x000B726C File Offset: 0x000B546C
		// (set) Token: 0x06000FA7 RID: 4007 RVA: 0x00008396 File Offset: 0x00006596
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string HelpText
		{
			get
			{
				return this.buttonHelp.Text;
			}
			set
			{
				this.buttonHelp.Text = value;
			}
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x000083A6 File Offset: 0x000065A6
		public void method_0()
		{
			if (this.SelectedIndex == this.class147_0.Count - 1)
			{
				this.buttonNext.Enabled = false;
			}
			else
			{
				this.vmethod_0(new Wizard.EventArgs6(this.SelectedIndex, this.SelectedIndex + 1));
			}
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x000083E6 File Offset: 0x000065E6
		public void method_1()
		{
			if (this.SelectedIndex == 0)
			{
				this.buttonBack.Enabled = false;
			}
			else
			{
				this.vmethod_0(new Wizard.EventArgs6(this.SelectedIndex, this.SelectedIndex - 1));
			}
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x000B7288 File Offset: 0x000B5488
		private void method_2(int int_1)
		{
			if (int_1 >= 0 && int_1 < this.class147_0.Count)
			{
				Class146 class146_ = this.class147_0[int_1];
				this.method_3(class146_);
			}
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x000B72C0 File Offset: 0x000B54C0
		private void method_3(Class146 class146_1)
		{
			if (this.class147_0.method_4(class146_1))
			{
				if (this.class146_0 != null)
				{
					this.class146_0.Visible = false;
				}
				this.class146_0 = class146_1;
				if (this.class146_0 != null)
				{
					this.class146_0.Parent = this;
					if (!base.Contains(this.class146_0))
					{
						base.Container.Add(this.class146_0);
					}
					if (this.class146_0.Style == Enum21.const_2)
					{
						this.buttonCancel.Text = "OK";
						this.buttonCancel.DialogResult = DialogResult.OK;
					}
					else
					{
						this.buttonCancel.Text = "Cancel";
						this.buttonCancel.DialogResult = DialogResult.Cancel;
					}
					this.class146_0.SetBounds(0, 0, base.Width, base.Height - 48);
					this.class146_0.Visible = true;
					this.class146_0.BringToFront();
					this.method_4(this.class146_0);
				}
				if (this.SelectedIndex > 0)
				{
					this.buttonBack.Enabled = true;
				}
				else
				{
					this.buttonBack.Enabled = false;
				}
				if (this.SelectedIndex < this.class147_0.Count - 1)
				{
					this.buttonNext.Enabled = true;
				}
				else
				{
					if (!base.DesignMode)
					{
						this.buttonBack.Enabled = false;
					}
					this.buttonNext.Enabled = false;
				}
				if (this.class146_0 != null)
				{
					this.class146_0.Invalidate();
				}
				else
				{
					base.Invalidate();
				}
			}
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x000B743C File Offset: 0x000B563C
		private void method_4(Control control_0)
		{
			Control control = null;
			foreach (object obj in control_0.Controls)
			{
				Control control2 = (Control)obj;
				if (control2.CanFocus && (control == null || control2.TabIndex < control.TabIndex))
				{
					control = control2;
				}
			}
			if (control != null)
			{
				control.Focus();
			}
			else
			{
				control_0.Focus();
			}
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x00008419 File Offset: 0x00006619
		protected void vmethod_0(Wizard.EventArgs6 eventArgs6_0)
		{
			if (this.delegate30_0 != null)
			{
				this.delegate30_0(this, eventArgs6_0);
			}
			if (!eventArgs6_0.Cancel)
			{
				this.method_2(eventArgs6_0.NewIndex);
				this.vmethod_1(eventArgs6_0);
			}
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x0000844F File Offset: 0x0000664F
		protected void vmethod_1(Wizard.EventArgs5 eventArgs5_0)
		{
			if (this.delegate31_0 != null)
			{
				this.delegate31_0(this, eventArgs5_0);
			}
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x00008468 File Offset: 0x00006668
		protected void vmethod_2(CancelEventArgs cancelEventArgs_0)
		{
			if (this.cancelEventHandler_0 != null)
			{
				this.cancelEventHandler_0(this, cancelEventArgs_0);
			}
			if (cancelEventArgs_0.Cancel)
			{
				base.ParentForm.DialogResult = DialogResult.None;
			}
			else
			{
				base.ParentForm.Close();
			}
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x000084A2 File Offset: 0x000066A2
		protected void vmethod_3(EventArgs eventArgs_0)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, eventArgs_0);
			}
			base.ParentForm.Close();
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x000084C6 File Offset: 0x000066C6
		protected void vmethod_4(EventArgs eventArgs_0)
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, eventArgs_0);
			}
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x000084DF File Offset: 0x000066DF
		protected void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (this.class147_0.Count > 0)
			{
				this.method_2(0);
			}
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x000B74C4 File Offset: 0x000B56C4
		protected void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this.class146_0 != null)
			{
				this.class146_0.SetBounds(0, 0, base.Width, base.Height - 48);
			}
			this.buttonCancel.Location = new Point(base.Width - this.point_0.X, base.Height - this.point_0.Y);
			this.buttonNext.Location = new Point(base.Width - this.point_1.X, base.Height - this.point_1.Y);
			this.buttonBack.Location = new Point(base.Width - this.point_2.X, base.Height - this.point_2.Y);
			this.buttonHelp.Location = new Point(this.buttonHelp.Location.X, base.Height - this.point_2.Y);
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x000B75E8 File Offset: 0x000B57E8
		protected void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Rectangle clientRectangle = base.ClientRectangle;
			clientRectangle.Y = base.Height - 48;
			clientRectangle.Height = 48;
			ControlPaint.DrawBorder3D(e.Graphics, clientRectangle, Border3DStyle.Etched, Border3DSide.Top);
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x000B762C File Offset: 0x000B582C
		protected void OnControlAdded(ControlEventArgs e)
		{
			if (!(e.Control is Class146) && e.Control != this.buttonCancel && e.Control != this.buttonNext && e.Control != this.buttonBack)
			{
				if (this.class146_0 != null)
				{
					this.class146_0.Controls.Add(e.Control);
				}
			}
			else
			{
				base.OnControlAdded(e);
			}
		}

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x06000FB6 RID: 4022 RVA: 0x000B769C File Offset: 0x000B589C
		// (remove) Token: 0x06000FB7 RID: 4023 RVA: 0x000B76D4 File Offset: 0x000B58D4
		[Description("Occurs before the wizard pages are switched, giving the user a chance to validate.")]
		[Category("Wizard")]
		public event Wizard.Delegate30 BeforeSwitchPages
		{
			add
			{
				Wizard.Delegate30 @delegate = this.delegate30_0;
				Wizard.Delegate30 delegate2;
				do
				{
					delegate2 = @delegate;
					Wizard.Delegate30 value2 = (Wizard.Delegate30)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Wizard.Delegate30>(ref this.delegate30_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Wizard.Delegate30 @delegate = this.delegate30_0;
				Wizard.Delegate30 delegate2;
				do
				{
					delegate2 = @delegate;
					Wizard.Delegate30 value2 = (Wizard.Delegate30)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Wizard.Delegate30>(ref this.delegate30_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x06000FB8 RID: 4024 RVA: 0x000B770C File Offset: 0x000B590C
		// (remove) Token: 0x06000FB9 RID: 4025 RVA: 0x000B7744 File Offset: 0x000B5944
		[Category("Wizard")]
		[Description("Occurs after the wizard pages are switched, giving the user a chance to setup the new page.")]
		public event Wizard.Delegate31 AfterSwitchPages
		{
			add
			{
				Wizard.Delegate31 @delegate = this.delegate31_0;
				Wizard.Delegate31 delegate2;
				do
				{
					delegate2 = @delegate;
					Wizard.Delegate31 value2 = (Wizard.Delegate31)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Wizard.Delegate31>(ref this.delegate31_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Wizard.Delegate31 @delegate = this.delegate31_0;
				Wizard.Delegate31 delegate2;
				do
				{
					delegate2 = @delegate;
					Wizard.Delegate31 value2 = (Wizard.Delegate31)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Wizard.Delegate31>(ref this.delegate31_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06000FBA RID: 4026 RVA: 0x000B777C File Offset: 0x000B597C
		// (remove) Token: 0x06000FBB RID: 4027 RVA: 0x000B77B4 File Offset: 0x000B59B4
		[Category("Wizard")]
		[Description("Occurs when wizard is canceled, giving the user a chance to validate.")]
		public event CancelEventHandler Cancel
		{
			add
			{
				CancelEventHandler cancelEventHandler = this.cancelEventHandler_0;
				CancelEventHandler cancelEventHandler2;
				do
				{
					cancelEventHandler2 = cancelEventHandler;
					CancelEventHandler value2 = (CancelEventHandler)Delegate.Combine(cancelEventHandler2, value);
					cancelEventHandler = Interlocked.CompareExchange<CancelEventHandler>(ref this.cancelEventHandler_0, value2, cancelEventHandler2);
				}
				while (cancelEventHandler != cancelEventHandler2);
			}
			remove
			{
				CancelEventHandler cancelEventHandler = this.cancelEventHandler_0;
				CancelEventHandler cancelEventHandler2;
				do
				{
					cancelEventHandler2 = cancelEventHandler;
					CancelEventHandler value2 = (CancelEventHandler)Delegate.Remove(cancelEventHandler2, value);
					cancelEventHandler = Interlocked.CompareExchange<CancelEventHandler>(ref this.cancelEventHandler_0, value2, cancelEventHandler2);
				}
				while (cancelEventHandler != cancelEventHandler2);
			}
		}

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06000FBC RID: 4028 RVA: 0x000B77EC File Offset: 0x000B59EC
		// (remove) Token: 0x06000FBD RID: 4029 RVA: 0x000B7824 File Offset: 0x000B5A24
		[Category("Wizard")]
		[Description("Occurs when wizard is finished, giving the user a chance to do extra stuff.")]
		public event EventHandler Finish
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

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06000FBE RID: 4030 RVA: 0x000B785C File Offset: 0x000B5A5C
		// (remove) Token: 0x06000FBF RID: 4031 RVA: 0x000B7894 File Offset: 0x000B5A94
		[Category("Wizard")]
		[Description("Occurs when the user clicks the help button.")]
		public event EventHandler Help
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_1, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_1, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x000084FF File Offset: 0x000066FF
		private void buttonNext_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x00008509 File Offset: 0x00006709
		private void buttonBack_Click(object sender, EventArgs e)
		{
			this.method_1();
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x00008513 File Offset: 0x00006713
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			if (this.buttonCancel.DialogResult == DialogResult.Cancel)
			{
				this.vmethod_2(new CancelEventArgs());
			}
			else if (this.buttonCancel.DialogResult == DialogResult.OK)
			{
				this.vmethod_3(EventArgs.Empty);
			}
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x0000854B File Offset: 0x0000674B
		private void buttonHelp_Click(object sender, EventArgs e)
		{
			this.vmethod_4(EventArgs.Empty);
		}

		// Token: 0x04000B31 RID: 2865
		private const int int_0 = 48;

		// Token: 0x04000B32 RID: 2866
		private readonly Point point_0 = new Point(84, 36);

		// Token: 0x04000B33 RID: 2867
		private readonly Point point_1 = new Point(168, 36);

		// Token: 0x04000B34 RID: 2868
		private readonly Point point_2 = new Point(244, 36);

		// Token: 0x04000B35 RID: 2869
		private Class146 class146_0;

		// Token: 0x04000B36 RID: 2870
		private Class147 class147_0;

		// Token: 0x04000B37 RID: 2871
		private Image image_0;

		// Token: 0x04000B38 RID: 2872
		private Image image_1;

		// Token: 0x04000B39 RID: 2873
		private Font font_0;

		// Token: 0x04000B3A RID: 2874
		private Font font_1;

		// Token: 0x04000B3B RID: 2875
		private Font font_2;

		// Token: 0x04000B3C RID: 2876
		private Font font_3;

		// Token: 0x04000B3D RID: 2877
		private Button buttonCancel;

		// Token: 0x04000B3E RID: 2878
		private Button buttonNext;

		// Token: 0x04000B3F RID: 2879
		private Button buttonBack;

		// Token: 0x04000B40 RID: 2880
		private Button buttonHelp;

		// Token: 0x04000B41 RID: 2881
		private Container container_0;

		// Token: 0x04000B42 RID: 2882
		private Wizard.Delegate30 delegate30_0;

		// Token: 0x04000B43 RID: 2883
		private Wizard.Delegate31 delegate31_0;

		// Token: 0x04000B44 RID: 2884
		private CancelEventHandler cancelEventHandler_0;

		// Token: 0x04000B45 RID: 2885
		private EventHandler eventHandler_0;

		// Token: 0x04000B46 RID: 2886
		private EventHandler eventHandler_1;

		// Token: 0x02000143 RID: 323
		// (Invoke) Token: 0x06000FC5 RID: 4037
		public delegate void Delegate30(object sender, Wizard.EventArgs6 e);

		// Token: 0x02000144 RID: 324
		// (Invoke) Token: 0x06000FC9 RID: 4041
		public delegate void Delegate31(object sender, Wizard.EventArgs5 e);

		// Token: 0x02000145 RID: 325
		internal sealed class Control8 : ParentControlDesigner
		{
			// Token: 0x06000FCC RID: 4044 RVA: 0x000B78CC File Offset: 0x000B5ACC
			protected void WndProc(ref Message m)
			{
				if (m.Msg == 513 || m.Msg == 515)
				{
					ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
					if (selectionService.PrimarySelection is Wizard)
					{
						Wizard wizard = (Wizard)selectionService.PrimarySelection;
						int x = (int)((short)((int)m.LParam & 65535));
						int y = (int)((short)((uint)((int)m.LParam & -65536) >> 16));
						Point pt = new Point(x, y);
						if (m.HWnd == wizard.buttonNext.Handle)
						{
							if (wizard.buttonNext.Enabled && wizard.buttonNext.ClientRectangle.Contains(pt))
							{
								wizard.method_0();
							}
						}
						else if (m.HWnd == wizard.buttonBack.Handle && wizard.buttonBack.Enabled && wizard.buttonBack.ClientRectangle.Contains(pt))
						{
							wizard.method_1();
						}
						return;
					}
				}
				base.WndProc(ref m);
			}

			// Token: 0x17000388 RID: 904
			// (get) Token: 0x06000FCD RID: 4045 RVA: 0x00024BE0 File Offset: 0x00022DE0
			protected bool DrawGrid
			{
				get
				{
					return false;
				}
			}
		}

		// Token: 0x02000146 RID: 326
		public class EventArgs5 : EventArgs
		{
			// Token: 0x06000FCF RID: 4047 RVA: 0x00008562 File Offset: 0x00006762
			internal EventArgs5(int oldIndex, int newIndex)
			{
				this.oldIndex = oldIndex;
				this.newIndex = newIndex;
			}

			// Token: 0x17000389 RID: 905
			// (get) Token: 0x06000FD0 RID: 4048 RVA: 0x000B79F0 File Offset: 0x000B5BF0
			public int OldIndex
			{
				get
				{
					return this.oldIndex;
				}
			}

			// Token: 0x1700038A RID: 906
			// (get) Token: 0x06000FD1 RID: 4049 RVA: 0x000B7A08 File Offset: 0x000B5C08
			public int NewIndex
			{
				get
				{
					return this.newIndex;
				}
			}

			// Token: 0x04000B47 RID: 2887
			private int oldIndex;

			// Token: 0x04000B48 RID: 2888
			protected int newIndex;
		}

		// Token: 0x02000147 RID: 327
		public sealed class EventArgs6 : Wizard.EventArgs5
		{
			// Token: 0x06000FD2 RID: 4050 RVA: 0x0000857A File Offset: 0x0000677A
			internal EventArgs6(int oldIndex, int newIndex) : base(oldIndex, newIndex)
			{
			}

			// Token: 0x1700038B RID: 907
			// (get) Token: 0x06000FD3 RID: 4051 RVA: 0x000B7A20 File Offset: 0x000B5C20
			// (set) Token: 0x06000FD4 RID: 4052 RVA: 0x00008584 File Offset: 0x00006784
			public bool Cancel
			{
				get
				{
					return this.bool_0;
				}
				set
				{
					this.bool_0 = value;
				}
			}

			// Token: 0x1700038C RID: 908
			// (get) Token: 0x06000FD5 RID: 4053 RVA: 0x000B7A08 File Offset: 0x000B5C08
			// (set) Token: 0x06000FD6 RID: 4054 RVA: 0x0000858F File Offset: 0x0000678F
			public new int NewIndex
			{
				get
				{
					return this.newIndex;
				}
				set
				{
					this.newIndex = value;
				}
			}

			// Token: 0x04000B49 RID: 2889
			private bool bool_0;
		}
	}
}
