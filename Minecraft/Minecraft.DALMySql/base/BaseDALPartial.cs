using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Minecraft.DALMySql
{
	public partial class BaseDAL
	{
		//动态建立数据表
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
			string tableName = $"Goods_{playerId / submeterLen + submeterLen }";
			return tableName;
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
				return Conn.Execute(sql) > 0;
			}
		}

		/// <summary>
		/// 动态增加goods表，如果存在，则不做处理
		/// </summary>
		/// <param name="playerId"></param>
		/// <returns></returns>
		public static bool AddGoodsTable(int playerId)
		{
			var isGoodsTableExists = JudgeTableExists(GetGoodsTableName(playerId));
			if (isGoodsTableExists)
			{
				return true;
			}
			string sql = GetCreateGoodsTableSql(playerId);
			using (var Conn = GetConn())
			{
				Conn.Open();
				return Conn.Execute(sql) > 0;
			}
		}
	}
}
