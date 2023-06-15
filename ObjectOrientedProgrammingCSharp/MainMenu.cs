using System.Collections.Generic;

namespace ObjectOrientedProgrammingCSharp
{
    internal class MainMenu
    {
        private Crud crud = new Crud();
        public List<User> Users = new List<User>();

        public void App()
        {
            /*Console.Clear();*/
            Console.WriteLine("===== Welcome to UserApp =====");
            Console.WriteLine(" 1. Login");
            Console.WriteLine(" 2. Don't have an account yet? Sign Up");
            Console.WriteLine(" 0. Exit");
            Console.Write(" Please select a menu (Input here) : ");
            int InputUser = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (InputUser)
                {
                    case 1:
                        this.LoginMenu(this.Users);
                        break;
                    case 2:
                        this.SignUpMenu(this.Users);
                        break;
                    case 0:
                        Logout();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(" Invalid input, Please select menu from 1, 2 or 0.");
                Console.ReadKey();
                this.App();
            }
        }

        public void LoginMenu(List<User> Users)
        {
            Auth Login = new Auth();
            Console.Clear();
            Console.WriteLine("===== Login Menu =====");
            Console.Write(" Email\t  : ");
            string Email = Console.ReadLine() ?? "";
            Console.Write(" Password : ");
            string Password = Auth.HasingPassword();

            foreach (var user in Users)
            {
                if ( (user.Email == Email) && !(user.Password == Password) )
                {
                    Console.WriteLine("\n Password incorrect");
                    Console.WriteLine(" Press any key to continue...");
                    Console.ReadKey();
                    this.App();
                }
            }


            if (Login.Authentication(Users, Email, Password))
            {
                User user;
                Console.WriteLine($"\n Welcome {Email}, Login Successful");
                Console.WriteLine(" Press any key to continue...");
                Console.ReadKey();
                foreach (var item in Users)
                {
                    if (item.Email == Email)
                    {
                        user = item;
                        if (user.IsAdmin == true)
                        {
                            UserManagementMenu();
                            break;
                        }
                        else
                        {
                            CheckNumberMenu();
                            break;
                        }
                    }
                }

            } else
            {
                Console.WriteLine("\n Account not found! please sign up first...");
                Console.WriteLine(" Press any key to continue...");
                Console.ReadKey();
                this.App();
            }
        }

        public void UserManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("===== User Management Menu =====");
            Console.WriteLine(" 1. Create User");
            Console.WriteLine(" 2. Show Users");
            Console.WriteLine(" 3. Search User");
            Console.WriteLine(" 4. Update User");
            Console.WriteLine(" 5. Delete User");
            Console.WriteLine(" 0. Logout");
            Console.Write(" Please select a menu (Input here) : ");
            int InputUser = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (InputUser)
                {
                    case 1:
                        this.CreateUserMenu(this.Users);
                        break;
                    case 2:
                        this.ShowUser(this.Users);
                        break;
                    case 3:
                        this.SearchUser(this.Users);
                        break;
                    case 4:
                        User user = new User();
                        this.EditUser(this.Users, user);
                        break;
                    case 5:
                        this.DeleteUser(this.Users);
                        break;
                    case 0:
                        this.Logout("logout");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(" Invalid input, Please select menu from 1 to 5 or 0.");
                Console.ReadKey();
            }
        }

        public static void CheckNumberMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Check Number Menu =====");
            Console.WriteLine(" 1. Check Odd Even");
            Console.WriteLine(" 2. Print Odd/Even (with limit)");
            Console.WriteLine(" 0. Logout");

