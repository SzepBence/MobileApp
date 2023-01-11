
using EduTron_Mobile;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTron_Mobile
{
    public class Database
    {
        readonly SQLiteAsyncConnection connection;
        public Database(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<Answer>().Wait();
            connection.CreateTableAsync<User>().Wait();
            connection.CreateTableAsync<Question>().Wait();
            connection.CreateTableAsync<Test>().Wait();
        }

        public bool DeleteTestData(Test kivalasztott)
        {
            return connection.DeleteAsync(kivalasztott).Result == 1 ? true : false;
        }

        public ObservableCollection<Test> GetAllTestData()
        {
            ObservableCollection<Test> obs = new ObservableCollection<Test>();
            List<Test> list = connection.Table<Test>().ToListAsync().Result;
            list.ForEach(x => obs.Add(x));
            return obs;
        }

        public Task<int> SaveTestData(Test teszt)
        {
            return connection.InsertAsync(teszt);
        }

        public Test GetLast()
        {
            return connection.Table<Test>().OrderByDescending(x => x.CreatedDate).FirstAsync().Result;
        }


    }
}
