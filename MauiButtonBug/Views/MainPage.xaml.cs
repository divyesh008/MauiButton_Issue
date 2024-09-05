namespace MauiButtonBug.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    async void Button_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("alert", "button clicked", "ok");
    }
}


