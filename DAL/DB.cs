using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoronaApp.Services.Models
{
    public class DB: IDB
    {
        public List<Patient> Patients { get; set; }
        public DB()
        {
            //string srcJsonFile ="../../"
            using (StreamReader r = new StreamReader("data.json"))
            {
                string json = r.ReadToEnd();
                Patients = JsonSerializer.Deserialize<List<Patient>>(json);
            }
        }
    }
}
