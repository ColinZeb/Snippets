using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Text
{
    /// <summary>
    /// 针对string类型的一组扩展方法
    /// </summary>
    public static class StringExtend
    {

        /// <summary>
        /// 根据指定字符串组进行格式化
        /// </summary>
        /// <param name="str"></param>
        /// <param name="args">参数</param>
        /// <returns>格式化结果</returns>
        public static string FormatWith(this string str, params string[] args)
        {
            return string.Format(str, args);
        }

        /// <summary>
        /// 根据指定字符串组进行格式化
        /// </summary>
        /// <param name="str"></param>
        /// <param name="args">参数</param>
        /// <returns>格式化结果</returns>
        public static string FormatWith(this string str, params object[] args)
        {
            return string.Format(str, args);
        }


        /// <summary>
        /// 是否是无意义字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty_(this string str)
        {
            return String.IsNullOrWhiteSpace(str) || str == "-";
        }


        /// <summary>
        /// 是否非空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string str)
        {
            return !String.IsNullOrWhiteSpace(str);
        }
    }
}
