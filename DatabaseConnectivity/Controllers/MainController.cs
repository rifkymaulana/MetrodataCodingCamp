using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers;


class MainController
{
    public void Menu()
    {
        MainView main = new MainView();
        AuthenticationView authenticationView = new AuthenticationView();
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    authenticationView.Login();
                    break;
                case 2:
                    Message.FeatureUnderMaintenance();
                    Message.ClickAnyKeyForContinue();
                    main.Menu();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Message.InputOnlyMenu();
                    Message.ClickAnyKeyForContinue();
                    main.Menu();
                    break;
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            main.Menu();
        }
    }
}
