using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Models.AuthModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Firstname Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Username Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Incorrect Password")]
        public string Password { get; set; }
    }
}
