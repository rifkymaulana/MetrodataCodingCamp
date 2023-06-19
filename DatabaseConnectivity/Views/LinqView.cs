using DatabaseConnectivity.Controllers;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;


class LinqView
{
    public void GetEmployees()
    {
        CrudView crudView = new CrudView();
        Console.Clear();
        Console.WriteLine("++ Show Employees with limit ++");
        Console.Write("Limit: ");
        try
        {
            LinqController linq = new LinqController();
            int limit = Convert.ToInt32(Console.ReadLine());
            List<EmployeeData> employeeDatas = linq.GetEmployees(limit);
            bool IsEmpty = !employeeDatas.Any();
            Console.WriteLine("++ Employees ++");
            if (IsEmpty)
            {
                Message.DataIsEmpty();
                Message.ClickAnyKeyForContinue();
                crudView.Menu();
            }
            foreach (var employeeData in employeeDatas)
            {
                Console.WriteLine($"Id: {employeeData.Id}");
                Console.WriteLine($"Full Name: {employeeData.FullName}");
                Console.WriteLine($"Email: {employeeData.Email}");
                Console.WriteLine($"Phone: {employeeData.Phone}");
                Console.WriteLine($"Salary: {employeeData.Salary}");
                Console.WriteLine($"Department Name: {employeeData.DepartmentName}");
                Console.WriteLine($"Street Address: {employeeData.StreetAddress}");
                Console.WriteLine($"Country Name: {employeeData.CountryName}");
                Console.WriteLine($"Region Name: {employeeData.RegionName}");
                Console.WriteLine();
            }
            Message.ClickAnyKeyForContinue();
            crudView.Menu();
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            crudView.Menu();

        }
    }


    public void GetDepartments()
    {
        CrudView crudView = new CrudView();
        Console.Clear();
        Console.WriteLine("++ Show Departments that have more than 3 employees ++");
        LinqController linq = new LinqController();
        List<DepartmentData> departmentDatas = linq.GetDepartments();
        Console.WriteLine("++ Departments ++");
        foreach (var departmentData in departmentDatas)
        {
            Console.WriteLine($"Department Name: {departmentData.DepartmentName}");
            Console.WriteLine($"Total Employees: {departmentData.TotalEmployees}");
            Console.WriteLine($"Min Salary: {departmentData.MinSalary}");
            Console.WriteLine($"Max Salary: {departmentData.MaxSalary}");
            Console.WriteLine($"Avg Salary: {departmentData.AverageSalary}");
            Console.WriteLine();
        }
        Message.ClickAnyKeyForContinue();
        crudView.Menu();
    }
}
