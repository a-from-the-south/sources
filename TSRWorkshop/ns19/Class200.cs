using System;
using System.Net;
using System.Text;
using System.Threading;
using ns16;
using ns18;
using ns20;
using ns21;
using ns3;
using ns5;
using ns8;

namespace ns19
{
	// Token: 0x020001C4 RID: 452
	internal class Class200
	{
		// Token: 0x060012BF RID: 4799 RVA: 0x00009D64 File Offset: 0x00007F64
		public void method_0(IWebProxy iwebProxy_1)
		{
			this.iwebProxy_0 = iwebProxy_1;
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x000C3EBC File Offset: 0x000C20BC
		internal bool method_1(byte[] byte_0, Class200.Class204 class204_0)
		{
			byte[] byte_;
			bool result;
			try
			{
				byte_ = Class187.smethod_2(byte_0);
				goto IL_1E;
			}
			catch (Exception)
			{
				this.method_3(Enum34.const_0, Class187.string_0);
				result = false;
			}
			return result;
			IL_1E:
			byte[] array = Class199.smethod_0(byte_, "<RSAKeyValue><Modulus>vBsYoFg7OherL8U5xCMhUGHeZSy+EaxQttYho0Lm3A2wRMeFIkel1MmdbJ+8HaG6/4V2YgWevGpOSn2oiN634oR9Wa9ghl+9490wAns4QJPXbqvEc5fhgVrl5S19AUsXdSHBwARqYZs8Q4d2RzhvUalD2oyBC5Rlqo/69+nQxw8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
			if (array == null)
			{
				this.method_3(Enum34.const_0, Class199.string_0);
				return false;
			}
			this.method_4(Enum34.const_1);
			Class212 @class = new Class212("d33103ee-dbda-e87d-6209-3df347df3551");
			if (this.iwebProxy_0 != null)
			{
				@class.method_0(this.iwebProxy_0);
			}
			Class200.Class202 class2 = new Class200.Class202(this, array, @class, class204_0);
			@class.method_1(new Delegate36(class2.method_0));
			return class2.bool_0;
		}

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x060012C1 RID: 4801 RVA: 0x000C3F5C File Offset: 0x000C215C
		// (remove) Token: 0x060012C2 RID: 4802 RVA: 0x000C3F94 File Offset: 0x000C2194
		public event Delegate35 SendingReportFeedback
		{
			add
			{
				Delegate35 @delegate = this.delegate35_0;
				Delegate35 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate35 value2 = (Delegate35)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate35>(ref this.delegate35_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate35 @delegate = this.delegate35_0;
				Delegate35 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate35 value2 = (Delegate35)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate35>(ref this.delegate35_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x000C3FCC File Offset: 0x000C21CC
		protected void method_2(Enum34 enum34_0, string string_3, string string_4)
		{
			Delegate35 @delegate = this.delegate35_0;
			if (@delegate != null)
			{
				@delegate(this, new EventArgs11(enum34_0, string_3, string_4));
			}
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x00009D6D File Offset: 0x00007F6D
		protected void method_3(Enum34 enum34_0, string string_3)
		{
			this.method_2(enum34_0, string_3, string.Empty);
		}

		// Token: 0x060012C5 RID: 4805 RVA: 0x00009D7C File Offset: 0x00007F7C
		protected void method_4(Enum34 enum34_0)
		{
			this.method_3(enum34_0, string.Empty);
		}

		// Token: 0x04000D45 RID: 3397
		protected const string string_0 = "{100fd8cd-4fe2-410e-8c33-ae1af08ef31d}";

		// Token: 0x04000D46 RID: 3398
		private const string string_1 = "{be78a0c5-c47c-4127-a428-52bdc580a02f}";

		// Token: 0x04000D47 RID: 3399
		private const string string_2 = "{bf13b64c-b3d2-4165-b3f5-7f852d4744cf}";

		// Token: 0x04000D48 RID: 3400
		private IWebProxy iwebProxy_0;

		// Token: 0x04000D49 RID: 3401
		private Delegate35 delegate35_0;

		// Token: 0x020001C5 RID: 453
		private sealed class Class202
		{
			// Token: 0x060012C7 RID: 4807 RVA: 0x00009D8A File Offset: 0x00007F8A
			public Class202(Class200 reportSender, byte[] encryptedData, Class212 services, Class200.Class204 notificationEmailSettings)
			{
				this.reportSender = reportSender;
				this.notificationEmailSettings = notificationEmailSettings;
				this.services = services;
				this.encryptedData = encryptedData;
			}

			// Token: 0x060012C8 RID: 4808 RVA: 0x000C3FF4 File Offset: 0x000C21F4
			public void method_0(string string_0)
			{
				if (string_0 == "OK")
				{
					this.reportSender.method_4(Enum34.const_2);
					byte[] bytes = Encoding.UTF8.GetBytes("{653DB4E2-8C85-4E4A-9099-267AB2090CEE}");
					byte[] array = new byte[bytes.Length + this.encryptedData.Length];
					Array.Copy(bytes, array, bytes.Length);
					Array.Copy(this.encryptedData, 0, array, bytes.Length, this.encryptedData.Length);
					Class200.Class203 @class = new Class200.Class203(this.reportSender);
					this.services.method_2(array, this.notificationEmailSettings.EmailAddress, this.notificationEmailSettings.AppFriendlyName, this.notificationEmailSettings.BuildFriendlyNumber, new Delegate36(@class.method_0));
					this.bool_0 = @class.bool_0;
					return;
				}
				if (this.reportSender.delegate35_0 != null)
				{
					this.reportSender.delegate35_0(this, new EventArgs11(Enum34.const_1, string_0));
				}
				this.bool_0 = false;
			}

			// Token: 0x04000D4A RID: 3402
			private readonly Class200 reportSender;

			// Token: 0x04000D4B RID: 3403
			private readonly byte[] encryptedData;

			// Token: 0x04000D4C RID: 3404
			private readonly Class212 services;

			// Token: 0x04000D4D RID: 3405
			private readonly Class200.Class204 notificationEmailSettings;

			// Token: 0x04000D4E RID: 3406
			public bool bool_0 = true;
		}

		// Token: 0x020001C6 RID: 454
		private sealed class Class203
		{
			// Token: 0x060012C9 RID: 4809 RVA: 0x00009DB6 File Offset: 0x00007FB6
			public Class203(Class200 reportSender)
			{
				this.reportSender = reportSender;
			}

			// Token: 0x060012CA RID: 4810 RVA: 0x00009DC5 File Offset: 0x00007FC5
			public void method_0(string string_0)
			{
				if (string_0.StartsWith("ERR"))
				{
					this.reportSender.method_3(Enum34.const_2, string_0);
					this.bool_0 = false;
					return;
				}
				this.reportSender.method_2(Enum34.const_3, string.Empty, string_0);
				this.bool_0 = true;
			}

			// Token: 0x04000D4F RID: 3407
			private readonly Class200 reportSender;

			// Token: 0x04000D50 RID: 3408
			public bool bool_0;
		}

		// Token: 0x020001C7 RID: 455
		internal sealed class Class204
		{
			// Token: 0x060012CB RID: 4811 RVA: 0x00009E02 File Offset: 0x00008002
			public Class204(string emailAddress, string appFriendlyName, string buildFriendlyNumber)
			{
				this.emailAddress = emailAddress;
				this.buildFriendlyNumber = buildFriendlyNumber;
				this.appFriendlyName = appFriendlyName;
			}

			// Token: 0x17000411 RID: 1041
			// (get) Token: 0x060012CC RID: 4812 RVA: 0x00009E1F File Offset: 0x0000801F
			public string BuildFriendlyNumber
			{
				get
				{
					return this.buildFriendlyNumber;
				}
			}

			// Token: 0x17000412 RID: 1042
			// (get) Token: 0x060012CD RID: 4813 RVA: 0x00009E27 File Offset: 0x00008027
			public string AppFriendlyName
			{
				get
				{
					return this.appFriendlyName;
				}
			}

			// Token: 0x17000413 RID: 1043
			// (get) Token: 0x060012CE RID: 4814 RVA: 0x00009E2F File Offset: 0x0000802F
			public string EmailAddress
			{
				get
				{
					return this.emailAddress;
				}
			}

			// Token: 0x04000D51 RID: 3409
			public static Class200.Class204 class204_0 = new Class200.Class204(null, null, null);

			// Token: 0x04000D52 RID: 3410
			private readonly string emailAddress;

			// Token: 0x04000D53 RID: 3411
			private readonly string appFriendlyName;

			// Token: 0x04000D54 RID: 3412
			private readonly string buildFriendlyNumber;
		}
	}
}
