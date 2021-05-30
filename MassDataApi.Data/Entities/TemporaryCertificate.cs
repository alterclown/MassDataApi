using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Data.Entities
{
    public class TemporaryCertificate
    {
        [Key]
        public int TemporaryCertificateId { get; set; }
        [Required(ErrorMessage = "RegNumber is required.")]
        public int RegNumber { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "FathersName is required.")]
        public string FathersName { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile is required.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "ApplyDate is required.")]
        public DateTime ApplyDate { get; set; }
        [Required(ErrorMessage = "TranIt is required.")]
        public string TranIt { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }
    }
}
