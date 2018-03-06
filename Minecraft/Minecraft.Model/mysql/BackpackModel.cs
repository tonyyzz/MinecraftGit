using System;
namespace Minecraft.Model
{
	/// <summary>
	/// 
	/// </summary>
	/// 由代码生成器生成，Created Time：2018-03-06 09:09:21
	public partial class BackpackModel
	{
		/// <summary>
		/// 
		/// </summary>
		public BackpackModel()
		{
			PlayerId = 0;
			Size = 0;
			GoodsIds = "";
		}
		/// <summary>
		/// 玩家Id
		/// </summary>
		public int PlayerId { get; set; }
		/// <summary>
		/// 背包格子大小
		/// </summary>
		public int Size { get; set; }
		/// <summary>
		/// 物品Id集合（中间用半角逗号","分隔）
		/// </summary>
		public string GoodsIds { get; set; }
	}
}
