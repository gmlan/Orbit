using System.Security.Cryptography;
using System.Text;

namespace Com.Qualcomm.Qswat.Core.Utility
{
    public static class EncryptHelper
    {
        public static string Md5Hex(string value, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            var x = new MD5CryptoServiceProvider();
            var bs = encoding.GetBytes(value);
            bs = x.ComputeHash(bs);
            var s = new StringBuilder();
            foreach (var b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }
    }
}
