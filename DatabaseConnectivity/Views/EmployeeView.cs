using DatabaseConnectivity.Controllers;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;


class EmployeeView
{
    public void Menu()
    {
        EmployeeController employeeController = new EmployeeController();
        Console.Clear();
        Console.WriteLine("++ Employee Menu ++");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Show All");
        Console.WriteLine("3. Show By Id");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("9. Back");
        Console.Write("Please select menu: ");
        employeeController.Menu();
    }


    public void Create()
    {
        EmployeeController employeeController = new EmployeeController();
        Console.Clear();
        Console.WriteLine("++ Create Employee ++");
        Console.Write("Input Id: ");
        int Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input First Name: ");
        string FirstName = Console.ReadLine() ?? "";
        Console.Write("Input Last Name: ");
        string LastName = Console.ReadLine() ?? "";
        Console.Write("Input Email: ");
        string Email = Console.ReadLine() ?? "";
        Console.Write("Input Phone Number: ");
        string PhoneNumber = Console.ReadLine() ?? "";
        DateTime HireDate = DateTime.Now;
        Console.Write("Input Salary: ");
        int Salary = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input Commission Pct: ");
        decimal CommissionPct = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Input Manager Id: ");
        int ManagerId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input Job Id: ");
        string JobId = Console.ReadLine() ?? "";
        Console.Write("Input Department Id: ");
        int DepartmentId = Convert.ToInt32(Console.ReadLine());
        int result = employeeController.Create(Id, FirstName, LastName, Email, PhoneNumber, HireDate, Salary,
            CommissionPct, ManagerId, JobId, DepartmentId);
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


    public void GetAll(List<Employee> employees)
    {
        Console.Clear();
        Console.WriteLine("++ Show All Region ++");
        employees.ForEach(e =>
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
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    public void GetById()
    {
        EmployeeController employeeController = new EmployeeController();
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        Console.Write("Input Id: ");
        var employees = employeeController.GetById(employeeController.GetById());
        this.GetById(employees);
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    private void GetById(List<Employee> employees)
    {
        Console.WriteLine("++ Show Region By Id ++");
        employees.ForEach(e =>
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
