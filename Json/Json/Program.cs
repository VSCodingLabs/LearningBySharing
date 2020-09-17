using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    class Program
    {
        private static EmployeeDataProvider _employeeDataProvider;

        private static async Task<IEnumerable<Employee>> ShowEmployeeList()
        {
            var employees = await _employeeDataProvider.LoadCustomerAsync();
            foreach (var employee in employees)
            {
                Console.WriteLine($"First Name  : {employee.FirstName}");
                Console.WriteLine($"Last Name : {employee.LastName}");
                Console.WriteLine($"Fresher : {employee.IsFresher}\n");
            }
            return employees;
        }

        private static async void Json()
        {
            _employeeDataProvider = new EmployeeDataProvider();
            IEnumerable<Employee> employees = await ShowEmployeeList();
            await _employeeDataProvider.SaveCustomersAsyn(employees);
        }

        static void Main(string[] args)
        {
            Json();
            Console.ReadLine();
        }
    }
}
