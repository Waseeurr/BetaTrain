using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test_4._0.Common
{
    public class Common
    {

        public static string GenerateMD5Hash(string str)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            //MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            byteArray = sha256.ComputeHash(byteArray);

            string hashedValue = "";
            foreach (byte b in byteArray)
            {
                hashedValue += b.ToString("x2");
            }
            return hashedValue;
        }
    }
}
