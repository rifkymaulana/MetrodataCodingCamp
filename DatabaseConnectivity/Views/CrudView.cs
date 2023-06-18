using DatabaseConnectivity.Controllers;

namespace DatabaseConnectivity.Views;


class CrudView
{
    public void Menu()
    {
        CrudController crud = new CrudController();
        Console.Clear();
        Console.WriteLine("++ Crud Menu ++");
        Console.WriteLine("1. Crud Region");
        Console.WriteLine("2. Crud Country");
        Console.WriteLine("3. Crud Location");
        Console.WriteLine("4. Crud Department");
        Console.WriteLine("5. Crud Employee");
        Console.WriteLine("6. Crud History");
        Console.WriteLine("7. Crud Job");
        Console.WriteLine("8. Show Employees with limit");
        Console.WriteLine("9. Show Departments that have more than 3 employees");
        Console.WriteLine("0. Logout");
        Console.Write("Please select menu: ");
        crud.Menu();
    }
}
