namespace BP.NetCore
{
    public static class LinqCurso
    {

        public static void Basico()
        {
            int[] listaIds = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            //Linq. (Consulta)
            //Where. (Filtro). (Sql). 
            //x => x < 5.
            //1. landan x => (...)
            //2. x < 5. (Condicion). 
            var listaMejoresCinco = listaIds.Where(x => x < 5);

            // foreach (var item in listaMejoresCinco)
            // {
            //     Console.WriteLine(item);
            // }

            //Lista empreados
            var listaEmpleados = ObtenerEmpleados();


            //Obtener todos los empleados.Sexo = Mujer.
            var empleadosMujeres = listaEmpleados.Where(i => i.Sexo == Sexo.Mujer);

            var empleadosSuledoMenor1000 = listaEmpleados.Where(x => x.Sueldo < 1000);
            var empleadasRRHHoOp = listaEmpleados.Where(y => y.Sexo == Sexo.Mujer &&
             (y.Departamento == Departamento.RRHH || y.Departamento == Departamento.Operaciones));
            //Obtener RRHH, ganen mas 1200 ??
            var empleadosRRHHMayor1200 = listaEmpleados.Where(x =>
                            x.Sueldo > 1200
                            && x.Departamento == Departamento.RRHH);
            var empleadosActivos = listaEmpleados.Where(x => x.Activo == true);
            var consultaMujer = listaEmpleados.Where(y => y.Sexo == Sexo.Mujer);
            consultaMujer = consultaMujer.Where(y => y.Departamento == Departamento.RRHH || y.Departamento == Departamento.Operaciones);

            var empleadosA = listaEmpleados.Where(x => x.Nombre.ToUpper().StartsWith("A"));
            var empleadosVac = listaEmpleados.Where(x => x.DiasVac() > 15 && x.Activo == true);
            var contarEmpAct = listaEmpleados.Count(x => x.Activo);
            var existeActivo = listaEmpleados.Any(x => x.Activo);


            // Empleados que comiencen con A

            //Notacion Metodo
            //Se utilizan metodos. (Metodos Extendidos)
            var consultaNotacionMetodo = ObtenerEmpleados()
            .Where(a => a.Activo)
            .Select(a => new
            {
                a.Nombre,
                a.Departamento
            });
            //Notaciones Consulta
            var consultaNotacionConsulta = from a in ObtenerEmpleados()
                                               //Filtro Condiciones
                                           where
                                           a.Activo
                                           //Proyeccion. (Seleccionar las propiedades)
                                           select new
                                           {
                                               a.Nombre,
                                               a.Departamento
                                           };
            var consultaNotacionConsulta1 = from x in ObtenerEmpleados()
                                            where
                                                x.Nombre.ToUpper().StartsWith("A") &&
                                                x.DiasVac() > 15 &&
                                                x.Activo
                                            select x;
            var consultaNotacionConsulta2 = from y in ObtenerEmpleados()
                                            where
                                                y.Sexo == Sexo.Mujer &&
                                                (y.Departamento == Departamento.RRHH
                                                || y.Departamento == Departamento.Operaciones)
                                            select y;
            //System.Console.WriteLine(consultaNotacionConsulta2.ToList());

            System.Console.WriteLine($"{contarEmpAct},{existeActivo}");
            foreach (var item in consultaNotacionConsulta2)
            {
                System.Console.WriteLine($"{item.Nombre} || {item.Sexo} || {item.Activo} || {item.Departamento}");
            }
        }
        public static void Conjuntos()
        {
            var listaChar = new char[] { 'A', 'B', 'D', 'D', 'F' };
            var listaChar2 = new char[] { 'z', 'Z', 'E', 'D', 'R', 'G', 'A' };
            var charUni = listaChar.Union(listaChar2).Distinct();
            var char2 = listaChar.Except(listaChar2).Union(listaChar2);
            var char3 = listaChar2.Intersect(listaChar);
            System.Console.WriteLine("UnionChar");
            foreach (var item in charUni)
            {
                System.Console.WriteLine(item);
            }



            var listaA = new int[] { 1, 1, 2, 3, 4, 5 };
            var listaB = new int[] { 4, 6, 5, 6, 7, 8 };

            var resultado = listaA.Union(listaB);
            var resultadoIntersect = listaA.Intersect(listaB);
            var resultadoExc = listaA.Except(listaB);
            System.Console.WriteLine("Listado Union");
            foreach (var item in resultado)
            {
                System.Console.WriteLine(item);
            }
            //INTERSECCION
            System.Console.WriteLine("Listado Intersección");
            foreach (var item in resultadoIntersect)
            {
                System.Console.WriteLine(item);
            }
            //EXCLUSION
            System.Console.WriteLine("Listado Except");
            foreach (var item in resultadoExc)
            {
                System.Console.WriteLine(item);
            }
            //QUITAR DUPLICADOS
            System.Console.WriteLine("Listado lita A Quitar duplicados");
            foreach (var item in listaA.Distinct())
            {
                System.Console.WriteLine(item);
            }
        }
        public static void Odenamiento()
        {
            var empleados = ObtenerEmpleados();

        }

