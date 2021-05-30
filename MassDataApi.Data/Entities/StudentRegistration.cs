using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Data.Entities
{
    public class StudentRegistration
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "RegNumber is required.")]
        public int RegNumber { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
