using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace ASP.NET_WebForm_Dapper_VB.NET_C_.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connStr =
            ConfigurationManager.ConnectionStrings["CustomerInformation"].ConnectionString;

        public List<Customer> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connStr))
            {
                return db.Query<Customer>("SELECT * FROM Customer;").ToList();
            }
        }

        public Customer FindById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connStr))
            {
                return db.QueryFirstOrDefault<Customer>(
                    "SELECT * FROM Customer WHERE CustomerID = @CustomerID",
                    new { CustomerID = id });
            }
        }

        public bool AddCustomer(Customer customer)
        {
            const string sql = @"
                INSERT INTO Customer
                    (CompanyName, Address, City, State, IntroDate, CreditLimit)
                VALUES
                    (@CompanyName, @Address, @City, @State, @IntroDate, @CreditLimit);";

            using (IDbConnection db = new SqlConnection(_connStr))
            {
                try
                {
                    int rows = db.Execute(sql, customer);
                    return rows > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            const string sql = @"
       　　　 UPDATE Customer
        　　　SET CompanyName = @CompanyName,
           　 Address     = @Address,
            　City        = @City,
            　State       = @State,
            　IntroDate   = @IntroDate,
            　CreditLimit = @CreditLimit
        　　　WHERE CustomerID = @CustomerID";

            var p = new DynamicParameters();
            p.Add("@CustomerID", customer.CustomerID, DbType.Int32);
            p.Add("@CompanyName", customer.CompanyName, DbType.String);
            p.Add("@Address", customer.Address, DbType.String);
            p.Add("@City", customer.City, DbType.String);
            p.Add("@State", customer.State, DbType.String);
            p.Add("@IntroDate", customer.IntroDate, DbType.Date);     
            p.Add("@CreditLimit", customer.CreditLimit, DbType.Decimal);
            
            using (IDbConnection db = new SqlConnection(_connStr))
            {
                try { return db.Execute(sql, p) > 0; }
                catch { return false; }
            }
        }

        public bool DeleteCustomer(int id)
        {
            const string sql = "DELETE FROM Customer WHERE CustomerID = @CustomerID";

            using (IDbConnection db = new SqlConnection(_connStr))
            {
                try
                {
                    int rows = db.Execute(sql, new { CustomerID = id });
                    return rows > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
