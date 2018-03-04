using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Test
{
	/// <summary>
	/// 消息响应实体
	/// </summary>
	public class MsgResp
	{
		/// <summary>
		/// 消息响应实体 有参构造
		/// </summary>
		/// <param name="infoLevel"></param>
		/// <param name="msg"></param>
		public MsgResp(MsgLevelEnum infoLevel, string msg)
		{
			InfoLevel = infoLevel;
			Msg = msg;
		}
		/// <summary>
		/// 消息级别
		/// </summary>
		public MsgLevelEnum InfoLevel { get; set; }
		/// <summary>
		/// 消息文本
		/// </summary>
		public string Msg { get; set; }
	}

	/// <summary>
	/// 消息级别枚举
	/// </summary>
	public enum MsgLevelEnum
	{
		Info = 1,
		Warn,
		Error,
	}
}
