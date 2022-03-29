using SQLite;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Register.Model
{
    public  class Database
    {
        string path;
        SQLiteConnection conn;

        public Database ()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                "MyDatabase.sqlite");
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            //Create table
            conn.CreateTable<User>();
        }

        public int Register(User user) 
        {
            return conn.Insert(new User()
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
            });
        }

        public bool Login(string user, string password)
        {
            var query = conn.Table<User>().
                Where(t => t.Username == user && t.Password == user);
            if (query.Count() > 0)
                return true;
            else 
                return false;
        }
    }
}
