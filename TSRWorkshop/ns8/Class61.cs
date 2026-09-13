using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using ns16;
using ns17;
using Package.Sims3Files;
using Package.Squish;
using Sims3WorkshopSDK;
using VisualHint.SmartPropertyGrid;

namespace ns8
{
	// Token: 0x02000091 RID: 145
	internal class Class61 : PropertyLook
	{
		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060005C8 RID: 1480 RVA: 0x0005BE9C File Offset: 0x0005A09C
		// (remove) Token: 0x060005C9 RID: 1481 RVA: 0x0005BED4 File Offset: 0x0005A0D4
		public event Class61.Delegate16 PropertyChanged
		{
			add
			{
				Class61.Delegate16 @delegate = this.delegate16_0;
				Class61.Delegate16 delegate2;
				do
				{
					delegate2 = @delegate;
					Class61.Delegate16 value2 = (Class61.Delegate16)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class61.Delegate16>(ref this.delegate16_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Class61.Delegate16 @delegate = this.delegate16_0;
				Class61.Delegate16 delegate2;
				do
				{
					delegate2 = @delegate;
					Class61.Delegate16 value2 = (Class61.Delegate16)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Class61.Delegate16>(ref this.delegate16_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00004EFF File Offset: 0x000030FF
		public Class61()
		{
			Class61.textureBrush_0.WrapMode = WrapMode.Tile;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00004F30 File Offset: 0x00003130
		public void method_0(PropertyButtonClickedEventArgs propertyButtonClickedEventArgs_0, ResKey resKey_0)
		{
			if (this.delegate16_0 != null)
			{
				this.NeedsUpdate = true;
				this.delegate16_0(propertyButtonClickedEventArgs_0, resKey_0);
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x0005BF0C File Offset: 0x0005A10C
		// (set) Token: 0x060005CD RID: 1485 RVA: 0x00004F50 File Offset: 0x00003150
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

		// Token: 0x060005CE RID: 1486 RVA: 0x00004F5B File Offset: 0x0000315B
		public Class61(bool hideValue)
		{
			this.hideValue = hideValue;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0005BF24 File Offset: 0x0005A124
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

		// Token: 0x060005D0 RID: 1488 RVA: 0x0005BFEC File Offset: 0x0005A1EC
		public override void OnDraw(Graphics graphics, Rectangle valueRect, Color textColor, PropertyEnumerator propEnum, string drawAnotherString, bool multipleTexts, PropertyValue.DrawValueIn drawValueIn)
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
					graphics.FillRectangle(Class61.textureBrush_0, num, num2, num3, num4);
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

		// Token: 0x060005D1 RID: 1489 RVA: 0x0005C278 File Offset: 0x0005A478
		protected virtual void vmethod_0(PropertyEnumerator propertyEnumerator_0, string string_0)
		{
			TextureResKey textureResKey = null;
			try
			{
				if (!propertyEnumerator_0.Property.Value.HasMultipleTexts())
				{
					textureResKey = (TextureResKey)base.Value.ConvertDisplayedStringToValue(string_0);
				}
			}
			catch (Exception)
			{
				textureResKey = (TextureResKey)base.Value.GetValue();
			}
			if (textureResKey != this.textureResKey_0 || this.bitmap_0 == null || this.bool_4)
			{
				if (this.bitmap_0 != null)
				{
					this.bitmap_0.Dispose();
				}
				this.bool_4 = false;
				DDS dds = (DDS)Class76.smethod_30(textureResKey, false, false);
				if (textureResKey.InstanceId == 0 && textureResKey.SecondInstanceId == 0 && textureResKey.GroupId == 0)
				{
					this.bitmap_0 = new Bitmap(64, 64);
					Graphics graphics = Graphics.FromImage(this.bitmap_0);
					graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, 64, 64));
					Font font = new Font("Tahoma", 7f);
					graphics.DrawString("null", font, Brushes.Black, new Point(22, 20));
					graphics.DrawString("reference", font, Brushes.Black, new Point(12, 32));
				}
				else if (dds != null)
				{
					if (dds.MipMaps.Length > 0)
					{
						DDS.MipMap mipMap = dds.MipMaps[0];
						this.bitmap_0 = (ImageLoader.Load(mipMap) as Bitmap);
					}
					else
					{
						this.bitmap_0 = new Bitmap(64, 64);
						Graphics graphics2 = Graphics.FromImage(this.bitmap_0);
						graphics2.FillRectangle(Brushes.Black, new Rectangle(0, 0, 64, 64));
						Font font2 = new Font("Tahoma", 7f);
						graphics2.DrawString("zero", font2, Brushes.White, new Point(23, 20));
						graphics2.DrawString("mipmaps", font2, Brushes.White, new Point(12, 32));
					}
				}
				this.textureResKey_0 = textureResKey;
			}
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0005C47C File Offset: 0x0005A67C
		public override Rectangle GetDisplayStringRect(Graphics graphics, Rectangle valueRect, Point point)
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

		// Token: 0x060005D3 RID: 1491 RVA: 0x00004ED2 File Offset: 0x000030D2
		public override void ControlHeightMultiplier()
		{
			base.Value.OwnerEnumerator.Property.HeightMultiplier = 5;
		}

		// Token: 0x04000531 RID: 1329
		private bool hideValue;

		// Token: 0x04000532 RID: 1330
		protected Bitmap bitmap_0;

		// Token: 0x04000533 RID: 1331
		private TextureResKey textureResKey_0;

		// Token: 0x04000534 RID: 1332
		protected bool bool_0 = true;

		// Token: 0x04000535 RID: 1333
		protected bool bool_1 = true;

		// Token: 0x04000536 RID: 1334
		protected bool bool_2 = true;

		// Token: 0x04000537 RID: 1335
		protected bool bool_3 = true;

		// Token: 0x04000538 RID: 1336
		protected bool bool_4;

		// Token: 0x04000539 RID: 1337
		protected static TextureBrush textureBrush_0 = new TextureBrush(Class143.alphacheck);

		// Token: 0x0400053A RID: 1338
		private Class61.Delegate16 delegate16_0;

		// Token: 0x02000092 RID: 146
		// (Invoke) Token: 0x060005D6 RID: 1494
		public delegate void Delegate16(PropertyButtonClickedEventArgs e, ResKey reskey);
	}
}
