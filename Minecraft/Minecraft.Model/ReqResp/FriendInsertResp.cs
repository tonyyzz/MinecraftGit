using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Model.ReqResp
{
	public class FriendInsertResp:BaseResp
	{
		public int PlayerId { get; set; }
		public int FriendId { get; set; }
	}
}
