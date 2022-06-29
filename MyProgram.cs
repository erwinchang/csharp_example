using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using System.Data;

namespace csharp_example
{
    public class Cutomer
    {
        public string CustomerID { get; set; }
        public string CompanName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }

    public class Users
    {
        public int id;
        public string user_name;
    }
    public class MyProgram
    {
        public void Main()
        {
            Console.WriteLine("Example ..");
            //ex01();
            //ex02();
            //ex03();
            //ex04();
            //ex05();
            ex06();
        }

        //https://www.tpisoftware.com/tpu/articleDetails/1046
        public void ex01()
        {
            string strConnection = "Data Source=db.db;";
            using (SQLiteConnection conn = new SQLiteConnection(strConnection))
            {
                conn.Open();
                string sql = "select * from Customers";
                var customers = conn.Query<Cutomer>(sql);

                foreach (var cust in customers)
                {
                    Console.WriteLine($"{cust.CustomerID},{cust.CompanName},{cust.Address},{cust.City},{cust.Phone}");
                }
            }
            Console.ReadLine();
        }
        public void ex02()
        {
            string strConnection = "Data Source=db.db;";
            using (SQLiteConnection conn = new SQLiteConnection(strConnection))
            {
                conn.Open();
                string sql = "select * from Customers";
                var customers = conn.Query(sql);

                foreach (var cust in customers)
                {
                    Console.WriteLine($"{cust.CustomerID},{cust.CompanName},{cust.Address},{cust.Citys},{cust.Phone}");
                }
            }
            Console.ReadLine();
        }
        public void ex03()
        {
            string strConnection = "Data Source=db.db;";
            using (SQLiteConnection conn = new SQLiteConnection(strConnection))
            {
                conn.Open();
                string sql = "select * from Customers where City in @Cities";
                var parameters = new
                {
                    Cities = new[] { "City01"}
                };
                var customers = conn.Query(sql, parameters);

                foreach (var cust in customers)
                {
                    Console.WriteLine($"{cust.CustomerID},{cust.CompanName},{cust.Address},{cust.Citys},{cust.Phone}");
                }
            }
            Console.ReadLine();
        }
        public void ex04()
        {
            string strConnection = "Data Source=db.db;";
            using (SQLiteConnection conn = new SQLiteConnection(strConnection))
            {
                conn.Open();
                string sql = "select * from Customers";
                var customers = conn.QueryFirstOrDefault(sql);
            }
            Console.ReadLine();
        }
        public void ex05()
        {
            string strConnection = "Data Source=db.db;";
            using (SQLiteConnection conn = new SQLiteConnection(strConnection))
            {
                conn.Open();
                string sql = "select * from Customers; select * from users";
                using (var results = conn.QueryMultiple(sql))
                {
                    var customers = results.Read().ToList();
                    var users = results.Read().ToList();
                }
            }
            Console.ReadLine();
        }

        public void ex06()
        {
            string strConnection = "Data Source=db.db;";
            using (SQLiteConnection conn = new SQLiteConnection(strConnection))
            {
                conn.Open();
                //string sql = "select * from Customers; select * from users";
                //var results = conn.Query("spGetUser", new { Id = 1 }, commandType: CommandType.StoredProcedure);
                var p = new DynamicParameters();
                p.Add("@a", 11);
                p.Add("@b", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@c", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                conn.Execute("spMagicProc", p, commandType: CommandType.StoredProcedure);
                int b = p.Get<int>("@b");
                int c = p.Get<int>("@c");
            }
            Console.ReadLine();
        }
    }
}
