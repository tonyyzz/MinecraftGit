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
	public class GoodsDAL : BaseDAL
	{
		/// <summary>
		/// 动态建立goods数据表
		/// </summary>
		/// <param name="playerId"></param>
		/// <returns></returns>
		private static string GetCreateGoodsTableSql(int playerId)
		{

			string tableName = GetGoodsTableName(playerId);

			string sql = @"

/*==============================================================*/
/* Table: " + tableName + @"                                                 */
/*==============================================================*/
create table " + tableName + @"
(
   GoodsId              varchar(64) not null comment '物品Id（GUID）（物品Id始终唯一，即使两个物品所有属性相同）',
   PlayerId             int comment '物品所属玩家',
   BelongsTo            int comment '物品所属（1：背包，2：装备）（待定，所属可能还有地面）',
   GoodsItemId          int comment '物品ItemId（相同属性的两个物品，其ItemId相同）（可能来自配置表）',
   GoodsPosition        int comment '物品位置（从0开始，背包中从左到右，由上至下的顺序，而装备中是从上到下，再从左到右的顺序）',
   WastageValue         int comment '损耗值',
   primary key (GoodsId)
);

alter table " + tableName + @" comment '物品（来自背包或者装备）（需要分表）';


";
			return sql;
		}


		private static string GetGoodsTableName(int playerId)
		{
			var submeterLen = Convert.ToInt32(MinecraftConfiguration.Minecraft_Mysql_GoodsTable_SubmeterLen);
			string tableName = $"Goods_{(playerId / submeterLen) * submeterLen + submeterLen }";
			return tableName;
		}

		/// <summary>
		/// 动态增加goods表，如果存在，则不做处理
		/// </summary>
		/// <param name="playerId"></param>
		/// <param name="tableNameList">goods表名称内存缓存</param>
		/// <returns></returns>
		public static bool AddGoodsTable(int playerId, List<string> tableNameList)
		{
			string tableName = GetGoodsTableName(playerId);
			if (tableNameList.Any(m => m == tableName))
			{
				return true;
			}
			var isGoodsTableExists = JudgeTableExists(tableName);
			if (isGoodsTableExists)
			{
				tableNameList.Add(tableName);
				return true;
			}
			string sql = GetCreateGoodsTableSql(playerId);
			using (var Conn = GetConn())
			{
				Conn.Open();
				Conn.Execute(sql);
				isGoodsTableExists = JudgeTableExists(tableName);
				if (isGoodsTableExists)
				{
					tableNameList.Add(tableName);
				}
				return isGoodsTableExists;
			}
		}


		/// <summary>
		/// goods信息插入
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public static bool InsertSuccessGoodsModel(GoodsModel model, List<string> goodsTableNameList)
		{
			if (AddGoodsTable(model.PlayerId, goodsTableNameList))
			{
				using (var Conn = GetConn())
				{
					Conn.Open();
					var propKeys = model.GetAllPropKeys();
					var names = string.Join(",", propKeys.ToArray());
					var values = string.Join(",", propKeys.ToList().ConvertAll(m => "@" + m).ToArray());
					string sql = string.Format(@"insert into {0}({1}) values({2});",
						//model.GetType().Name.Substring(0, model.GetType().Name.LastIndexOf("Model")).ToLower()+"_"+,
						GetGoodsTableName(model.PlayerId),
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
	}
}
