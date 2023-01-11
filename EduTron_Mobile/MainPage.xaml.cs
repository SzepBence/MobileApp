namespace EduTron_Mobile;

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
            await DisplayAlert("", $"Sikeres belépés \n Üdvözlünk { entUser.Text }!", "OK");
            await Navigation.PushAsync(new MenuPage());
        }
        else
        {
            await DisplayAlert("Hiba!", "Minden mező megadása kötelező!", "OK");
        }
    }

    private async void Guest_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MenuPage());
    }

    private async void Registration_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrationPage());
    }
}

