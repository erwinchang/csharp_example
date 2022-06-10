using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace csharp_example
{
    class MyProgram2
    {
    }
    public class Example2
    {
        //https://www.ruyut.com/2021/12/sqlite-crud.html
        public void Main()
        {
            //CreateDatabaseFile();
            //Insert("Jack");
            //Insert("Joe");
            //Read();
            Update(2, "Steven");
        }
        private string _connectionString = "Data Source=db.db;";
        private void CreateDatabaseFile()
        {
            Debug.WriteLine("CreateDatabaseFile");
            if (File.Exists("db.db")) return;

            //SqliteConnection => 是Microsoft.Data.Sqlite.Core 套件
            //https://docs.microsoft.com/zh-tw/dotnet/standard/data/sqlite/custom-versions?tabs=netcore-cli
            //這邊採用System.Data.SQLite要改為SQLiteConnection
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"CREATE TABLE users (
                        id INTEGER,
                        user_name  TEXT NOT NULL UNIQUE,
                        PRIMARY KEY(id AUTOINCREMENT)
                    );";
                command.ExecuteNonQuery();
            }
        }

        private void Insert(string userName)
        {
            Debug.WriteLine("Insert");
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"  INSERT INTO users (user_name)
                            values ($userName);
                            select last_insert_rowid();";
                command.Parameters.AddWithValue("$userName", userName);
                int id = Convert.ToInt32((object)command.ExecuteScalar());
                Debug.WriteLine($"\tid = {id}, userName = {userName}");
            }
        }
        private void Read()
        {
            Debug.WriteLine("Read");
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"  select * from users";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        Debug.WriteLine($"\tid = {id}, name = {name}");
                    }
                }
            }
        }
        private void Update(int id, string userName)
        {
            Debug.WriteLine("Update");
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"  UPDATE users
                            SET user_name= $userName
                        WHERE id = $id;";
                command.Parameters.AddWithValue("$userName", userName);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
