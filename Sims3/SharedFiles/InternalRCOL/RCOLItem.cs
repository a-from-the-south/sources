using System;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000C2 RID: 194
	public class RCOLItem : IRCOLItem, ICustomTypeDescriptor
	{
		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000A0E RID: 2574 RVA: 0x00007AC7 File Offset: 0x00005CC7
		// (set) Token: 0x06000A0F RID: 2575 RVA: 0x00007ACF File Offset: 0x00005CCF
		public string TypeName { get; set; }

		// Token: 0x06000A10 RID: 2576 RVA: 0x000038FA File Offset: 0x00001AFA
		public virtual void UnSerialize(BinaryReader reader)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x000038FA File Offset: 0x00001AFA
		public virtual void Serialize(BinaryWriter writer)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x000038FA File Offset: 0x00001AFA
		public virtual int ReplaceReferences(ResKey from, ResKey to)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00007AD8 File Offset: 0x00005CD8
		public string GetClassName()
		{
			return TypeDescriptor.GetClassName(this, true);
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00007AE1 File Offset: 0x00005CE1
		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, true);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00007AEA File Offset: 0x00005CEA
		public string GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00007AF3 File Offset: 0x00005CF3
		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00007AFC File Offset: 0x00005CFC
		public EventDescriptor GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00007B05 File Offset: 0x00005D05
		public PropertyDescriptor GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00007B0E File Offset: 0x00005D0E
		public object GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00007B18 File Offset: 0x00005D18
		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00007B22 File Offset: 0x00005D22
		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00007B2B File Offset: 0x00005D2B
		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00007B2E File Offset: 0x00005D2E
		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return this.GetProperties();
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00007B36 File Offset: 0x00005D36
		public PropertyDescriptorCollection GetProperties()
		{
			return TypeDescriptor.GetProperties(base.GetType());
		}
	}
}
