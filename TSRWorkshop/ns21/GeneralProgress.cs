using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns8;

namespace ns21
{
	// Token: 0x020000D0 RID: 208
	internal sealed partial class GeneralProgress : Form
	{
		// Token: 0x14000027 RID: 39
		// (add) Token: 0x060008A6 RID: 2214 RVA: 0x0007A234 File Offset: 0x00078434
		// (remove) Token: 0x060008A7 RID: 2215 RVA: 0x0007A26C File Offset: 0x0007846C
		private event GeneralProgress.Delegate23 Step
		{
			add
			{
				GeneralProgress.Delegate23 @delegate = this.delegate23_0;
				GeneralProgress.Delegate23 delegate2;
				do
				{
					delegate2 = @delegate;
					GeneralProgress.Delegate23 value2 = (GeneralProgress.Delegate23)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<GeneralProgress.Delegate23>(ref this.delegate23_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				GeneralProgress.Delegate23 @delegate = this.delegate23_0;
				GeneralProgress.Delegate23 delegate2;
				do
				{
					delegate2 = @delegate;
					GeneralProgress.Delegate23 value2 = (GeneralProgress.Delegate23)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<GeneralProgress.Delegate23>(ref this.delegate23_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x060008A8 RID: 2216 RVA: 0x0007A2A4 File Offset: 0x000784A4
		// (remove) Token: 0x060008A9 RID: 2217 RVA: 0x0007A2DC File Offset: 0x000784DC
		private event GeneralProgress.Delegate24 Done
		{
			add
			{
				GeneralProgress.Delegate24 @delegate = this.delegate24_0;
				GeneralProgress.Delegate24 delegate2;
				do
				{
					delegate2 = @delegate;
					GeneralProgress.Delegate24 value2 = (GeneralProgress.Delegate24)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<GeneralProgress.Delegate24>(ref this.delegate24_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				GeneralProgress.Delegate24 @delegate = this.delegate24_0;
				GeneralProgress.Delegate24 delegate2;
				do
				{
					delegate2 = @delegate;
					GeneralProgress.Delegate24 value2 = (GeneralProgress.Delegate24)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<GeneralProgress.Delegate24>(ref this.delegate24_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x0007A314 File Offset: 0x00078514
		// (set) Token: 0x060008AB RID: 2219 RVA: 0x00005F00 File Offset: 0x00004100
		public int MaxValue
		{
			get
			{
				return this.progressBar1.Maximum;
			}
			set
			{
				this.progressBar1.Maximum = value;
			}
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0007A330 File Offset: 0x00078530
		private GeneralProgress(string infoText)
		{
			this.InitializeComponent();
			base.Shown += this.GeneralProgress_Shown;
			this.Step += this.method_2;
			this.Done += this.method_1;
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x0007A384 File Offset: 0x00078584
		public static GeneralProgress.Class93 smethod_0(string string_0)
		{
			GeneralProgress generalProgress = new GeneralProgress(string_0);
			GeneralProgress.Class93 @class = GeneralProgress.Class93.smethod_0(generalProgress);
			@class.Arguments.Add(generalProgress);
			generalProgress.class93_0 = @class;
			return @class;
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00005F10 File Offset: 0x00004110
		private void GeneralProgress_Shown(object sender, EventArgs e)
		{
			this.class93_0.RunWorkerAsync(this.class93_0.Arguments.ToArray());
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00005F2F File Offset: 0x0000412F
		public void method_0()
		{
			base.ShowDialog(Class132.mainForm);
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00002B20 File Offset: 0x00000D20
		private void method_1()
		{
			base.Close();
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0007A3B8 File Offset: 0x000785B8
		private void method_2(float float_0, string string_0)
		{
			if (float_0 > (float)this.progressBar1.Maximum)
			{
				float_0 = (float)this.progressBar1.Maximum;
			}
			if (base.InvokeRequired)
			{
				GeneralProgress.Delegate23 method = new GeneralProgress.Delegate23(this.method_2);
				base.Invoke(method, new object[]
				{
					float_0,
					string_0
				});
			}
			else
			{
				this.progressBar1.Value = (int)float_0;
				this.label1.Text = string_0;
				this.Refresh();
			}
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x00005F3F File Offset: 0x0000413F
		public void method_3(float float_0, string string_0)
		{
			if (this.delegate23_0 != null)
			{
				this.delegate23_0(float_0, string_0);
			}
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00005F58 File Offset: 0x00004158
		public void method_4()
		{
			if (this.delegate24_0 != null)
			{
				this.delegate24_0();
			}
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00005F6F File Offset: 0x0000416F
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040006F1 RID: 1777
		private GeneralProgress.Delegate23 delegate23_0;

		// Token: 0x040006F2 RID: 1778
		private GeneralProgress.Delegate24 delegate24_0;

		// Token: 0x040006F3 RID: 1779
		private GeneralProgress.Class93 class93_0;

		// Token: 0x040006F4 RID: 1780
		private IContainer icontainer_0;

		// Token: 0x020000D1 RID: 209
		public sealed class Class93 : BackgroundWorker
		{
			// Token: 0x17000175 RID: 373
			// (get) Token: 0x060008B6 RID: 2230 RVA: 0x0007A594 File Offset: 0x00078794
			// (set) Token: 0x060008B7 RID: 2231 RVA: 0x00005F90 File Offset: 0x00004190
			public GeneralProgress ProgressForm { get; set; }

			// Token: 0x17000176 RID: 374
			// (get) Token: 0x060008B8 RID: 2232 RVA: 0x0007A5AC File Offset: 0x000787AC
			// (set) Token: 0x060008B9 RID: 2233 RVA: 0x00005F9B File Offset: 0x0000419B
			public List<object> Arguments { get; set; }

			// Token: 0x060008BA RID: 2234 RVA: 0x00005FA6 File Offset: 0x000041A6
			private Class93(GeneralProgress progress)
			{
				this.Arguments = new List<object>();
				this.ProgressForm = progress;
			}

			// Token: 0x060008BB RID: 2235 RVA: 0x0007A5C4 File Offset: 0x000787C4
			public static GeneralProgress.Class93 smethod_0(GeneralProgress generalProgress_1)
			{
				return new GeneralProgress.Class93(generalProgress_1);
			}

			// Token: 0x060008BC RID: 2236 RVA: 0x00005FC2 File Offset: 0x000041C2
			public void method_0()
			{
				this.ProgressForm.method_0();
			}

			// Token: 0x060008BD RID: 2237 RVA: 0x00005FD1 File Offset: 0x000041D1
			public void method_1()
			{
				this.ProgressForm.method_1();
			}

			// Token: 0x040006F7 RID: 1783
			[CompilerGenerated]
			private GeneralProgress generalProgress_0;

			// Token: 0x040006F8 RID: 1784
			[CompilerGenerated]
			private List<object> list_0;
		}

		// Token: 0x020000D2 RID: 210
		// (Invoke) Token: 0x060008BF RID: 2239
		public delegate void Delegate22();

		// Token: 0x020000D3 RID: 211
		// (Invoke) Token: 0x060008C3 RID: 2243
		private delegate void Delegate23(float stepValue, string infoText);

		// Token: 0x020000D4 RID: 212
		// (Invoke) Token: 0x060008C7 RID: 2247
		private delegate void Delegate24();
	}
}
