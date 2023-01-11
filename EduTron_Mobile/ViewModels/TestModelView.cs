using EduTron_Mobile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTron.ViewsModels
{
    public class TestModelView
    {
        public ObservableCollection<Test> results { get; set; }
        public TestModelView()
        {
            results = new ObservableCollection<Test>();
        }

        public void init()
        {
            results = App.Database.GetAllTestData();
        }

    }
}
