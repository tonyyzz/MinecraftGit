using Minecraft.CacheRedis;
using Minecraft.DALMongoDb;
using Minecraft.DALMySql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		public static void StartDBServerCheck()
		{
			Console.WriteLine("正在检查数据库连接状态...");
			Console.ForegroundColor = ConsoleColor.Yellow;
			bool canStartAll = true;

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			//启动mysql
			var canStartMysql = StartDALMySql.StartMySqlCheck();
			if (!canStartMysql)
			{
				Console.WriteLine("mysql 数据库连接失败");
				canStartAll = false;
			}
			////启动mongoDB
			//var canStartMongoDb = StartDALMongoDb.StartMongoDbCheck();
			//if (!canStartMongoDb)
			//{
			//	Console.WriteLine("MongoDb 数据库连接失败");
			//	canStartAll = false;
			//}
			//启动redis
			var canStartRedis = StartCacheRedis.StartCacheRedisCheck();
			if (!canStartRedis)
			{
				Console.WriteLine("redis 连接失败");
				canStartAll = false;
			}
			Console.ResetColor();

			stopwatch.Stop();
			if (canStartAll)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("数据库连接测试：所有数据库启动连接成功！");
				Console.ResetColor();
			}
			else
			{
				Console.WriteLine($"数据库连接检查所花时间为：{stopwatch.Elapsed.TotalSeconds.ToString("0.00")} s");
				//Console.WriteLine("按任意键退出");
				while (true)
				{
					Console.ReadKey();
				}
			}
		}
	}
}
