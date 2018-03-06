using Minecraft.CacheRedis;
using Minecraft.Config;
using Minecraft.DALMySql;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL.mysql
{
	public class PlayerbasisBLL : BaseBLL
	{
		private static RedisHelper redisHelper = new RedisHelper();
		public static PlayerbasisModel GetSingleOrDefault(int playerId, out bool fromCache)
		{
			fromCache = false;
			var cacheModel = redisHelper.StringGet<PlayerbasisModel>(RedisKeyConfig.PlayerInfo + playerId);
			if (cacheModel != null)
			{
				fromCache = true;
				return cacheModel;
			}
			else
			{
				var model = new PlayerbasisModel();
				model = BaseDAL.GetSingleOrDefault(model, (nameof(model.PlayerId), playerId));
				redisHelper.StringSet(RedisKeyConfig.PlayerInfo + playerId, model, CommonConfig.DefRedisExpiry);
				return model;
			}
		}

		/// <summary>
		/// 更新实体
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <param name="keyNames"></param>
		public static void Update<T>(T model, params string[] keyNames) where T : class
		{
			if (model == null)
			{
				return;
			}
			if (keyNames == null || !keyNames.Any())
			{
				throw new ArgumentException("参数不能为空或者列表元素个数不能为零");
			}
			var props = model.GetAllPropKeys(keyNames.ToList());
			string sql = $"";
		}
	}
}
