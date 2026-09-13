using System;
using System.Drawing;
using System.Windows.Forms;
using VisualHint.SmartPropertyGrid;

namespace ns17
{
	// Token: 0x0200008E RID: 142
	internal sealed class Class59 : PropInPlaceButton
	{
		// Token: 0x060005AD RID: 1453 RVA: 0x00004D8E File Offset: 0x00002F8E
		public Class59(bool editable) : base(editable)
		{
			base.ButtonText = "Edits";
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00004DA4 File Offset: 0x00002FA4
		protected void OnDoubleClick(EventArgs e)
		{
			this.RunButton();
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0005B65C File Offset: 0x0005985C
		protected void OnPaint(PaintEventArgs e)
		{
			PropertyValue value = base.OwnerPropertyEnumerator.Property.Value;
			this.mOwnerPropertyEnum.Property.ParentGrid.DrawManager.DrawPropertyValueBackground(e.Graphics, base.ClientRectangle, this.mOwnerPropertyEnum, PropertyValue.DrawValueIn.InPlaceCtrl);
			Rectangle rectangle = base.GetButtonRect(e.Graphics);
			rectangle = this.mOwnerPropertyEnum.Property.ParentGrid.TransformRectIfRTL(rectangle, base.ClientSize.Width);
			rectangle.X -= 2;
			rectangle.Y++;
			rectangle.Height = 22;
			rectangle.Width++;
			if (!base.ReadOnly)
			{
				VisualHint.SmartPropertyGrid.PropertyGrid parentGrid = this.mOwnerPropertyEnum.Property.ParentGrid;
				parentGrid.DrawManager.DrawButton(e.Graphics, this, rectangle, this.bool_0, this.bool_1, PropertyValue.DrawValueIn.InPlaceCtrl);
				StringFormat stringFormat = (StringFormat)StringFormat.GenericDefault.Clone();
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				using (Brush brush = new SolidBrush(parentGrid.DrawManager.GetButtonTextColor()))
				{
					e.Graphics.DrawString("Edit", this.Font, brush, rectangle, stringFormat);
				}
			}
			if (!base.FullWidthButton)
			{
				Rectangle clientRectangle = base.ClientRectangle;
				clientRectangle.Width -= rectangle.Width + 1;
				Color textColor;
				if (!this.mOwnerPropertyEnum.Property.Enabled)
				{
					textColor = SystemColors.GrayText;
				}
				else
				{
					textColor = value.ForeColor;
				}
				if (value.HasMultipleTexts() && this.Text.Length == 0)
				{
					value.DrawValue(e.Graphics, clientRectangle, textColor, this.mOwnerPropertyEnum, "", true, PropertyValue.DrawValueIn.InPlaceCtrl);
				}
				else
				{
					value.DrawValue(e.Graphics, clientRectangle, textColor, this.mOwnerPropertyEnum, this.Text, false, PropertyValue.DrawValueIn.InPlaceCtrl);
				}
			}
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0005B85C File Offset: 0x00059A5C
		protected void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Graphics graphics = base.CreateGraphics();
				if (this.mOwnerPropertyEnum.Property.ParentGrid.TransformRectIfRTL(base.GetButtonRect(graphics), base.ClientSize.Width).Contains(new Point(e.X, e.Y)))
				{
					this.bool_0 = true;
				}
				graphics.Dispose();
			}
			base.OnMouseDown(e);
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00004DAE File Offset: 0x00002FAE
		protected void OnLostFocus(EventArgs e)
		{
			this.bool_0 = false;
			base.OnLostFocus(e);
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00004DC0 File Offset: 0x00002FC0
		protected void OnMouseUp(MouseEventArgs e)
		{
			if (this.bool_0 && e.Button == MouseButtons.Left)
			{
				this.bool_0 = false;
				this.bool_1 = false;
			}
			base.OnMouseUp(e);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0005B8D8 File Offset: 0x00059AD8
		protected void OnMouseMove(MouseEventArgs e)
		{
			Graphics graphics = base.CreateGraphics();
			this.bool_1 = this.mOwnerPropertyEnum.Property.ParentGrid.TransformRectIfRTL(base.GetButtonRect(graphics), base.ClientSize.Width).Contains(new Point(e.X, e.Y));
			graphics.Dispose();
			base.OnMouseMove(e);
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00004DEE File Offset: 0x00002FEE
		protected void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyData == Keys.Return || e.KeyData == Keys.Space)
			{
				this.bool_1 = true;
				this.bool_0 = true;
			}
			base.OnKeyDown(e);
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00004E1B File Offset: 0x0000301B
		protected void OnKeyUp(KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Return || e.KeyData == Keys.Space) && this.bool_0)
			{
				this.bool_1 = false;
				this.bool_0 = false;
			}
			base.OnKeyUp(e);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0005B944 File Offset: 0x00059B44
		protected bool ProcessDialogKey(Keys keyData)
		{
			Keys keys = keyData & Keys.KeyCode;
			if (keys == Keys.Escape && this.mEdit != null && this.mEdit.Focused)
			{
				this.bool_0 = false;
			}
			return base.ProcessDialogKey(keyData);
		}

		// Token: 0x04000525 RID: 1317
		protected bool bool_0;

		// Token: 0x04000526 RID: 1318
		protected bool bool_1;
	}
}
