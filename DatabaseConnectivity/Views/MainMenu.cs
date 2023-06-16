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
        Console.WriteLine(" 1. Login");
        Console.WriteLine(" 2. SignUp");
        Console.WriteLine(" 0. Exit");
        Console.Write(" Please select menu: ");
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
        Console.Clear();
        Console.WriteLine("++ Login ++");
        Console.Write(" email: ");
        string email =  Console.ReadLine() ?? "";
        Console.Write(" Password: ");
        string password = Console.ReadLine() ?? "";
        if (Authentication.Login(email, password))
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
        Console.WriteLine(" 1. Crud Region");
        Console.WriteLine(" 2. Crud Country");
        Console.WriteLine(" 3. Show Location");
        Console.WriteLine(" 4. Show Department");
        Console.WriteLine(" 5. Show Employee");
        Console.WriteLine(" 6. Show History");
        Console.WriteLine(" 7. Show Job");
        Console.WriteLine(" 8. LINQ Show Employees");
        Console.WriteLine(" 9. LINQ Show Departments");
        Console.WriteLine(" 0. Logout");
        Console.Write(" Please select menu: ");
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
        Console.WriteLine(" 1. Create");
        Console.WriteLine(" 2. Show All");
        Console.WriteLine(" 3. Show By Id");
        Console.WriteLine(" 4. Update");
        Console.WriteLine(" 5. Delete");
        Console.WriteLine(" 9. Back");
        Console.Write(" Please select menu: ");
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
        Console.WriteLine(" 1. Create");
        Console.WriteLine(" 2. Show All");
        Console.WriteLine(" 3. Show By Id");
        Console.WriteLine(" 4. Update");
        Console.WriteLine(" 5. Delete");
        Console.WriteLine(" 9. Back");
        Console.Write(" Please select menu: ");
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
        _region.GetAllRegions().ForEach(e => { Console.WriteLine($"id = {e.Id}, name = {e.Name}"); });
    }


    private void PrintRegionById(int id)
    {
        _region.GetRegionById(id).ForEach(e => { Console.WriteLine($"id = {e.Id}, name = {e.Name}"); });
    }

    private void ShowRegionById()
    {
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        Console.Write(" id: ");
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
        _country.GetAllCountries().ForEach(e =>
        {
            Console.WriteLine($"id = {e.Id}");
            Console.WriteLine($"name = {e.Name}");
            Console.WriteLine($"region id = {e.RegionId}");
            Console.WriteLine();
        });
    }


    private void PrintCountryById(string id)
    {
        _country.GetCountryById(id).ForEach(e =>
        {
            Console.WriteLine($"id = {e.Id}");
            Console.WriteLine($"name = {e.Name}");
            Console.WriteLine($"region id = {e.RegionId}");
            Console.WriteLine();
        });
    }


    public void ShowCountryById()
    {
        Console.Clear();
        Console.WriteLine("++ Show Country By Id ++");
        Console.Write(" id: ");
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
        _location.GetAllLocations().ForEach(e =>
        {
            Console.WriteLine(
                $"id = {e.Id}, street address = {e.StreetAddress}, postal code = {e.PostalCode}, city = {e.City}, state province = {e.StateProvince}, country id = {e.CountryId}");
        });
    }


    private void PrintDepartments()
    {
        _department.GetAllDepartments().ForEach(e =>
        {
            Console.WriteLine(
                $"id = {e.Id}, name = {e.Name}, location id = {e.LocationId}, manager id = {e.ManagerId}, ");
        });
    }


    private void PrintEmployees()
    {
        _employee.GetAllEmployees().ForEach(e =>
        {
            Console.WriteLine(
                $"id = {e.Id}, name = {e.FirstName} {e.LastName}, email = {e.Email}, phone number = {e.PhoneNumber}, hire date = {e.HireDate}, salary = {e.Salary}");
        });
    }


    private void PrintHistories()
    {
        _history.GetAllHistories().ForEach(e =>
        {
            Console.WriteLine(
                $"start date = {e.StartDate}, end date = {e.EndDate}, employee id = {e.EmployeeId}, department id = {e.DepartmentId}, job id = {e.JobId}");
        });
    }


    private void PrintJobs()
    {
        _job.GetAllJobs().ForEach(e =>
        {
            Console.WriteLine(
                $"id = {e.Id}, title = {e.Title}, min salary = {e.MinSalary}, max salary = {e.MaxSalary}");
        });
    }
}