public class Program
{
    static void Menu()
    {
        Console.WriteLine("\n=====================================");
        Console.WriteLine("\tMENU GANJIL GENAP");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("1. Cek Ganjil Genap");
        Console.WriteLine("2. Print Ganjil/Genap (dengan limit)");
        Console.WriteLine("3. Exit");
        Console.WriteLine("-------------------------------------");

        Console.Write("Pilihan: ");
        string input_choice = Console.ReadLine();
        int choice;

        if (!int.TryParse(input_choice, out choice))
        {
            Console.WriteLine("Input pilihan tidak valid. Harap masukkan bilangan bulat.");
            Menu();
        }

        switch (choice)
        {
            case 1:
                Console.Write("Masukan bilangan yang ingin dicek : ");

                string input_number = Console.ReadLine();
                int number;

                if (!int.TryParse(input_number, out number))
                {
                    Console.WriteLine("Input bilangan tidak valid. Harap masukkan bilangan bulat.");
                    Menu();
                }
                Console.WriteLine(EvenOddCheck(number));
                Menu();
                break;
            case 2:
                Console.Write("Pilih (Ganjil/Genap) : ");
                string even_or_odd = Console.ReadLine().Trim();
                Console.Write("Masukan limit : ");
                string input_limit = Console.ReadLine();
                int limit;

                if (!int.TryParse(input_limit, out limit))
                {
                    Console.WriteLine("Input limit tidak valid. Harap masukkan bilangan bulat.");
                    Menu();
                }
                PrintEvenOdd(limit, even_or_odd);
                break;
            case 3:
                Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Input pilihan tidak valid!!!");
                Menu();
                break;
        }

    }

    static void PrintEvenOdd(int limit, string choice)
    {
        if (limit < 0)
        {
            Console.WriteLine($"Print bilangan 1 - {limit} : ");
            Console.WriteLine("Input limit tidak valid!!!");
            Menu();
        }

        List<int> numberList = new List<int>();

        if (choice.ToLower() == "ganjil")
        {
            for (int i = 1; i <= limit; i += 2)
            {
                numberList.Add(i);
            }

            Console.WriteLine($"Print bilangan 1 - {limit} : ");

            foreach (int i in numberList)
            {
                Console.Write($"{i}, ");
            }

            Menu();
        }
        else if (choice.ToLower() == "genap")
        {
            for (int i = 2; i <= limit; i += 2)
            {
                numberList.Add(i);
            }

            Console.WriteLine($"Print bilangan 1 - {limit} : ");

            foreach (int i in numberList)
            {
                Console.Write($"{i}, ");
            }

            Menu();
        }
        else
        {
            Console.WriteLine("Invalid input (silahkan pilih Ganjil atau Genap)!");
            Menu();
        }
    }

    static string EvenOddCheck(int number)
    {
        if (number < 0)
        {
            Console.WriteLine("Invalid input!!!");
            Menu();
        }

        if (number % 2 == 1)
        {
            return "Ganjil";
        }
        else
        {
            return "Genap";
        }
    }

    private static void Main(string[] args)

    {
        Menu();
    }
}