using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    class AddEmployee
    {
        public static void CollectInput()
        {
            Console.Clear();

            DepartmentRepository departmentRepo = new DepartmentRepository();

            EmployeeRepository employeeRepo = new EmployeeRepository();

            Console.WriteLine("Let's make a new Employee");
            Console.WriteLine("First Name");
            var firstName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Last Name");
            var lastName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Dept ID");
            var department = Console.ReadLine();

            Console.Clear();
            Employee newEmployee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                DepartmentId = int.Parse(department)
            };

            employeeRepo.AddEmployee(newEmployee);

            Console.WriteLine($"{firstName} has been added to the employees!\n");

            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}