        public static void PaginacionOrdenamiento()
        {
            var empleados = ObtenerEmpleados();

            //Obtener la primera pagina de empleados, ordenados por sueldo (menor a mayor)
            //Pagina size : 3
            var consulta = (from e in empleados
                            orderby e.Sueldo
                            select e).Take(3);
            var consultaSegundaPaginaMetodo = empleados
            .OrderBy(a => a.Sueldo)
            .Skip(3)
            .Take(3);
        }


        public static void PaginacionBasica()
        {
            var listaLetras = new List<int>{
                1,2,3,4,5,6,7,8,9,0
            };
            var listaPrimerosCuatro = listaLetras.Take(4);
            System.Console.WriteLine("Primeros 4");
            foreach (var item in listaPrimerosCuatro)
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine("Ultimos 4");
            var listaUltimosCuatro = listaLetras.Skip(6);
            foreach (var item in listaUltimosCuatro)
            {
                System.Console.WriteLine(item);
            }

            //5,6,7
            System.Console.WriteLine("Numeros Medio");
            var listaMedio = listaLetras.Skip(4).Take(3);
            foreach (var item in listaMedio)
            {
                System.Console.WriteLine(item);
            }
            var listaOrdenDiferente = listaLetras.Take(3).Skip(4);
            foreach (var item in listaOrdenDiferente)
            {
                System.Console.WriteLine(item);
            }
        }
        public static void Ejercicio()
        {
            var listaEmpleados = ObtenerEmpleados();
            var best3Employees = listaEmpleados.Take(3).Where(y => y.Sueldo > 1200);

            foreach (var item in best3Employees)
            {
                System.Console.WriteLine(item);
            }

            int[] array10 = new int[10];
            int[] arrayOrdenado = {2,4,6,8,10,12,14,16,18,20};
            var random = new Random();
            System.Console.WriteLine("Arreglo Par");
            for (var i = 0; i < array10.Length; i++)
            {
                array10[i] = arrayOrdenado[random.Next(11)];
                System.Console.WriteLine(array10[i]);
            }
            var consultaNumerosMayores = array10.OrderByDescending(a => a).Take(3);
            var numerosPar = array10.Except(consultaNumerosMayores);
            foreach (var item in numerosPar)
            {
                System.Console.WriteLine();
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
        public static void Proyecciones()
        {
            var listaNombresEmpleados = ObtenerEmpleados().Select(x => x.Nombre);
            foreach (var item in listaNombresEmpleados)
            {
                System.Console.Write(item);
            }
            var listaEmpleadosInfo = ObtenerEmpleados()
            .Select(x => new
            {
                Name = x.Nombre,
                Activo = x.Activo
            }
            );
            foreach (var item in listaEmpleadosInfo)
            {
                System.Console.WriteLine(item);
            }
        }
    }
    public class EmpleadoInfo
    {
        public String Nombre { get; set; }
        public String Cargo { get; set; }
    }
    public class Empleado
    {

        public string Nombre { get; set; }


        public Sexo Sexo { get; set; }

        public bool Activo { get; set; }

        public decimal Sueldo { get; set; }

        public EmpleadoCategoria EmpleadoCategoria { get; set; }

        public Departamento Departamento { get; set; }
        public int DiasVac()
        {
            Random rnd = new Random();
            int vac = rnd.Next(1, 50);
            return vac;
        }
        public override string ToString()
        {
            return $"El empleado es {Nombre}, trabaja en el departamente {Departamento}, y el sueldo de el es {Sueldo}";
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
}