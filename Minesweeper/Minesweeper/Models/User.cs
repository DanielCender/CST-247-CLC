using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Minesweeper.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "The field Gender must be selected.")]
        public bool Gender { get; set; }
        [Required]
        [Range(0, 120, ErrorMessage = "Please enter valid integer Number")]
        public int Age { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string State { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4)]
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
