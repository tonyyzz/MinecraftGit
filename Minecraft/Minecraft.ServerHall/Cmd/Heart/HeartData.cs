using Minecraft.Config;
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
        private MainCommand defMainCommand = MainCommand.Heart;
        private SecondCommand defSecondCommand = SecondCommand.Heart_Data;
        public override string Name
        {
            get
            {
                return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
            }
        }
        public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
        {
            session.Send(defMainCommand, defSecondCommand);
        }
    }
}
