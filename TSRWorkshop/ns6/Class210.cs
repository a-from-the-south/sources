using System;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using ns11;
using ns13;
using ns15;
using ns16;
using ns19;
using ns20;
using ns3;

namespace ns6
{
	// Token: 0x020001E0 RID: 480
	internal abstract class Class210
	{
		// Token: 0x14000041 RID: 65
		// (add) Token: 0x06001369 RID: 4969 RVA: 0x000C7318 File Offset: 0x000C5518
		// (remove) Token: 0x0600136A RID: 4970 RVA: 0x000C7350 File Offset: 0x000C5550
		public event EventHandler DebuggerLaunched
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x0600136B RID: 4971 RVA: 0x000C7388 File Offset: 0x000C5588
		// (remove) Token: 0x0600136C RID: 4972 RVA: 0x000C73C0 File Offset: 0x000C55C0
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

		// Token: 0x0600136D RID: 4973
		protected abstract void vmethod_0(EventArgs9 eventArgs9_0);

		// Token: 0x0600136E RID: 4974
		protected abstract void vmethod_1(EventArgs8 eventArgs8_0);

		// Token: 0x0600136F RID: 4975
		protected abstract void vmethod_2(EventArgs10 eventArgs10_0);

		// Token: 0x06001370 RID: 4976 RVA: 0x0000A428 File Offset: 0x00008628
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public static void smethod_0(Class210 class210_1)
		{
			if (class210_1 != null)
			{
				Class210.class210_0 = class210_1;
				AppDomain.CurrentDomain.UnhandledException += class210_1.method_1;
				Application.ThreadException += class210_1.method_0;
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06001371 RID: 4977 RVA: 0x000C73F8 File Offset: 0x000C55F8
		private static Class210 Handler
		{
			get
			{
				if (Class210.class210_0 == null)
				{
					foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
					{
						if (type != null && type.BaseType != null && type.BaseType == typeof(Class210))
						{
							try
							{
								Class210.class210_0 = (Class210)Activator.CreateInstance(type, true);
								if (Class210.class210_0 != null)
								{
									break;
								}
							}
							catch
							{
							}
						}
					}
				}
				return Class210.class210_0;
			}
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x000C747C File Offset: 0x000C567C
		public static void smethod_1(Exception exception_0, object[] object_0)
		{
			if (exception_0 != null && exception_0 is SecurityException && Class210.string_2 == "1" && Class210.Handler.method_3((SecurityException)exception_0))
			{
				return;
			}
			Class207.smethod_11(exception_0, object_0);
			Class210.Handler.method_4(exception_0, false, false);
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x000C74CC File Offset: 0x000C56CC
		public static Exception smethod_2(Exception exception_0, object[] object_0)
		{
			try
			{
				if (exception_0.GetType() == typeof(Exception) && exception_0.Message == "{report}")
				{
					exception_0 = exception_0.InnerException;
				}
				else
				{
					Class207.smethod_11(exception_0, object_0);
				}
				Class210.Handler.method_4(exception_0, true, false);
			}
			catch
			{
			}
			return new SoapException(exception_0.Message, SoapException.ServerFaultCode);
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x000C7540 File Offset: 0x000C5740
		public static void smethod_3(Exception exception_0, object[] object_0)
		{
			try
			{
				if (exception_0.GetType() == typeof(Exception) && exception_0.Message == "{report}")
				{
					exception_0 = exception_0.InnerException;
				}
				else
				{
					Class207.smethod_11(exception_0, object_0);
				}
				Class210.Handler.method_4(exception_0, true, true);
			}
			catch
			{
			}
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x000C75A4 File Offset: 0x000C57A4
		private void method_0(object sender, ThreadExceptionEventArgs e)
		{
			try
			{
				Exception ex = e.Exception;
				Type type = ex.GetType();
				if (type.Name == "UnhandledException" && type.Namespace == "SmartAssembly.SmartExceptionsCore")
				{
					ex = (Exception)type.GetField("PreviousException").GetValue(ex);
				}
				if (!(ex is SecurityException) || !(Class210.string_2 == "1") || !this.method_3(ex as SecurityException))
				{
					this.method_4(ex, true, false);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x000C7644 File Offset: 0x000C5844
		private void method_1(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				if (!(e.ExceptionObject is SecurityException) || !(Class210.string_2 == "1") || !this.method_3(e.ExceptionObject as SecurityException))
				{
					if (e.ExceptionObject is Exception)
					{
						this.method_4((Exception)e.ExceptionObject, !e.IsTerminating, false);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x0000A45A File Offset: 0x0000865A
		public void method_2(IWebProxy iwebProxy_1)
		{
			this.iwebProxy_0 = iwebProxy_1;
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x0000A463 File Offset: 0x00008663
		protected virtual Guid vmethod_3()
		{
			return Guid.Empty;
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x000C76C4 File Offset: 0x000C58C4
		private bool method_3(SecurityException securityException_0)
		{
			EventArgs10 eventArgs = new EventArgs10(securityException_0);
			this.vmethod_2(eventArgs);
			if (eventArgs.ReportException)
			{
				return false;
			}
			if (!eventArgs.TryToContinue)
			{
				Application.Exit();
			}
			return true;
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x000C76F8 File Offset: 0x000C58F8
		private void method_4(Exception exception_0, bool bool_1, bool bool_2)
		{
			Type type = exception_0.GetType();
			if (type.Name == "UnhandledException" && type.Namespace == "SmartAssembly.SmartExceptionsCore")
			{
				exception_0 = (Exception)type.GetField("PreviousException").GetValue(exception_0);
			}
			bool flag = true;
			if (exception_0 != null && !(exception_0 is ThreadAbortException))
			{
				try
				{
					Class201 @class = new Class201(this.vmethod_3(), exception_0, this.iwebProxy_0);
					@class.SendingReportFeedback += this.method_7;
					@class.DebuggerLaunched += this.method_6;
					@class.FatalException += this.method_5;
					EventArgs9 eventArgs = new EventArgs9(@class, exception_0);
					if (Class183.smethod_0() != null)
					{
						eventArgs.method_1();
					}
					if (!bool_1)
					{
						eventArgs.method_0(false);
						eventArgs.TryToContinue = false;
					}
					else if (bool_2 || Class210.bool_0)
					{
						eventArgs.method_0(false);
						eventArgs.TryToContinue = true;
					}
					this.vmethod_0(eventArgs);
					flag = !eventArgs.TryToContinue;
				}
				catch (ThreadAbortException)
				{
				}
				catch (Exception fatalException)
				{
					this.vmethod_1(new EventArgs8(fatalException));
				}
				if (flag)
				{
					foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
					{
						try
						{
							string fullName = assembly.FullName;
							if (fullName.EndsWith("31bf3856ad364e35") && fullName.StartsWith("PresentationFramework,"))
							{
								object obj = assembly.GetType("System.Windows.Application").GetProperty("Current").GetGetMethod().Invoke(null, null);
								obj.GetType().GetMethod("Shutdown", new Type[0]).Invoke(obj, null);
							}
						}
						catch
						{
						}
					}
					try
					{
						Application.Exit();
					}
					catch
					{
						try
						{
							Environment.Exit(0);
						}
						catch
						{
						}
					}
				}
				return;
			}
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x0000A46A File Offset: 0x0000866A
		private void method_5(object sender, EventArgs8 e)
		{
			this.vmethod_1(e);
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x000C7904 File Offset: 0x000C5B04
		private void method_6(object sender, EventArgs e)
		{
			EventHandler eventHandler = this.eventHandler_0;
			if (eventHandler != null)
			{
				eventHandler(sender, e);
			}
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x000C7924 File Offset: 0x000C5B24
		private void method_7(object sender, EventArgs11 e)
		{
			Delegate35 @delegate = this.delegate35_0;
			if (@delegate != null)
			{
				@delegate(sender, e);
			}
		}

		// Token: 0x04000DB3 RID: 3507
		public const string string_0 = "{1fe9e38e-05cc-46a3-ae48-6cda8fb62056}";

		// Token: 0x04000DB4 RID: 3508
		public const string string_1 = "{395edd3b-130e-4160-bb08-6931086cea46}";

		// Token: 0x04000DB5 RID: 3509
		private static readonly bool bool_0 = Convert.ToBoolean("False");

		// Token: 0x04000DB6 RID: 3510
		private static readonly string string_2 = "1";

		// Token: 0x04000DB7 RID: 3511
		private static Class210 class210_0;

		// Token: 0x04000DB8 RID: 3512
		private IWebProxy iwebProxy_0;

		// Token: 0x04000DB9 RID: 3513
		private EventHandler eventHandler_0;

		// Token: 0x04000DBA RID: 3514
		private Delegate35 delegate35_0;
	}
}
