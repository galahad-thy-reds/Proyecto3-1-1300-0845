using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto3.Entidades.Clases;
using Proyecto3.WebUI.Servicios.Interfaces;

namespace Proyecto3.WebUI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            try
            {
                var clientes = await _clienteServicio.ListarClientes();
                return View(clientes);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(string cedula)
        {
            try
            {
                var cliente = await _clienteServicio.LeerCliente(cedula);
                return View(cliente);
            }
            catch (Exception ex)
            {
                return View(ex.Message);

            }
        }
        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            try
            {
                var resultado = await _clienteServicio.CrearCliente(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(string cedula)
        {
            try
            {
                var cliente = await _clienteServicio.LeerCliente(cedula);
                return View(cliente);
            }
            catch (Exception ex)
            {
                return View(ex.Message);

            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Cliente cliente)
        {
            try
            {
                var resultado = await _clienteServicio.ActualizarCliente(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<ActionResult> Delete(string cedula)
        {
            try
            {
                var cliente = await _clienteServicio.LeerCliente(cedula);
                return View(cliente);
            }
            catch (Exception ex)
            {
                return View(ex.Message);

            }
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Cliente cliente)
        {
            try
            {
                _clienteServicio.EliminarCliente(cliente.Cedula!);

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
                var clientes = Enumerable.Empty<Cliente>();

                if (!string.IsNullOrEmpty(criterioBusqueda))
                {
                    clientes = await _clienteServicio.BuscarCliente(criterioBusqueda);
                }
                else
                {
                    clientes = await _clienteServicio.ListarClientes();
                }

                return View("Index", clientes);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
