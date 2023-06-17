using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;

class LocationView
{
    private readonly Location _location = new Location();
    void Menu()
    {
        Console.Clear();
        Console.WriteLine("++ Crud Location ++");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Show All");
        Console.WriteLine("3. Show By Id");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("9. Back");
        Console.Write("Please select menu: ");
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("Please, input 1, 2 3, 4 or 9");
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
        }
    }


    void getAll()
    {
        Console.Clear();
        Console.WriteLine("++ Show All Region ++");
        _location.GetAll().ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Street Address = {e.StreetAddress}");
            Console.WriteLine($"Postal Code = {e.PostalCode}");
            Console.WriteLine($"City = {e.City}");
            Console.WriteLine($"State Province = {e.StateProvince}");
            Console.WriteLine($"Country Id = {e.CountryId}");
            Console.WriteLine();
        });
    }


    void GetById()
    {
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        Console.Write("Input Id: ");
        try
        {
            int Id = Convert.ToInt32(Console.ReadLine());
            this.GetById(Id);
            Console.Write("Click any key for continue...");
            Console.ReadKey();
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
        }
    }


    private void GetById(int Id)
    {
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        _location.GetById(Id).ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Street Address = {e.StreetAddress}");
            Console.WriteLine($"Postal Code = {e.PostalCode}");
            Console.WriteLine($"City = {e.City}");
            Console.WriteLine($"State Province = {e.StateProvince}");
            Console.WriteLine($"Country Id = {e.CountryId}");
            Console.WriteLine();
        });
    }
}