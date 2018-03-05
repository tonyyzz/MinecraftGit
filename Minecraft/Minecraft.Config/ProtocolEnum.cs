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
		/// 错误
		/// </summary>
		Error,
		/// <summary>
		/// 玩家
		/// </summary>
		Player,
		
		/// <summary>
		/// 背包
		/// </summary>
		Backpack,
		/// <summary>
		/// 背包
		/// </summary>
		Goods,
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
		/// 应用程序错误
		/// </summary>
		Error_ApplicationError,
		/// <summary>
		/// 未知错误
		/// </summary>
		Error_UnknowRequest,
		/// <summary>
		/// 参数错误
		/// </summary>
		Error_ParameterError,
		/// <summary>
		/// 不存在
		/// </summary>
		Error_NotExist,



		/// <summary>
		/// 玩家登录
		/// </summary>
		Player_PlyerLogin,
		/// <summary>
		/// 玩家基础信息插入
		/// </summary>
		Player_PlayerBaseInsert,
		

		/// <summary>
		/// 背包物品插入
		/// </summary>
		Backpack_BackpackGoodsInsert,


		/// <summary>
		/// 背包插入
		/// </summary>
		Goods_GoodsInsert,
	}
}
