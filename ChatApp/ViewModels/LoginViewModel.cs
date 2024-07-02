
using ChatApp.Helpers;

namespace ChatApp.ViewModel;

public partial class LoginViewModel : BaseViewModel
{
    public LoginViewModel()
    {
        user = new User();
    }

    [ObservableProperty]
    User user;

    [RelayCommand]
    private async void Login()
    {
        // Read the values set in registration page
        var username = Preferences.Get("Username", "");
        var password = Preferences.Get("Password", "");
        var name = Preferences.Get("Name", "");
        var location = Preferences.Get("Location", "");
        string imageName = Preferences.Get("ProfilePhoto", "");

        if (User.Username != username || User.Password != password)
        {
            await Shell.Current.DisplayAlert("Alert!", "Invalid username or password!", "OK");
        }
        else
        {
            // Connect to chat hub
            string chatUsername = User.Username + "_" + name + "_" + imageName + "_" + location;
            await ChatHelper.Connect(chatUsername);

            // Save to local storage
            Preferences.Set("ChatUserName", chatUsername);

            // Navigate to chat user list page
            await AppShell.Current.GoToAsync("//ChatListPage");
        }
    }

    [RelayCommand]
    private void Register()
    {
        AppShell.Current.GoToAsync("//RegisterPage");
    }
}

