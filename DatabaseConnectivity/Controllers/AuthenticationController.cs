using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers;


class AuthenticationController
{
    protected static Employee _employee = new Employee();
    protected static List<Employee> employees = _employee.GetAll();


    public void Login(string Email, string Password)
    {
        CrudView crudView = new CrudView();
        MainView mainView = new MainView();
        try
        {
            List<bool> auth = this.Authentication(Email, Password);

            if (auth[0])
            {
                Message.LoginSuccess();
                Message.ClickAnyKeyForContinue();
                crudView.Menu();
            }
            else if (!(auth[0]) && auth[1])
            {
                Message.IncorrectPassword();
                Message.ClickAnyKeyForContinue();
                mainView.Menu();
            }
            else if (!(auth[0]) && !(auth[1]))
            {
                Message.AccountNotFound();
                Message.ClickAnyKeyForContinue();
                mainView.Menu();
            }
        }
        catch (Exception)
        {
            Message.LoginFailed();
            Message.ClickAnyKeyForContinue();
            mainView.Menu();
        }
    }

    private List<bool> Authentication(string Email, string Password)
    {
        List<bool> auth = new List<bool>();
        foreach (var employee in employees)
        {
            if (employee.Email == Email && ($"{employee.Id}{employee.JobId}" == Password))
            {
                auth.Add(true);
                break;
            }
            else if (employee.Email == Email && ($"{employee.Id}{employee.JobId}" != Password))
            {
                auth.Add(false);
                auth.Add(true);
                break;
            }
            else
            {
                auth.Add(false);
                auth.Add(false);
            }
        }
        return auth;
    }


    public bool ChangePassword(string Email, string Password, string NewPassword)
    {
        foreach (var employee in employees)
        {
            if (employee.Email == Email && ($"{employee.Id}{employee.JobId}" == Password))
            {
                employee.Password = NewPassword;
                return true;
            }
            else if (employee.Email == Email || ($"{employee.Id}{employee.JobId}" != Password))
            {
                Console.WriteLine("Incorrect password");
                return false;
            }
        }
        return false;
    }
}