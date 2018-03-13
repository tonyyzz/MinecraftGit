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
			string redisKey = RedisKeyHelper.GetRedisKeyName(RedisKeyConfig.Playerbasis, playerId.ToString());
			var cacheModel = redisHelper.StringGet<PlayerbasisModel>(redisKey);
			if (cacheModel != null)
			{
				fromCache = true;
				return cacheModel;
			}
			else
			{
				var model = new PlayerbasisModel();
				model = GetSingleOrDefault(model, new KeyValue<int> { Key = nameof(model.PlayerId), Value = playerId });
				redisHelper.StringSet(redisKey, model, CommonConfig.DefRedisExpiry);
				return model;
			}
		}

		public static bool Update(PlayerbasisModel model)
		{
			string redisKey = RedisKeyHelper.GetRedisKeyName(RedisKeyConfig.Playerbasis, model.PlayerId.ToString());
			redisHelper.StringSet(redisKey, model, CommonConfig.DefRedisExpiry);
			return Update(model, nameof(model.PlayerId));
		}
	}
}
