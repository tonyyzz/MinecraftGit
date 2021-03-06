﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using Minecraft.Config;
using Minecraft.Model;
using System.Text.RegularExpressions;

namespace Minecraft.DALMongoDb
{

	public class MgDb
	{
		private static readonly string connStr = JsonConfig.Value.MongoDB.ConnectionString;// MinecraftConfiguration.Minecraft_MongoDBConnStr;
		private static readonly string dbName = JsonConfig.Value.MongoDB.DBName;// MinecraftConfiguration.Minecraft_MongoDBName;


		private static IMongoDatabase db = null;

		private static readonly object lockHelper = new object();

		private MgDb() { }

		public static IMongoDatabase GetDb()
		{
			if (db == null)
			{
				lock (lockHelper)
				{
					if (db == null)
					{
						Match match = Regex.Match(connStr, @"((\d+\.){3}\d+)\:(\d+)");
						if (!match.Success)
						{
							throw new Exception("mongodb连接字符串匹配错误");
						}
						var host = match.Groups[1].Value;
						var port = Convert.ToInt32(match.Groups[3].Value);
						var timeoutTimeSpan = new TimeSpan(0, 0, 3);
						var client = new MongoClient(new MongoClientSettings()
						{
							ConnectTimeout = timeoutTimeSpan,
							SocketTimeout = timeoutTimeSpan,
							ServerSelectionTimeout = timeoutTimeSpan, //真正的连接超时，上面两个不起作用
							Server = new MongoServerAddress(host, port)
						});
						db = client.GetDatabase(dbName);

					}
				}
			}
			return db;
		}
	}

	public class MgHelper<T> where T : BaseEntity
	{
		private IMongoDatabase db = null;
		private IMongoCollection<T> collection = null;

		public MgHelper()
		{
			db = MgDb.GetDb();
			collection = db.GetCollection<T>(typeof(T).Name);
		}

		/// <summary>
		/// 插入
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public T Insert(T entity)
		{
			var flag = ObjectId.GenerateNewId();
			entity.GetType().GetProperty("Id").SetValue(entity, flag.ToString());
			//entity.State = "y";
			entity.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			entity.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

			//collection.InsertOneAsync(entity);
			collection.InsertOne(entity);
			return entity;
		}

		/// <summary>
		/// 修改实体中的字段值
		/// </summary>
		/// <param name="id"></param>
		/// <param name="field"></param>
		/// <param name="value"></param>
		public void Modify(string id, string field, string value)
		{
			var filter = Builders<T>.Filter.Eq("Id", ObjectId.Parse(id));
			var updated = Builders<T>.Update.Set(field, value);
			//UpdateResult result = collection.UpdateOneAsync(filter, updated).Result;
			UpdateResult result = collection.UpdateOne(filter, updated);
		}

		/// <summary>
		/// 查找一个
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public T QueryOne(string id)
		{
			return collection.Find(a => a.Id == id).ToList().FirstOrDefault();
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="id"></param>
		public void Delete(string id)
		{
			var filter = Builders<T>.Filter.Eq("Id", ObjectId.Parse(id));
			//collection.DeleteOneAsync(filter);
			collection.DeleteOne(filter);
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="entity"></param>
		public void Delete(T entity)
		{
			var filter = Builders<T>.Filter.Eq("Id", entity.Id);
			//collection.DeleteOneAsync(filter);
			collection.DeleteOne(filter);
		}
		//public List<T> QueryAll()
		//{
		//	return collection.Find(a => a.State.Equals("y")).ToList();
		//}

		/// <summary>
		/// 查找所有
		/// </summary>
		/// <returns></returns>
		public List<T> QueryAll()
		{
			//查找时，字段要一一对应，Model中不能缺少字段
			return collection.Find(a => true).ToList();
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="entity"></param>
		public void Update(T entity)
		{
			var old = collection.Find(e => e.Id.Equals(entity.Id)).ToList().FirstOrDefault();

			foreach (var prop in entity.GetType().GetProperties())
			{
				var newValue = prop.GetValue(entity);
				var oldValue = old.GetType().GetProperty(prop.Name).GetValue(old);
				if (newValue != null)
				{
					if (!newValue.ToString().Equals(oldValue.ToString()))
					{
						old.GetType().GetProperty(prop.Name).SetValue(old, newValue.ToString());
					}
				}
			}
			old.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

			var filter = Builders<T>.Filter.Eq("Id", entity.Id);
			//ReplaceOneResult result = collection.ReplaceOneAsync(filter, old).Result;
			ReplaceOneResult result = collection.ReplaceOne(filter, old);
		}






		/// <summary>
		/// 删除表
		/// </summary>
		/// <param name="entity"></param>
		public void Drop()
		{
			db.DropCollection(typeof(T).Name);
		}


	}
}

