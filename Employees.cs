using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesAssignment
{
    public class Employees
    {

        public string EmployeeId { get; set; }
        public string ManagerId { get; set; }
        public long EmployeeSalary { get; set; }
        //I have two constructors for the Employees class
        //This has the fields that bbelong to an employee
        public Employees(string employeeId, string managerId, long employeeSalary)
        {

            EmployeeId = employeeId;
            ManagerId = managerId;
            EmployeeSalary = employeeSalary;
        }

        public static List<Employees> Create(string[] _csvInput)
        {
            List<Employees> employees = new List<Employees>();
            foreach (var _employeecsvInput in _csvInput)
            {
                var values = _employeecsvInput.Split(',');
                long EmployeeSalary;
                bool CheckIfSalaryIsInteger = long.TryParse(values[2], out EmployeeSalary);
                if ( EmployeeSalary < 0||!CheckIfSalaryIsInteger)
                    throw new ArgumentOutOfRangeException("Salary Must be A valid Integere Number ");
                employees.Add(new Employees(values[0], values[1], EmployeeSalary));
            }

            return employees;
        }

        //Employees Constructor receiving a csv input string
        public Employees(string[] _csvInput)

        {

           

            if (_csvInput.Length != 3)
            {
                throw new ArgumentException("The file should have only 3 columns " + _csvInput.Length);
            }
            if (_csvInput == null || _csvInput.Length == 0) {
                throw new ArgumentException("Invalid CSV Input");
            }
            employees = Employees.Create(_csvInput);

            ValidateNoOfEmployeesAssignedToAManger();
            ValidateNoManagerIsNotAnEmloyee();
            ValidateCeoNumber();
            ValidateCircularReference();


        }

        public List<Employees> employees { get; set; }
        //Insatnce Method that returns managers salary budget
        public long GetSalaryBudget(string managerId)
        {
            if (string.IsNullOrWhiteSpace(managerId))
            {
                throw new ArgumentException("Manager Must Exist");
            }
            long totalSalary = 0;
            totalSalary += employees.FirstOrDefault(e => e.EmployeeId == managerId).EmployeeSalary;
            foreach (var item in employees.Where(e => e.ManagerId == managerId))
            {
                if (ValidateEmloyeeManagerNumber(item.EmployeeId))
                {
                    totalSalary += GetSalaryBudget(item.EmployeeId);
                }
                else
                {
                    totalSalary += item.EmployeeSalary;
                }
            }
            return totalSalary;
        }

        //Validating the number of emloyees reporting to a manager 
        private bool ValidateEmloyeeManagerNumber(string id) => employees.Where(e => e.ManagerId == id).Count() > 0;

        //Validating that there is only one ceo
        private void ValidateCeoNumber()
        {
            if (employees.Where(e => e.ManagerId == null || e.ManagerId == string.Empty).Count() > 1)
            {
                throw new ArgumentException("CEOs should not be more than one");

            }
        }
        //Validating Circular Refference
        private void ValidateCircularReference()
        {
            foreach (var _ in from employee in employees
                              .Where(e => e.ManagerId != string.Empty && e.ManagerId != null)
                              let supervisor = employees
                              .Where(e => e.ManagerId != string.Empty && e.ManagerId != null)
                              .FirstOrDefault(e => e.EmployeeId == employee.ManagerId)
                              where supervisor != null
                              where supervisor.ManagerId == employee.EmployeeId
                              select new { })
            {
                throw new ArgumentException("There is Circular Refference");
            }
        }
        //Validating the number of emloyees assigned to one manager
        private void ValidateNoOfEmployeesAssignedToAManger()
        {
            foreach (var id in employees.Select(e => e.EmployeeId).Distinct().Where(employeeId => employees.Where(i => i.EmployeeId == employeeId)
            .Select(m => m.ManagerId).Distinct().Count() > 1).Select(employeeId => employeeId))
            {
                throw new ArgumentException("Employee has only one Manager");
            }
        }
        //Validating that a manager should be an emloyee
        private void ValidateNoManagerIsNotAnEmloyee()
        {
            foreach (var _ in employees.Where(e => e.ManagerId != null && e.ManagerId != string.Empty)
                .Select(e => e.ManagerId).Where(manager => employees.FirstOrDefault(e => e.EmployeeId == manager) == null).Select(manager => new { }))
            {
                throw new ArgumentException("All Managers Must Be employees");
            }
        }


    }
}
