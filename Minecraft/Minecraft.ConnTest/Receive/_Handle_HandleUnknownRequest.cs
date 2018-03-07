﻿using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Net.Sockets;

namespace Minecraft.ConnTest.Receive
{
	public class Handle_HandleUnknownRequest
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
					break;
				case RespLevelEnum.Warn:
					break;
				case RespLevelEnum.Error:
					{

					}
					break;
				default:
					break;
			}
		}
	}
}