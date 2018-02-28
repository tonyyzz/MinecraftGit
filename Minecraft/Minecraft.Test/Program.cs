﻿using Minecraft.BLL;
using Minecraft.BLL.mysql;
using Minecraft.Model.ReqResp.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerLoginReq playerLoginRequest = new PlayerLoginReq()
            {
                PlayerId = 1
            };
            var player = PlayerBLL.GetSingleOrDefault(playerLoginRequest.PlayerId);
            Console.WriteLine(player.JsonSerialize());
            Console.ReadKey();
        }

        
    }
}
