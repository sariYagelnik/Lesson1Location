using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Services.Models
{
    public class Location
    {
        [Required(ErrorMessage ="required"), MinLength(2,ErrorMessage ="At Least 2 characters"), MaxLength(20, ErrorMessage = "Not more than 20 characters")]
        public string City { get; set; }
        [Required(ErrorMessage = "required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "required")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage ="required"), MinLength(2, ErrorMessage = "At Least 2 characters"), MaxLength(100, ErrorMessage = "Not more than 20 characters")]
        public string LocationDescription { get; set; }
    }
}
