using Minecraft.DALMySql;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL.mysql
{
	public class GoodsBLL
	{
		/// <summary>
		/// 动态增加goods表，如果存在，则不做处理
		/// </summary>
		/// <param name="playerId">玩家Id</param>
		/// <param name="tableNameList">goods表名称内存缓存</param>
		/// <returns></returns>
		//public static bool AddGoodsTable(int playerId, List<string> tableNameList)
		//{
		//	return GoodsDAL.AddGoodsTable(playerId, tableNameList);
		//}

		/// <summary>
		/// goods信息插入
		/// </summary>
		/// <param name="model"></param>
		/// <param name="goodsTableNameList"></param>
		/// <returns></returns>
		public static bool InsertSuccessGoodsModel(GoodsModel model, List<string> goodsTableNameList)
		{
			return GoodsDAL.InsertSuccessGoodsModel(model, goodsTableNameList);
		}
	}
}
