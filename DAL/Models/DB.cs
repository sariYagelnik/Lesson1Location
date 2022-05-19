using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson1Location.Models
{
    public static class DB
    {
        public static List<Patient> Patients { get; set; }
            //= new List<Patient>();
        static DB()
        {
            using (StreamReader r = new StreamReader("data.json"))
            {
                string json = r.ReadToEnd();
                Patients = JsonSerializer.Deserialize<List<Patient>>(json);
            }
        }
    }
}
