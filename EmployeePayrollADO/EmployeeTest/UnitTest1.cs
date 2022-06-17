using NUnit.Framework;
using EmployeePayrollADO;
using System;

namespace EmployeeTest
{
    public class Tests
    {
        Employee employee;
        EmployeeDetail employeeDetail;
        [SetUp]
        public void Setup()
        {
            employee = new Employee();
            employeeDetail = new EmployeeDetail();
        }
        //<summary>
        //TC 2 : Insert Details
        //</summary>
        [Test]
        public void AddingEmployeeDetails()
        {
            int expected = 1;
            employee.Name = "Hails";
            employee.StartDate = Convert.ToDateTime("2022-10-03");
            employee.Gender = "M";
            employee.PhoneNumber = 9856742311;
            employee.Address = "Mulund";
            employee.Department = "Civil";
            employee.BasicPay = 33300;
            employee.Deduction = 4400;
            employee.TaxablePay = 1000;
            employee.IncomeTax = 1200;
            employee.NetPay = 25000;
            var actual = employeeDetail.InsertEmployeeData(employee);
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //TC 3 : Update Details
        //</summary>
        [Test]
        public void UpdatingEmployeeDetails()
        {
            employee.ID = 4;
            employee.Name = "Athena";
            employee.BasicPay = 56500;
            var result = employeeDetail.UpdateSalary(employee);
            var expected = result.BasicPay;
            var actual = result.BasicPay;
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //TC 4 : Retrieve Data in DateRange
        //</summary>
        [Test]
        public void Retrieving_Data_In_DateRange()
        {
            var fromDate = Convert.ToDateTime("2022-01-01");
            var toDate = Convert.ToDateTime("2022-10-01");
            var result = employeeDetail.EmployeeData_InDataRange(fromDate, toDate);
            var expected = result.Count;
            Assert.AreEqual(expected, result.Count);
        }
    }
}