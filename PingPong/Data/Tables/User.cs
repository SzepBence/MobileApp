using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTron.Data.Tables
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime EntryDate { get; set; }

        public User(string Nev, string Jelszo)
        {
            Name = Nev;
            Password = Jelszo;
            EntryDate = DateTime.Now;
        }

    }
}
