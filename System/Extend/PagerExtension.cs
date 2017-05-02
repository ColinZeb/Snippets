using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Linq
{
    /// <summary>
    /// 页面扩展
    /// </summary>
    public static class PagerExtension
    {


        /// <summary>
        /// key
        /// </summary>
        public const string pagerKey = "pager";

        /// <summary>
        /// 设置分页
        /// </summary>
        /// <typeparam name="T">模型类型</typeparam>
        /// <param name="session">会话</param>
        /// <param name="data">数据源</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Pager<T> Page<T>(this HttpSessionStateBase session, IQueryable<T> data, int size = 5, int index = 1)
        {
            var pager = new Pager<T>(data, size, index);
            session[pagerKey] = pager;
            return pager;
        }



        /// <summary>
        /// 使用数据源获得Pager实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <param name="index">The index.</param>
        /// <param name="size">The size.</param>
        /// <returns>IPager&lt;T&gt;.</returns>
        public static IPager<T> Pager<T>(this IQueryable<T> data, int? index = 1, int? size = 10)
        {
            var page = new Pager<T>(data);

            if (index.HasValue)
            {
                page.Index = index.Value;
            }

            if (size.HasValue)
            {
                page.Size = size.Value;
            }

            return page;
        }

        /// <summary>
        /// 获取页面对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <returns></returns>
        public static Pager<T> Page<T>(this HttpSessionStateBase session)
        {
            return session[pagerKey] as Pager<T>;
        }
        /// <summary>
        /// 获取当前页数据
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static IPager Page(this HttpSessionStateBase Session)
        {
            return Session[pagerKey] as IPager;
        }

    }


    #region IPager 实现
    /// <summary>
    /// 实现IPager
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Pager<T> : IPager<T>, IDisposable
    {
        /// <summary>
        /// 用数据和页面数量初始化分页文件
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="size">页面元素数量</param>
        /// <param name="index">索引</param>
        /// <exception cref="System.ArgumentNullException">data;数据无效</exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Pager(IQueryable<T> data, int size = 5, int index = 1)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data", "数据无效");
            }
            Size = size;
            Data = data;
            Index = index;
        }

        #region IPager  成员

        /// <summary>
        /// The _ size
        /// </summary>
        private int _Size;

        /// <summary>
        /// 获取或设置页面元素数量
        /// </summary>
        /// <value>The size.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Size;页面元素必须大于0</exception>
        public int Size
        {
            get
            {
                return _Size;
            }
            set
            {

                _Size = value < 1 ? 1 : value;
            }
        }



        /// <summary>
        /// The _ index
        /// </summary>
        private int _Index;
        /// <summary>
        /// 获取或设置页面索引
        /// </summary>
        /// <value>The index.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">index;页面索引无效必须大于0</exception>
        public int Index
        {
            get { return _Index; }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                _Index = value > Count ? Count : value;
            }
        }

        /// <summary>
        /// 页面数量
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                if (Data.Count() <= Size)
                {
                    return 1;
                }
                else
                {
                    return (Data.Count() - 1) / Size + 1;
                }
            }
        }

        #endregion

        #region IPager<T> 成员
        /// <summary>
        /// The _ data
        /// </summary>
        private IQueryable<T> _Data;

        /// <summary>
        /// 获取或设置数据集合
        /// </summary>
        /// <value>The data.</value>
        public IQueryable<T> Data
        {
            get
            {
                return _Data;
            }
            set { _Data = value; }
        }




        /// <summary>
        /// 当前页
        /// </summary>
        /// <value>The current.</value>
        public IQueryable<T> Current { get { return GetPage(Index); } }

        /// <summary>
        /// 获取指定页面
        /// </summary>
        /// <param name="index">页面索引</param>
        /// <returns>一页数据</returns>
        public IQueryable<T> GetPage(int index)
        {
            Index = index;
            return Data.Skip((Index - 1) * Size).Take(Size);
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> GetPage()
        {
            return GetPage(Index);
        }

        /// <summary>
        /// Gets the <see cref="IQueryable{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> this[int index]
        {
            get { return GetPage(index); }
        }

        /// <summary>
        /// Nexts the specified page number.
        /// </summary>
        /// <param name="pageNum">The page number.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> Next(int pageNum = 1)
        {
            return GetPage(Index + pageNum);
        }

        /// <summary>
        /// Previouses the specified page number.
        /// </summary>
        /// <param name="pageNum">The page number.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> Prev(int pageNum = 1)
        {
            return GetPage(Index - pageNum);
        }
        #endregion

        #region IEnumerable<T> 成员

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>IEnumerator&lt;T&gt;.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Current.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns>可用于循环访问集合的 <see cref="T:System.Collections.IEnumerator" /> 对象。</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Current.GetEnumerator();
        }

        #endregion

        /// <summary>
        /// 释放事件
        /// </summary>
        public event Action<IPager<T>, IQueryable<T>> Disposing;

        #region IDisposable 成员

        /// <summary>
        /// 执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {

            Disposing(this, Data);
        }

        #endregion
    }
    #endregion

    #region Pager接口
    /// <summary>
    /// 分页接口  指定主要元素
    /// </summary>
    
    public interface IPager : System.Collections.IEnumerable
    {
        /// <summary>
        /// 页面索引
        /// </summary>
        int Index { get; set; }
        /// <summary>
        /// 单页元素数量
        /// </summary>
        int Size { get; set; }
        /// <summary>
        /// 页面数量
        /// </summary>
        int Count { get; }

    }
    /// <summary>
    /// 泛型分页接口 指定获取页面数据的N中方式
    /// </summary>
    /// <typeparam name="T">泛型类型</typeparam>
    
    public interface IPager<T> : IPager, IEnumerable<T>
    {
        /// <summary>
        /// 获取或设置数据源
        /// </summary>
        IQueryable<T> Data { get; set; }

        /// <summary>
        /// 获取当前页
        /// </summary>
        IQueryable<T> Current { get; }

        /// <summary>
        /// 下｛index｝页
        /// </summary>
        /// <param name="index">翻页次数[可选、默认为1]</param>
        /// <returns>页面数据</returns>
        IQueryable<T> Next(int index = 1);

        /// <summary>
        /// 上｛index｝页
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IQueryable<T> Prev(int index = 1);
        /// <summary>
        /// 获取指定页面
        /// </summary>
        /// <param name="index">页面索引</param>
        /// <returns>页面数据</returns>
        IQueryable<T> GetPage(int index);
        /// <summary>
        /// 获取当前页数据
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetPage();
        /// <summary>
        /// 索引：获取指定页面数据
        /// </summary>
        /// <param name="index">页面索引</param>
        /// <returns></returns>
        IQueryable<T> this[int index] { get; }

    }

    #endregion
}