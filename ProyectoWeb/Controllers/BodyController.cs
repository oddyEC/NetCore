using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class BodyController : ControllerBase
{

    //Body: POST, PUT, DELETE, PATCH, ... 
    [HttpPost]
    public string ObtenerValor(BodyInput input)
    {

        return $"Datos Enviados: {input}";

    }

    //Body: POST, PUT, DELETE, PATCH, ... 
    [HttpPost("explicito")]
    public string ObtenerValorExplicito([FromBody] BodyInput input)
    {

        return $"Datos Enviados: {input}";

    }

}

public class BodyInput
{

    [Required]
    [StringLength(10)]
    public string Ciudad { get; set; }

    [Required]
    public string Nombre { get; set; }

    public bool? Activo { get; set; }

    public int? Id { get; set; }

    public override string ToString()
    {
        return $"Ciudad: {Ciudad}, Nombre: {Nombre}, Activo: {Activo}, Id: {Id} ";
    }
}