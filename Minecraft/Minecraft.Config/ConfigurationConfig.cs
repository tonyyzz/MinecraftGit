using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
    public static class ConfigurationConfig
    {
        public static string Minecraft_MySqlDBConnStr = ConfigurationManager.ConnectionStrings["Minecraft_MySql"].ToString();
        public static string Minecraft_MongoDBConnStr = ConfigurationManager.ConnectionStrings["Minecraft_MongoDB"].ToString();
        public static string Minecraft_MongoDBName = ConfigurationManager.AppSettings["Minecraft_MongoDBName"].ToString();
    }
}
