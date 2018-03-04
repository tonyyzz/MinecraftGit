using Minecraft.ConnTest.Com;
using Minecraft.ConnTest.Send.Test;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
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
		public void Execute(string respStr)
		{
			var resp = respStr.JsonDeserialize<MsgResp>();
			if (resp == null || resp.InfoLevel != MsgLevelEnum.Info)
			{
				return;
			}
			//连接成功

			ComManager.Send(ComManager.socketClient, () =>
			{
				return SendTestCmd.GetReq();
			}, () =>
			{
				ComManager.Send(ComManager.socketClient, () =>
				{
					return SendTestCmd.GetReq();
				});
			});

			ThreadPool.QueueUserWorkItem(nn =>
			{
				while (true)
				{
					//发送
					ComManager.Send(ComManager.socketClient, () =>
					{
						return SendTestCmd.GetReq();
					});
					Thread.Sleep(1000);
				}
			});
		}
	}
}
