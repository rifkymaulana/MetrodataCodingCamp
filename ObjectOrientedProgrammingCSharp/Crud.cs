using System.Runtime.CompilerServices;

namespace ObjectOrientedProgrammingCSharp
{
    internal class Crud
    {
        private string NotFound() => "\n User Not Found!";
        private string Success(string value) => $"\n User Success to {value}!";
        private string Failure(string value, string Email) => $"\n {value} failure, {Email} already exists!";

        public string Create(List<User> users, User user)
        {
            if (new Auth().ValidateUser(users, user.Email ?? ""))
                return this.Failure(nameof(Create), "Username");
            users.Add(user);
            return this.Success("Created");
        }

        public void View(List<User> Users)
        {
            int num = 0;
            foreach (User user in Users)
            {
                ++num;
                Console.WriteLine("=============================");
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
                interpolatedStringHandler.AppendLiteral(" ID\t: ");
                interpolatedStringHandler.AppendFormatted<int>(num);
                Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
                Console.WriteLine(" Name\t: " + user.Name);
                Console.WriteLine(" Email\t: " + user.Email);
                Console.WriteLine(" Admin\t: " + user.IsAdmin);
                Console.WriteLine("=============================");
            }
        }

        public string Edit(List<User> users, User user, int id)
        {
            users[id - 1].Name = user.Name;
            users[id - 1].Email = user.Email;
            users[id - 1].Password = user.Password;
            return this.Success("Edited");
        }

        public string Delete(List<User> users, int id)
        {
            if (id > users.Count) return this.NotFound();
            users.RemoveAt(id - 1);
            return this.Success("Deleted");
        }

    }
}
