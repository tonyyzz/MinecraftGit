using Minecraft.BLL;
using Minecraft.Common;
using Minecraft.Config;
using Minecraft.Model.Player;
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
        private MainCommand defMainCommand = MainCommand.Player;
        private SecondCommand defSecondCommand = SecondCommand.Player_Login;
        public override string Name
        {
            get
            {
                return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
            }
        }
        public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
        {
            //Console.WriteLine($"IP:{session.RemoteEndPoint.Address.ToString()}; Body:{requestInfo.Body}");

            PlayerLoginRequest playerLoginRequest = requestInfo.GetRequestObj<PlayerLoginRequest>();
            if (playerLoginRequest == null || playerLoginRequest.PlayerId <= 0)
            {
                session.Send(MainCommand.Error, SecondCommand.Error_ParameterError);
                return;
            }

            var player = PlayerBLL.GetSingleOrDefault(playerLoginRequest.PlayerId);
            if (player == null)
            {
                session.Send(MainCommand.Error, SecondCommand.Error_NotExist);
                return;
            }

            //登录成功
            session.IsLogin = true;
            session.Send(defMainCommand, defSecondCommand,
                player.JsonSerialize());
        }
    }
}
