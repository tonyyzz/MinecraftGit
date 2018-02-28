using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Model.ReqResp.Player
{
	/// <summary>
	/// 玩家登录响应消息体
	/// </summary>
	public class PlayerLoginResp
	{
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
