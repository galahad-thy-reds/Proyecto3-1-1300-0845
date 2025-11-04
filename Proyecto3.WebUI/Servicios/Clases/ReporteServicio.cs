
using Proyecto3.Entidades.Clases;
using Proyecto3.WebUI.Servicios.Interfaces;

namespace Proyecto3.WebUI.Servicios.Clases
{
    public class ReporteServicio : IReporteServicio
    {
        private readonly string _BaseURL = "http://localhost:5004/api/reportes/";

        //public async Task<IEnumerable<Cliente>> GenerarReporteProcedimientosParaVacunacionAnual(int id)
        public async Task<IEnumerable<Cliente>> GenerarReporteProcedimientosParaVacunacionAnual()
        {
            IEnumerable<Cliente> clientes = new List<Cliente>();

            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await httpClient.GetAsync($"GenerarReporteProcedimientosParaVacunacionAnual/");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = respuesta.Content.ReadAsStringAsync().Result;
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Cliente>>(json_respuesta);
                clientes = resultado!;
            }

            return clientes;
        }
    }
}
