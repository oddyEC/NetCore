using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Controllers
{
    [ApiController]
    [Route("/ecommerce/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<ClienteDto> _datos;
        protected static List<ClienteDto> datos
        {
            get
            {
                if (_datos == null)
                {
                    _datos = new List<ClienteDto>();
                    var client = new ClienteDto
                    {
                        Id = 1,
                        Nombre = "Maria",
                        Activo = true
                    };

                    _datos.Add(client);

                    _datos.Add(new ClienteDto()
                    {
                        Id = 2,
                        Nombre = "Luis",
                        Activo = false
                    });

                }

                return _datos;
            }
        }
        [HttpGet("{productId}")]
        public List<ClienteDto> Obtener(int productId)
        {
            return null;

        }
        [HttpGet("brand/{brandId}")]
        public List<ClienteDto> Obtener1(int brandId)
        {
            return null;

        }
        [HttpGet("/rest/{storeCode}/products")]
        public List<ClienteDto> Obtener2(int storeCode)
        {
            return null;

        }
        [HttpPost]
        public ClienteDto Agregar(ClienteDto clienteDto)
        {
            datos.Add(clienteDto);

            return null;
        }
        [HttpPost("/products/bulk")]
        public bool Crear(List<ClienteDto> clientes ){
            return false;
        }
        //Lista de ids o booleano confirmando
        // public List<id, Guid, string o etc..> 

    }
}