using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySite.Properties;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySite.Models
{
    public class Sharp
    {
        int numAnswer;
        int id;

        public int NUMANSWER
        {
            get { return numAnswer; }
            set { numAnswer = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value;}
        }

        public Sharp(int id, int numAnswer)
        {
            NUMANSWER = numAnswer;
            ID = id;
        }

        public static List<Sharp> Load()//загружает даные из БД и возвращает их в list
        {
            List<Sharp> Sharp = new List<Sharp>();
            MySqlConnection conn = new MySqlConnection(Settings.Default.connString);
            conn.Open();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT *FROM SHARP", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())//считываем строки таблицы
                {
                    Sharp.Add(new Sharp(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString())));
                }
            }
            catch (Exception exc)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return Sharp;
        }
    }
}