using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SCSD.DTO.Model
{
    public class LoginUser
    {
        [Display(Name = "User Name")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class ForgotPassword
    {
        [Display(Name = "User Name")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePassword
    {
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }

    }
}
