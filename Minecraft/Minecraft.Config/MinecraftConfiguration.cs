using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	public class MinecraftConfiguration1
	{
#if DEBUG //本地测试
		public static string Minecraft_MySqlDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MySql_Debug");
		public static string Minecraft_MongoDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MongoDB_Debug");
		public static string Minecraft_RedisConnStr = ConfigurationHelper.GetConnStr("Minecraft_Redis_Debug");
		public static string Minecraft_RedisToolsSectionName = "RedisTools_Debug";
		public static bool IsConsoleWrite = ConfigurationHelper.GetAppSettingStr("IsConsoleWrite_Debug") == "1" ? true : false;
		public static List<string> Minecraft_Redis_SentinelHosts = ConfigurationHelper.GetConnStr("Minecraft_Redis_SentinelHosts_Debug").Split(',').ToList();
#elif MINECRAFT_LAN //windows局域网测试
		public static string Minecraft_MySqlDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MySql_Minecraft_LAN");
		public static string Minecraft_MongoDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MongoDB_Minecraft_LAN");
		public static string Minecraft_RedisConnStr = ConfigurationHelper.GetConnStr("Minecraft_Redis_Minecraft_LAN");
		public static string Minecraft_RedisToolsSectionName = "RedisTools_Minecraft_LAN";
		public static bool IsConsoleWrite = ConfigurationHelper.GetAppSettingStr("IsConsoleWrite_Minecraft_LAN") == "1" ? true : false;
		public static List<string> Minecraft_Redis_SentinelHosts = ConfigurationHelper.GetConnStr("Minecraft_Redis_SentinelHosts_Minecraft_LAN").Split(',').ToList();
#elif LINUX_LAN //linux局域网测试
		public static string Minecraft_MySqlDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MySql_Linux_LAN");
		public static string Minecraft_MongoDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MongoDB_Linux_LAN");
		public static string Minecraft_RedisConnStr = ConfigurationHelper.GetConnStr("Minecraft_Redis_Linux_LAN");
		public static string Minecraft_RedisToolsSectionName = "RedisTools_Linux_LAN";
		public static bool IsConsoleWrite = ConfigurationHelper.GetAppSettingStr("IsConsoleWrite_Linux_LAN") == "1" ? true : false;
		public static List<string> Minecraft_Redis_SentinelHosts = ConfigurationHelper.GetConnStr("Minecraft_Redis_SentinelHosts_Linux_LAN").Split(',').ToList();
#else //（不使用，只用来做模板）
		public static string Minecraft_MySqlDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MySql_Release");
		public static string Minecraft_MongoDBConnStr = ConfigurationHelper.GetConnStr("Minecraft_MongoDB_Release");
		public static string Minecraft_RedisConnStr = ConfigurationHelper.GetConnStr("Minecraft_Redis_Release");
		public static string Minecraft_RedisToolsSectionName = "RedisTools_Release";
		public static bool IsConsoleWrite = ConfigurationHelper.GetAppSettingStr("IsConsoleWrite_Release") == "1" ? true : false;
		public static List<string> Minecraft_Redis_SentinelHosts = ConfigurationHelper.GetConnStr("Minecraft_Redis_SentinelHosts_Release").Split(',').ToList();
#endif

		public static string HeartDataReqSecretKey = ConfigurationHelper.GetAppSettingStr("HeartDataReqSecretKey");
		public static string HeartDataReqTimeFrame = ConfigurationHelper.GetAppSettingStr("HeartDataReqTimeFrame");
		public static string Minecraft_MongoDBName = ConfigurationHelper.GetAppSettingStr("Minecraft_MongoDBName");
		public static string Minecraft_RedisDefaultKey = ConfigurationHelper.GetAppSettingStr("Redis.DefaultKey");
		public static string Minecraft_Mysql_GoodsTable_SubmeterLen = ConfigurationHelper.GetAppSettingStr("Minecraft_Mysql_GoodsTable_SubmeterLen");
		public static string Minecraft_Mysql_FriendTable_SubmeterLen = ConfigurationHelper.GetAppSettingStr("Minecraft_Mysql_FriendTable_SubmeterLen");
		public static string Minecraft_Redis_SentinelPattern_MasterName = ConfigurationHelper.GetAppSettingStr("Redis_SentinelPattern_MasterName");
		public static string Minecraft_Redis_CachePattern = ConfigurationHelper.GetAppSettingStr("Redis_CachePattern");
	}
}
