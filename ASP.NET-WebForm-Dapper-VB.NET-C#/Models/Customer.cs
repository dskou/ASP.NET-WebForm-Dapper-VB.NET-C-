using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace ASP.NET_WebForm_Dapper_VB.NET_C_.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? IntroDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal CreditLimit { get; set; }
    }
}
