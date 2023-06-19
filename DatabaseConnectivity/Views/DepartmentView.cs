using DatabaseConnectivity.Controllers;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;


class DepartmentView
{
    public void Menu()
    {
        DepartmentController departmentController = new DepartmentController();
        Console.Clear();
        Console.WriteLine("++ Crud Department ++");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Show All");
        Console.WriteLine("3. Show By Id");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("9. Back");
        Console.Write("Please select menu: ");
        departmentController.Menu();
    }


    public void Create()
    {
        DepartmentController departmentController = new DepartmentController();
        Console.Clear();
        Console.WriteLine("++ Create Department ++");
        Console.Write("Input Id: ");
        int Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input Name: ");
        string Name = Console.ReadLine() ?? "";
        Console.Write("Input Location Id: ");
        int LocationId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input Manager Id: ");
        int ManagerId = Convert.ToInt32(Console.ReadLine());
        int result = departmentController.Create(Id, Name, LocationId, ManagerId);
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


    public void GetAll(List<Department> departments)
    {
        Console.Clear();
        Console.WriteLine("++ Show All Departments ++");
        departments.ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine($"LocationId = {e.LocationId}");
            Console.WriteLine($"ManagerId = {e.ManagerId}");
            Console.WriteLine();
        });
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    public void GetById()
    {
        DepartmentController departmentController = new DepartmentController();
        Console.Clear();
        Console.WriteLine("++ Show Department By Id ++");
        Console.Write("Input Id: ");
        var department = departmentController.GetById(departmentController.GetById());
        this.GetById(department);
        Message.ClickAnyKeyForContinue();
        this.Menu();
    }


    public void GetById(List<Department> department)
    {
        department.ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Name = {e.Name}");
            Console.WriteLine($"LocationId = {e.LocationId}");
            Console.WriteLine($"ManagerId = {e.ManagerId}");
            Console.WriteLine();
        });
    }


    public void Update()
    {
        DepartmentController departmentController = new DepartmentController();
        Console.Clear();
        Console.WriteLine("++ Update Department By Id ++");
        try
        {
            Console.Write("Input Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Name: ");
            string Name = Console.ReadLine() ?? "";
            Console.Write("Input Location Id: ");
            int LocationId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Manager Id: ");
            int ManagerId = Convert.ToInt32(Console.ReadLine());
            departmentController.Update(Id, Name, LocationId, ManagerId, true);
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
        DepartmentController departmentController = new DepartmentController();
        Console.Clear();
        Console.WriteLine("++ Delete Department By Id ++");
        Console.Write("Input Id: ");
        int result = departmentController.Delete();
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
