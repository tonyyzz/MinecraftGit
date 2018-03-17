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
				return File.ReadAllText(Path.Combine("jsonConfig", "config.json")).JsonDeserialize<Rootobject>();
			}
		}



		public class Rootobject
		{
			public string EncryptKey { get; set; }
			public Connectionstring ConnectionString { get; set; }
			public Isconsolewrite IsConsoleWrite { get; set; }
			public Heartdata HeartData { get; set; }
			public Redis Redis { get; set; }
			public Mongodb MongoDB { get; set; }
			public Mysql Mysql { get; set; }
		}

		public class Connectionstring
		{
			public Debug Debug { get; set; }
			public Minecraft_LAN Minecraft_LAN { get; set; }
			public Linux_LAN Linux_LAN { get; set; }
			public Release Release { get; set; }
		}

		public class Debug
		{
			public string mySql { get; set; }
			public string mongoDB { get; set; }
			public string redis { get; set; }
		}

		public class Minecraft_LAN
		{
			public string mySql { get; set; }
			public string mongoDB { get; set; }
			public string redis { get; set; }
		}

		public class Linux_LAN
		{
			public string mySql { get; set; }
			public string mongoDB { get; set; }
			public string redis { get; set; }
		}

		public class Release
		{
			public string mySql { get; set; }
			public string mongoDB { get; set; }
			public string redis { get; set; }
		}

		public class Isconsolewrite
		{
			public bool Debug { get; set; }
			public bool Minecraft_LAN { get; set; }
			public bool Linux_LAN { get; set; }
			public bool Release { get; set; }
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
		}

		public class Sentinelpattern
		{
			public string MasterName { get; set; }
			public Sentinelhosts SentinelHosts { get; set; }
			public Colonypattern ColonyPattern { get; set; }
		}

		public class Sentinelhosts
		{
			public string Debug { get; set; }
			public string Minecraft_LAN { get; set; }
			public string Linux_LAN { get; set; }
			public string Release { get; set; }
		}

		public class Colonypattern
		{
			public Debug1 Debug { get; set; }
			public Minecraft_LAN1 Minecraft_LAN { get; set; }
			public Linux_LAN1 Linux_LAN { get; set; }
			public Release1 Release { get; set; }
		}

		public class Debug1
		{
			public string WriteServerList { get; set; }
			public string ReadServerList { get; set; }
			public int MaxWritePoolSize { get; set; }
			public int MaxReadPoolSize { get; set; }
			public bool AutoStart { get; set; }
			public int LocalCacheTime { get; set; }
			public bool RecordeLog { get; set; }
		}

		public class Minecraft_LAN1
		{
			public string WriteServerList { get; set; }
			public string ReadServerList { get; set; }
			public int MaxWritePoolSize { get; set; }
			public int MaxReadPoolSize { get; set; }
			public bool AutoStart { get; set; }
			public int LocalCacheTime { get; set; }
			public bool RecordeLog { get; set; }
		}

		public class Linux_LAN1
		{
			public string WriteServerList { get; set; }
			public string ReadServerList { get; set; }
			public int MaxWritePoolSize { get; set; }
			public int MaxReadPoolSize { get; set; }
			public bool AutoStart { get; set; }
			public int LocalCacheTime { get; set; }
			public bool RecordeLog { get; set; }
		}

		public class Release1
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