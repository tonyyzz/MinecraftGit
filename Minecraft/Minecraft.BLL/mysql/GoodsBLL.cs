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
		public static bool InsertGoodsInfoForSplitTable(GoodsModel model, List<string> goodsTableNameCacheList)
		{
			return GoodsDAL.InsertGoodsInfoForSplitTable(model, goodsTableNameCacheList);
		}
	}
}
