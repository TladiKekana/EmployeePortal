using EmployeePortal.Core;
using EmployeePortal.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeData db;

        public EmployeesController(IEmployeeData db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = db.GetById(id);
            if(model == null)
                return View("NotFound");
            else
                return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                foreach(var e in db.GetAll())
                {
                    if(employee.Id == e.Id)
                    {
                        e.Name = employee.Name;
                        e.Surname = employee.Surname;
                    }
                }

                return RedirectToAction("Details", new { id = employee.Id });
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            var model = db.GetById(id);
            if(model == null)
                return View("NotFound");
            else
                return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Add(employee);
                return RedirectToAction("Details", new { id = employee.Id });
            }

            return View();
        }
    }
}
