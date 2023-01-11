
using System.Collections.ObjectModel;
using EduTron.ViewsModels;

namespace EduTron_Mobile;

public partial class MenuPage : ContentPage
{
    TestModelView model;
	public MenuPage()
	{
		InitializeComponent();
        model = new TestModelView();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.BindingContext = model;
        model.init();
        lstView.ItemsSource = model.results;
    }

    private async void imgbtn_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new TestCreatePage());
    }

    private void btnKereses_Clicked(object sender, EventArgs e)
    {
        var tesztnev = shbKereses.Text;
        var filtered = new ObservableCollection<Test>(model.results.Where(x => x.Name == tesztnev).ToList());
        lstView.ItemsSource = filtered;
    }
}