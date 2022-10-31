using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaseEntityFramework
{
    public static class ObjetosNulos
    {
        public static void Ejecutar(){
            //Valores nulos,
            int? valor = null;
            bool? existe = null;

            if(valor.HasValue){
                //Tiene valor
            }
            
            FooNulo fooNulo = null;
        }
    }
    public class FooNulo {
        public string Name {get;set;}
    }
}