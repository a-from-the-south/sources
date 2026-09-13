using System;
using System.IO;
using System.Net;

namespace ns14
{
	// Token: 0x020000ED RID: 237
	internal sealed class Class99
	{
		// Token: 0x0600099F RID: 2463 RVA: 0x00084E54 File Offset: 0x00083054
		public static bool smethod_0(string string_0, string string_1, string string_2, string string_3)
		{
			bool result = false;
			try
			{
				FileStream fileStream = File.OpenRead(string_2);
				byte[] array = new byte[fileStream.Length + 1L];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				string text = Convert.ToBase64String(array);
				HttpWebRequest httpWebRequest = WebRequest.Create("http://test.thesimsresource.com/webservices/members/do/upload/email/" + string_1 + "/password/" + string_0) as HttpWebRequest;
				string text2 = "---asd---";
				string value = string.Concat(new object[]
				{
					Environment.NewLine,
					"--",
					text2,
					Environment.NewLine,
					"Content-Disposition: form-data; name=\"file\"; filename=\"",
					string_3,
					"\"; size=",
					text.Length,
					Environment.NewLine,
					"Content-Type: binary/octet-stream",
					Environment.NewLine,
					Environment.NewLine,
					text,
					Environment.NewLine,
					Environment.NewLine,
					"--",
					text2,
					"--",
					Environment.NewLine
				});
				httpWebRequest.ContentType = "multipart/form-data; boundary=" + text2;
				httpWebRequest.Method = "POST";
				httpWebRequest.AllowAutoRedirect = false;
				httpWebRequest.KeepAlive = false;
				httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				binaryWriter.Write(value);
				httpWebRequest.ContentLength = memoryStream.Length;
				Stream requestStream = httpWebRequest.GetRequestStream();
				memoryStream.WriteTo(requestStream);
				requestStream.Close();
				WebResponse response = httpWebRequest.GetResponse();
				StreamReader streamReader = new StreamReader(response.GetResponseStream());
				string a = streamReader.ReadToEnd();
				response.Close();
				if (a == "true")
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Could not upload file.\n\n" + ex.Message);
			}
			return result;
		}
	}
}
