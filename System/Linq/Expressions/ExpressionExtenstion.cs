using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Linq.Expressions
{
    /// <summary>
    /// 针对表达式的一组扩展方法
    /// </summary>
    public static class ExpressionExtenstion
    {
        /// <summary>
        /// 获取表达式的选择属性名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Tp"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string GetPropertyName<T, Tp>(this Expression<Func<T, Tp>> expr)
        {
            var rtn = "";
            if (expr.Body is UnaryExpression)
            {
                rtn = ((MemberExpression)((UnaryExpression)expr.Body).Operand).Member.Name;
            }
            else if (expr.Body is MemberExpression)
            {
                rtn = ((MemberExpression)expr.Body).Member.Name;
            }
            else if (expr.Body is ParameterExpression)
            {
                rtn = ((ParameterExpression)expr.Body).Type.Name;
            }
            return rtn;
        }

        /// <summary>
        /// 获取表达式的选择属性名称
        /// </summary>
        /// <typeparam name="Delegate"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string GetPropertyName<Delegate>(this Expression<Delegate> expr)
        {
            var rtn = "";
            if (expr.Body is UnaryExpression)
            {
                rtn = ((MemberExpression)((UnaryExpression)expr.Body).Operand).Member.Name;
            }
            else if (expr.Body is MemberExpression)
            {
                rtn = ((MemberExpression)expr.Body).Member.Name;
            }
            else if (expr.Body is ParameterExpression)
            {
                rtn = ((ParameterExpression)expr.Body).Type.Name;
            }
            return rtn;
        }

        /// <summary>
        /// 获取返回属性信息
        /// </summary>
        /// <typeparam name="Delegate">委托类型</typeparam>
        /// <param name="expression">表达式</param>
        /// <returns>属性信息</returns>
        public static PropertyInfo GetPropertyInfo<Delegate>(this Expression<Delegate> expression)
        {
            return expression.Body.GetType().GetProperty("Member").GetValue(expression.Body, null) as PropertyInfo;
        }

        /// <summary>
        /// 获取属性名称
        /// </summary>
        /// <typeparam name="Delegate">委托类型</typeparam>
        /// <param name="expression">表达式</param>
        /// <returns>属性名称</returns>
        public static string GetRenturnName<Delegate>(this Expression<Delegate> expression)
        {
            return expression.GetPropertyInfo().Name;
        }
    }
}
