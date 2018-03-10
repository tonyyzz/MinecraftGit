namespace Minecraft.Model.ReqResp
{
	/// <summary>
	/// 响应实体基类
	/// </summary>
	public class BaseResp
	{
		public BaseResp()
		{
			RespLevel = RespLevelEnum.Success;
			Msg = "";
		}

		/// <summary>
		/// 响应消息级别
		/// </summary>
		public RespLevelEnum RespLevel { get; set; }
		/// <summary>
		/// 消息文本
		/// </summary>
		public string Msg { get; set; }
	}
	/// <summary>
	/// 响应消息级别
	/// </summary>
	public enum RespLevelEnum
	{
		/// <summary>
		/// 响应成功
		/// </summary>
		Success = 1,
		/// <summary>
		/// 响应警告
		/// </summary>
		Warn,
		/// <summary>
		/// 响应错误
		/// </summary>
		Error,
	}
}
