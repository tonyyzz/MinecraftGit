using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Minecraft.Model;

namespace Minecraft.DALMySql
{
	public partial class BaseDAL
	{
		/// <summary>
		/// 分表信息插入
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <param name="tableNameCacheList">表名称缓存列表</param>
		/// <param name="keyId">主键Id</param>
		/// <param name="tableNamePrefix">表名称前缀</param>
		/// <param name="submeterLenStr">根据keyId分表间隔长度</param>
		/// <param name="createTableSqlFunc">创建表的sql func</param>
		/// <returns></returns>
		protected static bool InsertSuccessModelData<T>(T model,
			List<string> tableNameCacheList,
			int keyId,
			string tableNamePrefix,
			int submeterLen,
			Func<int, string> createTableSqlFunc) where T : class
		{
			if (AddTableSuccess(keyId, tableNameCacheList, tableNamePrefix, submeterLen, createTableSqlFunc))
			{
				using (var Conn = GetConn())
				{
					Conn.Open();
					var propKeys = model.GetAllPropKeys();
					var names = string.Join(",", propKeys.ToArray());
					var values = string.Join(",", propKeys.ToList().ConvertAll(m => "@" + m).ToArray());
					string sql = string.Format(@"insert into {0}({1}) values({2});",
						GetTableNameWithTablePrefix(keyId, tableNamePrefix, submeterLen),
						names,
						values);
					return Conn.Execute(sql, model) > 0;
				}
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 根据前缀删除表
		/// </summary>
		/// <param name="prefixName"></param>
		public static void DropTablesWithPrefix(string prefixName)
		{
			var list = GetTableNames(prefixName);
			if (list.Any())
			{
				string sql = "";
				list.ForEach(item =>
				{
					sql += $"drop table if exists {item};";
				});
				using (var Conn = GetConn())
				{
					Conn.Open();
					Conn.Execute(sql);
				}
			}
		}

		/// <summary>
		/// 分表获取单个数据
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="keyId"></param>
		/// <param name="tableNamePrefix"></param>
		/// <param name="submeterLenStr"></param>
		/// <param name="keyValue"></param>
		/// <returns></returns>
		protected static T GetSingleOrDefaultWithTablePrefix<T, V>(T model, int keyId,
			string tableNamePrefix,
			int submeterLen,
			KeyValue<V> keyValue) where T : class
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				string sql = $"select * from {GetTableNameWithTablePrefix(keyId, tableNamePrefix, submeterLen)} where {keyValue.Key}={GetTypeValueStr(keyValue.Value)} limit 1";
				return Conn.QueryFirstOrDefault<T>(sql);
			}
		}

		protected static List<T> GetListAllWithTablePrefix<T, V>(T model, int keyId,
			string tableNamePrefix,
			int submeterLen,
			KeyValue<V> keyValue) where T : class
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				string sql = $"select * from {GetTableNameWithTablePrefix(keyId, tableNamePrefix, submeterLen)} where {keyValue.Key}={GetTypeValueStr(keyValue.Value)}";
				return Conn.Query<T>(sql).ToList();
			}
		}

		protected static List<T> GetListAllWithTablePrefix<T, V,U>(T model, int keyId,
			string tableNamePrefix,
			int submeterLen,
			KeyValue<V> keyValue1,
			KeyValue<U> keyValue2
			) where T : class
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				string sql = $"select * from {GetTableNameWithTablePrefix(keyId, tableNamePrefix, submeterLen)} where {keyValue1.Key}={GetTypeValueStr(keyValue1.Value)} and {keyValue2.Key}={GetTypeValueStr(keyValue2.Value)}";
				return Conn.Query<T>(sql).ToList();
			}
		}


		/// <summary>
		/// 判断表是否存在
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		private static bool JudgeTableExists(string tableName)
		{
			string sql = $"show tables like '{tableName}'; ";
			using (var Conn = GetConn())
			{
				Conn.Open();
				return !string.IsNullOrWhiteSpace(Conn.QueryFirstOrDefault<string>(sql));
			}
		}

		private static List<string> GetTableNames(string prefixName)
		{
			List<string> list = new List<string>();
			string sql = $"show tables like '{prefixName}_%'; ";
			using (var Conn = GetConn())
			{
				Conn.Open();
				list = Conn.Query<string>(sql).ToList();
			}
			return list;
		}



		protected static string GetTableNameWithTablePrefix(int keyId, string tableNamePrefix, int submeterLen)
		{
			string tableName = $"{tableNamePrefix}_{CommonConfig.GetTablePostfix(keyId, submeterLen)}";
			return tableName;
		}

		/// <summary>
		/// 动态增加表（分表处理），如果存在，则不做处理
		/// </summary>
		/// <param name="keyId"></param>
		/// <param name="tableNameList">goods表名称内存缓存</param>
		/// <returns></returns>
		private static bool AddTableSuccess(int keyId,
			List<string> tableNameList,
			string tableNamePrefix,
			int submeterLen,
			Func<int, string> createTableSqlFunc)
		{
			string tableName = GetTableNameWithTablePrefix(keyId, tableNamePrefix, submeterLen);
			if (tableNameList.Any(m => m == tableName))
			{
				return true;
			}
			var isTableExists = JudgeTableExists(tableName);
			if (isTableExists)
			{
				tableNameList.Add(tableName);
				return true;
			}
			string sql = createTableSqlFunc(keyId);
			using (var Conn = GetConn())
			{
				Conn.Open();
				Conn.Execute(sql);
				isTableExists = JudgeTableExists(tableName);
				if (isTableExists)
				{
					tableNameList.Add(tableName);
				}
				return isTableExists;
			}
		}


	}
}
