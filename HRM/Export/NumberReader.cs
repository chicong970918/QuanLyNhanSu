using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Class
{
    public class NumberReader
    {
        private static string[] arrNum = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };
        private static string[] arrUnit = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };


        /// <summary>
        /// Reads the specified money number.
        /// </summary>
        /// <param name="moneyNumber">The money number.</param>
        /// <param name="currencyUnit">The currency unit.</param>
        /// <returns></returns>
        public static string Read(decimal moneyNumber, string currencyUnit)
        {
            int count;
            int i;
            decimal num;
            string result = string.Empty;
            string tmp = string.Empty;
            int[] arrPos = new int[6];

            if (moneyNumber < 0)
            {
                return "Số tiền âm !";
            }

            if (moneyNumber == 0)
            {
                return "Không đồng !";
            }

            // Over range
            if (moneyNumber > 8999999999999999)
            {
                return string.Empty;
            }

            num = moneyNumber;

            arrPos[5] = (int)(num / 1000000000000000);
            num = num - decimal.Parse(arrPos[5].ToString()) * 1000000000000000;
            arrPos[4] = (int)(num / 1000000000000);
            num = num - decimal.Parse(arrPos[4].ToString()) * +1000000000000;
            arrPos[3] = (int)(num / 1000000000);
            num = num - decimal.Parse(arrPos[3].ToString()) * 1000000000;
            arrPos[2] = (int)(num / 1000000);
            arrPos[1] = (int)((num % 1000000) / 1000);
            arrPos[0] = (int)(num % 1000);

            if (arrPos[5] > 0)
            {
                count = 5;
            }
            else if (arrPos[4] > 0)
            {
                count = 4;
            }
            else if (arrPos[3] > 0)
            {
                count = 3;
            }
            else if (arrPos[2] > 0)
            {
                count = 2;
            }
            else if (arrPos[1] > 0)
            {
                count = 1;
            }
            else
            {
                count = 0;
            }

            for (i = count; i >= 0; i--)
            {
                tmp = Read3Digits(arrPos[i]);
                result += tmp;

                if (arrPos[i] != 0)
                {
                    result += arrUnit[i];
                }

                if (i > 0 && !string.IsNullOrEmpty(tmp))
                {
                    result += ",";
                }
            }

            if (result.Substring(result.Length - 1, 1) == ",")
            {
                result = result.Substring(0, result.Length - 1);
            }

            result = result.Trim() + " " + currencyUnit;
            return result.Substring(0, 1).ToUpper() + result.Substring(1);
        }


        /// <summary>
        /// Read 3 the digits.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private static string Read3Digits(int number)
        {
            int hundred;
            int dozen;
            int unit;
            string result = string.Empty;

            hundred = number / 100;
            dozen = (number % 100) / 10;
            unit = number % 10;

            if (hundred == 0 && dozen == 0 && unit == 0)
            {
                return string.Empty;
            }
                
            if (hundred != 0)
            {
                result += arrNum[hundred] + " trăm";

                if (dozen == 0 && unit != 0)
                {
                    result += " linh";
                }
            }

            if (dozen != 0 && dozen != 1)
            {
                result += arrNum[dozen] + " mươi";

                if (dozen == 0 && unit != 0)
                {
                    result = result + " linh";
                }
            }

            if (dozen == 1) 
            { 
                result += " mười"; 
            }

            switch (unit)
            {
                case 1:
                    if ((dozen != 0) && (dozen != 1))
                    {
                        result += " mốt";
                    }
                    else
                    {
                        result += arrNum[unit];
                    }
                    break;
                case 5:
                    if (dozen == 0)
                    {
                        result += arrNum[unit];
                    }
                    else
                    {
                        result += " lăm";
                    }
                    break;
                default:
                    if (unit != 0)
                    {
                        result += arrNum[unit];
                    }
                    break;
            }

            return result;
        }
    }
}
