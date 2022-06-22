using sqlapp.Models;
using System.Data.SqlClient;

namespace sqlapp.Services
{
    public class EmployeeDB
    {
        private static string db_endpoint = "ikclassessqlserver.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "Azure@123";
        private static string db_database = "ikclassessqldb";

        private SqlConnection GetConnection()
        {
            var _builder=new SqlConnectionStringBuilder();
            _builder.DataSource = db_endpoint;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Employee> GetEmployees()
        {
            SqlConnection conn = GetConnection();

            List<Employee> employee = new List<Employee>();

            string statement = "SELECT EmployeeID,EmployeeName,Salary from Employee";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Employee _employee = new Employee()
                    {
                        EmployeeID = reader.GetInt32(0),
                        EmployeeName = reader.GetString(1),
                        Salary = reader.GetInt32(2)
                    };

                    employee.Add(_employee);
                }
            }
            conn.Close();

            return employee;
        }
    }
}
