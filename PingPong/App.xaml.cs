using EduTron.Data;
using System.Collections.ObjectModel;

namespace EduTron;

public partial class App : Application
{

    static Database database;
	public static Database Database
	{
		get
		{
			if(database == null)
			{
				database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EduTron.db3"));
			}
			return	database; 
		}
	}
	public App()
	{
		InitializeComponent();
		Application.Current.UserAppTheme = AppTheme.Light;
		MainPage = new NavigationPage(new MainPage());
	}
}
