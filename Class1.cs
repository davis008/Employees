using System;

namespace Employees
{
    public class Employees
    {
        
       
        private readonly string csvData;
        //Employees Constructor 
        public Employees(string _csvData)
        {
            this.employeeId = employeeId;
            this.salary = salary;
            this.managerId = managerId;

            csvData = _csvData;
            string[] splitCsv = csvData.Split(',');

            if (splitCsv.Length != 3)
            {
                throw new ArgumentException("The file should have only 3 columns " + splitCsv.Length);
            }
             if(splitCsv)
            if((employeeId as managerId)?.Reports ?? 0)
            {

            }

          if (!int.TryParse(salary))
            {

            }


            salary= int.Parse(splitCsv[2]);//checked wether salary is an integer 

           
            var items = splitCsv;
            var circulars = new Dictionary(employeeId,managerId);
            foreach (var item in items)
            {
                var target = item.Value;
                while (items.ContainsKey(target))
                {
                    target = items[target];

                    if (target.Equals(item.Key))
                    {
                        circulars.Add(target, item.Value);
                        break;
                    }
                }
            }

        }
        // Instance Properties
        public int employeeId { get; set; }
        public int managerId { get; set; }
        public int salary { get; set; }

       public long getBudget( String managerId)
        {
            IList<Employees> GetEmployees(Employees managerId)
            {
                var result = new List<Employees>();

                var employees = Employees
                                           .Where(e => e.ManagerEmployeeNumber == manager.EmployeeNumber)
                                           .ToList();

                foreach (var employee in employees)
                {
                    result.Add(employee);
                    result.AddRange(GetEmployees(employee));
                }

                return result;
            }

        }
    }

}
