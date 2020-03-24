using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    class EmployeeById
    {
        public static void CollectInput()
        {
            Console.Clear();

            EmployeeRepository employeeRepo = new EmployeeRepository();

            Console.WriteLine("Please enter the integer ID of the employee you'd like to get:");
            Console.Write("> ");
            int option = int.Parse(Console.ReadLine());


            Employee employee = employeeRepo.GetEmployeeById(option);

            Console.WriteLine("Here's the employee you requested:");

            Console.WriteLine($"{employee.Id} {employee.FirstName} {employee.LastName}");

            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}