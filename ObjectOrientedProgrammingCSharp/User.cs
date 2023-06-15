namespace ObjectOrientedProgrammingCSharp
{
    internal class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLogin { get; set; }
        public User(string Name, string Email, string Password, string IsAdmin)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            if (IsAdmin.ToLower() == "yes")
            {
                this.IsAdmin = true;
            } else
            {
                this.IsAdmin= false;
            }
        }

        public User() {
            this.Name = "";
            this.Email = "";
            this.Password = "";
            this.IsAdmin = false;
         }
    }
}
