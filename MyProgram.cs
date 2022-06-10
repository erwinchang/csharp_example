using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;

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
            ex01();
            //ex02();
            //ex03();
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
    }
}
