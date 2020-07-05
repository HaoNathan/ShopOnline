using System.Security.Cryptography;
using System.Text;

namespace ShopOnlineTools
{
    public class Md5
    {
        /// <summary>
        /// MD5字符串加密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns>加密后字符串</returns>
        public string MD5Encrypt(string strText)
        {
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            byte[] targetData = md5.ComputeHash(Encoding.UTF8.GetBytes(strText));

            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++) byte2String += targetData[i].ToString("x2");

            return byte2String.ToUpper();
        }

    }
}