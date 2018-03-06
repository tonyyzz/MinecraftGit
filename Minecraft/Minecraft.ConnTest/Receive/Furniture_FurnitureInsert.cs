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
	public class Furniture_FurnitureInsert
	{
		public void Execute(Socket socketClient, MainCommand mainCommand, SecondCommand secondCommand, string respStr)
		{
			var resp = respStr.JsonDeserialize<FurnitureInsertResp>();
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
					break;
				default:
					break;
			}
		}
	}
}
