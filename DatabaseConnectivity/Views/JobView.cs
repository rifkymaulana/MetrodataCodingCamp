using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;


class JobView
{
    private readonly Job _job = new Job();
    public void Menu()
    {
        Console.Clear();
        Console.WriteLine("++ Job Menu ++");
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


    void getAll()
    {
        Console.Clear();
        Console.WriteLine("++ Show All Region ++");
        _job.GetAll().ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Title = {e.Title}");
            Console.WriteLine($"Min Salary = {e.MinSalary}");
            Console.WriteLine($"Max Salary = {e.MaxSalary}");
            Console.WriteLine();
        });
    }


    void GetById()
    {
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        Console.Write("Input Id: ");
        try
        {
            int Id = Convert.ToInt32(Console.ReadLine());
            this.GetById(Id);
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


    private void GetById(int Id)
    {
        Console.Clear();
        Console.WriteLine("++ Show Region By Id ++");
        _job.GetById(Id).ForEach(e =>
        {
            Console.WriteLine($"Id = {e.Id}");
            Console.WriteLine($"Title = {e.Title}");
            Console.WriteLine($"Min Salary = {e.MinSalary}");
            Console.WriteLine($"Max Salary = {e.MaxSalary}");
            Console.WriteLine();
        });
    }
}
