using Microsoft.AspNetCore.Mvc;
using Proyecto3.WebUI.Servicios.Interfaces;

namespace Proyecto3.WebUI.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IReporteServicio _reporteServicio;

        public ReportesController(IReporteServicio reporteServicio)
        {
            _reporteServicio = reporteServicio;
        }

        // GET: ReportesController
        public async Task<ActionResult> Index()
        {
            var clientes = await _reporteServicio.GenerarReporteProcedimientosParaVacunacionAnual();

            return View(clientes);
        }
    }
}
