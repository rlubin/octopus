namespace domain
{
    public class Account
    {
        public Account(int userId, string username, string email, string password)
        {
            this.userId = userId;
            this.username = username;
            this.email = email;
            this.password = password;
        }

        public int userId { get; set; }
        public string username { get; set; }
        public string email{ get; set; }
        public string password { get; set; }
    }
}
