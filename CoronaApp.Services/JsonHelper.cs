using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    class JsonHelper
    {
        public static void WriteObjectToJsonFile(object obj, string fileNmae)
        {
            string patientContext = JsonSerializer.Serialize(obj, new JsonSerializerOptions() { WriteIndented = true });
            using (StreamWriter outputFile = new StreamWriter(fileNmae))
            {
                outputFile.WriteLine(patientContext);
            }
        }
    }
}
