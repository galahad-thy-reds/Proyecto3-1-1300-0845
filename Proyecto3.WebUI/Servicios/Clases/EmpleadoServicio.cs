using Newtonsoft.Json;
using Proyecto3.Entidades.Clases;
using Proyecto3.WebUI.Servicios.Interfaces;

namespace Proyecto3.WebUI.Servicios.Clases
{
    public class EmpleadoServicio : IEmpleadoServicio
    {
        #region Atributos
        private readonly string _BaseURL = "http://localhost:5004/api/Empleado/";
        #endregion

        #region Metodos de IEmpleadoServicio
        /// <summary>
        /// Metodo para actualizar los datos de un Empleado existente.
        /// </summary>
        /// <param name="empleado">Objeto <Proyecto2.Entidades.Clases.Empleado> con los datos actualizado del empleado</param>
        /// <returns>Verdadero si se actualiza el empleado. Falso en caso contrario</returns>d
        public async Task<bool> ActualizarEmpleado(Empleado empleado)
        {
            var clienteAPI = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var contenido = new StringContent(JsonConvert.SerializeObject(empleado), System.Text.Encoding.UTF8, "application/json");

            var respuesta = await clienteAPI.PutAsync("ActualizarEmpleado", contenido);

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
        /// Metodo para buscar empleados por criterio de busqueda.
        /// </summary>
        /// <param name="criterioBusqueda"></param>
        /// <returns>Objeto Task<IEnumerable<Proyecto2.Entidades.Clases.Empleado>> con la lista de empleados que cumplieron con el criterio de busqueda. Puede ser vacia.</returns>
        public async Task<IEnumerable<Empleado>> BuscarEmpleado(string criterioBusqueda)
        {
            IEnumerable<Empleado> empleados = new List<Empleado>();

            var clienteAPI = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await clienteAPI.GetAsync($"BuscarEmpleado/{criterioBusqueda}?");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuest = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<IEnumerable<Empleado>>(json_respuest);
                empleados = resultado!;
            }

            return empleados;
        }
        /// <summary>
        /// Metodo para crear un Empleado nuevo.
        /// </summary>
        /// <param name="empleado">Objeto <Proyecto2.Entidades.Clases.Empleado> con los datos del empleado</param>
        /// <returns>Verdadero si se crea el empleado. Falso en caso contrario</returns>
        public async Task<bool> CrearEmpleado(Empleado empleado)
        {
            var clienteAPI = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var contenido = new StringContent(JsonConvert.SerializeObject(empleado), System.Text.Encoding.UTF8, "application/json");

            var respuesta = await clienteAPI.PostAsync("CrearEmpleado/", contenido);

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
        /// Metodo para eliminar un Empleado existente.
        /// </summary>
        /// <param name="empleado">Valor <string> con el empleado a eliminar</param>
        /// <returns>Verdadero si se elimina el empleado. Falso en caso contrario</returns>
        public async Task<bool> EliminarEmpleado(string cedula)
        {
            var clienteAPI = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await clienteAPI.DeleteAsync($"EliminarEmpleado/{cedula}?");

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
        /// Metodo para leer un Empleado existente.
        /// </summary>
        /// <param name="cedula">Valor <string> con la cedula del empleado que se desea leer los datos</param>
        /// <returns>Objeto Task<Proyecto2.Entidades.Clases.Empleado> del empleado.</returns>
        public async Task<Empleado> LeerEmpleado(string cedula)
        {
            var empleado = new Empleado();

            var clienteAPI = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await clienteAPI.GetAsync($"LeerEmpleado/{cedula}?");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuest = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Empleado>(json_respuest);
                empleado = resultado!;
            }

            return empleado;
        }
        /// <summary>
        /// Metodo para listar todos los empleados existentes.
        /// </summary>
        /// <returns>Objeto Task<IEnumerable<Proyecto2.Entidades.Clases.Empleado>> con la lista de empleados.</returns>
        public async Task<IEnumerable<Empleado>> ListarEmpleados()
        {
            IEnumerable<Empleado> empleados = new List<Empleado>();

            var clienteAPI = new HttpClient { BaseAddress = new Uri(_BaseURL) };

            var respuesta = await clienteAPI.GetAsync("ListarEmpleados");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuest = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<IEnumerable<Empleado>>(json_respuest);
                empleados = resultado!;
            }

            return empleados;
        }
        #endregion
    }
}
