using Proyecto3.Entidades.Clases;
using Proyecto3.WebUI.Servicios.Interfaces;

namespace Proyecto3.WebUI.Servicios.Clases
{
    public class TipoProcedimientoServicio : ITipoProcedimientoServicio
    {
        #region Atributos
        private readonly string _BaseURL = "http://localhost:5004/api/tipoprocedimiento/";
        #endregion

        #region Metodos de ITipoProcedimientoServicio
        /// <summary>
        /// Procedimiento para leer un tipo de procedimiento por su id.
        /// </summary>
        /// <param name="id">Identificador del tipo de procedimiento</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TipoProcedimiento> LeerProcedimiento(int id)
        {
            TipoProcedimiento tipoProcedimiento = new TipoProcedimiento();
            
            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await httpClient.GetAsync($"LeerTipoProcedimiento/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuest = respuesta.Content.ReadAsStringAsync().Result;
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<TipoProcedimiento>(json_respuest);
                tipoProcedimiento = resultado!;
            }
            
            return tipoProcedimiento;
        }

        /// <summary>
        /// Procedimiento para listar todos los tipos de tiposProcedimiento.
        /// </summary>
        /// <returns>Objeto IEnumerable<Proyecto2.Entidades.ClasesTipoProcedimiento> con todos los tipos de tiposProcedimiento.</returns>
        public async Task<IEnumerable<TipoProcedimiento>> Listar()
        {
            IEnumerable<TipoProcedimiento> tiposProcedimiento = new List<TipoProcedimiento>();

            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await httpClient.GetAsync("ListarTiposProcedimiento");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuest = await respuesta.Content.ReadAsStringAsync();
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<TipoProcedimiento>>(json_respuest);
                tiposProcedimiento = resultado!;
            }

            return tiposProcedimiento;
        }
        #endregion
    }
}
