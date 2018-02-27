using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall
{
    public static class MinecraftSessionExt
    {
        public static void Send(this MinecraftSession session,
            MainCommand mainCommand,
            SecondCommand secondCommand,
            string sendStr = "")
        {
            string protocolStr = ProtocolHelper.GetProtocolStr(mainCommand, secondCommand);
            session.Send(protocolStr + " " + sendStr);
        }
    }
}
