using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    class EmployeesWithDepartment
    {
        public static void CollectInput()
        {
            Console.Clear();

            EmployeeRepository employeeRepo = new EmployeeRepository();

            Console.WriteLine("Employees and their department:\n");

            List<Employee> allEmployeesWithDepartment = employeeRepo.GetAllEmployeesWithDepartment();

            foreach (Employee emp in allEmployeesWithDepartment)
            {
                Console.WriteLine($"{emp.Id} {emp.FirstName} {emp.LastName} {emp.Department.DeptName}");
            }

            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}