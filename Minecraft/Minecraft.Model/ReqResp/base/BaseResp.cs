namespace Minecraft.Model.ReqResp
{
	/// <summary>
	/// 响应实体基类
	/// 注意：
	/// 1、所有的请求响应实体的属性不能有getset，直接用分号结束就好，不然前端不能序列化
	////2、所有嵌套实体要加上[System.Serializable]标签，保证与客户端反序列化兼容
	/// </summary>
	[System.Serializable]
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
		public RespLevelEnum RespLevel;
		/// <summary>
		/// 消息文本
		/// </summary>
		public string Msg;
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
