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
			var resp = respStr.JsonDeserialize<MsgResp>();
			if (resp == null || resp.InfoLevel != MsgLevelEnum.Info)
			{
				return;
			}
			//连接成功


			ComManager.Send(socketClient, () =>
			{
				return SendTestCmd.GetReq();
			});
		}
	}
}
