using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;


namespace CatWorx.BadgeMaker {
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees() 
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
                int id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Photo URL:");
                string photoUrl = Console.ReadLine();

                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            // return the list of employees
            return employees;
        }
        public static List<Employee> GetFromApi() {
            List<Employee> employees = new List<Employee>();
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                JObject json = JObject.Parse(response);
                foreach (JToken token in json.SelectToken("results"))
                {
                    Employee emp = new Employee
                    (
                        token.SelectToken("name.first").ToString(),
                        token.SelectToken("name.last").ToString(),
                        Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
                        token.SelectToken("picture.large").ToString()
                    );
                    employees.Add(emp);
                }
            }
            return employees;
        }
    }
}