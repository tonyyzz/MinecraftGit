using Minecraft.BLL;
using Minecraft.Model.Player;
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
            PlayerLoginRequest playerLoginRequest = new PlayerLoginRequest()
            {
                PlayerId = 1
            };
            var player = PlayerBLL.GetSingleOrDefault(playerLoginRequest.PlayerId);
            Console.WriteLine(player.JsonSerialize());
            Console.ReadKey();
        }

       
    }
}
