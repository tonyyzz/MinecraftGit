﻿using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Net.Sockets;

namespace Minecraft.ConnTest.Receive
{
	public class Test_TestCmd
	{
		public void Execute(Socket socketClient, MainCommand mainCommand, SecondCommand secondCommand, string respStr)
		{
			var resp = respStr.JsonDeserialize<MsgResp>();
			if (resp == null || resp.InfoLevel != MsgLevelEnum.Info)
			{
				return;
			}
		}
	}
}
