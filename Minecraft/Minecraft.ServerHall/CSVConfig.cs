using GoStop.BaseCommon;
using Minecraft.Model.csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall
{
	public class CSVConfig
	{
		/// <summary>
		/// 家具
		/// </summary>
		public static List<Mod_Furniture> furnitureList = new List<Mod_Furniture>();
		/// <summary>
		/// 物品
		/// </summary>
		public static List<Mod_Items> itemsList = new List<Mod_Items>();

		private static string folderName = "csvfile";
		public static void Install()
		{
			CsvHelper.Install(Path.Combine(folderName, "Mod_Furniture.csv"), out furnitureList);
			CsvHelper.Install(Path.Combine(folderName, "Mod_Items.csv"), out itemsList);
		}
	}
}
