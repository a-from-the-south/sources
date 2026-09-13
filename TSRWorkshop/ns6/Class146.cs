using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ns11;
using ns19;

namespace ns6
{
	// Token: 0x02000149 RID: 329
	[DefaultEvent("Click")]
	[Designer(typeof(Class146.Control9))]
	internal sealed class Class146 : Panel
	{
		// Token: 0x06000FD7 RID: 4055 RVA: 0x000B7A38 File Offset: 0x000B5C38
		public Class146()
		{
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.UserPaint, true);
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000FD8 RID: 4056 RVA: 0x000B7A8C File Offset: 0x000B5C8C
		// (set) Token: 0x06000FD9 RID: 4057 RVA: 0x000B7AA4 File Offset: 0x000B5CA4
		[DefaultValue(Enum21.const_0)]
		[Description("Gets or sets the style of the wizard page.")]
		[Category("Wizard")]
		public Enum21 Style
		{
			get
			{
				return this.enum21_0;
			}
			set
			{
				if (this.enum21_0 != value)
				{
					this.enum21_0 = value;
					if (base.Parent != null && base.Parent is Wizard)
					{
						Wizard wizard = (Wizard)base.Parent;
						if (wizard.SelectedPage == this)
						{
							wizard.SelectedPage = this;
						}
					}
					else
					{
						base.Invalidate();
					}
				}
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000FDA RID: 4058 RVA: 0x000B7AFC File Offset: 0x000B5CFC
		// (set) Token: 0x06000FDB RID: 4059 RVA: 0x0000859A File Offset: 0x0000679A
		[DefaultValue("")]
		[Category("Wizard")]
		[Description("Gets or sets the title of the wizard page.")]
		public string Title
		{
			get
			{
				return this.string_0;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				if (this.string_0 != value)
				{
					this.string_0 = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000FDC RID: 4060 RVA: 0x000B7B14 File Offset: 0x000B5D14
		// (set) Token: 0x06000FDD RID: 4061 RVA: 0x000085C3 File Offset: 0x000067C3
		[Description("Gets or sets the description of the wizard page.")]
		[Category("Wizard")]
		[DefaultValue("")]
		public string Description
		{
			get
			{
				return this.string_1;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				if (this.string_1 != value)
				{
					this.string_1 = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x000B7B2C File Offset: 0x000B5D2C
		protected void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (this.enum21_0 != Enum21.const_3)
			{
				Rectangle clientRectangle = base.ClientRectangle;
				Rectangle empty = Rectangle.Empty;
				Rectangle empty2 = Rectangle.Empty;
				Rectangle empty3 = Rectangle.Empty;
				StringFormat genericDefault = StringFormat.GenericDefault;
				genericDefault.LineAlignment = StringAlignment.Near;
				genericDefault.Alignment = StringAlignment.Near;
				genericDefault.Trimming = StringTrimming.EllipsisCharacter;
				switch (this.enum21_0)
				{
				case Enum21.const_0:
				{
					clientRectangle.Height = 64;
					ControlPaint.DrawBorder3D(e.Graphics, clientRectangle, Border3DStyle.Etched, Border3DSide.Bottom);
					clientRectangle.Height -= SystemInformation.Border3DSize.Height;
					e.Graphics.FillRectangle(SystemBrushes.Window, clientRectangle);
					int num = (int)Math.Floor(8.0);
					empty.Location = new Point(1, 1);
					empty.Size = new Size(base.Width - 2, 60);
					Image image = null;
					Font font = this.Font;
					Font font2 = this.Font;
					if (base.Parent != null && base.Parent is Wizard)
					{
						Wizard wizard = (Wizard)base.Parent;
						image = wizard.HeaderImage;
						font = wizard.HeaderFont;
						font2 = wizard.HeaderTitleFont;
					}
					if (image == null)
					{
						ControlPaint.DrawFocusRectangle(e.Graphics, empty);
					}
					else
					{
						e.Graphics.DrawImage(image, empty);
					}
					empty.Location = new Point(base.Width - 48 - num, num);
					empty.Size = new Size(base.Width - 2, 60);
					int num2 = (int)Math.Ceiling((double)e.Graphics.MeasureString(this.string_0, font2, 0, genericDefault).Height);
					empty2.Location = new Point(8, 8);
					empty2.Size = new Size(empty.Left - 8, num2);
					empty3.Location = empty2.Location;
					empty3.Y += num2 + 4;
					empty3.Size = new Size(empty2.Width, 64 - empty3.Y);
					e.Graphics.DrawString(this.string_0, font2, SystemBrushes.WindowText, empty2, genericDefault);
					e.Graphics.DrawString(this.string_1, font, SystemBrushes.WindowText, empty3, genericDefault);
					break;
				}
				case Enum21.const_1:
				case Enum21.const_2:
				{
					e.Graphics.FillRectangle(SystemBrushes.Window, clientRectangle);
					empty.Location = Point.Empty;
					empty.Size = new Size(164, base.Height);
					Image image2 = null;
					Font font3 = this.Font;
					Font font4 = this.Font;
					if (base.Parent != null && base.Parent is Wizard)
					{
						Wizard wizard2 = (Wizard)base.Parent;
						image2 = wizard2.WelcomeImage;
						font3 = wizard2.WelcomeFont;
						font4 = wizard2.WelcomeTitleFont;
					}
					if (image2 == null)
					{
						ControlPaint.DrawFocusRectangle(e.Graphics, empty);
					}
					else
					{
						e.Graphics.DrawImage(image2, empty, new Rectangle(0, 0, empty.Width, empty.Height), GraphicsUnit.Pixel);
					}
					empty2.Location = new Point(172, 8);
					empty2.Width = base.Width - empty2.Left - 8;
					int num3 = (int)Math.Ceiling((double)e.Graphics.MeasureString(this.string_0, font4, empty2.Width, genericDefault).Height);
					empty3.Location = empty2.Location;
					empty3.Y += num3 + 8;
					empty3.Size = new Size(base.Width - empty3.Left - 8, base.Height - empty3.Y);
					e.Graphics.DrawString(this.string_0, font4, SystemBrushes.WindowText, empty2, genericDefault);
					e.Graphics.DrawString(this.string_1, font3, SystemBrushes.WindowText, empty3, genericDefault);
					break;
				}
				}
			}
		}

		// Token: 0x04000B4F RID: 2895
		private const int int_0 = 64;

		// Token: 0x04000B50 RID: 2896
		private const int int_1 = 48;

		// Token: 0x04000B51 RID: 2897
		private const int int_2 = 8;

		// Token: 0x04000B52 RID: 2898
		private const int int_3 = 164;

		// Token: 0x04000B53 RID: 2899
		private Enum21 enum21_0;

		// Token: 0x04000B54 RID: 2900
		private string string_0 = string.Empty;

		// Token: 0x04000B55 RID: 2901
		private string string_1 = string.Empty;

		// Token: 0x0200014A RID: 330
		internal sealed class Control9 : ParentControlDesigner
		{
			// Token: 0x17000390 RID: 912
			// (get) Token: 0x06000FDF RID: 4063 RVA: 0x000B7F2C File Offset: 0x000B612C
			public SelectionRules SelectionRules
			{
				get
				{
					return SelectionRules.Visible | SelectionRules.Locked;
				}
			}
		}
	}
}
