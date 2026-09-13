using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using ns16;
using ns17;
using Package;
using Sims3WorkshopSDK;
using VisualHint.SmartPropertyGrid;

namespace ns9
{
	// Token: 0x0200008F RID: 143
	internal sealed class Class60 : PropertyLook
	{
		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060005B7 RID: 1463 RVA: 0x0005B988 File Offset: 0x00059B88
		// (remove) Token: 0x060005B8 RID: 1464 RVA: 0x0005B9C0 File Offset: 0x00059BC0
		public event Class60.Delegate15 PropertyChanged
		{
			add
			{
				Class60.Delegate15 @delegate = this.delegate15_0;
				Class60.Delegate15 delegate2;
				do
				{
					delegate2 = @delegate;
					Class60.Delegate15 value2 = (Class60.Delegate15)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class60.Delegate15>(ref this.delegate15_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Class60.Delegate15 @delegate = this.delegate15_0;
				Class60.Delegate15 delegate2;
				do
				{
					delegate2 = @delegate;
					Class60.Delegate15 value2 = (Class60.Delegate15)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class60.Delegate15>(ref this.delegate15_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00004E50 File Offset: 0x00003050
		public Class60()
		{
			Class60.textureBrush_0.WrapMode = WrapMode.Tile;
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00004E81 File Offset: 0x00003081
		public void method_0(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
		{
			if (this.delegate15_0 != null)
			{
				this.delegate15_0(propertyButtonClickedEventArgs_0, resKey_0);
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0005B9F8 File Offset: 0x00059BF8
		// (set) Token: 0x060005BC RID: 1468 RVA: 0x00004E9A File Offset: 0x0000309A
		public bool NeedsUpdate
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
			}
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x00004EA5 File Offset: 0x000030A5
		public Class60(bool hideValue)
		{
			this.hideValue = hideValue;
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0005BA10 File Offset: 0x00059C10
		private Rectangle method_1(Rectangle rectangle_0)
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
				result.Width = result.Height;
			}
			return result;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0005BAD8 File Offset: 0x00059CD8
		public void OnDraw(Graphics graphics, Rectangle valueRect, Color textColor, PropertyEnumerator propEnum, string drawAnotherString, bool multipleTexts, PropertyValue.DrawValueIn drawValueIn)
		{
			valueRect.Height++;
			base.Value.DrawIcon(graphics, valueRect, drawValueIn);
			PropertyGrid parentGrid = propEnum.Property.ParentGrid;
			int containerWidth = 0;
			if (drawValueIn == PropertyValue.DrawValueIn.Grid)
			{
				containerWidth = parentGrid.InternalGrid.ClientSize.Width;
			}
			else if (drawValueIn == PropertyValue.DrawValueIn.InPlaceCtrl)
			{
				containerWidth = parentGrid.InPlaceControl.ClientSize.Width;
			}
			Rectangle rect = this.method_1(valueRect);
			rect = base.Value.Grid.TransformRectIfRTL(rect, containerWidth);
			if (this.bool_2)
			{
				graphics.FillRectangle(Brushes.Black, rect);
			}
			this.vmethod_0(propEnum, drawAnotherString);
			if (this.bitmap_0 != null)
			{
				int num = rect.Left;
				int num2 = rect.Top;
				int num3 = rect.Width;
				int num4 = rect.Height;
				if (!this.bool_0)
				{
					if (this.bitmap_0.Width <= num3)
					{
						num3 = this.bitmap_0.Width;
					}
					if (this.bitmap_0.Height <= num4)
					{
						num4 = this.bitmap_0.Height;
					}
				}
				else if (this.bitmap_0.Width > this.bitmap_0.Height)
				{
					num4 = (int)((float)num4 * ((float)this.bitmap_0.Height / (float)this.bitmap_0.Width));
					num2 += (rect.Height - num4) / 2;
				}
				else if (this.bitmap_0.Height > this.bitmap_0.Width)
				{
					num3 = (int)((float)num3 * ((float)this.bitmap_0.Width / (float)this.bitmap_0.Height));
					num += (rect.Width - num3) / 2;
				}
				if (this.bool_1)
				{
					graphics.FillRectangle(Class60.textureBrush_0, num, num2, num3, num4);
				}
				graphics.DrawImage(this.bitmap_0, num, num2, num3, num4);
			}
			if (propEnum.Property.Value.HasMultipleTexts())
			{
				graphics.DrawLine(SystemPens.GrayText, base.Value.Grid.TransformPointIfRTL(rect.Left, rect.Bottom, containerWidth), base.Value.Grid.TransformPointIfRTL(rect.Right, rect.Top, containerWidth));
			}
			if (this.bool_3)
			{
				graphics.DrawRectangle(Pens.Black, rect);
			}
			Rectangle rect2 = this.GetDisplayStringRect(graphics, valueRect, Point.Empty);
			rect2.Width = valueRect.Right - rect2.Left;
			rect2 = base.Value.Grid.TransformRectIfRTL(rect2, containerWidth);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0005BD64 File Offset: 0x00059F64
		protected void vmethod_0(PropertyEnumerator propertyEnumerator_0, string string_0)
		{
			ImageReskey imageReskey = null;
			try
			{
				if (!propertyEnumerator_0.Property.Value.HasMultipleTexts())
				{
					imageReskey = (ImageReskey)base.Value.ConvertDisplayedStringToValue(string_0);
				}
			}
			catch (Exception)
			{
				imageReskey = (ImageReskey)base.Value.GetValue();
			}
			if (imageReskey != this.imageReskey_0 || this.bitmap_0 == null || this.bool_4)
			{
				if (this.bitmap_0 != null)
				{
					this.bitmap_0.Dispose();
				}
				this.bool_4 = false;
				DBPFEntry dbpfentry = Class76.smethod_26(imageReskey);
				if (dbpfentry != null)
				{
					MemoryStream memoryStream = new MemoryStream(dbpfentry.GetData());
					this.bitmap_0 = (Image.FromStream(memoryStream) as Bitmap);
					memoryStream.Dispose();
				}
				this.imageReskey_0 = imageReskey;
			}
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0005BE28 File Offset: 0x0005A028
		public Rectangle GetDisplayStringRect(Graphics graphics, Rectangle valueRect, Point point)
		{
			Rectangle result;
			if (this.hideValue)
			{
				result = Rectangle.Empty;
			}
			else
			{
				Rectangle rectangle = this.method_1(valueRect);
				Rectangle rectangle2 = valueRect;
				rectangle2.X = rectangle.Right + 3 + base.Value.Grid.GlobalTextMargin;
				rectangle2.Width = Win32Calls.GetTextExtent(graphics, this.DisplayString, base.Value.Font).Width;
				result = rectangle2;
			}
			return result;
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00004ED2 File Offset: 0x000030D2
		public void ControlHeightMultiplier()
		{
			base.Value.OwnerEnumerator.Property.HeightMultiplier = 5;
		}

		// Token: 0x04000527 RID: 1319
		private bool hideValue;

		// Token: 0x04000528 RID: 1320
		protected Bitmap bitmap_0;

		// Token: 0x04000529 RID: 1321
		private ImageReskey imageReskey_0;

		// Token: 0x0400052A RID: 1322
		protected bool bool_0 = true;

		// Token: 0x0400052B RID: 1323
		protected bool bool_1 = true;

		// Token: 0x0400052C RID: 1324
		protected bool bool_2 = true;

		// Token: 0x0400052D RID: 1325
		protected bool bool_3 = true;

		// Token: 0x0400052E RID: 1326
		protected bool bool_4;

		// Token: 0x0400052F RID: 1327
		protected static TextureBrush textureBrush_0 = new TextureBrush(Class143.alphacheck);

		// Token: 0x04000530 RID: 1328
		private Class60.Delegate15 delegate15_0;

		// Token: 0x02000090 RID: 144
		// (Invoke) Token: 0x060005C5 RID: 1477
		public delegate void Delegate15(PropertyButtonClickedEventArgs e, ResKey reskey);
	}
}
