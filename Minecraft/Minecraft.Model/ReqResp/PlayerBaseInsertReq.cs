using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Model.ReqResp
{
	public class PlayerBaseInsertReq
	{
		/// <summary>
		/// 玩家Id
		/// </summary>
		public int PlayerId { get; set; }
		/// <summary>
		/// 生命值
		/// </summary>
		public int Human_Life { get; set; }
		/// <summary>
		/// 饥饿值
		/// </summary>
		public int Human_Hunger { get; set; }
		/// <summary>
		/// 清洁值
		/// </summary>
		public int Human_Clean { get; set; }
		/// <summary>
		/// 如厕值
		/// </summary>
		public int Human_GoToilet { get; set; }
		/// <summary>
		/// 攻击力
		/// </summary>
		public int Fight_Attack { get; set; }
		/// <summary>
		/// 防御力
		/// </summary>
		public int Fight_Defense { get; set; }
		/// <summary>
		/// 移动速度
		/// </summary>
		public int Fight_TravelRate { get; set; }
		/// <summary>
		/// 攻击速度
		/// </summary>
		public int Fight_AttackSpeed { get; set; }
	}
}
