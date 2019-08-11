using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesAssignment;
using Xunit;

namespace Employee.Tests
{
    class EmployeeeTests
    {

        public void Should_CheckIfSalaryIsInteger()
        {
            
            //Arrange
            string valid= "Employee4,Employee2,500";
            //Act
            string actual= "Employee4,Employee2,-500";
           

            string[] _csvInput = {valid, actual };

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>new  Employees(_csvInput));

        }
       public void Should_ValidateNoOfEmployeesAssignedToAManager()
        {
      
            string employee1 = "Employee2,,200";
            string employee2 = "Employee1,,500";
            string[] _csvInput = { employee1, employee2 };
            Assert.Throws<ArgumentException>(() => new Employees(_csvInput));

        public void Should_ValidateNoManagerIsNotAnEmloyee()
        {
            string employee1 = "Employee2,Employee3,200";
            string employee2 = "Employee1,Employee4,500";
            string[] _csvInput = { employee1, employee2 };
            Assert.Throws<ArgumentException>(() => new Employees(_csvInput));
        }
        public void Should_ValidateCeoNumber()
        {
            string employee1 = "Employee2,Employee3,200";

            string employee2 = "Employee2,Employee4,500";

            string[] _csvInput = { employee1, employee2 };

            Assert.Throws<ArgumentException>(() => new Employees(_csvInput));
        }
        public void Should_ValidateCircularReference()
        {
            string employee1 = "Employee2,Employee3,200";

            string employee2 = "Employee3,Employee2,500";

            string[] _csvInput = { employee1, employee2 };
            Assert.Throws<ArgumentException>(() => new Employees(_csvInput));

        }

        public void Should_GetSalaryBudget()
        {
            //Arrange
            string employee2 = "Employee2,Employee1,800";

            string employee4 = "Employee4,Employee2,500";

            string employee3 = "Employee3,Employee1,500";
            string[] _csvInput = { employee2, employee4, employee3 };

            //Act
            long ExpectedSalary = 1800;
            long ActualSalary;
            Employees employees = new Employees(_csvInput);
            ActualSalary = employees.GetSalaryBudget("Employee2");

            //Assert
            Assert.Equal(ExpectedSalary, ActualSalary);
        }


    }
}
