using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq
{
    /// <summary>
    /// 针对一组string类型变量的一系列扩展方法
    /// </summary>
    public static class StringArrayExtenstion
    {

        /// <summary>
        /// 字符串连接
        /// </summary>
        /// <param name="source">要串联的字符串集合</param>
        /// <param name="separator">分隔符</param>
        /// <returns>使用自定分隔符连接的字符串集合</returns>
        public static string Join(this IEnumerable<String> source, string separator)
        {
            return string.Join(separator, source);
        }
    }
}
