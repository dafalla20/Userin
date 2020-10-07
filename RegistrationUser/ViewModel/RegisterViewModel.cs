using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationUser.ViewModel
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string UserName { get; set; }

        public string PassWord { get; set; }
        [Compare("PassWord", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string newPassWord { get; set; }
        [Compare("newPassWord", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }


    }
}