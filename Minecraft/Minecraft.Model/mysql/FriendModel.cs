using System;
namespace Minecraft.Model
{
	/// <summary>
	/// 
	/// </summary>
	/// 由代码生成器生成，Created Time：2018-03-06 09:16:51
	public partial class FriendModel
	{
		/// <summary>
		/// 
		/// </summary>
		public FriendModel()
		{
			PlayerId = 0;
			FriendId = 0;
			AddTime = new DateTime(1900, 1, 1);
		}
		/// <summary>
		/// 玩家Id
		/// </summary>
		public int PlayerId { get; set; }
		/// <summary>
		/// 好友Id
		/// </summary>
		public int FriendId { get; set; }
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddTime { get; set; }
	}
}
