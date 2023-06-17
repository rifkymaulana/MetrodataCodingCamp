using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;


class CountryView
{
    private readonly Country _country = new Country();

    void CrudCountry()
    {
        Console.Clear();
        Console.WriteLine("++ Crud Country ++");
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
                    this.CrudCountry();
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.CrudCountry();
        }
    }


    void GetAll()
    {
        Console.Clear();
        Console.WriteLine("++ Show All Country ++");
        _country.GetAll().ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine($"Region Id = {e.RegionId}");
            Console.WriteLine();
        });
    }


    private void GetById(string id)
    {
        Console.Clear();
        Console.WriteLine("++ Show Country By Id ++");
        _country.GetById(id).ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine($"Region Id = {e.RegionId}");
            Console.WriteLine();
        });
    }


    public void GetById()
    {
        Console.Clear();
        Console.WriteLine("++ Show Country By Id ++");
        Console.Write("Input Id: ");
        try
        {
            string id = Console.ReadLine() ?? "";
            this.GetById(id);
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
}