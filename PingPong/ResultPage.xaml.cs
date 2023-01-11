using Android.OS;
using EduTron.Data.Tables;
using EduTron.ViewsModels;
using System.Collections.ObjectModel;

namespace EduTron;

public partial class ResultPage : ContentPage
{

	MatchListModelView model;

	public ResultPage(string Nev,string Jelszo)
	{
		InitializeComponent();
		model = new MatchListModelView();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		this.BindingContext = model;
		model.init();
		lstView.ItemsSource = model.eredmenyek;
        imgbtn.RotateXTo(180);
    }

	protected override bool OnBackButtonPressed()
	{
		return true;
	}

	private async void match_Selected(object sender, SelectedItemChangedEventArgs e)
	{
		User kivalasztott = (User)lstView.SelectedItem;
		if(await DisplayAlert("Meger�s�t�s", "Biztos, hogy t�r�lni k�v�nja az elemet?", "Igen", "Nem"))
		{
			if (App.Database.DeleteUserData(kivalasztott))
			{
				await DisplayAlert("Sikeres t�rl�s!", "A t�rl�s sikere�lt!", "OK");
				App.Database.DeleteUserData(kivalasztott);
				model.eredmenyek.Remove(kivalasztott);
				lstView.ItemsSource = model.eredmenyek;
			}
			else
			{
                await DisplayAlert("Hiba!", "A t�rl�s sikertelen, pr�b�lja �jra!", "OK");
            }
		}
	}

	private void ImageButton_Clicked(object sender, EventArgs e)
	{
		var gomb = (ImageButton)sender;
		if (gomb.RotationX == 0)
		{
			gomb.RotateXTo(180);
			model.eredmenyek = new ObservableCollection<User>(model.eredmenyek.OrderBy(x => x.).ToList());
		}
		else
		{
            gomb.RotateXTo(0);
            model.eredmenyek = new ObservableCollection<User>(model.eredmenyek.OrderByDescending(x => x.Idopont).ToList());
        }
		lstView.ItemsSource = model.eredmenyek;
       
	}

	private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
	{
		var kezdDate = startDate.Date;
		var vegDate = endDate.Date;
		var filtered = new ObservableCollection<User>(model.eredmenyek.Where(x => x.Idopont.Date >= kezdDate && x.Idopont.Date <= vegDate).ToList());
		lstView.ItemsSource = filtered;
	}
}