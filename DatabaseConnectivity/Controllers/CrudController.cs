using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers;


class CrudController
{
    public void Menu()
    {
        RegionView region = new RegionView();
        CountryView country = new CountryView();
        LocationView location = new LocationView();
        DepartmentView department = new DepartmentView();
        EmployeeView employee = new EmployeeView();
        HistoryView history = new HistoryView();
        JobView job = new JobView();
        LinqView linq = new LinqView();
        MainView mainView = new MainView();
        CrudView crudView = new CrudView();
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    region.Menu();
                    break;
                case 2:
                    country.Menu();
                    break;
                case 3:
                    location.Menu();
                    break;
                case 4:
                    department.Menu();
                    break;
                case 5:
                    employee.Menu();
                    break;
                case 6:
                    history.Menu();
                    break;
                case 7:
                    job.Menu();
                    break;
                case 8:
                    linq.GetEmployees();
                    break;
                case 9:
                    linq.GetDepartments();
                    break;
                case 0:
                    Message.LogoutSuccess();
                    Message.ClickAnyKeyForContinue();
                    mainView.Menu();
                    break;
                default:
                    Message.InputOnlyMenu();
                    Message.ClickAnyKeyForContinue();
                    crudView.Menu();
                    break;
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            crudView.Menu();
        }
    }
}
