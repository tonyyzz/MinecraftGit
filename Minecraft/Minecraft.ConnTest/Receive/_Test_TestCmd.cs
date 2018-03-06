using Minecraft.Config;
using Minecraft.ConnTest.Send;
using Minecraft.Model.ReqResp;
using System;
using System.Net.Sockets;
using System.Threading;

namespace Minecraft.ConnTest.Receive
{
	public class Test_TestCmd
	{
		public void Execute(Socket socketClient, MainCommand mainCommand, SecondCommand secondCommand, string respStr)
		{
			var resp = respStr.JsonDeserialize<BaseResp>();
			if (resp == null)
			{
				return;
			}
			switch (resp.RespLevel)
			{
				case RespLevelEnum.Success:
					{
						Thread.Sleep(1000);
						ComManager.Send(socketClient, () =>
						{
							return SendTestCmd.GetReq();
						});
					}
					break;
				case RespLevelEnum.Warn:
					break;
				case RespLevelEnum.Error:
					{
						Console.WriteLine(resp.Msg);
					}
					break;
				default:
					break;
			}
		}
	}
}
