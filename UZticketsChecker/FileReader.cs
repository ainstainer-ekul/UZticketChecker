using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZticketsChecker
{
    class FileReader
    {
        public static List<String> GetParamtersList()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\routeData.txt");
            List<String> parametersList = new List<String>();

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                parametersList.Add(line);
            }
            file.Close();
            return parametersList;
        }
    }
}
