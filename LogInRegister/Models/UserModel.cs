using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace LogInRegister.Models
{
    public class UserModel
    {   
        [Key]
        public int UserId { get; set; }


        [Required (ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
+ "@"
+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Please enter a valid Email.")]
        public string  Email { get; set; }
        
        [Required(ErrorMessage = "Password is Required")]
        [DataType (DataType.Password)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Password did not Matched")]
        [DataType (DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}