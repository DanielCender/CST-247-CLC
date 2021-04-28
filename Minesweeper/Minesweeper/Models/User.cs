using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(int userId, string firstName, string lastName, bool gender, int age, string state, string email, string userName, string password)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Age = age;
            State = state;
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
