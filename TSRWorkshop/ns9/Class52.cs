using System;
using System.Drawing;
using System.Windows.Forms;
using ns0;
using VisualHint.SmartPropertyGrid;

namespace ns9
{
	// Token: 0x02000076 RID: 118
	internal sealed class Class52 : PropertyLook
	{
		// Token: 0x06000477 RID: 1143 RVA: 0x000046E0 File Offset: 0x000028E0
		public Class52()
		{
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x000046E8 File Offset: 0x000028E8
		public Class52(bool hideValue)
		{
			this.hideValue = hideValue;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0004A620 File Offset: 0x00048820
		private Rectangle method_0(Rectangle rectangle_0)
		{
			Rectangle result = rectangle_0;
			Rectangle rectangle = base.Value.DrawIcon(null, rectangle_0, PropertyValue.DrawValueIn.None);
			if (rectangle.Width > 0)
			{
				rectangle.Width += base.Value.Grid.GlobalTextMargin;
			}
			result.X += base.Value.Grid.GlobalTextMargin + rectangle.Width;
			result.Y += 2;
			result.Height -= 6;
			if (this.hideValue)
			{
				result.Width = rectangle_0.Width - 2 * base.Value.Grid.GlobalTextMargin;
			}
			else
			{
				result.Width = 3 * result.Height / 2 * 2;
			}
			return result;
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0004A6F0 File Offset: 0x000488F0
		public void OnDraw(Graphics graphics, Rectangle valueRect, Color textColor, PropertyEnumerator propEnum, string drawAnotherString, bool multipleTexts, PropertyValue.DrawValueIn drawValueIn)
		{
			valueRect.Height++;
			base.Value.DrawIcon(graphics, valueRect, drawValueIn);
			VisualHint.SmartPropertyGrid.PropertyGrid parentGrid = propEnum.Property.ParentGrid;
			int containerWidth = 0;
			if (drawValueIn == PropertyValue.DrawValueIn.Grid)
			{
				containerWidth = parentGrid.InternalGrid.ClientSize.Width;
			}
			else if (drawValueIn == PropertyValue.DrawValueIn.InPlaceCtrl)
			{
				containerWidth = parentGrid.InPlaceControl.ClientSize.Width;
			}
			Rectangle rect = this.method_0(valueRect);
			rect = base.Value.Grid.TransformRectIfRTL(rect, containerWidth);
			Color color = Color.Empty;
			Color color2 = Color.Empty;
			try
			{
				if (!propEnum.Property.Value.HasMultipleTexts())
				{
					Class77 @class = (Class77)propEnum.Property.Value.ConvertDisplayedStringToValue(drawAnotherString);
					color = @class.method_0();
					color2 = @class.method_1();
				}
			}
			catch (Exception)
			{
				color = Color.Red;
			}
			Brush brush = new SolidBrush(color);
			graphics.FillRectangle(brush, rect);
			brush = new SolidBrush(color2);
			graphics.FillRectangle(brush, rect.X + rect.Width / 2, rect.Y, rect.Width / 2, rect.Height);
			if (propEnum.Property.Value.HasMultipleTexts())
			{
				graphics.DrawLine(SystemPens.GrayText, base.Value.Grid.TransformPointIfRTL(rect.Left, rect.Bottom, containerWidth), base.Value.Grid.TransformPointIfRTL(rect.Right, rect.Top, containerWidth));
			}
			graphics.DrawRectangle(Pens.Black, rect);
			Rectangle rect2 = this.GetDisplayStringRect(graphics, valueRect, Point.Empty);
			rect2.Width = valueRect.Right - rect2.Left;
			rect2 = base.Value.Grid.TransformRectIfRTL(rect2, containerWidth);
			Win32Calls.DrawText(graphics, (drawAnotherString == null) ? this.DisplayString : drawAnotherString, ref rect2, base.Value.Font, textColor, 34852 | ((base.Value.Grid.RightToLeft == RightToLeft.Yes) ? 131074 : 0));
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0004A914 File Offset: 0x00048B14
		public Rectangle GetDisplayStringRect(Graphics graphics, Rectangle valueRect, Point point)
		{
			Rectangle result;
			if (this.hideValue)
			{
				result = Rectangle.Empty;
			}
			else
			{
				Rectangle rectangle = this.method_0(valueRect);
				Rectangle rectangle2 = valueRect;
				rectangle2.X = rectangle.Right + 3 + base.Value.Grid.GlobalTextMargin;
				rectangle2.Width = Win32Calls.GetTextExtent(graphics, this.DisplayString, base.Value.Font).Width;
				result = rectangle2;
			}
			return result;
		}

		// Token: 0x0400041F RID: 1055
		private bool hideValue;
	}
}
