using System;
using System.IO;
using ns3;

namespace ns11
{
	// Token: 0x020001CF RID: 463
	internal sealed class EventArgs9 : EventArgs
	{
		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x060012FD RID: 4861 RVA: 0x00009F2E File Offset: 0x0000812E
		public Exception Exception
		{
			get
			{
				return this.exception;
			}
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x060012FE RID: 4862 RVA: 0x00009F36 File Offset: 0x00008136
		public bool CanDebug
		{
			get
			{
				return this.bool_0;
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x060012FF RID: 4863 RVA: 0x00009F3E File Offset: 0x0000813E
		public bool CanSendReport
		{
			get
			{
				return this.bool_1;
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06001300 RID: 4864 RVA: 0x00009F46 File Offset: 0x00008146
		public bool ShowContinueCheckbox
		{
			get
			{
				return this.bool_2;
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06001301 RID: 4865 RVA: 0x00009F46 File Offset: 0x00008146
		[Obsolete("Use ShowContinueCheckbox instead, as this is now also false when the builder has chosen not to show the checkbox.")]
		public bool CanContinue
		{
			get
			{
				return this.bool_2;
			}
		}

		// Token: 0x06001302 RID: 4866 RVA: 0x00009F4E File Offset: 0x0000814E
		internal void method_0(bool bool_4)
		{
			this.bool_2 = bool_4;
		}

		// Token: 0x06001303 RID: 4867 RVA: 0x00009F57 File Offset: 0x00008157
		internal void method_1()
		{
			this.bool_0 = true;
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x00009F60 File Offset: 0x00008160
		internal void method_2()
		{
			this.bool_1 = false;
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06001305 RID: 4869 RVA: 0x00009F69 File Offset: 0x00008169
		// (set) Token: 0x06001306 RID: 4870 RVA: 0x00009F71 File Offset: 0x00008171
		public bool TryToContinue
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
			}
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x00009F7A File Offset: 0x0000817A
		public void method_3()
		{
			if (this.bool_0)
			{
				this.reportSender.method_22();
			}
		}

		// Token: 0x06001308 RID: 4872 RVA: 0x00009F8F File Offset: 0x0000818F
		public bool method_4(string string_0)
		{
			if (File.Exists(string_0))
			{
				File.Delete(string_0);
			}
			return this.reportSender.method_23(string_0);
		}

		// Token: 0x06001309 RID: 4873 RVA: 0x00009FAB File Offset: 0x000081AB
		public byte[] method_5()
		{
			return this.reportSender.method_12();
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x00009FB8 File Offset: 0x000081B8
		public bool method_6()
		{
			return this.bool_1 && this.reportSender.method_19();
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x00009FCF File Offset: 0x000081CF
		public void method_7(string string_0, string string_1)
		{
			this.reportSender.method_17(string_0, string_1);
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x00009FDE File Offset: 0x000081DE
		public void method_8(string string_0, string string_1)
		{
			this.reportSender.method_18(string_0, string_1);
		}

		// Token: 0x0600130D RID: 4877 RVA: 0x00009FED File Offset: 0x000081ED
		internal EventArgs9(Class201 reportSender, Exception exception)
		{
			this.reportSender = reportSender;
			this.exception = exception;
		}

		// Token: 0x04000D77 RID: 3447
		private Class201 reportSender;

		// Token: 0x04000D78 RID: 3448
		private Exception exception;

		// Token: 0x04000D79 RID: 3449
		private bool bool_0;

		// Token: 0x04000D7A RID: 3450
		private bool bool_1 = true;

		// Token: 0x04000D7B RID: 3451
		private bool bool_2 = true;

		// Token: 0x04000D7C RID: 3452
		private bool bool_3;
	}
}
