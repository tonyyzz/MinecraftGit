using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Minecraft.Test.TestFolder
{
	public class JsonSerializeTest
	{
		public static void Do()
		{
			string str = @"{PlayerId:1,Name:,Exp:0,PhysicalStrengthValue:0,GoldCoin:0,Human_Life:0,Human_Clean:0,Human_GoToilet:0,Human_Hunger:0,Fight_Attack:0,Fight_Defense:0,Fight_TravelRate:0,Fight_AttackSpeed:0}";
			str = Regex.Replace(str, "(:)(,)", "$1''$2");
			var playerbasisModel = str.JsonDeserialize<PlayerbasisModel>();
		}
	}
}
