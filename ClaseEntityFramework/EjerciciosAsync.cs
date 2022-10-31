using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaseEntityFramework
{
    public class EjerciciosAsync
    {
        public static Task EjecutarAsync (){
            var guardarArchivo = new GuardarArchivo();

            var resultado = guardarArchivo.GuardarAsync();

            return Task.CompletedTask;
        }
    }
    public class GuardarArchivo{
        public async Task<bool> GuardarAsync(){
            await Task.Delay(299);
            return await Task.FromResult(true);
        }
    }
    public class ApiFoo{
        
    }
}