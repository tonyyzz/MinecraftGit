using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	public static class ProtocolLen
	{
		/// <summary>
		/// 主协议长度
		/// </summary>
		public const int Main = 3;
		/// <summary>
		/// 次协议长度
		/// </summary>
		public const int Second = 5;
	}

	/// <summary>
	/// 主协议
	/// </summary>
	public enum MainCommand
	{
		/// <summary>
		/// 测试
		/// </summary>
		Test = 1,
		/// <summary>
		/// 心跳包
		/// </summary>
		Heart,
		/// <summary>
		/// 连接
		/// </summary>
		Conn,
		/// <summary>
		/// 处理
		/// </summary>
		Handle,
		/// <summary>
		/// 玩家
		/// </summary>
		Player,
		/// <summary>
		/// 背包
		/// </summary>
		Backpack,
		/// <summary>
		/// 家具
		/// </summary>
		Furniture,
		/// <summary>
		/// 好友
		/// </summary>
		Friend,
		/// <summary>
		/// 大地图进度信息
		/// </summary>
		AtlasSchedule,
	}

	/// <summary>
	/// 次协议
	/// </summary>
	public enum SecondCommand
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
