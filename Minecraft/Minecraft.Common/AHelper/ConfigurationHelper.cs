using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	/// <summary>
	/// 配置文件帮助类
	/// </summary>
	public class ConfigurationHelper
	{
		/// <summary>
		/// 获取 ConnectionString value
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string GetConnStr(string str)
		{
			return ConfigurationManager.ConnectionStrings[str] != null ? ConfigurationManager.ConnectionStrings[str].ToString() : "";
		}

		/// <summary>
		/// 获取 AppSetting value
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string GetAppSettingStr(string str)
		{
			return ConfigurationManager.AppSettings[str] ?? "";
		}
	}
}
