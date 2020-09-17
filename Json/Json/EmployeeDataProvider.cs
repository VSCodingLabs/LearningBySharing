using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Json
{
    class EmployeeDataProvider
    {
        private static readonly string _employeeFileName = "employee.json";
        public async Task<IEnumerable<Employee>> LoadCustomerAsync()
        {
            List<Employee> EmployeeList = new List<Employee>();
            if(File.Exists(_employeeFileName))
            {
                using (FileStream fs = File.OpenRead(_employeeFileName))
                {
                    EmployeeList = await JsonSerializer.DeserializeAsync<List<Employee>>(fs);
                }
            }
            else
            {
                EmployeeList.Add(new Employee { FirstName = "Thomas", LastName = "Mathew", IsFresher = true });
                EmployeeList.Add(new Employee { FirstName = "Appu", LastName = "Kurian", IsFresher = true });
                EmployeeList.Add(new Employee { FirstName = "Abin", LastName = "Antony" });
                EmployeeList.Add(new Employee { FirstName = "Jerin", LastName = "Jose", IsFresher = true });
                EmployeeList.Add(new Employee { FirstName = "Alfred", LastName = "Geroge" });
                EmployeeList.Add(new Employee { FirstName = "Surrendar", LastName = "Babu" });
                EmployeeList.Add(new Employee { FirstName = "Georgy", LastName = "Punnen", IsFresher = true });
            }
            return EmployeeList;
        }

        public async Task SaveCustomersAsyn(IEnumerable<Employee> employees)
        {
            using (FileStream fs = File.Create(_employeeFileName))
            {
                await JsonSerializer.SerializeAsync(fs, employees);
            }
        }
    }
}
