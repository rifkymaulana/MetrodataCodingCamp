using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers;


class EmployeeController
{
    public void Menu()
    {
        CrudView crudView = new CrudView();
        EmployeeView employeeView = new EmployeeView();
        Employee employee = new Employee();
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    employeeView.Create();
                    break;
                case 2:
                    employeeView.GetAll(employee.GetAll());
                    break;
                case 3:
                    employeeView.GetById();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 9:
                    crudView.Menu();
                    break;
                default:
                    Message.InputOnlyMenu();
                    Message.ClickAnyKeyForContinue();
                    employeeView.Menu();
                    break;
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            employeeView.Menu();
        }
    }


    public int Create(int Id, string FirstName, string LastName, string Email, string PhoneNumber,
        DateTime HireDate, int Salary, decimal CommissionPct, int ManagerId, string JobId, int DepartmentId)
    {
        Employee employee = new Employee();
        try
        {
            return employee.Insert(Id, FirstName, LastName, Email, PhoneNumber, HireDate, Salary,
                CommissionPct, ManagerId, JobId, DepartmentId);
        }
        catch (Exception)
        {
            Message.InsertFailed();
            Message.ClickAnyKeyForContinue();
            return 0;
        }
    }


    public int GetById()
    {
        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            return -1;
        }
    }


    public List<Employee> GetById(int Id)
    {
        Employee employee = new Employee();
        return employee.GetById(Id);
    }
}
