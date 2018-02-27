using GoStop.BaseCommon;
using Minecraft.Common;
using Minecraft.Config;
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
        private MainCommand defMainCommand = MainCommand.Test;
        private SecondCommand defSecondCommand = SecondCommand.Test_Test;
        public override string Name
        {
            get
            {
                return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
            }
        }
        public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
        {
           // Console.WriteLine($"IP:{session.RemoteEndPoint.Address.ToString()}; Body:{requestInfo.Body}");

           // Console.WriteLine($"是否登陆：{session.IsLogin}");

            session.Send(defMainCommand, defSecondCommand,   
                requestInfo.Body + " --by yzz Minecraft");
            //session.Close( SuperSocket.SocketBase.CloseReason.ServerClosing);
        }
    }
}
