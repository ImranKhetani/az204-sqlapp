using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.Models;
using sqlapp.Services;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        // Creating constructor for the index model

        private readonly IEmployeeDB _employeeDB;

        public IndexModel(IEmployeeDB employeeDB)
        {
            _employeeDB = employeeDB;
        }

        public List<Employee> Employees;
        public void OnGet()
        {
            // EmployeeDB employeeService = new EmployeeDB();
            Employees = _employeeDB.GetEmployees();
        }
    }
}