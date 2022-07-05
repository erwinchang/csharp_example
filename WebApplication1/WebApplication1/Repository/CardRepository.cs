using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    //https://igouist.github.io/post/2021/05/newbie-3-dapper/
    /// <summary>
    /// 卡片資料操作
    /// </summary>
    public class CardRepository
    {
        private readonly string _connectString = "Data Source=D:\\gitWork\\github\\web-api\\test.db;";

        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Card> GetList()
        {
            using (var conn = new SQLiteConnection(_connectString))
            {
                var result = conn.Query<Card>("SELECT * FROM Card");
                return result;
            }
        }
    }

}
