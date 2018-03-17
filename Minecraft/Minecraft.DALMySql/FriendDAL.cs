using Minecraft.Config;
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
				TablePrefixConfig.Friend,
				JsonConfig.Value.Mysql.SubmeterLen.FriendTable// MinecraftConfiguration.Minecraft_Mysql_FriendTable_SubmeterLen
				);

			//  "+ tableName + @"

			string sql = @"

/*==============================================================*/
/* Table: " + tableName + @"                                                */
/*==============================================================*/
create table " + tableName + @"
(
   PlayerId             int comment '玩家Id',
   FriendId             int comment '好友Id',
   AddTime              datetime comment '添加时间',
   primary key (PlayerId, FriendId)
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
		public static bool InsertSuccessForSplitTable(FriendModel model, List<string> friendTableNameCacheList)
		{
			return InsertSuccessModelData(model,
				friendTableNameCacheList,
				model.PlayerId,
				TablePrefixConfig.Friend,
				JsonConfig.Value.Mysql.SubmeterLen.FriendTable,// MinecraftConfiguration.Minecraft_Mysql_FriendTable_SubmeterLen,
				GetCreateFriendTableSql);
		}

		public static List<FriendModel> GetListAll(int playerId)
		{
			var model = new FriendModel();
			return GetListAllWithTablePrefix(model, playerId,
				TablePrefixConfig.Friend,
			JsonConfig.Value.Mysql.SubmeterLen.FriendTable,//	MinecraftConfiguration.Minecraft_Mysql_FriendTable_SubmeterLen,
				new KeyValue<int> { Key = nameof(model.PlayerId), Value = playerId });
		}
	}
}
