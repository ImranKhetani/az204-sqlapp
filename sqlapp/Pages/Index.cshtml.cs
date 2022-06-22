using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.Models;
using sqlapp.Services;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Employee> Employees;

        // Creating constructor for the index model

        private readonly IEmployeeDB employeeDB;

        public IndexModel(IEmployeeDB employeeDB)
        {
            employeeDB = employeeDB;
        }

        public void OnGet()
        {
            // EmployeeDB employeeService = new EmployeeDB();
            Employees = employeeDB.GetEmployees();
        }
    }
}