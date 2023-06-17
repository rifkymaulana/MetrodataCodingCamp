using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Controllers;

class Authentication
{
    protected static Employee _employee = new Employee();

    protected static List<Employee> employees = _employee.GetAll();


    public bool Login(string Email, string Password)
    {
        /*
         * Account for login with email and password:
         * Email = john.doe@example.com
         * Password = 1AD
         */
        foreach (var employee in employees)
        {
            if (employee.Email == Email && ($"{employee.Id}{employee.JobId}" == Password))
            {
                return true;
            }
            else if (employee.Email == Email || ($"{employee.Id}{employee.JobId}" != Password))
            {
                Console.WriteLine("Incorrect password");
                return false;
            }
        }

        return true;
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