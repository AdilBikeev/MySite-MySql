using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySite.Properties;

namespace MySite.Models
{
    public class Users
    {
        #region Закрытые поля
            int id;
            string login;
            string password;
            string email;
            string name;
            string surname;
            string dateBirthDay;
            string aboutOneself;
            int sharp;
        #endregion


        #region Свойства для организации доступа к закрытым полям
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string LOGIN
        {
            get { return login; }
            set { login = value; }
        }

        public string PASSWORD
        {
            get { return password; }
            set { password = value; }
        }

        public string EMAIL
        {
            get { return email; }
            set { email = value; }
        }

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        public string SURNAME
        {
            get { return surname; }
            set { surname = value; }
        }

        public string DATEBIRTHDAY
        {
            get { return dateBirthDay; }
            set { dateBirthDay = value; }
        }

        public string ABOUTONESELF
        {
            get { return aboutOneself; }
            set { aboutOneself = value; }
        }

        public int SHARP
        {
            get { return sharp; }
            set { sharp = value; }
        }
        #endregion

        public Users()
        {

        }

        public Users(int id,string login,string password, string email, string name, string surname, string dateBirthDay, string aboutOneSelf, int sharp)
        {
            ID = id;
            LOGIN = login;
            PASSWORD = password;
            EMAIL = email;
            NAME = name;
            SURNAME = surname;
            DATEBIRTHDAY = dateBirthDay;
            ABOUTONESELF = aboutOneSelf;
            SHARP = sharp;
        }

        public static List<Users> Load()//загружает даные из БД и возвращает их в list
        {
            List<Users> Users = new List<Users>(); 
            MySqlConnection conn = new MySqlConnection(Settings.Default.connString);
            conn.Open();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT *FROM USERS", conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//считываем строки таблицы
                {
                    Users.Add(new Users(Convert.ToInt32(reader[0].ToString()),reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), Convert.ToInt32(reader[8].ToString())));
                }
            }catch(Exception exc)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return Users;
        }

        public static void SaveChanges(Users user)//Обновляет инф. о пользователе
        {
            List<Users> Users = new List<Users>();
            MySqlConnection conn = new MySqlConnection(Settings.Default.connString);
            conn.Open();
            try
            {
                string sql = "UPDATE Users " +
                    "set " +
                    "name = "+user.NAME + "," +
                    "surname = " + user.SURNAME + "," +
                    "dateBirthDay = " + user.DATEBIRTHDAY + "," +
                    "aboutOneSelf = " + user.ABOUTONESELF + "," +
                    "sharp = " + user.SHARP  +
                    " WHERE id = " + user.ID + ";";
                MySqlCommand command = new MySqlCommand(sql, conn);
                
                command.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                conn.Close();
            }
        }

        public static void Add(Users user)//добавляет нового пользователя в базу данных
        {
            MySqlConnection conn = new MySqlConnection(Settings.Default.connString);
            conn.Open();
            try
            {
                string sql = "INSERT INTO (Login, Password, Email, Name, Surname, DateBirthDay, AboutOneSelf, Sharp) VALUES " +
                     "(" +
                         user.LOGIN + "" +
                         user.PASSWORD + "" +
                         user.EMAIL + "" +
                         user.NAME + "" +
                         user.SURNAME + "" +
                         user.DATEBIRTHDAY + "" +
                         user.ABOUTONESELF + "" +
                         user.SHARP + "" +
                     ");";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }catch(Exception exc)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}