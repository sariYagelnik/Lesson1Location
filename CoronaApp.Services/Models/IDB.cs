using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoronaApp.Services.Models
{
    public interface IDB
    {
        List<Patient> Patients { get; set; }
    }
}
