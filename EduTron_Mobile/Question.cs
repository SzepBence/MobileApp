using SQLite;

namespace EduTron_Mobile
{
    public class Question
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public int PhotoID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public Question()
        {

        }
    }
}