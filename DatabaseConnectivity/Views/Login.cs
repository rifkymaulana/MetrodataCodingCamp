using DatabaseConnectivity.Controllers;


namespace DatabaseConnectivity.Views;

class Login
{
    void Menu()
    {
        Authentication authentication = new Authentication();
        Console.Clear();
        Console.WriteLine("++ Login ++");
        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";
        Console.Write("Password: ");
        string password = Console.ReadLine() ?? "";
        if (authentication.Login(email, password))
        {
            // Console.WriteLine("Login success");
        }
        else
        {
            Console.WriteLine("Your account not found, please signup first");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.Menu();
        }
    }
}