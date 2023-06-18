using System;
using DatabaseConnectivity.Models;
using DatabaseConnectivity.Controllers;

namespace DatabaseConnectivity.Views;


class LocationView
{
    private readonly Location _location = new Location();
    public void Menu()
    {
        LocationController locationController = new LocationController();
        Console.Clear();
        Console.WriteLine("++ Crud Location ++");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Show All");
        Console.WriteLine("3. Show By Id");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("9. Back");
        Console.Write("Please select menu: ");
        locationController.Menu();
    }


    public void Create()
    {
        LocationController locationController = new LocationController();
        Console.Clear();
        Console.WriteLine("++ Create Location ++");
        try
        {
            Console.Write("Input Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Street Address: ");
            string StreetAddress = Console.ReadLine() ?? "";
            Console.Write("Input Postal Code: ");
            string PostalCode = Console.ReadLine() ?? "";
            Console.Write("Input City: ");
            string City = Console.ReadLine() ?? "";
            Console.Write("Input State Province: ");
            string StateProvince = Console.ReadLine() ?? "";
            Console.Write("Input Country Id: ");
            string CountryId = Console.ReadLine() ?? "";
            int result = locationController.Create(Id, StreetAddress, PostalCode, City, StateProvince, CountryId);
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
        catch (Exception)
        {

        }
    }


    public void GetAll(List<Location> locations)
    {
        Console.Clear();
        Console.WriteLine("++ Show All Countries ++");
        locations.ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Street Address = {e.StreetAddress}");
            Console.WriteLine($"Postal Code = {e.PostalCode}");
            Console.WriteLine($"City = {e.City}");
            Console.WriteLine($"State Province = {e.StateProvince}");
            Console.WriteLine($"Country Id = {e.CountryId}");
            Console.WriteLine();
        });
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    public void GetById()
    {
        LocationController locationController = new LocationController();
        Console.Clear();
        Console.WriteLine("++ Show Country By Id ++");
        Console.Write("Input Id: ");
        var location = locationController.GetById(locationController.GetById());
        this.GetById(location);
    }


    public void GetById(List<Location> location)
    {
        location.ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Street Address = {e.StreetAddress}");
            Console.WriteLine($"Postal Code = {e.PostalCode}");
            Console.WriteLine($"City = {e.City}");
            Console.WriteLine($"State Province = {e.StateProvince}");
            Console.WriteLine($"Country Id = {e.CountryId}");
            Console.WriteLine();
        });
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    public void Update()
    {
        LocationController locationController = new LocationController();
        Console.Clear();
        Console.WriteLine("++ Update Country By Id ++");
        try
        {
            Console.Write("Input Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Street Address: ");
            string StreetAddress = Console.ReadLine() ?? "";
            Console.Write("Input Postal Code: ");
            string PostalCode = Console.ReadLine() ?? "";
            Console.Write("Input City: ");
            string City = Console.ReadLine() ?? "";
            Console.Write("Input State Province: ");
            string StateProvince = Console.ReadLine() ?? "";
            Console.Write("Input Country Id: ");
            string CountryId = Console.ReadLine() ?? "";
            locationController.Update(Id, StreetAddress, PostalCode, City, StateProvince, CountryId, true);
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
        LocationController locationController = new LocationController();
        Console.Clear();
        Console.WriteLine("++ Delete Location By Id ++");
        Console.Write("Input Id: ");
        int result = locationController.Delete();
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
