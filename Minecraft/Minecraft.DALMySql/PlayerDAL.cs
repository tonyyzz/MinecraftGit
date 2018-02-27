using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Minecraft.Model;

namespace Minecraft.DALMySql
{
    public class PlayerDAL : BaseDAL
    {
        public static PlayerModel GetSingleOrDefault(int playerId)
        {
            using (var Conn = GetConn())
            {
                Conn.Open();
                string sql = $"select * from player where PlayerId={playerId}";
                return Conn.QueryFirstOrDefault<PlayerModel>(sql);
            }
        }
    }
}
