using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTron_Mobile
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int InstituteID { get; set; }
        public string Email { get; set; }

        public User(string Nev,string Jelszo,string email, int OM_Azonosito)
        {
            Name = Nev;
            Password = Jelszo;
            Email = email;
            InstituteID = OM_Azonosito;

        }
        public User(bool IsGuest)
        {
            Name = "user_"+rnd();
        }


        public User()
        {

        }

        private string rnd()
        {
            string szamsor = "";
            for (int i = 0; i < 3; i++)
            {
                szamsor += new Random().ToString();
            }
            return szamsor;
        }
    }
}
