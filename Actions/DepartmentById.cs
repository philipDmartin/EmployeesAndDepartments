using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    class DepartmentById
    {
        public static void CollectInput()
        {
            Console.Clear();

            DepartmentRepository departmentRepo = new DepartmentRepository();

            Console.WriteLine("Please enter the integer ID of the department you'd like to get:");
            Console.Write("> ");
            int option = int.Parse(Console.ReadLine());


            Department department = departmentRepo.GetDepartmentById(option);

            Console.WriteLine("Here's the department you requested:");

            Console.WriteLine($"{department.Id} {department.DeptName}");

            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}