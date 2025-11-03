using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto3.Entidades.Clases;
using Proyecto3.WebUI.Servicios.Interfaces;

namespace Proyecto3.WebUI.Controllers
{
    public class ProcedimientoMascotaController : Controller
    {
        private readonly IProcedimientoServicio _procedimientoServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly ITipoProcedimientoServicio _tipoProcedimientoServicio;
        private readonly IMascotaServicio _mascotaServicio;

        public ProcedimientoMascotaController(IProcedimientoServicio procedimientoServicio, IClienteServicio clienteServicio, ITipoProcedimientoServicio tipoProcedimientoServicio, IMascotaServicio mascotaServicio)
        {
            _procedimientoServicio = procedimientoServicio;
            _clienteServicio = clienteServicio;
            _tipoProcedimientoServicio = tipoProcedimientoServicio;
            _mascotaServicio = mascotaServicio;
        }

        // GET: ProcedimientoMascotaController
        public async Task<ActionResult> Index()
        {
            try
            {
                var procedimientos = await _procedimientoServicio.ListarProcedimientos();

                return View(procedimientos);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: ProcedimientoMascotaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var procedimiento = await _procedimientoServicio.LeerProcedimiento(id);
                return View(procedimiento);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: ProcedimientoMascotaController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                var clientes = await _clienteServicio.ListarClientes();

                ViewBag.ClientesDropDownList = new SelectList(clientes, "Cedula", "Nombre");

                var tiposProcedimientos = await _tipoProcedimientoServicio.Listar();

                ViewBag.TiposDeProcedimientos = new SelectList(tiposProcedimientos, "Id", "Nombre");

                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpGet]
        // Este codigo se obtuvo y modifico de: https://www.rafaelacosta.net/Blog/2019/11/24/c%c3%b3mo-crear-un-cascading-dropdownlist-en-aspnet-mvc?AspxAutoDetectCookieSupport=1
        public async Task<JsonResult> ObtenerMascotasAsync(string cedula)
        {
            var cliente = await _clienteServicio!.LeerCliente(cedula);

            var resultado = Json(cliente.Mascotas);

            return resultado;
        }

        // POST: ProcedimientoMascotaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Procedimiento procedimiento, IFormCollection collection)
        {
            try
            {
                var cliente = await _clienteServicio.LeerCliente(collection["Cliente"]!);
                procedimiento.ClienteCedula = cliente.Cedula;

                var mascota = await _mascotaServicio.LeerMascota(int.Parse(collection["Mascota"]!));
                procedimiento.MascotaId = mascota.Id;

                var tipoProcedimiento = await _tipoProcedimientoServicio.LeerProcedimiento(int.Parse(collection["TipoProcedimientoId"]!));
                procedimiento.TipoProcedimientoId = tipoProcedimiento.Id;

                var resultado = await _procedimientoServicio.CrearProcedimiento(procedimiento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcedimientoMascotaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var clientes = await _clienteServicio.ListarClientes();

                var procedimiento = await _procedimientoServicio.LeerProcedimiento(id);

                var tiposProcedimiento = await _tipoProcedimientoServicio.Listar();

                ViewBag.TiposDeProcedimientos = new SelectList(tiposProcedimiento, "Id", "Nombre", procedimiento.TipoProcedimiento!.Nombre);

                ViewBag.ClientesDropDownList = new SelectList(clientes, "Cedula", "Nombre", procedimiento.Cliente!.Cedula);

                ViewBag.MascotasDropDownList = new SelectList(procedimiento.Cliente!.Mascotas!, "Id", "NombreMascota", procedimiento.Mascota!.Id);

                return View(procedimiento);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: ProcedimientoMascotaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Procedimiento procedimientoEditado, IFormCollection collection)
        {
            try
            {
                var procedimientoActual = await _procedimientoServicio.LeerProcedimiento(procedimientoEditado.Id);

                procedimientoEditado.Cliente = await _clienteServicio.LeerCliente(collection["ClientesId"]!);
                procedimientoEditado.ClienteCedula = procedimientoEditado.Cliente!.Cedula;
                
                procedimientoEditado.Mascota = await _mascotaServicio.LeerMascota(int.Parse(collection["MascotasId"]!));
                procedimientoEditado.MascotaId = procedimientoEditado.Mascota!.Id;

                procedimientoEditado.TipoProcedimiento = await _tipoProcedimientoServicio.LeerProcedimiento(int.Parse(collection["TipoProcedimientoId"]!));
                procedimientoEditado.TipoProcedimientoId = procedimientoEditado.TipoProcedimiento.Id;

                var resultado = await _procedimientoServicio.ActualizarProcedimiento(procedimientoEditado);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ProcedimientoMascotaController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var procedimiento = await _procedimientoServicio.LeerProcedimiento(id);
                return View(procedimiento);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: ProcedimientoMascotaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Procedimiento procedimiento /*string id, IFormCollection collection*/)
        {
            try
            {
                await _procedimientoServicio.EliminarProcedimiento(procedimiento.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ProcedimientoMascotaController/Search/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search(string criterioBusqueda)
        {
            try
            {
                var procedimientos = Enumerable.Empty<Procedimiento>();

                if (!string.IsNullOrEmpty(criterioBusqueda))
                    procedimientos = await _procedimientoServicio.BuscarProcedimiento(criterioBusqueda);
                else
                    procedimientos = await _procedimientoServicio.ListarProcedimientos();

                return View("Index", procedimientos);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


    }
}
