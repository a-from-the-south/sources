using System;

namespace Package.Helper
{
	// Token: 0x020000E1 RID: 225
	public class UserVerification
	{
		// Token: 0x06000BAC RID: 2988 RVA: 0x00039FF8 File Offset: 0x000381F8
		public static uint GenerateUserId(uint guid, string username, string password)
		{
			if (username.Trim() == "")
			{
				return 0U;
			}
			uint num = Hashes.GetCrc32(username) & 4294967294U;
			guid = (guid << 8 & 4294967040U);
			if (guid == 0U)
			{
				return num;
			}
			return ((num | 1U) & 255U) | guid;
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x0003A040 File Offset: 0x00038240
		public static bool ValidUserId(uint id, string username, string password)
		{
			if (username.Trim() == "")
			{
				return id == 0U;
			}
			uint num = Hashes.GetCrc32(username) & 4294967294U;
			if ((id & 1U) == 0U)
			{
				return id == num;
			}
			UserVerification.GetUserGuid(id);
			id &= 254U;
			num &= 254U;
			return id == num;
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0000877E File Offset: 0x0000697E
		public static uint GetUserGuid(uint id)
		{
			return id >> 8;
		}
	}
}
