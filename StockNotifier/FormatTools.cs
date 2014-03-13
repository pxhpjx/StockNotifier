using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Reflection;

namespace StockNotifier
{
    /// <summary>
    /// 数据格式转化工具
    /// </summary>
    public static class FormatTools
    {
        #region 数据格式转换

        /// <summary>
        /// 转化任意数据为Int（无效返回0）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ParseInt(object obj)
        {
            int Result;
            if (obj != null && int.TryParse(obj.ToString(), out Result))
                return Result;
            else
                return 0;
        }

        /// <summary>
        /// 转化任意数据为Int?（无效返回null）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ParseNInt(object obj)
        {
            int? Result = null;
            int i;
            if (obj != null && int.TryParse(obj.ToString(), out i))
                Result = i;
            return Result;
        }

        /// <summary>
        /// 转化任意数据为double（无效返回0）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ParseDouble(object obj)
        {
            double Result;
            if (obj != null && double.TryParse(obj.ToString(), out Result))
                return Result;
            else
                return 0;
        }

        /// <summary>
        /// 转化任意数据为double?（无效返回null）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ParseNDouble(object obj)
        {
            double? Result = null;
            double d;
            if (obj != null && double.TryParse(obj.ToString(), out d))
                Result = d;
            return Result;
        }

        /// <summary>
        /// 转化任意数据为指定小数位数的double?（无效返回null）
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="i">小数位数</param>
        /// <returns></returns>
        public static double? ParseNDouble(object obj, int i)
        {
            double? Result = null;
            double d;
            if (obj != null && double.TryParse(obj.ToString(), out d))
                Result = d;
            if (Result != null)
                while (i > 0)
                {
                    Result /= 10;
                    i--;
                }
            return Result;
        }


        /// <summary>
        /// 转化任意数据为long（无效返回0）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ParseLong(object obj)
        {
            long Result;
            if (obj != null && long.TryParse(obj.ToString(), out Result))
                return Result;
            else
                return 0;
        }

        /// <summary>
        /// 转化任意数据为byte（无效返回0）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte ParseByte(object obj)
        {
            byte Result;
            if (obj != null && byte.TryParse(obj.ToString(), out Result))
                return Result;
            else
                return 0;
        }

        /// <summary>
        /// 转化任意数据为byte?（无效返回null）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte? ParseNByte(object obj)
        {
            byte? Result = null;
            byte b;
            if (obj != null && byte.TryParse(obj.ToString(), out b))
                Result = b;
            return Result;
        }

        /// <summary>
        /// 转化任意数据为DateTime（无效返回new DateTime()）
        /// 特别的，可以识别YYYYMMDD格式的8位数字并进行转化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ParseDate(object obj)
        {
            DateTime Result;
            if (obj != null && DateTime.TryParse(obj.ToString(), out Result))
                return Result;
            if (obj != null && obj.ToString().Length == 8 && ParseInt(obj) > 0)
                return new DateTime(ParseInt(obj.ToString().Substring(0, 4)), ParseInt(obj.ToString().Substring(4, 2)), ParseInt(obj.ToString().Substring(6, 2)));
            return new DateTime();
        }

        /// <summary>
        /// 转化任意数据为DateTime（无效返回null）
        /// 特别的，可以识别YYYYMMDD格式的8位数字并进行转化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ParseNDate(object obj)
        {
            DateTime Result;
            if (obj != null && DateTime.TryParse(obj.ToString(), out Result))
                return Result;
            if (obj != null && obj.ToString().Length == 8 && ParseInt(obj) > 0)
                return new DateTime(ParseInt(obj.ToString().Substring(0, 4)), ParseInt(obj.ToString().Substring(4, 2)), ParseInt(obj.ToString().Substring(6, 2)));
            return null;
        }

        /// <summary>
        /// 转化任意数据为string（无效返回null）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ParseString(object obj)
        {
            return obj == null ? null : obj.ToString();
        }

        /// <summary>
        /// 转化任意数据为string（无效返回""）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ParseStringE(object obj)
        {
            return obj == null ? "" : obj.ToString();
        }

