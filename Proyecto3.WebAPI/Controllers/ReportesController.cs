using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Proyecto3.AccesoDatos.AccesoDB;
using Proyecto3.Entidades.Clases;
using System;
using System.Globalization;

namespace Proyecto3.WebAPI.Controllers
{
    [Route("api/Reportes")]
    [ApiController]
    public class ReportesController(DBContexto dBContexto) : ControllerBase
    {
        private readonly DBContexto _dbContexto = dBContexto;

        // GET api/<Reportes>/5
        [HttpGet("GenerarReporteProcedimientosParaVacunacionAnual/")]
        public ActionResult<IEnumerable<Cliente>> GenerarReporteProcedimientosParaVacunacionAnual()
        {
            try
            {
                DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

                // Calcular el inicio y fin de la proxima semana. Este codigo se hizo con ayuda de: Gemini
                DayOfWeek primerDiaSemana = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                int diff = (7 + (fechaActual.DayOfWeek - primerDiaSemana)) % 7;
                DateOnly inicioSemanaActual = fechaActual.AddDays(-1 * diff);
                DateOnly inicioSemanaSiguiente = inicioSemanaActual.AddDays(7);
                DateOnly finSemanaSiguiente = inicioSemanaSiguiente.AddDays(6);

                IEnumerable<Procedimiento> procedimientosVacunacionSemanaSiguiente = _dbContexto.Procedimientos
                    .Include(p => p.Cliente)
                    .Where(p => p.TipoProcedimiento!.Nombre!.Equals("Vacunas anuales") &&
                                p.Fecha <= finSemanaSiguiente.AddYears(-1) && p.Fecha <= finSemanaSiguiente.AddYears(-1))
                    .ToList();

                IEnumerable<Cliente> clientes = procedimientosVacunacionSemanaSiguiente
                    .Select(p => p.Cliente!)
                    .Distinct()
                    .ToList();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
