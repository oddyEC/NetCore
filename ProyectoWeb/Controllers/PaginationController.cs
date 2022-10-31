using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace ProyectoWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class PaginationController : ControllerBase
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

                _datos.Add(new ClienteDto()
                {
                    Id = 3,
                    Nombre = "Carlos",
                    Activo = false
                });


                _datos.Add(new ClienteDto()
                {
                    Id = 4,
                    Nombre = "Fernando",
                    Activo = false
                });

                _datos.Add(new ClienteDto()
                {
                    Id = 5,
                    Nombre = "Marco",
                    Activo = false
                });

                _datos.Add(new ClienteDto()
                {
                    Id = 6,
                    Nombre = "Mariela",
                    Activo = false
                });

            }

            return _datos;
        }
    }

    private const int LimiteMaximo = 3;

    [HttpGet]
    public ListaPaginada<ClienteDto> ObtenerConPaginacion(int limit = 3, int offset = 0)
    {
        //Control
        if (limit > LimiteMaximo)
        {
            limit = LimiteMaximo;
        }

        //Linq. 
        var clientesPaginados = datos
                                .Skip(offset)
                                .Take(limit);

        //Creacion Objetos. 
        var result = new ListaPaginada<ClienteDto>();
        result.Lista = clientesPaginados.ToList();
        result.Total = datos.Count;

        return result;
    }

}


public class ListaPaginada<T> where T : class
{

    public ICollection<T> Lista { get; set; }

    public long Total { get; set; }
}