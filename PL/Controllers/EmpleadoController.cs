using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();
            if (result.Correct)
            {
                return View(result);
            }
            else
            {
                return View();
            }
        }//GetAll

        [HttpPost]
        public JsonResult Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            return Json(result);         
        }

        [HttpPost]
        public JsonResult Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
            return Json(result);
        }

        [HttpGet]
        public JsonResult GetById(int idEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(idEmpleado);
            return Json(result);
        }

        [HttpPost]
        public JsonResult Delete(int idEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(idEmpleado);
            return Json(result);
        }

        [HttpPost]
        public JsonResult ChangeStatus(int idEmpleado, bool status)
        {
            ML.Result result = BL.Empleado.ChangeStatus(idEmpleado, status);
            return Json(result);
        }//ChangeStatus
    }
}
