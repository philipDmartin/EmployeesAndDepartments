using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    public class GetAllDepartments
    {
        public static void CollectInput()
        {
            Console.Clear();

            DepartmentRepository departmentRepo = new DepartmentRepository();

            List<Department> allDepartments = departmentRepo.GetAllDepartments();

            Console.WriteLine("Here are all the departments with their corresponding ID:");

            foreach (var department in allDepartments)
            {
                Console.WriteLine($"{department.Id} {department.DeptName}");
            }
            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}