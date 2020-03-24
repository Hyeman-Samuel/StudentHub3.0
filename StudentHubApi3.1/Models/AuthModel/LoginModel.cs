using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Models.AuthModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Incorrect Password")]
        public string Password { get; set; }
    }
}
