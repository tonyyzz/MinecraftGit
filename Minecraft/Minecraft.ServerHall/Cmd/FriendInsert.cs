﻿using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Config.Memory;
using Minecraft.Model;
using Minecraft.Model.ReqResp;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;

namespace Minecraft.ServerHall.Cmd
{
	public class FriendInsert : CommandBase<MinecraftSession, StringRequestInfo>
	{
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defCommand);
			}
		}

		private EnumCommand defCommand = EnumCommand.Friend_FriendInsert;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			if (!session.minecraftSessionInfo.IsLogin)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "未登录" });
				return;
			}
			var req = requestInfo.GetRequestObj<FriendInsertReq>(session);
			if (req == null || req.FriendId <= 0)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "参数错误" });
				return;
			}
			FriendModel friendModel = new FriendModel
			{
				PlayerId = session.minecraftSessionInfo.player.PlayerId,
				FriendId = req.FriendId,
				AddTime = DateTime.Now,
			};

			var flag = FriendBLL.InsertSuccessForSplitTable(friendModel, MemorySystemManager.friendTableNameCacheList);
			if (!flag)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "friend分表插入操作失败" });
				return;
			}


			var resp = new FriendInsertResp
			{
				PlayerId = friendModel.PlayerId,
				FriendId = friendModel.FriendId,
			};
			session.Send(defCommand, resp);
		}
	}
}
