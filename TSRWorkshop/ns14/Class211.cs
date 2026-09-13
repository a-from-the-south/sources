using System;
using System.Reflection;
using System.Security;
using System.Windows.Forms;
using ns11;
using ns15;
using ns19;
using ns3;
using ns6;

namespace ns14
{
	// Token: 0x020001EF RID: 495
	internal sealed class Class211 : Class210
	{
		// Token: 0x060013B5 RID: 5045 RVA: 0x000C8ED0 File Offset: 0x000C70D0
		protected override void vmethod_2(EventArgs10 eventArgs10_0)
		{
			using (Form3 form = new Form3(eventArgs10_0))
			{
				form.ShowDialog();
			}
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x000C8F08 File Offset: 0x000C7108
		protected override void vmethod_0(EventArgs9 eventArgs9_0)
		{
			using (Form2 form = new Form2(this, eventArgs9_0))
			{
				form.ShowDialog();
			}
		}

		// Token: 0x060013B7 RID: 5047 RVA: 0x0000A630 File Offset: 0x00008830
		protected override void vmethod_1(EventArgs8 eventArgs8_0)
		{
			MessageBox.Show(eventArgs8_0.FatalException.ToString(), string.Format("{0} Unexpected Error", "TSR Workshop"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x060013B8 RID: 5048 RVA: 0x000C8F40 File Offset: 0x000C7140
		public static bool smethod_4()
		{
			bool result;
			try
			{
				Class210.smethod_0(new Class211());
				result = true;
			}
			catch (SecurityException)
			{
				try
				{
					try
					{
						typeof(Application).InvokeMember("EnableVisualStyles", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, null);
					}
					catch (MissingMethodException)
					{
					}
					string securityMessage = string.Format("{0} cannot initialize itself because some permissions are not granted.\n\nYou probably try to launch {0} in a partial-trust situation. It's usually the case when the application is hosted on a network share.\n\nYou need to run {0} in full-trust, or at least grant it the UnmanagedCode security permission.\n\nTo grant this application the required permission, contact your system administrator, or use the Microsoft .NET Framework Configuration tool.", "TSR Workshop");
					new Form3(new EventArgs10(securityMessage, false))
					{
						ShowInTaskbar = true
					}.ShowDialog();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString(), string.Format("{0} Unexpected Error", "TSR Workshop"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				result = false;
			}
			return result;
		}
	}
}
