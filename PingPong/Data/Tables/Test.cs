using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTron.Data.Tables
{
    public class Test
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public int Name { get; set; }
        public string Category { get; set; }
        public string SolvingCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Question> Questions { get; set; }
        public bool IsCompleted { get; set; }
        public Test()
        {
            CreatedDate = DateTime.Now;
        }
    }

}
