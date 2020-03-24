using System;
using DepartmentsEmployees.Actions;

namespace DepartmentsEmployees
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("YYYYYYYYYOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO\n");

                Console.WriteLine("1. Get all departments");

                Console.WriteLine("2. Get department by ID");

                Console.WriteLine("3. Add a department");

                Console.WriteLine("4. Update a department");

                Console.WriteLine("5. Delete a department");

                Console.WriteLine("6. Get all employees");

                Console.WriteLine("7. Get employee by ID");

                Console.WriteLine("8. Get employees with their department");

                Console.WriteLine("9. Add a employee");

                Console.WriteLine("10. Update a employee");

                Console.WriteLine("11. Delete a employee");

                Console.WriteLine("12. Exit");

                Console.WriteLine("YYYYYYYYYOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO\n");


                Console.WriteLine("Please Select an Action?");
                Console.Write("> ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    GetAllDepartments.CollectInput();
                }

                else if (option == "2")
                {
                    DepartmentById.CollectInput();
                }

                else if (option == "3")
                {
                    AddDepartment.CollectInput();
                }

                else if (option == "4")
                {
                    UpdateDepartment.CollectInput();
                }

                else if (option == "5")
                {
                    DeleteDepartment.CollectInput();
                }

                else if (option == "6")
                {
                    GetAllEmployees.CollectInput();
                }

                else if (option == "7")
                {
                    EmployeeById.CollectInput();
                }

                else if (option == "8")
                {
                    EmployeesWithDepartment.CollectInput();
                }

                else if (option == "9")
                {
                    AddEmployee.CollectInput();
                }

                else if (option == "10")
                {
                    UpdateEmployee.CollectInput();
                }

                else if (option == "11")
                {
                    DeleteEmployee.CollectInput();
                }

                else if (option == "12")
                {
                    Console.WriteLine("Exit");
                    Console.ReadLine();
                    break;
                }

                else
                {
                    Console.WriteLine($"Invalid : {option}");
                    Console.WriteLine($"");
                    Console.ReadLine();
                }
            }
        }
    }
}
