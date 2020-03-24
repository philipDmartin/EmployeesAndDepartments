using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Data
{    
    public class EmployeeRepository
    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DepartmentsEmployees;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Employee> GetAllEmployeesWithDepartment()
        {
            //  We must "use" the database connection.
            //  Because a database is a shared resource (other applications may be using it too) we must
            //  be careful about how we interact with it. Specifically, we Open() connections when we need to
            //  interact with the database and we Close() them when we're finished.
            //  In C#, a "using" block ensures we correctly disconnect from a resource even if there is an error.
            //  For database connections, this means the connection will be properly closed.
            using (SqlConnection conn = Connection)
            {
                // Note, we must Open() the connection, the "using" block   doesn't do that for us.
                conn.Open();

                // We must "use" commands too.
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Here we setup the command with the SQL we want to execute before we execute it.
                    cmd.CommandText = @"SELECT e.Id, e.FirstName, e.LastName, e.DepartmentId, d.Id, d.DeptName
                      FROM Employee e
                      LEFT JOIN Department d
                      ON e.DepartmentId = d.Id";

                    // Execute the SQL in the database and get a "reader" that will give us access to the data.
                    SqlDataReader reader = cmd.ExecuteReader();

                    // A list to hold the departments we retrieve from the database.
                    List<Employee> employees = new List<Employee>();

                    // Read() will return true if there's more data to read
                    while (reader.Read())
                    {
                        // The "ordinal" is the numeric position of the column in the query results.
                        //  For our query, "Id" has an ordinal value of 0 and "DeptName" is 1.
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int firstNameColumn = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(firstNameColumn);

                        int lastNameColumn = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(lastNameColumn);

                        int departmentIdColumn = reader.GetOrdinal("DepartmentId");
                        int departmentValue = reader.GetInt32(departmentIdColumn);

                        int departmentNameColumn = reader.GetOrdinal("DeptName");
                        string departmentNameValue = reader.GetString(departmentNameColumn);

                        var employee = new Employee()
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            DepartmentId = departmentValue,
                            Department = new Department()
                            {
                                Id = departmentValue,
                                DeptName = departmentNameValue
                            }
                        };

                        // ...and add that department object to our list.
                        employees.Add(employee);
                    }

                    // We should Close() the reader. Unfortunately, a "using" block won't work here.
                    reader.Close();

                    // Return the list of departments who whomever called this method.
                    return employees;
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT e.Id, e.FirstName, e.LastName, e.DepartmentId, d.Id, d.DeptName
                      FROM Employee e
                      LEFT JOIN Department d
                      ON e.DepartmentId = d.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Employee> employees = new List<Employee>();

                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int firstNameColumn = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(firstNameColumn);

                        int lastNameColumn = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(lastNameColumn);

                        int departmentIdColumn = reader.GetOrdinal("DepartmentId");
                        int departmentValue = reader.GetInt32(departmentIdColumn);

                        int departmentNameColumn = reader.GetOrdinal("DeptName");
                        string departmentNameValue = reader.GetString(departmentNameColumn);

                        var employee = new Employee()
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            DepartmentId = departmentValue,
                            Department = new Department()
                            {
                                Id = departmentValue,
                                DeptName = departmentNameValue
                            }
                        };

                        employees.Add(employee);
                    }

                    reader.Close();

                    return employees;
                }
            }
        }

        /// <summary>
        ///  Returns a single department with the given id.
        /// </summary>
        public Employee GetEmployeeById(int employeeid)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT e.Id, e.FirstName, e.LastName, e.DepartmentId, d.Id, d.DeptName
                        FROM Employee e
                        LEFT JOIN Department d
                        ON e.DepartmentId = d.Id
                        WHERE e.Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", employeeid));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Employee employee = null;

                    // If we only expect a single row back from the database, we don't need a while loop.
                    if (reader.Read())
                    {
                        // Get ordinal returns us what "position" the Id column is in
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                       
                        int firstNameColumn = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(firstNameColumn);

                        int lastNameColumn = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(lastNameColumn);

                        int departmentIdColumn = reader.GetOrdinal("DepartmentId");
                        int departmentValue = reader.GetInt32(departmentIdColumn);

                        int departmentNameColumn = reader.GetOrdinal("DeptName");
                        string departmentNameValue = reader.GetString(departmentNameColumn);

                        employee = new Employee()
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            DepartmentId = departmentValue,
                            Department = new Department()
                            {
                                Id = departmentValue,
                                DeptName = departmentNameValue
                            }
                        };

                        reader.Close();

                    return employee;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        ///  Add a new department to the database
        ///   NOTE: This method sends data to the database,
        ///   it does not get anything from the database, so there is nothing to return.
        /// </summary>
        public Employee AddEmployee(Employee newEmployee)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Employee (FirstName, LastName, DepartmentId)
                        OUTPUT INSERTED.Id
                        VALUES (@firstName, @lastName, @departmentId)";

                    cmd.Parameters.Add(new SqlParameter("@firstName", newEmployee.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", newEmployee.LastName));
                    cmd.Parameters.Add(new SqlParameter("@departmentId", newEmployee.DepartmentId));

                    int id = (int)cmd.ExecuteScalar();

                    newEmployee.Id = id;

                    return newEmployee;
                }
            }
            // when this method is finished we can look in the database and see the new department.
        }

        public void UpdateEmployee(int Id, Employee employee)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Employee
                        SET Id = @id FirstName = @firstName, LastName = @lastName, DepartmentId = @departmentId
                        WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", Id));
                    cmd.Parameters.Add(new SqlParameter("@firstName", employee.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", employee.LastName));
                    cmd.Parameters.Add(new SqlParameter("@departmentId", employee.DepartmentId));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///  Delete the department with the given id
        /// </summary>
        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Employee WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", employeeId));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
