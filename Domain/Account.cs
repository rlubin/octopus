﻿namespace domain
{
    public class Account
    {
        public Account(int userId, string username, string email, string password)
        {
            this.UserId = userId;
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
    }
}
