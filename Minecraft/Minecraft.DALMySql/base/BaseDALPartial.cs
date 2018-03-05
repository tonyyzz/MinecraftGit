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
		/// 判断表是否存在
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		protected static bool JudgeTableExists(string tableName)
		{
			string sql = $"show tables like '{tableName}'; ";
			using (var Conn = GetConn())
			{
				Conn.Open();
				return !string.IsNullOrWhiteSpace(Conn.QueryFirstOrDefault<string>(sql));
			}
		}


		
	}
}
