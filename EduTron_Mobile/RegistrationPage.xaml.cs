namespace EduTron_Mobile;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await DisplayAlert("Siker", "Sikeres regisztr�ci� t�rt�nt!\n �tir�ny�t�sra ker�l a f�oldalra ", "OK");
		await Navigation.PushAsync(new MenuPage());
    }
}