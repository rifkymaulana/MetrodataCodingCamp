using System.Data;
using System.Data.SqlClient;

namespace ObjectOrientedProgrammingCSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            User user1 = new User("admin", "admin@gmail.com", "admin", "yes");
            User user2 = new User("user", "user@gmail.com", "user", "no");
            User user3 = new User("aef", "aef@gmail.com", "aef", "yes");
            User user4 = new User("ihsan", "ihsan@gmail.com", "ihsan", "no");
            MainMenu menu = new MainMenu();
            menu.Users.Add(user1);
            menu.Users.Add(user2);
            menu.Users.Add(user3);   
            menu.Users.Add(user4);
            menu.App();
        }

    
    }
}
