namespace DatabaseConnectivity.Views;
class Message
{
    private static readonly string MessageClickAnyKey = "Click any key for continue...";
    private static readonly string MessageFeatureUnderMaintenance = "Sorry, this feature under maintenance";
    private static readonly string MessageInputOnlyNumber = "Please, input only number not alphabet";
    private static readonly string MessageInputOnlyMenu = "Please, input only number in menu";

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
}