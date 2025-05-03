using KitchyTech.Services;

namespace KitchyTech;

public partial class RegisterPage : ContentPage
{
    private readonly FirebaseAuthService _authService;

    public RegisterPage()
	{
		InitializeComponent();
        _authService = new FirebaseAuthService();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (usernameEntry == null || emailEntry == null || passwordEntry == null)
        {
            await DisplayAlert("Error", "UI components not initialized.", "OK");
            return;
        }

        var username = usernameEntry?.Text ?? string.Empty;
        var email = emailEntry?.Text ?? string.Empty;
        var password = passwordEntry?.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please fill out all fields.", "OK");
            return;
        }

        try
        {
            var auth = await _authService.SignUp(email, password, username);
            await DisplayAlert("Success", $"Welcome {username}!", "OK");
        }

        catch (Exception ex)
        {
            await DisplayAlert("Registration Failed", ex.Message, "OK");
        }

        if (Shell.Current != null)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}