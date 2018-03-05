﻿using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Receive
{
	public class Heart_HeartData
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
