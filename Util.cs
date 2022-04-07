using System;
using System.IO;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Util
    {
        // Add list parameter to method
        public static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                string template = "{0, -10}\t{1, -20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetID(), employees[i].GetName(), employees[i].GetPhotoURL()));
            }
        }
        public static void MakeCSV(List<Employee> employees)
        {
            if(!Directory.Exists("data"))
            {
                // It not, create the directory
                Directory.CreateDirectory("data");
            }
            using (StreamWriter file = new StreamWriter("data/empoyees.csv"))
            {
                file.WriteLine("ID,Name,PhotoURL");
            }
        }
    }
}