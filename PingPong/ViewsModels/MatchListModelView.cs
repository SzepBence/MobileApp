using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTron.Data.Tables;

namespace EduTron.ViewsModels
{
    public class MatchListModelView
    {
        public ObservableCollection<User> eredmenyek { get; set; }
        public MatchListModelView()
        {
            eredmenyek = new ObservableCollection<User>();
        }

        public void init()
        {
            test = App.Database.GetAllTestData();
        }

    }
}
