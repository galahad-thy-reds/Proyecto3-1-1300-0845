using Newtonsoft.Json;
using Proyecto3.WebUI.Servicios.Interfaces;
using Proyecto3.Entidades.Clases;

namespace Proyecto3.WebUI.Servicios.Clases
{
    public class ClienteServicio : IClienteServicio
    {
        #region Atributos
        private readonly string _BaseURL = "http://localhost:5004/api/cliente/";
        #endregion

        #region Metodos de IClienteServicio
        /// <summary>
        /// Metodo para actualizar los datos de un cliente existente.
        /// </summary>
        /// <param name="cliente">Objeto <Proyecto2.Entidades.Clases.Cliente> con los datos actualizado del cliente</param>
        /// <returns>Verdadero si se actualiza el cliente. Falso en caso contrario</returns>
        public async Task<bool> ActualizarCliente(Cliente cliente)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var contenido = new StringContent(JsonConvert.SerializeObject(cliente), System.Text.Encoding.UTF8, "application/json");

            var respuesta = await httpClient.PutAsync("ActualizarCliente", contenido);

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
        /// Metodo para buscar clientes por criterio de busqueda.
        /// </summary>
        /// <param name="criterioBusqueda"></param>
        /// <returns>Objeto Task<IEnumerable<cliente>> con la lista de Clientes que cumplieron con el criterio de busqueda. Puede ser vacia.</returns>
        public async Task<IEnumerable<Cliente>> BuscarCliente(string criterioBusqueda)
        {
            IEnumerable<Cliente> clientes = new List<Cliente>();

            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await httpClient.GetAsync($"BuscarCliente/{criterioBusqueda}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuest = respuesta.Content.ReadAsStringAsync().Result;
                var resultado = JsonConvert.DeserializeObject<IEnumerable<Cliente>>(json_respuest);
                clientes = resultado!;
            }

            return clientes;
        }
        /// <summary>
        /// Metodo para crear un cliente nuevo.
        /// </summary>
        /// <param name="cliente">Objeto <Proyecto2.Entidades.Clases.Cliente> con los datos del cliente</param>
        /// <returns>Verdadero si se agrega el cliente. Falso en caso contrario</returns>
        public async Task<bool> CrearCliente(Cliente cliente)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var contenido = new StringContent(JsonConvert.SerializeObject(cliente), System.Text.Encoding.UTF8, "application/json");

            var respuesta = await httpClient.PostAsync("CrearCliente", contenido);

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
        /// Metodo para eliminar un cliente existente.
        /// </summary>
        /// <param name="Cliente">Valor <string> con el cliente a eliminar</param>
        /// <returns>Verdadero si se elimina el cliente. Falso en caso contrario</returns>
        public async Task<bool> EliminarCliente(string cedula)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await httpClient.DeleteAsync($"EliminarCliente/{cedula}");

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
        /// Metodo para leer un cliente existente.
        /// </summary>
        /// <param name="cedula">Valor <string> con la cedula del cliente que se desea leer los datos</param>
        /// <returns></returns>
        public async Task<Cliente> LeerCliente(string cedula)
        {
            var cliente = new Cliente();

            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await httpClient.GetAsync($"LeerCliente/{cedula}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuest = await respuesta.Content.ReadAsStringAsync();
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<Cliente>(json_respuest);
                cliente = resultado!;
            }

            return cliente;
        }
        /// <summary>
        /// Metodo para listar todos los clientes existentes.
        /// </summary>
        /// <returns>Objeto Task<IEnumerable<Cliente>> con la lista de Clientes.</returns>
        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            IEnumerable<Cliente> clientes = new List<Cliente>();

            var httpClient = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await httpClient.GetAsync("ListarClientes");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuest = await respuesta.Content.ReadAsStringAsync();
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Cliente>>(json_respuest);
                clientes = resultado!;
            }

            return clientes;
        }
        #endregion

    }
}
