using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ns12
{
	// Token: 0x0200006D RID: 109
	internal sealed class Control1 : UserControl
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x00049D04 File Offset: 0x00047F04
		protected Control1.Enum6 DropState
		{
			get
			{
				return this.enum6_0;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x00049D1C File Offset: 0x00047F1C
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x0000447D File Offset: 0x0000267D
		public new string Text
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				base.Invalidate();
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00049D34 File Offset: 0x00047F34
		public Control1()
		{
			this.method_8();
			this.size_0 = base.Size;
			this.BackColor = Color.White;
			this.Text = base.Name;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00049D88 File Offset: 0x00047F88
		public void method_0(Control control_1)
		{
			if (this.control_0 != null)
			{
				throw new Exception("The drop down item has already been implemented!");
			}
			this.bool_1 = false;
			this.enum6_0 = Control1.Enum6.const_0;
			base.Size = this.size_1;
			this.rectangle_0 = new Rectangle(2, 2, this.size_1.Width - 21, this.size_1.Height - 4);
			if (base.Controls.Contains(control_1))
			{
				base.Controls.Remove(control_1);
			}
			this.control_0 = control_1;
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00049E10 File Offset: 0x00048010
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x0000448E File Offset: 0x0000268E
		public Size AnchorSize
		{
			get
			{
				return this.size_1;
			}
			set
			{
				this.size_1 = value;
				base.Invalidate();
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00049E28 File Offset: 0x00048028
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x0000449F File Offset: 0x0000269F
		public Control1.Enum5 DockSide
		{
			get
			{
				return this.enum5_0;
			}
			set
			{
				this.enum5_0 = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00049E40 File Offset: 0x00048040
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x00049E58 File Offset: 0x00048058
		[DefaultValue(false)]
		protected bool DesignView
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != value)
				{
					this.bool_1 = value;
					if (this.bool_1)
					{
						base.Size = this.size_0;
					}
					else
					{
						this.size_0 = base.Size;
						base.Size = this.size_1;
					}
				}
			}
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000443 RID: 1091 RVA: 0x00049EA8 File Offset: 0x000480A8
		// (remove) Token: 0x06000444 RID: 1092 RVA: 0x00049EE0 File Offset: 0x000480E0
		public event EventHandler PropertyChanged
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

		// Token: 0x06000445 RID: 1093 RVA: 0x000044AA File Offset: 0x000026AA
		protected void method_1()
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(null, null);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x00049F18 File Offset: 0x00048118
		public Rectangle AnchorClientBounds
		{
			get
			{
				return this.rectangle_0;
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00049F30 File Offset: 0x00048130
		protected void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this.bool_1)
			{
				this.size_0 = base.Size;
			}
			this.size_1.Width = base.Width;
			if (!this.bool_1)
			{
				this.size_1.Height = base.Height;
				this.rectangle_0 = new Rectangle(2, 2, this.size_1.Width - 21, this.size_1.Height - 4);
			}
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x000044C3 File Offset: 0x000026C3
		protected void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.bool_2 = true;
			this.method_2();
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x000044DB File Offset: 0x000026DB
		protected void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.bool_2 = false;
			base.Invalidate();
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x00049FAC File Offset: 0x000481AC
		protected bool CanDrop
		{
			get
			{
				bool result;
				if (this.form0_0 != null)
				{
					result = false;
				}
				else if (this.form0_0 == null && this.bool_0)
				{
					this.bool_0 = false;
					result = false;
				}
				else
				{
					result = !this.bool_0;
				}
				return result;
			}
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00049FF0 File Offset: 0x000481F0
		protected void method_2()
		{
			if (this.control_0 == null)
			{
				throw new NotImplementedException("The drop down item has not been initialized!  Use the InitializeDropDown() method to do so.");
			}
			if (this.CanDrop)
			{
				this.form0_0 = new Control1.Form0(this.control_0);
				Rectangle bounds = new Rectangle(this.vmethod_0(), new Size(this.control_0.Width + 2, this.control_0.Height + 2));
				this.form0_0.Bounds = bounds;
				this.form0_0.DropStateChange += this.method_4;
				this.form0_0.FormClosed += this.form0_0_FormClosed;
				this.enum6_0 = Control1.Enum6.const_2;
				this.form0_0.Show();
				this.enum6_0 = Control1.Enum6.const_3;
				base.Invalidate();
			}
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x000044F3 File Offset: 0x000026F3
		public void method_3()
		{
			if (this.form0_0 != null)
			{
				this.enum6_0 = Control1.Enum6.const_1;
				this.form0_0.bool_0 = false;
				this.form0_0.Close();
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0000451D File Offset: 0x0000271D
		private void method_4(Control1.Enum6 enum6_1)
		{
			this.enum6_0 = enum6_1;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0004A0B8 File Offset: 0x000482B8
		private void form0_0_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!this.form0_0.IsDisposed)
			{
				this.form0_0.DropStateChange -= this.method_4;
				this.form0_0.FormClosed -= this.form0_0_FormClosed;
				this.form0_0.Dispose();
			}
			this.form0_0 = null;
			this.bool_0 = base.RectangleToScreen(base.ClientRectangle).Contains(Cursor.Position);
			this.enum6_0 = Control1.Enum6.const_0;
			base.Invalidate();
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0004A140 File Offset: 0x00048340
		protected Point vmethod_0()
		{
			Point result;
			if (this.enum5_0 == Control1.Enum5.const_0)
			{
				result = base.Parent.PointToScreen(new Point(base.Bounds.X, base.Bounds.Bottom));
			}
			else
			{
				result = base.Parent.PointToScreen(new Point(base.Bounds.Right - this.control_0.Width, base.Bounds.Bottom));
			}
			return result;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0004A1C4 File Offset: 0x000483C4
		protected void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			ComboBoxRenderer.DrawTextBox(e.Graphics, new Rectangle(new Point(0, 0), this.size_1), this.method_5());
			ComboBoxRenderer.DrawDropDownButton(e.Graphics, new Rectangle(this.size_1.Width - 17, 1, 16, this.size_1.Height - 2), this.method_5());
			using (Brush brush = new SolidBrush(this.BackColor))
			{
				e.Graphics.FillRectangle(brush, this.AnchorClientBounds);
			}
			TextRenderer.DrawText(e.Graphics, this.string_0, this.Font, new Rectangle(this.AnchorClientBounds.Left, this.AnchorClientBounds.Top + 1, this.AnchorClientBounds.Width, base.Height), this.ForeColor, TextFormatFlags.WordEllipsis);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0004A2C4 File Offset: 0x000484C4
		private ComboBoxState method_5()
		{
			ComboBoxState result;
			if (!this.bool_2 && this.form0_0 == null)
			{
				result = ComboBoxState.Normal;
			}
			else
			{
				result = ComboBoxState.Pressed;
			}
			return result;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00004528 File Offset: 0x00002728
		public void method_6(bool bool_3)
		{
			if (this.form0_0 != null)
			{
				this.form0_0.bool_0 = true;
				if (!bool_3)
				{
					this.form0_0.Visible = false;
				}
			}
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0000454F File Offset: 0x0000274F
		public void method_7()
		{
			if (this.form0_0 != null)
			{
				this.form0_0.bool_0 = false;
				if (!this.form0_0.Visible)
				{
					this.form0_0.Visible = true;
				}
			}
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00004580 File Offset: 0x00002780
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000045A1 File Offset: 0x000027A1
		private void method_8()
		{
			this.icontainer_0 = new Container();
			base.AutoScaleMode = AutoScaleMode.Font;
		}

		// Token: 0x04000403 RID: 1027
		private Control1.Form0 form0_0;

		// Token: 0x04000404 RID: 1028
		private Control control_0;

		// Token: 0x04000405 RID: 1029
		private bool bool_0;

		// Token: 0x04000406 RID: 1030
		private Size size_0;

		// Token: 0x04000407 RID: 1031
		private Control1.Enum6 enum6_0;

		// Token: 0x04000408 RID: 1032
		private string string_0;

		// Token: 0x04000409 RID: 1033
		private Size size_1 = new Size(121, 21);

		// Token: 0x0400040A RID: 1034
		private Control1.Enum5 enum5_0;

		// Token: 0x0400040B RID: 1035
		private bool bool_1 = true;

		// Token: 0x0400040C RID: 1036
		private EventHandler eventHandler_0;

		// Token: 0x0400040D RID: 1037
		private Rectangle rectangle_0;

		// Token: 0x0400040E RID: 1038
		protected bool bool_2;

		// Token: 0x0400040F RID: 1039
		private IContainer icontainer_0;

		// Token: 0x0200006E RID: 110
		public enum Enum5
		{
			// Token: 0x04000411 RID: 1041
			const_0,
			// Token: 0x04000412 RID: 1042
			const_1
		}

		// Token: 0x0200006F RID: 111
		public enum Enum6
		{
			// Token: 0x04000414 RID: 1044
			const_0,
			// Token: 0x04000415 RID: 1045
			const_1,
			// Token: 0x04000416 RID: 1046
			const_2,
			// Token: 0x04000417 RID: 1047
			const_3
		}

		// Token: 0x02000070 RID: 112
		internal sealed class Form0 : Form, IMessageFilter
		{
			// Token: 0x06000456 RID: 1110 RVA: 0x000045B7 File Offset: 0x000027B7
			public Form0(Control dropDownItem)
			{
				base.FormBorderStyle = FormBorderStyle.None;
				dropDownItem.Location = new Point(1, 1);
				base.Controls.Add(dropDownItem);
				base.StartPosition = FormStartPosition.Manual;
				base.ShowInTaskbar = false;
				Application.AddMessageFilter(this);
			}

			// Token: 0x06000457 RID: 1111 RVA: 0x0004A2EC File Offset: 0x000484EC
			public bool PreFilterMessage(ref Message m)
			{
				if (!this.bool_0 && base.Visible && (Form.ActiveForm == null || !Form.ActiveForm.Equals(this)))
				{
					this.method_0(Control1.Enum6.const_1);
					base.Close();
				}
				return false;
			}

			// Token: 0x14000014 RID: 20
			// (add) Token: 0x06000458 RID: 1112 RVA: 0x0004A330 File Offset: 0x00048530
			// (remove) Token: 0x06000459 RID: 1113 RVA: 0x0004A368 File Offset: 0x00048568
			public event Control1.Form0.Delegate10 DropStateChange
			{
				add
				{
					Control1.Form0.Delegate10 @delegate = this.delegate10_0;
					Control1.Form0.Delegate10 delegate2;
					do
					{
						delegate2 = @delegate;
						Control1.Form0.Delegate10 value2 = (Control1.Form0.Delegate10)Delegate.Combine(delegate2, value);
						@delegate = Interlocked.CompareExchange<Control1.Form0.Delegate10>(ref this.delegate10_0, value2, delegate2);
					}
					while (@delegate != delegate2);
				}
				remove
				{
					Control1.Form0.Delegate10 @delegate = this.delegate10_0;
					Control1.Form0.Delegate10 delegate2;
					do
					{
						delegate2 = @delegate;
						Control1.Form0.Delegate10 value2 = (Control1.Form0.Delegate10)Delegate.Remove(delegate2, value);
						@delegate = Interlocked.CompareExchange<Control1.Form0.Delegate10>(ref this.delegate10_0, value2, delegate2);
					}
					while (@delegate != delegate2);
				}
			}

			// Token: 0x0600045A RID: 1114 RVA: 0x000045F5 File Offset: 0x000027F5
			private void method_0(Control1.Enum6 enum6_0)
			{
				if (this.delegate10_0 != null)
				{
					this.delegate10_0(enum6_0);
				}
			}

			// Token: 0x0600045B RID: 1115 RVA: 0x0004A3A0 File Offset: 0x000485A0
			protected void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);
				e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(0, 0, base.ClientSize.Width - 1, base.ClientSize.Height - 1));
			}

			// Token: 0x0600045C RID: 1116 RVA: 0x0000460D File Offset: 0x0000280D
			protected void OnClosing(CancelEventArgs e)
			{
				Application.RemoveMessageFilter(this);
				base.Controls.RemoveAt(0);
				base.OnClosing(e);
			}

			// Token: 0x04000418 RID: 1048
			public bool bool_0;

			// Token: 0x04000419 RID: 1049
			private Control1.Form0.Delegate10 delegate10_0;

			// Token: 0x02000071 RID: 113
			// (Invoke) Token: 0x0600045E RID: 1118
			public delegate void Delegate10(Control1.Enum6 state);
		}
	}
}
