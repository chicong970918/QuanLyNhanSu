using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Library.Class
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonUtil
    {
        #region ---- Encrypt & Decrypt ----

        public const string PUBLIC_KEY = "HRM";

        /// <summary>
        /// Encrypts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Encrypt(string value, string publickKey)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            byte[] bytesIn = Encoding.UTF8.GetBytes(value);

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] bytesKey = Encoding.UTF8.GetBytes(publickKey);
            Array.Resize(ref bytesKey, des.Key.Length);
            Array.Resize(ref bytesKey, des.IV.Length);

            des.Key = bytesKey;
            des.IV = bytesKey;

            MemoryStream msOut = new MemoryStream();
            ICryptoTransform desdecrypt = des.CreateEncryptor();

            CryptoStream cryptStreem = new CryptoStream(msOut, desdecrypt, CryptoStreamMode.Write);

            cryptStreem.Write(bytesIn, 0, bytesIn.Length);
            cryptStreem.FlushFinalBlock();
            byte[] bytesOut = msOut.ToArray();

            cryptStreem.Close();
            msOut.Close();

            return Convert.ToBase64String(bytesOut);
        }

        /// <summary>
        /// Decrypts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Decrypt(string value, string publickKey)
        {
            DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();

            byte[] bytesKey = Encoding.UTF8.GetBytes(publickKey);

            Array.Resize(ref bytesKey, des.Key.Length);
            Array.Resize(ref bytesKey, des.IV.Length);

            des.Key = bytesKey;
            des.IV = bytesKey;

            byte[] bytesIn = Convert.FromBase64String(value);

            MemoryStream msIn = new MemoryStream(bytesIn);
            ICryptoTransform desdecrypt = des.CreateDecryptor();

            CryptoStream cryptStreem = new CryptoStream(msIn, desdecrypt, CryptoStreamMode.Read);

            StreamReader srOut = new System.IO.StreamReader(cryptStreem, System.Text.Encoding.UTF8);
            string result = srOut.ReadToEnd();

            srOut.Close();
            cryptStreem.Close();
            msIn.Close();

            return result;
        }

        #endregion ---- Encrypt & Decrypt ----

        /// <summary>
        /// Determines whether the specified num is number.
        /// </summary>
        /// <param name="num">The num.</param>
        /// <returns>
        /// 	<c>true</c> if the specified num is number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumber(char num)
        {
            string args = "0123456789";
            if (num > 26 && args.IndexOf(num) < 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the specified num is number.
        /// </summary>
        /// <param name="num">The num.</param>
        /// <returns>
        /// 	<c>true</c> if the specified num is number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumberAndDot(char num)
        {
            string args = ".0123456789";
            if (num > 26 && args.IndexOf(num) < 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the specified value is double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is double; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDouble(string value)
        {
            double output = 0;
            return double.TryParse(value, out output);
        }
        /// <summary>
        /// Determines whether the specified value is int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is int; otherwise, <c>false</c>.
        /// </returns>
        public static int IsInt(string value)
        {
            int output = 0;
            int.TryParse(value, out output);
            return output;
        }
        /// <summary>
        /// Parses the double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static decimal Parsedecimal(string value)
        {
            decimal output = 0;
            decimal.TryParse(value, out output);
            return output;
        }
        public static double ParseDouble(string value)
        {
            double output = 0;
            double.TryParse(value, out output);
            return output;
        }   

    }
}
