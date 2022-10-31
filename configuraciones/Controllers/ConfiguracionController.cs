using System.Net.Cache;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace configuraciones.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfiguracionController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ConfiguracionController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public string ObtenerValor(string clave)
        {
            var valor = configuration.GetValue<string>(clave);
            if (string.IsNullOrEmpty(valor))
            {
                throw new ArgumentException($"La clave {clave}, no existe en la configuracion", clave);
            }
            return valor;
        }
        [HttpGet("obtener_activo")]
        public bool ObtenerValor()
        {
            var activo = configuration.GetValue<bool>("Aplicacion:Informacion:Activo");
            return activo;

        }
        [HttpGet("obtener_nombre")]
        public string ObtenerNombre()
        {
            var nombre = configuration.GetValue<string>("TiposDatos:Informacion:Nombre");
            return nombre;
        }
        [HttpGet("obtener_numero")]
        public int ObtenerNumero()
        {
            var numero = configuration.GetValue<int>("TiposDatos:Informacion:NumeroId");
            return numero;
        }

        [HttpGet("obtener_verificacion")]
        public string ObtenerVerificacion()
        {
            var verificacion = configuration.GetValue<string>("TiposDatos:Informacion:Verification");
            return verificacion;
        }

        [HttpGet("otra_capacidad")]
        public string ObtenerValores(){
            var nombre = configuration.GetValue<string>("TiposDatos:Informacion:Nombre");
            var numero = configuration.GetValue<int>("TiposDatos:Informacion:NumeroId");
            var verificacion = configuration.GetValue<string>("TiposDatos:Informacion:Verification");
            var lista = configuration.GetSection("TiposDatos:Developer").Get<List<string>>();
            return $"Nombre: {nombre}, Numero: {numero}, Verificacion: {verificacion}, Lista: {lista}";
        }

    }
}