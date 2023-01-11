using EduTron.Data.Tables;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EduTron;

public partial class GamePage : ContentPage, INotifyPropertyChanged
{
    private User matchData { get; set; }
    public int PlayerOnePoint { get; set; }
    public int PlayerTwoPoint { get; set; }

    public GamePage(User m)
	{
		InitializeComponent();
        this.BindingContext = m;
        matchData = m;
	}

    private async void Player_Tapped(object sender, EventArgs e)
    {
        var frame = ((Frame)sender);
        var layout = (VerticalStackLayout)frame.Children[0];
        var label = (Label)layout.Children[1];
        if (layout.Rotation == 180)
            PlayerOnePoint++;
        else
            PlayerTwoPoint++;
        if (CheckMatchEnd())
        {
            await App.Database.SaveMatchData(matchData);
            await Navigation.PushAsync(new AfterGameTabbedPage());
        }
        else
        {
            label.Text = (int.Parse(label.Text) + 1).ToString();
        }
    }

    private bool CheckMatchEnd()
    {
        if (Math.Abs(PlayerOnePoint - PlayerTwoPoint) < 2)
            return false;
        if (PlayerOnePoint == 11 && PlayerTwoPoint < 10)
            return true;
        if (PlayerTwoPoint == 11 && PlayerOnePoint < 10)
            return true;
        return Math.Abs(PlayerOnePoint - PlayerTwoPoint) == 2 && (PlayerOnePoint > 10 || PlayerTwoPoint > 10);
    }

  
}