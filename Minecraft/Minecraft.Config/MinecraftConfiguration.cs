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
		public static string Minecraft_MySqlDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MySql_Debug");
		public static string Minecraft_MongoDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MongoDB_Debug");
		public static string Minecraft_RedisConnStr = ConfigurationHelper.GetConnStr("Minecraft_Redis_Debug");
#elif MINECRAFT_LAN //局域网测试
		public static string Minecraft_MySqlDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MySql_Minecraft_LAN");
		public static string Minecraft_MongoDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MongoDB_Minecraft_LAN");
		public static string Minecraft_RedisConnStr = ConfigurationHelper.GetConnStr("Minecraft_Redis_Minecraft_LAN");
#else //线上测试
		public static string Minecraft_MySqlDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MySql_Release");
		public static string Minecraft_MongoDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MongoDB_Release");
		public static string Minecraft_RedisConnStr = ConfigurationHelper.GetConnStr("Minecraft_Redis_Release");
#endif

		public static string HeartDataReqSecretKey = ConfigurationHelper.GetAppSettingStr("HeartDataReqSecretKey");
		public static string HeartDataReqTimeFrame = ConfigurationHelper.GetAppSettingStr("HeartDataReqTimeFrame");
		public static string Minecraft_MongoDBName = ConfigurationHelper.GetAppSettingStr("Minecraft_MongoDBName");
		public static string Minecraft_RedisDefaultKey = ConfigurationHelper.GetAppSettingStr("Redis.DefaultKey");
		public static string Minecraft_Mysql_GoodsTable_SubmeterLen = ConfigurationHelper.GetAppSettingStr("Minecraft_Mysql_GoodsTable_SubmeterLen");

	}
}
