// ***********************************************************************
// Assembly         : System.Extend
// Author           : Administrator
// Created          : 04-30-2014
//
// Last Modified By : Administrator
// Last Modified On : 05-04-2014
// ***********************************************************************
// <copyright file="StringExtenstion.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region 描述
//-----------------------------------------------------------------------------
// 文 件 名: StringExtenstion
// 作    者：段朝阳
// 计 算 机: 精视-PC 
// 创建时间：2014/3/12 22:23:01
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


namespace System.Data.Common
{
    /// <summary>
    /// stringExtenstion
    /// </summary>
    public static class StringExtenstion
    {
        /// <summary>
        /// Excutes the non query.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="con">The con.</param>
        /// <returns>System.Int32.</returns>
        public static int ExcuteNonQuery(this String sql, DbConnection con)
        {
            int result;
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = sql;
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            

            return result;
        }
    }
}