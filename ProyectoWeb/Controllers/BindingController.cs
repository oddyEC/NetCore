using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BindingController : ControllerBase
    {
        [HttpPost("[action]/{alias}")]
        public string GetValue(string alias, [FromHeader] string browser, Client client)
        {
            return $"Alias: {alias} | Browser: {browser} | " + client.ToString();
        }
        [HttpPut("[action]")]
        public string GetValue2(string alias, [FromHeader] string browser, [FromForm] Client client)
        {
            return $"Alias: {alias} | Browser: {browser} | " + client.ToString();
        }
    }

    public class Client
    {
        public string Name { get; set; }
        public string Pais { get; set; }
        public int Edad { get; set; }
        public string Ciudad { get; set; }
        public override string ToString()
        {
            return $"Nombre: {Name} | Pais: {Pais} | Edad: {Edad} | Ciudad: {Ciudad}";
        }
    }
}