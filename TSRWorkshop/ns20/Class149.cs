using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using ns14;

namespace ns20
{
	// Token: 0x02000153 RID: 339
	internal abstract class Class149 : TypeConverter
	{
		// Token: 0x06001004 RID: 4100 RVA: 0x00008698 File Offset: 0x00006898
		protected Class149(Type standardType)
		{
			this.standardType = standardType;
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x00037B84 File Offset: 0x00035D84
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x00037B84 File Offset: 0x00035D84
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x000B8350 File Offset: 0x000B6550
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			foreach (PropertyInfo propertyInfo in this.standardType.GetProperties(BindingFlags.Static | BindingFlags.Public))
			{
				if (propertyInfo.IsDefined(typeof(Attribute0), true))
				{
					arrayList.Add(propertyInfo.GetValue(null, null));
					arrayList2.Add(propertyInfo.Name);
				}
			}
			Array array = arrayList.ToArray();
			Array.Sort(arrayList2.ToArray(), array);
			return new TypeConverter.StandardValuesCollection(array);
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x000B83E0 File Offset: 0x000B65E0
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			bool result;
			if (destinationType != typeof(string) && destinationType != typeof(InstanceDescriptor))
			{
				result = base.CanConvertTo(context, destinationType);
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x000B8418 File Offset: 0x000B6618
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			object result;
			if (destinationType == typeof(string))
			{
				PropertyInfo propertyInfo = this.method_0(value);
				if (propertyInfo == null)
				{
					throw new FormatException();
				}
				result = this.method_1(propertyInfo);
			}
			else if (destinationType == typeof(InstanceDescriptor))
			{
				PropertyInfo propertyInfo2 = this.method_0(value);
				if (propertyInfo2 == null)
				{
					throw new FormatException();
				}
				result = new InstanceDescriptor(propertyInfo2, null, true);
			}
			else
			{
				result = base.ConvertTo(context, culture, value, destinationType);
			}
			return result;
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x000B8488 File Offset: 0x000B6688
		private PropertyInfo method_0(object object_0)
		{
			foreach (PropertyInfo propertyInfo in this.standardType.GetProperties(BindingFlags.Static | BindingFlags.Public))
			{
				if (propertyInfo.IsDefined(typeof(Attribute0), true) && object.Equals(propertyInfo.GetValue(null, null), object_0))
				{
					return propertyInfo;
				}
			}
			return null;
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x000B84E8 File Offset: 0x000B66E8
		private string method_1(PropertyInfo propertyInfo_0)
		{
			string name = (Attribute.GetCustomAttribute(propertyInfo_0, typeof(Attribute0)) as Attribute0).name;
			string result;
			if (name == null)
			{
				result = propertyInfo_0.Name;
			}
			else
			{
				result = name;
			}
			return result;
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x000B8524 File Offset: 0x000B6724
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			bool result;
			if (sourceType != typeof(string))
			{
				result = base.CanConvertFrom(context, sourceType);
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x000B8550 File Offset: 0x000B6750
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				foreach (PropertyInfo propertyInfo in this.standardType.GetProperties(BindingFlags.Static | BindingFlags.Public))
				{
					if (propertyInfo.IsDefined(typeof(Attribute0), true) && this.method_1(propertyInfo) == (string)value)
					{
						return propertyInfo.GetValue(null, null);
					}
				}
			}
			return base.ConvertFrom(context, culture, value);
		}

		// Token: 0x04000B7D RID: 2941
		private Type standardType;
	}
}
