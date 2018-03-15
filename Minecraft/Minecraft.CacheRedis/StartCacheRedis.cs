using Minecraft.Config;
using Minecraft.Model.ReqResp;
using ServiceStack.Redis;
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

                    //思路：getset使用单个redis，pubsub使用redis集群

                    //直接看redis官网

                    //百度搜索：ServiceStack.Redis.RedisResponseException
                    //https://stackoverflow.com/questions/36436212/unexpected-reply-on-high-volume-scenario-using-servicestack-redis

                    //https://stackoverflow.com/questions/30223105/moved-exception-with-redis-cluster-stackexchange-redis
                    //ClusterConfiguration clusterConfiguration
                    //ClusterNode
                    //ConfigurationOptions


                    //设置哨兵  sentinel
                    //RedisSentinel

                    //▲百度搜索：redis 哨兵 主从 集群 

                    //RedisSentinelResolver
                    // SentinelInfo


                    redisHelper.FlushAll();
                    string redisKey = RedisKeyHelper.GetRedisKeyName(RedisKeyConfig.Playerbasis, 1.ToString());

                    redisHelper.StringSet(redisKey, new TestResp { PlayerId = 1 });
                }
                 //   var res = redisHelper.StringGet<TestResp>(redisKey);
                
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
