using KitchyTech.Services;

namespace KitchyTech;

public partial class LoginPage : ContentPage
{
    private readonly FirebaseAuthService _authService;

    public LoginPage()
	{
		InitializeComponent();
        _authService = new FirebaseAuthService();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {

        try
        {
            var auth = await _authService.SignIn(emailEntry.Text, passwordEntry.Text);
            var token = await FirebaseAuthService.GetFreshToken(auth);


            await DisplayAlert("Success", $"Welcome {auth.User.Email}\nToken: {token}", "OK");

        }
        catch (Exception ex)
        {
            await DisplayAlert("Login Failed", ex.Message, "OK");
        }
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("RegisterPage");
    }

}