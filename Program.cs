using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
        List<Employee> employees = GetEmployees();

        PrintEmployees(employees);
       
    }
    static List<Employee> GetEmployees() 
    {
        //return a list of employees
        List<Employee> employees = new List<Employee>();
        while(true) {

            Console.WriteLine("Please enter a name: ");
            // Get a name from the console and assign it to a variable
            string input = Console.ReadLine();
            if( input == "") {
                break;
            }
            Employee currentEmployee = new Employee(input, "smith");
            employees.Add(currentEmployee);
        }
        // return the list of employees
        return employees;
    }
    static void PrintEmployees(List<Employee> employees)
    {
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine(employees[i].GetName());
        }
    }
  }
}