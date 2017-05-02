using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
namespace System
{
    /// <summary>
    /// 作为扩展
    /// </summary>
    public static class AsExtend
    {
        /// <summary>
        /// 把该对象转换为指定类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.NullReferenceException">obj</exception>
        public static T As<T>(this Object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("obj");
            }


            if (obj.GetType().IsClass && !typeof(T).IsValueType)
            {
                return (T)obj;
            }
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        /// <summary>
        /// Determines whether [is] [the specified object].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if [is] [the specified object]; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.NullReferenceException">obj</exception>
        public static bool Is<T>(this Object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("obj");
            }

            if (typeof(T) == typeof(string))
            {
                return true;
            }

            if (obj.GetType() == typeof(string) && typeof(T).IsValueType)
            {
                try
                {
                    obj.As<T>();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return typeof(T).IsAssignableFrom(obj.GetType());
        }

        
    }
}