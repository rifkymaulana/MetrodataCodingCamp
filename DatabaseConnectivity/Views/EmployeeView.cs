using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;


class EmployeeView
{
    private readonly Employee _employee = new Employee();
    void Main()
    {
        Console.Clear();
        Console.WriteLine("++ Employee Menu ++");
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
        _employee.GetAll().ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"First Name = {e.FirstName}");
            Console.WriteLine($"Last Name = {e.LastName}");
            Console.WriteLine($"Email = {e.Email}");
            Console.WriteLine($"Phone Number = {e.PhoneNumber}");
            Console.WriteLine($"Hire Date = {e.HireDate}");
            Console.WriteLine($"Job Id = {e.JobId}");
            Console.WriteLine($"Salary = {e.Salary}");
            Console.WriteLine($"Commission Pct = {e.CommissionPct}");
            Console.WriteLine($"Manager Id = {e.ManagerId}");
            Console.WriteLine($"Department Id = {e.DepartmentId}");
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
            int id = Convert.ToInt32(Console.ReadLine());
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


    private void GetById(int id)
    {
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        _employee.GetById(id).ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"First Name = {e.FirstName}");
            Console.WriteLine($"Last Name = {e.LastName}");
            Console.WriteLine($"Email = {e.Email}");
            Console.WriteLine($"Phone Number = {e.PhoneNumber}");
            Console.WriteLine($"Hire Date = {e.HireDate}");
            Console.WriteLine($"Job Id = {e.JobId}");
            Console.WriteLine($"Salary = {e.Salary}");
            Console.WriteLine($"Commission Pct = {e.CommissionPct}");
            Console.WriteLine($"Manager Id = {e.ManagerId}");
            Console.WriteLine($"Department Id = {e.DepartmentId}");
            Console.WriteLine();
        });
    }
}