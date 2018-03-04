using Minecraft.Config;
using Minecraft.Model.ReqResp;
using Minecraft.Model.ReqResp.Heart;
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
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
			}
		}

		private MainCommand defMainCommand = MainCommand.Heart;
		private SecondCommand defSecondCommand = SecondCommand.Heart_HeartData;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			var req = requestInfo.GetRequestObj<HeartDataReq>(session);
			if (req == null || req.StrEncrypted.IsNullOrWhiteSpace())
			{
				return;
			}
			string deStr = "";
			try
			{
				deStr = CustomEncrypt.Decrypt(req.StrEncrypted, "server_heartData");
			}
			catch (FormatException ex)
			{
				session.Logger.Fatal("server_heartData: FormatException  " + ex.Message);
				return;
			}
			catch (Exception ex)
			{
				session.Logger.Fatal("server_heartData: Exception  " + ex.Message);
				return;
			}
			if (deStr.IsNullOrWhiteSpace())
			{
				return;
			}
			var strs = deStr.Split(new String[] { " " }, StringSplitOptions.None);
			if (strs.Count() != 2)
			{
				return;
			}
			if (strs[0] != MinecraftConfiguration.HeartDataReqSecretKey)
			{
				return;
			}
			if (!long.TryParse(strs[1], out long ticks))
			{
				return;
			}
			if (ticks <= 0)
			{
				return;
			}
			DateTime time = new DateTime(ticks);
			var subMinuts = Convert.ToInt32(Math.Abs((DateTime.Now - time).TotalMinutes));
			var HeartDataReqTimeFrameInt = Convert.ToInt32(MinecraftConfiguration.HeartDataReqTimeFrame);
			if (subMinuts > HeartDataReqTimeFrameInt)
			{
				return;
			}
			//心跳包合法
			session.Send(defMainCommand, defSecondCommand, new MsgResp(MsgLevelEnum.Info, "心跳包"));
		}
	}
}
