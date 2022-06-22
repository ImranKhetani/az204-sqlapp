using sqlapp.Models;

namespace sqlapp.Services
{
    public interface IEmployeeDB
    {
        List<Employee> GetEmployees();
    }
}