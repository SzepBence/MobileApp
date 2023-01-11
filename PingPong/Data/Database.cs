using EduTron.Data.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTron.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection connection;
        public Database(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<User>().Wait();
        }

        public bool DeleteUserData(User kivalasztott)
        {
            return connection.DeleteAsync(kivalasztott).Result == 1 ? true : false;
        }

        public ObservableCollection<User> GetAllTestData()
        {
            ObservableCollection<User> obs = new ObservableCollection<User>();
            List<User> list = connection.Table<User>().ToListAsync().Result;
            list.ForEach(x => obs.Add(x));
            return obs;
        }

        public Task<int> SaveMatchData(User match)
        {
            return connection.InsertAsync(match);
        }

        public User GetLastMatch()
        {
            return connection.Table<User>().OrderByDescending(x => x.Idopont).FirstAsync().Result;
        }


    }
}
