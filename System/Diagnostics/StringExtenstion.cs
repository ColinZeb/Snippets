#region 描述
//-----------------------------------------------------------------------------
// 文 件 名: StringExtension
// 作    者：段朝阳
// 计 算 机: 精视-PC 
// 创建时间：2014/3/12 20:51:33
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

namespace System.Diagnostics
{
    /// <summary>
    /// 针对string类型的一系列用于执行Dos命令的方法
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 执行Dos命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string ExecuteDos(this string cmd)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.StandardInput.WriteLine(cmd);
            process.StandardInput.WriteLine("exit");
            return process.StandardOutput.ReadToEnd();
        }

        /// <summary>
        /// Executes the dos.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="error">The error.</param>
        /// <returns>System.String.</returns>
        public static string ExecuteDos(this string cmd, out string error)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.StandardInput.WriteLine(cmd);
            process.StandardInput.WriteLine("exit");
            error = process.StandardError.ReadToEnd();
            return process.StandardOutput.ReadToEnd();
        }
    }
}