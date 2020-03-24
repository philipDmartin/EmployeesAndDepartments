using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    class AddDepartment
    {
        public static void CollectInput()
        {
            Console.Clear();

            DepartmentRepository departmentRepo = new DepartmentRepository();

            Console.WriteLine("Please enter the name of the department you'd like to add:");
            Console.Write("> ");
            var option = Console.ReadLine();

            Department department = new Department()
            {
                DeptName = option
            };

            departmentRepo.AddDepartment(department);
            Console.WriteLine($"The {option} department has been added to the departments!");

            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}
