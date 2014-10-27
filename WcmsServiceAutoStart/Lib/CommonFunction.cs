using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WcmsServiceAutoStart
{
	public class CommonFunction
	{
		/// <summary>
		/// 写日志
		/// </summary>
		/// <param name="message"></param>
		//public static void WriteLog(Exception ex)
        public static void WriteLog(string ex)
		{
            //string logFileDirectory = HttpContext.Current.Server.MapPath("~/AutoStartLog/");
            string logFileDirectory = System.Environment.CurrentDirectory;
			Object thisLock = new Object();
			if (!Directory.Exists(logFileDirectory))
				Directory.CreateDirectory(logFileDirectory);
			string logFilePath = logFileDirectory + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("********************");
			sb.AppendLine("[LogTime]" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine(ex);
			System.Diagnostics.Trace.WriteLine("---LZ---" + sb.ToString());
			lock (thisLock)
			{
				File.AppendAllText(logFilePath, sb.ToString());
			}
		}
	
	}
}