using System;
namespace Minecraft.Model
{
	/// <summary>
	/// 
	/// </summary>
	/// 由代码生成器生成，Created Time：2018-03-03 17:28:38
	public partial class PlayerbasisModel
	{
		/// <summary>
		/// 
		/// </summary>
		public PlayerbasisModel()
		{
			PlayerId = 0;
			Name = "";
			Exp = 0;
			PhysicalStrengthValue = 0;
			GoldCoin = 0;
			Human_Life = 0;
			Human_Clean = 0;
			Human_GoToilet = 0;
			Human_Hunger = 0;
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
		/// 名字，不允许重名
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 当前经验值
		/// </summary>
		public int Exp { get; set; }
		/// <summary>
		/// 体力值
		/// </summary>
		public int PhysicalStrengthValue { get; set; }
		/// <summary>
		/// 金币
		/// </summary>
		public int GoldCoin { get; set; }
		/// <summary>
		/// 生命值
		/// </summary>
		public int Human_Life { get; set; }
		/// <summary>
		/// 清洁值
		/// </summary>
		public int Human_Clean { get; set; }
		/// <summary>
		/// 如厕值
		/// </summary>
		public int Human_GoToilet { get; set; }
		/// <summary>
		/// 饥饿值
		/// </summary>
		public int Human_Hunger { get; set; }
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
