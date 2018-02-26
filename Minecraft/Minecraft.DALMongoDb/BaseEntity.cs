using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketSdy.MongoStdy45
{
	public abstract class BaseEntity
	 {
		 public ObjectId Id { get; set; }
 
		 //public string State { get; set; }
 
		 public string CreateTime { get; set; }
 
		 public string UpdateTime { get; set; }
	 }
}
