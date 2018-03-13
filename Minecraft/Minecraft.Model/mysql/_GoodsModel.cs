using System;
namespace Minecraft.Model
{
	/// <summary>
	/// 
	/// </summary>
	/// 由代码生成器生成，Created Time：2018-03-03 18:15:37
	public partial class GoodsModel
	{
		/// <summary>
		/// 
		/// </summary>
		public GoodsModel()
		{
			GoodsId = "";
			PlayerId = 0;
			BelongsTo = 0;
			GoodsItemId = "";
			GoodsPosition = 0;
			WastageValue = 0;
		}
		/// <summary>
		/// 物品Id（GUID）（物品Id始终唯一，即使两个物品所有属性相同）
		/// </summary>
		public string GoodsId { get; set; }
		/// <summary>
		/// 物品所属玩家
		/// </summary>
		public int PlayerId { get; set; }
		/// <summary>
		/// 物品所属（1：背包，2：装备）（待定，所属可能还有地面）
		/// </summary>
		public int BelongsTo { get; set; }
		/// <summary>
		/// 物品ItemId（相同属性的两个物品，其ItemId相同）（可能来自配置表）
		/// </summary>
		public string GoodsItemId { get; set; }
		/// <summary>
		/// 物品位置（从0开始，背包中从左到右，由上至下的顺序，而装备中是从上到下，再从左到右的顺序）
		/// </summary>
		public int GoodsPosition { get; set; }
		/// <summary>
		/// 损耗值
		/// </summary>
		public int WastageValue { get; set; }
	}
}
