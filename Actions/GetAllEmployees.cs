using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    class GetAllEmployees
    {
        public static void CollectInput()
        {
            Console.Clear();

            EmployeeRepository employeeRepo = new EmployeeRepository();

            List<Employee> allEmployees = employeeRepo.GetAllEmployees();

            Console.WriteLine("Here are all the employees with their corresponding ID:");

            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"{employee.Id} {employee.FirstName} {employee.LastName}");
            }
            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}