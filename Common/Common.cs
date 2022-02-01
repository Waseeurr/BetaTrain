using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static string UpLoad(IFormFile formFile,string url)
        {
            //新名称
            var newFileName = Guid.NewGuid().ToString();
            //获取扩展名
            var ext = Path.GetExtension(formFile.FileName);
            //将文件名和扩展名拼接
            var newName = newFileName + ext;
            //找到路径  将虚拟路径转成物理路径
           // var path = Directory.GetCurrentDirectory() + "/Images";
            // 如果目录不存在则要先创建
            if (!Directory.Exists(url))
            {
                Directory.CreateDirectory(url);
            }
            //合并路径和文件名
            var newPath = Path.Combine(url, newName);

            using (var stream = System.IO.File.Create(newPath))
            {
                formFile.CopyTo(stream);

            }
            return "/Images/"+newName;
        }
    }
}
