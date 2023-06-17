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
        Console.Clear();
        Console.WriteLine("++ Welcome to HumanResourceApp ++");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. SignUp");
        Console.WriteLine("0. Exit");
        Console.Write("Please select menu: ");
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    break;
                case 2:
                    Console.WriteLine("Sorry, this feature under maintenance");
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please, input 1, 2 or 0");
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.Menu();
        }
    }


    void Crud()
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
            Linq linq = new Linq();
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
                    Console.Write("Input limit: ");
                    try
                    {
                        int limit = Convert.ToInt32(Console.ReadLine());
                        linq.GetEmployees(limit);
                        Console.Write("Click any key for continue...");
                        Console.ReadKey();
                        this.Menu();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please, input only number not alphabet");
                        Console.Write("Click any key for continue...");
                        Console.ReadKey();
                        this.Menu();
                    }

                    break;
                case 9:
                    Console.Clear();
                    linq.GetDepartments();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("You're successfully logout");
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Please, input 1, 2 3, 4, 5, 6, 7 or 9");
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.Menu();
        }
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