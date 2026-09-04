using System;

namespace Package.Helper
{
	// Token: 0x020000E3 RID: 227
	public class LocalizedString
	{
		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000BB4 RID: 2996 RVA: 0x000087A8 File Offset: 0x000069A8
		// (set) Token: 0x06000BB5 RID: 2997 RVA: 0x000087B0 File Offset: 0x000069B0
		public string Lang { get; set; }

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x000087B9 File Offset: 0x000069B9
		// (set) Token: 0x06000BB7 RID: 2999 RVA: 0x000087C1 File Offset: 0x000069C1
		public string Text { get; set; }

		// Token: 0x06000BB8 RID: 3000 RVA: 0x000087CA File Offset: 0x000069CA
		public LocalizedString(string text)
		{
			this.Text = text;
			this.Lang = "en-US";
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x000087E4 File Offset: 0x000069E4
		public LocalizedString(string text, string lang)
		{
			this.Text = text;
			this.Lang = lang;
		}
	}
}
