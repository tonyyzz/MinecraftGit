using Minecraft.Config;
using Minecraft.ServerHall.Helper;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall.Cmd.Player
{
    public class PlyerLogin : CommandBase<MinecraftSession, StringRequestInfo>
    {
        private MainCommand mainCommand = MainCommand.Player;
        private SecondCommand secondCommand = SecondCommand.Player_Login;
        public override string Name
        {
            get
            {
                return ProtocolHelper.GetProtocolStr(mainCommand, secondCommand);
            }
        }
        public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine($"IP:{session.RemoteEndPoint.Address.ToString()}; Body:{requestInfo.Body}");

            session.IsLogin = true;

            session.Send(mainCommand, secondCommand,
                requestInfo.Body + " --by yzz Minecraft");
        }
    }
}
