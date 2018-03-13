namespace Minecraft.Model.ReqResp
{
	/// <summary>
	/// 玩家登录响应消息体
	/// </summary>
	[System.Serializable]
	public class PlayerLoginResp : BaseResp
	{
		/// <summary>
		/// 玩家Id
		/// </summary>
		public int PlayerId;
		/// <summary>
		/// 名字，不允许重名
		/// </summary>
		public string Name;
		/// <summary>
		/// 当前经验值
		/// </summary>
		public int Exp;
		/// <summary>
		/// 体力值
		/// </summary>
		public int PhysicalStrengthValue;
		/// <summary>
		/// 金币
		/// </summary>
		public int GoldCoin;
		/// <summary>
		/// 生命值
		/// </summary>
		public int Human_Life;
		/// <summary>
		/// 清洁值
		/// </summary>
		public int Human_Clean;
		/// <summary>
		/// 如厕值
		/// </summary>
		public int Human_GoToilet;
		/// <summary>
		/// 饥饿值
		/// </summary>
		public int Human_Hunger;
		/// <summary>
		/// 攻击力
		/// </summary>
		public int Fight_Attack;
		/// <summary>
		/// 防御力
		/// </summary>
		public int Fight_Defense;
		/// <summary>
		/// 移动速度
		/// </summary>
		public int Fight_TravelRate;
		/// <summary>
		/// 攻击速度
		/// </summary>
		public int Fight_AttackSpeed;
	}
}
