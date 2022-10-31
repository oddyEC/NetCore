using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.NetCore
{
    public class Listas
    {
        public static void EjercicioBasico(){
            var listaNumeros = new List<int>();
            listaNumeros.Add(10);
            listaNumeros.Add(23);
            listaNumeros.Add(32);
            listaNumeros.Add(-20);
            Imprimir(listaNumeros);
            listaNumeros.RemoveAt(0);
            //Eliminar Elementos
            listaNumeros.RemoveAt(-20);
            Imprimir(listaNumeros);

            var listaLong = new List<long>();
            listaLong.Add(2999);
            listaLong.Add(2999);
            listaLong.Add(2999);
            listaLong.Add(2999);
            listaLong.Add(2999);
            listaLong.Add(2999);
            listaLong.Add(2999);
            listaLong.Add(2999);
            listaLong.Add(2999);
            listaLong.Add(2999);
            listaLong.Add(2999);
            

        }
        public static void Imprimir(List<int> lista){
            foreach (var item in lista)
            {
                System.Console.WriteLine(item);
            }
        }
        public static void Multiplicar(List<long> listaLong){
            var mult = listaLong.Aggregate((x,y)=>x * y);
            System.Console.WriteLine(mult);
        }
    }
}