﻿using System;
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

            Console.WriteLine("Please enter a name (leave empty to exit): ");
            // Get a name from the console and assign it to a variable
            string firstName = Console.ReadLine();
            if( firstName == "") {
                break;
            }
            // add a Console.ReadLine() for each value of employee
            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter ID: ");
            int id = Console.ReadLine();
            string photoUrl = Console.ReadLine();

            Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
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