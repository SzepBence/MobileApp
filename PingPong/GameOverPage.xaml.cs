using EduTron.Data.Tables;

namespace EduTron;

public partial class GameOverPage : ContentPage
{
	public GameOverPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		User utolso = App.Database.GetLastMatch();
		eredmenyLbl.Text = $"{utolso.ElsoJatekosPont} - {utolso.MasodikJatekosPont}";
		gyoztesLbl.Text = $"Gyõztes:\n{(utolso.ElsoJatekosPont > utolso.MasodikJatekosPont ? utolso.ElsoJatekosNev : utolso.MasodikJatekosNev)}";
	}

	private void QuitBtn_Clicked(object sender, EventArgs e)
	{
		Application.Current.Quit();
	}

	private async void NewGame_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync();
	}


}