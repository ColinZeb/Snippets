using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Text.RegularExpressions
{
    public static class StringExtension
    {
        /// <summary>
        /// 是否匹配指定的正则表达式
        /// </summary>
        /// <param name="text">要匹配的文本</param>
        /// <param name="pattern">要匹配的正则表达式</param>
        /// <returns></returns>
        public static bool IsMatch(this string text, string pattern)
        {
            return Regex.IsMatch(text, pattern: pattern);
        }
    }
}
