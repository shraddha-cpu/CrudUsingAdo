using CrudUsingAdo.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingAdo.Controllers
{
    public class EmpController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeDAL employeeDAL;
        public EmpController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeeDAL=new EmployeeDAL(this.configuration);
        }
        public ActionResult List()
        {
            var model = employeeDAL.GetAllEmployees();
            return View(model);
        }

        // GET: EmpController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result = employeeDAL.AddEmployee(emp);
                if (result==1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);
        }

        // POST: EmpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = employeeDAL.UpdateEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: EmpController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);
        }

        // POST: EmpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = employeeDAL.DeleteEmployee(id);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
