using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace ProyectoWeb.Controllers;



[ApiController]
//[Route("clients")]
[Route("[controller]")]
public class BusquedaController : ControllerBase
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
                    Cedula = "123",
                    CorreoElectronico = "maria@google.com",
                    Activo = true
                };

                _datos.Add(client);

                _datos.Add(new ClienteDto()
                {
                    Id = 2,
                    Nombre = "Luis",
                    Cedula = "456",
                    CorreoElectronico = "luis@foo.com",
                    Activo = false
                });

                _datos.Add(new ClienteDto()
                {
                    Id = 3,
                    Nombre = "Carlos",
                    Cedula = "789",
                    CorreoElectronico = "carlos@ecuador.com",
                    Activo = false
                });


                _datos.Add(new ClienteDto()
                {
                    Id = 4,
                    Nombre = "Fernando",
                    Cedula = "0000",
                    CorreoElectronico = "Fernando@ecuador.com",
                    Activo = false
                });

                _datos.Add(new ClienteDto()
                {
                    Id = 5,
                    Nombre = "Marco",
                    Cedula = "9999",
                    CorreoElectronico = "Marco@ecuador.com",
                    Activo = false
                });

                _datos.Add(new ClienteDto()
                {
                    Id = 6,
                    Nombre = "Mariela",
                    Cedula = "13579",
                    CorreoElectronico = "Mariela@google.com",
                    Activo = false
                });

            }

            return _datos;
        }
    }

    // [HttpGet]
    // public List<ClienteDto> Buscar(string? valorBuscar)
    // {
    //     var query = datos.AsQueryable();

    //     if (!string.IsNullOrEmpty(valorBuscar))
    //     {

    //         query = query.Where(x =>

    //                    x.Nombre.ToUpper().Contains(valorBuscar.ToUpper())

    //                 || x.Cedula.ToUpper().StartsWith(valorBuscar.ToUpper())

    //                 || x.CorreoElectronico.ToUpper().Contains(valorBuscar.ToUpper())

    //                 );
    //     }

    //     return query.ToList();
    // }
    [HttpGet]
    public List<ClienteDto> BuscarNombreYCedula(string? nombreBuscar, string? cedulaBuscar)
    {
        var query = datos.AsQueryable();

        if (!string.IsNullOrEmpty(nombreBuscar))
        {

            query = query.Where(x =>

                       x.Nombre.ToUpper().Contains(nombreBuscar.ToUpper())

                    && x.Cedula.ToUpper().Contains(cedulaBuscar.ToUpper())

                    );
        }

        return query.ToList();
    }



}