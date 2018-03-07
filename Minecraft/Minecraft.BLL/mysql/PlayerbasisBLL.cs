using Minecraft.CacheRedis;
using Minecraft.Config;
using Minecraft.DALMySql;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Minecraft.BLL.mysql
{
	public class PlayerbasisBLL : BaseBLL
	{
		private static RedisHelper redisHelper = new RedisHelper();
		public static PlayerbasisModel GetSingleOrDefault(int playerId, out bool fromCache)
		{
			fromCache = false;
			var cacheModel = redisHelper.StringGet<PlayerbasisModel>(RedisKeyConfig.Playerbasis + playerId);
			if (cacheModel != null)
			{
				fromCache = true;
				return cacheModel;
			}
			else
			{
				var model = new PlayerbasisModel();
				model = GetSingleOrDefault(model, (nameof(model.PlayerId), playerId));
				redisHelper.StringSet(RedisKeyConfig.Playerbasis + playerId, model, CommonConfig.DefRedisExpiry);
				return model;
			}
		}

		public static bool Update(PlayerbasisModel model)
		{
			redisHelper.StringSet(RedisKeyConfig.Playerbasis + model.PlayerId, model, CommonConfig.DefRedisExpiry);
			return Update(model, nameof(model.PlayerId));
		}
	}
}
