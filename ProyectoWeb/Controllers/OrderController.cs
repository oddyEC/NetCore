using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace ProyectoWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
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
    public List<ClienteDto> ObtenerConOrdenacion(
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

        return query.ToList();
    }

}

public enum TipoOrdenamiento
{

    Asc = 1,
    Desc = 2
}

