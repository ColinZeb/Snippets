using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// 集合的扩展
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// 根据指定表达式在集合中添加成员
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="list">数据源</param>
        /// <param name="condition">表达式，指示是否添加</param>
        /// <param name="t">要添加的成员</param>
        /// <returns>操作后的数据集合</returns>
        /// <exception cref="System.ArgumentNullException">list</exception>
        public static List<T> Add<T>(this List<T> list, bool condition, T t)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            if (condition)
            {
                list.Add(t);
            }
            return list;
        }

        /// <summary>
        /// 根据指定表达式在集合中添加成员
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="list">数据源</param>
        /// <param name="condition">表达式，指示是否添加</param>
        /// <param name="t">要添加的成员</param>
        /// <returns>操作后的数据集合</returns>
        /// <exception cref="System.ArgumentNullException">list</exception>
        public static ICollection<T> Add<T>(this ICollection<T> list, bool condition, T t)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            if (condition)
            {
                list.Add(t);
            }

            return list;
        }


        /// <summary>
        /// Fore aches the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The action.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> Foreach<T>(this IEnumerable<T> source, Action<T> action)where T:class
        {
            foreach (var item in source)
            {
                action(item);
            }
            return source;
        }


        /// <summary>
        /// 根据表达式将指定项添加到集合中
        /// </summary>
        /// <typeparam name="T">集合类型[继承泛型接口ICollection]</typeparam>
        /// <typeparam name="TPtype">集合泛型类型</typeparam>
        /// <param name="t">集合实例</param>
        /// <param name="conditional">表达式，如果为true则将p添加到该集合中，否则不进行任何操作</param>
        /// <param name="p">成员对象</param>
        /// <returns>将更新后的集合返回</returns>
        public static T Add<T, TPtype>(this T t, bool conditional, TPtype p) where T : ICollection<TPtype>
        {
            if (conditional)
            {
                t.Add(p);
            }
            return t;
        }
    }
}
