using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using ns1;

namespace ns17
{
	// Token: 0x0200017F RID: 383
	internal sealed class Class173 : IDisposable
	{
		// Token: 0x060011AC RID: 4524 RVA: 0x00009665 File Offset: 0x00007865
		public Class173(Enum30 motion, int duration)
		{
			this.motion = motion;
			this.duration = duration;
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x060011AD RID: 4525 RVA: 0x000BD270 File Offset: 0x000BB470
		// (set) Token: 0x060011AE RID: 4526 RVA: 0x0000967D File Offset: 0x0000787D
		public ISynchronizeInvoke x061479d2a6161ad7
		{
			get
			{
				return this.isynchronizeInvoke_0;
			}
			set
			{
				this.isynchronizeInvoke_0 = value;
				if (this.timer_0 != null)
				{
					this.timer_0.SynchronizingObject = value;
				}
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x060011AF RID: 4527 RVA: 0x000BD288 File Offset: 0x000BB488
		public double xd2f68ee6f47e9dfb
		{
			get
			{
				return this.double_0;
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x060011B0 RID: 4528 RVA: 0x000BD2A0 File Offset: 0x000BB4A0
		public int xf4d7b500db4ba600
		{
			get
			{
				return this.duration;
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x060011B1 RID: 4529 RVA: 0x000BD2B8 File Offset: 0x000BB4B8
		public bool xda1d1aa1eef530a1
		{
			get
			{
				return this.timer_0 == null;
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x060011B2 RID: 4530 RVA: 0x000BD2D4 File Offset: 0x000BB4D4
		public Enum30 xec53cc296529fdea
		{
			get
			{
				return this.motion;
			}
		}

		// Token: 0x060011B3 RID: 4531 RVA: 0x000BD2EC File Offset: 0x000BB4EC
		public void method_0()
		{
			if (this.timer_0 != null)
			{
				throw new InvalidOperationException("INTERNAL ERROR: The animation timer is already running.");
			}
			this.double_0 = 0.08;
			this.timer_0 = new System.Timers.Timer();
			this.timer_0.SynchronizingObject = this.x061479d2a6161ad7;
			this.timer_0.Interval = 1.0;
			this.timer_0.Elapsed += this.timer_0_Elapsed;
			this.timer_0.Start();
			this.double_1 = DateTime.Now.TimeOfDay.TotalMilliseconds;
			this.timer_0_Elapsed(this.timer_0, null);
		}

		// Token: 0x060011B4 RID: 4532 RVA: 0x0000969C File Offset: 0x0000789C
		public void method_1()
		{
			this.double_0 = 1.0 - this.xd2f68ee6f47e9dfb;
		}

		// Token: 0x060011B5 RID: 4533 RVA: 0x000096B6 File Offset: 0x000078B6
		public void method_2()
		{
			this.double_0 = 1.0;
			if (this.timer_0 != null)
			{
				this.timer_0.Stop();
				this.timer_0.Dispose();
				this.timer_0 = null;
			}
		}

		// Token: 0x060011B6 RID: 4534 RVA: 0x000BD398 File Offset: 0x000BB598
		private void timer_0_Elapsed(object sender, ElapsedEventArgs e)
		{
			if (Monitor.TryEnter(this))
			{
				try
				{
					if (this.timer_0 != null)
					{
						double num = DateTime.Now.TimeOfDay.TotalMilliseconds - this.double_1;
						double num2 = num / (double)this.xf4d7b500db4ba600;
						if (this.xec53cc296529fdea != Enum30.const_0)
						{
							double num3 = 0.0;
							if (this.xec53cc296529fdea == Enum30.const_3)
							{
								num3 = (this.xd2f68ee6f47e9dfb - 0.5) * 1.8;
							}
							else if (this.xec53cc296529fdea == Enum30.const_2)
							{
								num3 = this.xd2f68ee6f47e9dfb * 0.8;
							}
							else if (this.xec53cc296529fdea == Enum30.const_1)
							{
								num3 = -0.8 + this.xd2f68ee6f47e9dfb * 0.8;
							}
							double num4 = Math.Cos(num3 * 3.141592653589793);
							num2 += num2 * num4;
						}
						if (num2 < 0.01)
						{
							num2 = 0.01;
						}
						this.double_0 += num2;
						if (this.xd2f68ee6f47e9dfb >= 1.0)
						{
							this.method_2();
						}
						else
						{
							this.double_1 = DateTime.Now.TimeOfDay.TotalMilliseconds;
						}
						this.vmethod_0(e);
					}
				}
				finally
				{
					Monitor.Exit(this);
				}
			}
		}

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x060011B7 RID: 4535 RVA: 0x000096EE File Offset: 0x000078EE
		// (remove) Token: 0x060011B8 RID: 4536 RVA: 0x00009709 File Offset: 0x00007909
		public event EventHandler xf61701b848da9540
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.eventHandler_0 = (EventHandler)Delegate.Combine(this.eventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.eventHandler_0 = (EventHandler)Delegate.Remove(this.eventHandler_0, value);
			}
		}

		// Token: 0x060011B9 RID: 4537 RVA: 0x00009724 File Offset: 0x00007924
		protected void vmethod_0(EventArgs eventArgs_0)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, eventArgs_0);
			}
		}

		// Token: 0x060011BA RID: 4538 RVA: 0x0000973D File Offset: 0x0000793D
		public void Dispose()
		{
			if (this.timer_0 != null)
			{
				this.timer_0.Dispose();
				this.timer_0 = null;
			}
		}

		// Token: 0x04000C42 RID: 3138
		private System.Timers.Timer timer_0;

		// Token: 0x04000C43 RID: 3139
		private ISynchronizeInvoke isynchronizeInvoke_0;

		// Token: 0x04000C44 RID: 3140
		private double double_0;

		// Token: 0x04000C45 RID: 3141
		private int duration;

		// Token: 0x04000C46 RID: 3142
		private Enum30 motion;

		// Token: 0x04000C47 RID: 3143
		private double double_1;

		// Token: 0x04000C48 RID: 3144
		private EventHandler eventHandler_0;
	}
}
