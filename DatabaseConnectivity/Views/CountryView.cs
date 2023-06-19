using DatabaseConnectivity.Models;
using DatabaseConnectivity.Controllers;

namespace DatabaseConnectivity.Views;


class CountryView
{
    public void Menu()
    {
        CountryController countryController = new CountryController();
        Console.Clear();
        Console.WriteLine("++ Crud Country ++");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Show All");
        Console.WriteLine("3. Show By Id");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("9. Back");
        Console.Write("Please select menu: ");
        countryController.Menu();
    }


    public void Create()
    {
        CountryController countryController = new CountryController();
        Console.Clear();
        Console.WriteLine("++ Create Country ++");
        Console.Write("Input Id: ");
        string Id = Console.ReadLine() ?? "";
        Console.Write("Input Name: ");
        string Name = Console.ReadLine() ?? "";
        Console.Write("Input Region Id: ");
        int RegionId = Convert.ToInt32(Console.ReadLine());
        int result = countryController.Create(Id, Name, RegionId);
        if (result > 0)
        {
            Message.InsertSuccess();
        }
        else
        {
            Message.InsertFailed();
        }
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    public void GetAll(List<Country> countries)
    {
        Console.Clear();
        Console.WriteLine("++ Show All Countries ++");
        countries.ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine($"Region Id = {e.RegionId}");
            Console.WriteLine();
        });
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    public void GetById()
    {
        CountryController countryController = new CountryController();
        Console.Clear();
        Console.WriteLine("++ Show Country By Id ++");
        Console.Write("Input Id: ");
        var country = countryController.GetById(countryController.GetById());
        this.GetById(country);
    }


    public void GetById(List<Country> country)
    {
        country.ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine($"Region Id = {e.RegionId}");
            Console.WriteLine();
        });
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    public void Update()
    {
        CountryController countryController = new CountryController();
        Console.Clear();
        Console.WriteLine("++ Update Country By Id ++");
        try
        {
            Console.Write("Input Id: ");
            string Id = Console.ReadLine() ?? "";
            Console.Write("Input Name: ");
            string Name = Console.ReadLine() ?? "";
            Console.Write("Input Region Id: ");
            int RegionId = Convert.ToInt32(Console.ReadLine());
            countryController.Update(Id, Name, RegionId, true);
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            this.Menu();
        }
    }


    public void Delete()
    {
        CountryController countryController = new CountryController();
        Console.Clear();
        Console.WriteLine("++ Delete Country By Id ++");
        Console.Write("Input Id: ");
        int result = countryController.Delete();
        if (result > 0)
        {
            Message.DeleteSuccess();
        }
        else
        {
            Message.DeleteFailed();
        }
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }
}
