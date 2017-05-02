using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System
{
    /// <summary>
    /// 时间日期的扩展
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 获取两个时间之间所经历的年份
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>String[].</returns>
        public static String[] GetYears(this DateTime start, DateTime end)
        {
            var year = end.Year+1 - start.Year;
            var strs = new String[year];

            for (int i = 0; i < year; i++)
            {
                strs[i] = (start.Year + i)+"年";
            }
            return strs;
        }

        /// <summary>
        /// Gets the years.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>String[].</returns>
        public static String[] GetYears(this int start, int end)
        {
            var year = end + 1 - start;
            var strs = new String[year];

            for (int i = 0; i < year; i++)
            {
                strs[i] = (start + i) + "年";
            }
            return strs;
        }
    }
}