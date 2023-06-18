using DatabaseConnectivity.Controllers;

namespace DatabaseConnectivity.Views;


class CrudView
{
    public void Menu()
    {
        Console.Clear();
        Console.WriteLine("++ Crud Menu ++");
        Console.WriteLine("1. Crud Region");
        Console.WriteLine("2. Crud Country");
        Console.WriteLine("3. Crud Location");
        Console.WriteLine("4. Crud Department");
        Console.WriteLine("5. Crud Employee");
        Console.WriteLine("6. Crud History");
        Console.WriteLine("7. Crud Job");
        Console.WriteLine("8. Show Employees with limit");
        Console.WriteLine("9. Show Departments that have more than 3 employees");
        Console.WriteLine("0. Logout");
        Console.Write("Please select menu: ");
        try
        {
            LinqController linq = new LinqController();
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                case 5:
                    Console.Clear();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                case 6:
                    Console.Clear();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                case 7:
                    Console.Clear();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                case 8:
                    Console.Clear();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                case 9:
                    Console.Clear();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                case 0:
                    Console.Clear();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                default:
                    Console.WriteLine("Please select menu correctly");
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.Menu();
        }
    }

}
