using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.NetCore
{
    public class ITieneValor {

    }
    public class Cuenta: ITieneValor {

    }
    public class Evento{
        public int HoraEvento;
        public string NombreEvento;
        public decimal ValorEvento; //decimal -> float calculo cientifico
        public string LugarEvento;
    }
    public class MatricesCurso
    {
        public static void EjercicioBasico(){
 
            //Forma A
            var listaNumeros = new int[] {1,3,4,5,6};
            var listaCadenas = new string[]{"Quito","Guayaquil"};
            var listaNumeroSinInicializar = new int[10];
            //Forma B
            listaNumeroSinInicializar[0] = 20;
            listaNumeroSinInicializar[1] = 10;
            listaNumeroSinInicializar[2] = 30;

            var listaObjetos = new Evento[]{
                new Evento{HoraEvento = 10,NombreEvento = "Danza", ValorEvento = 10.2M, LugarEvento = "Guayaquil" },
                new Evento{HoraEvento = 11,NombreEvento = "Futbol", ValorEvento = 101.2M, LugarEvento = "Quito" },
                new Evento{HoraEvento = 13,NombreEvento = "Basquet", ValorEvento = 102.2M, LugarEvento = "Cuenca" },
                new Evento{HoraEvento = 10,NombreEvento = "Natacion", ValorEvento = 10.2M, LugarEvento = "Loja" },
            };
        }
        public static void EjercicioRecorrer(){
            var listaEventos = new Evento[]{
                                new Evento{HoraEvento = 10,NombreEvento = "Danza", ValorEvento = 10.2M, LugarEvento = "Guayaquil" },
                new Evento{HoraEvento = 11,NombreEvento = "Futbol", ValorEvento = 101.2M, LugarEvento = "Quito" },
                new Evento{HoraEvento = 13,NombreEvento = "Basquet", ValorEvento = 102.2M, LugarEvento = "Cuenca" },
                new Evento{HoraEvento = 10,NombreEvento = "Natacion", ValorEvento = 10.2M, LugarEvento = "Loja" },
            };
            for(int i = 0; i < listaEventos.Length; i++)
            {
                System.Console.WriteLine(listaEventos[i]);
            }
            foreach (var item in listaEventos)
            {
                Console.WriteLine(item);
            }
        }
    }
}