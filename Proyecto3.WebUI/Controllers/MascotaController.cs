using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto3.Entidades.Clases;
using Proyecto3.WebUI.Servicios.Interfaces;

namespace Proyecto3.WebUI.Controllers
{
    public class MascotaController : Controller
    {
        private readonly IMascotaServicio _mascotaServicio;
        private readonly IClienteServicio _clienteServicio;

        public MascotaController(IMascotaServicio mascotaServicio, IClienteServicio clienteServicio)
        {
            _mascotaServicio = mascotaServicio;
            _clienteServicio = clienteServicio;
        }

        // GET: MascotaController
        public async Task<ActionResult> Index()
        {
            try
            {
                IEnumerable<Mascota> mascota = await _mascotaServicio.ListarMascotas();

                return View(mascota);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: MascotaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var mascota = await _mascotaServicio.LeerMascota(id);
                return View(mascota);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: MascotaController/Create
        public async Task<ActionResult> Create()
        {
            var clientes = await _clienteServicio.ListarClientes();

            ViewBag.ClientesDropDownList = new SelectList(clientes, "Cedula", "Nombre");

            return View();
        }

        // POST: MascotaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Mascota mascota)
        {
            try
            {
                var resultado = await _mascotaServicio.CrearMascota(mascota);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MascotaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var mascota = await _mascotaServicio.LeerMascota(id);
                var clientes = await _clienteServicio.ListarClientes();

                ViewBag.ClientesDropDownList = new SelectList(clientes, "Cedula", "Nombre", mascota.ClienteCedula);

                return View(mascota);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: MascotaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Mascota mascota)
        {
            try
            {
                var resultado = await _mascotaServicio.ActualizarMascota(mascota);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MascotaController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var mascota = await _mascotaServicio.LeerMascota(id);
                return View(mascota);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: MascotaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Mascota mascota)
        {
            try
            {
                await _mascotaServicio.EliminarMascota(mascota.Id);

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
                var mascotas = Enumerable.Empty<Mascota>();

                if (!string.IsNullOrEmpty(criterioBusqueda))
                {
                    mascotas = await _mascotaServicio.BuscarMascota(criterioBusqueda);
                }
                else
                {
                    mascotas = await _mascotaServicio.ListarMascotas();
                }

                return View("Index", mascotas);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
