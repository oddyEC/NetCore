using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.NetCore
{
    public static class LinqCurso
    {
        public static void Ejercicio()
        {
            var empleados = ObtenerEmpleados();
            var requerimiento = from e in empleados
                                group e by e.Departamento into empDep
                                orderby empDep.Key
                                select new{
                                    Dep = empDep.Key,
                                    TotalDep = empDep.Sum(x => x.Sueldo),
                                    TotalEmp = empDep.Count()
                                };
            foreach (var dep in requerimiento)
            {
                System.Console.WriteLine($"Key: {dep.Dep}, Total por Departamento: {dep.TotalDep}, Total de Empleados: {dep.TotalEmp}");
                // foreach (var empleado in dep)
                // {
                //     System.Console.WriteLine($"\t{empleado.Nombre}, {empleado.Sueldo}");
                // }
            }
        }
        public static void Basico()
        {
            int[] listaIds = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            //Linq. (Consulta)
            //Where. (Filtro). (Sql). 
            //x => x < 5.
            //1. landan x => (...)
            //2. x < 5. (Condicion). 
            var listaMejoresCinco = listaIds.Where(x => x < 5);

            foreach (var item in listaMejoresCinco)
            {
                Console.WriteLine(item);
            }

            //Lista empreados
            var listaEmpleados = ObtenerEmpleados();


            //Obtener todos los empleados.Sexo = Mujer.
            var empleadosMujeres = listaEmpleados.Where(i => i.Sexo == Sexo.Mujer);

            var empleadosSuledoMenor1000 = listaEmpleados.Where(x => x.Sueldo < 1000);

            //Obtener RRHH, ganen mas 1200 ??
            var empleadosRRHHMayor1200 = listaEmpleados.Where(x =>
                            x.Sueldo > 1200
                            && x.Departamento == Departamento.RRHH);

            Console.WriteLine("Obtener RRHH, ganen mas 1200");
            Print(empleadosRRHHMayor1200.ToList());

        }


        public static void Proyecciones()
        {

            //Proyecciones: Select
            //Proyecciones de una propiedad
            var listaNombresEmpleados = ObtenerEmpleados()
                        .Select(x => x.Nombre);


            foreach (var nombres in listaNombresEmpleados)
            {
                Console.Write(nombres);
            }



            //Proyecciones sobre otro objeto, a partir de un objeto origen
            var listaEmpleadosInfo = ObtenerEmpleados()
                .Select(x => new EmpeadoInfo
                {
                    Name = x.Nombre,
                    Active = x.Activo
                });

            foreach (var empeadoInfo in listaEmpleadosInfo)
            {
                Console.Write(empeadoInfo);
            }

            //Proyecciones con objetos anonimos
            var listaPropiedadesEmpleados = ObtenerEmpleados()
                .Select(x => new
                {
                    Name = x.Nombre,
                    Active = x.Activo
                });

            foreach (var empeadoInfo in listaPropiedadesEmpleados)
            {
                Console.Write(empeadoInfo);
            }


        }


        public static void Notaciones()
        {

            //Notaciones Metodo
            //Se utilizan metodos. (Metodos Extendidos)

            //Obtener los nombres y departamentos de todos los empleados que sean activos.
            var consultaNotacionMetodo = ObtenerEmpleados()
                            //Filtro. Condiciones
                            .Where(a => a.Activo)
                            //Proyeccion (Seleccionan las propiedades)
                            .Select(a => new
                            {
                                a.Nombre,
                                a.Departamento
                            })
                            ;

            //Notaciones Consulta
            var consultaNotacionConsulta = from a in ObtenerEmpleados()
                                               //Filtro. Condiciones
                                           where
                                                a.Activo
                                           //Proyeccion. (Seleccionan las propiedades)
                                           select new
                                           {
                                               a.Nombre,
                                               a.Departamento
                                           }
                                            ;
            //SQL
            //1 => true
            //select nombre, departamento from Empleados where activo == 1


        }


        public static void Conjuntos()
        {

            var listaChar = new char[] { 'A', 'B', 'C', 'D', 'D', 'F' };

            var listaCiudades = new string[] { "Quito", "Cuenca", "Machala", "Guayaquil", "Loja" };

            var listaNombres = new string[] { "Maria", "Carmen", "Luis", "Roberto", "Felipe" };


            //Union
            var listaA = new int[] { 1, 1, 2, 3, 4, 5 };
            var listaB = new int[] { 4, 5, 6, 6, 8, 9 };
            Console.WriteLine("Listado. listaA");
            foreach (var item in listaA)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Listado. listaB");
            foreach (var item in listaB)
            {
                Console.WriteLine(item);
            }

            var resultado = listaA.Union(listaB);

            Console.WriteLine("Listado. Union");
            foreach (var item in resultado)
            {
                Console.WriteLine(item);
            }

            //Intersect
            var resultadoIntersect = listaA.Intersect(listaB);
            Console.WriteLine("Listado. Intersect");
            foreach (var item in resultadoIntersect)
            {
                Console.WriteLine(item);
            }


            var resultadoExcept = listaA.Except(listaB);
            Console.WriteLine("Listado. Except");
            foreach (var item in resultadoExcept)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Listado. listaA. Quitar duplicados");
            foreach (var item in listaA.Distinct())
            {
                Console.WriteLine(item);
            }


        }



        public static void PaginacionBasica()
        {

            var listaLetras = new List<int>{
                    1,2,3,4,5,6,7,8,9,0
               };

            var listaPrimerosCuatro = listaLetras.Take(4);

            Console.WriteLine("Primeros 4");

            foreach (var item in listaPrimerosCuatro)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Ultimos 4");
            var listaUltimosCuatro = listaLetras.Skip(6);
            foreach (var item in listaUltimosCuatro)
            {
                Console.WriteLine(item);
            }

            //5,6,7
            Console.WriteLine("Numeros Medio");
            var listaMedio = listaLetras.Skip(4).Take(3);
            foreach (var item in listaMedio)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Orden Take Skip");
            var listaOrdenDiferente = listaLetras.Take(3).Skip(4);
            foreach (var item in listaOrdenDiferente)
            {
                Console.WriteLine(item);
            }
        }


        public static void Ordenamiento()
        {

            var empleados = ObtenerEmpleados();

            //Ordenamiento por la propiedad nombre (ascen)
            var empleadosOrdenadosNombre = empleados.OrderBy(x => x.Nombre);

            //Ordenamiento por la propiedad nombre (desc)
            var empleadosOrdenadosNombreDesc = empleados.OrderByDescending(x => x.Nombre);

            //Listado de empleados ordenados por nombre (asc), y por sueldo (desc)
            var empleadosOrdenadosNombreSueldo = empleados.OrderBy(x => x.Nombre)
                                                .OrderByDescending(x => x.Sueldo);

            //Ordenar lista empleados sueldo (menor a mayor), y un segundo orden por su nombres
            var x = empleados.OrderBy(x => x.Sueldo).OrderBy(x => x.Nombre);


        }


        public static void PaginacionOrdenamiento()
        {

            var empleados = ObtenerEmpleados();


            //Obtener la primea pagina de empleados, ordenados por sueldo (menor a mayor)
            //Pagina Size: 3

            var consulta = (from e in empleados
                            orderby e.Sueldo
                            select e
                           ).Take(3)
                           ;

            Print(consulta.ToList());


            //Obtener 3 pagina de empleados, ordenados por sueldo (menor a mayor)
            //Pagina Size: 3

            var consultaTerceraPagina = (from e in empleados
                                         orderby e.Sueldo
                                         select e
                           ).Skip(6).Take(3)
                           ;

            Print(consulta.ToList());

            //Notacion Metodo
            var consultaSegundaPaginaMetodo =
                                        empleados
                                        .OrderBy(a => a.Sueldo)
                                        .Skip(3)
                                        .Take(3)
                           ;

            Print(consultaSegundaPaginaMetodo.ToList());


        }






        public static void Print(List<Empleado> empleados)
        {

            foreach (var empleado in empleados)
            {
                Console.WriteLine(empleado);
            }

        }

        public static List<Empleado> ObtenerEmpleados()
        {

            var nomina = new EmpleadoCategoria { Codigo = "N", Nombre = "Nomina" };
            var contratado = new EmpleadoCategoria { Codigo = "C", Nombre = "Contratado" };


            var list = new List<Empleado>();
            list.Add(new Empleado
            {
                Activo = true,
                Departamento = Departamento.Operaciones,
                Nombre = "Maria",
                EmpleadoCategoria = nomina,
                Sexo = Sexo.Mujer,
                Sueldo = 1200M
            });

            list.Add(new Empleado
            {
                Activo = true,
                Departamento = Departamento.RRHH,
                Nombre = "Luis",
                EmpleadoCategoria = contratado,
                Sexo = Sexo.Hombre,
                Sueldo = 800M
            });
            // list.Add(new Empleado
            // {
            //     Activo = true,
            //     Departamento = Departamento.RRHH,
            //     Nombre = "Luis",
            //     EmpleadoCategoria = contratado,
            //     Sexo = Sexo.Hombre,
            //     Sueldo = 800M
            // });
            list.Add(new Empleado
            {
                Activo = true,
                Departamento = Departamento.RRHH,
                Nombre = "Felipe",
                EmpleadoCategoria = nomina,
                Sexo = Sexo.Hombre,
                Sueldo = 2000M
            });


            list.Add(new Empleado
            {
                Activo = true,
                Departamento = Departamento.Operaciones,
                Nombre = "Fernanda",
                EmpleadoCategoria = contratado,
                Sexo = Sexo.Mujer,
                Sueldo = 1340M
            });

            return list;

        }
    }


    public class EmpeadoInfo
    {

        public string Name { get; set; }

        public bool Active { get; set; }

    }


    public class Empleado
    {

        public string Nombre { get; set; }

        public Sexo Sexo { get; set; }

        public bool Activo { get; set; }

        public decimal Sueldo { get; set; }

        public EmpleadoCategoria EmpleadoCategoria { get; set; }

        public Departamento Departamento { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Sexo: {Sexo}, Activo: {Activo}, Sueldo: {Sueldo}, EmpleadoCategoria: {EmpleadoCategoria},, Departamento: {Departamento}";
        }

    }

    public class EmpleadoCategoria
    {
        public string Codigo { get; set; }

        public string Nombre { get; set; }
    }

    public enum Sexo
    {

        Hombre,
        Mujer
    }

    public enum Departamento
    {

        RRHH,
        Operaciones,
        Tecnicos,
        Ventas
    }


    public class EmpleadoPagos
    {


    }

}
