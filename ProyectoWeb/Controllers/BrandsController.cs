using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Controllers
{
    [ApiController]
    [Route("ecommerce/v1/[controller]")]
    public class BrandsController : ControllerBase
    {
        [HttpGet]
        public List<ClienteDto> Obtener()
        {
            return null;

        }
    }
}