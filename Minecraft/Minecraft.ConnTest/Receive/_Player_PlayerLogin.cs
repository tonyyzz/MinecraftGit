using Minecraft.Config;
using Minecraft.ConnTest.Send;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Receive
{
	public class Player_PlayerLogin
	{
		public void Execute(Socket socketClient, MainCommand mainCommand, SecondCommand secondCommand, string respStr)
		{
			var resp = respStr.JsonDeserialize<PlayerLoginResp>();
			if (resp == null)
			{
				return;
			}
			switch (resp.RespLevel)
			{
				case RespLevelEnum.Success:
					{
						//登录成功

						//登录之后的操作

						ComManager.Send(socketClient, () =>
						{
							return SendFriendListSelect.GetReq();
						});

						//ThreadPool.QueueUserWorkItem(m =>
						//{
						//	while (true)
						//	{
						//		Thread.Sleep(1000);
						//		ComManager.Send(socketClient, () =>
						//		{
						//			return SendTestCmd.GetReq();
						//		});

						//	}
						//});
					}
					break;
				case RespLevelEnum.Warn:
					break;
				case RespLevelEnum.Error:
					break;
				default:
					break;
			}

		}
	}
}
