using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Net.Configuration;
using System.Xml.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
namespace ConsoleApp1
{
    class FruitOrVegetables
    {
        internal class Program
        {

            static void Main(string[] args)
            {
                FruitOrVegetables f = new FruitOrVegetables();
                Console.WriteLine("1 - ");
                f.Q1();
                Console.WriteLine("2 - ");
                f.Q2();
                Console.WriteLine("3 - ");
                f.Q3();
                Console.WriteLine("4 - ");
                f.Q4();
                Console.WriteLine("5 - ");
                f.Q5();
                Console.WriteLine("6 - ");
                f.Q6();
                Console.WriteLine("7 - ");
                f.Q7();
                Console.WriteLine("8 - ");
                f.Q8();
                Console.WriteLine("9 - ");
                f.Q9("red");
                Console.WriteLine("10 - ");
                f.Q10();
                Console.WriteLine("11 - ");
                f.Q11(10f);
                Console.WriteLine("12 - ");
                f.Q12(10f);
                Console.WriteLine("13 - ");
                f.Q13(5f, 20f);
                Console.WriteLine("14 - ");
                f.Q14();
            }
        }
        private SqlConnection connection;
        public FruitOrVegetables()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        public void OpenConnection()
        {
            try { connection.Open(); }
            catch (Exception e) { Console.WriteLine($"Вознилка ошибка подключения: {e.Message}"); }
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            Console.WriteLine("Подключение закрыто");
        }
        public void Q1()
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "Select * from VegetablesFruits";
            using (SqlDataReader sdr = selectCommand.ExecuteReader())
            {
                if (sdr.HasRows)
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr.GetName(i) + " ");
                    }
                    Console.WriteLine();
                    while (sdr.Read())
                    {

                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            Console.Write(sdr[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                sdr.Close();
            }
            CloseConnection();
        }
        public void Q2()
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "Select Name from VegetablesFruits";
            using (SqlDataReader sdr = selectCommand.ExecuteReader())
            {
                if (sdr.HasRows)
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr.GetName(i) + " ");
                    }
                    Console.WriteLine();
                    while (sdr.Read())
                    {

                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            Console.Write(sdr[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                sdr.Close();
            }
            CloseConnection();
        }
        public void Q3()
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "Select Color from VegetablesFruits";
            using (SqlDataReader sdr = selectCommand.ExecuteReader())
            {
                if (sdr.HasRows)
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr.GetName(i) + " ");
                    }
                    Console.WriteLine();
                    while (sdr.Read())
                    {

                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            Console.Write(sdr[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                sdr.Close();
            }
            CloseConnection();
        }
        public void Q4()
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = @"Select Min(Kalories) from VegetablesFruits";
            Console.WriteLine("Min калорийность: " + selectCommand.ExecuteScalar().ToString());
            CloseConnection();
        }
        public void Q5()
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = @"Select Max(Kalories) from VegetablesFruits";
            Console.WriteLine("Max калорийность: " + selectCommand.ExecuteScalar().ToString());
            CloseConnection();
        }
        public void Q6()
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = @"Select Avg(Kalories) from VegetablesFruits";
            Console.WriteLine("Avg калорийность: " + selectCommand.ExecuteScalar().ToString());
            CloseConnection();
        }
        public void Q7()
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = @"Select count(name) from VegetablesFruits where FruitOrVegetable = 'vegetable'";
            Console.WriteLine("count овощей: " + selectCommand.ExecuteScalar().ToString());
            CloseConnection();
        }
        public void Q8()
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = @"Select count(name) from VegetablesFruits where FruitOrVegetable = 'fruit'";
            Console.WriteLine("count фруктов: " + selectCommand.ExecuteScalar().ToString());
            CloseConnection();
        }
        public void Q9(string color)
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = @"Select count(Name) from VegetablesFruits where Color = @color and FruitOrVegetable = 'fruit'";
            selectCommand.Parameters.Add("@color", System.Data.SqlDbType.NVarChar).Value = color;
            Console.WriteLine($"count фруктов цвета {color}: " + selectCommand.ExecuteScalar().ToString());
            CloseConnection();
        }
        public void Q10()
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "select count(name) as count, color as color from VegetablesFruits group by Color";
            using (SqlDataReader sdr = selectCommand.ExecuteReader())
            {
                if (sdr.HasRows)
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr.GetName(i) + " ");
                    }
                    Console.WriteLine();
                    while (sdr.Read())
                    {

                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            Console.Write(sdr[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                sdr.Close();
            }
            CloseConnection();
        }
        public void Q11(float kallories)
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "select Name from VegetablesFruits where Kalories < @callories";
            selectCommand.Parameters.Add("@callories", System.Data.SqlDbType.Float).Value = kallories;
            using (SqlDataReader sdr = selectCommand.ExecuteReader())
            {
                if (sdr.HasRows)
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr.GetName(i) + " ");
                    }
                    Console.WriteLine();
                    while (sdr.Read())
                    {

                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            Console.Write(sdr[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                sdr.Close();
            }
            CloseConnection();
        }
        public void Q12(float kallories)
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "select Name from VegetablesFruits where Kalories > @callories";
            selectCommand.Parameters.Add("@callories", System.Data.SqlDbType.Float).Value = kallories;
            using (SqlDataReader sdr = selectCommand.ExecuteReader())
            {
                if (sdr.HasRows)
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr.GetName(i) + " ");
                    }
                    Console.WriteLine();
                    while (sdr.Read())
                    {

                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            Console.Write(sdr[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                sdr.Close();
            }
            CloseConnection();
        }
        public void Q13(float range1, float range2)
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "select Name from VegetablesFruits where Kalories > @range1 and Kalories<@range2";
            selectCommand.Parameters.Add("@range1", System.Data.SqlDbType.Float).Value = range1;
            selectCommand.Parameters.Add("@range2", System.Data.SqlDbType.Float).Value = range2;
            using (SqlDataReader sdr = selectCommand.ExecuteReader())
            {
                if (sdr.HasRows)
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr.GetName(i) + " ");
                    }
                    Console.WriteLine();
                    while (sdr.Read())
                    {

                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            Console.Write(sdr[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                sdr.Close();
            }
            CloseConnection();
        }
        public void Q14()
        {
            OpenConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "select Name from VegetablesFruits where Color ='red' or color = 'yellow'";
            using (SqlDataReader sdr = selectCommand.ExecuteReader())
            {
                if (sdr.HasRows)
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr.GetName(i) + " ");
                    }
                    Console.WriteLine();
                    while (sdr.Read())
                    {

                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            Console.Write(sdr[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                sdr.Close();
            }
            CloseConnection();
        }
    }

}
