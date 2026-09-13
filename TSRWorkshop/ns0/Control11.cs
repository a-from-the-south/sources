using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x020001DB RID: 475
	[DesignerCategory("Code")]
	internal sealed class Control11 : Control
	{
		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06001342 RID: 4930 RVA: 0x0000A145 File Offset: 0x00008345
		// (set) Token: 0x06001343 RID: 4931 RVA: 0x0000A14D File Offset: 0x0000834D
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				this.Refresh();
			}
		}

		// Token: 0x06001344 RID: 4932 RVA: 0x0000A15C File Offset: 0x0000835C
		public void method_0()
		{
			this.timer_0.Enabled = false;
			this.image_0 = null;
			this.bool_0 = false;
			this.string_0 = string.Empty;
			this.Refresh();
			base.Height = 16;
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x0000A191 File Offset: 0x00008391
		public void method_1()
		{
			this.timer_0.Enabled = true;
			this.image_0 = Class206.smethod_0("current");
			this.bool_0 = true;
			this.Refresh();
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x0000A1BC File Offset: 0x000083BC
		public void method_2()
		{
			this.method_3(string.Empty);
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x000C6920 File Offset: 0x000C4B20
		public void method_3(string string_1)
		{
			this.string_0 = string_1;
			this.timer_0.Enabled = false;
			this.image_0 = Class206.smethod_0((string_1.Length > 0) ? "error" : "ok");
			this.bool_1 = true;
			this.bool_0 = true;
			if (string_1.Length > 0)
			{
				base.Height = 100;
			}
			this.Refresh();
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x000C6988 File Offset: 0x000C4B88
		protected void OnResize(EventArgs e)
		{
			this.label_0.SetBounds(Convert.ToInt32(22f * this.float_0), Convert.ToInt32(this.float_1), base.Width - Convert.ToInt32(22f * this.float_0), base.Height - Convert.ToInt32(this.float_1));
			base.OnResize(e);
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x0000A1C9 File Offset: 0x000083C9
		protected void ScaleCore(float dx, float dy)
		{
			this.float_0 = dx;
			this.float_1 = dy;
			base.ScaleCore(dx, dy);
			this.OnResize(EventArgs.Empty);
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x000C69F0 File Offset: 0x000C4BF0
		protected void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (base.DesignMode)
			{
				this.image_0 = Class206.smethod_0("current");
				this.bool_0 = true;
			}
			if (this.image_0 != null && this.bool_1)
			{
				e.Graphics.DrawImage(this.image_0, new Rectangle(0, 0, Convert.ToInt32(16f * this.float_0), Convert.ToInt32(16f * this.float_1)), new Rectangle(0, 0, 16, 16), GraphicsUnit.Pixel);
			}
			if (this.bool_0)
			{
				this.label_0.Text = ((this.string_0.Length > 0) ? (base.Text + " (" + this.string_0 + ")") : base.Text);
				return;
			}
			this.label_0.Text = string.Empty;
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x000C6AD0 File Offset: 0x000C4CD0
		public Control11()
		{
			this.timer_0.Interval = 250;
			this.timer_0.Tick += this.timer_0_Tick;
			this.label_0.FlatStyle = FlatStyle.System;
			base.Controls.Add(this.label_0);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.TabStop = false;
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x0000A1EC File Offset: 0x000083EC
		public Control11(string text) : this()
		{
			base.Text = " " + text;
		}

		// Token: 0x0600134D RID: 4941 RVA: 0x0000A205 File Offset: 0x00008405
		protected void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.image_0 != null)
				{
					this.image_0.Dispose();
				}
				this.timer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x0000A22F File Offset: 0x0000842F
		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.bool_1 = !this.bool_1;
			this.Refresh();
		}

		// Token: 0x04000D93 RID: 3475
		private readonly Label label_0 = new Label();

		// Token: 0x04000D94 RID: 3476
		private Image image_0;

		// Token: 0x04000D95 RID: 3477
		private bool bool_0;

		// Token: 0x04000D96 RID: 3478
		private readonly Timer timer_0 = new Timer();

		// Token: 0x04000D97 RID: 3479
		private bool bool_1 = true;

		// Token: 0x04000D98 RID: 3480
		private string string_0 = string.Empty;

		// Token: 0x04000D99 RID: 3481
		private float float_0 = 1f;

		// Token: 0x04000D9A RID: 3482
		private float float_1 = 1f;
	}
}
