using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    class Program
    {
        private static String myStr = "abcd";
        private Boolean isRunning = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
           
        }

        void Classtest()
        {
            Game game = new Game("game title", DateTime.Now);
            Console.WriteLine(game.Display());

            Account account = new Account(1000);
            Account account1 = new Account(1500);
            Account account2 = new Account(2000);
            Console.WriteLine(account.getBalance());

            account.Withdraw(500);
            Console.WriteLine(account.getBalance());

            account.Deposit(1000);
            Console.WriteLine(account.getBalance());

            List<Account> accounts = new List<Account>();
            accounts.Add(account);
            accounts.Add(account1);
            accounts.Add(account2);


            int total = 0;
            foreach (Account a in accounts)
            {
                a.Withdraw(500);
                Console.WriteLine(a.getBalance());

                a.Deposit(1000);
                Console.WriteLine(account.getBalance());
                total += account.Balance;
            }

            Console.WriteLine(String.Format("total are {0} accounts and total balance is {1}", accounts.Count, total));

        }

        void DB()
        {
            string connectionString = @"server=159.65.173.30;userid=ucareer;password=LSnWpGKencRi8Xj5Ar4=;database=computerFactory_master";
            using var con = new MySqlConnection(connectionString);
            con.Open();
            Console.WriteLine($"MySQL version : {con.ServerVersion}");

            Console.WriteLine($"MySQL select head tables");
            string query = "select * from head";
            using var cmd = new MySqlCommand(query, con);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            Console.WriteLine("id\t label");
            while (dataReader.Read())
            {
                Console.WriteLine(String.Format("{0}\t {1}", dataReader["id"], dataReader["label"]));
            }
            dataReader.Close();


            Console.WriteLine($"MySQL insert a record to head");
            query = "insert into head set label = @label, description = @description, image_url = @imageURL ";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("label", "head test");
            cmd.Parameters.AddWithValue("description", "head desc test");
            cmd.Parameters.AddWithValue("imageURL", "http://example.com");
            cmd.Prepare();
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(String.Format("number of rows updated {0} , insert id is {1}", result.ToString(), cmd.LastInsertedId.ToString()));


            long id = cmd.LastInsertedId;
            Console.WriteLine($"MySQL get one record");
            cmd.CommandText = "select * from head where id = @id";
            cmd.Parameters.AddWithValue("id", id);
            dataReader = cmd.ExecuteReader();
            if (!dataReader.Read())
            {
                Console.WriteLine("no record found");
            }
            else
            {
                Console.WriteLine(String.Format("{0}\t {1}", dataReader["id"], dataReader["label"]));
            }
            dataReader.Close();

            Console.WriteLine($"MySQL get one record");
            cmd.Parameters.Clear();
            cmd.CommandText = "update head set label = @label where id = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("label", "updated label");
            int updated = cmd.ExecuteNonQuery();
            Console.WriteLine(String.Format("number of rows updated {0}", updated.ToString()));


            Console.WriteLine($"MySQL get one record");
            cmd.Parameters.Clear();
            cmd.CommandText = "update head set label = @label where label = 'name'";
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("label", "updated label");
            int updated2 = cmd.ExecuteNonQuery(); // 1, 0 , expection
            Console.WriteLine(String.Format("number of rows updated {0}", updated2.ToString()));

            Console.WriteLine($"MySQL delete one record");
            cmd.Parameters.Clear();
            cmd.CommandText = "delete from head where id = " + id.ToString();
            int updated3 = cmd.ExecuteNonQuery(); // 1, 0 , expection
            Console.WriteLine(String.Format("number of rows deleted {0}", updated3.ToString()));

            Console.WriteLine($"MySQL get one field");
            cmd.Parameters.Clear();
            cmd.CommandText = "select label from head where id = 2";
            var updated4 = cmd.ExecuteScalar(); // 1, 0 , expection
            Console.WriteLine(String.Format("get one field {0}", updated4.ToString()));


            Console.WriteLine("join examples");
            cmd.Parameters.Clear();
            query = "select u.username, h.label  from head h, user u, landing l where l.head_id = h.id and u.landing_id = l.id";
            cmd.CommandText = query;
            dataReader = cmd.ExecuteReader();
            Console.WriteLine("username\t label");
            while (dataReader.Read())
            {
                Console.WriteLine(String.Format("{0}\t {1}", dataReader.GetString(0), dataReader["label"]));
            }
            dataReader.Close();

            con.Close();
        }

        void Run()
        {
            Console.WriteLine(this.isRunning);
        }

        void ScopeDemo()
        {
            String str = "abc";
            if (str.Contains("abc"))
            {
                String str1 = "test";
            }
            else
            {
                string str2 = "test2";
            }
            Console.WriteLine(Program.myStr);
        }

        void DataType()
        {
            bool varBool = true;
            int id = 123;
            float price = 12.00f;
            double price1 = 12.00d;
            string str = "my str"; //When using methods which changes a string, the actual string is not changed - a new string is returned instead.
            char a = 'a'; //only single quote and single character
        }

        void Comment()
        {
            //single line comment
            /** 
                document comment
             */
            /*
             multiple line comment
             */
        }

        void Conditions()
        {
            int number;

            Console.WriteLine("Please enter a number between 0 and 10:");
            number = int.Parse(Console.ReadLine());

            if (number > 10)
                Console.WriteLine("The number should be 10 or less!");
            else if (number < 0)
                Console.WriteLine("The number should be 0 or more!");
            else
                Console.WriteLine("You entered" + number.ToString());


            Console.WriteLine("Please enter a number between 0 and 10:");
            if(number >10 || number < 0)
            {
                Console.WriteLine("The number should be 0 to 10!");
            }
            else
            {
                Console.WriteLine("You entered" + number.ToString());
            }
        }

        void WhileLoop()
        {
            int number = 0;

            while (number < 5)
            {
                Console.WriteLine(number);
                number = number + 1;
            }

            Console.ReadLine();
        }

        void ForLoop()
        {
            int number = 5;
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(i);
            }
        }

        void ForeachLoop()
        {
            ArrayList list = new ArrayList();
            list.Add("name1");
            list.Add("中文");
            list.Add("Someone Else");

            foreach (string name in list)
            {
                Console.WriteLine(name);
            }
        }
    }
}
