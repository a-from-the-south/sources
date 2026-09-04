using System;
using System.ComponentModel;
using System.Globalization;

namespace Sims3WorkshopSDK
{
	// Token: 0x02000003 RID: 3
	public class IntTypeConverter : TypeConverter
	{
		// Token: 0x0600000D RID: 13 RVA: 0x0000209D File Offset: 0x0000029D
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000020BB File Offset: 0x000002BB
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(int) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000030B0 File Offset: 0x000012B0
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				if (context.PropertyDescriptor.PropertyType.Name == "Int64")
				{
					return Convert.ToInt64(value as string, 16);
				}
				if (context.PropertyDescriptor.PropertyType.Name == "UInt64")
				{
					return Convert.ToUInt64(value as string, 16);
				}
				if (context.PropertyDescriptor.PropertyType.Name == "Int32")
				{
					return Convert.ToInt32(value as string, 16);
				}
				if (context.PropertyDescriptor.PropertyType.Name == "UInt32")
				{
					return Convert.ToUInt32(value as string, 16);
				}
				if (context.PropertyDescriptor.PropertyType.Name == "Int16")
				{
					return Convert.ToInt16(value as string, 16);
				}
				if (context.PropertyDescriptor.PropertyType.Name == "UInt16")
				{
					return Convert.ToUInt16(value as string, 16);
				}
				if (context.PropertyDescriptor.PropertyType.Name == "Byte")
				{
					return Convert.ToByte(value as string, 16);
				}
				if (context.PropertyDescriptor.PropertyType.Name == "SByte")
				{
					return Convert.ToSByte(value as string, 16);
				}
			}
			return base.ConvertFrom(context, culture, value);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000324C File Offset: 0x0000144C
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
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
