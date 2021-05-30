using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Data.Entities
{
    
    public class Authentication : IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "RegNumber is required.")]
        public int RegNumber { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string Role { get; set; }
    }
}
