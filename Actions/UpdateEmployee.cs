using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    class UpdateEmployee
    {
        public static void CollectInput()
        {
            Console.Clear();

            EmployeeRepository employeeRepo = new EmployeeRepository();

            List<Employee> allEmployees = employeeRepo.GetAllEmployees();
            Console.WriteLine("Let's update a employee\n");

            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"{employee.Id} {employee.FirstName} {employee.LastName}");
            }

            Console.WriteLine("Which employee would you like to update?");
            Console.Write("> ");
            var updateEmployId = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("What would you like to rename this employee?");
            Console.Write("> ");
            var employNameUpdate = Console.ReadLine();

            var UpdateEmployInfo = new Employee()
            {
                Id = updateEmployId,
                FirstName = employNameUpdate,
                LastName = employNameUpdate
            };

            employeeRepo.UpdateEmployee(updateEmployId, UpdateEmployInfo);

            Console.Clear();

            Console.WriteLine("The employee has been updated!\n");



            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}