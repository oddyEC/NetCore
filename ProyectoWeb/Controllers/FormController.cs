using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class FormController : ControllerBase
{


    [HttpPost]
    public string ObtenerValor([FromForm] BodyInput input)
    {

        return $"Datos Enviados: {input}";

    }

}
