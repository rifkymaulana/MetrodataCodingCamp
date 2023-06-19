using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers;


class DepartmentController
{
    public void Menu()
    {
        CrudView crudView = new CrudView();
        DepartmentView departmentView = new DepartmentView();
        Department department = new Department();
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    departmentView.Create();
                    break;
                case 2:
                    departmentView.GetAll(department.GetAll());
                    break;
                case 3:
                    departmentView.GetById();
                    break;
                case 4:
                    departmentView.Update();
                    break;
                case 5:
                    departmentView.Delete();
                    break;
                case 9:
                    crudView.Menu();
                    break;
                default:
                    Message.InputOnlyMenu();
                    Message.ClickAnyKeyForContinue();
                    break;
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            departmentView.Menu();
        }
    }


    public int Create(int Id, string Name, int LocationId, int ManagerId)
    {
        Department department = new Department();
        try
        {
            return department.Insert(Id, Name, LocationId, ManagerId);
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


    public List<Department> GetById(int Id)
    {
        Department department = new Department();
        return department.GetById(Id);
    }


    public void Update(int Id, string Name, int LocationId, int ManagerId, bool IsUpdate)
    {
        DepartmentView departmentView = new DepartmentView();
        try
        {
            int result = this.Update(Id, Name, LocationId, ManagerId);
            if (result > 0)
            {
                Message.UpdateSuccess();
                Message.ClickAnyKeyForContinue();
                departmentView.Menu();
            }
            else
            {
                Message.UpdateFailed();
                Message.ClickAnyKeyForContinue();
                departmentView.Menu();
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            departmentView.Menu();
        }
    }


    public int Update(int Id, string Name, int LocationId, int ManagerId)
    {
        Department department = new Department();
        try
        {
            return department.Update(Id, Name, LocationId, ManagerId);
        }
        catch (Exception)
        {
            return 0;
        }
    }


    public int Delete()
    {
        Department department = new Department();
        try
        {
            return department.Delete(Convert.ToInt32(Console.ReadLine()));
        }
        catch (Exception)
        {
            return 0;
        }
    }
}
