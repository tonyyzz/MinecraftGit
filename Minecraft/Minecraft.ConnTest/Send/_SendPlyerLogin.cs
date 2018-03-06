﻿using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Send
{
	public class SendPlyerLogin
	{
		public static MainCommand mainCommand = MainCommand.Player;
		public static SecondCommand secondCommand = SecondCommand.Player_PlayerLogin;
		public static (MainCommand, SecondCommand, object) GetReq()
		{
			var req = new PlayerLoginReq()
			{
				PlayerId = 1
			};
			return (mainCommand, secondCommand, req);
		}
	}
}
