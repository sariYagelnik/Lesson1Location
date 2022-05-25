using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Services.Models
{
    public class Patient
    {
        public string PatientId { get; set; }
        [Required(ErrorMessage ="required"), MaxLength(20, ErrorMessage = "Not more than 20 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "required"), MinLength(1,ErrorMessage ="At least one location")]
        public List<Location> Locations { get; set; }
    }
}
