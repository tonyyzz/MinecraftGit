using Minecraft.CacheRedis;
using Minecraft.Config;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL.mysql
{
	public class AtlasScheduleBLL : BaseBLL
	{
		private static RedisSingleCacheHelper redisCacheHelper = new RedisSingleCacheHelper();
		public static bool InsertSuccess(AtlasscheduleModel model)
		{
			string redisKey = RedisKeyHelper.GetRedisKeyName(RedisKeyConfig.AtlasSchedule, model.PlayerId.ToString());
			redisCacheHelper.StringSet(redisKey, model, CommonConfig.DefRedisExpiry);
			return BaseBLL.InsertSuccess(model);
		}

		public static AtlasscheduleModel GetSingleOrDefault(int playerId, out bool fromCache)
		{
			fromCache = false;
			string redisKey = RedisKeyHelper.GetRedisKeyName(RedisKeyConfig.AtlasSchedule, playerId.ToString());
			var cacheModel = redisCacheHelper.StringGet<AtlasscheduleModel>(redisKey);
			if (cacheModel != null)
			{
				fromCache = true;
				return cacheModel;
			}
			else
			{
				var model = new AtlasscheduleModel();
				model = GetSingleOrDefault(model, new KeyValue<int> { Key = nameof(model.PlayerId), Value = playerId });
				redisCacheHelper.StringSet(redisKey, model, CommonConfig.DefRedisExpiry);
				return model;
			}
		}
	}
}
