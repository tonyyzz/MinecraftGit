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
		/// 向goods表插入数据（分表插入，如果不存在表，则先建立表，并将表名称缓存起来）
		/// </summary>
		/// <param name="model"></param>
		/// <param name="goodsTableNameCacheList"></param>
		/// <returns></returns>
		public static bool InsertSuccessForSplitTable(GoodsModel model, List<string> goodsTableNameCacheList)
		{
			return GoodsDAL.InsertSuccessForSplitTable(model, goodsTableNameCacheList);
		}

		public static GoodsModel GetFirstOrDefault(int playerId, string goodsId)
		{
			return GoodsDAL.GetFirstOrDefault(playerId, goodsId);
		}
		public static List<GoodsModel> GetListAll(int playerId)
		{
			return GoodsDAL.GetListAll(playerId);
		}
	}
}
