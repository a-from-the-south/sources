using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Threading;
using ns11;
using ns12;
using ns3;

namespace Sims3Workshop.Data
{
	// Token: 0x020000BA RID: 186
	public class PropertyBag : ICustomTypeDescriptor
	{
		// Token: 0x060007B3 RID: 1971 RVA: 0x00005999 File Offset: 0x00003B99
		public PropertyBag()
		{
			this.string_0 = null;
			this.propertySpecCollection_0 = new PropertyBag.PropertySpecCollection();
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060007B4 RID: 1972 RVA: 0x00071FB0 File Offset: 0x000701B0
		// (set) Token: 0x060007B5 RID: 1973 RVA: 0x000059B5 File Offset: 0x00003BB5
		public string DefaultProperty
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060007B6 RID: 1974 RVA: 0x00071FC8 File Offset: 0x000701C8
		public PropertyBag.PropertySpecCollection Properties
		{
			get
			{
				return this.propertySpecCollection_0;
			}
		}

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060007B7 RID: 1975 RVA: 0x00071FE0 File Offset: 0x000701E0
		// (remove) Token: 0x060007B8 RID: 1976 RVA: 0x00072018 File Offset: 0x00070218
		public event Delegate19 GetValue
		{
			add
			{
				Delegate19 @delegate = this.delegate19_0;
				Delegate19 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate19 value2 = (Delegate19)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate19>(ref this.delegate19_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate19 @delegate = this.delegate19_0;
				Delegate19 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate19 value2 = (Delegate19)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate19>(ref this.delegate19_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060007B9 RID: 1977 RVA: 0x00072050 File Offset: 0x00070250
		// (remove) Token: 0x060007BA RID: 1978 RVA: 0x00072088 File Offset: 0x00070288
		public event Delegate19 SetValue
		{
			add
			{
				Delegate19 @delegate = this.delegate19_1;
				Delegate19 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate19 value2 = (Delegate19)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate19>(ref this.delegate19_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate19 @delegate = this.delegate19_1;
				Delegate19 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate19 value2 = (Delegate19)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate19>(ref this.delegate19_1, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x000059C0 File Offset: 0x00003BC0
		protected virtual void vmethod_0(EventArgs2 eventArgs2_0)
		{
			if (this.delegate19_0 != null)
			{
				this.delegate19_0(this, eventArgs2_0);
			}
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x000059D9 File Offset: 0x00003BD9
		protected virtual void vmethod_1(EventArgs2 eventArgs2_0)
		{
			if (this.delegate19_1 != null)
			{
				this.delegate19_1(this, eventArgs2_0);
			}
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x000720C0 File Offset: 0x000702C0
		AttributeCollection ICustomTypeDescriptor.GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, true);
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x000720D8 File Offset: 0x000702D8
		string ICustomTypeDescriptor.GetClassName()
		{
			return TypeDescriptor.GetClassName(this, true);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x000720F0 File Offset: 0x000702F0
		string ICustomTypeDescriptor.GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00072108 File Offset: 0x00070308
		TypeConverter ICustomTypeDescriptor.GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00072120 File Offset: 0x00070320
		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00072138 File Offset: 0x00070338
		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
		{
			Class82 @class = null;
			if (this.string_0 != null)
			{
				int int_ = this.propertySpecCollection_0.method_6(this.string_0);
				@class = this.propertySpecCollection_0[int_];
			}
			PropertyDescriptor result;
			if (@class != null)
			{
				result = new PropertyBag.Class84(@class, this, @class.Name, null);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00072188 File Offset: 0x00070388
		object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x000721A4 File Offset: 0x000703A4
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x000721BC File Offset: 0x000703BC
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x000721D8 File Offset: 0x000703D8
		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
		{
			return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x000721F8 File Offset: 0x000703F8
		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
		{
			ArrayList arrayList = new ArrayList();
			using (IEnumerator enumerator = this.propertySpecCollection_0.System.Collections.IEnumerable.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Class82 @class = (Class82)obj;
					ArrayList arrayList2 = new ArrayList();
					if (@class.Category != null)
					{
						arrayList2.Add(new CategoryAttribute(@class.Category));
					}
					if (@class.Description != null)
					{
						arrayList2.Add(new DescriptionAttribute(@class.Description));
					}
					if (@class.EditorTypeName != null)
					{
						arrayList2.Add(new EditorAttribute(@class.EditorTypeName, typeof(UITypeEditor)));
					}
					if (@class.ConverterTypeName != null)
					{
						arrayList2.Add(new TypeConverterAttribute(@class.ConverterTypeName));
					}
					if (@class.Attributes != null)
					{
						arrayList2.AddRange(@class.Attributes);
					}
					Attribute[] attrs = (Attribute[])arrayList2.ToArray(typeof(Attribute));
					PropertyBag.Class84 value = new PropertyBag.Class84(@class, this, @class.Name, attrs);
					arrayList.Add(value);
				}
			}
			PropertyDescriptor[] properties = (PropertyDescriptor[])arrayList.ToArray(typeof(PropertyDescriptor));
			return new PropertyDescriptorCollection(properties);
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x000059F2 File Offset: 0x00003BF2
		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}

		// Token: 0x04000653 RID: 1619
		private string string_0;

		// Token: 0x04000654 RID: 1620
		private PropertyBag.PropertySpecCollection propertySpecCollection_0;

		// Token: 0x04000655 RID: 1621
		private Delegate19 delegate19_0;

		// Token: 0x04000656 RID: 1622
		private Delegate19 delegate19_1;

		// Token: 0x020000BB RID: 187
		[Serializable]
		public sealed class PropertySpecCollection : IList, ICollection, IEnumerable
		{
			// Token: 0x060007C9 RID: 1993 RVA: 0x000059F5 File Offset: 0x00003BF5
			public PropertySpecCollection()
			{
				this.innerArray = new ArrayList();
			}

			// Token: 0x1700014A RID: 330
			// (get) Token: 0x060007CA RID: 1994 RVA: 0x00072340 File Offset: 0x00070540
			public int Count
			{
				get
				{
					return this.innerArray.Count;
				}
			}

			// Token: 0x1700014B RID: 331
			// (get) Token: 0x060007CB RID: 1995 RVA: 0x00024BE0 File Offset: 0x00022DE0
			public bool IsFixedSize
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700014C RID: 332
			// (get) Token: 0x060007CC RID: 1996 RVA: 0x00024BE0 File Offset: 0x00022DE0
			public bool IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700014D RID: 333
			// (get) Token: 0x060007CD RID: 1997 RVA: 0x00024BE0 File Offset: 0x00022DE0
			public bool IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700014E RID: 334
			// (get) Token: 0x060007CE RID: 1998 RVA: 0x00024C50 File Offset: 0x00022E50
			object ICollection.SyncRoot
			{
				get
				{
					return null;
				}
			}

			// Token: 0x1700014F RID: 335
			public Class82 this[int int_0]
			{
				get
				{
					return (Class82)this.innerArray[int_0];
				}
				set
				{
					this.innerArray[int_0] = value;
				}
			}

			// Token: 0x060007D1 RID: 2001 RVA: 0x00072380 File Offset: 0x00070580
			public int Add(Class82 value)
			{
				return this.innerArray.Add(value);
			}

			// Token: 0x060007D2 RID: 2002 RVA: 0x00005A1B File Offset: 0x00003C1B
			public void method_0(Class82[] class82_0)
			{
				this.innerArray.AddRange(class82_0);
			}

			// Token: 0x060007D3 RID: 2003 RVA: 0x00005A2B File Offset: 0x00003C2B
			public void Clear()
			{
				this.innerArray.Clear();
			}

			// Token: 0x060007D4 RID: 2004 RVA: 0x000723A0 File Offset: 0x000705A0
			public bool method_1(Class82 class82_0)
			{
				return this.innerArray.Contains(class82_0);
			}

			// Token: 0x060007D5 RID: 2005 RVA: 0x000723C0 File Offset: 0x000705C0
			public bool method_2(string string_0)
			{
				bool result;
				foreach (object obj in this.innerArray)
				{
					Class82 @class = (Class82)obj;
					if (@class.Name == string_0)
					{
						result = true;
						goto IL_4D;
					}
				}
				return false;
				IL_4D:
				return result;
			}

			// Token: 0x060007D6 RID: 2006 RVA: 0x00005A3A File Offset: 0x00003C3A
			public void method_3(Class82[] class82_0)
			{
				this.innerArray.CopyTo(class82_0);
			}

			// Token: 0x060007D7 RID: 2007 RVA: 0x00005A4A File Offset: 0x00003C4A
			public void method_4(Class82[] class82_0, int int_0)
			{
				this.innerArray.CopyTo(class82_0, int_0);
			}

			// Token: 0x060007D8 RID: 2008 RVA: 0x00072434 File Offset: 0x00070634
			public IEnumerator GetEnumerator()
			{
				return this.innerArray.GetEnumerator();
			}

			// Token: 0x060007D9 RID: 2009 RVA: 0x00072450 File Offset: 0x00070650
			public int method_5(Class82 class82_0)
			{
				return this.innerArray.IndexOf(class82_0);
			}

			// Token: 0x060007DA RID: 2010 RVA: 0x00072470 File Offset: 0x00070670
			public int method_6(string string_0)
			{
				int num = 0;
				int result;
				foreach (object obj in this.innerArray)
				{
					Class82 @class = (Class82)obj;
					if (@class.Name == string_0)
					{
						result = num;
						goto IL_56;
					}
					num++;
				}
				return -1;
				IL_56:
				return result;
			}

			// Token: 0x060007DB RID: 2011 RVA: 0x00005A5B File Offset: 0x00003C5B
			public void method_7(int int_0, Class82 class82_0)
			{
				this.innerArray.Insert(int_0, class82_0);
			}

			// Token: 0x060007DC RID: 2012 RVA: 0x00005A6C File Offset: 0x00003C6C
			public void method_8(Class82 class82_0)
			{
				this.innerArray.Remove(class82_0);
			}

			// Token: 0x060007DD RID: 2013 RVA: 0x000724EC File Offset: 0x000706EC
			public void method_9(string string_0)
			{
				int index = this.method_6(string_0);
				this.System.Collections.IList.RemoveAt(index);
			}

			// Token: 0x060007DE RID: 2014 RVA: 0x00005A7C File Offset: 0x00003C7C
			public void RemoveAt(int index)
			{
				this.innerArray.RemoveAt(index);
			}

			// Token: 0x060007DF RID: 2015 RVA: 0x0007250C File Offset: 0x0007070C
			public Class82[] method_10()
			{
				return (Class82[])this.innerArray.ToArray(typeof(Class82));
			}

			// Token: 0x060007E0 RID: 2016 RVA: 0x00005A8C File Offset: 0x00003C8C
			void ICollection.CopyTo(Array array, int index)
			{
				this.method_4((Class82[])array, index);
			}

			// Token: 0x060007E1 RID: 2017 RVA: 0x00072538 File Offset: 0x00070738
			int IList.Add(object value)
			{
				return this.Add((Class82)value);
			}

			// Token: 0x060007E2 RID: 2018 RVA: 0x00072558 File Offset: 0x00070758
			bool IList.Contains(object value)
			{
				return this.method_1((Class82)value);
			}

			// Token: 0x17000150 RID: 336
			object IList.this[int index]
			{
				get
				{
					return this[index];
				}
				set
				{
					this[index] = (Class82)value;
				}
			}

			// Token: 0x060007E5 RID: 2021 RVA: 0x00072590 File Offset: 0x00070790
			int IList.IndexOf(object value)
			{
				return this.method_5((Class82)value);
			}

			// Token: 0x060007E6 RID: 2022 RVA: 0x00005AAE File Offset: 0x00003CAE
			void IList.Insert(int index, object value)
			{
				this.method_7(index, (Class82)value);
			}

			// Token: 0x060007E7 RID: 2023 RVA: 0x00005ABF File Offset: 0x00003CBF
			void IList.Remove(object value)
			{
				this.method_8((Class82)value);
			}

			// Token: 0x04000657 RID: 1623
			private ArrayList innerArray;
		}

		// Token: 0x020000BC RID: 188
		private sealed class Class84 : PropertyDescriptor
		{
			// Token: 0x060007E8 RID: 2024 RVA: 0x00005ACF File Offset: 0x00003CCF
			public Class84(Class82 item, PropertyBag bag, string name, Attribute[] attrs) : base(name, attrs)
			{
				this.bag = bag;
				this.item = item;
			}

			// Token: 0x17000151 RID: 337
			// (get) Token: 0x060007E9 RID: 2025 RVA: 0x000725B0 File Offset: 0x000707B0
			public Type ComponentType
			{
				get
				{
					return this.item.GetType();
				}
			}

			// Token: 0x17000152 RID: 338
			// (get) Token: 0x060007EA RID: 2026 RVA: 0x000725CC File Offset: 0x000707CC
			public bool IsReadOnly
			{
				get
				{
					return this.Attributes.Matches(ReadOnlyAttribute.Yes);
				}
			}

			// Token: 0x17000153 RID: 339
			// (get) Token: 0x060007EB RID: 2027 RVA: 0x000725F0 File Offset: 0x000707F0
			public Type PropertyType
			{
				get
				{
					return Type.GetType(this.item.TypeName);
				}
			}

			// Token: 0x060007EC RID: 2028 RVA: 0x00072614 File Offset: 0x00070814
			public bool CanResetValue(object component)
			{
				bool result;
				if (this.item.DefaultValue == null)
				{
					result = false;
				}
				else
				{
					result = !this.GetValue(component).Equals(this.item.DefaultValue);
				}
				return result;
			}

			// Token: 0x060007ED RID: 2029 RVA: 0x00072650 File Offset: 0x00070850
			public object GetValue(object component)
			{
				EventArgs2 eventArgs = new EventArgs2(this.item, null);
				this.bag.vmethod_0(eventArgs);
				return eventArgs.Value;
			}

			// Token: 0x060007EE RID: 2030 RVA: 0x00005AEA File Offset: 0x00003CEA
			public void ResetValue(object component)
			{
				this.SetValue(component, this.item.DefaultValue);
			}

			// Token: 0x060007EF RID: 2031 RVA: 0x00072680 File Offset: 0x00070880
			public void SetValue(object component, object value)
			{
				EventArgs2 eventArgs2_ = new EventArgs2(this.item, value);
				this.bag.vmethod_1(eventArgs2_);
			}

			// Token: 0x060007F0 RID: 2032 RVA: 0x000726A8 File Offset: 0x000708A8
			public bool ShouldSerializeValue(object component)
			{
				object value = this.GetValue(component);
				bool result;
				if (this.item.DefaultValue == null && value == null)
				{
					result = false;
				}
				else
				{
					result = !value.Equals(this.item.DefaultValue);
				}
				return result;
			}

			// Token: 0x04000658 RID: 1624
			private PropertyBag bag;

			// Token: 0x04000659 RID: 1625
			private Class82 item;
		}
	}
}
