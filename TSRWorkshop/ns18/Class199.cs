using System;
using System.IO;
using System.Security.Cryptography;

namespace ns18
{
	// Token: 0x020001C3 RID: 451
	internal sealed class Class199
	{
		// Token: 0x060012BD RID: 4797 RVA: 0x000C3C88 File Offset: 0x000C1E88
		public static byte[] smethod_0(byte[] byte_0, string string_1)
		{
			if (string_1.StartsWith("{"))
			{
				Class199.string_0 = "ERR 2006: This template was not properly processed by SmartAssembly";
				return null;
			}
			RijndaelManaged rijndaelManaged = null;
			RSACryptoServiceProvider rsacryptoServiceProvider = null;
			MemoryStream memoryStream = null;
			CryptoStream cryptoStream = null;
			byte[] result;
			try
			{
				rijndaelManaged = new RijndaelManaged();
				rsacryptoServiceProvider = new RSACryptoServiceProvider();
				rsacryptoServiceProvider.FromXmlString(string_1);
				rijndaelManaged.GenerateKey();
				rijndaelManaged.GenerateIV();
				byte[] array = new byte[48];
				Buffer.BlockCopy(rijndaelManaged.Key, 0, array, 0, 32);
				Buffer.BlockCopy(rijndaelManaged.IV, 0, array, 32, 16);
				memoryStream = new MemoryStream();
				try
				{
					byte[] array2 = rsacryptoServiceProvider.Encrypt(array, false);
					memoryStream.WriteByte(1);
					memoryStream.WriteByte(Convert.ToByte(array2.Length / 8));
					memoryStream.Write(array2, 0, array2.Length);
				}
				catch (CryptographicException)
				{
					try
					{
						byte[] array3 = new byte[16];
						byte[] array4 = new byte[16];
						Buffer.BlockCopy(rijndaelManaged.Key, 0, array3, 0, 16);
						Buffer.BlockCopy(rijndaelManaged.Key, 16, array4, 0, 16);
						byte[] array5 = rsacryptoServiceProvider.Encrypt(array3, false);
						byte[] array6 = rsacryptoServiceProvider.Encrypt(array4, false);
						byte[] array7 = rsacryptoServiceProvider.Encrypt(rijndaelManaged.IV, false);
						memoryStream.WriteByte(2);
						memoryStream.WriteByte(Convert.ToByte(array5.Length / 8));
						memoryStream.Write(array5, 0, array5.Length);
						memoryStream.Write(array6, 0, array6.Length);
						memoryStream.Write(array7, 0, array7.Length);
					}
					catch (CryptographicException)
					{
						Class199.string_0 = "ERR 2005: The 128-bit encryption is not available on this computer. You need to install the High Encryption Pack in order to use the reporting feature.";
						return null;
					}
				}
				cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write);
				cryptoStream.Write(byte_0, 0, byte_0.Length);
				cryptoStream.FlushFinalBlock();
				result = memoryStream.ToArray();
			}
			catch (Exception ex)
			{
				Class199.string_0 = "ERR 2004: " + ex.Message;
				result = null;
			}
			finally
			{
				if (rijndaelManaged != null)
				{
					rijndaelManaged.Clear();
				}
				if (rsacryptoServiceProvider != null)
				{
					rsacryptoServiceProvider.Clear();
				}
				if (memoryStream != null)
				{
					memoryStream.Close();
				}
				if (cryptoStream != null)
				{
					cryptoStream.Close();
				}
			}
			return result;
		}

		// Token: 0x04000D44 RID: 3396
		public static string string_0;
	}
}
