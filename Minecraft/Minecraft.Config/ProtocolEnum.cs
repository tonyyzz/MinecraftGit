using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	public static class ProtocolLen
	{
		public const int Main = 3;
		public const int Second = 5;
	}

	public enum MainCommand
	{
		/// <summary>
		/// 测试
		/// </summary>
		Test = 1,
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
		/// 心跳包
		/// </summary>
		Heart,
	}

	public enum SecondCommand
	{
		/// <summary>
		/// 测试
		/// </summary>
		Test_Test = 1001,


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
		Player_Login,
		Player_BaseInsert,



		/// <summary>
		/// 心跳包 数据
		/// </summary>
		Heart_Data,
	}
}
