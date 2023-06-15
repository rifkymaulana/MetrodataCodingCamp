using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    class MainMenu
    {
        protected Region region = new Region();
        protected Country country = new Country();
        protected Location location = new Location();
        protected Employee employee = new Employee();
        protected Department department = new Department();
        protected Job job = new Job();
        protected History history = new History();


        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("++ Welcome to HumanResourceApp ++");
            Console.WriteLine(" 1. Login");
            Console.WriteLine(" 2. SignUp");
            Console.WriteLine(" 0. Exit");
            Console.Write(" Plase select menu: ");
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
            string email = Console.ReadLine();
            Console.Write(" Password: ");
            string password = Console.ReadLine();
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
            Console.WriteLine(" 4. Show Deparment");
            Console.WriteLine(" 5. Show Employee");
            Console.WriteLine(" 6. Show History");
            Console.WriteLine(" 7. Show Job");
            Console.WriteLine(" 9. Logout");
            Console.Write(" Plase select menu: ");
            try
            {
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
                    case 9:
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


        public void CrudRegion()
        {
            Console.Clear();
            Console.WriteLine("++ Crud Region ++");
            Console.WriteLine(" 1. Create");
            Console.WriteLine(" 2. Show All");
            Console.WriteLine(" 3. Show By Id");
            Console.WriteLine(" 4. Update");
            Console.WriteLine(" 5. Delete");
            Console.WriteLine(" 9. Back");
            Console.Write(" Plase select menu: ");
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


        public void CrudCountry()
        {
            Console.Clear();
            Console.WriteLine("++ Crud Country ++");
            Console.WriteLine(" 1. Create");
            Console.WriteLine(" 2. Show All");
            Console.WriteLine(" 3. Show By Id");
            Console.WriteLine(" 4. Update");
            Console.WriteLine(" 5. Delete");
            Console.WriteLine(" 9. Back");
            Console.Write(" Plase select menu: ");
            try
            {
                int inputMenu = Convert.ToInt32(Console.ReadLine());
                switch (inputMenu)
                {
                    case 1:
                        break;
                    case 2:
                        this.PrintCoutries();
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


        public void PrintRegions()
        {
            region.GetAllRegions().ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}, name = {e.name}");
            });
        }


        public void PrintRegionById(int id)
        {
            region.GetRegionById(id).ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}, name = {e.name}");
            });
        }

        public void ShowRegionById()
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


        public void PrintCoutries()
        {
            country.GetAllCountries().ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}");
                Console.WriteLine($"name = {e.name}");
                Console.WriteLine($"region id = {e.regionId}");
                Console.WriteLine();
            });
        }


        public void PrintCountryById(string id)
        {
            country.GetCountryById(id).ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}");
                Console.WriteLine($"name = {e.name}");
                Console.WriteLine($"region id = {e.regionId}");
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
                string id = Console.ReadLine();
                this.PrintCountryById(id);
                Console.Write("Click any key for continue...");
                Console.ReadKey();
                this.CrudCountry();

            }
            catch (Exception)
            {
                Console.WriteLine("Please, input only number not alphabet");
                Console.Write("Clik any key for continue...");
                Console.ReadKey();
                this.CrudCountry();
            }
        }


        public void PrintLocations()
        {
            location.GetAllLocations().ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}, street address = {e.streetAddress}, postal code = {e.postalCode}, city = {e.city}, state province = {e.stateProvince}, country id = {e.countryId}");
            });
        }


        public void PrintDepartments()
        {
            department.GetAllDepartments().ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}, name = {e.name}, location id = {e.locationId}, manager id = {e.managerId}, ");
            });
        }


        public void PrintEmployees()
        {
            employee.GetAllEmployees().ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}, name = {e.firstName} {e.lastName}, email = {e.email}, phone number = {e.phoneNumber}, hire date = {e.hireDate}, salary = {e.salary}");
            });
        }


        public void PrintHistories()
        {
            history.GetAllHistories().ForEach(e =>
            {
                Console.WriteLine($"start date = {e.startDate}, end date = {e.endDate}, employee id = {e.employeeId}, department id = {e.departmentId}, job id = {e.jobId}");
            });
        }


        public void PrintJobs()
        {
            job.GetAllJobs().ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}, title = {e.title}, min salary = {e.minSalary}, max salary = {e.maxSalary}");
            });
        }
    }
}
