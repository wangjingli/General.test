using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace General.Common
{
    /// <summary>
    /// 文档、密码、字符串所有加密 方式 
    /// </summary>
    public class StringEncryptionHelp
    {
        /// <summary>
        /// MD5加密 建议适用于密码
        /// </summary>
        /// <param name="value">准备加密字符串</param>
        /// <returns>返回 加密过后的字符串</returns>
        public static string Md5Encrypt(string value)
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = Encoding.Default.GetBytes(value);
            byte[] bytes = md5.ComputeHash(buffer);

            string result = BitConverter.ToString(bytes);

            result = result.Replace("-", "");

            return result;
        }

       
    }
}
