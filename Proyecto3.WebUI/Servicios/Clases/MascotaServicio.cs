using Newtonsoft.Json;
using Proyecto3.Entidades.Clases;
using Proyecto3.WebUI.Servicios.Interfaces;

namespace Proyecto3.WebUI.Servicios.Clases
{
    public class MascotaServicio : IMascotaServicio
    {
        #region Atributos
        private readonly string _BaseURL = "http://localhost:5004/api/mascota/";
        #endregion

        /// <summary>
        /// Metodo para actualizar los datos de una Mascota existente.
        /// </summary>
        /// <param name="Mascota">Objeto <Proyecto2.Entidades.Clases.Mascota> con los datos actualizado del Mascota</param>
        /// <returns>Verdadero si se actualiza la mascota. Falso en caso contrario</returns>
        public async Task<bool> ActualizarMascota(Mascota mascota)
        {
            try
            {
                var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

                var contenido = new StringContent(JsonConvert.SerializeObject(mascota), System.Text.Encoding.UTF8, "application/json");

                var respuesta = await httpClient.PutAsync("ActualizarMascota", contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la mascota: " + ex.Message);
            }
        }
        /// <summary>
        /// Metodo para buscar Mascotas por criterio de busqueda.
        /// </summary>
        /// <param name="criterioBusqueda"></param>
        /// <returns>Objeto Task<IEnumerable<Mascota>> con la lista de Mascotas que cumplieron con el criterio de busqueda. Puede ser vacia.</returns>
        public async Task<IEnumerable<Mascota>> BuscarMascota(string criterioBusqueda)
        {
            try
            {
                IEnumerable<Mascota> clientes = new List<Mascota>();

                var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

                var respuesta = httpClient.GetAsync($"BuscarMascota/{criterioBusqueda}");

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var json_respuest = await respuesta.Result.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<IEnumerable<Mascota>>(json_respuest);
                    clientes = resultado!;
                }

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la mascota: " + ex.Message);
            }
        }
        /// <summary>
        /// Metodo para crear una Mascota nueva.
        /// </summary>
        /// <param name="mascota">Objeto <Proyecto2.Entidades.Clases.Mascota> con los datos del Mascota</param>
        /// <returns>Verdadero si se crea la mascota. Falso en caso contrario</returns>
        public async Task<bool> CrearMascota(Mascota mascota)
        {
            try
            {
                var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

                var contenido = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(mascota), System.Text.Encoding.UTF8, "application/json");

                var respuesta = await httpClient.PostAsync("CrearMascota", contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la mascota: " + ex.Message);
            }
        }
        /// <summary>
        /// Metodo para eliminar una Mascota existente.
        /// </summary>
        /// <param name="id">Valor <int> con el identificador de la mascota</param>
        /// <returns>Verdadero si se crea la mascota. Falso en caso contrario</returns>
        public async Task<bool> EliminarMascota(int id)
        {
            try
            {
                var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

                var respuesta = await httpClient.DeleteAsync($"EliminarMascota/{id}");

                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la mascota: " + ex.Message);
            }
        }
        /// <summary>
        /// Metodo para leer una Mascota existente.
        /// </summary>
        /// <param name="id">Valor <int> con el identificador de la mascota</param>
        /// <returns>Objeto Task<Proyecto2.Entidades.Clases.Mascota> de la mascota</returns>
        public async Task<Mascota> LeerMascota(int id)
        {
            try
            {
                Mascota mascota = new Mascota();

                var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

                var respuesta = await httpClient.GetAsync($"LeerMascota/{id}");

                if (respuesta.IsSuccessStatusCode)
                {
                    var json_respuest = respuesta.Content.ReadAsStringAsync().Result;
                    var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<Mascota>(json_respuest);
                    mascota = resultado!;
                }

                return mascota;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer la mascota: " + ex.Message);
            }
        }
        /// <summary>
        /// Metodo para listar todos las Mascotas existentes.
        /// </summary>
        /// <returns>Objeto Task<IEnumerable<Mascota>> con la lista de Mascotas.</returns>
        public async Task<IEnumerable<Mascota>> ListarMascotas()
        {
            try
            {
                IEnumerable<Mascota> mascotas = new List<Mascota>();

                var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

                var respuesta = await httpClient.GetAsync("ListarMascotas");

                if (respuesta.IsSuccessStatusCode)
                {
                    var json_respuest = respuesta.Content.ReadAsStringAsync().Result;
                    var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Mascota>>(json_respuest);
                    mascotas = resultado!;
                }
                return mascotas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las mascotas: " + ex.Message);
            }
        }
    }
}
