using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Minecraft.Model.ReqResp
{
	[System.Serializable]
	public class BackpackGoodsSelectResp : BaseResp
	{
		public List<GoodsInfo> goodsList;
	}

	[System.Serializable]
	public class GoodsInfo
	{
		/// <summary>
		/// 物品Id（GUID）（物品Id始终唯一，即使两个物品所有属性相同）
		/// </summary>
		public string GoodsId;
		/// <summary>
		/// 物品所属玩家
		/// </summary>
		public int PlayerId;
		/// <summary>
		/// 物品所属（1：背包，2：装备）（待定，所属可能还有地面）
		/// </summary>
		public int BelongsTo;
		/// <summary>
		/// 物品ItemId（相同属性的两个物品，其ItemId相同）（可能来自配置表）
		/// </summary>
		public string GoodsItemId;
		/// <summary>
		/// 物品位置（从0开始，背包中从左到右，由上至下的顺序，而装备中是从上到下，再从左到右的顺序）
		/// </summary>
		public int GoodsPosition;
		/// <summary>
		/// 损耗值
		/// </summary>
		public int WastageValue;
	}
}
