using CrudUsingAdo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingAdo.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration configuration;
        CustomersDAL customersDAL;
        public CustomerController(IConfiguration configuration)
        {
            this.configuration = configuration;
            customersDAL = new CustomersDAL(this.configuration);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]

        // GET: CustomerController/Details/5
        public ActionResult Register(Customers cust)
        {
            try
            {
                int res = customersDAL.CustomerRegister(cust);
                if (res==1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CustomerController/Create
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customers cust)
        {
            Customers c = customersDAL.CustomerLogin(cust);
            if(c!=null)
            {
                return RedirectToAction("List", "Emp");
            }
            else
            {
                return View();
            }
            
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

