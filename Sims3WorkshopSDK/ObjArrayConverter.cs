using System;
using System.ComponentModel;
using System.Globalization;

namespace Sims3WorkshopSDK
{
	// Token: 0x02000004 RID: 4
	public class ObjArrayConverter : TypeConverter
	{
		// Token: 0x06000012 RID: 18 RVA: 0x0000209D File Offset: 0x0000029D
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000020BB File Offset: 0x000002BB
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(int) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003398 File Offset: 0x00001598
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				string[] array = (value as string).Split(new char[]
				{
					';'
				});
				object[] array2 = new object[array.Length];
				int num = 0;
				foreach (string text in array)
				{
					if (!text.Contains(".") && !text.Contains(","))
					{
						array2[num] = Convert.ToInt32(text);
					}
					else
					{
						array2[num] = Convert.ToSingle(text);
					}
					num++;
				}
				return array2;
			}
			return base.ConvertFrom(context, culture, value);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003430 File Offset: 0x00001630
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value is Array)
			{
				string text = "";
				int num = 0;
				foreach (object obj in ((Array)value))
				{
					if (num > 0)
					{
						text += "; ";
					}
					if (obj is int)
					{
						text = text + "0x" + ((int)obj).ToString("X8");
					}
					else if (obj is float)
					{
						text += ((float)obj).ToString();
					}
					num++;
				}
				return text;
			}
			if (value is ulong)
			{
				return "0x" + ((ulong)value).ToString("X16");
			}
			if (value is long)
			{
				return "0x" + ((long)value).ToString("X16");
			}
			if (value is uint)
			{
				return "0x" + ((uint)value).ToString("X8");
			}
			if (value is int)
			{
				return "0x" + ((int)value).ToString("X8");
			}
			if (value is short)
			{
				return "0x" + ((short)value).ToString("X4");
			}
			if (value is ushort)
			{
				return "0x" + ((ushort)value).ToString("X4");
			}
			if (value is byte)
			{
				return "0x" + ((byte)value).ToString("X2");
			}
			if (value is sbyte)
			{
				return "0x" + ((sbyte)value).ToString("X2");
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
