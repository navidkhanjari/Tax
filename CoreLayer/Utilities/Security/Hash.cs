using System.Security.Cryptography;
using System.Text;

namespace CoreLayer.Utilities.Security
{
    public class Hash
	{
		#region (Encode To Md5)
		public static string EncodeToMd5(string Password)
		{
			Byte[] OriginalBytes;
			Byte[] EncodedBytes;

			MD5 md5;
#pragma warning disable SYSLIB0021 // Type or member is obsolete
			md5 = new MD5CryptoServiceProvider();
#pragma warning restore SYSLIB0021 // Type or member is obsolete

			OriginalBytes = ASCIIEncoding.Default.GetBytes(Password);
			EncodedBytes = md5.ComputeHash(OriginalBytes);

			return BitConverter.ToString(EncodedBytes);
		}
		#endregion
	}
}
