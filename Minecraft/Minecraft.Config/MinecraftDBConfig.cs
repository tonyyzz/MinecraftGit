using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	public class MinecraftDBConfig
	{
		public static string Minecraft_MySqlDBConnStr = GetConnStr("Minecraft_MySql");
		public static string Minecraft_MongoDBConnStr = GetConnStr("Minecraft_MongoDB");
		public static string Minecraft_MongoDBName = GetAppSettingStr("Minecraft_MongoDBName");
		public static string Minecraft_RedisConnStr = GetConnStr("Minecraft_Redis");
		public static string Minecraft_RedisDefaultKey = GetAppSettingStr("Redis.DefaultKey");

		/// <summary>
		/// 获取 ConnectionString value
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private static string GetConnStr(string str)
		{
			return ConfigurationManager.ConnectionStrings[str] != null ? ConfigurationManager.ConnectionStrings[str].ToString() : "";
		}

		/// <summary>
		/// 获取 AppSetting value
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private static string GetAppSettingStr(string str)
		{
			return ConfigurationManager.AppSettings[str] ?? "";
		}
	}
}
