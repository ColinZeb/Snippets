using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Text
{
    /// <summary>
    /// 提供大小写转换的代码
    /// </summary>
    public static class CaseConvert
    {

        // Convert the string to Pascal case.
        /// <summary>
        /// 转换字符串为帕斯卡命名
        /// </summary>
        /// <param name="theString">待处理的字符串</param>
        /// <returns></returns>
        public static string ToPascalCase(this string theString)
        {
            // If there are 0 or 1 characters, just return the string.
            if (theString == null) return theString;
            if (theString.Length < 2) return theString.ToUpper();

            // Split the string into words.
            string[] words = theString.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            var result = new StringBuilder(theString.Length);
            foreach (string word in words)
            {
                result.Append(word.Substring(0, 1).ToUpper() +
                    word.Substring(1));
            }

            return result.ToString();
        }

        // Convert the string to camel case.
        /// <summary>
        /// 转换为驼峰命名
        /// </summary>
        /// <param name="theString">待处理的字符串</param>
        /// <returns></returns>
        public static string ToCamelCase(this string theString)
        {
            // If there are 0 or 1 characters, just return the string.
            if (theString == null || theString.Length < 2)
                return theString;

            // Split the string into words.
            string[] words = theString.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            var result = new StringBuilder(theString.Length);
            result.Append(words[0].ToLower());
           
            for (int i = 1; i < words.Length; i++)
            {
              
                result.Append(words[i].Substring(0, 1).ToUpper() +
                    words[i].Substring(1));
            }

            return result.ToString();
        }

        // Capitalize the first character and add a space before
        // each capitalized letter (except the first character).
        /// <summary>
        /// 大写第一个字符，并在每个大写字母之前添加一个空格（第一个字符除外）。
        /// </summary>
        /// <param name="theString">待处理的字符串</param>
        /// <returns></returns>
        public static string ToProperCase(this string theString)
        {
            // If there are 0 or 1 characters, just return the string.
            if (theString == null) return theString;
            if (theString.Length < 2) return theString.ToUpper();


            var result = new StringBuilder(theString.Length/5+theString.Length);

            // Start with the first character.
            result.Append(theString.Substring(0, 1).ToUpper());

            // Add the remaining characters.
            const string space = " ";
            for (int i = 1; i < theString.Length; i++)
            {
                var str = char.IsUpper(theString[i]) ? space : string.Empty;
                result.Append($"{str}{theString[i]}");
            }

            return result.ToString();
        }
    }
}
