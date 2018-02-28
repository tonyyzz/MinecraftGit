using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall
{
	/// <summary>
	/// Minecraft session info ext
	/// </summary>
	public class MinecraftSessionInfo
	{
		/// <summary>
		/// 是否登录
		/// </summary>
		public bool IsLogin = false;
		/// <summary>
		/// 最近登录时间
		/// </summary>
		public DateTime LastLoginTime = DateTimeHelper.DateTimeConst.DefaultTime;

		/// <summary>
		/// 玩家信息
		/// </summary>
		public PlayerModel player = null;
	}
}
