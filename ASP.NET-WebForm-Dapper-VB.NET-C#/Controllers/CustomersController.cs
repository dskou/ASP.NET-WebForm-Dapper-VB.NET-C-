using ASP.NET_WebForm_Dapper_VB.NET_C_.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace ASP.NET_WebForm_Dapper_VB.NET_C_.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _repo = new CustomerRepository();

        [HttpGet]
        public ActionResult Index(int? editId = null)
        {
           
            var list = _repo.GetAll();
            ViewBag.EditId = editId;
            return View("~/Views/Home/Index.cshtml", list); // 传 List<Customer>
        }
        public class CustomerListViewModel
        {
            public List<Customer> Customers { get; set; }
            public int? EditId { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(
               [Bind(Include="CustomerID,CompanyName,Address,City,State,IntroDate,CreditLimit")]
                Customer customer)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EditId = customer.CustomerID;
                var list = _repo.GetAll();
                return View("~/Views/Home/Index.cshtml", list);
            }

            if (!_repo.UpdateCustomer(customer))
            {
                ModelState.AddModelError("", "Update failed");
                ViewBag.EditId = customer.CustomerID;
                var list = _repo.GetAll();
                return View("~/Views/Home/Index.cshtml", list);
            }

            // 初期表示に戻る、エラーメッセージ画面上表示
            TempData["Message"] = "Record updated successfully.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EditId = customer.CustomerID;
                var list = _repo.GetAll();
                return View("~/Views/Home/Index.cshtml", list);
            }

            if (customer.CustomerID > 0)
            {

                if (!_repo.UpdateCustomer(customer))
                {
                    ModelState.AddModelError("", "Update failed");
                    ViewBag.EditId = customer.CustomerID;
                    var list = _repo.GetAll();
                    return View("~/Views/Home/Index.cshtml", list);
                }
            }
            else
            {
                
                _repo.AddCustomer(customer);
                TempData["Message"] = "Successfully AddCustomer a new reccord";

            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            bool success = _repo.DeleteCustomer(id);

            if (success)
            {
                TempData["Message"] = "Successfully deleted the record.";
            }
            else
            {
                TempData["Message"] = "Delete failed. Please try again.";
            }

            return RedirectToAction("Index");
        }

    }
}

