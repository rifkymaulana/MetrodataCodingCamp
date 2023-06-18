using DatabaseConnectivity.Models;
using DatabaseConnectivity.Controllers;

namespace DatabaseConnectivity.Views;


class Main
{
    private readonly Region _region = new Region();
    private readonly Location _location = new Location();
    private readonly Employee _employee = new Employee();
    private readonly Department _department = new Department();
    private readonly Job _job = new Job();
    private readonly History _history = new History();


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

    private void PrintLocations()
    {
        Console.Clear();
        Console.WriteLine("++ Print Locations ++");
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

    private void PrintEmployees()
    {
        Console.Clear();
        Console.WriteLine("++ Print Employees ++");
        _employee.GetAll().ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"First Name = {e.FirstName}");
            Console.WriteLine($"Last Name = {e.LastName}");
            Console.WriteLine($"Email = {e.Email}");
            Console.WriteLine($"Phone Number = {e.PhoneNumber}");
            Console.WriteLine($"Hire Date = {e.HireDate}");
            Console.WriteLine($"Salary = {e.Salary}");
            Console.WriteLine($"Commission Pct = {e.CommissionPct}");
            Console.WriteLine($"Manager Id = {e.ManagerId}");
            Console.WriteLine($"Department Id = {e.DepartmentId}");
            Console.WriteLine();
        });
    }


    private void PrintJobs()
    {
        Console.Clear();
        Console.WriteLine("++ Print Jobs ++");
        _job.GetAll().ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Title = {e.Title}");
            Console.WriteLine($"Min Salary = {e.MinSalary}");
            Console.WriteLine($"Max Salary = {e.MaxSalary}");
            Console.WriteLine();
        });
    }
}