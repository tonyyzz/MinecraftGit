namespace Minecraft.Model.ReqResp
{
	/// <summary>
	/// 玩家登录请求消息体
	/// </summary>
	[System.Serializable]
	public class PlayerLoginReq : BaseReq
	{
		public int PlayerId;
	}
}
