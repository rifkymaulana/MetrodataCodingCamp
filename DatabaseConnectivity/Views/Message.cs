namespace DatabaseConnectivity.Views;


class Message
{
    private static readonly string MessageClickAnyKey = "Click any key for continue...";
    private static readonly string MessageFeatureUnderMaintenance = "Sorry, this feature under maintenance";
    private static readonly string MessageInputOnlyNumber = "Please, input only number not alphabet";
    private static readonly string MessageInputOnlyMenu = "Please, input only number in menu";
    private static readonly string MessageAccountNotFound = "Account not found";
    private static readonly string MessagePasswordIncorrect = "Password incorrect";
    private static readonly string MessageLoginSuccess = "Login success";
    private static readonly string MessageLoginFailed = "Login failed";
    private static readonly string MessageLogoutSuccess = "Logout success";
    private static readonly string MessageLogoutFailed = "Logout failed";
    private static readonly string MessageDeleteSuccess = "Delete success";
    private static readonly string MessageDeleteFailed = "Delete failed";

    public static void ClickAnyKeyForContinue()
    {
        Console.WriteLine(MessageClickAnyKey);
        Console.ReadKey();
    }


    public static void FeatureUnderMaintenance()
    {
        Console.WriteLine(MessageFeatureUnderMaintenance);
    }


    public static void InputOnlyNumber()
    {
        Console.WriteLine(MessageInputOnlyNumber);
    }


    public static void InputOnlyMenu()
    {
        Console.WriteLine(MessageInputOnlyMenu);
    }


    public static void AccountNotFound()
    {
        Console.WriteLine(MessageAccountNotFound);
    }


    public static void IncorrectPassword()
    {
        Console.WriteLine(MessagePasswordIncorrect);
    }


    public static void LoginSuccess()
    {
        Console.WriteLine(MessageLoginSuccess);
    }


    public static void LoginFailed()
    {
        Console.WriteLine(MessageLoginFailed);
    }


    public static void LogoutSuccess()
    {
        Console.WriteLine(MessageLogoutSuccess);
    }


    public static void LogoutFailed()
    {
        Console.WriteLine(MessageLogoutFailed);
    }


    public static void DeleteSuccess()
    {
        Console.WriteLine(MessageDeleteSuccess);
    }


    public static void DeleteFailed()
    {
        Console.WriteLine(MessageDeleteFailed);
    }
}
