namespace Minecraft.Config
{
	public static class ProtocolLen
	{
		/// <summary>
		/// 协议长度
		/// </summary>
		public const int Length = 8;
	}

	/// <summary>
	/// 协议
	/// </summary>
	public enum EnumCommand
	{
		/// <summary>
		/// 测试
		/// </summary>
		Test_TestCmd = 1001,

		/// <summary>
		/// 心跳包 数据
		/// </summary>
		Heart_HeartData,


		/// <summary>
		/// 连接成功
		/// </summary>
		Conn_Success,
		/// <summary>
		/// 连接关闭
		/// </summary>
		Conn_Close,
		
		/// <summary>
		/// 处理异常
		/// </summary>
		Handle_HandleException,
		/// <summary>
		/// 处理未知请求
		/// </summary>
		Handle_HandleUnknownRequest,

		/// <summary>
		/// 玩家登录
		/// </summary>
		Player_PlayerLogin,
		

		/// <summary>
		/// 背包物品插入
		/// </summary>
		Backpack_BackpackGoodsInsert,
		/// <summary>
		/// 背包物品查询
		/// </summary>
		Backpack_BackpackGoodsSelect,


		/// <summary>
		/// 家具插入
		/// </summary>
		Furniture_FurnitureInsert,


		/// <summary>
		/// 好友信息插入
		/// </summary>
		Friend_FriendInsert,
		/// <summary>
		/// 朋友列表查询
		/// </summary>
		Friend_FriendListSelect,


		/// <summary>
		/// 大地图进度信息插入
		/// </summary>
		AtlasSchedule_AtlasScheduleInsert,
		/// <summary>
		/// 大地图信息查询
		/// </summary>
		AtlasSchedule_AtlasScheduleSelect,
	}
}
