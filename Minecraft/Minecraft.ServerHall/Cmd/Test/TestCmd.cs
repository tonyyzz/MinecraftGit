using GoStop.BaseCommon;
using Minecraft.Common;
using Minecraft.Config;
using Minecraft.ServerHall.Helper;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall.Cmd.Test
{
    /// <summary>
    /// 测试命令
    /// </summary>
    public class TestCmd : CommandBase<MinecraftSession, StringRequestInfo>
    {
        private MainCommand mainCommand = MainCommand.Test;
        private SecondCommand secondCommand = SecondCommand.Test_Test;
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

            session.Send(mainCommand, secondCommand,  
                requestInfo.Body + " --by yzz Minecraft");
        }
    }
}
