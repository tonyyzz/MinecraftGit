using System;
namespace GoStopProxy.Model
{
	/// <summary>
	/// 
	/// </summary>
	/// 由代码生成器生成，Created Time：2018-02-27 13:33:18
	public partial class PlayerModel
	{
		/// <summary>
		/// 
		/// </summary>
		public PlayerModel()
		{
			PlayerId = 0;
			Pwd = "";
			MinkName = "";
			exp = 0;
			CompetitiveCurrency = 0;
			diamond = 0;
		}
		/// <summary>
		/// 玩家Id
		/// </summary>
		public int PlayerId { get; set; }
		/// <summary>
		/// 密码
		/// </summary>
		public string Pwd { get; set; }
		/// <summary>
		/// 昵称
		/// </summary>
		public string MinkName { get; set; }
		/// <summary>
		/// 经验值
		/// </summary>
		public int exp { get; set; }
		/// <summary>
		/// 竞技币
		/// </summary>
		public int CompetitiveCurrency { get; set; }
		/// <summary>
		/// 钻石
		/// </summary>
		public int diamond { get; set; }
	}
}
