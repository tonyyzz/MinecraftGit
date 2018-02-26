using Minecraft.Config;
using Minecraft.ServerHall.Helper;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall.Cmd.Heart
{
    public class HeartData : CommandBase<MinecraftSession, StringRequestInfo>
    {
        private MainCommand mainCommand = MainCommand.Heart;
        private SecondCommand secondCommand = SecondCommand.Heart_Data;

        public override string Name
        {
            get
            {
                return ProtocolHelper.GetProtocolStr(mainCommand, secondCommand);
            }
        }
        public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
        {
            
        }
    }
}
