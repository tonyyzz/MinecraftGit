using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Minecraft.Config;
using System.Reflection;

namespace Minecraft.DALMySql
{
	public partial class BaseDAL
	{
		private static string _connStr
		{
			get
			{
				//INIBase ib = new INIBase("config.ini");
				//string ip = ib.IniReadValue("sql", "ip");
				//string port = ib.IniReadValue("sql", "port");
				//string psw = ib.IniReadValue("sql", "psw");
				//var connStr = string.Format(@"server={0};user={1};database={2};port={3};password={4};Charset=utf8;",
				//	ip, "root", "gostop", port, psw);
				return MinecraftConfiguration.Minecraft_MySqlDBConnStr;
			}
		}
		private static IDbConnection _conn = new MySqlConnection(_connStr);

		///// <summary>
		///// 数据库连接对象
		///// </summary>
		protected static IDbConnection Conn { get { return _conn; } }

		/// <summary>
		/// 获取数据库连接对象实例
		/// </summary>
		/// <param name="sqlType">数据库类型，默认mysql</param>
		/// <returns></returns>
		protected static IDbConnection GetConn(int sqlType = 1)
		{
			IDbConnection conn = null;
			switch (sqlType)
			{
				case 1: //mysql数据库
					{
						conn = new MySqlConnection(_connStr);
					}
					break;
				//case 2: //sqlserver数据库
				//	{
				//	}
				//	break;
				default: break;
			}
			return conn;
		}

		/// <summary>
		/// 初始化指定表
		/// </summary>
		/// <returns></returns>
		public static bool TruncateTable<T>(T model) where T : class, new()
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				string sql = string.Format("truncate table {0};", GetTableNameByModelName(model));
				return Conn.Execute(sql) > 0;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="tableName"></param>
		/// <param name="keyValue"></param>
		/// <returns></returns>
		public static T GetSingleOrDefault<T>(T model, (string key, int value) keyValue) where T : class
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				string sql = $"select * from {GetTableNameByModelName(model)} where {keyValue.key}={keyValue.value} limit 1";
				return Conn.QueryFirstOrDefault<T>(sql);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <returns></returns>
		private static string GetTableNameByModelName<T>(T model) where T : class
		{
			return typeof(T).Name.Substring(0, typeof(T).Name.LastIndexOf("Model")).ToLower();
		}

