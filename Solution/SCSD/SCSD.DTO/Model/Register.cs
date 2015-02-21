using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SCSD.DTO.Model
{
    public class Register
    {
        public string UserId { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage="Name required")]
        public string Name { get; set; }

        [Display(Name="Age")]
        [Required(ErrorMessage="Age required")]
        [RegularExpression("[0-9]{2}",ErrorMessage="Not valid age")]        
        public string Age { get; set; }

        [Display(Name="Gender")]
        [Required(ErrorMessage="Gender required")]
        public string Gender { get; set; }

        [Display(Name="Date Of Birth")]
        [Required]
        public string DOB { get; set; }

        [Display(Name="Marial Status")]
        [Required]
        public string Marital { get; set; }

        [Display(Name="User Name")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Display(Name="Password")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        [Display(Name="Confirm Password")]
        [Required]
        [Compare("Password",ErrorMessage="Password Not Match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Type")]
        [Required]
        public string UserType { get; set; }

        [Display(Name = "Group Type")]
        [Required]
        public string UserGroupType { get; set; }

        public Dictionary<int, string> UserTypes { get; set; }
        public Dictionary<int, string> UserGroups { get; set; }
        public List<string> Maritals { get; set; }
    }

    public class UserDetail
    {
        public string UserId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age required")]
        [RegularExpression("[0-9]{2}", ErrorMessage = "Not valid age")]
        public string Age { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender required")]
        public string Gender { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required]
        public string DOB { get; set; }

        [Display(Name = "Marial Status")]
        [Required]
        public string Marital { get; set; }

        [Display(Name = "User Name")]        
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }        

        [Display(Name = "Type")]
        [Required]
        public string UserType { get; set; }

        [Display(Name = "Group Type")]
        [Required]
        public string UserGroupType { get; set; }

        public Dictionary<int, string> UserTypes { get; set; }
        public Dictionary<int, string> UserGroups { get; set; }
        public List<string> Maritals { get; set; }
    }
}
