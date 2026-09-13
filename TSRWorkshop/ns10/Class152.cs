using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ns1;

namespace ns10
{
	// Token: 0x02000155 RID: 341
	internal sealed class Class152
	{
		// Token: 0x14000035 RID: 53
		// (add) Token: 0x06001011 RID: 4113 RVA: 0x000086A9 File Offset: 0x000068A9
		// (remove) Token: 0x06001012 RID: 4114 RVA: 0x000086C4 File Offset: 0x000068C4
		public event PropertyChangedEventHandler x236e2b71e0b477c3
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.propertyChangedEventHandler_0 = (PropertyChangedEventHandler)Delegate.Combine(this.propertyChangedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.propertyChangedEventHandler_0 = (PropertyChangedEventHandler)Delegate.Remove(this.propertyChangedEventHandler_0, value);
			}
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x000086DF File Offset: 0x000068DF
		public void method_0(string string_0)
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(string_0));
			}
		}

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06001014 RID: 4116 RVA: 0x000086FD File Offset: 0x000068FD
		// (remove) Token: 0x06001015 RID: 4117 RVA: 0x00008718 File Offset: 0x00006918
		public event PropertyChangedEventHandler x0ad6cb77c00e4e89
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.propertyChangedEventHandler_1 = (PropertyChangedEventHandler)Delegate.Combine(this.propertyChangedEventHandler_1, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.propertyChangedEventHandler_1 = (PropertyChangedEventHandler)Delegate.Remove(this.propertyChangedEventHandler_1, value);
			}
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x00008733 File Offset: 0x00006933
		public void method_1(string string_0)
		{
			if (this.propertyChangedEventHandler_1 != null)
			{
				this.propertyChangedEventHandler_1(this, new PropertyChangedEventArgs(string_0));
			}
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x000B8620 File Offset: 0x000B6820
		public object method_2(string string_0, object object_0)
		{
			object result;
			if (this.hashtable_0 == null)
			{
				result = object_0;
			}
			else if (!this.hashtable_0.Contains(string_0))
			{
				result = object_0;
			}
			else
			{
				result = this.hashtable_0[string_0];
			}
			return result;
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x000B865C File Offset: 0x000B685C
		public void method_3(string string_0, object object_0, object object_1)
		{
			if (object.Equals(object_0, object_1))
			{
				this.method_6(string_0);
			}
			else
			{
				if (this.hashtable_0 == null)
				{
					this.hashtable_0 = new Hashtable();
				}
				this.method_0(string_0);
				this.hashtable_0[string_0] = object_0;
				this.method_1(string_0);
			}
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x000B86AC File Offset: 0x000B68AC
		public bool method_4(string string_0)
		{
			bool result;
			if (this.hashtable_0 != null)
			{
				result = this.hashtable_0.Contains(string_0);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x000B86D8 File Offset: 0x000B68D8
		public bool method_5()
		{
			bool result;
			if (this.hashtable_0 != null)
			{
				result = (this.hashtable_0.Count > 0);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x00008751 File Offset: 0x00006951
		public void method_6(string string_0)
		{
			if (this.hashtable_0 != null && this.hashtable_0.Contains(string_0))
			{
				this.method_0(string_0);
				this.hashtable_0.Remove(string_0);
				this.method_1(string_0);
			}
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x000B8704 File Offset: 0x000B6904
		public void method_7()
		{
			if (this.hashtable_0 != null)
			{
				string[] array = new string[checked((uint)this.hashtable_0.Count)];
				this.hashtable_0.Keys.CopyTo(array, 0);
				foreach (string string_ in array)
				{
					this.method_6(string_);
				}
				this.hashtable_0 = null;
			}
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x000B8764 File Offset: 0x000B6964
		public static PropertyDescriptorCollection smethod_0(object object_0, Attribute[] attribute_0)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in TypeDescriptor.GetProperties(object_0, attribute_0, true))
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
				if (propertyDescriptor.Attributes.Contains(Attribute1.attribute1_0))
				{
					arrayList.Add(new Class152.Class153(propertyDescriptor));
				}
				else
				{
					arrayList.Add(propertyDescriptor);
				}
			}
			return new PropertyDescriptorCollection((PropertyDescriptor[])arrayList.ToArray(typeof(PropertyDescriptor)));
		}

		// Token: 0x04000B80 RID: 2944
		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		// Token: 0x04000B81 RID: 2945
		private PropertyChangedEventHandler propertyChangedEventHandler_1;

		// Token: 0x04000B82 RID: 2946
		private Hashtable hashtable_0;

		// Token: 0x02000156 RID: 342
		private sealed class Class153 : PropertyDescriptor
		{
			// Token: 0x0600101E RID: 4126 RVA: 0x00008785 File Offset: 0x00006985
			public Class153(PropertyDescriptor original) : base(original)
			{
				this.original = original;
			}

			// Token: 0x0600101F RID: 4127 RVA: 0x00037B84 File Offset: 0x00035D84
			public bool CanResetValue(object component)
			{
				return true;
			}

			// Token: 0x17000393 RID: 915
			// (get) Token: 0x06001020 RID: 4128 RVA: 0x000B8808 File Offset: 0x000B6A08
			public Type ComponentType
			{
				get
				{
					return this.original.ComponentType;
				}
			}

			// Token: 0x06001021 RID: 4129 RVA: 0x000B8824 File Offset: 0x000B6A24
			public object GetValue(object component)
			{
				return this.original.GetValue(component);
			}

			// Token: 0x17000394 RID: 916
			// (get) Token: 0x06001022 RID: 4130 RVA: 0x000B8844 File Offset: 0x000B6A44
			public bool IsReadOnly
			{
				get
				{
					return this.original.IsReadOnly;
				}
			}

			// Token: 0x17000395 RID: 917
			// (get) Token: 0x06001023 RID: 4131 RVA: 0x000B8860 File Offset: 0x000B6A60
			public Type PropertyType
			{
				get
				{
					return this.original.PropertyType;
				}
			}

			// Token: 0x06001024 RID: 4132 RVA: 0x00008797 File Offset: 0x00006997
			public void SetValue(object component, object value)
			{
				this.original.SetValue(component, value);
			}

			// Token: 0x06001025 RID: 4133 RVA: 0x000087A8 File Offset: 0x000069A8
			public void ResetValue(object component)
			{
				(component as Interface12).imethod_0().method_6(this.original.Name);
			}

			// Token: 0x06001026 RID: 4134 RVA: 0x000B887C File Offset: 0x000B6A7C
			public bool ShouldSerializeValue(object component)
			{
				return (component as Interface12).imethod_0().method_4(this.original.Name);
			}

			// Token: 0x04000B83 RID: 2947
			private PropertyDescriptor original;
		}
	}
}
