using DatabaseConnectivity.Models;
using DatabaseConnectivity.Controllers;

namespace DatabaseConnectivity.Views;


class RegionView
{
    private readonly Region _region = new Region();

    public void Menu()
    {
        RegionController regionController = new RegionController();
        Console.Clear();
        Console.WriteLine("++ Crud Region ++");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Show All");
        Console.WriteLine("3. Show By Id");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("9. Back");
        Console.Write("Please select menu: ");
        regionController.Menu();
    }


    public void Create()
    {
        RegionController regionController = new RegionController();
        Console.Clear();
        Console.WriteLine("++ Create Region ++");
        Console.Write("Input Name: ");
        string Name = Console.ReadLine() ?? "";
        int result = regionController.Create(Name);
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


    public void GetAll(List<Region> regions)
    {
        Console.Clear();
        Console.WriteLine("++ Show All Region ++");
        regions.ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine();
        });
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    public void GetById()
    {
        RegionController regionController = new RegionController();
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        Console.Write("Input Id: ");
        var region = regionController.GetById(regionController.GetById());
        this.GetById(region);
    }


    public void GetById(List<Region> region)
    {
        region.ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine();
        });
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    public void Update()
    {
        RegionController regionController = new RegionController();
        Console.Clear();
        Console.WriteLine("++ Update Region By Id ++");
        Console.Write("Input Id: ");
        regionController.Update();
    }


    public void Delete()
    {
        RegionController regionController = new RegionController();
        Console.Clear();
        Console.WriteLine("++ Delete Region By Id ++");
        Console.Write("Input Id: ");
        int result = regionController.Delete();
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
