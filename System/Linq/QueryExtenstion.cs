#region 描述
//-----------------------------------------------------------------------------
// 文 件 名: IQueryExtenstion
// 作    者：段朝阳
// 计 算 机: 精视-PC 
// 创建时间：2014/3/12 20:27:30
// 描    述：
// 版    本：
//-----------------------------------------------------------------------------
// 历史更新纪录
//-----------------------------------------------------------------------------
// 版    本：_._        修改时间： [yyyy-mm-dd]        修改人： [Ower]         
// 修改内容：-
//-----------------------------------------------------------------------------
// Copyright (C) 20013-2014 Crysier.Inc
//-----------------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Linq
{
    /// <summary>
    /// 针对IQueryable&lt;T&gt;接口的一系列扩展方法
    /// </summary>
    public static class QueryExtenstion
    {
        /// <summary>
        /// 基于谓词筛选值序列。将在谓词函数的逻辑中使用每个元素的索引。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">用于测试每个元素是否满足条件的函数。</param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<T> Where<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;

        }

        /// <summary>
        /// 基于谓词筛选值序列。将在谓词函数的逻辑中使用每个元素的索引。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">用于测试每个元素是否满足条件的函数。</param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<T> Where<T>(this IQueryable<T> source, Expression<Func<T, int, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }


        /// <summary>
        /// 基于谓词筛选值序列。将在谓词函数的逻辑中使用每个元素的索引。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">用于测试每个元素是否满足条件的函数。</param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// 基于谓词筛选值序列。将在谓词函数的逻辑中使用每个元素的索引。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">用于测试每个元素是否满足条件的函数。</param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, int, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// 是否在指定范围内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="lowerBound">小值</param>
        /// <param name="upperBound">大值</param>
        /// <param name="includeLowerBound">是否包括最小值 默认不包括</param>
        /// <param name="includeUpperBound">是否包括最大值 默认不包括</param>
        /// <returns></returns>
        public static bool IsBetween<T>(this T t, T lowerBound, T upperBound,
    bool includeLowerBound = false, bool includeUpperBound = false)
        where T : IComparable<T>
        {
            if (t == null) throw new ArgumentNullException("t");

            var lowerCompareResult = t.CompareTo(lowerBound);
            var upperCompareResult = t.CompareTo(upperBound);

            return (includeLowerBound && lowerCompareResult == 0) ||
                (includeUpperBound && upperCompareResult == 0) ||
                (lowerCompareResult > 0 && upperCompareResult < 0);
        }

        /// <summary>
        /// 指示该值是否在指定范围之间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <param name="comparer"></param>
        /// <param name="includeLowerBound"></param>
        /// <param name="includeUpperBound"></param>
        /// <returns></returns>
        public static bool IsBetween<T>(this T t, T lowerBound, T upperBound, IComparer<T> comparer,
    bool includeLowerBound = false, bool includeUpperBound = false)
        {
            if (comparer == null) throw new ArgumentNullException("comparer");

            var lowerCompareResult = comparer.Compare(t, lowerBound);
            var upperCompareResult = comparer.Compare(t, upperBound);

            return (includeLowerBound && lowerCompareResult == 0) ||
                (includeUpperBound && upperCompareResult == 0) ||
                (lowerCompareResult > 0 && upperCompareResult < 0);
        }

        /// <summary>
        /// 是否在集合中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="c">数据</param>
        /// <returns></returns>
        public static bool In<T>(this T t, params T[] c)
        {
            return c.Any(i => i.Equals(t));
        }

        /// <summary>
        /// 是否在集合中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="c">集合</param>
        /// <returns>如果存在相同值则返回true</returns>
        public static bool In<T>(this T t, IEnumerable<T> c)
        {
            return c.Any(i => i.Equals(t));
        }

    }
}