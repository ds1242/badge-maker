using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
        List<string> employees = GetEmployees();

        PrintEmployees(employees);
       
    }
    static List<string> GetEmployees() 
    {
        //return a list of employees
        List<string> employees = new List<string>();
        while(true) {

            Console.WriteLine("Please enter a name: ");
            // Get a name from the console and assign it to a variable
            string input = Console.ReadLine();
            if( input == "") {
                break;
            }
            Employee currentEmployee = new Employee();
            employees.Add(input);
        }
        // return the list of employees
        return employees;
    }
    static void PrintEmployees(List<string> employees)
    {
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine(employees[i]);
        }
    }
  }
}