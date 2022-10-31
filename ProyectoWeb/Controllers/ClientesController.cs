using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace ProyectoWeb.Controllers

{
    [ApiController]
    [Route("clients")]
    public class ClientesController : ControllerBase
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
                        Nombre = "Mary",
                        Activo = true
                    };

                    _datos.Add(client);

                    _datos.Add(new ClienteDto()
                    {
                        Id = 2,
                        Nombre = "Lois",
                        Activo = false
                    });
                    _datos.Add(new ClienteDto()
                    {
                        Id = 3,
                        Nombre = "Francis",
                        Activo = false
                    });


                    _datos.Add(new ClienteDto()
                    {
                        Id = 4,
                        Nombre = "Juan",
                        Activo = false
                    });

                    _datos.Add(new ClienteDto()
                    {
                        Id = 5,
                        Nombre = "Jose",
                        Activo = false
                    });

                    _datos.Add(new ClienteDto()
                    {
                        Id = 6,
                        Nombre = "Majo",
                        Activo = false
                    });

                }

                return _datos;
            }
        }
        // [HttpGet]
        // public List<ClienteDto> Obtener()
        // {
        //     return datos;

        // }
        [HttpGet]
        public ListaPaginada<ClienteDto> ObtenerConOrdenacion(
        string order = "Nombre",
        TipoOrdenamiento sort = TipoOrdenamiento.Asc)
        {

            var query = datos.AsQueryable();

            switch (order.ToUpper())
            {
                case "NOMBRE":
                    query = (sort == TipoOrdenamiento.Asc) ?
                                    query.OrderBy(x => x.Nombre) :
                                    query.OrderByDescending(x => x.Nombre);
                    break;
                case "ID":
                    query = (sort == TipoOrdenamiento.Asc) ? query.OrderBy(x => x.Id) :
                                   query.OrderByDescending(x => x.Id);
                    break;
                default:
                    throw new ArgumentException($"Campo {order} no soportado para ordenamiento");
            }
            var result = new ListaPaginada<ClienteDto>();
            result.Lista = query.ToList();
            result.Total = datos.Count;
            return result;
        }


        [HttpPost]
        public ClienteDto Agregar(ClienteDto clienteDto)
        {
            datos.Add(clienteDto);

            return clienteDto;
        }
        [HttpDelete("{id}")]
        public bool Eliminar(int id)
        {
            var cliente = datos.Where(x => x.Id == id).SingleOrDefault();
            if (cliente == null)
            {
                throw new Exception($"El cliente {id} no existe");
            }
            return datos.Remove(cliente);
        }
        [HttpPut("{id}")]
        public ClienteDto Actualizar(int id, ClienteDto cliente)
        {
            var encontrarCliente = datos.Find(x => x.Id == id);
            if (encontrarCliente == null)
            {
                throw new Exception($"El cliente {id} no existe");
            }
            encontrarCliente.Nombre = cliente.Nombre;
            encontrarCliente.Activo = cliente.Activo;
            return cliente;
        }
    }
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string Cedula {get; set;}
        public string CorreoElectronico {get; set;}
    }

}