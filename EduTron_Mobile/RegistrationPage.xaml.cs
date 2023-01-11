namespace EduTron_Mobile;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await DisplayAlert("Siker", "Sikeres regisztráció történt!\n Átirányításra kerül a fõoldalra ", "OK");
		await Navigation.PushAsync(new MenuPage());
    }
}