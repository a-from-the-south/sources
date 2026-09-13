using System;
using System.ComponentModel;
using System.Globalization;
using ns0;

namespace ns2
{
	// Token: 0x020000B3 RID: 179
	internal sealed class Class78 : TypeConverter
	{
		// Token: 0x06000711 RID: 1809 RVA: 0x00068A10 File Offset: 0x00066C10
		public bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			bool result;
			if (sourceType == typeof(string))
			{
				result = true;
			}
			else
			{
				result = base.CanConvertFrom(context, sourceType);
			}
			return result;
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00068A3C File Offset: 0x00066C3C
		public object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			object result;
			if (value is string)
			{
				string[] array = ((string)value).Split(new char[]
				{
					';'
				});
				result = new Class77(double.Parse(array[0]), double.Parse(array[1]), double.Parse(array[2]));
			}
			else
			{
				result = base.ConvertFrom(context, culture, value);
			}
			return result;
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00068A98 File Offset: 0x00066C98
		public object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			Class77 @class = (Class77)value;
			object result;
			if (destinationType == typeof(string))
			{
				result = string.Concat(new string[]
				{
					Math.Round(@class.H).ToString(),
					";",
					@class.S.ToString("F"),
					";",
					@class.V.ToString("F")
				});
			}
			else
			{
				result = base.ConvertTo(context, culture, value, destinationType);
			}
			return result;
		}
	}
}
