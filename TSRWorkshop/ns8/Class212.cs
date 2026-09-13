using System;
using System.Net;
using ns5;
using SmartAssembly.SmartExceptionsCore;

namespace ns8
{
	// Token: 0x020001E3 RID: 483
	internal sealed class Class212
	{
		// Token: 0x06001386 RID: 4998 RVA: 0x0000A4DA File Offset: 0x000086DA
		public void method_0(IWebProxy iwebProxy_1)
		{
			this.iwebProxy_0 = iwebProxy_1;
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x000C79DC File Offset: 0x000C5BDC
		public void method_1(Delegate36 delegate36_0)
		{
			if (this.string_1 == null)
			{
				try
				{
					UploadReportLoginService uploadReportLoginService = new UploadReportLoginService();
					if (this.iwebProxy_0 != null)
					{
						uploadReportLoginService.Proxy = this.iwebProxy_0;
					}
					this.string_1 = uploadReportLoginService.GetServerURL(this.licenseID);
					if (this.string_1.Length == 0)
					{
						throw new ApplicationException("Cannot connect to webservice");
					}
					if (this.string_1 == "ditto")
					{
						this.string_1 = Class212.string_0;
					}
				}
				catch (Exception ex)
				{
					delegate36_0("ERR 2001: " + ex.Message);
					return;
				}
			}
			delegate36_0(this.string_1.StartsWith("ERR") ? this.string_1 : "OK");
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x000C7AA4 File Offset: 0x000C5CA4
		public void method_2(byte[] byte_0, string string_2, string string_3, string string_4, Delegate36 delegate36_0)
		{
			try
			{
				ReportingService reportingService = new ReportingService(this.string_1);
				if (this.iwebProxy_0 != null)
				{
					reportingService.Proxy = this.iwebProxy_0;
				}
				delegate36_0(reportingService.UploadReport2(this.licenseID, byte_0, string_2, string_3, string_4));
			}
			catch (Exception ex)
			{
				delegate36_0("ERR 2002: " + ex.Message);
			}
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x0000A4E3 File Offset: 0x000086E3
		public Class212(string licenseID)
		{
			this.licenseID = licenseID;
		}

		// Token: 0x04000DBB RID: 3515
		internal static readonly string string_0 = "http://sawebservice.red-gate.com/";

		// Token: 0x04000DBC RID: 3516
		private string licenseID;

		// Token: 0x04000DBD RID: 3517
		private string string_1;

		// Token: 0x04000DBE RID: 3518
		private IWebProxy iwebProxy_0;
	}
}
