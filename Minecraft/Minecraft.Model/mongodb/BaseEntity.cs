using System;
using System.Collections.Generic;
using System.Text;

namespace Minecraft.Model
{
	public abstract class BaseEntity
	{
		//public ObjectId Id { get; set; }
		public string Id { get; set; }

		//public string State { get; set; }

		public string CreateTime { get; set; }

		public string UpdateTime { get; set; }
	}
}
