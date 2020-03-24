using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    class DeleteEmployee
    {
        public static void CollectInput()
        {
            Console.Clear();

            EmployeeRepository EmployeeRepo = new EmployeeRepository();

            List<Employee> allEmployees = EmployeeRepo.GetAllEmployees();
            Console.WriteLine("Let's delete a employee\n");

            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"{employee.Id} {employee.FirstName} {employee.LastName}");
            }

            Console.WriteLine("\nWhich employee would you like to delete?\n");
            Console.Write("> ");
            var employId = int.Parse(Console.ReadLine());

            EmployeeRepo.DeleteEmployee(employId);
            Console.WriteLine($"The employee has been deleted!");

            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}