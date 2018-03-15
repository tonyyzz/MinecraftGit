using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
    public class StartCacheRedis
    {
        public static bool StartCacheRedisCheck()
        {
            bool canStart = false;
            try
            {
                using (RedisHelper redisHelper = new RedisHelper())
                {
                    //百度搜索：ServiceStack.Redis.RedisResponseException
                    //https://stackoverflow.com/questions/36436212/unexpected-reply-on-high-volume-scenario-using-servicestack-redis
                    redisHelper.FlushAll();
                    string redisKey = RedisKeyHelper.GetRedisKeyName(RedisKeyConfig.Playerbasis, 1.ToString());

                    redisHelper.StringSet(redisKey, new TestResp { PlayerId = 1 });

                    var res = redisHelper.StringGet<TestResp>(redisKey);
                }
                canStart = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("【redis】异常：" + ex.ToString());
            }
            return canStart;
        }
    }
}
