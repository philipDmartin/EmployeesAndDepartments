using System;
using System.Collections.Generic;
using System.Text;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Actions
{
    class UpdateDepartment
    {
        public static void CollectInput()
        {
            Console.Clear();

            DepartmentRepository departmentRepo = new DepartmentRepository();

            List<Department> allDepartments = departmentRepo.GetAllDepartments();
            Console.WriteLine("Let's update a department\n");

            foreach (var department in allDepartments)
            {
                Console.WriteLine($"{department.Id} {department.DeptName}");
            }

            Console.WriteLine("Which department would you like to update?");
            Console.Write("> ");
            var updateDeptId = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("What would you like to rename this department?");
            Console.Write("> ");
            var deptNameUpdate = Console.ReadLine();

            var UpdateDeptInfo = new Department()
            {
                Id = updateDeptId,
                DeptName = deptNameUpdate,
            };

            departmentRepo.UpdateDepartment(updateDeptId, UpdateDeptInfo);

            Console.Clear();

            Console.WriteLine("The department has been updated!\n");



            Console.WriteLine("\nEnter anything to return to the main menu");
            Console.ReadLine();
        }
    }
}