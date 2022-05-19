using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson1Location.Models
{
    public class Patient
    {
        public string PatientId { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
    }
}
