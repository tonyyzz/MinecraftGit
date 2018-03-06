﻿using Minecraft.Config;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.DALMySql
{
	public class FriendDAL : BaseDAL
	{
		/// <summary>
		/// 动态建立goods数据表
		/// </summary>
		/// <param name="playerId"></param>
		/// <returns></returns>
		private static string GetCreateFriendTableSql(int playerId)
		{

			string tableName = GetTableNameWithTablePrefix(playerId, 
				MinecraftCommonConfig.Prefix_GoodsTable, 
				MinecraftConfiguration.Minecraft_Mysql_FriendTable_SubmeterLen);

			string sql = @"

/*==============================================================*/
/* Table: "+ tableName + @"                                                */
/*==============================================================*/
create table " + tableName + @"
(
   PlayerId             int comment '玩家Id',
   FriendId             int comment '好友Id',
   AddTime              datetime comment '添加时间'
);

alter table " + tableName + @" comment '好友表';

";
			return sql;
		}
		/// <summary>
		/// 向friend表插入数据（分表插入，如果不存在表，则先建立表，并将表名称缓存起来）
		/// </summary>
		/// <param name="model"></param>
		/// <param name="friendTableNameCacheList"></param>
		/// <returns></returns>
		public static bool InsertFriendInfoForSplitTable(FriendModel model, List<string> friendTableNameCacheList)
		{
			return InsertSuccessModelData(model,
				friendTableNameCacheList,
				model.PlayerId,
				MinecraftCommonConfig.Prefix_FriendTable,
				MinecraftConfiguration.Minecraft_Mysql_FriendTable_SubmeterLen,
				GetCreateFriendTableSql);
		}
	}
}