            Console.Write(" Please select a menu (Input here) : ");
            int InputUser = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (InputUser)
                {
                    case 1:
                        Console.Write(" Enter the number you want to check : ");
                        try
                        {
                            int input_number = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(CheckNumber.EvenOddCheck(input_number));
                            Console.WriteLine(" Press any key to continue...");
                            Console.ReadKey();
                            MainMenu.CheckNumberMenu();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine(" Invalid number input. Please enter an integer.");
                        }
                        break;
                    case 2:
                        Console.Write(" Select (Odd/Even) : ");
                        string even_or_odd = (Console.ReadLine() ?? "").Trim();
                        Console.Write(" Enter limits : ");
                        try
                        {
                            int input_limit = Convert.ToInt32(Console.ReadLine());
                            CheckNumber.PrintEvenOdd(input_limit, even_or_odd);
                            Console.WriteLine(" Press any key to continue...");
                            Console.ReadKey();
                            MainMenu.CheckNumberMenu();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine(" Invalid number input. Please enter an integer.");
                        }
                        break;
                    case 0:
                        MainMenu logout = new MainMenu();
                        logout.Logout("logout");
                        break;
                    default:
                        Console.WriteLine(" Invalid input, Please select menu from 1, 2 or 0.");
                        CheckNumberMenu();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(" Invalid input, Please select menu from 1 to 5 or 0.");
                Console.ReadKey();
            }
        }

        public void SignUpMenu(List<User> User)
        {
            Auth SignUp = new Auth();
            Console.Clear();
            Console.WriteLine("===== Create User Menu =====");
            Console.Write(" Name\t : ");
            string Name = SignUp.ValidateName(Console.ReadLine() ?? "");
            Console.Write(" Email\t : ");
            string Email = SignUp.ValidateEmail(Console.ReadLine() ?? "");
            Console.Write(" Are you admin? (Yes/No): ");
            string IsAdmin = SignUp.ValidateIsAdmin(Console.ReadLine() ?? "");
            Console.Write(" Password: ");
            string Password = SignUp.ValidatePassword(Auth.HasingPassword());
            User user = new User(Name, Email, Password, IsAdmin);
            Console.WriteLine(this.crud.Create(Users, user));
            Console.WriteLine(" Press any key to continue...");
            Console.ReadKey();
            this.App();
        }

        public void CreateUserMenu(List<User> User)
        {
            Auth SignUp = new Auth();
            Console.Clear();
            Console.WriteLine("===== Create User Menu =====");
            Console.Write(" Name\t : ");
            string Name = SignUp.ValidateName(Console.ReadLine() ?? "");
            Console.Write(" Email\t : ");
            string Email = SignUp.ValidateEmail(Console.ReadLine() ?? "");
            Console.Write(" Are you admin? (Yes/No): ");
            string IsAdmin = SignUp.ValidateIsAdmin(Console.ReadLine() ?? "");
            Console.Write(" Password: ");
            string Password = SignUp.ValidatePassword(Auth.HasingPassword());
            User user = new User(Name, Email, Password, IsAdmin);
            Console.WriteLine(this.crud.Create(Users, user));
            Console.WriteLine(" Press any key to continue...");
            Console.ReadKey();
            this.UserManagementMenu();
        }

        public void ShowUser(List<User> Users)
        {
            User User = new User();
            Console.Clear();
            this.crud.View(Users);
            Console.WriteLine(" Press any key to continue...");
            Console.ReadKey();
            this.UserManagementMenu();
        }

        public void SearchUser(List<User> User)
        {
            List<User> userList = new List<User>();
            Console.Clear();
            Console.WriteLine("===== Search Menu =====");
            Console.Write(" Input Name/Email : ");
            string Input = Console.ReadLine() ?? "";
            this.crud.View(User.Where<User>((Func<User, bool>)(i => i.Name.ToLower().Contains(Input.ToLower()) || i.Email.ToLower().Contains(Input.ToLower()))).Select<User, User>((Func<User, User>)(User => new User()
            {
                Name = User.Name,
                Email = User.Email,
                Password = User.Password
            })).ToList<User>());
            Console.WriteLine(" Press any key to continue...");
            Console.ReadKey();
            this.UserManagementMenu();
        }

        public void EditUser(List<User> Users, User user)
        {

            bool flag;
            do
            {
                Console.Write("Id Yang Ingin Diubah : ");
                int int32 = Convert.ToInt32(Console.ReadLine());
                if (int32 <= Users.Count)
                {
                    Console.Write("Name : ");
                    user.Name = Console.ReadLine() ?? "";
                    Console.Write("Email : ");
                    user.Email = Console.ReadLine() ?? "";
                    Console.Write("Password : ");
                    user.Password = Auth.HasingPassword(); ;
                    Auth ValidatePassword = new Auth();
                    if (ValidatePassword.ValidatePassword(Users, int32, user.Password))
                    {
                        Console.WriteLine(this.crud.Edit(Users, user, int32));
                    }
                    else
                    {
                        Console.WriteLine(" Password error");
                        Console.WriteLine(" Press any key to continue...");
                        Console.ReadKey();
                        this.App();
                    }

                    flag = false;
                }
                else
                {
                    Console.WriteLine(" User not found!");
                    flag = true;
                }
            }
            while (flag);
            Console.ReadKey();
            this.ShowUser(Users);
        }

        public void DeleteUser(List<User> Users)
        {
            Console.Write(" ID you want to delete : ");
            int int32 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.crud.Delete(Users, int32));
            Console.ReadKey();
            this.ShowUser(Users);
        }

        public void Logout()
        {
            Console.WriteLine(" Thank you for using this app, have a nice day!");
            Environment.Exit(1);
        }

        public void Logout(string logout)
        {
            Console.WriteLine($" You're {logout}");
            Console.WriteLine(" Press any key to continue...");
            Console.ReadKey();
            this.App();
        }
    }
}
