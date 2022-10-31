using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.NetCore
{
    public class Objetos
    {
        public static void Basico()
        {

        }
        public static List<Estudiante> ObtenerEstudiantes()
        {
            var sistemas = new Facultad { CodigoFacultad = "sis10", NombreFacultad = "Sistemas de Informacion", NumeroProgramas = 10 };
            var electronica = new Facultad { CodigoFacultad = "elec10", NombreFacultad = "Electronica", NumeroProgramas = 23 };
            var civil = new Facultad { CodigoFacultad = "civ10", NombreFacultad = "Civil", NumeroProgramas = 3 };
            var list = new List<Estudiante>();
            list.Add(new Estudiante
            {
                TipoDocumento = TipoDocumento.cedula,
                IdEstudiante = "234232",
                FechaExpedicion = "10/10/2020",
                NombreCompleto = "Diego Alejandro Marquez Coronel",
                Sexo = Sexo.Hombre,
                Correo = "diegomarquez2008@outlook.com",
                Facultad = sistemas
            });
            list.Add(new Estudiante
            {
                TipoDocumento = TipoDocumento.cedula,
                IdEstudiante = "23452",
                FechaExpedicion = "10/11/2020",
                NombreCompleto = "Diego Alejandro Marquez Coronel",
                Sexo = Sexo.Hombre,
                Correo = "diegomarquez2008@outlook.com",
                Facultad = sistemas
            });
            list.Add(new Estudiante
            {
                TipoDocumento = TipoDocumento.ruc,
                IdEstudiante = "236632",
                FechaExpedicion = "10/12/2020",
                NombreCompleto = "Jose Almeida",
                Sexo = Sexo.Hombre,
                Correo = "jose2008@outlook.com",
                Facultad = civil
            });
            list.Add(new Estudiante
            {
                TipoDocumento = TipoDocumento.cedula,
                IdEstudiante = "234232",
                FechaExpedicion = "10/10/2020",
                NombreCompleto = "Diego Alejandro Marquez Coronel",
                Sexo = Sexo.Hombre,
                Correo = "diegomarquez2008@outlook.com",
                Facultad = sistemas
            });
            list.Add(new Estudiante
            {
                TipoDocumento = TipoDocumento.cedula,
                IdEstudiante = "234232",
                FechaExpedicion = "10/10/2020",
                NombreCompleto = "Diego Alejandro Marquez Coronel",
                Sexo = Sexo.Hombre,
                Correo = "diegomarquez2008@outlook.com",
                Facultad = sistemas
            });
            list.Add(new Estudiante
            {
                TipoDocumento = TipoDocumento.cedula,
                IdEstudiante = "234232",
                FechaExpedicion = "10/10/2020",
                NombreCompleto = "Diego Alejandro Marquez Coronel",
                Sexo = Sexo.Hombre,
                Correo = "diegomarquez2008@outlook.com",
                Facultad = sistemas
            });
            list.Add(new Estudiante
            {
                TipoDocumento = TipoDocumento.cedula,
                IdEstudiante = "234232",
                FechaExpedicion = "10/10/2020",
                NombreCompleto = "Diego Alejandro Marquez Coronel",
                Sexo = Sexo.Hombre,
                Correo = "diegomarquez2008@outlook.com",
                Facultad = sistemas
            });
            list.Add(new Estudiante
            {
                TipoDocumento = TipoDocumento.cedula,
                IdEstudiante = "234232",
                FechaExpedicion = "10/10/2020",
                NombreCompleto = "Diego Alejandro Marquez Coronel",
                Sexo = Sexo.Hombre,
                Correo = "diegomarquez2008@outlook.com",
                Facultad = sistemas
            });
            list.Add(new Estudiante
            {
                TipoDocumento = TipoDocumento.cedula,
                IdEstudiante = "234232",
                FechaExpedicion = "10/10/2020",
                NombreCompleto = "Diego Alejandro Marquez Coronel",
                Sexo = Sexo.Hombre,
                Correo = "diegomarquez2008@outlook.com",
                Facultad = sistemas
            });
            list.Add(new Estudiante
            {
                TipoDocumento = TipoDocumento.cedula,
                IdEstudiante = "234232",
                FechaExpedicion = "10/10/2020",
                NombreCompleto = "Diego Alejandro Marquez Coronel",
                Sexo = Sexo.Hombre,
                Correo = "diegomarquez2008@outlook.com",
                Facultad = sistemas
            });
            return list;
        }
    }

    public class Estudiante
    {
        public TipoDocumento TipoDocumento { get; set; }
        public string IdEstudiante { get; set; }
        public string FechaExpedicion { get; set; }
        public string NombreCompleto { get; set; }
        public Sexo Sexo { get; set; }
        public string Correo { get; set; }
        public Facultad Facultad { get; set; }
    }
    public class Facultad
    {
        public string CodigoFacultad { get; set; }
        public string NombreFacultad { get; set; }
        public long NumeroProgramas { get; set; }
    }
    public class HorarioEstudiante
    {
        public string Codigo { get; set; }
        public Estudiante Estudiante { get; set; }
        public string CodigoMateria { get; set; }
        public string NombreAula { get; set; }
        public Dia Dia { get; set; }

    }
    public enum Dia
    {
        lunes,
        martes,
        miercoles,
        jueves,
        viernes
    }
    public enum TipoDocumento
    {
        cedula,
        ruc,
    }
    public enum Sexo
    {
        Hombre,
        Mujer
    }
}