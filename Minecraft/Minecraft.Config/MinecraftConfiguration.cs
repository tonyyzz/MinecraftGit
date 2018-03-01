using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	public class MinecraftConfiguration
	{
#if DEBUG //本地测试
		public static string Minecraft_MySqlDBConnStr = GetConnStr("Minecraft_MySql_Debug");
		public static string Minecraft_MongoDBConnStr = GetConnStr("Minecraft_MongoDB_Debug");
		public static string Minecraft_RedisConnStr = GetConnStr("Minecraft_Redis_Debug");
#elif YZZTEST //局域网测试
		public static string Minecraft_MySqlDBConnStr = GetConnStr("Minecraft_MySql_YzzTest");
		public static string Minecraft_MongoDBConnStr = GetConnStr("Minecraft_MongoDB_YzzTest");
		public static string Minecraft_RedisConnStr = GetConnStr("Minecraft_Redis_YzzTest");
#else //线上测试
		public static string Minecraft_MySqlDBConnStr = GetConnStr("Minecraft_MySql_Release");
		public static string Minecraft_MongoDBConnStr = GetConnStr("Minecraft_MongoDB_Release");
		public static string Minecraft_RedisConnStr = GetConnStr("Minecraft_Redis_Release");
#endif

		public static string Minecraft_MongoDBName = GetAppSettingStr("Minecraft_MongoDBName");
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
