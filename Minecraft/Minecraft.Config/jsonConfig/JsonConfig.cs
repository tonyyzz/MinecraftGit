using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	public class JsonConfig
	{
		public static Rootobject Value
		{
			get
			{
#if DEBUG //本地测试
				var jsonConfigFileName = ConfigurationHelper.GetAppSettingStr("jsonConfigFile_Debug");
#elif MINECRAFT_LAN //windows局域网测试
				var jsonConfigFileName = ConfigurationHelper.GetAppSettingStr("jsonConfigFile_Minecraft_LAN");
#elif LINUX_LAN //linux局域网测试
				var jsonConfigFileName = ConfigurationHelper.GetAppSettingStr("jsonConfigFile_Linux_LAN");
#else //（不使用，只用来做模板）
				var jsonConfigFileName = ConfigurationHelper.GetAppSettingStr("jsonConfigFile_Release");
#endif
				return File.ReadAllText(Path.Combine("jsonConfig", jsonConfigFileName)).JsonDeserialize<Rootobject>();
			}
		}





		public class Rootobject
		{
			public Connectionstring ConnectionString { get; set; }
			public bool IsConsoleWrite { get; set; }
			public Heartdata HeartData { get; set; }
			public Redis Redis { get; set; }
			public Mongodb MongoDB { get; set; }
			public Mysql Mysql { get; set; }
		}

		public class Connectionstring
		{
			public string mySql { get; set; }
			public string mongoDB { get; set; }
			public string redis { get; set; }
		}

		public class Heartdata
		{
			public string ReqSecretKey { get; set; }
			public int ReqTimeFrame { get; set; }
		}

		public class Redis
		{
			public string CachePrefixKey { get; set; }
			public int CachePattern { get; set; }
			public Sentinelpattern SentinelPattern { get; set; }
			public Colonypattern ColonyPattern { get; set; }
		}

		public class Sentinelpattern
		{
			public string MasterName { get; set; }
			public string SentinelHosts { get; set; }
		}

		public class Colonypattern
		{
			public string WriteServerList { get; set; }
			public string ReadServerList { get; set; }
			public int MaxWritePoolSize { get; set; }
			public int MaxReadPoolSize { get; set; }
			public bool AutoStart { get; set; }
			public int LocalCacheTime { get; set; }
			public bool RecordeLog { get; set; }
		}

		public class Mongodb
		{
			public string DBName { get; set; }
		}

		public class Mysql
		{
			public Submeterlen SubmeterLen { get; set; }
		}

		public class Submeterlen
		{
			public int GoodsTable { get; set; }
			public int FriendTable { get; set; }
		}










	}
}