		/// <summary>
		/// 统一插入方法（使用注意：model类名必须以‘Model’结尾，并且model属性名称和个数必须与数据库表字段名称和个数一致。如果不一致，请使用其中的一个重载方法 T^T）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <returns>自增主键Id</returns>
		public static int Insert<T>(T model) where T : class
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				var propKeys = model.GetAllPropKeys();
				var names = string.Join(",", propKeys.ToArray());
				var values = string.Join(",", propKeys.ToList().ConvertAll(m => "@" + m).ToArray());
				string sql = string.Format(@"insert into {0}({1}) values({2});select @@IDENTITY;",
					GetTableNameByModelName(model), names, values);
				var task = Conn.ExecuteScalarAsync(sql, model);
				return Convert.ToInt32(task.Result);
			}
		}
		/// <summary>
		/// 统一插入方法，只判断是否插入成功（使用注意：model类名必须以‘Model’结尾，并且model属性名称和个数必须与数据库表字段名称和个数一致。如果不一致，请使用其中的一个重载方法 T^T）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <returns>自增主键Id</returns>
		public static bool InsertSuccess<T>(T model) where T : class
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				var propKeys = model.GetAllPropKeys();
				var names = string.Join(",", propKeys.ToArray());
				var values = string.Join(",", propKeys.ToList().ConvertAll(m => "@" + m).ToArray());
				string sql = string.Format(@"insert into {0}({1}) values({2});",
					GetTableNameByModelName(model), names, values);
				return Conn.Execute(sql, model) > 0;
			}
		}
		/// <summary>
		/// 统一插入方法（使用注意：model类名必须以‘Model’结尾，fieldStrs为指明要插入的表字段字符串集合，字段集合可以包含所有，也可以是一部分）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <param name="fieldStrs">要插入的字段字符串集合，以半角逗号‘,’分割</param>
		/// <returns>自增主键Id</returns>
		public static int Insert<T>(T model, string fieldStrs) where T : class
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				string sql = string.Format(@"insert into {0}({1}) values ({2});select @@IDENTITY;",
				GetTableNameByModelName(model),
				fieldStrs,
				string.Join(",", fieldStrs.Split(',').ToList().ConvertAll(m => "@" + m.Trim()).ToArray()));
				var task = Conn.ExecuteScalarAsync(sql, model);
				return Convert.ToInt32(task.Result);
			}
		}

		/// <summary>
		/// 统一插入方法，只判断是否插入成功（使用注意：model类名必须以‘Model’结尾，fieldStrs为指明要插入的表字段字符串集合，字段集合可以包含所有，也可以是一部分）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <param name="fieldStrs">要插入的字段字符串集合，以半角逗号‘,’分割</param>
		/// <returns>自增主键Id</returns>
		public static bool InsertSuccess<T>(T model, string fieldStrs) where T : class
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				string sql = string.Format(@"insert into {0}({1}) values ({2});",
				GetTableNameByModelName(model), fieldStrs,
				string.Join(",", fieldStrs.Split(',').ToList().ConvertAll(m => "@" + m.Trim()).ToArray()));
				return Conn.Execute(sql, model) > 0;
			}
		}

		/// <summary>
		/// 批量插入
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static bool BatchInsert<T>(List<T> list) where T : class, new()
		{
			if (!list.Any())
			{
				return false;
			}
			T model = new T();
			var props = model.GetAllPropKeys();
			string names = string.Join(",", props.ToArray());

			List<string> valAllLi = new List<string>();
			foreach (var item in list)
			{
				var itemProps = item.GetType().GetProperties();
				List<string> valList = new List<string>();
				foreach (var itemProp in itemProps)
				{
					string valStr = GetPropsValueStr(model, itemProp);
					valList.Add(valStr);
				}
				string vals = string.Join(",", valList.ToArray());
				valAllLi.Add("(" + vals + ")");
			}

			string values = string.Join(",", valAllLi.ToArray());
			string sql = string.Format(@"insert into {0} ({1}) values {2}",
				GetTableNameByModelName(model), names, values);

			using (var Conn = GetConn())
			{
				Conn.Open();
				return Conn.Execute(sql) > 0;
			}
		}

		/// <summary>
		/// 更新实体
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <param name="keyNames"></param>
		public static bool Update<T>(T model, params string[] keyNames) where T : class
		{
			if (model == null)
			{
				return false;
			}
			if (keyNames == null || !keyNames.Any())
			{
				throw new ArgumentException("参数不能为空或者列表元素个数不能为零");
			}
			var propStrs = model.GetAllPropKeys(keyNames.ToList());

			if (!propStrs.Any())
			{
				return false;
			}
			var itemProps = model.GetType().GetProperties();
			List<string> valList = new List<string>();
			List<PropertyInfo> exceptProps = new List<PropertyInfo>();
			foreach (var itemProp in itemProps)
			{
				if (keyNames.Any(m => m == itemProp.Name))
				{
					exceptProps.Add(itemProp);
					continue;
				}
				string valStr = GetPropsValueStr(model, itemProp);
				valList.Add($"{itemProp.Name}={valStr}");
			}
			string vals = string.Join(",", valList.ToArray());
			List<string> whereList = new List<string>();
			foreach (var prop in exceptProps)
			{
				string valStr = GetPropsValueStr(model, prop);
				whereList.Add($"{prop.Name}={valStr}");
			}
			string whereStr = string.Join(",", whereList.ToArray());

			string sql = $"update {GetTableNameByModelName(model)} set {vals} where {whereStr}";

			using (var Conn = GetConn())
			{
				Conn.Open();
				return Conn.Execute(sql) > 0;
			}
		}

		/// <summary>
		/// 获取属性的值（特殊值添加引号）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <param name="itemProp"></param>
		/// <returns></returns>
		private static string GetPropsValueStr<T>(T model, PropertyInfo itemProp)
		{
			var val = itemProp.GetValue(model);
			string valStr = "";
			var typeName = itemProp.PropertyType.FullName;
			switch (typeName)
			{
				case "System.String":
				case "System.DateTime":
					{
						valStr = "'" + val + "'";
					}
					break;
				default:
					{
						valStr = val.ToString();
					}
					break;
			}
			return valStr;
		}
	}
}
