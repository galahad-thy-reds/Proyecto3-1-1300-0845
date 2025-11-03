using Newtonsoft.Json;
using Proyecto3.Entidades.Clases;
using Proyecto3.WebUI.Servicios.Interfaces;

namespace Proyecto3.WebUI.Servicios.Clases
{
    public class ProcedimientoServicio : IProcedimientoServicio
    {
        #region Atributos
        private readonly string _BaseURL = "http://localhost:5004/api/procedimientos_mascotas/";
        #endregion

        #region Metodos de IProcedimientoServicio
        /// <summary>
        /// Metodo para actualizar los datos de un procedimiento existente.
        /// </summary>
        /// <param name="procedimiento">Objeto <Proyecto2.Entidades.Clases.Procedimiento> con los datos actualizados del procedimiento.</param>
        /// <returns>Verdadero en caso de actualizar el procedimiento. Falso, en caso contrario</returns>
        public async Task<bool> ActualizarProcedimiento(Procedimiento procedimiento)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var contenido = new StringContent(JsonConvert.SerializeObject(procedimiento), System.Text.Encoding.UTF8, "application/json");

            var respuesta = await httpClient.PutAsync("ActualizarProcedimiento", contenido);

            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Metodo para buscar procedimientos por criterio de busqueda.
        /// </summary>
        /// <param name="criterioBusqueda">Valor <string> con el criterio de busqueda.</param>
        /// <returns>Objeto Task<IEnumerable<Proyecto2.Entidades.Clases.Procedimiento>>.</returns>
        public async Task<IEnumerable<Procedimiento>> BuscarProcedimiento(string criterioBusqueda)
        {
            IEnumerable<Procedimiento> procedimientos = new List<Procedimiento>();

            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = httpClient.GetAsync($"BuscarProcedimiento/{criterioBusqueda}");

            if (respuesta.Result.IsSuccessStatusCode)
            {
                var json_respuest = await respuesta.Result.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<IEnumerable<Procedimiento>>(json_respuest);
                procedimientos = resultado!;
            }

            return procedimientos;
        }
        /// <summary>
        /// Metodo para crear un procedimiento nuevo.
        /// </summary>
        /// <param name="procedimiento">Objeto <Proyecto2.Entidades.Clases.Procedimiento> con los datos del procedimiento</param>
        /// <returns>Verdadero en caso de crear el procedimiento. Falso, en caso contrario</returns>
        public async Task<bool> CrearProcedimiento(Procedimiento procedimiento)
        {
            bool resultado = false;

            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var contenido = new StringContent(JsonConvert.SerializeObject(procedimiento), System.Text.Encoding.UTF8, "application/json");

            var respuesta = await httpClient.PostAsync("CrearProcedimiento", contenido);

            if (respuesta.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }
        /// <summary>
        /// Metodo para eliminar un procedimiento existente.
        /// </summary>
        /// <param name="id">Valor <string> con el identificador del procedimiento que se desea eliminar</param>
        /// <returns>Verdadero en caso de eliminar el procedimiento. Falso, en caso contrario</returns>
        public async Task<bool> EliminarProcedimiento(int id)
        {
            bool resultado = false;

            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await httpClient.DeleteAsync($"EliminarProcedimiento/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;

        }
        /// <summary>
        /// Metodo para leer un procedimiento existente.
        /// </summary>
        /// <param name="id">Valor <string> con el identificador del procedimiento que se desea leer</param>
        /// <returns>Objeto Task<Proyecto2.Entidades.Clases.Procedimiento> del procedimiento</returns>
        public async Task<Procedimiento> LeerProcedimiento(int id)
        {
            Procedimiento procedimiento = new Procedimiento();

            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await httpClient.GetAsync($"LeerProcedimiento/{id}");

            if (respuesta != null)
            {
                var json_respuest = await respuesta.Content.ReadAsStringAsync();
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<Procedimiento>(json_respuest);
                procedimiento = resultado!;
            }

            return procedimiento;
        }
        /// <summary>
        /// Metodo para listar todos los procedimientos existentes.
        /// </summary>
        /// <returns>Objeto Task<IEnumerable<Procedimiento>> </returns>
        public async Task<IEnumerable<Procedimiento>> ListarProcedimientos()
        {
            IEnumerable<Procedimiento> procedimientos = new List<Procedimiento>();

            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await httpClient.GetAsync("ListarProcedimientos");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuest = await respuesta.Content.ReadAsStringAsync();
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Procedimiento>>(json_respuest);
                procedimientos = resultado!;
            }

            return procedimientos;
        }
        #endregion
    }
}