        /// <summary>
        /// 转化日期为string（无效或new则返回""）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Date2String(object obj)
        {
            DateTime d = new DateTime();
            try
            {
                d = (DateTime)obj;
            }
            catch { }
            return d == new DateTime() ? "" : d.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 将日期做Oracle数据库可null处理，若无效或new则返回""
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object Date2Oracle(object obj)
        {
            DateTime d = new DateTime();
            try
            {
                d = (DateTime)obj;
            }
            catch { }
            return d == new DateTime() ? (object)"" : obj;
        }

        /// <summary>
        /// 转化任意数据为decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ParseDecimal(object obj)
        {
            decimal Result;
            if (obj != null && decimal.TryParse(obj.ToString(), out Result))
                return Result;
            else
                return 0;
        }

        /// <summary>
        /// 转化任意数据为bool（特例：1/0转化为true/false）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ParseBool(object obj)
        {
            bool Result = false;
            if (obj != null)
            {
                if (obj.ToString() == "0")
                    return false;
                if (obj.ToString() == "1")
                    return true;
                bool.TryParse(obj.ToString(), out Result);
            }
            return Result;
        }

        #endregion

        #region 字符串处理

        /// <summary>
        /// 遮蔽字符串的后半段
        /// </summary>
        /// <param name="str"></param>
        /// <param name="IsEmail">是否邮箱。若是，不遮蔽@之后的内容。</param>
        /// <returns></returns>
        public static string StringMask(string str, bool IsEmail = false)
        {
            if (string.IsNullOrWhiteSpace(str))
                return "";
            else
            {
                string tail = "";
                if (IsEmail && str.IndexOf('@') > 0)
                {
                    tail = str.Substring(str.IndexOf('@'));
                    str = str.Substring(0, str.IndexOf('@'));
                }
                int L = str.Length;
                int l = L / 2;
                str = str.Substring(0, l);
                while (str.Length < L)
                    str += "*";
                return str + tail;
            }
        }

        public static string[] ReadColumns(string Source, int Cols)
        {
            string[] Result = { "", "" };
            int i = 0, Cur = 0;
            Regex rx = new Regex("^[\u4E00-\u9FA5]+$");
            while (Cur < Cols)
            {
                if (rx.IsMatch(Source[i].ToString()))
                    Cur += 2;
                else
                    Cur++;
                Result[0] += Source[i];
                i++;
            }
            Result[1] = Source.Substring(Result[0].Length);
            Result[0] = Result[0].Trim();
            return Result;
        }

        #endregion

        #region 拼音

        /// <summary> 
        /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 
        /// </summary> 
        /// <param name="cnChar">单个汉字</param> 
        /// <returns>单个大写字母</returns> 
        public static string GetCharSpellCode(string cnChar)
        {
            if (cnChar == "选")
                return "X";

            if (cnChar == "鑫")
                return "X";

            long iCnChar;

            byte[] cnCharByte = System.Text.Encoding.GetEncoding("gb2312").GetBytes(cnChar);

            if (cnCharByte.Length == 1)
            {
                if (cnCharByte[0] >= 'a' && cnCharByte[0] <= 'z')
                {
                    return cnChar.ToUpper();
                }
                else
                {
                    return cnChar;
                }
            }
            else
            {
                int i1 = (short)(cnCharByte[0]);
                int i2 = (short)(cnCharByte[1]);
                iCnChar = i1 * 256 + i2;
            }

            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }
            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else
            {
                return (cnChar);
            }
        }

        /// <summary> 
        /// 在指定的字符串列表CnStr中检索符合拼音索引字符串 
        /// </summary> 
        /// <param name="input">汉字字符串</param> 
        /// <returns>相对应的汉语拼音首字母串</returns> 
        public static string GetSpellCode(string CnStr)
        {
            string strTemp = "";
            int iLen = CnStr.Length;
            int i = 0;

            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += GetCharSpellCode(CnStr.Substring(i, 1));
            }
            return strTemp;
        }

        #endregion

        /// <summary>
        /// 将两个List中的数据合并到一个新的List中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List1"></param>
        /// <param name="List2"></param>
        /// <returns></returns>
        public static List<T> ListCombine<T>(List<T> List1, List<T> List2)
        {
            List<T> Result = new List<T>();
            if (List1 != null && List1.Count > 0)
                foreach (T entity in List1)
                    Result.Add(entity);
            if (List2 != null && List2.Count > 0)
                foreach (T entity in List2)
                    Result.Add(entity);
            return Result;
        }

        /// <summary>
        /// 获取指定Url返回的数据流
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string GetHttpResponseStream(string Url)
        {
            string Result = "";
            try
            {
                WebRequest WebReq = WebRequest.Create(Url);
                WebResponse WebRes = WebReq.GetResponse();
                Stream resStream = WebRes.GetResponseStream();
                StreamReader SR = new StreamReader(resStream, Encoding.UTF8);
                StringBuilder SB = new StringBuilder();
                while ((Result = SR.ReadLine()) != null)
                {
                    SB.Append(Result);
                }
                Result = SB.ToString();
                WebRes.Close();
            }
            catch { }
            return Result;
        }

        /// <summary>
        /// 简单复制类的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T SampleCopy<T>(T input) where T : class,new()
        {
            T Result = null;
            if (input != null)
            {
                try
                {
                    Result = new T();
                    Type type = typeof(T);
                    PropertyInfo[] Props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo p in Props)
                    {
                        object ElementValue = p.GetValue(input, null);
                        p.SetValue(Result, ElementValue, null);
                    }
                }
                catch { }
            }
            return Result;
        }
    }
}
