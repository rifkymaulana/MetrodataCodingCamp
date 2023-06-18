using DatabaseConnectivity.Controllers;

namespace DatabaseConnectivity.Views;


class AuthenticationView
{
    public void Login()
    {
        AuthenticationController authentication = new AuthenticationController();
        MainView mainView = new MainView();
        Console.Clear();
        Console.WriteLine("++ Login ++");
        Console.Write("Email: ");
        string Email = Console.ReadLine() ?? "";
        Console.Write("Password: ");
        string Password = Console.ReadLine() ?? "";
        authentication.Login(Email, Password);
    }
}