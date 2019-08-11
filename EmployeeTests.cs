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
            
            string  expected= "Employee4,Employee2,500";

            //Act
            string actual = "Employee4,Employee2,-800";

            string[] _csvInput = { expected,actual};

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>new  Employees(_csvInput));

        }
       public void Should_ValidateNoOfEmployeesAssignedToAManager()
        {
            //Arrange
            string employee5 = "Employee5,Employee1,500";

            string employee2 = "Employee2,Employee1,500";
            //Act
            string[] _csvInput = { employee5, employee2 };

            //Assert
            Assert.Throws<ArgumentException>(() => new Employees(_csvInput));
   
        }
        public void Should_ValidateNoManagerIsNotAnEmloyee()
        {

            string employee1 = "Employee1,,1000";

            string actual = ",,1000";

            string[] _csvInput = { employee1, actual };
            Assert.Throws<ArgumentException>(() => new Employees(_csvInput));
        }
        public void Should_ValidateCeoNumber()
        {
            string employee1 = "Employee1,,1000";

            string employee5 = "Employee5,Employee1,500";

            string employee3 = "Employee3,Emloyee1,800";

            string[] _csvInput = { employee1, employee5,employee3 };

            Assert.Throws<ArgumentException>(() => new Employees(_csvInput));
        }
        public void Should_ValidateCircularReference()
        {
            string employee2 = "Employee2,Employee1,500";

            string employee5 = "Employee5,Employee1,500";

            string[] _csvInput = { employee2, employee5 };
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
            Employees e = new Employees(_csvInput);
            long ActualSalary = e.GetSalaryBudget("Employee2");

            //Assert
            Assert.Equal(ExpectedSalary, ActualSalary);
        }


    }
}
