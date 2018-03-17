using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RedisTools
{
    public class HashOperator : RedisOperatorBase
    {
        public HashOperator() : base() { }
        public bool Exist<T>(string hashId, string key)
        {
            return Redis.HashContainsEntry(hashId, key);
        }

        public bool Set<T>(string hashId, string key, T t)
        {
            var jsonResult = ServiceStack.Text.JsonSerializer.SerializeToString(t);
            return Redis.SetEntryInHash(hashId, key, jsonResult);
        }

        public bool Remove(string hashId, string key)
        {

            return Redis.RemoveEntryFromHash(hashId, key);
        }

        public bool Remove(string hashId)
        {

            return Redis.Remove(hashId);
        }

        public T Get<T>(string hashId, string key)
        {
            var tempModel = Redis.GetValueFromHash(hashId, key);
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(tempModel);
        }

        public List<T> GetAll<T>(string hashId)
        {

            var list = new List<T>();
            var values = Redis.GetValuesFromHash(hashId);
            values.ForEach(c =>
            {
                var jsonResult = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(c);
                list.Add(jsonResult);
            });
            return list;
        }

        public void SetExpire(string key, DateTime datetime)
        {
            Redis.ExpireEntryAt(key, datetime);
        }
    }
}
