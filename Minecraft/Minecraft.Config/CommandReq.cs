using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minecraft.Config
{
	public class CommandReq<T> where T : BaseReq
	{
		public EnumCommand Command { get; set; }
		public T Req { get; set; }
	}
}
