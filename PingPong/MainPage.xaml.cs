namespace EduTron;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private async void Login_Clicked(object sender, EventArgs e)
	{
		if (!String.IsNullOrEmpty(entUser.Text) && !String.IsNullOrEmpty(entPw.Text))
		{
			await Navigation.PushAsync(new ResultPage(new User(entUser.Text,entPw.Text)));
		}
		else
		{
			DisplayAlert("Hiba!", "Minden mező megadása kötelező!", "OK");
		}
	}
}

