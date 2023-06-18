using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;


class HistoryView
{
    History _history = new History();
    void Main()
    {
        Console.Clear();
        Console.WriteLine("++ History Menu ++");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Show All");
        Console.WriteLine("3. Show By Id");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("9. Back");
        Console.Write("Please select menu: ");
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("Please, input 1, 2 3, 4 or 9");
                    Console.Write("Click any key for continue...");
                    Console.ReadKey();
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
        }
    }


    void GetAll()
    {
        Console.Clear();
        Console.WriteLine("++ Print Histories ++");
        _history.GetAll().ForEach(e =>
        {
            Console.WriteLine($"Start Date = {e.StartDate}");
            Console.WriteLine($"End Date = {e.EndDate}");
            Console.WriteLine($"Employee Id = {e.EmployeeId}");
            Console.WriteLine($"Department Id = {e.DepartmentId}");
            Console.WriteLine($"Job Id = {e.JobId}");
            Console.WriteLine();
        });
    }


    void GetByEmployeeId()
    {
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        Console.Write("Input Id: ");
        try
        {
            int id = Convert.ToInt32(Console.ReadLine());
            this.GetByEmployeeId(id);
            Console.Write("Click any key for continue...");
            Console.ReadKey();
        }
        catch (Exception)
        {
            Console.WriteLine("Please, input only number not alphabet");
            Console.Write("Click any key for continue...");
            Console.ReadKey();
        }
    }


    void GetByEmployeeId(int id)
    {
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        _history.GetByEmployeeId(id).ForEach(e =>
        {
            Console.WriteLine($"Start Date = {e.StartDate}");
            Console.WriteLine($"End Date = {e.EndDate}");
            Console.WriteLine($"Employee Id = {e.EmployeeId}");
            Console.WriteLine($"Department Id = {e.DepartmentId}");
            Console.WriteLine($"Job Id = {e.JobId}");
            Console.WriteLine();
        });
    }
}