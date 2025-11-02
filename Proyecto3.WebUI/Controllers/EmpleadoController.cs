using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto3.Entidades.Clases;
using Proyecto3.WebUI.Servicios.Interfaces;

namespace Proyecto3.WebUI.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoServicio _empleadoServicio;

        public EmpleadoController(IEmpleadoServicio empleadoServicio)
        {
            _empleadoServicio = empleadoServicio;
        }

        // GET: EmpleadoController
        public async Task<ActionResult> Index()
        {
            try
            {
                IEnumerable<Empleado> empleados = await _empleadoServicio.ListarEmpleados();

                return View(empleados);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EmpleadoController/Details/5
        public async Task<ActionResult> Details(string cedula)
        {
            try
            {
                var empleado = await _empleadoServicio.LeerEmpleado(cedula);

                return View(empleado);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Empleado empleado)
        {
            try
            {
                var resultaod = await _empleadoServicio.CrearEmpleado(empleado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/5
        public async Task<ActionResult> Edit(string cedula)
        {
            try
            {
                var empleado = await _empleadoServicio.LeerEmpleado(cedula);

                return View(empleado);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Empleado empleado)
        {
            try
            {
                var resultado = await _empleadoServicio.ActualizarEmpleado(empleado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/5
        public async Task<ActionResult> Delete(string cedula)
        {
            try
            {
                var empleado = await _empleadoServicio.LeerEmpleado(cedula);

                return View(empleado);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Empleado empleado)
        {
            try
            {
                _empleadoServicio.EliminarEmpleado(empleado.Cedula!);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: EmpleadoController/Search/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search(string criterioBusqueda)
        {
            try
            {
                var empleados = Enumerable.Empty<Empleado>();

                if (string.IsNullOrEmpty(criterioBusqueda))
                    empleados = await _empleadoServicio.ListarEmpleados();
                else
                    empleados = await _empleadoServicio.BuscarEmpleado(criterioBusqueda);

                return View("Index", empleados);
            }
            catch
            {
                return View("Index", _empleadoServicio.ListarEmpleados());
            }
        }
    }
}
