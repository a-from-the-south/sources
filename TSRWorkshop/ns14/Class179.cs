using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using ns17;

namespace ns14
{
	// Token: 0x0200018F RID: 399
	internal sealed class Class179 : ExpandableObjectConverter
	{
		// Token: 0x06001214 RID: 4628 RVA: 0x000B9958 File Offset: 0x000B7B58
		public bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType != typeof(string))
			{
				if (destinationType != typeof(InstanceDescriptor))
				{
					return base.CanConvertTo(context, destinationType);
				}
			}
			return true;
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x000BF70C File Offset: 0x000BD90C
		public object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			Class161 @class = value as Class161;
			object result;
			if (destinationType == typeof(string))
			{
				if (!@class.method_9())
				{
					result = "(none)";
				}
				else
				{
					result = "(VisualTip)";
				}
			}
			else if (destinationType == typeof(InstanceDescriptor))
			{
				result = new InstanceDescriptor(typeof(Class161).GetConstructor(Type.EmptyTypes), null, false);
			}
			else
			{
				result = base.ConvertTo(context, culture, value, destinationType);
			}
			return result;
		}
	}
}
