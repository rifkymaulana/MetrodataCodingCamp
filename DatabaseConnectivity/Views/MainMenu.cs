using DatabaseConnectivity.Models;
using DatabaseConnectivity.Controllers;


namespace DatabaseConnectivity.Views;

class MainMenu
{
    private readonly Region _region = new Region();
    private readonly Country _country = new Country();
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
                    this.Login();
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


    void Login()
    {
        Authentication authentication = new Authentication();
        Console.Clear();
        Console.WriteLine("++ Login ++");
        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";
        Console.Write("Password: ");
        string password = Console.ReadLine() ?? "";
        if (authentication.Login(email, password))
        {
            this.CrudMenu();
        }
        else
        {
            Console.WriteLine("Your account not found, please signup first");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.Menu();
        }
    }


    void CrudMenu()
    {
        Console.Clear();
        Console.WriteLine("++ Crud Menu ++");
        Console.WriteLine("1. Crud Region");
        Console.WriteLine("2. Crud Country");
        Console.WriteLine("3. Show Location");
        Console.WriteLine("4. Show Department");
        Console.WriteLine("5. Show Employee");
        Console.WriteLine("6. Show History");
        Console.WriteLine("7. Show Job");
        Console.WriteLine("8. LINQ Show Employees");
        Console.WriteLine("9. LINQ Show Departments");
        Console.WriteLine("0. Logout");
        Console.Write("Please select menu: ");
        try
        {
            Linq linq = new Linq();
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    this.CrudRegion();
                    break;
                case 2:
                    this.CrudCountry();
                    break;
                case 3:
                    Console.Clear();
                    this.PrintLocations();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.CrudMenu();
                    break;
                case 4:
                    Console.Clear();
                    this.PrintDepartments();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.CrudMenu();
                    break;
                case 5:
                    Console.Clear();
                    this.PrintEmployees();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.CrudMenu();
                    break;
                case 6:
                    Console.Clear();
                    this.PrintHistories();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.CrudMenu();
                    break;
                case 7:
                    Console.Clear();
                    this.PrintJobs();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.CrudMenu();
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
                        this.CrudMenu();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please, input only number not alphabet");
                        Console.Write("Click any key for continue...");
                        Console.ReadKey();
                        this.CrudMenu();
                    }

                    break;
                case 9:
                    Console.Clear();
                    linq.GetDepartments();
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.CrudMenu();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("You're successfully logout");
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.Menu();
                    break;
                default:
                    Console.WriteLine("Please, input 1, 2 3, 4, 5, 6, 7 or 9");
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.CrudMenu();
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.CrudMenu();
        }
    }


    private void CrudRegion()
    {
        Console.Clear();
        Console.WriteLine("++ Crud Region ++");
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
                    this.PrintRegions();
                    break;
                case 3:
                    this.ShowRegionById();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 9:
                    this.CrudMenu();
                    break;
                default:
                    Console.WriteLine("Please, input 1, 2 3, 4 or 9");
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    this.CrudRegion();
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.CrudRegion();
        }
    }


    private void CrudCountry()
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
                    this.PrintCountries();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 9:
                    this.CrudMenu();
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


    private void PrintRegions()
    {
        Console.Clear();
        Console.WriteLine("++ Show All Region ++");
        _region.GetAll().ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine();
        });
    }


    private void PrintRegionById(int id)
    {
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        _region.GetById(id).ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine();
        });
    }

    private void ShowRegionById()
    {
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        Console.Write("Input Id: ");
        try
        {
            int id = Convert.ToInt32(Console.ReadLine());
            this.PrintRegionById(id);
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.CrudRegion();
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.CrudRegion();
        }
    }


    private void PrintCountries()
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


    private void PrintCountryById(string id)
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


    public void ShowCountryById()
    {
        Console.Clear();
        Console.WriteLine("++ Show Country By Id ++");
        Console.Write("Input Id: ");
        try
        {
            string id = Console.ReadLine() ?? "";
            this.PrintCountryById(id);
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.CrudCountry();
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
            this.CrudCountry();
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


    private void PrintDepartments()
    {
        Console.Clear();
        Console.WriteLine("++ Print Departments ++");
        _department.GetAll().ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine($"Location Id = {e.LocationId}");
            Console.WriteLine($"Manager Id = {e.ManagerId}");
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


    private void PrintHistories()
    {
        Console.Clear();
        Console.WriteLine("++ Print Histories ++");
        _history.GetAll().ForEach(e =>
        {
            Console.WriteLine($"Start Date = {e.StartDate}");
            Console.WriteLine($"End Date = {e.EndDate}");
            Console.WriteLine($"Employee Id = {e.EmployeeId}");
            Console.WriteLine($"Department Id = {e.DepartmentId}");
            Console.WriteLine($"Job Id = {e.JobId}");
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