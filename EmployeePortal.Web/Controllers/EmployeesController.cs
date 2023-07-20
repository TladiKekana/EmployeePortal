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

        public IActionResult Details(int id)
        {
            var model = db.GetById(id);
            if(model == null)
                return View("NotFound");
            else
                return View(model);
        }
    }
}
