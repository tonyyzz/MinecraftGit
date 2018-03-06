using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft.ServerHall
{
	public static class MinecraftSessionExt
	{
		public static void Send<T>(this MinecraftSession session,
			MainCommand mainCommand,
			SecondCommand secondCommand,
			T obj) where T : BaseResp
		{
			string protocolStr = ProtocolHelper.GetProtocolStr(mainCommand, secondCommand);
			session.Send(protocolStr + SeparatorConfig.Transfer + obj.JsonSerialize());

			ThreadPool.QueueUserWorkItem(o =>
			{
				var t = o as BaseResp;
				if (t != null)
				{
					switch (t.RespLevel)
					{
						case RespLevelEnum.Warn:
							{
								session.Logger.Warn(t.Msg);
							}
							break;
						case RespLevelEnum.Error:
							{
								session.Logger.Error(t.Msg);
							}
							break;
						case RespLevelEnum.Success:
							break;
						default:
							break;
					}
				}
			}, obj);
		}
	}
}
