using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall
{
	public static class StringRequestInfoExt
	{
		/// <summary>
		/// 获取请求实体对象
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="requestInfo"></param>
		/// <returns></returns>
		public static T GetRequestObj<T>(this StringRequestInfo requestInfo,
			MinecraftSession session)
		{
			try
			{
				return  CustomEncrypt.Decrypt(requestInfo.Body,"server").JsonDeserialize<T>();
			}
			catch (FormatException ex)
			{
				session.Logger.Fatal(ex.Message);
			}
			catch (Newtonsoft.Json.JsonSerializationException ex)
			{
				session.Logger.Fatal(ex.Message);
			}
			catch (Exception ex)
			{
				session.Logger.Fatal(ex.Message);
			}
			return default(T);
		}
	}
}
