namespace ObjectOrientedProgrammingCSharp
{
    internal class Auth
    {
        public bool Authentication(List<User> users, string Email, string Password)
        {
            foreach (var user in users)
            {
                if (Email == user.Email && Password == user.Password)
                {
                    user.IsLogin = true;
                    return true;
                }
            }
            return false;
        }

        public bool ValidateUser(List<User> users, string Email)
        {
            foreach (User user in users)
            {
                if (user.Email == Email) return true;
            }
            return false;
        }

        public string ValidateName(string Name)
        {
            bool IsNumber = Name.Any<char>(new Func<char, bool>(char.IsNumber));

            if (!IsNumber)
            {
                return Name;
            }
            else
            {
                Console.WriteLine(" Name cannot be numeric.");
                Console.Write(" Name\t: ");
                Name = this.ValidateName(Console.ReadLine() ?? "");
                return Name;
            }
        }

        public string ValidateEmail(string Email)
        {
            if (Email.Contains('@') && Email.Contains('.') && !(Email == ""))
            {
                return Email;
            }
            else
            {
                Console.WriteLine(" Invalid email. Please input email with @ symbol (example@mii.com)");
                Console.Write(" Email\t: ");
                Email = this.ValidateEmail(Console.ReadLine() ?? "");
                return Email;
            }
        }

        public string ValidatePassword(string Password)
        {
            bool IsUppercase = Password.Any<char>(new Func<char, bool>(char.IsUpper));
            bool IsLowercase = Password.Any<char>(new Func<char, bool>(char.IsLower));
            bool IsNumber = Password.Any<char>(new Func<char, bool>(char.IsNumber));
            if (Password.Length >= 8 && IsUppercase && IsLowercase && IsNumber)
            {
                return Password;
            }
            else
            {
                Console.WriteLine("\n Password must have at least 8 characters\n with at least one Capital letter\n at least one lower case letter\n and at least one number.");
                Console.Write(" Password: ");
                Password = this.ValidatePassword(Auth.HasingPassword());
                return Password;
            }
        }

        public bool ValidatePassword(List<User> Users, int id, string Password)
        {

            if (Users[id - 1].Password == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ValidateIsAdmin(string IsAdmin)
        {

            if (IsAdmin.ToLower() == "yes" || IsAdmin.ToLower() == "no")
            {
                return IsAdmin;
            }
            else
            {
                Console.WriteLine(" Invalid input, just select yes or no");
                Console.Write(" Are you admin? (Yes/No): ");
                IsAdmin = this.ValidateIsAdmin(Console.ReadLine() ?? "");
                return IsAdmin;
            }
        }

        public static string HasingPassword()
        {
            string password = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                // Skip if Backspace or Enter is Pressed
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        // Remove last charcter if Backspace is Pressed
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Getting Password Once Enter is Pressed
            while (keyInfo.Key != ConsoleKey.Enter);
            return password;
        }
    }
}
