using System;
using System.Reflection;
using Sims3WorkshopSDK.Interfaces;

namespace Sims3WorkshopSDK
{
	// Token: 0x02000013 RID: 19
	public abstract class WorkshopExtension : IWorkshopExtension
	{
		// Token: 0x06000074 RID: 116 RVA: 0x0000258B File Offset: 0x0000078B
		public PluginResult _init(IWorkshop workshop)
		{
			this.workshop = workshop;
			return PluginResult.OK;
		}

		// Token: 0x06000075 RID: 117
		public abstract PluginResult Initialize();

		// Token: 0x06000076 RID: 118
		public abstract PluginResult Close();

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000077 RID: 119
		public abstract string Name { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00002595 File Offset: 0x00000795
		public virtual int SortOrder
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00002599 File Offset: 0x00000799
		public string PluginVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000025AF File Offset: 0x000007AF
		public IWorkshop Workshop
		{
			get
			{
				return this.workshop;
			}
		}

		// Token: 0x040000FD RID: 253
		private IWorkshop workshop;
	}
}
