﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollADO
{
    public class EmployeeDetail
    {
        static string connectionstring = @"Data source=(localdb)\MSSQLLocalDB;Initial Catalog=EmpPay;Integrated Security=SSPI";
        static SqlConnection connection = new SqlConnection(connectionstring);

        public void EstablishConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.CONNECTION_FAILED, "Connection not found");
                }
            }
        }
        public void CloseConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    connection.Close();
                }
                catch (Exception)
                {
                    throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.CONNECTION_FAILED, "Connection not found");
                }
            }
        }
        public int InsertEmployeeData(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertEmployeeDetails", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@BasicPay", employee.BasicPay);
                    command.Parameters.AddWithValue("@Deduction", employee.Deduction);
                    command.Parameters.AddWithValue("@TaxablePay", employee.TaxablePay);
                    command.Parameters.AddWithValue("@IncomeTax", employee.IncomeTax);
                    command.Parameters.AddWithValue("@NetPay", employee.NetPay);
                    var returnParameter = command.Parameters.Add("@new_identity", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    Console.WriteLine(employee.ID + "," + employee.Name + "," + employee.StartDate + "," + employee.Gender + "," + employee.PhoneNumber + "," + employee.Address + "," + employee.Department + "," + employee.BasicPay + "," + employee.Deduction + "," + employee.TaxablePay + "," + employee.IncomeTax + "," + employee.NetPay);
                    command.ExecuteNonQuery();
                    connection.Close();
                    var result = returnParameter.Value;
                    return (int)result;
                    Console.WriteLine("Contact is added");
                }
            }
            catch (Exception ex)
            {
                throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.INSERTION_ERROR, "Insertion error");
            }
            return 0;
        }
    }
}
