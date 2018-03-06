using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Model.ReqResp
{
	/// <summary>
	/// 玩家登录请求消息体
	/// </summary>
	public class PlayerLoginReq : BaseReq
	{
		public int PlayerId { get; set; }
	}
}
