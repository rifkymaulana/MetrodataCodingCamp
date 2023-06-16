
namespace DatabaseConnectivity.Controllers;

static class Authentication
{
    /*protected static Employee employee = new Employee();

    protected static List<Employee> employees = employee.GetAllEmployees();*/
    public static bool Login(string email, string password)
    {
        /*foreach (var employee in employees)
        {
            if (employee.email == email && ($"{employee.id}{employee.jobId}" == password))
            {
                return true;
            }
            else if (employee.email == email || ($"{employee.id}{employee.jobId}" == password))
            {
                Console.WriteLine("Incorrect password");
                return false;
            }
        }*/
        return true;
    }
}