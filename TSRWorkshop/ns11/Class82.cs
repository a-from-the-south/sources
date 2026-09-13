using System;

namespace ns11
{
	// Token: 0x020000B7 RID: 183
	internal sealed class Class82
	{
		// Token: 0x0600078B RID: 1931 RVA: 0x00005793 File Offset: 0x00003993
		public Class82(string name, string type) : this(name, type, null, null, null)
		{
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x000057A0 File Offset: 0x000039A0
		public Class82(string name, Type type) : this(name, type.AssemblyQualifiedName, null, null, null)
		{
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x000057B2 File Offset: 0x000039B2
		public Class82(string name, string type, string category) : this(name, type, category, null, null)
		{
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x000057BF File Offset: 0x000039BF
		public Class82(string name, Type type, string category) : this(name, type.AssemblyQualifiedName, category, null, null)
		{
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x000057D1 File Offset: 0x000039D1
		public Class82(string name, string type, string category, string description) : this(name, type, category, description, null)
		{
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x000057DF File Offset: 0x000039DF
		public Class82(string name, Type type, string category, string description) : this(name, type.AssemblyQualifiedName, category, description, null)
		{
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x000057F2 File Offset: 0x000039F2
		public Class82(string name, string type, string category, string description, object defaultValue)
		{
			this.name = name;
			this.type = type;
			this.category = category;
			this.description = description;
			this.defaultValue = defaultValue;
			this.attribute_0 = null;
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x00005828 File Offset: 0x00003A28
		public Class82(string name, Type type, string category, string description, object defaultValue) : this(name, type.AssemblyQualifiedName, category, description, defaultValue)
		{
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0000583C File Offset: 0x00003A3C
		public Class82(string name, string type, string category, string description, object defaultValue, string editor, string typeConverter) : this(name, type, category, description, defaultValue)
		{
			this.editor = editor;
			this.typeConverter = typeConverter;
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0000585D File Offset: 0x00003A5D
		public Class82(string name, Type type, string category, string description, object defaultValue, string editor, string typeConverter) : this(name, type.AssemblyQualifiedName, category, description, defaultValue, editor, typeConverter)
		{
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00005875 File Offset: 0x00003A75
		public Class82(string name, string type, string category, string description, object defaultValue, Type editor, string typeConverter) : this(name, type, category, description, defaultValue, editor.AssemblyQualifiedName, typeConverter)
		{
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0000588D File Offset: 0x00003A8D
		public Class82(string name, Type type, string category, string description, object defaultValue, Type editor, string typeConverter) : this(name, type.AssemblyQualifiedName, category, description, defaultValue, editor.AssemblyQualifiedName, typeConverter)
		{
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x000058AA File Offset: 0x00003AAA
		public Class82(string name, string type, string category, string description, object defaultValue, string editor, Type typeConverter) : this(name, type, category, description, defaultValue, editor, typeConverter.AssemblyQualifiedName)
		{
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x000058C2 File Offset: 0x00003AC2
		public Class82(string name, Type type, string category, string description, object defaultValue, string editor, Type typeConverter) : this(name, type.AssemblyQualifiedName, category, description, defaultValue, editor, typeConverter.AssemblyQualifiedName)
		{
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x000058DF File Offset: 0x00003ADF
		public Class82(string name, string type, string category, string description, object defaultValue, Type editor, Type typeConverter) : this(name, type, category, description, defaultValue, editor.AssemblyQualifiedName, typeConverter.AssemblyQualifiedName)
		{
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x000058FC File Offset: 0x00003AFC
		public Class82(string name, Type type, string category, string description, object defaultValue, Type editor, Type typeConverter) : this(name, type.AssemblyQualifiedName, category, description, defaultValue, editor.AssemblyQualifiedName, typeConverter.AssemblyQualifiedName)
		{
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x00071EC0 File Offset: 0x000700C0
		// (set) Token: 0x0600079C RID: 1948 RVA: 0x0000591E File Offset: 0x00003B1E
		public Attribute[] Attributes
		{
			get
			{
				return this.attribute_0;
			}
			set
			{
				this.attribute_0 = value;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x00071ED8 File Offset: 0x000700D8
		// (set) Token: 0x0600079E RID: 1950 RVA: 0x00005929 File Offset: 0x00003B29
		public string Category
		{
			get
			{
				return this.category;
			}
			set
			{
				this.category = value;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600079F RID: 1951 RVA: 0x00071EF0 File Offset: 0x000700F0
		// (set) Token: 0x060007A0 RID: 1952 RVA: 0x00005934 File Offset: 0x00003B34
		public string ConverterTypeName
		{
			get
			{
				return this.typeConverter;
			}
			set
			{
				this.typeConverter = value;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x00071F08 File Offset: 0x00070108
		// (set) Token: 0x060007A2 RID: 1954 RVA: 0x0000593F File Offset: 0x00003B3F
		public object DefaultValue
		{
			get
			{
				return this.defaultValue;
			}
			set
			{
				this.defaultValue = value;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x00071F20 File Offset: 0x00070120
		// (set) Token: 0x060007A4 RID: 1956 RVA: 0x0000594A File Offset: 0x00003B4A
		public string Description
		{
			get
			{
				return this.description;
			}
			set
			{
				this.description = value;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060007A5 RID: 1957 RVA: 0x00071F38 File Offset: 0x00070138
		// (set) Token: 0x060007A6 RID: 1958 RVA: 0x00005955 File Offset: 0x00003B55
		public string EditorTypeName
		{
			get
			{
				return this.editor;
			}
			set
			{
				this.editor = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060007A7 RID: 1959 RVA: 0x00071F50 File Offset: 0x00070150
		// (set) Token: 0x060007A8 RID: 1960 RVA: 0x00005960 File Offset: 0x00003B60
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060007A9 RID: 1961 RVA: 0x00071F68 File Offset: 0x00070168
		// (set) Token: 0x060007AA RID: 1962 RVA: 0x0000596B File Offset: 0x00003B6B
		public string TypeName
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}

		// Token: 0x04000649 RID: 1609
		private Attribute[] attribute_0;

		// Token: 0x0400064A RID: 1610
		private string category;

		// Token: 0x0400064B RID: 1611
		private object defaultValue;

		// Token: 0x0400064C RID: 1612
		private string description;

		// Token: 0x0400064D RID: 1613
		private string editor;

		// Token: 0x0400064E RID: 1614
		private string name;

		// Token: 0x0400064F RID: 1615
		private string type;

		// Token: 0x04000650 RID: 1616
		private string typeConverter;
	}
}
