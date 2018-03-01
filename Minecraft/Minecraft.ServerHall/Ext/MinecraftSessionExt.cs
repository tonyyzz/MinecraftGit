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
			T obj) where T : class
		{
			string protocolStr = ProtocolHelper.GetProtocolStr(mainCommand, secondCommand);
			session.Send(protocolStr + MinecraftCommonConfig.SeparativeSymbol.ToString() + obj.JsonSerialize());

			ThreadPool.QueueUserWorkItem(o =>
			{
				var t = obj as MsgResp;
				if (t != null)
				{
					switch (t.InfoLevel)
					{
						case MsgLevelEnum.Warn:
							{
								session.Logger.Warn(t.Msg);
							}
							break;
						case MsgLevelEnum.Error:
							{
								session.Logger.Error(t.Msg);
							}
							break;
						case MsgLevelEnum.Info:
							break;
						default:
							break;
					}
				}
			}, obj);
		}
	}
}
