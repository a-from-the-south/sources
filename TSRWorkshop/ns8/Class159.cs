using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using ns3;

namespace ns8
{
	// Token: 0x0200015D RID: 349
	internal abstract class Class159 : ExpandableObjectConverter, IComparer
	{
		// Token: 0x06001062 RID: 4194 RVA: 0x000089D1 File Offset: 0x00006BD1
		protected Class159(Type rendererType)
		{
			this.rendererType = rendererType;
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06001063 RID: 4195 RVA: 0x000B97CC File Offset: 0x000B79CC
		protected virtual object DefaultRenderer
		{
			get
			{
				return this.rendererType.GetProperty("DefaultRenderer", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);
			}
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x000B97F8 File Offset: 0x000B79F8
		protected virtual InstanceDescriptor vmethod_0(object object_0)
		{
			InstanceDescriptor result;
			if (object_0 == this.DefaultRenderer)
			{
				result = new InstanceDescriptor(this.rendererType.GetProperty("DefaultRenderer", BindingFlags.Static | BindingFlags.Public), null, true);
			}
			else
			{
				result = new InstanceDescriptor(object_0.GetType().GetConstructor(Type.EmptyTypes), null, object_0.GetType() == this.rendererType);
			}
			return result;
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x00037B84 File Offset: 0x00035D84
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x00037B84 File Offset: 0x00035D84
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x000B9854 File Offset: 0x000B7A54
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return this.method_0(context);
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x000B986C File Offset: 0x000B7A6C
		private TypeConverter.StandardValuesCollection method_0(ITypeDescriptorContext itypeDescriptorContext_0)
		{
			if (this.standardValuesCollection_0 == null)
			{
				this.hashtable_0 = new Hashtable();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(this.DefaultRenderer);
				this.hashtable_0["(Default)"] = this.vmethod_0(this.DefaultRenderer);
				foreach (Type type in this.rendererType.Assembly.GetExportedTypes())
				{
					if ((type == this.rendererType || type.IsSubclassOf(this.rendererType)) && !type.IsAbstract)
					{
						string key = Attribute2.smethod_0(type);
						this.hashtable_0[key] = new InstanceDescriptor(type.GetConstructor(Type.EmptyTypes), null, true);
						arrayList.Add(Activator.CreateInstance(type, null));
					}
				}
				arrayList.Sort(this);
				this.standardValuesCollection_0 = new TypeConverter.StandardValuesCollection(arrayList);
			}
			return this.standardValuesCollection_0;
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x000B9958 File Offset: 0x000B7B58
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
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

		// Token: 0x0600106A RID: 4202 RVA: 0x000B9994 File Offset: 0x000B7B94
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			object result;
			if (destinationType == typeof(string))
			{
				result = Attribute2.smethod_0(value.GetType());
			}
			else if (destinationType == typeof(InstanceDescriptor))
			{
				result = this.vmethod_0(value);
			}
			else
			{
				result = base.ConvertTo(context, culture, value, destinationType);
			}
			return result;
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x000B99E4 File Offset: 0x000B7BE4
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
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

		// Token: 0x0600106C RID: 4204 RVA: 0x000B9A10 File Offset: 0x000B7C10
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			object result;
			if (value is string)
			{
				if (!this.hashtable_0.ContainsKey(value))
				{
					throw new FormatException();
				}
				result = (this.hashtable_0[value] as InstanceDescriptor).Invoke();
			}
			else
			{
				result = base.ConvertFrom(context, culture, value);
			}
			return result;
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x000B9A60 File Offset: 0x000B7C60
		int IComparer.Compare(object x, object y)
		{
			string text = Attribute2.smethod_0(x.GetType());
			string strB = Attribute2.smethod_0(y.GetType());
			return text.CompareTo(strB);
		}

		// Token: 0x04000B94 RID: 2964
		private Type rendererType;

		// Token: 0x04000B95 RID: 2965
		private TypeConverter.StandardValuesCollection standardValuesCollection_0;

		// Token: 0x04000B96 RID: 2966
		private Hashtable hashtable_0;
	}
}
