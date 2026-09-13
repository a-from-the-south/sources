using System;
using System.Collections;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Skybound.VisualTips;

namespace ns10
{
	// Token: 0x02000182 RID: 386
	internal sealed class Class175 : IMessageFilter
	{
		// Token: 0x060011C0 RID: 4544 RVA: 0x00002BA3 File Offset: 0x00000DA3
		private Class175()
		{
		}

		// Token: 0x060011C2 RID: 4546 RVA: 0x00009773 File Offset: 0x00007973
		public static void smethod_0()
		{
			if (Class175.class175_0 == null)
			{
				Application.AddMessageFilter(Class175.class175_0 = new Class175());
			}
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x0000978E File Offset: 0x0000798E
		public static void smethod_1()
		{
			if (Class175.class175_0 != null)
			{
				Application.RemoveMessageFilter(Class175.class175_0);
				Class175.class175_0 = null;
			}
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x000BD550 File Offset: 0x000BB750
		public static void smethod_2(int int_0, EventHandler eventHandler_1)
		{
			if (Class175.control_0 == null)
			{
				Class175.control_0 = new Control();
				Class175.control_0.CreateControl();
			}
			EventHandler eventHandler = (EventHandler)Class175.hashtable_0[int_0];
			if (eventHandler == null)
			{
				System.Timers.Timer timer = new System.Timers.Timer();
				timer.SynchronizingObject = Class175.control_0;
				timer.Interval = (double)int_0;
				timer.Elapsed += Class175.smethod_4;
				timer.Start();
				Class175.hashtable_1[int_0] = timer;
				Class175.hashtable_0[int_0] = eventHandler_1;
			}
			else
			{
				Class175.hashtable_0[int_0] = (EventHandler)Delegate.Combine(eventHandler, eventHandler_1);
			}
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x000BD604 File Offset: 0x000BB804
		public static void smethod_3(int int_0, EventHandler eventHandler_1)
		{
			EventHandler eventHandler = (EventHandler)Class175.hashtable_0[int_0];
			if (eventHandler != null)
			{
				Class175.hashtable_0[int_0] = (EventHandler)Delegate.Remove(eventHandler, eventHandler_1);
			}
			if (Class175.hashtable_0[int_0] == null)
			{
				System.Timers.Timer timer = Class175.hashtable_1[int_0] as System.Timers.Timer;
				if (timer != null)
				{
					Class175.hashtable_1[int_0] = null;
					timer.Dispose();
				}
			}
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x000BD68C File Offset: 0x000BB88C
		private static void smethod_4(object sender, ElapsedEventArgs e)
		{
			EventHandler eventHandler = (EventHandler)Class175.hashtable_0[(int)(sender as System.Timers.Timer).Interval];
			if (eventHandler != null)
			{
				eventHandler(null, e);
			}
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x000BD6C8 File Offset: 0x000BB8C8
		public static void smethod_5(int int_0, EventHandler eventHandler_1)
		{
			lock (typeof(Class175))
			{
				Class175.eventHandler_0 = eventHandler_1;
				if (Class175.timer_0 == null)
				{
					Class175.timer_0 = new System.Timers.Timer();
					Class175.timer_0.SynchronizingObject = Class175.control_0;
				}
				else
				{
					Class175.timer_0.Stop();
				}
				Class175.timer_0.Interval = (double)int_0;
				Class175.timer_0.Elapsed += Class175.smethod_6;
				Class175.timer_0.Start();
			}
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x000BD760 File Offset: 0x000BB960
		private static void smethod_6(object sender, ElapsedEventArgs e)
		{
			if (Class175.timer_0.Enabled)
			{
				Class175.timer_0.Stop();
				Class175.timer_0.Elapsed -= Class175.smethod_6;
				if (Class175.eventHandler_0 != null)
				{
					Class175.eventHandler_0(null, e);
				}
			}
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x000BD7B0 File Offset: 0x000BB9B0
		private static void smethod_7()
		{
			if (Class175.hashtable_1 != null && Class175.hashtable_1.Values != null)
			{
				foreach (object obj in Class175.hashtable_1.Values)
				{
					System.Timers.Timer timer = (System.Timers.Timer)obj;
					if (timer != null)
					{
						timer.Stop();
						timer.Start();
					}
				}
			}
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x000BD82C File Offset: 0x000BBA2C
		bool IMessageFilter.PreFilterMessage(ref Message m)
		{
			if (m.Msg == 512)
			{
				Class175.smethod_7();
				Class175.intptr_0 = m.HWnd;
				Class175.control_1 = null;
			}
			else if ((m.Msg == 675 || m.Msg == 513) && Class175.intptr_0 == m.HWnd)
			{
				Class175.intptr_0 = IntPtr.Zero;
				Class175.control_1 = null;
			}
			if (Class175.xce630b15ef968765 != null)
			{
				int msg = m.Msg;
				if (msg == 256)
				{
					KeyEventArgs keyEventArgs = new KeyEventArgs((Keys)m.WParam.ToInt32());
					Class175.xce630b15ef968765.method_11(keyEventArgs);
					return keyEventArgs.Handled;
				}
				switch (msg)
				{
				case 512:
				{
					Point point = new Point(m.LParam.ToInt32());
					Class175.xce630b15ef968765.method_8(new MouseEventArgs(Control.MouseButtons, 0, point.X, point.Y, 0));
					break;
				}
				case 513:
				case 514:
					Class175.xce630b15ef968765.method_9();
					break;
				default:
					if (msg == 675)
					{
						Class175.xce630b15ef968765.method_10(EventArgs.Empty);
					}
					break;
				}
			}
			else if (m.Msg == 512)
			{
				Class175.smethod_7();
			}
			else if (m.Msg == 256 && VisualTipProvider.xde1abe0aa61e3828.Count > 0)
			{
				return VisualTipProvider.xde1abe0aa61e3828.method_2((Keys)m.WParam.ToInt32());
			}
			return false;
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x060011CB RID: 4555 RVA: 0x000BD9B0 File Offset: 0x000BBBB0
		public static Control x2ae3d24e2dae102a
		{
			get
			{
				Control result;
				if (Class175.control_1 != null)
				{
					result = Class175.control_1;
				}
				else
				{
					result = (Class175.control_1 = Control.FromHandle(Class175.intptr_0));
				}
				return result;
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x060011CC RID: 4556 RVA: 0x000BD9E0 File Offset: 0x000BBBE0
		// (set) Token: 0x060011CD RID: 4557 RVA: 0x000097A9 File Offset: 0x000079A9
		public static VisualTipProvider xce630b15ef968765
		{
			get
			{
				return Class175.visualTipProvider_0;
			}
			set
			{
				Class175.visualTipProvider_0 = value;
			}
		}

		// Token: 0x04000C50 RID: 3152
		private static Class175 class175_0;

		// Token: 0x04000C51 RID: 3153
		private static Hashtable hashtable_0 = new Hashtable();

		// Token: 0x04000C52 RID: 3154
		private static Hashtable hashtable_1 = new Hashtable();

		// Token: 0x04000C53 RID: 3155
		private static Control control_0;

		// Token: 0x04000C54 RID: 3156
		private static System.Timers.Timer timer_0;

		// Token: 0x04000C55 RID: 3157
		private static EventHandler eventHandler_0;

		// Token: 0x04000C56 RID: 3158
		private static Control control_1;

		// Token: 0x04000C57 RID: 3159
		private static IntPtr intptr_0;

		// Token: 0x04000C58 RID: 3160
		private static VisualTipProvider visualTipProvider_0;
	}
}
