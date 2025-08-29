using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_WebForm_Dapper_VB.NET_C_.Models
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer FindById(int id);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
    }
}
