using DatabaseConnectivity.Models;
using DatabaseConnectivity.Controllers;

namespace DatabaseConnectivity.Views;


class MainView
{
    public void Menu()
    {
        MainController mainController = new MainController();
        Console.Clear();
        Console.WriteLine("++ Welcome to HumanResourceApp ++");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. SignUp");
        Console.WriteLine("0. Exit");
        Console.Write("Please select menu: ");
        mainController.Menu();
    }
}
