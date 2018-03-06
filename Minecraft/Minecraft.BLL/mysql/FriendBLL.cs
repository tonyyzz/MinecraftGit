using Minecraft.DALMySql;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL.mysql
{
	public class FriendBLL
	{
		/// <summary>
		/// 向friend表插入数据（分表插入，如果不存在表，则先建立表，并将表名称缓存起来）
		/// </summary>
		/// <param name="model"></param>
		/// <param name="friendTableNameCacheList"></param>
		/// <returns></returns>
		public static bool InsertFriendInfoForSplitTable(FriendModel model, List<string> friendTableNameCacheList)
		{
			return FriendDAL.InsertFriendInfoForSplitTable(model, friendTableNameCacheList);
		}
	}
}
