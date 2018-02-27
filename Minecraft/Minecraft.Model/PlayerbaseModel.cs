using System;
namespace Minecraft.Model
{
	/// <summary>
	/// 玩家基地信息
	/// </summary>
	/// 由代码生成器生成，Created Time：2018-02-27 13:33:18
	public partial class PlayerbaseModel
	{
		/// <summary>
		/// 
		/// </summary>
		public PlayerbaseModel()
		{
			PlayerId = 0;
			Human_Life = 0;
			Human_Hunger = 0;
			Human_Clean = 0;
			Human_GoToilet = 0;
			Fight_Attack = 0;
			Fight_Defense = 0;
			Fight_TravelRate = 0;
			Fight_AttackSpeed = 0;
		}
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
