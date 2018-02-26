using GoStop.BaseCommon;
using Minecraft.Common;
using Minecraft.Config;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocketSdy.ConsoleTest.Telnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall.Cmd.Test
{
    public class TestCmd : CommandBase<MinecraftSession, StringRequestInfo>
    {

        private MainCommand mainCommand = MainCommand.TestCmd;
        private SecondCommand secondCommand = SecondCommand.TestCmd_Test;

        public override string Name
        {
            get
            {
                return GetProtocolStr(mainCommand, secondCommand);
            }
        }
        public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine($"IP:{session.RemoteEndPoint.Address.ToString()}; Body:{requestInfo.Body}");

            string protocolStr = GetProtocolStr(mainCommand, secondCommand);

            string sendStr = protocolStr + " " + requestInfo.Body + " --by yzz Minecraft";

            //var bytes = CommonConfig.DefEncoding.GetBytes(sendStr);
            //CustomDE.Encrypt(bytes, 0, bytes.Length);
            // session.Send(CommonConfig.DefEncoding.GetString(bytes));

            session.Send(CustomEncrypt.Encrypt(sendStr));

            //var sessions = session.AppServer.GetAllSessions().ToList();

            //UdpRequestInfo
        }

        string GetProtocolStr(MainCommand mainCommand, SecondCommand secondCommand)
        {
            return $"{((int)mainCommand).ToString().PadLeft(ProtocolLen.Main, '0')}" +
                   $"{((int)secondCommand).ToString().PadLeft(ProtocolLen.Second, '0')}";

        }
    }
}
