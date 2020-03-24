using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    class DeleteDepartment
    {
        public static void CollectInput()
        {
            Console.Clear();

            DepartmentRepository departmentRepo = new DepartmentRepository();

            List<Department> allDepartments = departmentRepo.GetAllDepartments();
            Console.WriteLine("Let's delete a department\n");

            foreach (var department in allDepartments)
            {
                Console.WriteLine($"{department.Id} {department.DeptName}");
            }

            Console.WriteLine("\nWhich department would you like to delete?\n");
            Console.Write("> ");
            var deptId = int.Parse(Console.ReadLine());

            departmentRepo.DeleteDepartment(deptId);
            Console.WriteLine($"The department has been deleted!");

            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}