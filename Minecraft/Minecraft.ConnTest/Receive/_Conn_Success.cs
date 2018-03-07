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
	/// <summary>
	/// 连接成功后
	/// </summary>
	public class Conn_Success
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
						//连接成功
						//登录操作
						//ComManager.Send(socketClient, () =>
						//{
						//	return SendPlyerLogin.GetReq();
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
