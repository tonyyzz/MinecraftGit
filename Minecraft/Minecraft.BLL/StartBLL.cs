using Minecraft.CacheRedis;
using Minecraft.DALMongoDb;
using Minecraft.DALMySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL
{
	public class StartBLL : BaseBLL
	{
		/// <summary>
		/// 数据库服务器启动检查
		/// </summary>
		public static void StartDBServerCheck(out bool canStartAll)
		{
			canStartAll = true;
			//启动mysql
			var canStartMysql = StartDALMySql.StartMySqlCheck();
			if (!canStartMysql)
			{
				Console.WriteLine("mysql 数据库连接失败");
				canStartAll = false;
			}
			//启动mongoDB
			var canStartMongoDb = StartDALMongoDb.StartMongoDbCheck();
			if (!canStartMongoDb)
			{
				Console.WriteLine("MongoDb 数据库连接失败");
				canStartAll = false;
			}
			//启动redis
			var canStartRedis = StartCacheRedis.StartCacheRedisCheck();
			if (!canStartRedis)
			{
				Console.WriteLine("redis 连接失败");
				canStartAll = false;
			}
		}
	}
}
