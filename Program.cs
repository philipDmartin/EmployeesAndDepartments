﻿using System;
using System.Collections.Generic;
using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            DepartmentRepository departmentRepo = new DepartmentRepository();

            Console.WriteLine("Getting All Departments:");
            List<Department> allDepartments = departmentRepo.GetAllDepartments();

            foreach (Department dept in allDepartments)
            {
                Console.WriteLine($"{dept.Id} {dept.DeptName}");
            }

            EmployeeRepository employeeRepo = new EmployeeRepository(); 

            Console.WriteLine("Getting all the employees and there department");
            List<Employee> allEmployees = employeeRepo.GetAllEmployeesWithDepartment();

            foreach (Employee employ in allEmployees)
            {
                Console.WriteLine($"{employ.FirstName} {employ.LastName} {employ.Department.DeptName}");
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Department with Id 1");

            Department legalDept = new Department
            {
                DeptName = "Legal"
            };

            departmentRepo.AddDepartment(legalDept);

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Added the new Legal Department!");

            Department singleDepartment = departmentRepo.GetDepartmentById(1);

            Console.WriteLine($"{singleDepartment.Id} {singleDepartment.DeptName}");
        }

    }
}
